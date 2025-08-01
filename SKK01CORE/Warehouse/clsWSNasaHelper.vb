Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class clsWSNasaHelper
    Inherits clsWSNasaDatabaseConnection
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

    Public Enum _pnmDatabaseName
        WS = 0
        WSLOG = 1
        TABLEMASTER = 2
        WS24 = 3
    End Enum

#Region "private - method"

    Private Function _cm01NasaDBConnectionString(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As String
        Dim pcNasaDBConnection As String = ""

        Select Case prmcNasaDatabaseTarget
            Case _pnmDatabaseName.WS
                pcNasaDBConnection = MyBase._pbNasaConnectDB01WS(prmnTargetServer012)

            Case _pnmDatabaseName.WSLOG
                pcNasaDBConnection = MyBase._pbNasaConnectDB02WSLOG(prmnTargetServer012)

            Case _pnmDatabaseName.TABLEMASTER
                pcNasaDBConnection = MyBase._pbNasaConnectDB03TABLEMASTER(prmnTargetServer012)

            Case _pnmDatabaseName.WS24
                pcNasaDBConnection = MyBase._pbNasaConnectDB04WS24(prmnTargetServer012)

        End Select

        Return pcNasaDBConnection
    End Function

#End Region

#Region "method - protected"

    Public Function _pbWSNasaExecSQLDirectToDataTable(ByVal prmnTargetServer012 As Int16,
                                                      ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                      ByVal prmnTarget1Text2SP As Int16,
                                                      ByVal prmcSQLScriptOrSPName As String) As DataTable
        Dim dsDataSet As New DataSet

        Dim _poCommandType As Object = Nothing
        If prmnTarget1Text2SP = 1 Then
            _poCommandType = CommandType.Text
        Else
            If prmnTarget1Text2SP = 2 Then
                _poCommandType = CommandType.StoredProcedure
            End If
        End If

        Using objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = _poCommandType,
                                                       .CommandText = prmcSQLScriptOrSPName}

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SQLDirectToTable")
                End Using

            End Using

            objConn.Close()
        End Using


        Return dsDataSet.Tables(0)
    End Function

    Public Function _pbWSNasaHelperExec01SPSQLProses(ByVal prmnTargetServer012 As Integer,
                                         ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                         ByVal prmnTarget1Text2SP As Integer,
                                         ByVal prmcSQLScriptOrSPName As String,
                                         Optional ByVal prmcParamTemplateDataTable01 As String = "", Optional ByVal prmdtTemplateDataTable01 As DataTable = Nothing,
                                         Optional ByVal prmcParamTemplateDataTable02 As String = "", Optional ByVal prmdtTemplateDataTable02 As DataTable = Nothing,
                                         Optional ByVal prmcParamTemplateDataTable03 As String = "", Optional ByVal prmdtTemplateDataTable03 As DataTable = Nothing) As Integer
        Dim _pnJmlHasil As Integer = 0

        Dim _poCommandType As Object = Nothing
        If prmnTarget1Text2SP = 1 Then
            _poCommandType = CommandType.Text
        Else
            If prmnTarget1Text2SP = 2 Then
                _poCommandType = CommandType.StoredProcedure
            End If
        End If

        Using _objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            _objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = _objConn,
                                                       .CommandType = _poCommandType,
                                                       .CommandText = prmcSQLScriptOrSPName}

                If Not String.IsNullOrEmpty(prmcParamTemplateDataTable01) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateDataTable01, prmdtTemplateDataTable01).SqlDbType = SqlDbType.Structured
                End If
                If Not String.IsNullOrEmpty(prmcParamTemplateDataTable02) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateDataTable02, prmdtTemplateDataTable02).SqlDbType = SqlDbType.Structured
                End If
                If Not String.IsNullOrEmpty(prmcParamTemplateDataTable03) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateDataTable03, prmdtTemplateDataTable03).SqlDbType = SqlDbType.Structured
                End If

                _pnJmlHasil = objCommand.ExecuteNonQuery()
            End Using

            _objConn.Close()
        End Using

        Return _pnJmlHasil
    End Function

    Public Function _pbWSNasaHelperExec01SQLScript(ByVal prmnTargetServer012 As Integer,
                                                   ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                   ByVal prmcSQLScript As String) As Integer
        Dim _pnJmlHasil As Integer = 0

        Using _objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            _objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = _objConn,
                                                      .CommandType = CommandType.Text,
                                                      .CommandText = prmcSQLScript}

                _pnJmlHasil = objCommand.ExecuteNonQuery()
            End Using

            _objConn.Close()
        End Using

        Return _pnJmlHasil
    End Function

    Protected Function _pbWSNasaHelperExec02SQLSELECTToDataTable(ByVal prmnTargetServer012 As Int16,
                                                               ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                               ByVal prmcScriptSQLSELECT As String) As DataTable
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.Text,
                                                       .CommandText = prmcScriptSQLSELECT}

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SQLSELECTToTable")
                End Using

            End Using

            objConn.Close()
        End Using


        Return dsDataSet.Tables(0)
    End Function

    Public Function _pbWSNasaHelperExec03SPSELECTToDataTable(ByVal prmnTargetServer012 As Int16,
                                                              ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                              ByVal prmdtWSNasaSelectParamDataCollection As clsWSNasaSelectParamDataCollection,
                                                              Optional ByVal prmcNamaStoredProcedure As String = "spWS100EXECSQLSELECT",
                                                              Optional ByVal prmcParamSQLSelect As String = "@tpParamSQLSelect") As DataTable
        Dim dsDataSet As New Data.DataSet

        Using objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = Data.CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}
                objCommand.Parameters.AddWithValue(prmcParamSQLSelect, prmdtWSNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SPSELECTToTable")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Function _pbMasterNasaHelperExec03SPSELECTToDataTable(ByVal prmnTargetServer012 As Int16,
                                                              ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                              ByVal prmdtWSNasaSelectParamDataCollection As clsWSNasaSelectParamDataCollection,
                                                              Optional ByVal prmcNamaStoredProcedure As String = "sp100EXECUTESELECT",
                                                              Optional ByVal prmcParamSQLSelect As String = "@tpParamSQLSelect") As DataTable
        Dim dsDataSet As New Data.DataSet

        Using objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = Data.CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}
                objCommand.Parameters.AddWithValue(prmcParamSQLSelect, prmdtWSNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SPSELECTToTable")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Function _pbWSNasaHelperExec04SPSELECTToDataTable(ByVal prmnTargetServer012 As Int16,
                                                           ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                           ByVal prmdtWSNasaSelectParamDataCollection As clsWSNasaSelectParamDataCollection,
                                                           Optional ByVal prmcNamaStoredProcedure As String = "spWS100EXECSQLSELECT",
                                                           Optional ByVal prmcParamSQLSelect As String = "@tpParamSQLSelect") As DataTable
        Dim dsDataSet As New Data.DataSet

        Using objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = Data.CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}
                objCommand.Parameters.AddWithValue(prmcParamSQLSelect, prmdtWSNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SPSELECTToTable")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Function _pbWSNasaHelperExec05SPSELEPassTblTypeToDataTable(ByVal prmnTargetServer012 As Int16,
                                                       ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                       ByVal prmcNamaStoredProcedure As String,
                                                       ByVal prmcParamTemplateDataTable As String,
                                                       ByVal prmdtTemplateDataTable As DataTable
                                                       ) As DataTable
        Dim dsDataSet As New Data.DataSet

        Using objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = Data.CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure,
                                                       .CommandTimeout = 5000}
                objCommand.Parameters.AddWithValue(prmcParamTemplateDataTable, prmdtTemplateDataTable).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SPSELETypeToTable")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Function _pbWSNasaHelperExec06SPSELEPassTblTypeToDataTable03(ByVal prmnTargetServer012 As Int16,
                                                    ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                    ByVal prmcNamaStoredProcedure As String,
                                                    Optional ByVal prmcParamTemplateDataTable As String = "", Optional ByVal prmdtTemplateDataTable As DataTable = Nothing,
                                                    Optional ByVal prmcParamTemplateDataTable01 As String = "", Optional ByVal prmdtTemplateDataTable01 As DataTable = Nothing,
                                                    Optional ByVal prmcParamTemplateDataTable02 As String = "", Optional ByVal prmdtTemplateDataTable02 As DataTable = Nothing
                                                    ) As DataTable
        Dim dsDataSet As New Data.DataSet

        Using objConn As New SqlConnection(_cm01NasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = Data.CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}

                If Not String.IsNullOrEmpty(prmcParamTemplateDataTable) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateDataTable, prmdtTemplateDataTable).SqlDbType = SqlDbType.Structured
                End If
                If Not String.IsNullOrEmpty(prmcParamTemplateDataTable01) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateDataTable01, prmdtTemplateDataTable01).SqlDbType = SqlDbType.Structured
                End If
                If Not String.IsNullOrEmpty(prmcParamTemplateDataTable02) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateDataTable02, prmdtTemplateDataTable02).SqlDbType = SqlDbType.Structured
                End If

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SPSELETypeToTable")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

#End Region

End Class
