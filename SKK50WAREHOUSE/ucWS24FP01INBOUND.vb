Imports DevExpress.CodeParser
Imports DevExpress.DashboardCommon.DataProcessing
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports SKK01CORE
Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGrid

Public Class ucWS24FP01INBOUND
    Implements clsWSNasaInterface

    Property _prop01User As clsWSNasaUser

    Private pdtMRPProduct As DataTable
    Private pdtMRPSize As DataTable

    Private pdtGridInbound As DataTable

    Private pdtDataForSave As DataTable
    Private ctrlDataForSave As clsWSNasaTemplateDataLargePlus

    Private objContainer As PopupContainerControl
    Private objUserControl As XtraUserControl

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtMRPProduct = New DataTable
        pdtMRPSize = New DataTable

        pdtGridInbound = New DataTable

        pdtDataForSave = New DataTable
        ctrlDataForSave = New clsWSNasaTemplateDataLargePlus With {.prop_dtsTABLELARGEPLUS = pdtDataForSave}
        ctrlDataForSave.dtInitsTABLELARGEPLUS()

        objContainer = New PopupContainerControl
        objUserControl = New XtraUserControl With {.Dock = DockStyle.Fill}
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtMRPProduct.Dispose()
        pdtMRPSize.Dispose()

        pdtGridInbound.Dispose()

        pdtDataForSave.Dispose()
        ctrlDataForSave.Dispose()

        objContainer.Dispose()
        objUserControl.Dispose()
    End Sub

    Private Sub ucWS24FP01INBOUND_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _cm01BersihkanEntrian()

        Cursor = Cursors.WaitCursor

        _cm02InitControlTargetInbound()
        _cm03GetDataMasterMRP()

        objContainer.Controls.Add(objUserControl)

        If _prop01User._UserProp02cUserID = "141202" Then
            WindowsuiButtonPanel1.Buttons(2).Properties.Visible = True
        Else
            WindowsuiButtonPanel1.Buttons(2).Properties.Visible = False
        End If

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "custom - method"
    Private Sub _cm01BersihkanEntrian()
        _01cTargetInbound.EditValue = ""
        _02cVendorExternalMarketingCustomer.EditValue = ""
        _03cWSSKU.EditValue = ""
        'PopupContainerEdit1.EditValue = ""
        '_05cPathXLS.EditValue = ""
        _06cNoDocExisting.EditValue = ""
        '_07cNoDocEntrian.EditValue = ""
        _08cSuggestedExistingSBox.EditValue = ""
        _09cStatusInventory.SelectedIndex = -1
        _10objPKBConsumeInbound.EditValue = ""

        _lay02cVendorExternalMarketingCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay03cWSSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '_lay04PopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '_lay05cPathXLS.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay06cNoDocExisting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '_lay07cNoDocEntrian.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay08cSuggestedExistingSBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay10objPKBConsumeInbound.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        ctrlDataForSave.prop_dtsTABLELARGEPLUS.Clear()
        _gdINBOUND.__pbWSGrid01InitGrid()
        _gdINBOUND.__pbWSGrid02ClearGrid()
        _gdINBOUND.__pbWSGridVisibilityCheckSelectAll()

        _01cTargetInbound.Focus()
    End Sub

    Private Sub _cm02InitControlTargetInbound()
        Cursor = Cursors.WaitCursor

        Dim pdtTargetInbound As New DataTable
        Using objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtTargetInbound = objTargetTransaksi.__pb02GetDataTable21TargetWarehouseByUser("502")
        End Using

        If pdtTargetInbound.Rows.Count > 0 Then
            _01cTargetInbound.Properties.DataSource = Nothing
            With _01cTargetInbound
                ._prop01WSDataSource = pdtTargetInbound
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _01cTargetInbound._pb01BindingAwalDataSource2Field("Code", "Inbound")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub _cm021InitControlVendorExternalMKTCustomer(ByVal prmcTarget As String)
        Cursor = Cursors.WaitCursor

        Dim pdtTargetVendorExternalMKTCustomer As New DataTable
        Using objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

            Select Case prmcTarget
                Case "VENDOREXTERNAL"
                    pdtTargetVendorExternalMKTCustomer = objTargetTransaksi.__pb14GetDataMasterWarehouseVendorExternal()
                Case "INTERNAL"
                    pdtTargetVendorExternalMKTCustomer = objTargetTransaksi.__pb18GetDataStockMarketing()
                Case "CUSTOMER"
                    pdtTargetVendorExternalMKTCustomer = objTargetTransaksi.__pb17GetDataSOLD()
                Case "KAE"
                    pdtTargetVendorExternalMKTCustomer = objTargetTransaksi.__pb19GetDataStockKAE()
                Case "CONSIGNMENT"
                    pdtTargetVendorExternalMKTCustomer = objTargetTransaksi.__pb20GetDataStockConsignment()
            End Select
        End Using

        If pdtTargetVendorExternalMKTCustomer.Rows.Count > 0 Then
            _02cVendorExternalMarketingCustomer.Properties.DataSource = Nothing
            With _02cVendorExternalMarketingCustomer
                ._prop01WSDataSource = pdtTargetVendorExternalMKTCustomer
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _02cVendorExternalMarketingCustomer._pb01BindingAwalDataSource2Field("Code", prmcTarget)
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm022InitControlDocumentCitrix()
        Cursor = Cursors.WaitCursor

        Dim pdtNoDocCitrix As New DataTable
        Using objNoDocCitrix As clsWSNasaSelect4CtrlRepoProses = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtNoDocCitrix = objNoDocCitrix._pb05GetDataNoDOInboundCitrix()
        End Using

        If pdtNoDocCitrix.Rows.Count > 0 Then
            _06cNoDocExisting.Properties.DataSource = Nothing
            With _06cNoDocExisting
                ._prop01WSDataSource = pdtNoDocCitrix
                ._prop02WSDaftarField = New String() {"f33String", "k03String", "f01String", "f16String", "f10String", "f12String"}
                ._prop05WSFieldValueMember = "f33String"
                ._prop06WSFieldDisplayMember = "f33String"
                ._prop07WSKeyKolomFilterUntSelect = "f33String"
            End With
            _06cNoDocExisting._pb05BindingAwalDataSource6Field("f33String", "No.DO", "k03String", "SPK", "f01String", "ProductCode", "f10String", "Kadar", "f16String", "Brand", "f12String", "Item")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm023InitControlSuggestedExistingSBox(ByVal prmcProductCode As String)
        Cursor = Cursors.WaitCursor

        Dim pdtSBox As New DataTable
        Using objclsMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtSBox = objclsMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("SBOX")
        End Using

        Dim pdtProductCodeSBox As New DataTable
        Using objclsProductCodeSBox As clsWSNasaSelect4CtrlRepoProses = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtProductCodeSBox = objclsProductCodeSBox._pb06GetDataSBoxProductCode(prmcProductCode)
        End Using

        Dim plExistSBox As Boolean = False
        For Each dtRowSBox As DataRow In pdtSBox.Rows
            plExistSBox = False
            For Each dtRowProdCode As DataRow In pdtProductCodeSBox.Rows
                If dtRowSBox("k13String") = dtRowProdCode("k03String") Then
                    plExistSBox = True

                    Exit For
                End If
            Next

            If plExistSBox Then
                dtRowSBox.Delete()
            End If
        Next
        pdtSBox.AcceptChanges()

        If pdtSBox.Rows.Count > 0 Then
            Dim oDataRow As DataRow = Nothing
            For Each dtRowSBox As DataRow In pdtSBox.Rows
                oDataRow = pdtProductCodeSBox.NewRow()
                oDataRow("k02String") = "**** NEW ***"
                oDataRow("k03String") = dtRowSBox("k13String")
                oDataRow("f01String") = dtRowSBox("k14String")
                oDataRow("f01SmallInt") = 0
                oDataRow("f01Double") = 0.0
                pdtProductCodeSBox.Rows.Add(oDataRow)
            Next
        End If

        _08cSuggestedExistingSBox.Properties.DataSource = Nothing
        If pdtProductCodeSBox.Rows.Count > 0 Then
            With _08cSuggestedExistingSBox
                ._prop01WSDataSource = pdtProductCodeSBox
                ._prop02WSDaftarField = New String() {"k02String", "k03String", "f01String", "f01SmallInt", "f01Double"}
                ._prop05WSFieldValueMember = "k03String"
                ._prop06WSFieldDisplayMember = "f01String"
            End With
            _08cSuggestedExistingSBox._pb04BindingAwalDataSource5Field("k02String", "ProductCode", "k03String", "BoxCode", "f01String", "Box", "f01SmallInt", "T.Qty", "f01Double", "T.Gram")

            _lay08cSuggestedExistingSBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm024InitControlPKBConsumeInbound(ByVal prmcProductCode As String)
        Cursor = Cursors.WaitCursor

        _lay10objPKBConsumeInbound.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        Dim pdtPKBConsumeInbound As New DataTable
        pdtPKBConsumeInbound.Clear()

        Using objPKBConsumeInbound As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses() With {._prop01User = _prop01User}
            pdtPKBConsumeInbound = objPKBConsumeInbound._pb20GetDataPKBForConsumeInbound(prmcProductCode)
        End Using

        If pdtPKBConsumeInbound.Rows.Count > 0 Then
            _lay10objPKBConsumeInbound.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            _10objPKBConsumeInbound.Controls.Clear()
            objUserControl.Controls.Clear()

            _10objPKBConsumeInbound.Properties.PopupControl = Nothing

            Dim objPKBConsumeInbound As New ucWS24IX01PKBCONSUMEINBOUND With {._prop01User = _prop01User,
                                                                              ._prop02DataPKB = pdtPKBConsumeInbound,
                                                                              ._prop03Grid = _gdINBOUND}

            Dim objSize As New Size With {.Width = objPKBConsumeInbound.Size.Width,
                                          .Height = objPKBConsumeInbound.Size.Height}
            objContainer.Size = objSize
            objUserControl.Size = objSize

            objUserControl.Controls.Add(objPKBConsumeInbound)

            _10objPKBConsumeInbound.Properties.PopupControl = objContainer
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm03GetDataMasterMRP()
        Cursor = Cursors.WaitCursor
        Using objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtMRPSize = objTargetTransaksi.__pb16GetDataMasterMRPSize()
        End Using

        Using objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtMRPProduct = objTargetTransaksi.__pb15GetDataMasterMRPProduct()
        End Using

        Cursor = Cursors.Default
    End Sub

    Private Function _cm04GetNoDocument() As String
        Dim pcIDNoDoc As String = ""

        Select Case _01cTargetInbound.EditValue
            Case "5021"        '"Inhouse-Produksi"
                pcIDNoDoc = "WSNOINBOUNDPRODUKSI"
            Case "5022"        '"Inhouse-Chain"
                pcIDNoDoc = "WSNOINBOUNDCHAIN"
            Case "5023"        '"Repair-Warehouse"
                pcIDNoDoc = "WSNOINBOUNDREPWS"
            Case "5024"        '"Repair-Customer"
                pcIDNoDoc = "WSNOINBOUNDREPCUST"
            Case "5025"        '"Retur-Customer"
                pcIDNoDoc = "WSNOINBOUNDRETCUST"
            Case "5026"        '"External"
                pcIDNoDoc = "WSNOINBOUNDEXTERNAL"
            Case "5027"        '"BRJ-Pinjaman-Marketing"
                pcIDNoDoc = "WSNOINBOUNDMKT"
            Case "5028"        '"Retur-KAE"
                pcIDNoDoc = "WSNOINBOUNDRETKAE"
            Case "5029"        '"Retur-Consignment" 
                pcIDNoDoc = "WSNOINBOUNDRETCONS"
        End Select

        Cursor = Cursors.WaitCursor

        Dim pcNoDokumen As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = pcIDNoDoc}
            pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()
        End Using

        Cursor = Cursors.Default

        Return pcNoDokumen
    End Function

    Private Sub _cm05GetPatternSKUReparasiRetur(ByRef prmcPatternSKU As String, ByRef prmnNomorTerakhir As Int32,
                                                ByVal prmcKodeGroup As String, ByVal prmnJmlInc As Int32)
        Dim pdtHasil As New DataTable
        Dim pnYear As Integer = Year(Today.Date)
        Dim pnMonth As Integer = Month(Today.Date)

        Cursor = Cursors.WaitCursor

        Using objSKU As New clsWSNasaSelect4AllProsesMaster() With {._prop01User = _prop01User, ._prop02String = prmcKodeGroup}
            pdtHasil = objSKU._pb52NewSKUReparasiRetur(pnYear, pnMonth, prmnJmlInc)
        End Using

        If pdtHasil.Rows.Count > 0 Then
            For Each dtRow As DataRow In pdtHasil.Rows
                prmcPatternSKU = dtRow("k13String")
                prmnNomorTerakhir = dtRow("f10Int")
            Next
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm06ProsesSaveInbound()
        Dim pdtDataForSave As New DataTable
        Dim pcSaveStoredProcedure As String = ""
        Dim pcTitle As String = ""

        Dim pnTotDataForSave As Integer = 0
        Dim pnTotDataForDisplay As Integer = 0

        Select Case _01cTargetInbound.EditValue
            Case "5021"        '"Inhouse-Produksi" 
                pdtDataForSave = _cm5021_02GetDataToSaveInhouseProduksi()
                pnTotDataForSave = pdtDataForSave.Rows.Count
                pnTotDataForDisplay = pdtGridInbound.Rows.Count
                pcSaveStoredProcedure = "spWSInbound5021InhouseProduksi"
                pcTitle = " : CITRIX ... "

            Case "5022"        '"Inhouse-Chain"
                '***** Proses Simpan pada :> ucWS24F101INBOUNDENTRYCONTAINER

            Case "5023"        '"Repair-Warehouse"
                '***** Proses Simpan pada :> ucWS24F101INBOUNDENTRYCONTAINER
                'pdtDataForSave = _cm5023_02GetDataToSaveReparasiWS()
                'pcSaveStoredProcedure = "spWSInbound5023ReparasiWS"
                'pcTitle = " : HASIL-REPARASI-WH ... "

            Case "5024"        '"Repair-Customer"
                '*** under development ***

            Case "5025"        '"Retur-Customer"
                pdtDataForSave = _cm5025_02GetDataToSaveReturCustomer()
                pcSaveStoredProcedure = "spWSInbound5025ReturCustomer"
                pcTitle = " : RETUR-CUSTOMER ... "

            Case "5026"        '"External"
                '***** Proses Simpan pada :> ucWS24F101INBOUNDENTRYCONTAINER

            Case "5027"        '"BRJ-Pinjaman-Internal"
                pdtDataForSave = _cm5027_02GetDataToSaveBRJPinjamanMarketing()
                pcSaveStoredProcedure = "spWSInbound5027BRJPinjamanMKT"
                pcTitle = " : RETUR-PINJAMAN-INTERNAL ... "

            Case "5028"
                pdtDataForSave = _cm5028_02GetDataToSaveReturKAE()
                pcSaveStoredProcedure = "spWSInbound5028ReturKAE"
                pcTitle = " : RETUR-KAE ... "

            Case "5029"
                pdtDataForSave = _cm5029_02GetDataToSaveReturCONSIGNMENT()
                pcSaveStoredProcedure = "spWSInbound5029ReturCONSIGNMENT"
                pcTitle = " : RETUR-CONSIGNMENT ... "

        End Select

        ' If pnTotDataForDisplay = pnTotDataForSave Then
        If pdtDataForSave.Rows.Count > 0 Then
                If _09cStatusInventory.SelectedIndex >= 0 Then
                    'Update StatusInventory ("ForSale","NotForSale")
                    Dim pcStatusInventory As String = ""
                    Select Case _09cStatusInventory.SelectedIndex
                        Case 0
                            pcStatusInventory = "FORSALE"
                        Case 1
                            pcStatusInventory = "NOTFORSALE"
                    End Select

                    For Each dtRow As DataRow In pdtDataForSave.Rows
                        dtRow("f43String") = pcStatusInventory
                    Next
                    pdtDataForSave.AcceptChanges()

                    Cursor = Cursors.WaitCursor

                    Dim objNasa As New clsWSNasaHelper
                    Dim pnJmlRec As Integer = 0
                    pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                        _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                        2, pcSaveStoredProcedure, "@tpDataForSaving", pdtDataForSave)

                    Cursor = Cursors.Default

                    MsgBox("Proses Simpan Data INBOUND" & pcTitle & " BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

                    Select Case _01cTargetInbound.EditValue
                        Case "5028"
                            _cm5028_01DisplayGridReturKAE()
                        Case "5029"
                            _cm5029_01DisplayGridReturConsignment()
                        Case Else
                            _cm01BersihkanEntrian()
                    End Select

                Else
                    MsgBox("Maaf ... STATUS INVENTORY tidak boleh KOSONG.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
                End If
            Else
                MsgBox("Maaf ... TIDAK ADA data INBOUND" & pcTitle & "yg akan disimpan.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        'Else
        '    MsgBox("Maaf ... Data INBOUND" & pcTitle & " BELUM SEMUA diproses.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        'End If
    End Sub

    Private Sub _cm07SaveAllInbound()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk menyimpan data ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm06ProsesSaveInbound()
        Else
            MsgBox("Maaf ... Proses Simpan Data INBOUND ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    Private Function _cm08ConvertPersenKadarToInteger(ByVal prmcPersenKadar As String) As Integer
        Dim pcHasil As Integer = 0

        Dim pcTemp As String = prmcPersenKadar.Substring(0, prmcPersenKadar.Length - 1).Trim()    '75.50%
        Select Case pcTemp.Length
            Case 2      '75
                pcTemp = pcTemp + "0"

            Case 3      '75.
                pcTemp = prmcPersenKadar.Substring(0, 2) + "0"

            Case 4      '75.5
                pcTemp = prmcPersenKadar.Substring(0, 2) + prmcPersenKadar.Substring(3, 1)

            Case 5      '75.50
                pcTemp = prmcPersenKadar.Substring(0, 2) + prmcPersenKadar.Substring(3, 1)

        End Select

        pcHasil = CInt(pcTemp)

        Return pcHasil
    End Function

    'ucWS24F101INBOUNDENTRYCONTAINER

    Private Sub _cm09CreateContentChainVendorExternal(Optional ByVal prmcKodeVendor As String = "VND02",
                                                      Optional ByVal prmcNamaVendor As String = "INHOUSE-CHAIN")
        '********************************
        '******* VENDOR : TABLE50 *******
        '********************************
        'VND02	INHOUSE-CHAIN

        Cursor = Cursors.WaitCursor
        Dim objInboundChainVendorExternal As New ucWS24F101INBOUNDENTRYCONTAINER With {._prop01User = _prop01User,
                                                                                       ._prop011TargetEntryContainer = ucWS24F101INBOUNDENTRYCONTAINER._nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN,
                                                                                       ._prop02cKodeVendor = prmcKodeVendor,
                                                                                       ._prop021cNamaVendor = prmcNamaVendor,
                                                                                       ._prop03cNoDO = "",
                                                                                       ._prop04DataMRPProduct = pdtMRPProduct,
                                                                                       ._prop05DataMRPSize = pdtMRPSize}

        Dim objSize As New Size With {.Width = objInboundChainVendorExternal.Size.Width,
                                      .Height = objInboundChainVendorExternal.Size.Height + 50}

        Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                           .MinimizeBox = False, .ShowIcon = False,
                                           .StartPosition = FormStartPosition.CenterScreen,
                                           .Text = _prop01User._UserProp01cTitle,
                                           .Dock = DockStyle.Fill}
        frmModal.AddControl(objInboundChainVendorExternal)

        Cursor = Cursors.Default

        frmModal.ShowDialog()
    End Sub

    Private Sub _cm091CreateContentRepairWarehouse(Optional ByVal prmcKodeVendor As String = "VND03",
                                                   Optional ByVal prmcNamaVendor As String = "REPAIR")
        '********************************
        '******* VENDOR : TABLE50 *******
        '********************************
        'VND03  REPAIR

        Dim plYes As MsgBoxResult = MsgBox("Apakah ini Inbound Repair Warehouse melalui 'BULK UPLOAD - XLSX' ... ?", vbYesNoCancel + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then

            Cursor = Cursors.WaitCursor
            Dim objBulkUploadXLS As New ucWS24LD01BULKUPLOADXLS With {._prop01User = _prop01User,
                                                                      ._prop02TargetBULKUPLOADXLS = ucWS24LD01BULKUPLOADXLS._pbEnumTargetBULKUPLOADXLS._INBOUNDRepairWarehouse}

            Dim objSize As New Size With {.Width = objBulkUploadXLS.Size.Width,
                                          .Height = objBulkUploadXLS.Size.Height + 50}

            Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                               .MinimizeBox = False, .ShowIcon = False,
                                               .StartPosition = FormStartPosition.CenterScreen,
                                               .Text = "Bulk Upload Inbound Repair | " & _prop01User._UserProp01cTitle,
                                               .Dock = DockStyle.Fill}
            frmModal.AddControl(objBulkUploadXLS)

            Cursor = Cursors.Default

            frmModal.ShowDialog()
        ElseIf plYes = MsgBoxResult.No Then

            Cursor = Cursors.WaitCursor
            Dim objInboundRepairWarehouse As New ucWS24F101INBOUNDENTRYCONTAINER With {._prop01User = _prop01User,
                                                                                       ._prop011TargetEntryContainer = ucWS24F101INBOUNDENTRYCONTAINER._nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE,
                                                                                       ._prop02cKodeVendor = prmcKodeVendor,
                                                                                       ._prop021cNamaVendor = prmcNamaVendor,
                                                                                       ._prop03cNoDO = _cm04GetNoDocument(),
                                                                                       ._prop04DataMRPProduct = pdtMRPProduct,
                                                                                       ._prop05DataMRPSize = pdtMRPSize}

            Dim objSize As New Size With {.Width = objInboundRepairWarehouse.Size.Width,
                                          .Height = objInboundRepairWarehouse.Size.Height + 50}

            Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                               .MinimizeBox = False, .ShowIcon = False,
                                               .StartPosition = FormStartPosition.CenterScreen,
                                               .Text = _prop01User._UserProp01cTitle,
                                               .Dock = DockStyle.Fill}
            frmModal.AddControl(objInboundRepairWarehouse)

            Cursor = Cursors.Default

            frmModal.ShowDialog()
        Else
            _cm01BersihkanEntrian()
        End If

    End Sub

    Private Function _cm10ValidasiDataProductCode(ByVal prmcProductCode As String,
                                                  ByVal prmcKadarCode As String, ByVal prmcBrandCode As String) As Boolean
        Cursor = Cursors.WaitCursor
        Dim plHasil As Boolean = True

        Dim pdtProductCode As New DataTable
        Using objProductCode As clsWSNasaSelect4CtrlRepoProses = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtProductCode = objProductCode._pb08GetDataProductCodeForValidasiData(prmcProductCode)
        End Using

        If pdtProductCode.Rows.Count > 0 Then
            For Each dtRow As DataRow In pdtProductCode.Rows
                If dtRow("f09String") = prmcKadarCode And dtRow("f15String") = prmcBrandCode Then
                    plHasil = True
                Else
                    plHasil = False
                    Exit For
                End If
            Next
        End If

        Cursor = Cursors.Default

        Return plHasil
    End Function

    'Private Sub _cm09CreateContentChainVendorExternal(ByVal prmcKodeVendor As String, ByVal prmcNamaVendor As String)
    '    Cursor = Cursors.WaitCursor

    '    PopupContainerEdit1.Controls.Clear()
    '    objUserControl.Controls.Clear()

    '    PopupContainerEdit1.Properties.PopupControl = Nothing

    '    Dim objInboundChainVendorExternal As New ucWS24F101INBOUNDENTRYCONTAINER With {._prop01User = _prop01User,
    '                                                    ._prop02cKodeVendor = prmcKodeVendor,
    '                                                    ._prop021cNamaVendor = prmcNamaVendor,
    '                                                    ._prop03cNoDO = _07cNoDocEntrian.EditValue,
    '                                                    ._prop04DataMRPProduct = pdtMRPProduct,
    '                                                    ._prop05DataMRPSize = pdtMRPSize}

    '    Dim objSize As New Size With {.Width = objInboundChainVendorExternal.Size.Width,
    '                                  .Height = objInboundChainVendorExternal.Size.Height}
    '    objContainer.Size = objSize
    '    objUserControl.Size = objSize

    '    objUserControl.Controls.Add(objInboundChainVendorExternal)

    '    PopupContainerEdit1.Properties.PopupControl = objContainer

    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub _cm10DisplayContentChainVendorExternal()
    '    If Not (String.IsNullOrEmpty(_02cVendorExternalMarketingCustomer.EditValue) And
    '            String.IsNullOrEmpty(_07cNoDocEntrian.EditValue)) Then

    '        Select Case _01cTargetInbound.EditValue
    '            Case "5022"        '"Inhouse-Chain"
    '                _cm09CreateContentChainVendorExternal("VND02", "INHOUSE-CHAIN")

    '            Case "5026"        '"Vendor-External"
    '                _cm09CreateContentChainVendorExternal(_02cVendorExternalMarketingCustomer.EditValue, _02cVendorExternalMarketingCustomer.Text)
    '        End Select

    '        _lay04PopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '        PopupContainerEdit1.Focus()
    '    End If

    'End Sub

    Private Sub _cm11SettingWidthGrid()
        With _gdINBOUND
            Select Case _01cTargetInbound.EditValue
                Case "5021"        '"Inhouse-Produksi"
                    .__pbWSGrid04CreateSettingColumnWidth("InboundInhouseProduksi")
                Case "5022"        '"Inhouse-Chain"
                    .__pbWSGrid04CreateSettingColumnWidth("InboundInhouseChain")
                Case "5023"        '"Repair-Warehouse"
                    .__pbWSGrid04CreateSettingColumnWidth("InboundRepairWarehouse")
                Case "5024"        '"Repair-Customer"
                    .__pbWSGrid04CreateSettingColumnWidth("InboundRepairCustomer")
                Case "5025"        '"Retur-Customer"
                    .__pbWSGrid04CreateSettingColumnWidth("InboundReturCustomer")
                Case "5026"        '"Vendor-External"
                    .__pbWSGrid04CreateSettingColumnWidth("InboundVendorExternal")
                Case "5027"        '"BRJ-Pinjaman-Marketing"
                    .__pbWSGrid04CreateSettingColumnWidth("InboundBRJPinjamanMarketing")
            End Select
        End With

        MsgBox("SettingWidthGrid ... done ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    End Sub

    Private Sub _cm12ReturCustomer5025()
        Dim plYes As MsgBoxResult = MsgBox("Apakah ini proses Retur Customer melalui 'BULK UPLOAD - XLSX' ... ?", vbYesNoCancel + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            '********************************
            '******* VENDOR : TABLE50 *******
            '********************************
            'VND04  RETUR

            Cursor = Cursors.WaitCursor
            Dim objBulkUploadXLS As New ucWS24LD01BULKUPLOADXLS With {._prop01User = _prop01User,
                                                                      ._prop02TargetBULKUPLOADXLS = ucWS24LD01BULKUPLOADXLS._pbEnumTargetBULKUPLOADXLS._INBOUNDReturCustomer}

            Dim objSize As New Size With {.Width = objBulkUploadXLS.Size.Width,
                                          .Height = objBulkUploadXLS.Size.Height + 50}

            Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                               .MinimizeBox = False, .ShowIcon = False,
                                               .StartPosition = FormStartPosition.CenterScreen,
                                               .Text = "Bulk Upload Inbound Retur Customer | " & _prop01User._UserProp01cTitle,
                                               .Dock = DockStyle.Fill}
            frmModal.AddControl(objBulkUploadXLS)

            Cursor = Cursors.Default

            frmModal.ShowDialog()
        ElseIf plYes = MsgBoxResult.No Then
            _lay02cVendorExternalMarketingCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            _lay02cVendorExternalMarketingCustomer.Text = "Customer"
            _cm021InitControlVendorExternalMKTCustomer("CUSTOMER")
        Else
            _cm01BersihkanEntrian()
        End If
    End Sub

#End Region

#Region "5021 : Inhouse Produksi"

    Private Sub _cm5021_01DisplayGridInhouseProduksi()
        Cursor = Cursors.WaitCursor
        _cm022InitControlDocumentCitrix()
        pdtGridInbound.Clear()

        Using objInhouseProduksi As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses() With {._prop01User = _prop01User}
            pdtGridInbound = objInhouseProduksi._pb19GetDataNoDocInboundCitrix(_06cNoDocExisting.EditValue)
        End Using

        With _gdINBOUND
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5021InhouseProduksi
            ._prop03pdtDataSourceGrid = pdtGridInbound
        End With
        _gdINBOUND.__pbWSGrid01InitGrid()
        _gdINBOUND.__pbWSGrid03DisplayGrid()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm5021_02GetDataToSaveInhouseProduksi() As DataTable
        Dim pcNoDoc As String = _cm04GetNoDocument()

        ctrlDataForSave.prop_dtsTABLELARGEPLUS.Clear()
        For Each dtRow As DataRow In pdtGridInbound.Rows
            If CBool(dtRow("k00Boolean")) Then
                ' ===================== UPDATED BY AKIRRA - 25/06/09 =====================
                ' set SINGLE/BUNDLE (BUNDLE SKU-B)
                Dim pcSinBun As String = ""
                If dtRow("f01SmallInt") = 1 Then
                    pcSinBun = "SINGLE"
                ElseIf dtRow("f01SmallInt") > 1 Then
                    pcSinBun = "BUNDLE"
                End If
                ' ========================================================================

                ctrlDataForSave.dtAddNewsTABLELARGEPLUS(pcNoDoc, _06cNoDocExisting.EditValue, "",
                    dtRow("k02String"), dtRow("f36String"), dtRow("f37String"), pcSinBun, "", "", "", "", "", "", 'f05String = NO.ORDER
                    "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "",
                    0, 0, 0, 0, 0, 0, 0,
                    0.0, 0.0, 0.0, 0.0, 0.0,
                    dtRow("f01Date"), "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            End If
        Next

        Return ctrlDataForSave.prop_dtsTABLELARGEPLUS
    End Function

#End Region

#Region "5022 : Inhouse-Chain"

#End Region

#Region "5023 : Repair Warehouse"
    Private Sub _cm5023_01DisplayGridReparasiWS()
        Cursor = Cursors.WaitCursor

        pdtGridInbound.Clear()

        Using objRepairWS As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses() With {._prop01User = _prop01User}
            pdtGridInbound = objRepairWS._pb16GetDataStockRepairWS()
        End Using

        With _gdINBOUND
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5023RepairWarehouse
            ._prop03pdtDataSourceGrid = pdtGridInbound
        End With
        _gdINBOUND.__pbWSGrid01InitGrid()
        _gdINBOUND.__pbWSGrid03DisplayGrid()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm5023_02GetDataToSaveReparasiWS() As DataTable
        Dim pcNoDoc As String = _cm04GetNoDocument()
        Dim pcSINGLE As String = ""

        Dim pnJmlRecReparasi As Integer = 0

        ctrlDataForSave.prop_dtsTABLELARGEPLUS.Clear()
        For Each dtRow As DataRow In pdtGridInbound.Rows
            If dtRow("f02Double") > 0 Then
                pcSINGLE = ""
                If dtRow("f01Int") = 1 Then
                    pcSINGLE = "SINGLE"
                Else
                    If dtRow("f01Int") > 1 Then
                        pcSINGLE = "BUNDLE"
                    End If
                End If

                pnJmlRecReparasi = pnJmlRecReparasi + 1
                ctrlDataForSave.dtAddNewsTABLELARGEPLUS("", "", "",
                    dtRow("f01String"), "", "VND03", "REPAIR", dtRow("f05String"),
                    dtRow("f26String"), dtRow("f31String"), dtRow("f34String"), dtRow("f29String"), dtRow("f10String"),
                    dtRow("f11String"), dtRow("f12String"), dtRow("f32String"), dtRow("f35String"), dtRow("f30String"),
                    dtRow("f33String"), "", "", dtRow("f08String"), dtRow("f09String"),
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "50303", "REPARASI WAREHOUSE", dtRow("f02String"), pcNoDoc, pcSINGLE,
                    dtRow("k03String"), dtRow("k02String"), "", "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "",
                    dtRow("f01TinyInt"), dtRow("f01Int"), dtRow("f01SmallInt"), 0, 0, 0, 0,
                    dtRow("f02Double"), dtRow("f03Double"), dtRow("f01Double"), 0.0, 0.0,
                    dtRow("f01Date"), dtRow("f03Date"), Today.Date, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            End If
        Next

        Dim prmcPatternSKU As String = ""
        Dim prmnNomorTerakhir As Integer = 0

        _cm05GetPatternSKUReparasiRetur(prmcPatternSKU, prmnNomorTerakhir, "WSNEWSKUREPARASIWS", pnJmlRecReparasi)
        Dim pnNoAwal As Integer = (prmnNomorTerakhir - pnJmlRecReparasi)

        For Each dtRow As DataRow In ctrlDataForSave.prop_dtsTABLELARGEPLUS.Rows
            pnNoAwal = pnNoAwal + 1   ' sb di awali dgn NOL, maka perlu INC di depan.

            dtRow("k02String") = prmcPatternSKU + pnNoAwal.ToString("0000")
        Next
        ctrlDataForSave.prop_dtsTABLELARGEPLUS.AcceptChanges()

        Return ctrlDataForSave.prop_dtsTABLELARGEPLUS
    End Function

#End Region

#Region "5025 : Retur Customer"

    Private Sub _cm5025_01DisplayGridReturCustomer()
        Cursor = Cursors.WaitCursor

        pdtGridInbound.Clear()

        Using objReturCustomer As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses() With {._prop01User = _prop01User}
            pdtGridInbound = objReturCustomer._pb17GetDataStockSOLD(_02cVendorExternalMarketingCustomer.EditValue)
        End Using

        With _gdINBOUND
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5025ReturCustomer
            ._prop03pdtDataSourceGrid = pdtGridInbound
        End With
        _gdINBOUND.__pbWSGrid01InitGrid()
        _gdINBOUND.__pbWSGrid03DisplayGrid()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm5025_02GetDataToSaveReturCustomer() As DataTable
        Dim pcNoDoc As String = _cm04GetNoDocument()
        Dim vsNoDocRepair As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User, ._prop02String = "WSREPAIRWAREHOUSE"}
            vsNoDocRepair = objNoDoc._pb51GetDataIncNoDocWarehouse()
        End Using

        Dim pcSINGLE As String = ""
        Dim pnJmlRecReturCust As Integer = 0
        Dim vsNoDocRepairVal As String = ""

        ctrlDataForSave.prop_dtsTABLELARGEPLUS.Clear()
        For Each dtRow As DataRow In pdtGridInbound.Rows
            If dtRow("f33String") <> "" Then
                pcSINGLE = ""
                If dtRow("f01Int") = 1 Then
                    pcSINGLE = "SINGLE"
                Else
                    If dtRow("f01Int") > 1 Then
                        pcSINGLE = "BUNDLE"
                    End If
                End If

                vsNoDocRepairVal = ""
                If dtRow("f33String") = "REPAIR" Then
                    vsNoDocRepairVal = vsNoDocRepair
                End If

                pnJmlRecReturCust = pnJmlRecReturCust + 1
                ctrlDataForSave.dtAddNewsTABLELARGEPLUS("", "", "",
                    dtRow("f01String"), "", "VND04", "RETUR", dtRow("f05String"),
                    dtRow("f26String"), dtRow("f27String"), dtRow("f28String"), dtRow("f29String"), dtRow("f10String"),
                    dtRow("f11String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"),
                    dtRow("f16String"), "", "", dtRow("f08String"), dtRow("f09String"),
                    _02cVendorExternalMarketingCustomer.EditValue, _02cVendorExternalMarketingCustomer.Text, dtRow("f34String"), "", "",
                    "", "", "", "", "",
                    dtRow("f17String"), dtRow("f18String"), dtRow("f02String"), pcNoDoc, pcSINGLE,
                    dtRow("k03String"), dtRow("k02String"), dtRow("f33String"), "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    dtRow("f51String"), "", "", "", vsNoDocRepairVal,     ' f51String = SKU Master (pertama kali sblm diubah-ubah)
                    dtRow("f01TinyInt"), dtRow("f01Int"), dtRow("f01SmallInt"), 0, 0, 0, 0,
                    dtRow("f02Double"), dtRow("f03Double"), dtRow("f01Double"), 0.0, 0.0,
                    dtRow("f01Date"), dtRow("f03Date"), Today.Date, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            End If
        Next

        Dim prmcPatternSKU As String = ""
        Dim prmnNomorTerakhir As Integer = 0

        _cm05GetPatternSKUReparasiRetur(prmcPatternSKU, prmnNomorTerakhir, "WSNEWSKURETURCUSTOMER", pnJmlRecReturCust)
        Dim pnNoAwal As Integer = (prmnNomorTerakhir - pnJmlRecReturCust)

        For Each dtRow As DataRow In ctrlDataForSave.prop_dtsTABLELARGEPLUS.Rows
            pnNoAwal = pnNoAwal + 1   ' sb di awali dgn NOL, maka perlu INC di depan.

            dtRow("k02String") = prmcPatternSKU + pnNoAwal.ToString("0000")
        Next
        ctrlDataForSave.prop_dtsTABLELARGEPLUS.AcceptChanges()

        Return ctrlDataForSave.prop_dtsTABLELARGEPLUS
    End Function

#End Region

#Region "5026 : External"

#End Region

#Region "5027 : BRJ Pinjaman Marketing"
    Private Sub _cm5027_01DisplayGridBRJPinjamanMarketing()
        Cursor = Cursors.WaitCursor

        pdtGridInbound.Clear()

        Using objBRJPinjamanMarketing As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses() With {._prop01User = _prop01User}
            pdtGridInbound = objBRJPinjamanMarketing._pb18GetDataStockMARKETING(_02cVendorExternalMarketingCustomer.EditValue)
        End Using

        With _gdINBOUND
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5027BRJPinjamanMarketing
            ._prop03pdtDataSourceGrid = pdtGridInbound
        End With
        _gdINBOUND.__pbWSGrid01InitGrid()
        _gdINBOUND.__pbWSGrid03DisplayGrid()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm5027_02GetDataToSaveBRJPinjamanMarketing() As DataTable
        Dim pcNoDoc As String = _cm04GetNoDocument()
        Dim pcSINGLE As String = ""

        ctrlDataForSave.prop_dtsTABLELARGEPLUS.Clear()
        For Each dtRow As DataRow In pdtGridInbound.Rows
            If CBool(dtRow("k00Boolean")) Then
                pcSINGLE = ""
                If dtRow("f01SmallInt") = 1 Then
                    pcSINGLE = "SINGLE"
                Else
                    If dtRow("f01SmallInt") > 1 Then
                        pcSINGLE = "BUNDLE"
                    End If
                End If

                ctrlDataForSave.dtAddNewsTABLELARGEPLUS("", dtRow("k03String"), "",
                    dtRow("f01String"), "", "VND99", "MARKETING", dtRow("f05String"),
                    dtRow("f26String"), dtRow("f27String"), dtRow("f28String"), dtRow("f29String"), dtRow("f10String"),
                    dtRow("f11String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"),
                    dtRow("f16String"), "", "", dtRow("f08String"), dtRow("f09String"),
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", dtRow("f19String"), dtRow("f02String"), pcNoDoc, pcSINGLE,
                    dtRow("k02String"), "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    "", "", "", "", "",
                    dtRow("f01TinyInt"), dtRow("f01SmallInt"), 0, 0, 0, 0, 0,
                    dtRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
                    dtRow("f01Date"), dtRow("f03Date"), Today.Date, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            End If

        Next

        Return ctrlDataForSave.prop_dtsTABLELARGEPLUS
    End Function

#End Region

#Region "*** 5028 : RETUR-KAE"

    Private Sub _cm5028_01DisplayGridReturKAE()
        Cursor = Cursors.WaitCursor

        pdtGridInbound.Clear()

        Using objBRJPinjamanMarketing As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses() With {._prop01User = _prop01User}
            pdtGridInbound = objBRJPinjamanMarketing._pb21GetDataStockKAE(_02cVendorExternalMarketingCustomer.EditValue)
        End Using

        With _gdINBOUND
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5028ReturKAE
            ._prop03pdtDataSourceGrid = pdtGridInbound
        End With
        _gdINBOUND.__pbWSGrid01InitGrid()
        _gdINBOUND.__pbWSGrid03DisplayGrid()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm5028_02GetDataToSaveReturKAE() As DataTable
        Dim pcNoDoc As String = _cm04GetNoDocument()
        Dim pcSINGLE As String = ""

        ctrlDataForSave.prop_dtsTABLELARGEPLUS.Clear()
        For Each dtRow As DataRow In pdtGridInbound.Rows
            If CBool(dtRow("k00Boolean")) Then
                pcSINGLE = ""
                If dtRow("f01SmallInt") = 1 Then
                    pcSINGLE = "SINGLE"
                Else
                    If dtRow("f01SmallInt") > 1 Then
                        pcSINGLE = "BUNDLE"
                    End If
                End If

                ctrlDataForSave.dtAddNewsTABLELARGEPLUS(dtRow("f02String"), dtRow("f01String"), dtRow("k03String"),
                    dtRow("f11String"), dtRow("f12String"), dtRow("f15String"), dtRow("f16String"), dtRow("f29String"),
                    dtRow("f10String"), dtRow("f27String"), dtRow("f28String"), dtRow("f13String"), dtRow("f14String"),
                    dtRow("f08String"), dtRow("f09String"), dtRow("f06String"), dtRow("f07String"), dtRow("k01String"),
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", pcNoDoc, pcSINGLE, "", "", "", "", "",
                    "", "", "", "", "",
                    dtRow("f01TinyInt"), dtRow("f01SmallInt"), 0, 0, 0, 0, 0,
                    dtRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
                    dtRow("f01Date"), Today.Date, Today.Date, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            End If

        Next

        Return ctrlDataForSave.prop_dtsTABLELARGEPLUS
    End Function

#End Region

#Region "*** 5029 : RETUR-CONSIGNMENT"

    Private Sub _cm5029_01DisplayGridReturConsignment()
        Cursor = Cursors.WaitCursor

        pdtGridInbound.Clear()

        Using objBRJPinjamanMarketing As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses() With {._prop01User = _prop01User}
            pdtGridInbound = objBRJPinjamanMarketing._pb22GetDataStockCONSIGNMENT(_02cVendorExternalMarketingCustomer.EditValue)
        End Using

        With _gdINBOUND
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5029ReturConsignment
            ._prop03pdtDataSourceGrid = pdtGridInbound
        End With
        _gdINBOUND.__pbWSGrid01InitGrid()
        _gdINBOUND.__pbWSGrid03DisplayGrid()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm5029_02GetDataToSaveReturCONSIGNMENT() As DataTable
        Dim pcNoDoc As String = _cm04GetNoDocument()
        Dim pcSINGLE As String = ""

        ctrlDataForSave.prop_dtsTABLELARGEPLUS.Clear()

        For Each dtRow As DataRow In pdtGridInbound.Rows
            If CBool(dtRow("k00Boolean")) Then
                pcSINGLE = ""
                If dtRow("f01SmallInt") = 1 Then
                    pcSINGLE = "SINGLE"
                Else
                    If dtRow("f01SmallInt") > 1 Then
                        pcSINGLE = "BUNDLE"
                    End If
                End If

                ctrlDataForSave.dtAddNewsTABLELARGEPLUS(dtRow("f02String"), dtRow("f01String"), dtRow("k03String"),
                    dtRow("f11String"), dtRow("f12String"), dtRow("f15String"), dtRow("f16String"), dtRow("f29String"),
                    dtRow("f10String"), dtRow("f27String"), dtRow("f28String"), dtRow("f13String"), dtRow("f14String"),
                    dtRow("f08String"), dtRow("f09String"), dtRow("f06String"), dtRow("f07String"), dtRow("k01String"),
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", "", "",
                    "", "", "", pcNoDoc, pcSINGLE, "", "", "", "", "",
                    "", "", "", "", "",
                    dtRow("f01TinyInt"), dtRow("f01SmallInt"), 0, 0, 0, 0, 0,
                    dtRow("f01Double"), 0.0, 0.0, 0.0, 0.0,
                    dtRow("f01Date"), Today.Date, Today.Date, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            End If

        Next

        Return ctrlDataForSave.prop_dtsTABLELARGEPLUS
    End Function

#End Region


#Region "control - event"

    Private Sub _01cTargetInbound_EditValueChanged(sender As Object, e As EventArgs) Handles _01cTargetInbound.EditValueChanged
        If Not String.IsNullOrEmpty(_01cTargetInbound.EditValue) Then
            _02cVendorExternalMarketingCustomer.EditValue = ""
            _03cWSSKU.EditValue = ""
            'PopupContainerEdit1.EditValue = ""
            '_05cPathXLS.EditValue = ""
            _06cNoDocExisting.EditValue = ""
            '_07cNoDocEntrian.EditValue = ""
            _08cSuggestedExistingSBox.EditValue = ""
            _09cStatusInventory.SelectedIndex = -1

            _lay02cVendorExternalMarketingCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _lay03cWSSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            '_lay04PopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            '_lay05cPathXLS.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _lay06cNoDocExisting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            '_lay07cNoDocEntrian.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            _lay08cSuggestedExistingSBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            ' ===================== UPDATED BY AKIRRA - 16/04/25 =====================
            ' agar ketika merubah target, maka grid akan terefresh ulang (sekaligus dengan header dan row numbernya).
            _gdINBOUND.__pbWSGrid01InitGrid()
            _gdINBOUND.__pbWSGrid02ClearGrid()
            ' ======================================================================

            Select Case _01cTargetInbound.EditValue
                Case "5021"        '"Inhouse-Produksi"
                    _lay03cWSSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay06cNoDocExisting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay06cNoDocExisting.Text = "No.DO Produksi"
                    _cm022InitControlDocumentCitrix()

                Case "5022"        '"Inhouse-Chain"
                    _cm09CreateContentChainVendorExternal()
                    '_lay07cNoDocEntrian.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    '_lay07cNoDocEntrian.Text = "No.DO Chain"

                Case "5023"        '"Repair-Warehouse"
                    '_cm5023_01DisplayGridReparasiWS()
                    _cm091CreateContentRepairWarehouse()

                Case "5024"        '"Repair-Customer"
                    'MsgBox("Maaf ... blueprint 'Repair-Customer' masih dalam pembuatan ...")
                    MsgBox("SUBMENU IS STILL UNDER DEVELOPMENT..", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
                    _cm01BersihkanEntrian()

                Case "5025"        '"Retur-Customer"
                    _cm12ReturCustomer5025()

                Case "5026"        '"Vendor-External"
                    _lay02cVendorExternalMarketingCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay02cVendorExternalMarketingCustomer.Text = "Vendor External"
                    '_lay07cNoDocEntrian.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    '_lay07cNoDocEntrian.Text = "No.DO-External"
                    _cm021InitControlVendorExternalMKTCustomer("VENDOREXTERNAL")

                Case "5027"        '"BRJ-Pinjaman-Marketing"
                    _lay02cVendorExternalMarketingCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay02cVendorExternalMarketingCustomer.Text = "Internal"
                    _cm021InitControlVendorExternalMKTCustomer("INTERNAL")

                Case "5028"        '"RETUR-KAE"
                    _lay02cVendorExternalMarketingCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay02cVendorExternalMarketingCustomer.Text = "KAE"
                    _cm021InitControlVendorExternalMKTCustomer("KAE")

                Case "5029"        '"RETUR-CONSIGNMENT"
                    _lay02cVendorExternalMarketingCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    _lay02cVendorExternalMarketingCustomer.Text = "Customer / Store"
                    _cm021InitControlVendorExternalMKTCustomer("CONSIGNMENT")

            End Select

            _gdINBOUND.__pbWSGridVisibilityCheckSelectAll()
        End If
    End Sub

    Private Sub _02cVendorExternalMarketingCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles _02cVendorExternalMarketingCustomer.EditValueChanged
        If Not String.IsNullOrEmpty(_02cVendorExternalMarketingCustomer.EditValue) Then

            Select Case _01cTargetInbound.EditValue
                Case "5024"        '"Repair-Customer"
                Case "5025"        '"Retur-Customer"
                    _cm5025_01DisplayGridReturCustomer()

                Case "5026"        '"External"
                    _cm09CreateContentChainVendorExternal(_02cVendorExternalMarketingCustomer.EditValue,
                                                          _02cVendorExternalMarketingCustomer.Text)

                Case "5027"        '"BRJ-Pinjaman-Marketing"
                    _cm5027_01DisplayGridBRJPinjamanMarketing()

                Case "5028"        '"RETUR-KAE"
                    _cm5028_01DisplayGridReturKAE()
                    _cm023InitControlSuggestedExistingSBox("")
                    _lay08cSuggestedExistingSBox.Text = "Box"

                Case "5029"        '"RETUR-CONSIGNMENT"
                    _cm5029_01DisplayGridReturConsignment()
                    _cm023InitControlSuggestedExistingSBox("")
                    _lay08cSuggestedExistingSBox.Text = "Box"
            End Select
        End If
    End Sub

    Private Sub _03cWSSKU_KeyDown(sender As Object, e As KeyEventArgs) Handles _03cWSSKU.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(_03cWSSKU.EditValue) Then
                Dim pcFieldWSSKU As String = "k03String"
                Select Case _01cTargetInbound.EditValue
                    Case "5021"        '"Inhouse-Produksi"
                        pcFieldWSSKU = "k02String"

                    Case "5022"        '"Inhouse-Chain"

                    Case "5023"        '"Repair-Warehouse"

                    Case "5024"        '"Repair-Customer"


                    Case "5025"        '"Retur-Customer"

                    Case "5026"        '"Vendor-External"

                    Case "5027"        '"BRJ-Pinjaman-Marketing"

                End Select


                Dim vsSku As String = If(_03cWSSKU.EditValue IsNot Nothing, _03cWSSKU.EditValue.ToString().ToUpper(), String.Empty)
                Dim _dlgCheckboxSKU As __dlgSetTrueCheckbox = AddressOf _gdINBOUND._ivkSetTrueCheckbox
                _dlgCheckboxSKU.Invoke(pcFieldWSSKU, vsSku)


                _03cWSSKU.SelectAll()
                SendKeys.Send("{DELETE}")
            End If
        End If
    End Sub

    Private Sub _06cNoDocument_EditValueChanged(sender As Object, e As EventArgs) Handles _06cNoDocExisting.EditValueChanged
        If Not String.IsNullOrEmpty(_06cNoDocExisting.EditValue) Then
            _cm5021_01DisplayGridInhouseProduksi()

            Dim pcFieldProductCode As DataRow()
            pcFieldProductCode = _06cNoDocExisting._pb05GetRecordTerpilih()

            Dim pcProductCode As String = ""
            Dim pcKadarCode As String = ""
            Dim pcBrandCode As String = ""
            For Each dtItem As Object In pcFieldProductCode
                pcProductCode = dtItem("f01String").ToString

                pcKadarCode = dtItem("f09String").ToString
                pcBrandCode = dtItem("f15String").ToString
            Next

            If _cm10ValidasiDataProductCode(pcProductCode, pcKadarCode, pcBrandCode) Then
                _cm023InitControlSuggestedExistingSBox(pcProductCode)
                _cm024InitControlPKBConsumeInbound(pcProductCode)

                _09cStatusInventory.SelectedIndex = 0

                _gdINBOUND.__pbWSGridVisibilityCheckSelectAll()
            Else
                MsgBox("Maaf PRODUCTCODE INBOUND ... tidak sama dgn HISTORY PRODUCTCODE WAREHOUSE ....", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
                _cm01BersihkanEntrian()
            End If

        End If
    End Sub

    Private Sub _08cSuggestedExistingSBox_EditValueChanged(sender As Object, e As EventArgs) Handles _08cSuggestedExistingSBox.EditValueChanged
        If _08cSuggestedExistingSBox.EditValue <> "" And _01cTargetInbound.EditValue <> "" Then

            Dim pcFieldKodeSBox As String = ""
            Dim pcFieldNamaSBox As String = ""
            Select Case _01cTargetInbound.EditValue
                Case "5021"        '"Inhouse-Produksi"
                    pcFieldKodeSBox = "f36String"
                    pcFieldNamaSBox = "f37String"

                Case "5022"        '"Inhouse-Chain"

                Case "5023"        '"Repair-Warehouse"
                    pcFieldKodeSBox = "f08String"
                    pcFieldNamaSBox = "f09String"

                Case "5024"        '"Repair-Customer"

                Case "5025"        '"Retur-Customer"
                    pcFieldKodeSBox = "f08String"
                    pcFieldNamaSBox = "f09String"

                Case "5026"        '"Vendor-External"

                Case "5027"        '"BRJ-Pinjaman-Marketing"
                    pcFieldKodeSBox = "f08String"
                    pcFieldNamaSBox = "f09String"

                Case "5028"        '"RETUR-KAE"
                    pcFieldKodeSBox = "f08String"
                    pcFieldNamaSBox = "f09String"

                Case "5029"        '"RETUR-CONSIGNMENT"
                    pcFieldKodeSBox = "f08String"
                    pcFieldNamaSBox = "f09String"

            End Select

            Dim _dlgSetSBox As __dlgSetSBox = AddressOf _gdINBOUND._ivkSettingStorageBoxInbound
            _dlgSetSBox.Invoke(pcFieldKodeSBox, _08cSuggestedExistingSBox.EditValue, pcFieldNamaSBox, _08cSuggestedExistingSBox.Text)

        End If
    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm07SaveAllInbound()

            Case 200  'Clear
                _cm01BersihkanEntrian()

            Case 300 'Grid
                _cm11SettingWidthGrid()

        End Select
    End Sub

#End Region

#Region "Interface - method"

    Public Sub _mnuIExecSave() Implements clsWSNasaInterface._mnuIExecSave

    End Sub

    Public Sub _mnuIExecAddNewBox(prmcNamaBoxNew As String) Implements clsWSNasaInterface._mnuIExecAddNewBox
        Cursor = Cursors.WaitCursor

        Dim dtExistingSBox As New DataTable

        Using objNasaMaster As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            dtExistingSBox = objNasaMaster.__pb11GetDataSbox(prmcNamaBoxNew)
        End Using

        If dtExistingSBox.Rows.Count > 0 Then
            Cursor = Cursors.Default
            MsgBox("Oops! An SBox with '" & prmcNamaBoxNew & "' already exists. Try something unique!", vbExclamation, _prop01User._UserProp01cTitle)
            Exit Sub
        End If


        Dim pcNewSBoxCode As String = _prop01User._UserProp02cUserID & DateTime.Now.ToString("yyyyMMddHHmmss")

        Dim pcSQL As String = ""
        pcSQL = " insert into TABLE50 " &
                " (k10String,k11String,k12String,k13String,k14String,k15String,f10String,f11String,f12String, " &
                "  f10TinyInt,f10SmallInt,f10Int,f11Int,f10SmallDouble,f10Double,f10Double16, " &
                "  f10Datetime,f11Datetime,f10IDUser,f11IDUser,f10NamaUser,f11NamaUser) " &
                " values " &
                " ('','SBOX','STORED BOX','" & pcNewSBoxCode & "','" & prmcNamaBoxNew & "','','','','', " &
                "  0,0,0,0,0.0,0.0,0.0, " &
                "  '3000-01-01','" & Date.Now & "','" & _prop01User._UserProp02cUserID & "','','" & _prop01User._UserProp03cUserName & "','') "

        Dim pnHasil As Integer = 0
        Using objNasa As New clsWSNasaHelper
            pnHasil = objNasa._pbWSNasaHelperExec01SQLScript(_prop01User._UserProp08TargetNetwork,
                                                             clsWSNasaHelper._pnmDatabaseName.TABLEMASTER, pcSQL)
        End Using
        Cursor = Cursors.Default

        If pnHasil > 0 Then
            Cursor = Cursors.WaitCursor

            Dim pdtSBoxCopy As New DataTable
            pdtSBoxCopy = _08cSuggestedExistingSBox._prop01WSDataSource.Copy

            Dim objNewSBox As DataRow
            objNewSBox = pdtSBoxCopy.NewRow()
            objNewSBox("k02String") = "**** NEW ***"
            objNewSBox("k03String") = pcNewSBoxCode
            objNewSBox("f01String") = prmcNamaBoxNew
            objNewSBox("f01SmallInt") = 0
            objNewSBox("f01Double") = 0.0
            pdtSBoxCopy.Rows.Add(objNewSBox)

            _08cSuggestedExistingSBox.Properties.DataSource = Nothing
            With _08cSuggestedExistingSBox
                ._prop01WSDataSource = pdtSBoxCopy
                ._prop02WSDaftarField = New String() {"k02String", "k03String", "f01String", "f01SmallInt", "f01Double"}
                ._prop05WSFieldValueMember = "k03String"
                ._prop06WSFieldDisplayMember = "f01String"
            End With
            _08cSuggestedExistingSBox._pb04BindingAwalDataSource5Field("k02String", "ProductCode", "k03String", "CodeSBox", "f01String", "SBox", "f01SmallInt", "T.Pcs", "f01Double", "T.Berat")

            _08cSuggestedExistingSBox.Refresh()
            _08cSuggestedExistingSBox.RefreshEditValue()

            Dim objBoxInGrid As __dlgSetTrueCheckbox = AddressOf _gdINBOUND._ivkAddNewBox
            objBoxInGrid.Invoke(pcNewSBoxCode, prmcNamaBoxNew)

            Cursor = Cursors.Default
        Else
            MsgBox("Maaf ... Add New Box ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

End Class
