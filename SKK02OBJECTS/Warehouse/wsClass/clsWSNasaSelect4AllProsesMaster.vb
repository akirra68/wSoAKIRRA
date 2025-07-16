Imports SKK01CORE

Public Class clsWSNasaSelect4AllProsesMaster
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

#Region "method proses - public"
    '*****************************************************************
    '****************** spWS45Sele4AllProsesMaster *******************
    '*****************************************************************
    Public Function _pb01GetDataReceiveFGDO() As DataTable
        ' : _prop02String ==> SKUVendor
        ' : ucWS23KG02INBOUNDSKU._cm04DisplayDataDetailSKU
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 1, _prop02String, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb02GetDataGambarFromPosterSKU() As DataTable
        ' : _prop02String ==> Poster - wsSKU
        ' : _prop03String ==> Poster - SLoc Current
        ' : ucWS23LE01REPARASILEBUR._cm03ShowImageBRJ
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 2, _prop02String, _prop03String, "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb02GetDataGambarFromProductCode() As DataTable
        ' _prop02String ==> Product Code
        ' ucWS23LN01PKBCUSTOMER
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 3, _prop02String, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb03GetDataDisplayGridRepairLeburRetur(ByVal prmdtDataRepairLebur As DataTable) As DataTable
        Dim pdtHasil As New DataTable

        pdtHasil = _pbWSNasaHelperExec05SPSELEPassTblTypeToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS,
                        "spWS23KU01DisplayGridRepairLebur", "@tpKEY", prmdtDataRepairLebur)

        Return pdtHasil
    End Function

    Public Function _pb04ResetBeratGagalInboundSKU(ByVal prmcSKUSPKCitrix As String) As Integer
        '(ucWS23KG02INBOUNDSKU) unt reset jika Total Berat nggak LOLOS BERAT TOLERANSI saat INBOUND.
        ' prmcSKUSPKCitrix ==> SKU SPK CITRIX
        ' ucWS23KG02INBOUNDSKU

        Dim pcSQL As String = ""
        pcSQL = "Update WS..wsTABLE20 set f01Double = 0.0 where k03String = '" & prmcSKUSPKCitrix & "';"

        Dim pnReturn As Integer = 0
        pnReturn = _pbWSNasaHelperExec01SPSQLProses(_prop01User._UserProp08TargetNetwork,
                                                    _pnmDatabaseName.WS, 1, pcSQL)

        Return pnReturn
    End Function

    Public Function _pb05GetDataCourierForPickup() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 6, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb06GetDataCustForDeliveredByCourier() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 7, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb07IsExistDesignProductCode(ByVal prmcDesignCode As String, ByVal prmcProductCode As String) As Boolean
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 8, prmcDesignCode, prmcProductCode, "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Dim plAdaRec As Boolean = False
        If pdtHasil.Rows.Count > 0 Then
            plAdaRec = True
        Else
            plAdaRec = False
        End If

        Return plAdaRec
    End Function

    Public Function _pbf07GetDataForSavingOrderManagement(ByVal viConCan As Integer, ByVal cUserInfo As clsWSNasaUser) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 9, "", "", "", viConCan, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        cUserInfo._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pbf08GetDataForCreatingChildOrder(ByVal cUserInfo As clsWSNasaUser) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 10, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        cUserInfo._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pbf09GetDataForSavingApprovalFIN(ByVal cUserInfo As clsWSNasaUser, ByVal vsOrderType As String, ByVal vsCust As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 11, vsOrderType, vsCust, "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        cUserInfo._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pbf10GetDataForSavingApprovalSLS(ByVal cUserInfo As clsWSNasaUser, ByVal vsOrderType As String, ByVal vsCust As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 12, vsOrderType, vsCust, "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        cUserInfo._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "method master - public"
    Public Function _pb50GetDataGroupMASTERWarehouse() As DataTable
        'spWS45Sele4AllProsesMaster : master GAMBAR

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(5, 0, 50, _prop02String, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb51GetDataIncNoDocWarehouse() As String
        Dim pcNoDokumen As String = ""

        '_prop02String adl GROUP NUMBER MASTER (table51 -> k11String)

        Dim objSelect As New clsWSNasaSelectParamDataCollection
        objSelect._pb01AddNew(0, 0, 0, _prop02String, "", "", 0.0, 0.0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.TABLEMASTER,
                        objSelect, "sp151WSIncNumberMaster", "@tpParamSQLSelect")

        For Each dtRow As DataRow In pdtHasil.Rows
            pcNoDokumen = dtRow("cNoDokumen").ToString
        Next

        Return pcNoDokumen
    End Function

    Public Function _pb521GetDataAccountCode() As String
        Dim pcNoDokumen As String = ""

        '_prop02String adl GROUP NUMBER MASTER (table51 -> k11String)

        Dim objSelect As New clsWSNasaSelectParamDataCollection
        objSelect._pb01AddNew(101, 0, 5212, _prop02String, "", "", 0.0, 0.0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbMasterNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.TABLEMASTER, objSelect)


        For Each dtRow As DataRow In pdtHasil.Rows
            pcNoDokumen = dtRow("cNoDokumen").ToString
        Next

        Return pcNoDokumen
    End Function



    Public Function _pb52NewSKUReparasiRetur(ByVal prmnYear As Int32, ByVal prmnMonth As Int32, ByVal prmnJmlIncrement As Int32) As DataTable
        Dim pcNoDokumen As String = ""

        '_prop02String adl GROUP NUMBER MASTER (table51 -> k11String)

        Dim objSelect As New clsWSNasaSelectParamDataCollection
        objSelect._pb01AddNew(prmnYear, prmnMonth, prmnJmlIncrement, _prop02String, "", "", 0.0, 0.0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.TABLEMASTER,
                        objSelect, "sp151WSCreateSKUReparasiRetur", "@tpParamSQLSelect")

        Return pdtHasil
    End Function
#End Region


#Region "ADDON FOR WSO"
    Private objHelper As New clsWSNasaHelper

    Public Function _pbWSNasaExecSPPROCESSToDataTable(ByVal prmnTargetServer012 As Int16,
                                                           ByVal prmcNamaStoredProcedure As String,
                                                           ByVal prmcParamTemplateData As String,
                                                           ByVal prmdtTemplateData As DataTable) As DataTable

        Return objHelper._pbWSNasaHelperExec05SPSELEPassTblTypeToDataTable(prmnTargetServer012, _pnmDatabaseName.WS,
                                                           prmcNamaStoredProcedure, prmcParamTemplateData, prmdtTemplateData)

    End Function

    Public Function _pbWSNasaExecSPPROCESSToDataTable2(ByVal prmnTargetServer012 As Int16,
                                                           ByVal prmcNamaStoredProcedure As String,
                                                           ByVal prmcParamTemplateData As String,
                                                           ByVal prmdtTemplateData As DataTable) As DataTable

        Return objHelper._pbWSNasaHelperExec05SPSELEPassTblTypeToDataTable(prmnTargetServer012, _pnmDatabaseName.WS24,
                                                           prmcNamaStoredProcedure, prmcParamTemplateData, prmdtTemplateData)

    End Function

    Public Function _pbWSNasaExecDirectAllDB(ByVal prmnTargetServer012 As Int16,
                                                         ByVal prmnTarget1Text2SP As Int16, ByVal prmcSQLScriptORNamaSP As String,
                                                         Optional ByVal prmcParamTemplateData As String = "", Optional ByVal prmdtTemplateData As DataTable = Nothing,
                                                         Optional ByVal prmcParamAdditional As String = "", Optional ByVal prmdtAdditional As DataTable = Nothing) As Integer

        Return objHelper._pbWSNasaHelperExec01SPSQLProses(prmnTargetServer012, _pnmDatabaseName.WS,
                                                           prmnTarget1Text2SP, prmcSQLScriptORNamaSP,
                                                           prmcParamTemplateData, prmdtTemplateData,
                                                           prmcParamAdditional, prmdtAdditional)
    End Function

    Public Function _pbWSNasaExecDirectAllDB2(ByVal prmnTargetServer012 As Int16,
                                                        ByVal prmnTarget1Text2SP As Int16, ByVal prmcSQLScriptORNamaSP As String,
                                                        Optional ByVal prmcParamTemplateData As String = "", Optional ByVal prmdtTemplateData As DataTable = Nothing,
                                                        Optional ByVal prmcParamAdditional As String = "", Optional ByVal prmdtAdditional As DataTable = Nothing) As Integer

        Return objHelper._pbWSNasaHelperExec01SPSQLProses(prmnTargetServer012, _pnmDatabaseName.WS24,
                                                           prmnTarget1Text2SP, prmcSQLScriptORNamaSP,
                                                           prmcParamTemplateData, prmdtTemplateData,
                                                           prmcParamAdditional, prmdtAdditional)
    End Function

#End Region

End Class
