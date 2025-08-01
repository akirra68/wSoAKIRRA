Imports SKK01CORE
Imports SKK01CORE.clsNasaHelper

Public Class clsGetDataTableMaster
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

#Region "Sync : custom method - public"

    Public Function _pb01GetDataUserLOGIN(ByVal prmnTargetServer012 As Int16, ByVal prmcNIK As String) As DataTable
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(200, 0, 1, prmcNIK, "", "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Function _pb02GetDataUserACCESSAsync(ByVal prmnTargetServer012 As Int16, ByVal prmcNIK As String) As DataTable
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(200, 0, 3, "USERACCESS", prmcNIK, "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Public Function _pb03UserChangePassword(ByVal prmnTargetServer012 As Int16,
                                            ByVal prmcNIK As String,
                                            ByVal prmcPrivatKey As String,
                                            ByVal prmcEncrypted As String) As Integer
        Dim pnHasil As Integer = 0
        objHelper._prop10SQLCommand = " update TABLE20 " &
                                      " set f01StringMax = '" & prmcPrivatKey & "', f02StringMax = '" & prmcEncrypted & "'" &
                                      " where k02String	= '" & prmcNIK & "'"

        pnHasil = objHelper._pb01NasaExecSQLDirect(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER, 1)

        Return pnHasil
    End Function

    Public Function _pb04GetDataAppVersion(ByVal prmnTargetServer012 As Int16,
                                           ByVal prmcIDApp As String) As DataTable
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        objParamCollection._01AddNew(200, 0, 2, "VERSIONAPP", prmcIDApp, "", 0, 0, "3000-01-01", "3000-01-01")

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, _pnmDatabaseName.TABLEMASTER)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    'copy dari "clsWSNasaSelect4AllProsesMaster.._pb51GetDataIncNoDocWarehouse"
    Public Function _pb51GetDataIncNoDocFinance(ByVal prmnTargetServer012 As Int16, ByVal _prop02String As String) As String
        Dim pcNoDokumen As String = ""

        '_prop02String adl GROUP NUMBER MASTER (table51 -> k11String)

        Dim objSelect As New clsNasaSelectParamDataCollection
        objSelect._01AddNew(0, 0, 0, _prop02String, "", "", 0.0, 0.0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = objHelper._pbFANasaHelperExec03SPSELECTToDataTable(
                        prmnTargetServer012, _pnmDatabaseName.TABLEMASTER,
                        objSelect, "sp151WSIncNumberMaster", "@tpParamSQLSelect")
        For Each dtRow As DataRow In pdtHasil.Rows
            pcNoDokumen = dtRow("cNoDokumen").ToString
        Next

        Return pcNoDokumen
    End Function

#End Region

End Class
