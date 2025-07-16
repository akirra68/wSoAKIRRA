Imports DevExpress.XtraBars.Docking2010
Imports SKK02OBJECTS
Imports SKK02OBJECTS.clsGetDataProsesTransaksiGEMINI

Public Class ucMD23BV01PRODUCTORDER
    Implements IDisposable

    Public Property prop01User As clsUserGEMINI

    'Private objHelper As clsNasaHelper
    'Private objConnection As clsNasaConnection

    Private pdtTemplateXLS As DataTable
    Private objTemplateXLS As clsTEMPLATEGEMINI

    'Private pdtTABLEMASTER As DataTable
    'Private pdtSBUMASTER As DataTable
    'Private pdtMRPDESIGNMASTER As DataTable

    Private objProductOrder As clsGetDataProsesTransaksiGEMINI
    Private pdtProductOrder As DataTable

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'objHelper = New clsNasaHelper
        'objConnection = New clsNasaConnection

        pdtTemplateXLS = New DataTable
        objTemplateXLS = New clsTEMPLATEGEMINI With {.prop_dtTABLEGEMINI = pdtTemplateXLS}
        objTemplateXLS.dtInitTABLEGEMINI()

        'pdtTABLEMASTER = New DataTable
        'pdtSBUMASTER = New DataTable
        'pdtMRPDESIGNMASTER = New DataTable

        objProductOrder = New clsGetDataProsesTransaksiGEMINI
        pdtProductOrder = New DataTable

        _cm01InitMaster()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        'objHelper.Dispose()
        'objConnection.Dispose()

        pdtTemplateXLS.Dispose()
        objTemplateXLS.Dispose()

        'pdtTABLEMASTER.Dispose()
        'pdtSBUMASTER.Dispose()
        'pdtMRPDESIGNMASTER.Dispose()

        objProductOrder.Dispose()
        pdtProductOrder.Dispose()
    End Sub

    Private Sub ucMD23BV01PRODUCTORDER_Load(sender As Object, e As EventArgs) Handles Me.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(prop01User._UserProp10Skin)

        _cm02InitControlEntrian()
        _cm03BersihkanEntrian()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01InitMaster()
        'Dim objGetDataMaster As New clsGetDataMasterGEMINI

        'pdtSBUMASTER = objGetDataMaster._pb01GetDataCUSTOMER()
        'pdtTABLEMASTER = objGetDataMaster._pb02GetDataTIPEMERCHANDISE()
        'pdtMRPDESIGNMASTER = objGetDataMaster._tr01GetDataMRP32DESIGNMASTER()

        _gdProductCode._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._02MD23BV01PRODUCTORDER
        _gdProductCode._pb01InitGrid()
    End Sub

    Private Sub _cm02InitControlEntrian()
        Dim objSetupRepo As New clsSetupRepository
        '--------------------------------
        'SBU..TABLE02
        'k01String = GroupMaster
        'k02String = KeyCodeMaster
        'k03String = NamaMaster
        '================================
        'With _01cCustomer
        '    ._01prop_dtGEMINIMaster = pdtSBUMASTER
        '    ._02prop_cGEMINIDaftarField = New String() {"k01String", "k02String", "k03String"}
        '    ._03prop_cGEMINIFieldYgDiFilter = "k01String"
        '    ._04prop_cGEMINIValueKodeMasterYgDiFilter = "MCUSTOMER"
        '    ._05prop_cGEMINIFieldValueMember = "k02String"
        '    ._06prop_cGEMINIFieldDisplayMember = "k03String"
        'End With
        '_01cCustomer._03BindingAwalDataSurce()
        '_01cCustomer._04FilterDataViewMasterSKK()
        objSetupRepo._pb20InitDataSourceSBUMASTER(prop01User._UserProp07TargetNetwork)
        objSetupRepo._pb201SetupCtrlCUSTOMER(_01cCustomer)

        '------------------------------------------------------
        'TABLEMASTER..TABLE02
        'k02String = Kode Master
        'f01String = Nama Master
        'f02String = Kode GroupMaster
        'f03String = Nama GroupMaster
        '================================
        'With _02cTipeProduksi
        '    ._01prop_dtGEMINIMaster = pdtTABLEMASTER
        '    ._02prop_cGEMINIDaftarField = New String() {"k02String", "f01String", "f02String", "f03String"}
        '    ._03prop_cGEMINIFieldYgDiFilter = "f03String"
        '    ._04prop_cGEMINIValueKodeMasterYgDiFilter = "MERCHANDISE"
        '    ._05prop_cGEMINIFieldValueMember = "k02String"
        '    ._06prop_cGEMINIFieldDisplayMember = "f01String"
        'End With
        '_02cTipeProduksi._03BindingAwalDataSurce()
        '_02cTipeProduksi._04FilterDataViewMasterSKK()

        'With _03cSubTipeProduksi
        '    ._01prop_dtGEMINIMaster = pdtTABLEMASTER
        '    ._02prop_cGEMINIDaftarField = New String() {"k02String", "f01String", "f02String", "f03String"}
        '    ._03prop_cGEMINIFieldYgDiFilter = "f03String"
        '    ._04prop_cGEMINIValueKodeMasterYgDiFilter = "SUBMERCHANDISE"
        '    ._05prop_cGEMINIFieldValueMember = "k02String"
        '    ._06prop_cGEMINIFieldDisplayMember = "f01String"
        'End With
        '_03cSubTipeProduksi._03BindingAwalDataSurce()
        '_03cSubTipeProduksi._04FilterDataViewMasterSKK()
        objSetupRepo._pb10InitDataSourceMDMASTER(prop01User._UserProp07TargetNetwork)
        objSetupRepo._pb101SetupCtrlMERCHANDISE(_02cTipeProduksi)
        objSetupRepo._pb101SetupCtrlMERCHANDISE(_03cSubTipeProduksi)

        '------------------------------------------------------
        'With _04cDesignMaster
        '    ._01prop_dtGEMINIMaster = pdtMRPDESIGNMASTER
        '    ._02prop_cGEMINIDaftarField = New String() {"f02cKodeDesignMaster_v50", "f04cNamaItemProduct_v50"}
        '    ._05prop_cGEMINIFieldValueMember = "f02cKodeDesignMaster_v50"
        '    ._06prop_cGEMINIFieldDisplayMember = "f02cKodeDesignMaster_v50"
        'End With
        '_04cDesignMaster._03BindingAwalDataSurce()
        objSetupRepo._pb30InitDataSourceMRPMASTER(prop01User._UserProp07TargetNetwork)
        objSetupRepo._pb301SetupCtrlDESIGNMASTER(_04cDesignMaster)
    End Sub

    Private Sub _cm03BersihkanEntrian()
        _01cCustomer.EditValue = ""
        _02cTipeProduksi.EditValue = ""
        _03cSubTipeProduksi.EditValue = ""
        _04cDesignMaster.EditValue = ""

        _gdProductCode._pb02ClearGrid()
    End Sub

    Private Async Sub _cm04DisplayGrid()
        pdtProductOrder = Await objProductOrder._tr01MRP32OrderDESIGNMASTER_Async(prop01User._UserProp07TargetNetwork, _04cDesignMaster.EditValue)

        _gdProductCode._prop02pdtDataSourceGrid = Nothing
        _gdProductCode._prop02pdtDataSourceGrid = pdtProductOrder

        _gdProductCode._pb03DisplayGridTransaction()
    End Sub

    Private Function _cm05GetNumberDokumen() As String
        Dim pcNumberOrderMD As String = ""
        Dim objMaster As New clsGetDataMasterGEMINI()
        pcNumberOrderMD = objMaster._pb03IncNumberMaster(prop01User._UserProp07TargetNetwork, "MNORDERMD", "cNOMORDOKUMEN")

        Return pcNumberOrderMD
    End Function

    Private Function _cm06ProsesSimpanData() As Int32
        Dim pcNoDokumen As String = _cm05GetNumberDokumen()

        For Each dtRow As DataRow In pdtProductOrder.Rows
            dtRow("k05String") = pcNoDokumen

            'f24 = Tipeproduksi    ==> kode : f27
            dtRow("f24String") = _02cTipeProduksi.Text
            dtRow("f27String") = _02cTipeProduksi.EditValue

            'f25 = SubTipeProduksi ==> kode : f28
            dtRow("f25String") = _03cSubTipeProduksi.Text
            dtRow("f28String") = _03cSubTipeProduksi.EditValue

            'f26 = Customer ==> kode : f29
            dtRow("f26String") = _01cCustomer.Text
            dtRow("f29String") = _01cCustomer.EditValue

            dtRow("f01Date") = Today.Date
            dtRow("f02Date") = _05dEstDeliveryDate.EditValue
        Next
        pdtProductOrder.AcceptChanges()

        'f01Int = Qty
        'f01Double = Berat / pcs
        'f02Double = TotBerat

        Cursor.Current = Cursors.WaitCursor

        Return objProductOrder._tr01NasaExecDirectAllDB(prop01User._UserProp07TargetNetwork, _pnmDatabaseName.SBU,
                                                        2, "spTABLE50Save", "@tpTEMPLATEGEMINI", pdtProductOrder)

        Cursor.Current = Cursors.Default
    End Function

    Private Sub _cm07SimpanData()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar ... ?", vbYesNo + MsgBoxStyle.Question, prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            If _cm06ProsesSimpanData() > 0 Then
                MsgBox("Simpan Data ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, prop01User._UserProp01cTitle)
                _cm03BersihkanEntrian()
            Else
                MsgBox("Simpan Data ... GAGAL", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Simpan Data ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "control - event"

    Private Sub _02cTipeProduksi_EditValueChanged(sender As Object, e As EventArgs) Handles _02cTipeProduksi.EditValueChanged
        If Not String.IsNullOrEmpty(_02cTipeProduksi.EditValue) Then
            With _03cSubTipeProduksi
                ._03prop_cGEMINIFieldYgDiFilter = "f02String"
                ._04prop_cGEMINIValueKodeMasterYgDiFilter = _02cTipeProduksi.EditValue
            End With
            _03cSubTipeProduksi._04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _04cDesignMaster_EditValueChanged(sender As Object, e As EventArgs) Handles _04cDesignMaster.EditValueChanged
        If Not String.IsNullOrEmpty(_04cDesignMaster.EditValue) Then
            _cm04DisplayGrid()
        End If
    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm07SimpanData()

            Case 200  'Clear
                _cm03BersihkanEntrian()

        End Select
    End Sub

#End Region

End Class
