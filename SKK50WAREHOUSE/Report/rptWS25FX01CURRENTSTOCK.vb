Imports System.Drawing.Printing
Imports DevExpress.Mvvm.Native
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports SKK01CORE
Imports SKK02OBJECTS

' ===================== CREATED BY AKIRRA - 25/06/24 =====================
' CURRENT STOCK TO VIEW SKU STOCK AND PRINT THE BARCODE.
' ini belum sempat dilanjutkan, saat ini baru berfungsi untuk show SKU & PRINT LABEL BARCODE SAJA. 
' siapapun tolong dilanjutkan saja, pindahkan semua fungsi dari CURRENT STOCK ke sini (CURRENT STOCK V2).

Public Class rptWS25FX01CURRENTSTOCK
    Implements IDisposable
    Implements clsRefreshTab

    Public Property _cUserInfo As clsWSNasaUser

    Private _oWsHelper As clsWSNasaHelper
    Private _oWsModelTiny As clsWSNasaTemplateDataTiny
    Private _oWsGetDtForSaving As clsWSNasaSelect4AllProsesMaster
    Private _oWsFetchDtForDisplay As clsWSNasaSelect4PivotGridReport

    Private vdtOrderMgmtSelected As DataTable

    'Private disposedValue As Boolean = False

#Region " *** FORM EVENTS *** "
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _oWsHelper = New clsWSNasaHelper
        _oWsGetDtForSaving = New clsWSNasaSelect4AllProsesMaster
        _oWsFetchDtForDisplay = New clsWSNasaSelect4PivotGridReport
        _oWsModelTiny = New clsWSNasaTemplateDataTiny
        _oWsModelTiny.dtInitsTABLETINY()


        vdtOrderMgmtSelected = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        'MyBase.Finalize()

        _oWsHelper.Dispose()
        _oWsGetDtForSaving.Dispose()
        _oWsFetchDtForDisplay.Dispose()
        _oWsModelTiny.Dispose()

        vdtOrderMgmtSelected.Dispose()

        BarManager1.Dispose()
        Bar1.Dispose()
        _gdCurrentStock.Dispose()
        'Dispose(False)
        MyBase.Finalize()
    End Sub


    'Public Overloads Sub Dispose() Implements IDisposable.Dispose
    '    If Not disposedValue Then
    '        MsgBox("Dispose dipanggil untuk " & Me.Name)

    '        ' Bersihkan resource Anda
    '        _oWsHelper?.Dispose()
    '        _oWsGetDtForSaving?.Dispose()
    '        _oWsModelTiny?.Dispose()
    '        vdtOrderMgmtSelected?.Dispose()

    '        BarManager1?.Dispose()
    '        Bar1?.Dispose()
    '        mnuBar01Save?.Dispose()
    '        mnuBar02Radio?.Dispose()
    '        _gdOrderMgmt?.Dispose()
    '        _gdOrderMgmtPcode?.Dispose()

    '        disposedValue = True
    '    End If

    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub rptWS25FX01CURRENTSTOCK_Load(sender As Object, e As EventArgs) Handles Me.Load
        _cmf01InitControl()
        _cmf02ClearControlVal()

        mnuBar01Target.EditValue = "SKU (Stock Keeping Unit)"

        tabPivot.PageVisible = False
    End Sub

    Public Sub RefreshData() Implements clsRefreshTab.RefreshTab


        _cmf04RefreshGrid()

    End Sub

#End Region


#Region " *** GRID EVENTS *** "

#End Region


#Region " *** CONTROL EVENTS *** "

    Private Sub TabPane1_SelectedPageChanged(sender As Object, e As SelectedPageChangedEventArgs) Handles TabPane1.SelectedPageChanged
        Cursor = Cursors.WaitCursor

        If TabPane1.SelectedPage Is tabTable Then
            _gdCurrentStock.Visible = True

            mnuBar01Target.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnuBar02Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        ElseIf TabPane1.SelectedPage Is tabPivot Then
            _gdCurrentStock.Visible = False


        End If
        If Me.IsHandleCreated Then
            Me.BeginInvoke(New MethodInvoker(AddressOf _cmf03InitData))
        Else
            AddHandler Me.HandleCreated, Sub()
                                             Me.BeginInvoke(New MethodInvoker(AddressOf _cmf03InitData))
                                         End Sub
        End If

        Cursor = Cursors.Default
    End Sub


    Private Sub mnuBar03Refresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar02Refresh.ItemClick
        Cursor = Cursors.WaitCursor

        '_cmf01InitControl()
        _cmf03InitData()

        Cursor = Cursors.Default
    End Sub

    Private Sub mnuBar04Stock_EditValueChanged(sender As Object, e As EventArgs) Handles mnuBar04Stock.EditValueChanged
        Cursor = Cursors.WaitCursor
        'MsgBox("bar editchanged" & mnuBar04Stock.EditValue)

        Dim _oWsGetDtForGrid As New clsWSNasaSelect4PivotGridReport With {._prop01User = _cUserInfo}

        Dim vsCheckedVal As String = mnuBar04Stock.EditValue.ToString()
        vsCheckedVal = vsCheckedVal.Replace("STOCK-WAREHOUSE", "STOCK")

        Dim vdtGrid As DataTable = _oWsGetDtForGrid._pbM302FetchDtCurrentStockSku(vsCheckedVal)

        With _gdCurrentStock
            ._prop01User = _cUserInfo
            ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetDisplayCurrentStockSku
            ._prop03pdtDataSourceGrid = Nothing
            ._prop03pdtDataSourceGrid = vdtGrid
        End With

        _cmf04RefreshGrid()

        Cursor = Cursors.Default
    End Sub

#End Region

#Region " *** CUSTOM METHODS / FUNCTIONS *** "
    Private Sub _cmf01InitControl()
        ' *** CLEARING ALL CONTROLS ***

        ' BarItem gaps
        barGap1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        barGap2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        barGap3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        barGap4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        barGap5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        barGap6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        ' Bar Items
        mnuBar01Target.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        ' Grid controls
        _gdCurrentStock.Visible = False

        ' TabPane and tabs
        TabPane1.Visible = False

        ' user control
        Root.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Me.Visible = False


        ' *** SHOWING ALL CONTROLS ***

        ' Layout controls
        Me.Visible = True
        Root.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        ' TabPane and tabs
        TabPane1.Visible = True

        ' Grid controls
        _gdCurrentStock.Visible = True

        ' BarItem gaps
        barGap1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        ' Bar Items
        mnuBar01Target.Visibility = DevExpress.XtraBars.BarItemVisibility.Always


        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        BarManager1.AllowCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 15
    End Sub

    Private Sub _cmf02ClearControlVal()
        mnuBar04Stock.EditValue = ""
    End Sub

    Private Sub _cmf03InitData()
        Cursor = Cursors.WaitCursor
        If TabPane1.SelectedPage Is tabTable Then
            Select Case mnuBar01Target.EditValue.ToString()
                Case "SKU (Stock Keeping Unit)"
                    Dim _oWsGetDtForRepo As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _cUserInfo}
                    Dim vdtStock As DataTable = _oWsGetDtForRepo._pbMF12FetchDtStockCurrentStock()

                    With _rpsStock
                        .DataSource = vdtStock
                        .ValueMember = "f19String"
                        .DisplayMember = "f19String"
                    End With

                    ' =======================================

                    Dim _oWsGetDtForGrid As New clsWSNasaSelect4PivotGridReport With {._prop01User = _cUserInfo}

                    Dim vsCheckedVal As String = If(mnuBar04Stock.EditValue IsNot Nothing, mnuBar04Stock.EditValue.ToString(), "")
                    vsCheckedVal = vsCheckedVal.Replace("STOCK-WAREHOUSE", "STOCK")

                    Dim vdtGrid As DataTable = _oWsGetDtForGrid._pbM302FetchDtCurrentStockSku(vsCheckedVal)

                    ' =======================================

                    With _gdCurrentStock
                        ._prop01User = _cUserInfo
                        ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetDisplayCurrentStockSku
                        ._prop03pdtDataSourceGrid = Nothing
                        ._prop03pdtDataSourceGrid = vdtGrid
                    End With

                Case "Product Code"
                    With _gdCurrentStock
                        ._prop01User = _cUserInfo
                        ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetDisplayCurrentStockPcode
                    End With
            End Select

        ElseIf TabPane1.SelectedPage Is tabPivot Then

        End If

        _cmf04RefreshGrid()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cmf04RefreshGrid()
        Cursor = Cursors.WaitCursor

        If TabPane1.SelectedPage Is tabTable Then
            _gdCurrentStock.__pbWSGridParentChild01InitGrid()
            _gdCurrentStock.__pbWSGridVisibilityCheckSelectAll(True, False)
            _gdCurrentStock.__pbWSGridParentChild02Clear()
            _gdCurrentStock.__pbWSGridParentChild03Display()

            _gdCurrentStock.Refresh()
            _gdCurrentStock.Focus()

        ElseIf TabPane1.SelectedPage Is tabPivot Then

        End If

        Cursor = Cursors.Default
    End Sub


    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar03PrintBarcode.ItemClick

        Dim vdtSelected As DataTable = _gdCurrentStock._cmf20GetSelectedDataCurrentStock()

        If vdtSelected Is Nothing OrElse vdtSelected.Rows.Count = 0 Then
            XtraMessageBox.Show("Please tick the data you want to process..", "Warning | " & _cUserInfo._UserProp01cTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim vsZPL As String = ""
        Dim vsAllZPL As String = ""

        Dim vsBrandXPoint As String = ""
        Dim vsBrandYPoint As (String, String) = ("0", "0")
        Dim vsColourFontProp As (String, String) = ("0", "0")
        Dim vsIsSizeExist As String = ""

        For Each itm As DataRow In vdtSelected.Rows

            vsZPL = String.Concat(vsZPL, "^FX ===== TAG OPEN ZPL =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^XA^MMT^PW480^LL0160^LS0", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== SKU =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT33,49^AAN,18,10^FH\^FD", CStr(itm("k03String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== PRODUCT CODE =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT33,135^AAN,18,10^FH\^FD", CStr(itm("f21String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsBrandXPoint = cm04SetPointXBrand(CInt(Len(CStr(itm("k03String")))))
            vsBrandYPoint = cm04SetPointYBrand(CInt(Len(CStr(itm("f25String")))), itm("f25String"))
            vsZPL = String.Concat(vsZPL, "^FX ===== BRAND =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT", vsBrandXPoint, ",", vsBrandYPoint.Item1, "^A0R,22,", vsBrandYPoint.Item2, "^FH\^FD", CStr(itm("f25String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== KADAR =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT247,48^AAN,18,10^FH\^FD", CStr(itm("f02Int")), " / ", CStr(itm("f27String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== TYPE =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT247,70^AAN,18,10^FH\^FD", CStr(itm("f12String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsColourFontProp = cm04SetFontPropColour(CInt(Len(CStr(itm("f08String")))))
            vsZPL = String.Concat(vsZPL, "^FX ===== COLOUR =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT247,92^A", vsColourFontProp.Item1, "N,18,", vsColourFontProp.Item2, "^FH\^FD", CStr(itm("f08String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsIsSizeExist = IIf(CStr(itm("f14String")).Trim() = "0" OrElse CStr(itm("f14String")).Trim() = "", "-", CStr(itm("f14String")).Trim())
            vsZPL = String.Concat(vsZPL, "^FX ===== SIZE =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT247,113^AAN,18,10^FH\^FDSz: ", CStr(itm("f14String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== PCS & GRAM =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT247,134^AAN,18,10^FH\^FD", CStr(itm("f01SmallInt")), "Pcs | ", CStr(itm("f01Double")), "Gr^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== VERTICAL BRAND (HALA,ILY,SDW) =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FT430,35^A0R,38,40^FB112,1,0,C^FH\^FD", cm06GetReserByKodeBrand(itm("f25String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== BARCODE (SKU) =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^BY 1,2,70^FO31,59^BC,55,N,N,N,N^FD", CStr(itm("k03String")), "^FS", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)

            vsZPL = String.Concat(vsZPL, "^FX ===== TAG CLOSE ZPL =====", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^PQ1,0,1,Y^XZ", vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ======================================", vbCrLf)
            vsZPL = String.Concat(vsZPL, vbCrLf)
            vsZPL = String.Concat(vsZPL, "^FX ================================================================", vbCrLf)

            'vsAllZPL &= vsZPL & vbCrLf
        Next
        'Dim vsFilename As String = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"!MERSY_PrintBarcode_Debug_{Now:yyyyMMdd-HHmmss}.txt")
        'System.IO.File.WriteAllText(vsFilename, vsAllZPL)
        'Process.Start("notepad.exe", vsFilename)

        cm03ReprintBarcode(vsZPL)
    End Sub

    Private Function cm04SetPointXBrand(ByVal viSKULength As Integer)

        Dim vsPointZPL As String = ""
        Select Case viSKULength
            Case 9, 10
                vsPointZPL = "203"
            Case 11
                vsPointZPL = "208"
            Case 12
                vsPointZPL = "214"
            Case 13
                vsPointZPL = "219"
            Case 14
                vsPointZPL = "225"
            Case Else
                vsPointZPL = "225"
        End Select
        Return vsPointZPL
    End Function

    Private Function cm04SetPointYBrand(ByVal viBrandLength As Integer, ByVal vsBrand As String) As (String, String)

        Dim vsPointZPL As String = ""
        Dim vsPointZPL2 As String = ""
        Select Case viBrandLength
            Case 3, 4
                vsPointZPL = "53"
                vsPointZPL2 = "30"

                If vsBrand = "ILY" Then
                    vsPointZPL = "63"
                    vsPointZPL2 = "35"
                End If
            Case 5
                vsPointZPL = "42"
                vsPointZPL2 = "30"
            Case 6
                vsPointZPL = "33"
                vsPointZPL2 = "30"
            Case 7
                vsPointZPL = "30"
                vsPointZPL2 = "28"
            Case 8
                vsPointZPL = "30"
                vsPointZPL2 = "25"
            Case 9, 10
                vsPointZPL = "36"
                vsPointZPL2 = "18"
            Case 11, 12
                vsPointZPL = "35"
                vsPointZPL2 = "15"
            Case >= 13
                vsPointZPL = "33"
                vsPointZPL2 = "14"
            Case Else
                vsPointZPL = "30"
                vsPointZPL2 = "30"
        End Select

        Return (vsPointZPL, vsPointZPL2)
    End Function

    Private Function cm04SetFontPropColour(ByVal viColourLength As Integer) As (String, String)

        Dim vsPointZPL As String = ""
        Dim vsPointZPL2 As String = ""
        Select Case viColourLength
            Case > 15
                vsPointZPL = "0"
                vsPointZPL2 = "18"
            Case Else
                vsPointZPL = "A"
                vsPointZPL2 = "10"
        End Select

        Return (vsPointZPL, vsPointZPL2)
    End Function

    Private Function cm06GetReserByKodeBrand(ByVal vsBrand As String) As String
        Dim vsBrandResult As String
        Select Case vsBrand
            Case "SDW", "ILY", "HALA"
                vsBrandResult = vsBrand
            Case Else
                vsBrandResult = "" ' 
        End Select

        Return vsBrandResult
    End Function

    Public Sub cm03ReprintBarcode(ByVal vsZPL As String)

        Dim vsHeader As String = ""
        vsHeader = String.Concat(vsHeader, "^FX ======================================", vbCrLf)
        vsHeader = String.Concat(vsHeader, "^FX ===== CREATED BY AKIRRA - 25/06/25 =====", vbCrLf)
        vsHeader = String.Concat(vsHeader, "^FX ======================================", vbCrLf)
        vsHeader = String.Concat(vsHeader, vbCrLf)
        vsHeader = String.Concat(vsHeader, "^FX ===== TINT THICKNESS (SD30) =====", vbCrLf)
        vsHeader = String.Concat(vsHeader, "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ", vbCrLf)
        vsHeader = String.Concat(vsHeader, "^FX ======================================", vbCrLf)
        vsHeader = String.Concat(vsHeader, vbCrLf, vbCrLf)

        vsZPL = String.Concat(vsHeader, vsZPL)

        'Dim vsFilename As String = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"!MERSY_PrintBarcode_Debug_{Now:yyyyMMdd-HHmmss}.txt")
        'System.IO.File.WriteAllText(vsFilename, vsZPL)
        'Process.Start("notepad.exe", vsFilename)


        ' =========== CREATED BY AKIRRA | 25/07/14 =============
        ' for auto select ZEBRA PRINTER
        Dim vsPrinterNameKey As String() = {"ZDESIGNER", "ZEBRA"}
        Dim vsPrinterName As String = cmf00FindPrintersName(vsPrinterNameKey)

        Dim _cPrintDoc As New PrintDocument()

        If vsPrinterName IsNot Nothing Then
            _cPrintDoc.PrinterSettings.PrinterName = vsPrinterName
        End If

        Dim vsZPLDebug As String = "
        
         "

        Dim _cPrintDialog As New PrintDialog() With {
            .Document = _cPrintDoc}

        If _cPrintDialog.ShowDialog() = DialogResult.OK Then
            Dim vsPrinterNameVal As String = _cPrintDialog.PrinterSettings.PrinterName
            RawPrinterHelper.rawPrinterHelper.PrintRaw(vsPrinterName, vsZPL)
        End If

    End Sub

    Function cmf00FindPrintersName(vsPrinterNameKey As String()) As String
        For Each keyword In vsPrinterNameKey
            For Each vsPrinterName As String In PrinterSettings.InstalledPrinters
                If vsPrinterName.ToUpper().Contains(keyword.ToUpper()) Then
                    Return vsPrinterName
                End If
            Next
        Next
        Return Nothing
    End Function



#End Region

End Class
