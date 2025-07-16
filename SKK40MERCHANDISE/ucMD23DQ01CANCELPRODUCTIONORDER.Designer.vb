<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMD23DQ01CANCELPRODUCTIONORDER
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(ucMD23DQ01CANCELPRODUCTIONORDER))
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _otblClear = New DevExpress.XtraEditors.SimpleButton()
        _otblProsesBatal = New DevExpress.XtraEditors.SimpleButton()
        _02cAlasanBatal = New DevExpress.XtraEditors.TextEdit()
        _01cKodeProductionOrder = New SKK02OBJECTS.ctrlGEMINIMaster()
        CtrlgeminiMaster1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        _gdPOBatal = New SKK02OBJECTS.ucGridTransaction()
        LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(_02cAlasanBatal.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01cKodeProductionOrder.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlgeminiMaster1View, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_gdPOBatal)
        LayoutControl1.Controls.Add(_otblClear)
        LayoutControl1.Controls.Add(_otblProsesBatal)
        LayoutControl1.Controls.Add(_02cAlasanBatal)
        LayoutControl1.Controls.Add(_01cKodeProductionOrder)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1200, 672)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _otblClear
        ' 
        _otblClear.Appearance.Font = New Font("Nirmala UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        _otblClear.Appearance.ForeColor = Color.Navy
        _otblClear.Appearance.Options.UseFont = True
        _otblClear.Appearance.Options.UseForeColor = True
        _otblClear.Location = New Point(828, 12)
        _otblClear.Name = "_otblClear"
        _otblClear.Size = New Size(212, 32)
        _otblClear.StyleController = LayoutControl1
        _otblClear.TabIndex = 7
        _otblClear.Text = "Clear"
        ' 
        ' _otblProsesBatal
        ' 
        _otblProsesBatal.Appearance.Font = New Font("Nirmala UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        _otblProsesBatal.Appearance.ForeColor = Color.Navy
        _otblProsesBatal.Appearance.Options.UseFont = True
        _otblProsesBatal.Appearance.Options.UseForeColor = True
        _otblProsesBatal.Location = New Point(602, 12)
        _otblProsesBatal.Name = "_otblProsesBatal"
        _otblProsesBatal.Size = New Size(222, 32)
        _otblProsesBatal.StyleController = LayoutControl1
        _otblProsesBatal.TabIndex = 6
        _otblProsesBatal.Text = "Proses Batal"
        ' 
        ' _02cAlasanBatal
        ' 
        _02cAlasanBatal.Location = New Point(162, 48)
        _02cAlasanBatal.Name = "_02cAlasanBatal"
        _02cAlasanBatal.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point)
        _02cAlasanBatal.Properties.Appearance.Options.UseFont = True
        _02cAlasanBatal.Size = New Size(1026, 26)
        _02cAlasanBatal.StyleController = LayoutControl1
        _02cAlasanBatal.TabIndex = 5
        ' 
        ' _01cKodeProductionOrder
        ' 
        _01cKodeProductionOrder._02prop_cGEMINIDaftarField = Nothing
        _01cKodeProductionOrder._03prop_cGEMINIFieldYgDiFilter = Nothing
        _01cKodeProductionOrder._04prop_cGEMINIValueKodeMasterYgDiFilter = Nothing
        _01cKodeProductionOrder._05prop_cGEMINIFieldValueMember = Nothing
        _01cKodeProductionOrder._06prop_cGEMINIFieldDisplayMember = Nothing
        _01cKodeProductionOrder._07prop_cGEMINIKeyKolomFilterUntSelect = Nothing
        _01cKodeProductionOrder.Location = New Point(162, 12)
        _01cKodeProductionOrder.Name = "_01cKodeProductionOrder"
        _01cKodeProductionOrder.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point)
        _01cKodeProductionOrder.Properties.Appearance.Options.UseFont = True
        _01cKodeProductionOrder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _01cKodeProductionOrder.Properties.NullText = ""
        _01cKodeProductionOrder.Properties.PopupView = CtrlgeminiMaster1View
        _01cKodeProductionOrder.Size = New Size(436, 26)
        _01cKodeProductionOrder.StyleController = LayoutControl1
        _01cKodeProductionOrder.TabIndex = 4
        ' 
        ' CtrlgeminiMaster1View
        ' 
        CtrlgeminiMaster1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlgeminiMaster1View.Name = "CtrlgeminiMaster1View"
        CtrlgeminiMaster1View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlgeminiMaster1View.OptionsView.ShowGroupPanel = False
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1, LayoutControlItem2, EmptySpaceItem1, LayoutControlItem3, LayoutControlItem4, LayoutControlItem5})
        Root.Name = "Root"
        Root.Size = New Size(1200, 672)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        LayoutControlItem1.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem1.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem1.Control = _01cKodeProductionOrder
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(590, 36)
        LayoutControlItem1.Text = "Production Order"
        LayoutControlItem1.TextSize = New Size(138, 25)
        ' 
        ' LayoutControlItem2
        ' 
        LayoutControlItem2.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        LayoutControlItem2.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem2.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem2.Control = _02cAlasanBatal
        LayoutControlItem2.Location = New Point(0, 36)
        LayoutControlItem2.Name = "LayoutControlItem2"
        LayoutControlItem2.Size = New Size(1180, 30)
        LayoutControlItem2.Text = "Alasan Batal"
        LayoutControlItem2.TextSize = New Size(138, 25)
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.AllowHotTrack = False
        EmptySpaceItem1.Location = New Point(1032, 0)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(148, 36)
        EmptySpaceItem1.TextSize = New Size(0, 0)
        ' 
        ' LayoutControlItem3
        ' 
        LayoutControlItem3.Control = _otblProsesBatal
        LayoutControlItem3.Location = New Point(590, 0)
        LayoutControlItem3.Name = "LayoutControlItem3"
        LayoutControlItem3.Size = New Size(226, 36)
        LayoutControlItem3.TextSize = New Size(0, 0)
        LayoutControlItem3.TextVisible = False
        ' 
        ' LayoutControlItem4
        ' 
        LayoutControlItem4.Control = _otblClear
        LayoutControlItem4.Location = New Point(816, 0)
        LayoutControlItem4.Name = "LayoutControlItem4"
        LayoutControlItem4.Size = New Size(216, 36)
        LayoutControlItem4.TextSize = New Size(0, 0)
        LayoutControlItem4.TextVisible = False
        ' 
        ' _gdPOBatal
        ' 
        _gdPOBatal._prop01TargetTransaksi = SKK02OBJECTS.ucGridTransaction.TargetTransaksi._01MD23BB01BULKORDER
        _gdPOBatal._prop02pdtDataSourceGrid = Nothing
        _gdPOBatal._prop03pdtSBUMasterGEMINI = Nothing
        _gdPOBatal._prop04pdtTableMasterGEMINI = Nothing
        _gdPOBatal.Location = New Point(12, 78)
        _gdPOBatal.Name = "_gdPOBatal"
        _gdPOBatal.Size = New Size(1176, 582)
        _gdPOBatal.TabIndex = 8
        ' 
        ' LayoutControlItem5
        ' 
        LayoutControlItem5.Control = _gdPOBatal
        LayoutControlItem5.Location = New Point(0, 66)
        LayoutControlItem5.Name = "LayoutControlItem5"
        LayoutControlItem5.Size = New Size(1180, 586)
        LayoutControlItem5.TextSize = New Size(0, 0)
        LayoutControlItem5.TextVisible = False
        ' 
        ' ucMD23DQ01CANCELPRODUCTIONORDER
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Name = "ucMD23DQ01CANCELPRODUCTIONORDER"
        Size = New Size(1200, 672)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(_02cAlasanBatal.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_01cKodeProductionOrder.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlgeminiMaster1View, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _02cAlasanBatal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _01cKodeProductionOrder As SKK02OBJECTS.ctrlGEMINIMaster
    Friend WithEvents CtrlgeminiMaster1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _otblClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents _otblProsesBatal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _gdPOBatal As SKK02OBJECTS.ucGridTransaction
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
