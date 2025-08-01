Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Data.SqlClient
Imports SKK01CORE
Imports SKK02OBJECTS
Imports SKK02OBJECTS.clsGetDataProsesTransaksiGEMINI

Public Class ucGridTransactionParentChild
    Implements IDisposable

    Property _prop01User As clsUserGEMINI
    Property _prop01TargetTransaksi As TargetTransaksi
    Property _prop02pdtDataSourceGrid As DataTable

    Property _prop03pdtDataSet As DataSet
    Property _prop10String As String
    Property _prop11String As String

    Private pdtTemplate As DataTable
    Private ctrlTemplate As clsTEMPLATEGEMINI

    Private _dataset As DataSet
    Private _pcNamaRelasiParentChild As String = ""

    Private objProses As clsGetDataProsesTransaksiGEMINI

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

    '************************************************
    Private _rsgv2colk02Int As New repoGEMININumeric

    Private _rsgv2colf01Int As New repoGEMININumeric
    Private _rsgv2colf02Int As New repoGEMININumeric
    Private _rsgv2colf03Int As New repoGEMININumeric
    Private _rsgv2colf04Int As New repoGEMININumeric
    Private _rsgv2colf05Int As New repoGEMININumeric
    Private _rsgv2colf06Int As New repoGEMININumeric
    Private _rsgv2colf07Int As New repoGEMININumeric

    Private _rsgv2colf01Double As New repoGEMININumeric
    Private _rsgv2colf02Double As New repoGEMININumeric
    Private _rsgv2colf03Double As New repoGEMININumeric
    Private _rsgv2colf04Double As New repoGEMININumeric
    Private _rsgv2colf05Double As New repoGEMININumeric
    Private _rsgv2colf06Double As New repoGEMININumeric
    Private _rsgv2colf07Double As New repoGEMININumeric

    Private _rsgv2colf01Date As New repoGEMINIDate
    Private _rsgv2colf02Date As New repoGEMINIDate
    Private _rsgv2colf03Date As New repoGEMINIDate
    Private _rsgv2colf04Date As New repoGEMINIDate
    Private _rsgv2colf05Date As New repoGEMINIDate
#End Region

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtTemplate = New DataTable
        ctrlTemplate = New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdtTemplate}
        ctrlTemplate.dtInitTABLEGEMINI()

        objProses = New clsGetDataProsesTransaksiGEMINI

        _dataset = New DataSet
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

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

        '**************************
        _rsgv2colk02Int.Dispose()

        _rsgv2colf01Int.Dispose()
        _rsgv2colf02Int.Dispose()
        _rsgv2colf03Int.Dispose()
        _rsgv2colf04Int.Dispose()
        _rsgv2colf05Int.Dispose()
        _rsgv2colf06Int.Dispose()
        _rsgv2colf07Int.Dispose()

        _rsgv2colf01Double.Dispose()
        _rsgv2colf02Double.Dispose()
        _rsgv2colf03Double.Dispose()
        _rsgv2colf04Double.Dispose()
        _rsgv2colf05Double.Dispose()
        _rsgv2colf06Double.Dispose()
        _rsgv2colf07Double.Dispose()

        _rsgv2colf01Date.Dispose()
        _rsgv2colf02Date.Dispose()
        _rsgv2colf03Date.Dispose()
        _rsgv2colf04Date.Dispose()
        _rsgv2colf05Date.Dispose()

        objProses.Dispose()
        _dataset.Dispose()
    End Sub

    Private Sub ucGridTransactionParentChild_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        colf03Memo.FieldName = "f03Memo"
        colf04Memo.FieldName = "f04Memo"
        colf05Memo.FieldName = "f05Memo"
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

        _gv2cm01InitFieldGrid()
    End Sub

    Private Sub _gv2cm01InitFieldGrid()
        gv2colk01String.FieldName = "k01String"
        gv2colk02Int.FieldName = "k02Int"
        gv2colk03String.FieldName = "k03String"
        gv2colk04String.FieldName = "k04String"
        gv2colk05String.FieldName = "k05String"
        gv2colf01String.FieldName = "f01String"
        gv2colf02String.FieldName = "f02String"
        gv2colf03String.FieldName = "f03String"
        gv2colf04String.FieldName = "f04String"
        gv2colf05String.FieldName = "f05String"
        gv2colf06String.FieldName = "f06String"
        gv2colf07String.FieldName = "f07String"
        gv2colf08String.FieldName = "f08String"
        gv2colf09String.FieldName = "f09String"
        gv2colf10String.FieldName = "f10String"
        gv2colf11String.FieldName = "f11String"
        gv2colf12String.FieldName = "f12String"
        gv2colf13String.FieldName = "f13String"
        gv2colf14String.FieldName = "f14String"
        gv2colf15String.FieldName = "f15String"
        gv2colf16String.FieldName = "f16String"
        gv2colf17String.FieldName = "f17String"
        gv2colf18String.FieldName = "f18String"
        gv2colf19String.FieldName = "f19String"
        gv2colf20String.FieldName = "f20String"
        gv2colf21String.FieldName = "f21String"
        gv2colf22String.FieldName = "f22String"
        gv2colf23String.FieldName = "f23String"
        gv2colf24String.FieldName = "f24String"
        gv2colf25String.FieldName = "f25String"
        gv2colf26String.FieldName = "f26String"
        gv2colf27String.FieldName = "f27String"
        gv2colf28String.FieldName = "f28String"
        gv2colf29String.FieldName = "f29String"
        gv2colf30String.FieldName = "f30String"
        gv2colf01Memo.FieldName = "f01Memo"
        gv2colf02Memo.FieldName = "f02Memo"
        gv2colf03Memo.FieldName = "f03Memo"
        gv2colf04Memo.FieldName = "f04Memo"
        gv2colf05Memo.FieldName = "f05Memo"
        gv2colf01Int.FieldName = "f01Int"
        gv2colf02Int.FieldName = "f02Int"
        gv2colf03Int.FieldName = "f03Int"
        gv2colf04Int.FieldName = "f04Int"
        gv2colf05Int.FieldName = "f05Int"
        gv2colf06Int.FieldName = "f06Int"
        gv2colf07Int.FieldName = "f07Int"
        gv2colf01Double.FieldName = "f01Double"
        gv2colf02Double.FieldName = "f02Double"
        gv2colf03Double.FieldName = "f03Double"
        gv2colf04Double.FieldName = "f04Double"
        gv2colf05Double.FieldName = "f05Double"
        gv2colf06Double.FieldName = "f06Double"
        gv2colf07Double.FieldName = "f07Double"
        gv2colf01Date.FieldName = "f01Date"
        gv2colf02Date.FieldName = "f02Date"
        gv2colf03Date.FieldName = "f03Date"
        gv2colf04Date.FieldName = "f04Date"
        gv2colf05Date.FieldName = "f05Date"
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

        _rscolf01Double._02InitRepoDoubleMoney(3)
        _rscolf02Double._02InitRepoDoubleMoney(3)
        _rscolf03Double._02InitRepoDoubleMoney(3)
        _rscolf04Double._02InitRepoDoubleMoney(3)
        _rscolf05Double._02InitRepoDoubleMoney(3)
        _rscolf06Double._02InitRepoDoubleMoney(3)
        _rscolf07Double._02InitRepoDoubleMoney(3)

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

        _gv2cm02InitRepoColumn()
    End Sub

    Private Sub _gv2cm02InitRepoColumn()
        _rsgv2colk02Int._01InitRepoInteger()

        _rsgv2colf01Int._01InitRepoInteger()
        _rsgv2colf02Int._01InitRepoInteger()
        _rsgv2colf03Int._01InitRepoInteger()
        _rsgv2colf04Int._01InitRepoInteger()
        _rsgv2colf05Int._01InitRepoInteger()
        _rsgv2colf06Int._01InitRepoInteger()
        _rsgv2colf07Int._01InitRepoInteger()

        _rsgv2colf01Double._02InitRepoDoubleMoney(2)
        _rsgv2colf02Double._02InitRepoDoubleMoney(2)
        _rsgv2colf03Double._02InitRepoDoubleMoney(2)
        _rsgv2colf04Double._02InitRepoDoubleMoney(2)
        _rsgv2colf05Double._02InitRepoDoubleMoney(2)
        _rsgv2colf06Double._02InitRepoDoubleMoney(2)
        _rsgv2colf07Double._02InitRepoDoubleMoney(2)

        _rsgv2colf01Date._01InitRepoDate()
        _rsgv2colf02Date._01InitRepoDate()
        _rsgv2colf03Date._01InitRepoDate()
        _rsgv2colf04Date._01InitRepoDate()
        _rsgv2colf05Date._01InitRepoDate()

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

        _gv2cm03InitColumnEdit()
    End Sub

    Private Sub _gv2cm03InitColumnEdit()
        gv2colf01Int.ColumnEdit = _rsgv2colf01Int
        gv2colf02Int.ColumnEdit = _rsgv2colf02Int
        gv2colf03Int.ColumnEdit = _rsgv2colf03Int
        gv2colf04Int.ColumnEdit = _rsgv2colf04Int
        gv2colf05Int.ColumnEdit = _rsgv2colf05Int
        gv2colf06Int.ColumnEdit = _rsgv2colf06Int
        gv2colf07Int.ColumnEdit = _rsgv2colf07Int
        gv2colf01Double.ColumnEdit = _rsgv2colf01Double
        gv2colf02Double.ColumnEdit = _rsgv2colf02Double
        gv2colf03Double.ColumnEdit = _rsgv2colf03Double
        gv2colf04Double.ColumnEdit = _rsgv2colf04Double
        gv2colf05Double.ColumnEdit = _rsgv2colf05Double
        gv2colf06Double.ColumnEdit = _rsgv2colf06Double
        gv2colf07Double.ColumnEdit = _rsgv2colf07Double
        gv2colf01Date.ColumnEdit = _rsgv2colf01Date
        gv2colf02Date.ColumnEdit = _rsgv2colf02Date
        gv2colf03Date.ColumnEdit = _rsgv2colf03Date
        gv2colf04Date.ColumnEdit = _rsgv2colf04Date
        gv2colf05Date.ColumnEdit = _rsgv2colf05Date
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

        _gv2cm05SettingColumnSummary()
    End Sub

    Private Sub _gv2cm05SettingColumnSummary()
        _cm04InitGridSummaryItem(gv2colk02Int, "k02Int", "INT")
        _cm04InitGridSummaryItem(gv2colf01Int, "f01Int", "INT")
        _cm04InitGridSummaryItem(gv2colf02Int, "f02Int", "INT")
        _cm04InitGridSummaryItem(gv2colf03Int, "f03Int", "INT")
        _cm04InitGridSummaryItem(gv2colf04Int, "f04Int", "INT")
        _cm04InitGridSummaryItem(gv2colf05Int, "f05Int", "INT")
        _cm04InitGridSummaryItem(gv2colf06Int, "f06Int", "INT")
        _cm04InitGridSummaryItem(gv2colf07Int, "f07Int", "INT")
        _cm04InitGridSummaryItem(gv2colf01Double, "f01Double", "DBL")
        _cm04InitGridSummaryItem(gv2colf02Double, "f02Double", "DBL")
        _cm04InitGridSummaryItem(gv2colf03Double, "f03Double", "DBL")
        _cm04InitGridSummaryItem(gv2colf04Double, "f04Double", "DBL")
        _cm04InitGridSummaryItem(gv2colf05Double, "f05Double", "DBL")
        _cm04InitGridSummaryItem(gv2colf06Double, "f06Double", "DBL")
        _cm04InitGridSummaryItem(gv2colf07Double, "f07Double", "DBL")
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
        colf03Memo.Visible = False
        colf04Memo.Visible = False
        colf05Memo.Visible = False

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

        _gv2cm06InitVisibilityOFF()
    End Sub

    Private Sub _gv2cm06InitVisibilityOFF()
        gv2colk01String.Visible = False
        gv2colk02Int.Visible = False
        gv2colk03String.Visible = False
        gv2colk04String.Visible = False
        gv2colk05String.Visible = False

        gv2colf01String.Visible = False
        gv2colf02String.Visible = False
        gv2colf03String.Visible = False
        gv2colf04String.Visible = False
        gv2colf05String.Visible = False
        gv2colf06String.Visible = False
        gv2colf07String.Visible = False
        gv2colf08String.Visible = False
        gv2colf09String.Visible = False
        gv2colf10String.Visible = False
        gv2colf11String.Visible = False
        gv2colf12String.Visible = False
        gv2colf13String.Visible = False
        gv2colf14String.Visible = False
        gv2colf15String.Visible = False
        gv2colf16String.Visible = False
        gv2colf17String.Visible = False
        gv2colf18String.Visible = False
        gv2colf19String.Visible = False
        gv2colf20String.Visible = False
        gv2colf21String.Visible = False
        gv2colf22String.Visible = False
        gv2colf23String.Visible = False
        gv2colf24String.Visible = False
        gv2colf25String.Visible = False
        gv2colf26String.Visible = False
        gv2colf27String.Visible = False
        gv2colf28String.Visible = False
        gv2colf29String.Visible = False
        gv2colf30String.Visible = False

        gv2colf01Memo.Visible = False
        gv2colf02Memo.Visible = False
        gv2colf03Memo.Visible = False
        gv2colf04Memo.Visible = False
        gv2colf05Memo.Visible = False
        gv2colf01Int.Visible = False
        gv2colf02Int.Visible = False
        gv2colf03Int.Visible = False
        gv2colf04Int.Visible = False
        gv2colf05Int.Visible = False
        gv2colf06Int.Visible = False
        gv2colf07Int.Visible = False

        gv2colf01Double.Visible = False
        gv2colf02Double.Visible = False
        gv2colf03Double.Visible = False
        gv2colf04Double.Visible = False
        gv2colf05Double.Visible = False
        gv2colf06Double.Visible = False
        gv2colf07Double.Visible = False

        gv2colf01Date.Visible = False
        gv2colf02Date.Visible = False
        gv2colf03Date.Visible = False
        gv2colf04Date.Visible = False
        gv2colf05Date.Visible = False

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
        colf03Memo.VisibleIndex = -1
        colf04Memo.VisibleIndex = -1
        colf05Memo.VisibleIndex = -1

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

        _gv2cm07InitVisibilityIndexOFF()
    End Sub

    Private Sub _gv2cm07InitVisibilityIndexOFF()
        gv2colk01String.VisibleIndex = -1
        gv2colk02Int.VisibleIndex = -1
        gv2colk03String.VisibleIndex = -1
        gv2colk04String.VisibleIndex = -1
        gv2colk05String.VisibleIndex = -1

        gv2colf01String.VisibleIndex = -1
        gv2colf02String.VisibleIndex = -1
        gv2colf03String.VisibleIndex = -1
        gv2colf04String.VisibleIndex = -1
        gv2colf05String.VisibleIndex = -1
        gv2colf06String.VisibleIndex = -1
        gv2colf07String.VisibleIndex = -1
        gv2colf08String.VisibleIndex = -1
        gv2colf09String.VisibleIndex = -1
        gv2colf10String.VisibleIndex = -1
        gv2colf11String.VisibleIndex = -1
        gv2colf12String.VisibleIndex = -1
        gv2colf13String.VisibleIndex = -1
        gv2colf14String.VisibleIndex = -1
        gv2colf15String.VisibleIndex = -1
        gv2colf16String.VisibleIndex = -1
        gv2colf17String.VisibleIndex = -1
        gv2colf18String.VisibleIndex = -1
        gv2colf19String.VisibleIndex = -1
        gv2colf20String.VisibleIndex = -1
        gv2colf21String.VisibleIndex = -1
        gv2colf22String.VisibleIndex = -1
        gv2colf23String.VisibleIndex = -1
        gv2colf24String.VisibleIndex = -1
        gv2colf25String.VisibleIndex = -1
        gv2colf26String.VisibleIndex = -1
        gv2colf27String.VisibleIndex = -1
        gv2colf28String.VisibleIndex = -1
        gv2colf29String.VisibleIndex = -1
        gv2colf30String.VisibleIndex = -1

        gv2colf01Memo.VisibleIndex = -1
        gv2colf02Memo.VisibleIndex = -1
        gv2colf03Memo.VisibleIndex = -1
        gv2colf04Memo.VisibleIndex = -1
        gv2colf05Memo.VisibleIndex = -1
        gv2colf01Int.VisibleIndex = -1
        gv2colf02Int.VisibleIndex = -1
        gv2colf03Int.VisibleIndex = -1
        gv2colf04Int.VisibleIndex = -1
        gv2colf05Int.VisibleIndex = -1
        gv2colf06Int.VisibleIndex = -1
        gv2colf07Int.VisibleIndex = -1

        gv2colf01Double.VisibleIndex = -1
        gv2colf02Double.VisibleIndex = -1
        gv2colf03Double.VisibleIndex = -1
        gv2colf04Double.VisibleIndex = -1
        gv2colf05Double.VisibleIndex = -1
        gv2colf06Double.VisibleIndex = -1
        gv2colf07Double.VisibleIndex = -1

        gv2colf01Date.VisibleIndex = -1
        gv2colf02Date.VisibleIndex = -1
        gv2colf03Date.VisibleIndex = -1
        gv2colf04Date.VisibleIndex = -1
        gv2colf05Date.VisibleIndex = -1

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
        colf03Memo.OptionsColumn.ReadOnly = True
        colf04Memo.OptionsColumn.ReadOnly = True
        colf05Memo.OptionsColumn.ReadOnly = True

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

        _gv2cm08ReadOnlyGrid()
    End Sub

    Private Sub _gv2cm08ReadOnlyGrid()
        gv2colk01String.OptionsColumn.ReadOnly = True
        gv2colk02Int.OptionsColumn.ReadOnly = True
        gv2colk03String.OptionsColumn.ReadOnly = True
        gv2colk04String.OptionsColumn.ReadOnly = True
        gv2colk05String.OptionsColumn.ReadOnly = True

        gv2colf01String.OptionsColumn.ReadOnly = True
        gv2colf02String.OptionsColumn.ReadOnly = True
        gv2colf03String.OptionsColumn.ReadOnly = True
        gv2colf04String.OptionsColumn.ReadOnly = True
        gv2colf05String.OptionsColumn.ReadOnly = True
        gv2colf06String.OptionsColumn.ReadOnly = True
        gv2colf07String.OptionsColumn.ReadOnly = True
        gv2colf08String.OptionsColumn.ReadOnly = True
        gv2colf09String.OptionsColumn.ReadOnly = True
        gv2colf10String.OptionsColumn.ReadOnly = True
        gv2colf11String.OptionsColumn.ReadOnly = True
        gv2colf12String.OptionsColumn.ReadOnly = True
        gv2colf13String.OptionsColumn.ReadOnly = True
        gv2colf14String.OptionsColumn.ReadOnly = True
        gv2colf15String.OptionsColumn.ReadOnly = True
        gv2colf16String.OptionsColumn.ReadOnly = True
        gv2colf17String.OptionsColumn.ReadOnly = True
        gv2colf18String.OptionsColumn.ReadOnly = True
        gv2colf19String.OptionsColumn.ReadOnly = True
        gv2colf20String.OptionsColumn.ReadOnly = True
        gv2colf21String.OptionsColumn.ReadOnly = True
        gv2colf22String.OptionsColumn.ReadOnly = True
        gv2colf23String.OptionsColumn.ReadOnly = True
        gv2colf24String.OptionsColumn.ReadOnly = True
        gv2colf25String.OptionsColumn.ReadOnly = True
        gv2colf26String.OptionsColumn.ReadOnly = True
        gv2colf27String.OptionsColumn.ReadOnly = True
        gv2colf28String.OptionsColumn.ReadOnly = True
        gv2colf29String.OptionsColumn.ReadOnly = True
        gv2colf30String.OptionsColumn.ReadOnly = True

        gv2colf01Memo.OptionsColumn.ReadOnly = True
        gv2colf02Memo.OptionsColumn.ReadOnly = True
        gv2colf03Memo.OptionsColumn.ReadOnly = True
        gv2colf04Memo.OptionsColumn.ReadOnly = True
        gv2colf05Memo.OptionsColumn.ReadOnly = True
        gv2colf01Int.OptionsColumn.ReadOnly = True
        gv2colf02Int.OptionsColumn.ReadOnly = True
        gv2colf03Int.OptionsColumn.ReadOnly = True
        gv2colf04Int.OptionsColumn.ReadOnly = True
        gv2colf05Int.OptionsColumn.ReadOnly = True
        gv2colf06Int.OptionsColumn.ReadOnly = True
        gv2colf07Int.OptionsColumn.ReadOnly = True

        gv2colf01Double.OptionsColumn.ReadOnly = True
        gv2colf02Double.OptionsColumn.ReadOnly = True
        gv2colf03Double.OptionsColumn.ReadOnly = True
        gv2colf04Double.OptionsColumn.ReadOnly = True
        gv2colf05Double.OptionsColumn.ReadOnly = True
        gv2colf06Double.OptionsColumn.ReadOnly = True
        gv2colf07Double.OptionsColumn.ReadOnly = True

        gv2colf01Date.OptionsColumn.ReadOnly = True
        gv2colf02Date.OptionsColumn.ReadOnly = True
        gv2colf03Date.OptionsColumn.ReadOnly = True
        gv2colf04Date.OptionsColumn.ReadOnly = True
        gv2colf05Date.OptionsColumn.ReadOnly = True

    End Sub

    Private Sub _cm09PropertiesGridONTarget()
        'OFF
        _cm06InitVisibilityOFF()
        _cm07InitVisibilityIndexOFF()

        'ON
        _mp01SettingRepoColoumn()
        _mp02SettingVisibilityON()
        _mp03SettingColumnCaption()
        _mp04SettingWriteColumn()
    End Sub

    Private Function _cm10GetBeratChild(ByVal prmcProductCodeParent As String) As Double
        Dim pnBeratChild As Double = 0.0
        For Each dtRow As DataRow In _dataset.Tables("ParentTable").Rows
            If dtRow("k04String").ToString = prmcProductCodeParent Then
                Dim childRows As DataRow()

                childRows = dtRow.GetChildRows(_pcNamaRelasiParentChild)
                For Each dtRowChild As DataRow In childRows
                    pnBeratChild = CDbl(dtRowChild("f01Double"))    'gv2colf01Double.Caption = "Berat/Unit"
                Next

            End If
        Next

        Return pnBeratChild
    End Function

#End Region

#Region "public - method"

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

    Public Function _pb03DisplayGridTransaction() As DataSet
        _cm09PropertiesGridONTarget()

        _pcNamaRelasiParentChild = ""
        Dim objDataSet As New DataSet

        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BZ01PRODUCTIONORDER
                _pcNamaRelasiParentChild = "PRODUCT ORDER"
                objDataSet = _gd001DisplayProductionOrder()

            Case TargetTransaksi._02FA23GU01SETTLEMENTAR
                _pcNamaRelasiParentChild = "PROFORMA"
                objDataSet = _gdFA64SettlementARDisplay()

            Case TargetTransaksi._03FA23HH01BILLING
                _pcNamaRelasiParentChild = "DETAILFAKTUR"
                objDataSet = _gdFA61BillingDisplay()

            Case Else
        End Select

        GridView1.OptionsView.ColumnAutoWidth = False
        GridView2.OptionsView.ColumnAutoWidth = False

        GridView1.BestFitColumns()
        GridView2.BestFitColumns()

        Return objDataSet
    End Function

    Public Function _pb04SaveTransaction() As Int16
        Dim pnHasil As Int16 = 0

        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BZ01PRODUCTIONORDER
                pnHasil = _gd002SaveProductionOrder()

            Case TargetTransaksi._02FA23GU01SETTLEMENTAR

            Case Else

        End Select

        Return pnHasil
    End Function

    Public Function _pb05FASettlementARTotalBerat() As Double
        Return CDbl(colf03Double.SummaryItem.SummaryValue)
    End Function

    Public Async Function _pb06FAGetDataSettlementARForSave() As Task(Of DataTable)
        Dim pdtKey As New DataTable
        Dim _prmKey As clsTEMPLATEKEY = New clsTEMPLATEKEY With {.prop_dtKEYGEMINI = pdtKey}
        _prmKey.dtInitKEYGEMINI()

        If GridView1.RowCount > 0 Then
            For i = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "k00Boolean") = True Then
                    _prmKey.dtAddNewKEYGEMINI(CStr(GridView1.GetRowCellValue(i, "f30String")),
                                              CStr(GridView1.GetRowCellValue(i, "k03String")),
                                              CStr(GridView1.GetRowCellValue(i, "f01String")), "", "")
                End If
            Next

            Using objFinHelp As New clsFinanceHelper
                Return Await objFinHelp._pFACore11SPSQLExecDirectToDataTable_Async(
                                _prop01User._UserProp07TargetNetwork, clsNasaHelper._pnmDatabaseName.SBU,
                                "sp64GetDataForSaveSettlementAR", "@tpKEY", _prmKey.prop_dtKEYGEMINI)
            End Using
        Else
            Return Nothing
        End If

    End Function

#End Region

#Region "********** method private - UPDATE/CHANGE **********"

    Public Enum TargetTransaksi
        _01MD23BZ01PRODUCTIONORDER = 0
        _02FA23GU01SETTLEMENTAR = 1
        _03FA23HH01BILLING = 2
    End Enum

    Private Sub _mp01SettingRepoColoumn()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BZ01PRODUCTIONORDER

            Case Else

        End Select
    End Sub

    Private Sub _mp02SettingVisibilityON()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BZ01PRODUCTIONORDER
                _vs01VisibilityCol51MDProductionOrder()
                _vs02VisibilityIndex51MDProductionOrder()

            Case TargetTransaksi._02FA23GU01SETTLEMENTAR
                _vs64FASettlementARVisibility()
                _vs64FASettlementARVisibilityIndex()

            Case TargetTransaksi._03FA23HH01BILLING
                _cc01Visibility61Billing()
                _cc01VisibilityIndex61Billing()

            Case Else

        End Select
    End Sub

    Private Sub _mp03SettingColumnCaption()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BZ01PRODUCTIONORDER
                _cc01CaptionCol51MDProductionOrder()
                _ll01LainLain51MDProductionOrder()

            Case TargetTransaksi._02FA23GU01SETTLEMENTAR
                _cc64FASettlementARCaptionCol()

            Case TargetTransaksi._03FA23HH01BILLING
                _cc01CaptionCol61Billing()

            Case Else
        End Select
    End Sub

    Private Sub _mp04SettingWriteColumn()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BZ01PRODUCTIONORDER
                _wr01WriteCol51MDProductionOrder()
                _tot01TotBeratDanLot51MDProductionOrder()

            Case TargetTransaksi._02FA23GU01SETTLEMENTAR
                _wr64FASettlementARWriteCol()
                _tot64FASettlementARTotBeratPcs()

            Case TargetTransaksi._03FA23HH01BILLING
                _cc01TotBeratRupiah61Billing()
                _cc01SettingLain61Billing()

            Case Else
        End Select
    End Sub

#End Region

#Region "********** method private - UPDATE/CHANGE ==> form : ucMD23BZ01PRODUCTIONORDER **********"
    Private _rscolf02Memo As repoGEMINIPicture

    Private Sub _rsRepoMaster51MDProductionOrder()
        '*** f02Memo = Picture ***

        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsView.RowAutoHeight = True
        GridView1.BestFitColumns()

        _rscolf02Memo = New repoGEMINIPicture()
        colf02Memo.ColumnEdit = _rscolf02Memo
    End Sub

    Private Sub _cc01CaptionCol51MDProductionOrder()
        colf02Int.Tag = 100
        colf03Double.Tag = 101

        'Parent
        colk04String.Caption = "ProductCode"
        colk05String.Caption = "No. Order"
        colf01String.Caption = "KodeBrand"
        colf02String.Caption = "Brand"
        colf03String.Caption = "KodeItem"
        colf04String.Caption = "Item"
        colf05String.Caption = "KodeWarnaBRJ"
        colf06String.Caption = "WarnaBRJ"
        colf07String.Caption = "KodeKadar"
        colf08String.Caption = "Kadar"
        colf09String.Caption = "KodeSize"
        colf10String.Caption = "Size"
        colf11String.Caption = "KodeProject"
        colf12String.Caption = "Project"
        colf13String.Caption = "KodeWarnaMaterial"
        colf14String.Caption = "WarnaMaterial"
        colf21String.Caption = "PO.JIMS"
        colf23String.Caption = "PO.CMK"
        'colf24String.Caption = "TipeProd"
        'colf27String.Caption = "KodeTipeProduksi"

        'colf25String.Caption = "SubTipeProd"
        'colf28String.Caption = "KodeSubTipeProduksi"
        colf26String.Caption = "Customer"
        colf29String.Caption = "KodeCustomer"
        'colf03Memo.Caption = "Remarks Sales"
        'colf04Memo.Caption = "Remarks MD"
        'colf05Memo.Caption = "Grafir"

        colf01Int.Caption = "QtyOrder"
        colf02Double.Caption = "TotBeratOrder"
        colf02Int.Caption = "QtyPO"
        colf03Double.Caption = "TotBeratPO"
        colf02Date.Caption = "ETA"  'Estimated Time of Arrival

        'Child
        gv2colf03Memo.Caption = "Remarks Sales"
        gv2colf04Memo.Caption = "Remarks MD"
        gv2colf05Memo.Caption = "Grafir"
        gv2colf24String.Caption = "TipeProd"
        gv2colf25String.Caption = "SubTipeProd"
        'gv2colf29String.Caption = "KodeCustomer"
        'gv2colf01Int.Caption = "Qty"
        'gv2colf01Double.Caption = "Berat/Unit"
        'gv2colf02Double.Caption = "TotBerat"
        'gv2colf01Date.Caption = "Entry"
        'gv2colf02Date.Caption = "ETA"  'Estimated Time of Arrival
    End Sub

    Private Sub _ll01LainLain51MDProductionOrder()
        With colf02Int              '"QtyPO"
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n0}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightYellow
        End With

        With colf03Double              '"TotBeratPO"
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n2}"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightYellow
        End With

        With colf02Date              '"ETA"
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.DateTime
                .FormatString = "d"
            End With
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightYellow
        End With
    End Sub

    Private Sub _vs01VisibilityCol51MDProductionOrder()
        'Parent
        colk04String.Visible = True   '"ProductCode"
        colk05String.Visible = True   '"ProductCode"
        colf01String.Visible = False   '"KodeBrand"
        colf02String.Visible = True   '"Brand"
        colf03String.Visible = False   '"KodeItem"
        colf04String.Visible = True   '"Item"
        colf05String.Visible = False   '"KodeWarnaBRJ"
        colf06String.Visible = True   '"WarnaBRJ"
        colf07String.Visible = False   '"KodeKadar"
        colf08String.Visible = True   '"Kadar"
        colf09String.Visible = False   '"KodeSize"
        colf10String.Visible = True   '"Size"
        colf11String.Visible = False   '"KodeProject"
        colf12String.Visible = True   '"Project"
        colf13String.Visible = False   '"KodeWarnaMaterial"
        colf14String.Visible = True   '"WarnaMaterial"
        colf21String.Visible = True   '"PO. JIMS"
        colf23String.Visible = True   '"PO.CMK"
        'colf24String.Visible = True   '"TipeProduksi"
        'colf27String.Visible = False   '"KodeTipeProduksi"

        'colf25String.Visible = True   '"SubTipeProd"
        'colf28String.Visible = False   '"KodeSubTipeProduksi"
        colf26String.Visible = True   '"Customer"
        colf29String.Visible = False   '"KodeCustomer"

        colf01Int.Visible = True   '"QtyOrder"
        colf02Int.Visible = True   '"TotBeratOrder"
        colf02Double.Visible = True   '"QtyPO"
        colf03Double.Visible = True   '"TotBeratPO"
        colf02Date.Visible = True

        'colf03Memo.Visible = True   '"Remarks Sales"
        'colf04Memo.Visible = True   '"Remarks MD"
        'colf05Memo.Visible = True   '"Grafir"

        'Child
        gv2colf03Memo.Visible = True   ' "Remarks Sales"
        gv2colf04Memo.Visible = True   ' "Remarks MD"
        gv2colf05Memo.Visible = True   ' "Grafir"
        gv2colf24String.Visible = True   ' "TipeProd"
        gv2colf25String.Visible = True   ' "SubTipeProd"
        'gv2colf01Int.Visible = True   '"Qty"
        'gv2colf01Double.Visible = True   '"Berat/Unit"
        'gv2colf02Double.Visible = True   '"TotBerat"
        'gv2colf01Date.Visible = True
        'gv2colf02Date.Visible = True
    End Sub

    Private Sub _vs02VisibilityIndex51MDProductionOrder()
        'Parent
        colk04String.VisibleIndex = 0   '"ProductCode"
        colk05String.VisibleIndex = 1   '"ProductCode"
        colf26String.VisibleIndex = 2   '"Customer"
        colf21String.VisibleIndex = 3   '"PO. JIMS"
        colf23String.VisibleIndex = 4   '"PO.CMK"
        colf01Int.VisibleIndex = 5      '"QtyOrder"
        colf02Double.VisibleIndex = 6  '"TotBeratOrder"

        colf02Int.VisibleIndex = 7      '"QtyPO"
        colf03Double.VisibleIndex = 8   '"TotBeratPO"
        colf02Date.VisibleIndex = 9

        'colf05Memo.VisibleIndex = 10   '"Grafir"

        colf02String.VisibleIndex = 10   '"Brand"
        colf04String.VisibleIndex = 11   '"Item"
        colf06String.VisibleIndex = 12   '"WarnaBRJ"
        colf08String.VisibleIndex = 13  '"Kadar"
        colf10String.VisibleIndex = 14   '"Size"
        colf12String.VisibleIndex = 15   '"Project"
        colf14String.VisibleIndex = 16   '"WarnaMaterial"
        'colf24String.VisibleIndex = 18   '"TipeProduksi"
        'colf25String.VisibleIndex = 19   '"SubTipeProd"
        'colf03Memo.VisibleIndex = 20   '"Remarks Sales"
        'colf04Memo.VisibleIndex = 21   '"Remarks MD"

        colf01String.VisibleIndex = -1   '"KodeBrand"
        colf03String.VisibleIndex = -1   '"KodeItem"
        colf05String.VisibleIndex = -1   '"KodeWarnaBRJ"
        colf07String.VisibleIndex = -1   '"KodeKadar"
        colf09String.VisibleIndex = -1   '"KodeSize"
        colf11String.VisibleIndex = -1   '"KodeProject"
        colf13String.VisibleIndex = -1   '"KodeWarnaMaterial"
        colf27String.VisibleIndex = -1   '"KodeTipeProduksi"
        colf28String.VisibleIndex = -1   '"KodeSubTipeProduksi"
        colf29String.VisibleIndex = -1   '"KodeCustomer"

        'Child
        gv2colf24String.VisibleIndex = 0  ' "TipeProd"
        gv2colf25String.VisibleIndex = 1  ' "SubTipeProd"
        gv2colf03Memo.VisibleIndex = 2   ' "Remarks Sales"
        gv2colf04Memo.VisibleIndex = 3  ' "Remarks MD"
        gv2colf05Memo.VisibleIndex = 4  ' "Grafir"

        'gv2colf01Int.VisibleIndex = 5   '"Qty"
        'gv2colf01Double.VisibleIndex = 6   '"Berat/Unit"
        'gv2colf02Double.VisibleIndex = 7   '"TotBerat"
        'gv2colf01Date.VisibleIndex = 8
        'gv2colf02Date.VisibleIndex = 9

        'gv2colf27String.VisibleIndex = -1   '"KodeTipeProd"
        'gv2colf28String.VisibleIndex = -1   '"KodeSubTipeProd"
        'gv2colf29String.VisibleIndex = -1   '"KodeCustomer"

    End Sub

    Private Sub _wr01WriteCol51MDProductionOrder()
        'Parent
        colf02Int.OptionsColumn.ReadOnly = False
        colf03Double.OptionsColumn.ReadOnly = False
        colf02Date.OptionsColumn.ReadOnly = False
    End Sub

    Private Sub _tot01TotBeratDanLot51MDProductionOrder()
        'Parent
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"

        GridView1.Columns("f02Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        GridView1.Columns("f02Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f02Int").SummaryItem.DisplayFormat = "{0:n0}"
        GridView1.Columns("f02Int").SummaryItem.Tag = 100

        GridView1.Columns("f03Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        GridView1.Columns("f03Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f03Double").SummaryItem.DisplayFormat = "{0:n2}"
        GridView1.Columns("f03Double").SummaryItem.Tag = 101

        colk04String.Fixed = FixedStyle.Left
        colk05String.Fixed = FixedStyle.Left

        'Child
        GridView2.OptionsView.ShowFooter = True

        GridView2.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView2.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"

        GridView2.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView2.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"
    End Sub

    Private Function _gd001DisplayProductionOrder() As DataSet
        _dataset.Clear()
        _dataset.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Const consFieldnTarget As String = "@tpParamSQLSelect"
        Const consNamaSP As String = "spMD51PRODUCTIONORDERSele"

        Dim objParamParent As clsNasaSelectParamDataCollection
        objParamParent = New clsNasaSelectParamDataCollection

        Dim objParamChild As clsNasaSelectParamDataCollection
        objParamChild = New clsNasaSelectParamDataCollection

        Dim objConnSBU As New clsNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnSBU._cm03NasaConnectionDBSBU(_prop01User._UserProp07TargetNetwork))

            objConn.Open()

            objParamParent._01AddNew(1, 0, 0, _prop10String, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
                objCommand.Parameters.AddWithValue(consFieldnTarget, objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dataset, "ParentTable")
            End Using

            objParamChild._01AddNew(2, 0, 0, _prop10String, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
                objCommand.Parameters.AddWithValue(consFieldnTarget, objParamChild).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dataset, "ChildTable")
            End Using

            Dim Parent_col As DataColumn()
            Dim Child_col As DataColumn()

            Parent_col = New DataColumn() {
                _dataset.Tables("ParentTable").Columns("k04String"),
            _dataset.Tables("ParentTable").Columns("k05String")}

            Child_col = New DataColumn() {
                _dataset.Tables("ChildTable").Columns("k04String"),
            _dataset.Tables("ChildTable").Columns("k05String")}

            Dim objDataRelation As DataRelation = New DataRelation(_pcNamaRelasiParentChild, Parent_col, Child_col, False)

            _dataset.Relations.Add(objDataRelation)

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _dataset.Tables("ParentTable")

            GridView2.OptionsView.ColumnAutoWidth = True

            With GridControl1.LevelTree.Nodes
                .Add(_pcNamaRelasiParentChild, GridView2)
            End With

            GridView2.BestFitColumns()

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChild.Dispose()

        Return _dataset
    End Function

    Private Function _gd002GetNoProductionOrder() As String
        Dim objMaster As New clsGetDataMasterGEMINI()
        Dim pcNumberPOMD As String = objMaster._pb03IncNumberMaster(_prop01User._UserProp07TargetNetwork, "MNPOMD", "cNOMORDOKUMEN")

        Return pcNumberPOMD
    End Function

    Private Function _gd002GetNoPOMDPPIC(ByVal prmnQtyRec As Integer) As DataTable
        Dim pdHasil As New DataTable

        Dim objMaster As New clsGetDataMasterGEMINI()
        pdHasil = objMaster._pb03IncNumberMasterReqQty(_prop01User._UserProp07TargetNetwork, "MNPPICPOMD", prmnQtyRec)

        Return pdHasil
    End Function

    Private Function _gd002SaveProductionOrder() As Integer
        Dim pcNoPOMD As String = _gd002GetNoProductionOrder()

        Dim pdTablePO As New DataTable
        Dim objPOGEMINI As New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdTablePO}
        objPOGEMINI.dtInitTABLEGEMINI()

        Dim pdTableChild As New DataTable
        Dim objChild As New clsTEMPLATEKEY With {.prop_dtKEYGEMINI = pdTableChild}
        objChild.dtInitKEYGEMINI()

        Dim table As DataTable = _dataset.Tables("ParentTable")
        Dim childRows As DataRow()

        Dim pcPOJIMS As String = ""
        Dim pcPOCMK As String = ""
        Dim pcMemo01 As String = ""
        Dim pcMemo02 As String = ""
        Dim pcMemo03 As String = ""

        For Each relation As DataRelation In table.ChildRelations
            For Each row As DataRow In table.Rows
                If row("f02Int") > 0 And Year(row("f02Date")) < 3000 Then
                    pcPOJIMS = "" : pcPOCMK = ""
                    pcMemo01 = "" : pcMemo02 = "" : pcMemo03 = ""

                    pcPOJIMS = If(String.IsNullOrEmpty(row("f21String").ToString), String.Empty, row("f21String"))
                    pcPOCMK = If(String.IsNullOrEmpty(row("f23String").ToString), String.Empty, row("f23String"))
                    pcMemo01 = If(String.IsNullOrEmpty(row("f03Memo").ToString), "", row("f03Memo"))
                    pcMemo02 = If(String.IsNullOrEmpty(row("f04Memo").ToString), "", row("f04Memo"))
                    pcMemo03 = If(String.IsNullOrEmpty(row("f05Memo").ToString), "", row("f05Memo"))

                    objPOGEMINI.dtAddNewTABLEGEMINI("", 0, row("k05String").ToString, row("k04String").ToString, pcNoPOMD,
                                                    row("f01String").ToString, row("f02String").ToString, row("f03String").ToString, row("f04String").ToString, row("f05String").ToString,
                                                    row("f06String").ToString, row("f07String").ToString, row("f08String").ToString, row("f09String").ToString, row("f10String").ToString,
                                                    row("f11String").ToString, row("f12String").ToString, row("f13String").ToString, row("f14String").ToString, row("f24String").ToString,
                                                    row("f27String").ToString, row("f25String").ToString, row("f28String").ToString, row("f26String").ToString, row("f29String").ToString,
                                                    pcPOJIMS, "OST", pcPOCMK, "", "",
                                                    "", "", "", "", "",
                                                    "", pcMemo01, pcMemo02, pcMemo03,
                                                    row("f01Int"), row("f02Int"), 0, 0, 0, 0, 0,
                                                    row("f02Double"), row("f03Double"), 0.0, 0.0, 0.0, 0.0, 0.0,
                                                    Today.Date, row("f02Date"), "3000-01-01", "3000-01-01", "3000-01-01",
                                                    Today.Date, "3000-01-01",
                                                    _prop01User._UserProp02cUserID, "",
                                                    _prop01User._UserProp03cUserName, "")

                    childRows = row.GetChildRows(relation)
                    For Each dtitem As Object In childRows
                        objChild.dtAddNewKEYGEMINI(dtitem("k01String"), pcNoPOMD, "", "", "")
                    Next
                End If
            Next
        Next

        Dim pnJmlRecAffect As Int16 = 0
        If objPOGEMINI.prop_dtTABLEGEMINI.Rows.Count > 0 Then

            Dim pdtHasil As New DataTable
            'Generate POMD to PPIC
            pdtHasil = _gd002GetNoPOMDPPIC(objPOGEMINI.prop_dtTABLEGEMINI.Rows.Count)
            If pdtHasil.Rows.Count > 0 Then
                Cursor.Current = Cursors.WaitCursor

                Dim pnNoAkhir As Integer = 0
                Dim pcFormatNoDoc As String = ""

                For Each dtRow As DataRow In pdtHasil.Rows
                    pcFormatNoDoc = dtRow("f01cParamString")
                    pnNoAkhir = dtRow("f01nTargetSPParent_int")
                Next
                Dim pnNoAwal As Integer = (pnNoAkhir - objPOGEMINI.prop_dtTABLEGEMINI.Rows.Count)

                For Each dtRow As DataRow In objPOGEMINI.prop_dtTABLEGEMINI.Rows
                    pnNoAwal = pnNoAwal + 1  ' HARUS increment dahulu...

                    dtRow("f25String") = pcFormatNoDoc & String.Format("{0:00000}", pnNoAwal)
                Next
                objPOGEMINI.prop_dtTABLEGEMINI.AcceptChanges()

                pnJmlRecAffect = objProses._tr01NasaExecDirectAllDB(_prop01User._UserProp07TargetNetwork,
                                                                _pnmDatabaseName.SBU,
                                                                2, "spTABLE51Save",
                                                                "@tpTEMPLATEGEMINI", objPOGEMINI.prop_dtTABLEGEMINI,
                                                                "@tpADDITIONAL", objChild.prop_dtKEYGEMINI)

                Cursor.Current = Cursors.Default
            Else
                MsgBox("Simpan Data ... DIBATALKAN ... " & Chr(13) & "Sebab GAGAL CREATE NO.DOC PPIC PO.MD.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, _prop01User._UserProp01cTitle)
            End If
        End If

        Return pnJmlRecAffect
    End Function

#End Region

#Region "********** method private - CREATE ==> form : ucFA23GU01SETTLEMENTAR **********"
    Private Sub _cc64FASettlementARCaptionCol()
        'PARENT
        'colk00Boolean.Caption = "#"
        colf30String.Caption = "Asal"
        colk03String.Caption = "NoDocument"
        colf03String.Caption = "TOP"
        colf04String.Caption = "Brand"
        colf05String.Caption = "Colour"
        colf01Int.Caption = "Kadar"
        colf02Date.Caption = "Tgl.JT"
        colf02Int.Caption = "Pcs.CMK"
        colf03Int.Caption = "Pcs.SKK"
        colf01Double.Caption = "Tot.Berat"
        colf02Double.Caption = "BeratCMK"
        colf03Double.Caption = "BeratSKK"

        'CHILD
        gv2colf08String.Caption = "NoProforma"
        gv2colk03String.Caption = "NoFaktur"
        gv2colk04String.Caption = "CO/PO"
        gv2colk05String.Caption = "SJ"
        gv2colf11String.Caption = "Rek.HargaEmas"
        gv2colf05Int.Caption = "HargaEmas"
        gv2colf02Int.Caption = "Pcs.CMK"
        gv2colf02Double.Caption = "Berat.CMK"
        gv2colf03Int.Caption = "Pcs.SKK"
        gv2colf03Double.Caption = "Berat.SKK"
        gv2colf01Double.Caption = "TotBerat"
    End Sub

    Private Sub _vs64FASettlementARVisibility()
        'PARENT
        'colk00Boolean.Visible = True   '"#"    
        colf30String.Visible = True   '"Asal"
        colk03String.Visible = True   '"NoDocument"                                                                                   
        colf03String.Visible = True   '"TOP"                                          
        colf04String.Visible = True   '"Brand"                                          
        colf05String.Visible = True   '"Colour"                                          
        colf01Int.Visible = True   '"Kadar"                                    
        colf02Date.Visible = True   '"Tgl.JT"    
        colf02Int.Visible = True   '"Pcs.CMK"      
        colf03Int.Visible = True   '"Pcs.SKK"      
        colf01Double.Visible = True   '"Tot.Berat"                               
        colf02Double.Visible = True   '"BeratCMK"                               
        colf03Double.Visible = True   '"BeratSKK"                               

        'CHILD
        gv2colf08String.Visible = True   '"NoProforma"
        gv2colk03String.Visible = True   '"NoFaktur"
        gv2colk04String.Visible = True   '"CO/PO"
        gv2colk05String.Visible = True   '"SJ"
        gv2colf11String.Visible = True   '"Rek.HargaEmas"
        gv2colf05Int.Visible = True   '"HargaEmas"
        gv2colf02Int.Visible = True   '"Pcs.CMK"
        gv2colf02Double.Visible = True   '"Berat.CMK"
        gv2colf03Int.Visible = True   '"Pcs.SKK"
        gv2colf03Double.Visible = True   '"Berat.SKK"
        gv2colf01Double.Visible = True   '"TotBerat"

    End Sub

    Private Sub _vs64FASettlementARVisibilityIndex()
        'PARENT
        'colk00Boolean.VisibleIndex = 0   '"#"     
        colf30String.VisibleIndex = 1   '"Asal"
        colk03String.VisibleIndex = 2   '"NoDocument"                                                                                  
        colf03String.VisibleIndex = 3  '"TOP"                                          
        colf04String.VisibleIndex = 4   '"Brand"                                          
        colf05String.VisibleIndex = 5   '"Colour"                                          
        colf01Int.VisibleIndex = 6   '"Kadar"                                    
        colf02Int.VisibleIndex = 7   '"Pcs.CMK"      
        colf02Double.VisibleIndex = 8   '"BeratCMK"
        colf03Int.VisibleIndex = 9   '"Pcs.SKK"   
        colf03Double.VisibleIndex = 10   '"BeratSKK"
        colf01Double.VisibleIndex = 11   '"Tot.Berat" 
        colf02Date.VisibleIndex = 12   '"Tgl.JT" 

        'CHILD
        gv2colf08String.VisibleIndex = 0   '"NoProforma"
        gv2colk03String.VisibleIndex = 1   '"NoFaktur"
        gv2colk04String.VisibleIndex = 2   '"CO/PO"
        gv2colk05String.VisibleIndex = 3   '"SJ"
        gv2colf11String.VisibleIndex = 4   '"Rek.HargaEmas"
        gv2colf05Int.VisibleIndex = 5   '"HargaEmas"
        gv2colf02Int.VisibleIndex = 6   '"Pcs.CMK"
        gv2colf02Double.VisibleIndex = 7   '"Berat.CMK"
        gv2colf03Int.VisibleIndex = 8   '"Pcs.SKK"
        gv2colf03Double.VisibleIndex = 9   '"Berat.SKK"
        gv2colf01Double.VisibleIndex = 10   '"TotBerat"
    End Sub

    Private Sub _wr64FASettlementARWriteCol()
        'Parent
        'colk00Boolean.OptionsColumn.ReadOnly = False
    End Sub

    Private Sub _tot64FASettlementARTotBeratPcs()
        'PARENT
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f02Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        GridView1.Columns("f02Int").SummaryItem.FieldName = "f02Int"
        GridView1.Columns("f02Int").SummaryItem.DisplayFormat = "{0:n0}"
        GridView1.Columns("f02Int").SummaryItem.Tag = 20

        GridView1.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
        GridView1.Columns("f02Double").SummaryItem.Tag = 21

        GridView1.Columns("f03Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        GridView1.Columns("f03Int").SummaryItem.FieldName = "f03Int"
        GridView1.Columns("f03Int").SummaryItem.DisplayFormat = "{0:n0}"
        GridView1.Columns("f03Int").SummaryItem.Tag = 22

        GridView1.Columns("f03Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        GridView1.Columns("f03Double").SummaryItem.FieldName = "f03Double"
        GridView1.Columns("f03Double").SummaryItem.DisplayFormat = "{0:n2}"
        GridView1.Columns("f03Double").SummaryItem.Tag = 23

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
        GridView1.Columns("f01Double").SummaryItem.Tag = 24

        'CHILD
        GridView2.OptionsView.ShowFooter = True

        GridView2.Columns("f02Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f02Int").SummaryItem.FieldName = "f02Int"
        GridView2.Columns("f02Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView2.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView2.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"

        GridView2.Columns("f03Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f03Int").SummaryItem.FieldName = "f03Int"
        GridView2.Columns("f03Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView2.Columns("f03Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f03Double").SummaryItem.FieldName = "f03Double"
        GridView2.Columns("f03Double").SummaryItem.DisplayFormat = "{0:n2}"

        GridView2.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView2.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
    End Sub

    Private Function _gdFA64SettlementARDisplay() As DataSet
        _dataset.Clear()
        _dataset.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Const consFieldnTarget As String = "@tpParamSQLSelect"
        Const consNamaSP As String = "spFA60TRANSACTION"

        Dim objParamParent As clsNasaSelectParamDataCollection
        objParamParent = New clsNasaSelectParamDataCollection

        Dim objParamChild As clsNasaSelectParamDataCollection
        objParamChild = New clsNasaSelectParamDataCollection

        Dim objConnSBU As New clsNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnSBU._cm03NasaConnectionDBSBU(_prop01User._UserProp07TargetNetwork))

            objConn.Open()

            objParamParent._01AddNew(60, 2, 3, _prop10String, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
                objCommand.Parameters.AddWithValue(consFieldnTarget, objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dataset, "ParentTable")
            End Using

            objParamChild._01AddNew(60, 2, 4, _prop10String, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn, .CommandType = CommandType.StoredProcedure, .CommandText = consNamaSP}
                objCommand.Parameters.AddWithValue(consFieldnTarget, objParamChild).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dataset, "ChildTable")
            End Using

            Dim Parent_col As DataColumn()
            Dim Child_col As DataColumn()

            Parent_col = New DataColumn() {_dataset.Tables("ParentTable").Columns("k03String")}

            Child_col = New DataColumn() {_dataset.Tables("ChildTable").Columns("f08String")}

            Dim objDataRelation As DataRelation = New DataRelation(_pcNamaRelasiParentChild, Parent_col, Child_col, False)

            _dataset.Relations.Add(objDataRelation)

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _dataset.Tables("ParentTable")

            With GridControl1.LevelTree.Nodes
                .Add(_pcNamaRelasiParentChild, GridView2)
            End With

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChild.Dispose()

        Return _dataset
    End Function

    'Private Async Function _gdFA64SettlementARGetNoInvoice() As Task(Of String)
    '    'Dim objMaster As New clsGetDataMasterGEMINI()
    '    'Dim pcNumberPOMD As String = Await objMaster._pb03IncNumberMaster_Async(_prop01User._UserProp07TargetNetwork, "MNPOMD", "cNOMORDOKUMEN")

    '    'Return pcNumberPOMD
    'End Function

    'Private Async Function _gdFA64SettlementARSave() As Task(Of Integer)

    'End Function

#End Region

#Region "********** method private - CREATE NEW BILLING ==> form : ucFA23HH01BILLING **********"
    Private Sub _cc01CaptionCol61Billing()
        'PARENT
        colf02String.Caption = "Entity"
        colf14String.Caption = "Identity"
        colf01Date.Caption = "Tgl.Faktur"
        colf02Date.Caption = "Tgl.JT"
        colk03String.Caption = "No.Faktur"
        colk05String.Caption = "SJ"
        colf04String.Caption = "Brand"
        colf10String.Caption = "RPY" '"RatePayment"
        colf05Double16.Caption = "Kadar"
        colf11String.Caption = "Karat"
        colf03Int.Caption = "Pcs"         'SKK
        colf03Double.Caption = "Gross (gr)"    'SKK
        colf05Double.Caption = "Tukaran"  'TukaranEnd
        colf03Double16.Caption = "Net (gr)"
        colf04Int.Caption = "TGP (Rp)"
        colf01Double16.Caption = "Net (Rp)"

        'CHILD
        gv2colk03String.Caption = "No.Faktur"
        gv2colk04String.Caption = "CO"
        gv2colk05String.Caption = "SJ"
        gv2colf01String.Caption = "BRAND"
        gv2colf01Double.Caption = "Berat (gr)"
    End Sub

    Private Sub _cc01Visibility61Billing()
        'PARENT
        colf02String.Visible = True   '"Entity"
        colf14String.Visible = True   '"Identity"
        colf01Date.Visible = True   '"Tgl.Faktur"
        colf02Date.Visible = True   '"Tgl.JT"
        colk03String.Visible = True   '"No.Faktur"
        colk05String.Visible = True   '"SJ"
        colf04String.Visible = True   '"Brand"
        colf10String.Visible = True   '"RatePayment"
        colf05Double16.Visible = True   '"Kadar"
        colf11String.Visible = True   '"Karat"
        colf03Int.Visible = True   '"Pcs (Lot)"         'SKK
        colf03Double.Visible = True   '"Gross (gr)"    'SKK
        colf05Double.Visible = True   '"Tukaran"  'TukaranEnd
        colf03Double16.Visible = True   '"Net (gr)"
        colf04Int.Visible = True   '"TGP (Rp)"
        colf01Double16.Visible = True   '"Net (Rp)"

        'CHILD
        gv2colk03String.Visible = True   '"No.Faktur"
        gv2colk04String.Visible = True   '"CO"
        gv2colk05String.Visible = True   '"SJ"
        gv2colf01String.Visible = True   '"BRAND"
        gv2colf01Double.Visible = True   '"Berat (gr)"

    End Sub

    Private Sub _cc01VisibilityIndex61Billing()
        'PARENT
        colf14String.VisibleIndex = 0      '"Identity"
        colf02String.VisibleIndex = 1      '"Entity"
        colf01Date.VisibleIndex = 2      '"Tgl.Faktur"
        colf02Date.VisibleIndex = 3      '"Tgl.JT"
        colk03String.VisibleIndex = 4      '"No.Faktur"
        colk05String.VisibleIndex = 5      '"SJ"
        colf04String.VisibleIndex = 6      '"Brand"
        colf10String.VisibleIndex = 7      '"RatePayment"
        colf05Double16.VisibleIndex = 8      '"Kadar"
        colf11String.VisibleIndex = 9      '"Karat"
        colf03Int.VisibleIndex = 10      '"Pcs (Lot)"         'SKK
        colf03Double.VisibleIndex = 11      '"Gross (gr)"    'SKK
        colf05Double.VisibleIndex = 12      '"Tukaran"  'TukaranEnd
        colf03Double16.VisibleIndex = 13      '"Net (gr)"
        colf04Int.VisibleIndex = 14         '"TGP (Rp)"
        colf01Double16.VisibleIndex = 15      '"Net (Rp)"

        'CHILD
        gv2colk03String.VisibleIndex = 0      '"No.Faktur"
        gv2colk04String.VisibleIndex = 1      '"CO"
        gv2colk05String.VisibleIndex = 2      '"SJ"
        gv2colf01String.VisibleIndex = 3      '"BRAND"
        gv2colf01Double.VisibleIndex = 4      '"Berat (gr)"

    End Sub

    Private Sub _cc01TotBeratRupiah61Billing()
        'PARENT
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f03Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f03Double").SummaryItem.FieldName = "f03Double"
        GridView1.Columns("f03Double").SummaryItem.DisplayFormat = "{0:n2}"

        GridView1.Columns("f03Double16").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f03Double16").SummaryItem.FieldName = "f03Double16"
        GridView1.Columns("f03Double16").SummaryItem.DisplayFormat = "{0:n3}"

        GridView1.Columns("f01Double16").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double16").SummaryItem.FieldName = "f01Double16"
        GridView1.Columns("f01Double16").SummaryItem.DisplayFormat = "{0:n0}"

        'CHILD
        GridView2.OptionsView.ShowFooter = True

        GridView2.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView2.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView2.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
    End Sub

    Private Sub _cc01SettingLain61Billing()
        With colf05Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n2}%"
            End With
        End With

        With colf03Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n2}"
            End With
        End With

        With colf03Double16
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:n3}"
            End With
        End With

        With colf05Double
            With .DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "P2"
            End With
        End With

        With colf01Double16
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
        Finally
            GridView1.EndSort()
        End Try

        ' "Count" summary item
        Dim gscCount As New GridGroupSummaryItem()
        gscCount.SummaryType = SummaryItemType.Count
        gscCount.DisplayFormat = "({0} Faktur)"
        GridView1.GroupSummary.Clear()
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

        Dim itemRp As GridGroupSummaryItem = New GridGroupSummaryItem()
        With itemRp
            .FieldName = "f01Double16"
            .ShowInGroupColumnFooter = GridView1.Columns("f01Double16")
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "{0:n2}"
        End With
        GridView1.GroupSummary.Add(itemRp)

        With GridView1.Appearance.GroupFooter
            .Font = New Font("Courier New", 9, FontStyle.Bold)
            .ForeColor = Color.Navy
        End With

        GridView1.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub _gdFA61BillingDisplayGrid()
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _prop03pdtDataSet.Tables(0)

        With GridControl1.LevelTree.Nodes
            .Add("ParentChild", GridView2)
        End With
    End Sub

    Private Function _gdFA61BillingDisplay() As DataSet
        _dataset.Clear()
        _dataset.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsNasaSelectParamDataCollection
        objParamParent = New clsNasaSelectParamDataCollection

        Dim objParamChild As clsNasaSelectParamDataCollection
        objParamChild = New clsNasaSelectParamDataCollection

        Dim objConnSBU As New clsNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnSBU._cm03NasaConnectionDBSBU(_prop01User._UserProp07TargetNetwork))

            objConn.Open()

            objParamParent._01AddNew(60, 4, 1, _prop10String, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "spFA60SELECT4GRID"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dataset, "ParentTable")
            End Using

            If Not String.IsNullOrEmpty(_prop11String) Then
                _dataset.Tables("ParentTable").DefaultView.RowFilter = _prop11String
                _dataset.Tables("ParentTable").DefaultView.RowStateFilter = DataViewRowState.CurrentRows
            End If

            For Each dtRow As DataRow In _dataset.Tables.Item("ParentTable").Rows
                dtRow("f20String") = TglWithNameMonth(dtRow("f01Date"))
                dtRow("f21String") = TglWithNameMonth(dtRow("f02Date"))

                dtRow("f05Double16") = dtRow("f01Int") / 10
                dtRow("f22String") = FormatPercent(dtRow("f05Double"), 2)
                dtRow("f23String") = String.Format("{0:n2}", dtRow("f03Double"))
                dtRow("f24String") = String.Format("{0:n3}", dtRow("f03Double16"))
            Next
            _dataset.Tables.Item("ParentTable").AcceptChanges()

            Dim pdtKey As New DataTable
            Dim ctrlKey As New clsTEMPLATEKEY With {.prop_dtKEYGEMINI = pdtKey}
            ctrlKey.dtInitKEYGEMINI()
            For Each dtRow As DataRow In _dataset.Tables.Item("ParentTable").Rows
                ctrlKey.dtAddNewKEYGEMINI(dtRow("k01String"), "", "", "", "")
            Next

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "spFA62GetDataFaktuDetail"}
                objCommand.Parameters.AddWithValue("@tpKey", ctrlKey.prop_dtKEYGEMINI).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_dataset, "ChildTable")
            End Using

            Dim Parent_col As DataColumn()
            Dim Child_col As DataColumn()

            Parent_col = New DataColumn() {_dataset.Tables("ParentTable").Columns("k01String")}

            Child_col = New DataColumn() {_dataset.Tables("ChildTable").Columns("k01String")}

            Dim objDataRelation As DataRelation = New DataRelation(_pcNamaRelasiParentChild, Parent_col, Child_col, False)

            _dataset.Relations.Add(objDataRelation)

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _dataset.Tables("ParentTable")

            With GridControl1.LevelTree.Nodes
                .Add(_pcNamaRelasiParentChild, GridView2)
            End With

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChild.Dispose()

        Return _dataset
    End Function

    Private Function TglWithNameMonth(ByVal prmDate As Date) As String
        Dim pcNamaBulan As String = ""
        Select Case prmDate.Month
            Case 1
                pcNamaBulan = "Jan"
            Case 2
                pcNamaBulan = "Feb"
            Case 3
                pcNamaBulan = "Mar"
            Case 4
                pcNamaBulan = "Apr"
            Case 5
                pcNamaBulan = "Mei"
            Case 6
                pcNamaBulan = "Jun"
            Case 7
                pcNamaBulan = "Jul"
            Case 8
                pcNamaBulan = "Agt"
            Case 9
                pcNamaBulan = "Sep"
            Case 10
                pcNamaBulan = "Okt"
            Case 11
                pcNamaBulan = "Nov"
            Case 12
                pcNamaBulan = "Des"
        End Select

        Dim plhasil As String = ""
        plhasil = String.Format("{0} {1} {2}", Format(prmDate.Day, "00"), pcNamaBulan, Format(prmDate.Year, "0000"))
        Return plhasil
    End Function

#End Region

#Region "control - event"

    Private Sub _rscolk00Boolean_CheckedChanged(sender As Object, e As EventArgs) Handles _rscolk00Boolean.CheckedChanged
        GridView1.PostEditor()
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_LostFocus(sender As Object, e As EventArgs) Handles GridView1.LostFocus
        GridView1.PostEditor()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        If _prop01TargetTransaksi = TargetTransaksi._01MD23BZ01PRODUCTIONORDER Then
            If Not e.Column.FieldName = "f02Date" Then
                If e.Column.FieldName = "f02Int" And (e.Value <> CInt(GridView1.GetFocusedRowCellValue("f01Int"))) Then  'colf02Int.Caption = "QtyPO"
                    Dim pnBeratChild As Double = _cm10GetBeratChild(GridView1.GetFocusedRowCellValue("k04String").ToString)

                    GridView1.SetFocusedRowCellValue("f03Double", e.Value * pnBeratChild)  'colf03Double.Caption = "TotBeratPO"
                End If
            End If
        Else
            If _prop01TargetTransaksi = TargetTransaksi._02FA23GU01SETTLEMENTAR Then
                If e.Column.FieldName = "k00Boolean" Then

                    If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                        GridView1.SetFocusedRowCellValue("k00Int", 1)
                    Else
                        GridView1.SetFocusedRowCellValue("k00Int", 0)
                    End If

                    GridView1.RefreshData()

                End If
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

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle + 1 'e.RowHandle.ToString()
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            With e.Appearance
                .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                .Font = New Font("Courier New", 9, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Navy
                .DrawBackground(e.Cache, e.Bounds)
                .DrawString(e.Cache, "NoUrut", e.Bounds)
            End With

            e.Handled = True
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If _prop01TargetTransaksi = TargetTransaksi._02FA23GU01SETTLEMENTAR Then
            Dim View As GridView = TryCast(sender, GridView)

            If e.RowHandle >= 0 Then
                Dim nCheck As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))
                If nCheck = 1 Then
                    e.Appearance.BackColor = Color.LightYellow
                Else
                    e.Appearance.BackColor = Color.White
                End If
            End If
        End If

        If _prop01TargetTransaksi = TargetTransaksi._01MD23BZ01PRODUCTIONORDER Then
            Dim View As GridView = TryCast(sender, GridView)

            If e.RowHandle >= 0 Then
                Dim nTahun As Integer = Year(View.GetRowCellValue(e.RowHandle, View.Columns("f02Date")))
                If nTahun = 3000 Then
                    e.Appearance.BackColor = Color.White
                Else
                    e.Appearance.BackColor = Color.LightYellow
                End If
            End If
        End If
    End Sub

    Private _Totf02Int As Integer = 0
    Private _Totf02Double As Double = 0

    Private _Totf03Int As Integer = 0
    Private _Totf03Double As Double = 0

    Private _Totf01Double As Double = 0

    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
        Dim View As GridView = CType(sender, GridView)

        If e.SummaryProcess = CustomSummaryProcess.Start Then
            If _prop01TargetTransaksi = TargetTransaksi._01MD23BZ01PRODUCTIONORDER Then
                _Totf02Int = 0
                _Totf03Double = 0
            Else
                If _prop01TargetTransaksi = TargetTransaksi._02FA23GU01SETTLEMENTAR Then
                    _Totf02Int = 0
                    _Totf02Double = 0
                    _Totf03Int = 0
                    _Totf03Double = 0
                    _Totf01Double = 0
                End If
            End If
        End If

        If e.SummaryProcess = CustomSummaryProcess.Calculate Then
            If _prop01TargetTransaksi = TargetTransaksi._01MD23BZ01PRODUCTIONORDER Then
                Dim pnTotf02Int As Int32 = CInt(View.GetRowCellValue(e.RowHandle, "f02Int"))
                Dim pnTotf03Double As Double = CDbl(View.GetRowCellValue(e.RowHandle, "f03Double"))

                Select Case summaryID
                    Case 100
                        _Totf02Int += pnTotf02Int
                    Case 101
                        _Totf03Double += pnTotf03Double
                End Select
            Else
                If _prop01TargetTransaksi = TargetTransaksi._02FA23GU01SETTLEMENTAR Then
                    Dim plk00Boolean As Boolean = View.GetRowCellValue(e.RowHandle, "k00Boolean")

                    If plk00Boolean Then
                        Dim pnTotf02Int As Int32 = CInt(View.GetRowCellValue(e.RowHandle, "f02Int"))
                        Dim pnTotf02Double As Double = CDbl(View.GetRowCellValue(e.RowHandle, "f02Double"))
                        Dim pnTotf03Int As Int32 = CInt(View.GetRowCellValue(e.RowHandle, "f03Int"))
                        Dim pnTotf03Double As Double = CDbl(View.GetRowCellValue(e.RowHandle, "f03Double"))
                        Dim pnTotf01Double As Double = CDbl(View.GetRowCellValue(e.RowHandle, "f01Double"))

                        Select Case summaryID
                            Case 20
                                _Totf02Int += pnTotf02Int

                            Case 21
                                _Totf02Double += pnTotf02Double

                            Case 22
                                _Totf03Int += pnTotf03Int

                            Case 23
                                _Totf03Double += pnTotf03Double

                            Case 24
                                _Totf01Double += pnTotf01Double

                        End Select
                    End If
                End If
            End If
        End If

        If e.SummaryProcess = CustomSummaryProcess.Finalize Then
            If _prop01TargetTransaksi = TargetTransaksi._01MD23BZ01PRODUCTIONORDER Then
                Select Case summaryID
                    Case 100
                        e.TotalValue = _Totf02Int
                    Case 101
                        e.TotalValue = _Totf03Double
                End Select
            Else
                If _prop01TargetTransaksi = TargetTransaksi._02FA23GU01SETTLEMENTAR Then
                    Select Case summaryID
                        Case 20
                            e.TotalValue = _Totf02Int

                        Case 21
                            e.TotalValue = _Totf02Double

                        Case 22
                            e.TotalValue = _Totf03Int

                        Case 23
                            e.TotalValue = _Totf03Double

                        Case 24
                            e.TotalValue = _Totf01Double

                    End Select
                End If
            End If
        End If
    End Sub


#End Region

End Class

'Private Shared Sub GetChildRowsFromDataRelation()
'    Dim table As DataTable = CreateDataSet().Tables("Customers")
'    Dim childRows As DataRow()

'    For Each relation As DataRelation In table.ChildRelations

'        For Each row As DataRow In table.Rows
'            PrintRowValues(New DataRow() {row}, "Parent Row")
'            childRows = row.GetChildRows(relation)
'            PrintRowValues(childRows, "child rows")
'        Next
'    Next
'End Sub