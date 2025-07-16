<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS24FK01TRANSAKSIWAREHOUSE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS24FK01TRANSAKSIWAREHOUSE))
        Dim WindowsuiButtonImageOptions1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim WindowsuiButtonImageOptions2 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _04cSKUTransaksi = New DevExpress.XtraEditors.TextEdit()
        _gdTransaksi = New SKK02OBJECTS.ucWSGrid()
        WindowsuiButtonPanel1 = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        _03KAETujuan = New SKK02OBJECTS.ctrlWSNasaMaster()
        CtrlwsNasaMaster3View = New DevExpress.XtraGrid.Views.Grid.GridView()
        _02cSupplierKAEAsal = New SKK02OBJECTS.ctrlWSNasaMaster()
        CtrlwsNasaMaster2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        _01cTargetTransaksiWS = New SKK02OBJECTS.ctrlWSNasaMaster()
        CtrlwsNasaMaster1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        _lay02cSupplierKAEAsal = New DevExpress.XtraLayout.LayoutControlItem()
        _lay03KAETujuan = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        _lay04cSKUTransaksi = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(_04cSKUTransaksi.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_03KAETujuan.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlwsNasaMaster3View, ComponentModel.ISupportInitialize).BeginInit()
        CType(_02cSupplierKAEAsal.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlwsNasaMaster2View, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01cTargetTransaksiWS.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlwsNasaMaster1View, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay02cSupplierKAEAsal, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay03KAETujuan, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem6, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay04cSKUTransaksi, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_04cSKUTransaksi)
        LayoutControl1.Controls.Add(_gdTransaksi)
        LayoutControl1.Controls.Add(WindowsuiButtonPanel1)
        LayoutControl1.Controls.Add(_03KAETujuan)
        LayoutControl1.Controls.Add(_02cSupplierKAEAsal)
        LayoutControl1.Controls.Add(_01cTargetTransaksiWS)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Margin = New Padding(2, 2, 2, 2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(771, 432)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _04cSKUTransaksi
        ' 
        _04cSKUTransaksi.Location = New Point(702, 8)
        _04cSKUTransaksi.Margin = New Padding(2, 2, 2, 2)
        _04cSKUTransaksi.Name = "_04cSKUTransaksi"
        _04cSKUTransaksi.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _04cSKUTransaksi.Properties.Appearance.Options.UseFont = True
        _04cSKUTransaksi.Size = New Size(51, 22)
        _04cSKUTransaksi.StyleController = LayoutControl1
        _04cSKUTransaksi.TabIndex = 3
        ' 
        ' _gdTransaksi
        ' 
        _gdTransaksi._prop01User = Nothing
        _gdTransaksi._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdTransaksi._prop04Date = New Date(0L)
        _gdTransaksi._prop05String = Nothing
        _gdTransaksi._prop06String = Nothing
        _gdTransaksi._prop07String = Nothing
        _gdTransaksi._prop11objSpinEdit = Nothing
        _gdTransaksi._prop12objSpinEdit = Nothing
        _gdTransaksi.Location = New Point(8, 80)
        _gdTransaksi.Margin = New Padding(1, 1, 1, 1)
        _gdTransaksi.Name = "_gdTransaksi"
        _gdTransaksi.Size = New Size(755, 344)
        _gdTransaksi.TabIndex = 6
        ' 
        ' WindowsuiButtonPanel1
        ' 
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Font = New Font("Nirmala UI", 10F, FontStyle.Italic)
        WindowsuiButtonPanel1.AppearanceButton.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Options.UseFont = True
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Options.UseForeColor = True
        WindowsuiButtonPanel1.AppearanceButton.Normal.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        WindowsuiButtonPanel1.AppearanceButton.Normal.ForeColor = Color.Navy
        WindowsuiButtonPanel1.AppearanceButton.Normal.Options.UseFont = True
        WindowsuiButtonPanel1.AppearanceButton.Normal.Options.UseForeColor = True
        WindowsuiButtonPanel1.AppearanceButton.Pressed.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        WindowsuiButtonPanel1.AppearanceButton.Pressed.ForeColor = Color.Green
        WindowsuiButtonPanel1.AppearanceButton.Pressed.Options.UseFont = True
        WindowsuiButtonPanel1.AppearanceButton.Pressed.Options.UseForeColor = True
        WindowsuiButtonImageOptions1.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonImageOptions2.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions2.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonPanel1.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", True, WindowsuiButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, 100S, -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("Clear", True, WindowsuiButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, 200S, -1, False)})
        WindowsuiButtonPanel1.Location = New Point(433, 8)
        WindowsuiButtonPanel1.Margin = New Padding(2, 2, 2, 2)
        WindowsuiButtonPanel1.Name = "WindowsuiButtonPanel1"
        WindowsuiButtonPanel1.Size = New Size(111, 59)
        WindowsuiButtonPanel1.TabIndex = 2
        WindowsuiButtonPanel1.Text = "WindowsuiButtonPanel1"
        ' 
        ' _03KAETujuan
        ' 
        _03KAETujuan._prop02WSDaftarField = Nothing
        _03KAETujuan._prop03WSFieldYgDiFilter = Nothing
        _03KAETujuan._prop04WSValueKodeMasterYgDiFilter = Nothing
        _03KAETujuan._prop05WSFieldValueMember = Nothing
        _03KAETujuan._prop06WSFieldDisplayMember = Nothing
        _03KAETujuan._prop07WSKeyKolomFilterUntSelect = Nothing
        _03KAETujuan.Location = New Point(164, 56)
        _03KAETujuan.Margin = New Padding(2, 2, 2, 2)
        _03KAETujuan.Name = "_03KAETujuan"
        _03KAETujuan.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _03KAETujuan.Properties.Appearance.Options.UseFont = True
        _03KAETujuan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _03KAETujuan.Properties.NullText = ""
        _03KAETujuan.Properties.PopupView = CtrlwsNasaMaster3View
        _03KAETujuan.Size = New Size(267, 22)
        _03KAETujuan.StyleController = LayoutControl1
        _03KAETujuan.TabIndex = 5
        ' 
        ' CtrlwsNasaMaster3View
        ' 
        CtrlwsNasaMaster3View.DetailHeight = 239
        CtrlwsNasaMaster3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlwsNasaMaster3View.Name = "CtrlwsNasaMaster3View"
        CtrlwsNasaMaster3View.OptionsEditForm.PopupEditFormWidth = 533
        CtrlwsNasaMaster3View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlwsNasaMaster3View.OptionsView.ShowGroupPanel = False
        ' 
        ' _02cSupplierKAEAsal
        ' 
        _02cSupplierKAEAsal._prop02WSDaftarField = Nothing
        _02cSupplierKAEAsal._prop03WSFieldYgDiFilter = Nothing
        _02cSupplierKAEAsal._prop04WSValueKodeMasterYgDiFilter = Nothing
        _02cSupplierKAEAsal._prop05WSFieldValueMember = Nothing
        _02cSupplierKAEAsal._prop06WSFieldDisplayMember = Nothing
        _02cSupplierKAEAsal._prop07WSKeyKolomFilterUntSelect = Nothing
        _02cSupplierKAEAsal.Location = New Point(164, 32)
        _02cSupplierKAEAsal.Margin = New Padding(2, 2, 2, 2)
        _02cSupplierKAEAsal.Name = "_02cSupplierKAEAsal"
        _02cSupplierKAEAsal.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _02cSupplierKAEAsal.Properties.Appearance.Options.UseFont = True
        _02cSupplierKAEAsal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _02cSupplierKAEAsal.Properties.NullText = ""
        _02cSupplierKAEAsal.Properties.PopupView = CtrlwsNasaMaster2View
        _02cSupplierKAEAsal.Size = New Size(267, 22)
        _02cSupplierKAEAsal.StyleController = LayoutControl1
        _02cSupplierKAEAsal.TabIndex = 4
        ' 
        ' CtrlwsNasaMaster2View
        ' 
        CtrlwsNasaMaster2View.DetailHeight = 239
        CtrlwsNasaMaster2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlwsNasaMaster2View.Name = "CtrlwsNasaMaster2View"
        CtrlwsNasaMaster2View.OptionsEditForm.PopupEditFormWidth = 533
        CtrlwsNasaMaster2View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlwsNasaMaster2View.OptionsView.ShowGroupPanel = False
        ' 
        ' _01cTargetTransaksiWS
        ' 
        _01cTargetTransaksiWS._prop02WSDaftarField = Nothing
        _01cTargetTransaksiWS._prop03WSFieldYgDiFilter = Nothing
        _01cTargetTransaksiWS._prop04WSValueKodeMasterYgDiFilter = Nothing
        _01cTargetTransaksiWS._prop05WSFieldValueMember = Nothing
        _01cTargetTransaksiWS._prop06WSFieldDisplayMember = Nothing
        _01cTargetTransaksiWS._prop07WSKeyKolomFilterUntSelect = Nothing
        _01cTargetTransaksiWS.Location = New Point(164, 8)
        _01cTargetTransaksiWS.Margin = New Padding(2, 2, 2, 2)
        _01cTargetTransaksiWS.Name = "_01cTargetTransaksiWS"
        _01cTargetTransaksiWS.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _01cTargetTransaksiWS.Properties.Appearance.Options.UseFont = True
        _01cTargetTransaksiWS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _01cTargetTransaksiWS.Properties.NullText = ""
        _01cTargetTransaksiWS.Properties.PopupView = CtrlwsNasaMaster1View
        _01cTargetTransaksiWS.Size = New Size(267, 22)
        _01cTargetTransaksiWS.StyleController = LayoutControl1
        _01cTargetTransaksiWS.TabIndex = 0
        ' 
        ' CtrlwsNasaMaster1View
        ' 
        CtrlwsNasaMaster1View.DetailHeight = 239
        CtrlwsNasaMaster1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlwsNasaMaster1View.Name = "CtrlwsNasaMaster1View"
        CtrlwsNasaMaster1View.OptionsEditForm.PopupEditFormWidth = 533
        CtrlwsNasaMaster1View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlwsNasaMaster1View.OptionsView.ShowGroupPanel = False
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1, _lay02cSupplierKAEAsal, _lay03KAETujuan, LayoutControlItem5, LayoutControlItem6, EmptySpaceItem1, _lay04cSKUTransaksi, EmptySpaceItem2})
        Root.Name = "Root"
        Root.Size = New Size(771, 432)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F)
        LayoutControlItem1.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem1.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem1.Control = _01cTargetTransaksiWS
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(425, 24)
        LayoutControlItem1.Text = "Target Transaksi Warehouse"
        ' 
        ' _lay02cSupplierKAEAsal
        ' 
        _lay02cSupplierKAEAsal.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F)
        _lay02cSupplierKAEAsal.AppearanceItemCaption.ForeColor = Color.Navy
        _lay02cSupplierKAEAsal.AppearanceItemCaption.Options.UseFont = True
        _lay02cSupplierKAEAsal.AppearanceItemCaption.Options.UseForeColor = True
        _lay02cSupplierKAEAsal.Control = _02cSupplierKAEAsal
        _lay02cSupplierKAEAsal.Location = New Point(0, 24)
        _lay02cSupplierKAEAsal.Name = "_lay02cSupplierKAEAsal"
        _lay02cSupplierKAEAsal.Size = New Size(425, 24)
        _lay02cSupplierKAEAsal.Text = "Supplier / Asal Location"
        ' 
        ' _lay03KAETujuan
        ' 
        _lay03KAETujuan.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F)
        _lay03KAETujuan.AppearanceItemCaption.ForeColor = Color.Navy
        _lay03KAETujuan.AppearanceItemCaption.Options.UseFont = True
        _lay03KAETujuan.AppearanceItemCaption.Options.UseForeColor = True
        _lay03KAETujuan.Control = _03KAETujuan
        _lay03KAETujuan.Location = New Point(0, 48)
        _lay03KAETujuan.Name = "_lay03KAETujuan"
        _lay03KAETujuan.Size = New Size(425, 24)
        _lay03KAETujuan.Text = "Tujuan Location"
        ' 
        ' LayoutControlItem5
        ' 
        LayoutControlItem5.Control = WindowsuiButtonPanel1
        LayoutControlItem5.Location = New Point(425, 0)
        LayoutControlItem5.Name = "LayoutControlItem5"
        LayoutControlItem5.Size = New Size(113, 72)
        LayoutControlItem5.TextSize = New Size(0, 0)
        LayoutControlItem5.TextVisible = False
        ' 
        ' LayoutControlItem6
        ' 
        LayoutControlItem6.Control = _gdTransaksi
        LayoutControlItem6.Location = New Point(0, 72)
        LayoutControlItem6.Name = "LayoutControlItem6"
        LayoutControlItem6.Size = New Size(757, 346)
        LayoutControlItem6.TextSize = New Size(0, 0)
        LayoutControlItem6.TextVisible = False
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(538, 24)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(209, 48)
        ' 
        ' _lay04cSKUTransaksi
        ' 
        _lay04cSKUTransaksi.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F)
        _lay04cSKUTransaksi.AppearanceItemCaption.ForeColor = Color.Navy
        _lay04cSKUTransaksi.AppearanceItemCaption.Options.UseFont = True
        _lay04cSKUTransaksi.AppearanceItemCaption.Options.UseForeColor = True
        _lay04cSKUTransaksi.Control = _04cSKUTransaksi
        _lay04cSKUTransaksi.Location = New Point(538, 0)
        _lay04cSKUTransaksi.Name = "_lay04cSKUTransaksi"
        _lay04cSKUTransaksi.Size = New Size(209, 24)
        _lay04cSKUTransaksi.Text = "SKU Transaksi"
        ' 
        ' EmptySpaceItem2
        ' 
        EmptySpaceItem2.Location = New Point(747, 0)
        EmptySpaceItem2.Name = "EmptySpaceItem2"
        EmptySpaceItem2.Size = New Size(10, 72)
        ' 
        ' ucWS24FK01TRANSAKSIWAREHOUSE
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Margin = New Padding(2, 2, 2, 2)
        Name = "ucWS24FK01TRANSAKSIWAREHOUSE"
        Size = New Size(771, 432)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(_04cSKUTransaksi.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_03KAETujuan.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlwsNasaMaster3View, ComponentModel.ISupportInitialize).EndInit()
        CType(_02cSupplierKAEAsal.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlwsNasaMaster2View, ComponentModel.ISupportInitialize).EndInit()
        CType(_01cTargetTransaksiWS.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlwsNasaMaster1View, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay02cSupplierKAEAsal, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay03KAETujuan, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem6, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay04cSKUTransaksi, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _01cTargetTransaksiWS As SKK02OBJECTS.ctrlWSNasaMaster
    Friend WithEvents CtrlwsNasaMaster1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _02cSupplierKAEAsal As SKK02OBJECTS.ctrlWSNasaMaster
    Friend WithEvents CtrlwsNasaMaster2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _lay02cSupplierKAEAsal As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _03KAETujuan As SKK02OBJECTS.ctrlWSNasaMaster
    Friend WithEvents CtrlwsNasaMaster3View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _lay03KAETujuan As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _gdTransaksi As SKK02OBJECTS.ucWSGrid
    Friend WithEvents WindowsuiButtonPanel1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents _04cSKUTransaksi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _lay04cSKUTransaksi As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem

End Class
