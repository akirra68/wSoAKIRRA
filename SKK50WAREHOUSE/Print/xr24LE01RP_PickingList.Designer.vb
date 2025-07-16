<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class xr24LE01RP_PickingList
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
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me._PrintDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.SubReportPickingList = New DevExpress.XtraReports.UI.XRSubreport()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._01NomorPicking = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._02PIC = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._04TanggalOrder = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._03NamaCustomer = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._01NomorOrder = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me._PrintDate, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 82.61125!
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
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrTable2})
        Me.PageHeader.HeightF = 103.5511!
        Me.PageHeader.Name = "PageHeader"
        '
        'SubReportPickingList
        '
        Me.SubReportPickingList.LocationFloat = New DevExpress.Utils.PointFloat(0.0001773834!, 0!)
        Me.SubReportPickingList.Name = "SubReportPickingList"
        Me.SubReportPickingList.SizeF = New System.Drawing.SizeF(784.8469!, 23.0!)
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SubReportPickingList})
        Me.ReportFooter.HeightF = 23.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrLabel2, Me.XrLabel3})
        Me.ReportHeader.HeightF = 100.7187!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00005817414!, 23.0!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(826.9999!, 17.21191!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "PICKING LIST"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0001773834!, 45.2119!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(826.9998!, 17.21191!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PT SENTRAL KREASI KENCANA"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0001773834!, 67.42384!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(826.9998!, 17.21191!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "WAREHOUSE"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTable1
        '
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(20.02574!, 13.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2, Me.XrTableRow3, Me.XrTableRow4, Me.XrTableRow5})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(433.5417!, 90.55115!)
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell5, Me._01NomorPicking})
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
        Me.XrTableCell4.Text = "Nomor Picking"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell4.Weight = 0.76820710506891865R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell5.Multiline = True
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UseTextAlignment = False
        Me.XrTableCell5.Text = ":"
        Me.XrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell5.Weight = 0.13150670778059304R
        '
        '_01NomorPicking
        '
        Me._01NomorPicking.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._01NomorPicking.Multiline = True
        Me._01NomorPicking.Name = "_01NomorPicking"
        Me._01NomorPicking.StylePriority.UseFont = False
        Me._01NomorPicking.StylePriority.UseTextAlignment = False
        Me._01NomorPicking.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._01NomorPicking.Weight = 2.5147812217027479R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.XrTableCell8, Me._02PIC})
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
        Me.XrTableCell7.Text = "PIC"
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell7.Weight = 0.76820710506891865R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell8.Multiline = True
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.StylePriority.UseFont = False
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = ":"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell8.Weight = 0.13150670778059304R
        '
        '_02PIC
        '
        Me._02PIC.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._02PIC.Multiline = True
        Me._02PIC.Name = "_02PIC"
        Me._02PIC.StylePriority.UseFont = False
        Me._02PIC.StylePriority.UseTextAlignment = False
        Me._02PIC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._02PIC.Weight = 2.5147812217027479R
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3, Me.XrTableCell6, Me._04TanggalOrder})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "Tanggal Order"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell3.Weight = 0.76820710506891865R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell6.Multiline = True
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.Text = ":"
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell6.Weight = 0.13150670778059304R
        '
        '_04TanggalOrder
        '
        Me._04TanggalOrder.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._04TanggalOrder.Multiline = True
        Me._04TanggalOrder.Name = "_04TanggalOrder"
        Me._04TanggalOrder.StylePriority.UseFont = False
        Me._04TanggalOrder.StylePriority.UseTextAlignment = False
        Me._04TanggalOrder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._04TanggalOrder.TextFormatString = "{0:dd/MM/yyyy}"
        Me._04TanggalOrder.Weight = 2.5147812217027479R
        '
        'XrTable2
        '
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(524.1737!, 13.00001!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(290.8263!, 47.79997!)
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me._03NamaCustomer})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "Nama Customer"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell1.Weight = 1.2286214475077146R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = ":"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell2.Weight = 0.21024527084914812R
        '
        '_03NamaCustomer
        '
        Me._03NamaCustomer.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._03NamaCustomer.Multiline = True
        Me._03NamaCustomer.Name = "_03NamaCustomer"
        Me._03NamaCustomer.StylePriority.UseFont = False
        Me._03NamaCustomer.StylePriority.UseTextAlignment = False
        Me._03NamaCustomer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._03NamaCustomer.Weight = 1.9917628595615726R
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell9, Me.XrTableCell10, Me._01NomorOrder})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.739141424123833R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell9.Multiline = True
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.StylePriority.UseFont = False
        Me.XrTableCell9.StylePriority.UseTextAlignment = False
        Me.XrTableCell9.Text = "Nomor Order"
        Me.XrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrTableCell9.Weight = 0.76820710506891865R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrTableCell10.Multiline = True
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StylePriority.UseFont = False
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = ":"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrTableCell10.Weight = 0.13150670778059304R
        '
        '_01NomorOrder
        '
        Me._01NomorOrder.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me._01NomorOrder.Multiline = True
        Me._01NomorOrder.Name = "_01NomorOrder"
        Me._01NomorOrder.StylePriority.UseFont = False
        Me._01NomorOrder.StylePriority.UseTextAlignment = False
        Me._01NomorOrder.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me._01NomorOrder.Weight = 2.5147812217027479R
        '
        'xr24LE01RP_PickingList
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageFooter, Me.PageHeader, Me.ReportFooter, Me.ReportHeader})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 0!, 0!, 0!)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4
        Me.RequestParameters = False
        Me.Version = "24.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Private WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents SubReportPickingList As DevExpress.XtraReports.UI.XRSubreport
    Private WithEvents _PrintDate As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _01NomorPicking As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _02PIC As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _04TanggalOrder As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _03NamaCustomer As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _01NomorOrder As DevExpress.XtraReports.UI.XRTableCell
End Class
