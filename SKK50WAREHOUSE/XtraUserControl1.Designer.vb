<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraUserControl1
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
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        _01nAngkaPertama = New DevExpress.XtraEditors.SpinEdit()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        _02nAngkaKedua = New DevExpress.XtraEditors.SpinEdit()
        LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        _03nAngkaHasilPenjumlahan = New DevExpress.XtraEditors.SpinEdit()
        LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01nAngkaPertama.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_02nAngkaKedua.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(_03nAngkaHasilPenjumlahan.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_03nAngkaHasilPenjumlahan)
        LayoutControl1.Controls.Add(_02nAngkaKedua)
        LayoutControl1.Controls.Add(_01nAngkaPertama)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(614, 279)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1, EmptySpaceItem1, LayoutControlItem2, LayoutControlItem3})
        Root.Name = "Root"
        Root.Size = New Size(614, 279)
        Root.TextVisible = False
        ' 
        ' _01nAngkaPertama
        ' 
        _01nAngkaPertama.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        _01nAngkaPertama.Location = New Point(116, 12)
        _01nAngkaPertama.Name = "_01nAngkaPertama"
        _01nAngkaPertama.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _01nAngkaPertama.Size = New Size(486, 28)
        _01nAngkaPertama.StyleController = LayoutControl1
        _01nAngkaPertama.TabIndex = 4
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = _01nAngkaPertama
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(594, 32)
        LayoutControlItem1.Text = "Angka 1"
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(0, 96)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(594, 163)
        ' 
        ' _02nAngkaKedua
        ' 
        _02nAngkaKedua.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        _02nAngkaKedua.Location = New Point(116, 44)
        _02nAngkaKedua.Name = "_02nAngkaKedua"
        _02nAngkaKedua.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _02nAngkaKedua.Size = New Size(486, 28)
        _02nAngkaKedua.StyleController = LayoutControl1
        _02nAngkaKedua.TabIndex = 5
        ' 
        ' LayoutControlItem2
        ' 
        LayoutControlItem2.Control = _02nAngkaKedua
        LayoutControlItem2.Location = New Point(0, 32)
        LayoutControlItem2.Name = "LayoutControlItem2"
        LayoutControlItem2.Size = New Size(594, 32)
        LayoutControlItem2.Text = "Angka 2"
        ' 
        ' _03nAngkaHasilPenjumlahan
        ' 
        _03nAngkaHasilPenjumlahan.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        _03nAngkaHasilPenjumlahan.Location = New Point(116, 76)
        _03nAngkaHasilPenjumlahan.Name = "_03nAngkaHasilPenjumlahan"
        _03nAngkaHasilPenjumlahan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _03nAngkaHasilPenjumlahan.Size = New Size(486, 28)
        _03nAngkaHasilPenjumlahan.StyleController = LayoutControl1
        _03nAngkaHasilPenjumlahan.TabIndex = 6
        ' 
        ' LayoutControlItem3
        ' 
        LayoutControlItem3.Control = _03nAngkaHasilPenjumlahan
        LayoutControlItem3.Location = New Point(0, 64)
        LayoutControlItem3.Name = "LayoutControlItem3"
        LayoutControlItem3.Size = New Size(594, 32)
        LayoutControlItem3.Text = "Penjumlahan"
        ' 
        ' XtraUserControl1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Name = "XtraUserControl1"
        Size = New Size(614, 279)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(_01nAngkaPertama.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(_02nAngkaKedua.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(_03nAngkaHasilPenjumlahan.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents _03nAngkaHasilPenjumlahan As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents _02nAngkaKedua As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents _01nAngkaPertama As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem

End Class
