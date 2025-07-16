Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class ucReportGrid
    Implements IDisposable

    Public Property _prop01User As clsUserGEMINI
    Public Property _prop02TargetReport As TargetReportGrid
    Public Property _prop03pdtDataSourceGrid As New DataTable

    Public Property _prop10Numeric As Double

    Private pdtTemplate As DataTable
    Private ctrlTemplate As clsTEMPLATEGEMINI

#Region "private - repository"

    Private _rscolk00Int As New repoGEMININumeric
    Private _rscolk02Int As New repoGEMININumeric

    Private _rscolf01Int As New repoGEMININumeric
    Private _rscolf02Int As New repoGEMININumeric
    Private _rscolf03Int As New repoGEMININumeric
    Private _rscolf04Int As New repoGEMININumeric
    Private _rscolf05Int As New repoGEMININumeric
    Private _rscolf06Int As New repoGEMININumeric
    Private _rscolf07Int As New repoGEMININumeric

    Private _rscolf01Double As New repoGEMININumeric
    Private _rscolf02Double As New repoGEMININumeric
    Private _rscolf03Double As New repoGEMININumeric
    Private _rscolf04Double As New repoGEMININumeric
    Private _rscolf05Double As New repoGEMININumeric
    Private _rscolf06Double As New repoGEMININumeric
    Private _rscolf07Double As New repoGEMININumeric

    Private _rscolf01Double16 As New repoGEMININumeric
    Private _rscolf02Double16 As New repoGEMININumeric
    Private _rscolf03Double16 As New repoGEMININumeric
    Private _rscolf04Double16 As New repoGEMININumeric
    Private _rscolf05Double16 As New repoGEMININumeric

    Private _rscolf01Date As New repoGEMINIDate
    Private _rscolf02Date As New repoGEMINIDate
    Private _rscolf03Date As New repoGEMINIDate
    Private _rscolf04Date As New repoGEMINIDate
    Private _rscolf05Date As New repoGEMINIDate

#End Region

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtTemplate = New DataTable
        ctrlTemplate = New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdtTemplate}
        ctrlTemplate.dtInitTABLEGEMINI()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        _prop03pdtDataSourceGrid.Dispose()
        pdtTemplate.Dispose()
        ctrlTemplate.Dispose()

        _rscolk00Int.Dispose()
        _rscolk02Int.Dispose()

        _rscolf01Int.Dispose()
        _rscolf02Int.Dispose()
        _rscolf03Int.Dispose()
        _rscolf04Int.Dispose()
        _rscolf05Int.Dispose()
        _rscolf06Int.Dispose()
        _rscolf07Int.Dispose()

        _rscolf01Double.Dispose()
        _rscolf02Double.Dispose()
        _rscolf03Double.Dispose()
        _rscolf04Double.Dispose()
        _rscolf05Double.Dispose()
        _rscolf06Double.Dispose()
        _rscolf07Double.Dispose()

        _rscolf01Double16.Dispose()
        _rscolf02Double16.Dispose()
        _rscolf03Double16.Dispose()
        _rscolf04Double16.Dispose()
        _rscolf05Double16.Dispose()

        _rscolf01Date.Dispose()
        _rscolf02Date.Dispose()
        _rscolf03Date.Dispose()
        _rscolf04Date.Dispose()
        _rscolf05Date.Dispose()
    End Sub

    Private Sub ucReportGrid_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

#End Region

#Region "private - custom method"

    Private Sub _cm01InitFieldGrid()
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.IndicatorWidth = 50

        colk00Boolean.FieldName = "k00Boolean"
        colk00Int.FieldName = "k00Int"
        colk01String.FieldName = "k01String"
        colk02Int.FieldName = "k02Int"
        colk03String.FieldName = "k03String"
        colk04String.FieldName = "k04String"
        colk05String.FieldName = "k05String"
        colf01String.FieldName = "f01String"
        colf02String.FieldName = "f02String"
        colf03String.FieldName = "f03String"
        colf04String.FieldName = "f04String"
        colf05String.FieldName = "f05String"
        colf06String.FieldName = "f06String"
        colf07String.FieldName = "f07String"
        colf08String.FieldName = "f08String"
        colf09String.FieldName = "f09String"
        colf10String.FieldName = "f10String"
        colf11String.FieldName = "f11String"
        colf12String.FieldName = "f12String"
        colf13String.FieldName = "f13String"
        colf14String.FieldName = "f14String"
        colf15String.FieldName = "f15String"
        colf16String.FieldName = "f16String"
        colf17String.FieldName = "f17String"
        colf18String.FieldName = "f18String"
        colf19String.FieldName = "f19String"
        colf20String.FieldName = "f20String"
        colf21String.FieldName = "f21String"
        colf22String.FieldName = "f22String"
        colf23String.FieldName = "f23String"
        colf24String.FieldName = "f24String"
        colf25String.FieldName = "f25String"
        colf26String.FieldName = "f26String"
        colf27String.FieldName = "f27String"
        colf28String.FieldName = "f28String"
        colf29String.FieldName = "f29String"
        colf30String.FieldName = "f30String"
        colf01Memo.FieldName = "f01Memo"
        colf02Memo.FieldName = "f02Memo"
        colf01Int.FieldName = "f01Int"
        colf02Int.FieldName = "f02Int"
        colf03Int.FieldName = "f03Int"
        colf04Int.FieldName = "f04Int"
        colf05Int.FieldName = "f05Int"
        colf06Int.FieldName = "f06Int"
        colf07Int.FieldName = "f07Int"
        colf01Double.FieldName = "f01Double"
        colf02Double.FieldName = "f02Double"
        colf03Double.FieldName = "f03Double"
        colf04Double.FieldName = "f04Double"
        colf05Double.FieldName = "f05Double"
        colf06Double.FieldName = "f06Double"
        colf07Double.FieldName = "f07Double"
        colf01Double16.FieldName = "f01Double16"
        colf02Double16.FieldName = "f02Double16"
        colf03Double16.FieldName = "f03Double16"
        colf04Double16.FieldName = "f04Double16"
        colf05Double16.FieldName = "f05Double16"
        colf01Date.FieldName = "f01Date"
        colf02Date.FieldName = "f02Date"
        colf03Date.FieldName = "f03Date"
        colf04Date.FieldName = "f04Date"
        colf05Date.FieldName = "f05Date"
    End Sub

    Private Sub _cm02InitRepoColumn()
        _rscolk00Int._01InitRepoInteger()
        _rscolk02Int._01InitRepoInteger()

        _rscolf01Int._01InitRepoInteger()
        _rscolf02Int._01InitRepoInteger()
        _rscolf03Int._01InitRepoInteger()
        _rscolf04Int._01InitRepoInteger()
        _rscolf05Int._01InitRepoInteger()
        _rscolf06Int._01InitRepoInteger()
        _rscolf07Int._01InitRepoInteger()

        _rscolf01Double._02InitRepoDoubleMoney(2)
        _rscolf02Double._02InitRepoDoubleMoney(2)
        _rscolf03Double._02InitRepoDoubleMoney(2)
        _rscolf04Double._02InitRepoDoubleMoney(2)
        _rscolf05Double._02InitRepoDoubleMoney(2)
        _rscolf06Double._02InitRepoDoubleMoney(2)
        _rscolf07Double._02InitRepoDoubleMoney(2)

        _rscolf01Double16._02InitRepoDoubleMoney(2)
        _rscolf02Double16._02InitRepoDoubleMoney(2)
        _rscolf03Double16._02InitRepoDoubleMoney(2)
        _rscolf04Double16._02InitRepoDoubleMoney(2)
        _rscolf05Double16._02InitRepoDoubleMoney(2)

        _rscolf01Date._01InitRepoDate()
        _rscolf02Date._01InitRepoDate()
        _rscolf03Date._01InitRepoDate()
        _rscolf04Date._01InitRepoDate()
        _rscolf05Date._01InitRepoDate()

    End Sub

    Private Sub _cm03InitColumnEdit()
        colf01Int.ColumnEdit = _rscolf01Int
        colf02Int.ColumnEdit = _rscolf02Int
        colf03Int.ColumnEdit = _rscolf03Int
        colf04Int.ColumnEdit = _rscolf04Int
        colf05Int.ColumnEdit = _rscolf05Int
        colf06Int.ColumnEdit = _rscolf06Int
        colf07Int.ColumnEdit = _rscolf07Int
        colf01Double.ColumnEdit = _rscolf01Double
        colf02Double.ColumnEdit = _rscolf02Double
        colf03Double.ColumnEdit = _rscolf03Double
        colf04Double.ColumnEdit = _rscolf04Double
        colf05Double.ColumnEdit = _rscolf05Double
        colf06Double.ColumnEdit = _rscolf06Double
        colf07Double.ColumnEdit = _rscolf07Double

        colf01Double16.ColumnEdit = _rscolf01Double16
        colf02Double16.ColumnEdit = _rscolf02Double16
        colf03Double16.ColumnEdit = _rscolf03Double16
        colf04Double16.ColumnEdit = _rscolf04Double16
        colf05Double16.ColumnEdit = _rscolf05Double16

        colf01Date.ColumnEdit = _rscolf01Date
        colf02Date.ColumnEdit = _rscolf02Date
        colf03Date.ColumnEdit = _rscolf03Date
        colf04Date.ColumnEdit = _rscolf04Date
        colf05Date.ColumnEdit = _rscolf05Date
    End Sub

    Private Sub _cm04InitGridSummaryItem(ByRef objColumn As GridColumn,
                                         ByVal prmcFieldName As String,
                                         ByVal prmcIntDouble As String)
        Dim pcDisplayFormat As String
        pcDisplayFormat = ""

        Select Case prmcIntDouble
            Case "INT"
                pcDisplayFormat = "{0:n0}"
            Case "DBL"
                pcDisplayFormat = "{0:n3}"
        End Select

        Dim objGridSummaryItem As New GridSummaryItem
        With objGridSummaryItem
            .DisplayFormat = pcDisplayFormat
            .FieldName = prmcFieldName
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With

    End Sub

    Private Sub _cm05SettingColumnSummary()
        _cm04InitGridSummaryItem(colk00Int, "k00Int", "INT")
        _cm04InitGridSummaryItem(colk02Int, "k02Int", "INT")
        _cm04InitGridSummaryItem(colf01Int, "f01Int", "INT")
        _cm04InitGridSummaryItem(colf02Int, "f02Int", "INT")
        _cm04InitGridSummaryItem(colf03Int, "f03Int", "INT")
        _cm04InitGridSummaryItem(colf04Int, "f04Int", "INT")
        _cm04InitGridSummaryItem(colf05Int, "f05Int", "INT")
        _cm04InitGridSummaryItem(colf06Int, "f06Int", "INT")
        _cm04InitGridSummaryItem(colf07Int, "f07Int", "INT")
        _cm04InitGridSummaryItem(colf01Double, "f01Double", "DBL")
        _cm04InitGridSummaryItem(colf02Double, "f02Double", "DBL")
        _cm04InitGridSummaryItem(colf03Double, "f03Double", "DBL")
        _cm04InitGridSummaryItem(colf04Double, "f04Double", "DBL")
        _cm04InitGridSummaryItem(colf05Double, "f05Double", "DBL")
        _cm04InitGridSummaryItem(colf06Double, "f06Double", "DBL")
        _cm04InitGridSummaryItem(colf07Double, "f07Double", "DBL")

        _cm04InitGridSummaryItem(colf01Double16, "f01Double16", "DBL")
        _cm04InitGridSummaryItem(colf02Double16, "f02Double16", "DBL")
        _cm04InitGridSummaryItem(colf03Double16, "f03Double16", "DBL")
        _cm04InitGridSummaryItem(colf04Double16, "f04Double16", "DBL")
        _cm04InitGridSummaryItem(colf05Double16, "f05Double16", "DBL")
    End Sub

    Private Sub _cm06InitVisibilityOFF()
        colk00Boolean.Visible = False
        colk00Int.Visible = False
        colk01String.Visible = False
        colk02Int.Visible = False
        colk03String.Visible = False
        colk04String.Visible = False
        colk05String.Visible = False

        colf01String.Visible = False
        colf02String.Visible = False
        colf03String.Visible = False
        colf04String.Visible = False
        colf05String.Visible = False
        colf06String.Visible = False
        colf07String.Visible = False
        colf08String.Visible = False
        colf09String.Visible = False
        colf10String.Visible = False
        colf11String.Visible = False
        colf12String.Visible = False
        colf13String.Visible = False
        colf14String.Visible = False
        colf15String.Visible = False
        colf16String.Visible = False
        colf17String.Visible = False
        colf18String.Visible = False
        colf19String.Visible = False
        colf20String.Visible = False
        colf21String.Visible = False
        colf22String.Visible = False
        colf23String.Visible = False
        colf24String.Visible = False
        colf25String.Visible = False
        colf26String.Visible = False
        colf27String.Visible = False
        colf28String.Visible = False
        colf29String.Visible = False
        colf30String.Visible = False

        colf01Memo.Visible = False
        colf02Memo.Visible = False
        colf01Int.Visible = False
        colf02Int.Visible = False
        colf03Int.Visible = False
        colf04Int.Visible = False
        colf05Int.Visible = False
        colf06Int.Visible = False
        colf07Int.Visible = False

        colf01Double.Visible = False
        colf02Double.Visible = False
        colf03Double.Visible = False
        colf04Double.Visible = False
        colf05Double.Visible = False
        colf06Double.Visible = False
        colf07Double.Visible = False

        colf01Double16.Visible = False
        colf02Double16.Visible = False
        colf03Double16.Visible = False
        colf04Double16.Visible = False
        colf05Double16.Visible = False

        colf01Date.Visible = False
        colf02Date.Visible = False
        colf03Date.Visible = False
        colf04Date.Visible = False
        colf05Date.Visible = False

    End Sub

    Private Sub _cm07InitVisibilityIndexOFF()
        colk00Boolean.VisibleIndex = -1
        colk00Int.VisibleIndex = -1

        colk01String.VisibleIndex = -1
        colk02Int.VisibleIndex = -1
        colk03String.VisibleIndex = -1
        colk04String.VisibleIndex = -1
        colk05String.VisibleIndex = -1

        colf01String.VisibleIndex = -1
        colf02String.VisibleIndex = -1
        colf03String.VisibleIndex = -1
        colf04String.VisibleIndex = -1
        colf05String.VisibleIndex = -1
        colf06String.VisibleIndex = -1
        colf07String.VisibleIndex = -1
        colf08String.VisibleIndex = -1
        colf09String.VisibleIndex = -1
        colf10String.VisibleIndex = -1
        colf11String.VisibleIndex = -1
        colf12String.VisibleIndex = -1
        colf13String.VisibleIndex = -1
        colf14String.VisibleIndex = -1
        colf15String.VisibleIndex = -1
        colf16String.VisibleIndex = -1
        colf17String.VisibleIndex = -1
        colf18String.VisibleIndex = -1
        colf19String.VisibleIndex = -1
        colf20String.VisibleIndex = -1
        colf21String.VisibleIndex = -1
        colf22String.VisibleIndex = -1
        colf23String.VisibleIndex = -1
        colf24String.VisibleIndex = -1
        colf25String.VisibleIndex = -1
        colf26String.VisibleIndex = -1
        colf27String.VisibleIndex = -1
        colf28String.VisibleIndex = -1
        colf29String.VisibleIndex = -1
        colf30String.VisibleIndex = -1

        colf01Memo.VisibleIndex = -1
        colf02Memo.VisibleIndex = -1
        colf01Int.VisibleIndex = -1
        colf02Int.VisibleIndex = -1
        colf03Int.VisibleIndex = -1
        colf04Int.VisibleIndex = -1
        colf05Int.VisibleIndex = -1
        colf06Int.VisibleIndex = -1
        colf07Int.VisibleIndex = -1

        colf01Double.VisibleIndex = -1
        colf02Double.VisibleIndex = -1
        colf03Double.VisibleIndex = -1
        colf04Double.VisibleIndex = -1
        colf05Double.VisibleIndex = -1
        colf06Double.VisibleIndex = -1
        colf07Double.VisibleIndex = -1

        colf01Double16.VisibleIndex = -1
        colf02Double16.VisibleIndex = -1
        colf03Double16.VisibleIndex = -1
        colf04Double16.VisibleIndex = -1
        colf05Double16.VisibleIndex = -1

        colf01Date.VisibleIndex = -1
        colf02Date.VisibleIndex = -1
        colf03Date.VisibleIndex = -1
        colf04Date.VisibleIndex = -1
        colf05Date.VisibleIndex = -1

    End Sub

    Private Sub _cm08ReadOnlyGrid()
        colk00Boolean.OptionsColumn.ReadOnly = False
        colk00Int.OptionsColumn.ReadOnly = False
        colk01String.OptionsColumn.ReadOnly = True
        colk02Int.OptionsColumn.ReadOnly = True
        colk03String.OptionsColumn.ReadOnly = True
        colk04String.OptionsColumn.ReadOnly = True
        colk05String.OptionsColumn.ReadOnly = True

        colf01String.OptionsColumn.ReadOnly = True
        colf02String.OptionsColumn.ReadOnly = True
        colf03String.OptionsColumn.ReadOnly = True
        colf04String.OptionsColumn.ReadOnly = True
        colf05String.OptionsColumn.ReadOnly = True
        colf06String.OptionsColumn.ReadOnly = True
        colf07String.OptionsColumn.ReadOnly = True
        colf08String.OptionsColumn.ReadOnly = True
        colf09String.OptionsColumn.ReadOnly = True
        colf10String.OptionsColumn.ReadOnly = True
        colf11String.OptionsColumn.ReadOnly = True
        colf12String.OptionsColumn.ReadOnly = True
        colf13String.OptionsColumn.ReadOnly = True
        colf14String.OptionsColumn.ReadOnly = True
        colf15String.OptionsColumn.ReadOnly = True
        colf16String.OptionsColumn.ReadOnly = True
        colf17String.OptionsColumn.ReadOnly = True
        colf18String.OptionsColumn.ReadOnly = True
        colf19String.OptionsColumn.ReadOnly = True
        colf20String.OptionsColumn.ReadOnly = True
        colf21String.OptionsColumn.ReadOnly = True
        colf22String.OptionsColumn.ReadOnly = True
        colf23String.OptionsColumn.ReadOnly = True
        colf24String.OptionsColumn.ReadOnly = True
        colf25String.OptionsColumn.ReadOnly = True
        colf26String.OptionsColumn.ReadOnly = True
        colf27String.OptionsColumn.ReadOnly = True
        colf28String.OptionsColumn.ReadOnly = True
        colf29String.OptionsColumn.ReadOnly = True
        colf30String.OptionsColumn.ReadOnly = True

        colf01Memo.OptionsColumn.ReadOnly = True
        colf02Memo.OptionsColumn.ReadOnly = True
        colf01Int.OptionsColumn.ReadOnly = True
        colf02Int.OptionsColumn.ReadOnly = True
        colf03Int.OptionsColumn.ReadOnly = True
        colf04Int.OptionsColumn.ReadOnly = True
        colf05Int.OptionsColumn.ReadOnly = True
        colf06Int.OptionsColumn.ReadOnly = True
        colf07Int.OptionsColumn.ReadOnly = True

        colf01Double.OptionsColumn.ReadOnly = True
        colf02Double.OptionsColumn.ReadOnly = True
        colf03Double.OptionsColumn.ReadOnly = True
        colf04Double.OptionsColumn.ReadOnly = True
        colf05Double.OptionsColumn.ReadOnly = True
        colf06Double.OptionsColumn.ReadOnly = True
        colf07Double.OptionsColumn.ReadOnly = True

        colf01Double16.OptionsColumn.ReadOnly = True
        colf02Double16.OptionsColumn.ReadOnly = True
        colf03Double16.OptionsColumn.ReadOnly = True
        colf04Double16.OptionsColumn.ReadOnly = True
        colf05Double16.OptionsColumn.ReadOnly = True

        colf01Date.OptionsColumn.ReadOnly = True
        colf02Date.OptionsColumn.ReadOnly = True
        colf03Date.OptionsColumn.ReadOnly = True
        colf04Date.OptionsColumn.ReadOnly = True
        colf05Date.OptionsColumn.ReadOnly = True

    End Sub

    Private Sub _cm09PropertiesGridONTarget()
        'OFF
        _cm06InitVisibilityOFF()
        _cm07InitVisibilityIndexOFF()

        'ON
        _mp01SettingColumnCaption()
        _mp02SettingVisibilityON()
        _mp03SettingSummaryColumn()
    End Sub

#End Region

#Region "public - method : Setting Grid"

    Public Sub _pb01InitGrid()
        _cm01InitFieldGrid()
        _cm02InitRepoColumn()
        _cm03InitColumnEdit()
        _cm05SettingColumnSummary()

        'agar waktu pertama kali display, kosong... tanpa header kolom
        _cm06InitVisibilityOFF()
        _cm07InitVisibilityIndexOFF()
        _cm08ReadOnlyGrid()
    End Sub

    Public Sub _pb02ClearGrid()
        GridControl1.DataSource = Nothing
        GridControl1.Refresh()
    End Sub

    Public Sub _pb03DisplayGridTransaction()
        _cm09PropertiesGridONTarget()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _prop03pdtDataSourceGrid

        GridView1.BestFitColumns()

        Me.Dock = DockStyle.Fill
    End Sub

#End Region

#Region "event - control grid"
    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle + 1 'e.RowHandle.ToString()
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)
            e.Appearance.DrawString(e.Cache, "NoUrut", e.Bounds)
            e.Handled = True
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        'Dim View As GridView = TryCast(sender, GridView)

        'If e.RowHandle >= 0 Then
        '    Dim nCheck As Int16 = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))

        '    If nCheck = 1 Then
        '        e.Appearance.BackColor = Color.LightYellow
        '    Else
        '        e.Appearance.BackColor = Color.White
        '    End If

        'End If
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Cursor = Cursors.WaitCursor

        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("Maaf ... ada library yg harus terinstall, silahkan hub IT.", "Error")
            Return
        End If

        GridControl1.ShowPrintPreview()

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "********** method private - UPDATE/CHANGE **********"
    Public Enum TargetReportGrid
        _FARpt01SelisihRate = 0
    End Enum

    Private Sub _mp01SettingColumnCaption()
        Select Case _prop02TargetReport
            Case ""
        End Select
    End Sub

    Private Sub _mp02SettingVisibilityON()
        Select Case _prop02TargetReport
            Case ""
        End Select
    End Sub

    Private Sub _mp03SettingSummaryColumn()
        Select Case _prop02TargetReport
            Case ""
        End Select
    End Sub

#End Region

#Region "***** 70. FA - SELISIH RATE  *****"

#End Region

End Class
