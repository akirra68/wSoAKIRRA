Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class ucGridDetailCatalog
    Implements IDisposable

    Property _prop01TargetTransaksi As TargetInfoDetailCatalog
    Property _prop02pdtDataSourceGrid As DataTable

#Region "private - repository"

    Private _rscolf01Int As New repoGEMININumeric
    Private _rscolf01Double As New repoGEMININumeric
    Private _rscolf01Date As New repoGEMINIDate
    Private _rscolf02Date As New repoGEMINIDate

#End Region

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ucGridDetailCatalog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#End Region

#Region "private - custom method"

    Private Sub _cm01InitFieldGrid()
        colf01String.FieldName = "f01String"
        colf02String.FieldName = "f02String"
        colf03String.FieldName = "f03String"
        colf04String.FieldName = "f04String"
        colf05String.FieldName = "f05String"
        colf06String.FieldName = "f06String"
        colf01Int.FieldName = "f01Int"
        colf01Double.FieldName = "f01Double"
        colf01Date.FieldName = "f01Date"
        colf02Date.FieldName = "f02Date"
    End Sub

    Private Sub _cm02InitRepoColumn()
        _rscolf01Int._01InitRepoInteger()
        _rscolf01Double._02InitRepoDoubleMoney(3)
        _rscolf01Date._01InitRepoDate()
        _rscolf02Date._01InitRepoDate()
    End Sub

    Private Sub _cm03InitColumnEdit()
        colf01Int.ColumnEdit = _rscolf01Int
        colf01Double.ColumnEdit = _rscolf01Double
        colf01Date.ColumnEdit = _rscolf01Date
        colf02Date.ColumnEdit = _rscolf02Date
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
        _cm04InitGridSummaryItem(colf01Int, "f01Int", "INT")
        _cm04InitGridSummaryItem(colf01Double, "f01Double", "DBL")
    End Sub

    Private Sub _cm06InitVisibilityOFF()
        colf01String.Visible = False
        colf02String.Visible = False
        colf03String.Visible = False
        colf04String.Visible = False
        colf05String.Visible = False
        colf06String.Visible = False

        colf01Int.Visible = False
        colf01Double.Visible = False

        colf01Date.Visible = False
        colf02Date.Visible = False
    End Sub

    Private Sub _cm07InitVisibilityIndexOFF()
        colf01String.VisibleIndex = -1
        colf02String.VisibleIndex = -1
        colf03String.VisibleIndex = -1
        colf04String.VisibleIndex = -1
        colf05String.VisibleIndex = -1
        colf06String.VisibleIndex = -1

        colf01Int.VisibleIndex = -1
        colf01Double.VisibleIndex = -1

        colf01Date.VisibleIndex = -1
        colf02Date.VisibleIndex = -1
    End Sub

    Private Sub _cm08ReadOnlyGrid()
        colf01String.OptionsColumn.ReadOnly = True
        colf02String.OptionsColumn.ReadOnly = True
        colf03String.OptionsColumn.ReadOnly = True
        colf04String.OptionsColumn.ReadOnly = True
        colf05String.OptionsColumn.ReadOnly = True
        colf06String.OptionsColumn.ReadOnly = True

        colf01Int.OptionsColumn.ReadOnly = True
        colf01Double.OptionsColumn.ReadOnly = True

        colf01Date.OptionsColumn.ReadOnly = True
        colf02Date.OptionsColumn.ReadOnly = True
    End Sub

    Private Sub _cm09PropertiesGridONTarget()
        'OFF
        _cm06InitVisibilityOFF()
        _cm07InitVisibilityIndexOFF()

        'ON
        _mp01SettingVisibilityON()
        _mp02SettingColumnCaption()
        _mp03SettingTotalNumerik()
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
#End Region

#Region "********** method private - UPDATE/CHANGE **********"

    Public Enum TargetInfoDetailCatalog
        _dcMerchandise = 0
        _dcBOMCastedPart = 1
        _dcBOMFCI = 2
        _dcBOMStone = 3
        _dcProduksi = 4
    End Enum

    Private Sub _mp01SettingVisibilityON()
        Select Case _prop01TargetTransaksi
            Case TargetInfoDetailCatalog._dcBOMCastedPart
                _vs01VisibilityColDCBOMCastedPart()
                _vs02VisibilityIndexDCBOMCastedPart()

            Case TargetInfoDetailCatalog._dcBOMFCI
                _vs01VisibilityColDCBOMFCI()
                _vs02VisibilityIndexDCBOMFCI()

            Case TargetInfoDetailCatalog._dcBOMStone
                _vs01VisibilityColDCBOMStone()
                _vs02VisibilityIndexDCBOMStone()

            Case TargetInfoDetailCatalog._dcMerchandise
                _vs01VisibilityColDCMerchandise()
                _vs02VisibilityIndexDCMerchandise()

            Case TargetInfoDetailCatalog._dcProduksi
                _vs01VisibilityColDCProduksi()
                _vs02VisibilityIndexDCProduksi()
        End Select
    End Sub

    Private Sub _mp02SettingColumnCaption()
        Select Case _prop01TargetTransaksi
            Case TargetInfoDetailCatalog._dcBOMCastedPart
                _cc01CaptionColDCBOMCastedPart()

            Case TargetInfoDetailCatalog._dcBOMFCI
                _cc01CaptionColDCBOMFCI()

            Case TargetInfoDetailCatalog._dcBOMStone
                _cc01CaptionColDCBOMStone()

            Case TargetInfoDetailCatalog._dcMerchandise
                _cc01CaptionColDCMerchandise()

            Case TargetInfoDetailCatalog._dcProduksi
                _cc01CaptionColDCProduksi()
        End Select
    End Sub

    Private Sub _mp03SettingTotalNumerik()
        Select Case _prop01TargetTransaksi
            Case TargetInfoDetailCatalog._dcBOMCastedPart
                _tot01TotalBeratDanLotDCBOMCastedPart()

            Case TargetInfoDetailCatalog._dcBOMFCI
                _tot01TotalBeratDanLotDCBOMFCI()

            Case TargetInfoDetailCatalog._dcBOMStone
                _tot01TotalBeratDanLotDCBOMStone()

            Case TargetInfoDetailCatalog._dcMerchandise
                _tot01TotalBeratDanLotDCMerchandise()

            Case TargetInfoDetailCatalog._dcProduksi
                _tot01TotalBeratDanLotDCProduksi()
        End Select
    End Sub

#End Region

#Region "***** Merchandise Detail Catalog ==> form : ucMD23GN01DETAILCATALOGPRODUCT *****"
    Private Sub _cc01CaptionColDCMerchandise()
        colf01String.Caption = "Title"
        colf02String.Caption = "No.Document"
        colf03String.Caption = "MTOMTS"
        colf04String.Caption = "SUBMTOMTS"
        colf05String.Caption = "Customer"
        colf06String.Caption = ""

        colf01Int.Caption = "Qty Order"
        colf01Double.Caption = ""

        colf01Date.Caption = "InputDate"
        colf02Date.Caption = "ETA"  'Estimated Time of Arrival

    End Sub

    Private Sub _vs01VisibilityColDCMerchandise()
        colf01String.Visible = True
        colf02String.Visible = True
        colf03String.Visible = True
        colf04String.Visible = True
        colf05String.Visible = True
        colf06String.Visible = False

        colf01Int.Visible = True
        colf01Double.Visible = False

        colf01Date.Visible = True
        colf02Date.Visible = True

    End Sub

    Private Sub _vs02VisibilityIndexDCMerchandise()
        colf01String.VisibleIndex = 0
        colf02String.VisibleIndex = 1
        colf03String.VisibleIndex = 2
        colf04String.VisibleIndex = 3
        colf05String.VisibleIndex = 4
        colf06String.VisibleIndex = -1

        colf01Int.VisibleIndex = 5
        colf01Double.VisibleIndex = -1

        colf01Date.VisibleIndex = 6
        colf02Date.VisibleIndex = 7
    End Sub

    Private Sub _tot01TotalBeratDanLotDCMerchandise()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

    End Sub
#End Region

#Region "***** BOM-CastedPart Detail Catalog ==> form : ucMD23GN01DETAILCATALOGPRODUCT *****"
    Private Sub _cc01CaptionColDCBOMCastedPart()
        colf01String.Caption = "Rubber"
        colf02String.Caption = "IDCastedPart"
        colf03String.Caption = "CastedPart"
        colf04String.Caption = "Assembly"
        colf05String.Caption = "Plating"
        colf06String.Caption = "Finishing"

        colf01Int.Caption = "Pcs"
        colf01Double.Caption = "Berat"

        colf01Date.Caption = ""
        colf02Date.Caption = ""

    End Sub

    Private Sub _vs01VisibilityColDCBOMCastedPart()
        colf01String.Visible = True
        colf02String.Visible = True
        colf03String.Visible = True
        colf04String.Visible = True
        colf05String.Visible = True
        colf06String.Visible = True

        colf01Int.Visible = True
        colf01Double.Visible = True

        colf01Date.Visible = False
        colf02Date.Visible = False

    End Sub

    Private Sub _vs02VisibilityIndexDCBOMCastedPart()
        colf01String.VisibleIndex = 0
        colf02String.VisibleIndex = 1
        colf03String.VisibleIndex = 2
        colf04String.VisibleIndex = 3
        colf05String.VisibleIndex = 4
        colf06String.VisibleIndex = 5

        colf01Int.VisibleIndex = 6
        colf01Double.VisibleIndex = 7

        colf01Date.VisibleIndex = -1
        colf02Date.VisibleIndex = -1
    End Sub

    Private Sub _tot01TotalBeratDanLotDCBOMCastedPart()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

    End Sub
#End Region

#Region "***** BOM-FCI Detail Catalog ==> form : ucMD23GN01DETAILCATALOGPRODUCT *****"
    Private Sub _cc01CaptionColDCBOMFCI()
        colf01String.Caption = "FCI Code"
        colf02String.Caption = "FCI"
        colf03String.Caption = ""
        colf04String.Caption = ""
        colf05String.Caption = ""
        colf06String.Caption = ""

        colf01Int.Caption = "Pcs"
        colf01Double.Caption = "Berat"

        colf01Date.Caption = ""
        colf02Date.Caption = ""

    End Sub

    Private Sub _vs01VisibilityColDCBOMFCI()
        colf01String.Visible = True
        colf02String.Visible = True
        colf03String.Visible = False
        colf04String.Visible = False
        colf05String.Visible = False
        colf06String.Visible = False

        colf01Int.Visible = True
        colf01Double.Visible = True

        colf01Date.Visible = False
        colf02Date.Visible = False

    End Sub

    Private Sub _vs02VisibilityIndexDCBOMFCI()
        colf01String.VisibleIndex = 0
        colf02String.VisibleIndex = 1
        colf03String.VisibleIndex = -1
        colf04String.VisibleIndex = -1
        colf05String.VisibleIndex = -1
        colf06String.VisibleIndex = -1

        colf01Int.VisibleIndex = 2
        colf01Double.VisibleIndex = 3

        colf01Date.VisibleIndex = -1
        colf02Date.VisibleIndex = -1
    End Sub

    Private Sub _tot01TotalBeratDanLotDCBOMFCI()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

    End Sub
#End Region

#Region "***** BOM-Stone Detail Catalog ==> form : ucMD23GN01DETAILCATALOGPRODUCT *****"
    Private Sub _cc01CaptionColDCBOMStone()
        colf01String.Caption = "Stone Code"
        colf02String.Caption = "Stone"
        colf03String.Caption = "Brand Stone"
        colf04String.Caption = ""
        colf05String.Caption = ""
        colf06String.Caption = ""

        colf01Int.Caption = "Butir"
        colf01Double.Caption = "Berat (gr)"

        colf01Date.Caption = ""
        colf02Date.Caption = ""

    End Sub

    Private Sub _vs01VisibilityColDCBOMStone()
        colf01String.Visible = True
        colf02String.Visible = True
        colf03String.Visible = True
        colf04String.Visible = False
        colf05String.Visible = False
        colf06String.Visible = False

        colf01Int.Visible = True
        colf01Double.Visible = True

        colf01Date.Visible = False
        colf02Date.Visible = False

    End Sub

    Private Sub _vs02VisibilityIndexDCBOMStone()
        colf01String.VisibleIndex = 0
        colf02String.VisibleIndex = 1
        colf03String.VisibleIndex = 2
        colf04String.VisibleIndex = -1
        colf05String.VisibleIndex = -1
        colf06String.VisibleIndex = -1

        colf01Int.VisibleIndex = 3
        colf01Double.VisibleIndex = 4

        colf01Date.VisibleIndex = -1
        colf02Date.VisibleIndex = -1
    End Sub

    Private Sub _tot01TotalBeratDanLotDCBOMStone()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

    End Sub
#End Region

#Region "***** Produksi Detail Catalog ==> form : ucMD23GN01DETAILCATALOGPRODUCT *****"
    Private Sub _cc01CaptionColDCProduksi()
        colf01String.Caption = "SKU"
        colf02String.Caption = "Last Position"
        colf03String.Caption = ""
        colf04String.Caption = ""
        colf05String.Caption = ""
        colf06String.Caption = ""

        colf01Int.Caption = "Lot"
        colf01Double.Caption = "Berat"

        colf01Date.Caption = "Tgl. Mutasi"
        colf02Date.Caption = ""

    End Sub

    Private Sub _vs01VisibilityColDCProduksi()
        colf01String.Visible = True
        colf02String.Visible = True
        colf03String.Visible = False
        colf04String.Visible = False
        colf05String.Visible = False
        colf06String.Visible = False

        colf01Int.Visible = True
        colf01Double.Visible = True

        colf01Date.Visible = True
        colf02Date.Visible = False

    End Sub

    Private Sub _vs02VisibilityIndexDCProduksi()
        colf01String.VisibleIndex = 0
        colf02String.VisibleIndex = 1
        colf03String.VisibleIndex = -1
        colf04String.VisibleIndex = -1
        colf05String.VisibleIndex = -1
        colf06String.VisibleIndex = -1

        colf01Int.VisibleIndex = 2
        colf01Double.VisibleIndex = 3

        colf01Date.VisibleIndex = 4
        colf02Date.VisibleIndex = -1
    End Sub

    Private Sub _tot01TotalBeratDanLotDCProduksi()
        GridView1.OptionsView.ShowFooter = True

        GridView1.Columns("f01Int").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Int").SummaryItem.FieldName = "f01Int"
        GridView1.Columns("f01Int").SummaryItem.DisplayFormat = "{0:n0}"

        GridView1.Columns("f01Double").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("f01Double").SummaryItem.FieldName = "f01Double"
        GridView1.Columns("f01Double").SummaryItem.DisplayFormat = "{0:n2}"

    End Sub

#End Region

#Region "event - control"

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        'Dim View As GridView = TryCast(sender, GridView)

        'If e.RowHandle >= 0 Then
        '    'Dim nCheck As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("k00Int"))

        '    'If _prop01TargetTransaksi = TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER Then
        '    '    If nCheck = 1 Then
        '    '        e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Italic + System.Drawing.FontStyle.Bold + System.Drawing.FontStyle.Strikeout, GraphicsUnit.Point)
        '    '    Else
        '    '        e.Appearance.Font = New Font("Courier New", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point)
        '    '    End If
        '    'Else
        '    '    If nCheck = 1 Then
        '    '        e.Appearance.ForeColor = Color.Black
        '    '    End If
        '    'End If
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

#End Region

End Class
