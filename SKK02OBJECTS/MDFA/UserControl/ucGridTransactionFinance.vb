Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.DataProcessing.InMemoryDataProcessor
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class ucGridTransactionFinance
    Implements IDisposable

    Public Property _prop01User As clsUserGEMINI
    Public Property _prop02TargetProses As TargetProses
    Public Property _prop03pdtDataSourceGrid As New DataTable
    Public Property _prop04Grid As ucGridTransactionFinance

    Public Property _prop10Numeric As Double

    Private pdtTemplate As DataTable
    Private ctrlTemplate As clsTEMPLATEGEMINI

    '**************************************
    '************* NOT USED ****************
    '**************************************
    'Public Delegate Sub __AutomaticPaymentDelegate(ByVal prmnTotBeratAR As Double)
    'Public Delegate Sub __ResetPaymentDelegate()
    '**************************************
    '************* NOT USED ****************
    '**************************************

    Public Delegate Function __dlgTotNetGramRupiah(ByVal prmcTarget As String) As Double

    Public Delegate Function __dlgTotNetGramRupiahPayment(ByVal prmcTarget As String) As Double


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

        GridView1.OptionsSelection.MultiSelect = True
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

    Private Sub ucGridTransactionFinance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                pcDisplayFormat = "{0:n2}"
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

        _01objPilihSemua.Visible = False
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
        _mp01SettingRepoColoumn()
        _mp03SettingVisibilityON()
        _mp02SettingColumnCaption()
        _mp04SettingWriteColumn()
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

        _01objPilihSemua.Checked = False
    End Sub

    Public Sub _pb03DisplayGridTransaction()
        If Not _prop03pdtDataSourceGrid.Columns.Contains("k00Boolean") Then
            _prop03pdtDataSourceGrid.Columns.Add("k00Boolean", GetType(Boolean)).DefaultValue = False
            _prop03pdtDataSourceGrid.Columns.Add("k00Int", GetType(Integer)).DefaultValue = 0
        End If

        _cm09PropertiesGridONTarget()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _prop03pdtDataSourceGrid

        GridView1.BestFitColumns()

        Me.Dock = DockStyle.Fill
    End Sub

    Public Sub _pb04AddNewData(ByVal prmk01String As String, ByVal prmk02Int As Integer, ByVal prmk03String As String,
                               ByVal prmk04String As String, ByVal prmk05String As String, ByVal prmf01String As String,
                               ByVal prmf02String As String, ByVal prmf03String As String, ByVal prmf04String As String,
                               ByVal prmf05String As String, ByVal prmf06String As String, ByVal prmf07String As String,
                               ByVal prmf08String As String, ByVal prmf09String As String, ByVal prmf10String As String,
                               ByVal prmf11String As String, ByVal prmf12String As String, ByVal prmf13String As String,
                               ByVal prmf14String As String, ByVal prmf15String As String, ByVal prmf16String As String,
                               ByVal prmf17String As String, ByVal prmf18String As String, ByVal prmf19String As String,
                               ByVal prmf20String As String, ByVal prmf21String As String, ByVal prmf22String As String,
                               ByVal prmf23String As String, ByVal prmf24String As String, ByVal prmf25String As String,
                               ByVal prmf26String As String, ByVal prmf27String As String, ByVal prmf28String As String,
                               ByVal prmf29String As String, ByVal prmf30String As String,
                               ByVal prmf01Memo As String,
                               ByVal prmf01Int As Integer, ByVal prmf02Int As Integer, ByVal prmf03Int As Integer, ByVal prmf04Int As Integer, ByVal prmf05Int As Integer, ByVal prmf06Int As Integer, ByVal prmf07Int As Integer,
                               ByVal prmf01Double As Double, ByVal prmf02Double As Double, ByVal prmf03Double As Double, ByVal prmf04Double As Double, ByVal prmf05Double As Double, ByVal prmf06Double As Double, ByVal prmf07Double As Double,
                               ByVal prmf01Double16 As Double, ByVal prmf02Double16 As Double, ByVal prmf03Double16 As Double, ByVal prmf04Double16 As Double, ByVal prmf05Double16 As Double,
                               ByVal prmf01Date As Date, ByVal prmf02Date As Date, ByVal prmf03Date As Date, ByVal prmf04Date As Date, ByVal prmf05Date As Date,
                               ByVal prmf01Datetime As Date, ByVal prmf02Datetime As Date,
                               ByVal prmf01IDUser As String, ByVal prmf02IDUser As String,
                               ByVal prmf01NamaUser As String, ByVal prmf02NamaUser As String,
                               Optional ByVal prmlCheckBox As Boolean = False)

        Dim oDataRow As DataRow = _prop03pdtDataSourceGrid.NewRow()

        'oDataRow("k00Boolean") = False
        'oDataRow("k00Int") = 0
        oDataRow("k01String") = prmk01String
        oDataRow("k02Int") = prmk02Int
        oDataRow("k03String") = prmk03String
        oDataRow("k04String") = prmk04String
        oDataRow("k05String") = prmk05String
        oDataRow("f01String") = prmf01String
        oDataRow("f02String") = prmf02String
        oDataRow("f03String") = prmf03String
        oDataRow("f04String") = prmf04String
        oDataRow("f05String") = prmf05String
        oDataRow("f06String") = prmf06String
        oDataRow("f07String") = prmf07String
        oDataRow("f08String") = prmf08String
        oDataRow("f09String") = prmf09String
        oDataRow("f10String") = prmf10String
        oDataRow("f11String") = prmf11String
        oDataRow("f12String") = prmf12String
        oDataRow("f13String") = prmf13String
        oDataRow("f14String") = prmf14String
        oDataRow("f15String") = prmf15String
        oDataRow("f16String") = prmf16String
        oDataRow("f17String") = prmf17String
        oDataRow("f18String") = prmf18String
        oDataRow("f19String") = prmf19String
        oDataRow("f20String") = prmf20String
        oDataRow("f21String") = prmf21String
        oDataRow("f22String") = prmf22String
        oDataRow("f23String") = prmf23String
        oDataRow("f24String") = prmf24String
        oDataRow("f25String") = prmf25String
        oDataRow("f26String") = prmf26String
        oDataRow("f27String") = prmf27String
        oDataRow("f28String") = prmf28String
        oDataRow("f29String") = prmf29String
        oDataRow("f30String") = prmf30String
        oDataRow("f01Memo") = prmf01Memo
        oDataRow("f01Int") = prmf01Int
        oDataRow("f02Int") = prmf02Int
        oDataRow("f03Int") = prmf03Int
        oDataRow("f04Int") = prmf04Int
        oDataRow("f05Int") = prmf05Int
        oDataRow("f06Int") = prmf06Int
        oDataRow("f07Int") = prmf07Int
        oDataRow("f01Double") = prmf01Double
        oDataRow("f02Double") = prmf02Double
        oDataRow("f03Double") = prmf03Double
        oDataRow("f04Double") = prmf04Double
        oDataRow("f05Double") = prmf05Double
        oDataRow("f06Double") = prmf06Double
        oDataRow("f07Double") = prmf07Double
        oDataRow("f01Double16") = prmf01Double16
        oDataRow("f02Double16") = prmf02Double16
        oDataRow("f03Double16") = prmf03Double16
        oDataRow("f04Double16") = prmf04Double16
        oDataRow("f05Double16") = prmf05Double16
        oDataRow("f01Date") = prmf01Date
        oDataRow("f02Date") = prmf02Date
        oDataRow("f03Date") = prmf03Date
        oDataRow("f04Date") = prmf04Date
        oDataRow("f05Date") = prmf05Date
        oDataRow("f01Datetime") = prmf01Datetime
        oDataRow("f02Datetime") = prmf02Datetime
        oDataRow("f01IDUser") = prmf01IDUser
        oDataRow("f02IDUser") = prmf02IDUser
        oDataRow("f01NamaUser") = prmf01NamaUser
        oDataRow("f02NamaUser") = prmf02NamaUser

        If prmlCheckBox Then
            oDataRow("k00Boolean") = False
            oDataRow("k00Int") = 0
        End If

        _prop03pdtDataSourceGrid.Rows.Add(oDataRow)
        _prop03pdtDataSourceGrid.AcceptChanges()

        GridControl1.RefreshDataSource()
        GridControl1.Refresh()
    End Sub

    Public Sub _pb05DisplayGridMini(ByVal prmdtDataSourceGridMini As DataTable,
                                    ByVal prmobjFinHargaEmas As clsFinanceHargaEmas,
                                    ByVal prmcString01 As String)
        Cursor = Cursors.WaitCursor

        _gridFinanceMini._pb01InitGrid()
        _gridFinanceMini._pb02ClearGrid()

        With _gridFinanceMini
            ._prop00User = _prop01User
            ._prop02pdtDataSource = prmdtDataSourceGridMini
            ._prop03TargetProses = ucGridTransactionFinanceMini.TargetProses._01FA23GV01NOFAKTUR_UPDATE
            ._prop04FinanceHargaEmas = prmobjFinHargaEmas
            ._prop05String = prmcString01
        End With
        _gridFinanceMini._pb03DisplayGridTransaction()

        Cursor = Cursors.Default
    End Sub

    Public Function _pb05FAOSTFakturSettlementARTotalBerat() As Double
        Return FormatNumber(CDbl(colf04Double16.SummaryItem.SummaryValue), 3)
    End Function

    Public Function _pb06FACollectionSettlementARTotalBerat() As Double
        Return FormatNumber(CDbl(colf02Double.SummaryItem.SummaryValue), 3)
    End Function

    'dipakai unt cek OSTSaldoCollection/Faktur < Rp.25000  (dari SisaBerat * RateBeli)
    Public Function _pb06FACollectionLatestRateBeli() As Integer
        Cursor = Cursors.WaitCursor

        Dim pnLatestRateBeli As Integer = 0

        Dim dataView As New DataView(_prop03pdtDataSourceGrid)
        With dataView
            .Sort = " f01Datetime desc "
            .RowFilter = String.Format(" k00Boolean = 1 ")
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Dim dataTable As DataTable = dataView.ToTable()

        Dim pnPertama As Int16 = 0
        For Each dtRow As DataRow In dataTable.Rows
            If pnPertama = 0 Then
                pnLatestRateBeli = CInt(dtRow("f03Int"))

                pnPertama = pnPertama + 1
            End If
        Next

        Cursor = Cursors.Default

        Return pnLatestRateBeli
    End Function

#End Region

#Region "public -  method : Proses Grid"
    Public Function _pbFA01GetDataOSTFakturSettlementARForSave(ByVal prmdDate As Date, ByVal prmcString As String) As DataTable
        Dim pdtData As New DataTable

        Dim objTemplateFakturSettlement As clsTEMPLATEGEMINIFINANCE = New clsTEMPLATEGEMINIFINANCE With {.prop_dtTABLEGEMINIFINANCE = pdtData}
        objTemplateFakturSettlement.dtInitTABLEGEMINIFINANCE()

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If CBool(dtRow("k00Boolean")) = True Then

                objTemplateFakturSettlement.dtAddNewTABLEGEMINIFINANCE(
                "", 0, dtRow("k01String"), prmcString, dtRow("k03String"),
                dtRow("k05String"), dtRow("f04String"), dtRow("f11String"), "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "",
                "",
                dtRow("f01Int"), dtRow("f03Int"), 0, 0, 0, 0, 0,
                dtRow("f03Double"), dtRow("f05Double"), 0.0, 0.0, 0.0, 0.0, 0.0,
                dtRow("f03Double16"), dtRow("f04Double16"), dtRow("f01Double16"), dtRow("f02Double16"), 0.0,
                dtRow("f01Date"), dtRow("f02Date"), prmdDate, "3000-01-01", "3000-01-01",
                Now, "3000-01-01", _prop01User._UserProp02cUserID, "", _prop01User._UserProp03cUserName, "")

            End If
        Next

        Return objTemplateFakturSettlement.prop_dtTABLEGEMINIFINANCE
    End Function

    Public Function _pbFA01GetDataPROFORMA() As DataTable
        'Nantinya pada form ucFA23GV01PROFORMAINVOICE akan dilakukan update data/ mengkompliti data
        'spt NoPROFORMA, REKENING HARGA EMAS dll

        Dim pdtData As New DataTable
        Dim objTempGEMINI As clsTEMPLATEGEMINI = New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdtData}
        objTempGEMINI.dtInitTABLEGEMINI()

        Dim plOK As Boolean = True
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows

            If _prop02TargetProses = TargetProses._01FA23GV01PROFORMAINVOICE_CREATE Then
                If dtRow("k00Boolean") = True Then
                    plOK = True
                Else
                    plOK = False
                End If
            Else
                plOK = True
            End If

            If plOK Then
                objTempGEMINI.dtAddNewTABLEGEMINI(
                        dtRow("k01String"), dtRow("k02Int"), dtRow("k03String"), dtRow("k04String"), dtRow("k05String"),
                        dtRow("f01String"), dtRow("f02String"), dtRow("f03String"), dtRow("f04String"), dtRow("f05String"),
                        dtRow("f06String"), dtRow("f07String"), dtRow("f08String"), dtRow("f09String"), dtRow("f10String"),
                        dtRow("f11String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"),
                        dtRow("f16String"), dtRow("f17String"), dtRow("f18String"), dtRow("f19String"), dtRow("f20String"),
                        dtRow("f21String"), dtRow("f22String"), dtRow("f23String"), dtRow("f24String"), dtRow("f25String"),
                        dtRow("f26String"), dtRow("f27String"), dtRow("f28String"), dtRow("f29String"), dtRow("f30String"),
                        dtRow("f01Memo"), "", "", "",
                        dtRow("f01Int"), dtRow("f02Int"), dtRow("f03Int"), dtRow("f04Int"), dtRow("f05Int"), dtRow("f06Int"), dtRow("f07Int"),
                        dtRow("f01Double"), dtRow("f02Double"), dtRow("f03Double"), dtRow("f04Double"), dtRow("f05Double"), dtRow("f06Double"), dtRow("f07Double"),
                        dtRow("f01Date"), dtRow("f02Date"), dtRow("f03Date"), dtRow("f04Date"), dtRow("f05Date"),
                        dtRow("f01Datetime"), dtRow("f02Datetime"), dtRow("f01IDUser"), dtRow("f02IDUser"), dtRow("f01NamaUser"), dtRow("f02NamaUser"))
            End If
        Next

        Return objTempGEMINI.prop_dtTABLEGEMINI
    End Function

    Public Function _pbFA01GetDataForClosingSisaan() As DataTable
        Dim pdtData As New DataTable

        Dim objTemplateKey As clsTEMPLATEKEY = New clsTEMPLATEKEY With {.prop_dtKEYGEMINI = pdtData}
        objTemplateKey.dtInitKEYGEMINI()

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If CBool(dtRow("k00Boolean")) = True Then
                objTemplateKey.dtAddNewKEYGEMINI(dtRow("k01String"), "", "", "", "")
            End If
        Next

        Return objTemplateKey.prop_dtKEYGEMINI
    End Function

#End Region

    Public Delegate Function __GetTotBeratDelegate() As Double
    Public Delegate Sub __ResetPaymentDelegate()
    Public Delegate Sub __AutoPaymentDelegate(ByVal prmnTotBerat As Double)

#Region "public - invoke delegate"

    '**************************************
    '************* NOT USED ****************
    '**************************************
    'Public Sub __AutomaticPaymentInvoke(ByVal prmnTotBeratAR As Double)
    '    'Assumsi nya adl : dari grid COLLECTION PAYMENT
    '    'colk00Boolean.Caption = "#"
    '    'colf03Double.Caption = "Berat Emas (gr)"
    '    'colf02Double.Caption = "Berat Settlement (gr)"
    '    'colf07Double.Caption = "Sisa (gr)"
    '    '======================================================

    '    'Assumsi nya adl : dari grid OST FAKTUR
    '    'colk00Boolean.Caption = "#"
    '    'colf03Double16.Caption = "T.Net (gr)"
    '    'colf04Double16.Caption = "Settlement (gr)"
    '    'colf07Double.Caption = "Sisa (gr)"
    '    '======================================================

    '    For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
    '        If prmnTotBeratAR > 0 Then
    '            '"f03Double" = BERAT Collection Customer
    '            '"f02Double" = BERAT Payment/Settlement
    '            If CDbl(dtRow("f03Double")) = prmnTotBeratAR Then
    '                dtRow("f02Double") = prmnTotBeratAR
    '                dtRow("f07Double") = 0
    '                prmnTotBeratAR = 0
    '            Else
    '                If CDbl(dtRow("f03Double")) > prmnTotBeratAR Then
    '                    dtRow("f02Double") = prmnTotBeratAR
    '                    dtRow("f07Double") = CDbl(dtRow("f03Double")) - prmnTotBeratAR
    '                    prmnTotBeratAR = 0
    '                Else
    '                    If CDbl(dtRow("f03Double")) < prmnTotBeratAR Then
    '                        dtRow("f02Double") = CDbl(dtRow("f03Double"))
    '                        dtRow("f07Double") = 0
    '                        prmnTotBeratAR = prmnTotBeratAR - CDbl(dtRow("f03Double"))
    '                    End If
    '                End If
    '            End If

    '            dtRow("k00Boolean") = True
    '            dtRow("k00Int") = 1
    '        End If
    '    Next
    '    _prop03pdtDataSourceGrid.AcceptChanges()

    'End Sub

    'Public Sub __ResetPaymentInvoke()
    '    'Assumsi nya adl : dari grid COLLECTION PAYMENT

    '    'colk00Boolean.Caption = "#"
    '    'colf03Double.Caption = "Berat Emas (gr)"
    '    'colf02Double.Caption = "Berat Settlement (gr)"
    '    'colf07Double.Caption = "Sisa (gr)"

    '    'Reset
    '    For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
    '        dtRow("k00Boolean") = False
    '        dtRow("k00Int") = 0
    '        dtRow("f02Double") = 0    '"Berat Settlement (gr)"
    '        dtRow("f07Double") = 0    '"Sisa (gr)"
    '    Next
    '    _prop03pdtDataSourceGrid.AcceptChanges()
    'End Sub
    '**************************************
    '************* NOT USED ****************
    '**************************************

    Private Function _TotBeratCollection() As Double
        Dim pnTotBerat As Double = 0.0

        'Assumsi nya adl : dari grid COLLECTION PAYMENT
        'colk00Boolean.Caption = "#"
        'colf03Double.Caption = "Berat Emas (gr)"
        'colf02Double.Caption = "Berat Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"
        '======================================================
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            pnTotBerat = pnTotBerat + CDbl(dtRow("f03Double"))
        Next

        Return pnTotBerat
    End Function

    Private Sub _AutoFullPaymentCollection()
        'Assumsi nya adl : dari grid COLLECTION PAYMENT
        'colk00Boolean.Caption = "#"
        'colf03Double.Caption = "Berat Emas (gr)"
        'colf02Double.Caption = "Berat Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"
        '======================================================
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            dtRow("k00Boolean") = True
            dtRow("k00Int") = 1
            dtRow("f02Double") = dtRow("f03Double")
            dtRow("f07Double") = 0
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()
    End Sub

    Private Sub _PaymentCollection(ByVal prmnTotBeratAR As Double)
        'Assumsi nya adl : dari grid COLLECTION PAYMENT
        'colk00Boolean.Caption = "#"
        'colf03Double.Caption = "Berat Emas (gr)"
        'colf02Double.Caption = "Berat Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"
        '======================================================

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If prmnTotBeratAR > 0 Then
                '"f03Double" = BERAT Collection Customer
                '"f02Double" = BERAT Payment/Settlement
                If CDbl(dtRow("f03Double")) = prmnTotBeratAR Then
                    dtRow("f02Double") = prmnTotBeratAR
                    dtRow("f07Double") = 0
                    prmnTotBeratAR = 0
                Else
                    If CDbl(dtRow("f03Double")) > prmnTotBeratAR Then
                        dtRow("f02Double") = prmnTotBeratAR
                        dtRow("f07Double") = CDbl(dtRow("f03Double")) - prmnTotBeratAR
                        prmnTotBeratAR = 0
                    Else
                        If CDbl(dtRow("f03Double")) < prmnTotBeratAR Then
                            dtRow("f02Double") = CDbl(dtRow("f03Double"))
                            dtRow("f07Double") = 0
                            prmnTotBeratAR = prmnTotBeratAR - CDbl(dtRow("f03Double"))
                        End If
                    End If
                End If

                dtRow("k00Boolean") = True
                dtRow("k00Int") = 1
            End If
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()
    End Sub

    Public Function __TotBeratOSTFakturARInvoke() As Double
        Dim pnTotBerat As Double = 0.0

        'Assumsi nya adl : dari grid OST FAKTUR
        'colk00Boolean.Caption = "#"
        'colf03Double16.Caption = "T.Net (gr)"
        'colf04Double16.Caption = "Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"
        '======================================================
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            pnTotBerat = pnTotBerat + CDbl(dtRow("f03Double16"))
        Next

        Return pnTotBerat
    End Function

    Public Sub __ResetPaymentOSTFakturARInvoke()
        'Assumsi nya adl : dari grid OST FAKTUR
        'colk00Boolean.Caption = "#"
        'colf03Double16.Caption = "T.Net (gr)"
        'colf04Double16.Caption = "Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"

        'Reset
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            dtRow("k00Boolean") = False
            dtRow("k00Int") = 0
            dtRow("f04Double16") = 0    '"Berat Settlement (gr)"
            dtRow("f07Double") = 0    '"Sisa (gr)"
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()
    End Sub

    Public Sub __AutoPaymentOSTFakturARInvoke(ByVal prmnTotBeratCollection As Double)
        'Assumsi nya adl : dari grid OST FAKTUR
        'colk00Boolean.Caption = "#"
        'colf03Double16.Caption = "T.Net (gr)"
        'colf04Double16.Caption = "Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"
        '======================================================

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If prmnTotBeratCollection > 0 Then
                '"f03Double16" = BERAT Collection Customer
                '"f04Double16" = BERAT Payment/Settlement
                If CDbl(dtRow("f03Double16")) = prmnTotBeratCollection Then
                    dtRow("f04Double16") = prmnTotBeratCollection
                    dtRow("f07Double") = 0
                    prmnTotBeratCollection = 0
                Else
                    If CDbl(dtRow("f03Double16")) > prmnTotBeratCollection Then
                        dtRow("f04Double16") = prmnTotBeratCollection
                        dtRow("f07Double") = CDbl(dtRow("f03Double16")) - prmnTotBeratCollection
                        prmnTotBeratCollection = 0
                    Else
                        If CDbl(dtRow("f03Double16")) < prmnTotBeratCollection Then
                            dtRow("f04Double16") = CDbl(dtRow("f03Double16"))
                            dtRow("f07Double") = 0
                            prmnTotBeratCollection = prmnTotBeratCollection - CDbl(dtRow("f03Double16"))
                        End If
                    End If
                End If

                dtRow("k00Boolean") = True
                dtRow("k00Int") = 1
            End If
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()
    End Sub

    Public Sub __AutoFULLPaymentOSTFakturARInvoke(ByVal prmnTotBeratCollection As Double)
        '    'Assumsi nya adl : dari grid OST FAKTUR
        '    'colk00Boolean.Caption = "#"
        '    'colf03Double16.Caption = "T.Net (gr)"
        '    'colf04Double16.Caption = "Settlement (gr)"
        '    'colf07Double.Caption = "Sisa (gr)"
        '    '======================================================
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            dtRow("k00Boolean") = True
            dtRow("k00Int") = 1
            dtRow("f04Double16") = dtRow("f03Double16")
            dtRow("f07Double") = 0
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()
    End Sub

#End Region

#Region "event - control grid"

    Private Sub _rscolk00Boolean_CheckedChanged(sender As Object, e As EventArgs) Handles _rscolk00Boolean.CheckedChanged
        GridView1.PostEditor()
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_LostFocus(sender As Object, e As EventArgs) Handles GridView1.LostFocus
        GridView1.PostEditor()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If (_prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR) Or
           (_prop02TargetProses = TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR) Or
           (_prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR) Then

            If e.Column.FieldName = "k00Boolean" Then

                If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                    GridView1.SetFocusedRowCellValue("k00Int", 1)
                    GridView1.RefreshData()

                    Dim pnBerat As Double = 0
                    Dim pnRupiah As Double = 0.0

                    If _prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR Then
                        pnBerat = GridView1.GetFocusedRowCellValue("f03Double")
                        pnRupiah = GridView1.GetFocusedRowCellValue("f03Double16")

                        GridView1.SetFocusedRowCellValue("f02Double", pnBerat)
                        GridView1.SetFocusedRowCellValue("f02Double16", pnRupiah)
                        GridView1.RefreshData()

                        colf02Double.OptionsColumn.ReadOnly = False
                        colf05Double.OptionsColumn.ReadOnly = False
                    Else
                        If (_prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR) Or
                            (_prop02TargetProses = TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR) Then
                            pnBerat = GridView1.GetFocusedRowCellValue("f03Double16")
                            GridView1.SetFocusedRowCellValue("f04Double16", pnBerat)

                            pnRupiah = GridView1.GetFocusedRowCellValue("f01Double16")
                            GridView1.SetFocusedRowCellValue("f02Double16", pnRupiah)
                            GridView1.RefreshData()

                            colf04Double16.OptionsColumn.ReadOnly = False
                            colf02Double16.OptionsColumn.ReadOnly = True

                        End If
                    End If

                Else
                    GridView1.SetFocusedRowCellValue("k00Int", 0)
                    GridView1.RefreshData()

                    If _prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR Then
                        GridView1.SetFocusedRowCellValue("f02Double", 0.0)
                        GridView1.SetFocusedRowCellValue("f02Double16", 0.0)
                        GridView1.SetFocusedRowCellValue("f07Double", 0.0)
                        GridView1.RefreshData()

                        colf02Double.OptionsColumn.ReadOnly = True
                        colf05Double.OptionsColumn.ReadOnly = True
                    Else
                        If _prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR Or
                           (_prop02TargetProses = TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR) Then

                            GridView1.SetFocusedRowCellValue("f04Double16", 0.0)
                            GridView1.SetFocusedRowCellValue("f02Double16", 0.0)
                            GridView1.SetFocusedRowCellValue("f07Double", 0.0)
                            GridView1.RefreshData()

                            colf04Double16.OptionsColumn.ReadOnly = True
                            colf02Double16.OptionsColumn.ReadOnly = True
                        End If
                    End If
                End If

                '**************************************
                '************* NOT USED ****************
                '**************************************
                'Dim pnTotBeratAR As Double = _pb05FAOSTFakturSettlementARTotalBerat()
                'If pnTotBeratAR > 0 Then
                '    Dim _dlgReset As __ResetPaymentDelegate = AddressOf _prop04Grid.__ResetPaymentInvoke
                '    _dlgReset.Invoke()

                '    Dim _dlg As __AutomaticPaymentDelegate = AddressOf _prop04Grid.__AutomaticPaymentInvoke
                '    _dlg.Invoke(pnTotBeratAR)
                'End If
                '**************************************
                '************* NOT USED ****************
                '**************************************

                If _prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR Then
                    'Total Berat ini merupakan total berat TANPA mempertimgbakan ter-CHECK atau TIDAK.
                    'dan ARAH pelunasan adalah : DARI gridCOLLECTION KE gridOSTFAKTURAR
                    Dim _dlgOSTFaktur As __GetTotBeratDelegate = AddressOf _prop04Grid.__TotBeratOSTFakturARInvoke
                    Dim pnTotBeratOSTFaktur As Double = _dlgOSTFaktur.Invoke()
                    Dim pnTotBeratCollection As Double = _TotBeratCollection()

                    Dim _dlgOSTFakturReset As __ResetPaymentDelegate = AddressOf _prop04Grid.__ResetPaymentOSTFakturARInvoke
                    _dlgOSTFakturReset.Invoke

                    Dim __dlg As __AutoPaymentDelegate
                    If pnTotBeratOSTFaktur = pnTotBeratCollection Then
                        __dlg = AddressOf _prop04Grid.__AutoFULLPaymentOSTFakturARInvoke
                        __dlg.Invoke(0)
                        _AutoFullPaymentCollection()
                    Else
                        If pnTotBeratOSTFaktur > pnTotBeratCollection Then
                            __dlg = AddressOf _prop04Grid.__AutoPaymentOSTFakturARInvoke
                            __dlg.Invoke(pnTotBeratCollection)
                            _AutoFullPaymentCollection()
                        Else
                            __dlg = AddressOf _prop04Grid.__AutoFULLPaymentOSTFakturARInvoke
                            __dlg.Invoke(0)
                            _PaymentCollection(pnTotBeratOSTFaktur)
                        End If
                    End If
                End If

            End If

            If e.Column.FieldName = "f04Double16" And _prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR Then
                Dim pnBeratAR As Double = GridView1.GetFocusedRowCellValue("f03Double16")
                Dim pnBeratSettlement As Double = GridView1.GetFocusedRowCellValue("f04Double16")
                GridView1.SetFocusedRowCellValue("f02Double16", GridView1.GetFocusedRowCellValue("f04Int") * pnBeratSettlement)
                GridView1.SetFocusedRowCellValue("f07Double", pnBeratAR - pnBeratSettlement)
                GridView1.RefreshData()

                If pnBeratSettlement > pnBeratAR Then
                    MsgBox("Maaf ... Berat Settlement terlalu besar dari pada berat AR ...", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)

                    GridView1.SetFocusedRowCellValue("f04Double16", 0.0)
                    GridView1.SetFocusedRowCellValue("f02Double16", 0.0)
                    GridView1.SetFocusedRowCellValue("f07Double", 0.0)
                    GridView1.RefreshData()
                End If

            End If

            If e.Column.FieldName = "f02Double" And _prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR Then
                Dim pnBeratCollection As Double = GridView1.GetFocusedRowCellValue("f03Double")
                Dim pnBeratCollectionUsed As Double = GridView1.GetFocusedRowCellValue("f02Double")
                GridView1.SetFocusedRowCellValue("f07Double", pnBeratCollection - pnBeratCollectionUsed)

                If pnBeratCollectionUsed > pnBeratCollection Then
                    MsgBox("Maaf ... BERAT Pelunasan terlalu besar dari pada BERAT Collection-nya ...", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)

                    GridView1.SetFocusedRowCellValue("f02Double", 0.0)
                    GridView1.SetFocusedRowCellValue("f02Double16", 0.0)
                    GridView1.SetFocusedRowCellValue("f07Double16", 0.0)
                    GridView1.RefreshData()
                Else
                    Dim pnGoldPricePerGram As Integer = GridView1.GetFocusedRowCellValue("f02Int")
                    GridView1.SetFocusedRowCellValue("f02Double16", pnGoldPricePerGram * pnBeratCollectionUsed)
                    GridView1.RefreshData()
                End If

            End If


            'If e.Column.FieldName = "f02Double16" And _prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR Then
            '    Dim pnRupiahCollection As Double = GridView1.GetFocusedRowCellValue("f03Double16")
            '    Dim pnRupiahCollectionUsed As Double = GridView1.GetFocusedRowCellValue("f02Double16")

            '    If pnRupiahCollectionUsed > pnRupiahCollection Then
            '        MsgBox("Maaf ... RUPIAH Pelunasan terlalu besar dari pada RUPIAH Collection-nya ...", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)

            '        GridView1.SetFocusedRowCellValue("f02Double16", 0.0)
            '        GridView1.RefreshData()
            '    End If

            'End If

        End If
    End Sub

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
        If (_prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR) Or
           (_prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR) Then
            Dim View As GridView = TryCast(sender, GridView)

            If e.RowHandle >= 0 Then
                Dim nCheck As Int16 = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))

                If nCheck = 1 Then
                    e.Appearance.BackColor = Color.LightYellow
                Else
                    e.Appearance.BackColor = Color.White
                End If

            End If
        End If
    End Sub

    Private Sub GridView1_ShowingEditor(sender As Object, e As CancelEventArgs) Handles GridView1.ShowingEditor
        If _prop02TargetProses = TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR Then
            Dim pcF10String As String = ""
            pcF10String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colf10String)

            e.Cancel = GridView1.FocusedColumn.FieldName = "k00Boolean" And pcF10String = "XRETUR"
        End If
    End Sub

    Private _Totf03Int As Integer = 0 : Private _Totf03Double As Double = 0.0
    Private _Totf03Double16 As Double = 0.0 : Private _Totf04Double16 As Double = 0.0

    Private _Totf04Double16Group As Double = 0.0 : Private pnf04Double16Group As Double = 0.0

    Private pnf03Int As Integer = 0 : Private pnf03Double As Double = 0.0
    Private pnf03Double16 As Double = 0.0 : Private pnf04Double16 As Double = 0.0

    Private pnf06Double As Double = 0.0 : Private _Totf06Double As Double = 0.0
    Private pnf04Double As Double = 0.0 : Private _Totf04Double As Double = 0.0

    Private pnf01Double16 As Double = 0.0 : Private _Totf01Double16 As Double = 0.0
    Private pnf02Double16 As Double = 0.0 : Private _Totf02Double16 As Double = 0.0
    Private pnf02Double16Group As Double = 0.0 : Private _Totf02Double16Group As Double = 0.0

    Private plBoolean As Boolean = False

    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        If _prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR Or
           _prop02TargetProses = TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR Then

            If e.IsGroupSummary Then
                Dim summaryIDGroup As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
                Dim ViewGroup As GridView = CType(sender, GridView)

                If e.SummaryProcess = CustomSummaryProcess.Start Then
                    _Totf04Double16Group = 0.0
                    _Totf02Double16Group = 0.0
                End If

                If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                    pnf04Double16Group = CDbl(ViewGroup.GetRowCellValue(e.RowHandle, "f04Double16"))
                    pnf02Double16Group = CDbl(ViewGroup.GetRowCellValue(e.RowHandle, "f02Double16"))

                    If CBool(ViewGroup.GetRowCellValue(e.RowHandle, "k00Boolean")) Then
                        Select Case summaryIDGroup
                            Case 416
                                _Totf04Double16Group += pnf04Double16Group
                            Case 216
                                _Totf02Double16Group += pnf02Double16Group
                        End Select
                    End If
                End If

                If e.SummaryProcess = CustomSummaryProcess.Finalize Then
                    Select Case summaryIDGroup
                        Case 416
                            e.TotalValue = _Totf04Double16Group
                        Case 216
                            e.TotalValue = _Totf02Double16Group
                    End Select
                End If
            End If

            Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
            Dim View As GridView = CType(sender, GridView)

            If e.SummaryProcess = CustomSummaryProcess.Start Then
                _Totf03Int = 0
                _Totf03Double = 0.0
                _Totf06Double = 0.0
                _Totf04Double = 0.0
                _Totf03Double16 = 0.0
                _Totf04Double16 = 0.0
                _Totf01Double16 = 0.0
                _Totf02Double16 = 0.0
            End If

            If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                plBoolean = CBool(View.GetRowCellValue(e.RowHandle, "k00Boolean"))
                pnf03Int = CInt(View.GetRowCellValue(e.RowHandle, "f03Int"))
                pnf03Double = CDbl(View.GetRowCellValue(e.RowHandle, "f03Double"))

                pnf06Double = CDbl(View.GetRowCellValue(e.RowHandle, "f06Double"))
                pnf04Double = CDbl(View.GetRowCellValue(e.RowHandle, "f04Double"))

                pnf03Double16 = CDbl(View.GetRowCellValue(e.RowHandle, "f03Double16"))
                pnf04Double16 = CDbl(View.GetRowCellValue(e.RowHandle, "f04Double16"))
                pnf01Double16 = CDbl(View.GetRowCellValue(e.RowHandle, "f01Double16"))
                pnf02Double16 = CDbl(View.GetRowCellValue(e.RowHandle, "f02Double16"))

                If plBoolean Then
                    Select Case summaryID
                        Case 1
                            _Totf03Int += pnf03Int
                        Case 2
                            _Totf03Double += pnf03Double
                        Case 26
                            _Totf06Double += pnf06Double
                        Case 24
                            _Totf04Double += pnf04Double
                        Case 3
                            _Totf03Double16 += pnf03Double16
                        Case 4
                            _Totf04Double16 += pnf04Double16
                        Case 5
                            _Totf01Double16 += pnf01Double16
                        Case 6
                            _Totf02Double16 += pnf02Double16
                    End Select

                End If

            End If

            If e.SummaryProcess = CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 1
                        e.TotalValue = _Totf03Int
                    Case 2
                        e.TotalValue = _Totf03Double
                    Case 26
                        e.TotalValue = _Totf06Double
                    Case 24
                        e.TotalValue = _Totf04Double
                    Case 3
                        e.TotalValue = _Totf03Double16
                    Case 4
                        e.TotalValue = _Totf04Double16
                    Case 5
                        e.TotalValue = _Totf01Double16
                    Case 6
                        e.TotalValue = _Totf02Double16
                End Select
            End If

        End If


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

    Private Sub _01objPilihSemua_CheckedChanged(sender As Object, e As EventArgs) Handles _01objPilihSemua.CheckedChanged
        If _prop03pdtDataSourceGrid.Rows.Count > 0 Then
            For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
                If _01objPilihSemua.Checked Then
                    dtRow("k00Boolean") = True
                    dtRow("k00Int") = 1

                    If (_prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR) Then
                        dtRow("f07Double") = 0                       'Sisaan(f07Double)
                        dtRow("f04Double16") = dtRow("f03Double16")  'pnBeratSettlement(f04Double16) =  pnBeratAR(f03Double16)

                        _colf07Double.OptionsColumn.ReadOnly = False
                    End If
                    If (_prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR) Then
                        dtRow("f07Double") = 0                     'Sisaan(f07Double)
                        dtRow("f02Double") = dtRow("f03Double")    'pnBeratCollectionUsed(f02Double) =  pnBeratCollection(f03Double)

                        _colf07Double.OptionsColumn.ReadOnly = False
                    End If
                Else
                    dtRow("k00Boolean") = False
                    dtRow("k00Int") = 0

                    If (_prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR) Then
                        dtRow("f07Double") = 0         'Sisaan(f07Double)
                        dtRow("f04Double16") = 0       'pnBeratSettlement(f04Double16) =  pnBeratAR(f03Double16)

                        _colf07Double.OptionsColumn.ReadOnly = True
                    End If
                    If (_prop02TargetProses = TargetProses._04FA23GU01CollectionSETTLEMENTAR) Then
                        dtRow("f07Double") = 0       'Sisaan(f07Double)
                        dtRow("f02Double") = 0       'pnBeratCollectionUsed(f02Double) =  pnBeratCollection(f03Double)

                        _colf07Double.OptionsColumn.ReadOnly = True
                    End If
                End If
            Next

            _prop03pdtDataSourceGrid.AcceptChanges()
        End If

    End Sub

#End Region

#Region "event - control popup-menu"

    Private Sub GridView1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If _prop02TargetProses = TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR Then
            If e.HitInfo.InRow Then
                Dim objPosition As System.Drawing.Point = Control.MousePosition
                Me.PopupMenu1.ShowPopup(objPosition)
            End If
        End If
    End Sub

    Private Sub _popMenuDeleteRow_ItemClick(sender As Object, e As ItemClickEventArgs) Handles _popMenuDeleteRow.ItemClick
        Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows()

        If selectedRowHandles.Count > 0 Then
            Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin akan MENGHAPUS data ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)
            If plYes = MsgBoxResult.Yes Then

                GridView1.DeleteSelectedRows()

                MsgBox("Hapus Data Record ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _prop01User._UserProp01cTitle)
            Else
                MsgBox("Hapus Data Record ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)
            End If
        End If

    End Sub

#End Region

#Region "********** method private - UPDATE/CHANGE **********"

    Public Enum TargetProses
        'Transaksi
        _01FA23GV01PROFORMAINVOICE_CREATE = 0
        _02FA23GV01PROFORMAINVOICE_UPDATE = 1
        _03FA23GV01PROFORMAINVOICE_DELETE = 2

        _04FA23GU01CollectionSETTLEMENTAR = 3

        '*******************************************
        _05FA23HH01BILLING = 4
        _06FA23GU01SETTLEMENTOSTFAKTURAR = 5
        _07FA23IL01CLOSINGCOLLECTION = 6

        _08FA23GU01COLLECTIONFORMULA = 7
        _09FA24AA01TAGIHANGRIDOSTFAKTUR = 8
        _10FA24AA01TAGIHANGRIDPAYMENT = 9
    End Enum

    Private Sub _mp01SettingRepoColoumn()
        Select Case _prop02TargetProses
            Case TargetProses._01FA23GV01PROFORMAINVOICE_CREATE

            Case TargetProses._02FA23GV01PROFORMAINVOICE_UPDATE

            Case TargetProses._03FA23GV01PROFORMAINVOICE_DELETE

            Case Else

        End Select
    End Sub

    Private Sub _mp02SettingColumnCaption()
        Select Case _prop02TargetProses
            Case TargetProses._01FA23GV01PROFORMAINVOICE_CREATE, TargetProses._02FA23GV01PROFORMAINVOICE_UPDATE, TargetProses._03FA23GV01PROFORMAINVOICE_DELETE
                _cc01CaptionCol620Proforma()

            Case TargetProses._04FA23GU01CollectionSETTLEMENTAR
                _cc63FASettlementCollectionARCaption()
                _ll01FASettingLainSettlementCollection()

            Case TargetProses._05FA23HH01BILLING, TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR
                _cc01CaptionCol610Billing()
                _ll01SettingLain610Billing()

            Case TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR
                _cc01CaptionWorksheetTagihan()
                _ll01SettingLainWorksheetTagihan()

            Case TargetProses._10FA24AA01TAGIHANGRIDPAYMENT
                _cc01CaptionTagihanPayment()
                _ll01SettingLainTagihanPayment()

            Case TargetProses._07FA23IL01CLOSINGCOLLECTION
                _cc63FAClosingCollectionARCaption()
                _ll01FASettingLainClosingCollection()

            Case TargetProses._08FA23GU01COLLECTIONFORMULA
                _cc651FACollectionFormulaCaption()

            Case Else

        End Select
    End Sub

    Private Sub _mp03SettingVisibilityON()
        Select Case _prop02TargetProses
            Case TargetProses._01FA23GV01PROFORMAINVOICE_CREATE, TargetProses._02FA23GV01PROFORMAINVOICE_UPDATE, TargetProses._03FA23GV01PROFORMAINVOICE_DELETE
                _vs01VisibilityCol620Proforma()
                _vs02VisibilityIndex620Proforma()

            Case TargetProses._04FA23GU01CollectionSETTLEMENTAR
                _vs63FASettlementCollectionARVisibility()
                _vs63FASettlementCollectionARVisibilityIndex()

            Case TargetProses._05FA23HH01BILLING, TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR
                _vs01VisibilityCol610Billing()
                _vs02VisibilityIndex610Billing()

            Case TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR
                _vs01VisibilityWorksheetTagihan()
                _vs02VisibilityIndexWorksheetTagihan()

            Case TargetProses._10FA24AA01TAGIHANGRIDPAYMENT
                _vs01VisibilityTagihanPayment()
                _vs02VisibilityIndexTagihanPayment()

            Case TargetProses._07FA23IL01CLOSINGCOLLECTION
                _vs63FAClosingCollectionARVisibility()
                _vs63FAClosingCollectionARVisibilityIndex()

            Case TargetProses._08FA23GU01COLLECTIONFORMULA
                _vs651FACollectionFormulaVisibility()
                _vs651FACollectionFormulaVisibilityIndex()

            Case Else

        End Select
    End Sub

    Private Sub _mp04SettingWriteColumn()
        Select Case _prop02TargetProses
            Case TargetProses._01FA23GV01PROFORMAINVOICE_CREATE, TargetProses._02FA23GV01PROFORMAINVOICE_UPDATE, TargetProses._03FA23GV01PROFORMAINVOICE_DELETE
                _wr01WriteCol620Proforma()
                _tot01TotalSummary620Proforma()

            Case TargetProses._04FA23GU01CollectionSETTLEMENTAR
                _tot63FASettlementCollectionARTotalSummary()

            Case TargetProses._05FA23HH01BILLING, TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR
                _tot01TotalSummary610Billing()
                _tot02GroupSummary610Billing()

            Case TargetProses._09FA24AA01TAGIHANGRIDOSTFAKTUR
                _tot01TotalCustomSummaryWorksheetTagihan()
                _tot02GroupSummaryWorksheetTagihan()

            Case TargetProses._10FA24AA01TAGIHANGRIDPAYMENT
                _tot01TotalCustomSummaryTagihanPayment()

            Case TargetProses._07FA23IL01CLOSINGCOLLECTION
                _tot63FAClosingCollectionARTotalSummary()

            Case Else

        End Select
    End Sub

#End Region

#Region "***** FA Billing ==> form : ucFA23HH01BILLING & FA Settlement AR (grid OST FAKTUR) ===> form : ucFA23GU01SETTLEMENTAR  *****"

    Private Sub _cc01CaptionCol610Billing()
        If _prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR Then
            colk00Boolean.Caption = "#"

            colf02String.Caption = "Entity"
            colf14String.Caption = "Identity"
            colf01Date.Caption = "Tgl.Faktur"
            colf02Date.Caption = "Tgl.JT"
            colk03String.Caption = "No.Faktur"
            colf10String.Caption = "RPY"
            colf04Int.Caption = "TGP"
            colf03Double.Caption = "Gross (gr)"    'SKK
            colf05Double.Caption = "Tukaran"       'TukaranEnd
            colf06Double.Caption = "Net (gr)"
            colf04Double.Caption = "Charge (gr)"
            colf03Double16.Caption = "T.Net (gr)"
            colf04Double16.Caption = "Settlement (gr)"
            colf07Double.Caption = "Sisa (gr)"
            colf01Double16.Caption = "Net (Rp)"
            colf02Double16.Caption = "Settlement (Rp)"

        Else
            If _prop02TargetProses = TargetProses._05FA23HH01BILLING Then
                colf02String.Caption = "Entity"
                colf14String.Caption = "Identity"
                colf01Date.Caption = "Tgl.Faktur"
                colf02Date.Caption = "Tgl.JT"
                colk03String.Caption = "No.Faktur"
                colk05String.Caption = "SJ"
                colf04String.Caption = "Brand"
                colf10String.Caption = "RPY"
                colf05Double16.Caption = "Kadar"
                colf11String.Caption = "Karat"
                colf03Int.Caption = "Pcs (Lot)"         'SKK
                colf03Double.Caption = "Gross (gr)"    'SKK
                colf05Double.Caption = "Tukaran"  'TukaranEnd
                colf03Double16.Caption = "Net (gr)"
            End If
        End If

    End Sub

    Private Sub _vs01VisibilityCol610Billing()
        If _prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR Then
            colk00Boolean.Visible = True   '"#"
            _01objPilihSemua.Visible = True

            colf02String.Visible = True   '"Entity"
            colf14String.Visible = True   '"Identity"
            colf01Date.Visible = True   '"Tgl.Faktur"
            colf02Date.Visible = True   '"Tgl.JT"
            colk03String.Visible = True   '"No.Faktur"
            'colk05String.Visible = True   '"SJ"
            'colf04String.Visible = True   '"Brand"
            colf10String.Visible = True   '"RatePayment"
            colf04Int.Visible = True   '"TGP"
            'colf05Double16.Visible = True '"Kadar"
            'colf11String.Visible = True   '"Karat"
            'colf03Int.Visible = True   '"Pcs (Lot)"         'SKK
            colf03Double.Visible = True   '"Berat (gram)"    'SKK
            colf05Double.Visible = True   '"Tukaran"  'TukaranEnd
            colf06Double.Visible = True   '"Net (gr)"
            colf04Double.Visible = True   '"Charge (gr)"
            colf03Double16.Visible = True   '"Berat AR"
            colf04Double16.Visible = True   '"Brt LUNAS"
            colf07Double.Visible = True     '"Sisa (gr)"
            colf01Double16.Visible = True   '"Net (Rp)"
            colf02Double16.Visible = True   '"Settlement (Rp)"
        Else
            If _prop02TargetProses = TargetProses._05FA23HH01BILLING Then
                colf02String.Visible = True   '"Entity"
                colf14String.Visible = True   '"Identity"
                colf01Date.Visible = True   '"Tgl.Faktur"
                colf02Date.Visible = True   '"Tgl.JT"
                colk03String.Visible = True   '"No.Faktur"
                colk05String.Visible = True   '"SJ"
                colf04String.Visible = True   '"Brand"
                colf10String.Visible = True   '"RatePayment"
                colf05Double16.Visible = True '"Kadar"
                colf11String.Visible = True   '"Karat"
                colf03Int.Visible = True   '"Pcs (Lot)"         'SKK
                colf03Double.Visible = True   '"Berat (gram)"    'SKK
                colf05Double.Visible = True   '"Tukaran"  'TukaranEnd
                colf03Double16.Visible = True   '"Berat AR"
            End If
        End If

    End Sub

    Private Sub _vs02VisibilityIndex610Billing()
        If _prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR Then
            colk00Boolean.VisibleIndex = 0 '"#"

            colf02String.VisibleIndex = 1   '"Entity"
            colf14String.VisibleIndex = 2   '"Identity"
            colf01Date.VisibleIndex = 3 '"Tgl.Faktur"
            colf02Date.VisibleIndex = 4 '"Tgl.JT"
            colk03String.VisibleIndex = 5 '"No.Faktur"
            'colk05String.VisibleIndex = 6   '"SJ"
            'colf04String.VisibleIndex = 7   '"Brand"
            colf10String.VisibleIndex = 6   '"RatePayment"
            colf04Int.VisibleIndex = 7   '"TGP"
            'colf05Double16.VisibleIndex = 9  '"Kadar"
            'colf11String.VisibleIndex = 10   '"Karat"
            'colf03Int.VisibleIndex = 11   '"Pcs (Lot)"         'SKK
            colf03Double.VisibleIndex = 8   '"Berat (gram)"    'SKK
            colf05Double.VisibleIndex = 9   '"Tukaran"  'TukaranEnd
            colf06Double.VisibleIndex = 10   '"Net (gr)"
            colf04Double.VisibleIndex = 11   '"Charge (gr)"
            colf03Double16.VisibleIndex = 12   '"Berat AR"
            colf04Double16.VisibleIndex = 13   '"Brt LUNAS"
            colf07Double.VisibleIndex = 14     '"Sisa (gr)"
            colf01Double16.VisibleIndex = 15   '"Net (Rp)"
            colf02Double16.VisibleIndex = 16   '"Settlement (Rp)"

        Else
            colf02String.VisibleIndex = 0   '"Entity"
            colf14String.VisibleIndex = 1   '"Identity"
            colf01Date.VisibleIndex = 2 '"Tgl.Faktur"
            colf02Date.VisibleIndex = 3 '"Tgl.JT"
            colk03String.VisibleIndex = 4 '"No.Faktur"
            colk05String.VisibleIndex = 5   '"SJ"
            colf04String.VisibleIndex = 6   '"Brand"
            colf10String.VisibleIndex = 7   '"RatePayment"
            colf05Double16.VisibleIndex = 8  '"Kadar"
            colf11String.VisibleIndex = 9   '"Karat"
            colf03Int.VisibleIndex = 10   '"Pcs (Lot)"         'SKK
            colf03Double.VisibleIndex = 11   '"Berat (gram)"    'SKK
            colf05Double.VisibleIndex = 12   '"Tukaran"  'TukaranEnd
            colf03Double16.VisibleIndex = 13   '"Berat AR"
        End If

    End Sub

    Private Sub _tot01TotalSummary610Billing()
        If _prop02TargetProses = TargetProses._06FA23GU01SETTLEMENTOSTFAKTURAR Then

            colf03Int.SummaryItem.SummaryType = SummaryItemType.Custom
            colf03Int.SummaryItem.DisplayFormat = "{0:n0}"
            colf03Int.SummaryItem.Tag = 1
            CType(colf03Int.View, GridView).OptionsView.ShowFooter = True

            colf03Double.SummaryItem.SummaryType = SummaryItemType.Custom
            colf03Double.SummaryItem.DisplayFormat = "{0:n2}"
            colf03Double.SummaryItem.Tag = 2
            CType(colf03Double.View, GridView).OptionsView.ShowFooter = True

            colf06Double.SummaryItem.SummaryType = SummaryItemType.Custom
            colf06Double.SummaryItem.DisplayFormat = "{0:n2}"
            colf06Double.SummaryItem.Tag = 26
            CType(colf06Double.View, GridView).OptionsView.ShowFooter = True

            colf04Double.SummaryItem.SummaryType = SummaryItemType.Custom
            colf04Double.SummaryItem.DisplayFormat = "{0:n2}"
            colf04Double.SummaryItem.Tag = 24
            CType(colf04Double.View, GridView).OptionsView.ShowFooter = True

            colf03Double16.SummaryItem.SummaryType = SummaryItemType.Custom
            colf03Double16.SummaryItem.DisplayFormat = "{0:n3}"
            colf03Double16.SummaryItem.Tag = 3
            CType(colf03Double16.View, GridView).OptionsView.ShowFooter = True

            colf04Double16.SummaryItem.SummaryType = SummaryItemType.Custom
            colf04Double16.SummaryItem.DisplayFormat = "{0:n3}"
            colf04Double16.SummaryItem.Tag = 4
            CType(colf04Double16.View, GridView).OptionsView.ShowFooter = True

            colf01Double16.SummaryItem.SummaryType = SummaryItemType.Custom
            colf01Double16.SummaryItem.DisplayFormat = "{0:n0}"
            colf01Double16.SummaryItem.Tag = 5
            CType(colf01Double16.View, GridView).OptionsView.ShowFooter = True

            colf02Double16.SummaryItem.SummaryType = SummaryItemType.Custom
            colf02Double16.SummaryItem.DisplayFormat = "{0:n0}"
            colf02Double16.SummaryItem.Tag = 6
            CType(colf02Double16.View, GridView).OptionsView.ShowFooter = True
        Else

            GridView1.OptionsView.ShowFooter = True

            '"Pcs SKK"
            GridView1.Columns("f03Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f03Int").SummaryItem.FieldName = "f03Int"
            GridView1.Columns("f03Int").SummaryItem.DisplayFormat = "{0:n0}"

            '"Berat SKK"
            GridView1.Columns("f03Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f03Double").SummaryItem.FieldName = "f03Double"
            GridView1.Columns("f03Double").SummaryItem.DisplayFormat = "{0:n2}"

            '"Berat AR"
            GridView1.Columns("f03Double16").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f03Double16").SummaryItem.FieldName = "f03Double16"
            GridView1.Columns("f03Double16").SummaryItem.DisplayFormat = "{0:n3}"
        End If
    End Sub

    Private Sub _tot02GroupSummary610Billing()
        GridView1.GroupSummary.Clear()

        Dim pnGroupBrtLunas As New GridGroupSummaryItem()
        With pnGroupBrtLunas
            .FieldName = "f04Double16"
            .Tag = 416
            .DisplayFormat = "{0:n3}"
            .SummaryType = DevExpress.Data.SummaryItemType.Custom
            .ShowInGroupColumnFooter = GridView1.Columns("f04Double16")
        End With

        GridView1.GroupSummary.Add(pnGroupBrtLunas)

        Dim pnGroupRpLunas As New GridGroupSummaryItem()
        With pnGroupRpLunas
            .FieldName = "f02Double16"
            .Tag = 216
            .DisplayFormat = "{0:n0}"
            .SummaryType = DevExpress.Data.SummaryItemType.Custom
            .ShowInGroupColumnFooter = GridView1.Columns("f02Double16")
        End With

        GridView1.GroupSummary.Add(pnGroupRpLunas)
    End Sub

    Private Sub _ll01SettingLain610Billing()
        With colf04Int
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf05Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n2}%"
            End With
        End With

        With colf05Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "P2"
            End With
        End With

        With colf03Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf04Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With

        With colf01Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf02Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        GridView1.BeginSort()
        Try
            GridView1.ClearGrouping()
            colf02String.GroupIndex = 0
            colf14String.GroupIndex = 1
            colf10String.GroupIndex = 2
        Finally
            GridView1.EndSort()
        End Try

        ' "Count" summary item
        Dim gscCount As New GridGroupSummaryItem()
        gscCount.SummaryType = SummaryItemType.Count
        gscCount.DisplayFormat = "({0} Faktur)"
        GridView1.GroupSummary.Add(gscCount)

        Dim itemPcs As GridGroupSummaryItem = New GridGroupSummaryItem()
        With itemPcs
            .FieldName = "f03Int"
            .ShowInGroupColumnFooter = GridView1.Columns("f03Int")
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "{0:n0}"
        End With
        GridView1.GroupSummary.Add(itemPcs)

        Dim itemBeratGross As GridGroupSummaryItem = New GridGroupSummaryItem()
        With itemBeratGross
            .FieldName = "f03Double"
            .ShowInGroupColumnFooter = GridView1.Columns("f03Double")
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "{0:n2}"
        End With
        GridView1.GroupSummary.Add(itemBeratGross)

        Dim itemBeratNet As GridGroupSummaryItem = New GridGroupSummaryItem()
        With itemBeratNet
            .FieldName = "f03Double16"
            .ShowInGroupColumnFooter = GridView1.Columns("f03Double16")
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "{0:n3}"
        End With
        GridView1.GroupSummary.Add(itemBeratNet)

        With GridView1.Appearance.GroupFooter
            .Font = New Font("Courier New", 9, FontStyle.Bold)
            .ForeColor = Color.Navy
        End With

        GridView1.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

#End Region

#Region "***** FA Settlement AR (grid COLLECTION PAYMENT) ===> form : ucFA23GU01SETTLEMENTAR *****"

    Private Sub _cc63FASettlementCollectionARCaption()
        colk00Boolean.Caption = "#"

        colk03String.Caption = "No.Dokumen"
        colk05String.Caption = "TipeCollection"
        colf02Int.Caption = "Rate Jual"
        colf03Int.Caption = "Rate Beli"
        colf03Double.Caption = "Berat Emas (gr)"
        colf03Double16.Caption = "Rupiah (Rp.)"
        colf01Date.Caption = "Tanggal"

        'Entrian
        colf02Double.Caption = "Berat Settlement (gr)"
        colf07Double.Caption = "Sisa (gr)"
        colf02Double16.Caption = "Rupiah Settlement (Rp.)"
    End Sub

    Private Sub _vs63FASettlementCollectionARVisibility()
        colk00Boolean.Visible = True  '"#"
        _01objPilihSemua.Visible = True

        colk03String.Visible = True   '"No.Dokumen"	
        colk05String.Visible = True   '"TipeCollection"	
        colf02Int.Visible = True      '"Rate Jual"
        colf03Int.Visible = True      '"Rate Beli"
        colf03Double.Visible = True   '"Berat Emas"	
        colf03Double16.Visible = True   '"Rupiah"	     
        colf01Date.Visible = True   '"Tanggal"	 

        'Entrian
        colf02Double.Visible = True   '"Berat Settlement"
        colf07Double.Visible = True   '"Sisa (gr)"
        colf02Double16.Visible = True   '"Rupiah Settlement"
    End Sub

    Private Sub _vs63FASettlementCollectionARVisibilityIndex()
        colk00Boolean.VisibleIndex = 0  '"#"

        colf01Date.VisibleIndex = 1      '"Tanggal"	
        colk03String.VisibleIndex = 2    '"No.Dokumen"	
        colk05String.VisibleIndex = 3    '"TipeCollection"	
        colf02Int.VisibleIndex = 4       '"Rate Jual"
        colf03Int.VisibleIndex = 5       '"Rate Beli"
        colf03Double.VisibleIndex = 6    '"Berat Emas"	
        colf03Double16.VisibleIndex = 7  '"Rupiah"	

        'Entrian
        colf02Double.VisibleIndex = 8 '"Berat Settlement"
        colf07Double.VisibleIndex = 9   '"Sisa (gr)"
        colf02Double16.VisibleIndex = 10 '"Rupiah Settlement"

        'Write
        colk00Boolean.OptionsColumn.ReadOnly = False
        colf02Double.OptionsColumn.ReadOnly = False
        'colf02Double16.OptionsColumn.ReadOnly = False   'Otomatis terisi : f02Int * f02Double
    End Sub

    Private Sub _tot63FASettlementCollectionARTotalSummary()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n3}"

        GridView1.Columns("f02Double16").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f02Double16").SummaryItem.FieldName = "f02Double16"
        GridView1.Columns("f02Double16").SummaryItem.DisplayFormat = "{0:n0}"
    End Sub

    Private Sub _ll01FASettingLainSettlementCollection()
        With colf03Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf03Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf02Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With

        With colf07Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf02Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf02Int
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf03Int
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With
    End Sub

#End Region

#Region "***** FA Settlement AR (grid COLLECTION FORMULA) ===> form : ucFA23GU01SETTLEMENTAR ***** "
    Private Sub _cc651FACollectionFormulaCaption()
        colf01String.Caption = "Collection"     'f05String	    : Nama Type Collection
        colf01Double.Caption = "Tagihan(gr)"    'f02Double	: Total Gram Tagihan YgAkanDiBayar
        colf02String.Caption = "SatBayar"       'f08String	    : Satuan Bayar (RP/GR)
        colf01Double16.Caption = "Bayar"        'f01Double163	: Total Bayar Dari Cust
        colf03String.Caption = "Faktur"         'f06String	    : FAKTUR Rate Payment (LD/GB)
        colf04String.Caption = "Pembayaran"     'f07String	    : COLLECTION/SETTLEMENT Rate Payment (LD/GB)
        colf01Int.Caption = "RateFaktur"        'f01Double160	: Rate Faktur
        colf02Int.Caption = "RatePembayaran"    'f02Double160	: Rate Settlement
        colf02Double.Caption = "Gross(gr)"      'f03Double	: Gram Gross
        colf03Double.Caption = "Kadar"          'f01Double	: Kadar Settlement
        colf04Double.Caption = "Nett(gr)"       'f04Double	: Gram Nett
        colf05Double.Caption = "Pelunasan(gr)"  'f05Double	: Gram Pelunasan
        colf03Int.Caption = "Pelunasan(Rp)"     'f05Double160	: Total Rupiah Pelunasan
    End Sub

    Private Sub _vs651FACollectionFormulaVisibility()
        colf01String.Visible = True     'f05String	    : Nama Type Collection
        colf01Double.Visible = True     'f02Double	: Total Gram Tagihan YgAkanDiBayar
        colf02String.Visible = True     'f08String	    : Satuan Bayar (RP/GR)
        colf01Double16.Visible = True   'f01Double163	: Total Bayar Dari Cust
        colf03String.Visible = True     'f06String	    : FAKTUR Rate Payment (LD/GB)
        colf04String.Visible = True     'f07String	    : COLLECTION/SETTLEMENT Rate Payment (LD/GB)
        colf01Int.Visible = True        'f01Double160	: Rate Faktur
        colf02Int.Visible = True        'f02Double160	: Rate Settlement
        colf02Double.Visible = True     'f03Double	: Gram Gross
        colf03Double.Visible = True     'f01Double	: Kadar Settlement
        colf04Double.Visible = True     'f04Double	: Gram Nett
        colf05Double.Visible = True     'f05Double	: Gram Pelunasan
        colf03Int.Visible = True        'f05Double160	: Total Rupiah Pelunasan
    End Sub

    Private Sub _vs651FACollectionFormulaVisibilityIndex()
        colf01String.VisibleIndex = 0     'f05String	: Nama Type Collection
        colf01Double.VisibleIndex = 1     'f02Double	: Total Gram Tagihan YgAkanDiBayar
        colf02String.VisibleIndex = 2     'f08String	: Satuan Bayar (RP/GR)
        colf01Double16.VisibleIndex = 3   'f01Double163	: Total Bayar Dari Cust
        colf03String.VisibleIndex = 4     'f06String	: FAKTUR Rate Payment (LD/GB)
        colf04String.VisibleIndex = 5     'f07String	: COLLECTION/SETTLEMENT Rate Payment (LD/GB)
        colf01Int.VisibleIndex = 6        'f01Double160	: Rate Faktur
        colf02Int.VisibleIndex = 7        'f02Double160	: Rate Settlement
        colf02Double.VisibleIndex = 8     'f03Double	: Gram Gross
        colf03Double.VisibleIndex = 9     'f01Double	: Kadar Settlement
        colf04Double.VisibleIndex = 10    'f04Double	: Gram Nett
        colf05Double.VisibleIndex = 11    'f05Double	: Gram Pelunasan
        colf03Int.VisibleIndex = 12       'f05Double160	: Total Rupiah Pelunasan
    End Sub

#End Region

#Region "***** FA Closing Collection ===> form : ucFA23IL01CLOSINGCOLLECTION *****"

    Private Sub _cc63FAClosingCollectionARCaption()
        colk00Boolean.Caption = "#"

        colk05String.Caption = "Nama Collection Type"
        colf02String.Caption = "Nama Group Customer"
        colf10String.Caption = "Identitas"
        colf03Double.Caption = "OST.Berat (grm)"
        colf03Double16.Caption = "OST.Rupiah"
    End Sub

    Private Sub _vs63FAClosingCollectionARVisibility()
        colk00Boolean.Visible = True  '"#"
        _01objPilihSemua.Visible = True

        colk05String.Visible = True  '"Nama Collection Type"
        colf02String.Visible = True  '"Nama Group Customer"
        colf10String.Visible = True  '"Identitas"
        colf03Double.Visible = True  '"OST.Berat (grm)"
        colf03Double16.Visible = True  '"OST.Rupiah"
    End Sub

    Private Sub _vs63FAClosingCollectionARVisibilityIndex()
        colk00Boolean.VisibleIndex = 0  '"#"

        colk05String.VisibleIndex = 1  '"Nama Collection Type"
        colf02String.VisibleIndex = 2  '"Nama Group Customer"
        colf10String.VisibleIndex = 3  '"Identitas"
        colf03Double.VisibleIndex = 4  '"OST.Berat (grm)"
        colf03Double16.VisibleIndex = 5  '"OST.Rupiah"

        'Write
        colk00Boolean.OptionsColumn.ReadOnly = False
    End Sub

    Private Sub _tot63FAClosingCollectionARTotalSummary()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f03Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f03Double").SummaryItem.FieldName = "f03Double"
        GridView1.Columns("f03Double").SummaryItem.DisplayFormat = "{0:n3}"

        GridView1.Columns("f03Double16").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f03Double16").SummaryItem.FieldName = "f03Double16"
        GridView1.Columns("f03Double16").SummaryItem.DisplayFormat = "{0:n0}"
    End Sub

    Private Sub _ll01FASettingLainClosingCollection()
        With colf03Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf03Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With
    End Sub

#End Region

#Region "***** FA ProformaInvoice (grid CREATE/UPDATE/DELETE) ==> form : ucFA23GV01PROFORMAINVOICE *****"

    Private Sub _cc01CaptionCol620Proforma()
        If _prop02TargetProses = TargetProses._01FA23GV01PROFORMAINVOICE_CREATE Then
            colk00Boolean.Caption = "#"
        End If

        colk03String.Caption = "No.Faktur"
        colk04String.Caption = "CO/PO"
        colk05String.Caption = "SJ"
        colf03String.Caption = "TOP"
        colf04String.Caption = "Brand"
        colf05String.Caption = "Warna"
        colf01Int.Caption = "Kadar"
        colf05Double.Caption = "TukaranEnd"
        colf01Date.Caption = "Tgl.Faktur"
        colf02Date.Caption = "Tgl.JT"
        colf02Int.Caption = "Pcs CMK"
        colf03Int.Caption = "Pcs SKK"
        colf01Double.Caption = "Tot.Berat"
        colf02Double.Caption = "Berat CMK"
        colf03Double.Caption = "Berat SKK"

        colf05Int.Caption = "Harga Emas"
        colf07Double.Caption = "AR.Rupiah"
    End Sub

    Private Sub _vs01VisibilityCol620Proforma()
        If _prop02TargetProses = TargetProses._01FA23GV01PROFORMAINVOICE_CREATE Then
            colk00Boolean.Visible = True   '"#"
            _01objPilihSemua.Visible = True
        End If

        'VISIBLE
        colk03String.Visible = True   '"No.Faktur"
        colk04String.Visible = True   '"CO/PO"
        colk05String.Visible = True   '"SJ"
        colf03String.Visible = True   '"TOP"
        colf04String.Visible = True   '"Brand"
        colf05String.Visible = True   '"Warna"
        colf01Int.Visible = True      '"Kadar"
        colf05Double.Visible = True   '"TukaranEnd"
        colf01Date.Visible = True     '"Tgl.Faktur"
        colf02Date.Visible = True     '"Tgl.JT"
        colf02Int.Visible = True      '"Pcs CMK"
        colf03Int.Visible = True      '"Pcs SKK"
        colf01Double.Visible = True   '"Tot.Berat"
        colf02Double.Visible = True   '"Berat CMK"
        colf03Double.Visible = True   '"Berat SKK"

        colf05Int.Visible = True   '"Harga Emas"
        colf07Double.Visible = True   '"AR.Rupiah"
    End Sub

    Private Sub _vs02VisibilityIndex620Proforma()
        If _prop02TargetProses = TargetProses._01FA23GV01PROFORMAINVOICE_CREATE Then
            colk00Boolean.VisibleIndex = 0 '"#"
            'VISIBLE
            colk03String.VisibleIndex = 1 '"No.Faktur"
            colk04String.VisibleIndex = 2 '"CO/PO"
            colk05String.VisibleIndex = 3 '"SJ"
            colf03String.VisibleIndex = 4 '"TOP"
            colf04String.VisibleIndex = 5 '"Brand"
            colf05String.VisibleIndex = 6 '"Warna"
            colf01Int.VisibleIndex = 7 '"Kadar"
            colf05Double.VisibleIndex = 8 '"TukaranEnd"
            colf02Int.VisibleIndex = 9 '"Pcs CMK"
            colf02Double.VisibleIndex = 10 '"Berat CMK"
            colf03Int.VisibleIndex = 11 '"Pcs SKK"
            colf03Double.VisibleIndex = 12 '"Berat SKK"
            colf01Double.VisibleIndex = 13 '"Tot.Berat"
            colf05Int.VisibleIndex = 14 '"Harga Emas"
            colf07Double.VisibleIndex = 15 '"AR.Rupiah"
            colf01Date.VisibleIndex = 16 '"Tgl.Faktur"
            colf02Date.VisibleIndex = 17 '"Tgl.JT"
        Else
            'VISIBLE
            colk03String.VisibleIndex = 0 '"No.Faktur"
            colk04String.VisibleIndex = 1 '"CO/PO"
            colk05String.VisibleIndex = 2 '"SJ"
            colf03String.VisibleIndex = 3 '"TOP"
            colf04String.VisibleIndex = 4 '"Brand"
            colf05String.VisibleIndex = 5 '"Warna"
            colf01Int.VisibleIndex = 6 '"Kadar"
            colf05Double.VisibleIndex = 7 '"TukaranEnd"
            colf02Int.VisibleIndex = 8 '"Pcs CMK"
            colf02Double.VisibleIndex = 9 '"Berat CMK"
            colf03Int.VisibleIndex = 10 '"Pcs SKK"
            colf03Double.VisibleIndex = 11 '"Berat SKK"
            colf01Double.VisibleIndex = 12 '"Tot.Berat"
            colf05Int.VisibleIndex = 13 '"Harga Emas"
            colf07Double.VisibleIndex = 14 '"AR.Rupiah"
            colf01Date.VisibleIndex = 15 '"Tgl.Faktur"
            colf02Date.VisibleIndex = 16 '"Tgl.JT"
        End If

    End Sub

    Private Sub _wr01WriteCol620Proforma()
        If _prop02TargetProses = TargetProses._01FA23GV01PROFORMAINVOICE_CREATE Then
            colk00Boolean.OptionsColumn.ReadOnly = False '"#"
        End If
    End Sub

    Private Sub _tot01TotalSummary620Proforma()
        If _prop02TargetProses = TargetProses._01FA23GV01PROFORMAINVOICE_CREATE Then

            colf02Int.SummaryItem.SummaryType = SummaryItemType.Custom
            colf02Int.SummaryItem.DisplayFormat = "{0:n0}"
            colf02Int.SummaryItem.Tag = 1
            CType(colf02Int.View, GridView).OptionsView.ShowFooter = True

            colf03Int.SummaryItem.SummaryType = SummaryItemType.Custom
            colf03Int.SummaryItem.DisplayFormat = "{0:n0}"
            colf03Int.SummaryItem.Tag = 2
            CType(colf03Int.View, GridView).OptionsView.ShowFooter = True

            colf02Double.SummaryItem.SummaryType = SummaryItemType.Custom
            colf02Double.SummaryItem.DisplayFormat = "{0:n2}"
            colf02Double.SummaryItem.Tag = 3
            CType(colf02Double.View, GridView).OptionsView.ShowFooter = True

            colf03Double.SummaryItem.SummaryType = SummaryItemType.Custom
            colf03Double.SummaryItem.DisplayFormat = "{0:n2}"
            colf03Double.SummaryItem.Tag = 4
            CType(colf03Double.View, GridView).OptionsView.ShowFooter = True

            colf01Double.SummaryItem.SummaryType = SummaryItemType.Custom
            colf01Double.SummaryItem.DisplayFormat = "{0:n2}"
            colf01Double.SummaryItem.Tag = 5
            CType(colf01Double.View, GridView).OptionsView.ShowFooter = True

            colf07Double.SummaryItem.SummaryType = SummaryItemType.Custom
            colf07Double.SummaryItem.DisplayFormat = "{0:n2}"
            colf07Double.SummaryItem.Tag = 6
            CType(colf07Double.View, GridView).OptionsView.ShowFooter = True

        Else
            GridView1.OptionsView.ShowFooter = True

            '"Pcs CMK"
            GridView1.Columns("f02Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f02Int").SummaryItem.FieldName = "f02Int"
            GridView1.Columns("f02Int").SummaryItem.DisplayFormat = "{0:n0}"
            '"Pcs SKK"
            GridView1.Columns("f03Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f03Int").SummaryItem.FieldName = "f03Int"
            GridView1.Columns("f03Int").SummaryItem.DisplayFormat = "{0:n0}"

            '"Berat CMK"
            GridView1.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
            GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"

            '"Berat SKK"
            GridView1.Columns("f03Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f03Double").SummaryItem.FieldName = "f03Double"
            GridView1.Columns("f03Double").SummaryItem.DisplayFormat = "{0:n2}"

            '"Tot.Berat"
            GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
            GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

            '"AR.Rupiah"
            GridView1.Columns("f07Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("f07Double").SummaryItem.FieldName = "f07Double"
            GridView1.Columns("f07Double").SummaryItem.DisplayFormat = "{0:n2}"
        End If
    End Sub

#End Region

#Region "***** FA TAGIHAN (OST Faktur) ==> form : ucFA24AA01TAGIHAN (Worksheet tim FA)  *****"

    Private Sub _cc01CaptionWorksheetTagihan()
        colk00Boolean.Caption = "#"

        'colf02String.Caption = "Entity"       'Customer
        'colf14String.Caption = "Identity"     'NON/YES
        colf01Date.Caption = "Tgl.Faktur"
        colf02Date.Caption = "Tgl.JT FAKTUR"
        colk03String.Caption = "No.Faktur"
        colf10String.Caption = "RPY"          'LD/GOLDBAR
        colf04Int.Caption = "TGP"
        colf01Double.Caption = "XCharge(gr)"
        colf02Double.Caption = "Retur(gr)"
        colf03Double.Caption = "Gross(gr)"    'SKK
        colf05Double.Caption = "Tukaran"       'TukaranEnd
        colf06Double.Caption = "Net(gr)"
        colf04Double.Caption = "Charge(gr)"
        colf03Double16.Caption = "T.Net(gr)"
        colf04Double16.Caption = "Settl(gr)"
        colf07Double.Caption = "Sisa(gr)"
        colf01Double16.Caption = "Jumlah(Rp)"
        colf02Double16.Caption = "Settl(Rp)"
        colf05Double16.Caption = "Sisa(Rp)"
    End Sub

    Private Sub _vs01VisibilityWorksheetTagihan()
        colk00Boolean.Visible = True    '"#"

        'colf02String.Visible = True     '"Entity"
        'colf14String.Visible = True     '"Identity"
        colf01Date.Visible = True       '"Tgl.Faktur"
        colf02Date.Visible = True       '"Tgl.JT"
        colk03String.Visible = True     '"No.Faktur"
        colf10String.Visible = True     '"RatePayment"
        colf04Int.Visible = True        '"TGP"
        colf01Double.Visible = False     '"XCharge(gr)"
        colf02Double.Visible = True     '"Retur(gr)"
        colf03Double.Visible = True     '"Berat (gram)"    'SKK
        colf05Double.Visible = True     '"Tukaran"  'TukaranEnd
        colf06Double.Visible = True     '"Net (gr)"
        colf04Double.Visible = True     '"Charge (gr)"
        colf03Double16.Visible = True   '"Berat AR"
        colf04Double16.Visible = True   '"Brt LUNAS"
        colf07Double.Visible = True     '"Sisa (gr)"
        colf01Double16.Visible = True   '"Net (Rp)"
        colf02Double16.Visible = True   '"Settlement (Rp)"
        colf05Double16.Visible = True   '"Sisa(Rp)"
    End Sub

    Private Sub _vs02VisibilityIndexWorksheetTagihan()
        colk00Boolean.VisibleIndex = 0     '"#"

        'colf02String.VisibleIndex = 1      '"Entity"
        'colf14String.VisibleIndex = 2      '"Identity"
        colf01Date.VisibleIndex = 1        '"Tgl.Faktur"
        colf02Date.VisibleIndex = 2        '"Tgl.JT"
        colk03String.VisibleIndex = 3      '"No.Faktur"
        colf10String.VisibleIndex = 4      '"RatePayment"
        colf04Int.VisibleIndex = 5         '"TGP"
        colf03Double.VisibleIndex = 6      '"Berat (gram)"    'SKK
        colf05Double.VisibleIndex = 7      '"Tukaran"  'TukaranEnd
        colf06Double.VisibleIndex = 8     '"Net (gr)"
        colf04Double.VisibleIndex = 9     '"Charge (gr)"
        colf01Double.VisibleIndex = -1     '"XCharge(gr)" jika visible akan berniala : 10
        colf02Double.VisibleIndex = 11     '"Retur(gr)"
        colf03Double16.VisibleIndex = 12   '"Berat AR"
        colf04Double16.VisibleIndex = 13  '"Brt LUNAS"
        colf07Double.VisibleIndex = 14     '"Sisa (gr)"
        colf01Double16.VisibleIndex = 15   '"Net (Rp)"
        colf02Double16.VisibleIndex = 16   '"Settlement (Rp)"
        colf05Double16.VisibleIndex = 17   '"Sisa(Rp)"
    End Sub

    Private Sub _tot01TotalCustomSummaryWorksheetTagihan()
        '"Gross(gr)" 
        colf03Double.SummaryItem.SummaryType = SummaryItemType.Custom
        colf03Double.SummaryItem.DisplayFormat = "{0:n2}"
        colf03Double.SummaryItem.Tag = 2
        CType(colf03Double.View, GridView).OptionsView.ShowFooter = True

        '"Net(gr)"
        colf06Double.SummaryItem.SummaryType = SummaryItemType.Custom
        colf06Double.SummaryItem.DisplayFormat = "{0:n2}"
        colf06Double.SummaryItem.Tag = 26
        CType(colf06Double.View, GridView).OptionsView.ShowFooter = True

        '"Charge(gr)"
        colf04Double.SummaryItem.SummaryType = SummaryItemType.Custom
        colf04Double.SummaryItem.DisplayFormat = "{0:n2}"
        colf04Double.SummaryItem.Tag = 24
        CType(colf04Double.View, GridView).OptionsView.ShowFooter = True

        '"T.Net(gr)"
        colf03Double16.SummaryItem.SummaryType = SummaryItemType.Custom
        colf03Double16.SummaryItem.DisplayFormat = "{0:n3}"
        colf03Double16.SummaryItem.Tag = 3
        CType(colf03Double16.View, GridView).OptionsView.ShowFooter = True

        '"Jumlah(Rp)"
        colf01Double16.SummaryItem.SummaryType = SummaryItemType.Custom
        colf01Double16.SummaryItem.DisplayFormat = "{0:n0}"
        colf01Double16.SummaryItem.Tag = 5
        CType(colf01Double16.View, GridView).OptionsView.ShowFooter = True

        GridView1.OptionsView.ShowFooter = True

        '"Settl(gr)"
        GridView1.Columns("f04Double16").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f04Double16").SummaryItem.FieldName = "f04Double16"
        GridView1.Columns("f04Double16").SummaryItem.DisplayFormat = "{0:n3}"

        '"Sisa(gr)"
        GridView1.Columns("f07Double").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f07Double").SummaryItem.FieldName = "f07Double"
        GridView1.Columns("f07Double").SummaryItem.DisplayFormat = "{0:n3}"

        '"Settl(Rp)"
        GridView1.Columns("f02Double16").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f02Double16").SummaryItem.FieldName = "f02Double16"
        GridView1.Columns("f02Double16").SummaryItem.DisplayFormat = "{0:n0}"

        '"Sisa(Rp)"
        GridView1.Columns("f05Double16").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f05Double16").SummaryItem.FieldName = "f05Double16"
        GridView1.Columns("f05Double16").SummaryItem.DisplayFormat = "{0:n0}"
    End Sub

    Private Sub _tot02GroupSummaryWorksheetTagihan()
        GridView1.GroupSummary.Clear()

        Dim pnGroupTBrtNet As New GridGroupSummaryItem()
        With pnGroupTBrtNet
            .FieldName = "f03Double16"
            .DisplayFormat = "{0:n3}"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .ShowInGroupColumnFooter = GridView1.Columns("f03Double16")
        End With

        GridView1.GroupSummary.Add(pnGroupTBrtNet)

        Dim pnGroupBrtLunas As New GridGroupSummaryItem()
        With pnGroupBrtLunas
            .FieldName = "f04Double16"
            .Tag = 416
            .DisplayFormat = "{0:n3}"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .ShowInGroupColumnFooter = GridView1.Columns("f04Double16")
        End With

        GridView1.GroupSummary.Add(pnGroupBrtLunas)

        Dim pnGroupRpOST As New GridGroupSummaryItem()
        With pnGroupRpOST
            .FieldName = "f01Double16"
            .Tag = 116
            .DisplayFormat = "{0:n0}"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .ShowInGroupColumnFooter = GridView1.Columns("f01Double16")
        End With

        GridView1.GroupSummary.Add(pnGroupRpOST)

        Dim pnGroupRpLunas As New GridGroupSummaryItem()
        With pnGroupRpLunas
            .FieldName = "f02Double16"
            .Tag = 216
            .DisplayFormat = "{0:n0}"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .ShowInGroupColumnFooter = GridView1.Columns("f02Double16")
        End With

        GridView1.GroupSummary.Add(pnGroupRpLunas)
    End Sub

    Private Sub _ll01SettingLainWorksheetTagihan()
        _lay01objPilihSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        'colk00Boolean.OptionsColumn.ReadOnly = True

        With colf04Int
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf05Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n2}%"
            End With
        End With

        With colf05Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "P2"
            End With
        End With

        With colf03Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf04Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With

        With colf01Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
            .AppearanceHeader.BackColor = Color.LightSalmon
            .AppearanceCell.BackColor = Color.LightSalmon
        End With

        With colf02Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
            .AppearanceHeader.BackColor = Color.LightSalmon
            .AppearanceCell.BackColor = Color.LightSalmon
        End With

        With colf01Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf02Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With

        With colf05Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf07Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        GridView1.BeginSort()
        Try
            GridView1.ClearGrouping()
            'colf02String.GroupIndex = 0
            'colf14String.GroupIndex = 1
            colf10String.GroupIndex = 0
        Finally
            GridView1.EndSort()
        End Try

        ' "Count" summary item
        Dim gscCount As New GridGroupSummaryItem()
        gscCount.SummaryType = SummaryItemType.Count
        gscCount.DisplayFormat = "({0} Faktur)"
        GridView1.GroupSummary.Add(gscCount)

        Dim itemPcs As GridGroupSummaryItem = New GridGroupSummaryItem()
        With itemPcs
            .FieldName = "f03Int"
            .ShowInGroupColumnFooter = GridView1.Columns("f03Int")
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "{0:n0}"
        End With
        GridView1.GroupSummary.Add(itemPcs)

        Dim itemBeratGross As GridGroupSummaryItem = New GridGroupSummaryItem()
        With itemBeratGross
            .FieldName = "f03Double"
            .ShowInGroupColumnFooter = GridView1.Columns("f03Double")
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "{0:n2}"
        End With
        GridView1.GroupSummary.Add(itemBeratGross)

        Dim itemBeratNet As GridGroupSummaryItem = New GridGroupSummaryItem()
        With itemBeratNet
            .FieldName = "f03Double16"
            .ShowInGroupColumnFooter = GridView1.Columns("f03Double16")
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "{0:n3}"
        End With
        GridView1.GroupSummary.Add(itemBeratNet)

        With GridView1.Appearance.GroupFooter
            .Font = New Font("Courier New", 9, FontStyle.Bold)
            .ForeColor = Color.Navy
        End With

        GridView1.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Public Delegate Sub __dlgAddNewTagihanRETUR(ByVal prmdtDataRetur As DataTable)
    Public Delegate Sub __dlgSpreadRETUR2Faktur(ByVal prmcIdentity As String, ByVal prmcRPY As String)
    Public Delegate Sub __dlgPemutihanAddCharge()
    Public Delegate Function __dlgIsExistDueDate() As Boolean
    Public Delegate Function __dlgGetDataGramForProsesDiscountPelunasan() As Double

    Public Sub __AddNewTagihanRETURInvoke(ByVal prmdtRetur As DataTable)
        Cursor = Cursors.WaitCursor

        Dim pcKodeCustomer As String = "" : Dim pcNamaCustomer As String = ""
        Dim pdTglReturFaktur As Date = Nothing : Dim pcNoReturFaktur As String = ""
        Dim pnKadarAwalReturFaktur As Integer = 0 : Dim pcNote As String = ""

        Dim pnGrossRetur As Double = 0.0 : Dim pnTukaran As Double = 0.0
        Dim pnTGP As Double = 0.0 : Dim pnNettRetur As Double = 0.0

        For Each dtRow As DataRow In prmdtRetur.Rows
            pcKodeCustomer = dtRow("cKodeCustomer")
            pcNamaCustomer = dtRow("cNamaCustomer")
            pdTglReturFaktur = dtRow("dTglReturFaktur")
            pcNoReturFaktur = dtRow("cNoReturFaktur")
            pnKadarAwalReturFaktur = dtRow("nKadarAwalReturFaktur") '* 10  'sb ini 75.5% mjd 755
            pcNote = dtRow("cNote")

            pnGrossRetur = dtRow("nGrossRetur")
            pnTukaran = dtRow("nTukaran") / 100
            pnTGP = dtRow("nTGP")
            pnNettRetur = dtRow("nNettRetur")
        Next

        If pnGrossRetur > 0 Then
            _pb04AddNewData(
                            "", 0, pcNoReturFaktur, "", "",
                            pcKodeCustomer, pcNamaCustomer, "", "", "",
                            "", "", "", "", "XRETUR",
                            "", pcKodeCustomer, pcNamaCustomer, "", "",
                            "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                            pcNote,
                            pnKadarAwalReturFaktur, 0, 0, pnTGP, 0, 0, 0,
                            0.0, 0.0, pnGrossRetur, 0.0, pnTukaran, pnNettRetur, 0.0,
                            0.0, 0.0, pnNettRetur, 0.0, 0.0,
                            pdTglReturFaktur, "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                            "3000-01-01", "3000-01-01", "", "", "", "", True)

            MsgBox("Add New data RETUR ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _prop01User._UserProp01cTitle)
        End If

        Cursor = Cursors.Default
    End Sub

    Public Sub __SpreadRETUR2FakturInvoke(ByVal prmcIdentityCustomer As String, ByVal prmcRatePayment As String)
        Cursor = Cursors.WaitCursor

        Dim pnTotGramRetur As Double = 0.0
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If dtRow("f10String").ToString = "XRETUR" Then
                pnTotGramRetur = pnTotGramRetur + CDbl(dtRow("f03Double16"))
            End If
        Next

        If pnTotGramRetur > 0 Then
            Dim pcNettPlusCharge As Double = 0.0
            Dim pnTGP As Integer = 0

            For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
                If dtRow("f10String").ToString = prmcRatePayment Then

                    If pnTotGramRetur > 0 Then
                        pnTGP = 0
                        pnTGP = CInt(dtRow("f04Int"))

                        pcNettPlusCharge = 0.0
                        pcNettPlusCharge = CDbl(dtRow("f06Double")) + CDbl(dtRow("f04Double"))

                        If pcNettPlusCharge = pnTotGramRetur Then

                            dtRow("f02Double") = pnTotGramRetur      'Retur
                            dtRow("f03Double16") = 0               'T.NET (gr)
                            dtRow("f01Double16") = 0               'T.Net (RP)
                            pnTotGramRetur = 0
                        Else
                            If pcNettPlusCharge > pnTotGramRetur Then

                                dtRow("f02Double") = pnTotGramRetur                                   'Retur
                                dtRow("f03Double16") = pcNettPlusCharge - pnTotGramRetur              'T.NET (gr)
                                dtRow("f01Double16") = (pcNettPlusCharge - pnTotGramRetur) * pnTGP    'T.Net (RP)
                                pnTotGramRetur = 0
                            Else
                                If pcNettPlusCharge < pnTotGramRetur Then

                                    dtRow("f02Double") = pcNettPlusCharge                   'Retur
                                    dtRow("f03Double16") = 0                                'T.NET (gr)
                                    dtRow("f01Double16") = 0                               'T.Net (RP)
                                    pnTotGramRetur = pnTotGramRetur - pcNettPlusCharge
                                End If
                            End If
                        End If


                    End If
                End If
            Next
            _prop03pdtDataSourceGrid.AcceptChanges()

            MsgBox("Proses RETUR ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _prop01User._UserProp01cTitle)
        End If

        Cursor = Cursors.Default
    End Sub

    Public Sub __HapusAddChargeInvoke()
        Dim pnJmlData As Int16 = 0
        Dim pnAddCharge As Double = 0.0

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            dtRow("f01Double") = 0.0
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            pnAddCharge = 0.0
            pnAddCharge = dtRow("f04Double")

            If pnAddCharge > 0.0 Then
                pnJmlData = pnJmlData + 1
                dtRow("f01Double") = pnAddCharge
                dtRow("f04Double") = 0.0

                'JANGAN DIBALIK URUTANNYA
                'T.Net-Rp : f01Double16
                dtRow("f01Double16") = ((dtRow("f03Double16") - pnAddCharge) * dtRow("f04Int")) - dtRow("f02Double16")

                'T.Net-Gr : f03Double16
                dtRow("f03Double16") = (dtRow("f03Double16") - pnAddCharge) - dtRow("f07Double")

            End If
        Next

        If pnJmlData > 0 Then
            _prop03pdtDataSourceGrid.AcceptChanges()

            MsgBox("Proses Penghapusan ADDCHARGE ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _prop01User._UserProp01cTitle)

            colf01Double.Visible = True
            colf01Double.VisibleIndex = 10
        Else
            MsgBox("Proses Penghapusan ADDCHARGE ... GAGAL ...", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Public Function __ApakahAdaJTInvoke() As Boolean
        Dim plAdaJT As Boolean = False

        'colf04Double.Caption = "Charge(gr)"
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If CDbl(dtRow("f04Double")) > 0.0 Then
                plAdaJT = True
            End If
        Next

        Return plAdaJT
    End Function

    Public Function __GetTotGramRupiahOSTFaktur4CashbackFakturInvoke(ByVal prmcTarget_RP_GRM As String) As Double
        Dim pnHasil As Double = 0.0

        'colf03Double16.Caption = "T.Net(gr)"
        'colf01Double16.Caption = "Jumlah(Rp)"
        'colf05Double           = "TukaranEnd"
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows

            If prmcTarget_RP_GRM = "GRM" Then
                pnHasil = pnHasil + CDbl(dtRow("f03Double16"))
            Else
                If prmcTarget_RP_GRM = "RP" Then
                    pnHasil = pnHasil + CDbl(dtRow("f01Double16"))
                End If
            End If

        Next

        Return pnHasil
    End Function

    Public Function __DiscountPelunasanGetDataGramFakturOSTARInvoke() As Double
        Dim pnTotBerat As Double = 0.0

        'Unt melakukan DISCOUNT PELUNASAN (BUKAN CASHBACK), 
        'OST FAKTUR HARUS di PILIH (checkbox) terlebih dahulu, sb BISA LUNAS SEBAGIAN.
        'Agar bisa menghitung BERAPA TOTAL GRAM yg akan di LUNASI
        '======================================================
        'Assumsi nya adl : dari grid OST FAKTUR
        'colk00Boolean.Caption = "#"
        'colf03Double16.Caption = "T.Net (gr)"
        'colf04Double16.Caption = "Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"
        '======================================================
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If CBool(dtRow("k00Boolean")) Then
                pnTotBerat = pnTotBerat + CDbl(dtRow("f03Double16"))
            End If
        Next

        Return pnTotBerat
    End Function

    Public Function __pbFA24AA01ProsesTagihanOSTFaktur(ByVal prmnTotalBeratPayment As Double) As Double
        'colf03Double16.Caption = "T.Net (gr)"
        'colf04Double16.Caption = "Settlement (gr)"
        'colf07Double.Caption = "Sisa (gr)"
        'colf01Double16.Caption = "Net (Rp)"
        'colf02Double16.Caption = "Settlement (Rp)"

        'Initialisasi
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If dtRow("f10String") <> "XRETUR" Then
                dtRow("f04Double16") = 0
                dtRow("f07Double") = 0

                dtRow("k00Boolean") = False
                dtRow("k00Int") = 0
            End If
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()

        Dim pnTotBeratPakaiProses As Double = prmnTotalBeratPayment
        Dim pnTGP As Integer = 0
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If dtRow("f10String") <> "XRETUR" Then

                If prmnTotalBeratPayment > 0 Then
                    pnTGP = 0
                    pnTGP = CInt(dtRow("f04Int"))

                    '"f03Double16" = BERAT Collection Customer
                    '"f04Double16" = BERAT Payment/Settlement
                    If CDbl(dtRow("f03Double16")) = prmnTotalBeratPayment Then
                        dtRow("f04Double16") = prmnTotalBeratPayment           '"Settl(gr)"
                        dtRow("f07Double") = 0                                 '"Sisa(gr)"
                        dtRow("f02Double16") = prmnTotalBeratPayment * pnTGP   '"Settl(Rp)"
                        dtRow("f05Double16") = 0                               '"Sisa(Rp)"
                        prmnTotalBeratPayment = 0
                    Else
                        If CDbl(dtRow("f03Double16")) > prmnTotalBeratPayment Then
                            dtRow("f04Double16") = prmnTotalBeratPayment
                            dtRow("f07Double") = CDbl(dtRow("f03Double16")) - prmnTotalBeratPayment
                            dtRow("f02Double16") = prmnTotalBeratPayment * pnTGP   '"Settl(Rp)"
                            dtRow("f05Double16") = (CDbl(dtRow("f03Double16")) - prmnTotalBeratPayment) * pnTGP  '"Sisa(Rp)"
                            prmnTotalBeratPayment = 0
                        Else
                            If CDbl(dtRow("f03Double16")) < prmnTotalBeratPayment Then
                                dtRow("f04Double16") = CDbl(dtRow("f03Double16"))
                                dtRow("f07Double") = 0
                                dtRow("f02Double16") = CDbl(dtRow("f03Double16")) * pnTGP   '"Settl(Rp)"
                                dtRow("f05Double16") = 0                               '"Sisa(Rp)"
                                prmnTotalBeratPayment = prmnTotalBeratPayment - CDbl(dtRow("f03Double16"))
                            End If
                        End If
                    End If

                    dtRow("k00Boolean") = True
                    dtRow("k00Int") = 1
                End If

            End If
        Next

        _prop03pdtDataSourceGrid.AcceptChanges()

        pnTotBeratPakaiProses = pnTotBeratPakaiProses - prmnTotalBeratPayment

        Return pnTotBeratPakaiProses
    End Function

#End Region

#Region "***** FA TAGIHAN (PAYMENT) =>= Form : ucFA24AA01TAGIHAN (Worksheet tim FA)  *****"
    Private Sub _cc01CaptionTagihanPayment()
        'Berdasarkan TABLE73 (pemakaian PAYMENT)
        colk00Boolean.Caption = "#"

        colk04String.Caption = "NoPayment"
        'colf03String.Caption = "Collection"
        colf05String.Caption = "Channel"
        colf06String.Caption = "Faktur"
        colf07String.Caption = "Pay"
        colf08String.Caption = "Sat.Pay"
        colf03Date.Caption = "Tgl.RatePay"
        colf01Int.Caption = "RateJual"
        colf02Int.Caption = "RateBeli"
        colf01Double.Caption = "OST-GRAM"
        colf02Double.Caption = "Wt.Settl"
        colf03Double.Caption = "Wt.Sisa.Settl"
        colf01Double16.Caption = "OST-RUPIAH"
        colf02Double16.Caption = "Rp.Settl"
        colf03Double16.Caption = "Rp.Sisa.Settl"

    End Sub

    Private Sub _vs01VisibilityTagihanPayment()
        colk00Boolean.Visible = True   '"#"

        colk04String.Visible = True   '"NoPayment"
        'colf03String.Visible = True   '"Collection"
        colf05String.Visible = True   '"Channel"
        colf06String.Visible = True   '"Faktur"
        colf07String.Visible = True   '"Payment"
        colf08String.Visible = True   '"Sat.Pay"
        colf03Date.Visible = True   '"Tgl.RatePayment"
        colf01Int.Visible = True   '"RateJual"
        colf02Int.Visible = True   '"RateBeli"
        colf01Double.Visible = True   '"OST-GRAM"
        colf02Double.Visible = True   '"Wt.Settl"
        colf03Double.Visible = True   '"Wt.Sisa.Settl"
        colf01Double16.Visible = True   '"OST-RUPIAH"
        colf02Double16.Visible = True   '"Rp.Settl"
        colf03Double16.Visible = True   '"Rp.Sisa.Settl

    End Sub

    Private Sub _vs02VisibilityIndexTagihanPayment()
        colk00Boolean.VisibleIndex = 0     '"#"

        colk04String.VisibleIndex = 1   '"NoPayment"
        'colf03String.VisibleIndex = 2   '"Collection"
        colf05String.VisibleIndex = 3   '"Channel"
        colf06String.VisibleIndex = 4   '"Faktur"
        colf07String.VisibleIndex = 5   '"Payment"
        colf08String.VisibleIndex = 6   '"Sat.Pay"
        colf03Date.VisibleIndex = 7   '"Tgl.RatePayment"
        colf01Int.VisibleIndex = 8   '"RateJual"
        colf02Int.VisibleIndex = 9   '"RateBeli"
        colf01Double.VisibleIndex = 10   '"OST-GRAM"
        colf02Double.VisibleIndex = 11   '"Wt.Settl"
        colf03Double.VisibleIndex = 12   '"Wt.Sisa.Settl"
        colf01Double16.VisibleIndex = 13   '"OST-RUPIAH"
        colf02Double16.VisibleIndex = 14   '"Rp.Settl"
        colf03Double16.VisibleIndex = 15   '"Rp.Sisa.Settl"

    End Sub

    Private Sub _tot01TotalCustomSummaryTagihanPayment()
        GridView1.OptionsView.ShowFooter = True
        'Summary
        GridView1.Columns("f01Double").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n3}"

        GridView1.Columns("f01Double16").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f01Double16").SummaryItem.FieldName = "f01Double16"
        GridView1.Columns("f01Double16").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f02Double").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n3}"

        GridView1.Columns("f02Double16").SummaryItem.SummaryType = SummaryItemType.Sum
        GridView1.Columns("f02Double16").SummaryItem.FieldName = "f02Double16"
        GridView1.Columns("f02Double16").SummaryItem.DisplayFormat = "{0:n0}"

    End Sub

    'Private Sub _wr01WriteOnlyTagihanPayment()
    '    'Write
    '    'colk00Boolean.OptionsColumn.ReadOnly = False
    '    'colf02Double.OptionsColumn.ReadOnly = False
    '    'colf02Double16.OptionsColumn.ReadOnly = False
    'End Sub

    Private Sub _ll01SettingLainTagihanPayment()

        _lay01objPilihSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        colk00Boolean.OptionsColumn.ReadOnly = True

        With colf01Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf02Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With

        With colf03Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf01Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With

        With colf02Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With

        With colf03Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
        End With
    End Sub

    Public Delegate Sub __dlgAddNewTagihanPAYMENT(ByVal prmcKodeCustomer As String,
                                                  ByVal prmcNoDocPayment As String,
                                                  ByVal prmdTglTagihan As Date,
                                                  ByVal prmdTglExpiredTagihan As Date)

    Public Delegate Sub __dlgPaymentPelunasan()

    Public Sub __AddNewTagihanPAYMENTInvoke(ByVal prmcCustomer As String, ByVal prmcNoDoc As String, ByVal prmdTanggalTGH As Date, ByVal prmdTanggalExpiredTGH As Date)
        'based on SBU..TABLE73
        'tapi "pdtHasil" dari SBU..TABLE72
        Dim pdtHasil As New DataTable

        Cursor = Cursors.WaitCursor

        Using objFinanceHelper As clsFinanceHelper = New clsFinanceHelper
            pdtHasil = objFinanceHelper._mFA70GetDataOSTPaymentTagihan(_prop01User._UserProp07TargetNetwork, prmcCustomer, prmcNoDoc)
        End Using

        For Each dtRow As DataRow In pdtHasil.Rows
            _pb04AddNewData(
                    dtRow("k01String"), 0, "", dtRow("k03String"), dtRow("k04String"),
                    dtRow("f01String"), dtRow("f05String"), dtRow("f06String"), dtRow("f11String"), dtRow("f12String"),
                    dtRow("f03String"), dtRow("f10String"), dtRow("f08String"), "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "",
                    "",
                    dtRow("f02Int"), dtRow("f03Int"), 0, 0, 0, 0, 0,
                    dtRow("f04Double") - dtRow("f05Double"), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                    dtRow("f02Double16") - dtRow("f03Double16"), 0.0, 0.0, 0.0, 0.0,
                    prmdTanggalTGH, prmdTanggalExpiredTGH, dtRow("f01Date"), dtRow("f03Date"), "3000-01-01",
                    Now.Date, dtRow("f02Datetime"), _prop01User._UserProp02cUserID, dtRow("f02IDUser"), _prop01User._UserProp03cUserName, dtRow("f02NamaUser"), True)
        Next

        Cursor = Cursors.Default
    End Sub

    Public Function __DiscountPelunasanGetDataGramExistingPaymentInvoke() As Double
        Dim pnTotBerat As Double = 0.0

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            pnTotBerat = pnTotBerat + CDbl(dtRow("f01Double"))
        Next

        Return pnTotBerat
    End Function

    Public Function __GetTotGramRupiahPayment4CashbackPaymentInvoke(ByVal prmcTarget_RP_GRM As String) As Double
        Dim pnHasil As Double = 0.0

        'colf01Double.Caption = "OST-GRAM"
        'colf01Double16.Caption = "OST-RUPIAH"
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If prmcTarget_RP_GRM = "GRM" Then
                pnHasil = pnHasil + CDbl(dtRow("f01Double"))
            Else
                If prmcTarget_RP_GRM = "RP" Then
                    pnHasil = pnHasil + CDbl(dtRow("f01Double16"))
                End If
            End If
        Next

        Return pnHasil
    End Function

    Public Sub __PaymentPelunasanInvoke()

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            dtRow("k00Boolean") = True
            dtRow("k00Int") = 1
            dtRow("f02Double") = dtRow("f01Double")
            dtRow("f02Double16") = dtRow("f01Double16")
        Next

        _prop03pdtDataSourceGrid.AcceptChanges()

        Me.Refresh()
    End Sub

    Public Function __pbFA24AA01GetDataTotalBeratPayment() As Double
        Return FormatNumber(CDbl(colf01Double.SummaryItem.SummaryValue), 3)
    End Function

    Public Sub __pbFA24AA01ProsesTagihanPayment(ByVal prmnTotBeratYgDiPakaiPelunasan As Double)
        'colf01Double.Caption = "OST-GRAM"
        'colf02Double.Caption = "Wt.Settl"
        'colf03Double.Caption = "Wt.Sisa.Settl"
        'colf01Double16.Caption = "OST-RUPIAH"
        'colf02Double16.Caption = "Rp.Settl"
        'colf03Double16.Caption = "Rp.Sisa.Settl"

        'Initialisasi
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            dtRow("f02Double") = 0
            dtRow("f03Double") = 0

            dtRow("k00Boolean") = False
            dtRow("k00Int") = 0
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()

        Dim pnTGPReal As Integer = 0
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If prmnTotBeratYgDiPakaiPelunasan > 0 Then
                pnTGPReal = 0
                pnTGPReal = dtRow("f01Double16") / dtRow("f01Double")

                If CDbl(dtRow("f01Double")) = prmnTotBeratYgDiPakaiPelunasan Then
                    dtRow("f02Double") = prmnTotBeratYgDiPakaiPelunasan
                    dtRow("f03Double") = 0
                    dtRow("f02Double16") = prmnTotBeratYgDiPakaiPelunasan * pnTGPReal       '"Rp.Settl"
                    dtRow("f03Double16") = 0                                            '"Rp.Sisa.Settl"
                    prmnTotBeratYgDiPakaiPelunasan = 0
                Else
                    If CDbl(dtRow("f01Double")) > prmnTotBeratYgDiPakaiPelunasan Then
                        dtRow("f02Double") = prmnTotBeratYgDiPakaiPelunasan
                        dtRow("f03Double") = CDbl(dtRow("f01Double")) - prmnTotBeratYgDiPakaiPelunasan
                        dtRow("f02Double16") = prmnTotBeratYgDiPakaiPelunasan * pnTGPReal                                '"Rp.Settl"
                        dtRow("f03Double16") = (CDbl(dtRow("f01Double")) - prmnTotBeratYgDiPakaiPelunasan) * pnTGPReal   '"Rp.Sisa.Settl"
                        prmnTotBeratYgDiPakaiPelunasan = 0
                    Else
                        If CDbl(dtRow("f01Double")) < prmnTotBeratYgDiPakaiPelunasan Then
                            dtRow("f02Double") = CDbl(dtRow("f01Double"))
                            dtRow("f03Double") = 0
                            dtRow("f02Double16") = CDbl(dtRow("f01Double")) * pnTGPReal       '"Rp.Settl"
                            dtRow("f03Double16") = 0                                      '"Rp.Sisa.Settl"
                            prmnTotBeratYgDiPakaiPelunasan = prmnTotBeratYgDiPakaiPelunasan - CDbl(dtRow("f01Double"))
                        End If
                    End If
                End If

                dtRow("k00Boolean") = True
                dtRow("k00Int") = 1
            End If
        Next

        _prop03pdtDataSourceGrid.AcceptChanges()
    End Sub

#End Region

#Region "Informasi - Target :"

#End Region

End Class