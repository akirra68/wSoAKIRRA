Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class clsNasaHelper
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

    Property _prop01VarNasaSelectParamDataCollection As clsNasaSelectParamDataCollection
    Property _prop10SQLCommand As String = ""
    Property _prop11StoredProcedureName As String = ""

    Private objNasaConnection As clsNasaDatabaseConnection

    'ENUM "_pnmDatabaseName" ini SAMA DGN "SKK02OBJECTS.clsGetDataProsesTransaksiGEMINI._pnmDatabaseName"
    'jika ada PENAMBAHAN ATAU PENGURANGAN ENUM ini maka ENUM yg di "SKK02OBJECTS.clsGetDataProsesTransaksiGEMINI._pnmDatabaseName" juga harus disesuaikan.
    Public Enum _pnmDatabaseName
        TABLEMASTER = 0
        LOG = 1
        SBU = 2
        MRP = 3
    End Enum

#Region "form - event"

    Public Sub New()
        objNasaConnection = New clsNasaDatabaseConnection
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objNasaConnection.Dispose()
    End Sub
#End Region

#Region "private - method"

    Private Function _cm01GetNasaDBConnectionString(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As String
        Dim pcNasaDBConnection As String = ""

        Select Case prmcNasaDatabaseTarget
            Case _pnmDatabaseName.TABLEMASTER
                pcNasaDBConnection = objNasaConnection._cm01NasaConnectionDBTABLEMASTER(prmnTargetServer012)

            Case _pnmDatabaseName.LOG
                pcNasaDBConnection = objNasaConnection._cm02NasaConnectionDBLOG(prmnTargetServer012)

            Case _pnmDatabaseName.SBU
                pcNasaDBConnection = objNasaConnection._cm03NasaConnectionDBSBU(prmnTargetServer012)

            Case _pnmDatabaseName.MRP
                pcNasaDBConnection = objNasaConnection._cm04NasaConnectionDBMRP(prmnTargetServer012)

        End Select

        Return pcNasaDBConnection
    End Function

#End Region

#Region "sync"

    Public Function _pb01NasaExecSQLDirect(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                           ByVal prmnTarget1Text2SP As Int16,
                                           Optional ByVal prmcParamTemplateData2023 As String = "",
                                           Optional ByVal prmdtTemplateData2023 As DataTable = Nothing) As Integer
        Dim _pnJmlHasil As Integer = 0
        Dim _pcSQL As String = ""

        Dim _poCommandType = Nothing
        If prmnTarget1Text2SP = 1 Then
            _poCommandType = CommandType.Text
            _pcSQL = _prop10SQLCommand
        Else
            If prmnTarget1Text2SP = 2 Then
                _poCommandType = CommandType.StoredProcedure
                _pcSQL = _prop11StoredProcedureName
            End If
        End If

        Using _objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            _objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = _objConn,
                                                       .CommandType = _poCommandType,
                                                       .CommandText = _pcSQL}

                If Not String.IsNullOrEmpty(prmcParamTemplateData2023) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateData2023, prmdtTemplateData2023)
                End If

                _pnJmlHasil = objCommand.ExecuteNonQuery()
            End Using

            _objConn.Close()
        End Using

        Return _pnJmlHasil
    End Function

    Public Function _pb02NasaExecSQLDirect(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                      ByVal prmnTarget1Text2SP As Int16, ByVal prmcSQLScriptORNamaSP As String,
                                                      Optional ByVal prmcParamTemplateData2023 As String = "",
                                                      Optional ByVal prmdtTemplateData2023 As DataTable = Nothing,
                                                      Optional ByVal prmcParamAdditional As String = "",
                                                      Optional ByVal prmdtAdditional As DataTable = Nothing) As Integer
        Dim pnJmlHasil As Integer = 0

        Dim _poCommandType = Nothing
        If prmnTarget1Text2SP = 1 Then
            _poCommandType = CommandType.Text
        Else
            If prmnTarget1Text2SP = 2 Then
                _poCommandType = CommandType.StoredProcedure
            End If
        End If

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = _poCommandType,
                                                       .CommandText = prmcSQLScriptORNamaSP}

                If Not String.IsNullOrEmpty(prmcParamTemplateData2023) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateData2023, prmdtTemplateData2023)
                End If
                If Not String.IsNullOrEmpty(prmcParamAdditional) Then
                    objCommand.Parameters.AddWithValue(prmcParamAdditional, prmdtAdditional)
                End If

                pnJmlHasil = objCommand.ExecuteNonQuery()
            End Using

            objConn.Close()
        End Using

        Return pnJmlHasil
    End Function

    Public Function _pb01NasaExecSQLDirectToDataTable(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As DataTable
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.Text,
                                                       .CommandText = _prop10SQLCommand}

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SQLDirectToTable")
                End Using

            End Using

            objConn.Close()
        End Using


        Return dsDataSet.Tables(0)
    End Function

    Public Function _pb01NasaExecSQLDirectTigaParamDataTable(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                             ByVal prmcNamaStoredProcedure As String,
                                                             ByVal prmcParamTemplateDataTable01 As String, ByVal prmdtTemplateDataTable01 As DataTable,
                                                             ByVal prmcParamTemplateDataTable02 As String, ByVal prmdtTemplateDataTable02 As DataTable,
                                                             ByVal prmcParamTemplateDataTable03 As String, ByVal prmdtTemplateDataTable03 As DataTable) As Integer
        Dim _pnJmlHasil As Integer = 0
        Using _objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            _objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = _objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}

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

    Public Function _pb02NasaExecSPSELECTtoDataTable(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As DataTable
        Dim dsDataSet As New Data.DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = Data.CommandType.StoredProcedure,
                                                       .CommandText = "sp100EXECUTESELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", _prop01VarNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet)
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Function _pb03NasaExecSPPROCESStoDataTable(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                      ByVal prmcNamaStoredProcedure As String,
                                                      Optional ByVal prmcParamTemplateData2023 As String = "",
                                                      Optional ByVal prmdtTemplateData2023 As DataTable = Nothing) As DataTable
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}
                If Not String.IsNullOrEmpty(prmcParamTemplateData2023) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateData2023, prmdtTemplateData2023).SqlDbType = SqlDbType.Structured
                End If

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "Process")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Function _pb04NasaExecDataCollectionToDataTable(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As DataTable
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = _prop11StoredProcedureName}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", _prop01VarNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "DataCollection")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Function _pbFANasaHelperExec03SPSELECTToDataTable(ByVal prmnTargetServer012 As Int16,
                                                              ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                              ByVal prmdtNasaSelectParamDataCollection As clsNasaSelectParamDataCollection,
                                                              Optional ByVal prmcNamaStoredProcedure As String = "spWS100EXECSQLSELECT",
                                                              Optional ByVal prmcParamSQLSelect As String = "@tpParamSQLSelect") As DataTable
        Dim dsDataSet As New Data.DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            objConn.Open()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = Data.CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}
                objCommand.Parameters.AddWithValue(prmcParamSQLSelect, prmdtNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SPSELECTToTable")
                End Using

            End Using

            objConn.Close()
        End Using

        Return dsDataSet.Tables(0)
    End Function
#End Region

#Region "async"

    Public Async Function _pb01NasaExecSQLDirectAsync(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                      ByVal prmnTarget1Text2SP As Int16, ByVal prmcSQLScriptORNamaSP As String,
                                                      Optional ByVal prmcParamTemplateData2023 As String = "",
                                                      Optional ByVal prmdtTemplateData2023 As DataTable = Nothing,
                                                      Optional ByVal prmcParamAdditional As String = "",
                                                      Optional ByVal prmdtAdditional As DataTable = Nothing) As Task(Of Integer)
        Dim pnJmlHasil As Integer = 0

        Dim _poCommandType = Nothing
        If prmnTarget1Text2SP = 1 Then
            _poCommandType = CommandType.Text
        Else
            If prmnTarget1Text2SP = 2 Then
                _poCommandType = CommandType.StoredProcedure
            End If
        End If

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            Await objConn.OpenAsync()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = _poCommandType,
                                                       .CommandText = prmcSQLScriptORNamaSP}

                If Not String.IsNullOrEmpty(prmcParamTemplateData2023) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateData2023, prmdtTemplateData2023)
                End If
                If Not String.IsNullOrEmpty(prmcParamAdditional) Then
                    objCommand.Parameters.AddWithValue(prmcParamAdditional, prmdtAdditional)
                End If

                pnJmlHasil = Await objCommand.ExecuteNonQueryAsync()
            End Using

            Dim unused = objConn.CloseAsync()
        End Using

        Return pnJmlHasil
    End Function

    Public Async Function _pb01NasaExecSQLDirecttoDataTableAsync(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As Task(Of DataTable)
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            Await objConn.OpenAsync()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.Text,
                                                       .CommandText = _prop10SQLCommand}

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SQLDirectToTable")
                End Using

            End Using

            Dim unused = objConn.CloseAsync()
        End Using


        Return dsDataSet.Tables(0)
    End Function

    Public Async Function _pb02NasaExecSPSELECTtoDataTableAsync(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As Task(Of DataTable)
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            Await objConn.OpenAsync()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = "sp100EXECUTESELECT"}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", _prop01VarNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "SQLSelect")
                End Using

            End Using

            Dim unused = objConn.CloseAsync()
        End Using


        Return dsDataSet.Tables(0)
    End Function

    Public Async Function _pb03NasaExecSPPROCESStoDataTableAsync(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                                ByVal prmcNamaStoredProcedure As String, Optional ByVal prmcParamTemplateData2023 As String = "",
                                                                 Optional ByVal prmdtTemplateData2023 As DataTable = Nothing) As Task(Of DataTable)
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            Await objConn.OpenAsync()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = prmcNamaStoredProcedure}
                If Not String.IsNullOrEmpty(prmcParamTemplateData2023) Then
                    objCommand.Parameters.AddWithValue(prmcParamTemplateData2023, prmdtTemplateData2023)
                End If

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "Process")
                End Using

            End Using

            Dim unused = objConn.CloseAsync()
        End Using

        Return dsDataSet.Tables(0)
    End Function

    Public Async Function _pb04NasaExecDataCollectionToDataTableAsync(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName) As Task(Of DataTable)
        Dim dsDataSet As New DataSet

        Using objConn As New SqlConnection(_cm01GetNasaDBConnectionString(prmnTargetServer012, prmcNasaDatabaseTarget))
            Await objConn.OpenAsync()

            Using objCommand As New SqlCommand() With {.Connection = objConn,
                                                       .CommandType = CommandType.StoredProcedure,
                                                       .CommandText = _prop11StoredProcedureName}
                objCommand.Parameters.AddWithValue("@tpParamSQLSelect", _prop01VarNasaSelectParamDataCollection).SqlDbType = SqlDbType.Structured

                Using objAdapter As New SqlDataAdapter(objCommand)
                    objAdapter.Fill(dsDataSet, "DataCollection")
                End Using

            End Using

            Dim unused = objConn.CloseAsync()
        End Using

        Return dsDataSet.Tables(0)
    End Function

#End Region

End Class
