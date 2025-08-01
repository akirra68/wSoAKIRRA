<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS24LD01BULKUPLOADXLS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS24LD01BULKUPLOADXLS))
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        _TabNav01BulkUploadData = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdBulkUploadData = New DevExpress.XtraGrid.GridControl()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar2 = New DevExpress.XtraBars.Bar()
        _bar01FileXLS = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        _bar02Clear = New DevExpress.XtraBars.BarButtonItem()
        _bar03Save = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        _TabNav02Result = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        _gdResult = New SKK02OBJECTS.ucWSGrid()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        _TabNav01BulkUploadData.SuspendLayout()
        CType(_gdBulkUploadData, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemButtonEdit1, ComponentModel.ISupportInitialize).BeginInit()
        _TabNav02Result.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(TabPane1)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 24)
        LayoutControl1.Margin = New Padding(2, 2, 2, 2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1160, 545)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' TabPane1
        ' 
        TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True
        TabPane1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 12F, FontStyle.Italic)
        TabPane1.AppearanceButton.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        TabPane1.AppearanceButton.Hovered.Options.UseFont = True
        TabPane1.AppearanceButton.Hovered.Options.UseForeColor = True
        TabPane1.AppearanceButton.Normal.Font = New Font("Nirmala UI Semilight", 10F)
        TabPane1.AppearanceButton.Normal.ForeColor = Color.Silver
        TabPane1.AppearanceButton.Normal.Options.UseFont = True
        TabPane1.AppearanceButton.Normal.Options.UseForeColor = True
        TabPane1.AppearanceButton.Pressed.Font = New Font("Nirmala UI", 10F, FontStyle.Bold)
        TabPane1.AppearanceButton.Pressed.ForeColor = Color.Navy
        TabPane1.AppearanceButton.Pressed.Options.UseFont = True
        TabPane1.AppearanceButton.Pressed.Options.UseForeColor = True
        TabPane1.Controls.Add(_TabNav01BulkUploadData)
        TabPane1.Controls.Add(_TabNav02Result)
        TabPane1.Location = New Point(8, 8)
        TabPane1.Margin = New Padding(2, 2, 2, 2)
        TabPane1.Name = "TabPane1"
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {_TabNav01BulkUploadData, _TabNav02Result})
        TabPane1.RegularSize = New Size(1144, 529)
        TabPane1.SelectedPage = _TabNav01BulkUploadData
        TabPane1.Size = New Size(1144, 529)
        TabPane1.TabIndex = 4
        TabPane1.Text = "TabPane1"
        ' 
        ' _TabNav01BulkUploadData
        ' 
        _TabNav01BulkUploadData.Caption = "Bulk Upload Data"
        _TabNav01BulkUploadData.Controls.Add(_gdBulkUploadData)
        _TabNav01BulkUploadData.ImageOptions.Image = CType(resources.GetObject("_TabNav01BulkUploadData.ImageOptions.Image"), Image)
        _TabNav01BulkUploadData.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        _TabNav01BulkUploadData.Margin = New Padding(2, 2, 2, 2)
        _TabNav01BulkUploadData.Name = "_TabNav01BulkUploadData"
        _TabNav01BulkUploadData.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        _TabNav01BulkUploadData.Size = New Size(1144, 486)
        ' 
        ' _gdBulkUploadData
        ' 
        _gdBulkUploadData.Dock = DockStyle.Fill
        _gdBulkUploadData.EmbeddedNavigator.Margin = New Padding(1, 1, 1, 1)
        _gdBulkUploadData.Location = New Point(0, 0)
        _gdBulkUploadData.MainView = GridView1
        _gdBulkUploadData.Margin = New Padding(2, 2, 2, 2)
        _gdBulkUploadData.MenuManager = BarManager1
        _gdBulkUploadData.Name = "_gdBulkUploadData"
        _gdBulkUploadData.Size = New Size(1144, 486)
        _gdBulkUploadData.TabIndex = 0
        _gdBulkUploadData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        ' 
        ' GridView1
        ' 
        GridView1.Appearance.FooterPanel.Font = New Font("Courier New", 10F, FontStyle.Bold)
        GridView1.Appearance.FooterPanel.ForeColor = Color.Navy
        GridView1.Appearance.FooterPanel.Options.UseFont = True
        GridView1.Appearance.FooterPanel.Options.UseForeColor = True
        GridView1.Appearance.HeaderPanel.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        GridView1.Appearance.HeaderPanel.ForeColor = Color.Navy
        GridView1.Appearance.HeaderPanel.Options.UseFont = True
        GridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Appearance.Row.Font = New Font("Courier New", 8F)
        GridView1.Appearance.Row.Options.UseFont = True
        GridView1.DetailHeight = 239
        GridView1.GridControl = _gdBulkUploadData
        GridView1.Name = "GridView1"
        GridView1.OptionsEditForm.PopupEditFormWidth = 533
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' BarManager1
        ' 
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar2})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {_bar01FileXLS, _bar02Clear, _bar03Save})
        BarManager1.MainMenu = Bar2
        BarManager1.MaxItemId = 3
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryItemButtonEdit1})
        ' 
        ' Bar2
        ' 
        Bar2.BarName = "Main menu"
        Bar2.DockCol = 0
        Bar2.DockRow = 0
        Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(_bar01FileXLS), New DevExpress.XtraBars.LinkPersistInfo(_bar02Clear), New DevExpress.XtraBars.LinkPersistInfo(_bar03Save)})
        Bar2.OptionsBar.AllowQuickCustomization = False
        Bar2.OptionsBar.DrawBorder = False
        Bar2.OptionsBar.DrawDragBorder = False
        Bar2.OptionsBar.MultiLine = True
        Bar2.OptionsBar.UseWholeRow = True
        Bar2.Text = "Main menu"
        ' 
        ' _bar01FileXLS
        ' 
        _bar01FileXLS.Caption = "File XLSX"
        _bar01FileXLS.Edit = RepositoryItemButtonEdit1
        _bar01FileXLS.EditWidth = 400
        _bar01FileXLS.Id = 0
        _bar01FileXLS.ImageOptions.SvgImage = CType(resources.GetObject("_bar01FileXLS.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        _bar01FileXLS.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8F)
        _bar01FileXLS.ItemAppearance.Normal.ForeColor = Color.Navy
        _bar01FileXLS.ItemAppearance.Normal.Options.UseFont = True
        _bar01FileXLS.ItemAppearance.Normal.Options.UseForeColor = True
        _bar01FileXLS.Name = "_bar01FileXLS"
        _bar01FileXLS.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' RepositoryItemButtonEdit1
        ' 
        RepositoryItemButtonEdit1.AutoHeight = False
        RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        ' 
        ' _bar02Clear
        ' 
        _bar02Clear.Caption = "Clear"
        _bar02Clear.Id = 1
        _bar02Clear.ImageOptions.SvgImage = CType(resources.GetObject("_bar02Clear.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        _bar02Clear.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8F)
        _bar02Clear.ItemAppearance.Normal.ForeColor = Color.Navy
        _bar02Clear.ItemAppearance.Normal.Options.UseFont = True
        _bar02Clear.ItemAppearance.Normal.Options.UseForeColor = True
        _bar02Clear.Name = "_bar02Clear"
        _bar02Clear.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' _bar03Save
        ' 
        _bar03Save.Caption = "Save"
        _bar03Save.Id = 2
        _bar03Save.ImageOptions.SvgImage = CType(resources.GetObject("_bar03Save.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        _bar03Save.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8F)
        _bar03Save.ItemAppearance.Normal.ForeColor = Color.Navy
        _bar03Save.ItemAppearance.Normal.Options.UseFont = True
        _bar03Save.ItemAppearance.Normal.Options.UseForeColor = True
        _bar03Save.Name = "_bar03Save"
        _bar03Save.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Margin = New Padding(2, 2, 2, 2)
        barDockControlTop.Size = New Size(1160, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 569)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Margin = New Padding(2, 2, 2, 2)
        barDockControlBottom.Size = New Size(1160, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Margin = New Padding(2, 2, 2, 2)
        barDockControlLeft.Size = New Size(0, 545)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(1160, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Margin = New Padding(2, 2, 2, 2)
        barDockControlRight.Size = New Size(0, 545)
        ' 
        ' _TabNav02Result
        ' 
        _TabNav02Result.Caption = "Result"
        _TabNav02Result.Controls.Add(_gdResult)
        _TabNav02Result.ImageOptions.Image = CType(resources.GetObject("_TabNav02Result.ImageOptions.Image"), Image)
        _TabNav02Result.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        _TabNav02Result.Margin = New Padding(2, 2, 2, 2)
        _TabNav02Result.Name = "_TabNav02Result"
        _TabNav02Result.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        _TabNav02Result.Size = New Size(1136, 488)
        ' 
        ' _gdResult
        ' 
        _gdResult._prop01User = Nothing
        _gdResult._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdResult._prop04Date = New Date(0L)
        _gdResult._prop05String = Nothing
        _gdResult._prop06String = Nothing
        _gdResult._prop07String = Nothing
        _gdResult._prop11objSpinEdit = Nothing
        _gdResult._prop12objSpinEdit = Nothing
        _gdResult.Dock = DockStyle.Fill
        _gdResult.Location = New Point(0, 0)
        _gdResult.Margin = New Padding(1, 1, 1, 1)
        _gdResult.Name = "_gdResult"
        _gdResult.Size = New Size(1136, 488)
        _gdResult.TabIndex = 0
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1})
        Root.Name = "Root"
        Root.Size = New Size(1160, 545)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = TabPane1
        LayoutControlItem1.Location = New Point(0, 0)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(1146, 531)
        LayoutControlItem1.TextSize = New Size(0, 0)
        LayoutControlItem1.TextVisible = False
        ' 
        ' ucWS24LD01BULKUPLOADXLS
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Margin = New Padding(2, 2, 2, 2)
        Name = "ucWS24LD01BULKUPLOADXLS"
        Size = New Size(1160, 569)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        _TabNav01BulkUploadData.ResumeLayout(False)
        CType(_gdBulkUploadData, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemButtonEdit1, ComponentModel.ISupportInitialize).EndInit()
        _TabNav02Result.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents _TabNav01BulkUploadData As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents _TabNav02Result As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents _bar01FileXLS As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents _bar02Clear As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _gdBulkUploadData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _gdResult As SKK02OBJECTS.ucWSGrid
    Friend WithEvents _bar03Save As DevExpress.XtraBars.BarButtonItem

End Class
