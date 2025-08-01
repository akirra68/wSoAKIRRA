<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class xr24LE03RP_SuratJalan
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(xr24LE03RP_SuratJalan))
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me._kopSurat = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._01NomorSJ = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._02Customer = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._03NomorOrder = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.SubReportPackaging = New DevExpress.XtraReports.UI.XRSubreport()
        Me.SubReportSuratJalan = New DevExpress.XtraReports.UI.XRSubreport()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me._PrintDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.HeightF = 0!
        Me.Detail.Name = "Detail"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me._kopSurat})
        Me.PageHeader.HeightF = 157.9619!
        Me.PageHeader.Name = "PageHeader"
        '
        '_kopSurat
        '
        Me._kopSurat.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("_kopSurat.ImageSource"))
        Me._kopSurat.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me._kopSurat.Name = "_kopSurat"
        Me._kopSurat.SizeF = New System.Drawing.SizeF(826.9999!, 157.9619!)
        Me._kopSurat.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrLabel1})
        Me.GroupHeader1.HeightF = 145.4043!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'XrTable1
        '
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 64.57843!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow3, Me.XrTableRow4})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(776.7962!, 70.82587!)
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell5, Me._01NomorSJ})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "Nomor SJ"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell4.Weight = 0.88368061640368722R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell5.Multiline = True
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.Text = ":"
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell5.Weight = 0.12094891415265119R
        '
        '_01NomorSJ
        '
        Me._01NomorSJ.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._01NomorSJ.Multiline = True
        Me._01NomorSJ.Name = "_01NomorSJ"
        Me._01NomorSJ.StylePriority.UseFont = False
        Me._01NomorSJ.StylePriority.UseTextAlignment = False
        Me._01NomorSJ.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._01NomorSJ.Weight = 6.7633321578957961R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.XrTableCell8, Me._02Customer})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell7.Multiline = True
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.Text = "Customer"
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell7.Weight = 0.88368061640368722R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell8.Multiline = True
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = ":"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell8.Weight = 0.12094883785871524R
        '
        '_02Customer
        '
        Me._02Customer.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._02Customer.Multiline = True
        Me._02Customer.Name = "_02Customer"
        Me._02Customer.StylePriority.UseFont = False
        Me._02Customer.StylePriority.UseTextAlignment = False
        Me._02Customer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._02Customer.Weight = 6.7633322341897317R
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell10, Me.XrTableCell11, Me._03NomorOrder})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 2.2627797529688074R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell10.Multiline = True
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseFont = False
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = "Nomor Order"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell10.Weight = 0.88368061640368722R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell11.Multiline = True
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.StylePriority.UseFont = False
        Me.XrTableCell11.StylePriority.UseTextAlignment = False
        Me.XrTableCell11.Text = ":"
        Me.XrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell11.Weight = 0.12094891415265119R
        '
        '_03NomorOrder
        '
        Me._03NomorOrder.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._03NomorOrder.Multiline = True
        Me._03NomorOrder.Name = "_03NomorOrder"
        Me._03NomorOrder.StylePriority.UseFont = False
        Me._03NomorOrder.StylePriority.UseTextAlignment = False
        Me._03NomorOrder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._03NomorOrder.Weight = 6.7633321578957961R
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 21.99997!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(827.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "SURAT JALAN"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SubReportPackaging, Me.SubReportSuratJalan})
        Me.GroupFooter1.HeightF = 75.49997!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'SubReportPackaging
        '
        Me.SubReportPackaging.LocationFloat = New DevExpress.Utils.PointFloat(9.999997!, 54.24997!)
        Me.SubReportPackaging.Name = "SubReportPackaging"
        Me.SubReportPackaging.SizeF = New System.Drawing.SizeF(803.0!, 21.25!)
        '
        'SubReportSuratJalan
        '
        Me.SubReportSuratJalan.LocationFloat = New DevExpress.Utils.PointFloat(9.999997!, 0!)
        Me.SubReportSuratJalan.Name = "SubReportSuratJalan"
        Me.SubReportSuratJalan.SizeF = New System.Drawing.SizeF(803.0!, 21.25!)
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me._PrintDate, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 81.48588!
        Me.PageFooter.Name = "PageFooter"
        '
        '_PrintDate
        '
        Me._PrintDate.Font = New DevExpress.Drawing.DXFont("Nirmala UI", 7.0!, CType((DevExpress.Drawing.DXFontStyle.Bold Or DevExpress.Drawing.DXFontStyle.Italic), DevExpress.Drawing.DXFontStyle))
        Me._PrintDate.LocationFloat = New DevExpress.Utils.PointFloat(559.8751!, 0!)
        Me._PrintDate.Multiline = True
        Me._PrintDate.Name = "_PrintDate"
        Me._PrintDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me._PrintDate.SizeF = New System.Drawing.SizeF(255.1249!, 12.99999!)
        Me._PrintDate.StylePriority.UseFont = False
        Me._PrintDate.StylePriority.UseTextAlignment = False
        Me._PrintDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Font = New DevExpress.Drawing.DXFont("Nirmala UI", 7.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(715.0!, 12.99999!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xr24LE03RP_SuratJalan
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageHeader, Me.GroupHeader1, Me.GroupFooter1, Me.PageFooter})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 0!, 0!, 0!)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4
        Me.Version = "24.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Private WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents _kopSurat As DevExpress.XtraReports.UI.XRPictureBox
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _01NomorSJ As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _02Customer As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _03NomorOrder As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents SubReportSuratJalan As DevExpress.XtraReports.UI.XRSubreport
    Private WithEvents SubReportPackaging As DevExpress.XtraReports.UI.XRSubreport
    Private WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents _PrintDate As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
