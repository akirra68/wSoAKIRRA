Imports SKK02OBJECTS

Public Class rptWS24B3REPORT
    Implements IDisposable
    Implements clsRefreshTab

    Property _prop01User As clsWSNasaUser
    Property _prop02TargetReportWarehouse As TargetReportWarehouse
    Property _prop03String As String
    Property _prop04String As String

    Public Enum TargetReportWarehouse
        'Inbound
        _wsInbound200All = 0
        _wsInbound201ByVendor = 201

        'General
        _wsGeneral300Stock = 300                'Current Stock SKU
        _wsGeneral301StockProductCode = 301     'Current Stock SKU

        'Outbound
        _wsOutbound350Sale = 350

        'Transaksi Warehouse (RepairWS-Lebur-ReturSUpplier)
        _wsTransaksiWS370Semua = 370
    End Enum

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub

    Private Sub rptWS24B3REPORT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _gdTabel.__pbWSGridVisibilityCheckSelectAll(False)

        _cm01VisiblityControl()
    End Sub

    Public Sub RefreshData() Implements clsRefreshTab.RefreshTab

        _cm01VisiblityControl()
    End Sub

#End Region

#Region "custom - method"
    Private Sub _cm01VisiblityControl()
        _01dPeriodeDariTanggal.EditValue = Today.AddMonths(-1).Date
        _02dPeriodeHinggaTanggal.EditValue = Today.Date
        _03cTargetStock.SelectedIndex = -1

        'Hide
        _lay01dPeriodeDariTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay02dPeriodeHinggaTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay03cTargetStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        'Show
        Select Case _prop02TargetReportWarehouse
            Case TargetReportWarehouse._wsInbound200All
                _lay01dPeriodeDariTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay02dPeriodeHinggaTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _cm05DisplayReport()

            Case TargetReportWarehouse._wsGeneral300Stock, TargetReportWarehouse._wsGeneral301StockProductCode
                _03cTargetStock.SelectedIndex = 0
                _prop02TargetReportWarehouse = TargetReportWarehouse._wsGeneral300Stock
                _lay03cTargetStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Case TargetReportWarehouse._wsOutbound350Sale
                _lay01dPeriodeDariTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay02dPeriodeHinggaTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _cm05DisplayReport()

            Case TargetReportWarehouse._wsTransaksiWS370Semua
                _lay01dPeriodeDariTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay02dPeriodeHinggaTanggal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _cm05DisplayReport()

        End Select

        _01dPeriodeDariTanggal.Size = New Size With {.Height = 30, .Width = 150}
        _02dPeriodeHinggaTanggal.Size = New Size With {.Height = 30, .Width = 150}
        _03cTargetStock.Size = New Size With {.Height = 30, .Width = 260}
        _otblDisplay.Size = New Size With {.Height = 32, .Width = 150}
    End Sub

    Private Function _cm02GetDataSource() As DataTable
        Dim objNasa As New clsWSNasaSelect4PivotGridReport With {._prop01User = _prop01User,
                                                                 ._prop02String = "",
                                                                 ._prop03String = "",
                                                                 ._prop04DateAwal = _01dPeriodeDariTanggal.EditValue,
                                                                 ._prop05DateHingga = _02dPeriodeHinggaTanggal.EditValue}
        Dim pdtTable As New DataTable
        Select Case _prop02TargetReportWarehouse
            Case TargetReportWarehouse._wsInbound200All
                pdtTable = objNasa._pb200RptInboundALL()

            Case TargetReportWarehouse._wsGeneral300Stock
                pdtTable = objNasa._pb300RptGeneralStock()

            Case TargetReportWarehouse._wsGeneral301StockProductCode
                pdtTable = objNasa._pb301RptGeneralStockProductCode()

            Case TargetReportWarehouse._wsOutbound350Sale
                pdtTable = objNasa._pb350RptOutboundSale(_prop01User._UserProp02cUserID)

            Case TargetReportWarehouse._wsTransaksiWS370Semua
                pdtTable = objNasa._pb370RptTransaksiWSSemua()
        End Select

        Return pdtTable
    End Function

    Private Sub _cm03SettingTargetGrid()
        With _gdTabel
            Select Case _prop02TargetReportWarehouse
                Case TargetReportWarehouse._wsInbound200All
                    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRptInbound200All

                Case TargetReportWarehouse._wsGeneral300Stock
                    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRptGeneral300Stock

                Case TargetReportWarehouse._wsGeneral301StockProductCode
                    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSRptGeneral301StockProductCode

                Case TargetReportWarehouse._wsOutbound350Sale
                    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._wsOutbound3501Sale

                Case TargetReportWarehouse._wsTransaksiWS370Semua
                    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._wsRptTransaksiWS370Semua

            End Select
        End With
    End Sub

    Private Sub _cm04SettingTargetPivot()
        With _pvAnalisa
            Select Case _prop02TargetReportWarehouse
                Case TargetReportWarehouse._wsInbound200All
                    ._prop02TargetPivot = ucWSPivot._pbEnumTargetPivot._WSRptInbound200All

                Case TargetReportWarehouse._wsGeneral300Stock
                    ._prop02TargetPivot = ucWSPivot._pbEnumTargetPivot._WSRptGeneral300Stock

                Case TargetReportWarehouse._wsGeneral301StockProductCode
                    ._prop02TargetPivot = ucWSPivot._pbEnumTargetPivot._WSRptGeneral301StockProductCode

                Case TargetReportWarehouse._wsOutbound350Sale
                    ._prop02TargetPivot = ucWSPivot._pbEnumTargetPivot._wsOutbound350Sale

                Case TargetReportWarehouse._wsTransaksiWS370Semua
                    ._prop02TargetPivot = ucWSPivot._pbEnumTargetPivot._wsRptTransaksiWS370Semua

            End Select
        End With
    End Sub

    Private Sub _cm05DisplayReport()
        Cursor = Cursors.WaitCursor

        TabPane1.SelectedPage = oTabGridTabel

        Dim pdtDataReport As New DataTable
        pdtDataReport = Nothing
        pdtDataReport = _cm02GetDataSource()

        Cursor = Cursors.Default

        If pdtDataReport.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor

            _cm03SettingTargetGrid()
            _cm04SettingTargetPivot()

            _gdTabel.__pbWSGrid02ClearGrid()
            With _gdTabel
                ._prop01User = _prop01User
                ._prop03pdtDataSourceGrid = pdtDataReport
            End With
            _gdTabel.__pbWSGrid01InitGrid()
            _gdTabel.__pbWSGrid03DisplayGrid()

            _pvAnalisa._pbWSPivot02ClearPivot()
            With _pvAnalisa
                ._prop01User = _prop01User
                ._prop03pdtDataSourcePivot = pdtDataReport
            End With
            _pvAnalisa._pbWSPivot01InitPivot()
            _pvAnalisa._pbWSPivot03DisplayPivot()

            Cursor = Cursors.Default
        Else
            MsgBox("Maaf ... data resource report ... tidak ditemukan", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If

    End Sub

#End Region

#Region "control - event"
    Private Sub _otblDisplay_Click(sender As Object, e As EventArgs) Handles _otblDisplay.Click
        _cm05DisplayReport()
    End Sub

    Private Sub _03cTargetStock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _03cTargetStock.SelectedIndexChanged
        Select Case _03cTargetStock.SelectedIndex
            Case 0
                _prop02TargetReportWarehouse = TargetReportWarehouse._wsGeneral300Stock
                _cm05DisplayReport()
            Case 1
                _prop02TargetReportWarehouse = TargetReportWarehouse._wsGeneral301StockProductCode
                _cm05DisplayReport()
        End Select
    End Sub

#End Region

End Class
