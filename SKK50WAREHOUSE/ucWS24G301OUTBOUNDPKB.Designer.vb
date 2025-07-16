<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucWS24G301OUTBOUNDPKB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucWS24G301OUTBOUNDPKB))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        _gdOutboundPKB = New SKK02OBJECTS.ucWSGridParentChild()
        Root = New DevExpress.XtraLayout.LayoutControlGroup()
        LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        BarManager1 = New DevExpress.XtraBars.BarManager(components)
        Bar1 = New DevExpress.XtraBars.Bar()
        mnubarTargetProses = New DevExpress.XtraBars.BarSubItem()
        mnubarTargetProses01NewPKBSampaiSJ = New DevExpress.XtraBars.BarButtonItem()
        mnubarTargetProses02SJSampaiDelivered = New DevExpress.XtraBars.BarButtonItem()
        mnuBarRefresh = New DevExpress.XtraBars.BarButtonItem()
        mnubarDateProsesTransaksi = New DevExpress.XtraBars.BarEditItem()
        rsobjDateDelivered = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        mnubarPicker = New DevExpress.XtraBars.BarEditItem()
        rsobjPicker = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        _col01f05StringKodePicker = New DevExpress.XtraGrid.Columns.GridColumn()
        _col02f06StringNamaPicker = New DevExpress.XtraGrid.Columns.GridColumn()
        mnubarPrintPicking = New DevExpress.XtraBars.BarButtonItem()
        mnubarPickingSKU = New DevExpress.XtraBars.BarButtonItem()
        mnubarAggregateAirwayBill = New DevExpress.XtraBars.BarButtonItem()
        mnubarSave = New DevExpress.XtraBars.BarButtonItem()
        mnubarGrid = New DevExpress.XtraBars.BarButtonItem()
        barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        _01cSKUPicking = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        _rsmnuBarPickingBRJ = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        _rsmnuBarSKUPicking = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Bar2 = New DevExpress.XtraBars.Bar()
        Bar3 = New DevExpress.XtraBars.Bar()
        Bar4 = New DevExpress.XtraBars.Bar()
        Bar5 = New DevExpress.XtraBars.Bar()
        CType(LayoutControl1, ComponentModel.ISupportInitialize).BeginInit()
        LayoutControl1.SuspendLayout()
        CType(Root, ComponentModel.ISupportInitialize).BeginInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).BeginInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsobjDateDelivered, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsobjDateDelivered.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(rsobjPicker, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemSearchLookUpEdit1View, ComponentModel.ISupportInitialize).BeginInit()
        CType(_01cSKUPicking, ComponentModel.ISupportInitialize).BeginInit()
        CType(_rsmnuBarPickingBRJ, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemTextEdit1, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryItemTextEdit2, ComponentModel.ISupportInitialize).BeginInit()
        CType(_rsmnuBarSKUPicking, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LayoutControl1
        ' 
        LayoutControl1.Controls.Add(_gdOutboundPKB)
        LayoutControl1.Dock = DockStyle.Fill
        LayoutControl1.Location = New Point(0, 24)
        LayoutControl1.Margin = New Padding(2)
        LayoutControl1.Name = "LayoutControl1"
        LayoutControl1.Root = Root
        LayoutControl1.Size = New Size(1253, 341)
        LayoutControl1.TabIndex = 0
        LayoutControl1.Text = "LayoutControl1"
        ' 
        ' _gdOutboundPKB
        ' 
        _gdOutboundPKB._prop01Date = New Date(0L)
        _gdOutboundPKB._prop01objUser = Nothing
        _gdOutboundPKB._prop01User = Nothing
        _gdOutboundPKB._prop02Date = New Date(0L)
        _gdOutboundPKB._prop02TargetGridParentChild = SKK02OBJECTS.ucWSGridParentChild.__TargetGridParentChild._TargetDisplayOutboundPKB
        _gdOutboundPKB._prop03String = Nothing
        _gdOutboundPKB._prop04String = Nothing
        _gdOutboundPKB.BorderStyle = BorderStyle.FixedSingle
        _gdOutboundPKB.Location = New Point(12, 12)
        _gdOutboundPKB.Margin = New Padding(1)
        _gdOutboundPKB.Name = "_gdOutboundPKB"
        _gdOutboundPKB.Size = New Size(1229, 317)
        _gdOutboundPKB.TabIndex = 4
        ' 
        ' Root
        ' 
        Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True
        Root.GroupBordersVisible = False
        Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {LayoutControlItem2})
        Root.Name = "Root"
        Root.Size = New Size(1253, 341)
        Root.TextVisible = False
        ' 
        ' LayoutControlItem2
        ' 
        LayoutControlItem2.Control = _gdOutboundPKB
        LayoutControlItem2.Location = New Point(0, 0)
        LayoutControlItem2.Name = "LayoutControlItem2"
        LayoutControlItem2.Size = New Size(1233, 321)
        LayoutControlItem2.TextSize = New Size(0, 0)
        LayoutControlItem2.TextVisible = False
        ' 
        ' BarManager1
        ' 
        BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Bar1})
        BarManager1.DockControls.Add(barDockControlTop)
        BarManager1.DockControls.Add(barDockControlBottom)
        BarManager1.DockControls.Add(barDockControlLeft)
        BarManager1.DockControls.Add(barDockControlRight)
        BarManager1.Form = Me
        BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {mnubarSave, mnubarGrid, mnubarPickingSKU, mnubarPrintPicking, mnubarTargetProses, mnubarTargetProses01NewPKBSampaiSJ, mnubarTargetProses02SJSampaiDelivered, mnubarPicker, mnubarDateProsesTransaksi, mnubarAggregateAirwayBill, mnuBarRefresh})
        BarManager1.MainMenu = Bar1
        BarManager1.MaxItemId = 24
        BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {_01cSKUPicking, _rsmnuBarPickingBRJ, RepositoryItemTextEdit1, RepositoryItemTextEdit2, _rsmnuBarSKUPicking, rsobjPicker, rsobjDateDelivered})
        ' 
        ' Bar1
        ' 
        Bar1.BarAppearance.Normal.Font = New Font("Nirmala UI Semilight", 8F)
        Bar1.BarAppearance.Normal.ForeColor = Color.Navy
        Bar1.BarAppearance.Normal.Options.UseFont = True
        Bar1.BarAppearance.Normal.Options.UseForeColor = True
        Bar1.BarItemHorzIndent = 10
        Bar1.BarName = "Tools"
        Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Bar1.DockCol = 0
        Bar1.DockRow = 0
        Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar1.FloatLocation = New Point(450, 213)
        Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnubarTargetProses), New DevExpress.XtraBars.LinkPersistInfo(mnuBarRefresh), New DevExpress.XtraBars.LinkPersistInfo(mnubarDateProsesTransaksi), New DevExpress.XtraBars.LinkPersistInfo(mnubarPicker), New DevExpress.XtraBars.LinkPersistInfo(mnubarPrintPicking), New DevExpress.XtraBars.LinkPersistInfo(mnubarPickingSKU), New DevExpress.XtraBars.LinkPersistInfo(mnubarAggregateAirwayBill), New DevExpress.XtraBars.LinkPersistInfo(mnubarSave), New DevExpress.XtraBars.LinkPersistInfo(mnubarGrid)})
        Bar1.Text = "Tools"
        ' 
        ' mnubarTargetProses
        ' 
        mnubarTargetProses.Caption = "Target Proses"
        mnubarTargetProses.Id = 11
        mnubarTargetProses.ImageOptions.SvgImage = CType(resources.GetObject("mnubarTargetProses.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarTargetProses.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarTargetProses.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarTargetProses.ItemAppearance.Normal.Options.UseFont = True
        mnubarTargetProses.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarTargetProses.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(mnubarTargetProses01NewPKBSampaiSJ), New DevExpress.XtraBars.LinkPersistInfo(mnubarTargetProses02SJSampaiDelivered)})
        mnubarTargetProses.Name = "mnubarTargetProses"
        mnubarTargetProses.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnubarTargetProses01NewPKBSampaiSJ
        ' 
        mnubarTargetProses01NewPKBSampaiSJ.Caption = "New Order Sampai SuratJalan"
        mnubarTargetProses01NewPKBSampaiSJ.Id = 12
        mnubarTargetProses01NewPKBSampaiSJ.ImageOptions.SvgImage = CType(resources.GetObject("mnubarTargetProses01NewPKBSampaiSJ.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarTargetProses01NewPKBSampaiSJ.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        mnubarTargetProses01NewPKBSampaiSJ.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarTargetProses01NewPKBSampaiSJ.ItemAppearance.Normal.Options.UseFont = True
        mnubarTargetProses01NewPKBSampaiSJ.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarTargetProses01NewPKBSampaiSJ.Name = "mnubarTargetProses01NewPKBSampaiSJ"
        ' 
        ' mnubarTargetProses02SJSampaiDelivered
        ' 
        mnubarTargetProses02SJSampaiDelivered.Caption = "SuratJalan Sampai Delivered"
        mnubarTargetProses02SJSampaiDelivered.Id = 16
        mnubarTargetProses02SJSampaiDelivered.ImageOptions.SvgImage = CType(resources.GetObject("mnubarTargetProses02SJSampaiDelivered.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarTargetProses02SJSampaiDelivered.ItemAppearance.Normal.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        mnubarTargetProses02SJSampaiDelivered.ItemAppearance.Normal.ForeColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        mnubarTargetProses02SJSampaiDelivered.ItemAppearance.Normal.Options.UseFont = True
        mnubarTargetProses02SJSampaiDelivered.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarTargetProses02SJSampaiDelivered.Name = "mnubarTargetProses02SJSampaiDelivered"
        ' 
        ' mnuBarRefresh
        ' 
        mnuBarRefresh.AllowRightClickInMenu = False
        mnuBarRefresh.Caption = "Refresh"
        mnuBarRefresh.Enabled = False
        mnuBarRefresh.Id = 23
        mnuBarRefresh.ImageOptions.SvgImage = CType(resources.GetObject("mnuBarRefresh.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnuBarRefresh.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        mnuBarRefresh.ItemAppearance.Normal.ForeColor = Color.Navy
        mnuBarRefresh.ItemAppearance.Normal.Options.UseFont = True
        mnuBarRefresh.ItemAppearance.Normal.Options.UseForeColor = True
        mnuBarRefresh.Name = "mnuBarRefresh"
        mnuBarRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ToolTipTitleItem1.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True
        ToolTipTitleItem1.Text = "<i>Refresh the data.<i>"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        mnuBarRefresh.SuperTip = SuperToolTip1
        ' 
        ' mnubarDateProsesTransaksi
        ' 
        mnubarDateProsesTransaksi.Caption = "Tgl. Transaksi"
        mnubarDateProsesTransaksi.Edit = rsobjDateDelivered
        mnubarDateProsesTransaksi.EditWidth = 125
        mnubarDateProsesTransaksi.Id = 21
        mnubarDateProsesTransaksi.ImageOptions.SvgImage = CType(resources.GetObject("mnubarDateProsesTransaksi.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarDateProsesTransaksi.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarDateProsesTransaksi.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarDateProsesTransaksi.ItemAppearance.Normal.Options.UseFont = True
        mnubarDateProsesTransaksi.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarDateProsesTransaksi.Name = "mnubarDateProsesTransaksi"
        mnubarDateProsesTransaksi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsobjDateDelivered
        ' 
        rsobjDateDelivered.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsobjDateDelivered.Appearance.Options.UseFont = True
        rsobjDateDelivered.AutoHeight = False
        rsobjDateDelivered.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsobjDateDelivered.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsobjDateDelivered.DisplayFormat.FormatString = "dd/MM/yyyy"
        rsobjDateDelivered.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        rsobjDateDelivered.EditFormat.FormatString = "dd/MM/yyyy"
        rsobjDateDelivered.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        rsobjDateDelivered.MaskSettings.Set("mask", """dd/MM/yyyy""")
        rsobjDateDelivered.Name = "rsobjDateDelivered"
        rsobjDateDelivered.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        ' 
        ' mnubarPicker
        ' 
        mnubarPicker.Caption = "Picker "
        mnubarPicker.Edit = rsobjPicker
        mnubarPicker.EditValue = ""
        mnubarPicker.EditWidth = 200
        mnubarPicker.Id = 20
        mnubarPicker.ImageOptions.SvgImage = CType(resources.GetObject("mnubarPicker.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarPicker.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarPicker.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarPicker.ItemAppearance.Normal.Options.UseFont = True
        mnubarPicker.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarPicker.Name = "mnubarPicker"
        mnubarPicker.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' rsobjPicker
        ' 
        rsobjPicker.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        rsobjPicker.Appearance.Options.UseFont = True
        rsobjPicker.AutoHeight = False
        rsobjPicker.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        rsobjPicker.Name = "rsobjPicker"
        rsobjPicker.NullText = ""
        rsobjPicker.PopupView = RepositoryItemSearchLookUpEdit1View
        ' 
        ' RepositoryItemSearchLookUpEdit1View
        ' 
        RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {_col01f05StringKodePicker, _col02f06StringNamaPicker})
        RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        ' 
        ' _col01f05StringKodePicker
        ' 
        _col01f05StringKodePicker.Caption = "Code"
        _col01f05StringKodePicker.FieldName = "f05String"
        _col01f05StringKodePicker.Name = "_col01f05StringKodePicker"
        _col01f05StringKodePicker.Visible = True
        _col01f05StringKodePicker.VisibleIndex = 0
        ' 
        ' _col02f06StringNamaPicker
        ' 
        _col02f06StringNamaPicker.Caption = "Picker"
        _col02f06StringNamaPicker.FieldName = "f06String"
        _col02f06StringNamaPicker.Name = "_col02f06StringNamaPicker"
        _col02f06StringNamaPicker.Visible = True
        _col02f06StringNamaPicker.VisibleIndex = 1
        ' 
        ' mnubarPrintPicking
        ' 
        mnubarPrintPicking.Caption = "Print Picking"
        mnubarPrintPicking.Id = 10
        mnubarPrintPicking.ImageOptions.SvgImage = CType(resources.GetObject("mnubarPrintPicking.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarPrintPicking.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarPrintPicking.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarPrintPicking.ItemAppearance.Normal.Options.UseFont = True
        mnubarPrintPicking.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarPrintPicking.Name = "mnubarPrintPicking"
        mnubarPrintPicking.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnubarPickingSKU
        ' 
        mnubarPickingSKU.Caption = "Picking SKU"
        mnubarPickingSKU.Id = 9
        mnubarPickingSKU.ImageOptions.SvgImage = CType(resources.GetObject("mnubarPickingSKU.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarPickingSKU.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarPickingSKU.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarPickingSKU.ItemAppearance.Normal.Options.UseFont = True
        mnubarPickingSKU.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarPickingSKU.Name = "mnubarPickingSKU"
        mnubarPickingSKU.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnubarAggregateAirwayBill
        ' 
        mnubarAggregateAirwayBill.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        mnubarAggregateAirwayBill.Caption = "Aggregate-AirwayBill"
        mnubarAggregateAirwayBill.Id = 22
        mnubarAggregateAirwayBill.ImageOptions.SvgImage = CType(resources.GetObject("mnubarAggregateAirwayBill.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarAggregateAirwayBill.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarAggregateAirwayBill.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarAggregateAirwayBill.ItemAppearance.Normal.Options.UseFont = True
        mnubarAggregateAirwayBill.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarAggregateAirwayBill.Name = "mnubarAggregateAirwayBill"
        mnubarAggregateAirwayBill.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnubarSave
        ' 
        mnubarSave.Caption = "Save"
        mnubarSave.Id = 0
        mnubarSave.ImageOptions.SvgImage = CType(resources.GetObject("mnubarSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarSave.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarSave.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarSave.ItemAppearance.Normal.Options.UseFont = True
        mnubarSave.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarSave.Name = "mnubarSave"
        mnubarSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' mnubarGrid
        ' 
        mnubarGrid.Caption = "Grid"
        mnubarGrid.Id = 2
        mnubarGrid.ImageOptions.SvgImage = CType(resources.GetObject("mnubarGrid.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        mnubarGrid.ItemAppearance.Normal.Font = New Font("Nirmala UI Semilight", 9F)
        mnubarGrid.ItemAppearance.Normal.ForeColor = Color.Navy
        mnubarGrid.ItemAppearance.Normal.Options.UseFont = True
        mnubarGrid.ItemAppearance.Normal.Options.UseForeColor = True
        mnubarGrid.Name = "mnubarGrid"
        mnubarGrid.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        ' 
        ' barDockControlTop
        ' 
        barDockControlTop.Appearance.Font = New Font("Nirmala UI", 8F, FontStyle.Bold)
        barDockControlTop.Appearance.Options.UseFont = True
        barDockControlTop.CausesValidation = False
        barDockControlTop.Dock = DockStyle.Top
        barDockControlTop.Location = New Point(0, 0)
        barDockControlTop.Manager = BarManager1
        barDockControlTop.Margin = New Padding(2)
        barDockControlTop.Size = New Size(1253, 24)
        ' 
        ' barDockControlBottom
        ' 
        barDockControlBottom.CausesValidation = False
        barDockControlBottom.Dock = DockStyle.Bottom
        barDockControlBottom.Location = New Point(0, 365)
        barDockControlBottom.Manager = BarManager1
        barDockControlBottom.Margin = New Padding(2)
        barDockControlBottom.Size = New Size(1253, 0)
        ' 
        ' barDockControlLeft
        ' 
        barDockControlLeft.CausesValidation = False
        barDockControlLeft.Dock = DockStyle.Left
        barDockControlLeft.Location = New Point(0, 24)
        barDockControlLeft.Manager = BarManager1
        barDockControlLeft.Margin = New Padding(2)
        barDockControlLeft.Size = New Size(0, 341)
        ' 
        ' barDockControlRight
        ' 
        barDockControlRight.CausesValidation = False
        barDockControlRight.Dock = DockStyle.Right
        barDockControlRight.Location = New Point(1253, 24)
        barDockControlRight.Manager = BarManager1
        barDockControlRight.Margin = New Padding(2)
        barDockControlRight.Size = New Size(0, 341)
        ' 
        ' _01cSKUPicking
        ' 
        _01cSKUPicking.Appearance.Font = New Font("Courier New", 9F, FontStyle.Bold)
        _01cSKUPicking.Appearance.Options.UseFont = True
        _01cSKUPicking.AutoHeight = False
        _01cSKUPicking.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        _01cSKUPicking.CharacterCasing = CharacterCasing.Upper
        _01cSKUPicking.MaxLength = 100
        _01cSKUPicking.Name = "_01cSKUPicking"
        ' 
        ' _rsmnuBarPickingBRJ
        ' 
        _rsmnuBarPickingBRJ.AutoHeight = False
        _rsmnuBarPickingBRJ.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        _rsmnuBarPickingBRJ.Name = "_rsmnuBarPickingBRJ"
        ' 
        ' RepositoryItemTextEdit1
        ' 
        RepositoryItemTextEdit1.AutoHeight = False
        RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        ' 
        ' RepositoryItemTextEdit2
        ' 
        RepositoryItemTextEdit2.AutoHeight = False
        RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        ' 
        ' _rsmnuBarSKUPicking
        ' 
        _rsmnuBarSKUPicking.Appearance.Font = New Font("Courier New", 10F, FontStyle.Bold)
        _rsmnuBarSKUPicking.Appearance.Options.UseFont = True
        _rsmnuBarSKUPicking.AutoHeight = False
        _rsmnuBarSKUPicking.CharacterCasing = CharacterCasing.Upper
        _rsmnuBarSKUPicking.Name = "_rsmnuBarSKUPicking"
        ' 
        ' Bar2
        ' 
        Bar2.BarName = "Custom 3"
        Bar2.DockCol = 0
        Bar2.DockRow = 1
        Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar2.Text = "Custom 3"
        ' 
        ' Bar3
        ' 
        Bar3.BarName = "Custom 4"
        Bar3.DockCol = 0
        Bar3.DockRow = 2
        Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar3.Text = "Custom 4"
        ' 
        ' Bar4
        ' 
        Bar4.BarName = "Custom 3"
        Bar4.DockCol = 0
        Bar4.DockRow = 1
        Bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar4.Text = "Custom 3"
        ' 
        ' Bar5
        ' 
        Bar5.BarName = "Custom 3"
        Bar5.DockCol = 0
        Bar5.DockRow = 1
        Bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Bar5.Text = "Custom 3"
        ' 
        ' ucWS24G301OUTBOUNDPKB
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LayoutControl1)
        Controls.Add(barDockControlLeft)
        Controls.Add(barDockControlRight)
        Controls.Add(barDockControlBottom)
        Controls.Add(barDockControlTop)
        Margin = New Padding(2)
        Name = "ucWS24G301OUTBOUNDPKB"
        Size = New Size(1253, 365)
        CType(LayoutControl1, ComponentModel.ISupportInitialize).EndInit()
        LayoutControl1.ResumeLayout(False)
        CType(Root, ComponentModel.ISupportInitialize).EndInit()
        CType(LayoutControlItem2, ComponentModel.ISupportInitialize).EndInit()
        CType(BarManager1, ComponentModel.ISupportInitialize).EndInit()
        CType(rsobjDateDelivered.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(rsobjDateDelivered, ComponentModel.ISupportInitialize).EndInit()
        CType(rsobjPicker, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemSearchLookUpEdit1View, ComponentModel.ISupportInitialize).EndInit()
        CType(_01cSKUPicking, ComponentModel.ISupportInitialize).EndInit()
        CType(_rsmnuBarPickingBRJ, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemTextEdit1, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryItemTextEdit2, ComponentModel.ISupportInitialize).EndInit()
        CType(_rsmnuBarSKUPicking, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnubarSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnubarGrid As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents _01cSKUPicking As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents _gdOutboundPKB As SKK02OBJECTS.ucWSGridParentChild
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _rsmnuBarPickingBRJ As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents _rsmnuBarSKUPicking As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents mnubarPickingSKU As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnubarPrintPicking As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnubarTargetProses As DevExpress.XtraBars.BarSubItem
    Friend WithEvents mnubarTargetProses01NewPKBSampaiSJ As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnubarTargetProses02SJSampaiDelivered As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar4 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar5 As DevExpress.XtraBars.Bar
    Friend WithEvents mnubarPicker As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsobjPicker As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _col01f05StringKodePicker As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _col02f06StringNamaPicker As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents mnubarDateProsesTransaksi As DevExpress.XtraBars.BarEditItem
    Friend WithEvents rsobjDateDelivered As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents mnubarAggregateAirwayBill As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuBarRefresh As DevExpress.XtraBars.BarButtonItem

End Class
