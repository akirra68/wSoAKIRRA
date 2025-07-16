Imports DevExpress.XtraBars
Imports SKK02OBJECTS

Public Class rptWS25EF01AgregatSJ
    Public Property _prop01User As clsWSNasaUser

#Region "Form - Event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub rptWS25EF01AgregatSJ_Load(sender As Object, e As EventArgs) Handles Me.Load

        Bar1.Visible = True
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10

        _cm00ClearControl()
        _cm01DisplayAgregateSJ()
    End Sub

#End Region

#Region "Custom - Method"
    Private Sub _cm00ClearControl()
        mnuBar02DateKe.EditValue = Date.Today
        mnuBar01DateDari.EditValue = DateAdd(DateInterval.Day, -10, mnuBar02DateKe.EditValue)

        _gdAgregatSJ.__pbWSGrid02ClearGrid()
        _gdAgregatSJ.__pbWSGrid01InitGrid()
    End Sub

    Private Sub _cm01DisplayAgregateSJ()
        _gdAgregatSJ.__pbWSGrid01InitGrid()
        Dim _pdtAgregatSJ As New DataTable

        Using objNasaMaster As New clsWSNasaSelect4PivotGridReport With {._prop01User = _prop01User}
            _pdtAgregatSJ = objNasaMaster._pb011GetDataRptAgregatSJ(mnuBar01DateDari.EditValue, mnuBar02DateKe.EditValue)
        End Using

        If _pdtAgregatSJ.Rows.Count > 0 Then
            _gdAgregatSJ.__pbWSGrid02ClearGrid()
            With _gdAgregatSJ
                ._prop01User = _prop01User
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRptAgregatSJ
                ._prop03pdtDataSourceGrid = _pdtAgregatSJ
            End With
            _gdAgregatSJ.__pbWSGrid03DisplayGrid()
        End If
    End Sub


#End Region

#Region "Control - Event"
    Private Sub mnuBar03Display_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar03Display.ItemClick
        _cm01DisplayAgregateSJ()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        _gdAgregatSJ.__pbWSGrid04CreateSettingColumnWidth("AgergatSJ")

    End Sub

#End Region
End Class
