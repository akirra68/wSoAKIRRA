Imports DevExpress.XtraBars.Docking2010
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucMDRPT23CG01ReportMerchandise
    Implements IDisposable

    Public Property prop01User As clsUserGEMINI
    Property prop02TargetReport As TargetReportMD
    Property prop03TitleReport As String

    Private objParamDataReport As clsNasaSelectParamData

    Public Enum TargetReportMD
        _01ProductionOrder = 0
        _21MDRPTSTATUSPODIPRODUKSI = 1
    End Enum

#Region "from - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objParamDataReport = New clsNasaSelectParamData
    End Sub

    Private Sub ucMDRPT23CG01ReportMerchandise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(prop01User._UserProp10Skin)

        _cm01DisplayTitle()
        _cm02SettingVisibilityFilter()
        _cm03InitControlRepo()
        _cm04BersihkanControlFilter()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01DisplayTitle()
        Select Case prop02TargetReport
            Case TargetReportMD._01ProductionOrder, TargetReportMD._21MDRPTSTATUSPODIPRODUKSI
                _01cTitleReport.EditValue = prop03TitleReport
        End Select
    End Sub

    Private Sub _cm02SettingVisibilityFilter()
        _layfilter03cTipeProduksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _layfilter04cSubTipeProduksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        Select Case prop02TargetReport
            Case TargetReportMD._01ProductionOrder, TargetReportMD._21MDRPTSTATUSPODIPRODUKSI
                _layfilter03cTipeProduksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _layfilter04cSubTipeProduksi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        End Select
    End Sub

    Private Sub _cm03InitControlRepo()
        Dim objSetupRepo As New clsSetupRepository

        objSetupRepo._pb10InitDataSourceMDMASTER(prop01User._UserProp07TargetNetwork)
        objSetupRepo._pb101SetupCtrlMERCHANDISE(_filter03cTipeProduksi)
        objSetupRepo._pb101SetupCtrlMERCHANDISE(_filter04cSubTipeProduksi)

        _gdTabel._pb01InitGrid()
        _pvAnalisa._pb01InitPivot()
    End Sub

    Private Sub _cm04BersihkanControlFilter()
        _filter01dDariTanggal.EditValue = Today.Date
        _filter02dHinggaTanggal.EditValue = Today.Date
        _filter03cTipeProduksi.EditValue = ""
        _filter04cSubTipeProduksi.EditValue = ""
    End Sub

    Private Sub _cm05SettingParamDataReport()
        With objParamDataReport
            Select Case prop02TargetReport
                Case TargetReportMD._01ProductionOrder
                    .f01nTargetSPParent_int = 1 : .f02nTargetSPChild_int = 0 : .f03nTargetExec_int = 0
                    .f01cParamString = _filter03cTipeProduksi.EditValue : .f02cParamString = _filter04cSubTipeProduksi.EditValue : .f03cParamString = ""
                    .f01nParamNumerik = 0.0 : .f02nParamNumerik = 0.0
                    .f01dParamDate = _filter01dDariTanggal.EditValue : .f02dParamDate = _filter02dHinggaTanggal.EditValue

                Case TargetReportMD._21MDRPTSTATUSPODIPRODUKSI
                    .f01nTargetSPParent_int = 2 : .f02nTargetSPChild_int = 0 : .f03nTargetExec_int = 0
                    .f01cParamString = _filter03cTipeProduksi.EditValue : .f02cParamString = _filter04cSubTipeProduksi.EditValue : .f03cParamString = ""
                    .f01nParamNumerik = 0.0 : .f02nParamNumerik = 0.0
                    .f01dParamDate = _filter01dDariTanggal.EditValue : .f02dParamDate = _filter02dHinggaTanggal.EditValue

            End Select

        End With
    End Sub

    Private Async Function _cm06PrepareDisplayReport() As Task(Of DataTable)
        _cm05SettingParamDataReport()

        Dim objGetDataReport As New clsGetDataReportGEMINI
        With objGetDataReport
            Select Case prop02TargetReport
                Case TargetReportMD._01ProductionOrder
                    ._propTargetReportGEMINI = clsGetDataReportGEMINI.TargetDataReportGEMINI._rpt01MDProductionOrder
                Case TargetReportMD._21MDRPTSTATUSPODIPRODUKSI
                    ._propTargetReportGEMINI = clsGetDataReportGEMINI.TargetDataReportGEMINI._rpt21MDRPTSTATUSPODIPRODUKSI

            End Select
        End With

        objGetDataReport._propParamData = objParamDataReport

        Dim pdtReport As New DataTable
        pdtReport = Await objGetDataReport._rpt01GetDataReportGEMINIAsync(prop01User._UserProp07TargetNetwork)

        Return pdtReport
    End Function

    Private Async Sub _cm07DisplayReport()
        Dim pdtReport As New DataTable
        pdtReport = Await _cm06PrepareDisplayReport()

        Select Case prop02TargetReport
            Case TargetReportMD._01ProductionOrder
                _gdTabel._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._20MDRPTPRODUCTIONORDER
                _pvAnalisa._prop02TargetPivot = ucPivotTransaction.TargetPivot._01ProductionOrder
                _pvAnalisa._pb04DisplayPanelFilter(True)

            Case TargetReportMD._21MDRPTSTATUSPODIPRODUKSI
                _gdTabel._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._21MDRPTSTATUSPODIPRODUKSI
                _pvAnalisa._prop02TargetPivot = ucPivotTransaction.TargetPivot._21MDRPTSTATUSPODIPRODUKSI
                _pvAnalisa._pb04DisplayPanelFilter(True)

        End Select

        _gdTabel._pb02ClearGrid()
        _gdTabel._prop02pdtDataSourceGrid = Nothing
        _gdTabel._prop02pdtDataSourceGrid = pdtReport
        _gdTabel._pb03DisplayGridTransaction()

        _pvAnalisa._pb02ClearPivot()
        _pvAnalisa._prop03pdtDataSourcePivot = Nothing
        _pvAnalisa._prop03pdtDataSourcePivot = pdtReport
        _pvAnalisa._pb03DisplayReportPivot()
    End Sub

#End Region

#Region "control - event"

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'DisplayReport
                _cm07DisplayReport()

            Case 200  'Clear


        End Select
    End Sub

#End Region

End Class
