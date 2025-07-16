Imports DevExpress.CodeParser
Imports DevExpress.DashboardWin.Native
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class rptWS25DX01Store
    Implements IDisposable
    Implements clsRefreshTab

    Public Property _prop01User As clsWSNasaUser
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

    Private Sub rptWS23LH01TrackingSKU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        Bar3.Visible = True
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar3.OptionsBar.DrawDragBorder = False
        Bar3.BarItemHorzIndent = 10

        ' _gdStore.__pbWSGridVisibilityCheckSelectAll(False)
        '_gdStore.__pbWSGrid01InitGrid()
        _cm01DisplayStore()
        '_02cTargetTracking.SelectedIndex = -1


        '_lay01WSSKUTracking.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Public Sub RefreshData() Implements clsRefreshTab.RefreshTab
        _cm01DisplayStore()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01DisplayStore()

        _gdStore.__pbWSGrid01InitGrid()
        Dim _pdtStore As New DataTable

        Using objNasaMaster As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            _pdtStore = objNasaMaster.__pb04GetDataTable52Customer()
        End Using

        If _pdtStore.Rows.Count > 0 Then
            _gdStore.__pbWSGrid02ClearGrid()
            With _gdStore
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRptStore
                ._prop03pdtDataSourceGrid = _pdtStore
            End With
            _gdStore.__pbWSGrid03DisplayGrid()
            _gdStore.__pbWSGridVisibilityCheckSelectAll(False)
        End If
    End Sub
    Private Sub _cm02UpdateData(ByVal pTarget As Boolean)
        Me.ActiveControl = Nothing

        Dim pdtDataStore As New DataTable
        _gdStore._pb05GetDataStore(pdtDataStore)

        If pTarget = True AndAlso pdtDataStore.Rows.Count = 0 Then
            MessageBox.Show("Please select the data you want to edit.", "No Data Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim objAddStore As New ucWS25WFStore With {._prop01User = _prop01User,
                                                   ._prop02DataStore = pdtDataStore,
                                                   ._prop03Target = pTarget}
        Dim objSize As New Size With {.Width = objAddStore.Size.Width + 10,
                                      .Height = objAddStore.Size.Height + 30}

        frmModal = New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                           .MinimizeBox = False, .ShowIcon = False,
                                           .StartPosition = FormStartPosition.CenterParent,
                                           .Text = "EDIT STORE | " & _prop01User._UserProp01cTitle}
        frmModal.AddControl(objAddStore)

        frmModal.ShowDialog()
        RefreshData()
    End Sub
#End Region

#Region "control - event"


    Private Sub mnuBar01Display_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar01Display.ItemClick
        _cm01DisplayStore()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        _gdStore.__pbWSGrid04CreateSettingColumnWidth("trackingSKU")
        MsgBox("Setting column width for Store grid has been created.", MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub mnuBar03Add_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar03Add.ItemClick

        _cm02UpdateData(False)
    End Sub

    Private Sub mnuBar02Edit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar02Edit.ItemClick
        _cm02UpdateData(True)
    End Sub



#End Region

End Class
