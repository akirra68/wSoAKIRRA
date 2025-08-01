Imports DevExpress.DataAccess.Excel
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls
Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGrid
Imports SKK02OBJECTS.ucWSGridParentChild
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.MVVM
Imports DevExpress.Office.PInvoke
Imports DevExpress.XtraBars
Imports SKK50WAREHOUSE.ucWS24G301OUTBOUNDPKB
Imports SKK50WAREHOUSE.ucWS24IJ01SALE
Imports SKK01CORE

Public Class ucWS24HG01PICKING
    Implements IDisposable

    Property _prop01User As clsWSNasaUser
    Property _prop02TargetSKU As _pbEnumTargetSKU
    Property _prop03GridParentChild As ucWSGridParentChild
    Property _prop04Grid As ucWSGrid
    Property _prop05DataStock As DataTable
    Property _prop06FormPicking As ucWS24G301OUTBOUNDPKB
    Property _prop07FormSale As ucWS24IJ01SALE
    Property _prop08CustomerCode As String
    Property _prop09Customer As String
    Property _prop10TOPCode As String
    Property _prop11TOP As String
    Property _prop12ProsesSale As String

    Private pnProgressBarMaximum As Integer
    Private pnProgressBarCurrent As Integer

    Private pdtTableDisplay As DataTable
    Private objTableDisplay As clsWSNasaTemplateDataTiny

    Private pdtDataSKUPickingList As DataTable
    Private objDataSKUPickingList As clsWSNasaTemplateDataTiny

    Private objDataProdCodePickingList As DataTable
    Private objTempDataPickingList As DataTable

    Private objExecSQL As clsWSNasaHelper

    Public Enum _pbEnumTargetSKU
        _SKUPicking = 0
        _SKUSale = 1
    End Enum

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtTableDisplay = New DataTable
        objTableDisplay = New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtTableDisplay}
        objTableDisplay.dtInitsTABLETINY()

        pdtDataSKUPickingList = New DataTable
        objDataSKUPickingList = New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtDataSKUPickingList}
        objDataSKUPickingList.dtInitsTABLETINY()

        objDataProdCodePickingList = New DataTable
        objTempDataPickingList = New DataTable
        objExecSQL = New clsWSNasaHelper
    End Sub

    Protected Overrides Sub Finalize()
        pdtTableDisplay.Dispose()
        objTableDisplay.Dispose()

        pdtDataSKUPickingList.Dispose()
        objDataSKUPickingList.Dispose()

        objDataProdCodePickingList.Dispose()

        MyBase.Finalize()
    End Sub

    Private Sub ucWS24HG01PICKING_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _cm01BersihkanEntrian()

        If _prop02TargetSKU = _pbEnumTargetSKU._SKUPicking Then
            _lay01cSKUPicking.Text = "SKU Picking"
            _layJudulGroupHeader.Text = "Identity Picking"
            _layJudulGroupHeader.AppearanceGroup.BorderColor = Color.Orange

            _cm04InitFillNomorPickingList()
            _cm05InitTabelPackingList()

            mnuBarLanjutkanSimpanKeSuratJalan.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnuBarLanjutkanSimpanKeSuratJalan.EditValue = False
            _lay00NomorGJ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _lay00Generate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            EmptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            ' ===================== CREATED BY AKIRRA - 25/06/02 =====================
            ' menutup tombol save ketika belum ada progress
            'mnuBarSave.Enabled = False
            mnuBarLanjutkanSimpanKeSuratJalan.Enabled = False

            ' ============================================================================

        Else
            If _prop02TargetSKU = _pbEnumTargetSKU._SKUSale Then
                _lay01cSKUPicking.Text = "SKU Sale"
                With _layJudulGroupHeader
                    .Text = "Identity Sale"
                    .AppearanceGroup.BorderColor = Color.DodgerBlue
                End With


                _lay04cNomorPickingList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _laygdPickingDanSale.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _laygdProductCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

                Bar1.Visible = False
                mnuBarLanjutkanSimpanKeSuratJalan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                mnuBarLanjutkanSimpanKeSuratJalan.EditValue = False

                _lay00NomorGJ.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay00Generate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                EmptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _01cSKUPicking.Enabled = False


            End If
        End If

        With _03objProgress.Properties
            .Minimum = 0
            .ShowTitle = True
            .BorderStyle = BorderStyles.Simple
            .PercentView = True
            With .Appearance
                .Font = New Font("Courier New", 8, FontStyle.Bold, GraphicsUnit.Point)
            End With
        End With
    End Sub

#End Region

#Region "custom - method"

    Public Sub _cm01BersihkanEntrian()

        _01cSKUPicking.EditValue = ""
        _01cSKUPicking.Focus()

        _04cNomorPickingList.EditValue = ""
        _04cNomorPickingList.Properties.ReadOnly = False

        pnProgressBarCurrent = 0

        _gdProductCode._prop03pdtDataSourceGrid = Nothing
        _gdPickingDanSale._prop03pdtDataSourceGrid = Nothing

        objTableDisplay.prop_dtsTABLETINY.Clear()
        objDataSKUPickingList.prop_dtsTABLETINY.Clear()
        objDataProdCodePickingList.Clear()
    End Sub

    Private Function _cm02DataExcelToDataTable(ByVal excelDataSource As ExcelDataSource) As DataTable
        Dim list As IList = (CType(excelDataSource, IListSource)).GetList()
        Dim dataView As DevExpress.DataAccess.Native.Excel.DataView = CType(list, DevExpress.DataAccess.Native.Excel.DataView)
        Dim props As List(Of DevExpress.DataAccess.Native.Excel.ViewColumn) = dataView.Columns

        Dim table As New DataTable()
        For i As Integer = 0 To props.Count - 1
            Dim prop As PropertyDescriptor = props(i)
            table.Columns.Add(prop.Name, prop.PropertyType)
        Next i
        Dim values(props.Count - 1) As Object
        For Each item As DevExpress.DataAccess.Native.Excel.ViewRow In list
            For i As Integer = 0 To values.Length - 1
                values(i) = props(i).GetValue(item)
            Next i
            table.Rows.Add(values)
        Next item

        Return table
    End Function

    Private Sub _cm03ProsesFileXLS(ByVal prmcFullPathNameXLS As String)
        Cursor = Cursors.WaitCursor

        Dim myExcelSource As New ExcelDataSource()
        myExcelSource.FileName = prmcFullPathNameXLS

        Try
            Dim worksheetSettings As New ExcelWorksheetSettings("WS")
            myExcelSource.SourceOptions = New ExcelSourceOptions(worksheetSettings)
            myExcelSource.SourceOptions.SkipEmptyRows = False
            myExcelSource.SourceOptions.UseFirstRowAsHeader = True
            myExcelSource.Fill()
        Catch ex As Exception
            MessageBox.Show("The sheet named 'WS' could not be found. Please double-check the sheet name.", "Sheet Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            _02cFileXLS.Text = ""
            Cursor = Cursors.Default
            Return
        End Try

        Dim pdtDataSKU As New DataTable
        pdtDataSKU = _cm02DataExcelToDataTable(myExcelSource)

        With _03objProgress
            .Properties.Step = 1
            .Properties.PercentView = True
            .Properties.Maximum = pdtDataSKU.Rows.Count
            .Properties.Minimum = 0
        End With

        'Process SKU
        If _prop02TargetSKU = _pbEnumTargetSKU._SKUPicking Then
            Dim objPicking As _dlgUpdatePicking
            For Each dtRow As DataRow In pdtDataSKU.Rows
                objPicking = AddressOf _prop03GridParentChild._ivk24UpdateProgressPickingBRJ
                objPicking(dtRow(0).ToString)

                _03objProgress.PerformStep()
                _03objProgress.Update()
            Next
        Else
            If _prop02TargetSKU = _pbEnumTargetSKU._SKUSale Then
                Dim objEntrySale As __dlgEntryDataSale
                For Each dtRow As DataRow In pdtDataSKU.Rows
                    objEntrySale = AddressOf _prop04Grid._ivkEntrySKUSale
                    If _prop12ProsesSale = "CSG" Then
                        If pdtDataSKU.Columns.Count <> 4 Then
                            MsgBox("Ensure the Excel template is correct and matches the required target sales format.❗❕", vbExclamation, _prop01User._UserProp01cTitle)
                            _02cFileXLS.EditValue = ""
                            Exit For
                        End If
                        objEntrySale.Invoke(dtRow(0).ToString, _prop05DataStock, dtRow(1).ToString, _prop08CustomerCode, _prop09Customer, dtRow(2).ToString, dtRow(3).ToString)
                    Else
                        If pdtDataSKU.Columns.Count <> 6 Then
                            MsgBox("Ensure the Excel template is correct and matches the required target sales format.❗❕", vbExclamation, _prop01User._UserProp01cTitle)
                            _02cFileXLS.EditValue = ""
                            Exit For
                        End If
                        objEntrySale.Invoke(dtRow(0).ToString, _prop05DataStock, dtRow(1).ToString, dtRow(2).ToString, dtRow(3).ToString, dtRow(4).ToString, dtRow(5).ToString)
                    End If

                    _03objProgress.PerformStep()
                    _03objProgress.Update()
                Next
            End If
        End If

        Cursor = Cursors.Default
    End Sub
    Private Sub _cm04InitFillNomorPickingList()
        Dim dtTemp As New DataTable
        Dim dvView As DataView = New DataView(_prop05DataStock)
        Dim pcKolomData = New String() {"f26String", "f17String", "f18String"}

        dtTemp = dvView.ToTable(True, pcKolomData)

        _04cNomorPickingList.Clear()

        Dim Coll As ComboBoxItemCollection = _04cNomorPickingList.Properties.Items
        Coll.BeginUpdate()
        Try
            For Each dtRow As DataRow In dtTemp.Rows
                Coll.Add(dtRow("f26String"))
            Next
        Finally
            Coll.EndUpdate()
        End Try

        _04cNomorPickingList.SelectedIndex = 0
        _01cSKUPicking.Focus()
    End Sub

    Private Sub _cm05InitTabelPackingList()

        With _gdPickingDanSale
            ._prop01User = _prop01User
            ._prop02TargetGrid = _pbEnumTargetGrid._WSOutbound5051PickingListSKU
            ._prop03pdtDataSourceGrid = objTableDisplay.prop_dtsTABLETINY
        End With
        _gdPickingDanSale.__pbWSGrid01InitGrid()
        _gdPickingDanSale.__pbWSGrid03DisplayGrid()
    End Sub

    Private Sub _cm06DisplayTabelPickingList(ByVal prmcSKU As String, ByVal prmbTarget As Boolean)
        Const defaultDate As String = "'3000-01-01'"
        Dim pcProductCode As String = ""
        Dim noOrder As String = ""
        Dim pnPcs As Integer = 0
        Dim isValidPick As Boolean = False

        ' Cari semua noOrder dengan ProductCode yang sesuai dengan SKU ini
        Dim allOrdersWithThisSKU As DataRow() = objDataSKUPickingList.prop_dtsTABLETINY.Select("k03String = '" & prmcSKU & "'")

        ' Cari order yang belum terpenuhi (belum 100%)
        For Each dtRow As DataRow In allOrdersWithThisSKU
            Dim orderStatusRows() As DataRow = objDataProdCodePickingList.Select("k01String = '" & dtRow("k01String") & "' AND k02String = '" & dtRow("k02String") & "'")

            If orderStatusRows.Length > 0 Then
                Dim currentProgress As Integer = Integer.Parse(orderStatusRows(0)("f02Double"))
                Dim totalPcs As Integer = orderStatusRows(0)("f01SmallInt")
                Dim progressPercentage As Integer = (currentProgress / totalPcs) * 100

                If progressPercentage < 100 Then
                    pcProductCode = dtRow("k02String")
                    noOrder = dtRow("k01String")
                    pnPcs = dtRow("f01SmallInt")
                    isValidPick = True
                    Exit For
                End If
            End If
        Next

        If Not isValidPick Then
            MessageBox.Show("The order has been fulfilled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' display jika valid
        For Each dtRow As DataRow In objDataSKUPickingList.prop_dtsTABLETINY.Select("k03String = '" & prmcSKU & "' AND k01String = '" & noOrder & "' AND k02String = '" & pcProductCode & "'")
            objTableDisplay.dtAddNewsTABLETINY(dtRow("k01String"), dtRow("k02String"), dtRow("k03String"),
                          "", "", "", "", "",
                          0, dtRow("f01SmallInt"), 0, dtRow("f01Double"), 0.0, 0.0,
                          "3000-01-01", "3000-01-01", "3000-01-01",
                          "", "", "", "", "")

            ' Insert ke wsTABLE271
            If prmbTarget = False Then
                Try
                    Dim pcSQLInsert As String = "INSERT INTO [dbo].[wsTABLE271] " &
                                            "VALUES ('" & _04cNomorPickingList.EditValue.ToString.Replace("'", "''") & "','" & dtRow("k01String").ToString.Replace("'", "''") & "','" & dtRow("k02String").ToString.Replace("'", "''") & "'" &
                                            ",'" & dtRow("k03String").ToString.Replace("'", "''") & "','','','',''" &
                                            ",0," & dtRow("f01SmallInt") & ",0" &
                                            "," & dtRow("f01Double") & ",0.0,0.0" &
                                            "," & defaultDate & "," & defaultDate & ",GETDATE()" &
                                            ",'','','','','')"

                    Dim pnHasilInsert As Integer = objExecSQL._pbWSNasaHelperExec01SQLScript(
                        _prop01User._UserProp08TargetNetwork,
                        clsWSNasaHelper._pnmDatabaseName.WS,
                        pcSQLInsert)
                Catch ex As Exception
                    MessageBox.Show("Failed insert wsTABLE271: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Next
        _gdPickingDanSale.Refresh()

        ' Update progress picking
        Dim pnJmlAwal As Integer = 0
        For Each dtRow In objDataProdCodePickingList.Select("k01String = '" & noOrder & "' AND k02String = '" & pcProductCode & "'")
            pnJmlAwal = dtRow("f02Double")
            Dim totalPcs As Integer = dtRow("f01SmallInt")

            If (pnJmlAwal + pnPcs) > totalPcs Then
                pnPcs = totalPcs - pnJmlAwal
            End If

            dtRow("k03String") = (pnJmlAwal + pnPcs).ToString & " of " & totalPcs
            dtRow("f01Int") = ((pnJmlAwal + pnPcs) / totalPcs) * 100
            dtRow("f02Double") += pnPcs
        Next
        objDataProdCodePickingList.AcceptChanges()
        _gdProductCode.Refresh()

        pnProgressBarCurrent += 1
        _03objProgress.Position = pnProgressBarCurrent

    End Sub


    Private Function _cm07ValidasiDataPickingList(ByVal prmcSKU As String) As Boolean
        Dim plHasil As Boolean = True
        Dim pcProductCode As String = ""

        'cek sku : ada/tidak ada
        For Each dtRow As DataRow In objDataSKUPickingList.prop_dtsTABLETINY.Select(" k03String = '" & prmcSKU & "'")
            pcProductCode = dtRow("k02String")
        Next

        If pcProductCode = "" Then
            plHasil = False
            MsgBox("SKU ~'" & prmcSKU & "'~ NOT AVAILABLE in stock WAREHOUSE.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            _01cSKUPicking.SelectAll()
            SendKeys.Send("{DELETE}")
        Else

            'cek sku : double entry/tidak
            If plHasil Then
                For Each dtRow As DataRow In objTableDisplay.prop_dtsTABLETINY.Select(" k03String = '" & prmcSKU & "'")
                    plHasil = False
                    MsgBox("SKU ~'" & prmcSKU & "'~ ALREADY PICKED.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
                    _01cSKUPicking.SelectAll()
                    SendKeys.Send("{DELETE}")
                Next
            End If
        End If

        Return plHasil
    End Function

#End Region

#Region "control - event"

    Private Sub _01cSKUPicking_EditValueChanged(sender As Object, e As EventArgs) Handles _01cSKUPicking.EditValueChanged

        If Not String.IsNullOrEmpty(_01cSKUPicking.EditValue) Then
            If _04cNomorPickingList.EditValue = Nothing AndAlso _prop02TargetSKU = _pbEnumTargetSKU._SKUPicking Then
                MsgBox("Please select the Picking List number first. 🙏🏻")

                _01cSKUPicking.SelectAll()
                SendKeys.Send("{DELETE}")
                Exit Sub
            End If
            If _01cSKUPicking.EditValue.ToString.Length >= 7 Then

                If _prop02TargetSKU = _pbEnumTargetSKU._SKUPicking Then
                    If _cm07ValidasiDataPickingList(_01cSKUPicking.EditValue) Then
                        Dim objPicking As _dlgUpdatePicking = AddressOf _prop03GridParentChild._ivk24UpdateProgressPickingBRJ
                        If Not objPicking(_01cSKUPicking.EditValue.ToString) Then
                            _cm06DisplayTabelPickingList(_01cSKUPicking.EditValue, False)

                            _01cSKUPicking.SelectAll()
                            SendKeys.Send("{DELETE}")
                        End If
                    End If
                Else
                    If _prop02TargetSKU = _pbEnumTargetSKU._SKUSale Then

                        Dim objEntrySale As __dlgEntryDataSale = AddressOf _prop04Grid._ivkEntrySKUSale
                        objEntrySale.Invoke(_01cSKUPicking.EditValue.ToString, _prop05DataStock, _00cNoGJ.EditValue, _prop08CustomerCode, _prop09Customer, _prop10TOPCode, _prop11TOP)

                        _01cSKUPicking.SelectAll()
                        SendKeys.Send("{DELETE}")
                    End If
                End If
            Else
                MsgBox("Maaf ... SKU '" & _01cSKUPicking.EditValue & "' TIDAK ADA...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)

                _01cSKUPicking.EditValue = ""
                _01cSKUPicking.Focus()
            End If

        End If
    End Sub

    Private Sub _02cFileXLS_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _02cFileXLS.ButtonClick
        If e.Button.Kind = ButtonPredefines.Ellipsis Then
            Dim ofd As OpenFileDialog = New OpenFileDialog()
            ofd.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            ofd.Title = "Please choose file XLSX | " & _prop01User._UserProp01cTitle

            If ofd.ShowDialog() = DialogResult.OK Then
                Dim pcNamaFile As String = ofd.FileName

                _02cFileXLS.EditValue = pcNamaFile

                _cm03ProsesFileXLS(pcNamaFile)
            End If
        End If
    End Sub

    ' ===================== CREATED BY AKIRRA & AGA - 25/06/02 =====================
    ' ager ketika picking sudah 100%, maka tombol lgsg surat jalan baru akan muncul dan aktif
    Private Sub _03objProgress_EditValueChanged(sender As Object, e As EventArgs) Handles _03objProgress.EditValueChanged
        Dim progressValue As Double = 0

        If Double.TryParse(Convert.ToString(_03objProgress.EditValue), progressValue) AndAlso progressValue = pnProgressBarMaximum Then
            ' mnuBarSave.Enabled = True
            mnuBarLanjutkanSimpanKeSuratJalan.Enabled = True
            mnuBarLanjutkanSimpanKeSuratJalan.EditValue = True

        Else
            'mnuBarSave.Enabled = False
            mnuBarLanjutkanSimpanKeSuratJalan.Enabled = False
        End If
    End Sub
    ' ===========================================================================

    Private Sub _03objProgress_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs) Handles _03objProgress.CustomDisplayText
        e.DisplayText = $"{e.Value}  ({pnProgressBarCurrent} of {pnProgressBarMaximum})"
    End Sub

    Private Sub _04cNomorPickingList_EditValueChanged(sender As Object, e As EventArgs) Handles _04cNomorPickingList.EditValueChanged
        Dim nomorPicking = Convert.ToString(_04cNomorPickingList.EditValue)?.Trim()

        If String.IsNullOrEmpty(nomorPicking) Then Exit Sub

        Cursor = Cursors.WaitCursor
        _04cNomorPickingList.Properties.ReadOnly = True

        Try
            ' Reset & init
            pnProgressBarCurrent = 0
            pnProgressBarMaximum = 0
            Dim pnJmlSKU As Integer = 0

            ' Set picking list & dapatkan jumlah SKU
            _prop03GridParentChild._ivk28SetPickingList(nomorPicking, pnJmlSKU)

            pnProgressBarMaximum = pnJmlSKU
            _03objProgress.Properties.Maximum = pnJmlSKU

            ' Clear data lama
            objDataSKUPickingList.prop_dtsTABLETINY.Clear()
            objTableDisplay.prop_dtsTABLETINY.Clear()
            objDataProdCodePickingList.Clear()
            objTempDataPickingList.Clear()

            ' Load data SKU Picking List
            objDataSKUPickingList.prop_dtsTABLETINY = _prop03GridParentChild._cm28GetDataPrepareForPickingList(nomorPicking)

            ' Load data Product Code Picking List
            objDataProdCodePickingList = _prop03GridParentChild._cm28GetDataProductCodeForPickingList(nomorPicking)

            ' Update kolom k03String
            For Each dtRow As DataRow In objDataProdCodePickingList.Rows
                dtRow("k03String") = $"0 of {dtRow("f01SmallInt")}"
            Next

            ' Setup & tampilkan grid Product Code
            With _gdProductCode
                ._prop01User = _prop01User
                ._prop02TargetGrid = _pbEnumTargetGrid._WSOutbound5051PickingListProdCode
                ._prop03pdtDataSourceGrid = objDataProdCodePickingList
                .__pbWSGrid01InitGrid()
                .__pbWSGrid03DisplayGrid()
                .Refresh()
                .__pbShowIndicatorOff()
            End With

            _gdPickingDanSale.__pbShowIndicatorOff()

            ' Load data Temp Picking List
            Using objStock As New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
                objTempDataPickingList = objStock._pb28GetDataTempPicking(nomorPicking)
            End Using

            ' Update progress picking
            Dim objPicking As _dlgUpdatePicking = AddressOf _prop03GridParentChild._ivk24UpdateProgressPickingBRJ
            For Each skuRow As DataRow In objTempDataPickingList.Rows
                If Not objPicking.Invoke(skuRow("f01String").ToString()) Then
                    _cm06DisplayTabelPickingList(skuRow("f01String").ToString(), True)
                End If
            Next

            _01cSKUPicking.Focus()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub mnuBarSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBarSave.ItemClick
        If _prop02TargetSKU = _pbEnumTargetSKU._SKUPicking Then
            pnProgressBarMaximum = 0
            Dim pnJmlSKU As Integer = 0

            Dim objPickingList As _dlgPreparePickingList = AddressOf _prop03GridParentChild._ivk28SetPickingList
            objPickingList.Invoke(_04cNomorPickingList.EditValue, pnJmlSKU)

            pnProgressBarMaximum = pnJmlSKU

            ' If pnProgressBarCurrent = pnProgressBarMaximum Then
            Dim objPicking As __dlgSavePickingBRJIncludeSJ = AddressOf _prop06FormPicking._ivkSavePickingDanSuratJalan
            objPicking.Invoke(mnuBarLanjutkanSimpanKeSuratJalan.EditValue)
            'Else
            '    MessageBox.Show("Please complete all SKU items before proceeding.", "Incomplete SKU", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Else
            If _prop02TargetSKU = _pbEnumTargetSKU._SKUSale Then
                Dim objSalesSelling As __dlgSaveData = AddressOf _prop07FormSale._ivkSaveSalesSelling
                objSalesSelling.Invoke
            End If
        End If
    End Sub

    Private Sub _btnGenerate_Click(sender As Object, e As EventArgs) Handles _btnGenerate.Click
        If _00cNoGJ.EditValue = "" Then
            MsgBox("Please enter the No.GJ field first.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            _00cNoGJ.Focus()
            _01cSKUPicking.Enabled = False
            Exit Sub
        End If

        If (_prop12ProsesSale = "CSG" AndAlso _prop10TOPCode = "") Then
            MsgBox("Don't forget to fill in the TOP field.👍🦾", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
            Exit Sub
        ElseIf (_prop12ProsesSale <> "CSG" AndAlso (_prop08CustomerCode = "" OrElse _prop10TOPCode = "")) Then
            MsgBox("Don't forget to fill in both Customer and TOP fields.👍🦾", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
            Exit Sub
        End If

        _01cSKUPicking.Enabled = True

    End Sub

    'Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
    '    _gdPickingDanSale.__pbWSGrid04CreateSettingColumnWidth("gdPickingDanSale")
    '    _gdProductCode.__pbWSGrid04CreateSettingColumnWidth("gdProductCode")

    '    MsgBox("done")
    'End Sub

#End Region

End Class

'Partial Public Class PickingListInfo
'    Private _cNomorPickingList As String
'    Private _cKodePicker As String
'    Private _cNamaPicker As String

'    Public Sub New(ByVal prmcNomorPickingList As String, ByVal prmcKodePicker As String, ByVal prmcNamaPicker As String)
'        _cNomorPickingList = prmcNomorPickingList
'        _cKodePicker = prmcKodePicker
'        _cNamaPicker = prmcNamaPicker
'    End Sub

'End Class
