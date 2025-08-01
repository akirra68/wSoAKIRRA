Imports Microsoft.Data.SqlClient
Imports SKK01CORE

Public Class clsGetDataProsesTransaksiGEMINI
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
    Public Property _prop01User As clsUserGEMINI

    Public Property _prop02String As String

    'ENUM "_pnmDatabaseName" ini DEPENDENCY dgn "SKK01CORE.clsNasaHelper._pnmDatabaseName"
    Public Enum _pnmDatabaseName
        TABLEMASTER = 0
        LOG = 1
        SBU = 2
        MRP = 3
    End Enum

#Region "form - event"
    Public Sub New()
        objHelper = New clsNasaHelper()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objHelper.Dispose()
    End Sub
#End Region

#Region "MD : Async & Sync - Inheritance dari SKK01CORE"
    Public Function _tr01NasaExecDirectAllDB(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                         ByVal prmnTarget1Text2SP As Int16, ByVal prmcSQLScriptORNamaSP As String,
                                                         Optional ByVal prmcParamTemplateData As String = "", Optional ByVal prmdtTemplateData As DataTable = Nothing,
                                                         Optional ByVal prmcParamAdditional As String = "", Optional ByVal prmdtAdditional As DataTable = Nothing) As Integer

        Return objHelper._pb02NasaExecSQLDirect(prmnTargetServer012, prmcNasaDatabaseTarget,
                                                           prmnTarget1Text2SP, prmcSQLScriptORNamaSP,
                                                           prmcParamTemplateData, prmdtTemplateData,
                                                           prmcParamAdditional, prmdtAdditional)
    End Function

    Public Async Function _tr02NasaExecSPPROCESStoDataTableAllDB_Async(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                                       ByVal prmcNamaStoredProcedure As String,
                                                                       ByVal prmcParamTemplateData As String, ByVal prmdtTemplateData As DataTable) As Task(Of DataTable)

        Return Await objHelper._pb03NasaExecSPPROCESStoDataTableAsync(prmnTargetServer012, prmcNasaDatabaseTarget,
                                                                      prmcNamaStoredProcedure, prmcParamTemplateData, prmdtTemplateData)
    End Function

    Public Function _tr02NasaExecSPPROCESStoDataTableAllDB(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                           ByVal prmcNamaStoredProcedure As String,
                                                           ByVal prmcParamTemplateData As String, ByVal prmdtTemplateData As DataTable) As DataTable

        Return objHelper._pb03NasaExecSPPROCESStoDataTable(prmnTargetServer012, prmcNasaDatabaseTarget,
                                                           prmcNamaStoredProcedure, prmcParamTemplateData, prmdtTemplateData)
    End Function

#End Region

#Region "***** FINANCE *****"

#End Region

#Region "***** MERCHANDISE *****"

#Region "MD : Async - transaksi - custom method - public"

    Public Function _tr01MDTransact(ByVal prmnTargetServer012 As Int16,
                                    ByVal prmcStoredProcedureName As String,
                                    ByVal prmParamDataCollection As clsNasaSelectParamDataCollection) As DataTable
        Dim pdtHasil As New DataTable

        With objHelper
            ._prop01VarNasaSelectParamDataCollection = prmParamDataCollection
            ._prop11StoredProcedureName = prmcStoredProcedureName
        End With
        pdtHasil = objHelper._pb04NasaExecDataCollectionToDataTable(prmnTargetServer012, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Async Function _tr01MRP32OrderDESIGNMASTER_Async(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeDesignMaster As String) As Task(Of DataTable)
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(0, 0, 0, prmcKodeDesignMaster, "", "", 0, 0, "3000-01-01", "3000-01-01")

        With objHelper
            ._prop01VarNasaSelectParamDataCollection = objParamCollection
            ._prop11StoredProcedureName = "spMD23CreateOrderDesignMaster"
        End With
        pdtHasil = Await objHelper._pb04NasaExecDataCollectionToDataTableAsync(prmnTargetServer012, _pnmDatabaseName.MRP)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

#End Region

#Region "MD  : Sync - transaksi - custom method - public"
    Public Function _pbsy01PrepareDataPOCancel(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeProductionOrder As String) As DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(2, 0, 0, prmcKodeProductionOrder, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim objGetData As New clsGetDataProsesTransaksiGEMINI

        Dim pdtHasil As New DataTable
        pdtHasil = objGetData._tr01MDTransact(prmnTargetServer012, "spMDTransaksi", objParamCollection)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Function _pbSBUCheckUploadFile() As Integer
        Dim pcDupliacate As Integer = 0

        Dim objSelect As New clsNasaSelectParamDataCollection
        objSelect._01AddNew(0, 0, 0, _prop02String, "", "", 0.0, 0.0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = objHelper._pbFANasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp07TargetNetwork, clsNasaHelper._pnmDatabaseName.SBU,
                        objSelect, "spCheckDuplicateUpload", "@tpParamSQLSelect")

        For Each dtRow As DataRow In pdtHasil.Rows
            pcDupliacate = dtRow("DuplicateCount")
        Next

        Return pcDupliacate
    End Function

    Public Function _pbSBUInsertUploadFile(ByVal f01cParamString As String, ByVal f02cParamString As String, ByVal f01dParamDate As DateTime) As DataTable
        Dim pcDupliacate As Integer = 0

        Dim objSelect As New clsNasaSelectParamDataCollection
        objSelect._01AddNew(0, 0, 0, f01cParamString, f02cParamString, "", 0.0, 0.0, f01dParamDate, "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = objHelper._pbFANasaHelperExec03SPSELECTToDataTable(
                        _prop01User._UserProp07TargetNetwork, clsNasaHelper._pnmDatabaseName.SBU,
                        objSelect, "spMDInsertUploadHistoryG", "@tpParamSQLSelect")


        Return pdtHasil
    End Function

#End Region

#End Region

End Class
