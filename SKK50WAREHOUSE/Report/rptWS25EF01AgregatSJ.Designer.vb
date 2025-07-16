<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptWS25EF01AgregatSJ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptWS25EF01AgregatSJ))
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnuBar01DateDari = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnuBar02DateKe = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnuBar03Display = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        DataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
        _gdAgregatSJ = New SKK02OBJECTS.ucWSGrid()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit1.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit2, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemDateEdit2.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataLayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        DataLayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BarManager1
        ' 
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar1})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnuBar01DateDari, mnuBar02DateKe, mnuBar03Display, BarButtonItem1})
        BarManager1.MaxItemId = 4
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryItemDateEdit1, RepositoryItemDateEdit2})
        ' 
        ' Bar1
        ' 
        Bar1.BarName = "Tools"
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBar01DateDari, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBar02DateKe, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, mnuBar03Display, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Bar1.Text = "Tools"
        ' 
        ' mnuBar01DateDari
        ' 
        mnuBar01DateDari.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default
        mnuBar01DateDari.Caption = "Dari"
        mnuBar01DateDari.Edit = RepositoryItemDateEdit1
        mnuBar01DateDari.EditWidth = 100
        mnuBar01DateDari.Id = 0
        mnuBar01DateDari.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar01DateDari.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar01DateDari.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar01DateDari.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar01DateDari.Name = "mnuBar01DateDari"
        ' 
        ' RepositoryItemDateEdit1
        ' 
        RepositoryItemDateEdit1.AutoHeight = False
        RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        ' 
        ' mnuBar02DateKe
        ' 
        mnuBar02DateKe.Caption = "Ke"
        mnuBar02DateKe.Edit = RepositoryItemDateEdit2
        mnuBar02DateKe.EditWidth = 100
        mnuBar02DateKe.Id = 1
        mnuBar02DateKe.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar02DateKe.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar02DateKe.Name = "mnuBar02DateKe"
        ' 
        ' RepositoryItemDateEdit2
        ' 
        RepositoryItemDateEdit2.AutoHeight = False
        RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        ' 
        ' mnuBar03Display
        ' 
        mnuBar03Display.Caption = "View Data"
        mnuBar03Display.Id = 2
        mnuBar03Display.ImageOptions.SvgImage = CType(resources.GetObject("mnuBar03Display.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBar03Display.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBar03Display.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBar03Display.Name = "mnuBar03Display"
        mnuBar03Display.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Size = New Size(987, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 537)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Size = New Size(987, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Size = New Size(0, 513)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(987, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Size = New Size(0, 513)
        ' 
        ' BarButtonItem1
        ' 
        BarButtonItem1.Caption = "BarButtonItem1"
        BarButtonItem1.Id = 3
        BarButtonItem1.Name = "BarButtonItem1"
        ' 
        ' DataLayoutControl1
        ' 
        DataLayoutControl1.Controls.Add(_gdAgregatSJ)
        DataLayoutControl1.Dock = DockStyle.Fill
        DataLayoutControl1.Location = New Point(0, 24)
        DataLayoutControl1.Name = "DataLayoutControl1"
        DataLayoutControl1.Root = Root
        DataLayoutControl1.Size = New Size(987, 513)
        DataLayoutControl1.TabIndex = 4
        DataLayoutControl1.Text = "DataLayoutControl1"
        ' 
        ' _gdAgregatSJ
        ' 
        _gdAgregatSJ._prop01User = Nothing
        _gdAgregatSJ._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdAgregatSJ._prop04Date = New Date(0L)
        _gdAgregatSJ._prop05String = Nothing
        _gdAgregatSJ._prop06String = Nothing
        _gdAgregatSJ._prop07String = Nothing
        _gdAgregatSJ._prop11objSpinEdit = Nothing
        _gdAgregatSJ._prop12objSpinEdit = Nothing
        _gdAgregatSJ.Location = New Point(12, 12)
        _gdAgregatSJ.Margin = New Padding(2)
        _gdAgregatSJ.Name = "_gdAgregatSJ"
        _gdAgregatSJ.Size = New Size(963, 489)
        _gdAgregatSJ.TabIndex = 4
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(987, 513)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = _gdAgregatSJ
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(967, 493)
        LayoutControlItem1.TextVisible = False
        ' 
        ' rptWS25EF01AgregatSJ
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DataLayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Name = "rptWS25EF01AgregatSJ"
        Size = New Size(987, 537)
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit1.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit2.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemDateEdit2, ComponentModel.ISupportInitialize).EndInit()
        CType(DataLayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        DataLayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuBar01DateDari As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents mnuBar02DateKe As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents DataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents _gdAgregatSJ As SKK02OBJECTS.ucWSGrid
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents mnuBar03Display As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem

End Class
