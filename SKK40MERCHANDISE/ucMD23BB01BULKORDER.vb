Imports System.Text.RegularExpressions
Imports DevExpress.Charts.Model
Imports DevExpress.DataAccess.Excel
Imports DevExpress.Pdf.Native
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors.Controls
Imports SHAN04SECURITY
Imports SKK01CORE
Imports SKK02OBJECTS
Imports SKK02OBJECTS.clsGetDataProsesTransaksiGEMINI
Imports SKK03SECURITY

Public Class ucMD23BB01BULKORDER
    Implements IDisposable

    Public Property prop01User As clsUserGEMINI

    Private pdtTemplateXLS As DataTable
    Private objTemplateXLS As clsTEMPLATEGEMINI

    Private pdtTABLEMASTER As DataTable
    Private pdtSBUMASTER As DataTable

    Private _gdBulkOrder As ucGridTransaction
    Private pdtTableIntiBulkOrder As DataTable

    Private _gdCheckProductCode As ucGridTransaction
    Private pdtCheckProductCode As DataTable
    Private ctrlTemplateCheckProdCode As clsTEMPLATEGEMINI

    Private objHash As EncryptProvider

    Private objProses As clsGetDataProsesTransaksiGEMINI


    Private objExecSQL As clsNasaHelper

    Private Const _pcStatusOK As String = "OK"
    Private Const _pcStatusERR As String = "ERR"

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        objProses = New clsGetDataProsesTransaksiGEMINI

        pdtTemplateXLS = New DataTable
        objTemplateXLS = New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdtTemplateXLS}
        objTemplateXLS.dtInitTABLEGEMINI()

        pdtTABLEMASTER = New DataTable
        pdtSBUMASTER = New DataTable

        _gdBulkOrder = New ucGridTransaction With {._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._01MD23BB01BULKORDER}
        _gdBulkOrder._pb01InitGrid()

        pdtCheckProductCode = New DataTable
        ctrlTemplateCheckProdCode = New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdtCheckProductCode}
        ctrlTemplateCheckProdCode.dtInitTABLEGEMINI()

        _gdCheckProductCode = New ucGridTransaction With {._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._04MD23BB01CHECKPRODUCTCODE}
        _gdCheckProductCode._pb01InitGrid()

        pdtTableIntiBulkOrder = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objProses.Dispose()

        pdtTemplateXLS.Dispose()
        objTemplateXLS.Dispose()

        pdtTABLEMASTER.Dispose()
        pdtSBUMASTER.Dispose()

        _gdBulkOrder.Dispose()
        pdtTableIntiBulkOrder.Dispose()
    End Sub

    Private Sub ucMD23BB01BULKORDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(prop01User._UserProp10Skin)

        _cm01BersihkanEntrian()
        _cm02InitMaster()

        oTabBulkOrder.Controls.Add(_gdBulkOrder)
        oTabCheckProductCode.Controls.Add(_gdCheckProductCode)

        If prop01User._UserProp02cUserID = "141202" Then
            WindowsuiButtonPanel1.Buttons(2).Properties.Visible = True
        Else
            WindowsuiButtonPanel1.Buttons(2).Properties.Visible = False
        End If
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01BersihkanEntrian()
        _01cFileXLS.EditValue = ""

        With _gdDataXLSX
            .DataSource = Nothing
            .Refresh()
        End With

        With _gdBulkOrder
            ._pb02ClearGrid()
            ._pb01InitGrid()
        End With
        With _gdCheckProductCode
            ._pb02ClearGrid()
            ._pb01InitGrid()
        End With
        pdtTableIntiBulkOrder.Clear()
    End Sub

    Private Async Sub _cm02InitMaster()
        Dim objGetDataMaster As New clsGetDataMasterGEMINI

        pdtSBUMASTER = Await objGetDataMaster._pb01GetDataCUSTOMER_Async(prop01User._UserProp07TargetNetwork)
        pdtTABLEMASTER = Await objGetDataMaster._pb02GetDataTIPEMERCHANDISE_Async(prop01User._UserProp07TargetNetwork)
    End Sub

    Private Sub _cm01ReadFileXLS(ByVal prmcFullPathNameXLS As String)

        Dim myExcelSource As New ExcelDataSource()
        myExcelSource.FileName = prmcFullPathNameXLS
        Dim worksheetSettings As New ExcelWorksheetSettings("MD")
        myExcelSource.SourceOptions = New ExcelSourceOptions(worksheetSettings)
        myExcelSource.SourceOptions.SkipEmptyRows = False
        myExcelSource.SourceOptions.UseFirstRowAsHeader = True
        myExcelSource.Fill()

        _gdDataXLSX.DataSource = myExcelSource

        _cm02CopyXLSGridToDataTable()
    End Sub

    Private Sub _cm02CopyXLSGridToDataTable()
        'Dim culDate As CultureInfo = New CultureInfo("en-us")

        Dim pdInputDate As Date = "01-01-3000" : Dim pdEstDeliveryDate As Date = "01-01-3000"
        Dim pcDesignCode As String = "" : Dim pcProductCode As String = ""

        Dim pnQty As Int32 = 0               'f01Int
        Dim pnBeratPerPcs As Double = 0.0    'f01Double = b.f08nProductEstimasiBerat_n93,
        Dim pnTotBerat As Double = 0.0       'f02Double = f01Int * b.f08nProductEstimasiBerat_n93

        Dim pcNamaCustomer As String = ""    'f20String : NamaCustomer (dari XLS-MD, nanti akan dihapus di "spMD23CreateBulkOrder")
        Dim pcNomorPOJIMS As String = ""     'f21String : Nomor PO JIMS
        Dim pcRemarksSales As String = ""    'f03Memo : Remarks Sales
        Dim pcRemarksMD As String = ""       'f04Memo : Remarks MD

        Dim pcKODETIPEProduksi As String = ""    'f27String : KODETIPEProduksi
        Dim pcKODESUBTipeProduksi As String = "" 'f28String : KODESUBTipeProduksi
        Dim pcKODECUSTOMER As String = ""        'f29String : KODECUSTOMER

        Dim pcBrand As String = ""
        Dim pcColor As String = ""
        Dim pcKadar As String = ""
        Dim pcSize As String = ""
        Dim pcGrafir As String = ""          'f05Memo : Grafir
        Dim pcPOCMK As String = ""

        objTemplateXLS.dtInitTABLEGEMINI()
        ctrlTemplateCheckProdCode.dtInitTABLEGEMINI()

        Dim pnYear As Integer = 0
        Dim pnMonth As Integer = 0
        Dim pnDay As Integer = 0

        For i = 0 To GridView1.RowCount - 1
            If Not (String.IsNullOrWhiteSpace(GridView1.GetRowCellValue(i, GridView1.Columns(0))) Or
                    String.IsNullOrEmpty(GridView1.GetRowCellValue(i, GridView1.Columns(0)))) Then
                'MsgBox(Convert.ToDateTime(GridView1.GetRowCellValue(i, GridView1.Columns(0)), culDate))

                pdInputDate = "01-01-3000"
                'pdInputDate = CDate(GridView1.GetRowCellValue(i, GridView1.Columns(0)))

                pnYear = 0 : pnMonth = 0 : pnDay = 0
                pnYear = DateAndTime.Year(CDate(GridView1.GetRowCellValue(i, GridView1.Columns(0))))
                pnMonth = DateAndTime.Month(CDate(GridView1.GetRowCellValue(i, GridView1.Columns(0))))
                pnDay = DateAndTime.Day(CDate(GridView1.GetRowCellValue(i, GridView1.Columns(0))))
                pdInputDate = DateSerial(pnYear, pnMonth, pnDay)
            End If
            If Not (String.IsNullOrWhiteSpace(GridView1.GetRowCellValue(i, GridView1.Columns(1))) Or
                    String.IsNullOrEmpty(GridView1.GetRowCellValue(i, GridView1.Columns(1)))) Then
                'MsgBox(Date.Parse(GridView1.GetRowCellValue(i, GridView1.Columns(1)), culDate, DateTimeStyles.AllowWhiteSpaces))

                pdEstDeliveryDate = "01-01-3000"
                'pdEstDeliveryDate = CDate(GridView1.GetRowCellValue(i, GridView1.Columns(1)))

                pnYear = 0 : pnMonth = 0 : pnDay = 0
                pnYear = DateAndTime.Year(CDate(GridView1.GetRowCellValue(i, GridView1.Columns(1))))
                pnMonth = DateAndTime.Month(CDate(GridView1.GetRowCellValue(i, GridView1.Columns(1))))
                pnDay = DateAndTime.Day(CDate(GridView1.GetRowCellValue(i, GridView1.Columns(1))))
                pdEstDeliveryDate = DateSerial(pnYear, pnMonth, pnDay)
            End If
            pcDesignCode = GridView1.GetRowCellValue(i, GridView1.Columns(2))
            pcProductCode = GridView1.GetRowCellValue(i, GridView1.Columns(3))

            pnQty = CInt(GridView1.GetRowCellValue(i, GridView1.Columns(4)))

            pcKODETIPEProduksi = CStr(GridView1.GetRowCellValue(i, GridView1.Columns(5)))
            pcKODESUBTipeProduksi = CStr(GridView1.GetRowCellValue(i, GridView1.Columns(6)))
            pcKODECUSTOMER = GridView1.GetRowCellValue(i, GridView1.Columns(7))

            pcNamaCustomer = GridView1.GetRowCellValue(i, GridView1.Columns(8))
            pcNomorPOJIMS = GridView1.GetRowCellValue(i, GridView1.Columns(9))
            pcRemarksSales = GridView1.GetRowCellValue(i, GridView1.Columns(10))
            pcRemarksMD = GridView1.GetRowCellValue(i, GridView1.Columns(11))

            pcBrand = GridView1.GetRowCellValue(i, GridView1.Columns(12))
            pcColor = GridView1.GetRowCellValue(i, GridView1.Columns(13))
            pcKadar = GridView1.GetRowCellValue(i, GridView1.Columns(14))
            If Not String.IsNullOrEmpty(GridView1.GetRowCellValue(i, GridView1.Columns(15))) Then
                pcSize = GridView1.GetRowCellValue(i, GridView1.Columns(15)).ToString
            End If
            pcGrafir = GridView1.GetRowCellValue(i, GridView1.Columns(16))
            pnBeratPerPcs = CDbl(GridView1.GetRowCellValue(i, GridView1.Columns(17)))
            pnTotBerat = pnQty * pnBeratPerPcs
            If Not String.IsNullOrEmpty(GridView1.GetRowCellValue(i, GridView1.Columns(18))) Then
                pcPOCMK = GridView1.GetRowCellValue(i, GridView1.Columns(18)).ToString
            End If

            'If pcProductCode = "BC220600-001" Then
            '    MsgBox(pcSize)
            'End If

            'NOTE :
            ' -. ESTIMASI BERAT     : f01Double  (ada di "spMD23CreateBulkOrder")
            ' -. Jml berat Estimasi : f02Double  (ada di "spMD23CreateBulkOrder")

            If (String.IsNullOrEmpty(pcProductCode)) Then
                'f02String	: Nama Brand
                'f06String	: Nama Warna Barang
                'f08String	: Nama Kadar
                'f10String	: Nama Size
                'f05Memo	: Grafir
                objTemplateXLS.dtAddNewTABLEGEMINI("", 0, pcDesignCode, "", "",
                                                     "", pcBrand, "", "", "",
                                                    pcColor, "", pcKadar, "", pcSize,
                                                    "", "", "", "", "",
                                                    "", "", "", "", pcNamaCustomer,
                                                    pcNomorPOJIMS, "", pcPOCMK, "", "",
                                                    "", pcKODETIPEProduksi, pcKODESUBTipeProduksi, pcKODECUSTOMER, "",
                                                    "", pcRemarksSales, pcRemarksMD, pcGrafir,
                                                    pnQty, 0, 0, 0, 0, 0, 0,
                                                    pnBeratPerPcs, pnTotBerat, 0.0, 0.0, 0.0, 0.0, 0.0,
                                                    pdInputDate, pdEstDeliveryDate, "3000-01-01", "3000-01-01", "3000-01-01",
                                                    Date.Now, "3000-01-01",
                                                    prop01User._UserProp02cUserID, "",
                                                    prop01User._UserProp03cUserName, "")
            Else
                'k01String = NEWID()
                'k05String = Nomer Order MCD
                objTemplateXLS.dtAddNewTABLEGEMINI("", 0, pcDesignCode, pcProductCode, "",
                                                     "", "", "", "", "",
                                                    "", "", "", "", "",
                                                    "", "", "", "", "",
                                                    "", "", "", "", pcNamaCustomer,
                                                    pcNomorPOJIMS, "", pcPOCMK, "", "",
                                                    "", pcKODETIPEProduksi, pcKODESUBTipeProduksi, pcKODECUSTOMER, "",
                                                    "", pcRemarksSales, pcRemarksMD, pcGrafir,
                                                    pnQty, 0, 0, 0, 0, 0, 0,
                                                    pnBeratPerPcs, pnTotBerat, 0.0, 0.0, 0.0, 0.0, 0.0,
                                                    pdInputDate, pdEstDeliveryDate, "3000-01-01", "3000-01-01", "3000-01-01",
                                                    Date.Now, "3000-01-01",
                                                    prop01User._UserProp02cUserID, "",
                                                    prop01User._UserProp03cUserName, "")

                Dim foundRows = ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI.Select($"k04String = '{pcProductCode}' AND f23String = '{pcPOCMK}'")

                If foundRows.Length = 0 Then
                    ' belum ada data dengan kombinasi itu, tambahkan
                    ctrlTemplateCheckProdCode.dtAddNewTABLEGEMINI("", 0, pcDesignCode, pcProductCode, "",
                                                                      pcBrand, pcColor, pcKadar, pcSize, "", "", "", "", "", "",
                                                                      "", "", "", "", "", "", "", "", "", "",
                                                                      "", "", pcPOCMK, "", "", "", "", "", "", "", "", "", "", "",
                                                                      0, 0, 0, 0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                                                                      "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                                                                      "", "", "", "")
                End If

            End If

            pdInputDate = "01-01-3000" ' "3000-01-01"
            pdEstDeliveryDate = "01-01-3000" ' "3000-01-01"
            pcDesignCode = "" : pcProductCode = ""
            pnQty = 0 : pnBeratPerPcs = 0.0 : pnTotBerat = 0.0
            pcKODETIPEProduksi = "" : pcKODESUBTipeProduksi = "" : pcKODECUSTOMER = ""
            pcNamaCustomer = "" : pcNomorPOJIMS = "" : pcRemarksSales = "" : pcRemarksMD = ""
            pcBrand = "" : pcColor = "" : pcKadar = "" : pcSize = "" : pcGrafir = "" : pcPOCMK = ""

        Next

        _cm03SyncDataMRPToMD()
    End Sub

    Private Sub _cm03SyncDataMRPToMD()

        Cursor.Current = Cursors.WaitCursor

        Dim pdtHasilSyncMaster As New DataTable
        pdtHasilSyncMaster = objProses._tr02NasaExecSPPROCESStoDataTableAllDB(
                                    prop01User._UserProp07TargetNetwork, _pnmDatabaseName.MRP,
                                    "spMD23CreateBulkOrder", "@tpTEMPLATEGEMINI",
                                    objTemplateXLS.prop_dtTABLEGEMINI)

        Cursor.Current = Cursors.Default

        Dim dtFiltered As DataTable = pdtHasilSyncMaster.Clone()

        For Each row As DataRow In pdtHasilSyncMaster.Rows
            ' cek kadar,brand,tipe kalo kosong brrti data product code tdk tersedia di MRP.
            If Not String.IsNullOrWhiteSpace(row("f01String")?.ToString()) AndAlso
               Not String.IsNullOrWhiteSpace(row("f02String")?.ToString()) AndAlso
               Not String.IsNullOrWhiteSpace(row("f03String")?.ToString()) AndAlso
               Not String.IsNullOrWhiteSpace(row("f04String")?.ToString()) AndAlso
               Not String.IsNullOrWhiteSpace(row("f07String")?.ToString()) AndAlso
               Not String.IsNullOrWhiteSpace(row("f08String")?.ToString()) Then

                dtFiltered.ImportRow(row)
            End If
        Next

        If dtFiltered.Rows.Count > 0 Then
            _cm031UpdateMasterToDataXLS(dtFiltered)
        End If
        '_cm031UpdateMasterToDataXLS(pdtHasilSyncMaster)

        _cm04DisplayGridBulkOrder()
    End Sub

    Private Sub _cm031UpdateMasterToDataXLS(ByVal prmdtHasilSyncMaster As DataTable)

        Cursor.Current = Cursors.WaitCursor

        pdtTableIntiBulkOrder.Clear()
        pdtTableIntiBulkOrder = objProses._tr02NasaExecSPPROCESStoDataTableAllDB(prop01User._UserProp07TargetNetwork,
                                                                                 _pnmDatabaseName.SBU,
                                                                                 "spMD50SyncMasterPadaBulkOrder",
                                                                                 "@tpTEMPLATEGEMINI", prmdtHasilSyncMaster)

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub _cm04DisplayGridBulkOrder()
        Cursor = Cursors.WaitCursor

        Dim vdiDupl As New Dictionary(Of String, Integer)
        Dim pdInputDate As String = ""
        Dim vsProductCode As String = ""
        Dim pcBrand As String = ""
        Dim pcColor As String = ""
        Dim pcKadar As String = ""
        Dim pcSize As String = ""
        Dim pcGrafir As String = ""
        Dim pcOK As String = _pcStatusOK
        Dim vsFound As Boolean = False

        For Each dtRowCheck As DataRow In ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI.Rows
            pcOK = _pcStatusOK
            vsFound = False

            For Each dtRow As DataRow In pdtTableIntiBulkOrder.Rows
                If (dtRowCheck("k03String") = dtRow("k03String")) And
                   (dtRowCheck("k04String") = dtRow("k04String")) And
                   (dtRowCheck("f23String") = dtRow("f23String")) Then

                    vsFound = True

                    vsProductCode = "" : pcBrand = "" : pcColor = "" : pcKadar = "" : pcSize = "" : pcOK = _pcStatusOK

                    If dtRowCheck("f01String").ToString = dtRow("f02String").ToString Then
                        pcBrand = dtRow("f02String").ToString
                    Else
                        pcOK = _pcStatusERR
                        pcBrand = dtRow("f02String").ToString
                        dtRowCheck("f01String") = dtRowCheck("f01String").ToString & " (X)"
                    End If

                    If dtRowCheck("f02String").ToString = dtRow("f06String").ToString Then
                        pcColor = dtRow("f06String").ToString
                    Else
                        pcOK = _pcStatusERR
                        pcColor = dtRow("f06String").ToString
                        dtRowCheck("f02String") = dtRowCheck("f02String").ToString & " (X)"
                    End If

                    Dim vsConvertKadar2Dec As String = (Convert.ToDouble(dtRow("f08String").ToString.Replace("%", "").Trim()) / 100).ToString("0.###")
                    If dtRowCheck("f03String").ToString = vsConvertKadar2Dec Then
                        pcKadar = dtRow("f08String").ToString
                    Else
                        pcOK = _pcStatusERR
                        pcKadar = dtRow("f08String").ToString
                        dtRowCheck("f03String") = dtRowCheck("f03String").ToString & " (X)"
                    End If

                    If dtRowCheck("f04String").ToString = dtRow("f10String").ToString Then
                        pcSize = dtRow("f10String").ToString
                    Else
                        pcOK = _pcStatusERR
                        pcSize = dtRow("f10String").ToString
                        dtRowCheck("f04String") = dtRowCheck("f04String").ToString & " (X)"
                    End If

                    If IsDate(dtRow("f01Date")) Then
                        Dim dtRowDate As Date = CDate(dtRow("f01Date"))

                        If dtRowDate.Date = Today Then
                            pdInputDate = dtRowDate.Date.ToString("dd-MM-yyyy")

                        Else
                            pcOK = _pcStatusERR
                            pdInputDate = " (X)" & dtRowDate.ToString("dd-MM-yyyy")

                        End If
                    End If

                    'pcBrand, pcColor, pcKadar, pcSize
                    dtRowCheck("f11String") = pcBrand
                    dtRowCheck("f12String") = pcColor
                    dtRowCheck("f13String") = pcKadar
                    dtRowCheck("f14String") = pcSize
                    dtRowCheck("f05String") = pdInputDate

                    dtRowCheck("f20String") = pcOK
                    dtRow("k01String") = pcOK
                    Exit For

                End If
            Next

            ' ========================================================================
            ' ===================== CREATED BY AKIRRA - 25/06/25 =====================
            ' ========================================================================
            ' CHECK FOR INVALID PRODUCT CODE
            If Not vsFound Then
                dtRowCheck("k04String") &= " (X)"
                dtRowCheck("f20String") = _pcStatusERR
            End If

            'Dim val As String = dtRowCheck("k04String").ToString()
            'If vdiDupl.ContainsKey(val) Then
            '    vdiDupl(val) += 1
            'Else
            '    vdiDupl(val) = 1
            'End If

        Next
        ' ========================================================================
        ' ===================== CREATED BY AKIRRA - 25/06/25 =====================
        ' ========================================================================
        ' CHECK FOR DUPLICATE PRODUCT CODE
        'For Each rowCheck As DataRow In ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI.Rows
        '    Dim val As String = rowCheck("k04String").ToString().Replace(" (Dupl)", "")
        '    If vdiDupl.ContainsKey(val) AndAlso vdiDupl(val) > 1 Then
        '        rowCheck("k04String") = val & " (Dupl)"
        '        rowCheck("f20String") = _pcStatusERR
        '    End If
        'Next

        'For Each row As DataRow In pdtTableIntiBulkOrder.Rows
        '    Dim val As String = row("k04String").ToString()
        '    If vdiDupl.ContainsKey(val) AndAlso vdiDupl(val) > 1 Then
        '        row("k01String") = _pcStatusERR
        '    End If
        'Next

        ' ========================================================================
        ' ===================== CREATED BY AGA - 07/07/25 =====================
        ' ========================================================================
        'Dim dtGemini As DataTable = ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI

        'If dtGemini.Rows.Count > 0 Then
        '    Dim uniqueRows = dtGemini.AsEnumerable() _
        '.GroupBy(Function(row) row.Field(Of String)("k04String")) _
        '.Select(Function(g) g.First()) _
        '.CopyToDataTable()

        '    ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI = uniqueRows
        'End If

        pdtTableIntiBulkOrder.AcceptChanges()
        ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI.AcceptChanges()

        With _gdBulkOrder
            ._prop02pdtDataSourceGrid = pdtTableIntiBulkOrder
            ._prop03pdtSBUMasterGEMINI = pdtSBUMASTER
            ._prop04pdtTableMasterGEMINI = pdtTABLEMASTER
        End With
        _gdBulkOrder._pb01InitGrid()
        _gdBulkOrder._pb03DisplayGridTransaction()
        _gdBulkOrder._wd240707WidthMD23BB01BULKORDER()

        With _gdCheckProductCode
            ._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._04MD23BB01CHECKPRODUCTCODE
            ._prop02pdtDataSourceGrid = ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI
        End With
        _gdCheckProductCode._pb01InitGrid()
        _gdCheckProductCode._pb03DisplayGridTransaction()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm05PrepareSaveData() As String
        Dim pcNumberOrderMD As String = ""
        Dim objMaster As New clsGetDataMasterGEMINI()

        If pdtTableIntiBulkOrder.Rows.Count > 0 Then
            For Each dtRow As DataRow In pdtTableIntiBulkOrder.Rows
                If dtRow("k01String") = _pcStatusERR Then
                    dtRow.Delete()
                Else
                    pcNumberOrderMD = objMaster._pb03IncNumberMaster(prop01User._UserProp07TargetNetwork, "MNORDERMD", "cNOMORDOKUMEN")

                    dtRow("k01String") = ""
                    dtRow("k05String") = pcNumberOrderMD

                End If
            Next
            pdtTableIntiBulkOrder.AcceptChanges()

        End If

        Return pcNumberOrderMD
    End Function

    Private Function _cm06ProsesSimpanData()

        Cursor.Current = Cursors.WaitCursor

        Return objProses._tr01NasaExecDirectAllDB(prop01User._UserProp07TargetNetwork,
                                                  _pnmDatabaseName.SBU, 2, "spTABLE50Save",
                                                  "@tpTEMPLATEGEMINI", pdtTableIntiBulkOrder)

        Cursor.Current = Cursors.Default
    End Function

    Private Sub _cm07SimpanData()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar ... ?", vbYesNo + MsgBoxStyle.Question, prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            Dim pcNoMDOrder As String = ""
            pcNoMDOrder = _cm05PrepareSaveData()

            If Not String.IsNullOrEmpty(pcNoMDOrder) Then
                _cm06ProsesSimpanData()
                Dim totalData As Integer = ctrlTemplateCheckProdCode.prop_dtTABLEGEMINI.Rows.Count
                Dim berhasil As Integer = pdtTableIntiBulkOrder.Rows.Count
                Dim gagal As Integer = totalData - berhasil

                If totalData > 0 Then
                    MsgBox($"Operation completed successfully" & vbCrLf &
                           $"Successful : {berhasil} data(s)" & vbCrLf &
                           $"Failed: {gagal} data(s)",
                           MsgBoxStyle.OkOnly + MsgBoxStyle.Information, prop01User._UserProp01cTitle)
                    _cm01BersihkanEntrian()
                Else
                    MsgBox("Simpan Data ... GAGAL", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
                End If
            Else
                MsgBox("Maaf ... Nomor Order GAGAL dibuat ..." & Chr(13) &
                       "Simpan Data ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Simpan Data ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
        End If
    End Sub



    ''' <summary>
    ''' Menampilkan dialog open file dan mengembalikan path file terpilih.
    ''' </summary>
    Private Function GetSelectedXLSXFilePath() As String
        Using ofd As New OpenFileDialog()
            ofd.Filter = "XLSX Files (*.xlsx)|*.xlsx"
            ofd.Title = "Please choose file XLSX - SKK Merchandise."

            If ofd.ShowDialog() = DialogResult.OK Then
                Return ofd.FileName
            End If
        End Using
        Return String.Empty
    End Function

    ''' <summary>
    ''' Mengecek apakah file dengan hash tertentu sudah pernah diupload.
    ''' </summary>
    Private Function IsDuplicateFile(fileHash As String) As Boolean
        Using checker As New clsGetDataProsesTransaksiGEMINI With {
        ._prop01User = prop01User,
        ._prop02String = fileHash
    }
            Return checker._pbSBUCheckUploadFile() > 0
        End Using
    End Function

    ''' <summary>
    ''' Menyimpan informasi file yang diupload ke database.
    ''' </summary>
    Private Sub InsertUploadedFileRecord(filePath As String, fileHash As String, dateModified As DateTime)
        Using saver As New clsGetDataProsesTransaksiGEMINI With {._prop01User = prop01User}
            saver._pbSBUInsertUploadFile(filePath, fileHash, dateModified)
        End Using
    End Sub



#End Region

#Region "control - event"
    Private Sub _01cFileXLS_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _01cFileXLS.ButtonClick
        If e.Button.Kind <> ButtonPredefines.Ellipsis Then Exit Sub

        Dim selectedFilePath As String = GetSelectedXLSXFilePath()
        If String.IsNullOrEmpty(selectedFilePath) Then Exit Sub

        Dim fileHash As String = SHAN04SECURITY.EncryptProvider.Sha256ExcelData(selectedFilePath)
        Dim dateModified As DateTime = (New System.IO.FileInfo(selectedFilePath)).LastWriteTime

        If IsDuplicateFile(fileHash) Then
            MsgBox("Duplicate upload detected. Kindly select another file", MsgBoxStyle.Exclamation, prop01User._UserProp01cTitle)
            Exit Sub
            _01cFileXLS.EditValue = ""
        End If

        InsertUploadedFileRecord(selectedFilePath, fileHash, dateModified)

        _01cFileXLS.EditValue = selectedFilePath
        _cm01ReadFileXLS(selectedFilePath)
    End Sub



    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm07SimpanData()

            Case 200  'Clear
                _cm01BersihkanEntrian()

            Case 300 'Grid
                _gdBulkOrder.__pb06CreateSettingColumnWidth("MD23BB01BULKORDER")

        End Select
    End Sub
    'Private Sub _01cFileXLS_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _01cFileXLS.ButtonClick

    '    If e.Button.Kind = ButtonPredefines.Ellipsis Then
    '        Dim ofd As OpenFileDialog = New OpenFileDialog()
    '        ofd.Filter = "XLSX Files (*.xlsx)|*.xlsx"
    '        ofd.Title = "Please choose file XLSX - SKK Merchandise."

    '        If ofd.ShowDialog() = DialogResult.OK Then
    '            Dim pcNamaFile As String = ofd.FileName
    '            'Dim pcPath As String = Path.GetDirectoryName(ofd.FileName)
    '            Dim fileInfo As New System.IO.FileInfo(pcNamaFile)
    '            Dim dateModified As DateTime = fileInfo.LastWriteTime

    '            _01cFileXLS.EditValue = pcNamaFile
    '            Dim fileHash As String = SHAN04SECURITY.EncryptProvider.Sha256File(pcNamaFile)

    '            Dim pcIsDuplicate As Integer = 0
    '            Using objNoDoc As clsGetDataProsesTransaksiGEMINI = New clsGetDataProsesTransaksiGEMINI With {._prop01User = prop01User,
    '                                                                                                          ._prop02String = fileHash}
    '                pcIsDuplicate = objNoDoc._pbSBUCheckUploadFile()
    '            End Using

    '            If pcIsDuplicate > 0 Then  ' Jika pcIsDuplicate > 0, berarti file sudah pernah diupload
    '                MsgBox("File ini sudah pernah diupload sebelumnya." & vbCrLf &
    '                       "Silakan gunakan file yang berbeda.", MsgBoxStyle.Exclamation, prop01User._UserProp01cTitle)
    '                Exit Sub

    '            End If

    '            Using objNoDoc As clsGetDataProsesTransaksiGEMINI = New clsGetDataProsesTransaksiGEMINI With {._prop01User = prop01User}
    '                objNoDoc._pbSBUInsertUploadFile(pcNamaFile, fileHash, dateModified)
    '            End Using
    '            _cm01ReadFileXLS(pcNamaFile)
    '        End If
    '    End If

    'End Sub

#End Region

End Class
