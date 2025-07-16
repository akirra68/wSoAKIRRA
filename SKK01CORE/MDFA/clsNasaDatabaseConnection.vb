Public Class clsNasaDatabaseConnection
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

    Private Const cstServerLocal = "(local)"
    Private Const cstServerPrivate = "172.25.0.2,1500"
    Private Const cstServerPublic = "103.116.201.138,1500"
    Private Const cstServerPrivateStaging = "172.25.0.4"
    Private Const cstServerPublicStaging = "103.116.201.140"

    Private Function _cm01NasaSQLConnection(ByVal prmnTargetServer012 As Int16,
                                            ByVal prmDatabaseName As String) As String
        Dim pcNasaConn As String = ""
        Dim pcNasaServerAddress As String = ""
        Dim pcUserIDSQL As String = ""
        Dim pcPasswordSQL As String = ""

        Select Case prmnTargetServer012
            Case 0
                pcNasaServerAddress = cstServerLocal
                pcUserIDSQL = "akirra"
                pcPasswordSQL = "g1t@2025"
            Case 1
                pcNasaServerAddress = cstServerPrivate
                pcUserIDSQL = "aris"
                pcPasswordSQL = "s@k@2020"
            Case 2
                pcNasaServerAddress = cstServerPublic
                pcUserIDSQL = "aris"
                pcPasswordSQL = "s@k@2020"
            Case 3
                pcNasaServerAddress = cstServerPrivateStaging
                pcUserIDSQL = "sa"
                pcPasswordSQL = "nasa@123"
            Case 4
                pcNasaServerAddress = cstServerPublicStaging
                pcUserIDSQL = "sa"
                pcPasswordSQL = "nasa@123"
        End Select

        pcNasaConn = String.Format("Server = {0};Database = {1};USER ID = {2};PASSWORD= {3};Encrypt=False",
                                   pcNasaServerAddress, prmDatabaseName, pcUserIDSQL, pcPasswordSQL)

        Return pcNasaConn
    End Function

#Region "database connection"

    Public Function _cm01NasaConnectionDBTABLEMASTER(ByVal prmnTargetServer012 As Int16) As String
        Return _cm01NasaSQLConnection(prmnTargetServer012, "TABLEMASTER")
    End Function

    Public Function _cm02NasaConnectionDBLOG(ByVal prmnTargetServer012 As Int16) As String
        Return _cm01NasaSQLConnection(prmnTargetServer012, "SBULOG")
    End Function

    Public Function _cm03NasaConnectionDBSBU(ByVal prmnTargetServer012 As Int16) As String
        Return _cm01NasaSQLConnection(prmnTargetServer012, "SBU")
    End Function

    Public Function _cm04NasaConnectionDBMRP(ByVal prmnTargetServer012 As Int16) As String
        Return _cm01NasaSQLConnection(prmnTargetServer012, "MRP")
    End Function

#End Region

End Class
