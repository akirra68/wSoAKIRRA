<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMD23JP01TRACKINGPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMD23JP01TRACKINGPO))
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _gdTrackingPO = New SKK02OBJECTS.ucWSGridParentChild()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnuBarDateDari = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnuBarDateKe = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnuBarDisplay = New DevExpress.XtraBars.BarButtonItem()
        mnuBarBtnClear = New DevExpress.XtraBars.BarButtonItem()
        BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit1.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit2, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit2.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemTextEdit1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_gdTrackingPO)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 24)
        LayoutControl1.Margin = New Padding(2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1159, 488)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _gdTrackingPO
        ' 
        _gdTrackingPO._prop01Date = New Date(0L)
        _gdTrackingPO._prop01objUser = Nothing
        _gdTrackingPO._prop01User = Nothing
        _gdTrackingPO._prop02Date = New Date(0L)
        _gdTrackingPO._prop02TargetGridParentChild = SKK02OBJECTS.ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB
        _gdTrackingPO._prop03String = Nothing
        _gdTrackingPO._prop04String = Nothing
        _gdTrackingPO.Location = New Point(12, 12)
        _gdTrackingPO.Margin = New Padding(2)
        _gdTrackingPO.Name = "_gdTrackingPO"
        _gdTrackingPO.Size = New Size(1135, 464)
        _gdTrackingPO.TabIndex = 4
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(1159, 488)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = _gdTrackingPO
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(1139, 468)
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
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnuBarDisplay, mnuBarDateDari, mnuBarDateKe, mnuBarBtnClear, BarButtonItem1})
        BarManager1.MaxItemId = 6
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryItemDateEdit1, RepositoryItemTextEdit1, RepositoryItemDateEdit2})
        ' 
        ' Bar1
        ' 
        Bar1.BarName = "Tools"
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnuBarDateDari), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBarDateKe, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBarDisplay, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBarBtnClear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Bar1.Text = "Tools"
        ' 
        ' mnuBarDateDari
        ' 
        mnuBarDateDari.Caption = "Dari"
        mnuBarDateDari.Edit = RepositoryItemDateEdit1
        mnuBarDateDari.EditWidth = 100
        mnuBarDateDari.Id = 1
        mnuBarDateDari.ImageOptions.SvgImage = CType(resources.GetObject("mnuBarDateDari.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBarDateDari.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBarDateDari.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBarDateDari.Name = "mnuBarDateDari"
        mnuBarDateDari.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' RepositoryItemDateEdit1
        ' 
        RepositoryItemDateEdit1.AutoHeight = False
        RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        ' 
        ' mnuBarDateKe
        ' 
        mnuBarDateKe.Caption = "Ke"
        mnuBarDateKe.Edit = RepositoryItemDateEdit2
        mnuBarDateKe.EditWidth = 100
        mnuBarDateKe.Id = 3
        mnuBarDateKe.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBarDateKe.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBarDateKe.Name = "mnuBarDateKe"
        ' 
        ' RepositoryItemDateEdit2
        ' 
        RepositoryItemDateEdit2.AutoHeight = False
        RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        ' 
        ' mnuBarDisplay
        ' 
        mnuBarDisplay.Caption = "Tracking PO"
        mnuBarDisplay.Id = 0
        mnuBarDisplay.ImageOptions.SvgImage = CType(resources.GetObject("mnuBarDisplay.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBarDisplay.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBarDisplay.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBarDisplay.ItemInMenuAppearance.Normal.ForeColor = Color.Navy
        mnuBarDisplay.ItemInMenuAppearance.Normal.Options.UseForeColor = True
        mnuBarDisplay.Name = "mnuBarDisplay"
        ' 
        ' mnuBarBtnClear
        ' 
        mnuBarBtnClear.Caption = "Clear"
        mnuBarBtnClear.Id = 4
        mnuBarBtnClear.ImageOptions.SvgImage = CType(resources.GetObject("mnuBarBtnClear.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBarBtnClear.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBarBtnClear.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBarBtnClear.Name = "mnuBarBtnClear"
        ' 
        ' BarButtonItem1
        ' 
        BarButtonItem1.Caption = "WIDTH GRID"
        BarButtonItem1.Id = 5
        BarButtonItem1.Name = "BarButtonItem1"
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Size = New Size(1159, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 512)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Size = New Size(1159, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Size = New Size(0, 488)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(1159, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Size = New Size(0, 488)
        ' 
        ' RepositoryItemTextEdit1
        ' 
        RepositoryItemTextEdit1.AutoHeight = False
        RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        ' 
        ' ucMD23JP01TRACKINGPO
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Margin = New Padding(2)
        Name = "ucMD23JP01TRACKINGPO"
        Size = New Size(1159, 512)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit1.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit2.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit2, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemTextEdit1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents mnuBarDisplay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBarDateDari As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuBarDateKe As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents mnuBarBtnClear As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _gdTrackingPO As SKK02OBJECTS.ucWSGridParentChild
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
End Class
