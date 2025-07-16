
Imports SKK01CORE
Imports SKK01CORE.clsNasaHelper

Public Class clsGetDataMasterGEMINI
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

    Private objHelper As clsNasaHelper

#Region "form - event"

    Public Sub New()
        objHelper = New clsNasaHelper()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objHelper.Dispose()
    End Sub

#End Region

#Region "Sync - master - custom method - public"
    Public Function _pb01GetDataCUSTOMER(ByVal prmnTargetServer012 As Int16) As DataTable
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(20, 1, 2, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.SBU)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Function _pb02GetDataTIPEMERCHANDISE(ByVal prmnTargetServer012 As Int16) As DataTable
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(101, 0, 2, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Function _pb03IncNumberMaster(ByVal prmnTargetServer012 As Int16, ByVal prmf01cParamString As String, ByVal prmcFieldNameReturn As String) As String
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(103, 0, 0, prmf01cParamString, "", "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Dim pcIncNumberOrderMD As String = ""

        For Each dtRow As DataRow In pdtHasil.Rows
            pcIncNumberOrderMD = CStr(dtRow(prmcFieldNameReturn))
        Next

        Return pcIncNumberOrderMD
    End Function

    Public Function _pb03IncNumberMasterReqQty(ByVal prmnTargetServer012 As Int16, ByVal prmf01cParamString As String, ByVal prmnJmlRec As Integer) As DataTable
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(1033, 0, 0, prmf01cParamString, "", "", prmnJmlRec, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Function _pb04GetDataHistoryTGP(ByVal prmnTargetServer012 As Int16, ByVal prmdTglTodayGoldPrice As Date) As Integer
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(101, 0, 7, "", "", "", 0, 0, prmdTglTodayGoldPrice, "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        Dim pnTGP As Integer = 0
        For Each dtRow As DataRow In pdtHasil.Rows
            pnTGP = CInt(dtRow("f10Int"))
        Next

        objParamCollection.Dispose()

        Return pnTGP
    End Function


#End Region

#Region "Async - master - custom method - public"

    Public Async Function _pb01GetDataCUSTOMER_Async(ByVal prmnTargetServer012 As Int16) As Task(Of DataTable)
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(20, 1, 2, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = Await objHelper._pb02NasaExecSPSELECTtoDataTableAsync(prmnTargetServer012, _pnmDatabaseName.SBU)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Async Function _pb02GetDataTIPEMERCHANDISE_Async(ByVal prmnTargetServer012 As Int16) As Task(Of DataTable)
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(101, 0, 2, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = Await objHelper._pb02NasaExecSPSELECTtoDataTableAsync(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Async Function _pb03IncNumberMaster_Async(ByVal prmnTargetServer012 As Int16, ByVal prmf01cParamString As String, ByVal prmcFieldNameReturn As String) As Task(Of String)
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(103, 0, 0, prmf01cParamString, "", "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = Await objHelper._pb02NasaExecSPSELECTtoDataTableAsync(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Dim pcIncNumberOrderMD As String = ""

        For Each dtRow As DataRow In pdtHasil.Rows
            pcIncNumberOrderMD = CStr(dtRow(prmcFieldNameReturn))
        Next

        Return pcIncNumberOrderMD
    End Function

#End Region

#Region "Async - transaksi - custom method - public"

    Public Function _pbtMD01GetDataPO(ByVal prmnTargetServer012 As Int16) As DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(1, 0, 0, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim objGetData As New clsGetDataProsesTransaksiGEMINI

        Dim pdtHasil As New DataTable
        pdtHasil = objGetData._tr01MDTransact(prmnTargetServer012, "spMDTransaksi", objParamCollection)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

#End Region

#Region "Sync - transaksi - custom method - public"
    Public Function _tr01GetDataMRP32DESIGNMASTER(ByVal prmnTargetServer012 As Int16) As DataTable
        Dim pdtHasil As New DataTable

        pdtHasil = objHelper._pb03NasaExecSPPROCESStoDataTable(prmnTargetServer012, _pnmDatabaseName.MRP, "spMD23ListDesigMaster")

        Return pdtHasil
    End Function

#End Region

End Class
