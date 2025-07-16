Imports DevExpress.Diagram.Core.Native
Imports System.Windows
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.CodeParser
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Data
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.ViewInfo
Imports System.IO


Public Class ucGridTransaction
    Implements IDisposable

    Property _prop01TargetTransaksi As TargetTransaksi
    Property _prop02pdtDataSourceGrid As DataTable
    Property _prop03pdtSBUMasterGEMINI As DataTable
    Property _prop04pdtTableMasterGEMINI As DataTable

    Private pdtTemplate As DataTable
    Private ctrlTemplate As clsTEMPLATEGEMINI

    Private ttips As ToolTipController

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

        ttips = New ToolTipController()
        AddHandler ttips.GetActiveObjectInfo, AddressOf ttips_GetActiveObjectInfo

    End Sub

    Private Sub ttips_GetActiveObjectInfo(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs)
        If e.SelectedControl IsNot colf02Memo Then
            Return
        End If
        Dim info As ToolTipControlInfo = Nothing
        Dim sTooltip1 As New SuperToolTip()
        Try
            Dim view As GridView = CType(colf02Memo.View, GridView)
            If view Is Nothing Then
                Return
            End If

            Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
            If hi.InRowCell Then
                info = New ToolTipControlInfo(GridHitTest.RowIndicator.ToString() & hi.RowHandle.ToString(), "Row Handle: " & hi.RowHandle.ToString())
                Dim titleItem1 As New ToolTipTitleItem()
                Dim myImage As Image
                If view.GetRowCellValue(hi.RowHandle, "f02Memo") IsNot DBNull.Value Then
                    Dim bytesArr As Byte() = CType(view.GetRowCellValue(hi.RowHandle, "f02Memo"), Byte())
                    Using ms As New System.IO.MemoryStream(bytesArr)
                        myImage = Image.FromStream(ms)
                    End Using
                    Dim item1 As New ToolTipItem()
                    item1.Image = myImage
                    sTooltip1.Items.Add(item1)
                End If
            End If

            info = New ToolTipControlInfo(hi.HitTest, "") With {
                        .SuperTip = sTooltip1
                    }
        Finally
            e.Info = info
        End Try
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

        _rscolf01Date.Dispose()
        _rscolf02Date.Dispose()
        _rscolf03Date.Dispose()
        _rscolf04Date.Dispose()
        _rscolf05Date.Dispose()
    End Sub

    Private Sub ucGridTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        _rscolf01Double._02InitRepoDoubleMoney(3)
        _rscolf02Double._02InitRepoDoubleMoney(3)
        _rscolf03Double._02InitRepoDoubleMoney(3)
        _rscolf04Double._02InitRepoDoubleMoney(3)
        _rscolf05Double._02InitRepoDoubleMoney(3)
        _rscolf06Double._02InitRepoDoubleMoney(3)
        _rscolf07Double._02InitRepoDoubleMoney(3)

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

        colf01Date.Visible = False
        colf02Date.Visible = False
        colf03Date.Visible = False
        colf04Date.Visible = False
        colf05Date.Visible = False

    End Sub

    Private Sub _cm07InitVisibilityIndexOFF()
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
        _mp02SettingVisibilityON()
        _mp03SettingColumnCaption()
        _mp04SettingWriteColumn()
    End Sub

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

    Public Sub _pb03DisplayGridTransaction()
        _cm09PropertiesGridONTarget()

        GridControl1.DataSource = Nothing
        GridControl1.DataSource = _prop02pdtDataSourceGrid

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
                               ByVal prmf01Memo As String, ByVal prmf02Memo As String,
                               ByVal prmf01Int As Integer, ByVal prmf02Int As Integer, ByVal prmf03Int As Integer, ByVal prmf04Int As Integer, ByVal prmf05Int As Integer,
                               ByVal prmf01Double As Double, ByVal prmf02Double As Double, ByVal prmf03Double As Double, ByVal prmf04Double As Double, ByVal prmf05Double As Double,
                               ByVal prmf01Date As Date, ByVal prmf02Date As Date, ByVal prmf03Date As Date,
                               ByVal prmf01Datetime As Date, ByVal prmf02Datetime As Date,
                               ByVal prmf01IDUser As String, ByVal prmf02IDUser As String,
                               ByVal prmf01NamaUser As String, ByVal prmf02NamaUser As String)

        Dim oDataRow As DataRow = _prop02pdtDataSourceGrid.NewRow()

        oDataRow("k00Boolean") = False
        oDataRow("k00Int") = 0
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
        oDataRow("f02Memo") = prmf02Memo
        oDataRow("f01Int") = prmf01Int
        oDataRow("f02Int") = prmf02Int
        oDataRow("f03Int") = prmf03Int
        oDataRow("f04Int") = prmf04Int
        oDataRow("f05Int") = prmf05Int
        oDataRow("f01Double") = prmf01Double
        oDataRow("f02Double") = prmf02Double
        oDataRow("f03Double") = prmf03Double
        oDataRow("f04Double") = prmf04Double
        oDataRow("f05Double") = prmf05Double
        oDataRow("f01Date") = prmf01Date
        oDataRow("f02Date") = prmf02Date
        oDataRow("f03Date") = prmf03Date
        oDataRow("f01Datetime") = prmf01Datetime
        oDataRow("f02Datetime") = prmf02Datetime
        oDataRow("f01IDUser") = prmf01IDUser
        oDataRow("f02IDUser") = prmf02IDUser
        oDataRow("f01NamaUser") = prmf01NamaUser
        oDataRow("f02NamaUser") = prmf02NamaUser

        _prop02pdtDataSourceGrid.Rows.Add(oDataRow)

        GridControl1.RefreshDataSource()
        GridControl1.Refresh()
    End Sub

    Public Function _pb05GetDataMD23DQ01CANCELPRODUCTIONORDER(ByVal prmcIDUser As String, ByVal prmcNamaUser As String,
                                                              ByVal prmcAlasanBatal As String, ByVal prmcNoDokumen As String) As DataTable
        Dim pdtData As New DataTable
        Dim objTempGEMINI As clsTEMPLATEGEMINI = New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdtData}
        objTempGEMINI.dtInitTABLEGEMINI()

        For Each dtRow As DataRow In _prop02pdtDataSourceGrid.Rows
            If dtRow("k00Boolean") = True Then
                objTempGEMINI.dtAddNewTABLEGEMINI(
                    dtRow("k01String"), dtRow("k02Int"), dtRow("k03String"), dtRow("k04String"), dtRow("k05String"),
                    dtRow("f01String"), dtRow("f02String"), dtRow("f03String"), dtRow("f04String"), dtRow("f05String"),
                    dtRow("f06String"), dtRow("f07String"), dtRow("f08String"), dtRow("f09String"), dtRow("f10String"),
                    dtRow("f11String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"),
                    dtRow("f16String"), dtRow("f17String"), dtRow("f18String"), dtRow("f19String"), dtRow("f20String"),
                    dtRow("f21String"), dtRow("f22String"), dtRow("f23String"), dtRow("f24String"), dtRow("f25String"),
                    dtRow("f26String"), dtRow("f27String"), dtRow("f28String"), prmcNoDokumen, "CANCEL-MD",
                    prmcAlasanBatal, dtRow("f03Memo"), dtRow("f04Memo"), dtRow("f05Memo"),
                    dtRow("f01Int"), dtRow("f02Int"), dtRow("f03Int"), dtRow("f04Int"), dtRow("f05Int"), dtRow("f06Int"), dtRow("f07Int"),
                    dtRow("f01Double"), dtRow("f02Double"), dtRow("f03Double"), dtRow("f04Double"), dtRow("f05Double"), dtRow("f06Double"), dtRow("f07Double"),
                    dtRow("f01Date"), Today.Date, dtRow("f03Date"), dtRow("f04Date"), dtRow("f05Date"),
                    dtRow("f01Datetime"), Now, dtRow("f01IDUser"), prmcIDUser, dtRow("f01NamaUser"), prmcNamaUser)
            End If
        Next

        Return objTempGEMINI.prop_dtTABLEGEMINI
    End Function

    Public Sub __pb06CreateSettingColumnWidth(ByVal prmcNamaFileTarget As String)
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
            _objstreamwriter.WriteLine("colk00Boolean.Width = " + colk00Boolean.Width.ToString)
            _objstreamwriter.WriteLine("colk00Int.Width = " + colk00Int.Width.ToString)
            _objstreamwriter.WriteLine("colk01String.Width = " + colk01String.Width.ToString)
            _objstreamwriter.WriteLine("colk02Int.Width = " + colk02Int.Width.ToString)
            _objstreamwriter.WriteLine("colk03String.Width = " + colk03String.Width.ToString)
            _objstreamwriter.WriteLine("colf01String.Width = " + colf01String.Width.ToString)
            _objstreamwriter.WriteLine("colf02String.Width = " + colf02String.Width.ToString)
            _objstreamwriter.WriteLine("colf03String.Width = " + colf03String.Width.ToString)
            _objstreamwriter.WriteLine("colf04String.Width = " + colf04String.Width.ToString)
            _objstreamwriter.WriteLine("colf05String.Width = " + colf05String.Width.ToString)
            _objstreamwriter.WriteLine("colf06String.Width = " + colf06String.Width.ToString)
            _objstreamwriter.WriteLine("colf07String.Width = " + colf07String.Width.ToString)
            _objstreamwriter.WriteLine("colf08String.Width = " + colf08String.Width.ToString)
            _objstreamwriter.WriteLine("colf09String.Width = " + colf09String.Width.ToString)
            _objstreamwriter.WriteLine("colf10String.Width = " + colf10String.Width.ToString)
            _objstreamwriter.WriteLine("colf11String.Width = " + colf11String.Width.ToString)
            _objstreamwriter.WriteLine("colf12String.Width = " + colf12String.Width.ToString)
            _objstreamwriter.WriteLine("colf13String.Width = " + colf13String.Width.ToString)
            _objstreamwriter.WriteLine("colf14String.Width = " + colf14String.Width.ToString)
            _objstreamwriter.WriteLine("colf15String.Width = " + colf15String.Width.ToString)
            _objstreamwriter.WriteLine("colf16String.Width = " + colf16String.Width.ToString)
            _objstreamwriter.WriteLine("colf17String.Width = " + colf17String.Width.ToString)
            _objstreamwriter.WriteLine("colf18String.Width = " + colf18String.Width.ToString)
            _objstreamwriter.WriteLine("colf19String.Width = " + colf19String.Width.ToString)
            _objstreamwriter.WriteLine("colf20String.Width = " + colf20String.Width.ToString)
            _objstreamwriter.WriteLine("colf21String.Width = " + colf21String.Width.ToString)
            _objstreamwriter.WriteLine("colf22String.Width = " + colf22String.Width.ToString)
            _objstreamwriter.WriteLine("colf23String.Width = " + colf23String.Width.ToString)
            _objstreamwriter.WriteLine("colf24String.Width = " + colf24String.Width.ToString)
            _objstreamwriter.WriteLine("colf25String.Width = " + colf25String.Width.ToString)
            _objstreamwriter.WriteLine("colf26String.Width = " + colf26String.Width.ToString)
            _objstreamwriter.WriteLine("colf27String.Width = " + colf27String.Width.ToString)
            _objstreamwriter.WriteLine("colf28String.Width = " + colf28String.Width.ToString)
            _objstreamwriter.WriteLine("colf29String.Width = " + colf29String.Width.ToString)
            _objstreamwriter.WriteLine("colf30String.Width = " + colf30String.Width.ToString)
            _objstreamwriter.WriteLine("colf01Memo.Width = " + colf01Memo.Width.ToString)
            _objstreamwriter.WriteLine("colf02Memo.Width = " + colf02Memo.Width.ToString)
            _objstreamwriter.WriteLine("colf01Int.Width = " + colf01Int.Width.ToString)
            _objstreamwriter.WriteLine("colf02Int.Width = " + colf02Int.Width.ToString)
            _objstreamwriter.WriteLine("colf03Int.Width = " + colf03Int.Width.ToString)
            _objstreamwriter.WriteLine("colf04Int.Width = " + colf04Int.Width.ToString)
            _objstreamwriter.WriteLine("colf05Int.Width = " + colf05Int.Width.ToString)
            _objstreamwriter.WriteLine("colf01Double.Width = " + colf01Double.Width.ToString)
            _objstreamwriter.WriteLine("colf02Double.Width = " + colf02Double.Width.ToString)
            _objstreamwriter.WriteLine("colf03Double.Width = " + colf03Double.Width.ToString)
            _objstreamwriter.WriteLine("colf04Double.Width = " + colf04Double.Width.ToString)
            _objstreamwriter.WriteLine("colf05Double.Width = " + colf05Double.Width.ToString)
            _objstreamwriter.WriteLine("colf01Date.Width = " + colf01Date.Width.ToString)
            _objstreamwriter.WriteLine("colf02Date.Width = " + colf02Date.Width.ToString)
            _objstreamwriter.WriteLine("colf03Date.Width = " + colf03Date.Width.ToString)
            _objstreamwriter.WriteLine("End Sub")
        End With

        _objstreamwriter.Close()
        fs.Close()

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "event - control"
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "k00Boolean" Then

            If CType(GridView1.GetFocusedRowCellValue("k00Boolean"), Boolean) = True Then
                GridView1.SetFocusedRowCellValue("k00Int", 1)
            Else
                GridView1.SetFocusedRowCellValue("k00Int", 0)
            End If

            GridView1.RefreshData()

        End If

        If _prop01TargetTransaksi = TargetTransaksi._01MD23BB01BULKORDER Then
            'f01Int = Lot
            If e.Column.FieldName = "f01Int" Then
                GridView1.SetFocusedRowCellValue("f02Double", CType(GridView1.GetFocusedRowCellValue("f01Double"), Double) * CType(GridView1.GetFocusedRowCellValue("f01Int"), Int16))
            End If

            'f24String - (MD - TipeProduksi)
            If e.Column.FieldName = "f27String" Then
                GridView1.SetFocusedRowCellValue("f24String", GridView1.GetFocusedRowCellDisplayText("f27String"))
            End If

            'f25String - (MD - SubTipeProduksi)
            If e.Column.FieldName = "f28String" Then
                GridView1.SetFocusedRowCellValue("f25String", GridView1.GetFocusedRowCellDisplayText("f28String"))
            End If

            'f26String - (Customer)
            If e.Column.FieldName = "f29String" Then
                GridView1.SetFocusedRowCellValue("f26String", GridView1.GetFocusedRowCellDisplayText("f29String"))
            End If

        End If

    End Sub

    Private Sub GridView1_LostFocus(sender As Object, e As EventArgs) Handles GridView1.LostFocus
        GridView1.PostEditor()
        GridView1.RefreshData()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim View As GridView = TryCast(sender, GridView)

        If e.RowHandle >= 0 Then
            If _prop01TargetTransaksi = TargetTransaksi._04MD23BB01CHECKPRODUCTCODE Then
                Dim pcIsOK As String = View.GetRowCellValue(e.RowHandle, View.Columns("f20String"))
                If pcIsOK = "ERR" Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.White
                End If
            Else
                Dim nCheck As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))

                If _prop01TargetTransaksi = TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER Then
                    If nCheck = 1 Then
                        e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
                    Else
                        e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
                    End If
                Else
                    If nCheck = 1 Then
                        e.Appearance.ForeColor = Color.Black
                    End If
                End If
            End If

        End If

        If e.Column.FieldName = "k04String" Or e.Column.FieldName = "f01String" Or e.Column.FieldName = "f02String" Or e.Column.FieldName = "f03String" Or e.Column.FieldName = "f04String" Then
            Dim pcString As String = ""
            pcString = View.GetRowCellDisplayText(e.RowHandle, View.Columns(e.Column.FieldName))
            If pcString.Contains("(X)") Then
                e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
            End If
        End If

    End Sub

    Private Sub _rscolk00Boolean_CheckedChanged(sender As Object, e As EventArgs) Handles _rscolk00Boolean.CheckedChanged
        GridView1.PostEditor()
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
            e.Appearance.DrawBackground(e.Cache, e.Bounds)
            e.Appearance.DrawString(e.Cache, "NoUrut", e.Bounds)
            e.Handled = True
        End If
    End Sub

    Private _Totf02Int As Integer = 0 : Private _Totf02Double As Double = 0.0
    Private pnf02Int As Integer = 0 : Private pnf02Double As Double = 0.0
    Private plBoolean As Boolean = False

    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        If _prop01TargetTransaksi = TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER Then

            Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, GridSummaryItem).Tag)
            Dim View As GridView = CType(sender, GridView)

            If e.SummaryProcess = CustomSummaryProcess.Start Then
                _Totf02Int = 0
                _Totf02Double = 0.0
            End If

            If e.SummaryProcess = CustomSummaryProcess.Calculate Then
                plBoolean = CBool(View.GetRowCellValue(e.RowHandle, "k00Boolean"))
                pnf02Int = CInt(View.GetRowCellValue(e.RowHandle, "f02Int"))
                pnf02Double = CDbl(View.GetRowCellValue(e.RowHandle, "f02Double"))

                If plBoolean Then
                    Select Case summaryID
                        Case 20
                            _Totf02Int += pnf02Int
                        Case 30
                            _Totf02Double += pnf02Double
                    End Select

                End If

            End If

            If e.SummaryProcess = CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 20
                        e.TotalValue = _Totf02Int
                    Case 30
                        e.TotalValue = _Totf02Double
                End Select
            End If

        End If
    End Sub

#End Region

#Region "********** method private - UPDATE/CHANGE **********"

    Public Enum TargetTransaksi
        'Transaksi
        _01MD23BB01BULKORDER = 0
        _02MD23BV01PRODUCTORDER = 1
        _03MD23DQ01CANCELPRODUCTIONORDER = 2

        _04MD23BB01CHECKPRODUCTCODE = 3

        'Reporting
        _20MDRPTPRODUCTIONORDER = 20
        _21MDRPTSTATUSPODIPRODUKSI = 21
    End Enum

    Private Sub _mp01SettingRepoColoumn()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BB01BULKORDER
                _rsRepoMaster50MDBulkOrder()

            Case TargetTransaksi._02MD23BV01PRODUCTORDER
                _rsRepoMaster50MDProductOrder()

            Case Else

        End Select
    End Sub

    Private Sub _mp02SettingVisibilityON()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BB01BULKORDER
                _vs01VisibilityCol50MDBulkOrder()
                _vs02VisibilityIndex50MDBulkOrder()

            Case TargetTransaksi._02MD23BV01PRODUCTORDER
                _vs01VisibilityCol50MDProductOrder()
                _vs02VisibilityIndex50MDProductOrder()

            Case TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER
                _vs01VisibilityCol51MDCANCELProductionOrder()
                _vs02VisibilityIndex51MDCANCELProductionOrder()

            Case TargetTransaksi._04MD23BB01CHECKPRODUCTCODE
                _vs01VisibilityCol50MDCheckProductCode()
                _vs01VisibilityIndexCol50MDCheckProductCode()

            Case TargetTransaksi._20MDRPTPRODUCTIONORDER
                _vs01VisibilityCol51MDProductionOrder()
                _vs02VisibilityIndex51MDProductionOrder()

            Case TargetTransaksi._21MDRPTSTATUSPODIPRODUKSI
                _vs01VisibilityCol52MDStatusPODiProduksi()
                _vs02VisibilityIndex52MDStatusPODiProduksi()

            Case Else

        End Select
    End Sub

    Private Sub _mp03SettingColumnCaption()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BB01BULKORDER
                _cc01CaptionCol50MDBulkOrder()

            Case TargetTransaksi._02MD23BV01PRODUCTORDER
                _cc01CaptionCol50MDProductOrder()

            Case TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER
                _cc01CaptionCol51MDCANCELProductionOrder()

            Case TargetTransaksi._04MD23BB01CHECKPRODUCTCODE
                _cc01CaptionCol50MDCheckProductCode()
                _ll01LainLain50MDCheckProductCode()

            Case TargetTransaksi._20MDRPTPRODUCTIONORDER
                _cc01CaptionCol51MDProductionOrder()

            Case TargetTransaksi._21MDRPTSTATUSPODIPRODUKSI
                _cc01CaptionCol52MDStatusPODiProduksi()

            Case Else
        End Select
    End Sub

    Private Sub _mp04SettingWriteColumn()
        Select Case _prop01TargetTransaksi
            Case TargetTransaksi._01MD23BB01BULKORDER
                _wr01WriteCol50MDBulkOrder()
                _tot01TotalBeratDanLotBulkOrder()

            Case TargetTransaksi._02MD23BV01PRODUCTORDER
                _wr01WriteCol50MDProductOrder()
                _tot01TotalBeratDanLotProductOrder()

            Case TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER
                _wr01WriteCol51MDCANCELProductionOrder()
                _tot01TotalCustomSummaryMDCANCELProductionOrder()

            Case TargetTransaksi._20MDRPTPRODUCTIONORDER
                _tot01TotalBeratDanLotMDProductionOrder()

            Case TargetTransaksi._21MDRPTSTATUSPODIPRODUKSI
                _tot01TotalBeratDanLot52MDStatusPODiProduksi()

            Case Else

        End Select
    End Sub

#Region "Method - TargetTransaksi"

#Region "***** MCDCreateOrder ==> form : ucMD23BB01BULKORDER *****"

    Private _rscolf27String As repoGEMINIMaster
    Private _rscolf28String As repoGEMINIMaster
    Private _rscolf29String As repoGEMINIMaster
    Private _rscolf02Memo As repoGEMINIPicture

    Private Sub _rsRepoMaster50MDBulkOrder()
        '=========================
        '*** f02Memo = Picture ***

        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsView.RowAutoHeight = True
        GridView1.BestFitColumns()

        _rscolf02Memo = New repoGEMINIPicture()
        colf02Memo.ColumnEdit = _rscolf02Memo

        '=========================

        'f01Int = Qty

        '=========================
        'f27String = MTOMTS
        _rscolf27String = New repoGEMINIMaster With {._prop_01dtGEMINIMaster = _prop04pdtTableMasterGEMINI,
                                                     ._prop_02cGEMINIDatabaseMaster = repoGEMINIMaster.DatabaseMaster.dbTABLEMASTERMasterTABLE02}
        _rscolf27String._01GEMINIBindingDataSource()
        _rscolf27String._02GEMINIFilterGroupMaster("f03String", "MERCHANDISE")
        colf27String.ColumnEdit = _rscolf27String

        '=========================
        'f28String = SubMTOMTS
        _rscolf28String = New repoGEMINIMaster With {._prop_01dtGEMINIMaster = _prop04pdtTableMasterGEMINI,
                                                  ._prop_02cGEMINIDatabaseMaster = repoGEMINIMaster.DatabaseMaster.dbTABLEMASTERMasterTABLE02}
        _rscolf28String._01GEMINIBindingDataSource()
        _rscolf28String._02GEMINIFilterGroupMaster("f03String", "SUBMERCHANDISE")
        colf28String.ColumnEdit = _rscolf28String

        '=========================
        'f29String = Customer
        _rscolf29String = New repoGEMINIMaster With {._prop_01dtGEMINIMaster = _prop03pdtSBUMasterGEMINI,
                                                     ._prop_02cGEMINIDatabaseMaster = repoGEMINIMaster.DatabaseMaster.dbSBUMasterTABLE02}
        _rscolf29String._01GEMINIBindingDataSource()
        _rscolf29String._02GEMINIFilterGroupMaster("k01String", "MCUSTOMER")
        colf29String.ColumnEdit = _rscolf29String
        '=========================
    End Sub

    Private Sub _cc01CaptionCol50MDBulkOrder()

        colf01Date.Caption = "InputDate"
        colf02Date.Caption = "ETA"  'Estimated Time of Arrival

        colk03String.Caption = "MasterCode"
        colk04String.Caption = "ProductCode"

        colf01String.Caption = "KodeBrand"
        colf02String.Caption = "NamaBrand"
        colf03String.Caption = "KodeItemProduct"
        colf04String.Caption = "NamaItemProduct"
        colf05String.Caption = "KodeColorFG"
        colf06String.Caption = "NamaColorFG"
        colf07String.Caption = "KodeKadar"
        colf08String.Caption = "NamaKadar"
        colf09String.Caption = "KodeSize"
        colf10String.Caption = "NamaSize"
        colf11String.Caption = "KodeProject"
        colf12String.Caption = "NamaProject"
        colf13String.Caption = "KodeWarnaMaterial"
        colf14String.Caption = "WarnaMaterial"
        colf02Memo.Caption = "Picture"

        colf01Double.Caption = "AvgWeight"
        colf02Double.Caption = "TotWeight"

        colf01Int.Caption = "Qty"

        colf21String.Caption = "PO.JIMS"
        colf03Memo.Caption = "RemarksSales"
        colf04Memo.Caption = "RemarksMD"
        colf05Memo.Caption = "Grafir"

        'colf27String.Caption = "MTOMTS"
        'colf28String.Caption = "SubMTOMTS"
        'colf29String.Caption = "Customer"
        colf24String.Caption = "MTOMTS"
        colf25String.Caption = "SubMTOMTS"
        colf26String.Caption = "Customer"

        colf23String.Caption = "PO.CMK"

    End Sub

    Private Sub _vs01VisibilityCol50MDBulkOrder()
        'VISIBLE
        colf01Date.Visible = True   '"InputDate"
        colf02Date.Visible = True   '"DeliveryDate"
        colf02Memo.Visible = True   '"Picture"
        colk03String.Visible = True   '"MasterCode"
        colk04String.Visible = True   '"ProductCode"
        colf02String.Visible = True   '"NamaBrand"
        colf04String.Visible = True   '"NamaItemProduct"
        colf06String.Visible = True   '"NamaColorFG"
        colf08String.Visible = True   '"NamaKadar"
        colf10String.Visible = True   '"NamaSize"
        colf12String.Visible = True   '"NamaProject"
        colf14String.Visible = True   '"WarnaMaterial"
        colf01Double.Visible = True   '"AvgWeight"
        colf02Double.Visible = True   '"TotWeight"

        colf01Int.Visible = True   '"Qty"
        colf21String.Visible = True   '"PO.JIMS"         
        'colf27String.Visible = True   '"MTOMTS"
        'colf28String.Visible = True   '"SubMTOMTS"
        'colf29String.Visible = True   '"Customer"

        colf24String.Visible = True   '"MTOMTS"
        colf25String.Visible = True   '"SubMTOMTS"
        colf26String.Visible = True   '"Customer"

        colf03Memo.Visible = True   '"RemarksSales"
        colf04Memo.Visible = True   '"RemarksMD"
        colf05Memo.Visible = True   '"Grafir"
        colf23String.Visible = True   'PO.CMK

        'UNVISIBLE
        colf01String.Visible = False   '"KodeBrand"
        colf03String.Visible = False   '"KodeItemProduct"
        colf05String.Visible = False   '"KodeColorFG"
        colf07String.Visible = False   '"KodeKadar"
        colf09String.Visible = False   '"KodeSize"
        colf11String.Visible = False   '"KodeProject"
        colf13String.Visible = False   '"KodeWarnaMaterial"
    End Sub

    Private Sub _vs02VisibilityIndex50MDBulkOrder()
        colf01Date.VisibleIndex = 0 '"InputDate"
        colf02Date.VisibleIndex = 1 '"DeliveryDate"
        colf02Memo.VisibleIndex = 2 '"Picture"
        colk03String.VisibleIndex = 3 '"MasterCode"
        colk04String.VisibleIndex = 4 '"ProductCode"
        colf02String.VisibleIndex = 5 '"NamaBrand"
        colf04String.VisibleIndex = 6 '"NamaItemProduct"
        colf06String.VisibleIndex = 7 '"NamaColorFG"
        colf08String.VisibleIndex = 8 '"NamaKadar"
        colf10String.VisibleIndex = 9 '"NamaSize"
        colf12String.VisibleIndex = 10 '"NamaProject"
        colf14String.VisibleIndex = 11 '"WarnaMaterial"
        colf01Double.VisibleIndex = 12 '"AvgWeight"
        colf02Double.VisibleIndex = 13 '"TotWeight"

        colf01Int.VisibleIndex = 14 '"Qty"
        'colf27String.VisibleIndex = 15 '"MTOMTS"
        'colf28String.VisibleIndex = 16 '"SubMTOMTS"
        'colf29String.VisibleIndex = 17 '"Customer"

        colf24String.VisibleIndex = 15 '"MTOMTS"
        colf25String.VisibleIndex = 16 '"SubMTOMTS"
        colf26String.VisibleIndex = 17 '"Customer"

        colf21String.VisibleIndex = 18   '"PO.JIMS"       
        colf03Memo.VisibleIndex = 19   '"RemarksSales"  
        colf04Memo.VisibleIndex = 20   '"RemarksMD"
        colf05Memo.VisibleIndex = 21   '"Grafir"
        colf23String.VisibleIndex = 22   'PO.CMK
    End Sub

    Private Sub _wr01WriteCol50MDBulkOrder()
        '****************************************************************
        '**** Update : semua READONLY, sb dari XLSX-nya sdh complete ****
        '****************************************************************

        'colf01Int.OptionsColumn.ReadOnly = False '"Qty"
        'colf27String.OptionsColumn.ReadOnly = False '"MTOMTS"
        'colf28String.OptionsColumn.ReadOnly = False '"SubMTOMTS"
        'colf29String.OptionsColumn.ReadOnly = False '"Customer"
    End Sub

    Private Sub _tot01TotalBeratDanLotBulkOrder()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"
    End Sub

    Public Sub _wd240707WidthMD23BB01BULKORDER()
        colk00Boolean.Width = 75
        colk00Int.Width = 75
        colk01String.Width = 75
        colk02Int.Width = 75
        colk03String.Width = 90
        colf01String.Width = 75
        colf02String.Width = 88
        colf03String.Width = 75
        colf04String.Width = 126
        colf05String.Width = 75
        colf06String.Width = 99
        colf07String.Width = 75
        colf08String.Width = 87
        colf09String.Width = 75
        colf10String.Width = 78
        colf11String.Width = 75
        colf12String.Width = 143
        colf13String.Width = 75
        colf14String.Width = 105
        colf15String.Width = 75
        colf16String.Width = 75
        colf17String.Width = 75
        colf18String.Width = 75
        colf19String.Width = 75
        colf20String.Width = 75
        colf21String.Width = 69
        colf22String.Width = 75
        colf23String.Width = 79

        colf24String.Width = 101
        colf25String.Width = 101
        colf26String.Width = 101

        colf27String.Width = 101
        colf28String.Width = 96
        colf29String.Width = 77
        colf30String.Width = 75
        colf01Memo.Width = 75
        colf02Memo.Width = 260
        colf01Int.Width = 43
        colf02Int.Width = 75
        colf03Int.Width = 75
        colf04Int.Width = 75
        colf05Int.Width = 75
        colf01Double.Width = 86
        colf02Double.Width = 83
        colf03Double.Width = 75
        colf04Double.Width = 75
        colf05Double.Width = 75
        colf01Date.Width = 94
        colf02Date.Width = 79
        colf03Date.Width = 75
    End Sub


#End Region

#Region "***** MCD CHECKPRODUCTCODE ==> form : ucMD23BB01BULKORDER *****"
    Private Sub _cc01CaptionCol50MDCheckProductCode()

        'pcBrand, pcColor, pcKadar, pcSize
        'dtRow("f11String") = dtRow01("f02String")
        'dtRow("f12String") = dtRow01("f06String")
        'dtRow("f13String") = dtRow01("f08String")
        'dtRow("f14String") = dtRow01("f10String")

        colf05String.Caption = "InputDate"
        colk03String.Caption = "DesignMaster"
        colk04String.Caption = "ProductCode"

        colf01String.Caption = "Brand - MD"
        colf02String.Caption = "Color - MD"
        colf03String.Caption = "Kadar - MD"
        colf04String.Caption = "Size - MD"

        colf11String.Caption = "Brand - PD"
        colf12String.Caption = "Color - PD"
        colf13String.Caption = "Kadar - PD"
        colf14String.Caption = "Size - PD"

        colf20String.Caption = "IsOK"
    End Sub

    Private Sub _vs01VisibilityCol50MDCheckProductCode()
        colf05String.Visible = True   '"DesignMaster"
        colk03String.Visible = True   '"DesignMaster"
        colk04String.Visible = True   '"ProductCode"

        colf01String.Visible = True   '"Brand - MD"
        colf02String.Visible = True   '"Color - MD"
        colf03String.Visible = True   '"Kadar - MD"
        colf04String.Visible = True   '"Size - MD"

        colf11String.Visible = True   '"Brand - PD"
        colf12String.Visible = True   '"Color - PD"
        colf13String.Visible = True   '"Kadar - PD"
        colf14String.Visible = True   '"Size - PD"

        colf20String.Visible = True   '"IsOK"
    End Sub

    Private Sub _vs01VisibilityIndexCol50MDCheckProductCode()
        colf05String.VisibleIndex = 0   '"DesignMaster"
        colk03String.VisibleIndex = 1   '"DesignMaster"
        colk04String.VisibleIndex = 2   '"ProductCode"

        colf01String.VisibleIndex = 3   '"Brand - PD"
        colf02String.VisibleIndex = 4   '"Color - PD"
        colf03String.VisibleIndex = 5   '"Kadar - PD"
        colf04String.VisibleIndex = 6   '"Size - PD"

        colf11String.VisibleIndex = 7   '"Brand - MD"
        colf12String.VisibleIndex = 8   '"Color - MD"
        colf13String.VisibleIndex = 9   '"Kadar - MD"
        colf14String.VisibleIndex = 10   '"Size - MD"

        colf20String.VisibleIndex = 11   '"IsOK"
    End Sub

    Private Sub _ll01LainLain50MDCheckProductCode()
        With colf01String
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With
        With colf02String
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With
        With colf03String
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With
        With colf04String
            .AppearanceHeader.BackColor = Color.Gold
            .AppearanceCell.BackColor = Color.LightGreen
        End With

        With colf11String
            .AppearanceCell.BackColor = Color.LightBlue
        End With
        With colf12String
            .AppearanceCell.BackColor = Color.LightBlue
        End With
        With colf13String
            .AppearanceCell.BackColor = Color.LightBlue
        End With
        With colf14String
            .AppearanceCell.BackColor = Color.LightBlue
        End With

        With colf20String
            .AppearanceHeader.BackColor = Color.GreenYellow
            .AppearanceCell.BackColor = Color.LightYellow
        End With
    End Sub

#End Region

#Region "***** MCDProductOrder ==> form : ucMD23BV01PRODUCTORDER *****"
    Private Sub _rsRepoMaster50MDProductOrder()
        '=========================
        '*** f02Memo = Picture ***

        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsView.RowAutoHeight = True
        GridView1.BestFitColumns()

        _rscolf02Memo = New repoGEMINIPicture()
        colf02Memo.ColumnEdit = _rscolf02Memo
    End Sub

    Private Sub _cc01CaptionCol50MDProductOrder()
        'colk00Boolean.Caption = "#"

        colk04String.Caption = "ProductCode"

        colf01String.Caption = "KodeBrand"
        colf02String.Caption = "NamaBrand"
        colf03String.Caption = "KodeItemProduct"
        colf04String.Caption = "NamaItemProduct"
        colf05String.Caption = "KodeColorFG"
        colf06String.Caption = "NamaColorFG"
        colf07String.Caption = "KodeKadar"
        colf08String.Caption = "NamaKadar"
        colf09String.Caption = "KodeSize"
        colf10String.Caption = "NamaSize"
        colf11String.Caption = "KodeProject"
        colf12String.Caption = "NamaProject"
        colf13String.Caption = "KodeWarnaMaterial"
        colf14String.Caption = "WarnaMaterial"
        colf02Memo.Caption = "Picture"

        colf01Double.Caption = "AvgWeight"
        colf02Double.Caption = "TotWeight"

        colf01Int.Caption = "Qty"
    End Sub

    Private Sub _vs01VisibilityCol50MDProductOrder()
        'colk00Boolean.Visible = True   '"#"

        'VISIBLE
        colf02Memo.Visible = True   '"Picture"
        colk04String.Visible = True   '"ProductCode"
        colf02String.Visible = True   '"NamaBrand"
        colf04String.Visible = True   '"NamaItemProduct"
        colf06String.Visible = True   '"NamaColorFG"
        colf08String.Visible = True   '"NamaKadar"
        colf10String.Visible = True   '"NamaSize"
        colf12String.Visible = True   '"NamaProject"
        colf14String.Visible = True   '"WarnaMaterial"
        colf01Double.Visible = True   '"AvgWeight"
        colf02Double.Visible = True   '"TotWeight"

        colf01Int.Visible = True   '"Qty"

    End Sub

    Private Sub _vs02VisibilityIndex50MDProductOrder()
        'colk00Boolean.VisibleIndex = 0 '"#"

        'VISIBLE
        colf02Memo.VisibleIndex = 1 '"Picture"
        colk04String.VisibleIndex = 2 '"ProductCode"
        colf02String.VisibleIndex = 3 '"NamaBrand"
        colf04String.VisibleIndex = 4 '"NamaItemProduct"
        colf06String.VisibleIndex = 5 '"NamaColorFG"
        colf08String.VisibleIndex = 6 '"NamaKadar"
        colf10String.VisibleIndex = 7 '"NamaSize"
        colf12String.VisibleIndex = 8 '"NamaProject"
        colf14String.VisibleIndex = 9 '"WarnaMaterial"
        colf01Double.VisibleIndex = 10 '"AvgWeight"
        colf02Double.VisibleIndex = 11 '"TotWeight"

        colf01Int.VisibleIndex = 12 '"Qty"
    End Sub

    Private Sub _wr01WriteCol50MDProductOrder()
        'colk00Boolean.OptionsColumn.ReadOnly = False '"#"
        colf01Int.OptionsColumn.ReadOnly = False '"Qty"
    End Sub

    Private Sub _tot01TotalBeratDanLotProductOrder()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"

    End Sub

#End Region

#Region "***** MCDCANCELPRODUCTIONORDER ==> form : ucMD23DQ01CANCELPRODUCTIONORDER *****"
    Private Sub _cc01CaptionCol51MDCANCELProductionOrder()
        colk00Boolean.Caption = "#"
        colk04String.Caption = "ProductCode"
        colf02String.Caption = "Brand"
        colf04String.Caption = "TipeBRJ"
        colf06String.Caption = "Color"
        colf08String.Caption = "Kadar"
        colf10String.Caption = "Size"
        colf12String.Caption = "Projects"
        colf15String.Caption = "TipeProd"
        colf17String.Caption = "SubTipeProd"
        colf19String.Caption = "Customer"
        colf21String.Caption = "PO. JIMS"
        colf02Int.Caption = "TQty"
        colf02Double.Caption = "TBerat"
    End Sub

    Private Sub _vs01VisibilityCol51MDCANCELProductionOrder()
        colk00Boolean.Visible = True   '"#"
        colk04String.Visible = True   '"ProductCode"
        colf02String.Visible = True   '"Brand"
        colf04String.Visible = True   '"TipeBRJ"
        colf06String.Visible = True   '"Color"
        colf08String.Visible = True   '"Kadar"
        colf10String.Visible = True   '"Size"
        colf12String.Visible = True   '"Projects"
        colf15String.Visible = True   '"TipeProd"
        colf17String.Visible = True   '"SubTipeProd"
        colf19String.Visible = True   '"Customer"
        colf21String.Visible = True   '"PO. JIMS"
        colf02Int.Visible = True   '"TQty"
        colf02Double.Visible = True   '"TBerat"
    End Sub

    Private Sub _vs02VisibilityIndex51MDCANCELProductionOrder()
        colk00Boolean.VisibleIndex = 0   '"#"
        colk04String.VisibleIndex = 1   '"ProductCode"
        colf02String.VisibleIndex = 2   '"Brand"
        colf04String.VisibleIndex = 3   '"TipeBRJ"
        colf06String.VisibleIndex = 4   '"Color"
        colf08String.VisibleIndex = 5   '"Kadar"
        colf10String.VisibleIndex = 6   '"Size"
        colf12String.VisibleIndex = 7   '"Projects"
        colf15String.VisibleIndex = 8   '"TipeProd"
        colf17String.VisibleIndex = 9   '"SubTipeProd"
        colf19String.VisibleIndex = 10   '"Customer"
        colf21String.VisibleIndex = 11   '"PO. JIMS"
        colf02Int.VisibleIndex = 12   '"TQty"
        colf02Double.VisibleIndex = 13  '"TBerat"
    End Sub

    Private Sub _wr01WriteCol51MDCANCELProductionOrder()
        colk00Boolean.OptionsColumn.ReadOnly = False '"#"
    End Sub

    Private Sub _tot01TotalCustomSummaryMDCANCELProductionOrder()
        '"TQty"
        colf02Int.SummaryItem.SummaryType = SummaryItemType.Custom
        colf02Int.SummaryItem.DisplayFormat = "{0:n0}"
        colf02Int.SummaryItem.Tag = 20
        CType(colf02Int.View, GridView).OptionsView.ShowFooter = True

        '"TBerat"
        colf02Double.SummaryItem.SummaryType = SummaryItemType.Custom
        colf02Double.SummaryItem.DisplayFormat = "{0:n2}"
        colf02Double.SummaryItem.Tag = 30
        CType(colf02Double.View, GridView).OptionsView.ShowFooter = True
    End Sub

#End Region

#End Region

#Region "Method - TargetReport"

#Region "REPORT - 51.ProductionOrder"
    Private Sub _cc01CaptionCol51MDProductionOrder()
        colk04String.Caption = "ProductCode"
        colk05String.Caption = "No.PO"

        colf19String.Caption = "Customer"
        colf02String.Caption = "Brand"
        colf04String.Caption = "Item"
        colf06String.Caption = "WarnaBRJ"
        colf08String.Caption = "Kadar"
        colf10String.Caption = "Size"
        colf12String.Caption = "Project"
        colf14String.Caption = "WarnaMaterial"
        colf15String.Caption = "TipeProduksi"
        colf17String.Caption = "SubTipeProduksi"
        colf03Memo.Caption = "Remarks Sales"
        colf04Memo.Caption = "Remarks MD"

        colf01Int.Caption = "T.UnitOrder"
        colf02Int.Caption = "T.UnitPO"

        colf01Double.Caption = "T.BeratOrder"
        colf02Double.Caption = "T.BeratPO"

        colf01Date.Caption = "CreatePO"
        colf02Date.Caption = "EstDeliveryDate"

        colf29String.Caption = "Document"
        colf30String.Caption = "Status"
        colf01Memo.Caption = "Note"
    End Sub

    Private Sub _vs01VisibilityCol51MDProductionOrder()
        colk04String.Visible = True       '"ProductCode"
        colk05String.Visible = True       '"No.PO"

        colf19String.Visible = True       '"Customer"
        colf02String.Visible = True       '"Brand"
        colf04String.Visible = True       '"Item"
        colf06String.Visible = True       '"WarnaBRJ"
        colf08String.Visible = True       '"Kadar"
        colf10String.Visible = True       '"Size"
        colf12String.Visible = True       '"Project"
        colf14String.Visible = True       '"WarnaMaterial"
        colf15String.Visible = True       '"TipeProduksi"
        colf17String.Visible = True       '"SubTipeProduksi"
        colf03Memo.Visible = True         '"Remarks Sales"
        colf04Memo.Visible = True         '"Remarks MD"

        colf01Int.Visible = True       '"T.UnitOrder"
        colf02Int.Visible = True       '"T.UnitPO"

        colf01Double.Visible = True       '"T.BeratOrder"
        colf02Double.Visible = True       '"T.BeratPO"

        colf01Date.Visible = True       '"CreatePO"
        colf02Date.Visible = True       '"EstDeliveryDate"

        colf29String.Visible = True       '"Document"
        colf30String.Visible = True       '"Status"
        colf01Memo.Visible = True       '"Note"
    End Sub

    Private Sub _vs02VisibilityIndex51MDProductionOrder()
        colf01Date.VisibleIndex = 0       '"CreatePO"
        colk05String.VisibleIndex = 1       '"No.PO"
        colk04String.VisibleIndex = 2       '"ProductCode"

        colf19String.VisibleIndex = 3       '"Customer"
        colf02String.VisibleIndex = 4       '"Brand"
        colf04String.VisibleIndex = 5       '"Item"
        colf06String.VisibleIndex = 6       '"WarnaBRJ"
        colf08String.VisibleIndex = 7       '"Kadar"
        colf10String.VisibleIndex = 8       '"Size"
        colf12String.VisibleIndex = 9       '"Project"
        colf14String.VisibleIndex = 10      '"WarnaMaterial"
        colf15String.VisibleIndex = 11      '"TipeProduksi"
        colf17String.VisibleIndex = 12      '"SubTipeProduksi"
        colf03Memo.VisibleIndex = 13        '"Remarks Sales"
        colf04Memo.VisibleIndex = 14        '"Remarks MD"

        colf01Int.VisibleIndex = 15         '"T.UnitOrder"
        colf01Double.VisibleIndex = 16      '"T.BeratOrder"

        colf02Int.VisibleIndex = 17         '"T.UnitPO"
        colf02Double.VisibleIndex = 18      '"T.BeratPO"

        colf02Date.VisibleIndex = 19        '"EstDeliveryDate"

        colf29String.VisibleIndex = 20      '"Document"
        colf30String.VisibleIndex = 21      '"Status"
        colf01Memo.VisibleIndex = 22        '"Note"
    End Sub

    Private Sub _tot01TotalBeratDanLotMDProductionOrder()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

        GridView1.Columns("f02Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f02Int").SummaryItem.FieldName = "f02Int"
        GridView1.Columns("f02Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f02Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f02Double").SummaryItem.FieldName = "f02Double"
        GridView1.Columns("f02Double").SummaryItem.DisplayFormat = "{0:n2}"
    End Sub

#End Region

#Region "REPORT - 52.Status PO di Produksi"
    Private Sub _cc01CaptionCol52MDStatusPODiProduksi()
        colf01String.Caption = "PO"
        colf02String.Caption = "SKU"
        colf03String.Caption = "ProductCode"
        colf04String.Caption = "NORO"
        colf05String.Caption = "ProsesProduksi"

        colf01Date.Caption = "Mutasi"
        colf01Int.Caption = "Lot"
        colf01Double.Caption = "Berat"
    End Sub

    Private Sub _vs01VisibilityCol52MDStatusPODiProduksi()
        colf01String.Visible = True       '"PO"
        colf02String.Visible = True       '"SKU"
        colf03String.Visible = True       '"ProductCode"
        colf04String.Visible = True       '"NORO"
        colf05String.Visible = True       '"ProsesProduksi"

        colf01Date.Visible = True         '"Mutasi"
        colf01Int.Visible = True          '"Lot"
        colf01Double.Visible = True       '"Berat"
    End Sub

    Private Sub _vs02VisibilityIndex52MDStatusPODiProduksi()
        colf01String.VisibleIndex = 0       '"PO"
        colf02String.VisibleIndex = 1       '"SKU"
        colf03String.VisibleIndex = 2       '"ProductCode"
        colf04String.VisibleIndex = 3       '"NORO"
        colf05String.VisibleIndex = 4       '"ProsesProduksi"

        colf01Date.VisibleIndex = 5       '"Mutasi"
        colf01Int.VisibleIndex = 6       '"Lot"
        colf01Double.VisibleIndex = 7       '"Berat"
    End Sub

    Private Sub _tot01TotalBeratDanLot52MDStatusPODiProduksi()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"
    End Sub


#End Region

#End Region

#End Region

End Class
