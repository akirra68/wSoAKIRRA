Imports DevExpress.Mvvm.Native
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports SKK01CORE
Imports SKK02OBJECTS

' ===================== CREATED BY AKIRRA - 25/04/24 =====================
' ORDER MANAGEMENT SUBMENU TO CONFIRM OR CANCEL THE ORDERS.

Public Class ucWS25DQ01ORDERMANAGEMENT
    Implements IDisposable
    Implements clsRefreshTab

    Public Property _cUserInfo As clsWSNasaUser

    Private _oWsHelper As clsWSNasaHelper
    Private _oWsModelTiny As clsWSNasaTemplateDataTiny
    Private _oWsGetDtForSaving As clsWSNasaSelect4AllProsesMaster

    Private vdtOrderMgmtSelected As DataTable

    'Private disposedValue As Boolean = False

#Region " *** FORM EVENTS *** "
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        _oWsHelper = New clsWSNasaHelper
        _oWsGetDtForSaving = New clsWSNasaSelect4AllProsesMaster
        _oWsModelTiny = New clsWSNasaTemplateDataTiny
        _oWsModelTiny.dtInitsTABLETINY()


        vdtOrderMgmtSelected = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        'MyBase.Finalize()

        _oWsHelper.Dispose()
        _oWsGetDtForSaving.Dispose()
        _oWsModelTiny.Dispose()

        vdtOrderMgmtSelected.Dispose()

        BarManager1.Dispose()
        Bar1.Dispose()
        mnuBar01Save.Dispose()
        mnuBar02Radio.Dispose()
        _gdOrderMgmt.Dispose()
        _gdOrderMgmtPcode.Dispose()
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

    Private Sub ucWS25DQ01ORDERMANAGEMENT_Load(sender As Object, e As EventArgs) Handles Me.Load

        _cmf01InitControl()
        _cmf02ClearControlVal()

    End Sub

    Public Sub RefreshData() Implements clsRefreshTab.RefreshTab
        _cmf01InitControl()
        _cmf02ClearControlVal()

        _cmf03InitGrid()
    End Sub

#End Region


#Region " *** GRID EVENTS *** "
    Private Sub _gdOrderMgmt_StatusCheckRequired(canConfirm As Boolean, canCancel As Boolean) Handles _gdOrderMgmt.isPENDING

        If Not canConfirm Then
            If Not canCancel Then   ' SURATJALAN -> DELIVERED (CANCELLED)
                mnuBar02Radio.Visibility = BarItemVisibility.Never
                mnuBar04Reason.Visibility = BarItemVisibility.Never
                mnuBar01Save.Visibility = BarItemVisibility.Never
                barGap4.Visibility = BarItemVisibility.Never

            Else    ' CONFIRMED -> PICKED
                For Each item In DirectCast(mnuBar02Radio.Edit, RepositoryItemRadioGroup).Items
                    If item.Value = 1 Then
                        item.Enabled = False
                    ElseIf item.Value = 0 Then
                        item.Enabled = True
                    End If
                Next
                mnuBar02Radio.Visibility = BarItemVisibility.Always
                mnuBar02Radio.EditValue = 0
                mnuBar01Save.Visibility = BarItemVisibility.Always
                mnuBar04Reason.Visibility = BarItemVisibility.Always
                barGap4.Visibility = BarItemVisibility.Always
            End If

        Else    ' PENDING
            For Each item In DirectCast(mnuBar02Radio.Edit, RepositoryItemRadioGroup).Items
                item.Enabled = True
            Next
            mnuBar01Save.Visibility = BarItemVisibility.Always
            mnuBar02Radio.Visibility = BarItemVisibility.Always
            mnuBar02Radio.EditValue = Nothing
            mnuBar04Reason.Visibility = BarItemVisibility.Never
            barGap4.Visibility = BarItemVisibility.Always

        End If

        'MsgBox(canConfirm & canCancel)
    End Sub

    Private Sub _gdOrderMgmt_CheckHasOst(canCreateChild As Boolean) Handles _gdOrderMgmt.hasOST

        If canCreateChild Then
            mnuBar05ChildOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            barGap7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        Else
            mnuBar05ChildOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            barGap7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        End If

        'MsgBox(canCreateChild)

    End Sub

#End Region


#Region " *** CONTROL EVENTS *** "

    Private Sub TabPane1_SelectedPageChanged(sender As Object, e As SelectedPageChangedEventArgs) Handles TabPane1.SelectedPageChanged
        If TabPane1.SelectedPage Is tabOrder Then
            _gdOrderMgmtPcode.Visible = False
            _gdOrderMgmt.Visible = True

            mnuBar01Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnuBar02Radio.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnuBar03Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        ElseIf TabPane1.SelectedPage Is tabProductCode Then
            _gdOrderMgmtPcode.Visible = True
            _gdOrderMgmt.Visible = False

            mnuBar01Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mnuBar02Radio.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            mnuBar02Radio.EditValue = Nothing
            mnuBar04Reason.EditValue = ""
            mnuBar04Reason.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        End If
        If Me.IsHandleCreated Then
            Me.BeginInvoke(New MethodInvoker(AddressOf _cmf03InitGrid))
        Else
            AddHandler Me.HandleCreated, Sub()
                                             Me.BeginInvoke(New MethodInvoker(AddressOf _cmf03InitGrid))
                                         End Sub
        End If
    End Sub

    Private Sub mnuBar01Save_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar01Save.ItemClick
        _cmf05SaveActions()
    End Sub

    Private Sub mnuBar02Radio_EditValueChanged(sender As Object, e As EventArgs) Handles mnuBar02Radio.EditValueChanged
        Try
            If mnuBar02Radio.EditValue = 0 Then
                mnuBar04Reason.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Else
                mnuBar04Reason.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            End If

        Catch ex As Exception
            MsgBox(ex, vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)
        End Try
    End Sub

    Private Sub mnuBar03Refresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar03Refresh.ItemClick
        '_cmf01InitControl()

        _cmf02ClearControlVal()
        _cmf03InitGrid()
    End Sub

    Private Sub mnuBar05ChildOrder_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar05ChildOrder.ItemClick
        _cmf08CreateChildOrder()
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
        barGap7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        ' Bar Items
        mnuBar01Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        mnuBar02Radio.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        mnuBar03Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        mnuBar04Reason.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        mnuBar05ChildOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        ' Grid controls
        _gdOrderMgmt.Visible = False
        _gdOrderMgmtPcode.Visible = False

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
        _gdOrderMgmt.Visible = True
        _gdOrderMgmtPcode.Visible = True

        ' BarItem gaps
        barGap1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        barGap7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

        ' Bar Items
        mnuBar01Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        mnuBar02Radio.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        mnuBar03Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        mnuBar04Reason.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        mnuBar05ChildOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always


        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        BarManager1.AllowCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 15
    End Sub

    Private Sub _cmf02ClearControlVal()
        mnuBar02Radio.EditValue = Nothing
        mnuBar04Reason.EditValue = ""
        mnuBar04Reason.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

        For Each item In DirectCast(mnuBar02Radio.Edit, RepositoryItemRadioGroup).Items
            item.Enabled = True
        Next
    End Sub

    Private Sub _cmf03InitGrid()
        If TabPane1.SelectedPage Is tabOrder Then
            With _gdOrderMgmt
                ._prop01User = _cUserInfo
                ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOrderManagement
            End With

        ElseIf TabPane1.SelectedPage Is tabProductCode Then
            With _gdOrderMgmtPcode
                ._prop01User = _cUserInfo
                ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOrderManagementPcode
            End With
        End If

        _cmf04RefreshGrid()
    End Sub

    Private Sub _cmf04RefreshGrid()
        If TabPane1.SelectedPage Is tabOrder Then
            _gdOrderMgmt.__pbWSGridParentChild01InitGrid()
            _gdOrderMgmt.__pbWSGridParentChild02Clear()
            _gdOrderMgmt.__pbWSGridParentChild03Display()
            _gdOrderMgmt.Refresh()
            _gdOrderMgmt.Focus()

        ElseIf TabPane1.SelectedPage Is tabProductCode Then
            _gdOrderMgmtPcode.__pbWSGridParentChild01InitGrid()
            _gdOrderMgmtPcode.__pbWSGridParentChild02Clear()
            _gdOrderMgmtPcode.__pbWSGridParentChild03Display()
            _gdOrderMgmtPcode.Refresh()
            _gdOrderMgmtPcode.Focus()
        End If
    End Sub


    Private Sub _cmf05SaveActions()
        Cursor = Cursors.WaitCursor

        Try
            If mnuBar02Radio.EditValue Is Nothing OrElse Not IsNumeric(mnuBar02Radio.EditValue) Then
                MsgBox("Please decide whether to Confirm or Cancel the Order..", MsgBoxStyle.Exclamation, _cUserInfo._UserProp01cTitle)
                Return
            End If

            vdtOrderMgmtSelected = _gdOrderMgmt._cmf10GetSelectedDataOrderMgmt()

            If vdtOrderMgmtSelected Is Nothing Then
                MsgBox("Please tick the data you want to process..", vbOKOnly + vbExclamation, _cUserInfo._UserProp01cTitle)

                _cmf04RefreshGrid()
                Return
            End If

            Dim msg As String = ""
            If mnuBar02Radio.EditValue = 0 Then
                If String.IsNullOrWhiteSpace(Convert.ToString(mnuBar04Reason.EditValue)) Then
                    MsgBox("Please insert the reason for cancellation..", MsgBoxStyle.Exclamation, _cUserInfo._UserProp01cTitle)
                    Return
                End If

            End If

            If mnuBar02Radio.EditValue = 0 Then
                Dim rsl As Int16 = _cmf07SaveActionsProcess(vdtOrderMgmtSelected, "CANCEL", Convert.ToString(mnuBar04Reason.EditValue))

                If rsl > 0 Then
                    MsgBox("Operation completed successfully.", vbOKOnly + vbInformation, _cUserInfo._UserProp01cTitle)
                    _cmf02ClearControlVal()
                    _cmf04RefreshGrid()

                ElseIf rsl = -2 Then
                    MsgBox("Process aborted..", MsgBoxStyle.Critical, _cUserInfo._UserProp01cTitle)

                    Return

                ElseIf rsl = -1 Then
                    MsgBox("There's no Order to process, please recheck the Order..", vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)
                    _cmf04RefreshGrid()
                    Return

                Else
                    MsgBox("Operation failed.", vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)
                    _cmf04RefreshGrid()
                    Return
                End If

            Else
                Dim rsl As Int16 = _cmf07SaveActionsProcess(vdtOrderMgmtSelected, "CONFIRM")
                If rsl > 0 Then
                    MsgBox("Operation completed successfully.", vbOKOnly + vbInformation, _cUserInfo._UserProp01cTitle)
                    _cmf02ClearControlVal()
                    _cmf04RefreshGrid()

                ElseIf rsl = -2 Then
                    MsgBox("Process aborted..", MsgBoxStyle.Critical, _cUserInfo._UserProp01cTitle)

                    Return

                ElseIf rsl = -1 Then
                    MsgBox("There's no Order to process, please recheck the Order..", vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)
                    _cmf04RefreshGrid()
                    Return

                Else
                    MsgBox("Operation failed.", vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)
                    _cmf04RefreshGrid()
                    Return
                End If
            End If

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function _cmf06GetDataForSaveActions(ByVal viConCan As Integer)

        Return _oWsGetDtForSaving._pbf07GetDataForSavingOrderManagement(viConCan, _cUserInfo)

    End Function
    Private Function _cmf07SaveActionsProcess(ByVal vdtOrderSelected As DataTable, ByVal prmcIsApproved As String, Optional ByVal prmcReasons As String = "") As Integer
        Dim viSuccessCount As Int16 = 0
        Dim vsResultMsg As String = ""
        Dim vdtOrderLatest As New DataTable()

        _oWsModelTiny.dtInitsTABLETINY()

        If prmcIsApproved = "CONFIRM" Then
            vdtOrderLatest = _cmf06GetDataForSaveActions(1)   ' get latest data (PENDING ONLY)
        Else
            vdtOrderLatest = _cmf06GetDataForSaveActions(0)   ' get latest data (NOT CANCELLED)
        End If

        ' join selected data with latest data
        Dim joinedRows = From row In vdtOrderLatest.AsEnumerable()
                         Join selected In vdtOrderSelected.AsEnumerable()
              On row.Field(Of String)("k03String") Equals selected.Field(Of String)("k03String")
                         Where selected.Field(Of Boolean)("k00Boolean") = True
                         Select row

        Dim vdtMerged As DataTable = vdtOrderLatest.Clone()
        For Each row In joinedRows
            vdtMerged.ImportRow(row)
        Next

        If vdtMerged.Rows.Count = 0 Then
            Return -1   ' no order to process
        End If

        ' confirmation
        Dim vsConfirmMsg As String = $"Are you sure want to {prmcIsApproved} these Orders ?" & vbCrLf & vbCrLf
        Dim uniqueOrders = vdtMerged.AsEnumerable().Select(Function(r) r.Field(Of String)("k03String")).Distinct().ToList()
        For i = 0 To uniqueOrders.Count - 1
            vsConfirmMsg &= $"  {i + 1}. Order : '{uniqueOrders(i)}'." & vbCrLf
        Next

        If XtraMessageBox.Show(vsConfirmMsg, $"{prmcIsApproved} Order | {_cUserInfo._UserProp01cTitle}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return -2
        End If


        ' process data
        Dim groupedOrders = From row In vdtMerged.AsEnumerable()
                            Group By orderNo = row.Field(Of String)("k03String") Into Group

        For Each group In groupedOrders
            Dim vsOrderNo As String = group.orderNo
            Dim vbSuccess As Boolean = False
            Dim vsErrMsg As String = ""

            Try
                _oWsModelTiny.dtInitsTABLETINY()
                For Each dtRow In group.Group
                    _oWsModelTiny.dtAddNewsTABLETINY(
                        dtRow("k03String").ToString,     '"No.Order"
                        dtRow("f06String").ToString,     '"BrandCode"
                        dtRow("f08String").ToString,     '"KadarCode"
                        prmcIsApproved, "", "", "", prmcReasons,
                        0, 0, 0, 0.0, 0.0, 0.0,
                        "3000-01-01", "3000-01-01", Now,
                        _cUserInfo._UserProp02cUserID, _cUserInfo._UserProp03cUserName,
                        _cUserInfo._UserProp04ComputerName, _cUserInfo._UserProp05IPLocalAddress, _cUserInfo._UserProp06IPPublicAddress)
                Next

                ' do not delete this !! (for testing purpose)
                'Dim vdtTest As DataTable = objTiny.prop_dtsTABLETINY
                'If vdtTest.Rows.Count > 0 Then
                '    vbSuccess = True
                'Else
                '    vsErrMsg = "SP returned no affected rows."
                'End If

                ' call SP
                Dim viRsl As Integer = _oWsHelper._pbWSNasaHelperExec01SPSQLProses(
                    _cUserInfo._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                    2, "spWSOrderMgmtActions",
                    mdWSNasaConst._pbWSNamaSPParamData02DataForSaving, _oWsModelTiny.prop_dtsTABLETINY)

                If viRsl > 0 Then
                    vbSuccess = True
                Else
                    vsErrMsg = "SP returned 0 affected rows."
                End If

            Catch ex As Exception
                vsErrMsg = ex.Message
            End Try

            If vbSuccess Then
                viSuccessCount += 1
                vsResultMsg &= $"✔ Successfully {prmcIsApproved}ED Order '{vsOrderNo}'." & vbCrLf
            Else
                vsResultMsg &= $"❌ Failed to {prmcIsApproved} Order '{vsOrderNo}'." & vbCrLf
                vsResultMsg &= $"     💬 Message : {vsErrMsg}" & vbCrLf
            End If
        Next

        ' result message
        XtraMessageBox.Show(vsResultMsg, $"{prmcIsApproved} Result | " & _cUserInfo._UserProp01cTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        If viSuccessCount = 0 Then
            Return 0    'failed
        End If

        Return viSuccessCount
    End Function

    Private Sub _cmf08CreateChildOrder()
        Cursor = Cursors.WaitCursor
        Try
            vdtOrderMgmtSelected = _gdOrderMgmt._cmf10GetSelectedDataOrderMgmt()

            If vdtOrderMgmtSelected Is Nothing Then
                MsgBox("Please tick the data you want to process..", vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)

                _cmf04RefreshGrid()
                Return
            End If

            Dim rsl As Int16 = _cmf11CreateChildOrderProcess(vdtOrderMgmtSelected)
            If rsl > 0 Then
                MsgBox("Operation completed successfully.", vbOKOnly + vbInformation, _cUserInfo._UserProp01cTitle)
                _cmf02ClearControlVal()
                _cmf04RefreshGrid()

            ElseIf rsl = -2 Then
                MsgBox("Process aborted..", MsgBoxStyle.Critical, _cUserInfo._UserProp01cTitle)
                _cmf04RefreshGrid()
                Return

            ElseIf rsl = -1 Then
                MsgBox("There's no Order to process, please recheck the Order..", vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)
                _cmf04RefreshGrid()
                Return

            Else
                MsgBox("Operation failed.", vbOKOnly + vbCritical, _cUserInfo._UserProp01cTitle)
                _cmf04RefreshGrid()
                Return
            End If

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function _cmf09GetDataForCreateChildOrder()

        Return _oWsGetDtForSaving._pbf08GetDataForCreatingChildOrder(_cUserInfo)

    End Function

    Private Function _cmf10GenerateUniqueNoOrderChild(vsOriOrderNo As String, vhExistOrderNo As HashSet(Of String)) As String
        Dim vsSuffix As String = "-C"
        Dim vsNewOrderNo As String = vsOriOrderNo & vsSuffix

        While vhExistOrderNo.Contains(vsNewOrderNo)
            vsSuffix &= "C"
            vsNewOrderNo = vsOriOrderNo & vsSuffix
        End While

        vhExistOrderNo.Add(vsNewOrderNo)
        Return vsNewOrderNo
    End Function

    Private Function _cmf11CreateChildOrderProcess(ByVal vdtOrderSelected As DataTable) As Integer
        Dim viSuccessCount As Int16 = 0
        Dim vsResultMsg As String = ""

        _oWsModelTiny.dtInitsTABLETINY()

        ' get latest Order with OST
        Dim vdtOrderOst As DataTable = _cmf09GetDataForCreateChildOrder()

        ' join selected with latest Order
        Dim joinedRows = From row In vdtOrderOst.AsEnumerable()
                         Join selected In vdtOrderSelected.AsEnumerable()
              On row.Field(Of String)("k03String") Equals selected.Field(Of String)("k03String")
                         Select row

        ' apply selected order with latest Order
        Dim vdtMerged As DataTable = vdtOrderOst.Clone()
        For Each row In joinedRows
            vdtMerged.ImportRow(row)
        Next

        If vdtMerged.Rows.Count = 0 Then
            Return -1   ' no order to process
        End If

        ' sort by f01Date, f01Datetime, k03String (ORDER DATE, LAST UPDATED, NO. ORDER)
        Dim sortedRows = From row In vdtMerged.AsEnumerable()
                         Order By row.Field(Of Date)("f01Date"),
                              row.Field(Of DateTime)("f01Datetime"),
                              row.Field(Of String)("k03String")
                         Select row

        ' apply merged orders with sorted rows
        Dim vdtFinal As DataTable = vdtMerged.Clone()
        For Each row In sortedRows
            vdtFinal.ImportRow(row)
        Next

        ' start process
        Dim vdiConfirmMsg As New Dictionary(Of String, List(Of String))()

        For Each row As DataRow In vdtFinal.Rows
            Dim vsOrderNo As String = row("k03String").ToString()
            Dim vsProductCode As String = row("f01String").ToString()
            Dim viOstQty As Integer = Convert.ToInt32(row("f02Int"))

            If Not vdiConfirmMsg.ContainsKey(vsOrderNo) Then
                vdiConfirmMsg(vsOrderNo) = New List(Of String)
            End If
            vdiConfirmMsg(vsOrderNo).Add($"    {vdiConfirmMsg(vsOrderNo).Count + 1}. Product Code '{vsProductCode}' | OutstandingQTY : {viOstQty}")
        Next

        ' confirmation msg
        Dim vsConfirmMsg As String = "Are you sure want to Create Child Order for these Orders :" & vbCrLf & vbCrLf
        For Each kvp In vdiConfirmMsg
            vsConfirmMsg &= $" • Order '{kvp.Key}'" & vbCrLf
            For Each detail In kvp.Value
                vsConfirmMsg &= detail & vbCrLf
            Next
        Next

        If XtraMessageBox.Show(vsConfirmMsg, "Create Child Order | " & _cUserInfo._UserProp01cTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return -2   ' process aborted
        End If


        ' check existing child order
        Dim vsSql As String = "SELECT DISTINCT k03String FROM wsTABLE30 WHERE k03String LIKE '%-C'"

        Dim vdtGetExistChildOrderNo As DataTable = Nothing
        vdtGetExistChildOrderNo = _oWsHelper._pbWSNasaExecSQLDirectToDataTable(_cUserInfo._UserProp08TargetNetwork,
                                                                clsWSNasaHelper._pnmDatabaseName.WS, 1, vsSql)

        Dim vhExisChildOrderNo As New HashSet(Of String)(From row In vdtGetExistChildOrderNo.AsEnumerable()
                                                         Select row.Field(Of String)("k03String"))


        ' continue the process
        Dim groupedRows = From row In vdtFinal.AsEnumerable()
                          Group By orderNo = row.Field(Of String)("k03String") Into Group

        For Each group In groupedRows
            Dim vsOrderNo = group.orderNo
            Dim vbSuccess As Boolean = False
            Dim vsErrMsg As String = ""

            Dim existingVariants = vhExisChildOrderNo.
            Where(Function(x) x.StartsWith(vsOrderNo & "-") AndAlso Not x.Substring(vsOrderNo.Length + 1).Contains("-")).
            OrderBy(Function(x) x.Length).ToList()

            Dim vsChildOrderNo As String = _cmf10GenerateUniqueNoOrderChild(vsOrderNo, vhExisChildOrderNo)


            If existingVariants.Count > 0 Then
                Dim msg = $"Child Order for Order '{vsOrderNo}' already exists :" & vbCrLf &
              String.Join(vbCrLf, existingVariants.Select(Function(x) $"  - {x}")) & vbCrLf & vbCrLf &
              "Do you want to proceed anyway?"

                If XtraMessageBox.Show(msg, "Child Order Already Exists | " & _cUserInfo._UserProp01cTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                    vsResultMsg &= $"⏭   Skipped creating Child Order for Order '{vsOrderNo}' (already exists)." & vbCrLf & vbCrLf
                    Continue For
                End If
            End If

            Try
                _oWsModelTiny.dtInitsTABLETINY()
                For Each dtRow As DataRow In group.Group
                    _oWsModelTiny.dtAddNewsTABLETINY(
                    dtRow("k03String").ToString,
                    dtRow("f01String").ToString,
                    dtRow("f06String").ToString,
                    dtRow("f08String"), vsChildOrderNo, "", "", "",
                    dtRow("f02Int"), 0, 0, 0.0, 0.0, 0.0,
                    dtRow("f01Date"), Now,
                    Now, _cUserInfo._UserProp02cUserID, _cUserInfo._UserProp03cUserName,
                    _cUserInfo._UserProp04ComputerName, _cUserInfo._UserProp05IPLocalAddress, _cUserInfo._UserProp06IPPublicAddress)
                Next

                ' do not delete this !! (for testing purpose)
                'Dim vdtTest As DataTable = objTiny.prop_dtsTABLETINY
                'If vdtTest.Rows.Count > 0 Then
                '    vbSuccess = True
                'Else
                '    vsErrMsg = "SP returned no affected rows."
                'End If

                ' call SP
                Dim viRsl As Integer = _oWsHelper._pbWSNasaHelperExec01SPSQLProses(
                _cUserInfo._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                2, "spWSOrderMgmtCreateChildOrder",
                "@pTvpForSaving", _oWsModelTiny.prop_dtsTABLETINY)

                If viRsl > 0 Then
                    vbSuccess = True
                Else
                    vsErrMsg = "SP returned 0 affected rows."
                End If

            Catch ex As Exception
                vsErrMsg = ex.Message
            End Try

            ' message
            If vbSuccess Then
                viSuccessCount += 1
                vsResultMsg &= $"✔ Successfully created Child Order for Order '{vsOrderNo}'." & vbCrLf
                vsResultMsg &= $"    ➕  Child Order '{vsChildOrderNo}'." & vbCrLf & vbCrLf
            Else
                vsResultMsg &= $"❌ Failed to create Child Order for Order '{vsOrderNo}'." & vbCrLf
                vsResultMsg &= $"     💬 Message : {vsErrMsg}" & vbCrLf & vbCrLf
            End If
        Next

        ' sum message
        XtraMessageBox.Show(vsResultMsg, "Create Child Order | " & _cUserInfo._UserProp01cTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' copy msg to notepad
        Dim vsFilename As String = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"!MERSY_OrderMgmt_CreateChildOrder_{Now:yyyyMMdd-HHmmss}.txt")
        System.IO.File.WriteAllText(vsFilename, vsResultMsg)

        Process.Start("notepad.exe", vsFilename)

        Return viSuccessCount
    End Function


#End Region

End Class
