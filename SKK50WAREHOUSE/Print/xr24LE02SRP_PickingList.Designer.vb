<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class xr24LE02SRP_PickingList
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me._01NomorUrut = New DevExpress.XtraReports.UI.XRTableCell()
        Me._02Segmen = New DevExpress.XtraReports.UI.XRTableCell()
        Me._03ProductCode = New DevExpress.XtraReports.UI.XRTableCell()
        Me._04MasterCode = New DevExpress.XtraReports.UI.XRTableCell()
        Me._05Qty = New DevExpress.XtraReports.UI.XRTableCell()
        Me._06Alamat = New DevExpress.XtraReports.UI.XRTableCell()
        Me._07Collection = New DevExpress.XtraReports.UI.XRTableCell()
        Me._08Item = New DevExpress.XtraReports.UI.XRTableCell()
        Me._09Kadar = New DevExpress.XtraReports.UI.XRTableCell()
        Me._10Size = New DevExpress.XtraReports.UI.XRTableCell()
        Me._11Warna = New DevExpress.XtraReports.UI.XRTableCell()
        Me._12Order = New DevExpress.XtraReports.UI.XRTableCell()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me._10Hbarang = New DevExpress.XtraReports.UI.XRTableCell()
        Me._11Hnofaktur = New DevExpress.XtraReports.UI.XRTableCell()
        Me._12Hqty = New DevExpress.XtraReports.UI.XRTableCell()
        Me._13Hgross = New DevExpress.XtraReports.UI.XRTableCell()
        Me._14Htukaran = New DevExpress.XtraReports.UI.XRTableCell()
        Me._14Haddcharge = New DevExpress.XtraReports.UI.XRTableCell()
        Me._15Hnet = New DevExpress.XtraReports.UI.XRTableCell()
        Me._16Hkurs = New DevExpress.XtraReports.UI.XRTableCell()
        Me._17Hkurs = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BottomMargin.HeightF = 0.5555471!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail.HeightF = 24.61805!
        Me.Detail.Name = "Detail"
        '
        'XrTable2
        '
        Me.XrTable2.BackColor = System.Drawing.Color.White
        Me.XrTable2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrTable2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.BorderWidth = 1.0!
        Me.XrTable2.Font = New DevExpress.Drawing.DXFont("Courier New", 7.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(19.45834!, 0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(790.5417!, 24.61805!)
        Me.XrTable2.StylePriority.UseBackColor = False
        Me.XrTable2.StylePriority.UseBorderDashStyle = False
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseBorderWidth = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me._01NomorUrut, Me._02Segmen, Me._03ProductCode, Me._04MasterCode, Me._05Qty, Me._06Alamat, Me._07Collection, Me._08Item, Me._09Kadar, Me._10Size, Me._11Warna, Me._12Order})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        '_01NomorUrut
        '
        Me._01NomorUrut.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._01NomorUrut.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._01NomorUrut.BorderWidth = 1.0!
        Me._01NomorUrut.Multiline = True
        Me._01NomorUrut.Name = "_01NomorUrut"
        Me._01NomorUrut.StylePriority.UseBorderDashStyle = False
        Me._01NomorUrut.StylePriority.UseBorders = False
        Me._01NomorUrut.StylePriority.UseBorderWidth = False
        Me._01NomorUrut.Text = "No"
        Me._01NomorUrut.Weight = 0.24135369876719362R
        '
        '_02Segmen
        '
        Me._02Segmen.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._02Segmen.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._02Segmen.BorderWidth = 1.0!
        Me._02Segmen.Multiline = True
        Me._02Segmen.Name = "_02Segmen"
        Me._02Segmen.StylePriority.UseBorderDashStyle = False
        Me._02Segmen.StylePriority.UseBorders = False
        Me._02Segmen.StylePriority.UseBorderWidth = False
        Me._02Segmen.Text = "HALA"
        Me._02Segmen.Weight = 0.57514359824688421R
        '
        '_03ProductCode
        '
        Me._03ProductCode.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._03ProductCode.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._03ProductCode.BorderWidth = 1.0!
        Me._03ProductCode.Multiline = True
        Me._03ProductCode.Name = "_03ProductCode"
        Me._03ProductCode.StylePriority.UseBorderDashStyle = False
        Me._03ProductCode.StylePriority.UseBorders = False
        Me._03ProductCode.StylePriority.UseBorderWidth = False
        Me._03ProductCode.Text = "Product Code"
        Me._03ProductCode.Weight = 0.87588263077930772R
        '
        '_04MasterCode
        '
        Me._04MasterCode.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._04MasterCode.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._04MasterCode.BorderWidth = 1.0!
        Me._04MasterCode.Multiline = True
        Me._04MasterCode.Name = "_04MasterCode"
        Me._04MasterCode.StylePriority.UseBorderDashStyle = False
        Me._04MasterCode.StylePriority.UseBorders = False
        Me._04MasterCode.StylePriority.UseBorderWidth = False
        Me._04MasterCode.Text = "Master Code"
        Me._04MasterCode.Weight = 0.83426098874766907R
        '
        '_05Qty
        '
        Me._05Qty.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._05Qty.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._05Qty.BorderWidth = 1.0!
        Me._05Qty.Multiline = True
        Me._05Qty.Name = "_05Qty"
        Me._05Qty.StylePriority.UseBorderDashStyle = False
        Me._05Qty.StylePriority.UseBorders = False
        Me._05Qty.StylePriority.UseBorderWidth = False
        Me._05Qty.Text = "QTY"
        Me._05Qty.Weight = 0.3043391229757843R
        '
        '_06Alamat
        '
        Me._06Alamat.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._06Alamat.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._06Alamat.BorderWidth = 1.0!
        Me._06Alamat.Multiline = True
        Me._06Alamat.Name = "_06Alamat"
        Me._06Alamat.StylePriority.UseBorderDashStyle = False
        Me._06Alamat.StylePriority.UseBorders = False
        Me._06Alamat.StylePriority.UseBorderWidth = False
        Me._06Alamat.Text = "Alamat"
        Me._06Alamat.Weight = 1.3354014402188796R
        '
        '_07Collection
        '
        Me._07Collection.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._07Collection.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._07Collection.BorderWidth = 1.0!
        Me._07Collection.Multiline = True
        Me._07Collection.Name = "_07Collection"
        Me._07Collection.StylePriority.UseBorderDashStyle = False
        Me._07Collection.StylePriority.UseBorders = False
        Me._07Collection.StylePriority.UseBorderWidth = False
        Me._07Collection.Text = "REFLECTA VOL 3"
        Me._07Collection.Weight = 1.3096178119039941R
        '
        '_08Item
        '
        Me._08Item.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._08Item.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._08Item.BorderWidth = 1.0!
        Me._08Item.Multiline = True
        Me._08Item.Name = "_08Item"
        Me._08Item.StylePriority.UseBorderDashStyle = False
        Me._08Item.StylePriority.UseBorders = False
        Me._08Item.StylePriority.UseBorderWidth = False
        Me._08Item.Text = "Necklace"
        Me._08Item.Weight = 0.75144089171472039R
        '
        '_09Kadar
        '
        Me._09Kadar.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._09Kadar.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me._09Kadar.BorderWidth = 1.0!
        Me._09Kadar.Multiline = True
        Me._09Kadar.Name = "_09Kadar"
        Me._09Kadar.StylePriority.UseBorderDashStyle = False
        Me._09Kadar.StylePriority.UseBorders = False
        Me._09Kadar.StylePriority.UseBorderWidth = False
        Me._09Kadar.Text = "755"
        Me._09Kadar.Weight = 0.49624201930201361R
        '
        '_10Size
        '
        Me._10Size.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._10Size.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._10Size.BorderWidth = 1.0!
        Me._10Size.Multiline = True
        Me._10Size.Name = "_10Size"
        Me._10Size.StylePriority.UseBorderDashStyle = False
        Me._10Size.StylePriority.UseBorders = False
        Me._10Size.StylePriority.UseBorderWidth = False
        Me._10Size.Text = "Size"
        Me._10Size.Weight = 0.441355538130938R
        '
        '_11Warna
        '
        Me._11Warna.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._11Warna.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._11Warna.BorderWidth = 1.0!
        Me._11Warna.Multiline = True
        Me._11Warna.Name = "_11Warna"
        Me._11Warna.StylePriority.UseBorderDashStyle = False
        Me._11Warna.StylePriority.UseBorders = False
        Me._11Warna.StylePriority.UseBorderWidth = False
        Me._11Warna.Text = "Rose Gold"
        Me._11Warna.Weight = 0.72818065549726008R
        '
        '_12Order
        '
        Me._12Order.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._12Order.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._12Order.BorderWidth = 1.0!
        Me._12Order.Multiline = True
        Me._12Order.Name = "_12Order"
        Me._12Order.StylePriority.UseBorderDashStyle = False
        Me._12Order.StylePriority.UseBorders = False
        Me._12Order.StylePriority.UseBorderWidth = False
        Me._12Order.Text = "PO240101"
        Me._12Order.Weight = 0.79688372785907213R
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.PageHeader.HeightF = 23.78473!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrTable1
        '
        Me.XrTable1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.XrTable1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrTable1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.BorderWidth = 1.0!
        Me.XrTable1.Font = New DevExpress.Drawing.DXFont("Nirmala UI", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(19.45834!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(790.5417!, 23.78473!)
        Me.XrTable1.StylePriority.UseBackColor = False
        Me.XrTable1.StylePriority.UseBorderDashStyle = False
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseBorderWidth = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me._10Hbarang, Me._11Hnofaktur, Me._12Hqty, Me._13Hgross, Me._14Htukaran, Me._14Haddcharge, Me._15Hnet, Me._16Hkurs, Me._17Hkurs, Me.XrTableCell2, Me.XrTableCell3})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrTableCell1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell1.BorderWidth = 1.0!
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseBorderDashStyle = False
        Me.XrTableCell1.StylePriority.UseBorders = False
        Me.XrTableCell1.StylePriority.UseBorderWidth = False
        Me.XrTableCell1.Text = "No"
        Me.XrTableCell1.Weight = 0.24135369760667114R
        '
        '_10Hbarang
        '
        Me._10Hbarang.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._10Hbarang.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._10Hbarang.BorderWidth = 1.0!
        Me._10Hbarang.Multiline = True
        Me._10Hbarang.Name = "_10Hbarang"
        Me._10Hbarang.StylePriority.UseBorderDashStyle = False
        Me._10Hbarang.StylePriority.UseBorders = False
        Me._10Hbarang.StylePriority.UseBorderWidth = False
        Me._10Hbarang.Text = "Segmen"
        Me._10Hbarang.Weight = 0.57514363959944859R
        '
        '_11Hnofaktur
        '
        Me._11Hnofaktur.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._11Hnofaktur.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._11Hnofaktur.BorderWidth = 1.0!
        Me._11Hnofaktur.Multiline = True
        Me._11Hnofaktur.Name = "_11Hnofaktur"
        Me._11Hnofaktur.StylePriority.UseBorderDashStyle = False
        Me._11Hnofaktur.StylePriority.UseBorders = False
        Me._11Hnofaktur.StylePriority.UseBorderWidth = False
        Me._11Hnofaktur.Text = "Product Code"
        Me._11Hnofaktur.Weight = 0.87588267213421545R
        '
        '_12Hqty
        '
        Me._12Hqty.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._12Hqty.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._12Hqty.BorderWidth = 1.0!
        Me._12Hqty.Multiline = True
        Me._12Hqty.Name = "_12Hqty"
        Me._12Hqty.StylePriority.UseBorderDashStyle = False
        Me._12Hqty.StylePriority.UseBorders = False
        Me._12Hqty.StylePriority.UseBorderWidth = False
        Me._12Hqty.Text = "Master Code"
        Me._12Hqty.Weight = 0.834260737147201R
        '
        '_13Hgross
        '
        Me._13Hgross.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._13Hgross.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._13Hgross.BorderWidth = 1.0!
        Me._13Hgross.Multiline = True
        Me._13Hgross.Name = "_13Hgross"
        Me._13Hgross.StylePriority.UseBorderDashStyle = False
        Me._13Hgross.StylePriority.UseBorders = False
        Me._13Hgross.StylePriority.UseBorderWidth = False
        Me._13Hgross.Text = "QTY"
        Me._13Hgross.Weight = 0.30433912244827555R
        '
        '_14Htukaran
        '
        Me._14Htukaran.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._14Htukaran.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._14Htukaran.BorderWidth = 1.0!
        Me._14Htukaran.Multiline = True
        Me._14Htukaran.Name = "_14Htukaran"
        Me._14Htukaran.StylePriority.UseBorderDashStyle = False
        Me._14Htukaran.StylePriority.UseBorders = False
        Me._14Htukaran.StylePriority.UseBorderWidth = False
        Me._14Htukaran.Text = "Alamat"
        Me._14Htukaran.Weight = 1.3354011029580497R
        '
        '_14Haddcharge
        '
        Me._14Haddcharge.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._14Haddcharge.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._14Haddcharge.BorderWidth = 1.0!
        Me._14Haddcharge.Multiline = True
        Me._14Haddcharge.Name = "_14Haddcharge"
        Me._14Haddcharge.StylePriority.UseBorderDashStyle = False
        Me._14Haddcharge.StylePriority.UseBorders = False
        Me._14Haddcharge.StylePriority.UseBorderWidth = False
        Me._14Haddcharge.Text = "Collection"
        Me._14Haddcharge.Weight = 1.3096185680769166R
        '
        '_15Hnet
        '
        Me._15Hnet.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._15Hnet.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._15Hnet.BorderWidth = 1.0!
        Me._15Hnet.Multiline = True
        Me._15Hnet.Name = "_15Hnet"
        Me._15Hnet.StylePriority.UseBorderDashStyle = False
        Me._15Hnet.StylePriority.UseBorders = False
        Me._15Hnet.StylePriority.UseBorderWidth = False
        Me._15Hnet.Text = "Item"
        Me._15Hnet.Weight = 0.75143954952905279R
        '
        '_16Hkurs
        '
        Me._16Hkurs.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._16Hkurs.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._16Hkurs.BorderWidth = 1.0!
        Me._16Hkurs.Multiline = True
        Me._16Hkurs.Name = "_16Hkurs"
        Me._16Hkurs.StylePriority.UseBorderDashStyle = False
        Me._16Hkurs.StylePriority.UseBorders = False
        Me._16Hkurs.StylePriority.UseBorderWidth = False
        Me._16Hkurs.Text = "Kadar"
        Me._16Hkurs.Weight = 0.49624201846736488R
        '
        '_17Hkurs
        '
        Me._17Hkurs.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me._17Hkurs.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me._17Hkurs.BorderWidth = 1.0!
        Me._17Hkurs.Multiline = True
        Me._17Hkurs.Name = "_17Hkurs"
        Me._17Hkurs.StylePriority.UseBorderDashStyle = False
        Me._17Hkurs.StylePriority.UseBorders = False
        Me._17Hkurs.StylePriority.UseBorderWidth = False
        Me._17Hkurs.Text = "Size"
        Me._17Hkurs.Weight = 0.44135620736812492R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrTableCell2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell2.BorderWidth = 1.0!
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseBorderDashStyle = False
        Me.XrTableCell2.StylePriority.UseBorders = False
        Me.XrTableCell2.StylePriority.UseBorderWidth = False
        Me.XrTableCell2.Text = "Warna"
        Me.XrTableCell2.Weight = 0.72818074020693113R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
        Me.XrTableCell3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell3.BorderWidth = 1.0!
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseBorderDashStyle = False
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.StylePriority.UseBorderWidth = False
        Me.XrTableCell3.Text = "Order"
        Me.XrTableCell3.Weight = 0.79688414866904467R
        '
        'xr24LE02SRP_PickingList
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageHeader})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 0!, 0!, 0.5555471!)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4
        Me.RequestParameters = False
        Me.Version = "24.2"
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Private WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _10Hbarang As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _11Hnofaktur As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _12Hqty As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _13Hgross As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _14Htukaran As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _14Haddcharge As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _15Hnet As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _16Hkurs As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _17Hkurs As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents _01NomorUrut As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _02Segmen As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _03ProductCode As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _04MasterCode As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _05Qty As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _06Alamat As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _07Collection As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _08Item As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _09Kadar As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _10Size As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _11Warna As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents _12Order As DevExpress.XtraReports.UI.XRTableCell
End Class
