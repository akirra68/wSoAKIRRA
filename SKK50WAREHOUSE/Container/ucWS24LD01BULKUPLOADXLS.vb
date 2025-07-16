Imports System.ComponentModel
Imports System.Windows.Controls
Imports DevExpress
Imports DevExpress.DataAccess.Excel
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucWS24LD01BULKUPLOADXLS
    Implements IDisposable

    Property _prop01User As clsWSNasaUser
    Property _prop02TargetBULKUPLOADXLS As _pbEnumTargetBULKUPLOADXLS
    Property _prop03DataTableParameter As DataTable = Nothing

    Private pdtTemplateXLS As DataTable
    Private objTemplateXLS As clsWSNasaTemplateDataLargePlus

    Private pdtDataFinalLargePlus As DataTable
    Private objDataFinalLargePlus As clsWSNasaTemplateDataLargePlus

    Private pdtDataFinalTiny As DataTable
    Private objDataFinalTiny As clsWSNasaTemplateDataTiny

    Private pdtOtherDataToSaveFinal As DataTable

    Public Enum _pbEnumTargetBULKUPLOADXLS
        _INBOUNDReturCustomer = 0            'IRTC
        _TRANSAKSIRepairWarehouse = 1        'TRPWS
        _TRANSAKSILeburWarehouse = 2         'TLBWS
        _DISTRIBUTIONOrderFG = 3             'ORDER
        _INBOUNDRepairWarehouse = 4          'IRPWS
    End Enum

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        pdtTemplateXLS = New DataTable
        objTemplateXLS = New clsWSNasaTemplateDataLargePlus With {.prop_dtsTABLELARGEPLUS = pdtTemplateXLS}
        objTemplateXLS.dtInitsTABLELARGEPLUS()

        pdtDataFinalLargePlus = New DataTable
        objDataFinalLargePlus = New clsWSNasaTemplateDataLargePlus With {.prop_dtsTABLELARGEPLUS = pdtDataFinalLargePlus}
        objDataFinalLargePlus.dtInitsTABLELARGEPLUS()

        pdtDataFinalTiny = New DataTable
        objDataFinalTiny = New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtDataFinalTiny}
        objDataFinalTiny.dtInitsTABLETINY()

        pdtOtherDataToSaveFinal = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        pdtTemplateXLS.Dispose()
        objTemplateXLS.Dispose()

        pdtDataFinalLargePlus.Dispose()
        objDataFinalLargePlus.Dispose()

        pdtDataFinalTiny.Dispose()
        objDataFinalTiny.Dispose()

        pdtOtherDataToSaveFinal.Dispose()

        MyBase.Finalize()
    End Sub

    Private Sub ucWS24LD01BULKUPLOADXLS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar2.OptionsBar.DrawDragBorder = False
        Bar2.BarItemHorzIndent = 10

        _bar03Save.Visibility = BarItemVisibility.Never

        CType(_bar01FileXLS.Edit, RepositoryItemButtonEdit).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        AddHandler RepositoryItemButtonEdit1.ButtonClick, AddressOf uploadXlsx_ButtonClick
    End Sub

#End Region

#Region "custom - method"

    ' ===================== CREATED BY AKIRRA - 25/05/27 =====================
    ' sebuah fungsi untuk convert datasource dari excel ke datatable.
    Public Function ToDataTable(ByVal excelDataSource As ExcelDataSource) As DataTable
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
    ' ======================================================================

    Private Sub _cm01BersihkanEntrian()
        TabPane1.SelectedPage = _TabNav01BulkUploadData

        _bar01FileXLS.EditValue = ""

        _gdBulkUploadData.DataSource = Nothing

        objTemplateXLS.prop_dtsTABLELARGEPLUS.Clear()

        objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Clear()
        objDataFinalTiny.prop_dtsTABLETINY.Clear()

        pdtOtherDataToSaveFinal.Clear()

        _bar03Save.Visibility = BarItemVisibility.Never
    End Sub

    Private Sub _cm02ReadFileXLS(ByVal prmcFullPathNameXLS As String)
        Cursor = Cursors.WaitCursor

        Dim pcNameWorksheet As String = ""
        Select Case _prop02TargetBULKUPLOADXLS
            Case _pbEnumTargetBULKUPLOADXLS._INBOUNDReturCustomer
                pcNameWorksheet = "IRTC"     'InboundReturCustomer
            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse
                pcNameWorksheet = "TRPWS"    'TransaksiRepairWarehouse
            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse
                pcNameWorksheet = "TLBWS"    'TransaksiLeburWarehouse
            Case _pbEnumTargetBULKUPLOADXLS._DISTRIBUTIONOrderFG
                pcNameWorksheet = "ORDER"    'Outbound Order / PKB (Perintah Kirim Barang)
            Case _pbEnumTargetBULKUPLOADXLS._INBOUNDRepairWarehouse
                pcNameWorksheet = "IRPWS"    'InboundRepairWarehouse
            Case Else
        End Select

        Dim myExcelSource As New ExcelDataSource()
        myExcelSource.FileName = prmcFullPathNameXLS
        Dim worksheetSettings As New ExcelWorksheetSettings(pcNameWorksheet)
        myExcelSource.SourceOptions = New ExcelSourceOptions(worksheetSettings)
        myExcelSource.SourceOptions.SkipEmptyRows = False
        myExcelSource.SourceOptions.UseFirstRowAsHeader = True
        myExcelSource.Fill()

        _gdBulkUploadData.DataSource = myExcelSource


        Select Case _prop02TargetBULKUPLOADXLS
            Case _pbEnumTargetBULKUPLOADXLS._INBOUNDReturCustomer
                _cm10CopyXLSGridToDataTable_IRTC()

            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse,
                 _pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse
                _cm16SyncronizeDataTransaksi_TRPWS_TLBWS()

            Case _pbEnumTargetBULKUPLOADXLS._DISTRIBUTIONOrderFG
                ' ===================== CREATED BY AKIRRA - 25/05/27 =====================
                ' untuk mengecek jika pada data excel terdapat row yang kosong/blank.
                For i As Integer = 0 To ToDataTable(myExcelSource).Rows.Count - 1
                    Dim row As DataRow = ToDataTable(myExcelSource).Rows(i)
                    If String.IsNullOrWhiteSpace(row("ProductCode").ToString()) OrElse  'cek Product Code (kolom pertama)
                String.IsNullOrWhiteSpace(row("Qty").ToString()) Then           'cek Qty (kolom kedua)

                        MsgBox("There is empty/null/blank data in row " & (i + 1) & "." & vbCrLf & vbCrLf &
                       "Please recheck the XLSX file..", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)

                        _gdBulkUploadData.DataSource = Nothing
                        Exit For
                        Exit Sub
                    End If
                Next
                ' =========================================================================

                _cm22SynchronizeDataStock22_ORDER()

            Case _pbEnumTargetBULKUPLOADXLS._INBOUNDRepairWarehouse
                _cm40CopyXLSGridToDataTable_IRPWS()

            Case Else
        End Select

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm03GetPatternSKUReparasiRetur(ByRef prmcPatternSKU As String, ByRef prmnNomorTerakhir As Int32,
                                                ByVal prmcKodeGroup As String, ByVal prmnJmlInc As Int32)
        Dim pdtHasil As New DataTable
        Dim pnYear As Integer = Year(Today.Date)
        Dim pnMonth As Integer = Month(Today.Date)

        Cursor = Cursors.WaitCursor

        Using objSKU As New clsWSNasaSelect4AllProsesMaster() With {._prop01User = _prop01User, ._prop02String = prmcKodeGroup}
            pdtHasil = objSKU._pb52NewSKUReparasiRetur(pnYear, pnMonth, prmnJmlInc)
        End Using

        If pdtHasil.Rows.Count > 0 Then
            For Each dtRow As DataRow In pdtHasil.Rows
                prmcPatternSKU = dtRow("k13String")
                prmnNomorTerakhir = dtRow("f10Int")
            Next
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function _cm04GetNoDocument(ByVal prmcTargetTransaksi As String) As String
        Dim pcIDNoDoc As String = ""

        Select Case prmcTargetTransaksi
            Case "5021"        '"Inhouse-Produksi"
                pcIDNoDoc = "WSNOINBOUNDPRODUKSI"
            Case "5022"        '"Inhouse-Chain"
                pcIDNoDoc = "WSNOINBOUNDCHAIN"
            Case "5023"        '"Repair-Warehouse"
                pcIDNoDoc = "WSNOINBOUNDREPWS"
            Case "5024"        '"Repair-Customer"
                pcIDNoDoc = "WSNOINBOUNDREPCUST"
            Case "5025"        '"Retur-Customer"
                pcIDNoDoc = "WSNOINBOUNDRETCUST"
            Case "5026"        '"External"
                pcIDNoDoc = "WSNOINBOUNDEXTERNAL"
            Case "5027"        '"BRJ-Pinjaman-Marketing"
                pcIDNoDoc = "WSNOINBOUNDMKT"

            Case "50303"    'Reparasi Warehouse
                pcIDNoDoc = "WSREPAIRWAREHOUSE"
            Case "50305"    'Lebur
                pcIDNoDoc = "WSLEBUR"
        End Select

        Cursor = Cursors.WaitCursor

        Dim pcNoDokumen As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = pcIDNoDoc}
            pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()
        End Using

        Cursor = Cursors.Default

        Return pcNoDokumen
    End Function

    Private Function _cm05ConvertPersenKadarToInteger(ByVal prmcPersenKadar As String) As Integer
        Dim pcHasil As Integer = 0

        If prmcPersenKadar <> "" Then
            Dim pcTemp As String = prmcPersenKadar.Substring(0, prmcPersenKadar.Length - 1).Trim()    '75.50%
            Select Case pcTemp.Length
                Case 2      '75
                    pcTemp = pcTemp + "0"

                Case 3      '75.
                    pcTemp = prmcPersenKadar.Substring(0, 2) + "0"

                Case 4      '75.5
                    pcTemp = prmcPersenKadar.Substring(0, 2) + prmcPersenKadar.Substring(3, 1)

                Case 5      '75.50
                    pcTemp = prmcPersenKadar.Substring(0, 2) + prmcPersenKadar.Substring(3, 1)

            End Select

            pcHasil = CInt(pcTemp)
        End If

        Return pcHasil
    End Function

    Private Sub _cm06GetPatternSKUNonCitrix(ByRef prmcPatternSKU As String, ByRef prmnNomorTerakhir As Int32,
                                            ByVal prmcKodeGroup As String, ByVal prmnJmlInc As Int32)
        Dim pdtHasil As New DataTable
        Dim pnYear As Integer = Year(Today.Date)
        Dim pnMonth As Integer = Month(Today.Date)

        Cursor = Cursors.WaitCursor

        Using objSKU As New clsWSNasaSelect4AllProsesMaster() With {._prop01User = _prop01User,
                                                                    ._prop02String = prmcKodeGroup}
            pdtHasil = objSKU._pb52NewSKUReparasiRetur(pnYear, pnMonth, prmnJmlInc)
        End Using

        If pdtHasil.Rows.Count > 0 Then
            For Each dtRow As DataRow In pdtHasil.Rows
                prmcPatternSKU = dtRow("k13String")
                prmnNomorTerakhir = dtRow("f10Int")
            Next
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function _cm07GetNoDocument() As String
        Dim pcIDNoDoc As String = ""
        pcIDNoDoc = "WSNOINBOUNDREPWS"

        Cursor = Cursors.WaitCursor

        Dim pcNoDokumen As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = pcIDNoDoc}
            pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()
        End Using

        Cursor = Cursors.Default

        Return pcNoDokumen
    End Function

#End Region

#Region "***** INBOUND - RETUR CUSTOMER (IRTC) *****"

    Private Sub _cm10CopyXLSGridToDataTable_IRTC()
        Dim pcKodeCustomer As String = ""
        Dim pcNamaCustomer As String = ""
        Dim pcSKUReturCustomer As String = ""
        Dim pcKondisi As String = ""    '(BAIK/KURANGBAIK/CACATPRODUKSI/RONGSOK)
        Dim pcTujuan As String = ""     '(WAREHOUSE/REPARASI/LEBUR)
        Dim pcKodeSBox As String = ""
        Dim pcNamaSBox As String = ""
        Dim pnPcs As Integer = 0
        Dim pnBeratGross As Double = 0.0
        Dim pnBeratNett As Double = 0.0
        Dim pcAlasan As String = ""     '(50-Char)
        Dim pcSINGLE As String = ""
        Dim pcSALE As String = ""
        'Dim pcNewSKU As String = ""
        'Dim pcNoDoc As String = ""

        'Dim prmcPatternSKU As String = ""
        'Dim prmnNomorTerakhir As Integer = 0
        'Dim pnJmlRecReturCust As Integer = GridView1.RowCount

        '_cm03GetPatternSKUReparasiRetur(prmcPatternSKU, prmnNomorTerakhir, "WSNEWSKURETURCUSTOMER", pnJmlRecReturCust)
        'Dim pnNoAwal As Integer = (prmnNomorTerakhir - pnJmlRecReturCust)

        'Dim objCustForDoc = New Dictionary(Of String, String)
        'For i = 0 To GridView1.RowCount - 1
        '    If Not objCustForDoc.ContainsKey(GridView1.GetRowCellValue(i, GridView1.Columns(0))) Then
        '        pcNoDoc = ""
        '        pcNoDoc = _cm04GetNoDocument("5025")    '"Retur-Customer"

        '        objCustForDoc.Add(GridView1.GetRowCellValue(i, GridView1.Columns(0)), pcNoDoc)
        '    End If
        'Next

        objTemplateXLS.prop_dtsTABLELARGEPLUS.Clear()

        ' ===================== CREATED BY AKIRRA - 25/07/01 =====================
        ' added TRY CATCH to catch error and convert it to MSGBOX.

        Dim vsErrMsg As String = ""
        For i = 0 To GridView1.RowCount - 1
            Try
                pcKodeCustomer = "" : pcNamaCustomer = "" : pcSKUReturCustomer = "" : pcKondisi = "" : pcTujuan = ""
                pcKodeSBox = "" : pcNamaSBox = "" : pnPcs = 0 : pnBeratGross = 0.0 : pnBeratNett = 0.0
                pcAlasan = "" : pcSINGLE = "" : pcSALE = ""

                'pcKodeCustomer = GridView1.GetRowCellValue(i, GridView1.Columns(0))
                'pcNamaCustomer = GridView1.GetRowCellValue(i, GridView1.Columns(1))
                'pcSKUReturCustomer = GridView1.GetRowCellValue(i, GridView1.Columns(2))
                'pcKondisi = GridView1.GetRowCellValue(i, GridView1.Columns(3))
                'pcTujuan = GridView1.GetRowCellValue(i, GridView1.Columns(4))
                'pcKodeSBox = GridView1.GetRowCellValue(i, GridView1.Columns(5))
                'pcNamaSBox = GridView1.GetRowCellValue(i, GridView1.Columns(6))
                'pnPcs = GridView1.GetRowCellValue(i, GridView1.Columns(7))
                'pnBeratGross = GridView1.GetRowCellValue(i, GridView1.Columns(8))
                'pnBeratNett = GridView1.GetRowCellValue(i, GridView1.Columns(9))
                'pcAlasan = GridView1.GetRowCellValue(i, GridView1.Columns(10))

                pcSKUReturCustomer = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns(0))).ToUpper()
                pcNamaSBox = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns(1))).ToUpper()
                pcSALE = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns(2))).ToUpper()

                pnPcs = Convert.ToInt32(GridView1.GetRowCellValue(i, GridView1.Columns(3)))
                pnBeratGross = Convert.ToDouble(GridView1.GetRowCellValue(i, GridView1.Columns(4)))
                pnBeratNett = Convert.ToDouble(GridView1.GetRowCellValue(i, GridView1.Columns(5)))

                pcTujuan = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns(6))).ToUpper()
                pcAlasan = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns(7)))

            Catch ex As Exception
                vsErrMsg &= "- Row " & (i + 1).ToString() & ": " & ex.Message & vbCrLf
            End Try

            If vsErrMsg <> "" Then
                MsgBox("An error occurred at row(s):" & vbCrLf & vsErrMsg, MsgBoxStyle.Critical, "XLSX File Error | " & _prop01User._UserProp01cTitle)

                Exit Sub
            End If

            ' =======================================================================


            'If pcTujuan = "WAREHOUSE" Then
            '    pcSALE = "FORSALE"
            'Else
            '    pcSALE = "NOTFORSALE"
            'End If

            If pnPcs = 1 Then
                pcSINGLE = "SINGLE"
            Else
                If pnPcs > 1 Then
                    pcSINGLE = "BUNDLE"
                End If
            End If

            'If objCustForDoc.ContainsKey(pcKodeCustomer) Then
            '    pcNoDoc = ""
            '    pcNoDoc = objCustForDoc(pcKodeCustomer)
            'End If

            'pnNoAwal = pnNoAwal + 1   ' sb di awali dgn nol, maka perlu INC di DEPAN.

            'pcNewSKU = ""
            'pcNewSKU = prmcPatternSKU + pnNoAwal.ToString("0000")

            'objTemplateXLS.dtAddNewsTABLELARGEPLUS("", pcNewSKU, "",
            '        "", "", "VND04", "RETUR", "", "", "", "", "", "",
            '        "", "", "", "", "", "", "", "", pcKodeSBox, pcNamaSBox,
            '        pcKodeCustomer, pcNamaCustomer, pcAlasan, "", "", "", "", "", "", "",
            '        "", "", "", pcNoDoc, pcSINGLE, pcSKUReturCustomer, "", pcTujuan, pcKondisi, "",
            '        "", "", pcSALE, "", "", "", "", "", "", "",
            '        "", "", "", "", "",
            '        0, 0, pnPcs, 0, 0, 0, 0,
            '        pnBeratGross, pnBeratNett, 0.0, 0.0, 0.0,
            '        "3000-01-01", "3000-01-01", Today.Date, "3000-01-01", "3000-01-01",
            '        Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
            '        _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            'objTemplateXLS.dtAddNewsTABLELARGEPLUS("", "", "",
            '        "", "", "VND04", "RETUR", "", "", "", "", "", "",
            '        "", "", "", "", "", "", "", "", pcKodeSBox, pcNamaSBox,
            '        pcKodeCustomer, pcNamaCustomer, pcAlasan, "", "", "", "", "", "", "",
            '        "", "", "", "", pcSINGLE, pcSKUReturCustomer, "", pcTujuan, pcKondisi, "",
            '        "", "", pcSALE, "", "", "", "", "", "", "",
            '        "", "", "", "", "",
            '        0, 0, pnPcs, 0, 0, 0, 0,
            '        pnBeratGross, pnBeratNett, 0.0, 0.0, 0.0,
            '        "3000-01-01", "3000-01-01", Today.Date, "3000-01-01", "3000-01-01",
            '        Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
            '        _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            objTemplateXLS.dtAddNewsTABLELARGEPLUS("", "", "",
                   "", "", "VND04", "RETUR", "", "", "", "", "", "",
                   "", "", "", "", "", "", "", "", "", pcNamaSBox,
                   "", "", pcAlasan, "", "", "", "", "", "", "",
                   "", "", "", "", pcSINGLE, pcSKUReturCustomer, "", pcTujuan, "", "",
                   "", "", pcSALE, "", "", "", "", "", "", "",
                   "", "", "", "", "",
                   0, 0, pnPcs, 0, 0, 0, 0,
                   pnBeratGross, pnBeratNett, 0.0, 0.0, 0.0,
                   "3000-01-01", "3000-01-01", Today.Date, "3000-01-01", "3000-01-01",
                   Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                   _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)


        Next

        _cm11SyncronizeDataReturCustomer()
    End Sub

    Private Sub _cm11SyncronizeDataReturCustomer()
        If objTemplateXLS.prop_dtsTABLELARGEPLUS.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Clear()
            Using objSyncronize As New clsWSNasaHelper
                objDataFinalLargePlus.prop_dtsTABLELARGEPLUS = objSyncronize._pbWSNasaHelperExec05SPSELEPassTblTypeToDataTable(
                                                           _prop01User._UserProp08TargetNetwork,
                                                           clsWSNasaHelper._pnmDatabaseName.WS, "spWSInboundXLS01IRCSyncronizeData",
                                                           "@DataUpload", objTemplateXLS.prop_dtsTABLELARGEPLUS)
            End Using

            With _gdResult
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInboundFromXLS10122024ReturCustomer
                ._prop03pdtDataSourceGrid = objDataFinalLargePlus.prop_dtsTABLELARGEPLUS
            End With
            _gdResult.__pbWSGrid01InitGrid()
            _gdResult.__pbWSGrid03DisplayGrid()

            TabPane1.SelectedPage = _TabNav02Result

            Dim pcPesan As String = ""

            _bar03Save.Visibility = BarItemVisibility.Always
            For Each dtRow As DataRow In objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Rows
                If dtRow("f01String") = "" Or dtRow("f09String") = "" Or dtRow("f15String") = "" Then
                    _bar03Save.Visibility = BarItemVisibility.Never
                    pcPesan = "Maaf ... ada data RETUR CUSTOMER yg TIDAK ADA OMSET-nya ..."
                End If

                If dtRow("k01String") <> "SOLD" Then
                    _bar03Save.Visibility = BarItemVisibility.Never
                    pcPesan = "Maaf ... ada data RETUR CUSTOMER yg STATUS-nya BUKAN SOLD ..."
                End If

                If dtRow("f19String") = "" Then
                    _bar03Save.Visibility = BarItemVisibility.Never
                    pcPesan = "Maaf ... Data BOX belum terdaftar, silahkan tambahkan BOX dahulu ..."
                End If

                If dtRow("f38String") <> "WAREHOUSE" AndAlso dtRow("f38String") <> "REPAIR" Then
                    _bar03Save.Visibility = BarItemVisibility.Never
                    pcPesan = "Maaf ... Tujuan hanya bisa ke 'WAREHOUSE' / 'REPAIR' ..."
                End If

                If dtRow("f43String") <> "FORSALE" AndAlso dtRow("f43String") <> "NOTFORSALE" Then
                    _bar03Save.Visibility = BarItemVisibility.Never
                    pcPesan = "Maaf ... Status hanya bisa 'FORSALE' / 'NOTFORSALE' ..."
                End If

                If dtRow("f23String") = "" Then
                    _bar03Save.Visibility = BarItemVisibility.Never
                    pcPesan = "Maaf ... Alasan Retur harus diisi ..."
                End If
            Next
            Cursor = Cursors.Default

            If pcPesan = "" Then
                If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Boolean") Then
                    objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Boolean")
                End If
                If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Int") Then
                    objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Int")
                End If
                If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Boolean01") Then
                    objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Boolean01")
                End If
                If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Int01") Then
                    objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Int01")
                End If
                If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Boolean02") Then
                    objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Boolean02")
                End If
                If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Int02") Then
                    objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Int02")
                End If
                If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Contains("f01Memo") Then
                    objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Columns.Remove("f01Memo")
                End If
            Else
                MsgBox(pcPesan, vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Maaf ... Data Masih ... Kosong ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm12PrepareSaveReturCustomer()
        Dim pcNewSKU As String = ""
        Dim pcNoDoc As String = ""
        Dim vsNoDocRepair As String = _cm04GetNoDocument("50303")

        Dim prmcPatternSKU As String = ""
        Dim prmnNomorTerakhir As Integer = 0
        Dim pnJmlRecReturCust As Integer = GridView1.RowCount

        _cm03GetPatternSKUReparasiRetur(prmcPatternSKU, prmnNomorTerakhir, "WSNEWSKURETURCUSTOMER", pnJmlRecReturCust)
        Dim pnNoAwal As Integer = (prmnNomorTerakhir - pnJmlRecReturCust)

        Dim objCustForDoc = New Dictionary(Of String, String)
        For i = 0 To GridView1.RowCount - 1
            If Not objCustForDoc.ContainsKey(GridView1.GetRowCellValue(i, GridView1.Columns(0))) Then
                pcNoDoc = ""
                pcNoDoc = _cm04GetNoDocument("5025")    '"Retur-Customer"

                objCustForDoc.Add(GridView1.GetRowCellValue(i, GridView1.Columns(0)), pcNoDoc)
            End If
        Next

        Dim pcKodeCustomer As String = ""
        For Each dtRow As DataRow In objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Rows
            pcKodeCustomer = ""
            pcKodeCustomer = dtRow("f21String")

            If objCustForDoc.ContainsKey(pcKodeCustomer) Then
                pcNoDoc = ""
                pcNoDoc = objCustForDoc(pcKodeCustomer)
            End If

            pnNoAwal = pnNoAwal + 1   ' sb di awali dgn nol, maka perlu INC di DEPAN.

            pcNewSKU = ""
            pcNewSKU = prmcPatternSKU + pnNoAwal.ToString("0000")

            dtRow("k02String") = pcNewSKU
            dtRow("f34String") = pcNoDoc

            ' created by AKIRRA 
            ' utk assign no doc repair jika tujuan adalah REPAIR.
            dtRow("f55String") = ""
            If dtRow("f38String") = "REPAIR" Then
                dtRow("f55String") = vsNoDocRepair
            End If
        Next
        objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.AcceptChanges()

    End Sub

    Private Sub _cm13ProsesSaveReturCustomer()
        If objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Rows.Count > 0 Then
            _cm12PrepareSaveReturCustomer()

            Dim pnJmlRec As Integer = 0
            Using objNasa = New clsWSNasaHelper
                pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(_prop01User._UserProp08TargetNetwork,
                                                                clsWSNasaHelper._pnmDatabaseName.WS, 2, "spWSInbound5025ReturCustomer",
                                                                "@tpDataForSaving", objDataFinalLargePlus.prop_dtsTABLELARGEPLUS)
            End Using

            If pnJmlRec > 0 Then
                With _gdResult
                    ._prop01User = _prop01User
                    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInboundFromXLS10122024ReturCustomer
                    ._prop03pdtDataSourceGrid = objDataFinalLargePlus.prop_dtsTABLELARGEPLUS
                End With
                _gdResult.__pbWSGrid01InitGrid()
                _gdResult.__pbWSGrid03DisplayGrid()

                TabPane1.SelectedPage = _TabNav02Result

                MsgBox("Proses Simpan Data INBOUND (RETUR-CUSTOMER) ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            Else
                MsgBox("Maaf ... Proses Simpan Data INBOUND (RETUR-CUSTOMER) ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        End If
    End Sub

    Private Sub _cm14SaveReturCustomer()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin akan menyimpan data RETUR CUSTOMER ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm13ProsesSaveReturCustomer()

            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "***** TRANSAKSI - REPAIR WAREHOUSE (TRPWS) - LEBUR (TLBWS) *****"
    Private Sub _cm15CopyXLSGridToDataTable_TRPWS_TLBWS()
        Dim pcSKURepairLeburWS As String = ""
        Dim pcAlasan As String = ""
        Dim pcNoDocRepairLeburWS As String = ""
        Select Case _prop02TargetBULKUPLOADXLS
            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse
                pcNoDocRepairLeburWS = _cm04GetNoDocument("50303")

            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse
                pcNoDocRepairLeburWS = _cm04GetNoDocument("50305")

            Case Else
        End Select

        objDataFinalTiny.prop_dtsTABLETINY.Clear()

        For i = 0 To GridView1.RowCount - 1
            pcSKURepairLeburWS = "" : pcAlasan = ""

            pcSKURepairLeburWS = GridView1.GetRowCellValue(i, GridView1.Columns(0))
            pcAlasan = GridView1.GetRowCellValue(i, GridView1.Columns(1))

            objDataFinalTiny.dtAddNewsTABLETINY("", pcSKURepairLeburWS, "",
                           "", "", pcNoDocRepairLeburWS, pcAlasan, "",
                           0, 0, 0, 0.0, 0.0, 0.0,
                           "3000-01-01", "3000-01-01", "3000-01-01",
                           _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                           _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress,
                           _prop01User._UserProp06IPPublicAddress)
        Next

    End Sub

    Private Sub _cm16SyncronizeDataTransaksi_TRPWS_TLBWS()
        Dim pcJudul As String = ""
        Select Case _prop02TargetBULKUPLOADXLS
            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse
                pcJudul = "REPARASI WAREHOUSE"

            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse
                pcJudul = "LEBUR"

            Case Else
        End Select

        _cm15CopyXLSGridToDataTable_TRPWS_TLBWS()

        If objDataFinalTiny.prop_dtsTABLETINY.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Clear()
            Using objSyncronize As New clsWSNasaHelper
                objDataFinalLargePlus.prop_dtsTABLELARGEPLUS = objSyncronize._pbWSNasaHelperExec05SPSELEPassTblTypeToDataTable(
                                                       _prop01User._UserProp08TargetNetwork,
                                                       clsWSNasaHelper._pnmDatabaseName.WS, "spWSTransaksi00XLSSyncronizeData",
                                                       "@tpTEMPLATETINY", objDataFinalTiny.prop_dtsTABLETINY)
            End Using
            Cursor = Cursors.Default

            Dim pcPesan As String = ""
            For Each dtRow As DataRow In objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Rows
                dtRow("f40String") = dtRow("AlasanXLS")

                If IsDBNull(dtRow("k03String")) Then
                    pcPesan = "Maaf .. ada data yg statusnya 'BUKAN STOCK' ..."
                End If
            Next
            objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.AcceptChanges()

            If Not pcPesan = "" Then
                _bar03Save.Visibility = BarItemVisibility.Never
                MsgBox(pcPesan, vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            Else
                _bar03Save.Visibility = BarItemVisibility.Always
            End If

            _gdResult.__pbWSGrid02ClearGrid()
            With _gdResult
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSTransaksi03ReparasiLebur
                ._prop03pdtDataSourceGrid = objDataFinalLargePlus.prop_dtsTABLELARGEPLUS
            End With
            _gdResult.__pbWSGrid01InitGrid()
            _gdResult.__pbWSGrid03DisplayGrid()

            TabPane1.SelectedPage = _TabNav02Result
        Else
            _bar03Save.Visibility = BarItemVisibility.Never
            MsgBox("Maaf ... TIDAK ADA data " & pcJudul & " yg akan disimpan.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If


        ' ===================== CREATED BY AKIRRA - 25/06/30 =====================
        ' assign f51String (MasterSKU) to f05String REPAIR.
        For Each tinyRow As DataRow In objDataFinalTiny.prop_dtsTABLETINY.Rows
            Dim matchingRows() As DataRow = objDataFinalLargePlus.prop_dtsTABLELARGEPLUS.Select("k03String = '" & tinyRow("k02String").ToString().Replace("'", "''") & "'")

            If matchingRows.Length > 0 Then
                Dim largePlusRow As DataRow = matchingRows(0)

                tinyRow("f05String") = largePlusRow("f51String")
            End If
        Next
        ' =========================================================================

        objDataFinalTiny.prop_dtsTABLETINY.AcceptChanges()
    End Sub

    Private Sub _cm17ProsesSaveDataTransaksi_TRPWS_TLBWS()
        Dim pcNamaSP As String = ""
        Select Case _prop02TargetBULKUPLOADXLS
            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse
                pcNamaSP = "spWSTransaksi02ReparasiWS"

            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse
                pcNamaSP = "spWSTransaksi03Lebur"

            Case Else
        End Select

        Dim objNasa As New clsWSNasaHelper
        Dim pnJmlRec As Integer = 0
        pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                            _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                            2, pcNamaSP, "@tpDataForSaving", objDataFinalTiny.prop_dtsTABLETINY)

        If pnJmlRec > 0 Then
            MsgBox("Proses Simpan Data ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        Else
            MsgBox("Proses Simpan Data ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm18SaveDataTransaksi_TRPWS_TLBWS()
        Dim pcJudul As String = ""
        Select Case _prop02TargetBULKUPLOADXLS
            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse
                pcJudul = "REPARASI WAREHOUSE"

            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse
                pcJudul = "LEBUR"

            Case Else
        End Select

        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin akan menyimpan data " & pcJudul & " ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm17ProsesSaveDataTransaksi_TRPWS_TLBWS()

            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "***** ORDER FG - via BULK UPLOAD XLS (ORDER) *****"

    Private Function _cm21CopyXLSGridToDataTable_ORDER() As DataTable
        Dim pcRuleStock As String = ""

        For Each dtRow As DataRow In _prop03DataTableParameter.Rows()
            pcRuleStock = dtRow("f08String").ToString
            Exit For
        Next

        Dim pdtListOfData As New DataTable
        Dim objListOfData As New clsWSNasaTemplateListOfData With {.prop_dtLISTOFDATA = pdtListOfData}
        objListOfData.dtInitLISTOFDATA()

        Dim pcKodeProductCode As String = ""
        Dim pnQty As Integer = 0
        Dim pdETA As Date = Nothing

        For i = 0 To GridView1.RowCount - 1
            pcKodeProductCode = "" : pnQty = 0 : pdETA = Nothing

            pcKodeProductCode = GridView1.GetRowCellValue(i, GridView1.Columns(0))
            pnQty = GridView1.GetRowCellValue(i, GridView1.Columns(1))
            pdETA = GridView1.GetRowCellValue(i, GridView1.Columns(2))

            objListOfData.dtAddNewISTOFDATA(pcKodeProductCode,
                                            pcRuleStock, "", "", "", "",
                                            pnQty, 0, 0.0, 0.0, pdETA, "3000-01-01")
        Next

        Return objListOfData.prop_dtLISTOFDATA
    End Function

    Private Sub _cm22SynchronizeDataStock22_ORDER()
        Cursor = Cursors.WaitCursor

        Dim pdtDataOrder As New DataTable
        pdtDataOrder = _cm21CopyXLSGridToDataTable_ORDER()

        pdtOtherDataToSaveFinal.Clear()
        Using objNasaHelper As clsWSNasaHelper = New clsWSNasaHelper
            pdtOtherDataToSaveFinal = objNasaHelper._pbWSNasaHelperExec06SPSELEPassTblTypeToDataTable03(
                                        _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                        "spWS30SyncronizeORDERViaBulkUploadXLS",
                                        "@tpLISTOFDATA", pdtDataOrder, "@tpTEMPLATESMALL", _prop03DataTableParameter)
        End Using

        Cursor = Cursors.Default

        If pdtOtherDataToSaveFinal.Rows.Count > 0 Then
            With _gdResult
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSDistribusiFGPKBOrderViaBulkUploadXLS
                ._prop03pdtDataSourceGrid = pdtOtherDataToSaveFinal
            End With
            _gdResult.__pbWSGrid01InitGrid()
            _gdResult.__pbWSGrid03DisplayGrid()

            TabPane1.SelectedPage = _TabNav02Result

            Dim _isValidDataToSave As Boolean = True

            For Each dtRow As DataRow In pdtOtherDataToSaveFinal.Rows
                If dtRow("f01String") = "" Or dtRow("f03String") = "" Then  'kadar & brand
                    _isValidDataToSave = False
                    Exit For
                End If

                If dtRow("f01SmallInt") < dtRow("f01Int") Then
                    MsgBox("There is a 'Product Code' with insufficient 'Stock Qty'", vbOKOnly + vbExclamation, "Attention | " & _prop01User._UserProp01cTitle)
                End If
            Next

            ' ===================== CREATED BY AKIRRA - 25/04/27 =====================
            ' mengecek Product Code (k02String) duplikat.
            Dim duplicateExists As Boolean = pdtOtherDataToSaveFinal.AsEnumerable() _
            .GroupBy(Function(r) r.Field(Of String)("k02String")) _
            .Any(Function(g) g.Count() > 1)

            If duplicateExists Then
                'MsgBox("There are duplicate Product Code." & vbCrLf & vbCrLf &
                '       "Please recheck the excel file..", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)

                _isValidDataToSave = False
            End If
            ' ========================================================================

            If _isValidDataToSave Then
                _bar03Save.Visibility = BarItemVisibility.Always
            Else
                _bar03Save.Visibility = BarItemVisibility.Never

                MsgBox("There is invalid data in this XLSX file." & vbCrLf & vbCrLf &
                       "Please recheck the XLSX file..", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        End If
    End Sub

    Private Function _cm23CreateDataDistinc() As DataTable
        Dim pcKolomData As String() = Nothing
        pcKolomData = New String() {"f01String", "f03String"}

        Dim dtTemp As New DataTable
        Dim dvView As DataView = New DataView(pdtOtherDataToSaveFinal)

        dtTemp = dvView.ToTable(True, pcKolomData)

        Return dtTemp
    End Function

    Private Function _cm24GetNoDocOrderViaBulkUploadXLS() As String
        Dim pcTargetNoDoc As String = ""
        Dim pcTargetTransaksi As String = ""
        Dim pcJenisOrder As String = ""

        For Each dtRow As DataRow In _prop03DataTableParameter.Rows
            pcTargetTransaksi = dtRow("k01String")
            pcJenisOrder = dtRow("f07String")
        Next

        Select Case pcTargetTransaksi
            Case "5061"    'Perintah Kirim FG : CUSTOMER
                If pcJenisOrder = "CO" Then
                    pcTargetNoDoc = "WSPKBCUSTOMER"
                Else
                    pcTargetNoDoc = "WSPKBCUSTOMERPO"
                End If

            Case "5062"    'Perintah Kirim FG : KAE
                pcTargetNoDoc = "WSPKBKAE"
            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                pcTargetNoDoc = "WSPKBCONSIGMENT"
            Case "5064"    'Perintah Kirim FG : MARKETING
                'pcTargetNoDoc = "WSPKBMARKETING"

                ' ===================== UPDATED BY AKIRRA - 250410 =====================
                ' memisah nodoc antara jenis order PINJAMAN (MO*) dan GIVEAWAY (GO*) pada MARKETING.

                If pcJenisOrder = "PINJAMAN" Then
                    pcTargetNoDoc = "WSPKBMARKETING"
                Else
                    pcTargetNoDoc = "WSPKBMARKETINGGO"
                End If

                ' ======================================================================
            Case "5065"    'Perintah Kirim FG : INTERNAL
                pcTargetNoDoc = "WSPKBINTERNAL"
            Case "5066"    'Perintah Kirim FG : PAMERAN
                pcTargetNoDoc = "WSPKBPAMERAN"
        End Select

        Dim pcNoDokumen As String = ""
        Dim objNoDoc As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                  ._prop02String = pcTargetNoDoc}
        pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()

        Return pcNoDokumen
    End Function

    Private Sub _cm25FinalisasiToSave_ORDER()
        Cursor = Cursors.WaitCursor

        Dim pcNoDocOrder As String = ""
        Dim pcKodeBrand As String = ""
        Dim pcKodeKadar As String = ""

        Dim pdtFinalDataTemp As New DataTable
        pdtFinalDataTemp = _cm23CreateDataDistinc()

        For Each dtRow As DataRow In pdtFinalDataTemp.Rows
            pcNoDocOrder = "" : pcKodeBrand = "" : pcKodeKadar = ""

            pcKodeBrand = dtRow("f01String")
            pcKodeKadar = dtRow("f03String")
            pcNoDocOrder = _cm24GetNoDocOrderViaBulkUploadXLS()

            For Each dtRow01 As DataRow In pdtOtherDataToSaveFinal.Rows
                If pcKodeBrand = dtRow01("f01String") And pcKodeKadar = dtRow01("f03String") Then
                    dtRow01("k03String") = pcNoDocOrder
                End If
            Next
        Next
        pdtOtherDataToSaveFinal.AcceptChanges()

        For Each dtRow01 As DataRow In pdtOtherDataToSaveFinal.Rows
            'dtRow01("f01Double") = (dtRow01("f01Double") / dtRow01("f01SmallInt")) * dtRow01("f01Int")
            If dtRow01("f01SmallInt") <> 0 Then
                dtRow01("f01Double") = (dtRow01("f01Double") / dtRow01("f01SmallInt")) * dtRow01("f01Int")
            Else
                dtRow01("f01Double") = 0
            End If
            dtRow01("f01SmallInt") = dtRow01("f01Int")
            dtRow01("f01Int") = 0

            ' ===================== CREATED BY AKIRRA - 25/06/17 =====================
            ' klasifikasi jenis order untuk APPROVAL.

            'Select Case dtRow01("f20String")
            '    Case "5062", "5064", "5065", "5066"    'KAE("5062"),MARKETING("5064"),INTERNAL("5065"),PAMERAN("5066")
            '        dtRow01("f09String") = "000001"
            '        dtRow01("f10String") = "ADMIN"
            '        dtRow01("f03Date") = Today.Date
            'End Select

            ' HANYA APPROVAL SALES
            Select Case dtRow01("f20String")
                Case "5062"    'KAE("5062")
                    dtRow01("f07String") = "ADMIN"
                    dtRow01("f08String") = "ADMIN"
                    dtRow01("f02Date") = Today.Date
            End Select

            ' HANYA APPROVAL FINANCE
            Select Case dtRow01("f20String")
                Case "5064", "5065"    'MARKETING("5064"),INTERNAL("5065")
                    dtRow01("f09String") = "ADMIN"
                    dtRow01("f10String") = "ADMIN"
                    dtRow01("f03Date") = Today.Date
            End Select
            ' ========================================================================

            dtRow01("f23String") = "PENDING"
            dtRow01("f24String") = dtRow01("f20String")
            dtRow01("f25String") = dtRow01("f21String")
            dtRow01("f30String") = "[BUP] " & dtRow01("f30String")

            dtRow01("f01IDUser") = _prop01User._UserProp02cUserID
            dtRow01("f01NamaUser") = _prop01User._UserProp03cUserName
            dtRow01("f01ComputerName") = _prop01User._UserProp04ComputerName
            dtRow01("f02ComputerIPPrivate") = _prop01User._UserProp05IPLocalAddress
            dtRow01("f03ComputerIPPublic") = _prop01User._UserProp06IPPublicAddress
        Next
        pdtOtherDataToSaveFinal.AcceptChanges()

        If pdtOtherDataToSaveFinal.Columns.Contains("k00Boolean") Then
            pdtOtherDataToSaveFinal.Columns.Remove("k00Boolean")
        End If
        If pdtOtherDataToSaveFinal.Columns.Contains("k00Int") Then
            pdtOtherDataToSaveFinal.Columns.Remove("k00Int")
        End If
        If pdtOtherDataToSaveFinal.Columns.Contains("k00Boolean01") Then
            pdtOtherDataToSaveFinal.Columns.Remove("k00Boolean01")
        End If
        If pdtOtherDataToSaveFinal.Columns.Contains("k00Int01") Then
            pdtOtherDataToSaveFinal.Columns.Remove("k00Int01")
        End If
        If pdtOtherDataToSaveFinal.Columns.Contains("k00Boolean02") Then
            pdtOtherDataToSaveFinal.Columns.Remove("k00Boolean02")
        End If
        If pdtOtherDataToSaveFinal.Columns.Contains("k00Int02") Then
            pdtOtherDataToSaveFinal.Columns.Remove("k00Int02")
        End If
        If pdtOtherDataToSaveFinal.Columns.Contains("f01Memo") Then
            pdtOtherDataToSaveFinal.Columns.Remove("f01Memo")
        End If

        Dim objNasa As New clsWSNasaHelper
        Dim pnJmlRec As Integer = 0
        pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                    2, "spWSTABLE30Save", "@tpDataForSaving30", pdtOtherDataToSaveFinal)

        Cursor = Cursors.Default

        If pnJmlRec > 0 Then
            pdtOtherDataToSaveFinal.Clear()
            MsgBox("Proses Simpan Data ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        Else
            MsgBox("Proses Simpan Data ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    Private Sub _cm26SaveOrderViaBulkUploadXLS()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin akan menyimpan data ORDER ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm25FinalisasiToSave_ORDER()

            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "***** INBOUND - (BULK) REPAIR WAREHOUSE CUSTOMER (IRPWS) *****"

    Private Sub _cm40CopyXLSGridToDataTable_IRPWS()
        Dim pcSKURepair As String = ""
        Dim pnBeratJadi As Double = 0.0
        Dim pcProductCode As String = ""
        Dim pcSBOXCode As String = ""

        Dim pdtTiny As New DataTable
        Dim objTiny As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtTiny}
        objTiny.dtInitsTABLETINY()

        For i = 0 To GridView1.RowCount - 1
            pcSKURepair = "" : pnBeratJadi = 0.0 : pcProductCode = "" : pcSBOXCode = ""

            pcSKURepair = GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString
            pnBeratJadi = CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(1)))

            If (Not IsDBNull(GridView1.GetRowCellValue(i, GridView1.Columns(2)))) Or (GridView1.GetRowCellValue(i, GridView1.Columns(2)) <> "") Then
                pcProductCode = GridView1.GetRowCellValue(i, GridView1.Columns(2))
            End If

            pcSBOXCode = GridView1.GetRowCellValue(i, GridView1.Columns(3))

            objTiny.dtAddNewsTABLETINY(pcSKURepair, pcProductCode, "",
                                       pcSBOXCode, "", "", "", "",
                                       0, 0, 0, pnBeratJadi, 0.0, 0.0,
                                       "3000-01-01", "3000-01-01", "3000-01-01",
                                       _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                       _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
        Next

        Dim pdtSynczData As New DataTable
        Dim objSynczData As New clsWSNasaTemplateDataLargePlus With {.prop_dtsTABLELARGEPLUS = pdtSynczData}
        objSynczData.dtInitsTABLELARGEPLUS()

        Using objGroupByPKBOrder As clsWSNasaHelper = New clsWSNasaHelper
            objSynczData.prop_dtsTABLELARGEPLUS = objGroupByPKBOrder._pbWSNasaHelperExec06SPSELEPassTblTypeToDataTable03(
                                                  _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                                  "spWSInboundXLS02IRPWSSyncronizeData", "@tpDataProses", objTiny.prop_dtsTABLETINY)
        End Using

        If objSynczData.prop_dtsTABLELARGEPLUS.Rows.Count > 0 Then

            objTemplateXLS.prop_dtsTABLELARGEPLUS.Clear()

            For Each dtRowRpr As DataRow In objSynczData.prop_dtsTABLELARGEPLUS.Rows
                objTemplateXLS.dtAddNewsTABLELARGEPLUS("", "", "",
                    dtRowRpr("f01String"), "", "VND03", "REPAIR", "", "", dtRowRpr("f07String"), dtRowRpr("f08String"), dtRowRpr("f09String"), dtRowRpr("f10String"),
                    dtRowRpr("f11String"), dtRowRpr("f12String"), dtRowRpr("f13String"), dtRowRpr("f14String"), dtRowRpr("f15String"), dtRowRpr("f16String"), "", "", dtRowRpr("f41String"), dtRowRpr("f42String"),
                    "", "", "", "", "", "", "", "", "", "",
                    "50303", "REPAIR-WAREHOUSE", dtRowRpr("f50String"), "", dtRowRpr("f35String"), dtRowRpr("f38String"), dtRowRpr("f37String"), "WAREHOUSE", "", "",
                    "", "", dtRowRpr("f43String"), "", "", "", "", "", "", dtRowRpr("f52String"),
                    dtRowRpr("f51String"), "", "", "", "",
                    0, dtRowRpr("f01SmallInt"),
                    dtRowRpr("f01SmallInt"), 0, 0, _cm05ConvertPersenKadarToInteger(dtRowRpr("f10String")), 0,
                    dtRowRpr("f01Double"), dtRowRpr("f01Double"), dtRowRpr("f01Double"), 0.0, 0.0,
                    dtRowRpr("f01Date"), dtRowRpr("f02Date"), Today.Date, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            Next

            With _gdResult
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInboundFromXLS11022025ReparasiWarehouse
                ._prop03pdtDataSourceGrid = objTemplateXLS.prop_dtsTABLELARGEPLUS
            End With
            _gdResult.__pbWSGrid01InitGrid()
            _gdResult.__pbWSGrid03DisplayGrid()

            TabPane1.SelectedPage = _TabNav02Result
            _bar03Save.Visibility = BarItemVisibility.Always

            Dim pcPesan As String = ""

            _bar03Save.Visibility = BarItemVisibility.Always
            For Each dtRow As DataRow In objTemplateXLS.prop_dtsTABLELARGEPLUS.Rows
                If dtRow("f10String") = "" Or dtRow("f16String") = "" Or dtRow("f12String") = "" Or dtRow("f02Double") = 0.0 Then
                    _bar03Save.Visibility = BarItemVisibility.Never
                    pcPesan = "Maaf ... ada data INBOUND REAPAIR WAREHOUSE ... yg masih salah ...."
                End If
            Next

            If pcPesan = "" Then
                If objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Boolean") Then
                    objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Boolean")
                End If
                If objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Int") Then
                    objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Int")
                End If
                If objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Boolean01") Then
                    objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Boolean01")
                End If
                If objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Int01") Then
                    objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Int01")
                End If
                If objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Boolean02") Then
                    objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Boolean02")
                End If
                If objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Contains("k00Int02") Then
                    objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Remove("k00Int02")
                End If
                If objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Contains("f01Memo") Then
                    objTemplateXLS.prop_dtsTABLELARGEPLUS.Columns.Remove("f01Memo")
                End If
            Else
                MsgBox(pcPesan, vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If

        Else
            MsgBox("Maaf ... data masih kosong...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    Private Sub _cm41SaveInboundRepairWSViaBulkUploadXLS()

        If objTemplateXLS.prop_dtsTABLELARGEPLUS.Rows.Count > 0 Then
            Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk menyimpan data Hasil Reparasi WH ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

            If plYes = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim prmcPatternSKU As String = "" : Dim prmnNomorTerakhir As Integer = 0
                Dim pcSKUNew As String = "" : Dim pcNoDOInboundRepWS As String = ""

                pcNoDOInboundRepWS = _cm07GetNoDocument()
                _cm06GetPatternSKUNonCitrix(prmcPatternSKU, prmnNomorTerakhir, "WSNEWSKUREPARASIWS", objTemplateXLS.prop_dtsTABLELARGEPLUS.Rows.Count)

                For Each dtRow As DataRow In objTemplateXLS.prop_dtsTABLELARGEPLUS.Rows
                    prmnNomorTerakhir = prmnNomorTerakhir + 1

                    pcSKUNew = ""
                    pcSKUNew = prmcPatternSKU + prmnNomorTerakhir.ToString("0000")

                    dtRow("k02String") = pcSKUNew
                    dtRow("f34String") = pcNoDOInboundRepWS
                    dtRow("f50String") = "OK | " & dtRow("f50String")
                Next
                objTemplateXLS.prop_dtsTABLELARGEPLUS.AcceptChanges()

                Dim pnJmlRec As Integer = 0
                Using objNasa As clsWSNasaHelper = New clsWSNasaHelper()
                    pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                       _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                       2, "spWSInbound5023ReparasiWS", "@tpDataForSaving", objTemplateXLS.prop_dtsTABLELARGEPLUS)
                End Using

                Cursor = Cursors.Default

                If pnJmlRec > 0 Then
                    MsgBox("Proses Simpan Data INBOUND Hasil Reparasi WH ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
                    _cm01BersihkanEntrian()
                Else
                    MsgBox("Maaf ... Proses Simpan Data INBOUND Hasil Reparasi WH ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
                End If
            Else
                MsgBox("Maaf ... Proses Simpan Data INBOUND Hasil Reparasi WH ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Maaf ... Data INBOUND Hasil Reparasi WH... TIDAK ADA...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

#End Region

#Region "control - event"

    Private Sub _bar01FileXLS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles _bar01FileXLS.ItemClick
        Using ofd As New OpenFileDialog()
            ofd.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            ofd.Title = "Please choose file XLSX | " & _prop01User._UserProp01cTitle

            If ofd.ShowDialog() = DialogResult.OK Then
                _bar01FileXLS.EditValue = ofd.FileName

                _cm02ReadFileXLS(ofd.FileName)
            End If
        End Using
    End Sub

    Private Sub uploadXlsx_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Using ofd As New OpenFileDialog()
            ofd.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            ofd.Title = "Please choose file XLSX | " & _prop01User._UserProp01cTitle

            If ofd.ShowDialog() = DialogResult.OK Then
                _bar01FileXLS.EditValue = ofd.FileName

                _cm02ReadFileXLS(ofd.FileName)
            End If
        End Using
    End Sub

    Private Sub _bar02Clear_ItemClick(sender As Object, e As ItemClickEventArgs) Handles _bar02Clear.ItemClick
        _cm01BersihkanEntrian()
    End Sub

    Private Sub _bar03Save_ItemClick(sender As Object, e As ItemClickEventArgs) Handles _bar03Save.ItemClick
        Select Case _prop02TargetBULKUPLOADXLS
            Case _pbEnumTargetBULKUPLOADXLS._DISTRIBUTIONOrderFG
                _cm26SaveOrderViaBulkUploadXLS()

            Case _pbEnumTargetBULKUPLOADXLS._INBOUNDReturCustomer
                _cm14SaveReturCustomer()

            Case _pbEnumTargetBULKUPLOADXLS._INBOUNDRepairWarehouse
                _cm41SaveInboundRepairWSViaBulkUploadXLS()

            Case _pbEnumTargetBULKUPLOADXLS._TRANSAKSIRepairWarehouse,
                 _pbEnumTargetBULKUPLOADXLS._TRANSAKSILeburWarehouse
                _cm18SaveDataTransaksi_TRPWS_TLBWS()

        End Select
    End Sub

#End Region

End Class

'******************************************
'******** KOLOM BULK UPLOAD - XLS *********
'******** WORKSHEET NAME : "IRTC" *********
'******************************************
'*******   Inbound Retur Customer   *******
'******************************************
'KodeCustomer
'NamaCustomer
'SKU-ReturCustomer
'Kondisi (BAIK/KURANGBAIK/CACATPRODUKSI/RONGSOK)
'Tujuan  (WAREHOUSE/REPARASI/LEBUR)
'KodeSBox
'NamaSBox
'Pcs
'BeratGross
'BeratNett
'Alasan (50-Char)
'********************************************

'********************************************
'******** KOLOM BULK UPLOAD - XLS   *********
'******** WORKSHEET NAME : "TRPWS"  *********
'********************************************
'******   Transaksi Repair Warehouse   ******
'********************************************
'SKURepair
'Alasan (50-Char)
'********************************************

'********************************************
'******** KOLOM BULK UPLOAD - XLS   *********
'******** WORKSHEET NAME : "ORDER"  *********
'********************************************
'******     Outbound Order / PKB       ******
'********************************************
'ProductCode
'Qty
'ETA
'********************************************

'select * from wsTABLE22 where f21String in ('PD190039-007
','BC220881-001') and f06String = '5040101'