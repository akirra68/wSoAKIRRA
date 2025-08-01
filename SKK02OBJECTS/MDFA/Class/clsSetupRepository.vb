
Public Class clsSetupRepository
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

    Private _pdtTABLEMASTER As DataTable
    Private _pdtSBUMASTER As DataTable
    Private _pdtMRPMASTER As DataTable

    Private _pdtSBUTRANSAKSI As DataTable

    Public Sub New()
        _pdtTABLEMASTER = New DataTable
        _pdtSBUMASTER = New DataTable
        _pdtMRPMASTER = New DataTable

        _pdtSBUTRANSAKSI = New DataTable
    End Sub

#Region "init - datasource - MASTER"

    Public Sub _pb10InitDataSourceMDMASTER(ByVal prmnTargetServer012 As Int16)
        Dim objGetDataMaster As New clsGetDataMasterGEMINI

        _pdtTABLEMASTER = objGetDataMaster._pb02GetDataTIPEMERCHANDISE(prmnTargetServer012)
    End Sub

    Public Sub _pb20InitDataSourceSBUMASTER(ByVal prmnTargetServer012 As Int16)
        Dim objGetDataMaster As New clsGetDataMasterGEMINI

        _pdtSBUMASTER = objGetDataMaster._pb01GetDataCUSTOMER(prmnTargetServer012)
    End Sub

    Public Sub _pb30InitDataSourceMRPMASTER(ByVal prmnTargetServer012 As Int16)
        Dim objGetDataMaster As New clsGetDataMasterGEMINI

        _pdtMRPMASTER = objGetDataMaster._tr01GetDataMRP32DESIGNMASTER(prmnTargetServer012)
    End Sub

    Private Sub _pb40GetDataTABLEMASTERForMastering(ByVal prmnTargetServer012 As Int16, ByVal prmnTargetExecMaster As Int16)
        Dim objFinHelper As New clsFinanceHelper

        _pdtTABLEMASTER.Clear()
        _pdtTABLEMASTER = objFinHelper._mFA101TableMasterForMastering(prmnTargetServer012, prmnTargetExecMaster)
    End Sub

#End Region

#Region "init - datasource - TRANSAKSI"

    Public Sub _pb40InitDataSourceSBUTRANSAKSI(ByVal prmnTargetServer012 As Int16)
        Dim objGetDataMaster As New clsGetDataMasterGEMINI

        _pdtSBUTRANSAKSI = objGetDataMaster._pbtMD01GetDataPO(prmnTargetServer012)
    End Sub
#End Region

#Region "setup - control - MERCHANDISE"

#Region "setup - control - TABLEMASTER"

    Public Sub _pb101SetupCtrlMERCHANDISE(ByRef prmCtrlMaster As ctrlGEMINIMaster)
        'Tipe Produksi
        'Sub Tipe Produksi

        '--------------------------------
        'TABLEMASTER..TABLE02
        'k02String = Kode Master
        'f01String = Nama Master
        'f02String = Kode GroupMaster
        'f03String = Nama GroupMaster
        '================================
        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtTABLEMASTER
            ._02prop_cGEMINIDaftarField = New String() {"k02String", "f01String", "f02String", "f03String"}
            ._03prop_cGEMINIFieldYgDiFilter = "f03String"
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = "MERCHANDISE"
            ._05prop_cGEMINIFieldValueMember = "k02String"
            ._06prop_cGEMINIFieldDisplayMember = "f01String"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()
        prmCtrlMaster._04FilterDataViewMasterSKK()

    End Sub

#End Region

#Region "setup - control - SBUMASTER"
    Public Sub _pb201SetupCtrlCUSTOMER(ByRef prmCtrlMaster As ctrlGEMINIMaster)
        '--------------------------------
        'SBU..TABLE02
        'k01String = GroupMaster
        'k02String = KeyCodeMaster
        'k03String = NamaMaster
        '================================
        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtSBUMASTER
            ._02prop_cGEMINIDaftarField = New String() {"k01String", "k02String", "k03String"}
            ._03prop_cGEMINIFieldYgDiFilter = "k01String"
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = "MCUSTOMER"
            ._05prop_cGEMINIFieldValueMember = "k02String"
            ._06prop_cGEMINIFieldDisplayMember = "k03String"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()
        prmCtrlMaster._04FilterDataViewMasterSKK()
    End Sub

#End Region

#Region "setup - control - MRP"
    Public Sub _pb301SetupCtrlDESIGNMASTER(ByRef prmCtrlMaster As ctrlGEMINIMaster)
        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtMRPMASTER
            ._02prop_cGEMINIDaftarField = New String() {"f02cKodeDesignMaster_v50", "f04cNamaItemProduct_v50"}
            ._05prop_cGEMINIFieldValueMember = "f02cKodeDesignMaster_v50"
            ._06prop_cGEMINIFieldDisplayMember = "f02cKodeDesignMaster_v50"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()
    End Sub
#End Region

#Region "setup - control - SBUTRANSAKSI"
    Public Sub _pb401SetupCtrlPO(ByRef prmCtrlMaster As ctrlGEMINIMaster)

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtSBUTRANSAKSI
            ._02prop_cGEMINIDaftarField = New String() {"k05String", "k04String", "f19String"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "k05String"
            ._06prop_cGEMINIFieldDisplayMember = "k05String"
        End With
        prmCtrlMaster._03BindingAwalDataSource3Field("k05String", "No. PO", "k04String", "ProductCode", "f19String", "Customer")
    End Sub
#End Region

#End Region

#Region "setup - control - FINANCE"

#Region "setup - control - TABLEMASTER"

    Public Sub _pb101SetupCtrlHargaEmas(ByVal prmnTargetServer012 As Int16,
                                        ByRef prmCtrlMaster As ctrlGEMINIMaster,
                                        Optional ByVal prmcString01 As String = "")
        Dim pdtHasil As New DataTable

        Dim objFinHelper As New clsFinanceHelper
        pdtHasil = objFinHelper._mFA101TableMasterForMastering(prmnTargetServer012, 3, prmcString01)

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = pdtHasil
            ._02prop_cGEMINIDaftarField = New String() {"k12String", "k13String", "k14String", "k15String", "f12String", "f10Int", "f11Int", "f10Datetime"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "k12String"
            ._06prop_cGEMINIFieldDisplayMember = "k13String"
            ._07prop_cGEMINIKeyKolomFilterUntSelect = "k12String"
        End With
        prmCtrlMaster._03BindingAwalDataSource3Field("k12String", "Code", "k13String", "Nama", "f10Int", "HargaEmas")

    End Sub

    Public Sub _pb101SetupCtrlHargaEmasWithPlusReserved(ByRef prmCtrlMaster As ctrlGEMINIMaster,
                                                        ByVal prmdtPlusReserved As DataTable)

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = prmdtPlusReserved
            ._02prop_cGEMINIDaftarField = New String() {"k12String", "k13String", "k14String", "k15String", "f12String", "f10Int", "f10Datetime"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "k12String"
            ._06prop_cGEMINIFieldDisplayMember = "k13String"
            ._07prop_cGEMINIKeyKolomFilterUntSelect = "k12String"
        End With
        prmCtrlMaster._03BindingAwalDataSource3Field("k12String", "Code", "k13String", "Nama", "f10Int", "HargaEmas")
    End Sub

    Public Sub _pb101SetupCtrlCollectionType(ByVal prmnTargetServer012 As Int16, ByRef prmCtrlMaster As ctrlGEMINIMaster)
        _pb40GetDataTABLEMASTERForMastering(prmnTargetServer012, 4)

        '"GTCOLL35" : Discount Pelunasan
        For Each dtRow As DataRow In _pdtTABLEMASTER.Rows
            If CStr(dtRow("k12String")) = "GTCOLL35" Then
                dtRow.Delete()
            End If
        Next
        _pdtTABLEMASTER.AcceptChanges()

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtTABLEMASTER
            ._02prop_cGEMINIDaftarField = New String() {"k12String", "k13String"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "k12String"
            ._06prop_cGEMINIFieldDisplayMember = "k13String"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()
    End Sub

#End Region

    Private Sub _pFA60GetDataSource(ByVal prmnTargetServer012 As Int16, ByVal prmnTarget As Int16, ByVal prmcString01 As String)
        _pdtSBUMASTER.Clear()

        Dim objFAHelper As New clsFinanceHelper
        Select Case prmnTarget
            Case 1, 2   '1.CREATE PROFORMA : 2. UPDATE/DELETE PROFORMA ==> Daftar Customer 
                _pdtSBUMASTER = objFAHelper._mFA61GetDataMastering(prmnTargetServer012, prmnTarget, prmcString01)
            Case 3      '3. No Proforma yg akan dipakai untuk UPDATE/DELETE
                _pdtSBUMASTER = objFAHelper._mFA61GetDataMastering(prmnTargetServer012, prmnTarget, prmcString01)
            Case 5      '5. List Customer yg melakukan Collection/Pelunasan (OST)
                _pdtSBUMASTER = objFAHelper._mFA61GetDataMastering(prmnTargetServer012, prmnTarget, prmcString01)
            Case 7      '7. List Customer unt membuat TAGIHAN
                _pdtSBUMASTER = objFAHelper._mFA61GetDataMastering(prmnTargetServer012, prmnTarget, prmcString01)
        End Select

    End Sub

    Public Sub _pbFA60SetupCtrlCustomerProforma(ByVal prmnTargetServer012 As Int16, ByRef prmCtrlMaster As ctrlGEMINIMaster, ByVal prmnTarget As Int16)
        _pFA60GetDataSource(prmnTargetServer012, prmnTarget, "")

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtSBUMASTER
            ._02prop_cGEMINIDaftarField = New String() {"f01String", "f02String"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "f01String"
            ._06prop_cGEMINIFieldDisplayMember = "f02String"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()

    End Sub

    Public Sub _pbFA62SetupCtrlNoProforma(ByVal prmnTargetServer012 As Int16, ByRef prmCtrlMaster As ctrlGEMINIMaster, ByVal prmnTarget As Int16, ByVal prmcString01 As String)
        _pFA60GetDataSource(prmnTargetServer012, prmnTarget, prmcString01)

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtSBUMASTER
            ._02prop_cGEMINIDaftarField = New String() {"f08String", "nJmlPcsCMK", "nJmlBeratCMK", "nJmlPcsSKK", "nJmlBeratSKK", "nTotalBerat"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "f08String"
            ._06prop_cGEMINIFieldDisplayMember = "f08String"
        End With
        prmCtrlMaster._03BindingAwalDataSource3Field("f08String", "No.Proforma", "nJmlPcsSKK", "JmlPcs", "nJmlBeratSKK", "JmlBerat")

    End Sub

    Public Sub _pbFA60SetupCtrlCustomerCollectionOST(ByVal prmnTargetServer012 As Int16, ByRef prmCtrlMaster As ctrlGEMINIMaster, ByVal prmnTarget As Int16)
        _pFA60GetDataSource(prmnTargetServer012, prmnTarget, "")

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = _pdtSBUMASTER
            ._02prop_cGEMINIDaftarField = New String() {"f01String", "f02String"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "f01String"
            ._06prop_cGEMINIFieldDisplayMember = "f02String"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()

    End Sub

    Public Sub _pbFA61SetupCtrlCustomerTagihan(ByVal prmnTargetServer012 As Int16, ByRef prmCtrlMaster As ctrlGEMINIMaster, ByVal prmnTarget As Int16, Optional ByVal isIncludeRESERVED As Boolean = False)
        '_pFA60GetDataSource(prmnTargetServer012, prmnTarget, "")
        '_pdtSBUMASTER

        Dim objFAHelper As New clsFinanceHelper
        Dim pdtHasil As New DataTable
        pdtHasil = objFAHelper._mFA61GetDataMastering(prmnTargetServer012, prmnTarget, "")

        If isIncludeRESERVED Then
            Dim oDataRow As DataRow = pdtHasil.NewRow()
            oDataRow("f12String") = "SKK2023"
            oDataRow("f13String") = "BANK OF SKK"
            pdtHasil.Rows.Add(oDataRow)
            pdtHasil.AcceptChanges()
        End If

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = pdtHasil
            ._02prop_cGEMINIDaftarField = New String() {"f12String", "f13String"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "f12String"
            ._06prop_cGEMINIFieldDisplayMember = "f13String"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()

    End Sub

    Public Sub _pbFA61SetupCtrlCustomerLUNAS(ByVal prmnTargetServer012 As Int16, ByRef prmCtrlMaster As ctrlGEMINIMaster, ByVal prmnTarget As Int16)
        Dim objFAHelper As New clsFinanceHelper
        Dim pdtHasil As New DataTable
        pdtHasil = objFAHelper._mFA61GetDataMastering(prmnTargetServer012, prmnTarget, "")

        With prmCtrlMaster
            ._01prop_dtGEMINIMaster = pdtHasil
            ._02prop_cGEMINIDaftarField = New String() {"f12String", "f13String"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "f12String"
            ._06prop_cGEMINIFieldDisplayMember = "f13String"
        End With
        prmCtrlMaster._03BindingAwalDataSource2Field()

    End Sub

    Public Sub _pbFA61SetupCtrlEntitasSettlement(ByVal prmnTargetServer012 As Int16, ByRef prmCtrlEntitas As ctrlGEMINIMaster, ByVal prmcString As String)
        Dim objFAHelper As New clsFinanceHelper
        Dim pdtHasil As New DataTable
        pdtHasil = objFAHelper._mFA61GetDataForRepoEntitas(prmnTargetServer012, prmcString)

        With prmCtrlEntitas
            ._01prop_dtGEMINIMaster = pdtHasil
            ._02prop_cGEMINIDaftarField = New String() {"f03String", "f01String", "f02String", "f01Double"}
            ._03prop_cGEMINIFieldYgDiFilter = ""
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = ""
            ._05prop_cGEMINIFieldValueMember = "f01String"
            ._06prop_cGEMINIFieldDisplayMember = "f02String"
            ._07prop_cGEMINIKeyKolomFilterUntSelect = "f01String"
        End With
        prmCtrlEntitas._03BindingAwalDataSource4Field("f03String", "Identity", "f01String", "Code", "f02String", "Name", "f01Double", "OST AR")

    End Sub

#End Region

#Region "setup - repository"

#End Region

End Class
