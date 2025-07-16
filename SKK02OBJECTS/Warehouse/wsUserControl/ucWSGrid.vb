Imports System.IO
Imports DevExpress.Charts.Native
Imports DevExpress.Data
Imports DevExpress.Pdf
Imports DevExpress.Pdf.Native
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.Design
Imports SKK01CORE
Imports SKK02OBJECTS.clsWSNasaSettingGridInbound
Imports SKK02OBJECTS.clsWSNasaSettingReportGrid
Imports SKK02OBJECTS.ctrlWSNasaSpinEdit
Imports SKK02OBJECTS.repoWS05Master

Public Class ucWSGrid
    Implements IDisposable

    Property _prop01User As clsWSNasaUser
    Property _prop02TargetGrid As _pbEnumTargetGrid
    Property _prop03pdtDataSourceGrid As New DataTable

    Property _prop04Date As Date
    Property _prop05String As String
    Property _prop06String As String
    Property _prop07String As String
    Property _prop11objSpinEdit As ctrlWSNasaSpinEdit
    Property _prop12objSpinEdit As ctrlWSNasaSpinEdit

    Private _cachedCustomerTable As DataTable = Nothing
    Private _cachedTopTable As DataTable = Nothing
    Private _isUpdating As Boolean = False


#Region "private - repository"
    Private _rscolk00Int As New repoWS02Numeric

    Private _rscolf01TinyInt As New repoWS02Numeric
    Private _rscolf01SmallInt As New repoWS02Numeric
    Private _rscolf01Int As New repoWS02Numeric
    Private _rscolf01Double As New repoWS02Numeric
    Private _rscolf02Double As New repoWS02Numeric
    Private _rscolf03Double As New repoWS02Numeric

    Private _rscolf01Date As New repoWS01Date
    Private _rscolf02Date As New repoWS01Date
    Private _rscolf03Date As New repoWS01Date

    Private objRepoWS05Master As New repoWS05Master   '==> _cm33SettingWS24FP01INBOUND()
#End Region

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        Me.Dispose()
    End Sub

    Private Sub ucWSGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _prop02TargetGrid = _pbEnumTargetGrid._WSOut10ProsesPKB Then
            GridView1.OptionsView.AllowCellMerge = True
        End If

    End Sub
#End Region

#Region "private - custom method"

    Private Sub _cm01InitOthersGrid()
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.IndicatorWidth = 50
        GridView1.BestFitColumns()
    End Sub

    Private Sub _cm02InitFieldGrid()
        _colk00Boolean.FieldName = "k00Boolean"
        _colk00Int.FieldName = "k00Int"

        _colk00Boolean01.FieldName = "k00Boolean01"
        _colk00Int01.FieldName = "k00Int01"
        _colk00Boolean02.FieldName = "k00Boolean02"
        _colk00Int02.FieldName = "k00Int02"
        _colf01Memo.FieldName = "f01Memo"

        _colk01String.FieldName = "k01String"
        _colk02String.FieldName = "k02String"
        _colk03String.FieldName = "k03String"
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
    End Sub

    Private Sub _cm03InitRepoColumn()
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

    Private Sub _cm04InitColumnEdit()
        _colf01TinyInt.ColumnEdit = _rscolf01TinyInt
        _colf01SmallInt.ColumnEdit = _rscolf01SmallInt
        _colf01Int.ColumnEdit = _rscolf01Int
        _colf01Double.ColumnEdit = _rscolf01Double
        _colf02Double.ColumnEdit = _rscolf02Double
        _colf03Double.ColumnEdit = _rscolf03Double
        _colf01Date.ColumnEdit = _rscolf01Date
        _colf02Date.ColumnEdit = _rscolf02Date
        _colf03Date.ColumnEdit = _rscolf03Date
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

    Private Sub _cm06SettingColumnSummary()

        _cm05InitGridSummaryItem(_colf01TinyInt, "f01TinyInt", "INT")
        _cm05InitGridSummaryItem(_colf01SmallInt, "f01SmallInt", "INT")
        _cm05InitGridSummaryItem(_colf01Int, "f01Int", "INT")
        _cm05InitGridSummaryItem(_colf01Double, "f01Double", "DBL2")
        _cm05InitGridSummaryItem(_colf02Double, "f02Double", "DBL2")
        _cm05InitGridSummaryItem(_colf03Double, "f03Double", "DBL2")

    End Sub

    Private Sub _cm07InitVisibilityOFF()
        _colk00Boolean.Visible = False  'k00Boolean"
        _colk00Int.Visible = False  'k00Int"

        _colk00Boolean01.Visible = False  '"k00Boolean01"
        _colk00Int01.Visible = False      '"k00Int01"
        _colk00Boolean02.Visible = False  '"k00Boolean02"
        _colk00Int02.Visible = False      '"k00Int02"
        _colf01Memo.Visible = False       '"f01Memo"

        _colk01String.Visible = False  'k01String"
        _colk02String.Visible = False  'k02String"
        _colk03String.Visible = False  'k03String"
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
    End Sub

    Private Sub _cm08InitVisibilityIndexOFF()
        _colk00Boolean.VisibleIndex = -1   '"k00Boolean"
        _colk00Int.VisibleIndex = -1   '"k00Int"

        _colk00Boolean01.VisibleIndex = -1  '"k00Boolean01"
        _colk00Int01.VisibleIndex = -1      '"k00Int01"
        _colk00Boolean02.VisibleIndex = -1  '"k00Boolean02"
        _colk00Int02.VisibleIndex = -1      '"k00Int02"
        _colf01Memo.VisibleIndex = -1       '"f01Memo"

        _colk01String.VisibleIndex = -1   '"k01String"
        _colk02String.VisibleIndex = -1   '"k02String"
        _colk03String.VisibleIndex = -1   '"k03String"
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
    End Sub

    Private Sub _cm09ReadOnlyGrid()
        _colk00Boolean.OptionsColumn.ReadOnly = True    '"k00Boolean"
        _colk00Int.OptionsColumn.ReadOnly = True    '"k00Int"

        _colk00Boolean01.OptionsColumn.ReadOnly = True  '"k00Boolean01"
        _colk00Int01.OptionsColumn.ReadOnly = True      '"k00Int01"
        _colk00Boolean02.OptionsColumn.ReadOnly = True  '"k00Boolean02"
        _colk00Int02.OptionsColumn.ReadOnly = True      '"k00Int02"
        _colf01Memo.OptionsColumn.ReadOnly = True       '"f01Memo"

        _colk01String.OptionsColumn.ReadOnly = True    '"k01String"
        _colk02String.OptionsColumn.ReadOnly = True    '"k02String"
        _colk03String.OptionsColumn.ReadOnly = True    '"k03String"
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
        _colf01TinyInt.OptionsColumn.ReadOnly = True    '"f01TinyInt"
        _colf01SmallInt.OptionsColumn.ReadOnly = True    '"f01SmallInt"
        _colf01Int.OptionsColumn.ReadOnly = True    '"f01Int"
        _colf02Int.OptionsColumn.ReadOnly = True    '"f01Int"
        _colf01Double.OptionsColumn.ReadOnly = True    '"f01Double52"
        _colf02Double.OptionsColumn.ReadOnly = True    '"f01Double62"
        _colf03Double.OptionsColumn.ReadOnly = True    '"f01Double162"
        _colf01Date.OptionsColumn.ReadOnly = True    '"f01Date"
        _colf02Date.OptionsColumn.ReadOnly = True    '"f01Date"
        _colf02Date.OptionsColumn.ReadOnly = True    '"f02Date"
        _colf03Date.OptionsColumn.ReadOnly = True    '"f03Date"
    End Sub

    Private Sub _cm10PropertiesGridONTarget()
        'OFF
        _cm07InitVisibilityOFF()
        _cm08InitVisibilityIndexOFF()

        'ON
        _cm12VisibilityCheckSelectAll()
        _cm20InstallSettingWSGrid()
    End Sub

    Private Function _cm11DataTableMasterWarehouse(ByVal prmcTarget As String) As DataTable
        Cursor = Cursors.WaitCursor

        Dim objclsMaster As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtMaster As New DataTable

        Select Case prmcTarget
            Case "SBOX"
                pdtMaster = objclsMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("SBOX")
            Case "SLOC-ALL"
                pdtMaster = objclsMaster.__pb02GetDataTable21TargetWarehouseByUser("5040")
            Case "SLOC-PER-USER"
                pdtMaster = objclsMaster.__pb02GetDataTable21TargetWarehouseByUser("5040")
            Case "COURIER"
                pdtMaster = objclsMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("COURIER")
        End Select

        Cursor = Cursors.Default

        Return pdtMaster
    End Function

    Private Function _cm11DataTableMasterMRP(ByVal prmcTarget As String) As DataTable
        Cursor = Cursors.WaitCursor

        Dim pdtHasil As New DataTable

        If prmcTarget = "SIZE" Then
            Using objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
                pdtHasil = objTargetTransaksi.__pb16GetDataMasterMRPSize()
            End Using
        Else
            If prmcTarget = "PRODUCT" Then
                Dim pdtTargetMRPProduct As New DataTable
                Using objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
                    pdtHasil = objTargetTransaksi.__pb15GetDataMasterMRPProduct()
                End Using
            End If
        End If
        Cursor = Cursors.Default

        Return pdtHasil
    End Function

    Private Sub _cm12VisibilityCheckSelectAll()
        _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        Select Case _prop02TargetGrid
            Case _pbEnumTargetGrid._WSPKBCustomer, _pbEnumTargetGrid._WSInbound5028ReturKAE, _pbEnumTargetGrid._WSInbound5029ReturConsignment, _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN, _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS
                _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        End Select
    End Sub

    Private Sub _cm13CekExistingField()
        If Not _prop03pdtDataSourceGrid.Columns.Contains("k00Boolean") Then
            _prop03pdtDataSourceGrid.Columns.Add("k00Boolean", GetType(Boolean)).DefaultValue = False
        End If

        If Not _prop03pdtDataSourceGrid.Columns.Contains("k00Int") Then
            _prop03pdtDataSourceGrid.Columns.Add("k00Int", GetType(Integer)).DefaultValue = 0
        End If

        If Not _prop03pdtDataSourceGrid.Columns.Contains("k00Boolean01") Then
            _prop03pdtDataSourceGrid.Columns.Add("k00Boolean01", GetType(Boolean)).DefaultValue = False
        End If

        If Not _prop03pdtDataSourceGrid.Columns.Contains("k00Int01") Then
            _prop03pdtDataSourceGrid.Columns.Add("k00Int01", GetType(Integer)).DefaultValue = 0
        End If

        If Not _prop03pdtDataSourceGrid.Columns.Contains("k00Boolean02") Then
            _prop03pdtDataSourceGrid.Columns.Add("k00Boolean02", GetType(Boolean)).DefaultValue = False
        End If

        If Not _prop03pdtDataSourceGrid.Columns.Contains("k00Int02") Then
            _prop03pdtDataSourceGrid.Columns.Add("k00Int02", GetType(Integer)).DefaultValue = 0
        End If

        If Not _prop03pdtDataSourceGrid.Columns.Contains("f01Memo") Then
            _prop03pdtDataSourceGrid.Columns.Add("f01Memo", GetType(String)).DefaultValue = ""
        End If

        If Not _prop03pdtDataSourceGrid.Columns.Contains("f03Date") Then
            _prop03pdtDataSourceGrid.Columns.Add("f03Date", GetType(String)).DefaultValue = "3000-01-01"
        End If
    End Sub

    Private Sub _cm14AddNewData(ByVal prmk01String As String, ByVal prmk02String As String, ByVal prmk03String As String,
                ByVal prmf01String As String, ByVal prmf02String As String, ByVal prmf03String As String, ByVal prmf04String As String, ByVal prmf05String As String,
                ByVal prmf06String As String, ByVal prmf07String As String, ByVal prmf08String As String, ByVal prmf09String As String, ByVal prmf10String As String,
                ByVal prmf11String As String, ByVal prmf12String As String, ByVal prmf13String As String, ByVal prmf14String As String, ByVal prmf15String As String,
                ByVal prmf16String As String, ByVal prmf17String As String, ByVal prmf18String As String, ByVal prmf19String As String, ByVal prmf20String As String,
                ByVal prmf21String As String, ByVal prmf22String As String, ByVal prmf23String As String, ByVal prmf24String As String, ByVal prmf25String As String,
                ByVal prmf26String As String, ByVal prmf27String As String, ByVal prmf28String As String, ByVal prmf29String As String, ByVal prmf30String As String,
                ByVal prmf31String As String, ByVal prmf32String As String, ByVal prmf33String As String, ByVal prmf34String As String, ByVal prmf35String As String,
                ByVal prmf36String As String, ByVal prmf37String As String, ByVal prmf38String As String, ByVal prmf39String As String, ByVal prmf40String As String,
                ByVal prmf01Memo As String,
                ByVal prmf01TinyInt As Integer, ByVal prmf01SmallInt As Integer, ByVal prmf01Int As Integer,
                ByVal prmf01Double As Double, ByVal prmf02Double As Double, ByVal prmf03Double As Double,
                ByVal prmf01Date As Date, ByVal prmf02Date As Date, ByVal prmf03Date As Date, ByVal prmf04Date As Date, ByVal prmf05Date As Date)

        Dim oDataRow As DataRow = _prop03pdtDataSourceGrid.NewRow()

        oDataRow("k01String") = prmk01String
        oDataRow("k02String") = prmk02String
        oDataRow("k03String") = prmk03String
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
        oDataRow("f31String") = prmf31String
        oDataRow("f32String") = prmf32String
        oDataRow("f33String") = prmf33String
        oDataRow("f34String") = prmf34String
        oDataRow("f35String") = prmf35String
        oDataRow("f36String") = prmf36String
        oDataRow("f37String") = prmf37String
        oDataRow("f38String") = prmf38String
        oDataRow("f39String") = prmf39String
        oDataRow("f40String") = prmf40String
        oDataRow("f01Memo") = prmf01Memo
        oDataRow("f01TinyInt") = prmf01TinyInt
        oDataRow("f01SmallInt") = prmf01SmallInt
        oDataRow("f01Int") = prmf01Int
        oDataRow("f01Double") = prmf01Double
        oDataRow("f02Double") = prmf02Double
        oDataRow("f03Double") = prmf03Double
        oDataRow("f01Date") = prmf01Date
        oDataRow("f02Date") = prmf02Date
        oDataRow("f03Date") = prmf03Date

        _prop03pdtDataSourceGrid.Rows.Add(oDataRow)
        _prop03pdtDataSourceGrid.AcceptChanges()

        GridControl1.RefreshDataSource()
        GridControl1.Refresh()
    End Sub

#End Region

#Region "public - method : Setting Grid"

    Public Sub __pbWSGrid01InitGrid()
        'Check existing field Boolean ...?
        _cm13CekExistingField()

        _cm01InitOthersGrid()
        _cm02InitFieldGrid()
        _cm03InitRepoColumn()
        _cm04InitColumnEdit()
        _cm06SettingColumnSummary()

        'agar waktu pertama kali display, kosong... tanpa header kolom
        _cm07InitVisibilityOFF()
        _cm08InitVisibilityIndexOFF()
        _cm09ReadOnlyGrid()
    End Sub

    Public Sub __pbWSGrid02ClearGrid()
        _prop03pdtDataSourceGrid.Clear()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _prop03pdtDataSourceGrid

        GridControl1.Refresh()
    End Sub

    Public Sub __pbWSGrid03DisplayGrid()
        _cm10PropertiesGridONTarget()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _prop03pdtDataSourceGrid

        ' ===================== UPDATED BY AKIRRA - 25/04/30 =====================
        ' agar ketika merubah target, maka akan mereset filter untuk mencegah error filter.
        GridView1.RefreshData()
        GridView1.ActiveFilter.Clear()
        GridView1.SortInfo.Clear()
        _01lCheckSemua.Checked = False
        ' ======================================================================

        ' ===================== UPDATED BY AKIRRA - 25/04/30 =====================
        ' agar lebar kolom lebih rapih (menyesuaikan konten).
        If Not _pbEnumTargetGrid._WSRptStore Then

            GridView1.BestFitColumns()
        End If
        ' ======================================================================

        Me.Dock = DockStyle.Fill
    End Sub

    Public Sub __pbWSGrid04CreateSettingColumnWidth(ByVal prmcNamaFileTarget As String)
        Cursor = Cursors.WaitCursor

        Const pcNamaPath As String = "C:\ITeamSKK\MERSY\ColumnWidthSettings"
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
            _objstreamwriter.WriteLine("._colk00Boolean02.Width = " + ._colk00Boolean02.Width.ToString)
            _objstreamwriter.WriteLine("._colk00Int02.Width = " + ._colk00Int02.Width.ToString)
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
            _objstreamwriter.WriteLine("End With")
            _objstreamwriter.WriteLine("End Sub")
        End With

        _objstreamwriter.Close()
        fs.Close()

        Cursor = Cursors.Default
    End Sub

    Public Sub __pbWSGridVisibilityCheckSelectAll(Optional ByVal plShow As Boolean = True, Optional ByVal plActive As Boolean = False)
        If plShow Then
            _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            _lay01lCheckSemua.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

        _01lCheckSemua.EditValue = plActive

    End Sub

    Public Sub __pbShowIndicatorOff()
        GridView1.OptionsView.ShowIndicator = False
    End Sub

#End Region

#Region "event - control grid"
    Private Sub _rscolk00Boolean_CheckedChanged(sender As Object, e As EventArgs) Handles _rscolk00Boolean.CheckedChanged
        GridView1.PostEditor()
        GridView1.RefreshData()
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
        If e.Column.FieldName = "k00Boolean" _
            And Not _prop02TargetGrid = TargetINBOUND._WSInbound5021InhouseProduksi _
            And Not _prop02TargetGrid = TargetINBOUND._WSInbound5023RepairWarehouse _
            And Not _prop02TargetGrid = TargetINBOUND._WSInbound5025ReturCustomer _
            And Not _prop02TargetGrid = TargetINBOUND._WSInbound5027BRJPinjamanMarketing _
            And Not _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN _
            And Not _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS Then

            If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                GridView1.SetFocusedRowCellValue("k00Int", 1)
            Else
                GridView1.SetFocusedRowCellValue("k00Int", 0)
            End If

            GridView1.RefreshData()
        End If

        If e.Column.FieldName = "f40String" And _prop02TargetGrid = _pbEnumTargetGrid._WSTransaksi03ReparasiLebur Then
            For i As Integer = 0 To GridView1.RowCount - 1
                Dim f40Value As Object = GridView1.GetRowCellValue(i, "f40String")

                If Not String.IsNullOrEmpty(f40Value.ToString()) Then
                    GridView1.SetRowCellValue(i, "k00Boolean", True)
                    GridView1.SetRowCellValue(i, "k00Int", 1)
                End If
            Next

            GridView1.RefreshData()

        End If

        If e.Column.FieldName = "k00Boolean" And _prop02TargetGrid = _pbEnumTargetGrid._wsOut5052PKBCreateSuratJalan Then
            If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                GridView1.SetFocusedRowCellValue("k00Int", 1)
            Else
                GridView1.SetFocusedRowCellValue("k00Int", 0)
            End If

            GridView1.RefreshData()
        End If


        ' ===================== CREATED BY AKIRRA - 25/06/23 =====================
        ' jika FINANCE memilih PENDING, maka nilai dari kolom alasan otomatis menjadi [PENDING].
        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN AndAlso e.Column.FieldName = "k00Int01" Then

            If CInt(GridView1.GetFocusedRowCellValue("k00Int01")) = 10 Then          ' default
                GridView1.SetFocusedRowCellValue("f29String", GridView1.GetDataRow(GridView1.FocusedRowHandle)("f29String", DataRowVersion.Original))
                'GridView1.SetFocusedRowCellValue("f29String", "")
                If CInt(GridView1.GetFocusedRowCellValue("k00Boolean")) <> False Then
                    GridView1.SetFocusedRowCellValue("k00Boolean", False)
                End If
            End If

            If CInt(GridView1.GetFocusedRowCellValue("k00Int01")) = 1 Then          ' APPROVE
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
            End If

            If CInt(GridView1.GetFocusedRowCellValue("k00Int01")) = 2 Then          ' REJECT
                'Dim reasonRtf As String = GridView1.GetFocusedRowCellValue("f29String")?.ToString()
                'Dim plainText As String = ""

                'Try
                '    Using rtb As New RichTextBox()
                '        rtb.Rtf = reasonRtf
                '        plainText = rtb.Text?.Trim()
                '    End Using
                'Catch
                '    plainText = reasonRtf?.Trim()
                'End Try

                GridView1.SetFocusedRowCellValue("f29String", "[REJECT] ")
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
            End If

            If CInt(GridView1.GetFocusedRowCellValue("k00Int01")) = 3 Then          ' PENDING
                'Dim reasonRtf As String = GridView1.GetFocusedRowCellValue("f29String")?.ToString()
                'Dim plainText As String = ""

                'Try
                '    Using rtb As New RichTextBox()
                '        rtb.Rtf = reasonRtf
                '        plainText = rtb.Text?.Trim()
                '    End Using
                'Catch
                '    plainText = reasonRtf?.Trim()
                'End Try

                GridView1.SetFocusedRowCellValue("f29String", "[PENDING] ")
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
            End If

            GridView1.RefreshData()
        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN AndAlso e.Column.FieldName = "k00Boolean" Then

            If CInt(GridView1.GetFocusedRowCellValue("k00Boolean")) = False Then          ' default
                If CInt(GridView1.GetFocusedRowCellValue("k00Int01")) <> 10 Then
                    GridView1.SetFocusedRowCellValue("k00Int01", 10)
                End If
            End If

            GridView1.RefreshData()
        End If
        ' ========================================================================


        ' ===================== CREATED BY AKIRRA - 25/07/08 =====================
        ' to process TICK on SALES APPROVAL
        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS AndAlso e.Column.FieldName = "k00Int" Then

            If CInt(GridView1.GetFocusedRowCellValue("k00Int")) = 10 Then          ' default
                GridView1.SetFocusedRowCellValue("k00Boolean", False)
            End If

            If CInt(GridView1.GetFocusedRowCellValue("k00Int")) = 1 Then          ' APPROVE
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
            End If

            If CInt(GridView1.GetFocusedRowCellValue("k00Int")) = 2 Then          ' REJECT
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
            End If

            If CInt(GridView1.GetFocusedRowCellValue("k00Int")) = 3 Then          ' PENDING
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
            End If

            GridView1.RefreshData()
        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS AndAlso e.Column.FieldName = "k00Boolean" Then

            If CInt(GridView1.GetFocusedRowCellValue("k00Boolean")) = False Then          ' default
                If CInt(GridView1.GetFocusedRowCellValue("k00Int")) <> 10 Then
                    GridView1.SetFocusedRowCellValue("k00Int", 10)
                End If
            End If

            GridView1.RefreshData()
        End If
        ' ========================================================================



        Dim View As GridView = TryCast(sender, GridView)

        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN Or
                _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS Then

        End If

        If _prop02TargetGrid = TargetINBOUND._WSInbound5021InhouseProduksi Then
            If e.Column.FieldName = "k00Boolean" Then

                If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                    GridView1.SetFocusedRowCellValue("k00Int", 1)
                Else
                    GridView1.SetFocusedRowCellValue("k00Int", 0)
                    View.SetFocusedRowCellValue("f37String", "")
                End If

            End If

            If e.Column.FieldName = "f36String" Then  'SBOX
                View.SetFocusedRowCellValue("f37String", View.GetFocusedRowCellDisplayText("f36String"))
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
                GridView1.SetFocusedRowCellValue("k00Int", 1)
            End If

            GridView1.RefreshData()
        End If

        If _prop02TargetGrid = TargetINBOUND._WSInbound5023RepairWarehouse Then
            If e.Column.FieldName = "f30String" Then  'Brand
                View.SetFocusedRowCellValue("f33String", View.GetFocusedRowCellDisplayText("f30String"))
            End If
            If e.Column.FieldName = "f31String" Then  'Warna
                View.SetFocusedRowCellValue("f34String", View.GetFocusedRowCellDisplayText("f31String"))
            End If
            If e.Column.FieldName = "f32String" Then  'Size
                View.SetFocusedRowCellValue("f35String", View.GetFocusedRowCellDisplayText("f32String"))
            End If

            If e.Column.FieldName = "f08String" Then  'SBOX
                View.SetFocusedRowCellValue("f09String", View.GetFocusedRowCellDisplayText("f08String"))
            End If

            GridView1.RefreshData()
        End If

        If _prop02TargetGrid = TargetINBOUND._WSInbound5025ReturCustomer Or
            _prop02TargetGrid = TargetINBOUND._WSInbound5027BRJPinjamanMarketing Or
            _prop02TargetGrid = TargetINBOUND._WSInbound5028ReturKAE Or
            _prop02TargetGrid = TargetINBOUND._WSInbound5029ReturConsignment Then
            If e.Column.FieldName = "f08String" Then  'SBOX
                View.SetFocusedRowCellValue("f09String", View.GetFocusedRowCellDisplayText("f08String"))
                GridView1.SetFocusedRowCellValue("k00Boolean", True)
                GridView1.SetFocusedRowCellValue("k00Int", 1)
            End If
            GridView1.RefreshData()
        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._wsOutbound3501Sale Then

            If e.Column.FieldName = "f20String" Then
                ' Cek nilai boolean dari kolom k00Boolean
                Dim allowEdit As Boolean = False
                Dim boolVal = View.GetRowCellValue(e.RowHandle, "k00Boolean")
                If boolVal IsNot Nothing Then
                    allowEdit = Convert.ToBoolean(boolVal)
                End If

                If allowEdit Then
                    Dim result = MessageBox.Show("Do you want To edit the GJ value?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If result = DialogResult.Yes Then
                        ' Lanjutkan proses edit
                        Dim sku = View.GetRowCellValue(e.RowHandle, "k03String")
                        Dim gj = View.GetRowCellValue(e.RowHandle, "f20String")

                        Using objStock As New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
                            _prop03pdtDataSourceGrid = objStock._pb29EditGJForSaleSalesConsign(sku, gj)
                        End Using

                        MessageBox.Show("GJ update was successful.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ' Batalkan edit: kembalikan ke nilai lama (refresh)
                        View.CancelUpdateCurrentRow()
                        View.RefreshRow(e.RowHandle)
                    End If
                End If
            End If

        End If

        GridView1.PostEditor()
        GridView1.RefreshData()

        'If _prop02TargetGrid = TargetReceiveFG._WSInboundSKU Then
        '    If e.Column.FieldName = "f01Double" Then
        '        If CDbl(View.GetFocusedRowCellValue("f01Double")) > 0 Then
        '            If CDbl(View.GetFocusedRowCellValue("f01Double")) >= CDbl(View.GetFocusedRowCellValue("f02Double")) _
        '               And CDbl(View.GetFocusedRowCellValue("f01Double")) <= CDbl(View.GetFocusedRowCellValue("f03Double")) Then
        '                View.SetFocusedRowCellValue("f01String", "OK")
        '            Else
        '                View.SetFocusedRowCellValue("f01String", "NO")
        '            End If
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor

        Dim view = CType(sender, GridView)
        If _prop02TargetGrid = _pbEnumTargetGrid._wsOutbound3501Sale Then

            If view.FocusedColumn.FieldName = "f20String" Then
                Dim val = view.GetFocusedRowCellValue("k00Boolean")
                Dim isAllowed As Boolean = False

                If val IsNot Nothing Then
                    isAllowed = Convert.ToBoolean(val)
                End If

                view.ActiveEditor.ReadOnly = Not isAllowed
            End If
        End If
    End Sub


    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        If _isUpdating Then Return

        If e.Column.FieldName = "k00Boolean" AndAlso _prop02TargetGrid = _pbEnumTargetGrid._WSRptStore Then
            _isUpdating = True

            ' Jika user ingin mencentang baris ini (jadi True)
            If Convert.ToBoolean(e.Value) = True Then
                ' Set semua baris lain menjadi False
                For i As Integer = 0 To GridView1.RowCount - 1
                    If i <> e.RowHandle Then
                        GridView1.SetRowCellValue(i, "k00Boolean", False)
                        GridView1.SetRowCellValue(i, "k00Int", 0)
                    End If
                Next

                ' Set baris ini ke Int = 1
                GridView1.SetRowCellValue(e.RowHandle, "k00Int", 1)
            Else
                ' Jika user uncheck, set Int = 0
                GridView1.SetRowCellValue(e.RowHandle, "k00Int", 0)
            End If

            _isUpdating = False
        End If
    End Sub


    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = e.RowHandle + 1 'e.RowHandle.ToString()
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)
            e.Appearance.DrawString(e.Cache, "No.", e.Bounds)
            e.Handled = True
        End If
    End Sub

    Private Sub GridView1_LostFocus(sender As Object, e As EventArgs) Handles GridView1.LostFocus
        GridView1.PostEditor()
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim View As GridView = TryCast(sender, GridView)

        If e.RowHandle >= 0 Then
            If _prop02TargetGrid <> _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN AndAlso
                 _prop02TargetGrid <> _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS Then
                If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))) Then
                    Dim nCheck As Int16 = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))

                    e.Appearance.ForeColor = Color.Black
                    If nCheck = 1 Then
                        e.Appearance.BackColor = Color.LightYellow
                        'Else
                        '    e.Appearance.BackColor = Color.White
                    End If
                End If
            End If
        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN OrElse
            _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS Then

            If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k00Boolean"))) Then
                Dim vbTicked As Boolean = CBool(View.GetRowCellValue(e.RowHandle, View.Columns("k00Boolean")))
                If vbTicked Then
                    e.Appearance.BackColor = Color.LightYellow
                End If
            End If

        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSRptStore Then
            Dim objOffStore As Object = View.GetRowCellValue(e.RowHandle, View.Columns("f23String"))
            Dim offStore As String = If(objOffStore IsNot Nothing AndAlso objOffStore IsNot DBNull.Value, objOffStore.ToString(), "")

            If offStore = "TUTUP" Then
                e.Appearance.BackColor = Color.FromArgb(255, 198, 172)
            End If

        End If
        If _prop02TargetGrid = _pbEnumTargetGrid._WSEntrySKUForSale Then
            Dim CustomerCode As String = ""
            Dim TopCode As String = ""

            If Not View.GetRowCellValue(e.RowHandle, "f04String") Is DBNull.Value Then
                CustomerCode = View.GetRowCellValue(e.RowHandle, "f04String").ToString().Trim()
            End If

            If Not View.GetRowCellValue(e.RowHandle, "f21String") Is DBNull.Value Then
                TopCode = View.GetRowCellValue(e.RowHandle, "f21String").ToString().Trim()
            End If

            Dim isCustomerInvalid As Boolean = False
            Dim isTopInvalid As Boolean = False

            If CustomerCode <> "" AndAlso Not _cachedCustomerTable Is Nothing AndAlso _cachedCustomerTable.Rows.Count > 0 Then
                isCustomerInvalid = _cachedCustomerTable.Select("k02String = '" & CustomerCode.Replace("'", "''") & "'").Length = 0
            End If

            If TopCode <> "" AndAlso Not _cachedTopTable Is Nothing AndAlso _cachedTopTable.Rows.Count > 0 Then
                isTopInvalid = _cachedTopTable.Select("k13String = '" & TopCode.Replace("'", "''") & "'").Length = 0
            End If

            If isCustomerInvalid OrElse isTopInvalid Then
                e.Appearance.BackColor = Color.FromArgb(255, 198, 172)
            End If
        End If




        'If e.RowHandle >= 0 Then
        If _prop02TargetGrid = TargetINBOUND._WSInboundSKU Then
            Dim pcIsOK As String = View.GetRowCellValue(e.RowHandle, View.Columns("f01String"))
            If pcIsOK = "OK" Then
                e.Appearance.BackColor = Color.LightGreen
            Else
                If pcIsOK = "NO" Then
                    e.Appearance.BackColor = Color.LightSalmon
                    e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
                End If
            End If
        End If
        'End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBOrderViaBulkUploadXLS Then
            Dim pcBrand As String = View.GetRowCellValue(e.RowHandle, View.Columns("f01String"))
            Dim pcKadar As String = View.GetRowCellValue(e.RowHandle, View.Columns("f03String"))

            If pcBrand = "" Or pcKadar = "" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
                e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
            End If

            ' ===================== CREATED BY AKIRRA - 25/04/27 =====================
            ' memberikan warna merah serta striketrhrough pada row yang memiliki Product Code (k02String) duplikat.
            Dim value = View.GetRowCellValue(e.RowHandle, "k02String")?.ToString()

            If _prop03pdtDataSourceGrid.AsEnumerable() _
                .Count(Function(r) r.Field(Of String)("k02String") = value) > 1 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
                e.Appearance.Font = New Font("Courier New", 9, FontStyle.Bold Or FontStyle.Strikeout)
            End If
            ' ========================================================================
        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSInboundFromXLS10122024ReturCustomer Then
            Dim pcKadar As String = View.GetRowCellValue(e.RowHandle, View.Columns("f09String"))
            Dim pcBrand As String = View.GetRowCellValue(e.RowHandle, View.Columns("f15String"))
            Dim pcSOLD As String = View.GetRowCellValue(e.RowHandle, View.Columns("k01String"))
            Dim pcBOX As String = View.GetRowCellValue(e.RowHandle, View.Columns("f19String"))
            Dim pcTujuan As String = View.GetRowCellValue(e.RowHandle, View.Columns("f38String"))
            Dim pcStatus As String = View.GetRowCellValue(e.RowHandle, View.Columns("f43String"))
            Dim pcAlasan As String = View.GetRowCellValue(e.RowHandle, View.Columns("f23String"))

            If (pcBrand = "") Or (pcKadar = "") Or (pcSOLD <> "SOLD") Or pcBOX = "" Or pcTujuan <> "WAREHOUSE" AndAlso pcTujuan <> "REPAIR" Or pcStatus <> "FORSALE" AndAlso pcStatus <> "NOTFORSALE" Or pcAlasan = "" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
                e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
            End If

        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSInboundFromXLS11022025ReparasiWarehouse Then
            Dim pcKadar As String = View.GetRowCellValue(e.RowHandle, View.Columns("f10String"))
            Dim pcBrand As String = View.GetRowCellValue(e.RowHandle, View.Columns("f16String"))
            Dim pcItem As String = View.GetRowCellValue(e.RowHandle, View.Columns("f12String"))
            Dim pnBerat As Double = View.GetRowCellValue(e.RowHandle, View.Columns("f02Double"))

            If (pcBrand = "") Or (pcKadar = "") Or (pcItem = "") Or (pnBerat = 0.0) Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
                e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
            End If

        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSTransaksi03ReparasiLebur Then
            If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k03String"))) Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
                e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
            End If
        End If


        ' ===================== UPDATED BY AKIRRA - 25/04/25 =====================
        If _prop02TargetGrid = _pbEnumTargetGrid._WSStockCheck Then
            If e.RowHandle >= 0 Then
                ' mengubah background colour row yang NOTFORSALE menjadi merah.
                If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k00Int02"))) Then
                    Dim nCheck As Int16 = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int02"))

                    e.Appearance.ForeColor = Color.Black
                    If nCheck = 1 Then
                        e.Appearance.BackColor = Color.OrangeRed
                    End If
                End If
            End If

        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSInbound5028ReturKAE Or
                _prop02TargetGrid = _pbEnumTargetGrid._WSInbound5029ReturConsignment Then

            If e.RowHandle >= 0 Then
                If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))) Then
                    Dim nCheck As Int16 = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))

                    e.Appearance.ForeColor = Color.Black
                    If nCheck = 1 Then
                        e.Appearance.BackColor = Color.PaleGoldenrod
                    Else
                        e.Appearance.BackColor = Color.White
                    End If
                End If

                ' mengubah background colour column.
                If e.Column.FieldName = "f03Date" Then          'tgl.mutasi
                    e.Appearance.BackColor = Color.LightPink
                End If
                If e.Column.FieldName = "f02String" Then        'no.order
                    e.Appearance.BackColor = Color.LightYellow
                End If
                If e.Column.FieldName = "f01String" Then        'p. code
                    e.Appearance.BackColor = Color.LightGreen
                End If
                If e.Column.FieldName = "k03String" Then        'sku
                    e.Appearance.BackColor = Color.LightBlue
                End If

            End If
        End If
        ' ====================================================================================

        ' ===================== UPDATED BY AKIRRA and AGA - 25/03/23 =====================
        If _prop02TargetGrid = _pbEnumTargetGrid._WSPKBCustomer Then
            If e.RowHandle >= 0 Then
                ' mengubah background colour row yang NOTFORSALE menjadi merah.
                If Not IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))) Then
                    Dim nCheck As Int16 = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))

                    If nCheck = 1 Then
                        e.Appearance.ForeColor = Color.White
                        e.Appearance.BackColor = Color.FromArgb(218, 108, 108)
                        e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold, GraphicsUnit.Point)

                    End If
                End If
            End If
        End If
        '====================================================================================

    End Sub

    Private pnf01SmallInt As Integer = 0 : Private pnf01Double As Double = 0.0
    Private _Totf01SmallInt As Integer = 0 : Private _Totf01Double As Double = 0.0
    Private _TotChecked As Integer = 0 : Private _TotUnChecked As Integer = 0
    Private plBoolean As Boolean = False

    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate

        If _prop02TargetGrid = _pbEnumTargetGrid._WSInbound5021InhouseProduksi Or
           _prop02TargetGrid = _pbEnumTargetGrid._wsOut5052PKBCreateSuratJalan Then

            Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
            Dim View As GridView = CType(sender, GridView)

            If e.SummaryProcess = CustomSummaryProcess.Start Then
                _TotChecked = 0
                _Totf01SmallInt = 0
                _Totf01Double = 0.0
                _TotUnChecked = GridView1.RowCount
            End If

            If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                plBoolean = CBool(View.GetRowCellValue(e.RowHandle, "k00Boolean"))
                pnf01SmallInt = CInt(View.GetRowCellValue(e.RowHandle, "f01SmallInt"))
                pnf01Double = CDbl(View.GetRowCellValue(e.RowHandle, "f01Double"))

                If plBoolean Then
                    Select Case summaryID
                        Case 1, 4
                            _TotChecked = _TotChecked + 1
                            _TotUnChecked = _TotUnChecked - 1
                        Case 2
                            _Totf01SmallInt += pnf01SmallInt
                        Case 3
                            _Totf01Double += pnf01Double
                    End Select
                End If
            End If

            If e.SummaryProcess = CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 1
                        e.TotalValue = _TotChecked
                    Case 2
                        e.TotalValue = _Totf01SmallInt
                    Case 3
                        e.TotalValue = _Totf01Double
                    Case 4
                        e.TotalValue = _TotUnChecked
                End Select

            End If
        End If

        If _prop02TargetGrid = _pbEnumTargetGrid._WSPKBCustomer Then

            Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
            Dim View As GridView = CType(sender, GridView)

            If e.SummaryProcess = CustomSummaryProcess.Start Then
                _Totf01SmallInt = 0
                _Totf01Double = 0.0
            End If

            If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                plBoolean = CBool(View.GetRowCellValue(e.RowHandle, "k00Boolean"))
                pnf01SmallInt = CInt(View.GetRowCellValue(e.RowHandle, "f01SmallInt"))
                pnf01Double = CDbl(View.GetRowCellValue(e.RowHandle, "f01Double"))

                If plBoolean Then
                    Select Case summaryID
                        Case 1
                            _Totf01SmallInt += pnf01SmallInt
                        Case 2
                            _Totf01Double += pnf01Double
                    End Select
                End If
            End If

            If e.SummaryProcess = CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 1
                        e.TotalValue = _Totf01SmallInt
                    Case 2
                        e.TotalValue = _Totf01Double
                End Select

                If summaryID = 1 Then
                    Dim objTotQuantity As _dlgGetData = AddressOf _prop11objSpinEdit.__GetDataIvk
                    Dim pnTQty As Integer = objTotQuantity.Invoke()

                    Dim pnTotPO As Integer = 0
                    If (pnTQty - e.TotalValue) < 0 Then
                        pnTotPO = 0
                    Else
                        pnTotPO = pnTQty - e.TotalValue
                    End If

                    Dim objTotPO As _dlgSetData = AddressOf _prop12objSpinEdit.__SetDataIvk
                    objTotPO.Invoke(pnTotPO)
                End If
            End If

        End If

    End Sub

    Private Sub GridView1_CellMerge(sender As Object, e As CellMergeEventArgs) Handles GridView1.CellMerge
        If _prop02TargetGrid = _pbEnumTargetGrid._WSOut10ProsesPKB Then
            If (e.Column.FieldName = "f05String") Then
                Dim view As GridView = CType(sender, GridView)
                Dim val1 As String = view.GetRowCellValue(e.RowHandle1, e.Column)
                Dim val2 As String = view.GetRowCellValue(e.RowHandle2, e.Column)
                e.Merge = (val1 = val2)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Cursor = Cursors.WaitCursor

        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("Maaf ... ada library yg harus terinstall, silahkan hub IT.", "Error")
            Cursor = Cursors.Default
            Return
        End If

        ' ===================== UPDATED BY AKIRRA - 25/07/04 =====================
        ' prevent auto print while double-clicking on the grid.
        Dim rsl As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(Me,
            "Apakah Anda yakin ingin Print data grid ?",
            "Print Confirmation | " & _prop01User._UserProp01cTitle,
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question)

        If rsl = DialogResult.Yes Then
            GridControl1.ShowPrintPreview()
        End If
        ' ========================================================================


        Cursor = Cursors.Default
    End Sub

#End Region

#Region "event - control"
    Private Sub _01lCheckSemua_CheckedChanged(sender As Object, e As EventArgs) Handles _01lCheckSemua.CheckedChanged
        ' ===================== UPDATED BY AKIRRA - 25/04/30 =====================
        ' agar ketika user melakukan select all pada kondisi grid terfilter, select all hanya diterapkan pada gridview yang terfilter (bukan datasource).

        If _01lCheckSemua.Checked Then
            ' if checked: hanya baris yang terfilter (pada grid)

            If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN Or _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS Then
                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim dataRow As DataRow = GridView1.GetDataRow(i)
                    If dataRow IsNot Nothing Then
                        dataRow("k00Boolean") = True
                    End If
                Next

            Else
                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim dataRow As DataRow = GridView1.GetDataRow(i)
                    If dataRow IsNot Nothing Then
                        dataRow("k00Boolean") = True
                        dataRow("k00Int") = 1
                    End If
                Next

            End If

        Else
            ' if unchecked: semua baris di datasource
            If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN Or _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS Then
                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim dataRow As DataRow = GridView1.GetDataRow(i)
                    If dataRow IsNot Nothing Then
                        dataRow("k00Boolean") = False

                        If _prop02TargetGrid = _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN Then
                            dataRow("k00Int01") = 10
                            dataRow("f29String") = dataRow("f29String", DataRowVersion.Original)

                        Else
                            dataRow("k00Int") = 10
                            'dataRow("f29String") = ""
                        End If
                    End If
                Next

            Else
                For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
                    dtRow("k00Boolean") = False
                    dtRow("k00Int") = 0
                Next

            End If

        End If
        _prop03pdtDataSourceGrid.AcceptChanges()

        ' ======================================================================
    End Sub

    ' ===================== UPDATED BY AKIRRA - 25/04/30 =====================
    ' agar ketika user melakukan filter pada grid, kondisi select all berubah menjadi default (false/unchecked).
    Private Sub GridView1_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GridView1.ColumnFilterChanged
        _01lCheckSemua.Checked = False
    End Sub
    ' ======================================================================

#End Region

    Public Delegate Function __dlgGetDataDouble(ByVal prmcProdCodeORSKU As String) As Double
    Public Delegate Sub __dlgTambahDataGrid(ByVal prmdtNewData As DataTable, ByVal prmcTarget As String, ByVal prmnTotBerat As Double)
    Public Delegate Sub __dlgSetSBox(ByVal prmcFieldKodeSBox As String, ByVal prmcValueKodeSBox As String, ByVal prmcFieldNamaSBox As String, ByVal prmcValueNamaSBox As String)
    Public Delegate Sub __dlgSetTrueCheckbox(ByVal prmcFieldSKU As String, ByVal prmcValueSKU As String)
    Public Delegate Sub __dlgSetVisibilityCheckBox(ByVal prmlShow As Boolean)
    Public Delegate Sub __dlgRefreshPKB(ByVal prmDataPKB As DataTable)
    Public Delegate Sub __dlgEntryDataSale(ByVal prmcSKU As String, ByVal prmdtStock As DataTable, ByVal prmGJ As String, ByVal prmCodeCust As String, ByVal prmCust As String, ByVal prmTOPCode As String, ByVal prmTOP As String)
    Public Delegate Sub __dlgSetUpdateField(ByVal prmcData As String, ByVal prmcJml As Integer)

    Public Delegate Sub pbMd08SetApprovalStatus(ByVal vsTarget As String, ByVal vsApproval As String)

#Region "method - invoke"

    Public Sub _ivkUpdateReservedPKB(ByVal prmcNoDocPKB As String, ByVal prmcQtyOST As Integer)
        '._colf38String.Caption = "ReservedPKB"
        Dim pnJmlProses As Integer = 1
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If dtRow("f38String") = "" Then
                If pnJmlProses > prmcQtyOST Then
                    Exit For
                Else
                    dtRow("f38String") = prmcNoDocPKB
                    pnJmlProses = pnJmlProses + 1
                End If
            End If
        Next

        If pnJmlProses > 0 Then
            _prop03pdtDataSourceGrid.AcceptChanges()
        End If
    End Sub

    Public Function _ivkGetDataBrtPerPcsPKBCustomer(ByVal prmcTargetPKB As String) As Double
        Dim pnDouble As Double = 0.0

        If prmcTargetPKB = "SKU" Then
            Dim pnTotPcs As Integer = CInt(_colf01SmallInt.SummaryItem.SummaryValue)
            Dim pnTotBerat As Double = CDbl(_colf01Double.SummaryItem.SummaryValue)
            pnDouble = pnTotBerat / pnTotPcs
        Else
            For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
                pnDouble = dtRow("f01Double")

                Exit For
            Next
        End If

        Return pnDouble
    End Function

    Public Sub _ivkAddNewDataGridMergeSplitSKU(ByVal prmdtDataBaruGrid As DataTable, ByVal prmcTargetProses As String, ByVal prmnTotalBerat As Double)
        _colf01Int.OptionsColumn.ReadOnly = True        '"Pcs Proses"
        _colf02Double.OptionsColumn.ReadOnly = True     '"Berat Proses"

        If prmcTargetProses = "MERGE" Then
            _MergeSKUAddNewData(prmdtDataBaruGrid, prmnTotalBerat)
        Else
            If prmcTargetProses = "SPLIT" Then
                _SplitSKUAddNewData(prmdtDataBaruGrid, prmnTotalBerat)

                _colf01Int.OptionsColumn.ReadOnly = False        '"Pcs Proses"
                _colf02Double.OptionsColumn.ReadOnly = False     '"Berat Proses"
            End If
        End If
    End Sub

    Public Sub _ivkSettingStorageBoxInbound(ByVal prmcFieldKodeStorageBox As String, ByVal prmcValueKodeStorageBox As String, ByVal prmcFieldNamaStorageBox As String, ByVal prmcValueNamaStorageBox As String)
        Cursor = Cursors.WaitCursor

        ' ===================== UPDATED BY AKIRRA - 25/04/30 =====================
        ' agar menerapkan sbox pada gridview saja, tidak ke datasource.

        For i As Integer = 0 To GridView1.RowCount - 1
            Dim dataRow As DataRow = GridView1.GetDataRow(i)
            If dataRow IsNot Nothing Then
                dataRow(prmcFieldKodeStorageBox) = prmcValueKodeStorageBox
                dataRow(prmcFieldNamaStorageBox) = prmcValueNamaStorageBox
            End If
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()

        ' ======================================================================

        'For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
        '    dtRow(prmcFieldKodeStorageBox) = prmcValueKodeStorageBox
        '    dtRow(prmcFieldNamaStorageBox) = prmcValueNamaStorageBox
        'Next
        '_prop03pdtDataSourceGrid.AcceptChanges()

        Cursor = Cursors.Default
    End Sub

    Public Sub _ivkSetTrueCheckbox(ByVal prmcFieldWSSKU As String, ByVal prmcValueWSSKU As String)
        Cursor = Cursors.WaitCursor

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If dtRow(prmcFieldWSSKU) = prmcValueWSSKU Then
                dtRow("k00Boolean") = True
                dtRow("k00Int") = 1
            End If
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()

        Cursor = Cursors.Default
    End Sub

    Public Sub _ivkSetVisibilityCheckBox(ByVal prmlShowCheckBox As Boolean)
        If prmlShowCheckBox Then
            _colk00Boolean.Visible = True
            _colk00Boolean.VisibleIndex = 0
        Else
            _colk00Boolean.Visible = False
            _colk00Int.Visible = False

            _colk00Boolean.VisibleIndex = -1
            _colk00Int.VisibleIndex = -1
        End If
    End Sub

    Public Sub _ivkRefreshDisplayGrid(ByVal prmpdtRefreshDataPKB As DataTable)
        Cursor = Cursors.WaitCursor

        Dim dvView As DataView = New DataView(prmpdtRefreshDataPKB)

        Dim pcKolomData = New String() {"k02String", "k03String", "f02String", "f04String", "f06String", "f15String", "f17String", "f01SmallInt", "f01Double"}

        Dim pdtDataPKB As New DataTable
        pdtDataPKB = dvView.ToTable(True, pcKolomData)

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = pdtDataPKB

        GridControl1.Refresh()

        Cursor = Cursors.Default
    End Sub

    Public Sub _ivkEntrySKUSale(ByVal prmcString As String, ByVal prmData As DataTable, Optional ByVal prmGJ As String = "", Optional ByVal prmCodeCust As String = "", Optional ByVal prmCust As String = "",
                                Optional ByVal prmTOPCode As String = "", Optional ByVal prmTOP As String = "")

        Dim listSudahDitansaksikan As New List(Of String)

        Dim dtRowExist() As DataRow
        dtRowExist = _prop03pdtDataSourceGrid.Select(" k03String = '" & prmcString & "'")
        If dtRowExist.Count > 0 Then
            listSudahDitansaksikan.Add(prmcString)
        End If

        If listSudahDitansaksikan.Count > 0 Then
            Dim hasilText As String = "SKU berikut sudah ditransaksikan:" & vbCrLf & vbCrLf & String.Join(vbCrLf, listSudahDitansaksikan)
            MsgBox(hasilText, vbOKOnly + vbInformation, "Informasi")
            'Dim tempFilePath As String = Path.Combine(Path.GetTempPath(), "SKU_Sudah_Ditransaksikan.txt")
            'File.WriteAllText(tempFilePath, hasilText)
            'Process.Start("notepad.exe", tempFilePath)
        Else
            Dim dtRow() As DataRow
            dtRow = prmData.Select(" k03String = '" & prmcString & "'")
            If dtRow.Count > 0 Then

                Dim vdiNoDocSjSettle As New Dictionary(Of String, String) From {
                    {"SJ/SS/", "SJ/SC/"},
                    {"SJ/CS/", "SJ/CC/"},
                    {"SJ/XB/", "SJ/XC/"}
                }

                For Each dtItem As Object In dtRow
                    Dim vsNoSj As String = dtItem("f18String")?.ToString()
                    Dim vsNoSjSettle As String = vsNoSj
                    For Each kvp In vdiNoDocSjSettle
                        If vsNoSj.StartsWith(kvp.Key) Then
                            vsNoSjSettle = vsNoSj.Replace(kvp.Key, kvp.Value)
                            Exit For
                        End If
                    Next

                    _prop03pdtDataSourceGrid.Rows.Add(New Object() {"", "", dtItem("k03String"),
                                dtItem("f01String"), dtItem("f02String"), "", prmCodeCust, prmCust, dtItem("f06String"), dtItem("f07String"), dtItem("f08String"), dtItem("f09String"), dtItem("f10String"),
                                "", dtItem("f12String"), "", dtItem("f14String"), "", dtItem("f16String"), "", dtItem("f18String"), "", prmGJ,
                                prmTOPCode, prmTOP, dtItem("f23String"), "", "", "", "", "", "", "",
                                "", "", "", "", "", "", "", "", "", vsNoSjSettle, dtItem("f01TinyInt"), dtItem("f01SmallInt"), 0, dtItem("f01Double"), 0.0, 0.0,
                                dtItem("f01Date"), "3000-01-01", "3000-01-01", "", "", "", "", ""})
                Next

                If _cachedCustomerTable Is Nothing Or _cachedTopTable Is Nothing Then
                    Using objNasaMaster As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
                        _cachedCustomerTable = objNasaMaster.__pb04GetDataTable52Customer()
                        _cachedTopTable = objNasaMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("TOP")
                    End Using
                End If

            Else
                MsgBox("Maaf... SKU '" & prmcString & "' ini ... TIDAK ADA ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            End If
        End If

    End Sub

    Public Sub _ivkAddNewBox(ByVal prmcKode As String, ByVal prmcNama As String)
        Dim objBox As __dlgFilterData = AddressOf objRepoWS05Master.__ivkAddNewSBox
        objBox.Invoke(prmcKode, prmcNama)
    End Sub


    ' ===================== CREATED BY AKIRRA - 25/07/09 =====================
    ' invoke untuk set STATUS APPROVAL
    Public Sub _ivkSetApprovalStatus(ByVal vsTarget As String, ByVal vsApproval As String)
        Cursor = Cursors.WaitCursor
        Dim vbTick As Boolean = False
        Dim vsApproval2 As Int16 = 10

        For i As Integer = 0 To GridView1.RowCount - 1
            Dim dataRow As DataRow = GridView1.GetDataRow(i)
            If dataRow IsNot Nothing Then
                Dim vsReason As String = dataRow("f29String", DataRowVersion.Original)?.ToString()

                If vsApproval = "APPROVE" Then
                    vbTick = True
                    vsApproval2 = 1
                ElseIf vsApproval = "REJECT" Then
                    vbTick = True
                    vsApproval2 = 2
                    vsReason = "[REJECT] "
                ElseIf vsApproval = "PENDING" Then
                    vbTick = True
                    vsApproval2 = 3
                    vsReason = "[PENDING] "
                End If

                If vsTarget = "FIN" Then
                    dataRow("k00Boolean") = vbTick
                    dataRow("k00Int01") = vsApproval2
                    dataRow("f29String") = vsReason
                ElseIf vsTarget = "SLS" Then
                    dataRow("k00Boolean") = vbTick
                    dataRow("k00Int") = vsApproval2
                End If
            End If
        Next

        Cursor = Cursors.Default
    End Sub
    ' ==============================================================================

#End Region

#Region "********** method Private - UPDATE/CHANGE **********"

    Public Enum _pbEnumTargetGrid
        'Transaksi
        _WSReceiveDOFinishGoodsFromCitrix = 0
        _WSInboundSKU = 5

        _WSMutasiAntarSLoc = 6
        _WSApproveMutasi = 7
        _WSRepairLebur = 8


        'Distribusi FG => ucWS23LN01PKB (container)
        _WSPKBCustomer = 9

        'Distribusi FG => ucWS23LL01DISTRIBUSIFINISHGOODS
        _WSDistribusiFGPKB = 91
        _WSDistribusiFGPKBApproveSLS = 92
        _WSDistribusiFGPKBApproveFIN = 93
        _WSDistribusiFGPKBOrderViaBulkUploadXLS = 94

        'Distribusi FG => ucWS25DX01STOCKCHECK (container)
        _WSStockCheck = 95

        _WSMergeSplitSKU = 10

        'Outbound
        _WSOutboundSuratJalan = 11
        _WSOutboundSuratJalanAirwayBill = 110
        _WSOutboundSuratJalanPICKUP = 111
        _WSOutboundSuratJalanDELIVERED = 112

        _WSOutboundPenjualan = 12

        'Transaksi Warehouse :> ucWS24FK01TRANSAKSIWAREHOUSE
        _WSTransaksi01MutasiAntarKAE = 30
        _WSTransaksi02ApproveMutasiAntarKAE = 31
        _WSTransaksi03ReparasiLebur = 32
        '_WSTransaksi04ReparasiCustomer = 33
        _WSTransaksi05ReturSupplier = 34

        'Inbound :> ucWS24FP01INBOUND
        _WSInbound5021InhouseProduksi = 5021
        _WSInbound5022InhouseChain = 5022
        _WSInbound5023RepairWarehouse = 5023
        _WSInbound5024RepairCustomer = 5024
        _WSInbound5025ReturCustomer = 5025
        _WSInbound5026External = 5026
        _WSInbound5027BRJPinjamanMarketing = 5027
        _WSInbound5028ReturKAE = 5028
        _WSInbound5029ReturConsignment = 5029

        _WSPKBConsumeInbound3034 = 3034

        _WSOut10ProsesPKB = 60

        'Report
        '_WSRptTrackingSKU = 20
        '_WSRptTrackingPKB = 21
        _WSRptINOUTSLoc_IN = 22
        _WSRptINOUTSLoc_OUT = 23
        _WSRptPosterSaldoCurrent = 25

        'Report - Inbound
        _WSRptInbound200All = 200
        _WSRptInbound201ByVendor = 201

        'Report - General
        _WSRptGeneral300Stock = 300
        _WSRptGeneral301StockProductCode = 301

        'Entrian Sale - NEW
        _WSStockForSale = 350
        _WSEntrySKUForSale = 351

        'Report - Transaksi Warehouse - Semua
        _wsRptTransaksiWS370Semua = 370

        'Report - Outbound Sale
        _wsOutbound3501Sale = 3501

        _wsOut5052PKBCreateSuratJalan = 5052

        'BULK UPLOAD - XLS
        _WSInboundFromXLS10122024ReturCustomer = 101
        _WSInboundFromXLS11022025ReparasiWarehouse = 102

        'PickingList
        _WSOutbound5051PickingListSKU = 505128620
        _WSOutbound5051PickingListProdCode = 505128621

        'Report Store
        _WSRptStore = 52

        'Report AgregatSJ
        _WSRptAgregatSJ = 352720
    End Enum

    Private Sub _cm20InstallSettingWSGrid()

        Select Case _prop02TargetGrid
            Case _pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
                _cm21SettingWSGridReceiveDOFG()

            Case _pbEnumTargetGrid._WSInboundSKU
                _cm22SettingWSGridInboundSKU()

            Case _pbEnumTargetGrid._WSMutasiAntarSLoc, _pbEnumTargetGrid._WSApproveMutasi
                _cm23SettingWSMutasiAntarSLoc()

            Case _pbEnumTargetGrid._WSRepairLebur
                _cm24SettingWSRepairLebur()

            'Case _pbEnumTargetGrid._WSRptTrackingSKU
            '    _cm25SettingWSRptTrackingSKU()

            'Case _pbEnumTargetGrid._WSRptTrackingPKB
            '    _cm251SettingWSRptTrackingPKB()

            Case _pbEnumTargetGrid._WSRptINOUTSLoc_IN
                _cm26SettingWSRptINOUTSLoc("In")

            Case _pbEnumTargetGrid._WSRptINOUTSLoc_OUT
                _cm26SettingWSRptINOUTSLoc("OUT")

            Case _pbEnumTargetGrid._WSPKBCustomer
                _cm27SettingWSPKBCustomer()

            Case _pbEnumTargetGrid._WSMergeSplitSKU
                _cm28SettingMergeSplitSKU()

            Case _pbEnumTargetGrid._WSRptPosterSaldoCurrent
                _cm29SettingWSRptPosterSaldoCurrent()

            Case _pbEnumTargetGrid._WSOutboundSuratJalan
                _cm30SettingWSOutboundSuratJalan()

            Case _pbEnumTargetGrid._WSOutboundSuratJalanAirwayBill
                _cm301SettingWSOutboundSuratJalanAirwayBill()

            Case _pbEnumTargetGrid._WSOutboundSuratJalanPICKUP
                _cm302SettingWSOutboundSuratJalanPickup()

            Case _pbEnumTargetGrid._WSOutboundSuratJalanDELIVERED
                _cm303SettingWSOutboundSuratJalanDelivered()

            Case _pbEnumTargetGrid._WSOutboundPenjualan
                _cm31SettingWSOutboundPenjualan()

            Case _pbEnumTargetGrid._WSTransaksi01MutasiAntarKAE
                _cm32SettingWSTransaksiMutasiStockKAE()

            Case _pbEnumTargetGrid._WSTransaksi03ReparasiLebur
                _cm321SettingWSTransaksiReparasiLebur()

            Case _pbEnumTargetGrid._WSTransaksi05ReturSupplier
                _cm322SettingWSTransaksiReturSupplier()

            Case _pbEnumTargetGrid._WSInbound5021InhouseProduksi, _pbEnumTargetGrid._WSInbound5022InhouseChain,
                 _pbEnumTargetGrid._WSInbound5023RepairWarehouse, _pbEnumTargetGrid._WSInbound5024RepairCustomer,
                 _pbEnumTargetGrid._WSInbound5025ReturCustomer, _pbEnumTargetGrid._WSInbound5026External,
                 _pbEnumTargetGrid._WSInbound5027BRJPinjamanMarketing, _pbEnumTargetGrid._WSInbound5028ReturKAE,
                 _pbEnumTargetGrid._WSInbound5029ReturConsignment, _pbEnumTargetGrid._WSPKBConsumeInbound3034
                _cm33SettingWS24FP01INBOUND()

            Case _pbEnumTargetGrid._WSDistribusiFGPKB, _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS,
                 _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN, _pbEnumTargetGrid._WSDistribusiFGPKBOrderViaBulkUploadXLS
                _cm34SettingWSDistribusiFG()

            Case _pbEnumTargetGrid._WSStockCheck
                _cm35SettingWSStockCheck()

            Case _pbEnumTargetGrid._WSRptInbound200All, _pbEnumTargetGrid._WSRptInbound201ByVendor,
                 _pbEnumTargetGrid._WSRptGeneral300Stock, _pbEnumTargetGrid._WSRptGeneral301StockProductCode,
                 _pbEnumTargetGrid._wsOutbound3501Sale, _pbEnumTargetGrid._wsRptTransaksiWS370Semua,
                 _pbEnumTargetGrid._WSRptStore, _pbEnumTargetGrid._WSRptAgregatSJ
                _cm50SettingWS24B3REPORT()

            Case _pbEnumTargetGrid._WSOut10ProsesPKB
                _cm60SettingWSProsesPKB()

            Case _pbEnumTargetGrid._WSStockForSale
                _cm70SettingWSStockForSale()

            Case _pbEnumTargetGrid._WSEntrySKUForSale
                _cm71SettingWSEntrySKUForSale()

            Case _pbEnumTargetGrid._wsOut5052PKBCreateSuratJalan
                _cm5052SettingWSPKBCreateSuratJalan()

            Case _pbEnumTargetGrid._WSInboundFromXLS10122024ReturCustomer,
                 _pbEnumTargetGrid._WSInboundFromXLS11022025ReparasiWarehouse
                _cm72SettingWS24LD01BULKUPLOADXLSFromInbound()

            Case _pbEnumTargetGrid._WSOutbound5051PickingListSKU
                _cm73PickingListSKU5051()

            Case _pbEnumTargetGrid._WSOutbound5051PickingListProdCode
                _cm73PickingListProdCode5051()


        End Select
    End Sub

    Private Sub _cm21SettingWSGridReceiveDOFG()
        Cursor = Cursors.WaitCursor

        Dim objclsGrid As New clsWSNasaSettingGridInbound With {._prop01cTargetINBOUND = clsWSNasaSettingGridInbound.TargetINBOUND._WSReceiveDOFGFromCITRIX,
                                                                ._prop02User = _prop01User,
                                                                ._prop03Grid = Me,
                                                                ._prop04DataTableMaster = _cm11DataTableMasterWarehouse("SBOX"),
                                                                ._prop05DataTableMaster = _cm11DataTableMasterWarehouse("SLOC-ALL")}
        objclsGrid._pbSetting01ReceiveDOFinishGoods()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm22SettingWSGridInboundSKU()
        Cursor = Cursors.WaitCursor

        Dim objGridSetting As New clsWSNasaSettingGridInbound With {._prop01cTargetINBOUND = clsWSNasaSettingGridInbound.TargetINBOUND._WSInboundSKU,
                                                                    ._prop02User = _prop01User,
                                                                    ._prop03Grid = Me,
                                                                    ._prop04DataTableMaster = _cm11DataTableMasterWarehouse("SBOX"),
                                                                    ._prop05DataTableMaster = _cm11DataTableMasterWarehouse("SLOC-ALL")}
        objGridSetting._pbSetting02InboundSKU()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm23SettingWSMutasiAntarSLoc()
        Cursor = Cursors.WaitCursor
        Dim objGridMutasiAntarSLoc As New clsWSNasaSettingGridMutasi With {._prop01cTargetReceiveFG = clsWSNasaSettingGridMutasi.TargetMutasiWSSKU._TargetWSSKUMutasiAntarSLoc,
                                                                           ._prop02User = _prop01User,
                                                                           ._prop03Grid = Me}
        objGridMutasiAntarSLoc._pbSettingGrid()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm24SettingWSRepairLebur()
        Cursor = Cursors.WaitCursor
        Dim objGridRepairLebur As New clsWSNasaSettingGridMutasi With {._prop01cTargetReceiveFG = clsWSNasaSettingGridMutasi.TargetMutasiWSSKU._TargetWSRepairDanLebur,
                                                                       ._prop02User = _prop01User,
                                                                       ._prop03Grid = Me}
        objGridRepairLebur._pbSettingGrid()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm26SettingWSRptINOUTSLoc(ByVal prmcINOUT As String)
        Cursor = Cursors.WaitCursor
        Dim objGridRptINOUTSLoc As New clsWSNasaSettingGridMutasi

        With objGridRptINOUTSLoc
            If prmcINOUT = "In" Then
                ._prop01cTargetReceiveFG = clsWSNasaSettingGridMutasi.TargetMutasiWSSKU._TargetWSRptInOutSLoc_IN
            Else
                ._prop01cTargetReceiveFG = clsWSNasaSettingGridMutasi.TargetMutasiWSSKU._TargetWSRptInOutSLoc_OUT
            End If
            ._prop02User = _prop01User
            ._prop03Grid = Me
        End With

        objGridRptINOUTSLoc._pbSettingGrid()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm27SettingWSPKBCustomer()
        Cursor = Cursors.WaitCursor

        Dim objGridWSPKBCustomer As New clsWSNasaSettingGridMutasi With {._prop01cTargetReceiveFG = clsWSNasaSettingGridMutasi.TargetMutasiWSSKU._TargetWSPKBCustomer,
                                                                         ._prop02User = _prop01User,
                                                                         ._prop03Grid = Me}
        objGridWSPKBCustomer._pbSettingGrid()

        _PKBCustomer_SettingTotalSummary()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm28SettingMergeSplitSKU()
        Cursor = Cursors.WaitCursor

        Dim objclsGrid As New clsWSNasaSettingGridInbound With {._prop01cTargetINBOUND = clsWSNasaSettingGridInbound.TargetINBOUND._WSReceiveFGMixFromMergeSplitSKU,
                                                                ._prop02User = _prop01User,
                                                                ._prop03Grid = Me}
        objclsGrid._pbSetting03MergeSplitSKU()

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm29SettingWSRptPosterSaldoCurrent()
        Cursor = Cursors.WaitCursor
        Dim objGridRptPosterSaldoCurrent As New clsWSNasaSettingGridMutasi With {._prop01cTargetReceiveFG = clsWSNasaSettingGridMutasi.TargetMutasiWSSKU._TargetWSRptPosterSaldoCurrent,
                                                                                 ._prop02User = _prop01User,
                                                                                 ._prop03Grid = Me}
        objGridRptPosterSaldoCurrent._pbSettingGrid()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm30SettingWSOutboundSuratJalan()
        Cursor = Cursors.WaitCursor
        Dim objOutboundSuratJalan As New clsWSNasaSettingGridOutbound With {._prop01cTargetReceiveFG = clsWSNasaSettingGridOutbound.TargetWSOutbound._wsOutboundSuratJalan,
                                                                            ._prop02User = _prop01User,
                                                                            ._prop03Grid = Me}
        objOutboundSuratJalan._pbSetting01SuratJalan()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm301SettingWSOutboundSuratJalanAirwayBill()
        Cursor = Cursors.WaitCursor
        Dim objOutboundSJAirwayBill As New clsWSNasaSettingGridOutbound With {._prop01cTargetReceiveFG = clsWSNasaSettingGridOutbound.TargetWSOutbound._WSOutboundSuratJalanAirwayBill,
                                                                              ._prop02User = _prop01User,
                                                                              ._prop03Grid = Me,
                                                                              ._prop04DataTableMaster = _cm11DataTableMasterWarehouse("COURIER")}
        objOutboundSJAirwayBill._pbSetting011SuratJalanAirwayBill()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm302SettingWSOutboundSuratJalanPickup()
        Cursor = Cursors.WaitCursor
        Dim objOutboundSJAirwayBill As New clsWSNasaSettingGridOutbound With {._prop01cTargetReceiveFG = clsWSNasaSettingGridOutbound.TargetWSOutbound._WSOutboundSuratJalanPICKUPbyCourier,
                                                                              ._prop02User = _prop01User,
                                                                              ._prop03Grid = Me}
        objOutboundSJAirwayBill._pbSetting012SuratJalanPickupbyCourier()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm303SettingWSOutboundSuratJalanDelivered()
        Cursor = Cursors.WaitCursor
        Dim objOutboundSJAirwayBill As New clsWSNasaSettingGridOutbound With {._prop01cTargetReceiveFG = clsWSNasaSettingGridOutbound.TargetWSOutbound._WSOutboundSuratJalanDELIVEREDbyCourier,
                                                                              ._prop02User = _prop01User,
                                                                              ._prop03Grid = Me}
        objOutboundSJAirwayBill._pbSetting013SuratJalanDeliveredbyCourier()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm31SettingWSOutboundPenjualan()
        Cursor = Cursors.WaitCursor
        Dim objOutboundPenjualan As New clsWSNasaSettingGridOutbound With {._prop01cTargetReceiveFG = clsWSNasaSettingGridOutbound.TargetWSOutbound._wsOutboundPenjualan,
                                                                            ._prop02User = _prop01User,
                                                                            ._prop03Grid = Me}
        objOutboundPenjualan._pbSetting02Penjualan()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm32SettingWSTransaksiMutasiStockKAE()
        Cursor = Cursors.WaitCursor
        Dim objTransaksiWS01 As New clsWSNasaSettingGridTransaksiWarehouse With {._prop01cTargetTransaksiWS = clsWSNasaSettingGridTransaksiWarehouse.TargetWSTransaksi._01WSTransaksiMutasiAntarKAE,
                                                                               ._prop02User = _prop01User,
                                                                               ._prop03Grid = Me}
        objTransaksiWS01._pbSettingTransaksiWarehouse()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm321SettingWSTransaksiReparasiLebur()
        Cursor = Cursors.WaitCursor
        Dim objTransaksiWS02 As New clsWSNasaSettingGridTransaksiWarehouse With {._prop01cTargetTransaksiWS = clsWSNasaSettingGridTransaksiWarehouse.TargetWSTransaksi._03WSTransaksiReparasiLeburWS,
                                                                               ._prop02User = _prop01User,
                                                                               ._prop03Grid = Me}
        objTransaksiWS02._pbSettingTransaksiWarehouse()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm322SettingWSTransaksiReturSupplier()
        Cursor = Cursors.WaitCursor
        Dim objTransaksiWS03 As New clsWSNasaSettingGridTransaksiWarehouse With {._prop01cTargetTransaksiWS = clsWSNasaSettingGridTransaksiWarehouse.TargetWSTransaksi._06WSTransaksiReturSupplier,
                                                                                 ._prop02User = _prop01User,
                                                                                 ._prop03Grid = Me}
        objTransaksiWS03._pbSettingTransaksiWarehouse()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm33SettingWS24FP01INBOUND()
        Cursor = Cursors.WaitCursor

        Using objGridSettingWS24FP01INBOUND As clsWSNasaSettingGridInbound = New clsWSNasaSettingGridInbound With {
                                                                                    ._prop02User = _prop01User,
                                                                                    ._prop03Grid = Me,
                                                                                    ._prop04DataTableMaster = _cm11DataTableMasterMRP("PRODUCT"),
                                                                                    ._prop05DataTableMaster = _cm11DataTableMasterMRP("SIZE"),
                                                                                    ._prop06DataTableMaster = _cm11DataTableMasterWarehouse("SBOX"),
                                                                                    ._prop07RepoMasterDelegate = objRepoWS05Master}
            Select Case _prop02TargetGrid
                Case _pbEnumTargetGrid._WSInbound5021InhouseProduksi
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5021InhouseProduksi
                    _WSInbound5021InhouseProduksi_SettingTotalSummary()

                Case _pbEnumTargetGrid._WSInbound5022InhouseChain
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5022InhouseChain

                Case _pbEnumTargetGrid._WSInbound5023RepairWarehouse
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5023RepairWarehouse

                Case _pbEnumTargetGrid._WSInbound5024RepairCustomer
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5024RepairCustomer

                Case _pbEnumTargetGrid._WSInbound5025ReturCustomer
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5025ReturCustomer

                Case _pbEnumTargetGrid._WSInbound5026External
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5026External

                Case _pbEnumTargetGrid._WSInbound5027BRJPinjamanMarketing
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5027BRJPinjamanMarketing

                Case _pbEnumTargetGrid._WSInbound5028ReturKAE
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5028ReturKAE

                Case _pbEnumTargetGrid._WSInbound5029ReturConsignment
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSInbound5029ReturConsignment

                Case _pbEnumTargetGrid._WSPKBConsumeInbound3034
                    objGridSettingWS24FP01INBOUND._prop01cTargetINBOUND = TargetINBOUND._WSPKBConsumeInbound3034
            End Select

            objGridSettingWS24FP01INBOUND._pbCallSetting20WS24FP01INBOUND()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm34SettingWSDistribusiFG()
        Cursor = Cursors.WaitCursor
        Using objGridSettingWS24FP01INBOUND As clsWSNasaSettingGridDistribusiBarang = New clsWSNasaSettingGridDistribusiBarang With {
                                                                                          ._prop02User = _prop01User, ._prop03Grid = Me}
            Select Case _prop02TargetGrid
                Case _pbEnumTargetGrid._WSDistribusiFGPKB
                    objGridSettingWS24FP01INBOUND._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSDistribusiFGPKB

                Case _pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS
                    objGridSettingWS24FP01INBOUND._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBSLS

                Case _pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN
                    objGridSettingWS24FP01INBOUND._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSDistribusiFGApprovePKBFIN

                Case _pbEnumTargetGrid._WSDistribusiFGPKBOrderViaBulkUploadXLS
                    objGridSettingWS24FP01INBOUND._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSDistribusiFGOrderViaBulkUploadXLS

            End Select

            objGridSettingWS24FP01INBOUND.__pbSettingGridDistribusiFG()
        End Using
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm35SettingWSStockCheck()
        Cursor = Cursors.WaitCursor

        Dim objStockForSale As New clsWSNasaSettingGridDistribusiBarang With {._prop01cTargetDistribusiBarang = clsWSNasaSettingGridDistribusiBarang.TargetDistribusiBarang._TargetWSDIstibusiFGStockCheck,
                                                                         ._prop02User = _prop01User,
                                                                         ._prop03Grid = Me}
        objStockForSale.__pbSettingGridDistribusiFG()

        Cursor = Cursors.Default
    End Sub
    Private Sub _cm50SettingWS24B3REPORT()
        Cursor = Cursors.WaitCursor

        Using objGridSettingWS24B3REPORT As clsWSNasaSettingReportGrid = New clsWSNasaSettingReportGrid With {._prop02Grid = Me}
            Select Case _prop02TargetGrid
                Case _pbEnumTargetGrid._WSRptInbound200All
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsInbound200All

                Case _pbEnumTargetGrid._WSRptInbound201ByVendor
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsInbound201ByVendor

                Case _pbEnumTargetGrid._WSRptGeneral300Stock
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsGeneral300Stock

                Case _pbEnumTargetGrid._WSRptGeneral301StockProductCode
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsGeneral301StockProductCode

                Case _pbEnumTargetGrid._wsOutbound3501Sale
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsOutbound350Sale


                Case _pbEnumTargetGrid._wsRptTransaksiWS370Semua
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsTransaksiWS370Semua

                Case _pbEnumTargetGrid._WSRptStore
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsStore

                Case _pbEnumTargetGrid._WSRptAgregatSJ
                    objGridSettingWS24B3REPORT._prop01cTargetGridWSReport = TargetGridWSReport._wsAgergatSJ




            End Select

            objGridSettingWS24B3REPORT.__pbCallSettingReportGrid()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm60SettingWSProsesPKB()
        Cursor = Cursors.WaitCursor
        Dim objProsesPKB As New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsOut10ProsesPKB,
                                                                      ._prop02User = _prop01User,
                                                                      ._prop03Grid = Me}
        objProsesPKB.__pbSettingGridOutboundPKB()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm70SettingWSStockForSale()
        Cursor = Cursors.WaitCursor
        Dim objStockForSale As New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsOut30StockForSale,
                                                                         ._prop02User = _prop01User,
                                                                         ._prop03Grid = Me}
        objStockForSale.__pbSettingGridOutboundPKB()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm71SettingWSEntrySKUForSale()
        Cursor = Cursors.WaitCursor
        Dim objEntrySKUForSale As New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsOut31EntrySKUForSale,
                                                                            ._prop02User = _prop01User,
                                                                            ._prop03Grid = Me}
        objEntrySKUForSale.__pbSettingGridOutboundPKB()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm72SettingWS24LD01BULKUPLOADXLSFromInbound()
        Cursor = Cursors.WaitCursor
        Using objBULKUPLOADXLS = New clsWSNasaSettingGridInbound With {._prop02User = _prop01User, ._prop03Grid = Me}
            Select Case _prop02TargetGrid
                Case _pbEnumTargetGrid._WSInboundFromXLS10122024ReturCustomer
                    objBULKUPLOADXLS._prop01cTargetINBOUND = TargetINBOUND._WSInboundFromXLS10122024ReturCustomer

                Case _pbEnumTargetGrid._WSInboundFromXLS11022025ReparasiWarehouse
                    objBULKUPLOADXLS._prop01cTargetINBOUND = TargetINBOUND._WSInboundFromXLS11022025ReparasiWarehouse
            End Select

            objBULKUPLOADXLS._pbCallSetting21WS24LD01BULKUPLOADXLS()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm73PickingListSKU5051()
        Cursor = Cursors.WaitCursor
        Dim objOutboundPickingListSKU As New clsWSNasaSettingGridOutbound With {._prop01cTargetReceiveFG = clsWSNasaSettingGridOutbound.TargetWSOutbound._WSOutbound5051PickingListSKU,
                                                                                ._prop02User = _prop01User,
                                                                                ._prop03Grid = Me}
        objOutboundPickingListSKU._pbSetting03PickingListSKU()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm73PickingListProdCode5051()
        Cursor = Cursors.WaitCursor
        Dim objOutboundPickingListProdCode As New clsWSNasaSettingGridOutbound With {._prop01cTargetReceiveFG = clsWSNasaSettingGridOutbound.TargetWSOutbound._WSOutbound5051PickingListProdCode,
                                                                                     ._prop02User = _prop01User,
                                                                                     ._prop03Grid = Me}
        objOutboundPickingListProdCode._pbSetting04PickingListProdCode()
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm5052SettingWSPKBCreateSuratJalan()
        Cursor = Cursors.WaitCursor

        Dim objEntrySKUForSale As New clsWSNasaSettingGridOutboundPKB With {._prop01cTargetOutboundPKB = clsWSNasaSettingGridOutboundPKB.TargetWSOutboundPKB._wsOut5052PKBCreateSuratJalan,
                                                                            ._prop02User = _prop01User,
                                                                            ._prop03Grid = Me}
        objEntrySKUForSale.__pbSettingGridOutboundPKB()
        _WSOut5052PKBCreateSuratJalan_SettingTotalSummary()

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "Private -  method : Tambahan Setting Column"
    Private Sub _PKBCustomer_SettingTotalSummary()
        _colf01SmallInt.SummaryItem.SummaryType = SummaryItemType.Sum
        _colf01SmallInt.SummaryItem.DisplayFormat = "{0:n0}"
        _colf01SmallInt.SummaryItem.Tag = 1
        CType(_colf01SmallInt.View, GridView).OptionsView.ShowFooter = True

        _colf01Double.SummaryItem.SummaryType = SummaryItemType.Sum
        _colf01Double.SummaryItem.DisplayFormat = "{0:n2}"
        _colf01Double.SummaryItem.Tag = 2
        CType(_colf01Double.View, GridView).OptionsView.ShowFooter = True
    End Sub

    Private Sub _WSInbound5021InhouseProduksi_SettingTotalSummary()
        _colk02String.SummaryItem.SummaryType = SummaryItemType.Custom
        _colk02String.SummaryItem.DisplayFormat = "{0:n0} Checked"
        _colk02String.SummaryItem.Tag = 1
        CType(_colk02String.View, GridView).OptionsView.ShowFooter = True

        _colf01SmallInt.SummaryItem.SummaryType = SummaryItemType.Custom
        _colf01SmallInt.SummaryItem.DisplayFormat = "{0:n0}"
        _colf01SmallInt.SummaryItem.Tag = 2
        CType(_colf01SmallInt.View, GridView).OptionsView.ShowFooter = True

        _colf01Double.SummaryItem.SummaryType = SummaryItemType.Custom
        _colf01Double.SummaryItem.DisplayFormat = "{0:n2}"
        _colf01Double.SummaryItem.Tag = 3
        CType(_colf01Double.View, GridView).OptionsView.ShowFooter = True

        _colf36String.SummaryItem.SummaryType = SummaryItemType.Custom
        _colf36String.SummaryItem.DisplayFormat = "{0:n0} UnCheck"
        _colf36String.SummaryItem.Tag = 4
        CType(_colf36String.View, GridView).OptionsView.ShowFooter = True
    End Sub

    Private Sub _WSOut5052PKBCreateSuratJalan_SettingTotalSummary()
        _colk02String.SummaryItem.SummaryType = SummaryItemType.Custom
        _colk02String.SummaryItem.DisplayFormat = "{0:n0} Checked"
        _colk02String.SummaryItem.Tag = 1
        CType(_colk02String.View, GridView).OptionsView.ShowFooter = True

        _colf01SmallInt.SummaryItem.SummaryType = SummaryItemType.Custom
        _colf01SmallInt.SummaryItem.DisplayFormat = "{0:n0}"
        _colf01SmallInt.SummaryItem.Tag = 2
        CType(_colf01SmallInt.View, GridView).OptionsView.ShowFooter = True

        _colf01Double.SummaryItem.SummaryType = SummaryItemType.Custom
        _colf01Double.SummaryItem.DisplayFormat = "{0:n2}"
        _colf01Double.SummaryItem.Tag = 3
        CType(_colf01Double.View, GridView).OptionsView.ShowFooter = True

        _colf02String.SummaryItem.SummaryType = SummaryItemType.Custom
        _colf02String.SummaryItem.DisplayFormat = "{0:n0} UnCheck"
        _colf02String.SummaryItem.Tag = 4
        CType(_colf02String.View, GridView).OptionsView.ShowFooter = True
    End Sub

#End Region

#Region "private -  method : Merge/Split SKU"
    Private Sub _MergeSKUAddNewData(ByVal prmdtDataBaruGrid As DataTable, ByVal prmnTotalBerat As Double)
        For Each dtRow As DataRow In prmdtDataBaruGrid.Rows
            _cm14AddNewData(dtRow("k01String"), dtRow("k02String"), dtRow("k02String"),
                dtRow("f04String"), "", "", "", "", "", "", dtRow("f01String"), dtRow("f02String"), dtRow("f03String"),
                "", "", "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "",
                "",
                dtRow("f01TinyInt"), dtRow("f01SmallInt"), dtRow("f01SmallInt"),
                dtRow("f01Double"), dtRow("f01Double"), 0.0,
                dtRow("f01Date"), "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01")
        Next
    End Sub

    Private Sub _SplitSKUAddNewData(ByVal prmdtDataBaruGrid As DataTable, ByVal prmnTotalBerat As Double)
        '._colk02String.Caption = "SKU Baru"
        '._colk03String.Caption = "SKU Asal"
        '._colf09String.Caption = "Box"
        '._colf01SmallInt.Caption = "Pcs Asal"
        '._colf01Double.Caption = "Berat Asal"
        '._colf01Int.Caption = "Pcs Proses"
        '._colf02Double.Caption = "Berat Proses"

        For Each dtRow As DataRow In prmdtDataBaruGrid.Rows
            _cm14AddNewData(dtRow("k01String"), dtRow("k03String"), dtRow("k02String"),
                dtRow("f04String"), "", "", "", "", "", "", dtRow("f01String"), dtRow("f02String"), dtRow("f03String"),
                "", "", "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "",
                "", "", "", "", "", "", "", "", "", "",
                "",
                dtRow("f01TinyInt"), dtRow("f01SmallInt"), 0,
                dtRow("f01Double"), 0.0, 0.0,
                dtRow("f01Date"), "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01")
        Next
    End Sub
#End Region

#Region "public -  method : Proses Data"

    Public Sub __pb01UpdDefaultSLocGridReceiveFGFromCitrix(ByVal prmcKodeSLocDefault As String)
        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            dtRow("f27String") = prmcKodeSLocDefault
        Next

        _prop03pdtDataSourceGrid.AcceptChanges()
    End Sub

    Public Function __pb01PrepareSaveDataReceiveFGFromCitrix(ByVal prmcKodeSLoc As String, ByVal prmcNamaSLoc As String) As DataTable
        '***************************************************************************************
        'field2 ini berasal dari "clsWSNasaSettingGridInbound._cc01CaptionReceiveFGFromCitrix()"
        '***************************************************************************************
        Dim pcf01String As String = ""         '"DO"              
        Dim pck02String As String = ""         '"SKUVendor"       
        Dim pck03String As String = ""         '"ProductCode"
        Dim pnf01SmallInt As Int32 = 0         '"TPcs" 

        Dim plk00Boolean As Boolean = False    '"Warna OK ?"
        Dim plk00Boolean01 As Boolean = False  '"Size OK ?"
        Dim pnf01TinyInt As Int16 = 0          '"Bundling"
        Dim pcf27String As String = ""         '"SLoc Tujuan"
        Dim pcf28String As String = ""         '"Box Tujuan"
        Dim pcNamaSLoc As String = ""          '"SLoc Tujuan"
        Dim pcNamaBox As String = ""           '"Box Tujuan"

        '_prop04Date         'Tgl Terima Warehouse
        '_prop05String       'KodeVendor
        '_prop06String       'NamaVendor
        '_prop07String       'Keterangan

        Dim pdtSmall As New DataTable
        Dim ctrlSmall As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtSmall}
        ctrlSmall.dtInitsTABLESMALL()

        For i As Integer = 0 To GridView1.RowCount - 1

            plk00Boolean = CBool(GridView1.GetRowCellValue(i, "k00Boolean"))
            plk00Boolean01 = CBool(GridView1.GetRowCellValue(i, "k00Boolean01"))
            pnf01TinyInt = CInt(GridView1.GetRowCellValue(i, "f01TinyInt"))

            'pcf27String = GridView1.GetRowCellValue(i, "f27String").ToString()
            'pcNamaSLoc = GridView1.GetRowCellDisplayText(i, "f27String").ToString

            'pcf28String = GridView1.GetRowCellValue(i, "f28String").ToString()
            'pcNamaBox = GridView1.GetRowCellDisplayText(i, "f28String").ToString

            pcf27String = prmcKodeSLoc
            pcNamaSLoc = prmcNamaSLoc
            pcf28String = "SBOXFROMCITRIX"
            pcNamaBox = "PENDING INBOUND"

            If plk00Boolean And plk00Boolean01 _
               And (pnf01TinyInt > 0) _
               And (Not String.IsNullOrEmpty(pcf27String)) _
               And (Not String.IsNullOrEmpty(pcf28String)) Then

                pcf01String = GridView1.GetRowCellValue(i, "f01String").ToString()
                pck02String = GridView1.GetRowCellValue(i, "k02String").ToString()
                pck03String = GridView1.GetRowCellValue(i, "k03String").ToString()
                pnf01SmallInt = CInt(GridView1.GetRowCellValue(i, "f01SmallInt"))

                ctrlSmall.dtAddNewsTABLESMALL(
                    pcf01String, pck02String, pck03String,
                    pcf27String, pcNamaSLoc, pcf28String, pcNamaBox,
                    _prop05String, _prop06String, _prop07String,
                    "SINGLE", "", "",
                    pnf01TinyInt, pnf01SmallInt, 0,
                    0.0, 0.0, 0.0,
                    _prop04Date, "3000-01-01", "3000-01-01",
                    Now.Date, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName,
                    _prop01User._UserProp05IPLocalAddress,
                    _prop01User._UserProp06IPPublicAddress)

            End If

            pcf01String = "" : pck02String = "" : pck03String = "" : pnf01SmallInt = 0

            plk00Boolean = False : plk00Boolean01 = False : pnf01TinyInt = 0
            pcf27String = "" : pcf28String = "" : pcNamaSLoc = "" : pcNamaBox = ""
        Next

        Return ctrlSmall.prop_dtsTABLESMALL
    End Function

    Public Function __pb02InboundSKUNextReady(ByRef objctrlActualGW As ctrlWSNasaSpinEdit,
                                              ByVal prmnQtyVendor As Integer,
                                              ByVal prmnGWVendor As Double,
                                              ByVal prmnToleransiBeratPerSKU As Double) As String
        Dim pcwsSKUNext As String = ""
        Dim pnTotActualGrossWeight As Double = 0.0
        Dim pnJmlWSSKU As Integer = 0

        With GridView1
            For i = 0 To .RowCount - 1
                pnJmlWSSKU = pnJmlWSSKU + CInt(.GetRowCellValue(i, "f01TinyInt"))
                pnTotActualGrossWeight = pnTotActualGrossWeight + CDbl(.GetRowCellValue(i, "f01Double"))

                If CDbl(.GetRowCellValue(i, "f01Double")) = 0 Then
                    pcwsSKUNext = .GetRowCellValue(i, "k01String").ToString

                    Exit For
                End If
            Next
        End With

        objctrlActualGW.EditValue = pnTotActualGrossWeight

        If (pcwsSKUNext = "") And (pnJmlWSSKU = prmnQtyVendor) And (pnTotActualGrossWeight > 0) Then
            Dim pnTotBeratToleransi As Double = prmnQtyVendor * prmnToleransiBeratPerSKU

            If (pnTotActualGrossWeight >= (prmnGWVendor - pnTotBeratToleransi)) And
               (pnTotActualGrossWeight <= (prmnGWVendor + pnTotBeratToleransi)) Then
                pcwsSKUNext = "COMPLETE"
            Else
                pcwsSKUNext = "ERROR-ACTUALWEIGHT"
            End If

        End If

        Return pcwsSKUNext
    End Function

    Public Sub __pb03InboundSKUUpdBerat(ByVal prmcwsSKU As String, ByVal prmnBerat As Double, ByVal prmcStatusBeratSKU As String)

        For Each dtRow As DataRow In _prop03pdtDataSourceGrid.Rows
            If dtRow("k01String").ToString = prmcwsSKU Then
                dtRow("f01Double") = prmnBerat
                dtRow("f01String") = prmcStatusBeratSKU

                Exit For
            End If
        Next
        _prop03pdtDataSourceGrid.AcceptChanges()

        Me.GridView1.RefreshData()
        Me.Refresh()

        Dim _pcKodeSLoc As String = ""
        Dim _pcNamaSLoc As String = ""
        Dim _pcKodeBOX As String = ""
        Dim _pcNamaBOX As String = ""

        For i As Integer = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(i, "k01String") = prmcwsSKU Then
                _pcKodeSLoc = GridView1.GetRowCellValue(i, "k02String").ToString
                _pcNamaSLoc = GridView1.GetRowCellDisplayText(i, "k02String").ToString
                _pcKodeBOX = GridView1.GetRowCellValue(i, "k03String").ToString
                _pcNamaBOX = GridView1.GetRowCellDisplayText(i, "k03String").ToString
            End If
        Next

        Dim pcSQL As String = ""
        pcSQL = " Update wsTABLE20 " &
                " set f01Double = " & prmnBerat & ", " &
                "     f31String = '" & _pcKodeSLoc & "', " &
                "     f32String = '" & _pcNamaSLoc & "', " &
                "     f33String = '" & _pcKodeBOX & "', " &
                "     f34String = '" & _pcNamaBOX & "'" &
                " where k02String = '" & prmcwsSKU & "'"
        Dim objNasa As New clsWSNasaHelper
        Dim pnJmlRec As Integer = 0
        pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(_prop01User._UserProp08TargetNetwork,
                                                            clsWSNasaHelper._pnmDatabaseName.WS,
                                                            1, pcSQL)
    End Sub

    Public Function __pvGetData4ApprovedFinSls(ByVal vsTargetApproval As String) As DataTable
        Dim pdtDataTiny As New DataTable
        Dim objTiny As New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtDataTiny}
        objTiny.dtInitsTABLETINY()

        ' ===================== UPDATED BY AKIRRA - 25/07/07 =====================
        ' cek apakah user sudah checklist (k00Boolean)

        Dim vbHasTick As Boolean = False

        For i = 0 To GridView1.RowCount - 1
            Dim vbTicked As Boolean = CBool(GridView1.GetRowCellValue(i, "k00Boolean"))
            If vbTicked Then
                vbHasTick = True
                Exit For
            End If
        Next

        If Not vbHasTick Then
            MsgBox("Please tick the data you want to process..", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
            Exit Function
        End If


        ' ===================== UPDATED BY AKIRRA - 25/07/07 =====================
        ' cek apakah user sudah memilih approval status
        Dim vbHasApprovalStatus As Boolean = False

        For i = 0 To GridView1.RowCount - 1
            Dim viApprovalStatus As Integer = CInt(GridView1.GetRowCellValue(i, If(vsTargetApproval = "FIN", "k00Int01", "k00Int")))
            If viApprovalStatus <> 10 Then
                vbHasApprovalStatus = True
                Exit For
            End If
        Next

        If Not vbHasApprovalStatus Then
            MsgBox("Please select the approval status..", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
            Exit Function
        End If

        'Dim vdtest As DataTable = GridControl1.DataSource

        For i = 0 To GridView1.RowCount - 1
            Dim vsSetujuTolakSALES As String = ""
            Dim vsSetujuTolakFIN As String = ""
            Dim vsRejectReason As String = ""

            ' ============= CEK DATA TICKED ONYL =============
            Dim vbTicked As Boolean = False
            If GridView1.GetRowCellValue(i, "k00Boolean") IsNot Nothing Then
                vbTicked = CBool(GridView1.GetRowCellValue(i, "k00Boolean"))
            End If

            If Not vbTicked Then
                Continue For
            End If

            ' ============= SALES CUY =============
            If vsTargetApproval = "SLS" Then
                Dim viApprovalStatusSLS As Integer = CInt(GridView1.GetRowCellValue(i, "k00Int"))
                Dim viApprovalStatusFIN As Integer = CInt(GridView1.GetRowCellValue(i, "k00Int01"))

                If viApprovalStatusSLS = 1 Then
                    vsSetujuTolakSALES = "SETUJU"
                    If viApprovalStatusFIN = 1 Then
                        vsSetujuTolakFIN = "SETUJU"
                    End If

                ElseIf viApprovalStatusSLS = 2 Then
                    vsSetujuTolakSALES = "TOLAK"
                    If viApprovalStatusFIN = 2 Then
                        vsSetujuTolakFIN = "TOLAK"
                    End If

                End If

                ' ============= FINANCE CUY =============
            ElseIf vsTargetApproval = "FIN" Then
                Dim viApprovalStatusFIN As Integer = CInt(GridView1.GetRowCellValue(i, "k00Int01"))
                Dim viApprovalStatusSLS As Integer = CInt(GridView1.GetRowCellValue(i, "k00Int"))

                If viApprovalStatusFIN = 1 Then
                    vsSetujuTolakFIN = "SETUJU"
                    If viApprovalStatusSLS = 1 Then
                        vsSetujuTolakSALES = "SETUJU"
                    End If

                ElseIf viApprovalStatusFIN = 2 Then
                    vsSetujuTolakFIN = "TOLAK"
                    If viApprovalStatusSLS = 2 Then
                        vsSetujuTolakSALES = "TOLAK"
                    End If

                    If String.IsNullOrWhiteSpace(GridView1.GetRowCellValue(i, "f29String")?.ToString()) Then
                        MsgBox("Please insert the reason for rejection..", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
                        Exit Function
                    End If

                    Try
                        Using rtb As New RichTextBox()
                            rtb.Rtf = GridView1.GetRowCellValue(i, "f29String")?.ToString()
                            vsRejectReason = rtb.Text
                        End Using
                    Catch
                        vsRejectReason = GridView1.GetRowCellValue(i, "f29String")?.ToString()
                    End Try

                ElseIf viApprovalStatusFIN = 3 Then
                    vsSetujuTolakFIN = "PENDING"

                    If String.IsNullOrWhiteSpace(GridView1.GetRowCellValue(i, "f29String")?.ToString()) OrElse
                        GridView1.GetRowCellValue(i, "f29String")?.ToString().Trim() = "[PENDING]" OrElse
                        GridView1.GetRowCellValue(i, "f29String")?.ToString().Trim() = "[PENDING] " Then

                        MsgBox("Please insert the reason for the Pending status..", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
                        Exit Function
                    End If

                    Try
                        Using rtb As New RichTextBox()
                            rtb.Rtf = GridView1.GetRowCellValue(i, "f29String")?.ToString()
                            vsRejectReason = rtb.Text
                        End Using
                    Catch
                        vsRejectReason = GridView1.GetRowCellValue(i, "f29String")?.ToString()
                    End Try
                End If
            End If

            ' ============= insert ke model =============
            If Not (String.IsNullOrEmpty(vsSetujuTolakSALES) AndAlso String.IsNullOrEmpty(vsSetujuTolakFIN)) Then
                objTiny.dtAddNewsTABLETINY(
            GridView1.GetRowCellValue(i, "k03String").ToString(),     '"No.Order"
            GridView1.GetRowCellValue(i, "f01String").ToString(),     '"BrandCode"
            GridView1.GetRowCellValue(i, "f03String").ToString(),     '"KadarCode"
            vsTargetApproval, vsSetujuTolakSALES, vsSetujuTolakFIN, "", vsRejectReason,
            0, 0, 0, 0.0, 0.0, 0.0, "3000-01-01", "3000-01-01",
            Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
            _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            End If

        Next

        Return objTiny.prop_dtsTABLETINY
    End Function

    Public Sub _pb05GetDataStore(ByRef objDataPickingList As DataTable)
        If _prop03pdtDataSourceGrid Is Nothing Then Exit Sub

        Dim rows = _prop03pdtDataSourceGrid.Select("k00Boolean = True")

        ' Jika tidak ada, keluar
        If rows.Length = 0 Then
            Exit Sub
        End If

        ' Salin struktur kolom jika objDataPickingList masih kosong
        If objDataPickingList.Columns.Count = 0 Then
            For Each col As DataColumn In _prop03pdtDataSourceGrid.Columns
                objDataPickingList.Columns.Add(col.ColumnName, col.DataType)
            Next
        End If

        ' Salin baris yang terpilih ke objDataPickingList
        For Each row As DataRow In rows
            objDataPickingList.ImportRow(row)
        Next
    End Sub



#End Region

End Class
