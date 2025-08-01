Imports System.Drawing.Printing
Imports SKK02OBJECTS
Imports RawPrinterHelper

Public Class cls24FX01CreateLabelBarcode
    Implements IDisposable

#Region "dispose"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

    Public Property _prop01User As clsWSNasaUser
    Public Property prop01_NoSPK As String ' isi nya NO SPK (ZN1234) bukan (ZN1234-001)
    Public Property prop02_TypeLabelBarcode As String ' isi nya (NORMAL, CMK , BELALAI, COLOR)
    Public Property prop03_NamaBrand As String

    Private Property pdtInBound As New DataTable

#Region " How To Used "
    'Type label
    ' ------------------------------------------------------------------------
    ' Normal = (label yg sudah ada warna bordser nya (Hala,SDW,Ily)) size 60 x20 mm
    ' CMK = label yanga da harga nya size 60 x20 mm
    ' Belalai = Label yg left nya saja di isi karna di lipat 2 dana da belalai ' (70 x 29 mm)
    '-------------------------------------------------------------------------

    '****************************************
    '01. Cetak Langsung saat save data Selesai
    '***************************************

    'Private HelperCTX As New cls24FX01CreateLabelBarcode
    'HelperCTX.prop01_NoSPK = " NO SPK " ' (Tanpa sparator -00)
    'HelperCTX.prop02_TypeLabelBarcode = _26LabelSetting.EditValue ' ' isi STRING (NORMAL, CMK , BELALAi)
    'HelperCTX.cm01CetakLabelBarcode()


    '****************************************
    '02. Reprint Data
    '****************************************
    'Dim prmBarCode As String = ""

    'For i As Integer = 0 To GridView1.RowCount

    '    HelperCTX.prop01_NoSPK = " NO SKU " 
    '    HelperCTX.prop02_TypeLabelBarcode = _26LabelSetting.EditValue ' isi STRING (NORMAL, CMK , BELALAi)
    '    prmBarCode = String.Concat(prmBarCode, HelperCTX.cm02GenerateLabelBarcode())

    'Next

    ''*** Cetak label
    'HelperCTX.cm03ReprintBarcode(prmBarCode)


#End Region

#Region " Private Custome Methods"


    Private Function cm00GenerateLabelCOLOR()

        Dim quantity As Integer = 0
        Dim codeZPL As String = ""

        ' *** param untuk Geser BArcode Sesuai leng SKu
        Dim prmPointBarcode_X As String = "" ' 12 (^FO30,60 ) |  14 (^FO25,60 ) posisi kiri start dari point berapa ke kanan

#Region " Template "
        ' Labale untuk HALA & SDW, yang buat CMK pakai warna dan sudah ada BRand nya
        ' hala -> IJO
        ' SDW -> Oren

        ' Templte Untuk BRAND SKK
        '*****************************************************************
        ' Created : Kamis, 20 Juni 2024 (Arif)
        'SIZE label W:60mm H:20mm
        'Full Code tempaklet untuk print label nya berikut ini
        ' link Untuk Preview ZPL code = h*t*t*p*s://labelary.com/viewer.html
        ' copy paste ZPL code nya -> pilih redraws
        '*****************************************************************
        '    empalte label SKK brand (size label W = 60mm ,H = 20mm)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ
        '^XA
        '^MMT
        '^PW480
        '^LL0160
        '^LS0
        '^FT224,41^AAR,18,10^FB97,1,0,C^FH\^FDEARRING^FS
        '^FT262,55^AAN,18,10^FH\^FDQTY:1 ^FS
        '^FT262,80^AAN,18,10^FH\^FD1.230gr 12sz^FS
        '^FT262,102^AAN,18,10^FH\^FDWHITE^FS
        '^FT262,125^AAN,18,10^FH\^FDEA190088-001^FS
        ' ^FT430,35^A0R,36,40^FB112,1,0,C^FH\^FDHALA^FS
        '^FT75,55^AAN,18,10^FH\^FDHALA 755^FS
        '^FT33,130^AAN,18,10^FH\^FDZN202210-005^FS
        '^BY 1,2,70^FO34,60^BC,50,N,N,N,N^FDZN202210-005^FS
        '^PQ1,0,1,Y^XZ
        '*****************************************************************

#End Region

        'codeZPL = String.Concat(codeZPL, "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ") ' --> Setting ketebalan tinta ( SD30 )
        Dim prmBRAND As String = ""
        Dim prmLeghtBrand As String = ""


        For Each itm As DataRow In pdtInBound.Rows

            ' *** cek Leng SKu
            prmPointBarcode_X = cm04SetPointBarcdoe(CInt(Len(CStr(itm("k02String")))))

            codeZPL = String.Concat(codeZPL, "^XA") ' tag Open
            codeZPL = String.Concat(codeZPL, "^MMT")
            codeZPL = String.Concat(codeZPL, "^PW480")
            codeZPL = String.Concat(codeZPL, "^LL0160")
            codeZPL = String.Concat(codeZPL, "^LS0")
            codeZPL = String.Concat(codeZPL, "^FT224,41^AAR,18,10^FB97,1,0,C^FH\^FD", CStr(itm("f12String")), "^FS") ' Setting item
            ' codeZPL = String.Concat(codeZPL, "^FT262,55^AAN,18,10^FH\^FD", String.Format("QTY:{0} {1}sz", CStr(itm("f01SmallInt")), CStr(itm("f14String"))), "^FS") ' Setting Qty, Size

            ' Set size jika tidak ada size di hilangkan
            If Not String.IsNullOrEmpty(CStr(itm("f14String"))) Then
                codeZPL = String.Concat(codeZPL, "^FT262,55^AAN,18,10^FH\^FD", String.Format("QTY:{0} ", CStr(itm("f01SmallInt"))), String.Format("{0}sz", CStr(itm("f14String"))), "^FS") ' Setting Qty, Size : sz
            Else
                codeZPL = String.Concat(codeZPL, "^FT262,55^AAN,18,10^FH\^FD", String.Format("QTY:{0} ", CStr(itm("f01SmallInt"))), "^FS") ' Setting Qty, Size : sz

            End If

            codeZPL = String.Concat(codeZPL, "^FT262,80^AAN,18,10^FH\^FD", CStr(FormatNumber(itm("f01Double"), 2)), "gr", "^FS") ' Setting berat (2digit)
            'codeZPL = String.Concat(codeZPL, "^FT262,80^AAN,18,10^FH\^FD", CStr(itm("f01Double")), "gr", "^FS") ' Setting berat (3digit)
            codeZPL = String.Concat(codeZPL, "^FT262,102^AAN,18,10^FH\^FD", CStr(itm("f08String")), "^FS") ' Setting Warna
            codeZPL = String.Concat(codeZPL, "^FT262,125^AAN,18,10^FH\^FD", CStr(itm("f01String")), "^FS") ' Setting Prodcut Code
            '  codeZPL = String.Concat(codeZPL, "^FT75,55^AAN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand kadar
            codeZPL = String.Concat(codeZPL, "^FT", cm04SetPointBRandKadar(CStr(itm("f16String"))), ",55^AAN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand kadar

            ' *** Request Selian Brand HANYA HALA , SWD baca note di atas
            'codeZPL = String.Concat(codeZPL, "^FT430,35^A0R,36,40^FB112,1,0,C^FH\^FD", String.Format("{0}", CStr(itm("f16String"))), "^FS") ' Setting Brand 
            ' codeZPL = String.Concat(codeZPL, "^FT430,35^A0R,36,40^FB112,1,0,C^FH\^FD", cm06GetReserByKodeBrand(itm("f15String")), "^FS") ' Setting Brand VERTICAL LABEL BOLD

            codeZPL = String.Concat(codeZPL, "^FT33,130^AAN,18,10^FH\^FD", CStr(itm("k02String")), "^FS") ' Setting SKU- 001
            codeZPL = String.Concat(codeZPL, String.Format("^BY 1,2,70^FO{0},60", prmPointBarcode_X), "^BC,50,N,N,N,N^FD", CStr(itm("k02String")), "^FS") ' Setting BARCODE ()
            codeZPL = String.Concat(codeZPL, "^PQ1,0,1,Y^XZ") ' Tag CLose Zpl



        Next

        'Clipboard.SetText(codeZPL)

        Return codeZPL
    End Function


    Private Function cm01GenerateLabelNORMAL()

        Dim quantity As Integer = 0
        Dim codeZPL As String = ""

        ' *** param untuk Geser BArcode Sesuai leng SKu
        Dim prmPointBarcode_X As String = "" ' 12 (^FO30,60 ) |  14 (^FO25,60 ) posisi kiri start dari point berapa ke kanan

#Region " Template "

        ' Templte Untuk BRAND SKK
        '*****************************************************************
        ' Created : Kamis, 20 Juni 2024 (Arif)
        'SIZE label W:60mm H:20mm
        'Full Code tempaklet untuk print label nya berikut ini
        ' link Untuk Preview ZPL code = h*t*t*p*s://labelary.com/viewer.html
        ' copy paste ZPL code nya -> pilih redraws
        '*****************************************************************
        '    empalte label SKK brand (size label W = 60mm ,H = 20mm)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ
        '^XA
        '^MMT
        '^PW480
        '^LL0160
        '^LS0
        '^FT220,41^AAR,18,10^FB97,1,0,C^FH\^FDEARRING^FS
        '^FT262,55^AAN,18,10^FH\^FDQTY:1 ^FS
        '^FT262,80^AAN,18,10^FH\^FD1.230gr 12sz^FS
        '^FT262,102^AAN,18,10^FH\^FDWHITE^FS
        '^FT262,125^AAN,18,10^FH\^FDEA190088-001^FS
        ' ^FT430,35^A0R,36,40^FB112,1,0,C^FH\^FDHALA^FS
        '^FT75,55^AAN,18,10^FH\^FDHALA 755^FS
        '^FT33,130^AAN,18,10^FH\^FDZN202210-005^FS
        '^BY 1,2,70^FO30,60^BC,50,N,N,N,N^FDZN202210-005^FS
        '^PQ1,0,1,Y^XZ
        '*****************************************************************

#End Region

        'codeZPL = String.Concat(codeZPL, "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ") ' --> Setting ketebalan tinta ( SD30 )
        Dim prmBRAND As String = ""
        Dim prmLeghtBrand As String = ""
        For Each itm As DataRow In pdtInBound.Rows

            ' *** cek Leng SKu
            prmPointBarcode_X = cm04SetPointBarcdoe(CInt(Len(CStr(itm("k02String")))))

            codeZPL = String.Concat(codeZPL, "^XA") ' tag Open
            codeZPL = String.Concat(codeZPL, "^MMT")
            codeZPL = String.Concat(codeZPL, "^PW480")
            codeZPL = String.Concat(codeZPL, "^LL0160")
            codeZPL = String.Concat(codeZPL, "^LS0")
            codeZPL = String.Concat(codeZPL, "^FT220,41^AAR,18,10^FB97,1,0,C^FH\^FD", CStr(itm("f12String")), "^FS") ' Setting item
            ' codeZPL = String.Concat(codeZPL, "^FT262,55^AAN,18,10^FH\^FD", String.Format("QTY:{0} {1}sz", CStr(itm("f01SmallInt")), CStr(itm("f14String"))), "^FS") ' Setting Qty, Size

            ' Set size jika tidak ada size di hilangkan
            If Not String.IsNullOrEmpty(CStr(itm("f14String"))) Then
                codeZPL = String.Concat(codeZPL, "^FT262,55^AAN,18,10^FH\^FD", String.Format("QTY:{0} ", CStr(itm("f01SmallInt"))), String.Format("{0}sz", CStr(itm("f14String"))), "^FS") ' Setting Qty, Size : sz
            Else
                codeZPL = String.Concat(codeZPL, "^FT262,55^AAN,18,10^FH\^FD", String.Format("QTY:{0} ", CStr(itm("f01SmallInt"))), "^FS") ' Setting Qty, Size : sz

            End If

            codeZPL = String.Concat(codeZPL, "^FT262,80^AAN,18,10^FH\^FD", CStr(FormatNumber(itm("f01Double"), 2)), "gr", "^FS") ' Setting berat (2digit)
            'codeZPL = String.Concat(codeZPL, "^FT262,80^AAN,18,10^FH\^FD", CStr(itm("f01Double")), "gr", "^FS") ' Setting berat (3digit)
            codeZPL = String.Concat(codeZPL, "^FT262,102^AAN,18,10^FH\^FD", CStr(itm("f08String")), "^FS") ' Setting Warna
            codeZPL = String.Concat(codeZPL, "^FT262,125^AAN,18,10^FH\^FD", CStr(itm("f01String")), "^FS") ' Setting Prodcut Code
            '  codeZPL = String.Concat(codeZPL, "^FT75,55^AAN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand kadar
            codeZPL = String.Concat(codeZPL, "^FT", cm04SetPointBRandKadar(CStr(itm("f16String"))), ",55^AAN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand kadar

            ' *** Request Selian Brand ILY, HALA, SDW di hide (29 Juli 2024 Gery WH)
            'codeZPL = String.Concat(codeZPL, "^FT430,35^A0R,36,40^FB112,1,0,C^FH\^FD", String.Format("{0}", CStr(itm("f16String"))), "^FS") ' Setting Brand 
            codeZPL = String.Concat(codeZPL, "^FT430,35^A0R,36,40^FB112,1,0,C^FH\^FD", prop03_NamaBrand, "^FS") ' Setting Brand VERTICAL LABEL BOLD

            codeZPL = String.Concat(codeZPL, "^FT33,130^AAN,18,10^FH\^FD", CStr(itm("k02String")), "^FS") ' Setting SKU- 001
            codeZPL = String.Concat(codeZPL, String.Format("^BY 1,2,70^FO{0},60", prmPointBarcode_X), "^BC,50,N,N,N,N^FD", CStr(itm("k02String")), "^FS") ' Setting BARCODE ()
            codeZPL = String.Concat(codeZPL, "^PQ1,0,1,Y^XZ") ' Tag CLose Zpl



        Next

        'Clipboard.SetText(codeZPL)

        Return codeZPL
    End Function

    Private Function cm02GenerateLabelPrice()

        Dim quantity As Integer = 0
        Dim codeZPL As String = ""

#Region " Tempalte "


        '*****************************************************************
        ' Created : Kamis, 20 Juni 2024 (Arif)
        'SIZE label W:60mm H:20mm
        'Full Code tempaklet untuk print label nya berikut ini
        ' link Untuk Preview ZPL code = h*t*t*p*s://labelary.com/viewer.html
        ' copy paste ZPL code nya dibaWAH INI -> pilih redraws
        '*****************************************************************
        ' TEMPLATE Label CMK (ada Harga nya) (size label W = 60mm ,H = 20mm)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ
        '^XA
        '^MMT
        '^PW480
        '^LL0160
        '^LS0
        '^FT221,41^AAR,18,10^FB97,1,0,C^FH\^FDEA190088^FS
        '^FT262,55^AAN,18,10^FH\^FDEARRING QTY:1^FS
        '^FT262,80^AAN,18,10^FH\^FD1.230gr^FS
        '^FT262,102^AAN,18,10^FH\^FDWHITE^FS
        '^FT262,125^AAN,18,10^FH\^FDRp. 1.530.000^FS
        '^FT75,55^AAN,18,10^FH\^FDHALA 755^FS
        '^FT33,130^AAN,18,10^FH\^FDZN202210-005^FS
        '^BY 1,2,70^FO25,60^BC,50,N,N,N,N^FDZN202210-005^FS
        '^PQ1,0,1,Y^XZ
        '*****************************************************************
#End Region

        ' Format V1
        'codeZPL = String.Concat(codeZPL, "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ") ' --> Setting ketebalan tinta ( SD30 )


        For Each itm As DataRow In pdtInBound.Rows

            codeZPL = String.Concat(codeZPL, "^XA") ' tag Open
            codeZPL = String.Concat(codeZPL, "^MMT")
            codeZPL = String.Concat(codeZPL, "^PW480")
            codeZPL = String.Concat(codeZPL, "^LL0160")
            codeZPL = String.Concat(codeZPL, "^LS0")
            codeZPL = String.Concat(codeZPL, "^FT221,41^AAR,18,10^FB97,1,0,C^FH\^FD", CStr(itm("f02String")), "^FS") ' Setting Master Code
            codeZPL = String.Concat(codeZPL, "^FT262,55^AAN,18,10^FH\^FD", CStr(itm("f12String")), " ", String.Format("QTY:{0}", CStr(itm("f01SmallInt"))), "^FS") ' Setting item , Qty (sepasi baut pemisah)

            ' Set size jika tidak ada size di hilangkan
            If Not String.IsNullOrEmpty(CStr(itm("f14String"))) Then
                codeZPL = String.Concat(codeZPL, "^FT262,80^AAN,18,10^FH\^FD", String.Format("{0}gr", CStr(FormatNumber(itm("f01Double"), 2))), " ", String.Format("{0}sz", CStr(itm("f14String"))), "^FS") ' Setting berat, size (sepasi baut pemisah)
            Else
                codeZPL = String.Concat(codeZPL, "^FT262,80^AAN,18,10^FH\^FD", String.Format("{0}gr", CStr(FormatNumber(itm("f01Double"), 2))), "^FS") ' Setting berat, size (sepasi baut pemisah)
            End If

            codeZPL = String.Concat(codeZPL, "^FT262,102^AAN,18,10^FH\^FD", CStr(itm("f08String")), "^FS") ' Setting Warna
            codeZPL = String.Concat(codeZPL, "^FT262,125^AAN,18,10^FH\^FD", "Rp. ", cm03FormatUang(CStr(itm("f03Int"))), "^FS") ' Setting harga

            ' codeZPL = String.Concat(codeZPL, "^FT75,55^AAN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand, kadar
            codeZPL = String.Concat(codeZPL, "^FT", cm04SetPointBRandKadar(CStr(itm("f16String"))), ",55^AAN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand kadar


            codeZPL = String.Concat(codeZPL, "^FT33,130^AAN,18,10^FH\^FD", CStr(itm("k02String")), "^FS") ' Setting SKU
            codeZPL = String.Concat(codeZPL, "^BY 1,2,70^FO25,60^BC,50,N,N,N,N^FD", CStr(itm("k02String")), "^FS") ' Setting BARCODE ()
            codeZPL = String.Concat(codeZPL, "^PQ1,0,1,Y^XZ") ' Tag CLose Zpl

        Next

        Return codeZPL
    End Function

    Private Function cm03GenerateLabelBelalai()

        Dim quantity As Integer = 0
        Dim codeZPL As String = ""
        Dim prmPointBarcode_X As String = "" ' 12 (^FO30,60 ) |  14 (^FO25,60 ) posisi kiri start dari point berapa ke kanan


#Region " Tempalte (Khusus CUstomer Melati BALI)"


        '*****************************************************************
        ' Created : Kamis, 20 Juni 2024 (Arif)
        'SIZE label W:60mm H:20mm
        'Full Code tempaklet untuk print label nya berikut ini
        ' link Untuk Preview ZPL code = h*t*t*p*s://labelary.com/viewer.html
        ' copy paste ZPL code nya dibaWAH INI -> pilih redraws
        '*****************************************************************

        '-- Template belalai (size label W = 77mm ,H = 29mm)
        '^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ
        '^XA
        '^MMT
        '^PW623
        '^LL0240
        '^LS0
        '^BY1,3,85
        '^FT17,100^BCN,,Y,N^FDZN202646-005^FS
        '^FT29,226^ADB,18,10^FH\^FDRI190495^FS
        '^FT47,227^ADB,18,10^FH\^FD14sz^FS
        '^FT52,146^ADN,18,10^FH\^FDZN202646-005^FS
        '^FT52,169^ADN,18,10^FH\^FD2.470gr QTY: 1^FS
        '^FT52,196^ADN,18,10^FH\^FDWHITE ROSE^FS
        '^FT52,222^ADN,18,10^FH\^FDHALA 755^FS
        '^PQ1,0,1,Y^XZ
        '*****************************************************************
#End Region

        ' Format V1
        'codeZPL = String.Concat(codeZPL, "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ") ' --> Setting ketebalan tinta ( SD30 )

        For Each itm As DataRow In pdtInBound.Rows

            codeZPL = String.Concat(codeZPL, "^XA") ' tag Open
            codeZPL = String.Concat(codeZPL, "^MMT")
            codeZPL = String.Concat(codeZPL, "^PW623")
            codeZPL = String.Concat(codeZPL, "^LL0240")
            codeZPL = String.Concat(codeZPL, "^LS0")

            If CInt(Len(CStr(itm("k02String")))) = 14 Then

            End If

            Select Case CInt(Len(CStr(itm("k02String"))))
                Case 12
                    prmPointBarcode_X = "35"
                Case 14
                    prmPointBarcode_X = "24"
                Case Else
                    prmPointBarcode_X = "35"
            End Select

            ' backup Lama
            ' codeZPL = String.Concat(codeZPL, "^BY1,3,85^FT17,100^BCN,,Y,N^FD", CStr(itm("k02String")), "^FS") '--> Setting BArcode
            ' codeZPL = String.Concat(codeZPL, "^FT29,226^ADB,18,10^FH\^FD", CStr(itm("f02String")), "^FS") ' --> master Code

            codeZPL = String.Concat(codeZPL, "^BY1,3,85^FT", prmPointBarcode_X, ",95^BCN,,Y,N^FD", CStr(itm("k02String")), "^FS") '--> Setting BArcode
            codeZPL = String.Concat(codeZPL, "^FT35,226^ADB,18,10^FH\^FD", CStr(itm("f02String")), "^FS") ' --> master Code

            ' Set size jika tidak ada size di hilangkan
            If Not String.IsNullOrEmpty(CStr(itm("f14String"))) Then
                ' codeZPL = String.Concat(codeZPL, "^FT47, 227 ^ ADB, 18, 10 ^ FH \^ FD", CStr(itm("f14String")), "sz^FS") '--> Size
                codeZPL = String.Concat(codeZPL, "^FT53,227^ADB,18,10^FH\^FD", CStr(itm("f14String")), "sz^FS") '--> Size
            End If

            ' Default
            'codeZPL = String.Concat(codeZPL, "^FT52, 146 ^ ADN, 18, 10 ^ FH \^ FD", CStr(itm("k02String")), "^FS") '--> SKU
            'codeZPL = String.Concat(codeZPL, "^FT52, 169 ^ ADN, 18, 10 ^ FH \^ FD", String.Format("{0}gr QTY: {1}", CStr(FormatNumber(itm("f01Double"), 2)), CStr(itm("f01SmallInt"))), "^FS")
            'codeZPL = String.Concat(codeZPL, "^FT52,196^ADN,18,10^FH\^FD", CStr(itm("f08String")), "^FS") ' --> seting warna
            'codeZPL = String.Concat(codeZPL, "^FT52,222^ADN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand kadar
            'codeZPL = String.Concat(codeZPL, "^PQ1,0,1,Y^XZ") ' Tag CLose Zpl

            codeZPL = String.Concat(codeZPL, "^FT58,146^ADN,18,10^FH\^FD", CStr(itm("k02String")), "^FS") '--> SKU
            codeZPL = String.Concat(codeZPL, "^FT58,169^ADN,18,10^FH\^FD", String.Format("{0}gr QTY:{1}", CStr(FormatNumber(itm("f01Double"), 2)), CStr(itm("f01SmallInt"))), "^FS")
            codeZPL = String.Concat(codeZPL, "^FT58,196^ADN,18,10^FH\^FD", CStr(itm("f08String")), "^FS") ' --> seting warna
            codeZPL = String.Concat(codeZPL, "^FT58,222^ADN,18,10^FH\^FD", String.Format("{0} {1}", CStr(itm("f16String")), CStr(itm("f04Int"))), "^FS") ' Setting Brand kadar
            codeZPL = String.Concat(codeZPL, "^PQ1,0,1,Y^XZ") ' Tag CLose Zpl

            '^FT25,100^BCN,,Y,N^FDZN202646-005^FS
            '^FT35,225^ADB,18,10^FH\^FDRI190495^FS
            '^FT53,225^ADB,18,10^FH\^FD14sz^FS
            '^FT52,146^ADN,18,10^FH\^FDZN202646-005^FS
            '^FT60,169^ADN,18,10^FH\^FD2.470gr QTY: 1^FS
            '^FT60,196^ADN,18,10^FH\^FDWHITE ROSE^FS
            '^FT60,222^ADN,18,10^FH\^FDHALA 755^FS
        Next

        Return codeZPL
    End Function

    Private Function cm04SetPointBarcdoe(ByVal prmLengtSKu As Integer)

        Dim prmZPLCode As String = ""

        Select Case prmLengtSKu
            Case 12
                prmZPLCode = "34"
            Case 14
                prmZPLCode = "29"
            Case Else
                prmZPLCode = "34"
        End Select

        Return prmZPLCode
    End Function

    Private Function cm04SetPointBRandKadar(ByVal prmBRAND As String)

        Dim prmZPLCode As String = ""

        Dim lenghtBrand As Integer = 0

        lenghtBrand = prmBRAND.Length()

        ' 4 + Panjang BRAND (HALA,SDW,ILLY) di seting center jika lebih dari 4 di set dari kiri

        If lenghtBrand >= 4 Then
            prmZPLCode = 30 ' float left
        Else
            If lenghtBrand < 4 Then
                prmZPLCode = 70 ' center
            End If
        End If


        Return prmZPLCode
    End Function

    Private Sub cm04CollateData()
        ' Di pakai untuk print Barcode By : SPK
        pdtInBound.Clear()

        Using objStock As New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
            pdtInBound = objStock._pb27GetDataBarcodePerSPK(prop01_NoSPK)
        End Using

    End Sub

    Private Sub cm05CollateDataReprint()
        ' Di pakai untuk print Barcode By : (SKU) SPK-001 
        pdtInBound.Clear()

        Using objStock As New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
            pdtInBound = objStock._pb26GetDataBarcodePerSKU(prop01_NoSPK)
        End Using
    End Sub


    'Private Function cm06GetReserByKodeBrand(ByVal prmKODEBRAND As String)
    '    '*************************************
    '    ' Req : LEAD WH (GERY) Senin 27 Juni 2024
    '    ' Selain Brand (ILY, HALA, SDW) di hide
    '    ' jadi bniar tdk sett di coding ambil dari mastering y51 MRP BRAND saja
    '    ' untuk DI Label nya MAX Lengt String  = 7 character
    '    '*************************************
    '    Dim Brand As String = ""

    '    Dim pdtRow() As DataRow = prop03_NamaBrand.Select("k01cKodeFieldValueMaster_v50 ='" & prmKODEBRAND & "' ")

    '    For Each itm As DataRow In pdtRow
    '        ' untuk DI Label nya MAX Lengt String  = 7 character
    '        Brand = CStr(itm("f03cReserve01_v50"))
    '    Next

    '    If CInt(Brand.Length) > 7 Then
    '        Brand.Substring(0, 7)
    '    End If

    '    Return Brand
    'End Function

#End Region

#Region " Public Methods "

    Public Sub cm01CetakLabelBarcode()
        ' method ini unutk Print Label by SPK
        ' ZN1234 => punya bnyak detail pe rpcs nya ZN123-001

        Dim prmStringZPLCode As String = ""

        ' *** 01 Collate Data BY SPK
        cm04CollateData()

        If pdtInBound.Rows.Count > 0 Then

            ' ** setting ketebalan warna saat print
            prmStringZPLCode = String.Concat(prmStringZPLCode, "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ") '

            Select Case prop02_TypeLabelBarcode
                Case "COLOR"
                    prmStringZPLCode = cm00GenerateLabelCOLOR()
                Case "NORMAL"
                    prmStringZPLCode = cm01GenerateLabelNORMAL()
                Case "PRICE"
                    prmStringZPLCode = cm02GenerateLabelPrice()
                Case "BELALAI"
                    prmStringZPLCode = cm03GenerateLabelBelalai()
                Case Else
                    prmStringZPLCode = cm01GenerateLabelNORMAL()
            End Select

            Dim printDialog As System.Windows.Forms.PrintDialog = New System.Windows.Forms.PrintDialog() With
        {
            .PrinterSettings = New PrinterSettings()
        }
            If (DialogResult.OK = printDialog.ShowDialog()) Then
                Dim printerName As String = printDialog.PrinterSettings.PrinterName
                'RawPrinterHelper.rawPrinterHelper.PrintRaw(printDialog.PrinterSettings.PrinterName, prmStringZPLCode)

                RawPrinterHelper.rawPrinterHelper.PrintRaw(printDialog.PrinterSettings.PrinterName, prmStringZPLCode)
            End If
        Else
            MsgBox("Data SPK " & prop01_NoSPK & " Tidak di Temukan ...", MsgBoxStyle.Exclamation + vbOKOnly, "Warrning")
        End If

    End Sub

    Public Function cm02GenerateLabelBarcode()

        Dim prmStringZPLCode As String = ""
        Dim printerName As String = ""
        Dim prmSettingAwal As Boolean = True

        ' *** 01 Collate Data BY SPK
        cm05CollateDataReprint()

        If pdtInBound.Rows.Count > 0 Then

            Select Case prop02_TypeLabelBarcode
                Case "COLOR"
                    prmStringZPLCode = cm00GenerateLabelCOLOR()
                Case "NORMAL"
                    prmStringZPLCode = cm01GenerateLabelNORMAL()
                Case "PRICE"
                    prmStringZPLCode = cm02GenerateLabelPrice()
                Case "BELALAI"
                    prmStringZPLCode = cm03GenerateLabelBelalai()
                Case Else
                    prmStringZPLCode = cm01GenerateLabelNORMAL()
            End Select

        Else
            MsgBox("Data SPK " & prop01_NoSPK & " Tidak di Temukan ...", MsgBoxStyle.Exclamation + vbOKOnly, "Warrning")
        End If

        Return prmStringZPLCode
    End Function

    Public Sub cm03ReprintBarcode(ByVal prmZPLCode As String)

        ' ** setting ketebalan warna saat print
        Dim prmSetting As String = "^XA~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR5,5~SD30^JUS^LRN^CI0^XZ"

        prmZPLCode = String.Concat(prmSetting, prmZPLCode)

        Dim printDialog As System.Windows.Forms.PrintDialog = New System.Windows.Forms.PrintDialog() With
   {
       .PrinterSettings = New PrinterSettings()
   }
        If (DialogResult.OK = printDialog.ShowDialog()) Then
            Dim printerName As String = printDialog.PrinterSettings.PrinterName

            RawPrinterHelper.rawPrinterHelper.PrintRaw(printerName, prmZPLCode)
        End If

    End Sub

    'di implementasikan langsung di "WS..spWSInbound40VENDORCHAINEXTERNAL"
    Public Function cm02PembulatanHarga(ByVal prmHarga As Decimal)
        Dim hasil As Decimal
        Dim kelipatan As Decimal = 10000
        Dim prmCash As Decimal = 10000 ' rumus dari JIms + 10 RB

        ' *** Pembulatan Harga (1.232.000 => 1.240.000)
        hasil = Math.Ceiling(prmHarga / kelipatan) * kelipatan

        Return hasil + prmCash
    End Function

    Public Function cm03FormatUang(ByVal prmHarga As Decimal)
        Dim hasil As String

        ' unutk seeting titk sparator Rupiah
        Dim numberFormatInfo As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo() With {.NumberDecimalDigits = 0, .NumberGroupSeparator = "."
        }

        ' *** Pembulatan Harga (1.232.000 => 1.240.000)
        hasil = prmHarga.ToString("N0", numberFormatInfo)

        Return hasil
    End Function

#End Region


End Class
