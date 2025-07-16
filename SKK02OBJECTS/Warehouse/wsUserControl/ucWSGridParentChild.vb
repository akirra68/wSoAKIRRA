Imports System.ComponentModel
Imports System.DirectoryServices.ActiveDirectory
Imports System.IO
Imports System.Text
Imports DevExpress.CodeParser
Imports DevExpress.Data
Imports DevExpress.DataAccess.Native.Sql.MasterDetail
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraLayout.Customization
Imports Microsoft.Data.SqlClient
Imports SKK01CORE
Imports SKK02OBJECTS.clsWSNasaSettingGridInbound
Imports SKK02OBJECTS.repoWS05Master
Imports SKK02OBJECTS.repoWS08ProgressBar
Imports SKK02OBJECTS.ucWSGrid

Public Class ucWSGridParentChild
    Implements IDisposable

    Public Property _prop01User As clsWSNasaUser
    Public Property _prop01objUser As clsUserGEMINI

    Public Property _prop02TargetGridParentChild As __TargetGridParentChild
    Public Property _prop03String As String
    Public Property _prop04String As String
    Public Property _prop01Date As Date
    Public Property _prop02Date As Date
    Property _prop03pdtDataSourceGrid As New DataTable


    Private _pdsDataSet As DataSet
    Private _pcRelasiParentMiddle As String
    Private _pcRelasiMiddleChild As String
    Private _isCheked As Boolean = False


    Private pdtMasterProses As DataTable
    Private pdtPicker As DataTable
    Private pdtEkspedisi As DataTable

    Private objProgressParent As repoWS08ProgressBar
    Private objProgressMiddle As repoWS08ProgressBar

#Region "private - repository"
    'Parent
    Private _rscolk00Int As New repoWS02Numeric
    Private _rscolf01TinyInt As New repoWS02Numeric
    Private _rscolf01SmallInt As New repoWS02Numeric
    Private _rscolf01Int As New repoWS02Numeric
    Private _rscolf02Int As New repoWS02Numeric
    Private _rscolf01Double As New repoWS02Numeric
    Private _rscolf02Double As New repoWS02Numeric
    Private _rscolf03Double As New repoWS02Numeric
    Private _rscolf01Date As New repoWS01Date
    Private _rscolf02Date As New repoWS01Date
    Private _rscolf03Date As New repoWS01Date

    'Child
    Private _rschcolk00Int As New repoWS02Numeric
    Private _rschcolf01TinyInt As New repoWS02Numeric
    Private _rschcolf01SmallInt As New repoWS02Numeric
    Private _rschcolf01Int As New repoWS02Numeric
    Private _rschcolf02Int As New repoWS02Numeric
    Private _rschcolf03Int As New repoWS02Numeric
    Private _rschcolf01Double As New repoWS02Numeric
    Private _rschcolf02Double As New repoWS02Numeric
    Private _rschcolf03Double As New repoWS02Numeric
    Private _rschcolf01Date As New repoWS01Date
    Private _rschcolf02Date As New repoWS01Date
    Private _rschcolf03Date As New repoWS01Date

    'Grand-Child
    Private _rsgccolk00Int As New repoWS02Numeric
    Private _rsgccolf01TinyInt As New repoWS02Numeric
    Private _rsgccolf01SmallInt As New repoWS02Numeric
    Private _rsgccolf01Int As New repoWS02Numeric
    Private _rsgccolf02Int As New repoWS02Numeric
    Private _rsgccolf01Double As New repoWS02Numeric
    Private _rsgccolf02Double As New repoWS02Numeric
    Private _rsgccolf03Double As New repoWS02Numeric
    Private _rsgccolf01Date As New repoWS01Date
    Private _rsgccolf02Date As New repoWS01Date
    Private _rsgccolf03Date As New repoWS01Date

    'Additional
    Private _rscolNEXTProses As repoWS05Master
    Private _rscolPicker As repoWS05Master
    Private _rscolEkspedisi As repoWS05Master
#End Region

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _pdsDataSet = New DataSet

        pdtMasterProses = New DataTable
        pdtPicker = New DataTable
        pdtEkspedisi = New DataTable

        objProgressParent = New repoWS08ProgressBar
        objProgressParent.__pb01InitRepoProgressBar()

        objProgressMiddle = New repoWS08ProgressBar
        objProgressMiddle.__pb01InitRepoProgressBar()

        'AddHandler objProgressParent.CustomDisplayText, AddressOf objProgressParent_CustomDisplayText
        'AddHandler objProgressMiddle.CustomDisplayText, AddressOf objProgressMiddle_CustomDisplayText
        _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        _pdsDataSet.Dispose()

        pdtMasterProses.Dispose()
        pdtPicker.Dispose()
        pdtEkspedisi.Dispose()
        objProgressParent.Dispose()
        objProgressMiddle.Dispose()

        Me.Dispose()
    End Sub
#End Region

#Region "private - custom method"

    Private Sub _cm01InitOthersGridParentChild()
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.IndicatorWidth = 50
        GridView1.BestFitColumns()

        GridView2.OptionsView.ColumnAutoWidth = False
        GridView2.IndicatorWidth = 50
        GridView2.BestFitColumns()

        GridView3.OptionsView.ColumnAutoWidth = False
        GridView3.IndicatorWidth = 50
        GridView3.BestFitColumns()
    End Sub

    Private Sub _cm02InitFieldGridParent()
        _colk00Boolean.FieldName = "k00Boolean"
        _colk00Int.FieldName = "k00Int"
        _colk00Boolean01.FieldName = "k00Boolean01"
        _colk00Int01.FieldName = "k00Int01"

        _colk01String.FieldName = "k01String"
        _colk02String.FieldName = "k02String"
        _colk03String.FieldName = "k03String"
        _colk04String.FieldName = "k04String"
        _colk05String.FieldName = "k05String"
        _colf01String.FieldName = "f01String"
        _colf02String.FieldName = "f02String"
        _colf03String.FieldName = "f03String"
        _colf04String.FieldName = "f04String"
        _colf05String.FieldName = "f05String"
        _colf06String.FieldName = "f06String"
        _colf07String.FieldName = "f07String"
        _colf08String.FieldName = "f08String"
        _colf09String.FieldName = "f09String"
        _colf10String.FieldName = "f10String"
        _colf11String.FieldName = "f11String"
        _colf12String.FieldName = "f12String"
        _colf13String.FieldName = "f13String"
        _colf14String.FieldName = "f14String"
        _colf15String.FieldName = "f15String"
        _colf16String.FieldName = "f16String"
        _colf17String.FieldName = "f17String"
        _colf18String.FieldName = "f18String"
        _colf19String.FieldName = "f19String"
        _colf20String.FieldName = "f20String"
        _colf21String.FieldName = "f21String"
        _colf22String.FieldName = "f22String"
        _colf23String.FieldName = "f23String"
        _colf24String.FieldName = "f24String"
        _colf25String.FieldName = "f25String"
        _colf26String.FieldName = "f26String"
        _colf27String.FieldName = "f27String"
        _colf28String.FieldName = "f28String"
        _colf29String.FieldName = "f29String"
        _colf30String.FieldName = "f30String"
        _colf31String.FieldName = "f31String"
        _colf32String.FieldName = "f32String"
        _colf33String.FieldName = "f33String"
        _colf34String.FieldName = "f34String"
        _colf35String.FieldName = "f35String"
        _colf36String.FieldName = "f36String"
        _colf37String.FieldName = "f37String"
        _colf38String.FieldName = "f38String"
        _colf39String.FieldName = "f39String"
        _colf40String.FieldName = "f40String"
        _colf01Memo.FieldName = "f01Memo"
        _colf01TinyInt.FieldName = "f01TinyInt"
        _colf01SmallInt.FieldName = "f01SmallInt"
        _colf01Int.FieldName = "f01Int"
        _colf02Int.FieldName = "f02Int"
        _colf01Double.FieldName = "f01Double"
        _colf02Double.FieldName = "f02Double"
        _colf03Double.FieldName = "f03Double"
        _colf01Date.FieldName = "f01Date"
        _colf02Date.FieldName = "f02Date"
        _colf03Date.FieldName = "f03Date"
        _colf04Date.FieldName = "f04Date"
        _colf01Datetime.FieldName = "f01Datetime"
    End Sub

    Private Sub _cm02InitFieldGridChild()
        _chcolk00Boolean.FieldName = "k00Boolean"
        _chcolk00Int.FieldName = "k00Int"
        _chcolk01String.FieldName = "k01String"
        _chcolk02String.FieldName = "k02String"
        _chcolk03String.FieldName = "k03String"
        _chcolf01String.FieldName = "f01String"
        _chcolf02String.FieldName = "f02String"
        _chcolf03String.FieldName = "f03String"
        _chcolf04String.FieldName = "f04String"
        _chcolf05String.FieldName = "f05String"
        _chcolf06String.FieldName = "f06String"
        _chcolf07String.FieldName = "f07String"
        _chcolf08String.FieldName = "f08String"
        _chcolf09String.FieldName = "f09String"
        _chcolf10String.FieldName = "f10String"
        _chcolf11String.FieldName = "f11String"
        _chcolf12String.FieldName = "f12String"
        _chcolf13String.FieldName = "f13String"
        _chcolf14String.FieldName = "f14String"
        _chcolf15String.FieldName = "f15String"
        _chcolf16String.FieldName = "f16String"
        _chcolf17String.FieldName = "f17String"
        _chcolf18String.FieldName = "f18String"
        _chcolf19String.FieldName = "f19String"
        _chcolf20String.FieldName = "f20String"
        _chcolf21String.FieldName = "f21String"
        _chcolf22String.FieldName = "f22String"
        _chcolf23String.FieldName = "f23String"
        _chcolf24String.FieldName = "f24String"
        _chcolf25String.FieldName = "f25String"
        _chcolf26String.FieldName = "f26String"
        _chcolf27String.FieldName = "f27String"
        _chcolf28String.FieldName = "f28String"
        _chcolf29String.FieldName = "f29String"
        _chcolf30String.FieldName = "f30String"
        _chcolf31String.FieldName = "f31String"
        _chcolf32String.FieldName = "f32String"
        _chcolf33String.FieldName = "f33String"
        _chcolf34String.FieldName = "f34String"
        _chcolf35String.FieldName = "f35String"
        _chcolf36String.FieldName = "f36String"
        _chcolf37String.FieldName = "f37String"
        _chcolf38String.FieldName = "f38String"
        _chcolf39String.FieldName = "f39String"
        _chcolf40String.FieldName = "f40String"
        _chcolf01TinyInt.FieldName = "f01TinyInt"
        _chcolf01SmallInt.FieldName = "f01SmallInt"
        _chcolf01Int.FieldName = "f01Int"
        _chcolf02Int.FieldName = "f02Int"
        _chcolf03Int.FieldName = "f03Int"
        _chcolf01Double.FieldName = "f01Double"
        _chcolf02Double.FieldName = "f02Double"
        _chcolf03Double.FieldName = "f03Double"
        _chcolf01Date.FieldName = "f01Date"
        _chcolf02Date.FieldName = "f02Date"
        _chcolf03Date.FieldName = "f03Date"
        _chcolf01Datetime.FieldName = "f01Datetime"
    End Sub

    Private Sub _cm02InitFieldGridGrandChild()
        _gccolk00Boolean.FieldName = "k00Boolean"
        _gccolk00Int.FieldName = "k00Int"
        _gccolk01String.FieldName = "k01String"
        _gccolk02String.FieldName = "k02String"
        _gccolk03String.FieldName = "k03String"
        _gccolf01String.FieldName = "f01String"
        _gccolf02String.FieldName = "f02String"
        _gccolf03String.FieldName = "f03String"
        _gccolf04String.FieldName = "f04String"
        _gccolf05String.FieldName = "f05String"
        _gccolf06String.FieldName = "f06String"
        _gccolf07String.FieldName = "f07String"
        _gccolf08String.FieldName = "f08String"
        _gccolf09String.FieldName = "f09String"
        _gccolf10String.FieldName = "f10String"
        _gccolf11String.FieldName = "f11String"
        _gccolf12String.FieldName = "f12String"
        _gccolf13String.FieldName = "f13String"
        _gccolf14String.FieldName = "f14String"
        _gccolf15String.FieldName = "f15String"
        _gccolf16String.FieldName = "f16String"
        _gccolf17String.FieldName = "f17String"
        _gccolf18String.FieldName = "f18String"
        _gccolf19String.FieldName = "f19String"
        _gccolf20String.FieldName = "f20String"
        _gccolf21String.FieldName = "f21String"
        _gccolf22String.FieldName = "f22String"
        _gccolf23String.FieldName = "f23String"
        _gccolf24String.FieldName = "f24String"
        _gccolf25String.FieldName = "f25String"
        _gccolf26String.FieldName = "f26String"
        _gccolf27String.FieldName = "f27String"
        _gccolf28String.FieldName = "f28String"
        _gccolf29String.FieldName = "f29String"
        _gccolf30String.FieldName = "f30String"
        _gccolf31String.FieldName = "f31String"
        _gccolf32String.FieldName = "f32String"
        _gccolf33String.FieldName = "f33String"
        _gccolf34String.FieldName = "f34String"
        _gccolf35String.FieldName = "f35String"
        _gccolf36String.FieldName = "f36String"
        _gccolf37String.FieldName = "f37String"
        _gccolf38String.FieldName = "f38String"
        _gccolf39String.FieldName = "f39String"
        _gccolf40String.FieldName = "f40String"
        _gccolf01TinyInt.FieldName = "f01TinyInt"
        _gccolf01SmallInt.FieldName = "f01SmallInt"
        _gccolf01Int.FieldName = "f01Int"
        _gccolf02Int.FieldName = "f02Int"
        _gccolf01Double.FieldName = "f01Double"
        _gccolf02Double.FieldName = "f02Double"
        _gccolf03Double.FieldName = "f03Double"
        _gccolf01Date.FieldName = "f01Date"
        _gccolf02Date.FieldName = "f02Date"
        _gccolf03Date.FieldName = "f03Date"
    End Sub

    Private Sub _cm03InitRepoColumnParent()
        _rscolk00Int._pb01InitRepoNumeric(0)

        _rscolf01TinyInt._pb01InitRepoNumeric(0)
        _rscolf01SmallInt._pb01InitRepoNumeric(0)
        _rscolf01Int._pb01InitRepoNumeric(0)
        _rscolf01Double._pb01InitRepoNumeric(2)
        _rscolf02Double._pb01InitRepoNumeric(2)
        _rscolf03Double._pb01InitRepoNumeric(2)

        _rscolf01Date._pb01InitRepoDate()
        _rscolf02Date._pb01InitRepoDate()
        _rscolf03Date._pb01InitRepoDate()
    End Sub

    Private Sub _cm03InitRepoColumnChild()
        _rschcolk00Int._pb01InitRepoNumeric(0)

        _rschcolf01TinyInt._pb01InitRepoNumeric(0)
        _rschcolf01SmallInt._pb01InitRepoNumeric(0)
        _rschcolf01Int._pb01InitRepoNumeric(0)
        _rschcolf02Int._pb01InitRepoNumeric(0)
        _rschcolf01Double._pb01InitRepoNumeric(2)
        _rschcolf02Double._pb01InitRepoNumeric(2)
        _rschcolf03Double._pb01InitRepoNumeric(2)

        _rschcolf01Date._pb01InitRepoDate()
        _rschcolf02Date._pb01InitRepoDate()
        _rschcolf03Date._pb01InitRepoDate()
    End Sub

    Private Sub _cm03InitRepoColumnGrandChild()
        _rsgccolk00Int._pb01InitRepoNumeric(0)

        _rsgccolf01TinyInt._pb01InitRepoNumeric(0)
        _rsgccolf01SmallInt._pb01InitRepoNumeric(0)
        _rsgccolf01Int._pb01InitRepoNumeric(0)
        _rsgccolf02Int._pb01InitRepoNumeric(0)
        _rsgccolf01Double._pb01InitRepoNumeric(2)
        _rsgccolf02Double._pb01InitRepoNumeric(2)
        _rsgccolf03Double._pb01InitRepoNumeric(2)

        _rsgccolf01Date._pb01InitRepoDate()
        _rsgccolf02Date._pb01InitRepoDate()
        _rsgccolf03Date._pb01InitRepoDate()
    End Sub

    Private Sub _cm04InitColumnEditParent()
        _colf01TinyInt.ColumnEdit = _rscolf01TinyInt
        _colf01SmallInt.ColumnEdit = _rscolf01SmallInt
        _colf01Int.ColumnEdit = _rscolf01Int
        _colf02Int.ColumnEdit = _rscolf02Int
        _colf01Double.ColumnEdit = _rscolf01Double
        _colf02Double.ColumnEdit = _rscolf02Double
        _colf03Double.ColumnEdit = _rscolf03Double
        _colf01Date.ColumnEdit = _rscolf01Date
        _colf02Date.ColumnEdit = _rscolf02Date
        _colf03Date.ColumnEdit = _rscolf03Date
    End Sub

    Private Sub _cm04InitColumnEditChild()
        _chcolf01TinyInt.ColumnEdit = _rschcolf01TinyInt
        _chcolf01SmallInt.ColumnEdit = _rschcolf01SmallInt
        _chcolf01Int.ColumnEdit = _rschcolf01Int
        _chcolf02Int.ColumnEdit = _rschcolf02Int
        _chcolf03Int.ColumnEdit = _rschcolf03Int
        _chcolf01Double.ColumnEdit = _rschcolf01Double
        _chcolf02Double.ColumnEdit = _rschcolf02Double
        _chcolf03Double.ColumnEdit = _rschcolf03Double
        _chcolf01Date.ColumnEdit = _rschcolf01Date
        _chcolf02Date.ColumnEdit = _rschcolf02Date
        _chcolf03Date.ColumnEdit = _rschcolf03Date
    End Sub

    Private Sub _cm04InitColumnEditGrandChild()
        _gccolf01TinyInt.ColumnEdit = _rsgccolf01TinyInt
        _gccolf01SmallInt.ColumnEdit = _rsgccolf01SmallInt
        _gccolf01Int.ColumnEdit = _rsgccolf01Int
        _gccolf02Int.ColumnEdit = _rsgccolf02Int
        _gccolf01Double.ColumnEdit = _rsgccolf01Double
        _gccolf02Double.ColumnEdit = _rsgccolf02Double
        _gccolf03Double.ColumnEdit = _rsgccolf03Double
        _gccolf01Date.ColumnEdit = _rsgccolf01Date
        _gccolf02Date.ColumnEdit = _rsgccolf02Date
        _gccolf03Date.ColumnEdit = _rsgccolf03Date
    End Sub

    Private Sub _cm05InitGridSummaryItem(ByRef objColumn As GridColumn,
                                         ByVal prmcFieldName As String,
                                         ByVal prmcIntDouble As String)
        Dim pcDisplayFormat As String
        pcDisplayFormat = ""

        Select Case prmcIntDouble
            Case "INT"
                pcDisplayFormat = "{0:n0}"
            Case "DBL2"
                pcDisplayFormat = "{0:n2}"
            Case "DBL3"
                pcDisplayFormat = "{0:n3}"
        End Select

        Dim objGridSummaryItem As New GridSummaryItem
        With objGridSummaryItem
            .DisplayFormat = pcDisplayFormat
            .FieldName = prmcFieldName
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
        End With

    End Sub

    Private Sub _cm06SettingColumnSummaryParent()

        _cm05InitGridSummaryItem(_colf01TinyInt, "f01TinyInt", "INT")
        _cm05InitGridSummaryItem(_colf01SmallInt, "f01SmallInt", "INT")
        _cm05InitGridSummaryItem(_colf01Int, "f01Int", "INT")
        _cm05InitGridSummaryItem(_colf02Int, "f02Int", "INT")
        _cm05InitGridSummaryItem(_colf01Double, "f01Double", "DBL2")
        _cm05InitGridSummaryItem(_colf02Double, "f02Double", "DBL2")
        _cm05InitGridSummaryItem(_colf03Double, "f03Double", "DBL2")

    End Sub

    Private Sub _cm06SettingColumnSummaryChild()

        _cm05InitGridSummaryItem(_chcolf01TinyInt, "f01TinyInt", "INT")
        _cm05InitGridSummaryItem(_chcolf01SmallInt, "f01SmallInt", "INT")
        _cm05InitGridSummaryItem(_chcolf01Int, "f01Int", "INT")
        _cm05InitGridSummaryItem(_chcolf02Int, "f02Int", "INT")
        _cm05InitGridSummaryItem(_chcolf03Int, "f03Int", "INT")
        _cm05InitGridSummaryItem(_chcolf01Double, "f01Double", "DBL2")
        _cm05InitGridSummaryItem(_chcolf02Double, "f02Double", "DBL2")
        _cm05InitGridSummaryItem(_chcolf03Double, "f03Double", "DBL2")

    End Sub

    Private Sub _cm06SettingColumnSummaryGrandChild()

        _cm05InitGridSummaryItem(_gccolf01TinyInt, "f01TinyInt", "INT")
        _cm05InitGridSummaryItem(_gccolf01SmallInt, "f01SmallInt", "INT")
        _cm05InitGridSummaryItem(_gccolf01Int, "f01Int", "INT")
        _cm05InitGridSummaryItem(_gccolf02Int, "f02Int", "INT")
        _cm05InitGridSummaryItem(_gccolf01Double, "f01Double", "DBL2")
        _cm05InitGridSummaryItem(_gccolf02Double, "f02Double", "DBL2")
        _cm05InitGridSummaryItem(_gccolf03Double, "f03Double", "DBL2")

    End Sub

    Private Sub _cm07InitVisibilityOFFParent()
        _colk00Boolean.Visible = False  'k00Boolean"
        _colk00Int.Visible = False  'k00Int"
        _colk00Boolean01.Visible = False  '"k00Boolean01"
        _colk00Int01.Visible = False  '"k00Int01"

        _colk01String.Visible = False  'k01String"
        _colk02String.Visible = False  'k02String"
        _colk03String.Visible = False  'k03String"
        _colk04String.Visible = False  'k03String"
        _colk05String.Visible = False  'k03String"
        _colf01String.Visible = False  'f01String"
        _colf02String.Visible = False  'f02String"
        _colf03String.Visible = False  'f03String"
        _colf04String.Visible = False  'f04String"
        _colf05String.Visible = False  'f05String"
        _colf06String.Visible = False  'f06String"
        _colf07String.Visible = False  'f07String"
        _colf08String.Visible = False  'f08String"
        _colf09String.Visible = False  'f09String"
        _colf10String.Visible = False  'f10String"
        _colf11String.Visible = False  'f11String"
        _colf12String.Visible = False  'f12String"
        _colf13String.Visible = False  'f13String"
        _colf14String.Visible = False  'f14String"
        _colf15String.Visible = False  'f15String"
        _colf16String.Visible = False  'f16String"
        _colf17String.Visible = False  'f17String"
        _colf18String.Visible = False  'f18String"
        _colf19String.Visible = False  'f19String"
        _colf20String.Visible = False  'f20String"
        _colf21String.Visible = False  'f21String"
        _colf22String.Visible = False  'f22String"
        _colf23String.Visible = False  'f23String"
        _colf24String.Visible = False  'f24String"
        _colf25String.Visible = False  'f25String"
        _colf26String.Visible = False  'f26String"
        _colf27String.Visible = False  'f27String"
        _colf28String.Visible = False  'f28String"
        _colf29String.Visible = False  'f29String"
        _colf30String.Visible = False  'f30String"
        _colf31String.Visible = False  '"f31String"
        _colf32String.Visible = False  '"f32String"
        _colf33String.Visible = False  '"f33String"
        _colf34String.Visible = False  '"f34String"
        _colf35String.Visible = False  '"f35String"
        _colf36String.Visible = False  '"f36String"
        _colf37String.Visible = False  '"f37String"
        _colf38String.Visible = False  '"f38String"
        _colf39String.Visible = False  '"f39String"
        _colf40String.Visible = False  '"f40String"
        _colf01Memo.Visible = False  '"f01Memo"
        _colf01TinyInt.Visible = False  'f01TinyInt"
        _colf01SmallInt.Visible = False  'f01SmallInt"
        _colf01Int.Visible = False  'f01Int"
        _colf02Int.Visible = False  'f01Int"
        _colf01Double.Visible = False  'f01Double52"
        _colf02Double.Visible = False  'f01Double62"
        _colf03Double.Visible = False  'f01Double162"
        _colf01Date.Visible = False  'f01Date"
        _colf02Date.Visible = False  'f02Date"
        _colf03Date.Visible = False  'f03Date"
        _colf04Date.Visible = False  'f04Date"
        _colf01Datetime.Visible = False  'f01Datetime"
    End Sub

    Private Sub _cm07InitVisibilityOFFChild()
        _chcolk00Boolean.Visible = False  'k00Boolean"
        _chcolk00Int.Visible = False  'k00Int"

        _chcolk01String.Visible = False  'k01String"
        _chcolk02String.Visible = False  'k02String"
        _chcolk03String.Visible = False  'k03String"
        _chcolf01String.Visible = False  'f01String"
        _chcolf02String.Visible = False  'f02String"
        _chcolf03String.Visible = False  'f03String"
        _chcolf04String.Visible = False  'f04String"
        _chcolf05String.Visible = False  'f05String"
        _chcolf06String.Visible = False  'f06String"
        _chcolf07String.Visible = False  'f07String"
        _chcolf08String.Visible = False  'f08String"
        _chcolf09String.Visible = False  'f09String"
        _chcolf10String.Visible = False  'f10String"
        _chcolf11String.Visible = False  'f11String"
        _chcolf12String.Visible = False  'f12String"
        _chcolf13String.Visible = False  'f13String"
        _chcolf14String.Visible = False  'f14String"
        _chcolf15String.Visible = False  'f15String"
        _chcolf16String.Visible = False  'f16String"
        _chcolf17String.Visible = False  'f17String"
        _chcolf18String.Visible = False  'f18String"
        _chcolf19String.Visible = False  'f19String"
        _chcolf20String.Visible = False  'f20String"
        _chcolf21String.Visible = False  'f21String"
        _chcolf22String.Visible = False  'f22String"
        _chcolf23String.Visible = False  'f23String"
        _chcolf24String.Visible = False  'f24String"
        _chcolf25String.Visible = False  'f25String"
        _chcolf26String.Visible = False  'f26String"
        _chcolf27String.Visible = False  'f27String"
        _chcolf28String.Visible = False  'f28String"
        _chcolf29String.Visible = False  'f29String"
        _chcolf30String.Visible = False  'f30String"
        _chcolf31String.Visible = False  '"f31String"
        _chcolf32String.Visible = False  '"f32String"
        _chcolf33String.Visible = False  '"f33String"
        _chcolf34String.Visible = False  '"f34String"
        _chcolf35String.Visible = False  '"f35String"
        _chcolf36String.Visible = False  '"f36String"
        _chcolf37String.Visible = False  '"f37String"
        _chcolf38String.Visible = False  '"f38String"
        _chcolf39String.Visible = False  '"f39String"
        _chcolf40String.Visible = False  '"f40String"
        _chcolf01TinyInt.Visible = False  'f01TinyInt"
        _chcolf01SmallInt.Visible = False  'f01SmallInt"
        _chcolf01Int.Visible = False  'f01Int"
        _chcolf02Int.Visible = False  'f02Int"
        _chcolf03Int.Visible = False  'f03Int"
        _chcolf01Double.Visible = False  'f01Double52"
        _chcolf02Double.Visible = False  'f01Double62"
        _chcolf03Double.Visible = False  'f01Double162"
        _chcolf01Date.Visible = False  'f01Date"
        _chcolf02Date.Visible = False  'f02Date"
        _chcolf03Date.Visible = False  'f03Date"
        _chcolf01Datetime.Visible = False  'f01Datetime"
    End Sub

    Private Sub _cm07InitVisibilityOFFGrandChild()
        _gccolk00Boolean.Visible = False  'k00Boolean"
        _gccolk00Int.Visible = False  'k00Int"

        _gccolk01String.Visible = False  'k01String"
        _gccolk02String.Visible = False  'k02String"
        _gccolk03String.Visible = False  'k03String"
        _gccolf01String.Visible = False  'f01String"
        _gccolf02String.Visible = False  'f02String"
        _gccolf03String.Visible = False  'f03String"
        _gccolf04String.Visible = False  'f04String"
        _gccolf05String.Visible = False  'f05String"
        _gccolf06String.Visible = False  'f06String"
        _gccolf07String.Visible = False  'f07String"
        _gccolf08String.Visible = False  'f08String"
        _gccolf09String.Visible = False  'f09String"
        _gccolf10String.Visible = False  'f10String"
        _gccolf11String.Visible = False  'f11String"
        _gccolf12String.Visible = False  'f12String"
        _gccolf13String.Visible = False  'f13String"
        _gccolf14String.Visible = False  'f14String"
        _gccolf15String.Visible = False  'f15String"
        _gccolf16String.Visible = False  'f16String"
        _gccolf17String.Visible = False  'f17String"
        _gccolf18String.Visible = False  'f18String"
        _gccolf19String.Visible = False  'f19String"
        _gccolf20String.Visible = False  'f20String"
        _gccolf21String.Visible = False  'f21String"
        _gccolf22String.Visible = False  'f22String"
        _gccolf23String.Visible = False  'f23String"
        _gccolf24String.Visible = False  'f24String"
        _gccolf25String.Visible = False  'f25String"
        _gccolf26String.Visible = False  'f26String"
        _gccolf27String.Visible = False  'f27String"
        _gccolf28String.Visible = False  'f28String"
        _gccolf29String.Visible = False  'f29String"
        _gccolf30String.Visible = False  'f30String"
        _gccolf31String.Visible = False  '"f31String"
        _gccolf32String.Visible = False  '"f32String"
        _gccolf33String.Visible = False  '"f33String"
        _gccolf34String.Visible = False  '"f34String"
        _gccolf35String.Visible = False  '"f35String"
        _gccolf36String.Visible = False  '"f36String"
        _gccolf37String.Visible = False  '"f37String"
        _gccolf38String.Visible = False  '"f38String"
        _gccolf39String.Visible = False  '"f39String"
        _gccolf40String.Visible = False  '"f40String"
        _gccolf01TinyInt.Visible = False  'f01TinyInt"
        _gccolf01SmallInt.Visible = False  'f01SmallInt"
        _gccolf01Int.Visible = False  'f01Int"
        _gccolf02Int.Visible = False  'f02Int"
        _gccolf01Double.Visible = False  'f01Double52"
        _gccolf02Double.Visible = False  'f01Double62"
        _gccolf03Double.Visible = False  'f01Double162"
        _gccolf01Date.Visible = False  'f01Date"
        _gccolf02Date.Visible = False  'f02Date"
        _gccolf03Date.Visible = False  'f03Date"
    End Sub

    Private Sub _cm08InitVisibilityIndexOFFParent()
        _colk00Boolean.VisibleIndex = -1   '"k00Boolean"
        _colk00Int.VisibleIndex = -1   '"k00Int"
        _colk00Boolean01.VisibleIndex = -1  '"k00Boolean01"
        _colk00Int01.VisibleIndex = -1  '"k00Int01"

        _colk01String.VisibleIndex = -1   '"k01String"
        _colk02String.VisibleIndex = -1   '"k02String"
        _colk03String.VisibleIndex = -1   '"k03String"
        _colk04String.VisibleIndex = -1   '"k03String"
        _colk05String.VisibleIndex = -1   '"k03String"
        _colf01String.VisibleIndex = -1   '"f01String"
        _colf02String.VisibleIndex = -1   '"f02String"
        _colf03String.VisibleIndex = -1   '"f03String"
        _colf04String.VisibleIndex = -1   '"f04String"
        _colf05String.VisibleIndex = -1   '"f05String"
        _colf06String.VisibleIndex = -1   '"f06String"
        _colf07String.VisibleIndex = -1   '"f07String"
        _colf08String.VisibleIndex = -1   '"f08String"
        _colf09String.VisibleIndex = -1   '"f09String"
        _colf10String.VisibleIndex = -1   '"f10String"
        _colf11String.VisibleIndex = -1   '"f11String"
        _colf12String.VisibleIndex = -1   '"f12String"
        _colf13String.VisibleIndex = -1   '"f13String"
        _colf14String.VisibleIndex = -1   '"f14String"
        _colf15String.VisibleIndex = -1   '"f15String"
        _colf16String.VisibleIndex = -1   '"f16String"
        _colf17String.VisibleIndex = -1   '"f17String"
        _colf18String.VisibleIndex = -1   '"f18String"
        _colf19String.VisibleIndex = -1   '"f19String"
        _colf20String.VisibleIndex = -1   '"f20String"
        _colf21String.VisibleIndex = -1   '"f21String"
        _colf22String.VisibleIndex = -1   '"f22String"
        _colf23String.VisibleIndex = -1   '"f23String"
        _colf24String.VisibleIndex = -1   '"f24String"
        _colf25String.VisibleIndex = -1   '"f25String"
        _colf26String.VisibleIndex = -1   '"f26String"
        _colf27String.VisibleIndex = -1   '"f27String"
        _colf28String.VisibleIndex = -1   '"f28String"
        _colf29String.VisibleIndex = -1   '"f29String"
        _colf30String.VisibleIndex = -1   '"f30String"
        _colf31String.VisibleIndex = -1   '"f31String"
        _colf32String.VisibleIndex = -1   '"f32String"
        _colf33String.VisibleIndex = -1   '"f33String"
        _colf34String.VisibleIndex = -1   '"f34String"
        _colf35String.VisibleIndex = -1   '"f35String"
        _colf36String.VisibleIndex = -1   '"f36String"
        _colf37String.VisibleIndex = -1   '"f37String"
        _colf38String.VisibleIndex = -1   '"f38String"
        _colf39String.VisibleIndex = -1   '"f39String"
        _colf40String.VisibleIndex = -1   '"f40String"
        _colf01Memo.VisibleIndex = -1  '"f01Memo"
        _colf01TinyInt.VisibleIndex = -1   '"f01TinyInt"
        _colf01SmallInt.VisibleIndex = -1   '"f01SmallInt"
        _colf01Int.VisibleIndex = -1   '"f01Int"
        _colf02Int.VisibleIndex = -1   '"f01Int"
        _colf01Double.VisibleIndex = -1   '"f01Double52"
        _colf02Double.VisibleIndex = -1   '"f01Double62"
        _colf03Double.VisibleIndex = -1   '"f01Double162"
        _colf01Date.VisibleIndex = -1   '"f01Date"
        _colf02Date.VisibleIndex = -1   '"f02Date"
        _colf03Date.VisibleIndex = -1   '"f03Date"
        _colf04Date.VisibleIndex = -1   '"f04Date"
        _colf01Datetime.VisibleIndex = -1   '"f01Datetime"
    End Sub

    Private Sub _cm08InitVisibilityIndexOFFChild()
        _chcolk00Boolean.VisibleIndex = -1   '"k00Boolean"
        _chcolk00Int.VisibleIndex = -1   '"k00Int"

        _chcolk01String.VisibleIndex = -1   '"k01String"
        _chcolk02String.VisibleIndex = -1   '"k02String"
        _chcolk03String.VisibleIndex = -1   '"k03String"
        _chcolf01String.VisibleIndex = -1   '"f01String"
        _chcolf02String.VisibleIndex = -1   '"f02String"
        _chcolf03String.VisibleIndex = -1   '"f03String"
        _chcolf04String.VisibleIndex = -1   '"f04String"
        _chcolf05String.VisibleIndex = -1   '"f05String"
        _chcolf06String.VisibleIndex = -1   '"f06String"
        _chcolf07String.VisibleIndex = -1   '"f07String"
        _chcolf08String.VisibleIndex = -1   '"f08String"
        _chcolf09String.VisibleIndex = -1   '"f09String"
        _chcolf10String.VisibleIndex = -1   '"f10String"
        _chcolf11String.VisibleIndex = -1   '"f11String"
        _chcolf12String.VisibleIndex = -1   '"f12String"
        _chcolf13String.VisibleIndex = -1   '"f13String"
        _chcolf14String.VisibleIndex = -1   '"f14String"
        _chcolf15String.VisibleIndex = -1   '"f15String"
        _chcolf16String.VisibleIndex = -1   '"f16String"
        _chcolf17String.VisibleIndex = -1   '"f17String"
        _chcolf18String.VisibleIndex = -1   '"f18String"
        _chcolf19String.VisibleIndex = -1   '"f19String"
        _chcolf20String.VisibleIndex = -1   '"f20String"
        _chcolf21String.VisibleIndex = -1   '"f21String"
        _chcolf22String.VisibleIndex = -1   '"f22String"
        _chcolf23String.VisibleIndex = -1   '"f23String"
        _chcolf24String.VisibleIndex = -1   '"f24String"
        _chcolf25String.VisibleIndex = -1   '"f25String"
        _chcolf26String.VisibleIndex = -1   '"f26String"
        _chcolf27String.VisibleIndex = -1   '"f27String"
        _chcolf28String.VisibleIndex = -1   '"f28String"
        _chcolf29String.VisibleIndex = -1   '"f29String"
        _chcolf30String.VisibleIndex = -1   '"f30String"
        _chcolf31String.VisibleIndex = -1   '"f31String"
        _chcolf32String.VisibleIndex = -1   '"f32String"
        _chcolf33String.VisibleIndex = -1   '"f33String"
        _chcolf34String.VisibleIndex = -1   '"f34String"
        _chcolf35String.VisibleIndex = -1   '"f35String"
        _chcolf36String.VisibleIndex = -1   '"f36String"
        _chcolf37String.VisibleIndex = -1   '"f37String"
        _chcolf38String.VisibleIndex = -1   '"f38String"
        _chcolf39String.VisibleIndex = -1   '"f39String"
        _chcolf40String.VisibleIndex = -1   '"f40String"
        _chcolf01TinyInt.VisibleIndex = -1   '"f01TinyInt"
        _chcolf01SmallInt.VisibleIndex = -1   '"f01SmallInt"
        _chcolf01Int.VisibleIndex = -1   '"f01Int"
        _chcolf02Int.VisibleIndex = -1   '"f02Int"
        _chcolf03Int.VisibleIndex = -1   '"f03Int"
        _chcolf01Double.VisibleIndex = -1   '"f01Double52"
        _chcolf02Double.VisibleIndex = -1   '"f01Double62"
        _chcolf03Double.VisibleIndex = -1   '"f01Double162"
        _chcolf01Date.VisibleIndex = -1   '"f01Date"
        _chcolf02Date.VisibleIndex = -1   '"f02Date"
        _chcolf03Date.VisibleIndex = -1   '"f03Date"
        _chcolf01Datetime.VisibleIndex = -1   '"f01Datetime"
    End Sub

    Private Sub _cm08InitVisibilityIndexOFFGrandChild()
        _gccolk00Boolean.VisibleIndex = -1   '"k00Boolean"
        _gccolk00Int.VisibleIndex = -1   '"k00Int"

        _gccolk01String.VisibleIndex = -1   '"k01String"
        _gccolk02String.VisibleIndex = -1   '"k02String"
        _gccolk03String.VisibleIndex = -1   '"k03String"
        _gccolf01String.VisibleIndex = -1   '"f01String"
        _gccolf02String.VisibleIndex = -1   '"f02String"
        _gccolf03String.VisibleIndex = -1   '"f03String"
        _gccolf04String.VisibleIndex = -1   '"f04String"
        _gccolf05String.VisibleIndex = -1   '"f05String"
        _gccolf06String.VisibleIndex = -1   '"f06String"
        _gccolf07String.VisibleIndex = -1   '"f07String"
        _gccolf08String.VisibleIndex = -1   '"f08String"
        _gccolf09String.VisibleIndex = -1   '"f09String"
        _gccolf10String.VisibleIndex = -1   '"f10String"
        _gccolf11String.VisibleIndex = -1   '"f11String"
        _gccolf12String.VisibleIndex = -1   '"f12String"
        _gccolf13String.VisibleIndex = -1   '"f13String"
        _gccolf14String.VisibleIndex = -1   '"f14String"
        _gccolf15String.VisibleIndex = -1   '"f15String"
        _gccolf16String.VisibleIndex = -1   '"f16String"
        _gccolf17String.VisibleIndex = -1   '"f17String"
        _gccolf18String.VisibleIndex = -1   '"f18String"
        _gccolf19String.VisibleIndex = -1   '"f19String"
        _gccolf20String.VisibleIndex = -1   '"f20String"
        _gccolf21String.VisibleIndex = -1   '"f21String"
        _gccolf22String.VisibleIndex = -1   '"f22String"
        _gccolf23String.VisibleIndex = -1   '"f23String"
        _gccolf24String.VisibleIndex = -1   '"f24String"
        _gccolf25String.VisibleIndex = -1   '"f25String"
        _gccolf26String.VisibleIndex = -1   '"f26String"
        _gccolf27String.VisibleIndex = -1   '"f27String"
        _gccolf28String.VisibleIndex = -1   '"f28String"
        _gccolf29String.VisibleIndex = -1   '"f29String"
        _gccolf30String.VisibleIndex = -1   '"f30String"
        _gccolf31String.VisibleIndex = -1   '"f31String"
        _gccolf32String.VisibleIndex = -1   '"f32String"
        _gccolf33String.VisibleIndex = -1   '"f33String"
        _gccolf34String.VisibleIndex = -1   '"f34String"
        _gccolf35String.VisibleIndex = -1   '"f35String"
        _gccolf36String.VisibleIndex = -1   '"f36String"
        _gccolf37String.VisibleIndex = -1   '"f37String"
        _gccolf38String.VisibleIndex = -1   '"f38String"
        _gccolf39String.VisibleIndex = -1   '"f39String"
        _gccolf40String.VisibleIndex = -1   '"f40String"
        _gccolf01TinyInt.VisibleIndex = -1   '"f01TinyInt"
        _gccolf01SmallInt.VisibleIndex = -1   '"f01SmallInt"
        _gccolf01Int.VisibleIndex = -1   '"f01Int"
        _gccolf02Int.VisibleIndex = -1   '"f02Int"
        _gccolf01Double.VisibleIndex = -1   '"f01Double52"
        _gccolf02Double.VisibleIndex = -1   '"f01Double62"
        _gccolf03Double.VisibleIndex = -1   '"f01Double162"
        _gccolf01Date.VisibleIndex = -1   '"f01Date"
        _gccolf02Date.VisibleIndex = -1   '"f02Date"
        _gccolf03Date.VisibleIndex = -1   '"f03Date"
    End Sub

    Private Sub _cm09ReadOnlyGridParent()
        _colk00Boolean.OptionsColumn.ReadOnly = True    '"k00Boolean"
        _colk00Int.OptionsColumn.ReadOnly = True    '"k00Int"
        _colk00Boolean01.OptionsColumn.ReadOnly = True  '"k00Boolean01"
        _colk00Int01.OptionsColumn.ReadOnly = True  '"k00Int01"

        _colk01String.OptionsColumn.ReadOnly = True    '"k01String"
        _colk02String.OptionsColumn.ReadOnly = True    '"k02String"
        _colk03String.OptionsColumn.ReadOnly = True    '"k03String"
        _colk04String.OptionsColumn.ReadOnly = True    '"k03String"
        _colk05String.OptionsColumn.ReadOnly = True    '"k03String"
        _colf01String.OptionsColumn.ReadOnly = True    '"f01String"
        _colf02String.OptionsColumn.ReadOnly = True    '"f02String"
        _colf03String.OptionsColumn.ReadOnly = True    '"f03String"
        _colf04String.OptionsColumn.ReadOnly = True    '"f04String"
        _colf05String.OptionsColumn.ReadOnly = True    '"f05String"
        _colf06String.OptionsColumn.ReadOnly = True    '"f06String"
        _colf07String.OptionsColumn.ReadOnly = True    '"f07String"
        _colf08String.OptionsColumn.ReadOnly = True    '"f08String"
        _colf09String.OptionsColumn.ReadOnly = True    '"f09String"
        _colf10String.OptionsColumn.ReadOnly = True    '"f10String"
        _colf11String.OptionsColumn.ReadOnly = True    '"f11String"
        _colf12String.OptionsColumn.ReadOnly = True    '"f12String"
        _colf13String.OptionsColumn.ReadOnly = True    '"f13String"
        _colf14String.OptionsColumn.ReadOnly = True    '"f14String"
        _colf15String.OptionsColumn.ReadOnly = True    '"f15String"
        _colf16String.OptionsColumn.ReadOnly = True    '"f16String"
        _colf17String.OptionsColumn.ReadOnly = True    '"f17String"
        _colf18String.OptionsColumn.ReadOnly = True    '"f18String"
        _colf19String.OptionsColumn.ReadOnly = True    '"f19String"
        _colf20String.OptionsColumn.ReadOnly = True    '"f20String"
        _colf21String.OptionsColumn.ReadOnly = True    '"f21String"
        _colf22String.OptionsColumn.ReadOnly = True    '"f22String"
        _colf23String.OptionsColumn.ReadOnly = True    '"f23String"
        _colf24String.OptionsColumn.ReadOnly = True    '"f24String"
        _colf25String.OptionsColumn.ReadOnly = True    '"f25String"
        _colf26String.OptionsColumn.ReadOnly = True    '"f26String"
        _colf27String.OptionsColumn.ReadOnly = True    '"f27String"
        _colf28String.OptionsColumn.ReadOnly = True    '"f28String"
        _colf29String.OptionsColumn.ReadOnly = True    '"f29String"
        _colf30String.OptionsColumn.ReadOnly = True    '"f30String"
        _colf31String.OptionsColumn.ReadOnly = True    '"f31String"
        _colf32String.OptionsColumn.ReadOnly = True    '"f32String"
        _colf33String.OptionsColumn.ReadOnly = True    '"f33String"
        _colf34String.OptionsColumn.ReadOnly = True    '"f34String"
        _colf35String.OptionsColumn.ReadOnly = True    '"f35String"
        _colf36String.OptionsColumn.ReadOnly = True    '"f36String"
        _colf37String.OptionsColumn.ReadOnly = True    '"f37String"
        _colf38String.OptionsColumn.ReadOnly = True    '"f38String"
        _colf39String.OptionsColumn.ReadOnly = True    '"f39String"
        _colf40String.OptionsColumn.ReadOnly = True    '"f40String"
        _colf01Memo.OptionsColumn.ReadOnly = True    '"f01Memo"
        _colf01TinyInt.OptionsColumn.ReadOnly = True    '"f01TinyInt"
        _colf01SmallInt.OptionsColumn.ReadOnly = True    '"f01SmallInt"
        _colf01Int.OptionsColumn.ReadOnly = True    '"f01Int"
        _colf02Int.OptionsColumn.ReadOnly = True    '"f01Int"
        _colf01Double.OptionsColumn.ReadOnly = True    '"f01Double52"
        _colf02Double.OptionsColumn.ReadOnly = True    '"f01Double62"
        _colf03Double.OptionsColumn.ReadOnly = True    '"f01Double162"
        _colf01Date.OptionsColumn.ReadOnly = True    '"f01Date"
        _colf02Date.OptionsColumn.ReadOnly = True    '"f02Date"
        _colf03Date.OptionsColumn.ReadOnly = True    '"f03Date"
        _colf04Date.OptionsColumn.ReadOnly = True    '"f04Date"
        _colf01Datetime.OptionsColumn.ReadOnly = True    '"f03Date"
    End Sub

    Private Sub _cm09ReadOnlyGridChild()
        _chcolk00Boolean.OptionsColumn.ReadOnly = True    '"k00Boolean"
        _chcolk00Int.OptionsColumn.ReadOnly = True    '"k00Int"

        _chcolk01String.OptionsColumn.ReadOnly = True    '"k01String"
        _chcolk02String.OptionsColumn.ReadOnly = True    '"k02String"
        _chcolk03String.OptionsColumn.ReadOnly = True    '"k03String"
        _chcolf01String.OptionsColumn.ReadOnly = True    '"f01String"
        _chcolf02String.OptionsColumn.ReadOnly = True    '"f02String"
        _chcolf03String.OptionsColumn.ReadOnly = True    '"f03String"
        _chcolf04String.OptionsColumn.ReadOnly = True    '"f04String"
        _chcolf05String.OptionsColumn.ReadOnly = True    '"f05String"
        _chcolf06String.OptionsColumn.ReadOnly = True    '"f06String"
        _chcolf07String.OptionsColumn.ReadOnly = True    '"f07String"
        _chcolf08String.OptionsColumn.ReadOnly = True    '"f08String"
        _chcolf09String.OptionsColumn.ReadOnly = True    '"f09String"
        _chcolf10String.OptionsColumn.ReadOnly = True    '"f10String"
        _chcolf11String.OptionsColumn.ReadOnly = True    '"f11String"
        _chcolf12String.OptionsColumn.ReadOnly = True    '"f12String"
        _chcolf13String.OptionsColumn.ReadOnly = True    '"f13String"
        _chcolf14String.OptionsColumn.ReadOnly = True    '"f14String"
        _chcolf15String.OptionsColumn.ReadOnly = True    '"f15String"
        _chcolf16String.OptionsColumn.ReadOnly = True    '"f16String"
        _chcolf17String.OptionsColumn.ReadOnly = True    '"f17String"
        _chcolf18String.OptionsColumn.ReadOnly = True    '"f18String"
        _chcolf19String.OptionsColumn.ReadOnly = True    '"f19String"
        _chcolf20String.OptionsColumn.ReadOnly = True    '"f20String"
        _chcolf21String.OptionsColumn.ReadOnly = True    '"f21String"
        _chcolf22String.OptionsColumn.ReadOnly = True    '"f22String"
        _chcolf23String.OptionsColumn.ReadOnly = True    '"f23String"
        _chcolf24String.OptionsColumn.ReadOnly = True    '"f24String"
        _chcolf25String.OptionsColumn.ReadOnly = True    '"f25String"
        _chcolf26String.OptionsColumn.ReadOnly = True    '"f26String"
        _chcolf27String.OptionsColumn.ReadOnly = True    '"f27String"
        _chcolf28String.OptionsColumn.ReadOnly = True    '"f28String"
        _chcolf29String.OptionsColumn.ReadOnly = True    '"f29String"
        _chcolf30String.OptionsColumn.ReadOnly = True    '"f30String"
        _chcolf31String.OptionsColumn.ReadOnly = True    '"f31String"
        _chcolf32String.OptionsColumn.ReadOnly = True    '"f32String"
        _chcolf33String.OptionsColumn.ReadOnly = True    '"f33String"
        _chcolf34String.OptionsColumn.ReadOnly = True    '"f34String"
        _chcolf35String.OptionsColumn.ReadOnly = True    '"f35String"
        _chcolf36String.OptionsColumn.ReadOnly = True    '"f36String"
        _chcolf37String.OptionsColumn.ReadOnly = True    '"f37String"
        _chcolf38String.OptionsColumn.ReadOnly = True    '"f38String"
        _chcolf39String.OptionsColumn.ReadOnly = True    '"f39String"
        _chcolf40String.OptionsColumn.ReadOnly = True    '"f40String"
        _chcolf01TinyInt.OptionsColumn.ReadOnly = True    '"f01TinyInt"
        _chcolf01SmallInt.OptionsColumn.ReadOnly = True    '"f01SmallInt"
        _chcolf01Int.OptionsColumn.ReadOnly = True    '"f01Int"
        _chcolf02Int.OptionsColumn.ReadOnly = True    '"f02Int"
        _chcolf03Int.OptionsColumn.ReadOnly = True    '"f03Int"
        _chcolf01Double.OptionsColumn.ReadOnly = True    '"f01Double52"
        _chcolf02Double.OptionsColumn.ReadOnly = True    '"f01Double62"
        _chcolf03Double.OptionsColumn.ReadOnly = True    '"f01Double162"
        _chcolf01Date.OptionsColumn.ReadOnly = True    '"f01Date"
        _chcolf02Date.OptionsColumn.ReadOnly = True    '"f02Date"
        _chcolf03Date.OptionsColumn.ReadOnly = True    '"f03Date"
        _chcolf01Datetime.OptionsColumn.ReadOnly = True    '"f03Date"
    End Sub

    Private Sub _cm09ReadOnlyGridGrandChild()
        _gccolk00Boolean.OptionsColumn.ReadOnly = True    '"k00Boolean"
        _gccolk00Int.OptionsColumn.ReadOnly = True    '"k00Int"

        _gccolk01String.OptionsColumn.ReadOnly = True    '"k01String"
        _gccolk02String.OptionsColumn.ReadOnly = True    '"k02String"
        _gccolk03String.OptionsColumn.ReadOnly = True    '"k03String"
        _gccolf01String.OptionsColumn.ReadOnly = True    '"f01String"
        _gccolf02String.OptionsColumn.ReadOnly = True    '"f02String"
        _gccolf03String.OptionsColumn.ReadOnly = True    '"f03String"
        _gccolf04String.OptionsColumn.ReadOnly = True    '"f04String"
        _gccolf05String.OptionsColumn.ReadOnly = True    '"f05String"
        _gccolf06String.OptionsColumn.ReadOnly = True    '"f06String"
        _gccolf07String.OptionsColumn.ReadOnly = True    '"f07String"
        _gccolf08String.OptionsColumn.ReadOnly = True    '"f08String"
        _gccolf09String.OptionsColumn.ReadOnly = True    '"f09String"
        _gccolf10String.OptionsColumn.ReadOnly = True    '"f10String"
        _gccolf11String.OptionsColumn.ReadOnly = True    '"f11String"
        _gccolf12String.OptionsColumn.ReadOnly = True    '"f12String"
        _gccolf13String.OptionsColumn.ReadOnly = True    '"f13String"
        _gccolf14String.OptionsColumn.ReadOnly = True    '"f14String"
        _gccolf15String.OptionsColumn.ReadOnly = True    '"f15String"
        _gccolf16String.OptionsColumn.ReadOnly = True    '"f16String"
        _gccolf17String.OptionsColumn.ReadOnly = True    '"f17String"
        _gccolf18String.OptionsColumn.ReadOnly = True    '"f18String"
        _gccolf19String.OptionsColumn.ReadOnly = True    '"f19String"
        _gccolf20String.OptionsColumn.ReadOnly = True    '"f20String"
        _gccolf21String.OptionsColumn.ReadOnly = True    '"f21String"
        _gccolf22String.OptionsColumn.ReadOnly = True    '"f22String"
        _gccolf23String.OptionsColumn.ReadOnly = True    '"f23String"
        _gccolf24String.OptionsColumn.ReadOnly = True    '"f24String"
        _gccolf25String.OptionsColumn.ReadOnly = True    '"f25String"
        _gccolf26String.OptionsColumn.ReadOnly = True    '"f26String"
        _gccolf27String.OptionsColumn.ReadOnly = True    '"f27String"
        _gccolf28String.OptionsColumn.ReadOnly = True    '"f28String"
        _gccolf29String.OptionsColumn.ReadOnly = True    '"f29String"
        _gccolf30String.OptionsColumn.ReadOnly = True    '"f30String"
        _gccolf31String.OptionsColumn.ReadOnly = True    '"f31String"
        _gccolf32String.OptionsColumn.ReadOnly = True    '"f32String"
        _gccolf33String.OptionsColumn.ReadOnly = True    '"f33String"
        _gccolf34String.OptionsColumn.ReadOnly = True    '"f34String"
        _gccolf35String.OptionsColumn.ReadOnly = True    '"f35String"
        _gccolf36String.OptionsColumn.ReadOnly = True    '"f36String"
        _gccolf37String.OptionsColumn.ReadOnly = True    '"f37String"
        _gccolf38String.OptionsColumn.ReadOnly = True    '"f38String"
        _gccolf39String.OptionsColumn.ReadOnly = True    '"f39String"
        _gccolf40String.OptionsColumn.ReadOnly = True    '"f40String"
        _gccolf01TinyInt.OptionsColumn.ReadOnly = True    '"f01TinyInt"
        _gccolf01SmallInt.OptionsColumn.ReadOnly = True    '"f01SmallInt"
        _gccolf01Int.OptionsColumn.ReadOnly = True    '"f01Int"
        _gccolf02Int.OptionsColumn.ReadOnly = True    '"f02Int"
        _gccolf01Double.OptionsColumn.ReadOnly = True    '"f01Double52"
        _gccolf02Double.OptionsColumn.ReadOnly = True    '"f01Double62"
        _gccolf03Double.OptionsColumn.ReadOnly = True    '"f01Double162"
        _gccolf01Date.OptionsColumn.ReadOnly = True    '"f01Date"
        _gccolf02Date.OptionsColumn.ReadOnly = True    '"f02Date"
        _gccolf03Date.OptionsColumn.ReadOnly = True    '"f03Date"
    End Sub

    Private Sub _cm10PropertiesGridParentChildONTarget()
        'OFF
        _cm07InitVisibilityOFFParent()
        _cm07InitVisibilityOFFChild()
        _cm07InitVisibilityOFFGrandChild()

        _cm08InitVisibilityIndexOFFParent()
        _cm08InitVisibilityIndexOFFChild()
        _cm08InitVisibilityIndexOFFGrandChild()

        'ON
        '_mp01SettingVisibilityON()
        '_mp02SettingColumnCaption()
        '_mp03SettingLainLainColumn()

    End Sub

#End Region

#Region "private - method non grid"

    Private Function _pmInitRepoNEXTProcess() As repoWS05Master
        Cursor = Cursors.WaitCursor

        Using objMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtMasterProses = objMaster.__pb24G301GetDataNextProses()
        End Using

        _rscolNEXTProses = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtMasterProses,
                                                    ._prop_02TargetMaster = repoWS05Master._TargetMaster._07NEXTPROSES}
        _rscolNEXTProses._01WSNasaBindingDataSource()

        Cursor = Cursors.Default

        Return _rscolNEXTProses
    End Function

    Private Sub _pmInitRepoPickerEkspedisi()
        Cursor = Cursors.WaitCursor

        Using objMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtPicker = objMaster.__pb02GetDataTable21TargetWarehouseByUser("5040", "50403")
            pdtEkspedisi = objMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("COURIER")
        End Using

        _rscolPicker = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtPicker,
                                                ._prop_02TargetMaster = repoWS05Master._TargetMaster._08PICKER}
        _rscolPicker._01WSNasaBindingDataSource()

        _rscolEkspedisi = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtEkspedisi,
                                                   ._prop_02TargetMaster = repoWS05Master._TargetMaster._03COURIER}
        _rscolEkspedisi._01WSNasaBindingDataSource()

        Cursor = Cursors.Default
    End Sub

    Private Function _pmCreateNoDocPKBOutbound(ByVal prmcTargetPKBOutbound As String) As String
        Dim pcIDNoDoc As String = ""

        Select Case prmcTargetPKBOutbound
            Case "5051"          'Picking 
                pcIDNoDoc = "WSPICKING"

            Case "505012"        'Airbill
                pcIDNoDoc = "WSAIRBILL"

            Case "505013"        'Confirm Pickup by Ekspedisi'
                pcIDNoDoc = "WSPICKUP"

            Case "505014"        'Confirm Delivered by Ekspedisi'
                pcIDNoDoc = "WSDLVEKSPEDISI"

            Case "505015"        'Confirm Delivered NON Ekspedisi'
                pcIDNoDoc = "WSDLVNONEKSPEDISI"
        End Select

        Cursor = Cursors.WaitCursor

        Dim pcNoDokumen As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = pcIDNoDoc}
            pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()
        End Using

        Cursor = Cursors.Default

        Return pcNoDokumen
    End Function


#End Region

#Region "*** EVENT - CONTROL GRID ***"

    Private Sub _rscolk00Boolean_CheckedChanged(sender As Object, e As EventArgs) Handles _rscolk00Boolean.CheckedChanged
        GridView1.PostEditor()
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
            e.Appearance.Font = New Font("Cambria", 8.25, FontStyle.Bold)
            e.Appearance.ForeColor = Color.DarkSlateGray
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            Dim _cFont As New Font("Segoe UI", 8.5, FontStyle.Bold)
            Dim _cFontColour As Brush = Brushes.DarkSlateGray

            e.Cache.DrawString("No.", _cFont, _cFontColour, e.Bounds, sf)
            e.Handled = True
        End If
    End Sub

    Private Sub GridView2_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView2.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle + 1 'e.RowHandle.ToString()
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)
            e.Appearance.DrawString(e.Cache, "No.", e.Bounds)
            e.Handled = True
        End If
    End Sub

    Private Sub GridView1_EndSorting(sender As Object, e As EventArgs) Handles GridView1.EndSorting
        ' Tunda eksekusi supaya GridView bisa proses event click editor dulu
        Me.BeginInvoke(Sub()
                           If GridView1.RowCount > 0 Then
                               ' Hanya scroll ke atas, tanpa mengubah focus row
                               GridView1.TopRowIndex = 0
                           End If
                       End Sub)
    End Sub




    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.RowHandle >= 0 Then
            If _prop02TargetGridParentChild = __TargetGridParentChild._Target505015PKBProsesSuratJalan Then

                If e.Column.FieldName = "f29String" And (Not String.IsNullOrEmpty(e.Value.ToString)) Then
                    Dim pcKodeProses As String = GridView1.GetFocusedRowCellValue("f29String").ToString

                    'Airway Bill by Ekspedisi
                    If pcKodeProses = "505012" Then
                        'Dim pcNoSJ As String = GridView1.GetFocusedRowCellValue("k02String").ToString

                        'Dim pdtParentRow() As DataRow
                        'Dim pdtChildRow() As DataRow
                        'pdtChildRow = Nothing

                        'Dim pdtChild As New DataTable
                        'Dim objChild As New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtChild}
                        'objChild.dtInitsTABLELARGE()

                        'pdtParentRow = _pdsDataSet.Tables("ParentTable").Select("k02String = '" & pcNoSJ & "'")
                        'For Each dtRowParent As Object In pdtParentRow
                        '    For Each dtRowMiddle As DataRow In dtRowParent.GetChildRows(_pcRelasiParentMiddle)
                        '        pdtChildRow = dtRowMiddle.GetChildRows(_pcRelasiMiddleChild)
                        '        For Each dtItem As Object In pdtChildRow
                        '            objChild.dtAddNewsTABLELARGE("", "", "",
                        '                    "", "", dtItem("f03String").ToString, dtItem("f04String").ToString, dtItem("f05String").ToString, "", "", "", "", "",
                        '                    "", "", "", "", "", "", "", "", "", "",
                        '                    "", "", "", dtItem("f24String").ToString, dtItem("f25String").ToString, "", "", "", "", "",
                        '                    "", "", dtItem("f33String").ToString, "", "", "", "", "", "", "",
                        '                    0, CInt(dtItem("f01SmallInt")), 0, CDbl(dtItem("f01Double")), 0.0, 0.0,
                        '                    "3000-01-01", "3000-01-01", "3000-01-01",
                        '                    "", "", "", "", "")
                        '        Next
                        '    Next
                        'Next

                        'Dim objProsesPKB As New ucWS24H201PROSESPKB With {._prop01User = _prop01User,
                        '                                                  ._prop02dtPARENT = pdtParentRow.CopyToDataTable,
                        '                                                  ._prop03dtCHILD = objChild.prop_dtsTABLELARGE,
                        '                                                  ._prop04dtPROSES = pdtMasterProses,
                        '                                                  ._prop05dtPICKER = pdtPicker,
                        '                                                  ._prop06dtEKSPEDISI = pdtEkspedisi,
                        '                                                  ._prop07gdParentChild = Me,
                        '                                                  ._prop08TargetProsesPKB = ucWS24H201PROSESPKB.TargetProsesPKB._01AirwayBill,
                        '                                                  .Dock = DockStyle.Fill}

                        'Dim objSize As New Size With {.Width = objProsesPKB.Size.Width,
                        '                              .Height = objProsesPKB.Size.Height + 100}

                        'Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                        '                                   .MinimizeBox = False, .ShowIcon = False,
                        '                                   .StartPosition = FormStartPosition.CenterScreen,
                        '                                   .Text = "create AirwayBill - " & _prop01User._UserProp01cTitle}
                        'frmModal.AddControl(objProsesPKB)

                        'frmModal.ShowDialog()
                    Else
                        GridView1.SetFocusedRowCellValue("f28String", GridView1.GetFocusedRowCellDisplayText("f29String"))
                    End If

                End If
            End If

            If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOutboundPKB Then
                If e.Column.FieldName = "f28String" And (Not String.IsNullOrEmpty(e.Value.ToString)) Then

                    Dim pcDisplayNextTransaksi As String = GridView1.GetFocusedRowCellDisplayText("f28String").ToString
                    GridView1.SetFocusedRowCellValue("f29String", pcDisplayNextTransaksi)

                    Dim pcKodeProses As String = GridView1.GetFocusedRowCellValue("f28String").ToString

                    'Picking
                    If pcKodeProses = "5051" Then
                        If GridView1.GetFocusedRowCellValue("f14String").ToString = "" Then
                            GridView1.SetFocusedRowCellValue("f14String", _prop03String)
                            GridView1.SetFocusedRowCellValue("f15String", _prop04String)

                            'Valen        : Kamis, 06 Februari 2025.
                            'Aggregate SJ : Cust,Brand,Kadar,CO/PO,TOP.

                            Dim pcKodeCust As String = GridView1.GetFocusedRowCellValue("f01String").ToString
                            Dim pcKodeTOP As String = GridView1.GetFocusedRowCellValue("f05String").ToString
                            Dim pcKodeBrand As String = GridView1.GetFocusedRowCellValue("f07String").ToString
                            Dim pcKodeKadar As String = GridView1.GetFocusedRowCellValue("f09String").ToString
                            Dim pcCOPO As String = GridView1.GetFocusedRowCellValue("f11String").ToString
                            ' Dim pcKAE As String = GridView1.GetFocusedRowCellValue("f04String").ToString

                            Dim pcFilter As String = " f01String = '" & pcKodeCust & "' and " &
                                                         " f05String = '" & pcKodeTOP & "' and " &
                                                         " f07String = '" & pcKodeBrand & "' and " &
                                                         " f09String = '" & pcKodeKadar & "' and " &
                                                         " f11String = '" & pcCOPO & "' and " &
                                                         " f26String = ''"
                            ' " f04String = '" & pcKAE & "' and " &
                            For Each dtRow As DataRow In _pdsDataSet.Tables("ParentTable").Select(pcFilter)
                                If (dtRow("f01String") = pcKodeCust And dtRow("f05String") = pcKodeTOP And
                                       dtRow("f07String") = pcKodeBrand And dtRow("f09String") = pcKodeKadar And
                                       dtRow("f11String") = pcCOPO) Then

                                    dtRow("f14String") = _prop03String
                                    dtRow("f15String") = _prop04String
                                    dtRow("f28String") = "5051"
                                    dtRow("f29String") = pcDisplayNextTransaksi

                                End If

                            Next
                            _pdsDataSet.Tables("ParentTable").AcceptChanges()

                            Me.Refresh()

                        End If

                        '5062	NEW PKB KAE
                        'Dim pcAsal As String = GridView1.GetFocusedRowCellValue("f24String").ToString
                        'If pcAsal = "5062" Then

                        'End If
                    Else
                        'Create SuratJalan
                        If pcKodeProses = "5052" Then
                            Dim pcKodeCust As String = GridView1.GetFocusedRowCellValue("f01String").ToString
                            Dim pcKodeTOP As String = GridView1.GetFocusedRowCellValue("f05String").ToString
                            Dim pcKodeBrand As String = GridView1.GetFocusedRowCellValue("f07String").ToString
                            Dim pcKodeKadar As String = GridView1.GetFocusedRowCellValue("f09String").ToString
                            Dim pcCOPO As String = GridView1.GetFocusedRowCellValue("f11String").ToString

                            Dim pcFilter As String = " f01String = '" & pcKodeCust & "' and " &
                                                         " f05String = '" & pcKodeTOP & "' and " &
                                                         " f07String = '" & pcKodeBrand & "' and " &
                                                         " f09String = '" & pcKodeKadar & "' and " &
                                                         " f11String = '" & pcCOPO & "' and " &
                                                         " f12String = '5051' "

                            Dim pdtParentRow() As DataRow
                            pdtParentRow = _pdsDataSet.Tables("ParentTable").Select(pcFilter)

                            Dim objCreateSuratJalan As New ucWS24H201PROSESPKB With {._prop01User = _prop01User,
                                                                                         ._prop02dtPARENT = pdtParentRow.CopyToDataTable,
                                                                                         ._prop07gdParentChild = Me,
                                                                                         ._prop08TargetProsesPKB = ucWS24H201PROSESPKB.TargetProsesPKB._02CreateSuratJalan,
                                                                                         .Dock = DockStyle.Fill}

                            Dim objSizeSJ As New Size With {.Width = objCreateSuratJalan.Size.Width,
                                                                    .Height = objCreateSuratJalan.Size.Height + 100}

                            Dim frmModalSJ As New XtraForm With {.Size = objSizeSJ, .MaximizeBox = False,
                                                                   .MinimizeBox = False, .ShowIcon = False,
                                                                   .StartPosition = FormStartPosition.CenterScreen,
                                                                   .Text = "Create SuratJalan - " & _prop01User._UserProp01cTitle}
                            frmModalSJ.AddControl(objCreateSuratJalan)

                            frmModalSJ.ShowDialog()
                        End If
                    End If


                End If

                If e.Column.FieldName = "f14String" And (Not String.IsNullOrEmpty(e.Value.ToString)) Then
                    Dim pcDisplayNextTransaksi As String = GridView1.GetFocusedRowCellDisplayText("f14String").ToString
                    GridView1.SetFocusedRowCellValue("f15String", pcDisplayNextTransaksi)
                End If

            End If


            ' ===================== UPDATED BY AGA =====================
            If _prop02TargetGridParentChild = __TargetGridParentChild._WSRptTrackingPKB AndAlso _prop02TargetGridParentChild = __TargetGridParentChild._WSRptTrackingSKU AndAlso
                    _prop02TargetGridParentChild = __TargetGridParentChild._Target505015PKBProsesSuratJalan Then
                If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                    GridView1.SetFocusedRowCellValue("k00Int", 1)
                End If
                GridView1.RefreshData()
            End If

            If e.Column.FieldName = "k00Boolean" Then
                Dim semuaChecked As Boolean = True

                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim row As DataRow = GridView1.GetDataRow(i)
                    If row IsNot Nothing AndAlso Not Convert.ToBoolean(row("k00Boolean")) Then
                        semuaChecked = False
                        Exit For
                    End If
                Next

                _isCheked = True
                _01lCheckSemua.Checked = semuaChecked
                _isCheked = False
            End If


            ' ===================== UPDATED BY AKIRRA - 25/04/21 =====================
            ' untuk proses kolom ceklis

            If e.Column.FieldName = "k00Boolean" _
                    And _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOrderManagement Then

                If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                    GridView1.SetFocusedRowCellValue("k00Int", 1)
                Else
                    GridView1.SetFocusedRowCellValue("k00Int", 0)
                End If

                GridView1.RefreshData()
            End If


            ' ======================================================================
            ' ===================== UPDATED BY AKIRRA - 25/05/15 =====================
            ' ======================================================================
            If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOrderManagement Then

                ' untuk ORDER MGMT, jika status NOT PENDING maka tidak dapat di CONFIRM lagi.
                ' dan jika status setelah PICKED / CANCEL / REJECT maka tidak dapat di CANCEL. hanya dpt melihat lognya.
                If e.Column.FieldName = "k00Boolean" Then
                    Dim canConfirm As Boolean = True
                    Dim canCancel As Boolean = True

                    Dim anySelected As Boolean = False

                    For i As Integer = 0 To GridView1.RowCount - 1
                        Dim isChecked As Boolean = Convert.ToBoolean(GridView1.GetRowCellValue(i, "k00Boolean"))
                        If isChecked Then
                            anySelected = True
                            Dim status As String = Convert.ToString(GridView1.GetRowCellValue(i, "f12String")).Trim().ToUpper()

                            If status <> "PENDING" Then
                                canConfirm = False
                            End If

                            Select Case status
                                Case "SURATJALAN", "AIRWAYBILL", "PICKED UP BY COURIER", "DELIVERED",
                     "REJECTED BY SALES", "CANCELLED"
                                    canConfirm = False
                                    canCancel = False
                            End Select
                        End If
                    Next

                    If Not anySelected Then
                        canConfirm = True
                        canCancel = True
                    End If

                    GridView1.RefreshData()

                    RaiseEvent isPENDING(canConfirm, canCancel)
                End If


                If e.Column.FieldName = "k00Boolean" Then
                    Dim canCreateChild As Boolean = False

                    Dim anyChecked As Boolean = False
                    Dim allHaveOST As Boolean = True

                    For i As Integer = 0 To GridView1.RowCount - 1
                        Dim isChecked As Boolean = Convert.ToBoolean(GridView1.GetRowCellValue(i, "k00Boolean"))
                        If isChecked Then
                            anyChecked = True
                            Dim hasOST As Boolean = Convert.ToBoolean(GridView1.GetRowCellValue(i, "k00Boolean01"))
                            If Not hasOST Then
                                allHaveOST = False
                                Exit For
                            End If
                        End If
                    Next

                    If anyChecked AndAlso allHaveOST Then
                        canCreateChild = True
                    End If

                    GridView1.RefreshData()
                    RaiseEvent hasOST(canCreateChild)
                End If
            End If


            ' ======================================================================

            GridView1.PostEditor()
            GridView1.RefreshData()
        End If

    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Select Case _prop02TargetGridParentChild
            Case __TargetGridParentChild._WSRptTrackingPKB, __TargetGridParentChild._WSRptTrackingSKU, __TargetGridParentChild._TargetDisplayCurrentStockSku
                Dim hasData As Boolean = False

                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim rowHandle As Integer = GridView1.GetVisibleRowHandle(i)
                    If GridView1.GetRowCellValue(rowHandle, "k00Boolean") = True Then
                        hasData = True
                        Exit For
                    End If
                Next

                If hasData Then
                    ' ===================== UPDATED BY AKIRRA - 25/07/04 =====================
                    ' prevent auto print while double-clicking on the grid.
                    Dim rsl As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(Me,
                        "Apakah Anda yakin ingin Print data grid ?",
                        "Print Confirmation | " & _prop01User._UserProp01cTitle,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)

                    If rsl = DialogResult.Yes Then
                        Dim originalFilter As String = GridView1.ActiveFilterString
                        GridView1.ActiveFilterString = "[k00Boolean] = True"

                        With GridView1.OptionsPrint
                            .PrintDetails = True
                            .ExpandAllDetails = True
                        End With

                        GridControl1.ShowPrintPreview()

                        GridView1.ActiveFilterString = originalFilter

                    End If
                    ' ========================================================================
                Else
                    XtraMessageBox.Show("Tidak ada data yang dapat dicetak.", "Print Information | " & _prop01User._UserProp01cTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

        End Select
    End Sub

    Public Event isPENDING(canConfirm As Boolean, canCancel As Boolean)
    Public Event hasOST(canCreateChild As Boolean)

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor

        If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOutboundPKB Then
            Dim pcValueFilter As String = GridView1.GetFocusedRowCellValue("f12String").ToString   'CurrentProses

            If GridView1.FocusedColumn.FieldName = "f28String" Then   'NextProses
                Dim objNextProses As __dlgFilterData = AddressOf _rscolNEXTProses.__ivkDisplayHasilFilter
                objNextProses.Invoke("f03String", pcValueFilter)
            End If

        Else
            If _prop02TargetGridParentChild = __TargetGridParentChild._Target505015PKBProsesSuratJalan Then
                Dim pcValueFilter As String = GridView1.GetFocusedRowCellValue("f12String").ToString   'CurrentProses

                If GridView1.FocusedColumn.FieldName = "f29String" Then   'NextProses
                    Dim objNextProses As __dlgFilterData = AddressOf _rscolNEXTProses.__ivkDisplayHasilFilter
                    objNextProses.Invoke("f03String", pcValueFilter)
                End If
            End If
        End If

    End Sub

    'Private Sub GridView1_ShowingEditor(sender As Object, e As CancelEventArgs) Handles GridView1.ShowingEditor
    '    If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOutboundPKB Then
    '        ''._colf12String.Visible = False       '"KodeTransaksiCurrent"
    '        ''._colf28String.Visible = False       '"KodeTransaksiNextProses"
    '        'Dim pcValueFilter As String = ""
    '        'Dim pcValueFilter01 As String = ""
    '        'If GridView1.FocusedColumn.FieldName = "f15String" Then '"PICKER"
    '        '    pcValueFilter = GridView1.GetFocusedRowCellValue("f12String").ToString
    '        '    If pcValueFilter = "5061" Then
    '        '        e.Cancel = False
    '        '    Else
    '        '        e.Cancel = True
    '        '    End If
    '        'End If

    '        'If GridView1.FocusedColumn.FieldName = "f17String" Then '"EKSPEDISI"
    '        '    pcValueFilter = GridView1.GetFocusedRowCellValue("f12String").ToString
    '        '    pcValueFilter01 = GridView1.GetFocusedRowCellValue("f28String").ToString
    '        '    If pcValueFilter = "5051" And pcValueFilter01 = "505012" Then
    '        '        e.Cancel = True
    '        '    Else
    '        '        e.Cancel = False
    '        '    End If
    '        'End If

    '        'If GridView1.FocusedColumn.FieldName = "f18String" Then '"RESI"
    '        '    pcValueFilter = GridView1.GetFocusedRowCellValue("f12String").ToString
    '        '    pcValueFilter01 = GridView1.GetFocusedRowCellValue("f28String").ToString
    '        '    If pcValueFilter = "5051" And pcValueFilter01 = "505012" Then
    '        '        e.Cancel = True
    '        '    Else
    '        '        e.Cancel = False
    '        '    End If
    '        'End If
    '    End If
    'End Sub

    'Private Sub GridView1_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEdit
    '    If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOutboundPKB Then
    '        Dim view As GridView = TryCast(sender, GridView)

    '        If e.Column.FieldName = "f29String" Then
    '            Dim pcValueFilter As String = view.GetRowCellValue(e.RowHandle, "f29String").ToString
    '            Select Case pcValueFilter
    '                Case "5051"        'Picking + Create SuratJalan'
    '                Case "505012"      'Airway Bill by Ekspedisi',
    '                Case "505013"      'Confirm Pickup by Ekspedisi'
    '                Case "505014"      'Confirm Delivered by Ekspedisi'
    '                Case "505015"      'Confirm Delivered NON Ekspedisi'
    '                    'e.RepositoryItem = _rscolNEXTProses
    '            End Select
    '        End If

    '    End If

    'End Sub

    'Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
    '    If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOutboundPKB Then
    '        Dim pcNoProses As String = GridView1.GetFocusedRowCellValue("f29String").ToString

    '        'Airway Bill by Ekspedisi
    '        If pcNoProses = "505012" Then

    '        Else
    '            MsgBox("Maaf ... Proses di TOLAK ..." & Chr(13) &
    '                   "Sebab hanya Current Proses 'AIRWAY BILL' yg diijinkan.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
    '        End If
    '    End If

    'End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.RowHandle >= 0 Then
            Dim View As GridView = TryCast(sender, GridView)
            Dim pcNoProses As String = ""

            ' ===================== UPDATED BY AKIRRA - 25/04/21 =====================
            ' mengubah background colour row yang di ceklis.

            If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))) And
                Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k00Boolean"))) Then

                Dim nCheck As Int16 = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))
                Dim bCheck As Double = (View.GetRowCellValue(e.RowHandle, View.Columns("k00Boolean")))

                e.Appearance.ForeColor = Color.Black
                If nCheck = 1 Or bCheck = True Then
                    e.Appearance.BackColor = Color.FromArgb(162, 210, 255)
                End If
            End If

            ' ======================================================================

            If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOutboundPKB Then
                Dim pcNoPickingList = View.GetRowCellValue(e.RowHandle, View.Columns("f26String"))
                pcNoProses = View.GetRowCellValue(e.RowHandle, View.Columns("f12String"))


                If pcNoPickingList IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(pcNoPickingList.ToString()) Then
                    If pcNoProses IsNot Nothing Then
                        Select Case pcNoProses.ToString()
                            Case "5061", "5062", "5063", "5064", "5065", "5066" ' NEW ORDER
                                e.Appearance.BackColor = Color.FromArgb(228, 217, 255)
                            Case "5051" ' Picking
                                e.Appearance.BackColor = Color.FromArgb(192, 166, 255)
                        End Select
                    End If
                End If

                e.Appearance.ForeColor = Color.Navy

            End If

            If _prop02TargetGridParentChild = __TargetGridParentChild._Target505015PKBProsesSuratJalan Then
                pcNoProses = View.GetRowCellValue(e.RowHandle, View.Columns("f12String"))

                Select Case pcNoProses

                    Case "5052"     'Create SuratJalan

                    Case "505012"   'Airway Bill by Ekspedisi
                        e.Appearance.BackColor = Color.LightGoldenrodYellow

                    Case "505013"   'Confirm Pickup by Ekspedisi
                        e.Appearance.BackColor = Color.LightGreen
                End Select

                ' Set warna teks default
                e.Appearance.ForeColor = Color.Navy
            End If

            ' ===================== CREATED BY AKIRRA - 25/06/17 =====================
            ' mengubah background colour row yang OUTSTANDING menjadi Red.
            If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayOrderManagement Then
                If e.RowHandle >= 0 Then
                    Dim isChecked As Boolean = False

                    If Not IsDBNull(View.GetRowCellValue(e.RowHandle, "k00Boolean01")) Then
                        isChecked = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, "k00Boolean01"))
                    End If

                    e.Appearance.ForeColor = Color.Black

                    If isChecked Then
                        e.Appearance.BackColor = Color.DarkSalmon
                    End If
                End If
            End If
            ' ========================================================================

        End If


    End Sub


    Private Sub GridView2_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If e.RowHandle >= 0 Then
            Dim View As GridView = TryCast(sender, GridView)
            If _prop02TargetGridParentChild = __TargetGridParentChild._MDTrackingPO Then
                If e.Column.FieldName = "f02Int" Then
                    Dim row As DataRowView = TryCast(View.GetRow(e.RowHandle), DataRowView)

                    If row IsNot Nothing AndAlso Not IsDBNull(row("f02Int")) Then
                        Dim f02Value As Integer = Convert.ToInt32(row("f02Int"))

                        If f02Value < 0 Then
                            e.Appearance.BackColor = Color.FromArgb(215, 74, 73)
                            e.Appearance.ForeColor = Color.White
                        End If
                    End If
                End If
            End If

        End If

    End Sub


    Private Sub GridView1_LostFocus(sender As Object, e As EventArgs) Handles GridView1.LostFocus
        GridView1.PostEditor()
        GridView1.RefreshData()
    End Sub

    Private Sub GridView2_LostFocus(sender As Object, e As EventArgs) Handles GridView2.LostFocus
        GridView2.PostEditor()
        GridView1.RefreshData()
    End Sub

    Private Sub GridView3_LostFocus(sender As Object, e As EventArgs) Handles GridView3.LostFocus
        GridView3.PostEditor()
        GridView1.RefreshData()
    End Sub

#End Region

#Region "public - method : Setting Grid ParentChild"
    Public Sub __pbWSGridParentChild01InitGrid()
        _cm01InitOthersGridParentChild()

        _cm02InitFieldGridParent()
        _cm02InitFieldGridChild()
        _cm02InitFieldGridGrandChild()

        _cm03InitRepoColumnParent()
        _cm03InitRepoColumnChild()
        _cm03InitRepoColumnGrandChild()

        _cm04InitColumnEditParent()
        _cm04InitColumnEditChild()


        _cm04InitColumnEditGrandChild()

        _cm06SettingColumnSummaryParent()
        _cm06SettingColumnSummaryChild()
        _cm06SettingColumnSummaryGrandChild()

        'agar waktu pertama kali display, kosong... tanpa header kolom
        _cm07InitVisibilityOFFParent()
        _cm07InitVisibilityOFFChild()
        _cm07InitVisibilityOFFGrandChild()

        _cm08InitVisibilityIndexOFFParent()
        _cm08InitVisibilityIndexOFFChild()
        _cm08InitVisibilityIndexOFFGrandChild()

        _cm09ReadOnlyGridParent()
        _cm09ReadOnlyGridChild()
        _cm09ReadOnlyGridGrandChild()
    End Sub

    Public Sub __pbWSGridParentChild02Clear()
        GridControl1.DataSource = Nothing
        GridControl1.Refresh()
    End Sub


    Public Sub __pbWSGridParentChild03Display(Optional ByVal prmcNomorProses As String = "", Optional ByVal prmc01String As String = "")
        _cm10PropertiesGridParentChildONTarget()

        Select Case _prop02TargetGridParentChild
            Case __TargetGridParentChild._TargetDisplayOutboundPKB
                _cm24SettingWSGridPKB(prmcNomorProses)
                _cm24DisplayWSGridPKB(prmcNomorProses)

            Case __TargetGridParentChild._Target505015PKBProsesSuratJalan
                _cm505015SettingWSGridPKBProsesSuratJalan()
                _cm505015DisplayWSGridPKBProsesSuratJalan()

            Case __TargetGridParentChild._WSRptTrackingSKU
                _cm41SettingWSGridTrackingSKU()
                _cm41DisplayWSGridTrackingSKU()

            Case __TargetGridParentChild._WSRptTrackingPKB
                _cm42SettingWSGridTrackingPKB()
                _cm42DisplayWSGridTrackingPKB()

            Case __TargetGridParentChild._MDTrackingPO
                _cm50SettingMDGridTrackingPO()
                _cm50DisplayMDGridTrackingPO()

            Case __TargetGridParentChild._TargetDisplayOrderManagement
                _cm01SettingWSGridOrderManagement()
                _cm01DisplayWSGridOrderManagement()

            Case __TargetGridParentChild._TargetDisplayOrderManagementPcode
                _cm02SettingWSGridOrderManagementPcode()
                _cm02DisplayWSGridOrderManagementPcode()

            Case __TargetGridParentChild._TargetDisplayCurrentStockSku
                _cm03SettingWSGridCurrentStockSku()
                _cm03DisplayWSGridCurrentStockSku()

        End Select

        ' ===================== UPDATED BY AKIRRA - 25/04/30 =====================
        ' agar ketika merubah target, maka akan mereset filter untuk mencegah error filter.
        GridView1.RefreshData()
        GridView1.ActiveFilter.Clear()
        GridView1.SortInfo.Clear()

        GridView2.RefreshData()
        GridView2.ActiveFilter.Clear()
        GridView2.SortInfo.Clear()

        GridView3.RefreshData()
        GridView3.ActiveFilter.Clear()
        GridView3.SortInfo.Clear()
        ' ======================================================================

        ' ===================== UPDATED BY AKIRRA - 25/04/30 =====================
        ' agar lebar kolom lebih rapih (menyesuaikan konten).
        GridView1.BestFitColumns()
        GridView2.BestFitColumns()
        GridView3.BestFitColumns()
        ' ======================================================================

        'GridControl1.LevelTree.Nodes.Clear()
        'GridControl1.DataSource = Nothing
        'GridControl1.DataSource = pdsDataset.Tables(_prop04cNamaTableParent)

        'With GridControl1.LevelTree.Nodes
        '    .Add(_prop06cNamaRelasi, GridView2)
        'End With

        'Case __TargetGridParentChild._TargetPKBCustomer
        '    'display di remote dari client ucWS23LN01PKB

        'Case __TargetGridParentChild._TargetAPPROVEPKBMgrFIN,
        '     __TargetGridParentChild._TargetAPPROVEPKBMgrSLS
        '    __pvDisplayGridApprovePKB()

        'GridView1.OptionsView.ColumnAutoWidth = False
        'GridView2.OptionsView.ColumnAutoWidth = False

        'GridView1.BestFitColumns()
        'GridView2.BestFitColumns()
    End Sub

    'Public Sub __pbWSGrid03DisplayGrid()
    '    __pbWSGridParentChild03Display()

    '    GridControl1.DataSource = Nothing
    '    GridControl1.DataSource = _prop03pdtDataSourceGrid

    '    Me.Dock = DockStyle.Fill
    'End Sub

    Public Sub __pbWSGridParentChild04CreateSettingColumnWidth(ByVal prmcNamaFileTarget As String)
        Cursor = Cursors.WaitCursor

        Const pcNamaPath As String = "C:\NASA_MERSY"
        If Not Directory.Exists(pcNamaPath) Then
            Directory.CreateDirectory(pcNamaPath)
        End If

        Dim pcNamaFile As String = pcNamaPath & "\" & prmcNamaFileTarget & ".txt"
        If File.Exists(pcNamaFile) Then
            File.Delete(pcNamaFile)
        End If

        Dim fs As New FileStream(pcNamaFile, FileMode.Create, FileAccess.Write, FileShare.None)
        Dim _objstreamwriter As New StreamWriter(fs)
        With Me
            _objstreamwriter.WriteLine("Private Sub _wd240707Width" & prmcNamaFileTarget)
            _objstreamwriter.WriteLine("With _prop03Grid")
            _objstreamwriter.WriteLine("._colk00Boolean.Width = " + ._colk00Boolean.Width.ToString)
            _objstreamwriter.WriteLine("._colk00Int.Width = " + ._colk00Int.Width.ToString)
            _objstreamwriter.WriteLine("._colk00Boolean01.Width = " + ._colk00Boolean01.Width.ToString)
            _objstreamwriter.WriteLine("._colk00Int01.Width = " + ._colk00Int01.Width.ToString)
            _objstreamwriter.WriteLine("._colf01Memo.Width = " + ._colf01Memo.Width.ToString)
            _objstreamwriter.WriteLine("._colk01String.Width = " + ._colk01String.Width.ToString)
            _objstreamwriter.WriteLine("._colk02String.Width = " + ._colk02String.Width.ToString)
            _objstreamwriter.WriteLine("._colk03String.Width = " + ._colk03String.Width.ToString)
            _objstreamwriter.WriteLine("._colf01String.Width = " + ._colf01String.Width.ToString)
            _objstreamwriter.WriteLine("._colf02String.Width = " + ._colf02String.Width.ToString)
            _objstreamwriter.WriteLine("._colf03String.Width = " + ._colf03String.Width.ToString)
            _objstreamwriter.WriteLine("._colf04String.Width = " + ._colf04String.Width.ToString)
            _objstreamwriter.WriteLine("._colf05String.Width = " + ._colf05String.Width.ToString)
            _objstreamwriter.WriteLine("._colf06String.Width = " + ._colf06String.Width.ToString)
            _objstreamwriter.WriteLine("._colf07String.Width = " + ._colf07String.Width.ToString)
            _objstreamwriter.WriteLine("._colf08String.Width = " + ._colf08String.Width.ToString)
            _objstreamwriter.WriteLine("._colf09String.Width = " + ._colf09String.Width.ToString)
            _objstreamwriter.WriteLine("._colf10String.Width = " + ._colf10String.Width.ToString)
            _objstreamwriter.WriteLine("._colf11String.Width = " + ._colf11String.Width.ToString)
            _objstreamwriter.WriteLine("._colf12String.Width = " + ._colf12String.Width.ToString)
            _objstreamwriter.WriteLine("._colf13String.Width = " + ._colf13String.Width.ToString)
            _objstreamwriter.WriteLine("._colf14String.Width = " + ._colf14String.Width.ToString)
            _objstreamwriter.WriteLine("._colf15String.Width = " + ._colf15String.Width.ToString)
            _objstreamwriter.WriteLine("._colf16String.Width = " + ._colf16String.Width.ToString)
            _objstreamwriter.WriteLine("._colf17String.Width = " + ._colf17String.Width.ToString)
            _objstreamwriter.WriteLine("._colf18String.Width = " + ._colf18String.Width.ToString)
            _objstreamwriter.WriteLine("._colf19String.Width = " + ._colf19String.Width.ToString)
            _objstreamwriter.WriteLine("._colf20String.Width = " + ._colf20String.Width.ToString)
            _objstreamwriter.WriteLine("._colf21String.Width = " + ._colf21String.Width.ToString)
            _objstreamwriter.WriteLine("._colf22String.Width = " + ._colf22String.Width.ToString)
            _objstreamwriter.WriteLine("._colf23String.Width = " + ._colf23String.Width.ToString)
            _objstreamwriter.WriteLine("._colf24String.Width = " + ._colf24String.Width.ToString)
            _objstreamwriter.WriteLine("._colf25String.Width = " + ._colf25String.Width.ToString)
            _objstreamwriter.WriteLine("._colf26String.Width = " + ._colf26String.Width.ToString)
            _objstreamwriter.WriteLine("._colf27String.Width = " + ._colf27String.Width.ToString)
            _objstreamwriter.WriteLine("._colf28String.Width = " + ._colf28String.Width.ToString)
            _objstreamwriter.WriteLine("._colf29String.Width = " + ._colf29String.Width.ToString)
            _objstreamwriter.WriteLine("._colf30String.Width = " + ._colf30String.Width.ToString)
            _objstreamwriter.WriteLine("._colf31String.Width = " + ._colf31String.Width.ToString)
            _objstreamwriter.WriteLine("._colf32String.Width = " + ._colf32String.Width.ToString)
            _objstreamwriter.WriteLine("._colf33String.Width = " + ._colf33String.Width.ToString)
            _objstreamwriter.WriteLine("._colf34String.Width = " + ._colf34String.Width.ToString)
            _objstreamwriter.WriteLine("._colf35String.Width = " + ._colf35String.Width.ToString)
            _objstreamwriter.WriteLine("._colf36String.Width = " + ._colf36String.Width.ToString)
            _objstreamwriter.WriteLine("._colf37String.Width = " + ._colf37String.Width.ToString)
            _objstreamwriter.WriteLine("._colf38String.Width = " + ._colf38String.Width.ToString)
            _objstreamwriter.WriteLine("._colf39String.Width = " + ._colf39String.Width.ToString)
            _objstreamwriter.WriteLine("._colf40String.Width = " + ._colf40String.Width.ToString)
            _objstreamwriter.WriteLine("._colf01TinyInt.Width = " + ._colf01TinyInt.Width.ToString)
            _objstreamwriter.WriteLine("._colf01SmallInt.Width = " + ._colf01SmallInt.Width.ToString)
            _objstreamwriter.WriteLine("._colf01Int.Width = " + ._colf01Int.Width.ToString)
            _objstreamwriter.WriteLine("._colf01Double.Width = " + ._colf01Double.Width.ToString)
            _objstreamwriter.WriteLine("._colf02Double.Width = " + ._colf02Double.Width.ToString)
            _objstreamwriter.WriteLine("._colf03Double.Width = " + ._colf03Double.Width.ToString)
            _objstreamwriter.WriteLine("._colf01Date.Width = " + ._colf01Date.Width.ToString)
            _objstreamwriter.WriteLine("._colf02Date.Width = " + ._colf02Date.Width.ToString)
            _objstreamwriter.WriteLine("._colf03Date.Width = " + ._colf03Date.Width.ToString)

            _objstreamwriter.WriteLine("._chcolk00Boolean.Width = " + ._chcolk00Boolean.Width.ToString)
            _objstreamwriter.WriteLine("._chcolk00Int.Width = " + ._chcolk00Int.Width.ToString)
            _objstreamwriter.WriteLine("._chcolk01String.Width = " + ._chcolk01String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolk02String.Width = " + ._chcolk02String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolk03String.Width = " + ._chcolk03String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf01String.Width = " + ._chcolf01String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf02String.Width = " + ._chcolf02String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf03String.Width = " + ._chcolf03String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf04String.Width = " + ._chcolf04String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf05String.Width = " + ._chcolf05String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf06String.Width = " + ._chcolf06String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf07String.Width = " + ._chcolf07String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf08String.Width = " + ._chcolf08String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf09String.Width = " + ._chcolf09String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf10String.Width = " + ._chcolf10String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf11String.Width = " + ._chcolf11String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf12String.Width = " + ._chcolf12String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf13String.Width = " + ._chcolf13String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf14String.Width = " + ._chcolf14String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf15String.Width = " + ._chcolf15String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf16String.Width = " + ._chcolf16String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf17String.Width = " + ._chcolf17String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf18String.Width = " + ._chcolf18String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf19String.Width = " + ._chcolf19String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf20String.Width = " + ._chcolf20String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf21String.Width = " + ._chcolf21String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf22String.Width = " + ._chcolf22String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf23String.Width = " + ._chcolf23String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf24String.Width = " + ._chcolf24String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf25String.Width = " + ._chcolf25String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf26String.Width = " + ._chcolf26String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf27String.Width = " + ._chcolf27String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf28String.Width = " + ._chcolf28String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf29String.Width = " + ._chcolf29String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf30String.Width = " + ._chcolf30String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf31String.Width = " + ._chcolf31String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf32String.Width = " + ._chcolf32String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf33String.Width = " + ._chcolf33String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf34String.Width = " + ._chcolf34String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf35String.Width = " + ._chcolf35String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf36String.Width = " + ._chcolf36String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf37String.Width = " + ._chcolf37String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf38String.Width = " + ._chcolf38String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf39String.Width = " + ._chcolf39String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf40String.Width = " + ._chcolf40String.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf01TinyInt.Width = " + ._chcolf01TinyInt.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf01SmallInt.Width = " + ._chcolf01SmallInt.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf01Int.Width = " + ._chcolf01Int.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf01Double.Width = " + ._chcolf01Double.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf02Double.Width = " + ._chcolf02Double.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf03Double.Width = " + ._chcolf03Double.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf01Date.Width = " + ._chcolf01Date.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf02Date.Width = " + ._chcolf02Date.Width.ToString)
            _objstreamwriter.WriteLine("._chcolf03Date.Width = " + ._chcolf03Date.Width.ToString)

            _objstreamwriter.WriteLine("._gccolk00Boolean.Width = " + ._gccolk00Boolean.Width.ToString)
            _objstreamwriter.WriteLine("._gccolk00Int.Width = " + ._gccolk00Int.Width.ToString)
            _objstreamwriter.WriteLine("._gccolk01String.Width = " + ._gccolk01String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolk02String.Width = " + ._gccolk02String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolk03String.Width = " + ._gccolk03String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf01String.Width = " + ._gccolf01String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf02String.Width = " + ._gccolf02String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf03String.Width = " + ._gccolf03String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf04String.Width = " + ._gccolf04String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf05String.Width = " + ._gccolf05String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf06String.Width = " + ._gccolf06String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf07String.Width = " + ._gccolf07String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf08String.Width = " + ._gccolf08String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf09String.Width = " + ._gccolf09String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf10String.Width = " + ._gccolf10String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf11String.Width = " + ._gccolf11String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf12String.Width = " + ._gccolf12String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf13String.Width = " + ._gccolf13String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf14String.Width = " + ._gccolf14String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf15String.Width = " + ._gccolf15String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf16String.Width = " + ._gccolf16String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf17String.Width = " + ._gccolf17String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf18String.Width = " + ._gccolf18String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf19String.Width = " + ._gccolf19String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf20String.Width = " + ._gccolf20String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf21String.Width = " + ._gccolf21String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf22String.Width = " + ._gccolf22String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf23String.Width = " + ._gccolf23String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf24String.Width = " + ._gccolf24String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf25String.Width = " + ._gccolf25String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf26String.Width = " + ._gccolf26String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf27String.Width = " + ._gccolf27String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf28String.Width = " + ._gccolf28String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf29String.Width = " + ._gccolf29String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf30String.Width = " + ._gccolf30String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf31String.Width = " + ._gccolf31String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf32String.Width = " + ._gccolf32String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf33String.Width = " + ._gccolf33String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf34String.Width = " + ._gccolf34String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf35String.Width = " + ._gccolf35String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf36String.Width = " + ._gccolf36String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf37String.Width = " + ._gccolf37String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf38String.Width = " + ._gccolf38String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf39String.Width = " + ._gccolf39String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf40String.Width = " + ._gccolf40String.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf01TinyInt.Width = " + ._gccolf01TinyInt.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf01SmallInt.Width = " + ._gccolf01SmallInt.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf01Int.Width = " + ._gccolf01Int.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf01Double.Width = " + ._gccolf01Double.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf02Double.Width = " + ._gccolf02Double.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf03Double.Width = " + ._gccolf03Double.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf01Date.Width = " + ._gccolf01Date.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf02Date.Width = " + ._gccolf02Date.Width.ToString)
            _objstreamwriter.WriteLine("._gccolf03Date.Width = " + ._gccolf03Date.Width.ToString)

            _objstreamwriter.WriteLine("End With")
            _objstreamwriter.WriteLine("End Sub")
        End With

        _objstreamwriter.Close()
        fs.Close()

        Cursor = Cursors.Default
    End Sub


    Public Sub __pbWSGridVisibilityCheckSelectAll(Optional ByVal plShow As Boolean = True, Optional ByVal plActive As Boolean = False)
        _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        If plShow Then
            _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

        _01lCheckSemua.EditValue = plActive

    End Sub
#End Region

#Region "********** method private - UPDATE/CHANGE **********"
    Public Enum __TargetGridParentChild
        _TargetDisplayOutboundPKB = 0
        _Target505015PKBProsesSuratJalan = 505015
        _TargetDisplayOrderManagement = 1
        _TargetDisplayOrderManagementPcode = 2
        _TargetDisplayCurrentStockSku = 3
        _TargetDisplayCurrentStockPcode = 4

        _WSRptTrackingSKU = 41
        _WSRptTrackingPKB = 42
        '_TargetPKBCustomer = 0
        '_TargetAPPROVEPKBMgrFIN = 1
        '_TargetAPPROVEPKBMgrSLS = 2
        _MDTrackingPO = 50
    End Enum

#End Region

#Region "********** Setting Grid **********"

    Private Sub _cm41SettingWSGridTrackingSKU()
        Cursor = Cursors.WaitCursor

        Using objGrid As clsWSNasaSettingGridOutboundPKB = New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsTrackingSKU,
                                                                                                     ._prop02User = _prop01User,
                                                                                                     ._prop03GridParentChild = Me}
            objGrid.__pbSettingGridOutboundPKB()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm42SettingWSGridTrackingPKB()
        Cursor = Cursors.WaitCursor

        Using objGrid As clsWSNasaSettingGridOutboundPKB = New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsTrackingPKB,
                                                                                                     ._prop02User = _prop01User,
                                                                                                     ._prop03GridParentChild = Me}
            objGrid.__pbSettingGridOutboundPKB()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm50SettingMDGridTrackingPO()
        Cursor = Cursors.WaitCursor

        Using objGrid As clsWSNasaSettingGridOutboundPKB = New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._mdTrackingPO,
                                                                                                     ._prop02objUser = _prop01objUser,
                                                                                                     ._prop03GridParentChild = Me}
            objGrid.__pbSettingGridOutboundPKB()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm24SettingWSGridPKB(ByVal prmcNomorProses As String)
        Cursor = Cursors.WaitCursor

        'Using objMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
        '    pdtMasterProses = objMaster.__pb24G301GetDataNextProses()
        'End Using

        '_rscolNEXTProses = New repoWS05Master With {._prop_01dtWSNasaMaster = pdtMasterProses,
        '                                            ._prop_02TargetMaster = repoWS05Master._TargetMaster._07NEXTPROSES}
        '_rscolNEXTProses._01WSNasaBindingDataSource()

        _pmInitRepoPickerEkspedisi()

        Using objGrid As clsWSNasaSettingGridOutboundPKB = New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsOut01RefreshDisplayPKB,
                                                                                                     ._prop02User = _prop01User,
                                                                                                     ._prop03GridParentChild = Me,
                                                                                                     ._prop04RepoMaster = _pmInitRepoNEXTProcess(),
                                                                                                     ._prop05RepoMaster = _rscolPicker,
                                                                                                     ._prop06RepoMaster = _rscolEkspedisi,
                                                                                                     ._prop07cNomorProses = prmcNomorProses,
                                                                                                     ._prop08Progress = objProgressParent,
                                                                                                     ._prop09ProgressMiddle = objProgressMiddle}
            objGrid.__pbSettingGridOutboundPKB()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm505015SettingWSGridPKBProsesSuratJalan()
        Cursor = Cursors.WaitCursor

        _pmInitRepoPickerEkspedisi()

        Using objGrid As clsWSNasaSettingGridOutboundPKB = New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsOut505015PKBProsesSuratJalan,
                                                                                                     ._prop02User = _prop01User,
                                                                                                     ._prop03GridParentChild = Me,
                                                                                                     ._prop04RepoMaster = _pmInitRepoNEXTProcess(),
                                                                                                     ._prop05RepoMaster = _rscolPicker,
                                                                                                     ._prop06RepoMaster = _rscolEkspedisi}
            objGrid.__pbSettingGridOutboundPKB()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm01SettingWSGridOrderManagement()
        Cursor = Cursors.WaitCursor

        Using objGrid As clsWSNasaSettingGridDistribusiBarang = New clsWSNasaSettingGridDistribusiBarang With {._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSDIstibusiFGOrderManagement,
                                                                                                     ._prop02User = _prop01User,
                                                                                                     ._prop04GridParentChild = Me}
            objGrid.__pbSettingGridDistribusiFG()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm02SettingWSGridOrderManagementPcode()
        Cursor = Cursors.WaitCursor

        Using objgrid As clsWSNasaSettingGridDistribusiBarang = New clsWSNasaSettingGridDistribusiBarang With {._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSDIstibusiFGOrderManagementPcode,
                                                                                                     ._prop02User = _prop01User,
                                                                                                     ._prop04GridParentChild = Me}
            objgrid.__pbSettingGridDistribusiFG()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm03SettingWSGridCurrentStockSku()
        Cursor = Cursors.WaitCursor

        Using objgrid As clsWSNasaSettingReportGrid = New clsWSNasaSettingReportGrid With {._prop01cTargetGridWSReport = clsWSNasaSettingReportGrid.TargetGridWSReport._wsCurrentStockSku,
                                                                                                     ._prop03GridParentChild = Me}
            objgrid.__pbCallSettingReportGrid()
        End Using

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "********** Setting Display ParentChild Grid **********"

    Private Sub _cm24DisplayWSGridPKB(ByVal prmcNomorProses As String)
        Cursor = Cursors.WaitCursor

        Dim pcNomorAsalProses As String = _cm241GetNomorAsalProses(prmcNomorProses)
        Dim pcDataAsalProses As String = ""

        _pdsDataSet.Clear()
        _pdsDataSet.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsWSNasaSelectParamDataCollection
        objParamParent = New clsWSNasaSelectParamDataCollection

        Dim objParamMiddle As clsWSNasaSelectParamDataCollection
        objParamMiddle = New clsWSNasaSelectParamDataCollection

        Dim objParamChild As clsWSNasaSelectParamDataCollection
        objParamChild = New clsWSNasaSelectParamDataCollection

        Dim objConnWS As New clsWSNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnWS._pbNasaConnectDB01WSDirect(_prop01User._UserProp08TargetNetwork))

            objConn.Open()

            objParamParent._pb01AddNew(6, 0, 1, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ParentTable")
            End Using


            objParamMiddle._pb01AddNew(6, 0, 2, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamMiddle).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "MiddleTable")
            End Using


            objParamChild._pb01AddNew(6, 0, 3, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamChild).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ChildTable")
            End Using


            _pcRelasiParentMiddle = ""
            _pcRelasiParentMiddle = "Shipment Order"

            _pcRelasiMiddleChild = ""
            _pcRelasiMiddleChild = "StockKeepingUnit"


            Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
                                                                      New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("k02String")},
                                                                      New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("k03String")}, False)

            Dim objRelMiddleChild As DataRelation = New DataRelation(_pcRelasiMiddleChild,
                                                                      New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("f18String"), _pdsDataSet.Tables("MiddleTable").Columns("k03String"), _pdsDataSet.Tables("MiddleTable").Columns("k02String")},
                                                                      New DataColumn() {_pdsDataSet.Tables("ChildTable").Columns("f18String"), _pdsDataSet.Tables("ChildTable").Columns("k01String"), _pdsDataSet.Tables("ChildTable").Columns("k02String")}, False)
            ', _pdsDataSet.Tables("MiddleTable").Columns("f17String")
            ', _pdsDataSet.Tables("ChildTable").Columns("f17String")

            _pdsDataSet.Relations.Add(objRelParentMiddle)
            _pdsDataSet.Relations.Add(objRelMiddleChild)

            Dim detailLevel1 As New GridLevelNode()
            detailLevel1.LevelTemplate = GridView2
            detailLevel1.RelationName = _pcRelasiParentMiddle

            Dim detailLevel2 As New GridLevelNode()
            detailLevel2.LevelTemplate = GridView3
            detailLevel2.RelationName = _pcRelasiMiddleChild

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _pdsDataSet.Tables("ParentTable")

            detailLevel1.Nodes.Add(detailLevel2)
            GridControl1.LevelTree.Nodes.Add(detailLevel1)

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChild.Dispose()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm241GetNomorAsalProses(ByVal prmcNomorProses As String) As String
        Dim pcNomorAsalProses As String = ""
        Select Case prmcNomorProses
            Case "5051"    'Picking + Create SuratJalan'
                pcNomorAsalProses = ""

            Case "505015"  'Confirm Delivered NON Ekspedisi'
                pcNomorAsalProses = "5051"

            Case "505012"  'Airway Bill by Ekspedisi'
                pcNomorAsalProses = "5051"

            Case "505013"  'Confirm Pickup by Ekspedisi'
                pcNomorAsalProses = "505012"

            Case "505014"  'Confirm Delivered by Ekspedisi'
                pcNomorAsalProses = "505013"

            Case "100" 'All Process'
                pcNomorAsalProses = "100"

        End Select

        Return pcNomorAsalProses
    End Function

    Private Sub _cm41DisplayWSGridTrackingSKU()
        Cursor = Cursors.WaitCursor

        _pdsDataSet.Clear()
        _pdsDataSet.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsWSNasaSelectParamDataCollection
        objParamParent = New clsWSNasaSelectParamDataCollection

        Dim objParamMiddle As clsWSNasaSelectParamDataCollection
        objParamMiddle = New clsWSNasaSelectParamDataCollection

        'Dim objParamChild As clsWSNasaSelectParamDataCollection
        'objParamChild = New clsWSNasaSelectParamDataCollection

        Dim objConnWS As New clsWSNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnWS._pbNasaConnectDB01WSDirect(_prop01User._UserProp08TargetNetwork))

            objConn.Open()
            Dim paramString As String = If(String.IsNullOrEmpty(_prop03String), "", _prop03String)
            objParamParent._pb01AddNew(4, 109, 0, paramString, "", "", 0, 0, _prop01Date, _prop02Date)

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ParentTable")
            End Using

            objParamMiddle._pb01AddNew(4, 110, 0, paramString, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamMiddle).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "MiddleTable")
            End Using

            'objParamChild._pb01AddNew(6, 0, 12, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            'Using objCommand As New SqlCommand() With {.Connection = objConn,
            '                                           .CommandType = CommandType.StoredProcedure,
            '                                           .CommandText = "spWS100EXECSQLSELECT"}
            '    objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamChild).SqlDbType = SqlDbType.Structured

            '    _sqldataadapter = New SqlDataAdapter(objCommand)
            '    _sqldataadapter.Fill(_pdsDataSet, "ChildTable")
            'End Using

            _pcRelasiParentMiddle = ""
            _pcRelasiParentMiddle = "Details SKU"

            '_pcRelasiMiddleChild = ""
            '_pcRelasiMiddleChild = "Stock-Keeping-Units"

            Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
                                                                      New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("k03String")},
                                                                      New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("k03String")}, False)

            'Dim objRelMiddleChild As DataRelation = New DataRelation(_pcRelasiMiddleChild,
            '                                                          New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("f33String"), _pdsDataSet.Tables("MiddleTable").Columns("f03String"), _pdsDataSet.Tables("MiddleTable").Columns("f05String")},
            '                                                          New DataColumn() {_pdsDataSet.Tables("ChildTable").Columns("f33String"), _pdsDataSet.Tables("ChildTable").Columns("f03String"), _pdsDataSet.Tables("ChildTable").Columns("f05String")}, False)
            '', _pdsDataSet.Tables("MiddleTable").Columns("f17String")
            ', _pdsDataSet.Tables("ChildTable").Columns("f17String")

            _pdsDataSet.Relations.Add(objRelParentMiddle)
            '_pdsDataSet.Relations.Add(objRelMiddleChild)

            Dim detailLevel1 As New GridLevelNode()
            detailLevel1.LevelTemplate = GridView2
            detailLevel1.RelationName = _pcRelasiParentMiddle

            'Dim detailLevel2 As New GridLevelNode()
            'detailLevel2.LevelTemplate = GridView3
            'detailLevel2.RelationName = _pcRelasiMiddleChild

            GridControl1.DataSource = Nothing
            GridControl1.LevelTree.Nodes.Clear()
            GridControl1.DataSource = _pdsDataSet.Tables("ParentTable")

            'detailLevel1.Nodes.Add(detailLevel2)
            GridControl1.LevelTree.Nodes.Add(detailLevel1)

            objConn.Close()
        End Using

        objParamParent.Dispose()
        'objParamChild.Dispose()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm505015DisplayWSGridPKBProsesSuratJalan()
        Cursor = Cursors.WaitCursor

        _pdsDataSet.Clear()
        _pdsDataSet.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsWSNasaSelectParamDataCollection
        objParamParent = New clsWSNasaSelectParamDataCollection

        Dim objParamMiddle As clsWSNasaSelectParamDataCollection
        objParamMiddle = New clsWSNasaSelectParamDataCollection

        Dim objParamChild As clsWSNasaSelectParamDataCollection
        objParamChild = New clsWSNasaSelectParamDataCollection

        Dim objConnWS As New clsWSNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnWS._pbNasaConnectDB01WSDirect(_prop01User._UserProp08TargetNetwork))

            objConn.Open()

            objParamParent._pb01AddNew(6, 0, 10, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                    .CommandType = CommandType.StoredProcedure,
                                                    .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ParentTable")
            End Using

            objParamMiddle._pb01AddNew(6, 0, 11, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                    .CommandType = CommandType.StoredProcedure,
                                                    .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamMiddle).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "MiddleTable")
            End Using

            objParamChild._pb01AddNew(6, 0, 12, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                    .CommandType = CommandType.StoredProcedure,
                                                    .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamChild).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ChildTable")
            End Using

            _pcRelasiParentMiddle = ""
            _pcRelasiParentMiddle = "Perintah-Kirim-Barang"

            _pcRelasiMiddleChild = ""
            _pcRelasiMiddleChild = "Stock-Keeping-Units"

            Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
                                                                   New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("k02String"), _pdsDataSet.Tables("ParentTable").Columns("f04String")},
                                                                   New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("f33String"), _pdsDataSet.Tables("MiddleTable").Columns("f15String")}, False)

            Dim objRelMiddleChild As DataRelation = New DataRelation(_pcRelasiMiddleChild,
                                                                   New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("f33String"), _pdsDataSet.Tables("MiddleTable").Columns("f03String"), _pdsDataSet.Tables("MiddleTable").Columns("f05String")},
                                                                   New DataColumn() {_pdsDataSet.Tables("ChildTable").Columns("f33String"), _pdsDataSet.Tables("ChildTable").Columns("f03String"), _pdsDataSet.Tables("ChildTable").Columns("f05String")}, False)
            ', _pdsDataSet.Tables("MiddleTable").Columns("f17String")
            ', _pdsDataSet.Tables("ChildTable").Columns("f17String")

            _pdsDataSet.Relations.Add(objRelParentMiddle)
            _pdsDataSet.Relations.Add(objRelMiddleChild)

            Dim detailLevel1 As New GridLevelNode()
            detailLevel1.LevelTemplate = GridView2
            detailLevel1.RelationName = _pcRelasiParentMiddle

            Dim detailLevel2 As New GridLevelNode()
            detailLevel2.LevelTemplate = GridView3
            detailLevel2.RelationName = _pcRelasiMiddleChild

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _pdsDataSet.Tables("ParentTable")

            detailLevel1.Nodes.Add(detailLevel2)
            GridControl1.LevelTree.Nodes.Add(detailLevel1)

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChild.Dispose()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm42DisplayWSGridTrackingPKB()
        Cursor = Cursors.WaitCursor

        _pdsDataSet.Clear()
        _pdsDataSet.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsWSNasaSelectParamDataCollection
        objParamParent = New clsWSNasaSelectParamDataCollection

        Dim objParamMiddle As clsWSNasaSelectParamDataCollection
        objParamMiddle = New clsWSNasaSelectParamDataCollection


        Dim objConnWS As New clsWSNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnWS._pbNasaConnectDB01WSDirect(_prop01User._UserProp08TargetNetwork))

            objConn.Open()

            'MsgBox(_prop01Date)
            Dim paramString As String = If(String.IsNullOrEmpty(_prop03String), "", _prop03String)
            objParamParent._pb01AddNew(4, 111, 0, paramString, "", "", 0, 0, _prop01Date, _prop02Date)
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                    .CommandType = CommandType.StoredProcedure,
                                                    .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ParentTable")
            End Using

            objParamMiddle._pb01AddNew(4, 112, 0, paramString, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                    .CommandType = CommandType.StoredProcedure,
                                                    .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamMiddle).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "MiddleTable")
            End Using


            _pcRelasiParentMiddle = ""
            _pcRelasiParentMiddle = "Details"

            Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
                                                                   New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("k02String")},
                                                                   New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("k02String")}, False)



            _pdsDataSet.Relations.Add(objRelParentMiddle)

            Dim detailLevel1 As New GridLevelNode()
            detailLevel1.LevelTemplate = GridView2
            detailLevel1.RelationName = _pcRelasiParentMiddle

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _pdsDataSet.Tables("ParentTable")

            'detailLevel1.Nodes.Add(detailLevel2)
            GridControl1.LevelTree.Nodes.Add(detailLevel1)

            objConn.Close()
        End Using

        objParamParent.Dispose()
        'objParamChild.Dispose()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm50DisplayMDGridTrackingPO()
        Cursor = Cursors.WaitCursor

        _pdsDataSet.Clear()
        _pdsDataSet.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsWSNasaSelectParamDataCollection
        objParamParent = New clsWSNasaSelectParamDataCollection

        Dim objParamMiddle As clsWSNasaSelectParamDataCollection
        objParamMiddle = New clsWSNasaSelectParamDataCollection


        Dim objConnWS As New clsNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnWS._cm03NasaConnectionDBSBU(_prop01objUser._UserProp07TargetNetwork))

            objConn.Open()

            'MsgBox(_prop01Date)
            Dim paramString As String = If(String.IsNullOrEmpty(_prop03String), "", _prop03String)
            objParamParent._pb01AddNew(7, 0, 0, paramString, "", "", 0, 0, _prop01Date, _prop02Date)
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                    .CommandType = CommandType.StoredProcedure,
                                                    .CommandText = "spMDTransaksi"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ParentTable")
            End Using

            objParamMiddle._pb01AddNew(8, 0, 0, paramString, "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                    .CommandType = CommandType.StoredProcedure,
                                                    .CommandText = "spMDTransaksi"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamMiddle).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "MiddleTable")
            End Using


            _pcRelasiParentMiddle = ""
            _pcRelasiParentMiddle = "Details"

            Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
                                                                   New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("f25String")},
                                                                   New DataColumn() {_pdsDataSet.Tables("MiddleTable").Columns("k01String")}, False)



            _pdsDataSet.Relations.Add(objRelParentMiddle)

            Dim detailLevel1 As New GridLevelNode()
            detailLevel1.LevelTemplate = GridView2
            detailLevel1.RelationName = _pcRelasiParentMiddle

            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _pdsDataSet.Tables("ParentTable")

            'detailLevel1.Nodes.Add(detailLevel2)
            GridControl1.LevelTree.Nodes.Add(detailLevel1)

            objConn.Close()
        End Using

        objParamParent.Dispose()
        'objParamChild.Dispose()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm01DisplayWSGridOrderManagement()
        Cursor = Cursors.WaitCursor

        _pdsDataSet.Clear()
        _pdsDataSet.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsWSNasaSelectParamDataCollection
        objParamParent = New clsWSNasaSelectParamDataCollection

        Dim objParamChild As clsWSNasaSelectParamDataCollection
        objParamChild = New clsWSNasaSelectParamDataCollection

        Dim objConnWS As New clsWSNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnWS._pbNasaConnectDB01WSDirect(_prop01User._UserProp08TargetNetwork))

            objConn.Open()

            objParamParent._pb01AddNew(3, 0, 31, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                     .CommandType = CommandType.StoredProcedure,
                                                     .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ParentTable")
            End Using

            objParamChild._pb01AddNew(3, 0, 32, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                     .CommandType = CommandType.StoredProcedure,
                                                     .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamChild).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ChildTable")
            End Using

            _pcRelasiParentMiddle = ""
            _pcRelasiParentMiddle = "No.Order"

            Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
                                                                    New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("k03String")},
                                                                    New DataColumn() {_pdsDataSet.Tables("ChildTable").Columns("k03String")}, False)

            _pdsDataSet.Relations.Add(objRelParentMiddle)

            Dim detailLevel1 As New GridLevelNode()
            detailLevel1.LevelTemplate = GridView2
            detailLevel1.RelationName = _pcRelasiParentMiddle


            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _pdsDataSet.Tables("ParentTable")
            GridControl1.LevelTree.Nodes.Add(detailLevel1)

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChild.Dispose()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm02DisplayWSGridOrderManagementPcode()
        Cursor = Cursors.WaitCursor

        _pdsDataSet.Clear()
        _pdsDataSet.Relations.Clear()

        Dim _sqldataadapter As SqlDataAdapter

        Dim objParamParent As clsWSNasaSelectParamDataCollection
        objParamParent = New clsWSNasaSelectParamDataCollection

        Dim objParamChild As clsWSNasaSelectParamDataCollection
        objParamChild = New clsWSNasaSelectParamDataCollection

        Dim objConnWS As New clsWSNasaDatabaseConnection

        Using objConn As New SqlConnection(objConnWS._pbNasaConnectDB01WSDirect(_prop01User._UserProp08TargetNetwork))

            objConn.Open()

            objParamParent._pb01AddNew(3, 0, 33, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                     .CommandType = CommandType.StoredProcedure,
                                                     .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamParent).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ParentTable")
            End Using

            objParamChild._pb01AddNew(3, 0, 34, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                     .CommandType = CommandType.StoredProcedure,
                                                     .CommandText = "spWS100EXECSQLSELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", objParamChild).SqlDbType = SqlDbType.Structured

                _sqldataadapter = New SqlDataAdapter(objCommand)
                _sqldataadapter.Fill(_pdsDataSet, "ChildTable")
            End Using

            _pcRelasiParentMiddle = ""
            _pcRelasiParentMiddle = "ProductCode"

            Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
                                                                    New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("f01String")},
                                                                    New DataColumn() {_pdsDataSet.Tables("ChildTable").Columns("f01String")}, False)

            _pdsDataSet.Relations.Add(objRelParentMiddle)

            Dim detailLevel1 As New GridLevelNode()
            detailLevel1.LevelTemplate = GridView2
            detailLevel1.RelationName = _pcRelasiParentMiddle


            GridControl1.DataSource = Nothing
            GridControl1.DataSource = _pdsDataSet.Tables("ParentTable")
            GridControl1.LevelTree.Nodes.Add(detailLevel1)

            objConn.Close()
        End Using

        objParamParent.Dispose()
        objParamChild.Dispose()

        Cursor = Cursors.Default
    End Sub

    'Dim dtCopy As New DataTable

    Private Sub _cm03DisplayWSGridCurrentStockSku()
        Cursor = Cursors.WaitCursor

        ' ini sementara PARENT dulu yang ditampilkan, dilanjutkan saja utk menampilkan childnya.

        _pdsDataSet.Relations.Clear()
        If _pdsDataSet.Tables.Contains("Parent") Then
            _pdsDataSet.Tables.Remove("Parent")
        End If

        If _prop03pdtDataSourceGrid Is Nothing Then
            Exit Sub
        End If

        Dim dtCopy As DataTable = _prop03pdtDataSourceGrid.Copy()
        dtCopy.TableName = "Parent"
        _pdsDataSet.Tables.Add(dtCopy)

        _pcRelasiParentMiddle = ""

        GridControl1.LevelTree.Nodes.Clear()
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _pdsDataSet.Tables("Parent")
        'GridControl1.DataMember = "Parent"


        '_pdsDataSet.Relations.Clear()


        'dtCopy.TableName = "SPSELECTToTable_Copy" ' atau nama unik lainnya

        '_pdsDataSet.Tables.Add(_prop03pdtDataSourceGrid.Copy)

        'dtChild.TableName = "ChildTable"



        'Dim objRelParentMiddle As DataRelation = New DataRelation(_pcRelasiParentMiddle,
        '                                                        New DataColumn() {_pdsDataSet.Tables("ParentTable").Columns("k03String")},
        '                                                        New DataColumn() {_pdsDataSet.Tables("ChildTable").Columns("k03String")}, False)

        '_pdsDataSet.Relations.Add(objRelParentMiddle)

        'Dim rel As New DataRelation(_pcRelasiParentMiddle,
        '                _pdsDataSet.Tables("Parent").Columns("k03String"),
        '                _pdsDataSet.Tables("Child").Columns("k03String"))
        '_pdsDataSet.Relations.Add(rel)


        'GridControl1.DataMember = "Parent"

        'Dim detailLevel1 As New GridLevelNode()
        'detailLevel1.LevelTemplate = GridView2
        'detailLevel1.RelationName = _pcRelasiParentMiddle

        'GridControl1.LevelTree.Nodes.Add(detailLevel1)


        Cursor = Cursors.Default
    End Sub

#End Region

#Region "********** Public Proses ParentChild Grid **********"
    Public Delegate Function _dlgDataSKUPickingList(ByVal prmcString As String) As DataTable
    Public Delegate Sub _dlgPreparePickingList(ByVal prmcString As String, ByRef prmcInteger As Integer)
    Public Delegate Function _dlgUpdatePicking(ByVal prmcString As String) As Boolean
    Public Delegate Sub _dlgUpdatePicker(ByVal prmcString As String, ByVal prmcString As String)
    Public Delegate Sub _dlgUpdateAirwayBill(ByVal prmcString As String, ByVal prmcString As String, ByVal prmcString As String, ByVal prmcString As String)

    Private Function _ivk24UpdateProgressPickingBRJ_CHECK(ByVal prmcSKUPicking As String) As Boolean
        Dim plIsExistSKUdiGridParentChild As Boolean = False

        For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f15String <> '' ")
            For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
                    If childRow("k03String") = prmcSKUPicking Then
                        plIsExistSKUdiGridParentChild = True

                        Exit For
                    End If
                Next
            Next
        Next

        Return plIsExistSKUdiGridParentChild
    End Function

    Public Function _ivk24UpdateProgressPickingBRJ(ByVal prmcSKUPicking As String) As Boolean
        'f29String = KodeNextProses :>  "'5051','Picking + Create SuratJalan'"
        'f14String = "KodePICKER"
        'f15String = "PICKER"
        Dim plExist As Boolean = False

        If Not String.IsNullOrEmpty(prmcSKUPicking) Then
            Cursor = Cursors.WaitCursor

            If Not plExist Then

                Dim pcKodePicker As String = ""
                Dim pcNamaPicker As String = ""
                Dim pnJmlPickingAwal As Int32 = 0
                Dim pnJmlPickingAwalMiddle As Int32 = 0
                Dim plActionUpd As Boolean = False

                For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f15String <> '' ")
                    pcKodePicker = ""
                    pcNamaPicker = ""

                    If rowParent("f28String") = "5051" And rowParent("f15String") <> "" Then
                        pnJmlPickingAwal = CInt(rowParent("k00Int01"))

                        pcKodePicker = rowParent("f14String")
                        pcNamaPicker = rowParent("f15String")

                        For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                            If rowParent("k02String").ToString = dtrowMiddle("k03String").ToString Then
                                pnJmlPickingAwalMiddle = CInt(dtrowMiddle("k00Int01"))

                                For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
                                    If dtrowMiddle("f18String") = childRow("f18String") Then

                                        If CInt(dtrowMiddle("f01SmallInt")) >= (CInt(dtrowMiddle("k00Int01")) + CInt(childRow("f01SmallInt"))) Then
                                            If childRow("k03String") = prmcSKUPicking And childRow("k00Boolean") = False Then
                                                childRow("k00Boolean") = True
                                                childRow("k00Int") = 1
                                                childRow("f05String") = pcKodePicker
                                                childRow("f06String") = pcNamaPicker

                                                childRow.AcceptChanges()
                                                plActionUpd = True

                                                dtrowMiddle("k00Int") = CInt(dtrowMiddle("k00Int")) + CInt(childRow("f01SmallInt"))
                                                dtrowMiddle("f39String") = dtrowMiddle("k00Int").ToString + " of " + CInt(dtrowMiddle("f01SmallInt")).ToString

                                                dtrowMiddle("k00Int01") = CInt(dtrowMiddle("k00Int01")) + CInt(childRow("f01SmallInt"))
                                                dtrowMiddle("f01Int") = ((pnJmlPickingAwalMiddle + CInt(childRow("f01SmallInt"))) / CInt(dtrowMiddle("f01SmallInt"))) * 100
                                                dtrowMiddle.AcceptChanges()

                                                rowParent("k00Int01") = CInt(rowParent("k00Int01")) + CInt(childRow("f01SmallInt"))
                                                rowParent("f39String") = rowParent("k00Int01").ToString + " of " + CInt(rowParent("f01SmallInt")).ToString
                                                rowParent("f01Int") = ((pnJmlPickingAwal + CInt(childRow("f01SmallInt"))) / CInt(rowParent("f01SmallInt"))) * 100
                                                rowParent.AcceptChanges()

                                                Exit For
                                            End If
                                        Else

                                        End If
                                    End If
                                Next

                            End If

                            If plActionUpd Then
                                Exit For
                            End If
                        Next
                    End If

                    If plActionUpd Then
                        Exit For
                    End If
                Next
            End If

            Cursor = Cursors.Default
        End If

        Return plExist
    End Function

    Public Sub _ivk28SetPickingList(ByVal prmcNoPickingList As String, ByRef prmnJmlSKU As Integer)

        For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f26String = '" & prmcNoPickingList & "' and f14String <> '' ")
            If rowParent("f26String") = prmcNoPickingList And rowParent("f14String") <> "" Then
                rowParent("f28String") = "5051"

                prmnJmlSKU += rowParent("f01SmallInt")
            End If
        Next

    End Sub

    Public Function _cm28GetDataPrepareForPickingList(ByVal prmcPickingList As String) As DataTable
        Cursor = Cursors.WaitCursor

        Dim pdtDataSKU As New DataTable
        Dim objDataSKU As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtDataSKU}
        objDataSKU.dtInitsTABLETINY()

        For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f26String = '" & prmcPickingList & "' ")

            For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
                    objDataSKU.dtAddNewsTABLETINY(childRow("k01String"), childRow("k02String"), childRow("k03String"),
                                                  "", "", "", "", "",
                                                  0, childRow("f01SmallInt"), 0, childRow("f01Double"), 0.0, 0.0,
                                                  "3000-01-01", "3000-01-01", "3000-01-01",
                                                  "", "", "", "", "")
                Next


            Next
        Next

        Cursor = Cursors.Default

        Return objDataSKU.prop_dtsTABLETINY
    End Function


    Public Function _cm28GetDataProductCodeForPickingList(ByVal prmcPickingList As String) As DataTable
        Cursor = Cursors.WaitCursor

        Dim pdtDataSKU As New DataTable
        Dim objDataSKU As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtDataSKU}
        objDataSKU.dtInitsTABLETINY()

        For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f26String = '" & prmcPickingList & "' ")

            For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                objDataSKU.dtAddNewsTABLETINY(dtrowMiddle("k03String"), dtrowMiddle("k02String"), "",
                                              "", "", "", "", "",
                                              0, dtrowMiddle("f01SmallInt"), 0, dtrowMiddle("f01Double"), 0.0, 0.0,
                                              "3000-01-01", "3000-01-01", "3000-01-01",
                                              "", "", "", "", "")
            Next

        Next

        Cursor = Cursors.Default

        Return objDataSKU.prop_dtsTABLETINY
    End Function

    Public Sub __ivkUpdateAirwayBill(ByVal prmcNoPKB As String, ByVal prmcKodeEkspedisi As String, ByVal prmcNamaEkspedisi As String, ByVal prmcNoResi As String)
        For Each dtRow As DataRow In _pdsDataSet.Tables("ParentTable").Rows
            If dtRow("k02String").ToString = prmcNoPKB Then
                dtRow("f16String") = prmcKodeEkspedisi
                dtRow("f17String") = prmcNamaEkspedisi
                dtRow("f18String") = prmcNoResi

                Exit For
            End If
        Next
        _pdsDataSet.Tables("ParentTable").AcceptChanges()

        Me.Refresh()
    End Sub

    Public Sub __ivkUpdPickerBRJ(ByVal prmcKode As String, ByVal prmcNama As String)
        For Each dtRow As DataRow In _pdsDataSet.Tables("ParentTable").Rows
            If dtRow("f28String") = "5051" AndAlso dtRow("f26String") = "" Then    'Picking + Create SuratJalan'
                dtRow("f14String") = prmcKode
                dtRow("f15String") = prmcNama
            End If
        Next
        _pdsDataSet.Tables("ParentTable").AcceptChanges()

        Me.Refresh()
    End Sub

    'Public Sub _cm24GetDataPKBForSavePickingBRJ(ByRef objParent As clsWSNasaTemplateDataMediumPlus, ByRef objChild As clsWSNasaTemplateDataMediumPlus)
    '    Cursor = Cursors.WaitCursor

    '    Dim dvView24 As DataView = New DataView(_pdsDataSet.Tables("ParentTable"))
    '    With dvView24
    '        .Sort = [String].Empty
    '        .RowFilter = [String].Empty
    '    End With

    '    With dvView24
    '        .Sort = "f28String,f02String,f08String,f10String"
    '        .RowFilter = String.Format(" f28String = '5051' ")
    '        .RowStateFilter = DataViewRowState.CurrentRows
    '    End With

    '    Dim pdtParent As New DataTable
    '    pdtParent = dvView24.ToTable()

    '    If pdtParent.Rows.Count > 0 Then
    '        Dim pcKeyOLD As String = ""
    '        Dim pcKeyCurrent As String = ""
    '        Dim pcNoDocSJ As String = ""

    '        For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f15String <> '' ")

    '            If rowParent("f28String") = "5051" And rowParent("f15String") <> "" Then
    '                pcKeyCurrent = rowParent("f02String").ToString &
    '                                       rowParent("f08String").ToString &
    '                                       rowParent("f10String").ToString

    '                If pcKeyOLD <> pcKeyCurrent Then
    '                    pcNoDocSJ = ""
    '                    pcNoDocSJ = _pmCreateNoDocPKBOutbound("5051")
    '                End If

    '                If pcNoDocSJ <> "" Then
    '                    objParent.dtAddNewsTABLEMEDIUMPLUS("", rowParent("k02String"), pcNoDocSJ,
    '                                                                rowParent("f01String"), rowParent("f02String"), rowParent("f03String"), rowParent("f04String"), rowParent("f05String"), rowParent("f06String"), rowParent("f07String"), rowParent("f08String"), rowParent("f09String"), rowParent("f10String"),
    '                                                                rowParent("f11String"), rowParent("f12String"), rowParent("f13String"), rowParent("f14String"), rowParent("f15String"), rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), rowParent("f19String"), "",
    '                                                                "", "", "", rowParent("f24String"), rowParent("f25String"), "", pcNoDocSJ, rowParent("f28String"), rowParent("f29String"), "",
    '                                                                rowParent("f01TinyInt"), rowParent("f01SmallInt"), rowParent("k00Int01"), 0, 0,
    '                                                                rowParent("f01Double"), 0.0, 0.0, 0.0, 0.0,
    '                                                                "3000-01-01", rowParent("f02Date"), "3000-01-01", "3000-01-01", "3000-01-01",
    '                                                                Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                                                                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '                    For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
    '                        If rowParent("k02String").ToString = dtrowMiddle("k03String").ToString Then

    '                            For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
    '                                If dtrowMiddle("f18String") = childRow("f18String") And childRow("k00Boolean") = True Then
    '                                    objChild.dtAddNewsTABLEMEDIUMPLUS(childRow("k01String"), childRow("k02String"), childRow("k03String"),
    '                                                        childRow("f01String"), childRow("f02String"), childRow("f03String"), childRow("f04String"), childRow("f05String"), childRow("f06String"), childRow("f07String"), childRow("f08String"), childRow("f09String"), childRow("f10String"),
    '                                                        pcNoDocSJ, rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), rowParent("f24String"), rowParent("f25String"), rowParent("f12String"), rowParent("f13String"), rowParent("f05String"), rowParent("f06String"),
    '                                                        rowParent("f11String"), rowParent("f03String"), rowParent("f04String"), rowParent("f01String"), rowParent("f02String"), childRow("f20String"), childRow("f19String"), rowParent("f28String"), rowParent("f29String"), "",
    '                                                        childRow("f01TinyInt"), childRow("f01SmallInt"), 0, 0, 0,
    '                                                        childRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
    '                                                        "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
    '                                                        Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                                                        _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '                                End If
    '                            Next

    '                        End If
    '                    Next

    '                    pcKeyOLD = pcKeyCurrent
    '                End If
    '            End If

    '        Next

    '    End If

    '    Cursor = Cursors.Default
    'End Sub

    Public Sub _cm24GetDataPKBForSavePickingBRJ(ByRef objParent As clsWSNasaTemplateDataMediumPlus, ByRef objChild As clsWSNasaTemplateDataMediumPlus)
        Cursor = Cursors.WaitCursor

        Dim dvView24 As DataView = New DataView(_pdsDataSet.Tables("ParentTable"))
        With dvView24
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With dvView24
            .Sort = "f28String,f02String,f08String,f10String"
            .RowFilter = String.Format(" f28String = '5051' ")
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Dim pdtParent As New DataTable
        pdtParent = dvView24.ToTable()

        If pdtParent.Rows.Count > 0 Then
            Dim pcKeyOLD As String = ""
            Dim pcKeyCurrent As String = ""
            Dim pcNoDocSJ As String = ""

            For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f15String <> '' ")

                If rowParent("f28String") = "5051" And rowParent("f15String") <> "" Then
                    pcKeyCurrent = rowParent("f02String").ToString &
                                       rowParent("f08String").ToString &
                                       rowParent("f10String").ToString

                    If pcKeyOLD <> pcKeyCurrent Then
                        pcNoDocSJ = ""
                        pcNoDocSJ = _pmCreateNoDocPKBOutbound("5051")
                    End If

                    If pcNoDocSJ <> "" Then
                        ' Add parent data with progress information
                        objParent.dtAddNewsTABLEMEDIUMPLUS("", rowParent("k02String"), rowParent("f26String"),
                                                            rowParent("f01String"), rowParent("f02String"), rowParent("f03String"), rowParent("f04String"), rowParent("f05String"), rowParent("f06String"), rowParent("f07String"), rowParent("f08String"), rowParent("f09String"), rowParent("f10String"),
                                                            rowParent("f11String"), rowParent("f12String"), rowParent("f13String"), rowParent("f14String"), rowParent("f15String"), rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), rowParent("f19String"), rowParent("f39String"), ' Progress string (e.g., "50 of 100")
                                                            "", "", "", rowParent("f24String"), rowParent("f25String"), "", rowParent("f26String"), rowParent("f28String"), rowParent("f29String"), "",
                                                            rowParent("f01TinyInt"), rowParent("f01SmallInt"), rowParent("k00Int01"), rowParent("f01Int"), 0, ' Include progress percentage (f01Int)
                                                            rowParent("f01Double"), 0.0, 0.0, 0.0, 0.0,
                                                            "3000-01-01", rowParent("f02Date"), "3000-01-01", "3000-01-01", "3000-01-01",
                                                            Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                                            _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

                        For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                            If rowParent("k02String").ToString = dtrowMiddle("k03String").ToString Then

                                For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
                                    If dtrowMiddle("f18String") = childRow("f18String") And childRow("k00Boolean") = True Then
                                        ' Add child data with picking status
                                        objChild.dtAddNewsTABLEMEDIUMPLUS(childRow("k01String"), childRow("k02String"), childRow("k03String"),
                                                            childRow("f01String"), childRow("f02String"), childRow("f03String"), childRow("f04String"), childRow("f05String"), childRow("f06String"), childRow("f07String"), childRow("f08String"), childRow("f09String"), childRow("f10String"),
                                                            rowParent("f26String"), rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), rowParent("f24String"), rowParent("f25String"), rowParent("f12String"), rowParent("f13String"), rowParent("f05String"), rowParent("f06String"),
                                                            rowParent("f11String"), rowParent("f03String"), rowParent("f04String"), rowParent("f01String"), rowParent("f02String"), childRow("f20String"), childRow("f19String"), rowParent("f28String"), rowParent("f29String"), "",
                                                            childRow("f01TinyInt"), childRow("f01SmallInt"), childRow("k00Int"), 0, 0, ' Include picking status (k00Int)
                                                            childRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
                                                            "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                                                            Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                                            _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
                                    End If
                                Next

                            End If
                        Next

                        pcKeyOLD = pcKeyCurrent
                    End If
                End If
            Next
        End If

        Cursor = Cursors.Default
    End Sub

    Public Sub _cm24GetDataPKBForPickingList(ByRef objDataPickingList As DataTable, Optional ByVal plForProsesPickingList As Boolean = False)
        Dim pcNoPickingList As String = ""
        Dim pcCodeProses As String = ""
        Dim pcNamaProses As String = ""

        For Each dtRow As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f26String <> '' ")
            If dtRow("f28String") <> "" And dtRow("f29String") <> "" And dtRow("f26String") <> "" Then
                pcNoPickingList = dtRow("f26String")
                pcCodeProses = dtRow("f28String")
                pcNamaProses = dtRow("f29String")

                Exit For
            End If
        Next

        For Each dtRow As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f26String = '" & pcNoPickingList & "' ")
            dtRow("f28String") = pcCodeProses
            dtRow("f29String") = pcNamaProses
        Next
        _pdsDataSet.AcceptChanges()

        Dim dvView24 As DataView = New DataView(_pdsDataSet.Tables("ParentTable"))
        With dvView24
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With dvView24
            .RowFilter = String.Format(" f26String = '" & pcNoPickingList & "' ")
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        'If Not plForProsesPickingList Then
        '    With dvView24
        '        .Sort = "f28String,f02String,f08String,f10String"
        '        .RowFilter = String.Format(" f28String = '5051' ")
        '        .RowStateFilter = DataViewRowState.CurrentRows
        '    End With
        'Else
        '    With dvView24
        '        .RowFilter = String.Format(" f26String = '" & pcNoPickingList & "' ")
        '        .RowStateFilter = DataViewRowState.CurrentRows
        '    End With
        'End If

        Dim pdtParent As New DataTable
        pdtParent = dvView24.ToTable()

        If pdtParent.Rows.Count > 0 Then
            objDataPickingList = pdtParent

            For Each dtRow As DataRow In objDataPickingList.Rows
                dtRow("f28String") = pcCodeProses
                dtRow("f29String") = pcNamaProses
            Next
            objDataPickingList.AcceptChanges()

        End If
    End Sub

    Public Sub _cm25GetDataPKBForSaveExceptPickingAirwayBill(ByRef objParent As clsWSNasaTemplateDataMediumPlus, ByRef objChild As clsWSNasaTemplateDataMediumPlus)
        Cursor = Cursors.WaitCursor

        Dim dvView25 As DataView = New DataView(_pdsDataSet.Tables("ParentTable"))
        With dvView25
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With dvView25
            .Sort = "f28String,f02String,f08String,f10String"
            .RowFilter = String.Format("f28String <> '5051' and f28String <> '505012'")
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Dim pdtParent As New DataTable
        pdtParent = dvView25.ToTable()

        '"5051"   :> 'Picking + Create SuratJalan'
        '"505012" :> Airway Bill by Ekspedisi
        If pdtParent.Rows.Count > 0 Then
            Dim pcKeyOLD As String = ""
            Dim pcKeyCurrent As String = ""
            Dim pcNoDocument As String = ""

            For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select("f28String <> '5051' and f28String <> '505012'")
                If rowParent("f28String") <> "5051" And rowParent("f28String") <> "505012" Then
                    pcKeyCurrent = rowParent("f02String").ToString &
                                   rowParent("f08String").ToString &
                                   rowParent("f10String").ToString

                    If pcKeyOLD <> pcKeyCurrent Then
                        '"505013" - 'Confirm Pickup by Ekspedisi'
                        '"505014" - 'Confirm Delivered by Ekspedisi'
                        '"505015" - 'Confirm Delivered NON Ekspedisi'

                        pcNoDocument = ""
                        pcNoDocument = _pmCreateNoDocPKBOutbound(rowParent("f28String").ToString)
                    End If

                    If Not String.IsNullOrEmpty(pcNoDocument) Then
                        objParent.dtAddNewsTABLEMEDIUMPLUS("", rowParent("k02String"), rowParent("k03String"),
                                                        rowParent("f01String"), rowParent("f02String"), rowParent("f03String"), rowParent("f04String"), rowParent("f05String"), rowParent("f06String"), rowParent("f07String"), rowParent("f08String"), rowParent("f09String"), rowParent("f10String"),
                                                        rowParent("f11String"), rowParent("f12String"), rowParent("f13String"), rowParent("f14String"), rowParent("f15String"), rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), rowParent("f19String"), "",
                                                        "", "", "", rowParent("f24String"), rowParent("f25String"), "", pcNoDocument, rowParent("f28String"), rowParent("f29String"), "",
                                                        rowParent("f01TinyInt"), rowParent("f01SmallInt"), rowParent("k00Int01"), 0, 0,
                                                        rowParent("f01Double"), 0.0, 0.0, 0.0, 0.0,
                                                        "3000-01-01", rowParent("f02Date"), "3000-01-01", "3000-01-01", "3000-01-01",
                                                        Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                                        _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

                        For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                            If rowParent("k02String").ToString = dtrowMiddle("k03String").ToString Then

                                For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
                                    If dtrowMiddle("f18String") = childRow("f18String") Then
                                        objChild.dtAddNewsTABLEMEDIUMPLUS(childRow("k01String"), childRow("k02String"), childRow("k03String"),
                                                            childRow("f01String"), childRow("f02String"), childRow("f03String"), childRow("f04String"), childRow("f06String"), childRow("f05String"), childRow("f07String"), childRow("f08String"), childRow("f09String"), childRow("f10String"),
                                                            pcNoDocument, rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), rowParent("f24String"), rowParent("f25String"), rowParent("f12String"), rowParent("f13String"), rowParent("f05String"), rowParent("f06String"),
                                                            rowParent("f11String"), rowParent("f03String"), rowParent("f04String"), rowParent("f01String"), rowParent("f02String"), childRow("f20String"), childRow("f19String"), rowParent("f28String"), rowParent("f29String"), "",
                                                            childRow("f01TinyInt"), childRow("f01SmallInt"), 0, 0, 0,
                                                            childRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
                                                            "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                                                            Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                                            _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

                                    End If
                                Next

                            End If
                        Next

                        pcKeyOLD = pcKeyCurrent
                    End If

                End If

            Next

        End If

        Cursor = Cursors.Default
    End Sub

    'Public Sub _cm26GetDataPKBForPrintPicking(ByRef objParent As clsWSNasaTemplateDataTiny, ByRef objChild As clsWSNasaTemplateDataTiny)
    '    Cursor = Cursors.WaitCursor

    '    Dim dvView26 As DataView = New DataView(_pdsDataSet.Tables("ParentTable"))
    '    With dvView26
    '        .Sort = [String].Empty
    '        .RowFilter = [String].Empty
    '    End With
    'objParent.dtAddNewsTABLESMALL(
    'rowParent("k02String"), rowParent("f02String"), dtrowMiddle("k02String"),
    'dtrowMiddle("f01String"), dtrowMiddle("f02String"), dtrowMiddle("f03String"), dtrowMiddle("f04String"), dtrowMiddle("f05String"),
    'dtrowMiddle("f06String"), dtrowMiddle("f07String"), dtrowMiddle("f40String"), "", "",
    '0, rowParent("f01SmallInt"), 0, 0.0, 0.0, 0.0,
    '"3000-01-01", CDate(rowParent("f02Date")), "3000-01-01", "3000-01-01",
    '"", "", "", "", "")
    '    Dim pdtParent As New DataTable
    '    pdtParent = dvView26.ToTable()

    '    If pdtParent.Rows.Count > 0 Then
    '        Dim pcProductCode As String = ""
    '        Dim pcTgl As String = ""

    '        For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select(" f28String = '5051' and f15String <> '' ")

    '            If rowParent("f28String") = "5051" And rowParent("f15String") <> "" Then
    '                pcProductCode = ""

    '                For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
    '                    If rowParent("k02String").ToString = dtrowMiddle("k03String").ToString Then
    '                        pcProductCode = dtrowMiddle("k02String").ToString

    '                        For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
    '                            If dtrowMiddle("f18String") = childRow("f18String") Then 'And childRow("f07String") = "PKBSKU"

    '                                objChild.dtAddNewsTABLETINY(childRow("k01String"), childRow("k02String"), "",
    '                                                                 childRow("f01String"), "", "", "", childRow("k03String"),
    '                                                                 0, 0, childRow("f01SmallInt"), 0.0, 0.0, 0.0,
    '                                                                 "3000-01-01", "3000-01-01", "3000-01-01",
    '                                                                 "", "", "", "", "")

    '                            End If
    '                        Next

    '                    End If
    '                Next

    '                pcTgl = ""
    '                pcTgl = DateAndTime.Day(rowParent(("f02Date"))).ToString("00") & "-" &
    '                        DateAndTime.Month(rowParent(("f02Date"))).ToString("00") & "-" &
    '                        DateAndTime.Year(rowParent(("f02Date"))).ToString

    '                objParent.dtAddNewsTABLETINY(pcTgl, rowParent("k02String"), pcProductCode,
    '                                             rowParent("f15String"), rowParent("f02String"), rowParent("f08String"), rowParent("f10String"), "",
    '                                             0, rowParent("f01SmallInt"), 0, 0.0, 0.0, 0.0,
    '                                             "3000-01-01", CDate(rowParent("f02Date")), "3000-01-01",
    '                                             "", "", "", "", "")
    '            End If
    '        Next
    '    End If

    '    Cursor = Cursors.Default
    'End Sub

    Public Sub _cm26GetDataPKBForPrintPicking(ByRef objParent As clsWSNasaTemplateDataSmall) ',  'ByRef objChild As clsWSNasaTemplateDataTiny)
        Cursor = Cursors.WaitCursor

        Dim dvView26 As DataView = New DataView(_pdsDataSet.Tables("ParentTable"))
        With dvView26
            .Sort = String.Empty
            .RowFilter = String.Format("f28String = '5051' AND f15String <> ''")
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Dim pdtParent As DataTable = dvView26.ToTable()

        If pdtParent.Rows.Count > 0 Then
            For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select("f28String = '5051' AND f15String <> ''")

                If rowParent("f28String") = "5051" And rowParent("f15String") <> "" Then
                    ' Format tanggal
                    'Dim pcTgl As String = DateAndTime.Day(rowParent("f02Date")).ToString("00") & "-" &
                    '                  DateAndTime.Month(rowParent("f02Date")).ToString("00") & "-" &
                    '                  DateAndTime.Year(rowParent("f02Date")).ToString

                    ' Loop middle
                    For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                        If rowParent("k02String").ToString = dtrowMiddle("k03String").ToString Then
                            ' Dim pcProductCode As String = dtrowMiddle("k02String").ToString

                            objParent.dtAddNewsTABLESMALL(
                         rowParent("k02String"), rowParent("f02String"), dtrowMiddle("k02String"),
                         dtrowMiddle("f01String"), dtrowMiddle("f02String"), dtrowMiddle("f03String"), dtrowMiddle("f04String"), dtrowMiddle("f05String"),
                         dtrowMiddle("f06String"), dtrowMiddle("f07String"), dtrowMiddle("f40String"), "", "",
                         0, dtrowMiddle("f01SmallInt"), 0, 0.0, 0.0, 0.0,
                         "3000-01-01", CDate(rowParent("f02Date")), "3000-01-01", "3000-01-01",
                         "", "", "", "", "")

                            ' Loop child
                            'For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
                            '    If dtrowMiddle("f18String") = childRow("f18String") Then
                            '        objChild.dtAddNewsTABLETINY(
                            '        childRow("k01String"), childRow("k02String"), "",
                            '        childRow("f01String"), "", "", "", childRow("k03String"),
                            '        0, 0, childRow("f01SmallInt"), 0.0, 0.0, 0.0,
                            '        "3000-01-01", "3000-01-01", "3000-01-01",
                            '        "", "", "", "", "")
                            '    End If
                            'Next

                            ' Tambahkan data ke objParent per product code
                            'objParent.dtAddNewsTABLESMALL(
                            'pcTgl, rowParent("k02String"), pcProductCode,
                            'rowParent("f15String"), rowParent("f02String"), rowParent("f08String"), rowParent("f10String"), "",
                            'rowParent("f15String"), rowParent("f02String"), rowParent("f08String"), rowParent("f10String"), "",
                            '0, rowParent("f01SmallInt"), 0, 0.0, 0.0, 0.0,
                            '"3000-01-01", CDate(rowParent("f02Date")), "3000-01-01", "3000-01-01",
                            '"", "", "", "", "")
                        End If
                    Next
                End If
            Next
        End If

        Cursor = Cursors.Default
    End Sub

    Public Sub _cm26GetDataPKBForPrintSJ(ByRef objParent As clsWSNasaTemplateDataSmall) ',  'ByRef objChild As clsWSNasaTemplateDataTiny)
        Cursor = Cursors.WaitCursor

        Dim dvView26 As DataView = New DataView(_pdsDataSet.Tables("ParentTable"))
        With dvView26
            .Sort = String.Empty
            .RowFilter = String.Format("k00Boolean = True")
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Dim pdtParent As DataTable = dvView26.ToTable()

        If pdtParent.Rows.Count > 0 Then
            For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Select("k00Boolean = True")

                If rowParent("k00Boolean") = True Then
                    For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
                        For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
                            If rowParent("k02String").ToString = childRow("f33String").ToString Then

                                objParent.dtAddNewsTABLESMALL(
                                 childRow("f33String"), childRow("f03String"), childRow("f05String"),
                                 childRow("f01String"), childRow("f04String"), childRow("f07String"), childRow("f09String"), childRow("f10String"),
                                 childRow("f12String"), childRow("f14String"), childRow("f16String"), childRow("f18String"), childRow("f19String"),
                                 0, childRow("f01SmallInt"), 0, childRow("f01Double"), 0.0, 0.0,
                                 "3000-01-01", CDate(rowParent("f01Date")), "3000-01-01", "3000-01-01",
                                 "", "", "", "", "")
                            End If
                        Next
                    Next
                End If
            Next
        End If

        Cursor = Cursors.Default
    End Sub

    Public Sub _cm27GetDataPKBUntilDelivered(ByRef objParent As clsWSNasaTemplateDataMediumPlus, ByRef objChild As clsWSNasaTemplateDataMediumPlus)
        Dim pcNoDoc As String = ""
        Dim pcIDNoDoc As String = ""

        Dim pdtParentRow() As DataRow
        Dim pdtChildRow() As DataRow
        pdtChildRow = Nothing

        pdtParentRow = _pdsDataSet.Tables("ParentTable").Select("f29String in ('505013','505014','505015')")
        For Each dtRowParent As Object In pdtParentRow

            If pcIDNoDoc <> dtRowParent("f29String") Then
                pcNoDoc = ""
                pcNoDoc = _pmCreateNoDocPKBOutbound(dtRowParent("f29String"))
            End If

            objParent.dtAddNewsTABLEMEDIUMPLUS(pcNoDoc, dtRowParent("k02String"), "",
                         dtRowParent("f01String"), dtRowParent("f02String"), dtRowParent("f03String"), dtRowParent("f04String"), dtRowParent("f05String"), dtRowParent("f06String"), dtRowParent("f07String"), dtRowParent("f08String"), dtRowParent("f09String"), dtRowParent("f10String"),
                         dtRowParent("f11String"), dtRowParent("f12String"), dtRowParent("f13String"), dtRowParent("f14String"), dtRowParent("f15String"), dtRowParent("f16String"), "", dtRowParent("f18String"), "", dtRowParent("f20String"),
                         dtRowParent("f21String"), "", "", dtRowParent("f24String"), dtRowParent("f25String"), "", "", dtRowParent("f28String"), dtRowParent("f29String"), "",
                         0, dtRowParent("f01SmallInt"), 0, 0, 0,
                         dtRowParent("f01Double"), 0.0, 0.0, 0.0, 0.0,
                         "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                         "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                         _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            For Each dtRowMiddle As DataRow In dtRowParent.GetChildRows(_pcRelasiParentMiddle)
                pdtChildRow = dtRowMiddle.GetChildRows(_pcRelasiMiddleChild)
                For Each dtItem As Object In pdtChildRow
                    'objChild.dtAddNewsTABLEMEDIUMPLUS(pcNoDoc, dtItem("k01String"), "",
                    '     "", "", dtItem("k02String"), dtItem("f01String"), dtItem("k03String"), dtItem("f05String"), dtItem("f06String"), dtItem("f07String"), dtItem("f08String"), "",
                    '     "", dtRowParent("f05String"), dtRowParent("f06String"), dtRowParent("f11String"), "", "", "", "", "", "",
                    '     "", "", "", dtItem("f03String"), dtItem("f04String"), dtItem("f09String"), dtItem("f10String"), dtRowParent("f28String"), dtRowParent("f29String"), "",
                    '     0, dtItem("f01SmallInt"), 0, 0, 0,
                    '     dtItem("f01Double"), 0.0, 0.0, 0.0, 0.0,
                    '     "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                    '     "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    '     _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

                    objChild.dtAddNewsTABLEMEDIUMPLUS(pcNoDoc, dtItem("f33String"), "",
                          "", "", dtItem("f03String"), dtItem("f04String"), dtItem("f05String"), dtItem("f06String"), dtItem("f07String"), dtItem("f08String"), dtItem("f09String"), "",
                          "", dtRowParent("f05String"), dtRowParent("f06String"), dtRowParent("f11String"), "", "", "", "", "", "",
                          "", "", "", dtItem("f24String"), dtItem("f25String"), dtItem("f26String"), dtItem("f27String"), dtRowParent("f28String"), dtRowParent("f29String"), "",
                          0, dtItem("f01SmallInt"), 0, 0, 0,
                          dtItem("f01Double"), 0.0, 0.0, 0.0, 0.0,
                          "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                          "3000-01-01", _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                          _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
                Next
            Next
        Next

    End Sub

#End Region

#Region "public - custom method"

    Public Sub _cmProsesAggregate505012AirwayBill()

        Dim pdtParentRow() As DataRow
        Dim pdtChildRow() As DataRow
        pdtChildRow = Nothing

        Dim pdtChild As New DataTable
        Dim objChild As New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtChild}
        objChild.dtInitsTABLELARGE()

        pdtParentRow = _pdsDataSet.Tables("ParentTable").Select("f29String = '505012'")
        If pdtParentRow.Count > 0 Then

            For Each dtRowParent As Object In pdtParentRow
                For Each dtRowMiddle As DataRow In dtRowParent.GetChildRows(_pcRelasiParentMiddle)
                    pdtChildRow = dtRowMiddle.GetChildRows(_pcRelasiMiddleChild)
                    For Each dtItem As Object In pdtChildRow
                        objChild.dtAddNewsTABLELARGE("", "", "",
                                                "", "", dtItem("f03String"), dtItem("f04String"), dtItem("f05String"), "", "", "", "", "",
                                                "", "", "", "", "", "", "", "", "", "",
                                                "", "", "", dtItem("f24String"), dtItem("f25String"), "", "", "", "", "",
                                                "", "", dtItem("f33String"), "", "", "", "", "", "", "",
                                                0, CInt(dtItem("f01SmallInt")), 0, CDbl(dtItem("f01Double")), 0.0, 0.0,
                                                "3000-01-01", "3000-01-01", "3000-01-01",
                                                "", "", "", "", "")
                    Next
                Next
            Next

            Dim objProsesPKB As New ucWS24H201PROSESPKB With {._prop01User = _prop01User,
                                                                              ._prop02dtPARENT = pdtParentRow.CopyToDataTable,
                                                                              ._prop03dtCHILD = objChild.prop_dtsTABLELARGE,
                                                                              ._prop04dtPROSES = pdtMasterProses,
                                                                              ._prop05dtPICKER = pdtPicker,
                                                                              ._prop06dtEKSPEDISI = pdtEkspedisi,
                                                                              ._prop07gdParentChild = Me,
                                                                              ._prop08TargetProsesPKB = ucWS24H201PROSESPKB.TargetProsesPKB._01AirwayBill,
                                                                              .Dock = DockStyle.Fill}

            Dim objSize As New Size With {.Width = objProsesPKB.Size.Width,
                                                          .Height = objProsesPKB.Size.Height + 100}

            Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                                               .MinimizeBox = False, .ShowIcon = False,
                                                               .StartPosition = FormStartPosition.CenterScreen,
                                                               .Text = "create AirwayBill - " & _prop01User._UserProp01cTitle}
            frmModal.AddControl(objProsesPKB)

            frmModal.ShowDialog()
        Else
            MsgBox("Maaf ... Proses AIRWAY-BILL ... Tidak Ditemukan.", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
        End If

    End Sub

    Public Function _cmf10GetSelectedDataOrderMgmt() As DataTable
        'Return _pdsDataSet.Tables("ParentTable")

        Dim pdtSrc As DataTable = _pdsDataSet.Tables("ParentTable")
        Dim selectedRows = pdtSrc.AsEnumerable().
        Where(Function(r) r.Field(Of Integer)("k00Int") = 1)

        If Not selectedRows.Any() Then
            Return Nothing
        End If

        Return selectedRows.CopyToDataTable()
    End Function

    Public Function _cmf20GetSelectedDataCurrentStock() As DataTable
        'Return _pdsDataSet.Tables("ParentTable")

        Dim vdtSrc As DataTable = _pdsDataSet.Tables("Parent")

        If vdtSrc Is Nothing OrElse vdtSrc.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim selectedRows = vdtSrc.AsEnumerable().
        Where(Function(r) r.Field(Of Boolean)("k00Boolean") = True)

        If Not selectedRows.Any() Then
            Return Nothing
        End If

        Return selectedRows.CopyToDataTable()
    End Function

    'Public Function _cm20GetDataOrderManagementChild(ByRef prmdtParent As DataTable, ByVal prmcFilterNoOrder As String) As DataTable
    '    Dim pdtChild As New DataTable

    '    Using objChild As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtChild}
    '        objChild.dtInitsTABLETINY()

    '        For Each rowParent As DataRow In prmdtParent.Select(" k03String = '" & prmcFilterNoOrder & "'")
    '            For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
    '                objChild.dtAddNewsTABLETINY("", dtrowMiddle("k02String"), dtrowMiddle("k03String"),
    '                                dtrowMiddle("f01String"), dtrowMiddle("f02String"), "", "", "",
    '                                dtrowMiddle("f01TinyInt"), dtrowMiddle("f01SmallInt"), 0,
    '                                dtrowMiddle("f01Double"), 0.0, 0.0,
    '                                "3000-01-01", "3000-01-01",
    '                                Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
    '            Next

    '        Next

    '        If objChild.prop_dtsTABLETINY.Rows.Count > 0 Then
    '            Return objChild.prop_dtsTABLETINY
    '        End If

    '    End Using

    '    Return pdtChild
    'End Function



#End Region

#Region "EVENT - CONTROL"

    Private Sub _01lCheckSemua_CheckedChanged(sender As Object, e As EventArgs) Handles _01lCheckSemua.CheckedChanged
        If _isCheked Then Return

        Me.ActiveControl = Nothing
        Dim isChecked As Boolean = _01lCheckSemua.Checked
        Dim intValue As Integer = If(isChecked, 1, 0)

        If _prop02TargetGridParentChild = __TargetGridParentChild._TargetDisplayCurrentStockSku Then
            For i As Integer = 0 To GridView1.RowCount - 1
                Dim dataRow As DataRow = GridView1.GetDataRow(i)
                If dataRow IsNot Nothing Then
                    dataRow("k00Boolean") = isChecked
                End If
            Next
        Else
            For i As Integer = 0 To GridView1.RowCount - 1
                Dim dataRow As DataRow = GridView1.GetDataRow(i)
                If dataRow IsNot Nothing Then
                    dataRow("k00Boolean") = isChecked
                    dataRow("k00Int") = intValue
                End If
            Next

        End If

        _prop03pdtDataSourceGrid.AcceptChanges()


    End Sub
#End Region

    '"*************** NOT USED ***************"
    '"****************************************"
    'Public Sub _cm24GetDataPKBForSavePickingBRJ(ByRef prmdtParent As DataTable, ByRef prmdtChild As DataTable)
    '    Cursor = Cursors.WaitCursor

    '    Dim pdtParent As New DataTable
    '    Dim pdtChild As New DataTable

    '    pdtParent = _pdsDataSet.Tables("ParentTable").Select("f28String = '5051'").CopyToDataTable()
    '    If pdtParent.Rows.Count > 0 Then
    '        Dim pcKeyOLD As String = ""
    '        Dim pcKeyCurrent As String = ""
    '        Dim pcNoDocSJ As String = ""
    '        Dim pdtTempParent As New DataTable
    '        Dim pdtTempChild As New DataTable

    '        Using objParent As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtTempParent}
    '            objParent.dtInitsTABLEMEDIUMPLUSPLUS()

    '            Using objChild As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtTempChild}
    '                objChild.dtInitsTABLEMEDIUMPLUSPLUS()

    '                For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Rows

    '                    If rowParent("f28String") = "5051" And rowParent("f15String") <> "" Then
    '                        pcKeyCurrent = rowParent("f02String").ToString &
    '                                       rowParent("f08String").ToString &
    '                                       rowParent("f10String").ToString

    '                        If pcKeyOLD <> pcKeyCurrent Then
    '                            pcNoDocSJ = ""
    '                            pcNoDocSJ = _pmCreateNoDocPKBOutbound("5051")
    '                        End If

    '                        If Not String.IsNullOrEmpty(pcNoDocSJ) Then
    '                            objParent.dtAddNewsTABLEMEDIUMPLUS("", rowParent("k02String"), "",
    '                                                                rowParent("f01String"), rowParent("f02String"), rowParent("f03String"), rowParent("f04String"), rowParent("f05String"), rowParent("f06String"), rowParent("f07String"), rowParent("f08String"), rowParent("f09String"), rowParent("f10String"),
    '                                                                rowParent("f11String"), rowParent("f12String"), rowParent("f13String"), rowParent("f14String"), rowParent("f15String"), rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), "", "",
    '                                                                "", "", "", "", "", "", pcNoDocSJ, rowParent("f28String"), rowParent("f29String"), "",
    '                                                                rowParent("f01TinyInt"), rowParent("f01SmallInt"), rowParent("k00Int01"), 0, 0,
    '                                                                rowParent("f01Double"), 0.0, 0.0, 0.0, 0.0,
    '                                                                "3000-01-01", rowParent("f02Date"), "3000-01-01", "3000-01-01", "3000-01-01",
    '                                                                Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                                                                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '                            For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
    '                                For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
    '                                    If dtrowMiddle("f18String") = childRow("f18String") And childRow("k00Boolean") = True Then
    '                                        objChild.dtAddNewsTABLEMEDIUMPLUS(childRow("k01String"), childRow("k02String"), childRow("k03String"),
    '                                                    childRow("f01String"), childRow("f02String"), childRow("f03String"), childRow("f04String"), childRow("f06String"), childRow("f05String"), childRow("f07String"), childRow("f08String"), childRow("f09String"), childRow("f10String"),
    '                                                    pcNoDocSJ, rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), "", "", rowParent("f12String"), rowParent("f13String"), rowParent("f05String"), rowParent("f06String"),
    '                                                    rowParent("f11String"), rowParent("f03String"), rowParent("f04String"), rowParent("f01String"), rowParent("f02String"), childRow("f20String"), childRow("f19String"), rowParent("f28String"), rowParent("f29String"), "",
    '                                                    childRow("f01TinyInt"), childRow("f01SmallInt"), 0, 0, 0,
    '                                                    childRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
    '                                                    "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
    '                                                    Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                                                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '                                    End If
    '                                Next

    '                            Next

    '                            pcKeyOLD = pcKeyCurrent
    '                        Else
    '                            MsgBox("Maaf ... Nomor SURAT JALAN... KOSONG..", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '                        End If
    '                    End If

    '                Next

    '                If objParent.prop_dtsTABLEMEDIUMPLUS.Rows.Count > 0 Then
    '                    prmdtParent = objParent.prop_dtsTABLEMEDIUMPLUS
    '                    prmdtChild = objChild.prop_dtsTABLEMEDIUMPLUS
    '                End If

    '            End Using
    '        End Using
    '    Else
    '        MsgBox("Maaf ... Data masih KOSONG ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '    End If

    '    Cursor = Cursors.Default
    'End Sub

    'Public Sub _cm25GetDataPKBForSaveExceptPickingAirwayBill(ByRef prmdtParent As DataTable, ByRef prmdtChild As DataTable)
    '    Cursor = Cursors.WaitCursor

    '    Dim pdtParent As New DataTable
    '    Dim pdtChild As New DataTable

    '    '"5051"   - 'Picking + Create SuratJalan'
    '    '"505012" - Airway Bill by Ekspedisi
    '    pdtParent = _pdsDataSet.Tables("ParentTable").Select("f28String <> '5051' and f28String <> '505012'").CopyToDataTable()
    '    If pdtParent.Rows.Count > 0 Then
    '        Dim pcKeyOLD As String = ""
    '        Dim pcKeyCurrent As String = ""
    '        Dim pcNoDocument As String = ""
    '        Dim pdtTempParent As New DataTable
    '        Dim pdtTempChild As New DataTable

    '        Using objParent As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtTempParent}
    '            objParent.dtInitsTABLEMEDIUMPLUSPLUS()

    '            Using objChild As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtTempChild}
    '                objChild.dtInitsTABLEMEDIUMPLUSPLUS()

    '                For Each rowParent As DataRow In _pdsDataSet.Tables("ParentTable").Rows
    '                    pcKeyCurrent = rowParent("f02String").ToString & rowParent("f08String").ToString & rowParent("f10String").ToString

    '                    If pcKeyOLD <> pcKeyCurrent Then
    '                        '"505013" - 'Confirm Pickup by Ekspedisi'
    '                        '"505014" - 'Confirm Delivered by Ekspedisi'
    '                        '"505015" - 'Confirm Delivered NON Ekspedisi'

    '                        pcNoDocument = ""
    '                        pcNoDocument = _pmCreateNoDocPKBOutbound(rowParent("f28String").ToString)
    '                    End If

    '                    If Not String.IsNullOrEmpty(pcNoDocument) Then
    '                        objParent.dtAddNewsTABLEMEDIUMPLUS("", rowParent("k02String"), "",
    '                                                                rowParent("f01String"), rowParent("f02String"), rowParent("f03String"), rowParent("f04String"), rowParent("f05String"), rowParent("f06String"), rowParent("f07String"), rowParent("f08String"), rowParent("f09String"), rowParent("f10String"),
    '                                                                rowParent("f11String"), rowParent("f12String"), rowParent("f13String"), rowParent("f14String"), rowParent("f15String"), rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), "", "",
    '                                                                "", "", "", "", "", "", pcNoDocument, rowParent("f28String"), rowParent("f29String"), "",
    '                                                                rowParent("f01TinyInt"), rowParent("f01SmallInt"), rowParent("k00Int01"), 0, 0,
    '                                                                rowParent("f01Double"), 0.0, 0.0, 0.0, 0.0,
    '                                                                "3000-01-01", rowParent("f02Date"), "3000-01-01", "3000-01-01", "3000-01-01",
    '                                                                Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                                                                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '                        For Each dtrowMiddle As DataRow In rowParent.GetChildRows(_pcRelasiParentMiddle)
    '                            For Each childRow As DataRow In dtrowMiddle.GetChildRows(_pcRelasiMiddleChild)
    '                                If dtrowMiddle("f18String") = childRow("f18String") Then
    '                                    objChild.dtAddNewsTABLEMEDIUMPLUS(childRow("k01String"), childRow("k02String"), childRow("k03String"),
    '                                                    childRow("f01String"), childRow("f02String"), childRow("f03String"), childRow("f04String"), childRow("f06String"), childRow("f05String"), childRow("f07String"), childRow("f08String"), childRow("f09String"), childRow("f10String"),
    '                                                    pcNoDocument, rowParent("f16String"), rowParent("f17String"), rowParent("f18String"), "", "", rowParent("f12String"), rowParent("f13String"), rowParent("f05String"), rowParent("f06String"),
    '                                                    rowParent("f11String"), rowParent("f03String"), rowParent("f04String"), rowParent("f01String"), rowParent("f02String"), childRow("f20String"), childRow("f19String"), rowParent("f28String"), rowParent("f29String"), "",
    '                                                    childRow("f01TinyInt"), childRow("f01SmallInt"), 0, 0, 0,
    '                                                    childRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
    '                                                    "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
    '                                                    Today.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                                                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '                                End If
    '                            Next

    '                        Next

    '                        pcKeyOLD = pcKeyCurrent
    '                    Else
    '                        MsgBox("Maaf ... Nomor Document... KOSONG..", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '                    End If

    '                Next

    '                If objParent.prop_dtsTABLEMEDIUMPLUS.Rows.Count > 0 Then
    '                    prmdtParent = objParent.prop_dtsTABLEMEDIUMPLUS
    '                    prmdtChild = objChild.prop_dtsTABLEMEDIUMPLUS
    '                End If

    '            End Using
    '        End Using
    '    Else
    '        MsgBox("Maaf ... Data masih KOSONG ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '    End If

    '    Cursor = Cursors.Default
    'End Sub


    '#Region "public - method : Display Setting Grid ParentChild"

    'Public Function __pbWSGridParentChild04GetData() As DataTable
    '    Dim pdtData As New DataTable

    '    Select Case _prop02TargetGridParentChild
    '        Case __TargetGridParentChild._TargetDisplayOutboundPKB

    '        Case Else
    '    End Select

    '    'Case __TargetGridParentChild._TargetAPPROVEPKBMgrFIN,
    '    '     __TargetGridParentChild._TargetAPPROVEPKBMgrSLS
    '    '    'pdtData = __pvGetData4ApprovedFinSls()

    '    Return pdtData
    'End Function


    '    'Private Sub __pvDisplayGridApprovePKB()
    '    '    Dim pdtDataApprove As New DataTable
    '    '    Dim objData As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
    '    '    Select Case _prop02TargetGridParentChild
    '    '        Case __TargetGridParentChild._TargetAPPROVEPKBMgrFIN
    '    '            pdtDataApprove = objData._pb03GetDataPrepareAPPROVEPKB("FIN")

    '    '        Case __TargetGridParentChild._TargetAPPROVEPKBMgrSLS
    '    '            pdtDataApprove = objData._pb03GetDataPrepareAPPROVEPKB("SLS")

    '    '    End Select

    '    '    'Using objApprovePKB As clsWSNasaSettingGridDistribusiBarang = New clsWSNasaSettingGridDistribusiBarang With {._prop02User = _prop01User,
    '    '    '                                                                                                             ._prop03Grid = Me}
    '    '    '    Select Case _prop02TargetGridParentChild
    '    '    '        Case __TargetGridParentChild._TargetAPPROVEPKBMgrFIN
    '    '    '            objApprovePKB._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSApprovePKBbyFIN

    '    '    '        Case __TargetGridParentChild._TargetAPPROVEPKBMgrSLS
    '    '    '            objApprovePKB._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSApprovePKBbySLS
    '    '    '    End Select

    '    '    '    objApprovePKB._pbSetting01ApprovePKB()
    '    '    'End Using

    '    '    Me.GridControl1.DataSource = Nothing
    '    '    Me.GridControl1.DataSource = pdtDataApprove
    '    'End Sub

    '#End Region

    '#Region "public - method : GetData Grid ParentChild"

    '    'Private Function __pvGetData4ApprovedFinSls() As DataTable
    '    '    Dim pdtDataTiny As New DataTable
    '    '    Dim objTiny As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtDataTiny}
    '    '    objTiny.dtInitsTABLETINY()

    '    '    Dim pcTargetApprove As String = ""
    '    '    Select Case _prop02TargetGridParentChild
    '    '        Case __TargetGridParentChild._TargetAPPROVEPKBMgrFIN
    '    '            pcTargetApprove = "FIN"
    '    '        Case __TargetGridParentChild._TargetAPPROVEPKBMgrSLS
    '    '            pcTargetApprove = "SLS"
    '    '    End Select

    '    '    Dim pcSetujuTolakSALES As String = ""
    '    '    Dim pcSetujuTolakFIN As String = ""

    '    '    For i = 0 To GridView1.RowCount
    '    '        pcSetujuTolakSALES = ""
    '    '        If CInt(GridView1.GetRowCellValue(i, "k00Int")) = 1 Then   '"Agree/DisAgree" 
    '    '            pcSetujuTolakSALES = "SETUJU"
    '    '        Else
    '    '            If CInt(GridView1.GetRowCellValue(i, "k00Int")) = 2 Then
    '    '                pcSetujuTolakSALES = "TOLAK"
    '    '            End If
    '    '        End If

    '    '        pcSetujuTolakFIN = ""
    '    '        If CInt(GridView1.GetRowCellValue(i, "k00Int01")) = 1 Then   '"Agree/DisAgree" 
    '    '            pcSetujuTolakFIN = "SETUJU"
    '    '        Else
    '    '            If CInt(GridView1.GetRowCellValue(i, "k00Int01")) = 2 Then
    '    '                pcSetujuTolakFIN = "TOLAK"
    '    '            End If
    '    '        End If

    '    '        If Not (pcSetujuTolakSALES = "" And pcSetujuTolakFIN = "") Then
    '    '            objTiny.dtAddNewsTABLETINY(
    '    '                    GridView1.GetRowCellValue(i, "k03String").ToString,     '"No.PKB"
    '    '                    GridView1.GetRowCellValue(i, "f02String").ToString,     '"ProductCode"
    '    '                    GridView1.GetRowCellValue(i, "f09String").ToString,     '"KodeCustomer"
    '    '                    pcTargetApprove, pcSetujuTolakSALES, pcSetujuTolakFIN, "", "",
    '    '                    0, 0, 0, 0.0, 0.0, 0.0, "3000-01-01", "3000-01-01",
    '    '                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '    '                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
    '    '        End If
    '    '    Next

    '    '    Return objTiny.prop_dtsTABLETINY
    '    'End Function

    '#End Region

    '#Region "method - invoke"
    '    Public Delegate Sub __dlgBindingManual(ByVal prmdtData1 As DataTable, ByVal prmdtData12 As DataTable)

    '    Public Sub __ivkDisplayPKBCustomer(ByVal prmdtParent As DataTable, ByVal prmdtChild As DataTable)
    '        Cursor = Cursors.WaitCursor

    '        GridControl1.LevelTree.Nodes.Clear()
    '        GridControl1.DataSource = Nothing

    '        _pcNamaRelasiParentChild = ""
    '        _pcNamaRelasiParentChild = "PKBCustomer"

    '        If pdsDataset.Relations.Contains(_pcNamaRelasiParentChild) Then
    '            pdsDataset.Relations.Remove(_pcNamaRelasiParentChild)
    '        End If

    '        If pdsDataset.Tables.Contains(prmdtParent.TableName) Or
    '            pdsDataset.Tables.Contains(prmdtChild.TableName) Then

    '            Dim prmdtParentCopy As DataTable
    '            prmdtParentCopy = prmdtParent.Copy

    '            Dim prmdtChildCopy As DataTable
    '            prmdtChildCopy = prmdtChild.Copy

    '            pdsDataset.EnforceConstraints = False

    '            pdsDataset.Tables(prmdtParent.TableName).Clear()
    '            pdsDataset.Tables(prmdtChild.TableName).Clear()

    '            prmdtParent = prmdtParentCopy
    '            prmdtChild = prmdtChildCopy

    '            pdsDataset.EnforceConstraints = True

    '            Dim pcParentName As String = GetRandomAlphanumericString(10)
    '            prmdtParent.TableName = pcParentName

    '            Dim pcChildName As String = GetRandomAlphanumericString(10)
    '            prmdtChild.TableName = pcChildName

    '            pdsDataset.Tables.Add(prmdtParent)
    '            pdsDataset.Tables.Add(prmdtChild)
    '            pdsDataset.Relations.Add(_pcNamaRelasiParentChild, prmdtParent.Columns("f01String"), prmdtChild.Columns("f01String"), True)
    '            GridControl1.DataSource = pdsDataset.Tables(pcParentName)
    '        Else
    '            pdsDataset.Tables.AddRange(New DataTable() {prmdtParent, prmdtChild})
    '            pdsDataset.Relations.Add(_pcNamaRelasiParentChild, prmdtParent.Columns("f01String"), prmdtChild.Columns("f01String"), True)
    '            GridControl1.DataSource = pdsDataset.Tables("dtParent")
    '        End If

    '        'GridControl1.LevelTree.Nodes.Clear()
    '        'GridControl1.DataSource = Nothing
    '        'GridControl1.DataSource = pdsDataset.Tables("dtParent")

    '        GridView2.OptionsView.ColumnAutoWidth = False

    '        With GridControl1.LevelTree.Nodes
    '            .Add(_pcNamaRelasiParentChild, GridView2)
    '        End With

    '        GridView2.BestFitColumns()

    '        Cursor = Cursors.Default
    '    End Sub

    '    Public Sub __ivkDisplayPKBCustomerRefresh(ByVal prmdtParent As DataTable, ByVal prmdtChild As DataTable)
    '        Cursor = Cursors.WaitCursor

    '        GridControl1.RefreshDataSource()
    '        GridControl1.Refresh()

    '        Cursor = Cursors.Default
    '    End Sub

    '    Public Function GetRandomAlphanumericString(ByVal length As Integer) As String
    '        Dim random As New Random()
    '        Dim chars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
    '        Dim result As StringBuilder = New StringBuilder()

    '        For i As Integer = 0 To length - 1
    '            result.Append(chars(random.Next(chars.Length)))
    '        Next

    '        Return result.ToString()
    '    End Function
    '#End Region
    '"****************************************"
    '"*************** NOT USED ***************"
    '"****************************************"

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