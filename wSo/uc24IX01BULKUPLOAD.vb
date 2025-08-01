Imports System.ComponentModel
Imports DevExpress.DataAccess.Excel
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen
Imports SKK02OBJECTS

Public Class uc24IX01BULKUPLOAD
    Implements IDisposable
    Public Property _objUserPropWS As clsWSNasaUser
    Public Property _enmTarget As targetBulkUpload

    Private objProses As clsWSNasaSelect4AllProsesMaster

    Private pdtXLSXtemp As DataTable
    Private pdtXLSX As DataTable
    Private pdtSAVE20 As DataTable
    Private pdtSAVE201 As DataTable
    Private pdtSAVE21 As DataTable
    Private pdtSAVE29 As DataTable
    Private pdtSAVE31 As DataTable

    Private objTemplateXLSMediumExt As clsWSNasaTemplateDataMediumExt
    Private objTemplateXLSTiny As clsWSNasaTemplateDataTiny

    Private objTpSave201 As clsWSNasaTemplateDataMediumExt
    Private objTpSave21 As clsWSNasaTemplateDataLargePlus

    Public Enum targetBulkUpload
        _BUP01Stock = 0
        _BUP02Sold = 1

    End Enum

    '1.0.0 = FIRST TIME CREATED (23-09-2024)
    '1.1.0 = ADA BEBERAPA REVISI DATA PADA KOLOM (28-09-2024)
    '1.2.0 = PERUBAHAN PADA PROSES UPDATE KE WSTABLE31 (02-10-2024)
    '1.2.1 = MENAMBAHKAN FITUR VALIDASI JIKA ADA DATA NULL YANG TERUPLOAD (03-10-2024)
    '1.3.0 = MERUBAH DATA YANG DISIMPAN KE F01DATE MENJADI TGL. DIBUAT (04-10-2024)
    '1.4.0 = MEREVISI SP UNTUK SAVE DATA SLOC, SBOX DAN STATUS (07-10-2024)
    '1.4.1 = MERUBAH WAKTU TIMEOUT SAAT UPLOAD MENJADI 5 MENIT YANG SEMULA 30 DETIK (14-10-2024)
    '2.0.1 = MELAKUKAN PERBAIKAN-PERBAIKAN KECIL AGAR PROGRAM LEBIH EFISIEN. (21-10-2024)
    '3.0.0 = MEMBUAT FITUR BARU YAITU FORM UNTUK UPLOAD DATA SO SOLD. (25-10-2024)
    '3.1.0 = PENYESUAIAN UNTUK UPLOAD DATA SO SOLD. MENGUBAH DATABASE KE WS24 DAN BEBERAPA PENYESUAIAN LAIN. (04-11-2024)
    '4.0.1 = UPDATED TO .NET 8.0 (10-03-2025)
    '4.0.2 = MENGUBAH PARAMETER NAMA KOMPUTER DAN MENAMBAKAN TARGET NETWORK STAGING (23-05-2025)

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        objProses = New clsWSNasaSelect4AllProsesMaster

        objTemplateXLSMediumExt = New clsWSNasaTemplateDataMediumExt With {.prop_dtsTABLEMEDIUMExt = pdtXLSX}
        objTemplateXLSMediumExt.dtInitsTABLEMEDIUMExt()

        objTemplateXLSTiny = New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtXLSX}
        objTemplateXLSTiny.dtInitsTABLETINY()

        pdtXLSXtemp = New DataTable
        pdtXLSX = New DataTable
        pdtSAVE20 = New DataTable
        pdtSAVE201 = New DataTable
        pdtSAVE21 = New DataTable
        pdtSAVE29 = New DataTable
        pdtSAVE31 = New DataTable

        objTpSave201 = New clsWSNasaTemplateDataMediumExt
        objTpSave201.dtInitsTABLEMEDIUMExt()

        objTpSave21 = New clsWSNasaTemplateDataLargePlus
        objTpSave21.dtInitsTABLELARGEPLUS()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objProses.Dispose()

        pdtXLSXtemp.Dispose()
        pdtXLSX.Dispose()
        pdtSAVE20.Dispose()
        pdtSAVE201.Dispose()
        pdtSAVE21.Dispose()
        pdtSAVE29.Dispose()
        pdtSAVE31.Dispose()

        objTemplateXLSMediumExt.Dispose()
        objTemplateXLSTiny.Dispose()

        objTpSave201.Dispose()
        objTpSave21.Dispose()

        _gdXLSX.Dispose()

    End Sub

    Private Sub ucMD23BB01BULKORDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _cm01BersihkanEntrian()

        _01cFileXLS.Properties.TextEditStyle = TextEditStyles.DisableTextEditor

        oTabDataXLSX.Controls.Add(_gdXLSX)

        Select Case _enmTarget
            Case targetBulkUpload._BUP01Stock
                _lblTitle.Text = "SO Upload - STOCKㅤ"
            Case targetBulkUpload._BUP02Sold
                _lblTitle.Text = "SO Upload - SOLDㅤ"

        End Select

    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm00settingGrid()
        With GridView1
            .OptionsView.ColumnAutoWidth = False

            _cm100initFields()

            .OptionsBehavior.ReadOnly = True
            .OptionsView.ShowFooter = True

            .Appearance.HeaderPanel.ForeColor = Color.Navy
            .Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold
            .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .Appearance.Row.Font = New Font("Courier New", GridView1.Appearance.Row.Font.Size)
            .Appearance.HeaderPanel.Font = New Font(.Appearance.HeaderPanel.Font.FontFamily, .Appearance.HeaderPanel.Font.Size, FontStyle.Bold)

            .BestFitColumns()
        End With
    End Sub

    Private Sub _cm01BersihkanEntrian()
        _01cFileXLS.EditValue = ""

        _gdXLSX.DataSource = Nothing
        _gdXLSX.Refresh()
        GridView1.Columns.Clear()

        pdtXLSXtemp.Clear()
        pdtXLSX.Clear()

        pdtSAVE20.Clear()
        pdtSAVE201.Clear()
        pdtSAVE21.Clear()
        pdtSAVE29.Clear()
        pdtSAVE31.Clear()

        TabPane1.SelectedPageIndex = 0
    End Sub

    Private Sub _cm01ReadFileXLS(ByVal prmcFullPathNameXLS As String)
        Cursor = Cursors.WaitCursor
        Dim myExcelSource As New ExcelDataSource()
        myExcelSource.FileName = prmcFullPathNameXLS
        Dim worksheetSettings As New ExcelWorksheetSettings("WSO")
        myExcelSource.SourceOptions = New ExcelSourceOptions(worksheetSettings)
        myExcelSource.SourceOptions.SkipEmptyRows = False
        myExcelSource.SourceOptions.UseFirstRowAsHeader = True
        myExcelSource.Fill()

        pdtXLSXtemp = ToDataTable(myExcelSource)

        _cm02displayGridXLSX()
        Cursor = Cursors.Default
    End Sub

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

    Private Sub _cm02displayGridXLSX()
        Cursor.Current = Cursors.WaitCursor

        If pdtXLSXtemp.Rows.Count > 0 Then
            For Each row As DataRow In pdtXLSXtemp.Rows
                For Each col As DataColumn In pdtXLSXtemp.Columns
                    If row.IsNull(col) OrElse row(col).ToString() = "" Then

                        Select Case _enmTarget
                            Case targetBulkUpload._BUP01Stock, targetBulkUpload._BUP02Sold
                                If col.ColumnName = "Quantity" OrElse col.ColumnName = "Product Age" OrElse col.ColumnName = "Model/Design Age" Then
                                    row(col) = 0
                                ElseIf col.ColumnName = "Tanggal Inbound" OrElse col.ColumnName = "Tanggal Dibuat" OrElse col.ColumnName = "Tanggal SJ" OrElse col.ColumnName = "Tanggal SO" Then
                                    row(col) = "3000-01-01"
                                ElseIf col.DataType Is GetType(String) Then
                                    row(col) = ""
                                ElseIf col.DataType Is GetType(Integer) Then
                                    row(col) = 0
                                ElseIf col.DataType Is GetType(Double) Then
                                    row(col) = 0.0
                                ElseIf col.DataType Is GetType(Date) Then
                                    row(col) = "3000-01-01"
                                End If

                        End Select

                    End If
                Next
            Next

            objTemplateXLSMediumExt.dtInitsTABLEMEDIUMExt()

            Select Case _enmTarget
                Case targetBulkUpload._BUP01Stock
                    For Each dtRow As DataRow In pdtXLSXtemp.Rows
                        objTemplateXLSMediumExt.dtAddNewsTABLEMEDIUMExt(dtRow("SKU").ToUpper(), "", "",
                                                                       dtRow("Product Code"), dtRow("Kode Karet"),
                                                                       dtRow("Storage"), dtRow("Segmen"), dtRow("Warna"),
                                                                       dtRow("Size"), dtRow("Item"), dtRow("Kadar"),
                                                                       dtRow("Status Mersy"), dtRow("No. Surat Jalan").ToUpper(),
                                                                       dtRow("Customer Order").ToUpper(), dtRow("Nama Customer"),
                                                                       dtRow("Box Name"), dtRow("Status"),
                                                                       dtRow("Keterangan"), dtRow("Sale/Not for Sale").ToUpper(),
                                                                       dtRow("Storage Mersy"), "", "",
                                                                       dtRow("Collection"),
                                                                       dtRow("Quantity"), 0, dtRow("Product Age"),
                                                                       dtRow("Model/Design Age"),
                                                                       dtRow("Berat"), dtRow("Berat Zircon"), 0.0,
                                                                       "3000-01-01", "3000-01-01", "3000-01-01",
                                                                       "3000-01-01", dtRow("Tanggal Inbound"),
                                                                       dtRow("Tanggal Dibuat"), dtRow("Tanggal SJ"),
                                                                       dtRow("Tanggal SO"),
                                                                       "WSO : STOCK AWAL ",
                                                                       _objUserPropWS._UserProp03cUserName,
                                                                       _objUserPropWS._UserProp04ComputerName,
                                                                       _objUserPropWS._UserProp05IPLocalAddress,
                                                                       _objUserPropWS._UserProp06IPPublicAddress)
                    Next

                Case targetBulkUpload._BUP02Sold
                    For Each dtRow As DataRow In pdtXLSXtemp.Rows
                        objTemplateXLSMediumExt.dtAddNewsTABLEMEDIUMExt(dtRow("SKU").ToUpper(), "", "",
                                                                       dtRow("Product Code"), dtRow("Kode Karet"),
                                                                       dtRow("Storage"), dtRow("Segmen"), dtRow("Warna"),
                                                                       dtRow("Size"), dtRow("Item"), dtRow("Kadar"),
                                                                       dtRow("Status Mersy"), dtRow("No. Surat Jalan").ToUpper(),
                                                                       dtRow("Customer Order").ToUpper(), dtRow("Nama Customer"),
                                                                       dtRow("Box Name"), dtRow("Status"),
                                                                       dtRow("Keterangan"), dtRow("Sale/Not for Sale").ToUpper(),
                                                                       dtRow("Storage Mersy"), dtRow("Jenis Order"), dtRow("TOP"),
                                                                       dtRow("Collection"),
                                                                       dtRow("Quantity"), 0, dtRow("Product Age"),
                                                                       dtRow("Model/Design Age"),
                                                                       dtRow("Berat"), dtRow("Berat Zircon"), 0.0,
                                                                       "3000-01-01", "3000-01-01", "3000-01-01",
                                                                       "3000-01-01", Format(CDate(dtRow("Tanggal Inbound")), "yyyy/MM/dd"),
                                                                       Format(CDate(dtRow("Tanggal Dibuat")), "yyyy/MM/dd"), Format(CDate(dtRow("Tanggal SJ")), "yyyy/MM/dd"),
                                                                       Format(CDate(dtRow("Tanggal SO")), "yyyy/MM/dd"),
                                                                       "WSO : STOCK AWAL ",
                                                                       _objUserPropWS._UserProp03cUserName,
                                                                       _objUserPropWS._UserProp04ComputerName,
                                                                       _objUserPropWS._UserProp05IPLocalAddress,
                                                                       _objUserPropWS._UserProp06IPPublicAddress)
                    Next

            End Select

            pdtXLSX.Clear()
            Select Case _enmTarget
                Case targetBulkUpload._BUP01Stock
                    pdtXLSX = objProses._pbWSNasaExecSPPROCESSToDataTable(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTP_wSo", "@tpTEMPLATE_wSo", objTemplateXLSMediumExt.prop_dtsTABLEMEDIUMExt)

                Case targetBulkUpload._BUP02Sold
                    pdtXLSX = objProses._pbWSNasaExecSPPROCESSToDataTable2(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTP_wSoLD", "@tpTEMPLATE_wSo", objTemplateXLSMediumExt.prop_dtsTABLEMEDIUMExt)

            End Select

            _gdXLSX.DataSource = pdtXLSX
            _cm00settingGrid()
        Else
            MsgBox("Data not found!!", MsgBoxStyle.OkOnly, "wSo (Warehouse SO) File Uploader")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function _cm06ProsesSimpanData() As Int32
        Cursor.Current = Cursors.WaitCursor
        SplashScreenManager.ShowForm(Me, GetType(WaitForm1), True, True)
        SplashScreenManager.Default.SetWaitFormDescription("Loading ... 5%")
        Try
            Dim result As Integer
            Select Case _enmTarget
                Case targetBulkUpload._BUP01Stock

                    Dim totalData As Integer = objTemplateXLSMediumExt.prop_dtsTABLEMEDIUMExt.Rows.Count
                    Dim processedData As Integer = 0

                    While processedData < totalData
                        SplashScreenManager.Default.SetWaitFormDescription("Loading ... 10%")
                        Dim currentBatch As DataTable = objTemplateXLSMediumExt.prop_dtsTABLEMEDIUMExt.AsEnumerable().
                                    Skip(processedData).Take(10000).CopyToDataTable()

                        pdtSAVE20.Clear()
                        pdtSAVE21.Clear()
                        pdtSAVE31.Clear()

                        'WSTABLE20
                        pdtSAVE20 = objProses._pbWSNasaExecSPPROCESSToDataTable(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTpForSAVE20_wSo", "@tpTEMPLATE_wSo", currentBatch)
                        SplashScreenManager.Default.SetWaitFormDescription("Loading ... 17%")
                        result = objProses._pbWSNasaExecDirectAllDB(_objUserPropWS._UserProp08TargetNetwork, 2, "mrV_spWSTABLE20Save_wSo", "@tpDataForSaving", pdtSAVE20)
                        SplashScreenManager.Default.SetWaitFormDescription("Loading ... 25%")

                        If result > 0 Then
                            'WSTABLE21
                            pdtSAVE21 = objProses._pbWSNasaExecSPPROCESSToDataTable(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTpForSAVE21_wSo", "@tpTEMPLATE_wSo", pdtSAVE20)
                            SplashScreenManager.Default.SetWaitFormDescription("Loading ... 40%")
                            result = objProses._pbWSNasaExecDirectAllDB(_objUserPropWS._UserProp08TargetNetwork, 2, "mrV_spWSTABLE21Save_wSo", "@tpDataForSaving", pdtSAVE21)
                            SplashScreenManager.Default.SetWaitFormDescription("Loading ... 45%")

                            If result > 0 Then
                                'WSTABLE31
                                SplashScreenManager.Default.SetWaitFormDescription("Loading ... 55%")
                                pdtSAVE31 = objProses._pbWSNasaExecSPPROCESSToDataTable(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTpForSAVE31_wSo", "@tpTEMPLATE_wSo", pdtSAVE21)
                                result = objProses._pbWSNasaExecDirectAllDB(_objUserPropWS._UserProp08TargetNetwork, 2, "mrV_spWSTABLE31Save_wSo", "@tpDataForSaving", pdtSAVE31)
                                SplashScreenManager.Default.SetWaitFormDescription("Loading ... 75%")

                                If result > 0 Then
                                    processedData += currentBatch.Rows.Count

                                    SplashScreenManager.Default.SetWaitFormDescription("Loading ... 95%")
                                Else
                                    SplashScreenManager.Default.SetWaitFormDescription("Error while saving to WSTABLE31!!")
                                    Exit While
                                End If
                            Else
                                SplashScreenManager.Default.SetWaitFormDescription("Error while saving to WSTABLE21!!")
                                Exit While
                            End If
                        Else
                            SplashScreenManager.Default.SetWaitFormDescription("Error while saving to WSTABLE20!!")
                            Exit While
                        End If
                    End While

                    If processedData = totalData Then
                        SplashScreenManager.Default.SetWaitFormDescription("Loading ... 99.99%")
                        System.Threading.Thread.Sleep(2000)
                        SplashScreenManager.Default.SetWaitFormDescription("Process Completed!")
                    Else
                        SplashScreenManager.Default.SetWaitFormDescription("Process stopped due to an error!!")
                    End If

                Case targetBulkUpload._BUP02Sold
                    ''---------------------------------------------------------------------------------------
                    Dim dt As Integer = objTemplateXLSMediumExt.prop_dtsTABLEMEDIUMExt.Rows.Count
                    Dim pro As Integer = 0

                    While pro < dt
                        Dim dt2 As DataTable = objTemplateXLSMediumExt.prop_dtsTABLEMEDIUMExt.AsEnumerable().
                                    Skip(pro).Take(10000).CopyToDataTable()
                        pdtSAVE201.Clear()
                        pdtSAVE21.Clear()
                        pdtSAVE29.Clear()

                        pdtSAVE201 = objProses._pbWSNasaExecSPPROCESSToDataTable2(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTpForSAVE201_wSoLD", "@tpTEMPLATE_wSo", dt2)
                        result = objProses._pbWSNasaExecDirectAllDB2(_objUserPropWS._UserProp08TargetNetwork, 2, "mrV_spWSTABLE201Save_wSoLD", "@tpDataForSaving", pdtSAVE201)

                        If result > 0 Then
                            pdtSAVE21 = objProses._pbWSNasaExecSPPROCESSToDataTable2(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTpForSAVE21_wSoLD", "@tpTEMPLATE_wSo", pdtSAVE201)
                            result = objProses._pbWSNasaExecDirectAllDB2(_objUserPropWS._UserProp08TargetNetwork, 2, "mrV_spWSTABLE21Save_wSoLD", "@tpDataForSaving", pdtSAVE21)

                            If result > 0 Then
                                pdtSAVE29 = objProses._pbWSNasaExecSPPROCESSToDataTable2(_objUserPropWS._UserProp08TargetNetwork, "mrV_spWSInsertToTpForSAVE29_wSoLD", "@tpTEMPLATE_wSo", pdtSAVE201)
                                result = objProses._pbWSNasaExecDirectAllDB2(_objUserPropWS._UserProp08TargetNetwork, 2, "mrV_spWSTABLE29Save_wSoLD", "@tpDataForSaving", pdtSAVE29)

                                If result > 0 Then
                                    pro += dt2.Rows.Count
                                Else
                                    SplashScreenManager.Default.SetWaitFormDescription("Error while saving to WSTABLE29!!")
                                    Exit While
                                End If
                            Else
                                SplashScreenManager.Default.SetWaitFormDescription("Error while saving to WSTABLE21!!")
                                Exit While
                            End If
                        Else
                            SplashScreenManager.Default.SetWaitFormDescription("Error while saving to WSTABLE201!!")
                            Exit While
                        End If
                    End While

                    If pro = dt Then
                        SplashScreenManager.Default.SetWaitFormDescription("Process Completed!")
                    Else
                        SplashScreenManager.Default.SetWaitFormDescription("Process stopped due to an error!!")
                    End If

            End Select

            SplashScreenManager.Default.SetWaitFormCaption("Saving complete!")
            SplashScreenManager.Default.SetWaitFormDescription("Complete 100%!")
            System.Threading.Thread.Sleep(1000)
            SplashScreenManager.CloseForm()

            Return result
        Catch ex As Exception
            SplashScreenManager.Default.SetWaitFormCaption("Error !")
            System.Threading.Thread.Sleep(700)
            SplashScreenManager.CloseForm()

            MsgBox(ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "wSo (Warehouse SO) File Uploader")
            Return -1

        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub _cm07SimpanData()
        If GridView1.RowCount <= 0 Then
            MsgBox("Silahkan upload data terlebih dahulu..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "WSO (Warehouse SO) File Uploader")
            Exit Sub
        End If

        Dim plYes As MsgBoxResult = MsgBox("Are you sure this data is correct and want to continue saving the data..?", vbYesNo + MsgBoxStyle.Question, "wSo (Warehouse SO) File Uploader")

        If plYes = MsgBoxResult.Yes Then
            If _cm06ProsesSimpanData() > 0 Then
                MsgBox("The data was saved successfully.. ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "wSo (Warehouse SO) File Uploader")
                _cm01BersihkanEntrian()
            Else
                MsgBox("Failed to save the data..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "wSo (Warehouse SO) File Uploader")
            End If
        Else
            MsgBox("Save data process is cancelled..", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "wSo (Warehouse SO) File Uploader")
        End If
    End Sub


#End Region

#Region "METHOD UPDATE CHANGES"

    Private Sub _cm100initFields()
        With GridView1

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                col.Visible = False
                col.VisibleIndex = -1
            Next

            Select Case _enmTarget
                Case targetBulkUpload._BUP01Stock, targetBulkUpload._BUP02Sold

                    With .Columns("f03String")
                        .Caption = "Storage"
                        .Visible = True
                        .VisibleIndex = 2
                    End With
                    With .Columns("f04String")
                        .Caption = "Segmen"
                        .Visible = True
                        .VisibleIndex = 3
                    End With
                    With .Columns("k01String")
                        .Caption = "SKU"
                        .Visible = True
                        .VisibleIndex = 4
                    End With
                    With .Columns("f01String")
                        .Caption = "Product Code"
                        .Visible = True
                        .VisibleIndex = 5
                    End With
                    With .Columns("f02String")
                        .Caption = "Kode Karet"
                        .Visible = True
                        .VisibleIndex = 6
                    End With
                    With .Columns("f05String")
                        .Caption = "Warna"
                        .Visible = True
                        .VisibleIndex = 7
                    End With
                    With .Columns("f06String")
                        .Caption = "Size"
                        .Visible = True
                        .VisibleIndex = 8
                    End With
                    With .Columns("f07String")
                        .Caption = "Item"
                        .Visible = True
                        .VisibleIndex = 9
                    End With
                    With .Columns("f01TinyInt")
                        .Caption = "Qty"
                        .Visible = True
                        .VisibleIndex = 10
                        .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        .SummaryItem.DisplayFormat = "{0:n0}"
                    End With
                    With .Columns("f01Double")
                        .Caption = "Berat"
                        .Visible = True
                        .VisibleIndex = 11
                        .DisplayFormat.FormatType = FormatType.Numeric
                        .DisplayFormat.FormatString = "{0:n2}"
                        .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        .SummaryItem.DisplayFormat = "{0:n2}"
                    End With
                    With .Columns("f02Double")
                        .Caption = "Berat Zircon"
                        .Visible = True
                        .VisibleIndex = 12
                        .DisplayFormat.FormatType = FormatType.Numeric
                        .DisplayFormat.FormatString = "{0:n2}"
                        .SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        .SummaryItem.DisplayFormat = "{0:n2}"
                    End With
                    With .Columns("f08String")
                        .Caption = "Kadar"
                        .Visible = True
                        .VisibleIndex = 13
                    End With
                    With .Columns("f20String")
                        .Caption = "Collection"
                        .Visible = True
                        .VisibleIndex = 14
                    End With
                    With .Columns("f02Datetime")
                        .Caption = "Tanggal Inbound"
                        .Visible = True
                        .VisibleIndex = 15
                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
                    End With
                    With .Columns("f03Datetime")
                        .Caption = "Tanggal Dibuat"
                        .Visible = True
                        .VisibleIndex = 16
                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
                    End With
                    With .Columns("f01Int")
                        .Caption = "Product Age"
                        .Visible = True
                        .VisibleIndex = 17
                    End With
                    With .Columns("f02Int")
                        .Caption = "Model/Design Age"
                        .Visible = True
                        .VisibleIndex = 18
                    End With
                    With .Columns("f09String")
                        .Caption = "No. IR"
                        .Visible = True
                        .VisibleIndex = 19
                    End With
                    With .Columns("f10String")
                        .Caption = "No. Surat Jalan"
                        .Visible = True
                        .VisibleIndex = 20
                    End With
                    With .Columns("f04Datetime")
                        .Caption = "Tanggal SJ"
                        .Visible = True
                        .VisibleIndex = 21
                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
                    End With
                    With .Columns("f11String")
                        .Caption = "Customer Order"
                        .Visible = True
                        .VisibleIndex = 22
                    End With
                    With .Columns("f12String")
                        .Caption = "Nama Customer"
                        .Visible = True
                        .VisibleIndex = 23
                    End With
                    With .Columns("f13String")
                        .Caption = "Box Name"
                        .Visible = True
                        .VisibleIndex = 24
                    End With
                    With .Columns("f14String")
                        .Caption = "Status"
                        .Visible = True
                        .VisibleIndex = 25
                    End With
                    With .Columns("f15String")
                        .Caption = "Keterangan"
                        .Visible = True
                        .VisibleIndex = 26
                    End With
                    With .Columns("f05Datetime")
                        .Caption = "Tanggal SO"
                        .Visible = True
                        .VisibleIndex = 27
                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        .DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
                    End With
                    With .Columns("f16String")
                        .Caption = "Sale / Not"
                        .Visible = True
                        .VisibleIndex = 28
                    End With
                    With .Columns("f17String")
                        .Caption = "Storage"
                        .Visible = True
                        .VisibleIndex = 29
                    End With
                    With .Columns("f09String")
                        .Caption = "Status"
                        .Visible = True
                        .VisibleIndex = 30
                    End With

                    Select Case _enmTarget
                        Case targetBulkUpload._BUP02Sold
                            With .Columns("f18String")
                                .Caption = "Jenis Order"
                                .Visible = True
                                .VisibleIndex = 31
                            End With
                            With .Columns("f19String")
                                .Caption = "TOP"
                                .Visible = True
                                .VisibleIndex = 32
                            End With

                    End Select

            End Select


            .OptionsView.ColumnAutoWidth = False
        End With
    End Sub

#End Region

#Region "control - event"

    Private Sub _01cFileXLS_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _01cFileXLS.ButtonClick

        If e.Button.Kind = ButtonPredefines.Ellipsis Then
            Dim ofd As OpenFileDialog = New OpenFileDialog()
            ofd.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            ofd.Title = "Please choose file XLSX - wSo."

            If ofd.ShowDialog() = DialogResult.OK Then
                Dim pcNamaFile As String = ofd.FileName

                _01cFileXLS.EditValue = pcNamaFile

                _cm01ReadFileXLS(pcNamaFile)
            End If
        End If

    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm07SimpanData()

            Case 200  'Clear
                Dim plYes As MsgBoxResult = MsgBox("Are you sure want to clear this data on the grid..?", vbYesNo + MsgBoxStyle.Question, "wSo (Warehouse SO) File Uploader")

                If plYes = MsgBoxResult.Yes Then
                    _cm01BersihkanEntrian()
                End If

        End Select
    End Sub
    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)

            Dim semiTransparentPen As New Pen(Color.FromArgb(25, 0, 0, 0), 1)

            e.Cache.DrawRectangle(semiTransparentPen, e.Bounds)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            e.Appearance.DrawString(e.Cache, (e.RowHandle + 1).ToString(), e.Bounds, sf)
            e.Handled = True
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)

            Dim semiTransparentPen As New Pen(Color.FromArgb(25, 0, 0, 0), 1)

            e.Cache.DrawRectangle(semiTransparentPen, e.Bounds)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            e.Appearance.DrawString(e.Cache, "No.", e.Bounds, sf)
            e.Handled = True
        End If

        GridView1.IndicatorWidth = 40
    End Sub

#End Region

End Class
