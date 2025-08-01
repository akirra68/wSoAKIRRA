<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class uc24IX01BULKUPLOAD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc24IX01BULKUPLOAD))
        Dim WindowsuiButtonImageOptions1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim WindowsuiButtonImageOptions2 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _lblTitle = New Label()
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        oTabDataXLSX = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdXLSX = New DevExpress.XtraGrid.GridControl()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        WindowsuiButtonPanel1 = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        _01cFileXLS = New DevExpress.XtraEditors.ButtonEdit()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        CtrlgeminiMaster2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        CtrlgeminiMaster1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        oTabDataXLSX.SuspendLayout()
        CType(_gdXLSX, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01cFileXLS.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem3, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlgeminiMaster2View, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlgeminiMaster1View, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_lblTitle)
        LayoutControl1.Controls.Add(TabPane1)
        LayoutControl1.Controls.Add(WindowsuiButtonPanel1)
        LayoutControl1.Controls.Add(_01cFileXLS)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Margin = New Padding(2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(886, 492)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _lblTitle
        ' 
        _lblTitle.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        _lblTitle.ForeColor = Color.Navy
        _lblTitle.Location = New Point(581, 22)
        _lblTitle.Name = "_lblTitle"
        _lblTitle.Size = New Size(293, 39)
        _lblTitle.TabIndex = 1
        _lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TabPane1
        ' 
        TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True
        TabPane1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 11F, FontStyle.Italic)
        TabPane1.AppearanceButton.Hovered.Options.UseFont = True
        TabPane1.AppearanceButton.Normal.Font = New Font("Nirmala UI Semilight", 10F)
        TabPane1.AppearanceButton.Normal.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TabPane1.AppearanceButton.Pressed.ForeColor = Color.Navy
        TabPane1.AppearanceButton.Pressed.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Options.UseForeColor = True
        TabPane1.Controls.Add(oTabDataXLSX)
        TabPane1.Location = New Point(12, 75)
        TabPane1.Margin = New Padding(2)
        TabPane1.Name = "TabPane1"
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {oTabDataXLSX})
        TabPane1.RegularSize = New Size(862, 405)
        TabPane1.SelectedPage = oTabDataXLSX
        TabPane1.Size = New Size(862, 405)
        TabPane1.TabIndex = 3
        TabPane1.Text = "Data"
        ' 
        ' oTabDataXLSX
        ' 
        oTabDataXLSX.Caption = "Data XLSX"
        oTabDataXLSX.Controls.Add(_gdXLSX)
        oTabDataXLSX.ImageOptions.Image = CType(resources.GetObject("oTabDataXLSX.ImageOptions.Image"), Image)
        oTabDataXLSX.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabDataXLSX.Margin = New Padding(2)
        oTabDataXLSX.Name = "oTabDataXLSX"
        oTabDataXLSX.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        oTabDataXLSX.Size = New Size(862, 362)
        ' 
        ' _gdXLSX
        ' 
        _gdXLSX.Dock = DockStyle.Fill
        _gdXLSX.Location = New Point(0, 0)
        _gdXLSX.MainView = GridView1
        _gdXLSX.Name = "_gdXLSX"
        _gdXLSX.Size = New Size(862, 362)
        _gdXLSX.TabIndex = 0
        _gdXLSX.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        ' 
        ' GridView1
        ' 
        GridView1.Appearance.HeaderPanel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GridView1.Appearance.HeaderPanel.ForeColor = Color.Navy
        GridView1.Appearance.HeaderPanel.Options.UseFont = True
        GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        GridView1.Appearance.Row.Font = New Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridView1.Appearance.Row.ForeColor = Color.Navy
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.Appearance.Row.Options.UseForeColor = True
        GridView1.GridControl = _gdXLSX
        GridView1.Name = "GridView1"
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' WindowsuiButtonPanel1
        ' 
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        WindowsuiButtonPanel1.AppearanceButton.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Options.UseFont = True
        WindowsuiButtonPanel1.AppearanceButton.Hovered.Options.UseForeColor = True
        WindowsuiButtonPanel1.AppearanceButton.Normal.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        WindowsuiButtonPanel1.AppearanceButton.Normal.ForeColor = Color.Navy
        WindowsuiButtonPanel1.AppearanceButton.Normal.Options.UseFont = True
        WindowsuiButtonPanel1.AppearanceButton.Normal.Options.UseForeColor = True
        WindowsuiButtonPanel1.AppearanceButton.Pressed.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        WindowsuiButtonPanel1.AppearanceButton.Pressed.Options.UseFont = True
        WindowsuiButtonImageOptions1.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonImageOptions2.SvgImage = CType(resources.GetObject("WindowsuiButtonImageOptions2.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsuiButtonPanel1.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", True, WindowsuiButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, 100S, -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("Clear", True, WindowsuiButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, 200S, -1, False)})
        WindowsuiButtonPanel1.Location = New Point(475, 12)
        WindowsuiButtonPanel1.Margin = New Padding(2)
        WindowsuiButtonPanel1.Name = "WindowsuiButtonPanel1"
        WindowsuiButtonPanel1.Size = New Size(102, 59)
        WindowsuiButtonPanel1.TabIndex = 2
        WindowsuiButtonPanel1.Text = "WindowsuiButtonPanel1"
        ' 
        ' _01cFileXLS
        ' 
        _01cFileXLS.Location = New Point(80, 12)
        _01cFileXLS.Margin = New Padding(2)
        _01cFileXLS.Name = "_01cFileXLS"
        _01cFileXLS.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.False
        _01cFileXLS.Properties.Appearance.Font = New Font("Cambria", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        _01cFileXLS.Properties.Appearance.ForeColor = Color.DarkSlateGray
        _01cFileXLS.Properties.Appearance.Options.UseFont = True
        _01cFileXLS.Properties.Appearance.Options.UseForeColor = True
        _01cFileXLS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        _01cFileXLS.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _01cFileXLS.Size = New Size(349, 20)
        _01cFileXLS.StyleController = LayoutControl1
        _01cFileXLS.TabIndex = 0
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1, LayoutControlItem4, EmptySpaceItem1, EmptySpaceItem2, LayoutControlItem5, EmptySpaceItem3, LayoutControlItem2, EmptySpaceItem4})
        Root.Name = "Root"
        Root.Size = New Size(886, 492)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.AppearanceItemCaption.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LayoutControlItem1.AppearanceItemCaption.ForeColor = Color.Navy
        LayoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        LayoutControlItem1.AppearanceItemCaption.Options.UseForeColor = True
        LayoutControlItem1.Control = _01cFileXLS
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(421, 24)
        LayoutControlItem1.Text = "XLSX Files:"
        ' 
        ' LayoutControlItem4
        ' 
        LayoutControlItem4.Control = WindowsuiButtonPanel1
        LayoutControlItem4.Location = New Point(463, 0)
        LayoutControlItem4.Name = "LayoutControlItem4"
        LayoutControlItem4.Size = New Size(106, 63)
        LayoutControlItem4.TextSize = New Size(0, 0)
        LayoutControlItem4.TextVisible = False
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(569, 53)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(297, 10)
        ' 
        ' EmptySpaceItem2
        ' 
        EmptySpaceItem2.Location = New Point(421, 0)
        EmptySpaceItem2.Name = "EmptySpaceItem2"
        EmptySpaceItem2.Size = New Size(42, 63)
        ' 
        ' LayoutControlItem5
        ' 
        LayoutControlItem5.Control = TabPane1
        LayoutControlItem5.Location = New Point(0, 63)
        LayoutControlItem5.Name = "LayoutControlItem5"
        LayoutControlItem5.Size = New Size(866, 409)
        LayoutControlItem5.TextSize = New Size(0, 0)
        LayoutControlItem5.TextVisible = False
        ' 
        ' EmptySpaceItem3
        ' 
        EmptySpaceItem3.Location = New Point(0, 24)
        EmptySpaceItem3.Name = "EmptySpaceItem3"
        EmptySpaceItem3.Size = New Size(421, 39)
        ' 
        ' LayoutControlItem2
        ' 
        LayoutControlItem2.Control = _lblTitle
        LayoutControlItem2.Location = New Point(569, 10)
        LayoutControlItem2.Name = "LayoutControlItem2"
        LayoutControlItem2.Size = New Size(297, 43)
        LayoutControlItem2.TextSize = New Size(0, 0)
        LayoutControlItem2.TextVisible = False
        ' 
        ' EmptySpaceItem4
        ' 
        EmptySpaceItem4.Location = New Point(569, 0)
        EmptySpaceItem4.Name = "EmptySpaceItem4"
        EmptySpaceItem4.Size = New Size(297, 10)
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
        ' uc24IX01BULKUPLOAD
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Margin = New Padding(2)
        Name = "uc24IX01BULKUPLOAD"
        Size = New Size(886, 492)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        oTabDataXLSX.ResumeLayout(False)
        CType(_gdXLSX, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(_01cFileXLS.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem5, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem3, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem4, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents UcGridTransaction1 As SKK02OBJECTS.ucGridTransaction
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents oTabDataXLSX As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents _gdXLSX As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _lblTitle As Label
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
End Class
