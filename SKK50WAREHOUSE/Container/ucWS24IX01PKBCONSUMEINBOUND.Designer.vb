<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS24IX01PKBCONSUMEINBOUND
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS24IX01PKBCONSUMEINBOUND))
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _gdInboundConsumePKB = New SKK02OBJECTS.ucWSGrid()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar2 = New DevExpress.XtraBars.Bar()
        mnubar01Save = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        RepositoryItemSearchControl1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchControl()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemSearchControl1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_gdInboundConsumePKB)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(50, 0)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1259, 514)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _gdInboundConsumePKB
        ' 
        _gdInboundConsumePKB._prop01User = Nothing
        _gdInboundConsumePKB._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdInboundConsumePKB._prop04Date = New Date(0L)
        _gdInboundConsumePKB._prop05String = Nothing
        _gdInboundConsumePKB._prop06String = Nothing
        _gdInboundConsumePKB._prop07String = Nothing
        _gdInboundConsumePKB._prop11objSpinEdit = Nothing
        _gdInboundConsumePKB._prop12objSpinEdit = Nothing
        _gdInboundConsumePKB.Location = New Point(12, 12)
        _gdInboundConsumePKB.Name = "_gdInboundConsumePKB"
        _gdInboundConsumePKB.Size = New Size(1235, 490)
        _gdInboundConsumePKB.TabIndex = 4
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(1259, 514)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = _gdInboundConsumePKB
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(1239, 494)
        LayoutControlItem1.TextSize = New Size(0, 0)
        LayoutControlItem1.TextVisible = False
        ' 
        ' BarManager1
        ' 
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar2})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnubar01Save})
        BarManager1.MainMenu = Bar2
        BarManager1.MaxItemId = 2
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryItemSearchControl1})
        ' 
        ' Bar2
        ' 
        Bar2.BarName = "Main menu"
        Bar2.DockCol = 0
        Bar2.DockRow = 0
        Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Left
        Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnubar01Save)})
        Bar2.OptionsBar.MultiLine = True
        Bar2.OptionsBar.UseWholeRow = True
        Bar2.Text = "Main menu"
        ' 
        ' mnubar01Save
        ' 
        mnubar01Save.Caption = "Process"
        mnubar01Save.Id = 1
        mnubar01Save.ImageOptions.SvgImage = CType(resources.GetObject("mnubar01Save.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubar01Save.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        mnubar01Save.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubar01Save.ItemAppearance.Normal.Options.UseFont = True
        mnubar01Save.ItemAppearance.Normal.Options.UseForeColor = True
        mnubar01Save.Name = "mnubar01Save"
        mnubar01Save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Size = New Size(1309, 0)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 514)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Size = New Size(1309, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 0)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Size = New Size(50, 514)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(1309, 0)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Size = New Size(0, 514)
        ' 
        ' RepositoryItemSearchControl1
        ' 
        RepositoryItemSearchControl1.AutoHeight = False
        RepositoryItemSearchControl1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Repository.ClearButton(), New DevExpress.XtraEditors.Repository.SearchButton()})
        RepositoryItemSearchControl1.Name = "RepositoryItemSearchControl1"
        ' 
        ' ucWS24IX01PKBCONSUMEINBOUND
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Name = "ucWS24IX01PKBCONSUMEINBOUND"
        Size = New Size(1309, 514)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemSearchControl1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents _gdInboundConsumePKB As SKK02OBJECTS.ucWSGrid
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RepositoryItemSearchControl1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchControl
    Friend WithEvents mnubar01Save As DevExpress.XtraBars.BarButtonItem

End Class
