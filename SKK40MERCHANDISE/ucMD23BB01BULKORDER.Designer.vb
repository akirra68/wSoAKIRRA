<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucMD23BB01BULKORDER
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucMD23BB01BULKORDER))
        Dim WindowsuiButtonImageOptions1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim WindowsuiButtonImageOptions2 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim WindowsuiButtonImageOptions3 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        oTabDataXLSX = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdDataXLSX = New DevExpress.XtraGrid.GridControl()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        oTabBulkOrder = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        oTabCheckProductCode = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        WindowsuiButtonPanel1 = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        _01cFileXLS = New DevExpress.XtraEditors.ButtonEdit()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        _layProgressBar = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CtrlgeminiMaster2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        CtrlgeminiMaster1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        oTabDataXLSX.SuspendLayout()
        CType(_gdDataXLSX, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(ProgressBarControl1.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01cFileXLS.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(_layProgressBar, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlgeminiMaster2View, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlgeminiMaster1View, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(TabPane1)
        LayoutControl1.Controls.Add(ProgressBarControl1)
        LayoutControl1.Controls.Add(WindowsuiButtonPanel1)
        LayoutControl1.Controls.Add(_01cFileXLS)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Margin = New Padding(2, 2, 2, 2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(741, 460)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' TabPane1
        ' 
        TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True
        TabPane1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 11F, FontStyle.Italic)
        TabPane1.AppearanceButton.Hovered.Options.UseFont = True
        TabPane1.AppearanceButton.Normal.Font = New Font("Nirmala UI Semilight", 10F)
        TabPane1.AppearanceButton.Normal.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Font = New Font("Nirmala UI", 10F, FontStyle.Bold)
        TabPane1.AppearanceButton.Pressed.ForeColor = Color.Navy
        TabPane1.AppearanceButton.Pressed.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Options.UseForeColor = True
        TabPane1.Controls.Add(oTabDataXLSX)
        TabPane1.Controls.Add(oTabBulkOrder)
        TabPane1.Controls.Add(oTabCheckProductCode)
        TabPane1.Location = New Point(8, 72)
        TabPane1.Margin = New Padding(2, 2, 2, 2)
        TabPane1.Name = "TabPane1"
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {oTabDataXLSX, oTabBulkOrder, oTabCheckProductCode})
        TabPane1.RegularSize = New Size(725, 365)
        TabPane1.SelectedPage = oTabDataXLSX
        TabPane1.Size = New Size(725, 365)
        TabPane1.TabIndex = 7
        TabPane1.Text = "Data"
        ' 
        ' oTabDataXLSX
        ' 
        oTabDataXLSX.Caption = "Data XLSX"
        oTabDataXLSX.Controls.Add(_gdDataXLSX)
        oTabDataXLSX.ImageOptions.Image = CType(resources.GetObject("oTabDataXLSX.ImageOptions.Image"), Image)
        oTabDataXLSX.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabDataXLSX.Margin = New Padding(2, 2, 2, 2)
        oTabDataXLSX.Name = "oTabDataXLSX"
        oTabDataXLSX.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabDataXLSX.Size = New Size(725, 322)
        ' 
        ' _gdDataXLSX
        ' 
        _gdDataXLSX.Dock = DockStyle.Fill
        _gdDataXLSX.EmbeddedNavigator.Margin = New Padding(1, 1, 1, 1)
        _gdDataXLSX.Location = New Point(0, 0)
        _gdDataXLSX.MainView = GridView1
        _gdDataXLSX.Margin = New Padding(2, 2, 2, 2)
        _gdDataXLSX.Name = "_gdDataXLSX"
        _gdDataXLSX.Size = New Size(725, 322)
        _gdDataXLSX.TabIndex = 0
        _gdDataXLSX.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        ' 
        ' GridView1
        ' 
        GridView1.Appearance.HeaderPanel.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        GridView1.Appearance.HeaderPanel.Options.UseFont = True
        GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Appearance.Row.Font = New Font("Courier New", 10F)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.DetailHeight = 239
        GridView1.GridControl = _gdDataXLSX
        GridView1.Name = "GridView1"
        GridView1.OptionsBehavior.ReadOnly = True
        GridView1.OptionsEditForm.PopupEditFormWidth = 533
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' oTabBulkOrder
        ' 
        oTabBulkOrder.Caption = "Bulk Order"
        oTabBulkOrder.ImageOptions.Image = CType(resources.GetObject("oTabBulkOrder.ImageOptions.Image"), Image)
        oTabBulkOrder.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabBulkOrder.Margin = New Padding(2, 2, 2, 2)
        oTabBulkOrder.Name = "oTabBulkOrder"
        oTabBulkOrder.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabBulkOrder.Size = New Size(725, 329)
        ' 
        ' oTabCheckProductCode
        ' 
        oTabCheckProductCode.Caption = "Check Product Code"
        oTabCheckProductCode.ImageOptions.Image = CType(resources.GetObject("oTabCheckProductCode.ImageOptions.Image"), Image)
        oTabCheckProductCode.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabCheckProductCode.Margin = New Padding(2, 2, 2, 2)
        oTabCheckProductCode.Name = "oTabCheckProductCode"
        oTabCheckProductCode.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabCheckProductCode.Size = New Size(725, 363)
        ' 
        ' ProgressBarControl1
        ' 
        ProgressBarControl1.Location = New Point(8, 439)
        ProgressBarControl1.Margin = New Padding(2, 2, 2, 2)
        ProgressBarControl1.Name = "ProgressBarControl1"
        ProgressBarControl1.Size = New Size(725, 13)
        ProgressBarControl1.StyleController = LayoutControl1
        ProgressBarControl1.TabIndex = 5
        ' 
        ' WindowsuiButtonPanel1
        ' 
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 11F, FontStyle.Italic)
        WindowsuiButtonPanel1.AppearanceButton.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Options.UseFont = True
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Options.UseForeColor = True
        WindowsuiButtonPanel1.AppearanceButton.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        WindowsuiButtonPanel1.AppearanceButton.Normal.ForeColor = Color.Navy
        WindowsuiButtonPanel1.AppearanceButton.Normal.Options.UseFont = True
        WindowsuiButtonPanel1.AppearanceButton.Normal.Options.UseForeColor = True
        WindowsuiButtonPanel1.AppearanceButton.Pressed.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        WindowsuiButtonPanel1.AppearanceButton.Pressed.Options.UseFont = True
        WindowsuiButtonImageOptions1.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonImageOptions2.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions2.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonImageOptions3.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions3.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonPanel1.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", True, WindowsuiButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, 100S, -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("Clear", True, WindowsuiButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, 200S, -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("Grid", True, WindowsuiButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, 300S, -1, False)})
        WindowsuiButtonPanel1.Location = New Point(431, 8)
        WindowsuiButtonPanel1.Margin = New Padding(2, 2, 2, 2)
        WindowsuiButtonPanel1.Name = "WindowsuiButtonPanel1"
        WindowsuiButtonPanel1.Size = New Size(168, 62)
        WindowsuiButtonPanel1.TabIndex = 2
        WindowsuiButtonPanel1.Text = "WindowsuiButtonPanel1"
        ' 
        ' _01cFileXLS
        ' 
        _01cFileXLS.Location = New Point(100, 8)
        _01cFileXLS.Margin = New Padding(2, 2, 2, 2)
        _01cFileXLS.Name = "_01cFileXLS"
        _01cFileXLS.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _01cFileXLS.Properties.Appearance.Options.UseFont = True
        _01cFileXLS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        _01cFileXLS.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _01cFileXLS.Size = New Size(319, 22)
        _01cFileXLS.StyleController = LayoutControl1
        _01cFileXLS.TabIndex = 0
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1, LayoutControlItem4, EmptySpaceItem1, EmptySpaceItem2, _layProgressBar, LayoutControlItem5})
        Root.Name = "Root"
        Root.Size = New Size(741, 460)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F)
        LayoutControlItem1.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem1.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem1.Control = _01cFileXLS
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(413, 64)
        LayoutControlItem1.Text = "File Excel - XLSX"
        ' 
        ' LayoutControlItem4
        ' 
        LayoutControlItem4.Control = WindowsuiButtonPanel1
        LayoutControlItem4.Location = New Point(423, 0)
        LayoutControlItem4.Name = "LayoutControlItem4"
        LayoutControlItem4.Size = New Size(170, 64)
        LayoutControlItem4.TextSize = New Size(0, 0)
        LayoutControlItem4.TextVisible = False
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(593, 0)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(134, 64)
        ' 
        ' EmptySpaceItem2
        ' 
        EmptySpaceItem2.Location = New Point(413, 0)
        EmptySpaceItem2.Name = "EmptySpaceItem2"
        EmptySpaceItem2.Size = New Size(10, 64)
        ' 
        ' _layProgressBar
        ' 
        _layProgressBar.Control = ProgressBarControl1
        _layProgressBar.Location = New Point(0, 431)
        _layProgressBar.Name = "_layProgressBar"
        _layProgressBar.Size = New Size(727, 15)
        _layProgressBar.TextSize = New Size(0, 0)
        _layProgressBar.TextVisible = False
        _layProgressBar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        ' 
        ' LayoutControlItem5
        ' 
        LayoutControlItem5.Control = TabPane1
        LayoutControlItem5.Location = New Point(0, 64)
        LayoutControlItem5.Name = "LayoutControlItem5"
        LayoutControlItem5.Size = New Size(727, 367)
        LayoutControlItem5.TextSize = New Size(0, 0)
        LayoutControlItem5.TextVisible = False
        ' 
        ' CtrlgeminiMaster2View
        ' 
        CtrlgeminiMaster2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlgeminiMaster2View.Name = "CtrlgeminiMaster2View"
        CtrlgeminiMaster2View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlgeminiMaster2View.OptionsView.ShowGroupPanel = False
        ' 
        ' CtrlgeminiMaster1View
        ' 
        CtrlgeminiMaster1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlgeminiMaster1View.Name = "CtrlgeminiMaster1View"
        CtrlgeminiMaster1View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlgeminiMaster1View.OptionsView.ShowGroupPanel = False
        ' 
        ' ucMD23BB01BULKORDER
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Margin = New Padding(2, 2, 2, 2)
        Name = "ucMD23BB01BULKORDER"
        Size = New Size(741, 460)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        oTabDataXLSX.ResumeLayout(False)
        CType(_gdDataXLSX, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(ProgressBarControl1.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_01cFileXLS.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(_layProgressBar, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlgeminiMaster2View, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlgeminiMaster1View, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _01cFileXLS As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents CtrlgeminiMaster2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CtrlgeminiMaster1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents WindowsuiButtonPanel1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents _layProgressBar As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents UcGridTransaction1 As SKK02OBJECTS.ucGridTransaction
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents oTabDataXLSX As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents oTabBulkOrder As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _gdDataXLSX As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents oTabCheckProductCode As DevExpress.XtraBars.Navigation.TabNavigationPage
End Class
