Imports System.Drawing.Drawing2D
Imports DevExpress.CodeParser
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucWS24F101INBOUNDENTRYCONTAINER
    Implements IDisposable

    Property _prop01User As clsWSNasaUser
    Property _prop011TargetEntryContainer As _nmTargetEntryContainer
    Property _prop02cKodeVendor As String
    Property _prop021cNamaVendor As String
    Property _prop03cNoDO As String
    Property _prop04DataMRPProduct As DataTable
    Property _prop05DataMRPSize As DataTable

    Private pdtItem As DataTable
    Private pdtKadar As DataTable
    Private pdtBrand As DataTable
    Private pdtWarna As DataTable

    Private pdtInbound As DataTable
    Private objInbound As clsWSNasaTemplateDataLargePlus

    Private _pcStatusNewUpd As String = ""
    Private _pnNumberLastSKU As Integer = 0
    Private _pnTotalSKU As Integer = 0

    Private objExecSQL As clsWSNasaHelper
    Private pdtDataTbl40 As DataTable

#Region "form - event"
    Public Enum _nmTargetEntryContainer
        _VND02INBOUNDINHOUSECHAIN = 0
        _VND03INBOUNDREPAIRWAREHOUSE = 1
    End Enum

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtItem = New DataTable
        pdtKadar = New DataTable
        pdtBrand = New DataTable
        pdtWarna = New DataTable

        pdtInbound = New DataTable
        objInbound = New clsWSNasaTemplateDataLargePlus With {.prop_dtsTABLELARGEPLUS = pdtInbound}
        objInbound.dtInitsTABLELARGEPLUS()

        objExecSQL = New clsWSNasaHelper
        pdtDataTbl40 = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtItem.Dispose()
        pdtKadar.Dispose()
        pdtBrand.Dispose()
        pdtWarna.Dispose()

        pdtInbound.Dispose()
        objInbound.Dispose()

        objExecSQL.Dispose()
        pdtDataTbl40.Dispose()
    End Sub

    Private Sub ucWS24F101INBOUNDENTRY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '********************************
        '******* VENDOR : TABLE50 *******
        '********************************
        'VND02	INHOUSE-CHAIN
        'VND03  REPAIR

        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        Cursor = Cursors.WaitCursor
        If _prop011TargetEntryContainer = _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN Then
            _layVendorHeaderGroup.Text = "Vendor : " & _prop021cNamaVendor
            _lay24cSKU.Text = "SKU"
            _lay05nBeratGross.Text = "Berat Gross"
            _lay06nBeratNett.Text = "Berat Nett"
            _lay07nWarehouseBundling.Text = "Warehouse Bundling"
        Else
            If _prop011TargetEntryContainer = _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE Then
                _layVendorHeaderGroup.Text = " Repair Warehouse "
                _lay24cSKU.Text = "SKU yg diReparasi"
                _lay05nBeratGross.Text = "Berat Gross Hasil Repair"
                _lay06nBeratNett.Text = "Berat Nett Hasil Repair"
                _lay07nWarehouseBundling.Text = "Pcs"
                BeginInvoke(New MethodInvoker(Sub()
                                                  _24cSKU.Focus()
                                              End Sub))
            End If
        End If

        _cm02GetDataMasterMRP()

        _cm03InitControlItem()
        _cm031InitControlKadar()
        _cm032InitControlBrand()
        _cm033InitControlWarna()
        _cm034InitControlSize()
        _cm035InitControlStorageBox()

        _cm01BersihkanEntrian()
        _cm011ControlReadOnly(False)
        _cm013SettingLayoutVisibility()

        'Setting BarManager - Menu
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar2.OptionsBar.DrawDragBorder = False
        Bar2.BarItemHorzIndent = 10

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01BersihkanEntrian()
        _01cVendorPONumber.EditValue = ""

        _02cVendorValidationCode.EditValue = ""

        _03cProductCode.EditValue = ""
        _04nTotalQtyDO.EditValue = 1
        _04nTotalBeratDO.EditValue = 0
        _07nWarehouseBundling.EditValue = 1
        _08cItem.EditValue = ""
        _09cBrand.EditValue = ""
        _10cKadar.EditValue = ""
        _11cWarna.EditValue = ""
        _12cSize.EditValue = ""

        _20dTglInbound.EditValue = Today.Date
        _21cVendorDONumber.EditValue = ""
        _22cStorageBox.EditValue = ""
        _23cJenisInventory.SelectedIndex = 0
        _24cSKU.EditValue = ""

        _pnNumberLastSKU = 0
        _pnTotalSKU = 0

        _pcStatusNewUpd = "NEW"

        pdtDataTbl40.Clear()
        objInbound.prop_dtsTABLELARGEPLUS.Clear()

        _gdInbound._prop03pdtDataSourceGrid = Nothing

        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
                _05nBeratGross.EditValue = 0
                _06nBeratNett.EditValue = 0
        End Select
    End Sub

    Private Sub _cm011ControlReadOnly(Optional ByVal prmlEnableDisable As Boolean = False)
        _21cVendorDONumber.Properties.ReadOnly = prmlEnableDisable
        _01cVendorPONumber.Properties.ReadOnly = prmlEnableDisable
        _20dTglInbound.Properties.ReadOnly = prmlEnableDisable
        _02cVendorValidationCode.Properties.ReadOnly = prmlEnableDisable
        _03cProductCode.Properties.ReadOnly = prmlEnableDisable
        _04nTotalQtyDO.Properties.ReadOnly = prmlEnableDisable
        _04nTotalBeratDO.Properties.ReadOnly = prmlEnableDisable
        _07nWarehouseBundling.Properties.ReadOnly = prmlEnableDisable
        _23cJenisInventory.Properties.ReadOnly = prmlEnableDisable
        _22cStorageBox.Properties.ReadOnly = prmlEnableDisable

        _08cItem.Properties.ReadOnly = prmlEnableDisable
        _12cSize.Properties.ReadOnly = prmlEnableDisable
        _09cBrand.Properties.ReadOnly = prmlEnableDisable
        _10cKadar.Properties.ReadOnly = prmlEnableDisable
        _11cWarna.Properties.ReadOnly = prmlEnableDisable

        _cm012SettingControlReadOnly()
    End Sub

    Private Sub _cm012SettingControlReadOnly()
        _05nBeratGross.Properties.ReadOnly = False
        _06nBeratNett.Properties.ReadOnly = False

        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                _24cSKU.Properties.ReadOnly = True

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
                _24cSKU.Properties.ReadOnly = False
                _03cProductCode.Properties.ReadOnly = True
                _03cProductCode.Properties.AllowFocused = False
                _03cProductCode.TabStop = False
                _08cItem.Properties.ReadOnly = True
                _09cBrand.Properties.ReadOnly = True
                _10cKadar.Properties.ReadOnly = True
                _11cWarna.Properties.ReadOnly = True

        End Select
    End Sub

    Private Sub _cm013SettingLayoutVisibility()
        _lay21cVendorDONumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay01cVendorPONumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay20dTglInbound.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay02cVendorValidationCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay03cProductCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay04nTotalQtyDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay04nTotalBeratDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay07nWarehouseBundling.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay23cJenisInventory.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay22cStorageBox.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        _lay08cItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay12cSize.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay09cBrand.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay10cKadar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay11cWarna.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        _lay24cSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay05nBeratGross.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        _lay06nBeratNett.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
                _lay21cVendorDONumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _lay01cVendorPONumber.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _lay20dTglInbound.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _lay02cVendorValidationCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _lay04nTotalQtyDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _lay04nTotalBeratDO.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _gdInbound.Visible = False
        End Select

    End Sub

    Private Sub _cm02GetDataMasterMRP()

        pdtItem = _prop04DataMRPProduct.Copy()
        pdtKadar = _prop04DataMRPProduct.Copy()
        pdtBrand = _prop04DataMRPProduct.Copy()
        pdtWarna = _prop04DataMRPProduct.Copy()
    End Sub

    Private Sub _cm03InitControlItem()
        If pdtItem.Rows.Count > 0 Then
            _08cItem.Properties.DataSource = Nothing
            With _08cItem
                ._prop01WSDataSource = pdtItem
                ._prop02WSDaftarField = New String() {"k01cKodeFieldValueMaster_v50", "f01cIsiFieldValueMaster_v50", "f02cKodeMaster_v50"}
                ._prop03WSFieldYgDiFilter = "f02cKodeMaster_v50"
                ._prop04WSValueKodeMasterYgDiFilter = "ITEMPRODUCT"
                ._prop05WSFieldValueMember = "k01cKodeFieldValueMaster_v50"
                ._prop06WSFieldDisplayMember = "f01cIsiFieldValueMaster_v50"
            End With
            _08cItem._pb01BindingAwalDataSource2Field("Code", "ITEM")
            _08cItem._pb04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _cm031InitControlKadar()
        If pdtKadar.Rows.Count > 0 Then
            _10cKadar.Properties.DataSource = Nothing
            With _10cKadar
                ._prop01WSDataSource = pdtKadar
                ._prop02WSDaftarField = New String() {"k01cKodeFieldValueMaster_v50", "f01cIsiFieldValueMaster_v50", "f02cKodeMaster_v50"}
                ._prop03WSFieldYgDiFilter = "f02cKodeMaster_v50"
                ._prop04WSValueKodeMasterYgDiFilter = "KADAR"
                ._prop05WSFieldValueMember = "k01cKodeFieldValueMaster_v50"
                ._prop06WSFieldDisplayMember = "f01cIsiFieldValueMaster_v50"
            End With
            _10cKadar._pb01BindingAwalDataSource2Field("Code", "KADAR")
            _10cKadar._pb04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _cm032InitControlBrand()
        If pdtBrand.Rows.Count > 0 Then
            _09cBrand.Properties.DataSource = Nothing
            With _09cBrand
                ._prop01WSDataSource = pdtBrand
                ._prop02WSDaftarField = New String() {"k01cKodeFieldValueMaster_v50", "f01cIsiFieldValueMaster_v50", "f02cKodeMaster_v50"}
                ._prop03WSFieldYgDiFilter = "f02cKodeMaster_v50"
                ._prop04WSValueKodeMasterYgDiFilter = "BRAND"
                ._prop05WSFieldValueMember = "k01cKodeFieldValueMaster_v50"
                ._prop06WSFieldDisplayMember = "f01cIsiFieldValueMaster_v50"
            End With
            _09cBrand._pb01BindingAwalDataSource2Field("Code", "BRAND")
            _09cBrand._pb04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _cm033InitControlWarna()
        If pdtWarna.Rows.Count > 0 Then
            _11cWarna.Properties.DataSource = Nothing
            With _11cWarna
                ._prop01WSDataSource = pdtWarna
                ._prop02WSDaftarField = New String() {"k01cKodeFieldValueMaster_v50", "f01cIsiFieldValueMaster_v50", "f02cKodeMaster_v50"}
                ._prop03WSFieldYgDiFilter = "f02cKodeMaster_v50"
                ._prop04WSValueKodeMasterYgDiFilter = "COLOR"
                ._prop05WSFieldValueMember = "k01cKodeFieldValueMaster_v50"
                ._prop06WSFieldDisplayMember = "f01cIsiFieldValueMaster_v50"
            End With
            _11cWarna._pb01BindingAwalDataSource2Field("Code", "WARNA")
            _11cWarna._pb04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _cm034InitControlSize()
        If _prop05DataMRPSize.Rows.Count > 0 Then
            _12cSize.Properties.DataSource = Nothing
            With _12cSize
                ._prop01WSDataSource = _prop05DataMRPSize
                ._prop02WSDaftarField = New String() {"k01cKodeFieldValueMaster_v50", "f01cIsiFieldValueMaster_v50", "f02cKodeMaster_v50"}
                ._prop05WSFieldValueMember = "k01cKodeFieldValueMaster_v50"
                ._prop06WSFieldDisplayMember = "f01cIsiFieldValueMaster_v50"
            End With
            _12cSize._pb01BindingAwalDataSource2Field("Code", "SIZE")
        End If
    End Sub

    Private Sub _cm035InitControlStorageBox()
        Cursor = Cursors.WaitCursor

        Dim pdtSBox As New DataTable
        Using objclsMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtSBox = objclsMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("SBOX")
        End Using

        _22cStorageBox.Properties.DataSource = Nothing
        With _22cStorageBox
            ._prop01WSDataSource = pdtSBox
            ._prop02WSDaftarField = New String() {"k13String", "k14String"}
            ._prop05WSFieldValueMember = "k13String"
            ._prop06WSFieldDisplayMember = "k14String"
        End With
        _22cStorageBox._pb01BindingAwalDataSource2Field("Code", "StorageBox")

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm036InitControlStorageBoxProductCode()
        Cursor = Cursors.WaitCursor

        Dim pdtSBox As New DataTable
        Using objclsMaster As clsWSNasaSelect4CtrlRepoMaster = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
            pdtSBox = objclsMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("SBOX")
        End Using

        Dim pdtProductCodeSBox As New DataTable
        If Not String.IsNullOrEmpty(_03cProductCode.EditValue) Then
            Using objclsProductCodeSBox As clsWSNasaSelect4CtrlRepoProses = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
                pdtProductCodeSBox = objclsProductCodeSBox._pb06GetDataSBoxProductCode(_03cProductCode.EditValue)
            End Using
        End If

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

        _22cStorageBox.Properties.DataSource = Nothing
        If pdtProductCodeSBox.Rows.Count > 0 Then
            With _22cStorageBox
                ._prop01WSDataSource = pdtProductCodeSBox
                ._prop02WSDaftarField = New String() {"k02String", "k03String", "f01String", "f01SmallInt", "f01Double"}
                ._prop05WSFieldValueMember = "k03String"
                ._prop06WSFieldDisplayMember = "f01String"
            End With
            _22cStorageBox._pb04BindingAwalDataSource5Field("k02String", "ProductCode", "k03String", "CodeSBox", "f01String", "SBox", "f01SmallInt", "T.Pcs", "f01Double", "T.Berat")

        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm04GetPatternSKUNonCitrix(ByRef prmcPatternSKU As String, ByRef prmnNomorTerakhir As Int32,
                                            ByVal prmcKodeGroup As String, ByVal prmnJmlInc As Int32)
        Dim pdtHasil As New DataTable
        Dim pnYear As Integer = Year(Today.Date)
        Dim pnMonth As Integer = Month(Today.Date)

        Cursor = Cursors.WaitCursor

        Using objSKU As New clsWSNasaSelect4AllProsesMaster() With {._prop01User = _prop01User,
                                                                    ._prop02String = prmcKodeGroup}
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

#Region "***** INBOUND INHOUSE-CHAIN/VENDOR EXTERNAL *****"

    Private Sub _cm05CekVendorPODO()
        _pcStatusNewUpd = ""
        _pnNumberLastSKU = 0

        'cek apakah ada Vendor DO-PO di database...?
        'jika ADA, berarti _pcStatusNewUpd = "UPD"
        'dan proses dilanjutkan display data dan akan melanjutkan mengisi SKU sisaan yg kurang.
        If _21cVendorDONumber.EditValue <> "" And _01cVendorPONumber.EditValue <> "" Then
            _cm11DisplayDataTable40(pdtDataTbl40, "PODO")
        End If

        If _pcStatusNewUpd = "NEW" Then
            Dim prmcPatternSKU As String = ""
            Dim prmnNomorTerakhir As Integer = 0

            Dim pcIDSKU As String = ""
            If _prop02cKodeVendor = "VND02" Then
                pcIDSKU = "WSNEWSKUVENDORCHAIN"
            Else
                pcIDSKU = "WSNEWSKUVENDOREXTERNAL"
            End If

            _cm04GetPatternSKUNonCitrix(prmcPatternSKU, prmnNomorTerakhir, pcIDSKU, 1)
            prmnNomorTerakhir = prmnNomorTerakhir + 1

            _02cVendorValidationCode.EditValue = ""
            _02cVendorValidationCode.EditValue = prmcPatternSKU + prmnNomorTerakhir.ToString("0000")
            _02cVendorValidationCode.Properties.ReadOnly = True

            _cm011ControlReadOnly(False)

        End If

    End Sub

    Private Sub _cm06CekValueFieldComplete()
        If (_08cItem.EditValue <> "") And (_09cBrand.EditValue <> "") And
           (_10cKadar.EditValue <> "") And (_11cWarna.EditValue <> "") Then

            If _prop011TargetEntryContainer = _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN Then
                If _pcStatusNewUpd = "NEW" Then
                    _pnNumberLastSKU = 1
                    _24cSKU.EditValue = _02cVendorValidationCode.EditValue + "-001"

                    _cm07GenerateSKUKosongInbound()
                End If
            Else
                If _prop011TargetEntryContainer = _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE Then

                End If
            End If

        End If
    End Sub

    Private Sub _cm07GenerateSKUKosongInbound()
        Dim pnTotalQtyDO As Integer = _04nTotalQtyDO.EditValue
        Dim pnBundling As Integer = _07nWarehouseBundling.EditValue

        If (pnTotalQtyDO > 0 And pnBundling > 0) And (pnTotalQtyDO >= pnBundling) Then
            Dim pcSKU As String = ""

            Dim pcStatusInventory As String = ""
            Select Case _23cJenisInventory.SelectedIndex
                Case 0
                    pcStatusInventory = "FORSALE"
                Case 1
                    pcStatusInventory = "NOTFORSALE"
            End Select

            Dim pnKadarInteger As Integer = 0
            pnKadarInteger = _cm08ConvertPersenKadarToInteger(_10cKadar.Text)

            Dim pdtData As New DataTable

            Dim objTable40 As New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtData}
            objTable40.dtInitsTABLEMEDIUMPLUSPLUS()

            Dim pnIncrementSKU As Integer = 0
            For i As Integer = 1 To pnTotalQtyDO Step pnBundling
                pnIncrementSKU = pnIncrementSKU + 1

                pcSKU = ""
                pcSKU = _02cVendorValidationCode.EditValue + "-" + pnIncrementSKU.ToString("000")
                objTable40.dtAddNewsTABLEMEDIUMPLUS(_02cVendorValidationCode.EditValue, pcSKU, "",
                                  _21cVendorDONumber.EditValue, _01cVendorPONumber.EditValue, _03cProductCode.EditValue, pcStatusInventory, _22cStorageBox.EditValue, _22cStorageBox.Text, "", "", "", "",
                                  _08cItem.EditValue, _08cItem.Text, _09cBrand.EditValue, _09cBrand.Text, _10cKadar.EditValue, _10cKadar.Text, _11cWarna.EditValue, _11cWarna.Text, _12cSize.EditValue, _12cSize.Text,
                                  _prop02cKodeVendor, _prop021cNamaVendor, "", "", "", "", "", "", "", "",
                                  pnIncrementSKU, _07nWarehouseBundling.EditValue, pnKadarInteger, 0, _04nTotalQtyDO.EditValue,
                                  0.0, 0.0, 0.0, 0.0, _04nTotalBeratDO.EditValue,
                                  _20dTglInbound.EditValue, "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                                  Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                                  _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
            Next

            Cursor = Cursors.WaitCursor

            If objTable40.prop_dtsTABLEMEDIUMPLUS.Rows.Count > 0 Then
                Dim objNasa As New clsWSNasaHelper
                Dim pnJmlRec As Integer = 0
                pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                    2, "spWSTABLE40Save", "@tpDataForSaving", objTable40.prop_dtsTABLEMEDIUMPLUS)

                pdtDataTbl40.Clear()
                pdtDataTbl40 = objTable40.prop_dtsTABLEMEDIUMPLUS

                _cm10UpdateProgressSKUProses()
                _cm13DisplayGridInboundChainExternal()
            Else
                MsgBox("Maaf ... Data TEMPORARY ... KOSONG ...", vbCritical + vbOKOnly, _prop01User._UserProp01cTitle)
            End If

            Cursor = Cursors.Default
        Else
            MsgBox("Maaf ... Tot.Qty atau Bundling ... SALAH ...", vbCritical + vbOKOnly, _prop01User._UserProp01cTitle)
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

    Private Function _cm09CekBundling() As Boolean
        Dim pnSisa As Integer = _04nTotalQtyDO.EditValue Mod _07nWarehouseBundling.EditValue

        Dim plHasil As Boolean

        If pnSisa = 0 Then
            _pnTotalSKU = _04nTotalQtyDO.EditValue / _07nWarehouseBundling.EditValue

            plHasil = True
        Else
            plHasil = False

            MsgBox("Maaf ... TotalQtyDO dan WarehouseBundling ... SALAH ...", vbInformation + vbOKOnly, _prop01User._UserProp01cTitle)

            _pnTotalSKU = 0
            _04nTotalQtyDO.EditValue = 1
            _07nWarehouseBundling.EditValue = 1

            _04nTotalQtyDO.Focus()
        End If

        Return plHasil
    End Function

    Private Sub _cm10UpdateProgressSKUProses()
        _layVendorIdentitasSKU.Text = "Identitas SKU - (" + _pnNumberLastSKU.ToString + " of " + _pnTotalSKU.ToString + ")"
    End Sub

    Private Sub _cm11DisplayDataTable40(ByRef prmdtTable40 As DataTable, Optional ByVal pcTarget1PODO2VALCODE As String = "VALCODE")
        Cursor.Current = Cursors.WaitCursor

        _pnNumberLastSKU = 0

        Dim pcSQL As String = ""
        If pcTarget1PODO2VALCODE = "VALCODE" Then
            pcSQL = " select * from wsTABLE40 where k01String = '" & _02cVendorValidationCode.EditValue & "' order by f01TinyInt"
        Else
            pcSQL = " select * from wsTABLE40 " &
                    " where f01String = '" & _21cVendorDONumber.EditValue & "'" &
                    "       and f02String = '" & _01cVendorPONumber.EditValue & "'" &
                    "       and k01String <> 'COMPLETE'" &
                    " order by f01TinyInt"
        End If

        prmdtTable40.Clear()
        prmdtTable40 = objExecSQL._pbWSNasaExecSQLDirectToDataTable(_prop01User._UserProp08TargetNetwork,
                                                                clsWSNasaHelper._pnmDatabaseName.WS, 1, pcSQL)

        If prmdtTable40.Rows.Count > 0 Then
            For Each dtRow As DataRow In prmdtTable40.Rows
                _01cVendorPONumber.EditValue = dtRow("f02String")
                _02cVendorValidationCode.EditValue = dtRow("k01String")

                _03cProductCode.EditValue = dtRow("f03String")
                _08cItem.EditValue = dtRow("f11String")
                _09cBrand.EditValue = dtRow("f13String")
                _10cKadar.EditValue = dtRow("f15String")
                _11cWarna.EditValue = dtRow("f17String")
                _12cSize.EditValue = dtRow("f19String")

                _20dTglInbound.EditValue = dtRow("f01Date")
                _21cVendorDONumber.EditValue = dtRow("f01String")
                _22cStorageBox.EditValue = dtRow("f05String")

                If dtRow("f04String") = "FORSALE" Then
                    _23cJenisInventory.SelectedIndex = 0
                Else
                    _23cJenisInventory.SelectedIndex = 1
                End If

                _04nTotalQtyDO.EditValue = dtRow("f03Int")
                _04nTotalBeratDO.EditValue = dtRow("f05Double")
                _07nWarehouseBundling.EditValue = dtRow("f01SmallInt")

                If dtRow("f01Double") = 0.0 And _pnNumberLastSKU = 0 Then
                    _24cSKU.EditValue = dtRow("k02String")
                    _pnNumberLastSKU = dtRow("f01TinyInt")
                    _pnTotalSKU = dtRow("f03Int") / dtRow("f01SmallInt")

                    _pcStatusNewUpd = "UPD"
                    Exit For
                End If

            Next

            _cm011ControlReadOnly(True)

            _cm10UpdateProgressSKUProses()
            _cm13DisplayGridInboundChainExternal()
        Else
            _pcStatusNewUpd = "NEW"
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub _cm12UpdateDataTable40(ByVal prmcSKU As String, ByVal prmnBeratGross As Double, ByVal prmnBeratNett As Double)
        Cursor.Current = Cursors.WaitCursor

        Dim pcSQL As String = ""
        pcSQL = " update wsTABLE40 " &
                " set f01Double = " & prmnBeratGross & ", f02Double = " & prmnBeratNett &
                "     ,f01Datetime = getdate(), f01IDUser = '" & _prop01User._UserProp02cUserID & "'" &
                "     ,f01NamaUser = '" & _prop01User._UserProp03cUserName & "', f01ComputerName = '" & _prop01User._UserProp04ComputerName & "'" &
                "     ,f02ComputerIPPrivate = '" & _prop01User._UserProp05IPLocalAddress & "', f03ComputerIPPublic  = '" & _prop01User._UserProp06IPPublicAddress & "'" &
                " where k02String = '" & prmcSKU & "'"

        Dim pnHasil As Integer = 0
        pnHasil = objExecSQL._pbWSNasaHelperExec01SQLScript(_prop01User._UserProp08TargetNetwork,
                                                            clsWSNasaHelper._pnmDatabaseName.WS, pcSQL)

        _cm14UpdateGridBerat(prmcSKU, prmnBeratGross, prmnBeratNett)

        'NEXT Proses SKU
        _pnNumberLastSKU = _pnNumberLastSKU + 1
        If _pnNumberLastSKU <= _pnTotalSKU Then

            _05nBeratGross.EditValue = 0.0
            _06nBeratNett.EditValue = 0.0

            _24cSKU.EditValue = ""
            _24cSKU.EditValue = _02cVendorValidationCode.EditValue + "-" + _pnNumberLastSKU.ToString("000")

            _05nBeratGross.Focus()
        Else
            _cm15SaveInboundVendorChainExternalComplete()
            Me.ParentForm.Close()
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub _cm13DisplayGridInboundChainExternal()
        _gdInbound._prop03pdtDataSourceGrid = Nothing

        With _gdInbound
            ._prop01User = _prop01User
            If _prop02cKodeVendor = "VND02" Then
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5022InhouseChain
            Else
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSInbound5026External
            End If
            ._prop03pdtDataSourceGrid = pdtDataTbl40
        End With
        _gdInbound.__pbWSGrid01InitGrid()
        _gdInbound.__pbWSGrid03DisplayGrid()

    End Sub

    Private Sub _cm14UpdateGridBerat(ByVal prmcSKU As String, ByVal prmnBeratGross As Double, ByVal prmnBeratNett As Double)
        For Each dtRow As DataRow In pdtDataTbl40.Rows
            If dtRow("k02String") = prmcSKU Then
                dtRow("f01Double") = prmnBeratGross
                dtRow("f02Double") = prmnBeratNett

                Exit For
            End If
        Next

        pdtDataTbl40.AcceptChanges()

        GridView1.RefreshData()
    End Sub

    Private Sub _cm15SaveInboundVendorChainExternalComplete()
        Cursor = Cursors.WaitCursor

        Dim pdtKey As New DataTable
        Dim objKey As New clsWSNasaTemplateKey With {.prop_dtKEY = pdtKey}
        objKey.dtInitKEY()
        objKey.dtAddNewKEY(_02cVendorValidationCode.EditValue, _21cVendorDONumber.EditValue, "", "", "")

        Dim objNasa As New clsWSNasaHelper
        Dim pnJmlRec As Integer = 0
        pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                            _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                            2, "spWSInbound40VENDORCHAINEXTERNAL", "@Key", objKey.prop_dtKEY)

        Cursor = Cursors.Default

        If pnJmlRec > 0 Then
            MsgBox(_02cVendorValidationCode.EditValue & "... COMPLETE ..." & Chr(13) &
                   "Proses Simpan Data INBOUND - " & _prop021cNamaVendor & " ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... Proses Simpan Data INBOUND - " & _prop021cNamaVendor & " ... GAGAL ...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

#End Region

#Region "***** INBOUND REPAIR-WAREHOUSE *****"

    Private Sub _cm16SearchingSKUReparasi()
        Cursor = Cursors.WaitCursor
        Dim plHasil As Boolean = True

        Dim pdtSKURepair As New DataTable
        Using objSKURepair As clsWSNasaSelect4CtrlRepoProses = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtSKURepair = objSKURepair._pb09GetDataSKUForRepairResult(_24cSKU.EditValue)
        End Using

        objInbound.prop_dtsTABLELARGEPLUS.Clear()
        If pdtSKURepair.Rows.Count > 0 Then
            For Each dtRow As DataRow In pdtSKURepair.Rows
                _03cProductCode.EditValue = dtRow("f03String")
                _07nWarehouseBundling.EditValue = dtRow("f01SmallInt")
                _08cItem.EditValue = dtRow("f11String")
                _09cBrand.EditValue = dtRow("f15String")
                _10cKadar.EditValue = dtRow("f09String")
                _11cWarna.EditValue = dtRow("f07String")
                _12cSize.EditValue = dtRow("f13String")

                objInbound.dtAddNewsTABLELARGEPLUS("", "", "",
                    dtRow("f03String"), "", "VND03", "REPAIR", "", "", dtRow("f07String"), dtRow("f08String"), dtRow("f09String"), dtRow("f10String"),
                    dtRow("f11String"), dtRow("f12String"), dtRow("f13String"), dtRow("f14String"), dtRow("f15String"), dtRow("f16String"), "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "",
                    "50303", "REPAIR-WAREHOUSE", dtRow("f01String"), "", "", _24cSKU.EditValue, dtRow("k01String"), "", "", "",
                    "", "", "", "", "", "", "", "", "", dtRow("f50String"),
                    dtRow("f51String"), "", "", "", "",
                    0, 0, dtRow("f01SmallInt"), 0, 0, 0, 0,
                    0.0, 0.0, dtRow("f01Double"), 0.0, 0.0,
                    dtRow("f01Date"), dtRow("f02Date"), Today.Date, "3000-01-01", "3000-01-01",
                    Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            Next
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm17SaveInboundResultRepairWarehouse()
        Dim prmcPatternSKU As String = "" : Dim prmnNomorTerakhir As Integer = 0
        _cm04GetPatternSKUNonCitrix(prmcPatternSKU, prmnNomorTerakhir, "WSNEWSKUREPARASIWS", 1)
        prmnNomorTerakhir = prmnNomorTerakhir + 1

        Dim pcSKUNew As String = ""
        pcSKUNew = prmcPatternSKU + prmnNomorTerakhir.ToString("0000")

        For Each dtRow As DataRow In objInbound.prop_dtsTABLELARGEPLUS.Rows
            dtRow("k02String") = pcSKUNew
            dtRow("f19String") = _22cStorageBox.EditValue
            dtRow("f20String") = _22cStorageBox.Text
            dtRow("f34String") = _prop03cNoDO
            dtRow("f35String") = If(_07nWarehouseBundling.Value = 1, "SINGLE", "BUNDLE")
            dtRow("f43String") = If(_23cJenisInventory.SelectedIndex = 0, "FORSALE", "NOTFORSALE")
            dtRow("f01SmallInt") = _07nWarehouseBundling.Value
            dtRow("f04Int") = _cm08ConvertPersenKadarToInteger(_10cKadar.Text)
            dtRow("f01Double") = _05nBeratGross.EditValue
            dtRow("f02Double") = _06nBeratNett.EditValue
            dtRow("f38String") = "WAREHOUSE"
            dtRow("f50String") = "OK | " & dtRow("f50String")
        Next
        objInbound.prop_dtsTABLELARGEPLUS.AcceptChanges()

        If objInbound.prop_dtsTABLELARGEPLUS.Rows.Count > 0 Then
            Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk menyimpan data Hasil Reparasi WH ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

            If plYes = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim objNasa As New clsWSNasaHelper
                Dim pnJmlRec As Integer = 0
                pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                        _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                        2, "spWSInbound5023ReparasiWS", "@tpDataForSaving", objInbound.prop_dtsTABLELARGEPLUS)
                Cursor = Cursors.Default

                If pnJmlRec > 0 Then
                    MsgBox("Proses Simpan Data INBOUND Hasil Reparasi WH ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
                    _cm01BersihkanEntrian()
                Else
                    MsgBox("Maaf ... Proses Simpan Data INBOUND Hasil Reparasi WH ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
                End If
            Else
                MsgBox("Maaf ... Proses Simpan Data INBOUND Hasil Reparasi WH ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Maaf ... Data INBOUND Hasil Reparasi WH... TIDAK ADA...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub
#End Region

    '*********************************************************************************************************
    '******************************* AKHIR CODE YG SDG DIUPDATE **********************************************
    '*********************************************************************************************************

    'Private Function _cm05GetDataForSave() As DataTable
    '    objInbound.prop_dtsTABLELARGEPLUS.Clear()

    '    objInbound.dtAddNewsTABLELARGEPLUS("", "", _02cVendorValidationCode.EditValue,
    '               _03cProductCode.EditValue, "", _prop02cKodeVendor, _prop021cNamaVendor, "", "", _11cWarna.EditValue, _11cWarna.Text, _10cKadar.EditValue, _10cKadar.Text,
    '               _08cItem.EditValue, _08cItem.Text, _12cSize.EditValue, _12cSize.Text, _09cBrand.EditValue, _09cBrand.Text, "", "", "", "",
    '               "", "", "", "", "", "", "", "", "", "",
    '               "", "PARENT", _prop03cNoDO, "", "", _01cVendorPONumber.EditValue, "", "", "", "",
    '               "", "", "", "", "", "", "", "", "", "",
    '               "", "", "", "", "",
    '               _07nWarehouseBundling.EditValue, _04nTotalQtyDO.EditValue, 0, 0, 0, 0, 0,
    '               _05nBeratGross.EditValue, _06nBeratNett.EditValue, 0.0, 0.0, 0.0,
    '               "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
    '               Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '               _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '    Dim prmcPatternSKU As String = ""
    '    Dim prmnNomorTerakhir As Integer = 0

    '    Dim pcIDSKU As String = ""
    '    If _prop02cKodeVendor = "VND02" Then
    '        pcIDSKU = "WSNEWSKUVENDORCHAIN"
    '    Else
    '        pcIDSKU = "WSNEWSKUVENDOREXTERNAL"
    '    End If

    '    Dim pcNewSKU As String = ""
    '    If _04nTotalQtyDO.EditValue = 1 Then

    '        _cm04GetPatternSKUNonCitrix(prmcPatternSKU, prmnNomorTerakhir, pcIDSKU, 1)
    '        prmnNomorTerakhir = prmnNomorTerakhir + 1

    '        pcNewSKU = ""
    '        pcNewSKU = prmcPatternSKU + prmnNomorTerakhir.ToString("0000")

    '        objInbound.dtAddNewsTABLELARGEPLUS("", pcNewSKU, _02cVendorValidationCode.EditValue,
    '                   _03cProductCode.EditValue, "", _prop02cKodeVendor, _prop021cNamaVendor, "", "", _11cWarna.EditValue, _11cWarna.Text, _10cKadar.EditValue, _10cKadar.Text,
    '                   _08cItem.EditValue, _08cItem.Text, _12cSize.EditValue, _12cSize.Text, _09cBrand.EditValue, _09cBrand.Text, "", "", "", "",
    '                   "", "", "", "", "", "", "", "", "", "",
    '                   "", "DETAIL", _prop03cNoDO, "", "SINGLE", _01cVendorPONumber.EditValue, "", "", "", "",
    '                   "", "", "", "", "", "", "", "", "", "",
    '                   "", "", "", "", "",
    '                   0, _04nTotalQtyDO.EditValue, 0, 0, 0, 0, 0,
    '                   0.0, 0.0, 0.0, 0.0, 0.0,
    '                   Today.Date, "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
    '                   Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                   _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

    '    Else
    '        If _04nTotalQtyDO.EditValue > 1 Then

    '            Dim pnLoop As Integer = CInt(_04nTotalQtyDO.EditValue / _07nWarehouseBundling.EditValue)

    '            _cm04GetPatternSKUNonCitrix(prmcPatternSKU, prmnNomorTerakhir, pcIDSKU, pnLoop)
    '            Dim pnNoAwal As Integer = prmnNomorTerakhir

    '            If prmnNomorTerakhir > 0 Then
    '                pnNoAwal = (prmnNomorTerakhir - pnLoop)
    '            End If

    '            For i As Integer = 1 To pnLoop

    '                pnNoAwal = pnNoAwal + 1   ' sb di awali dgn NOL, maka perlu INC di depan.

    '                pcNewSKU = ""
    '                pcNewSKU = prmcPatternSKU + pnNoAwal.ToString("0000")

    '                objInbound.dtAddNewsTABLELARGEPLUS("", pcNewSKU, _02cVendorValidationCode.EditValue,
    '                   _03cProductCode.EditValue, "", "", "", "", "", _11cWarna.EditValue, _11cWarna.Text, _10cKadar.EditValue, _10cKadar.Text,
    '                   _08cItem.EditValue, _08cItem.Text, _12cSize.EditValue, _12cSize.Text, _09cBrand.EditValue, _09cBrand.Text, "", "", "", "",
    '                   "", "", "", "", "", "", "", "", "", "",
    '                   "", "DETAIL", _prop03cNoDO, "", "", _01cVendorPONumber.EditValue, "", "", "", "",
    '                   "", "", "", "", "", "", "", "", "", "",
    '                   "", "", "", "", "",
    '                   0, _07nWarehouseBundling.EditValue, 0, 0, 0, 0, 0,
    '                   0.0, 0.0, 0.0, 0.0, 0.0,
    '                   Today.Date, "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
    '                   Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                   _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
    '            Next

    '        End If

    '    End If

    '    Return objInbound.prop_dtsTABLELARGEPLUS
    'End Function

    'Private Sub _cm06ProsesSave()
    '    Dim pdtData As New DataTable
    '    pdtData = _cm05GetDataForSave()

    '    If pdtData.Rows.Count > 0 Then
    '        Cursor = Cursors.WaitCursor

    '        Dim objNasa As New clsWSNasaHelper
    '        Dim pnJmlRec As Integer = 0
    '        pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
    '                            _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
    '                            2, "spWSTABLE201Save", "@tpDataForSaving", pdtData)

    '        Cursor = Cursors.Default

    '        MsgBox("Proses Simpan Data INBOUND - " & _prop021cNamaVendor & " ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
    '        _cm01BersihkanEntrian()
    '    Else
    '        MsgBox("Maaf ... TIDAK ADA data INBOUND - " & _prop021cNamaVendor & " yg akan disimpan.", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
    '    End If
    'End Sub

    'Private Sub _cm07SaveData()
    '    Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin untuk menyimpan data ini ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

    '    If plYes = MsgBoxResult.Yes Then
    '        _cm06ProsesSave()
    '    Else
    '        MsgBox("Maaf ... Proses Simpan Data INBOUND - " & _prop021cNamaVendor & " ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
    '    End If
    'End Sub

#End Region

#Region "control - event"

    Private Sub _01cVendorPONumber_LostFocus(sender As Object, e As EventArgs) Handles _01cVendorPONumber.LostFocus
        If Not String.IsNullOrEmpty(_01cVendorPONumber.EditValue = "") Then
            Select Case _prop011TargetEntryContainer
                Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                    _cm05CekVendorPODO()

                Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
            End Select
        End If
    End Sub

    Private Sub _02cVendorValidationCode_LostFocus(sender As Object, e As EventArgs) Handles _02cVendorValidationCode.LostFocus
        If _02cVendorValidationCode.EditValue <> "" Then
            Select Case _prop011TargetEntryContainer
                Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                    _cm11DisplayDataTable40(pdtDataTbl40, "VALCODE")

                Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
            End Select
        End If
    End Sub

    Private Sub _03cProductCode_LostFocus(sender As Object, e As EventArgs) Handles _03cProductCode.LostFocus
        If Not String.IsNullOrEmpty(_03cProductCode.EditValue) Then
            Select Case _prop011TargetEntryContainer
                Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                    _cm036InitControlStorageBoxProductCode()

                Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
            End Select
        End If
    End Sub

    Private Sub _21cVendorDONumber_LostFocus(sender As Object, e As EventArgs) Handles _21cVendorDONumber.LostFocus
        If Not String.IsNullOrEmpty(_21cVendorDONumber.EditValue = "") Then
            Select Case _prop011TargetEntryContainer
                Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                    _cm05CekVendorPODO()

                Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
            End Select
        End If
    End Sub

    Private Sub _08cItem_EditValueChanged(sender As Object, e As EventArgs) Handles _08cItem.EditValueChanged
        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                _cm06CekValueFieldComplete()

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
        End Select
    End Sub

    Private Sub _09cBrand_EditValueChanged(sender As Object, e As EventArgs) Handles _09cBrand.EditValueChanged
        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                _cm06CekValueFieldComplete()

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
        End Select
    End Sub

    Private Sub _10cKadar_EditValueChanged(sender As Object, e As EventArgs) Handles _10cKadar.EditValueChanged
        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                _cm06CekValueFieldComplete()

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
        End Select
    End Sub

    Private Sub _11cWarna_EditValueChanged(sender As Object, e As EventArgs) Handles _11cWarna.EditValueChanged
        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                _cm06CekValueFieldComplete()

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
        End Select
    End Sub

    Private Sub _04nTotalQtyDO_LostFocus(sender As Object, e As EventArgs) Handles _04nTotalQtyDO.LostFocus
        If _prop011TargetEntryContainer = _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN Then
            _cm09CekBundling()
        End If
    End Sub

    Private Sub _07nWarehouseBundling_LostFocus(sender As Object, e As EventArgs) Handles _07nWarehouseBundling.LostFocus
        If _prop011TargetEntryContainer = _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN Then
            _cm09CekBundling()
        End If
    End Sub

    Private Sub _05nBeratGross_EditValueChanged(sender As Object, e As EventArgs) Handles _05nBeratGross.EditValueChanged
        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN
                If _05nBeratGross.EditValue > 0 Then
                    _06nBeratNett.EditValue = _05nBeratGross.EditValue

                    _cm12UpdateDataTable40(_24cSKU.EditValue, _05nBeratGross.EditValue, _06nBeratNett.EditValue)
                End If

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
        End Select
    End Sub

    Private Sub _24cSKU_LostFocus(sender As Object, e As EventArgs) Handles _24cSKU.LostFocus
        If _prop011TargetEntryContainer = _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE Then
            _cm16SearchingSKUReparasi()
        End If
    End Sub

    Private Sub mnuBar02Clear_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar02Clear.ItemClick
        _cm01BersihkanEntrian()
        _cm011ControlReadOnly(False)
    End Sub

    Private Sub mnuBar01Save_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnuBar01Save.ItemClick
        Select Case _prop011TargetEntryContainer
            Case _nmTargetEntryContainer._VND02INBOUNDINHOUSECHAIN

            Case _nmTargetEntryContainer._VND03INBOUNDREPAIRWAREHOUSE
                _cm17SaveInboundResultRepairWarehouse()
        End Select
    End Sub

#End Region

End Class
