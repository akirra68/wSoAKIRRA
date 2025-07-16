<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptWS24B3REPORT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptWS24B3REPORT))
        TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        oTabGridTabel = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        _gdTabel = New SKK02OBJECTS.ucWSGrid()
        oTabPivotAnalisa = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        XtraScrollableControl2 = New DevExpress.XtraEditors.XtraScrollableControl()
        _pvAnalisa = New SKK02OBJECTS.ucWSPivot()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _03cTargetStock = New DevExpress.XtraEditors.ComboBoxEdit()
        _otblDisplay = New DevExpress.XtraEditors.SimpleButton()
        _02dPeriodeHinggaTanggal = New DevExpress.XtraEditors.DateEdit()
        _01dPeriodeDariTanggal = New DevExpress.XtraEditors.DateEdit()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        _lay01dPeriodeDariTanggal = New DevExpress.XtraLayout.LayoutControlItem()
        _lay02dPeriodeHinggaTanggal = New DevExpress.XtraLayout.LayoutControlItem()
        LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        _lay03cTargetStock = New DevExpress.XtraLayout.LayoutControlItem()
        EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(TabPane1, ComponentModel.ISupportInitialize).BeginInit()
        TabPane1.SuspendLayout()
        oTabGridTabel.SuspendLayout()
        XtraScrollableControl1.SuspendLayout()
        oTabPivotAnalisa.SuspendLayout()
        XtraScrollableControl2.SuspendLayout()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(_03cTargetStock.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_02dPeriodeHinggaTanggal.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_02dPeriodeHinggaTanggal.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01dPeriodeDariTanggal.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01dPeriodeDariTanggal.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay01dPeriodeDariTanggal, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay02dPeriodeHinggaTanggal, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay03cTargetStock, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TabPane1
        ' 
        TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.True
        TabPane1.AppearanceButton.Hovered.Font = New Font("Nirmala UI Semilight", 12F, FontStyle.Italic)
        TabPane1.AppearanceButton.Hovered.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
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
        TabPane1.Controls.Add(oTabGridTabel)
        TabPane1.Controls.Add(oTabPivotAnalisa)
        TabPane1.Location = New Point(12, 38)
        TabPane1.Margin = New Padding(2)
        TabPane1.Name = "TabPane1"
        TabPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {oTabGridTabel, oTabPivotAnalisa})
        TabPane1.RegularSize = New Size(949, 321)
        TabPane1.SelectedPage = oTabGridTabel
        TabPane1.Size = New Size(949, 321)
        TabPane1.TabAlignment = DevExpress.XtraEditors.Alignment.Far
        TabPane1.TabIndex = 5
        TabPane1.Text = "TabPane1"
        ' 
        ' oTabGridTabel
        ' 
        oTabGridTabel.Caption = "Tabel"
        oTabGridTabel.Controls.Add(XtraScrollableControl1)
        oTabGridTabel.ImageOptions.Image = CType(resources.GetObject("oTabGridTabel.ImageOptions.Image"), Image)
        oTabGridTabel.Margin = New Padding(2)
        oTabGridTabel.Name = "oTabGridTabel"
        oTabGridTabel.Size = New Size(949, 278)
        ' 
        ' XtraScrollableControl1
        ' 
        XtraScrollableControl1.Controls.Add(_gdTabel)
        XtraScrollableControl1.Dock = DockStyle.Fill
        XtraScrollableControl1.Location = New Point(0, 0)
        XtraScrollableControl1.Margin = New Padding(2)
        XtraScrollableControl1.Name = "XtraScrollableControl1"
        XtraScrollableControl1.Size = New Size(949, 278)
        XtraScrollableControl1.TabIndex = 0
        ' 
        ' _gdTabel
        ' 
        _gdTabel._prop01User = Nothing
        _gdTabel._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdTabel._prop04Date = New Date(0L)
        _gdTabel._prop05String = Nothing
        _gdTabel._prop06String = Nothing
        _gdTabel._prop07String = Nothing
        _gdTabel._prop11objSpinEdit = Nothing
        _gdTabel._prop12objSpinEdit = Nothing
        _gdTabel.Dock = DockStyle.Fill
        _gdTabel.Location = New Point(0, 0)
        _gdTabel.Margin = New Padding(1)
        _gdTabel.Name = "_gdTabel"
        _gdTabel.Size = New Size(949, 278)
        _gdTabel.TabIndex = 0
        ' 
        ' oTabPivotAnalisa
        ' 
        oTabPivotAnalisa.Caption = "Analisa"
        oTabPivotAnalisa.Controls.Add(XtraScrollableControl2)
        oTabPivotAnalisa.ImageOptions.Image = CType(resources.GetObject("oTabPivotAnalisa.ImageOptions.Image"), Image)
        oTabPivotAnalisa.Margin = New Padding(2)
        oTabPivotAnalisa.Name = "oTabPivotAnalisa"
        oTabPivotAnalisa.Size = New Size(657, 330)
        ' 
        ' XtraScrollableControl2
        ' 
        XtraScrollableControl2.Controls.Add(_pvAnalisa)
        XtraScrollableControl2.Dock = DockStyle.Fill
        XtraScrollableControl2.Location = New Point(0, 0)
        XtraScrollableControl2.Margin = New Padding(2)
        XtraScrollableControl2.Name = "XtraScrollableControl2"
        XtraScrollableControl2.Size = New Size(657, 330)
        XtraScrollableControl2.TabIndex = 0
        ' 
        ' _pvAnalisa
        ' 
        _pvAnalisa._prop01User = Nothing
        _pvAnalisa._prop02TargetPivot = SKK02OBJECTS.ucWSPivot._pbEnumTargetPivot._rptWS01PosterSaldoCurrent
        _pvAnalisa.Dock = DockStyle.Fill
        _pvAnalisa.Location = New Point(0, 0)
        _pvAnalisa.Margin = New Padding(1)
        _pvAnalisa.Name = "_pvAnalisa"
        _pvAnalisa.Size = New Size(657, 330)
        _pvAnalisa.TabIndex = 0
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_03cTargetStock)
        LayoutControl1.Controls.Add(_otblDisplay)
        LayoutControl1.Controls.Add(_02dPeriodeHinggaTanggal)
        LayoutControl1.Controls.Add(_01dPeriodeDariTanggal)
        LayoutControl1.Controls.Add(TabPane1)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 0)
        LayoutControl1.Margin = New Padding(2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(973, 371)
        LayoutControl1.TabIndex = 1
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _03cTargetStock
        ' 
        _03cTargetStock.EditValue = "Stock Keeping Unit"
        _03cTargetStock.Location = New Point(89, 12)
        _03cTargetStock.Margin = New Padding(2)
        _03cTargetStock.Name = "_03cTargetStock"
        _03cTargetStock.Properties.Appearance.Font = New Font("Courier New", 10F, FontStyle.Bold)
        _03cTargetStock.Properties.Appearance.Options.UseFont = True
        _03cTargetStock.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _03cTargetStock.Properties.Items.AddRange(New Object() {"Stock Keeping Unit (SKU)", "Product Code"})
        _03cTargetStock.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _03cTargetStock.Size = New Size(165, 22)
        _03cTargetStock.StyleController = LayoutControl1
        _03cTargetStock.TabIndex = 0
        ' 
        ' _otblDisplay
        ' 
        _otblDisplay.Appearance.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        _otblDisplay.Appearance.ForeColor = Color.Navy
        _otblDisplay.Appearance.Options.UseFont = True
        _otblDisplay.Appearance.Options.UseForeColor = True
        _otblDisplay.ImageOptions.SvgImageSize = New Size(20, 20)
        _otblDisplay.Location = New Point(707, 12)
        _otblDisplay.Margin = New Padding(2)
        _otblDisplay.Name = "_otblDisplay"
        _otblDisplay.Size = New Size(177, 22)
        _otblDisplay.StyleController = LayoutControl1
        _otblDisplay.TabIndex = 4
        _otblDisplay.Text = "Refresh"
        ' 
        ' _02dPeriodeHinggaTanggal
        ' 
        _02dPeriodeHinggaTanggal.EditValue = Nothing
        _02dPeriodeHinggaTanggal.Location = New Point(549, 12)
        _02dPeriodeHinggaTanggal.Margin = New Padding(2)
        _02dPeriodeHinggaTanggal.Name = "_02dPeriodeHinggaTanggal"
        _02dPeriodeHinggaTanggal.Properties.Appearance.Font = New Font("Courier New", 10F, FontStyle.Bold)
        _02dPeriodeHinggaTanggal.Properties.Appearance.Options.UseFont = True
        _02dPeriodeHinggaTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _02dPeriodeHinggaTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _02dPeriodeHinggaTanggal.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        _02dPeriodeHinggaTanggal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        _02dPeriodeHinggaTanggal.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        _02dPeriodeHinggaTanggal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        _02dPeriodeHinggaTanggal.Properties.MaskSettings.Set("mask", "dd/MM/yyyy")
        _02dPeriodeHinggaTanggal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _02dPeriodeHinggaTanggal.Properties.UseMaskAsDisplayFormat = True
        _02dPeriodeHinggaTanggal.Size = New Size(142, 22)
        _02dPeriodeHinggaTanggal.StyleController = LayoutControl1
        _02dPeriodeHinggaTanggal.TabIndex = 3
        ' 
        ' _01dPeriodeDariTanggal
        ' 
        _01dPeriodeDariTanggal.EditValue = Nothing
        _01dPeriodeDariTanggal.Location = New Point(335, 12)
        _01dPeriodeDariTanggal.Margin = New Padding(2)
        _01dPeriodeDariTanggal.Name = "_01dPeriodeDariTanggal"
        _01dPeriodeDariTanggal.Properties.Appearance.Font = New Font("Courier New", 10F, FontStyle.Bold)
        _01dPeriodeDariTanggal.Properties.Appearance.Options.UseFont = True
        _01dPeriodeDariTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _01dPeriodeDariTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _01dPeriodeDariTanggal.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        _01dPeriodeDariTanggal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        _01dPeriodeDariTanggal.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        _01dPeriodeDariTanggal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        _01dPeriodeDariTanggal.Properties.MaskSettings.Set("mask", "dd/MM/yyyy")
        _01dPeriodeDariTanggal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _01dPeriodeDariTanggal.Properties.UseMaskAsDisplayFormat = True
        _01dPeriodeDariTanggal.Size = New Size(133, 22)
        _01dPeriodeDariTanggal.StyleController = LayoutControl1
        _01dPeriodeDariTanggal.TabIndex = 2
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem1, _lay01dPeriodeDariTanggal, _lay02dPeriodeHinggaTanggal, LayoutControlItem4, EmptySpaceItem1, _lay03cTargetStock, EmptySpaceItem2})
        Root.Name = "Root"
        Root.Size = New Size(973, 371)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem1
        ' 
        LayoutControlItem1.Control = TabPane1
        LayoutControlItem1.Location = New Point(0, 26)
        LayoutControlItem1.Name = "LayoutControlItem1"
        LayoutControlItem1.Size = New Size(953, 325)
        LayoutControlItem1.TextSize = New Size(0, 0)
        LayoutControlItem1.TextVisible = False
        ' 
        ' _lay01dPeriodeDariTanggal
        ' 
        _lay01dPeriodeDariTanggal.AppearanceItemCaption.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        _lay01dPeriodeDariTanggal.AppearanceItemCaption.ForeColor = Color.Navy
        _lay01dPeriodeDariTanggal.AppearanceItemCaption.Options.UseFont = True
        _lay01dPeriodeDariTanggal.AppearanceItemCaption.Options.UseForeColor = True
        _lay01dPeriodeDariTanggal.Control = _01dPeriodeDariTanggal
        _lay01dPeriodeDariTanggal.Location = New Point(246, 0)
        _lay01dPeriodeDariTanggal.Name = "_lay01dPeriodeDariTanggal"
        _lay01dPeriodeDariTanggal.Size = New Size(214, 26)
        _lay01dPeriodeDariTanggal.Text = "Dari"
        ' 
        ' _lay02dPeriodeHinggaTanggal
        ' 
        _lay02dPeriodeHinggaTanggal.AppearanceItemCaption.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        _lay02dPeriodeHinggaTanggal.AppearanceItemCaption.ForeColor = Color.Navy
        _lay02dPeriodeHinggaTanggal.AppearanceItemCaption.Options.UseFont = True
        _lay02dPeriodeHinggaTanggal.AppearanceItemCaption.Options.UseForeColor = True
        _lay02dPeriodeHinggaTanggal.Control = _02dPeriodeHinggaTanggal
        _lay02dPeriodeHinggaTanggal.Location = New Point(460, 0)
        _lay02dPeriodeHinggaTanggal.Name = "_lay02dPeriodeHinggaTanggal"
        _lay02dPeriodeHinggaTanggal.Size = New Size(223, 26)
        _lay02dPeriodeHinggaTanggal.Text = "Hingga"
        ' 
        ' LayoutControlItem4
        ' 
        LayoutControlItem4.Control = _otblDisplay
        LayoutControlItem4.Location = New Point(695, 0)
        LayoutControlItem4.Name = "LayoutControlItem4"
        LayoutControlItem4.Size = New Size(181, 26)
        LayoutControlItem4.TextSize = New Size(0, 0)
        LayoutControlItem4.TextVisible = False
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(876, 0)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(77, 26)
        ' 
        ' _lay03cTargetStock
        ' 
        _lay03cTargetStock.AppearanceItemCaption.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        _lay03cTargetStock.AppearanceItemCaption.ForeColor = Color.Navy
        _lay03cTargetStock.AppearanceItemCaption.Options.UseFont = True
        _lay03cTargetStock.AppearanceItemCaption.Options.UseForeColor = True
        _lay03cTargetStock.Control = _03cTargetStock
        _lay03cTargetStock.Location = New Point(0, 0)
        _lay03cTargetStock.Name = "_lay03cTargetStock"
        _lay03cTargetStock.Size = New Size(246, 26)
        _lay03cTargetStock.Text = "Target Stock"
        ' 
        ' EmptySpaceItem2
        ' 
        EmptySpaceItem2.Location = New Point(683, 0)
        EmptySpaceItem2.Name = "EmptySpaceItem2"
        EmptySpaceItem2.Size = New Size(12, 26)
        ' 
        ' rptWS24B3REPORT
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Margin = New Padding(2)
        Name = "rptWS24B3REPORT"
        Size = New Size(973, 371)
        CType(TabPane1, ComponentModel.ISupportInitialize).EndInit()
        TabPane1.ResumeLayout(False)
        oTabGridTabel.ResumeLayout(False)
        XtraScrollableControl1.ResumeLayout(False)
        oTabPivotAnalisa.ResumeLayout(False)
        XtraScrollableControl2.ResumeLayout(False)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(_03cTargetStock.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_02dPeriodeHinggaTanggal.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(_02dPeriodeHinggaTanggal.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_01dPeriodeDariTanggal.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(_01dPeriodeDariTanggal.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay01dPeriodeDariTanggal, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay02dPeriodeHinggaTanggal, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem4, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay03cTargetStock, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents oTabGridTabel As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents oTabPivotAnalisa As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents XtraScrollableControl2 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents _pvAnalisa As SKK02OBJECTS.ucWSPivot
    Friend WithEvents _gdTabel As SKK02OBJECTS.ucWSGrid
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents _otblDisplay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents _02dPeriodeHinggaTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents _01dPeriodeDariTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _lay01dPeriodeDariTanggal As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _lay02dPeriodeHinggaTanggal As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents _03cTargetStock As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents _lay03cTargetStock As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem

End Class
