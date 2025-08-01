<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS25DQ01ORDERMANAGEMENT
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS25DQ01ORDERMANAGEMENT))
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip7 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        tabOrder = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdOrderMgmt = New SKK02OBJECTS.ucWSGridParentChild()
        tabProductCode = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdOrderMgmtPcode = New SKK02OBJECTS.ucWSGridParentChild()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        barGap1 = New DevExpress.XtraBars.BarStaticItem()
        mnuBar03Refresh = New DevExpress.XtraBars.BarButtonItem()
        barGap2 = New DevExpress.XtraBars.BarStaticItem()
        barGap3 = New DevExpress.XtraBars.BarStaticItem()
        mnuBar02Radio = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemRadioGroup1 = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        mnuBar04Reason = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        barGap4 = New DevExpress.XtraBars.BarStaticItem()
        barGap5 = New DevExpress.XtraBars.BarStaticItem()
        mnuBar01Save = New DevExpress.XtraBars.BarButtonItem()
        barGap6 = New DevExpress.XtraBars.BarStaticItem()
        barGap7 = New DevExpress.XtraBars.BarStaticItem()
        mnuBar05ChildOrder = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        tabOrder.SuspendLayout()
        tabProductCode.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemRadioGroup1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemMemoExEdit1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(TabPane1)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 28)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(942, 437)
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
        TabPane1.Controls.Add(tabOrder)
        TabPane1.Controls.Add(tabProductCode)
        TabPane1.Location = New Point(12, 12)
        TabPane1.Name = "TabPane1"
        TabPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {tabOrder, tabProductCode})
        TabPane1.RegularSize = New Size(918, 413)
        TabPane1.SelectedPage = tabOrder
        TabPane1.Size = New Size(918, 413)
        TabPane1.TabIndex = 4
        TabPane1.Text = "TabPane1"
        TabPane1.TransitionAnimationProperties.FrameCount = 500
        TabPane1.TransitionAnimationProperties.FrameInterval = 5000
        ' 
        ' tabOrder
        ' 
        tabOrder.BackgroundPadding = New Padding(16, 16, 17, 16)
        tabOrder.Caption = " Order "
        tabOrder.Controls.Add(_gdOrderMgmt)
        tabOrder.ImageOptions.SvgImage = CType(resources.GetObject("tabOrder.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        tabOrder.ImageOptions.SvgImageSize = New Size(20, 20)
        tabOrder.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabOrder.Name = "tabOrder"
        tabOrder.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabOrder.Size = New Size(918, 380)
        ToolTipItem1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem1.Appearance.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolTipItem1.Appearance.ForeColor = Color.Navy
        ToolTipItem1.Appearance.Options.UseFont = True
        ToolTipItem1.Appearance.Options.UseForeColor = True
        ToolTipItem1.Text = "<i>Show by ""ORDER""</i>"
        SuperToolTip1.Items.Add(ToolTipItem1)
        tabOrder.SuperTip = SuperToolTip1
        ' 
        ' _gdOrderMgmt
        ' 
        _gdOrderMgmt._prop01Date = New Date(0L)
        _gdOrderMgmt._prop01objUser = Nothing
        _gdOrderMgmt._prop01User = Nothing
        _gdOrderMgmt._prop02Date = New Date(0L)
        _gdOrderMgmt._prop02TargetGridParentChild = SKK02OBJECTS.ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB
        _gdOrderMgmt._prop03String = Nothing
        _gdOrderMgmt._prop04String = Nothing
        _gdOrderMgmt.Dock = DockStyle.Fill
        _gdOrderMgmt.Location = New Point(0, 0)
        _gdOrderMgmt.Margin = New Padding(2)
        _gdOrderMgmt.Name = "_gdOrderMgmt"
        _gdOrderMgmt.Size = New Size(918, 380)
        _gdOrderMgmt.TabIndex = 0
        ' 
        ' tabProductCode
        ' 
        tabProductCode.Caption = " Product Code "
        tabProductCode.Controls.Add(_gdOrderMgmtPcode)
        tabProductCode.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        tabProductCode.ImageOptions.SvgImage = CType(resources.GetObject("tabProductCode.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        tabProductCode.ImageOptions.SvgImageSize = New Size(20, 20)
        tabProductCode.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabProductCode.Name = "tabProductCode"
        tabProductCode.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        tabProductCode.Size = New Size(918, 380)
        ToolTipItem2.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem2.Appearance.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolTipItem2.Appearance.ForeColor = Color.Navy
        ToolTipItem2.Appearance.Options.UseFont = True
        ToolTipItem2.Appearance.Options.UseForeColor = True
        ToolTipItem2.Text = "<i>Show by ""PRODUCT CODE""</i>"
        SuperToolTip2.Items.Add(ToolTipItem2)
        tabProductCode.SuperTip = SuperToolTip2
        ' 
        ' _gdOrderMgmtPcode
        ' 
        _gdOrderMgmtPcode._prop01Date = New Date(0L)
        _gdOrderMgmtPcode._prop01objUser = Nothing
        _gdOrderMgmtPcode._prop01User = Nothing
        _gdOrderMgmtPcode._prop02Date = New Date(0L)
        _gdOrderMgmtPcode._prop02TargetGridParentChild = SKK02OBJECTS.ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB
        _gdOrderMgmtPcode._prop03String = Nothing
        _gdOrderMgmtPcode._prop04String = Nothing
        _gdOrderMgmtPcode.Dock = DockStyle.Fill
        _gdOrderMgmtPcode.Location = New Point(0, 0)
        _gdOrderMgmtPcode.Margin = New Padding(2)
        _gdOrderMgmtPcode.Name = "_gdOrderMgmtPcode"
        _gdOrderMgmtPcode.Size = New Size(918, 380)
        _gdOrderMgmtPcode.TabIndex = 0
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(942, 437)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = TabPane1
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(922, 417)
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
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnuBar01Save, mnuBar02Radio, mnuBar03Refresh, mnuBar04Reason, barGap1, barGap2, barGap3, barGap4, barGap5, barGap6, barGap7, mnuBar05ChildOrder})
        BarManager1.MainMenu = Bar1
        BarManager1.MaxItemId = 18
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryItemRadioGroup1, RepositoryItemMemoExEdit1})
        ' 
        ' Bar1
        ' 
        Bar1.BarItemHorzIndent = 20
        Bar1.BarName = "Tools"
        Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(barGap1), New DevExpress.XtraBars.LinkPersistInfo(mnuBar03Refresh), New DevExpress.XtraBars.LinkPersistInfo(barGap2), New DevExpress.XtraBars.LinkPersistInfo(barGap3, True), New DevExpress.XtraBars.LinkPersistInfo(mnuBar02Radio), New DevExpress.XtraBars.LinkPersistInfo(mnuBar04Reason), New DevExpress.XtraBars.LinkPersistInfo(barGap4), New DevExpress.XtraBars.LinkPersistInfo(barGap5, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, mnuBar01Save, "", False, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.Standard, "", ""), New DevExpress.XtraBars.LinkPersistInfo(barGap6), New DevExpress.XtraBars.LinkPersistInfo(barGap7, True), New DevExpress.XtraBars.LinkPersistInfo(mnuBar05ChildOrder)})
        Bar1.OptionsBar.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.Text = "Tools"
        ' 
        ' barGap1
        ' 
        barGap1.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap1.Id = 9
        barGap1.Name = "barGap1"
        ' 
        ' mnuBar03Refresh
        ' 
        mnuBar03Refresh.AllowRightClickInMenu = False
        mnuBar03Refresh.Caption = "Refresh"
        mnuBar03Refresh.Id = 6
        mnuBar03Refresh.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar03Refresh.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar03Refresh.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar03Refresh.ItemAppearance.Normal.Options.UseFont = True
        mnuBar03Refresh.Name = "mnuBar03Refresh"
        mnuBar03Refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem3.Text = "<i>Refresh the data.</i>"
        SuperToolTip3.Items.Add(ToolTipItem3)
        mnuBar03Refresh.SuperTip = SuperToolTip3
        ' 
        ' barGap2
        ' 
        barGap2.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap2.Id = 10
        barGap2.Name = "barGap2"
        ' 
        ' barGap3
        ' 
        barGap3.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap3.Id = 11
        barGap3.Name = "barGap3"
        ' 
        ' mnuBar02Radio
        ' 
        mnuBar02Radio.AllowRightClickInMenu = False
        mnuBar02Radio.CaptionToEditorIndent = 2
        mnuBar02Radio.Edit = RepositoryItemRadioGroup1
        mnuBar02Radio.Id = 5
        mnuBar02Radio.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar02Radio.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar02Radio.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar02Radio.ItemAppearance.Normal.Options.UseFont = True
        mnuBar02Radio.ItemAppearance.Pressed.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar02Radio.ItemAppearance.Pressed.Options.UseFont = True
        mnuBar02Radio.Name = "mnuBar02Radio"
        mnuBar02Radio.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        mnuBar02Radio.Size = New Size(175, 0)
        ToolTipItem4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem4.Text = "<i>Click to Confirm or Cancel the Order.</i>"
        SuperToolTip4.Items.Add(ToolTipItem4)
        mnuBar02Radio.SuperTip = SuperToolTip4
        mnuBar02Radio.UseEditorPadding = False
        ' 
        ' RepositoryItemRadioGroup1
        ' 
        RepositoryItemRadioGroup1.Appearance.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RepositoryItemRadioGroup1.Appearance.Options.UseFont = True
        RepositoryItemRadioGroup1.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Confirm", True, Nothing, "Confirm"), New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Cancel", True, Nothing, "Cancel")})
        RepositoryItemRadioGroup1.Name = "RepositoryItemRadioGroup1"
        RepositoryItemRadioGroup1.Padding = New Padding(4, 0, 4, 0)
        ' 
        ' mnuBar04Reason
        ' 
        mnuBar04Reason.AllowRightClickInMenu = False
        mnuBar04Reason.Caption = "Cancellation Reasons"
        mnuBar04Reason.CaptionToEditorIndent = 5
        mnuBar04Reason.Edit = RepositoryItemMemoExEdit1
        mnuBar04Reason.EditWidth = 75
        mnuBar04Reason.Id = 7
        mnuBar04Reason.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar04Reason.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar04Reason.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar04Reason.ItemAppearance.Normal.Options.UseFont = True
        mnuBar04Reason.Name = "mnuBar04Reason"
        mnuBar04Reason.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem5.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem5.Text = "<i>Insert order cancellation reasons.</i>"
        SuperToolTip5.Items.Add(ToolTipItem5)
        mnuBar04Reason.SuperTip = SuperToolTip5
        ' 
        ' RepositoryItemMemoExEdit1
        ' 
        RepositoryItemMemoExEdit1.AutoHeight = False
        RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        ' 
        ' barGap4
        ' 
        barGap4.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap4.Id = 12
        barGap4.Name = "barGap4"
        ' 
        ' barGap5
        ' 
        barGap5.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap5.Id = 13
        barGap5.Name = "barGap5"
        ' 
        ' mnuBar01Save
        ' 
        mnuBar01Save.AllowRightClickInMenu = False
        mnuBar01Save.Caption = "Save"
        mnuBar01Save.Id = 3
        mnuBar01Save.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar01Save.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar01Save.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar01Save.ItemAppearance.Normal.Options.UseFont = True
        mnuBar01Save.Name = "mnuBar01Save"
        mnuBar01Save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipTitleItem1.Appearance.FontStyleDelta = FontStyle.Italic
        ToolTipTitleItem1.Appearance.Options.UseFont = True
        ToolTipTitleItem1.Text = "Save the data."
        SuperToolTip6.Items.Add(ToolTipTitleItem1)
        mnuBar01Save.SuperTip = SuperToolTip6
        ' 
        ' barGap6
        ' 
        barGap6.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap6.Id = 14
        barGap6.Name = "barGap6"
        ' 
        ' barGap7
        ' 
        barGap7.Caption = "‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ ‎ "
        barGap7.Id = 15
        barGap7.Name = "barGap7"
        ' 
        ' mnuBar05ChildOrder
        ' 
        mnuBar05ChildOrder.AllowRightClickInMenu = False
        mnuBar05ChildOrder.Caption = "Create Child Order"
        mnuBar05ChildOrder.Id = 17
        mnuBar05ChildOrder.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar05ChildOrder.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar05ChildOrder.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar05ChildOrder.ItemAppearance.Normal.Options.UseFont = True
        mnuBar05ChildOrder.Name = "mnuBar05ChildOrder"
        mnuBar05ChildOrder.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem6.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem6.Text = "<i>Create Child Order for Order that has OutstandingQty.</i>"
        SuperToolTip7.Items.Add(ToolTipItem6)
        mnuBar05ChildOrder.SuperTip = SuperToolTip7
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Size = New Size(942, 28)
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
        barDockControlLeft.Location = New Point(0, 28)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Size = New Size(0, 437)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(942, 28)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Size = New Size(0, 437)
        ' 
        ' ucWS25DQ01ORDERMANAGEMENT
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Name = "ucWS25DQ01ORDERMANAGEMENT"
        Size = New Size(942, 465)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        tabOrder.ResumeLayout(False)
        tabProductCode.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemRadioGroup1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemMemoExEdit1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents mnuBar01Save As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBar02Radio As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemRadioGroup1 As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents mnuBar03Refresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBar04Reason As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents barGap1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap2 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap4 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap3 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap5 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barGap6 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents tabOrder As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _gdOrderMgmt As SKK02OBJECTS.ucWSGridParentChild
    Friend WithEvents tabProductCode As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _gdOrderMgmtPcode As SKK02OBJECTS.ucWSGridParentChild
    Friend WithEvents barGap7 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents mnuBar05ChildOrder As DevExpress.XtraBars.BarButtonItem

End Class
