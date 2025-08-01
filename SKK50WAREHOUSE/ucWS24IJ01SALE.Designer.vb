<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS24IJ01SALE
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS24IJ01SALE))
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        TabDetailStock = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdDetailStock = New SKK02OBJECTS.ucWSGrid()
        TabSummaryStock = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _pvSummaryStock = New SKK02OBJECTS.ucWSPivot()
        TabPenjualan = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdPenjualan = New SKK02OBJECTS.ucWSGrid()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnuBar1TargetPenjualan = New DevExpress.XtraBars.BarSubItem()
        mnuBar11SalesSelling = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar11SalesSelling = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        _colf06String = New DevExpress.XtraGrid.Columns.GridColumn()
        _colf07String = New DevExpress.XtraGrid.Columns.GridColumn()
        mnuBar12Consignment = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar12Consignment = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        RepositoryItemSearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        _colf06String1 = New DevExpress.XtraGrid.Columns.GridColumn()
        _colf07String1 = New DevExpress.XtraGrid.Columns.GridColumn()
        mnuBar13Exhibition = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar13Exhibition = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        _colf05StringExh = New DevExpress.XtraGrid.Columns.GridColumn()
        _colf06StringExh = New DevExpress.XtraGrid.Columns.GridColumn()
        mnuBar02TglPenjualan = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar02TglPenjualan = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnuBar04Kepada = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar04Kepada = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        _colk02StringCust = New DevExpress.XtraGrid.Columns.GridColumn()
        _colk03StringCust = New DevExpress.XtraGrid.Columns.GridColumn()
        mnuBar06TOP = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar06TOP = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        _colk13StringTOP = New DevExpress.XtraGrid.Columns.GridColumn()
        _colk14StringTOP = New DevExpress.XtraGrid.Columns.GridColumn()
        mnuBar03SKU = New DevExpress.XtraBars.BarButtonItem()
        mnuBar05Save = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        TabDetailStock.SuspendLayout()
        TabSummaryStock.SuspendLayout()
        TabPenjualan.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar11SalesSelling, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemSearchLookUpEdit1View, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar12Consignment, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemSearchLookUpEdit2View, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar13Exhibition, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar02TglPenjualan, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar02TglPenjualan.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar04Kepada, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar06TOP, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView3, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemTextEdit2, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemTextEdit1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(TabPane1)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 24)
        LayoutControl1.Margin = New Padding(2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1175, 481)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' TabPane1
        ' 
        TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True
        TabPane1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 10F, FontStyle.Italic)
        TabPane1.AppearanceButton.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        TabPane1.AppearanceButton.Hovered.Options.UseFont = True
        TabPane1.AppearanceButton.Hovered.Options.UseForeColor = True
        TabPane1.AppearanceButton.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        TabPane1.AppearanceButton.Normal.ForeColor = Color.Silver
        TabPane1.AppearanceButton.Normal.Options.UseFont = True
        TabPane1.AppearanceButton.Normal.Options.UseForeColor = True
        TabPane1.AppearanceButton.Pressed.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        TabPane1.AppearanceButton.Pressed.ForeColor = Color.Navy
        TabPane1.AppearanceButton.Pressed.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Options.UseForeColor = True
        TabPane1.Controls.Add(TabDetailStock)
        TabPane1.Controls.Add(TabSummaryStock)
        TabPane1.Controls.Add(TabPenjualan)
        TabPane1.Location = New Point(12, 12)
        TabPane1.Margin = New Padding(2)
        TabPane1.Name = "TabPane1"
        TabPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {TabPenjualan, TabDetailStock, TabSummaryStock})
        TabPane1.RegularSize = New Size(1151, 457)
        TabPane1.SelectedPage = TabPenjualan
        TabPane1.Size = New Size(1151, 457)
        TabPane1.TabAlignment = DevExpress.XtraEditors.Alignment.Center
        TabPane1.TabIndex = 0
        TabPane1.Text = "TabPane1"
        ' 
        ' TabDetailStock
        ' 
        TabDetailStock.Caption = "Detail Stock"
        TabDetailStock.Controls.Add(_gdDetailStock)
        TabDetailStock.ImageOptions.Image = CType(resources.GetObject("TabDetailStock.ImageOptions.Image"), Image)
        TabDetailStock.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabDetailStock.Margin = New Padding(2)
        TabDetailStock.Name = "TabDetailStock"
        TabDetailStock.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabDetailStock.Size = New Size(1151, 414)
        ' 
        ' _gdDetailStock
        ' 
        _gdDetailStock._prop01User = Nothing
        _gdDetailStock._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdDetailStock._prop04Date = New Date(0L)
        _gdDetailStock._prop05String = Nothing
        _gdDetailStock._prop06String = Nothing
        _gdDetailStock._prop07String = Nothing
        _gdDetailStock._prop11objSpinEdit = Nothing
        _gdDetailStock._prop12objSpinEdit = Nothing
        _gdDetailStock.Dock = DockStyle.Fill
        _gdDetailStock.Location = New Point(0, 0)
        _gdDetailStock.Margin = New Padding(1)
        _gdDetailStock.Name = "_gdDetailStock"
        _gdDetailStock.Size = New Size(1151, 414)
        _gdDetailStock.TabIndex = 0
        ' 
        ' TabSummaryStock
        ' 
        TabSummaryStock.Caption = "Summary Stock"
        TabSummaryStock.Controls.Add(_pvSummaryStock)
        TabSummaryStock.ImageOptions.Image = CType(resources.GetObject("TabSummaryStock.ImageOptions.Image"), Image)
        TabSummaryStock.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabSummaryStock.Margin = New Padding(2)
        TabSummaryStock.Name = "TabSummaryStock"
        TabSummaryStock.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabSummaryStock.Size = New Size(1138, 465)
        ' 
        ' _pvSummaryStock
        ' 
        _pvSummaryStock._prop01User = Nothing
        _pvSummaryStock._prop02TargetPivot = SKK02OBJECTS.ucWSPivot._pbEnumTargetPivot._rptWS01PosterSaldoCurrent
        _pvSummaryStock.Dock = DockStyle.Fill
        _pvSummaryStock.Location = New Point(0, 0)
        _pvSummaryStock.Margin = New Padding(1)
        _pvSummaryStock.Name = "_pvSummaryStock"
        _pvSummaryStock.Size = New Size(1138, 465)
        _pvSummaryStock.TabIndex = 0
        ' 
        ' TabPenjualan
        ' 
        TabPenjualan.Caption = "Penjualan"
        TabPenjualan.Controls.Add(_gdPenjualan)
        TabPenjualan.ImageOptions.Image = CType(resources.GetObject("TabPenjualan.ImageOptions.Image"), Image)
        TabPenjualan.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabPenjualan.Margin = New Padding(2)
        TabPenjualan.Name = "TabPenjualan"
        TabPenjualan.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabPenjualan.Size = New Size(1151, 414)
        ' 
        ' _gdPenjualan
        ' 
        _gdPenjualan._prop01User = Nothing
        _gdPenjualan._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdPenjualan._prop04Date = New Date(0L)
        _gdPenjualan._prop05String = Nothing
        _gdPenjualan._prop06String = Nothing
        _gdPenjualan._prop07String = Nothing
        _gdPenjualan._prop11objSpinEdit = Nothing
        _gdPenjualan._prop12objSpinEdit = Nothing
        _gdPenjualan.Dock = DockStyle.Fill
        _gdPenjualan.Location = New Point(0, 0)
        _gdPenjualan.Margin = New Padding(1)
        _gdPenjualan.Name = "_gdPenjualan"
        _gdPenjualan.Size = New Size(1151, 414)
        _gdPenjualan.TabIndex = 0
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(1175, 481)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = TabPane1
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(1155, 461)
        LayoutControlItem1.TextSize = New Size(0, 0)
        LayoutControlItem1.TextVisible = False
        ' 
        ' BarManager1
        ' 
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar1})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnuBar1TargetPenjualan, mnuBar11SalesSelling, mnuBar12Consignment, mnuBar05Save, mnuBar03SKU, mnuBar02TglPenjualan, mnuBar04Kepada, mnuBar13Exhibition, BarEditItem1, mnuBar06TOP})
        BarManager1.MaxItemId = 14
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {rsmnuBar11SalesSelling, rsmnuBar12Consignment, RepositoryItemTextEdit1, rsmnuBar02TglPenjualan, rsmnuBar04Kepada, rsmnuBar13Exhibition, RepositoryItemTextEdit2, rsmnuBar06TOP})
        ' 
        ' Bar1
        ' 
        Bar1.BarItemHorzIndent = 10
        Bar1.BarName = "Tools"
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnuBar1TargetPenjualan), New DevExpress.XtraBars.LinkPersistInfo(mnuBar02TglPenjualan), New DevExpress.XtraBars.LinkPersistInfo(mnuBar04Kepada), New DevExpress.XtraBars.LinkPersistInfo(mnuBar06TOP), New DevExpress.XtraBars.LinkPersistInfo(mnuBar03SKU), New DevExpress.XtraBars.LinkPersistInfo(mnuBar05Save)})
        Bar1.Text = "Tools"
        ' 
        ' mnuBar1TargetPenjualan
        ' 
        mnuBar1TargetPenjualan.Caption = "Target Penjualan"
        mnuBar1TargetPenjualan.Id = 1
        mnuBar1TargetPenjualan.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar1TargetPenjualan.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar1TargetPenjualan.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar1TargetPenjualan.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar1TargetPenjualan.ItemAppearance.Normal.Options.UseFont = True
        mnuBar1TargetPenjualan.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar1TargetPenjualan.ItemAppearance.Pressed.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        mnuBar1TargetPenjualan.ItemAppearance.Pressed.ForeColor = Color.Navy
        mnuBar1TargetPenjualan.ItemAppearance.Pressed.Options.UseFont = True
        mnuBar1TargetPenjualan.ItemAppearance.Pressed.Options.UseForeColor = True
        mnuBar1TargetPenjualan.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnuBar11SalesSelling), New DevExpress.XtraBars.LinkPersistInfo(mnuBar12Consignment), New DevExpress.XtraBars.LinkPersistInfo(mnuBar13Exhibition)})
        mnuBar1TargetPenjualan.Name = "mnuBar1TargetPenjualan"
        mnuBar1TargetPenjualan.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnuBar11SalesSelling
        ' 
        mnuBar11SalesSelling.Caption = "Sales Selling  "
        mnuBar11SalesSelling.Edit = rsmnuBar11SalesSelling
        mnuBar11SalesSelling.EditWidth = 250
        mnuBar11SalesSelling.Id = 2
        mnuBar11SalesSelling.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar11SalesSelling.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar11SalesSelling.ItemAppearance.Hovered.Font = New Font("Nirmala UI", 9F, FontStyle.Bold Or FontStyle.Italic)
        mnuBar11SalesSelling.ItemAppearance.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        mnuBar11SalesSelling.ItemAppearance.Hovered.Options.UseFont = True
        mnuBar11SalesSelling.ItemAppearance.Hovered.Options.UseForeColor = True
        mnuBar11SalesSelling.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar11SalesSelling.ItemAppearance.Normal.ForeColor = Color.DarkGreen
        mnuBar11SalesSelling.ItemAppearance.Normal.Options.UseFont = True
        mnuBar11SalesSelling.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar11SalesSelling.Name = "mnuBar11SalesSelling"
        mnuBar11SalesSelling.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsmnuBar11SalesSelling
        ' 
        rsmnuBar11SalesSelling.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar11SalesSelling.Appearance.Options.UseFont = True
        rsmnuBar11SalesSelling.AppearanceDropDown.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar11SalesSelling.AppearanceDropDown.Options.UseFont = True
        rsmnuBar11SalesSelling.AppearanceFocused.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar11SalesSelling.AppearanceFocused.Options.UseFont = True
        rsmnuBar11SalesSelling.AutoHeight = False
        rsmnuBar11SalesSelling.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar11SalesSelling.Name = "rsmnuBar11SalesSelling"
        rsmnuBar11SalesSelling.NullText = ""
        rsmnuBar11SalesSelling.PopupView = RepositoryItemSearchLookUpEdit1View
        ' 
        ' RepositoryItemSearchLookUpEdit1View
        ' 
        RepositoryItemSearchLookUpEdit1View.Appearance.Row.Font = New Font("Courier New", 9F, FontStyle.Bold)
        RepositoryItemSearchLookUpEdit1View.Appearance.Row.Options.UseFont = True
        RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {_colf06String, _colf07String})
        RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        ' 
        ' _colf06String
        ' 
        _colf06String.Caption = "Code"
        _colf06String.Name = "_colf06String"
        _colf06String.Visible = True
        _colf06String.VisibleIndex = 0
        ' 
        ' _colf07String
        ' 
        _colf07String.Caption = "Sales"
        _colf07String.Name = "_colf07String"
        _colf07String.Visible = True
        _colf07String.VisibleIndex = 1
        ' 
        ' mnuBar12Consignment
        ' 
        mnuBar12Consignment.Caption = "Consignment"
        mnuBar12Consignment.Edit = rsmnuBar12Consignment
        mnuBar12Consignment.Id = 3
        mnuBar12Consignment.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar12Consignment.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar12Consignment.ItemAppearance.Hovered.Font = New Font("Nirmala UI", 9F, FontStyle.Bold Or FontStyle.Italic)
        mnuBar12Consignment.ItemAppearance.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        mnuBar12Consignment.ItemAppearance.Hovered.Options.UseFont = True
        mnuBar12Consignment.ItemAppearance.Hovered.Options.UseForeColor = True
        mnuBar12Consignment.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar12Consignment.ItemAppearance.Normal.ForeColor = Color.DarkGreen
        mnuBar12Consignment.ItemAppearance.Normal.Options.UseFont = True
        mnuBar12Consignment.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar12Consignment.Name = "mnuBar12Consignment"
        ' 
        ' rsmnuBar12Consignment
        ' 
        rsmnuBar12Consignment.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar12Consignment.Appearance.Options.UseFont = True
        rsmnuBar12Consignment.AppearanceDropDown.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar12Consignment.AppearanceDropDown.Options.UseFont = True
        rsmnuBar12Consignment.AppearanceFocused.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar12Consignment.AppearanceFocused.Options.UseFont = True
        rsmnuBar12Consignment.AutoHeight = False
        rsmnuBar12Consignment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar12Consignment.Name = "rsmnuBar12Consignment"
        rsmnuBar12Consignment.NullText = ""
        rsmnuBar12Consignment.PopupView = RepositoryItemSearchLookUpEdit2View
        ' 
        ' RepositoryItemSearchLookUpEdit2View
        ' 
        RepositoryItemSearchLookUpEdit2View.Appearance.Row.Font = New Font("Courier New", 9F, FontStyle.Bold)
        RepositoryItemSearchLookUpEdit2View.Appearance.Row.Options.UseFont = True
        RepositoryItemSearchLookUpEdit2View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {_colf06String1, _colf07String1})
        RepositoryItemSearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        RepositoryItemSearchLookUpEdit2View.Name = "RepositoryItemSearchLookUpEdit2View"
        RepositoryItemSearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        RepositoryItemSearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        ' 
        ' _colf06String1
        ' 
        _colf06String1.Caption = "Code"
        _colf06String1.Name = "_colf06String1"
        _colf06String1.Visible = True
        _colf06String1.VisibleIndex = 0
        ' 
        ' _colf07String1
        ' 
        _colf07String1.Caption = "Customer"
        _colf07String1.Name = "_colf07String1"
        _colf07String1.Visible = True
        _colf07String1.VisibleIndex = 1
        ' 
        ' mnuBar13Exhibition
        ' 
        mnuBar13Exhibition.Caption = "Exhibition       "
        mnuBar13Exhibition.Edit = rsmnuBar13Exhibition
        mnuBar13Exhibition.Id = 10
        mnuBar13Exhibition.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar13Exhibition.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar13Exhibition.ItemAppearance.Hovered.Font = New Font("Nirmala UI", 9F, FontStyle.Bold Or FontStyle.Italic)
        mnuBar13Exhibition.ItemAppearance.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        mnuBar13Exhibition.ItemAppearance.Hovered.Options.UseFont = True
        mnuBar13Exhibition.ItemAppearance.Hovered.Options.UseForeColor = True
        mnuBar13Exhibition.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar13Exhibition.ItemAppearance.Normal.ForeColor = Color.DarkGreen
        mnuBar13Exhibition.ItemAppearance.Normal.Options.UseFont = True
        mnuBar13Exhibition.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar13Exhibition.Name = "mnuBar13Exhibition"
        ' 
        ' rsmnuBar13Exhibition
        ' 
        rsmnuBar13Exhibition.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar13Exhibition.Appearance.Options.UseFont = True
        rsmnuBar13Exhibition.AppearanceDropDown.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar13Exhibition.AppearanceDropDown.Options.UseFont = True
        rsmnuBar13Exhibition.AppearanceFocused.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar13Exhibition.AppearanceFocused.Options.UseFont = True
        rsmnuBar13Exhibition.AutoHeight = False
        rsmnuBar13Exhibition.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar13Exhibition.Name = "rsmnuBar13Exhibition"
        rsmnuBar13Exhibition.NullText = ""
        rsmnuBar13Exhibition.PopupView = GridView2
        ' 
        ' GridView2
        ' 
        GridView2.Appearance.ColumnFilterButton.Font = New Font("Courier New", 9F, FontStyle.Bold)
        GridView2.Appearance.ColumnFilterButton.Options.UseFont = True
        GridView2.Appearance.Row.Font = New Font("Courier New", 8F, FontStyle.Bold)
        GridView2.Appearance.Row.Options.UseFont = True
        GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {_colf05StringExh, _colf06StringExh})
        GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView2.Name = "GridView2"
        GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView2.OptionsView.ShowGroupPanel = False
        ' 
        ' _colf05StringExh
        ' 
        _colf05StringExh.Caption = "Code"
        _colf05StringExh.Name = "_colf05StringExh"
        _colf05StringExh.Visible = True
        _colf05StringExh.VisibleIndex = 0
        ' 
        ' _colf06StringExh
        ' 
        _colf06StringExh.Caption = "Exhibition"
        _colf06StringExh.Name = "_colf06StringExh"
        _colf06StringExh.Visible = True
        _colf06StringExh.VisibleIndex = 1
        ' 
        ' mnuBar02TglPenjualan
        ' 
        mnuBar02TglPenjualan.Caption = "Tgl. Penjualan"
        mnuBar02TglPenjualan.Edit = rsmnuBar02TglPenjualan
        mnuBar02TglPenjualan.EditWidth = 125
        mnuBar02TglPenjualan.Id = 8
        mnuBar02TglPenjualan.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar02TglPenjualan.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar02TglPenjualan.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar02TglPenjualan.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar02TglPenjualan.ItemAppearance.Normal.Options.UseFont = True
        mnuBar02TglPenjualan.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar02TglPenjualan.Name = "mnuBar02TglPenjualan"
        mnuBar02TglPenjualan.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsmnuBar02TglPenjualan
        ' 
        rsmnuBar02TglPenjualan.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar02TglPenjualan.Appearance.Options.UseFont = True
        rsmnuBar02TglPenjualan.AppearanceDropDown.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar02TglPenjualan.AppearanceDropDown.Options.UseFont = True
        rsmnuBar02TglPenjualan.AppearanceFocused.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar02TglPenjualan.AppearanceFocused.Options.UseFont = True
        rsmnuBar02TglPenjualan.AutoHeight = False
        rsmnuBar02TglPenjualan.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar02TglPenjualan.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar02TglPenjualan.Name = "rsmnuBar02TglPenjualan"
        rsmnuBar02TglPenjualan.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        ' 
        ' mnuBar04Kepada
        ' 
        mnuBar04Kepada.Caption = "Kepada Yth. "
        mnuBar04Kepada.Edit = rsmnuBar04Kepada
        mnuBar04Kepada.EditWidth = 250
        mnuBar04Kepada.Id = 9
        mnuBar04Kepada.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar04Kepada.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar04Kepada.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar04Kepada.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar04Kepada.ItemAppearance.Normal.Options.UseFont = True
        mnuBar04Kepada.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar04Kepada.Name = "mnuBar04Kepada"
        mnuBar04Kepada.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsmnuBar04Kepada
        ' 
        rsmnuBar04Kepada.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar04Kepada.Appearance.Options.UseFont = True
        rsmnuBar04Kepada.AppearanceDropDown.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar04Kepada.AppearanceDropDown.Options.UseFont = True
        rsmnuBar04Kepada.AppearanceFocused.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar04Kepada.AppearanceFocused.Options.UseFont = True
        rsmnuBar04Kepada.AutoHeight = False
        rsmnuBar04Kepada.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar04Kepada.Name = "rsmnuBar04Kepada"
        rsmnuBar04Kepada.NullText = ""
        rsmnuBar04Kepada.PopupView = GridView1
        ' 
        ' GridView1
        ' 
        GridView1.Appearance.Row.Font = New Font("Courier New", 9F, FontStyle.Bold)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {_colk02StringCust, _colk03StringCust})
        GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView1.Name = "GridView1"
        GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' _colk02StringCust
        ' 
        _colk02StringCust.Caption = "Code"
        _colk02StringCust.Name = "_colk02StringCust"
        _colk02StringCust.Visible = True
        _colk02StringCust.VisibleIndex = 0
        ' 
        ' _colk03StringCust
        ' 
        _colk03StringCust.Caption = "Customer"
        _colk03StringCust.Name = "_colk03StringCust"
        _colk03StringCust.Visible = True
        _colk03StringCust.VisibleIndex = 1
        ' 
        ' mnuBar06TOP
        ' 
        mnuBar06TOP.Caption = "TOP"
        mnuBar06TOP.Edit = rsmnuBar06TOP
        mnuBar06TOP.EditWidth = 100
        mnuBar06TOP.Id = 12
        mnuBar06TOP.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar06TOP.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar06TOP.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar06TOP.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar06TOP.ItemAppearance.Normal.Options.UseFont = True
        mnuBar06TOP.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar06TOP.Name = "mnuBar06TOP"
        mnuBar06TOP.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsmnuBar06TOP
        ' 
        rsmnuBar06TOP.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar06TOP.Appearance.Options.UseFont = True
        rsmnuBar06TOP.AppearanceDropDown.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar06TOP.AppearanceDropDown.Options.UseFont = True
        rsmnuBar06TOP.AppearanceFocused.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsmnuBar06TOP.AppearanceFocused.Options.UseFont = True
        rsmnuBar06TOP.AutoHeight = False
        rsmnuBar06TOP.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar06TOP.Name = "rsmnuBar06TOP"
        rsmnuBar06TOP.NullText = ""
        rsmnuBar06TOP.PopupView = GridView3
        ' 
        ' GridView3
        ' 
        GridView3.Appearance.Row.Font = New Font("Courier New", 9F, FontStyle.Bold)
        GridView3.Appearance.Row.Options.UseFont = True
        GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {_colk13StringTOP, _colk14StringTOP})
        GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView3.Name = "GridView3"
        GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView3.OptionsView.ShowGroupPanel = False
        ' 
        ' _colk13StringTOP
        ' 
        _colk13StringTOP.Caption = "Code"
        _colk13StringTOP.Name = "_colk13StringTOP"
        _colk13StringTOP.Visible = True
        _colk13StringTOP.VisibleIndex = 0
        ' 
        ' _colk14StringTOP
        ' 
        _colk14StringTOP.Caption = "TOP"
        _colk14StringTOP.Name = "_colk14StringTOP"
        _colk14StringTOP.Visible = True
        _colk14StringTOP.VisibleIndex = 1
        ' 
        ' mnuBar03SKU
        ' 
        mnuBar03SKU.Caption = "SKU Scanning"
        mnuBar03SKU.Id = 6
        mnuBar03SKU.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar03SKU.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar03SKU.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar03SKU.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar03SKU.ItemAppearance.Normal.Options.UseFont = True
        mnuBar03SKU.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar03SKU.Name = "mnuBar03SKU"
        mnuBar03SKU.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnuBar05Save
        ' 
        mnuBar05Save.Caption = "Save"
        mnuBar05Save.Id = 5
        mnuBar05Save.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar05Save.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar05Save.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnuBar05Save.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar05Save.ItemAppearance.Normal.Options.UseFont = True
        mnuBar05Save.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar05Save.Name = "mnuBar05Save"
        mnuBar05Save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Margin = New Padding(2)
        barDockControlTop.Size = New Size(1175, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 505)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Margin = New Padding(2)
        barDockControlBottom.Size = New Size(1175, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Margin = New Padding(2)
        barDockControlLeft.Size = New Size(0, 481)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(1175, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Margin = New Padding(2)
        barDockControlRight.Size = New Size(0, 481)
        ' 
        ' BarEditItem1
        ' 
        BarEditItem1.Caption = "BarEditItem1"
        BarEditItem1.Edit = RepositoryItemTextEdit2
        BarEditItem1.Id = 11
        BarEditItem1.Name = "BarEditItem1"
        ' 
        ' RepositoryItemTextEdit2
        ' 
        RepositoryItemTextEdit2.AutoHeight = False
        RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        ' 
        ' RepositoryItemTextEdit1
        ' 
        RepositoryItemTextEdit1.AutoHeight = False
        RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        ' 
        ' ucWS24IJ01SALE
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Margin = New Padding(2)
        Name = "ucWS24IJ01SALE"
        Size = New Size(1175, 505)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        TabDetailStock.ResumeLayout(False)
        TabSummaryStock.ResumeLayout(False)
        TabPenjualan.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar11SalesSelling, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemSearchLookUpEdit1View, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar12Consignment, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemSearchLookUpEdit2View, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar13Exhibition, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView2, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar02TglPenjualan.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar02TglPenjualan, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar04Kepada, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar06TOP, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView3, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemTextEdit2, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemTextEdit1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabDetailStock As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabSummaryStock As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _gdDetailStock As SKK02OBJECTS.ucWSGrid
    Friend WithEvents _pvSummaryStock As SKK02OBJECTS.ucWSPivot
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuBar1TargetPenjualan As DevExpress.XtraBars.BarSubItem
    Friend WithEvents mnuBar11SalesSelling As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar11SalesSelling As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents mnuBar12Consignment As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar12Consignment As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents mnuBar05Save As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBar03SKU As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBar02TglPenjualan As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar02TglPenjualan As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents mnuBar04Kepada As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar04Kepada As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _colf06String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _colf07String As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _colf06String1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _colf07String1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _colk02StringCust As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _colk03StringCust As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabPenjualan As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _gdPenjualan As SKK02OBJECTS.ucWSGrid
    Friend WithEvents mnuBar13Exhibition As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar13Exhibition As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _colf05StringExh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _colf06StringExh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents mnuBar06TOP As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar06TOP As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _colk13StringTOP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _colk14StringTOP As DevExpress.XtraGrid.Columns.GridColumn

End Class
