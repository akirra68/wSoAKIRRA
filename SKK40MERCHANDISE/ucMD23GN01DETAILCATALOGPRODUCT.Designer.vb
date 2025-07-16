<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMD23GN01DETAILCATALOGPRODUCT
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
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        _oTab01Picture = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _01Picture = New DevExpress.XtraEditors.PictureEdit()
        _oTab02BOM = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _splitBOMPanel01 = New DevExpress.XtraEditors.SplitContainerControl()
        _GroupBOM01CastedPart = New DevExpress.XtraEditors.GroupControl()
        _splitBOMPanel02 = New DevExpress.XtraEditors.SplitContainerControl()
        _GroupBOM02FCI = New DevExpress.XtraEditors.GroupControl()
        _GroupBOM03Stone = New DevExpress.XtraEditors.GroupControl()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        _oTab03Merchandise = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _layoutMerchandise = New DevExpress.XtraLayout.LayoutControl()
        LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        _oTab05Warehouse = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        _oTab04Production = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _layoutProduksi = New DevExpress.XtraLayout.LayoutControl()
        LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        _GroupMerchandise = New DevExpress.XtraEditors.GroupControl()
        LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        _GroupProduksi = New DevExpress.XtraEditors.GroupControl()
        LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        _oTab01Picture.SuspendLayout()
        CType(_01Picture.Properties, ComponentModel.ISupportInitialize).BeginInit()
        _oTab02BOM.SuspendLayout()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(_splitBOMPanel01, ComponentModel.ISupportInitialize).BeginInit()
        CType(_splitBOMPanel01.Panel1, ComponentModel.ISupportInitialize).BeginInit()
        _splitBOMPanel01.Panel1.SuspendLayout()
        CType(_splitBOMPanel01.Panel2, ComponentModel.ISupportInitialize).BeginInit()
        _splitBOMPanel01.Panel2.SuspendLayout()
        _splitBOMPanel01.SuspendLayout()
        CType(_GroupBOM01CastedPart, ComponentModel.ISupportInitialize).BeginInit()
        CType(_splitBOMPanel02, ComponentModel.ISupportInitialize).BeginInit()
        CType(_splitBOMPanel02.Panel1, ComponentModel.ISupportInitialize).BeginInit()
        _splitBOMPanel02.Panel1.SuspendLayout()
        CType(_splitBOMPanel02.Panel2, ComponentModel.ISupportInitialize).BeginInit()
        _splitBOMPanel02.Panel2.SuspendLayout()
        _splitBOMPanel02.SuspendLayout()
        CType(_GroupBOM02FCI, ComponentModel.ISupportInitialize).BeginInit()
        CType(_GroupBOM03Stone, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        _oTab03Merchandise.SuspendLayout()
        CType(_layoutMerchandise, ComponentModel.ISupportInitialize).BeginInit()
        _layoutMerchandise.SuspendLayout()
        CType(LayoutControlGroup1, ComponentModel.ISupportInitialize).BeginInit()
        _oTab05Warehouse.SuspendLayout()
        _oTab04Production.SuspendLayout()
        CType(_layoutProduksi, ComponentModel.ISupportInitialize).BeginInit()
        _layoutProduksi.SuspendLayout()
        CType(LayoutControlGroup2, ComponentModel.ISupportInitialize).BeginInit()
        CType(_GroupMerchandise, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(_GroupProduksi, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TabPane1
        ' 
        TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True
        TabPane1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 10F, FontStyle.Italic, GraphicsUnit.Point)
        TabPane1.AppearanceButton.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        TabPane1.AppearanceButton.Hovered.Options.UseFont = True
        TabPane1.AppearanceButton.Hovered.Options.UseForeColor = True
        TabPane1.AppearanceButton.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        TabPane1.AppearanceButton.Normal.ForeColor = Color.Gray
        TabPane1.AppearanceButton.Normal.Options.UseFont = True
        TabPane1.AppearanceButton.Normal.Options.UseForeColor = True
        TabPane1.AppearanceButton.Pressed.Font = New Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        TabPane1.AppearanceButton.Pressed.ForeColor = Color.Blue
        TabPane1.AppearanceButton.Pressed.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Options.UseForeColor = True
        TabPane1.Controls.Add(_oTab01Picture)
        TabPane1.Controls.Add(_oTab02BOM)
        TabPane1.Controls.Add(_oTab03Merchandise)
        TabPane1.Controls.Add(_oTab05Warehouse)
        TabPane1.Controls.Add(_oTab04Production)
        TabPane1.Dock = DockStyle.Fill
        TabPane1.Location = New Point(0, 0)
        TabPane1.Name = "TabPane1"
        TabPane1.PageProperties.AppearanceCaption.Options.UseFont = True
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {_oTab01Picture, _oTab02BOM, _oTab03Merchandise, _oTab04Production, _oTab05Warehouse})
        TabPane1.RegularSize = New Size(1419, 734)
        TabPane1.SelectedPage = _oTab01Picture
        TabPane1.Size = New Size(1419, 734)
        TabPane1.TabIndex = 0
        TabPane1.Text = "TabPane1"
        ' 
        ' _oTab01Picture
        ' 
        _oTab01Picture.Caption = "Picture"
        _oTab01Picture.Controls.Add(_01Picture)
        _oTab01Picture.Name = "_oTab01Picture"
        _oTab01Picture.Size = New Size(1419, 685)
        ' 
        ' _01Picture
        ' 
        _01Picture.Dock = DockStyle.Fill
        _01Picture.Location = New Point(0, 0)
        _01Picture.Name = "_01Picture"
        _01Picture.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto
        _01Picture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        _01Picture.Size = New Size(1419, 685)
        _01Picture.TabIndex = 0
        ' 
        ' _oTab02BOM
        ' 
        _oTab02BOM.Caption = "Bill of Materials"
        _oTab02BOM.Controls.Add(LayoutControl1)
        _oTab02BOM.Name = "_oTab02BOM"
        _oTab02BOM.Size = New Size(1419, 685)
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_splitBOMPanel01)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1419, 685)
        LayoutControl1.TabIndex = 1
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _splitBOMPanel01
        ' 
        _splitBOMPanel01.Horizontal = False
        _splitBOMPanel01.Location = New Point(12, 12)
        _splitBOMPanel01.Name = "_splitBOMPanel01"
        ' 
        ' _splitBOMPanel01.Panel1
        ' 
        _splitBOMPanel01.Panel1.Controls.Add(_GroupBOM01CastedPart)
        _splitBOMPanel01.Panel1.Text = "Panel1"
        ' 
        ' _splitBOMPanel01.Panel2
        ' 
        _splitBOMPanel01.Panel2.Controls.Add(_splitBOMPanel02)
        _splitBOMPanel01.Panel2.Text = "Panel2"
        _splitBOMPanel01.Size = New Size(1395, 661)
        _splitBOMPanel01.SplitterPosition = 214
        _splitBOMPanel01.TabIndex = 0
        ' 
        ' _GroupBOM01CastedPart
        ' 
        _GroupBOM01CastedPart.AppearanceCaption.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        _GroupBOM01CastedPart.AppearanceCaption.Options.UseForeColor = True
        _GroupBOM01CastedPart.Dock = DockStyle.Fill
        _GroupBOM01CastedPart.Location = New Point(0, 0)
        _GroupBOM01CastedPart.Name = "_GroupBOM01CastedPart"
        _GroupBOM01CastedPart.Size = New Size(1395, 214)
        _GroupBOM01CastedPart.TabIndex = 0
        _GroupBOM01CastedPart.Text = "Casted Part"
        ' 
        ' _splitBOMPanel02
        ' 
        _splitBOMPanel02.Dock = DockStyle.Fill
        _splitBOMPanel02.Horizontal = False
        _splitBOMPanel02.Location = New Point(0, 0)
        _splitBOMPanel02.Name = "_splitBOMPanel02"
        ' 
        ' _splitBOMPanel02.Panel1
        ' 
        _splitBOMPanel02.Panel1.Controls.Add(_GroupBOM02FCI)
        _splitBOMPanel02.Panel1.Text = "Panel1"
        ' 
        ' _splitBOMPanel02.Panel2
        ' 
        _splitBOMPanel02.Panel2.Controls.Add(_GroupBOM03Stone)
        _splitBOMPanel02.Panel2.Text = "Panel2"
        _splitBOMPanel02.Size = New Size(1395, 432)
        _splitBOMPanel02.SplitterPosition = 220
        _splitBOMPanel02.TabIndex = 0
        ' 
        ' _GroupBOM02FCI
        ' 
        _GroupBOM02FCI.AppearanceCaption.ForeColor = Color.Fuchsia
        _GroupBOM02FCI.AppearanceCaption.Options.UseForeColor = True
        _GroupBOM02FCI.Dock = DockStyle.Fill
        _GroupBOM02FCI.Location = New Point(0, 0)
        _GroupBOM02FCI.Name = "_GroupBOM02FCI"
        _GroupBOM02FCI.Size = New Size(1395, 220)
        _GroupBOM02FCI.TabIndex = 0
        _GroupBOM02FCI.Text = "Finding and Component"
        ' 
        ' _GroupBOM03Stone
        ' 
        _GroupBOM03Stone.AppearanceCaption.ForeColor = Color.Teal
        _GroupBOM03Stone.AppearanceCaption.Options.UseForeColor = True
        _GroupBOM03Stone.Dock = DockStyle.Fill
        _GroupBOM03Stone.Location = New Point(0, 0)
        _GroupBOM03Stone.Name = "_GroupBOM03Stone"
        _GroupBOM03Stone.Size = New Size(1395, 197)
        _GroupBOM03Stone.TabIndex = 0
        _GroupBOM03Stone.Text = "Stone"
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(1419, 685)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = _splitBOMPanel01
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(1399, 665)
        LayoutControlItem1.TextSize = New Size(0, 0)
        LayoutControlItem1.TextVisible = False
        ' 
        ' _oTab03Merchandise
        ' 
        _oTab03Merchandise.Caption = "Merchandise"
        _oTab03Merchandise.Controls.Add(_layoutMerchandise)
        _oTab03Merchandise.Name = "_oTab03Merchandise"
        _oTab03Merchandise.Size = New Size(1419, 685)
        ' 
        ' _layoutMerchandise
        ' 
        _layoutMerchandise.Controls.Add(_GroupMerchandise)
        _layoutMerchandise.Dock = DockStyle.Fill
        _layoutMerchandise.Location = New Point(0, 0)
        _layoutMerchandise.Name = "_layoutMerchandise"
        _layoutMerchandise.Root = LayoutControlGroup1
        _layoutMerchandise.Size = New Size(1419, 685)
        _layoutMerchandise.TabIndex = 0
        _layoutMerchandise.Text = "LayoutControl2"
        ' 
        ' LayoutControlGroup1
        ' 
        LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        LayoutControlGroup1.GroupBordersVisible = False
        LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem2})
        LayoutControlGroup1.Name = "LayoutControlGroup1"
        LayoutControlGroup1.Size = New Size(1419, 685)
        LayoutControlGroup1.TextVisible = False
        ' 
        ' _oTab05Warehouse
        ' 
        _oTab05Warehouse.Caption = "Warehouse"
        _oTab05Warehouse.Controls.Add(LabelControl1)
        _oTab05Warehouse.Name = "_oTab05Warehouse"
        _oTab05Warehouse.Size = New Size(1419, 685)
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Appearance.Font = New Font("Impact", 20F, FontStyle.Underline, GraphicsUnit.Point)
        LabelControl1.Appearance.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        LabelControl1.Appearance.Options.UseFont = True
        LabelControl1.Appearance.Options.UseForeColor = True
        LabelControl1.Location = New Point(395, 155)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(491, 48)
        LabelControl1.TabIndex = 0
        LabelControl1.Text = "SORRY ..... UNDER CONTRUCTION"
        ' 
        ' _oTab04Production
        ' 
        _oTab04Production.Caption = "Production"
        _oTab04Production.Controls.Add(_layoutProduksi)
        _oTab04Production.Name = "_oTab04Production"
        _oTab04Production.Size = New Size(1419, 685)
        ' 
        ' _layoutProduksi
        ' 
        _layoutProduksi.Controls.Add(_GroupProduksi)
        _layoutProduksi.Dock = DockStyle.Fill
        _layoutProduksi.Location = New Point(0, 0)
        _layoutProduksi.Name = "_layoutProduksi"
        _layoutProduksi.Root = LayoutControlGroup2
        _layoutProduksi.Size = New Size(1419, 685)
        _layoutProduksi.TabIndex = 0
        _layoutProduksi.Text = "LayoutControl2"
        ' 
        ' LayoutControlGroup2
        ' 
        LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        LayoutControlGroup2.GroupBordersVisible = False
        LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem3})
        LayoutControlGroup2.Name = "LayoutControlGroup2"
        LayoutControlGroup2.Size = New Size(1419, 685)
        LayoutControlGroup2.TextVisible = False
        ' 
        ' _GroupMerchandise
        ' 
        _GroupMerchandise.Location = New Point(12, 12)
        _GroupMerchandise.Name = "_GroupMerchandise"
        _GroupMerchandise.Size = New Size(1395, 661)
        _GroupMerchandise.TabIndex = 4
        ' 
        ' LayoutControlItem2
        ' 
        LayoutControlItem2.Control = _GroupMerchandise
        LayoutControlItem2.Location = New Point(0, 0)
        LayoutControlItem2.Name = "LayoutControlItem2"
        LayoutControlItem2.Size = New Size(1399, 665)
        LayoutControlItem2.TextSize = New Size(0, 0)
        LayoutControlItem2.TextVisible = False
        ' 
        ' _GroupProduksi
        ' 
        _GroupProduksi.Location = New Point(12, 12)
        _GroupProduksi.Name = "_GroupProduksi"
        _GroupProduksi.Size = New Size(1395, 661)
        _GroupProduksi.TabIndex = 4
        ' 
        ' LayoutControlItem3
        ' 
        LayoutControlItem3.Control = _GroupProduksi
        LayoutControlItem3.Location = New Point(0, 0)
        LayoutControlItem3.Name = "LayoutControlItem3"
        LayoutControlItem3.Size = New Size(1399, 665)
        LayoutControlItem3.TextSize = New Size(0, 0)
        LayoutControlItem3.TextVisible = False
        ' 
        ' ucMD23GN01DETAILCATALOGPRODUCT
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(TabPane1)
        Name = "ucMD23GN01DETAILCATALOGPRODUCT"
        Size = New Size(1419, 734)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        _oTab01Picture.ResumeLayout(False)
        CType(_01Picture.Properties, ComponentModel.ISupportInitialize).EndInit()
        _oTab02BOM.ResumeLayout(False)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(_splitBOMPanel01.Panel1, ComponentModel.ISupportInitialize).EndInit()
        _splitBOMPanel01.Panel1.ResumeLayout(False)
        CType(_splitBOMPanel01.Panel2, ComponentModel.ISupportInitialize).EndInit()
        _splitBOMPanel01.Panel2.ResumeLayout(False)
        CType(_splitBOMPanel01, ComponentModel.ISupportInitialize).EndInit()
        _splitBOMPanel01.ResumeLayout(False)
        CType(_GroupBOM01CastedPart, ComponentModel.ISupportInitialize).EndInit()
        CType(_splitBOMPanel02.Panel1, ComponentModel.ISupportInitialize).EndInit()
        _splitBOMPanel02.Panel1.ResumeLayout(False)
        CType(_splitBOMPanel02.Panel2, ComponentModel.ISupportInitialize).EndInit()
        _splitBOMPanel02.Panel2.ResumeLayout(False)
        CType(_splitBOMPanel02, ComponentModel.ISupportInitialize).EndInit()
        _splitBOMPanel02.ResumeLayout(False)
        CType(_GroupBOM02FCI, ComponentModel.ISupportInitialize).EndInit()
        CType(_GroupBOM03Stone, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        _oTab03Merchandise.ResumeLayout(False)
        CType(_layoutMerchandise, ComponentModel.ISupportInitialize).EndInit()
        _layoutMerchandise.ResumeLayout(False)
        CType(LayoutControlGroup1, ComponentModel.ISupportInitialize).EndInit()
        _oTab05Warehouse.ResumeLayout(False)
        _oTab05Warehouse.PerformLayout()
        _oTab04Production.ResumeLayout(False)
        CType(_layoutProduksi, ComponentModel.ISupportInitialize).EndInit()
        _layoutProduksi.ResumeLayout(False)
        CType(LayoutControlGroup2, ComponentModel.ISupportInitialize).EndInit()
        CType(_GroupMerchandise, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(_GroupProduksi, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents _oTab01Picture As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _oTab02BOM As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _oTab03Merchandise As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _oTab05Warehouse As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _01Picture As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents _oTab04Production As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents _splitBOMPanel01 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents _splitBOMPanel02 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents _GroupBOM01CastedPart As DevExpress.XtraEditors.GroupControl
    Friend WithEvents _GroupBOM02FCI As DevExpress.XtraEditors.GroupControl
    Friend WithEvents _GroupBOM03Stone As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _layoutMerchandise As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _layoutProduksi As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _GroupMerchandise As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _GroupProduksi As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
End Class
