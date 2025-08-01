Imports System.Buffers
Imports DevExpress.Pdf.Native
Imports SKK01CORE

Public Class clsWSNasaSelect4PivotGridProses
    Inherits clsWSNasaHelper
    Implements IDisposable

#Region "dispose"
    Private disposedValue As Boolean

    Protected Overrides Sub Dispose(disposing As Boolean)
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

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Property _prop01User As clsWSNasaUser
    Public Property _prop02String As String
    Public Property _prop03String As String

#Region "method - public"
    '*****************************************************************
    '****************** spWS43Sele4PivotGridProses *******************
    '*****************************************************************

    Public Function _pb01GetDataDOFGStatusOPEN() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(3, 0, 1, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb02GetDataSKUPKBCustomer() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(3, 0, 4, _prop02String, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb03GetDataPrepareAPPROVEPKB(ByVal prmcSLSorFIN As String, ByVal vsJenisOrder As String, ByVal vsCustomer As String) As DataTable
        '3,0,5 ==> (APPROVE PKB Customer : Mgr.Sales)
        '3,0,6 ==> (APPROVE PKB Customer : Mgr.Finance)
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        If prmcSLSorFIN = "SLS" Then
            objParamCollection._pb01AddNew(3, 0, 5, vsJenisOrder, vsCustomer, "", 0, 0, "3000-01-01", "3000-01-01")
        Else
            If prmcSLSorFIN = "FIN" Then
                objParamCollection._pb01AddNew(3, 0, 6, vsJenisOrder, vsCustomer, "", 0, 0, "3000-01-01", "3000-01-01")
            End If
        End If

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb04GetDataPICKINGSKU(ByVal prmcTarget As String, ByVal prmcKodeCustomer As String) As DataTable
        Dim pnTarget As Int32
        Select Case prmcTarget
            Case "HEADER"
                pnTarget = 8
            Case "DETAIL"
                pnTarget = 9
        End Select

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(3, 0, pnTarget, prmcKodeCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb05GetDataPrepareSuratJalan(ByVal prmcKodeCustomer As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 10, prmcKodeCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")


        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb06GetDataSuratJalanAirwayBill() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 11, "", "", "", 0, 0, "3000-01-01", "3000-01-01")


        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb07GetDataSuratJalanPickup() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 12, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb08GetDataSuratJalanDeliveredByCourier(ByVal prmcString As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 13, prmcString, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb09GetDataSuratJalanDeliveredNONCourier(ByVal prmcString As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 14, prmcString, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb10GetDataStockPreparePenjualan(ByVal prmcFilterKodeStock As String, ByVal prmcKodeSLoc As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 15, prmcFilterKodeStock, prmcKodeSLoc, "", 0, 0, "3000-01-01", "3000-01-01")


        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#Region "***** ucWS24FK01TRANSAKSIWAREHOUSE *****"
    Public Function _pb11GetDataStockKAE(ByVal prmcKodeKAE As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 16, prmcKodeKAE, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb12GetDataStockForRepairLebur() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 18, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb13GetDataStockSupplier(ByVal prmcKodeSupplier As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 19, prmcKodeSupplier, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb14GetDataAPPROVEMUTASIANTARKAE(ByVal prmcKodeKAE As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 17, prmcKodeKAE, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "***** ucWS24FP01INBOUND *****"

    Public Function _pb16GetDataStockRepairWS() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 20, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb17GetDataStockSOLD(ByVal prmcCustomer As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 21, prmcCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb18GetDataStockMARKETING(ByVal prmcCustomer As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 22, prmcCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb19GetDataNoDocInboundCitrix(ByVal prmcNoDocument As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 23, prmcNoDocument, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb20GetDataPKBForConsumeInbound(ByVal prmcProductCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 25, prmcProductCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb21GetDataStockKAE(ByVal prmcProductCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 35, prmcProductCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb22GetDataStockCONSIGNMENT(ByVal prmcProductCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 36, prmcProductCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "***** ucWS23LL01DISTRIBUSIFINISHGOODS *****"
    Public Function _pb30GetDataPKB(ByVal prmcNoPKB As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 24, prmcNoPKB, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
#End Region

#End Region

#Region "***** ucWS24G301OUTBOUNDPKB *****"
    '*****************************************************************
    '************** spWS46Sele4AllProsesOUTBOUNDPKB ******************
    '*****************************************************************

#End Region

#Region "***** ucWS24IJ01SALE *****"
    '*****************************************************************
    '************** spWS43Sele4PivotGridProses ******************
    '*****************************************************************

    Public Function _pb30GetDataStockForSaleSalesConsign(ByVal prmcTargetSale_f28 As String, ByVal prmcKodeSLoc_f06 As String) As DataTable
        Dim pcTarget As String = ""

        Select Case prmcTargetSale_f28
            Case "SLS"
                pcTarget = "5062"   '"NEW PKB KAE"

            Case "CSG"
                pcTarget = "5063"   '"NEW PKB CONSIGNMENT"

            Case "EXH"
                pcTarget = "5066"   '"NEW PKB EXHIBITION"
        End Select

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 30, pcTarget, prmcKodeSLoc_f06, "", 0, 0, "3000-01-01", "3000-01-01")
        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb29EditGJForSaleSalesConsign(ByVal prmcSKU_k03 As String, ByVal prmcGJ_f20 As String) As DataTable
        Dim pcNoDokumen As String = ""

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 29, prmcSKU_k03, prmcGJ_f20, "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "***** LABEL/BARCODE (ucWS24F101INBOUNDENTRYCONTAINER) *****"
    '*****************************************************************
    '************** spWS43Sele4PivotGridProses ******************
    '*****************************************************************
    Public Function _pb26GetDataBarcodePerSKU(ByVal prmcSKUNumber As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 26, prmcSKUNumber, "", "", 0, 0, "3000-01-01", "3000-01-01")
        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb27GetDataBarcodePerSPK(ByVal prmcSPKNumber As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 27, prmcSPKNumber, "", "", 0, 0, "3000-01-01", "3000-01-01")
        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
#End Region

#Region "TEMP - PICKING LIST"
    Public Function _pb28GetDataTempPicking(ByVal prmcNoPicking As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection

        objParamCollection._pb01AddNew(3, 0, 28, prmcNoPicking, "", "", 0, 0, "3000-01-01", "3000-01-01")
        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
#End Region
End Class
