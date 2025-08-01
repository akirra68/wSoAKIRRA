Imports DevExpress.DashboardWin.Native
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.UI
Imports SKK01CORE
Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGridParentChild
Imports DevExpress.Spreadsheet
Imports System.IO

Public Class ucWS24G301OUTBOUNDPKB
    Implements IDisposable
    Implements clsRefreshTab


    Property _prop01User As clsWSNasaUser

    Private _pcTargetProsesPKB As String = ""

    Private frmModal As XtraForm

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ucWS24G301OUTBOUNDPKB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _cm03InitControl()

        mnubarSave.Visibility = BarItemVisibility.Never
        mnubarPickingSKU.Visibility = BarItemVisibility.Never
        mnubarPrintPicking.Visibility = BarItemVisibility.Never
        mnubarGrid.Visibility = BarItemVisibility.Never
        mnubarPicker.Visibility = BarItemVisibility.Never
        mnubarAggregateAirwayBill.Visibility = BarItemVisibility.Never

        mnubarDateProsesTransaksi.EditValue = Today.Date

        If _prop01User._UserProp02cUserID = "141202" Then
            mnubarGrid.Visibility = BarItemVisibility.Always
        End If

        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        BarManager1.AllowCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10

    End Sub

    Public Sub RefreshData() Implements clsRefreshTab.RefreshTab
        Cursor = Cursors.WaitCursor
        Select Case _pcTargetProsesPKB
            Case "100"
                _cm01DisplayNewPKBUntilSuratJalan("100")
                _gdOutboundPKB.Refresh()
            Case "101"
                _cm01DisplayNewPKBUntilSuratJalan("101")
                _gdOutboundPKB.Refresh()
        End Select
        Cursor = Cursors.Default
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01DisplayNewPKBUntilSuratJalan(ByVal prmcNomorProses As String)
        With _gdOutboundPKB
            ._prop01User = _prop01User
            Select Case prmcNomorProses
                Case "5051", "5052"    'Picking + Create SuratJalan'
                    ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB
                Case "505015"  'Confirm Delivered NON Ekspedisi'
                Case "505012"  'Airway Bill by Ekspedisi'
                Case "505013"  'Confirm Pickup by Ekspedisi'
                Case "505014"  'Confirm Delivered by Ekspedisi'
                Case "100"     'All Process'
            End Select

        End With
        _gdOutboundPKB.__pbWSGridParentChild01InitGrid()
        _gdOutboundPKB.__pbWSGridParentChild02Clear()
        _gdOutboundPKB.__pbWSGridParentChild03Display(prmcNomorProses)

    End Sub

    Private Sub _cm01DisplaySuratJalanUntilDelivered()
        With _gdOutboundPKB
            ._prop01User = _prop01User
            ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._Target505015PKBProsesSuratJalan
        End With

        _gdOutboundPKB.__pbWSGridParentChild01InitGrid()
        _gdOutboundPKB.__pbWSGridVisibilityCheckSelectAll(True)

        _gdOutboundPKB.__pbWSGridParentChild02Clear()
        _gdOutboundPKB.__pbWSGridParentChild03Display()
    End Sub

    Private Sub _cm02PrintPickingBRJ()
        Dim pdtParent As New DataTable
        Dim objParent As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtParent}
        objParent.dtInitsTABLESMALL()

        Select Case _pcTargetProsesPKB
            Case "100"
                _gdOutboundPKB._cm26GetDataPKBForPrintPicking(objParent)
            Case "101"
                _gdOutboundPKB._cm26GetDataPKBForPrintSJ(objParent)
        End Select

        Dim jumlahRecord As Integer = objParent.prop_dtsTABLESMALL.Rows.Count

        If jumlahRecord > 0 Then
            Select Case _pcTargetProsesPKB
                Case "100"
                    _cm022PrintPickingBRJParentChild(objParent)
                Case "101"
                    '_cm022PrintPickingBRJParentChildSJ(parentData)
                    _cm022PrintPickingBRJParentChild(objParent)

            End Select
        Else
            MsgBox("We couldn't find any data. 🙏🏻", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub

    '========================== NOT USED ==========================
    'Private Sub _cm021PrintPickingBRJRegular(ByVal objData As clsWSNasaTemplateDataTiny)
    '    Cursor = Cursors.WaitCursor

    '    Dim objPreview As New XtraReport

    '    Dim objPrint As New rptWS24IE01LISTPICKING With {._prop01Picker = rsobjPicker.GetDisplayText(mnubarPicker.EditValue)}

    '    objPrint.DataSource = objData.prop_dtsTABLETINY
    '    objPrint.CreateDocument()

    '    objPreview.Pages.AddRange(objPrint.Pages)
    '    objPreview.ShowPreview

    '    Cursor = Cursors.Default
    'End Sub
    '=============================================================

    Private Sub _cm022PrintPickingBRJParentChild(ByVal objDataParent As clsWSNasaTemplateDataSmall) ', Optional ByVal objDataChild As clsWSNasaTemplateDataTiny)

        Cursor = Cursors.WaitCursor
        Select Case _pcTargetProsesPKB
            Case "100"
                Dim fullTable As DataTable = objDataParent.prop_dtsTABLESMALL
                If fullTable Is Nothing OrElse fullTable.Rows.Count = 0 Then
                    Cursor = Cursors.Default
                    MessageBox.Show("Data kosong.")
                    Return
                End If

                Dim objPrint As New xr24LE01RP_PickingList With {
                    .DataSource = fullTable,
                    ._prop03Picker = rsobjPicker.GetDisplayText(mnubarPicker.EditValue),
                    ._prop04NoPicking = _cm023ProsesSaveNomorPickingList(objDataParent),
                    .PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4,
                    .Margins = New DevExpress.Drawing.DXMargins(0, 0, 0, 0),
                    .DisplayName = $"PRINT PICKING"
                }

                objPrint.CreateDocument()
                objPrint.PrintingSystem.ShowMarginsWarning = False
                objPrint.ShowPreview()

            Case "101"
                Dim fullTable As DataTable = objDataParent.prop_dtsTABLESMALL
                If fullTable Is Nothing OrElse fullTable.Rows.Count = 0 Then
                    Cursor = Cursors.Default
                    MessageBox.Show("Data kosong.")
                    Return
                End If

                ' Ambil semua nilai unik dari k01String
                Dim distinctK01Values = fullTable.AsEnumerable() _
                .Select(Function(r) r.Field(Of String)("k01String")) _
                .Distinct() _
                .ToList()

                Dim objPreview As New XtraReport()

                For Each k01 In distinctK01Values
                    ' Filter data untuk k01String saat ini
                    Dim filteredRows = fullTable.Select($"k01String = '{k01}'")
                    If filteredRows.Length = 0 Then Continue For

                    Dim filteredTable As DataTable = filteredRows.CopyToDataTable()

                    ' Buat report untuk k01String
                    Dim objPrint As New xr24LE03RP_SuratJalan With {
                    .DataSource = filteredTable,
                    .PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4,
                    .Margins = New DevExpress.Drawing.DXMargins(0, 0, 0, 0),
                    .DisplayName = $"PRINT SJ - {k01}"
                    }
                    '.Margins = New System.Drawing.Printing.Margins(25, 25, 75, 75),

                    objPrint.CreateDocument()

                    ' Gabungkan halaman ke preview utama
                    objPreview.Pages.AddRange(objPrint.Pages)
                Next

                If objPreview.Pages.Count > 0 Then
                    objPreview.PrintingSystem.ShowMarginsWarning = False
                    objPreview.ShowPreview()

                End If
                Dim result As DialogResult = MessageBox.Show("Do you need this data in an Excel file?", "Export Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                Dim exportedFiles As New List(Of String)()
                If result = DialogResult.OK Then

                    Dim folderPath As String = $"C:\MERSY\SuratJalan{Now.Year}"

                    If Not Directory.Exists(folderPath) Then
                        Directory.CreateDirectory(folderPath)
                    End If

                    For Each k01 In distinctK01Values
                        Dim filteredTable = fullTable.Clone()
                        For Each row In fullTable.AsEnumerable().Where(Function(r) r.Field(Of String)("k01String") = k01)
                            filteredTable.ImportRow(row)
                        Next

                        Dim filePath = ExportSuratJalan(filteredTable, folderPath)
                        exportedFiles.Add(filePath)
                    Next

                    If exportedFiles.Count > 0 Then
                        Dim message = "Berhasil diekspor:" & vbCrLf & String.Join(vbCrLf, exportedFiles)
                        MessageBox.Show(message, "Export Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If
        End Select

        Cursor = Cursors.Default

    End Sub

    Private Function ExportSuratJalan(fullTable As DataTable, outputFolder As String)
        Dim workbook As New Workbook()
        Dim sheet = workbook.Worksheets(0)
        sheet.Name = "SuratJalanDetailReportWithLogo"

        ' ===== JUDUL BESAR =====
        sheet.MergeCells(sheet.Range.FromLTRB(5, 2, 27, 2)) ' F3 to AB3
        sheet.Cells(2, 5).Value = "SURAT JALAN"
        sheet.Cells(2, 5).Font.Size = 14
        sheet.Cells(2, 5).Font.Bold = True
        sheet.Cells(2, 5).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

        ' ===== HEADER ATAS =====
        Dim k01 = fullTable.Rows(0)("k01String").ToString()
        Dim toko = "TOKO: " & fullTable.Rows(0)("f09String").ToString()

        sheet.Cells("C5").Value = k01
        sheet.Cells("C7").Value = toko

        ' ===== DAFTAR PO HORIZONTAL =====
        Dim distinctPOs = fullTable.AsEnumerable().
        Select(Function(r) r.Field(Of String)("k02String")).Distinct().ToList()

        Dim poMergeRanges As New List(Of Tuple(Of Integer, Integer)) From {
        Tuple.Create(1, 5),    ' B to F
        Tuple.Create(6, 14),   ' G to O
        Tuple.Create(15, 18),  ' P to S
        Tuple.Create(19, 25),  ' T to Z
        Tuple.Create(26, 31)   ' AA to AF
    }

        Dim poStartRow As Integer = 8
        Dim currentRow As Integer = poStartRow
        Dim poIndex As Integer = 0

        For i = 0 To distinctPOs.Count - 1
            Dim po = distinctPOs(i)
            Dim mergeIndex = poIndex Mod poMergeRanges.Count
            Dim colStart = poMergeRanges(mergeIndex).Item1
            Dim colEnd = poMergeRanges(mergeIndex).Item2

            sheet.MergeCells(sheet.Range.FromLTRB(colStart, currentRow, colEnd, currentRow))
            sheet.Cells(currentRow, colStart).Value = po
            sheet.Cells(currentRow, colStart).Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
            poIndex += 1

            If poIndex Mod poMergeRanges.Count = 0 Then
                currentRow += 1
            End If
        Next

        ' ===== TABEL DETAIL =====
        Dim headerRow As Integer = currentRow + 2
        Dim dataStartRow As Integer = headerRow + 1

        ' Header
        sheet.MergeCells(sheet.Range.FromLTRB(1, headerRow, 2, headerRow)) : sheet.Cells(headerRow, 1).Value = "No."
        sheet.Cells(headerRow, 3).Value = "Segmen"
        sheet.MergeCells(sheet.Range.FromLTRB(4, headerRow, 7, headerRow)) : sheet.Cells(headerRow, 4).Value = "SKU"
        sheet.MergeCells(sheet.Range.FromLTRB(8, headerRow, 10, headerRow)) : sheet.Cells(headerRow, 8).Value = "Product Id"
        sheet.MergeCells(sheet.Range.FromLTRB(11, headerRow, 15, headerRow)) : sheet.Cells(headerRow, 11).Value = "Product Code"
        sheet.MergeCells(sheet.Range.FromLTRB(16, headerRow, 17, headerRow)) : sheet.Cells(headerRow, 16).Value = "Item"
        sheet.MergeCells(sheet.Range.FromLTRB(18, headerRow, 21, headerRow)) : sheet.Cells(headerRow, 18).Value = "Kadar Emas"
        sheet.MergeCells(sheet.Range.FromLTRB(22, headerRow, 23, headerRow)) : sheet.Cells(headerRow, 22).Value = "Size"
        sheet.Cells(headerRow, 24).Value = "Color"
        sheet.MergeCells(sheet.Range.FromLTRB(25, headerRow, 26, headerRow)) : sheet.Cells(headerRow, 25).Value = "Berat"
        sheet.MergeCells(sheet.Range.FromLTRB(27, headerRow, 28, headerRow)) : sheet.Cells(headerRow, 27).Value = "Qty"
        sheet.MergeCells(sheet.Range.FromLTRB(29, headerRow, 33, headerRow)) : sheet.Cells(headerRow, 29).Value = "Nomor Order"

        ' Format header
        Dim headerRange = sheet.Range.FromLTRB(1, headerRow, 33, headerRow)
        headerRange.Font.Bold = True
        headerRange.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center
        headerRange.Fill.BackgroundColor = System.Drawing.Color.LightGray

        ' ===== ISI DATA DENGAN MERGE SESUAI HEADER =====
        Dim row = dataStartRow
        Dim totalBerat As Double = 0
        Dim totalQty As Integer = 0

        For r = 0 To fullTable.Rows.Count - 1
            sheet.MergeCells(sheet.Range.FromLTRB(1, row, 2, row)) : sheet.Cells(row, 1).Value = (r + 1).ToString()
            sheet.Cells(row, 3).Value = fullTable.Rows(r)("f04String").ToString()
            sheet.MergeCells(sheet.Range.FromLTRB(4, row, 7, row)) : sheet.Cells(row, 4).Value = fullTable.Rows(r)("f02String").ToString()
            sheet.MergeCells(sheet.Range.FromLTRB(8, row, 10, row)) : sheet.Cells(row, 8).Value = fullTable.Rows(r)("f01String").ToString()
            sheet.MergeCells(sheet.Range.FromLTRB(11, row, 15, row)) : sheet.Cells(row, 11).Value = fullTable.Rows(r)("k03String").ToString()
            sheet.MergeCells(sheet.Range.FromLTRB(16, row, 17, row)) : sheet.Cells(row, 16).Value = fullTable.Rows(r)("f06String").ToString()
            sheet.MergeCells(sheet.Range.FromLTRB(18, row, 21, row)) : sheet.Cells(row, 18).Value = fullTable.Rows(r)("f05String").ToString()
            sheet.MergeCells(sheet.Range.FromLTRB(22, row, 23, row)) : sheet.Cells(row, 22).Value = fullTable.Rows(r)("f07String").ToString()
            sheet.Cells(row, 24).Value = fullTable.Rows(r)("f08String").ToString()
            sheet.MergeCells(sheet.Range.FromLTRB(25, row, 26, row)) : sheet.Cells(row, 25).Value = Convert.ToDouble(fullTable.Rows(r)("f01Double"))
            sheet.MergeCells(sheet.Range.FromLTRB(27, row, 28, row)) : sheet.Cells(row, 27).Value = Convert.ToInt32(fullTable.Rows(r)("f01SmallInt"))
            sheet.MergeCells(sheet.Range.FromLTRB(29, row, 33, row)) : sheet.Cells(row, 29).Value = fullTable.Rows(r)("k02String").ToString()

            totalBerat += Convert.ToDouble(fullTable.Rows(r)("f01Double"))
            totalQty += Convert.ToInt32(fullTable.Rows(r)("f01SmallInt"))

            row += 1
        Next

        ' ===== TOTAL BERAT & QTY =====
        sheet.Cells(row, 24).Value = "Total"
        sheet.Cells(row, 24).Font.Bold = True

        sheet.MergeCells(sheet.Range.FromLTRB(25, row, 26, row))
        sheet.Cells(row, 25).Value = totalBerat
        sheet.Cells(row, 25).Font.Bold = True
        sheet.Cells(row, 25).NumberFormat = "#,##0.00"

        sheet.MergeCells(sheet.Range.FromLTRB(27, row, 28, row))
        sheet.Cells(row, 27).Value = totalQty
        sheet.Cells(row, 27).Font.Bold = True
        sheet.Cells(row, 27).NumberFormat = "#,##0"

        Dim totalRange = sheet.Range.FromLTRB(24, row, 28, row)
        totalRange.Fill.BackgroundColor = System.Drawing.Color.LightGray
        totalRange.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center

        ' ===== TANDA TANGAN DAN KETERANGAN =====
        row += 2 ' lompat 1 baris

        ' Baris: Diserahkan oleh, Diterima oleh
        sheet.MergeCells(sheet.Range.FromLTRB(2, row, 6, row)) ' C to G
        sheet.Cells(row, 2).Value = "Diserahkan oleh,"
        sheet.Cells(row, 2).Font.Bold = True

        sheet.MergeCells(sheet.Range.FromLTRB(23, row, 29, row)) ' X to AD
        sheet.Cells(row, 23).Value = "Diterima oleh,"
        sheet.Cells(row, 23).Font.Bold = True

        row += 2 ' lompat 1 baris lagi

        ' Baris: Nama dan Toko (underline)
        Dim distinctNama As String = String.Join(", ", fullTable.AsEnumerable().
        Select(Function(r) r.Field(Of String)("f03String")).Distinct())

        sheet.MergeCells(sheet.Range.FromLTRB(2, row, 12, row)) ' C to M
        sheet.Cells(row, 2).Value = distinctNama
        sheet.Cells(row, 2).Font.UnderlineType = UnderlineType.Single

        sheet.MergeCells(sheet.Range.FromLTRB(23, row, 31, row)) ' X to AF
        sheet.Cells(row, 23).Value = toko
        sheet.Cells(row, 23).Font.UnderlineType = UnderlineType.Single

        ' ===== AUTOFIT KOLOM =====
        For i = 1 To 33
            sheet.Columns(i).WidthInCharacters += 2
        Next

        ' ===== SIMPAN FILE =====

        Dim invalidChars = Path.GetInvalidFileNameChars()
        Dim saveK01 = New String(k01.Select(Function(c) If(invalidChars.Contains(c), "_"c, c)).ToArray())
        Dim saveToko = New String(fullTable.Rows(0)("f09String").ToString().Select(Function(c) If(invalidChars.Contains(c), "_"c, c)).ToArray())

        Dim outputFile = Path.Combine(outputFolder, $"{Now:MMdd_HHmmss}_{saveK01}_{saveToko}.xlsx")
        workbook.SaveDocument(outputFile, DocumentFormat.OpenXml)
        Return outputFile
    End Function

    ' Dim outputFile = Path.Combine(outputFolder, $"ESJ_&_{Now:yyyyMMdd_HHmmss}.xlsx")

    Private Function _cm023ProsesSaveNomorPickingList(ByVal pdtDataPickingList As clsWSNasaTemplateDataSmall) As String
        Dim pcNoDocPicking As String = ""

        If pdtDataPickingList.prop_dtsTABLESMALL.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            ' Generate nomor picking
            Using objNoDoc As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = "WSPICKING"}
                pcNoDocPicking = objNoDoc._pb51GetDataIncNoDocWarehouse()
            End Using

            ' Siapkan DataTable untuk disimpan
            Dim pdtNoDOcPicking As New DataTable
            Dim objNoDocPicking As New clsWSNasaTemplateKey With {.prop_dtKEY = pdtNoDOcPicking}
            objNoDocPicking.dtInitKEY()

            For Each dtRow As DataRow In pdtDataPickingList.prop_dtsTABLESMALL.Rows
                objNoDocPicking.dtAddNewKEY(
                pcNoDocPicking,
                dtRow("k01String"),
                mnubarPicker.EditValue,
                rsobjPicker.GetDisplayText(mnubarPicker.EditValue),
                "")
            Next

            Cursor = Cursors.Default

            ' Proses Save
            If objNoDocPicking.prop_dtKEY.Rows.Count > 0 Then
                Cursor = Cursors.WaitCursor
                Dim pnJmlRec As Integer

                Using objPickingList As New clsWSNasaHelper
                    pnJmlRec = objPickingList._pbWSNasaHelperExec01SPSQLProses(_prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS, 2,
                                                                               "spWSOutboundPKB5051PickingListSave34", "@DataKey", objNoDocPicking.prop_dtKEY)
                End Using

                Cursor = Cursors.Default

            End If
        End If

        Return pcNoDocPicking
    End Function
    '        If pnJmlRec > 0 Then
    '            MsgBox("Nomor PICKING LIST : " & pcNoDocPicking, vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

    '            Clipboard.Clear()
    '            Clipboard.SetText(pcNoDocPicking)
    '        Else
    '            MsgBox("Maaf ... Proses Simpan data PICKING LIST ... GAGAL ", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '            pcNoDocPicking = "" ' Kosongkan karena gagal simpan
    '        End If
    '    Else
    '        MsgBox("Maaf ... Tidak ada data untuk disimpan.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '        pcNoDocPicking = ""
    '    End If
    'Else
    '    MsgBox("Data kosong.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '    pcNoDocPicking = ""


    Private Sub _cm03InitControl()
        Dim pdtPicker As New DataTable

        Using objMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtPicker = objMaster.__pb02GetDataTable21TargetWarehouseByUser("5040", "50403")
        End Using

        With rsobjPicker
            .DataSource = pdtPicker
            .ValueMember = "f05String"
            .DisplayMember = "f06String"
        End With
        _gdOutboundPKB.__pbWSGridParentChild01InitGrid()

    End Sub

    Private Sub _cm10SaveProsesPKB()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk menyimpan data ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            If _pcTargetProsesPKB = "100" Then
                _cm12SaveProsesNewPKBUntilSuratJalan(False)
            Else
                If _pcTargetProsesPKB = "101" Then
                    _cm13SaveProsesPKBPickupUntilDelivered()
                End If
            End If
        Else
            MsgBox("Maaf ... Proses Simpan Data PICKING ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    'Valen        : Kamis, 06 Februari 2025.
    'Aggregate SJ : Cust,Brand,Kadar,CO/PO,TOP.
    Private Sub _cm11PrepareAggregatePickingForSuratJalan(ByVal objPickingParent As clsWSNasaTemplateDataMediumPlus,
                                                          ByRef objSuratJalan As clsWSNasaTemplateDataMedium)
        Cursor = Cursors.WaitCursor

        '1. Group By - per PKB/Order
        Dim pdtGroupByPKBOrder As New DataTable

        Using objGroupByPKBOrder As clsWSNasaHelper = New clsWSNasaHelper
            pdtGroupByPKBOrder = objGroupByPKBOrder._pbWSNasaHelperExec06SPSELEPassTblTypeToDataTable03(
                                _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                "spWSPPickingForSJ01", "@DataPicking", objPickingParent.prop_dtsTABLEMEDIUMPLUS)
        End Using

        Dim pdtTemp28 As New DataTable
        Dim objTemp28 As New clsWSNasaTemplateDataMedium With {.prop_dtsTABLEMEDIUM = pdtTemp28}
        objTemp28.dtInitsTABLEMEDIUM()

        For Each dtRow As DataRow In pdtGroupByPKBOrder.Rows
            objTemp28.dtAddNewsTABLEMEDIUM("", "", "",
                                           dtRow("f01String"), dtRow("f02String"), "", "", dtRow("f05String"),
                                           dtRow("f06String"), dtRow("f07String"), dtRow("f08String"), dtRow("f09String"), dtRow("f10String"),
                                           "", "", "", "", dtRow("f11String"), "", "", "", "", "",
                                           0, 0, dtRow("f01Int"), dtRow("f01Double"), 0.0, 0.0,
                                           "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "", "", "", "", "")
        Next

        '2. Group By - Surat Jalan (tanpa - PKB/Order) : Hanya untuk mengisi data NoSJ saja.
        Dim pdtGroupBySuratJalan As New DataTable
        Using objGroupBySuratJalan As clsWSNasaHelper = New clsWSNasaHelper
            pdtGroupBySuratJalan = objGroupBySuratJalan._pbWSNasaHelperExec06SPSELEPassTblTypeToDataTable03(
                                   _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                   "spWSPPickingForSJ02", "@DataPickingGroupBy", objTemp28.prop_dtsTABLEMEDIUM)
        End Using


        ' ===================== UPDATED BY AKIRRA - 15/04/2025 =====================
        ' change No.SJ to specific order
        Dim pcOrderType = ""
        For Each dtRow As DataRow In pdtGroupBySuratJalan.Rows
            pcOrderType = dtRow("f15String").ToString()
        Next

        Dim pcTypeNoDocSJ = ""
        If pcOrderType = "CO" Then
            pcTypeNoDocSJ = "WSSJCUSTOMER"
        ElseIf pcOrderType = "PO" Then
            pcTypeNoDocSJ = "WSSJCUSTOMERPO"
        ElseIf pcOrderType = "SS" Then
            pcTypeNoDocSJ = "WSSJKAE"
        ElseIf pcOrderType = "CS" Then
            pcTypeNoDocSJ = "WSSJCONSIGNMENT"
        ElseIf pcOrderType = "PINJAMAN" Then
            pcTypeNoDocSJ = "WSSJMARKETING"
        ElseIf pcOrderType = "GIFTAWAY" Then
            pcTypeNoDocSJ = "WSSJMARKETINGGO"
        ElseIf pcOrderType = "XB" Then
            pcTypeNoDocSJ = "WSSJPAMERAN"
            'ElseIf pcOrderType = "IN" Then
            '    pcKodeNoDocSJ = "WSSJ ?"    ' sj internal gak ada ya? yaudah
        Else
            pcTypeNoDocSJ = "WSSURATJALAN"
        End If

        ' ======================================================================

        Dim pcNoDocSJ = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = pcTypeNoDocSJ}
            For Each dtRow As DataRow In pdtGroupBySuratJalan.Rows
                pcNoDocSJ = ""
                pcNoDocSJ = objNoDoc._pb51GetDataIncNoDocWarehouse()
                dtRow("k02String") = pcNoDocSJ
            Next

            pdtGroupBySuratJalan.AcceptChanges()
        End Using

        '3. Update Nomor SJ-nya ke 'Group By - per PKB/Order' menjadi 'SuratJalan per PKB'
        For Each dtRowSJ As DataRow In pdtGroupBySuratJalan.Rows
            For Each dtRowPKBOrder As DataRow In pdtGroupByPKBOrder.Rows
                If dtRowSJ("f01String") = dtRowPKBOrder("f01String") And
                   dtRowSJ("f05String") = dtRowPKBOrder("f05String") And
                   dtRowSJ("f07String") = dtRowPKBOrder("f07String") And
                   dtRowSJ("f09String") = dtRowPKBOrder("f09String") And
                   dtRowSJ("f15String") = dtRowPKBOrder("f11String") Then

                    objSuratJalan.dtAddNewsTABLEMEDIUM("", dtRowSJ("k02String"), dtRowPKBOrder("k02String"),
                                           dtRowPKBOrder("f01String"), dtRowPKBOrder("f02String"), "", "", dtRowPKBOrder("f05String"),
                                           dtRowPKBOrder("f06String"), dtRowPKBOrder("f07String"), dtRowPKBOrder("f08String"), dtRowPKBOrder("f09String"), dtRowPKBOrder("f10String"),
                                           "NEW", "", "", "", dtRowPKBOrder("f11String"), "", "", "", "", "",
                                           0, dtRowPKBOrder("f01Int"), 0, dtRowPKBOrder("f01Double"), 0.0, 0.0,
                                           "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "", "", "", "", "")

                End If

            Next
        Next

        '4. Update No.Picking/KAE 
        For Each dtRowSJ As DataRow In objSuratJalan.prop_dtsTABLEMEDIUM.Rows
            For Each dtPickingParent As DataRow In objPickingParent.prop_dtsTABLEMEDIUMPLUS.Rows
                If dtRowSJ("k03String") = dtPickingParent("k02String") Then

                    dtRowSJ("f16String") = dtPickingParent("k03String")
                    dtRowSJ("f03String") = dtPickingParent("f03String")
                    dtRowSJ("f04String") = dtPickingParent("f04String")

                End If
            Next
        Next

        objSuratJalan.prop_dtsTABLEMEDIUM.AcceptChanges()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm12SaveProsesNewPKBUntilSuratJalan(ByVal IsPickingSKUIncludeCreateSJ As Boolean)
        Dim pdtPKBParent As New DataTable
        Dim objPKBParent As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtPKBParent}
        objPKBParent.dtInitsTABLEMEDIUMPLUSPLUS()

        Dim pdtPKBChild As New DataTable
        Dim objPKBChild As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtPKBChild}
        objPKBChild.dtInitsTABLEMEDIUMPLUSPLUS()

        _gdOutboundPKB._cm24GetDataPKBForSavePickingBRJ(objPKBParent, objPKBChild)
        _gdOutboundPKB._cm25GetDataPKBForSaveExceptPickingAirwayBill(objPKBParent, objPKBChild)

        If objPKBParent.prop_dtsTABLEMEDIUMPLUS.Rows.Count > 0 Then
            Dim pnJmlRec As Integer = 0
            Dim pcPesan As String = ""

            If IsPickingSKUIncludeCreateSJ Then
                Dim pdtWSTable28 As New DataTable
                Dim objWSTable28 As New clsWSNasaTemplateDataMedium With {.prop_dtsTABLEMEDIUM = pdtWSTable28}
                objWSTable28.dtInitsTABLEMEDIUM()

                _cm11PrepareAggregatePickingForSuratJalan(objPKBParent, objWSTable28)

                Using objOutbound As clsWSNasaHelper = New clsWSNasaHelper
                    pnJmlRec = objOutbound._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS, 2, "spWSOutboundPKB01SaveAll",
                                    "@DataParent", objPKBParent.prop_dtsTABLEMEDIUMPLUS,
                                    "@DataChild", objPKBChild.prop_dtsTABLEMEDIUMPLUS,
                                    "@tpDataForSaving", objWSTable28.prop_dtsTABLEMEDIUM)
                End Using

                pcPesan = "Proses Simpan Data...PICKING dan SURATJALAN... SUKSES."

            Else
                Using objOutbound As clsWSNasaHelper = New clsWSNasaHelper
                    pnJmlRec = objOutbound._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS, 2, "spWSOutboundPKB01SaveAll",
                                    "@DataParent", objPKBParent.prop_dtsTABLEMEDIUMPLUS,
                                    "@DataChild", objPKBChild.prop_dtsTABLEMEDIUMPLUS)
                End Using

                pcPesan = "Proses Simpan Data PICKING... SUKSES."
            End If

            If pnJmlRec > 0 Then
                MsgBox(pcPesan, vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

                ' ===================== CREATED BY AKIRRA - 25/06/03 =====================
                ' otomatis menutup container modal PICKING setelah data berhasil tersimpan.
                If frmModal IsNot Nothing Then
                    frmModal.Close()
                    frmModal = Nothing
                End If
                ' =========================================================================

                _cm01DisplayNewPKBUntilSuratJalan("100")
            End If
        Else
            MsgBox("Maaf ... Data unt Proses PKB ... KOSONG.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub

    ''505013','Confirm Pickup by Ekspedisi'
    ''505014','Confirm Delivered by Ekspedisi'
    ''505015','Confirm Delivered NON Ekspedisi'
    Private Sub _cm13SaveProsesPKBPickupUntilDelivered()
        Dim pdtPKBParent As New DataTable
        Dim objPKBParent As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtPKBParent}
        objPKBParent.dtInitsTABLEMEDIUMPLUSPLUS()

        Dim pdtPKBChild As New DataTable
        Dim objPKBChild As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtPKBChild}
        objPKBChild.dtInitsTABLEMEDIUMPLUSPLUS()

        _gdOutboundPKB._cm27GetDataPKBUntilDelivered(objPKBParent, objPKBChild)

        For Each dtRow As DataRow In objPKBParent.prop_dtsTABLEMEDIUMPLUS.Rows
            dtRow("f02Date") = mnubarDateProsesTransaksi.EditValue
        Next
        objPKBParent.prop_dtsTABLEMEDIUMPLUS.AcceptChanges()

        For Each dtRow As DataRow In objPKBChild.prop_dtsTABLEMEDIUMPLUS.Rows
            dtRow("f02Date") = mnubarDateProsesTransaksi.EditValue
        Next
        objPKBChild.prop_dtsTABLEMEDIUMPLUS.AcceptChanges()

        If objPKBParent.prop_dtsTABLEMEDIUMPLUS.Rows.Count > 0 Then

            Dim pnJmlRec As Integer
            Using objOutbound As clsWSNasaHelper = New clsWSNasaHelper
                pnJmlRec = objOutbound._pbWSNasaHelperExec01SPSQLProses(
                                _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS, 2, "spWSOutboundPKB505015SavePickupDelivered",
                                "@DataParent", objPKBParent.prop_dtsTABLEMEDIUMPLUS,
                                "@DataChild", objPKBChild.prop_dtsTABLEMEDIUMPLUS)
            End Using

            If pnJmlRec > 0 Then
                MsgBox("Proses Simpan Data ... SUKSES.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

                _cm01DisplaySuratJalanUntilDelivered()
            End If
        Else
            MsgBox("Maaf ... Data unt Proses PKB ... KOSONG.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If
    End Sub


#End Region

#Region "public - method"
    Public Delegate Sub __dlgSavePickingBRJIncludeSJ(ByVal prmlBoolean As Boolean)

    Public Sub _ivkSavePickingDanSuratJalan(ByVal prmlPickingDanSJ As Boolean)
        Dim pcPesan As String = ""
        Dim pcPesanBatal As String = ""

        If prmlPickingDanSJ Then
            pcPesan = "Apakah anda yakin ingin menyimpan data PICKING dan SJ ini ... ?"
            pcPesanBatal = "Maaf ... Proses Simpan Data PICKING dan SJ ... DIBATALKAN..."
        Else
            pcPesan = "Apakah anda yakin ingin menyimpan data PICKING ini ... ?"
            pcPesanBatal = "Maaf ... Proses Simpan Data PICKING ... DIBATALKAN..."
        End If

        Dim plYes As MsgBoxResult = MsgBox(pcPesan, vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm12SaveProsesNewPKBUntilSuratJalan(prmlPickingDanSJ)
        Else
            MsgBox(pcPesanBatal, vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub
#End Region

#Region "control - event"
    Private Sub mnuBarRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBarRefresh.ItemClick
        If _pcTargetProsesPKB = "100" Then
            _cm01DisplayNewPKBUntilSuratJalan("100")
            _gdOutboundPKB.Refresh()
        Else
            _cm01DisplayNewPKBUntilSuratJalan("101")
            _gdOutboundPKB.Refresh()
        End If
    End Sub
    Private Sub mnubarSave_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarSave.ItemClick
        Me.ActiveControl = Nothing
        _cm10SaveProsesPKB()
    End Sub

    Private Sub mnubarGrid_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarGrid.ItemClick
        _gdOutboundPKB.__pbWSGridParentChild04CreateSettingColumnWidth("OutboundPKB")
        MsgBox("done")
    End Sub

    Private Sub mnubarPickingSKU_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarPickingSKU.ItemClick
        'If mnubarPicker.EditValue <> "" Then
        Me.ActiveControl = Nothing

        Dim pdtDataForProsesPicking As New DataTable
        _gdOutboundPKB._cm24GetDataPKBForPickingList(pdtDataForProsesPicking, True)

        If pdtDataForProsesPicking.Rows.Count > 0 Then
            mnubarSave.Visibility = BarItemVisibility.Never

            Dim objSKUPicking As New ucWS24HG01PICKING With {._prop01User = _prop01User,
                                                             ._prop02TargetSKU = ucWS24HG01PICKING._pbEnumTargetSKU._SKUPicking,
                                                             ._prop03GridParentChild = _gdOutboundPKB,
                                                             ._prop05DataStock = pdtDataForProsesPicking,
                                                             ._prop06FormPicking = Me}
            Dim objSize As New Size With {.Width = objSKUPicking.Size.Width,
                                      .Height = objSKUPicking.Size.Height + 25}

            frmModal = New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                           .MinimizeBox = False, .ShowIcon = False,
                                           .StartPosition = FormStartPosition.CenterParent,
                                           .Text = "SKU Picking | " & _prop01User._UserProp01cTitle}
            frmModal.AddControl(objSKUPicking)

            frmModal.ShowDialog()
            _cm01DisplayNewPKBUntilSuratJalan("100")
        Else
            MsgBox("Sorry, the PICKER is still empty. 🙏🏻", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If

        '_cm01DisplayNewPKBUntilSuratJalan("100")
    End Sub

    Private Sub mnubarPrintPicking_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarPrintPicking.ItemClick
        Me.ActiveControl = Nothing

        Select Case _pcTargetProsesPKB
            Case "100"
                If String.IsNullOrWhiteSpace(mnubarPicker.EditValue?.ToString()) Then
                    MsgBox("Sorry, the PICKER is still empty. 🙏🏻", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
                    Exit Sub
                End If
                _cm02PrintPickingBRJ()

            Case "101"
                _cm02PrintPickingBRJ()
        End Select
        _cm01DisplayNewPKBUntilSuratJalan("100")
    End Sub



    Private Sub mnubarPicker_EditValueChanged(sender As Object, e As EventArgs) Handles mnubarPicker.EditValueChanged
        If mnubarPicker.EditValue <> "" Then
            With _gdOutboundPKB
                ._prop03String = mnubarPicker.EditValue
                ._prop04String = rsobjPicker.GetDisplayText(mnubarPicker.EditValue)
            End With

            Dim objUpdPicker As _dlgUpdatePicker = AddressOf _gdOutboundPKB.__ivkUpdPickerBRJ
            objUpdPicker.Invoke(mnubarPicker.EditValue, rsobjPicker.GetDisplayText(mnubarPicker.EditValue))
        End If
    End Sub

    Private Sub mnubarTargetProses01NewPKBSampaiSJ_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses01NewPKBSampaiSJ.ItemClick
        With _gdOutboundPKB
            ._prop01User = _prop01User
            ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB

            .__pbWSGridParentChild01InitGrid()
            .__pbWSGridVisibilityCheckSelectAll(False)
            .__pbWSGridParentChild02Clear()
            .__pbWSGridParentChild03Display()
        End With

        'Proses : '100','All Process'
        '_cm01DisplayNewPKBUntilSuratJalan("100")
        _pcTargetProsesPKB = "100"

        With mnubarPicker
            .Visibility = BarItemVisibility.Always
            .EditValue = ""
        End With
        mnubarPickingSKU.Visibility = BarItemVisibility.Always
        With mnubarPrintPicking
            .Visibility = BarItemVisibility.Always
            .Caption = "Print Picking List"
        End With

        mnubarAggregateAirwayBill.Visibility = BarItemVisibility.Never

        mnubarSave.Visibility = BarItemVisibility.Never
        mnuBarRefresh.Enabled = True
    End Sub

    Private Sub mnubarTargetProses02SJSampaiDelivered_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses02SJSampaiDelivered.ItemClick

        With _gdOutboundPKB
            ._prop01User = _prop01User
            ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._Target505015PKBProsesSuratJalan

            .__pbWSGridParentChild01InitGrid()
            .__pbWSGridVisibilityCheckSelectAll(True, False)
            .__pbWSGridParentChild02Clear()
            .__pbWSGridParentChild03Display()
        End With

        '_cm01DisplaySuratJalanUntilDelivered() '
        _pcTargetProsesPKB = "101"

        mnubarPicker.Visibility = BarItemVisibility.Never
        mnubarPickingSKU.Visibility = BarItemVisibility.Never
        With mnubarPrintPicking
            .Visibility = BarItemVisibility.Always
            .Caption = "Print Surat Jalan"

        End With

        mnubarAggregateAirwayBill.Visibility = BarItemVisibility.Always

        mnubarSave.Visibility = BarItemVisibility.Always
        mnuBarRefresh.Enabled = True
    End Sub

    Private Sub mnubarAggregateAirwayBill_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarAggregateAirwayBill.ItemClick
        Me.ActiveControl = Nothing
        _gdOutboundPKB._cmProsesAggregate505012AirwayBill()
    End Sub

    '***************** NOT USED ******************
    '*********************************************
    'Private Sub mnubarTargetProses01PickingSJ_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses01PickingSJ.ItemClick
    '    'Proses : '5051','Picking + Create SuratJalan'
    '    _cm02DisplayPKB("5051")

    '    mnubarPickingSKU.Visibility = BarItemVisibility.Always
    '    mnubarPrintPicking.Visibility = BarItemVisibility.Always
    'End Sub

    'Private Sub mnubarTargetProses02DeliverNONEkspedisi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses02DeliverNONEkspedisi.ItemClick
    '    'Proses : '505015','Confirm Delivered NON Ekspedisi'
    '    _cm02DisplayPKB("505015")

    '    mnubarPickingSKU.Visibility = BarItemVisibility.Never
    '    mnubarPrintPicking.Visibility = BarItemVisibility.Never
    'End Sub

    'Private Sub mnubarTargetProses03AirwayBill_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses03AirwayBill.ItemClick
    '    'Proses : '505012','Airway Bill by Ekspedisi'
    '    _cm02DisplayPKB("505012")

    '    mnubarPickingSKU.Visibility = BarItemVisibility.Never
    '    mnubarPrintPicking.Visibility = BarItemVisibility.Never
    'End Sub

    'Private Sub mnubarTargetProses04PickupEkspedisi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses04PickupEkspedisi.ItemClick
    '    'Proses : '505013','Confirm Pickup by Ekspedisi'
    '    _cm02DisplayPKB("505013")

    '    mnubarPickingSKU.Visibility = BarItemVisibility.Never
    '    mnubarPrintPicking.Visibility = BarItemVisibility.Never
    'End Sub

    'Private Sub mnubarTargetProses05DeliverEkspedisi_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses05DeliverEkspedisi.ItemClick
    '    'Proses : '505014','Confirm Delivered by Ekspedisi'
    '    _cm02DisplayPKB("505014")

    '    mnubarPickingSKU.Visibility = BarItemVisibility.Never
    '    mnubarPrintPicking.Visibility = BarItemVisibility.Never
    'End Sub

    'Private Sub mnubarTargetProses06AllProcess_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubarTargetProses06AllProcess.ItemClick
    '    'Proses : '100','All Process'
    '    _cm02DisplayPKB("100")

    '    mnubarPickingSKU.Visibility = BarItemVisibility.Always
    '    mnubarPrintPicking.Visibility = BarItemVisibility.Always
    'End Sub

#End Region

End Class
