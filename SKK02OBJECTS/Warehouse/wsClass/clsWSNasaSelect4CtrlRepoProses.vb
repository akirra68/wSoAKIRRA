Imports SKK01CORE

Public Class clsWSNasaSelect4CtrlRepoProses
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

#Region "method - public"
    '*****************************************************************
    '****************** spWS42Sele4CtrlRepoProses *******************
    '*****************************************************************
    Public Function _pb01GetDataInboundSKU() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 1, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb02GetDataProductCodePosterStock(ByVal prmcFORSALE As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 2, prmcFORSALE, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb03GetDataPosterSKUBySLoc(ByVal prmcSLoc As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 3, prmcSLoc, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb04GetDataSKU4TrackingSKU() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 4, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb041GetDataSKU4TrackingPKB() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 41, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb042GetDataJenisOrder4TrackingPKB() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 42, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb05GetDataNoDOInboundCitrix() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 5, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb06GetDataSBoxProductCode(ByVal prmcProductCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 6, prmcProductCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb07GetDataStockOSTProdCodePKB(ByVal prmcProducCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 7, prmcProducCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb08GetDataProductCodePosterStockWHForChecking() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 8, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb09GetDataSkuPosterStockWHForChecking(ByVal prmcProductCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 9, prmcProductCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb08GetDataProductCodeForValidasiData(ByVal prmcProductCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 11, prmcProductCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb09GetDataSKUForRepairResult(ByVal prmcSKU As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 12, prmcSKU, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pbf10GetDataForFilterJenisOrderApproval() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 13, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pbf11GetDataForFilterCustomerApproval() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 14, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "method - public - SALE"
    '*****************************************************************
    '****************** spWS42Sele4CtrlRepoProses *******************
    '*****************************************************************

    Public Function _pb10GetDataTargetPenjualan() As DataTable
        ' TargetPenjualan :> data SALESSELLING dan CONSIGNMENT

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(2, 0, 10, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb11GetDataRegion() As DataTable
        ' TargetPenjualan :> data SALESSELLING dan CONSIGNMENT

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(101, 0, 521, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbMasterNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.TABLEMASTER, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb12GetDataHeadquarter() As DataTable
        ' TargetPenjualan :> data SALESSELLING dan CONSIGNMENT

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(101, 0, 522, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbMasterNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.TABLEMASTER, objParamCollection)

        Return pdtHasil
    End Function
#End Region

End Class
