<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS25DX01STOCKCHECK
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS25DX01STOCKCHECK))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _gdStockCheck = New SKK02OBJECTS.ucWSGrid()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnuBar01ProductCode = New DevExpress.XtraBars.BarEditItem()
        rsmnuBar01ProductCode = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        mnuBar02Refresh = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar01ProductCode, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemSearchLookUpEdit1View, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_gdStockCheck)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 24)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(942, 441)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _gdStockCheck
        ' 
        _gdStockCheck._prop01User = Nothing
        _gdStockCheck._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdStockCheck._prop04Date = New Date(0L)
        _gdStockCheck._prop05String = Nothing
        _gdStockCheck._prop06String = Nothing
        _gdStockCheck._prop07String = Nothing
        _gdStockCheck._prop11objSpinEdit = Nothing
        _gdStockCheck._prop12objSpinEdit = Nothing
        _gdStockCheck.Location = New Point(12, 12)
        _gdStockCheck.Margin = New Padding(2, 2, 2, 2)
        _gdStockCheck.Name = "_gdStockCheck"
        _gdStockCheck.Size = New Size(918, 417)
        _gdStockCheck.TabIndex = 4
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
        LayoutControlItem1.Control = _gdStockCheck
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
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnuBar02Refresh, mnuBar01ProductCode})
        BarManager1.MainMenu = Bar1
        BarManager1.MaxItemId = 10
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {rsmnuBar01ProductCode})
        ' 
        ' Bar1
        ' 
        Bar1.BarItemHorzIndent = 20
        Bar1.BarName = "Tools"
        Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnuBar01ProductCode, True), New DevExpress.XtraBars.LinkPersistInfo(mnuBar02Refresh, True)})
        Bar1.OptionsBar.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.Text = "Tools"
        ' 
        ' mnuBar01ProductCode
        ' 
        mnuBar01ProductCode.Caption = "Product Code"
        mnuBar01ProductCode.CaptionToEditorIndent = 10
        mnuBar01ProductCode.Edit = rsmnuBar01ProductCode
        mnuBar01ProductCode.Id = 9
        mnuBar01ProductCode.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar01ProductCode.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar01ProductCode.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar01ProductCode.ItemAppearance.Normal.Options.UseFont = True
        mnuBar01ProductCode.Name = "mnuBar01ProductCode"
        mnuBar01ProductCode.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        mnuBar01ProductCode.Size = New Size(270, 0)
        ' 
        ' rsmnuBar01ProductCode
        ' 
        rsmnuBar01ProductCode.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rsmnuBar01ProductCode.Appearance.Options.UseFont = True
        rsmnuBar01ProductCode.AppearanceDropDown.Font = New Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rsmnuBar01ProductCode.AppearanceDropDown.Options.UseFont = True
        rsmnuBar01ProductCode.AppearanceFocused.Font = New Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rsmnuBar01ProductCode.AppearanceFocused.Options.UseFont = True
        rsmnuBar01ProductCode.AutoHeight = False
        rsmnuBar01ProductCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar01ProductCode.Name = "rsmnuBar01ProductCode"
        rsmnuBar01ProductCode.PopupView = RepositoryItemSearchLookUpEdit1View
        ' 
        ' RepositoryItemSearchLookUpEdit1View
        ' 
        RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        ' 
        ' mnuBar02Refresh
        ' 
        mnuBar02Refresh.AllowRightClickInMenu = False
        mnuBar02Refresh.Caption = "Refresh"
        mnuBar02Refresh.Id = 6
        mnuBar02Refresh.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar02Refresh.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar02Refresh.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar02Refresh.ItemAppearance.Normal.Options.UseFont = True
        mnuBar02Refresh.Name = "mnuBar02Refresh"
        mnuBar02Refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipItem1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipItem1.Text = "<i>Refresh the data.</i>"
        SuperToolTip1.Items.Add(ToolTipItem1)
        mnuBar02Refresh.SuperTip = SuperToolTip1
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
        ' ucWS25DX01STOCKCHECK
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Name = "ucWS25DX01STOCKCHECK"
        Size = New Size(942, 465)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar01ProductCode, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemSearchLookUpEdit1View, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents _gdStockCheck As SKK02OBJECTS.ucWSGrid
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents mnuBar01ProductCode As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsmnuBar01ProductCode As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView

End Class
