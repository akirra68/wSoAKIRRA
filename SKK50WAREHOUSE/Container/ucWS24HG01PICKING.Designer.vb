<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS24HG01PICKING
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS24HG01PICKING))
        DataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
        _btnGenerate = New DevExpress.XtraEditors.CheckButton()
        _00cNoGJ = New DevExpress.XtraEditors.TextEdit()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnuBarLanjutkanSimpanKeSuratJalan = New DevExpress.XtraBars.BarEditItem()
        RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        mnuBarSave = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        _gdProductCode = New SKK02OBJECTS.ucWSGrid()
        _gdPickingDanSale = New SKK02OBJECTS.ucWSGrid()
        _04cNomorPickingList = New DevExpress.XtraEditors.ComboBoxEdit()
        _03objProgress = New DevExpress.XtraEditors.ProgressBarControl()
        _02cFileXLS = New DevExpress.XtraEditors.ButtonEdit()
        _01cSKUPicking = New SKK02OBJECTS.ctrlWSNasaTextEdit()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        _laygdPickingDanSale = New DevExpress.XtraLayout.LayoutControlItem()
        _layJudulGroupHeader = New DevExpress.XtraLayout.LayoutControlGroup()
        _lay01cSKUPicking = New DevExpress.XtraLayout.LayoutControlItem()
        _lay02cFileXLS = New DevExpress.XtraLayout.LayoutControlItem()
        _lay03objProgress = New DevExpress.XtraLayout.LayoutControlItem()
        _lay04cNomorPickingList = New DevExpress.XtraLayout.LayoutControlItem()
        _laygdProductCode = New DevExpress.XtraLayout.LayoutControlItem()
        _lay00NomorGJ = New DevExpress.XtraLayout.LayoutControlItem()
        _lay00Generate = New DevExpress.XtraLayout.LayoutControlItem()
        CtrlwsNasaMaster1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(DataLayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        DataLayoutControl1.SuspendLayout()
        CType(_00cNoGJ.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemCheckEdit1, ComponentModel.ISupportInitialize).BeginInit()
        CType(_04cNomorPickingList.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_03objProgress.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_02cFileXLS.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01cSKUPicking.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(_laygdPickingDanSale, ComponentModel.ISupportInitialize).BeginInit()
        CType(_layJudulGroupHeader, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay01cSKUPicking, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay02cFileXLS, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay03objProgress, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay04cNomorPickingList, ComponentModel.ISupportInitialize).BeginInit()
        CType(_laygdProductCode, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay00NomorGJ, ComponentModel.ISupportInitialize).BeginInit()
        CType(_lay00Generate, ComponentModel.ISupportInitialize).BeginInit()
        CType(CtrlwsNasaMaster1View, ComponentModel.ISupportInitialize).BeginInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataLayoutControl1
        ' 
        DataLayoutControl1.Controls.Add(_btnGenerate)
        DataLayoutControl1.Controls.Add(_00cNoGJ)
        DataLayoutControl1.Controls.Add(_gdProductCode)
        DataLayoutControl1.Controls.Add(_gdPickingDanSale)
        DataLayoutControl1.Controls.Add(_04cNomorPickingList)
        DataLayoutControl1.Controls.Add(_03objProgress)
        DataLayoutControl1.Controls.Add(_02cFileXLS)
        DataLayoutControl1.Controls.Add(_01cSKUPicking)
        DataLayoutControl1.Dock = DockStyle.Fill
        DataLayoutControl1.Location = New Point(0, 24)
        DataLayoutControl1.Margin = New Padding(2)
        DataLayoutControl1.Name = "DataLayoutControl1"
        DataLayoutControl1.Root = Root
        DataLayoutControl1.Size = New Size(939, 543)
        DataLayoutControl1.TabIndex = 0
        DataLayoutControl1.Text = "DataLayoutControl1"
        ' 
        ' _btnGenerate
        ' 
        _btnGenerate.Appearance.Font = New Font("Nirmala UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
        _btnGenerate.Appearance.Options.UseFont = True
        _btnGenerate.Location = New Point(386, 61)
        _btnGenerate.Name = "_btnGenerate"
        _btnGenerate.Size = New Size(86, 22)
        _btnGenerate.StyleController = DataLayoutControl1
        _btnGenerate.TabIndex = 2
        _btnGenerate.Text = "🔁 Generate GJ"
        ' 
        ' _00cNoGJ
        ' 
        _00cNoGJ.Location = New Point(24, 63)
        _00cNoGJ.MenuManager = BarManager1
        _00cNoGJ.Name = "_00cNoGJ"
        _00cNoGJ.Size = New Size(358, 20)
        _00cNoGJ.StyleController = DataLayoutControl1
        _00cNoGJ.TabIndex = 0
        ' 
        ' BarManager1
        ' 
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar1})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnuBarSave, mnuBarLanjutkanSimpanKeSuratJalan})
        BarManager1.MaxItemId = 2
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryItemCheckEdit1})
        ' 
        ' Bar1
        ' 
        Bar1.BarName = "Tools"
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnuBarLanjutkanSimpanKeSuratJalan), New DevExpress.XtraBars.LinkPersistInfo(mnuBarSave)})
        Bar1.OptionsBar.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawBorder = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.Text = "Tools"
        ' 
        ' mnuBarLanjutkanSimpanKeSuratJalan
        ' 
        mnuBarLanjutkanSimpanKeSuratJalan.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        mnuBarLanjutkanSimpanKeSuratJalan.Caption = "Lanjutkan Simpan ke Surat Jalan"
        mnuBarLanjutkanSimpanKeSuratJalan.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far
        mnuBarLanjutkanSimpanKeSuratJalan.CaptionToEditorIndent = 0
        mnuBarLanjutkanSimpanKeSuratJalan.Edit = RepositoryItemCheckEdit1
        mnuBarLanjutkanSimpanKeSuratJalan.EditValue = False
        mnuBarLanjutkanSimpanKeSuratJalan.EditWidth = 30
        mnuBarLanjutkanSimpanKeSuratJalan.Id = 1
        mnuBarLanjutkanSimpanKeSuratJalan.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F)
        mnuBarLanjutkanSimpanKeSuratJalan.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBarLanjutkanSimpanKeSuratJalan.ItemAppearance.Normal.Options.UseFont = True
        mnuBarLanjutkanSimpanKeSuratJalan.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBarLanjutkanSimpanKeSuratJalan.Name = "mnuBarLanjutkanSimpanKeSuratJalan"
        mnuBarLanjutkanSimpanKeSuratJalan.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' RepositoryItemCheckEdit1
        ' 
        RepositoryItemCheckEdit1.AutoHeight = False
        RepositoryItemCheckEdit1.Caption = ""
        RepositoryItemCheckEdit1.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.CheckBox
        RepositoryItemCheckEdit1.ContentAlignment = DevExpress.Utils.HorzAlignment.Far
        RepositoryItemCheckEdit1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default
        RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        RepositoryItemCheckEdit1.ValueGrayed = False
        ' 
        ' mnuBarSave
        ' 
        mnuBarSave.Caption = "Save"
        mnuBarSave.Id = 0
        mnuBarSave.ImageOptions.SvgImage = CType(resources.GetObject("mnuBarSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBarSave.ItemAppearance.Normal.Font = New Font("Nirmala UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
        mnuBarSave.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBarSave.ItemAppearance.Normal.Options.UseFont = True
        mnuBarSave.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBarSave.Name = "mnuBarSave"
        mnuBarSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Margin = New Padding(2)
        barDockControlTop.Size = New Size(939, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 567)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Margin = New Padding(2)
        barDockControlBottom.Size = New Size(939, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Margin = New Padding(2)
        barDockControlLeft.Size = New Size(0, 543)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(939, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Margin = New Padding(2)
        barDockControlRight.Size = New Size(0, 543)
        ' 
        ' _gdProductCode
        ' 
        _gdProductCode._prop01User = Nothing
        _gdProductCode._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdProductCode._prop04Date = New Date(0L)
        _gdProductCode._prop05String = Nothing
        _gdProductCode._prop06String = Nothing
        _gdProductCode._prop07String = Nothing
        _gdProductCode._prop11objSpinEdit = Nothing
        _gdProductCode._prop12objSpinEdit = Nothing
        _gdProductCode.Location = New Point(24, 195)
        _gdProductCode.Margin = New Padding(1)
        _gdProductCode.Name = "_gdProductCode"
        _gdProductCode.Size = New Size(448, 324)
        _gdProductCode.TabIndex = 6
        ' 
        ' _gdPickingDanSale
        ' 
        _gdPickingDanSale._prop01User = Nothing
        _gdPickingDanSale._prop02TargetGrid = SKK02OBJECTS.ucWSGrid._pbEnumTargetGrid._WSReceiveDOFinishGoodsFromCitrix
        _gdPickingDanSale._prop04Date = New Date(0L)
        _gdPickingDanSale._prop05String = Nothing
        _gdPickingDanSale._prop06String = Nothing
        _gdPickingDanSale._prop07String = Nothing
        _gdPickingDanSale._prop11objSpinEdit = Nothing
        _gdPickingDanSale._prop12objSpinEdit = Nothing
        _gdPickingDanSale.Location = New Point(488, 12)
        _gdPickingDanSale.Margin = New Padding(1)
        _gdPickingDanSale.Name = "_gdPickingDanSale"
        _gdPickingDanSale.Size = New Size(439, 519)
        _gdPickingDanSale.TabIndex = 7
        ' 
        ' _04cNomorPickingList
        ' 
        _04cNomorPickingList.Location = New Point(24, 105)
        _04cNomorPickingList.Margin = New Padding(2)
        _04cNomorPickingList.Name = "_04cNomorPickingList"
        _04cNomorPickingList.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _04cNomorPickingList.Properties.Appearance.Options.UseFont = True
        _04cNomorPickingList.Properties.AppearanceReadOnly.BackColor = Color.Green
        _04cNomorPickingList.Properties.AppearanceReadOnly.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _04cNomorPickingList.Properties.AppearanceReadOnly.ForeColor = Color.White
        _04cNomorPickingList.Properties.AppearanceReadOnly.Options.UseBackColor = True
        _04cNomorPickingList.Properties.AppearanceReadOnly.Options.UseFont = True
        _04cNomorPickingList.Properties.AppearanceReadOnly.Options.UseForeColor = True
        _04cNomorPickingList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _04cNomorPickingList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _04cNomorPickingList.Size = New Size(167, 22)
        _04cNomorPickingList.StyleController = DataLayoutControl1
        _04cNomorPickingList.TabIndex = 3
        ' 
        ' _03objProgress
        ' 
        _03objProgress.Location = New Point(24, 175)
        _03objProgress.Margin = New Padding(2)
        _03objProgress.Name = "_03objProgress"
        _03objProgress.Properties.Appearance.BackColor = Color.Transparent
        _03objProgress.Properties.Appearance.Font = New Font("Microsoft Sans Serif", 8F)
        _03objProgress.Properties.Appearance.ForeColor = Color.ForestGreen
        _03objProgress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        _03objProgress.Properties.ShowTitle = True
        _03objProgress.Size = New Size(448, 16)
        _03objProgress.StyleController = DataLayoutControl1
        _03objProgress.TabIndex = 1
        ' 
        ' _02cFileXLS
        ' 
        _02cFileXLS.Location = New Point(24, 149)
        _02cFileXLS.Margin = New Padding(2)
        _02cFileXLS.Name = "_02cFileXLS"
        _02cFileXLS.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _02cFileXLS.Properties.Appearance.Options.UseFont = True
        _02cFileXLS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        _02cFileXLS.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _02cFileXLS.Size = New Size(448, 22)
        _02cFileXLS.StyleController = DataLayoutControl1
        _02cFileXLS.TabIndex = 5
        ' 
        ' _01cSKUPicking
        ' 
        _01cSKUPicking.Location = New Point(195, 105)
        _01cSKUPicking.Margin = New Padding(2)
        _01cSKUPicking.Name = "_01cSKUPicking"
        _01cSKUPicking.Properties.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _01cSKUPicking.Properties.Appearance.Options.UseFont = True
        _01cSKUPicking.Size = New Size(277, 22)
        _01cSKUPicking.StyleController = DataLayoutControl1
        _01cSKUPicking.TabIndex = 4
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {_laygdPickingDanSale, _layJudulGroupHeader})
        Root.Name = "Root"
        Root.Size = New Size(939, 543)
        Root.TextVisible = False
        ' 
        ' _laygdPickingDanSale
        ' 
        _laygdPickingDanSale.Control = _gdPickingDanSale
        _laygdPickingDanSale.Location = New Point(476, 0)
        _laygdPickingDanSale.Name = "_laygdPickingDanSale"
        _laygdPickingDanSale.Size = New Size(443, 523)
        _laygdPickingDanSale.TextSize = New Size(0, 0)
        _laygdPickingDanSale.TextVisible = False
        ' 
        ' _layJudulGroupHeader
        ' 
        _layJudulGroupHeader.AppearanceGroup.BorderColor = Color.Gold
        _layJudulGroupHeader.AppearanceGroup.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        _layJudulGroupHeader.AppearanceGroup.ForeColor = Color.Navy
        _layJudulGroupHeader.AppearanceGroup.Options.UseBorderColor = True
        _layJudulGroupHeader.AppearanceGroup.Options.UseFont = True
        _layJudulGroupHeader.AppearanceGroup.Options.UseForeColor = True
        _layJudulGroupHeader.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {_lay01cSKUPicking, _lay02cFileXLS, _lay03objProgress, _lay04cNomorPickingList, _laygdProductCode, _lay00NomorGJ, _lay00Generate, EmptySpaceItem1})
        _layJudulGroupHeader.Location = New Point(0, 0)
        _layJudulGroupHeader.Name = "_layJudulGroupHeader"
        _layJudulGroupHeader.Size = New Size(476, 523)
        _layJudulGroupHeader.Text = "Identity Picking"
        ' 
        ' _lay01cSKUPicking
        ' 
        _lay01cSKUPicking.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        _lay01cSKUPicking.AppearanceItemCaption.ForeColor = Color.Navy
        _lay01cSKUPicking.AppearanceItemCaption.Options.UseFont = True
        _lay01cSKUPicking.AppearanceItemCaption.Options.UseForeColor = True
        _lay01cSKUPicking.AppearanceItemCaption.Options.UseTextOptions = True
        _lay01cSKUPicking.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        _lay01cSKUPicking.Control = _01cSKUPicking
        _lay01cSKUPicking.Location = New Point(171, 42)
        _lay01cSKUPicking.Name = "_lay01cSKUPicking"
        _lay01cSKUPicking.Size = New Size(281, 44)
        _lay01cSKUPicking.Text = "SKU Picking"
        _lay01cSKUPicking.TextLocation = DevExpress.Utils.Locations.Top
        ' 
        ' _lay02cFileXLS
        ' 
        _lay02cFileXLS.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        _lay02cFileXLS.AppearanceItemCaption.ForeColor = Color.Orange
        _lay02cFileXLS.AppearanceItemCaption.Options.UseFont = True
        _lay02cFileXLS.AppearanceItemCaption.Options.UseForeColor = True
        _lay02cFileXLS.AppearanceItemCaption.Options.UseTextOptions = True
        _lay02cFileXLS.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        _lay02cFileXLS.Control = _02cFileXLS
        _lay02cFileXLS.CustomizationFormText = "Bulk Data XLS"
        _lay02cFileXLS.Location = New Point(0, 86)
        _lay02cFileXLS.Name = "_lay02cFileXLS"
        _lay02cFileXLS.Size = New Size(452, 44)
        _lay02cFileXLS.Text = "Bulk Upload via XLSX"
        _lay02cFileXLS.TextLocation = DevExpress.Utils.Locations.Top
        ' 
        ' _lay03objProgress
        ' 
        _lay03objProgress.Control = _03objProgress
        _lay03objProgress.Location = New Point(0, 130)
        _lay03objProgress.Name = "_lay03objProgress"
        _lay03objProgress.Size = New Size(452, 20)
        _lay03objProgress.TextSize = New Size(0, 0)
        _lay03objProgress.TextVisible = False
        ' 
        ' _lay04cNomorPickingList
        ' 
        _lay04cNomorPickingList.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F, FontStyle.Bold)
        _lay04cNomorPickingList.AppearanceItemCaption.ForeColor = Color.Green
        _lay04cNomorPickingList.AppearanceItemCaption.Options.UseFont = True
        _lay04cNomorPickingList.AppearanceItemCaption.Options.UseForeColor = True
        _lay04cNomorPickingList.AppearanceItemCaption.Options.UseTextOptions = True
        _lay04cNomorPickingList.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        _lay04cNomorPickingList.Control = _04cNomorPickingList
        _lay04cNomorPickingList.Location = New Point(0, 42)
        _lay04cNomorPickingList.Name = "_lay04cNomorPickingList"
        _lay04cNomorPickingList.Size = New Size(171, 44)
        _lay04cNomorPickingList.Text = "No. Picking List"
        _lay04cNomorPickingList.TextLocation = DevExpress.Utils.Locations.Top
        ' 
        ' _laygdProductCode
        ' 
        _laygdProductCode.Control = _gdProductCode
        _laygdProductCode.Location = New Point(0, 150)
        _laygdProductCode.Name = "_laygdProductCode"
        _laygdProductCode.Size = New Size(452, 328)
        _laygdProductCode.TextSize = New Size(0, 0)
        _laygdProductCode.TextVisible = False
        ' 
        ' _lay00NomorGJ
        ' 
        _lay00NomorGJ.AppearanceItemCaption.Font = New Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0)
        _lay00NomorGJ.AppearanceItemCaption.FontStyleDelta = FontStyle.Bold
        _lay00NomorGJ.AppearanceItemCaption.ForeColor = Color.IndianRed
        _lay00NomorGJ.AppearanceItemCaption.Options.UseFont = True
        _lay00NomorGJ.AppearanceItemCaption.Options.UseForeColor = True
        _lay00NomorGJ.AppearanceItemCaption.Options.UseTextOptions = True
        _lay00NomorGJ.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        _lay00NomorGJ.Control = _00cNoGJ
        _lay00NomorGJ.Location = New Point(0, 0)
        _lay00NomorGJ.Name = "_lay00NomorGJ"
        _lay00NomorGJ.Size = New Size(362, 42)
        _lay00NomorGJ.Text = "Nomor GJ"
        _lay00NomorGJ.TextLocation = DevExpress.Utils.Locations.Top
        ' 
        ' _lay00Generate
        ' 
        _lay00Generate.Control = _btnGenerate
        _lay00Generate.Location = New Point(362, 16)
        _lay00Generate.Name = "_lay00Generate"
        _lay00Generate.Size = New Size(90, 26)
        _lay00Generate.TextVisible = False
        ' 
        ' CtrlwsNasaMaster1View
        ' 
        CtrlwsNasaMaster1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        CtrlwsNasaMaster1View.Name = "CtrlwsNasaMaster1View"
        CtrlwsNasaMaster1View.OptionsSelection.EnableAppearanceFocusedCell = False
        CtrlwsNasaMaster1View.OptionsView.ShowGroupPanel = False
        ' 
        ' EmptySpaceItem1
        ' 
        EmptySpaceItem1.Location = New Point(362, 0)
        EmptySpaceItem1.Name = "EmptySpaceItem1"
        EmptySpaceItem1.Size = New Size(90, 16)
        ' 
        ' ucWS24HG01PICKING
        ' 
        Appearance.BackColor = Color.White
        Appearance.Options.UseBackColor = True
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(DataLayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Margin = New Padding(2)
        Name = "ucWS24HG01PICKING"
        Size = New Size(939, 567)
        CType(DataLayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        DataLayoutControl1.ResumeLayout(False)
        CType(_00cNoGJ.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemCheckEdit1, ComponentModel.ISupportInitialize).EndInit()
        CType(_04cNomorPickingList.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_03objProgress.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_02cFileXLS.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(_01cSKUPicking.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(_laygdPickingDanSale, ComponentModel.ISupportInitialize).EndInit()
        CType(_layJudulGroupHeader, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay01cSKUPicking, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay02cFileXLS, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay03objProgress, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay04cNomorPickingList, ComponentModel.ISupportInitialize).EndInit()
        CType(_laygdProductCode, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay00NomorGJ, ComponentModel.ISupportInitialize).EndInit()
        CType(_lay00Generate, ComponentModel.ISupportInitialize).EndInit()
        CType(CtrlwsNasaMaster1View, ComponentModel.ISupportInitialize).EndInit()
        CType(EmptySpaceItem1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents _01cSKUPicking As SKK02OBJECTS.ctrlWSNasaTextEdit
    Friend WithEvents CtrlwsNasaMaster1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _lay01cSKUPicking As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _layJudulGroupHeader As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _02cFileXLS As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents _lay02cFileXLS As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _03objProgress As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents _lay03objProgress As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _04cNomorPickingList As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents _lay04cNomorPickingList As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _gdPickingDanSale As SKK02OBJECTS.ucWSGrid
    Friend WithEvents _laygdPickingDanSale As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _gdProductCode As SKK02OBJECTS.ucWSGrid
    Friend WithEvents _laygdProductCode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuBarSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBarLanjutkanSimpanKeSuratJalan As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents _00cNoGJ As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _lay00NomorGJ As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _btnGenerate As DevExpress.XtraEditors.CheckButton
    Friend WithEvents _lay00Generate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem

End Class
