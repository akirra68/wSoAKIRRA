Imports SKK01CORE
Imports SKK01CORE.clsNasaHelper

Public Class clsGetDataReportGEMINI
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

    Public Property _propTargetReportGEMINI As TargetDataReportGEMINI

    Public Property _propParamData As clsNasaSelectParamData

    Private objHelper As clsNasaHelper

    Public Enum TargetDataReportGEMINI

        _rpt01MDProductionOrder = 0
        _rpt21MDRPTSTATUSPODIPRODUKSI = 1

        _infoCatalogProduct = 20    'CATALOG PRODUCT : ucMD23FO01LISTPRODUCTCODE (pd event "leave TglHingga" & pd event buttonclick "Display")
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

#Region "custom method - private"

    Private Function _cm01GetNamaSPReportGEMINI() As String
        Dim pcNamaSP As String = ""

        Select Case _propTargetReportGEMINI
            Case TargetDataReportGEMINI._rpt01MDProductionOrder, TargetDataReportGEMINI._rpt21MDRPTSTATUSPODIPRODUKSI
                pcNamaSP = "spMDReport"
        End Select

        Return pcNamaSP
    End Function

#End Region

#Region "Async - report - custom method - public"

    Public Async Function _rpt01GetDataReportGEMINIAsync(ByVal prmnTargetServer012 As Int16) As Task(Of DataTable)
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        With _propParamData
            objParamCollection._01AddNew(.f01nTargetSPParent_int, .f02nTargetSPChild_int, .f03nTargetExec_int,
                                         .f01cParamString, .f02cParamString, .f03cParamString,
                                         .f01nParamNumerik, .f02nParamNumerik,
                                         .f01dParamDate, .f02dParamDate)
        End With

        With objHelper
            ._prop01VarNasaSelectParamDataCollection = objParamCollection
            ._prop11StoredProcedureName = _cm01GetNamaSPReportGEMINI()
        End With
        pdtHasil = Await objHelper._pb04NasaExecDataCollectionToDataTableAsync(prmnTargetServer012, _pnmDatabaseName.SBU)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

#End Region

#Region "Async - report (CATALOG PRODUCT) - custom method - public"

    'CATALOG PRODUCT
    Public Async Function _info01GetDataDisplayProductCodeAsync(ByVal prmnTargetServer012 As Int16,
                                                                ByVal prmcSQL As String) As Task(Of DataTable)
        Dim pdtHasil As New DataTable

        objHelper._prop10SQLCommand = prmcSQL
        pdtHasil = Await objHelper._pb01NasaExecSQLDirecttoDataTableAsync(prmnTargetServer012, _pnmDatabaseName.MRP)

        Return pdtHasil
    End Function

    Public Function _info02GetDataDisplayProductCode(ByVal prmnTargetServer012 As Int16,
                                                     ByVal prmcSQL As String) As DataTable
        Dim pdtHasil As New DataTable

        objHelper._prop10SQLCommand = prmcSQL
        pdtHasil = objHelper._pb01NasaExecSQLDirectToDataTable(prmnTargetServer012, _pnmDatabaseName.MRP)

        Return pdtHasil
    End Function

    'DETAIL CATALOG PRODUCT
    Public Function _info03GetDataMerchandiseDetailCatalog(ByVal prmnTargetServer012 As Int16,
                                                           ByVal prmcSQL As String) As DataTable
        Dim pdtHasil As New DataTable

        objHelper._prop10SQLCommand = prmcSQL
        pdtHasil = objHelper._pb01NasaExecSQLDirectToDataTable(prmnTargetServer012, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _info04GetDataBOMDetailCatalog(ByVal prmnTargetServer012 As Int16,
                                                   ByVal prmcSQL As String) As DataTable
        Dim pdtHasil As New DataTable

        objHelper._prop10SQLCommand = prmcSQL
        pdtHasil = objHelper._pb01NasaExecSQLDirectToDataTable(prmnTargetServer012, _pnmDatabaseName.MRP)

        Return pdtHasil
    End Function

    Public Function _info05GetDataProduksiDetailCatalog(ByVal prmnTargetServer012 As Int16,
                                                        ByVal prmcSQL As String) As DataTable
        Dim pdtHasil As New DataTable

        objHelper._prop10SQLCommand = prmcSQL
        pdtHasil = objHelper._pb01NasaExecSQLDirectToDataTable(prmnTargetServer012, _pnmDatabaseName.MRP)

        Return pdtHasil
    End Function

#End Region

End Class
