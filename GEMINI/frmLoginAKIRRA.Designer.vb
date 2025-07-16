<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoginAKIRRA
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim WindowsuiButtonImageOptions1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginAKIRRA))
        Dim WindowsuiButtonImageOptions2 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        _03cTargetNetwork = New DevExpress.XtraEditors.ComboBoxEdit()
        WindowsuiButtonPanel1 = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        peImage = New DevExpress.XtraEditors.PictureEdit()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(SeparatorControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_03cTargetNetwork.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem5, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem3, ComponentModel.ISupportInitialize).BeginInit()
        CType(peImage.Properties, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(SeparatorControl1)
        LayoutControl1.Controls.Add(_03cTargetNetwork)
        LayoutControl1.Controls.Add(WindowsuiButtonPanel1)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 80)
        LayoutControl1.Margin = New Padding(2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(473, 93)
        LayoutControl1.TabIndex = 18
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' SeparatorControl1
        ' 
        SeparatorControl1.Location = New Point(12, 58)
        SeparatorControl1.Name = "SeparatorControl1"
        SeparatorControl1.Size = New Size(339, 23)
        SeparatorControl1.TabIndex = 4
        ' 
        ' _03cTargetNetwork
        ' 
        _03cTargetNetwork.EditValue = "<AKIRRA>"
        _03cTargetNetwork.Location = New Point(100, 32)
        _03cTargetNetwork.Margin = New Padding(2)
        _03cTargetNetwork.Name = "_03cTargetNetwork"
        _03cTargetNetwork.Properties.Appearance.Font = New Font("Cambria", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        _03cTargetNetwork.Properties.Appearance.ForeColor = Color.DarkSlateGray
        _03cTargetNetwork.Properties.Appearance.Options.UseFont = True
        _03cTargetNetwork.Properties.Appearance.Options.UseForeColor = True
        _03cTargetNetwork.Properties.AppearanceDropDown.Font = New Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        _03cTargetNetwork.Properties.AppearanceDropDown.ForeColor = Color.Navy
        _03cTargetNetwork.Properties.AppearanceDropDown.Options.UseFont = True
        _03cTargetNetwork.Properties.AppearanceDropDown.Options.UseForeColor = True
        _03cTargetNetwork.Properties.AppearanceItemSelected.Font = New Font("Cambria", 9.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        _03cTargetNetwork.Properties.AppearanceItemSelected.ForeColor = Color.DarkSlateGray
        _03cTargetNetwork.Properties.AppearanceItemSelected.Options.UseFont = True
        _03cTargetNetwork.Properties.AppearanceItemSelected.Options.UseForeColor = True
        _03cTargetNetwork.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _03cTargetNetwork.Size = New Size(251, 22)
        _03cTargetNetwork.StyleController = LayoutControl1
        _03cTargetNetwork.TabIndex = 2
        ' 
        ' WindowsuiButtonPanel1
        ' 
        WindowsuiButtonImageOptions1.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonImageOptions2.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions2.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonPanel1.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("", True, WindowsuiButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Login", -1, True, Nothing, True, False, True, 100S, -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("", True, WindowsuiButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Exit", -1, True, Nothing, True, False, True, 200S, -1, False)})
        WindowsuiButtonPanel1.Location = New Point(365, 23)
        WindowsuiButtonPanel1.Margin = New Padding(2)
        WindowsuiButtonPanel1.Name = "WindowsuiButtonPanel1"
        WindowsuiButtonPanel1.Size = New Size(96, 40)
        WindowsuiButtonPanel1.TabIndex = 0
        WindowsuiButtonPanel1.Text = "WindowsuiButtonPanel1"
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem5, LayoutControlItem3, EmptySpaceItem1, EmptySpaceItem5, LayoutControlItem1, EmptySpaceItem4, EmptySpaceItem3})
        Root.Name = "Root"
        Root.Size = New Size(473, 93)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem5
        ' 
        LayoutControlItem5.Control = WindowsuiButtonPanel1
        LayoutControlItem5.Location = New Point(353, 11)
        LayoutControlItem5.Name = "LayoutControlItem5"
        LayoutControlItem5.Size = New Size(100, 44)
        LayoutControlItem5.TextSize = New Size(0, 0)
        LayoutControlItem5.TextVisible = False
        ' 
        ' LayoutControlItem3
        ' 
        LayoutControlItem3.AppearanceItemCaption.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LayoutControlItem3.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem3.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem3.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem3.Control = _03cTargetNetwork
        LayoutControlItem3.Location = New Point(0, 20)
        LayoutControlItem3.Name = "LayoutControlItem3"
        LayoutControlItem3.Size = New Size(343, 26)
        LayoutControlItem3.Text = "Server Target:"
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(0, 0)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(343, 20)
        ' 
        ' EmptySpaceItem5
        ' 
        EmptySpaceItem5.Location = New Point(353, 55)
        EmptySpaceItem5.Name = "EmptySpaceItem5"
        EmptySpaceItem5.Size = New Size(100, 18)
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = SeparatorControl1
        LayoutControlItem1.Location = New Point(0, 46)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(343, 27)
        LayoutControlItem1.TextSize = New Size(0, 0)
        LayoutControlItem1.TextVisible = False
        ' 
        ' EmptySpaceItem4
        ' 
        EmptySpaceItem4.Location = New Point(353, 0)
        EmptySpaceItem4.Name = "EmptySpaceItem4"
        EmptySpaceItem4.Size = New Size(100, 11)
        ' 
        ' EmptySpaceItem3
        ' 
        EmptySpaceItem3.Location = New Point(343, 0)
        EmptySpaceItem3.Name = "EmptySpaceItem3"
        EmptySpaceItem3.Size = New Size(10, 73)
        ' 
        ' peImage
        ' 
        peImage.Dock = DockStyle.Top
        peImage.EditValue = resources.GetObject("peImage.EditValue")
        peImage.Location = New Point(0, 0)
        peImage.Name = "peImage"
        peImage.Properties.AllowFocused = False
        peImage.Properties.Appearance.BackColor = Color.Transparent
        peImage.Properties.Appearance.Options.UseBackColor = True
        peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        peImage.Properties.ShowMenu = False
        peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        peImage.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        peImage.Size = New Size(473, 80)
        peImage.TabIndex = 17
        ' 
        ' frmLoginAKIRRA
        ' 
        Appearance.ForeColor = Color.Navy
        Appearance.Options.UseForeColor = True
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(473, 173)
        ControlBox = False
        Controls.Add(LayoutControl1)
        Controls.Add(peImage)
        IconOptions.Icon = CType(resources.GetObject("frmLoginAKIRRA.IconOptions.Icon"), Icon)
        Margin = New Padding(2)
        Name = "frmLoginAKIRRA"
        StartPosition = FormStartPosition.CenterScreen
        Text = "<AKIRRA>"
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(SeparatorControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(_03cTargetNetwork.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem5, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem4, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem3, ComponentModel.ISupportInitialize).EndInit()
        CType(peImage.Properties, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Private WithEvents peImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents WindowsuiButtonPanel1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _03cTargetNetwork As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
End Class
