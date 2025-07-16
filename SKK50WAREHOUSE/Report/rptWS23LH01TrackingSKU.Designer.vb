<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptWS23LH01TrackingSKU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptWS23LH01TrackingSKU))
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _gdTrackingSKUPKB = New SKK02OBJECTS.ucWSGridParentChild()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnu01TargetTracking = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar01TargetTracking = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        mnu02WSSKUTracking = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar02WSSKU = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        _colk02StringSKU = New DevExpress.XtraGrid.Columns.GridColumn()
        mnu03Datedari = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar03DateDari = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnu03DateKe = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar04DateKe = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnu05Display = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        mnu03FilterData = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemPopupContainerEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        CtrlwsNasaMaster1 = New SKK02OBJECTS.ctrlWSNasaMaster()
        GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        _F03Customer = New SKK02OBJECTS.ctrlWSNasaMaster()
        GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CtrlwsNasaMaster2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CtrlwsNasaMaster1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Bar2 = New DevExpress.XtraBars.Bar()
        Bar3 = New DevExpress.XtraBars.Bar()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar01TargetTracking, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar02WSSKU, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView3, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar03DateDari, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar03DateDari.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar04DateKe, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar04DateKe.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemPopupContainerEdit1, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlwsNasaMaster1.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView6, ComponentModel.ISupportInitialize).BeginInit()
        CType(_F03Customer.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView5, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView4, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlwsNasaMaster2View, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlwsNasaMaster1View, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_gdTrackingSKUPKB)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 24)
        LayoutControl1.Margin = New Padding(2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1004, 391)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _gdTrackingSKUPKB
        ' 
        _gdTrackingSKUPKB._prop01Date = New Date(0L)
        _gdTrackingSKUPKB._prop01objUser = Nothing
        _gdTrackingSKUPKB._prop01User = Nothing
        _gdTrackingSKUPKB._prop02Date = New Date(0L)
        _gdTrackingSKUPKB._prop02TargetGridParentChild = SKK02OBJECTS.ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB
        _gdTrackingSKUPKB._prop03String = Nothing
        _gdTrackingSKUPKB._prop04String = Nothing
        _gdTrackingSKUPKB.Location = New Point(12, 12)
        _gdTrackingSKUPKB.Margin = New Padding(2)
        _gdTrackingSKUPKB.Name = "_gdTrackingSKUPKB"
        _gdTrackingSKUPKB.Size = New Size(980, 367)
        _gdTrackingSKUPKB.TabIndex = 4
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(1004, 391)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = _gdTrackingSKUPKB
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(984, 371)
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
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnu01TargetTracking, mnu02WSSKUTracking, mnu03FilterData, mnu03Datedari, mnu03DateKe, mnu05Display, BarButtonItem1})
        BarManager1.MaxItemId = 18
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {rsmnuBar01TargetTracking, rsmnuBar02WSSKU, RepositoryItemPopupContainerEdit1, rsmnuBar03DateDari, rsmnuBar04DateKe})
        ' 
        ' Bar1
        ' 
        Bar1.BarName = "Custom 2"
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnu01TargetTracking), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnu02WSSKUTracking, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnu03Datedari, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnu03DateKe, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnu05Display, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Bar1.Text = "Tools"
        ' 
        ' mnu01TargetTracking
        ' 
        mnu01TargetTracking.Caption = "Target Tracking"
        mnu01TargetTracking.Edit = rsmnuBar01TargetTracking
        mnu01TargetTracking.EditWidth = 180
        mnu01TargetTracking.Id = 5
        mnu01TargetTracking.ImageOptions.SvgImage = CType(resources.GetObject("mnu01TargetTracking.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnu01TargetTracking.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnu01TargetTracking.ItemAppearance.Normal.ForeColor = Color.Navy
        mnu01TargetTracking.ItemAppearance.Normal.Options.UseFont = True
        mnu01TargetTracking.ItemAppearance.Normal.Options.UseForeColor = True
        mnu01TargetTracking.ItemInMenuAppearance.Normal.BackColor = Color.Navy
        mnu01TargetTracking.ItemInMenuAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mnu01TargetTracking.ItemInMenuAppearance.Normal.Options.UseBackColor = True
        mnu01TargetTracking.ItemInMenuAppearance.Normal.Options.UseFont = True
        mnu01TargetTracking.Name = "mnu01TargetTracking"
        mnu01TargetTracking.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsmnuBar01TargetTracking
        ' 
        rsmnuBar01TargetTracking.Appearance.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rsmnuBar01TargetTracking.Appearance.Options.UseFont = True
        rsmnuBar01TargetTracking.AutoHeight = False
        rsmnuBar01TargetTracking.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar01TargetTracking.DropDownRows = 10
        rsmnuBar01TargetTracking.Items.AddRange(New Object() {"SKU", "ORDER"})
        rsmnuBar01TargetTracking.Name = "rsmnuBar01TargetTracking"
        rsmnuBar01TargetTracking.NullText = "Please select a target"
        rsmnuBar01TargetTracking.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        ' 
        ' mnu02WSSKUTracking
        ' 
        mnu02WSSKUTracking.AllowHtmlText = DevExpress.Utils.DefaultBoolean.False
        mnu02WSSKUTracking.Caption = "SKU"
        mnu02WSSKUTracking.Edit = rsmnuBar02WSSKU
        mnu02WSSKUTracking.EditWidth = 170
        mnu02WSSKUTracking.Id = 12
        mnu02WSSKUTracking.ImageOptions.SvgImage = CType(resources.GetObject("mnu02WSSKUTracking.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnu02WSSKUTracking.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnu02WSSKUTracking.ItemAppearance.Normal.ForeColor = Color.Navy
        mnu02WSSKUTracking.ItemAppearance.Normal.Options.UseFont = True
        mnu02WSSKUTracking.ItemAppearance.Normal.Options.UseForeColor = True
        mnu02WSSKUTracking.MinWidth = 100
        mnu02WSSKUTracking.Name = "mnu02WSSKUTracking"
        ' 
        ' rsmnuBar02WSSKU
        ' 
        rsmnuBar02WSSKU.AutoHeight = False
        rsmnuBar02WSSKU.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar02WSSKU.Name = "rsmnuBar02WSSKU"
        rsmnuBar02WSSKU.NullText = ""
        rsmnuBar02WSSKU.PopupView = GridView3
        ' 
        ' GridView3
        ' 
        GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {_colk02StringSKU})
        GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView3.Name = "GridView3"
        GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView3.OptionsView.ShowGroupPanel = False
        ' 
        ' _colk02StringSKU
        ' 
        _colk02StringSKU.Caption = "Code"
        _colk02StringSKU.Name = "_colk02StringSKU"
        _colk02StringSKU.Visible = True
        _colk02StringSKU.VisibleIndex = 0
        ' 
        ' mnu03Datedari
        ' 
        mnu03Datedari.Caption = "Dari"
        mnu03Datedari.Edit = rsmnuBar03DateDari
        mnu03Datedari.EditWidth = 100
        mnu03Datedari.Id = 14
        mnu03Datedari.ImageOptions.SvgImage = CType(resources.GetObject("mnu03Datedari.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnu03Datedari.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnu03Datedari.ItemAppearance.Normal.ForeColor = Color.Navy
        mnu03Datedari.ItemAppearance.Normal.Options.UseFont = True
        mnu03Datedari.ItemAppearance.Normal.Options.UseForeColor = True
        mnu03Datedari.Name = "mnu03Datedari"
        mnu03Datedari.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsmnuBar03DateDari
        ' 
        rsmnuBar03DateDari.AutoHeight = False
        rsmnuBar03DateDari.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar03DateDari.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar03DateDari.DisplayFormat.FormatString = "dd/MM/yyyy"
        rsmnuBar03DateDari.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        rsmnuBar03DateDari.EditFormat.FormatString = "dd/MM/yyyy"
        rsmnuBar03DateDari.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        rsmnuBar03DateDari.MaskSettings.Set("mask", "dd/MM/yyyy")
        rsmnuBar03DateDari.Name = "rsmnuBar03DateDari"
        rsmnuBar03DateDari.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        rsmnuBar03DateDari.UseMaskAsDisplayFormat = True
        ' 
        ' mnu03DateKe
        ' 
        mnu03DateKe.Caption = "Ke"
        mnu03DateKe.Edit = rsmnuBar04DateKe
        mnu03DateKe.EditWidth = 100
        mnu03DateKe.Id = 15
        mnu03DateKe.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnu03DateKe.ItemAppearance.Normal.ForeColor = Color.Navy
        mnu03DateKe.ItemAppearance.Normal.Options.UseFont = True
        mnu03DateKe.ItemAppearance.Normal.Options.UseForeColor = True
        mnu03DateKe.Name = "mnu03DateKe"
        mnu03DateKe.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsmnuBar04DateKe
        ' 
        rsmnuBar04DateKe.AutoHeight = False
        rsmnuBar04DateKe.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar04DateKe.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar04DateKe.DisplayFormat.FormatString = "dd/MM/yyyy"
        rsmnuBar04DateKe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        rsmnuBar04DateKe.EditFormat.FormatString = "dd/MM/yyyy"
        rsmnuBar04DateKe.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        rsmnuBar04DateKe.MaskSettings.Set("mask", "dd/MM/yyyy")
        rsmnuBar04DateKe.Name = "rsmnuBar04DateKe"
        rsmnuBar04DateKe.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        rsmnuBar04DateKe.UseMaskAsDisplayFormat = True
        ' 
        ' mnu05Display
        ' 
        mnu05Display.Caption = "Refresh"
        mnu05Display.Id = 16
        mnu05Display.ImageOptions.SvgImage = CType(resources.GetObject("mnu05Display.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnu05Display.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnu05Display.ItemAppearance.Normal.ForeColor = Color.Navy
        mnu05Display.ItemAppearance.Normal.Options.UseFont = True
        mnu05Display.ItemAppearance.Normal.Options.UseForeColor = True
        mnu05Display.Name = "mnu05Display"
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Size = New Size(1004, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 415)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Size = New Size(1004, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Size = New Size(0, 391)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(1004, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Size = New Size(0, 391)
        ' 
        ' mnu03FilterData
        ' 
        mnu03FilterData.Caption = "Filter"
        mnu03FilterData.Edit = RepositoryItemPopupContainerEdit1
        mnu03FilterData.EditWidth = 100
        mnu03FilterData.Id = 13
        mnu03FilterData.ImageOptions.SvgImage = CType(resources.GetObject("mnu03FilterData.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnu03FilterData.ItemAppearance.Normal.ForeColor = Color.Navy
        mnu03FilterData.ItemAppearance.Normal.Options.UseForeColor = True
        mnu03FilterData.Name = "mnu03FilterData"
        mnu03FilterData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' RepositoryItemPopupContainerEdit1
        ' 
        RepositoryItemPopupContainerEdit1.AutoHeight = False
        RepositoryItemPopupContainerEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemPopupContainerEdit1.Name = "RepositoryItemPopupContainerEdit1"
        ' 
        ' BarButtonItem1
        ' 
        BarButtonItem1.Caption = "Grid CUY"
        BarButtonItem1.Id = 17
        BarButtonItem1.Name = "BarButtonItem1"
        ' 
        ' CtrlwsNasaMaster1
        ' 
        CtrlwsNasaMaster1._prop02WSDaftarField = Nothing
        CtrlwsNasaMaster1._prop03WSFieldYgDiFilter = Nothing
        CtrlwsNasaMaster1._prop04WSValueKodeMasterYgDiFilter = Nothing
        CtrlwsNasaMaster1._prop05WSFieldValueMember = Nothing
        CtrlwsNasaMaster1._prop06WSFieldDisplayMember = Nothing
        CtrlwsNasaMaster1._prop07WSKeyKolomFilterUntSelect = Nothing
        CtrlwsNasaMaster1.Location = New Point(79, 60)
        CtrlwsNasaMaster1.MenuManager = BarManager1
        CtrlwsNasaMaster1.Name = "CtrlwsNasaMaster1"
        CtrlwsNasaMaster1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        CtrlwsNasaMaster1.Properties.NullText = ""
        CtrlwsNasaMaster1.Properties.PopupView = GridView6
        CtrlwsNasaMaster1.Size = New Size(204, 20)
        CtrlwsNasaMaster1.TabIndex = 7
        ' 
        ' GridView6
        ' 
        GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView6.Name = "GridView6"
        GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView6.OptionsView.ShowGroupPanel = False
        ' 
        ' _F03Customer
        ' 
        _F03Customer._prop02WSDaftarField = Nothing
        _F03Customer._prop03WSFieldYgDiFilter = Nothing
        _F03Customer._prop04WSValueKodeMasterYgDiFilter = Nothing
        _F03Customer._prop05WSFieldValueMember = Nothing
        _F03Customer._prop06WSFieldDisplayMember = Nothing
        _F03Customer._prop07WSKeyKolomFilterUntSelect = Nothing
        _F03Customer.Location = New Point(79, 60)
        _F03Customer.MenuManager = BarManager1
        _F03Customer.Name = "_F03Customer"
        _F03Customer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _F03Customer.Properties.NullText = ""
        _F03Customer.Properties.PopupView = GridView5
        _F03Customer.Size = New Size(204, 20)
        _F03Customer.TabIndex = 7
        ' 
        ' GridView5
        ' 
        GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView5.Name = "GridView5"
        GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView5.OptionsView.ShowGroupPanel = False
        ' 
        ' GridView4
        ' 
        GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView4.Name = "GridView4"
        GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView4.OptionsView.ShowGroupPanel = False
        ' 
        ' CtrlwsNasaMaster2View
        ' 
        CtrlwsNasaMaster2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlwsNasaMaster2View.Name = "CtrlwsNasaMaster2View"
        CtrlwsNasaMaster2View.OptionsNavigation.UseTabKey = False
        CtrlwsNasaMaster2View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlwsNasaMaster2View.OptionsView.ShowGroupPanel = False
        ' 
        ' GridView2
        ' 
        GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView2.Name = "GridView2"
        GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView2.OptionsView.ShowGroupPanel = False
        ' 
        ' CtrlwsNasaMaster1View
        ' 
        CtrlwsNasaMaster1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlwsNasaMaster1View.Name = "CtrlwsNasaMaster1View"
        CtrlwsNasaMaster1View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlwsNasaMaster1View.OptionsView.ShowGroupPanel = False
        ' 
        ' GridView1
        ' 
        GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView1.Name = "GridView1"
        GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' Bar2
        ' 
        Bar2.BarName = "Custom 3"
        Bar2.DockCol = 0
        Bar2.DockRow = 1
        Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar2.Text = "Custom 3"
        ' 
        ' Bar3
        ' 
        Bar3.BarName = "Custom 3"
        Bar3.DockCol = 0
        Bar3.DockRow = 1
        Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar3.Text = "Custom 3"
        ' 
        ' rptWS23LH01TrackingSKU
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Margin = New Padding(2)
        Name = "rptWS23LH01TrackingSKU"
        Size = New Size(1004, 415)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar01TargetTracking, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar02WSSKU, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView3, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar03DateDari.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar03DateDari, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar04DateKe.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar04DateKe, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemPopupContainerEdit1, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlwsNasaMaster1.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView6, ComponentModel.ISupportInitialize).EndInit()
        CType(_F03Customer.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView5, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView4, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlwsNasaMaster2View, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView2, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlwsNasaMaster1View, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents mnu01TargetTracking As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar01TargetTracking As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents mnu02WSSKUTracking As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar02WSSKU As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents mnu03FilterData As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemPopupContainerEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents _colk02StringSKU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CtrlwsNasaMaster1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CtrlwsNasaMaster2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _F03Customer As SKK02OBJECTS.ctrlWSNasaMaster
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CtrlwsNasaMaster1 As SKK02OBJECTS.ctrlWSNasaMaster
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _gdTrackingSKUPKB As SKK02OBJECTS.ucWSGridParentChild
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents mnu03Datedari As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar03DateDari As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents mnu03DateKe As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar04DateKe As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents mnu05Display As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
End Class
