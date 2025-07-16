Imports SKK01CORE

Public Class clsWSNasaSelect4PivotGridReport
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
    Public Property _prop04DateAwal As Date
    Public Property _prop05DateHingga As Date

    '*****************************************************************
    '****************** spWS44Sele4PivotGridReport *******************
    '*****************************************************************

#Region "method report - public"

    Public Function _pb01GetDataRptTrackingSKU() As DataTable
        '_prop02String = WSSKU
        'pada "spWSTABLE21Tracking"

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 1, 0, _prop02String, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb011GetDataRptTrackingPKB() As DataTable
        '_prop02String = WSPKB
        'pada "spWSTABLE21Tracking"

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 11, 0, _prop02String, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb011GetDataRptAgregatSJ(ByVal prmdDariTgl As Date, ByVal prmdHinggaTgl As Date) As DataTable
        '_prop02String = WSPKB
        'pada "spWSTABLE21Tracking"

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 100, 0, "", "", "", 0, 0, prmdDariTgl, prmdHinggaTgl)

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb02GetDataRptInOutSLoc(ByVal prmdDariTgl As Date, ByVal prmdHinggaTgl As Date) As DataTable
        '_prop02String = SLoc
        'pada "spWSTABLE21Tracking"

        'Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        'objParamCollection._pb01AddNew(4, 1, 2, _prop02String, "", "", 0, 0, prmdDariTgl, prmdHinggaTgl)

        Dim pdtHasil As New DataTable
        'pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
        '                _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "report - inbound"
    Public Function _pb200RptInboundALL() As DataTable

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 200, 0, "", "", "", 0, 0, _prop04DateAwal, _prop05DateHingga)

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

#End Region

#Region "report - general"
    Public Function _pb300RptGeneralStock() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 300, 0, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pb301RptGeneralStockProductCode() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 301, 0, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function

    Public Function _pbM302FetchDtCurrentStockSku(vsStock As String) As DataTable
        'Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        'objParamCollection._pb01AddNew(4, 302, 0, "", "", vsStock, 0, 0, "3000-01-01", "3000-01-01")

        'Dim pdtHasil As New DataTable
        'pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
        '                _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        'Return pdtHasil

        Cursor.Current = Cursors.WaitCursor

        Dim vsSql As String = ""

        vsSql = "SELECT CONVERT(BIT,0) AS k00Boolean, *, 
                    CASE WHEN f19String = 'STOCK' THEN 'STOCK-WAREHOUSE' ELSE f19String END AS f18String 
                 FROM vWS22SKUCurrentStock
                    WHERE f19String IN (
                        SELECT LTRIM(RTRIM(value)) 
                        FROM STRING_SPLIT('" & vsStock.Replace("'", "''") & "', ','))
                 ORDER BY 
                    CASE WHEN f19String = 'STOCK' THEN 0         
                         WHEN f19String LIKE 'STOCK%' THEN 1     
                         ELSE 2                                  
                    END, f19String, f07String, f25String, f27String, f12String, f01Datetime, k03String, f21String"

        Dim vdtResult As New DataTable
        vdtResult = _pbWSNasaHelperExec02SQLSELECTToDataTable(
                   _prop01User._UserProp08TargetNetwork,
                   clsWSNasaHelper._pnmDatabaseName.WS, vsSql)

        Return vdtResult

        Cursor.Current = Cursors.Default
    End Function
#End Region

#Region "report - outbound"
    Public Function _pb350RptOutboundSale(ByVal idUser) As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 350, 0, idUser, "", "", 0, 0, _prop04DateAwal, _prop05DateHingga)

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
    Public Function _pb350RptEditGJOutboundSale() As DataTable

        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 0, 29, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
#End Region

#Region "report - Transaksi Warehouse"
    Public Function _pb370RptTransaksiWSSemua() As DataTable
        Dim objParamCollection As New clsWSNasaSelectParamDataCollection
        objParamCollection._pb01AddNew(4, 370, 0, "", "", "", 0, 0, _prop04DateAwal, _prop05DateHingga)

        Dim pdtHasil As New DataTable
        pdtHasil = _pbWSNasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp08TargetNetwork, _pnmDatabaseName.WS, objParamCollection)

        Return pdtHasil
    End Function
#End Region

End Class
