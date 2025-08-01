Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucWS24BE01MERGESPLITSKU
    Implements IDisposable

    Public Property _prop01User As clsWSNasaUser

    Private objContainer As PopupContainerControl
    Private objUserControl As XtraUserControl

    Private pcKodeSLocAsalHanya1 As String = ""

    Private pdtGrid As DataTable
    Private objTemplateGrid As clsWSNasaTemplateDataLarge

    Private pdtMedium As DataTable
    Private objSaveTable18 As clsWSNasaTemplateDataMedium

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objContainer = New PopupContainerControl
        objUserControl = New XtraUserControl With {.Dock = DockStyle.Fill}

        pdtGrid = New DataTable
        objTemplateGrid = New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtGrid}
        objTemplateGrid.dtInitsTABLELARGE()

        pdtMedium = New DataTable
        objSaveTable18 = New clsWSNasaTemplateDataMedium With {.prop_dtsTABLEMEDIUM = pdtMedium}
        objSaveTable18.dtInitsTABLEMEDIUM()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objContainer.Dispose()
        objUserControl.Dispose()

        pdtGrid.Dispose()
        objTemplateGrid.Dispose()
    End Sub

    Private Sub ucWS24BE01MERGESPLITSKU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        objContainer.Controls.Add(objUserControl)

        _cm02BersihkanEntrian()
        _cm03InitCtrlSLocAsal()
        _cm04InitCtrlTargetSBox()
        _cm05InitCtrlTargetTransaksi()

        _cm01InitGridMergeSplitSKU()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01InitGridMergeSplitSKU()
        With _gdMergeSplitSKU
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSMergeSplitSKU
            ._prop03pdtDataSourceGrid = objTemplateGrid.prop_dtsTABLELARGE
        End With
        _gdMergeSplitSKU.__pbWSGrid01InitGrid()
        _gdMergeSplitSKU.__pbWSGrid03DisplayGrid()
    End Sub

    Private Sub _cm02BersihkanEntrian()
        _01cKodeAsalSLoc.EditValue = ""
        _01cKodeAsalSLoc.Properties.ReadOnly = False

        _02cKodeTargetTransaksi.EditValue = ""
        _03cKeterangan.EditValue = ""
        _04dTanggalTransaksi.EditValue = Today.Date
        _06cKodeStorageBox.EditValue = ""

        pcKodeSLocAsalHanya1 = ""

        _gdMergeSplitSKU.__pbWSGrid02ClearGrid()

        _01cKodeAsalSLoc.Focus()
    End Sub

    Private Sub _cm03InitCtrlSLocAsal()
        Cursor = Cursors.WaitCursor

        Dim objSLoc As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtSLoc As New DataTable
        If _prop01User._UserProp09IsRootUser Then
            pdtSLoc = objSLoc.__pb02GetDataTable21TargetWarehouseByUser("5040", "50401")
            'pdtSLoc = objSLoc.__pb03GetDataTable21TargetWarehouseByGroup("5040", "50401")
        Else
            pdtSLoc = objSLoc.__pb02GetDataTable21TargetWarehouseByUser("5040", "50401")
        End If

        If pdtSLoc.Rows.Count > 0 Then
            With _01cKodeAsalSLoc
                ._prop01WSDataSource = pdtSLoc
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _01cKodeAsalSLoc._pb01BindingAwalDataSource2Field("Code", "Target")

            If pdtSLoc.Rows.Count = 1 Then
                For Each dtRow As DataRow In pdtSLoc.Rows
                    pcKodeSLocAsalHanya1 = dtRow("f05String").ToString
                Next

                _01cKodeAsalSLoc.EditValue = pcKodeSLocAsalHanya1
                _01cKodeAsalSLoc.Properties.ReadOnly = True
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm04InitCtrlTargetSBox()
        Cursor = Cursors.WaitCursor
        Dim pdtMaster As New DataTable
        Dim objclsMaster As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}
        pdtMaster = objclsMaster.__pb01GetDataMasterWarehouseBerdasarkanGroup("SBOX")

        If pdtMaster.Rows.Count > 0 Then
            With _06cKodeStorageBox
                ._prop01WSDataSource = pdtMaster
                ._prop02WSDaftarField = New String() {"k13String", "k14String"}
                ._prop05WSFieldValueMember = "k13String"
                ._prop06WSFieldDisplayMember = "k14String"
            End With
            _06cKodeStorageBox._pb01BindingAwalDataSource2Field("Code", "Box")

        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm05InitCtrlTargetTransaksi()
        Cursor = Cursors.WaitCursor

        Dim objTargetMutasi As New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtTargetMutasi As New DataTable
        pdtTargetMutasi = objTargetMutasi.__pb02GetDataTable21TargetWarehouseByUser("5010")

        If pdtTargetMutasi.Rows.Count > 0 Then
            With _02cKodeTargetTransaksi
                ._prop01WSDataSource = pdtTargetMutasi
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _02cKodeTargetTransaksi._pb01BindingAwalDataSource2Field("Code", "Target")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function _cm06GetDataPosterOSTBySLoc() As DataTable
        Cursor = Cursors.WaitCursor

        Dim pdtHasil As New DataTable
        Using objNasa = New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtHasil = objNasa._pb03GetDataPosterSKUBySLoc(_01cKodeAsalSLoc.EditValue)
        End Using

        Cursor = Cursors.Default

        Return pdtHasil
    End Function

    Private Sub _cm07InitContentMergeSplitSKU()
        Cursor = Cursors.WaitCursor

        Dim pdtPosterSKU As New DataTable
        pdtPosterSKU = _cm06GetDataPosterOSTBySLoc()

        If pdtPosterSKU.Rows.Count > 0 Then
            Dim objMERGESPLITSKU As New ucWS24BE01MERGESPLITSKUCONTAINER With {
                                            ._prop01User = _prop01User,
                                            ._prop03DataPosterSKU = pdtPosterSKU,
                                            ._prop04GridMergeSplit = _gdMergeSplitSKU,
                                            ._prop05TanggalTransaksi = _04dTanggalTransaksi.EditValue}

            If _02cKodeTargetTransaksi.EditValue = "50101" Then        'MergeSKU
                objMERGESPLITSKU._prop02TargetMergeSplit = ucWS24BE01MERGESPLITSKUCONTAINER._TargetMergeSplitSKU._MergeSKU
            Else
                If _02cKodeTargetTransaksi.EditValue = "50102" Then    'SplitSKU
                    objMERGESPLITSKU._prop02TargetMergeSplit = ucWS24BE01MERGESPLITSKUCONTAINER._TargetMergeSplitSKU._SplitSKU
                End If
            End If

            Dim objSize As New Size With {.Width = objMERGESPLITSKU.Size.Width,
                                          .Height = objMERGESPLITSKU.Size.Height}
            objContainer.Size = objSize
            objUserControl.Size = objSize

            objUserControl.Controls.Clear()
            objUserControl.Controls.Add(objMERGESPLITSKU)

            _05objContent.Properties.PopupControl = objContainer
        Else
            Cursor = Cursors.Default

            MsgBox("Maaf ... List SKU tidak ditemukan ...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)

            _02cKodeTargetTransaksi.EditValue = ""
            _01cKodeAsalSLoc.EditValue = ""
            _01cKodeAsalSLoc.Focus()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function _cm08PrepareSaveDataMergeSplitSKU(ByVal prmcNoDocMergeSplitSKU As String, ByVal prmcNewSKUMerge As String) As DataTable
        objSaveTable18.prop_dtsTABLEMEDIUM.Clear()

        Dim pcNote As String = ""
        If Not String.IsNullOrEmpty(_03cKeterangan.EditValue) Then
            If _03cKeterangan.EditValue.ToString.Length > 49 Then
                pcNote = _03cKeterangan.EditValue.ToString.Substring(0, 48)
            Else
                pcNote = _03cKeterangan.EditValue.ToString
            End If
        End If

        Dim pcNewSKU As String = ""
        For Each dtRow As DataRow In _gdMergeSplitSKU._prop03pdtDataSourceGrid.Rows
            If _02cKodeTargetTransaksi.EditValue = "50101" Then        'MergeSKU
                pcNewSKU = prmcNewSKUMerge
            Else
                If _02cKodeTargetTransaksi.EditValue = "50102" Then    'SplitSKU
                    pcNewSKU = dtRow("k02String").ToString
                End If
            End If

            objSaveTable18.dtAddNewsTABLEMEDIUM(
                "", pcNewSKU, dtRow("k03String"),
                dtRow("k01String"), prmcNoDocMergeSplitSKU, dtRow("f01String"), dtRow("f08String"), dtRow("f09String"),
                dtRow("f10String"), _01cKodeAsalSLoc.EditValue, _01cKodeAsalSLoc.Text, "", pcNote,
                _06cKodeStorageBox.EditValue, _06cKodeStorageBox.Text, "", "", "", "", "", "", "", "",
                dtRow("f01TinyInt"), dtRow("f01SmallInt"), dtRow("f01Int"),
                dtRow("f01Double"), dtRow("f02Double"), 0.0,
                dtRow("f01Date"), _04dTanggalTransaksi.EditValue, "3000-01-01",
                Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
        Next

        Return objSaveTable18.prop_dtsTABLEMEDIUM
    End Function

    Private Sub _cm09ProsesSave()
        Dim pcSKUMerge As String = ""
        If _02cKodeTargetTransaksi.EditValue = "50101" Then        'MergeSKU
            Using objSKUSplit = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                         ._prop02String = "WSNEWSKUMERGE"}
                pcSKUMerge = objSKUSplit._pb51GetDataIncNoDocWarehouse()
            End Using
        End If

        Dim pcNoDocMergeSplitSKU As String = ""
        Using objNoDocMergeSplit = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                            ._prop02String = "WSNODOCMERGESPLIT"}
            pcNoDocMergeSplitSKU = objNoDocMergeSplit._pb51GetDataIncNoDocWarehouse()
        End Using

        Dim pdtTable18 As New DataTable
        pdtTable18 = _cm08PrepareSaveDataMergeSplitSKU(pcNoDocMergeSplitSKU, pcSKUMerge)

        If pdtTable18.Rows.Count > 0 Then
            Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar unt proses SIMPAN Data ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

            If plYes = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim objNasa As New clsWSNasaHelper
                Dim pnJmlRec As Integer = 0
                pnJmlRec = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                    _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                                    2, "spWSTABLE18ProsesSave", "@tpDataForSaving", pdtTable18)

                Cursor = Cursors.Default

                MsgBox("Proses Simpan Data ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
                _cm02BersihkanEntrian()
            Else
                MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If

        End If

    End Sub

#End Region

#Region "control - event"
    Private Sub _02cKodeTargetTransaksi_EditValueChanged(sender As Object, e As EventArgs) Handles _02cKodeTargetTransaksi.EditValueChanged

        If Not String.IsNullOrEmpty(_01cKodeAsalSLoc.EditValue) _
           And Not String.IsNullOrEmpty(_02cKodeTargetTransaksi.EditValue) Then
            _cm07InitContentMergeSplitSKU()
        End If

    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        Dim tags As Int16 = CInt(CType(e.Button, WindowsUIButton).Tag)

        Select Case tags
            Case 100  'Save
                _cm09ProsesSave()

            Case 200  'Clear
                _cm02BersihkanEntrian()
        End Select
    End Sub
#End Region

End Class