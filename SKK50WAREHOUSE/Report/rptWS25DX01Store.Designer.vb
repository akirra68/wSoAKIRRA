<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptWS25DX01Store
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptWS25DX01Store))
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar3 = New DevExpress.XtraBars.Bar()
        mnuBar01Display = New DevExpress.XtraBars.BarButtonItem()
        mnuBar02Edit = New DevExpress.XtraBars.BarButtonItem()
        mnuBar03Add = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        rsmnuBar01TargetTracking = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        rsmnuBar02WSSKU = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        _colk02StringSKU = New DevExpress.XtraGrid.Columns.GridColumn()
        RepositoryItemPopupContainerEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        rsmnuBar03DateDari = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        rsmnuBar04DateKe = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        DataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
        _gdStore = New SKK02OBJECTS.ucWSGrid()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LAY_gdStore = New DevExpress.XtraLayout.LayoutControlItem()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar01TargetTracking, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar02WSSKU, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView3, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemPopupContainerEdit1, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar03DateDari, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar03DateDari.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar04DateKe, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsmnuBar04DateKe.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataLayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        DataLayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LAY_gdStore, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BarManager1
        ' 
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar3})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {BarButtonItem1, mnuBar01Display, mnuBar02Edit, mnuBar03Add})
        BarManager1.MaxItemId = 22
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {rsmnuBar01TargetTracking, rsmnuBar02WSSKU, RepositoryItemPopupContainerEdit1, rsmnuBar03DateDari, rsmnuBar04DateKe})
        ' 
        ' Bar3
        ' 
        Bar3.BarName = "Custom 2"
        Bar3.DockCol = 0
        Bar3.DockRow = 0
        Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBar01Display, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBar02Edit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBar03Add, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Bar3.Text = "Tools"
        ' 
        ' mnuBar01Display
        ' 
        mnuBar01Display.Caption = "Refresh Data"
        mnuBar01Display.Hint = "Refresh Data"
        mnuBar01Display.Id = 19
        mnuBar01Display.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar01Display.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar01Display.ItemAppearance.Normal.Font = New Font("Tahoma", 8.25F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        mnuBar01Display.ItemAppearance.Normal.FontStyleDelta = FontStyle.Italic
        mnuBar01Display.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar01Display.ItemAppearance.Normal.Options.UseFont = True
        mnuBar01Display.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar01Display.ItemInMenuAppearance.Normal.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBar01Display.ItemInMenuAppearance.Normal.Options.UseFont = True
        mnuBar01Display.Name = "mnuBar01Display"
        mnuBar01Display.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnuBar02Edit
        ' 
        mnuBar02Edit.Caption = "Edit"
        mnuBar02Edit.Id = 20
        mnuBar02Edit.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar02Edit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar02Edit.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar02Edit.ItemAppearance.Normal.Options.UseFont = True
        mnuBar02Edit.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar02Edit.Name = "mnuBar02Edit"
        mnuBar02Edit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnuBar03Add
        ' 
        mnuBar03Add.Caption = "Add"
        mnuBar03Add.Id = 21
        mnuBar03Add.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar03Add.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar03Add.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar03Add.ItemAppearance.Normal.Options.UseFont = True
        mnuBar03Add.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar03Add.Name = "mnuBar03Add"
        mnuBar03Add.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Size = New Size(912, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 404)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Size = New Size(912, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Size = New Size(0, 380)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(912, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Size = New Size(0, 380)
        ' 
        ' BarButtonItem1
        ' 
        BarButtonItem1.Caption = "WIDTH GRID CUY"
        BarButtonItem1.Id = 18
        BarButtonItem1.Name = "BarButtonItem1"
        ' 
        ' rsmnuBar01TargetTracking
        ' 
        rsmnuBar01TargetTracking.Appearance.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rsmnuBar01TargetTracking.Appearance.Options.UseFont = True
        rsmnuBar01TargetTracking.AutoHeight = False
        rsmnuBar01TargetTracking.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar01TargetTracking.DropDownRows = 10
        rsmnuBar01TargetTracking.Items.AddRange(New Object() {"Stock Keeping Unit", "Perintah Kirim Barang"})
        rsmnuBar01TargetTracking.Name = "rsmnuBar01TargetTracking"
        rsmnuBar01TargetTracking.NullText = "Please select a target"
        rsmnuBar01TargetTracking.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
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
        ' RepositoryItemPopupContainerEdit1
        ' 
        RepositoryItemPopupContainerEdit1.AutoHeight = False
        RepositoryItemPopupContainerEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemPopupContainerEdit1.Name = "RepositoryItemPopupContainerEdit1"
        ' 
        ' rsmnuBar03DateDari
        ' 
        rsmnuBar03DateDari.AutoHeight = False
        rsmnuBar03DateDari.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar03DateDari.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar03DateDari.Name = "rsmnuBar03DateDari"
        ' 
        ' rsmnuBar04DateKe
        ' 
        rsmnuBar04DateKe.AutoHeight = False
        rsmnuBar04DateKe.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar04DateKe.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsmnuBar04DateKe.Name = "rsmnuBar04DateKe"
        ' 
        ' DataLayoutControl1
        ' 
        DataLayoutControl1.Controls.Add(_gdStore)
        DataLayoutControl1.Dock = DockStyle.Fill
        DataLayoutControl1.Location = New Point(0, 24)
        DataLayoutControl1.Name = "DataLayoutControl1"
        DataLayoutControl1.Root = Root
        DataLayoutControl1.Size = New Size(912, 380)
        DataLayoutControl1.TabIndex = 5
        DataLayoutControl1.Text = "DataLayoutControl1"
        ' 
        ' _gdStore
        ' 
        _gdStore._prop01User = Nothing
        _gdStore._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSRptStore
        _gdStore._prop04Date = New Date(0L)
        _gdStore._prop05String = Nothing
        _gdStore._prop06String = Nothing
        _gdStore._prop07String = Nothing
        _gdStore._prop11objSpinEdit = Nothing
        _gdStore._prop12objSpinEdit = Nothing
        _gdStore.Location = New Point(12, 12)
        _gdStore.Margin = New Padding(2)
        _gdStore.Name = "_gdStore"
        _gdStore.Size = New Size(888, 356)
        _gdStore.TabIndex = 4
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LAY_gdStore})
        Root.Name = "Root"
        Root.Size = New Size(912, 380)
        Root.TextVisible = False
        ' 
        ' LAY_gdStore
        ' 
        LAY_gdStore.Control = _gdStore
        LAY_gdStore.Location = New Point(0, 0)
        LAY_gdStore.Name = "LAY_gdStore"
        LAY_gdStore.Size = New Size(892, 360)
        LAY_gdStore.TextVisible = False
        ' 
        ' rptWS25DX01Store
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DataLayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Name = "rptWS25DX01Store"
        Size = New Size(912, 404)
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar01TargetTracking, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar02WSSKU, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView3, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemPopupContainerEdit1, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar03DateDari.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar03DateDari, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar04DateKe.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(rsmnuBar04DateKe, ComponentModel.ISupportInitialize).EndInit()
        CType(DataLayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        DataLayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LAY_gdStore, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents rsmnuBar01TargetTracking As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents rsmnuBar02WSSKU As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _colk02StringSKU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rsmnuBar03DateDari As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents rsmnuBar04DateKe As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents DataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents RepositoryItemPopupContainerEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents mnuBar01Display As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBar02Edit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBar03Add As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _gdStore As SKK02OBJECTS.ucWSGrid
    Friend WithEvents LAY_gdStore As DevExpress.XtraLayout.LayoutControlItem

End Class
