<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuAKIRRA
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuAKIRRA))
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        mnuBulkUpload = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        mnuBUP01wSo = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        AccordionControlSeparator2 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        mnuBUP02wSoLD = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        AccordionControlSeparator3 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(AccordionControl1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Margin = New Padding(4, 3, 4, 3)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1063, 497)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {EmptySpaceItem1})
        Root.Name = "Root"
        Root.Size = New Size(1063, 497)
        Root.TextVisible = False
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(0, 0)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(1043, 477)
        ' 
        ' AccordionControl1
        ' 
        AccordionControl1.Appearance.Group.Default.Font = New Font("Nirmala UI", 12F, FontStyle.Bold)
        AccordionControl1.Appearance.Group.Default.Options.UseFont = True
        AccordionControl1.Appearance.Group.Hovered.Font = New Font("Nirmala UI Semilight", 14F, FontStyle.Italic)
        AccordionControl1.Appearance.Group.Hovered.Options.UseFont = True
        AccordionControl1.Appearance.Group.Normal.Font = New Font("Nirmala UI", 12F, FontStyle.Bold)
        AccordionControl1.Appearance.Group.Normal.Options.UseFont = True
        AccordionControl1.Appearance.Group.Pressed.Font = New Font("Nirmala UI", 12F, FontStyle.Bold)
        AccordionControl1.Appearance.Group.Pressed.Options.UseFont = True
        AccordionControl1.Appearance.Item.Hovered.Font = New Font("Nirmala UI Semilight", 9F, FontStyle.Italic)
        AccordionControl1.Appearance.Item.Hovered.Options.UseFont = True
        AccordionControl1.Appearance.Item.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        AccordionControl1.Appearance.Item.Normal.Options.UseFont = True
        AccordionControl1.Appearance.Item.Pressed.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        AccordionControl1.Appearance.Item.Pressed.Options.UseFont = True
        AccordionControl1.Dock = DockStyle.Left
        AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {mnuBulkUpload})
        AccordionControl1.Location = New Point(0, 0)
        AccordionControl1.Margin = New Padding(5)
        AccordionControl1.Name = "AccordionControl1"
        AccordionControl1.Size = New Size(306, 497)
        AccordionControl1.TabIndex = 1
        AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        ' 
        ' mnuBulkUpload
        ' 
        mnuBulkUpload.Appearance.Default.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mnuBulkUpload.Appearance.Default.ForeColor = Color.Navy
        mnuBulkUpload.Appearance.Default.Options.UseFont = True
        mnuBulkUpload.Appearance.Default.Options.UseForeColor = True
        mnuBulkUpload.Appearance.Hovered.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        mnuBulkUpload.Appearance.Hovered.ForeColor = Color.DarkSlateGray
        mnuBulkUpload.Appearance.Hovered.Options.UseFont = True
        mnuBulkUpload.Appearance.Hovered.Options.UseForeColor = True
        mnuBulkUpload.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {mnuBUP01wSo, AccordionControlSeparator2, mnuBUP02wSoLD, AccordionControlSeparator3})
        mnuBulkUpload.Expanded = True
        mnuBulkUpload.HeaderIndent = 5
        mnuBulkUpload.HeaderTemplate.AddRange(New DevExpress.XtraBars.Navigation.HeaderElementInfo() {New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Right)})
        mnuBulkUpload.ImageOptions.Image = CType(resources.GetObject("mnuBulkUpload.ImageOptions.Image"), Image)
        mnuBulkUpload.Name = "mnuBulkUpload"
        mnuBulkUpload.Text = "wSo: Bulk Upload"
        ' 
        ' mnuBUP01wSo
        ' 
        mnuBUP01wSo.Appearance.Default.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mnuBUP01wSo.Appearance.Default.ForeColor = Color.Navy
        mnuBUP01wSo.Appearance.Default.Options.UseFont = True
        mnuBUP01wSo.Appearance.Default.Options.UseForeColor = True
        mnuBUP01wSo.Appearance.Hovered.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        mnuBUP01wSo.Appearance.Hovered.ForeColor = Color.DarkSlateGray
        mnuBUP01wSo.Appearance.Hovered.Options.UseFont = True
        mnuBUP01wSo.Appearance.Hovered.Options.UseForeColor = True
        mnuBUP01wSo.HeaderIndent = 7
        mnuBUP01wSo.ImageOptions.Image = CType(resources.GetObject("mnuBUP01wSo.ImageOptions.Image"), Image)
        mnuBUP01wSo.Name = "mnuBUP01wSo"
        mnuBUP01wSo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        mnuBUP01wSo.Text = "SO Upload - STOCK"
        ' 
        ' AccordionControlSeparator2
        ' 
        AccordionControlSeparator2.Name = "AccordionControlSeparator2"
        ' 
        ' mnuBUP02wSoLD
        ' 
        mnuBUP02wSoLD.Appearance.Default.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mnuBUP02wSoLD.Appearance.Default.ForeColor = Color.Navy
        mnuBUP02wSoLD.Appearance.Default.Options.UseFont = True
        mnuBUP02wSoLD.Appearance.Default.Options.UseForeColor = True
        mnuBUP02wSoLD.Appearance.Hovered.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        mnuBUP02wSoLD.Appearance.Hovered.ForeColor = Color.DarkSlateGray
        mnuBUP02wSoLD.Appearance.Hovered.Options.UseFont = True
        mnuBUP02wSoLD.Appearance.Hovered.Options.UseForeColor = True
        mnuBUP02wSoLD.ImageOptions.Image = CType(resources.GetObject("mnuBUP02wSoLD.ImageOptions.Image"), Image)
        mnuBUP02wSoLD.Name = "mnuBUP02wSoLD"
        mnuBUP02wSoLD.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        mnuBUP02wSoLD.Text = "SO Upload - SOLD"
        ' 
        ' AccordionControlSeparator3
        ' 
        AccordionControlSeparator3.Name = "AccordionControlSeparator3"
        ' 
        ' frmMenuAKIRRA
        ' 
        Appearance.ForeColor = Color.Navy
        Appearance.Options.UseFont = True
        Appearance.Options.UseForeColor = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1063, 497)
        Controls.Add(AccordionControl1)
        Controls.Add(LayoutControl1)
        Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(4, 3, 4, 3)
        Name = "frmMenuAKIRRA"
        Text = "<AKIRRA>"
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(AccordionControl1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents mnuBulkUpload As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents mnuBUP01wSo As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlSeparator1 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents AccordionControlSeparator2 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents mnuBUP02wSoLD As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlSeparator3 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
End Class
