Imports DevExpress.XtraRichEdit.Import.Doc
Imports SKK01CORE

Public Class clsWSNasaSelect4CtrlRepoMaster
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

    Public Function __pb01GetDataMasterWarehouseBerdasarkanGroup(ByVal prmcKodeGroupMaster01 As String,
                                                                Optional ByVal prmcKodeGroupMaster02 As String = "",
                                                                Optional ByVal prmcKodeGroupMaster03 As String = "") As DataTable
        '(sp101SeleForRepository) ==> ini akses ke TABLEMASTER..TABLE50
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(101, 0, 50, prmcKodeGroupMaster01, prmcKodeGroupMaster02, prmcKodeGroupMaster03, 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork,
                                                            _pnmDatabaseName.TABLEMASTER,
                                                            objParamCollection,
                                                            mdWSNasaConst._pbTABLEMASTERSPSELECT01EXECUTE)

        Return pdtHasil
    End Function

    Public Function __pb02GetDataTable21TargetWarehouseByUser(ByVal prmcTargetGroup As String,
                                                              Optional ByVal prmnTargetSubGroup As Integer = 0) As DataTable
        'ini akses ke TABLEMASTER.TABLE21

        Cursor.Current = Cursors.WaitCursor
        Dim pcSQL As String = ""
        If _prop01User._UserProp02cUserID = "141202" Then
            If prmnTargetSubGroup = 0 Then
                pcSQL = " select * from TABLEMASTER..TABLE21 " &
                        " where f03String = '" & prmcTargetGroup & "' and k02String = 'MENU' " &
                        " order by f05String "
            ElseIf prmnTargetSubGroup = 50401 Then
                pcSQL = " select * from TABLEMASTER..TABLE21 " &
                        " where f03String = '" & prmcTargetGroup & "' and k02String = 'MENU' " &
                        " and f01Int = " & prmnTargetSubGroup & " order by f05String "
            Else
                pcSQL = " select * from TABLEMASTER..TABLE21 " &
                        " where f03String = '" & prmcTargetGroup & "' and k02String = 'MENU' " &
                        " and f01Int = " & prmnTargetSubGroup & " order by f06String "
            End If
        Else
            If prmnTargetSubGroup = 0 Then
                'pcSQL = " select * from TABLEMASTER..TABLE21 " &
                '        " where f07String = '" & _prop01User._UserProp02cUserID &
                '        "' and f03String = '" & prmcTargetGroup & "' and k02String = 'USERACCESS' " &
                '        " order by f05String "
                pcSQL = " select * from TABLEMASTER..TABLE21 " &
                        " where f03String = '" & prmcTargetGroup & "' and k02String = 'MENU' " &
                        " order by f05String "
            ElseIf prmnTargetSubGroup = 50401 Then
                pcSQL = " select * from TABLEMASTER..TABLE21 " &
                        " where f03String = '" & prmcTargetGroup & "' and k02String = 'MENU' " &
                        " and f01Int = " & prmnTargetSubGroup & " order by f05String "
            Else
                'pcSQL = " select * from TABLEMASTER..TABLE21 " &
                '        " where f07String = '" & _prop01User._UserProp02cUserID &
                '        "' and f03String = '" & prmcTargetGroup & "' and k02String = 'USERACCESS' " &
                '        " and f01Int = " & prmnTargetSubGroup & " order by f05String "
                pcSQL = " select * from TABLEMASTER..TABLE21 " &
                        " where f03String = '" & prmcTargetGroup & "' and k02String = 'MENU' " &
                        " and f01Int = " & prmnTargetSubGroup & " order by f06String "
            End If
        End If

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec02SQLSELECTToDataTable(
                      _prop01User._UserProp08TargetNetwork,
                      clsNasaHelper._pnmDatabaseName.TABLEMASTER, pcSQL)

        Cursor.Current = Cursors.Default

        Return pdtHasil
    End Function

    Public Function __pb04GetDataTable52Customer() As DataTable
        '(sp101SeleForRepository) ==> ini akses ke TABLEMASTER..TABLE52 (CUSTOMER)
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(101, 0, 52, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork,
                                                            _pnmDatabaseName.TABLEMASTER,
                                                            objParamCollection,
                                                            mdWSNasaConst._pbTABLEMASTERSPSELECT01EXECUTE)

        Return pdtHasil
    End Function

    Public Function __pb05GetDataTable21Pameran() As DataTable
        'ini akses ke TABLEMASTER.TABLE21

        Cursor.Current = Cursors.WaitCursor
        Dim pcSQL As String = ""

        pcSQL = " select * from TABLEMASTER..TABLE21 " &
                " where f03String = '5040' and f01Int = 50405 and f10String = 'OPEN' order by f05String "

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec02SQLSELECTToDataTable(
                   _prop01User._UserProp08TargetNetwork,
                   clsNasaHelper._pnmDatabaseName.TABLEMASTER, pcSQL)

        Cursor.Current = Cursors.Default

        Return pdtHasil
    End Function

    Public Function __pb06GetDataCustomerPKBApprove(ByVal prmnTargetExec As Int16, ByVal prmcTargetCode As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, prmnTargetExec, prmcTargetCode, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb07GetDataCustomerPICKING() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 2, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb08GetDataPKBForCreateSURATJALAN() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 3, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb09GetDataPKBForDELIVEREDNONCOURIER() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 5, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb10GetDataSLocStockForControlPenjualan(ByVal prmcTarget As String) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 7, prmcTarget, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb11GetDataSbox(ByVal prmcNamaBoxNew As String) As DataTable

        Cursor.Current = Cursors.WaitCursor
        Dim pcSQL As String = ""

        pcSQL = "SELECT * FROM TABLEMASTER..TABLE50 WHERE k14String = '" & prmcNamaBoxNew.Replace("'", "''") & "'"

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec02SQLSELECTToDataTable(
                   _prop01User._UserProp08TargetNetwork,
                   clsNasaHelper._pnmDatabaseName.TABLEMASTER, pcSQL)

        Cursor.Current = Cursors.Default

        Return pdtHasil
    End Function

    Public Function _pbMF12FetchDtStockCurrentStock() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 17, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#Region "***** ucWS24FK01TRANSAKSIWAREHOUSE *****"

    Public Function __pb11GetDataSLocKAEStatusStock() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 8, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb12GetDataSupplierStatusStock() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 9, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb13GetDataSLocKAEApproveMutasiAntarKAE() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 10, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
#End Region

#Region "***** ucWS24FP01INBOUND *****"

    Public Function __pb14GetDataMasterWarehouseVendorExternal() As DataTable
        '(sp101SeleForRepository) ==> ini akses ke TABLEMASTER..TABLE50
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(101, 0, 20, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork,
                                                            _pnmDatabaseName.TABLEMASTER,
                                                            objParamCollection,
                                                            mdWSNasaConst._pbTABLEMASTERSPSELECT01EXECUTE)

        Return pdtHasil
    End Function

    Public Function __pb15GetDataMasterMRPProduct() As DataTable
        '(sp101SeleForRepository) ==> ini akses ke MRP..y51VALUEMASTER
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(101, 0, 21, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork,
                                                            _pnmDatabaseName.TABLEMASTER,
                                                            objParamCollection,
                                                            mdWSNasaConst._pbTABLEMASTERSPSELECT01EXECUTE)

        Return pdtHasil
    End Function

    Public Function __pb16GetDataMasterMRPSize() As DataTable
        '(sp101SeleForRepository) ==> ini akses ke MRP..y51VALUEMASTER
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(101, 0, 22, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(_prop01User._UserProp08TargetNetwork,
                                                            _pnmDatabaseName.TABLEMASTER,
                                                            objParamCollection,
                                                            mdWSNasaConst._pbTABLEMASTERSPSELECT01EXECUTE)

        Return pdtHasil
    End Function

    Public Function __pb17GetDataSOLD() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 12, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb18GetDataStockMarketing() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 13, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb19GetDataStockKAE() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 15, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function __pb20GetDataStockConsignment() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 16, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "***** ucWS24G301OUTBOUNDPKB *****"
    Public Function __pb24G301GetDataNextProses() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(1, 0, 14, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
#End Region

#End Region

End Class
