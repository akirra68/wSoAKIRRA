<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class rptWS25FX01CURRENTSTOCK
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptWS25FX01CURRENTSTOCK))
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        tabTable = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdCurrentStock = New SKK02OBJECTS.ucWSGridParentChild()
        tabPivot = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnuBar01Target = New DevExpress.XtraBars.BarEditItem()
        _rpsTarget = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        barGap1 = New DevExpress.XtraBars.BarStaticItem()
        barGap2 = New DevExpress.XtraBars.BarStaticItem()
        mnuBar04Stock = New DevExpress.XtraBars.BarEditItem()
        _rpsStock = New DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit()
        barGap3 = New DevExpress.XtraBars.BarStaticItem()
        barGap4 = New DevExpress.XtraBars.BarStaticItem()
        mnuBar02Refresh = New DevExpress.XtraBars.BarButtonItem()
        barGap5 = New DevExpress.XtraBars.BarStaticItem()
        barGap6 = New DevExpress.XtraBars.BarStaticItem()
        mnuBar03PrintBarcode = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        tabTable.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_rpsTarget, ComponentModel.ISupportInitialize).BeginInit()
        CType(_rpsStock, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(TabPane1)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 24)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(942, 441)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' TabPane1
        ' 
        TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True
        TabPane1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 10F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        TabPane1.AppearanceButton.Hovered.ForeColor = Color.DarkGoldenrod
        TabPane1.AppearanceButton.Hovered.Options.UseFont = True
        TabPane1.AppearanceButton.Hovered.Options.UseForeColor = True
        TabPane1.AppearanceButton.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TabPane1.AppearanceButton.Normal.ForeColor = Color.Silver
        TabPane1.AppearanceButton.Normal.Options.UseFont = True
        TabPane1.AppearanceButton.Normal.Options.UseForeColor = True
        TabPane1.AppearanceButton.Pressed.Font = New Font("Nirmala UI Semilight", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TabPane1.AppearanceButton.Pressed.ForeColor = Color.Navy
        TabPane1.AppearanceButton.Pressed.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Options.UseForeColor = True
        TabPane1.Controls.Add(tabTable)
        TabPane1.Controls.Add(tabPivot)
        TabPane1.Location = New Point(12, 12)
        TabPane1.Name = "TabPane1"
        TabPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {tabTable, tabPivot})
        TabPane1.RegularSize = New Size(918, 417)
        TabPane1.SelectedPage = tabTable
        TabPane1.Size = New Size(918, 417)
        TabPane1.TabIndex = 4
        TabPane1.Text = "TabPane1"
        TabPane1.TransitionAnimationProperties.FrameCount = 500
        TabPane1.TransitionAnimationProperties.FrameInterval = 5000
        ' 
        ' tabTable
        ' 
        tabTable.BackgroundPadding = New Padding(16, 16, 17, 16)
        tabTable.Caption = "Table"
        tabTable.Controls.Add(_gdCurrentStock)
        tabTable.ImageOptions.SvgImage = CType(resources.GetObject("tabTable.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        tabTable.ImageOptions.SvgImageSize = New Size(20, 20)
        tabTable.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabTable.Name = "tabTable"
        tabTable.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabTable.Size = New Size(918, 384)
        ToolTipItem1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem1.Appearance.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolTipItem1.Appearance.ForeColor = Color.Navy
        ToolTipItem1.Appearance.Options.UseFont = True
        ToolTipItem1.Appearance.Options.UseForeColor = True
        ToolTipItem1.Text = "<i>Show by ""ORDER""</i>"
        SuperToolTip1.Items.Add(ToolTipItem1)
        tabTable.SuperTip = SuperToolTip1
        ' 
        ' _gdCurrentStock
        ' 
        _gdCurrentStock._prop01Date = New Date(0L)
        _gdCurrentStock._prop01objUser = Nothing
        _gdCurrentStock._prop01User = Nothing
        _gdCurrentStock._prop02Date = New Date(0L)
        _gdCurrentStock._prop02TargetGridParentChild = SKK02OBJECTS.ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB
        _gdCurrentStock._prop03String = Nothing
        _gdCurrentStock._prop04String = Nothing
        _gdCurrentStock.Dock = DockStyle.Fill
        _gdCurrentStock.Location = New Point(0, 0)
        _gdCurrentStock.Margin = New Padding(2)
        _gdCurrentStock.Name = "_gdCurrentStock"
        _gdCurrentStock.Size = New Size(918, 384)
        _gdCurrentStock.TabIndex = 0
        ' 
        ' tabPivot
        ' 
        tabPivot.Caption = "Pivot"
        tabPivot.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tabPivot.ImageOptions.SvgImage = CType(resources.GetObject("tabPivot.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        tabPivot.ImageOptions.SvgImageSize = New Size(20, 20)
        tabPivot.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabPivot.Name = "tabPivot"
        tabPivot.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabPivot.Size = New Size(918, 417)
        ToolTipItem2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem2.Appearance.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolTipItem2.Appearance.ForeColor = Color.Navy
        ToolTipItem2.Appearance.Options.UseFont = True
        ToolTipItem2.Appearance.Options.UseForeColor = True
        ToolTipItem2.Text = "<i>Show by ""PRODUCT CODE""</i>"
        SuperToolTip2.Items.Add(ToolTipItem2)
        tabPivot.SuperTip = SuperToolTip2
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(942, 441)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = TabPane1
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(922, 421)
        LayoutControlItem1.TextVisible = False
        ' 
        ' BarManager1
        ' 
        BarManager1.AllowCustomization = False
        BarManager1.AllowQuickCustomization = False
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar1})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnuBar02Refresh, barGap1, barGap2, barGap3, barGap6, mnuBar01Target, BarStaticItem1, mnuBar03PrintBarcode, mnuBar04Stock, barGap4, barGap5})
        BarManager1.MainMenu = Bar1
        BarManager1.MaxItemId = 24
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {_rpsTarget, _rpsStock})
        ' 
        ' Bar1
        ' 
        Bar1.BarItemHorzIndent = 20
        Bar1.BarName = "Tools"
        Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, mnuBar01Target, "", False, True, True, 152), New DevExpress.XtraBars.LinkPersistInfo(barGap1), New DevExpress.XtraBars.LinkPersistInfo(barGap2, True), New DevExpress.XtraBars.LinkPersistInfo(mnuBar04Stock), New DevExpress.XtraBars.LinkPersistInfo(barGap3), New DevExpress.XtraBars.LinkPersistInfo(barGap4, True), New DevExpress.XtraBars.LinkPersistInfo(mnuBar02Refresh), New DevExpress.XtraBars.LinkPersistInfo(barGap5), New DevExpress.XtraBars.LinkPersistInfo(barGap6, True), New DevExpress.XtraBars.LinkPersistInfo(mnuBar03PrintBarcode)})
        Bar1.OptionsBar.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.Text = "Tools"
        ' 
        ' mnuBar01Target
        ' 
        mnuBar01Target.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        mnuBar01Target.AllowRightClickInMenu = False
        mnuBar01Target.Caption = "Target:"
        mnuBar01Target.Edit = _rpsTarget
        mnuBar01Target.EditWidth = 150
        mnuBar01Target.Id = 18
        mnuBar01Target.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar01Target.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar01Target.ItemAppearance.Normal.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mnuBar01Target.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar01Target.ItemAppearance.Normal.Options.UseFont = True
        mnuBar01Target.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar01Target.Name = "mnuBar01Target"
        mnuBar01Target.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem3.Appearance.Font = New Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        ToolTipItem3.Appearance.ForeColor = Color.Navy
        ToolTipItem3.Appearance.Options.UseFont = True
        ToolTipItem3.Appearance.Options.UseForeColor = True
        ToolTipItem3.Text = "Choose the Target."
        SuperToolTip3.Items.Add(ToolTipItem3)
        mnuBar01Target.SuperTip = SuperToolTip3
        ' 
        ' _rpsTarget
        ' 
        _rpsTarget.Appearance.Font = New Font("Sitka Text", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        _rpsTarget.Appearance.ForeColor = Color.DarkSlateGray
        _rpsTarget.Appearance.Options.UseFont = True
        _rpsTarget.Appearance.Options.UseForeColor = True
        _rpsTarget.AppearanceDropDown.Font = New Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        _rpsTarget.AppearanceDropDown.ForeColor = Color.Navy
        _rpsTarget.AppearanceDropDown.Options.UseFont = True
        _rpsTarget.AppearanceDropDown.Options.UseForeColor = True
        _rpsTarget.AppearanceItemHighlight.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        _rpsTarget.AppearanceItemHighlight.Options.UseFont = True
        _rpsTarget.AppearanceItemSelected.Font = New Font("Sitka Small", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        _rpsTarget.AppearanceItemSelected.ForeColor = Color.DarkSlateGray
        _rpsTarget.AppearanceItemSelected.Options.UseFont = True
        _rpsTarget.AppearanceItemSelected.Options.UseForeColor = True
        _rpsTarget.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _rpsTarget.Items.AddRange(New Object() {"SKU (Stock Keeping Unit)", "Product Code"})
        _rpsTarget.Name = "_rpsTarget"
        _rpsTarget.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        ' 
        ' barGap1
        ' 
        barGap1.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap1.Id = 9
        barGap1.Name = "barGap1"
        ' 
        ' barGap2
        ' 
        barGap2.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap2.Id = 10
        barGap2.Name = "barGap2"
        ' 
        ' mnuBar04Stock
        ' 
        mnuBar04Stock.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        mnuBar04Stock.AllowRightClickInMenu = False
        mnuBar04Stock.Caption = "Stock:"
        mnuBar04Stock.Edit = _rpsStock
        mnuBar04Stock.EditWidth = 170
        mnuBar04Stock.Id = 21
        mnuBar04Stock.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar04Stock.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar04Stock.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar04Stock.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar04Stock.ItemAppearance.Normal.Options.UseFont = True
        mnuBar04Stock.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar04Stock.Name = "mnuBar04Stock"
        mnuBar04Stock.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem4.Appearance.Font = New Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        ToolTipItem4.Appearance.ForeColor = Color.Navy
        ToolTipItem4.Appearance.Options.UseFont = True
        ToolTipItem4.Appearance.Options.UseForeColor = True
        ToolTipItem4.Text = "Choose the Stock."
        SuperToolTip4.Items.Add(ToolTipItem4)
        mnuBar04Stock.SuperTip = SuperToolTip4
        ' 
        ' _rpsStock
        ' 
        _rpsStock.AllowMultiSelect = True
        _rpsStock.Appearance.Font = New Font("Sitka Text", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        _rpsStock.Appearance.ForeColor = Color.DarkSlateGray
        _rpsStock.Appearance.Options.UseFont = True
        _rpsStock.Appearance.Options.UseForeColor = True
        _rpsStock.AppearanceDropDown.Font = New Font("Sitka Text", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        _rpsStock.AppearanceDropDown.ForeColor = Color.Navy
        _rpsStock.AppearanceDropDown.Options.UseFont = True
        _rpsStock.AppearanceDropDown.Options.UseForeColor = True
        _rpsStock.AppearanceFocused.Font = New Font("Sitka Small", 9.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        _rpsStock.AppearanceFocused.ForeColor = Color.DarkSlateGray
        _rpsStock.AppearanceFocused.Options.UseFont = True
        _rpsStock.AppearanceFocused.Options.UseForeColor = True
        _rpsStock.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _rpsStock.Name = "_rpsStock"
        ' 
        ' barGap3
        ' 
        barGap3.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap3.Id = 11
        barGap3.Name = "barGap3"
        ' 
        ' barGap4
        ' 
        barGap4.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap4.Id = 22
        barGap4.Name = "barGap4"
        ' 
        ' mnuBar02Refresh
        ' 
        mnuBar02Refresh.AllowRightClickInMenu = False
        mnuBar02Refresh.Caption = "Refresh"
        mnuBar02Refresh.Id = 6
        mnuBar02Refresh.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar02Refresh.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar02Refresh.ItemAppearance.Normal.Font = New Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mnuBar02Refresh.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar02Refresh.ItemAppearance.Normal.Options.UseFont = True
        mnuBar02Refresh.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar02Refresh.Name = "mnuBar02Refresh"
        mnuBar02Refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem5.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem5.Appearance.Font = New Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        ToolTipItem5.Appearance.ForeColor = Color.Navy
        ToolTipItem5.Appearance.Options.UseFont = True
        ToolTipItem5.Appearance.Options.UseForeColor = True
        ToolTipItem5.Text = "Refresh the Data."
        SuperToolTip5.Items.Add(ToolTipItem5)
        mnuBar02Refresh.SuperTip = SuperToolTip5
        ' 
        ' barGap5
        ' 
        barGap5.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap5.Id = 23
        barGap5.Name = "barGap5"
        ' 
        ' barGap6
        ' 
        barGap6.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap6.Id = 14
        barGap6.Name = "barGap6"
        ' 
        ' mnuBar03PrintBarcode
        ' 
        mnuBar03PrintBarcode.Caption = "Print Barcode"
        mnuBar03PrintBarcode.Id = 20
        mnuBar03PrintBarcode.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar03PrintBarcode.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar03PrintBarcode.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar03PrintBarcode.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar03PrintBarcode.ItemAppearance.Normal.Options.UseFont = True
        mnuBar03PrintBarcode.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar03PrintBarcode.Name = "mnuBar03PrintBarcode"
        mnuBar03PrintBarcode.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem6.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem6.Appearance.Font = New Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        ToolTipItem6.Appearance.ForeColor = Color.Navy
        ToolTipItem6.Appearance.Options.UseFont = True
        ToolTipItem6.Appearance.Options.UseForeColor = True
        ToolTipItem6.Text = "Print Barcode Label"
        SuperToolTip6.Items.Add(ToolTipItem6)
        mnuBar03PrintBarcode.SuperTip = SuperToolTip6
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Size = New Size(942, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 465)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Size = New Size(942, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Size = New Size(0, 441)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(942, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Size = New Size(0, 441)
        ' 
        ' BarStaticItem1
        ' 
        BarStaticItem1.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        BarStaticItem1.Id = 19
        BarStaticItem1.Name = "BarStaticItem1"
        ' 
        ' rptWS25FX01CURRENTSTOCK
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Name = "rptWS25FX01CURRENTSTOCK"
        Size = New Size(942, 465)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        tabTable.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(_rpsTarget, ComponentModel.ISupportInitialize).EndInit()
        CType(_rpsStock, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents mnuBar02Refresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barGap1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap2 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap3 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap6 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents tabTable As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _gdCurrentStock As SKK02OBJECTS.ucWSGridParentChild
    Friend WithEvents tabPivot As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents mnuBar01Target As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rpsTargetStock As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents mnuBar03PrintBarcode As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents _rpsStock As DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit
    Friend WithEvents mnuBar04Stock As DevExpress.XtraBars.BarEditItem
    Friend WithEvents barGap4 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap5 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents _rpsTarget As DevExpress.XtraEditors.Repository.RepositoryItemComboBox

End Class
