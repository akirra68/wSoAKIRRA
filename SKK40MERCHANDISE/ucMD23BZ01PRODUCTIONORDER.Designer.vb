<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMD23BZ01PRODUCTIONORDER
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
        _01cTipeProduksiNew = New DevExpress.XtraEditors.SearchLookUpEdit()
        SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        _gdProductionOrder = New SKK02OBJECTS.ucGridTransactionParentChild()
        _02dTglProductionOrder = New DevExpress.XtraEditors.DateEdit()
        _otblClear = New DevExpress.XtraEditors.SimpleButton()
        _otblSave = New DevExpress.XtraEditors.SimpleButton()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CtrlgeminiMaster1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(_01cTipeProduksiNew.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(SearchLookUpEdit1View, ComponentModel.ISupportInitialize).BeginInit()
        CType(_02dTglProductionOrder.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_02dTglProductionOrder.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem3, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem6, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem7, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlgeminiMaster1View, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_01cTipeProduksiNew)
        LayoutControl1.Controls.Add(_gdProductionOrder)
        LayoutControl1.Controls.Add(_02dTglProductionOrder)
        LayoutControl1.Controls.Add(_otblClear)
        LayoutControl1.Controls.Add(_otblSave)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Margin = New Padding(2, 2, 2, 2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1177, 430)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _01cTipeProduksiNew
        ' 
        _01cTipeProduksiNew.Location = New Point(406, 8)
        _01cTipeProduksiNew.Margin = New Padding(2, 2, 2, 2)
        _01cTipeProduksiNew.Name = "_01cTipeProduksiNew"
        _01cTipeProduksiNew.Properties.Appearance.Font = New Font("Courier New", 10F, FontStyle.Bold)
        _01cTipeProduksiNew.Properties.Appearance.Options.UseFont = True
        _01cTipeProduksiNew.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _01cTipeProduksiNew.Properties.PopupView = SearchLookUpEdit1View
        _01cTipeProduksiNew.Size = New Size(270, 22)
        _01cTipeProduksiNew.StyleController = LayoutControl1
        _01cTipeProduksiNew.TabIndex = 6
        ' 
        ' SearchLookUpEdit1View
        ' 
        SearchLookUpEdit1View.DetailHeight = 239
        SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 533
        SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        ' 
        ' _gdProductionOrder
        ' 
        _gdProductionOrder._prop01TargetTransaksi = SKK02OBJECTS.ucGridTransactionParentChild.TargetTransaksi._01MD23BZ01PRODUCTIONORDER
        _gdProductionOrder._prop01User = Nothing
        _gdProductionOrder._prop02pdtDataSourceGrid = Nothing
        _gdProductionOrder._prop03pdtDataSet = Nothing
        _gdProductionOrder._prop10String = Nothing
        _gdProductionOrder._prop11String = Nothing
        _gdProductionOrder.Location = New Point(8, 33)
        _gdProductionOrder.Margin = New Padding(1, 1, 1, 1)
        _gdProductionOrder.Name = "_gdProductionOrder"
        _gdProductionOrder.Size = New Size(1161, 389)
        _gdProductionOrder.TabIndex = 5
        ' 
        ' _02dTglProductionOrder
        ' 
        _02dTglProductionOrder.EditValue = Nothing
        _02dTglProductionOrder.Location = New Point(131, 8)
        _02dTglProductionOrder.Margin = New Padding(2, 2, 2, 2)
        _02dTglProductionOrder.Name = "_02dTglProductionOrder"
        _02dTglProductionOrder.Properties.Appearance.Font = New Font("Courier New", 10F, FontStyle.Bold)
        _02dTglProductionOrder.Properties.Appearance.Options.UseFont = True
        _02dTglProductionOrder.Properties.AppearanceReadOnly.BackColor = Color.Green
        _02dTglProductionOrder.Properties.AppearanceReadOnly.Font = New Font("Courier New", 9F)
        _02dTglProductionOrder.Properties.AppearanceReadOnly.ForeColor = Color.White
        _02dTglProductionOrder.Properties.AppearanceReadOnly.Options.UseBackColor = True
        _02dTglProductionOrder.Properties.AppearanceReadOnly.Options.UseFont = True
        _02dTglProductionOrder.Properties.AppearanceReadOnly.Options.UseForeColor = True
        _02dTglProductionOrder.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _02dTglProductionOrder.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _02dTglProductionOrder.Properties.ReadOnly = True
        _02dTglProductionOrder.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _02dTglProductionOrder.Size = New Size(150, 22)
        _02dTglProductionOrder.StyleController = LayoutControl1
        _02dTglProductionOrder.TabIndex = 0
        ' 
        ' _otblClear
        ' 
        _otblClear.Appearance.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        _otblClear.Appearance.ForeColor = Color.Navy
        _otblClear.Appearance.Options.UseFont = True
        _otblClear.Appearance.Options.UseForeColor = True
        _otblClear.Location = New Point(856, 8)
        _otblClear.Margin = New Padding(2, 2, 2, 2)
        _otblClear.Name = "_otblClear"
        _otblClear.Size = New Size(164, 23)
        _otblClear.StyleController = LayoutControl1
        _otblClear.TabIndex = 3
        _otblClear.Text = "Clear"
        ' 
        ' _otblSave
        ' 
        _otblSave.Appearance.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        _otblSave.Appearance.ForeColor = Color.Navy
        _otblSave.Appearance.Options.UseFont = True
        _otblSave.Appearance.Options.UseForeColor = True
        _otblSave.Location = New Point(689, 8)
        _otblSave.Margin = New Padding(2, 2, 2, 2)
        _otblSave.Name = "_otblSave"
        _otblSave.Size = New Size(165, 23)
        _otblSave.StyleController = LayoutControl1
        _otblSave.TabIndex = 2
        _otblSave.Text = "Save"
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {EmptySpaceItem2, EmptySpaceItem3, LayoutControlItem2, LayoutControlItem3, LayoutControlItem5, LayoutControlItem6, LayoutControlItem7, EmptySpaceItem4, LayoutControlItem4})
        Root.Name = "Root"
        Root.Size = New Size(1177, 430)
        Root.TextVisible = False
        ' 
        ' EmptySpaceItem2
        ' 
        EmptySpaceItem2.Location = New Point(1116, 0)
        EmptySpaceItem2.Name = "EmptySpaceItem2"
        EmptySpaceItem2.Size = New Size(10, 25)
        ' 
        ' EmptySpaceItem3
        ' 
        EmptySpaceItem3.Location = New Point(670, 0)
        EmptySpaceItem3.MaxSize = New Size(11, 25)
        EmptySpaceItem3.MinSize = New Size(11, 25)
        EmptySpaceItem3.Name = "EmptySpaceItem3"
        EmptySpaceItem3.Size = New Size(11, 25)
        EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        ' 
        ' LayoutControlItem2
        ' 
        LayoutControlItem2.Control = _otblSave
        LayoutControlItem2.Location = New Point(681, 0)
        LayoutControlItem2.MaxSize = New Size(167, 25)
        LayoutControlItem2.MinSize = New Size(167, 25)
        LayoutControlItem2.Name = "LayoutControlItem2"
        LayoutControlItem2.Size = New Size(167, 25)
        LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        LayoutControlItem2.TextSize = New Size(0, 0)
        LayoutControlItem2.TextVisible = False
        ' 
        ' LayoutControlItem3
        ' 
        LayoutControlItem3.Control = _otblClear
        LayoutControlItem3.Location = New Point(848, 0)
        LayoutControlItem3.MaxSize = New Size(166, 25)
        LayoutControlItem3.MinSize = New Size(166, 25)
        LayoutControlItem3.Name = "LayoutControlItem3"
        LayoutControlItem3.Size = New Size(166, 25)
        LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        LayoutControlItem3.TextSize = New Size(0, 0)
        LayoutControlItem3.TextVisible = False
        ' 
        ' LayoutControlItem5
        ' 
        LayoutControlItem5.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F)
        LayoutControlItem5.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem5.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem5.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem5.Control = _02dTglProductionOrder
        LayoutControlItem5.Location = New Point(0, 0)
        LayoutControlItem5.Name = "LayoutControlItem5"
        LayoutControlItem5.Size = New Size(275, 25)
        LayoutControlItem5.Text = "Tgl. Production Order"
        ' 
        ' LayoutControlItem6
        ' 
        LayoutControlItem6.Control = _gdProductionOrder
        LayoutControlItem6.Location = New Point(0, 25)
        LayoutControlItem6.Name = "LayoutControlItem6"
        LayoutControlItem6.Size = New Size(1163, 391)
        LayoutControlItem6.TextSize = New Size(0, 0)
        LayoutControlItem6.TextVisible = False
        ' 
        ' LayoutControlItem7
        ' 
        LayoutControlItem7.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F)
        LayoutControlItem7.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem7.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem7.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem7.Control = _01cTipeProduksiNew
        LayoutControlItem7.Location = New Point(275, 0)
        LayoutControlItem7.Name = "LayoutControlItem7"
        LayoutControlItem7.Size = New Size(395, 25)
        LayoutControlItem7.Text = "Tipe Produksi"
        ' 
        ' EmptySpaceItem4
        ' 
        EmptySpaceItem4.Location = New Point(1126, 0)
        EmptySpaceItem4.Name = "EmptySpaceItem4"
        EmptySpaceItem4.Size = New Size(37, 25)
        ' 
        ' LayoutControlItem4
        ' 
        LayoutControlItem4.Location = New Point(1014, 0)
        LayoutControlItem4.Name = "LayoutControlItem4"
        LayoutControlItem4.Size = New Size(102, 25)
        LayoutControlItem4.TextSize = New Size(0, 0)
        LayoutControlItem4.TextVisible = False
        ' 
        ' GridView1
        ' 
        GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridView1.Name = "GridView1"
        GridView1.OptionsNavigation.UseTabKey = False
        GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' CtrlgeminiMaster1View
        ' 
        CtrlgeminiMaster1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlgeminiMaster1View.Name = "CtrlgeminiMaster1View"
        CtrlgeminiMaster1View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlgeminiMaster1View.OptionsView.ShowGroupPanel = False
        ' 
        ' ucMD23BZ01PRODUCTIONORDER
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Margin = New Padding(2, 2, 2, 2)
        Name = "ucMD23BZ01PRODUCTIONORDER"
        Size = New Size(1177, 430)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(_01cTipeProduksiNew.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(SearchLookUpEdit1View, ComponentModel.ISupportInitialize).EndInit()
        CType(_02dTglProductionOrder.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(_02dTglProductionOrder.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem3, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem3, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem6, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem7, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem4, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlgeminiMaster1View, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _otblClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents _otblSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CtrlgeminiMaster1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _02dTglProductionOrder As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents _gdProductionOrder As SKK02OBJECTS.ucGridTransactionParentChild
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _01cTipeProduksiNew As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
End Class
