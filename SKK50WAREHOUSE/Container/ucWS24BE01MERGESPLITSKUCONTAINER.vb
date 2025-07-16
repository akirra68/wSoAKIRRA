Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGrid

Public Class ucWS24BE01MERGESPLITSKUCONTAINER
    Implements IDisposable

    Property _prop01User As clsWSNasaUser
    Property _prop02TargetMergeSplit As _TargetMergeSplitSKU
    Property _prop03DataPosterSKU As New DataTable
    Property _prop04GridMergeSplit As ucWSGrid
    Property _prop05TanggalTransaksi As Date

    Private objSettingCtrlSKU As ctrlWSNasaMasterSetting

    Private pcUniqRowWSSKUAsal As String
    Private pcKodeStorageBoxWSSKUAsal As String
    Private pcNamaStorageBoxWSSKUAsal As String
    Private pnIndexWSSKUAsal As Int16
    Private pcSINGLEMIXAsalwsSKU As String
    Private pdTglINBOUNDwsSKUAsal As Date

#Region "form - event"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objSettingCtrlSKU = New ctrlWSNasaMasterSetting With {._objSearchLookupEdit = _01cSKU,
                                                              ._objSearchLookupEditView = SearchLookUpEdit1View}

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ucWS24BE01MERGESPLITSKUCONTAINER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        _cm01BersihkanEntrian()
        _cm02VisibilityControl()
        _cm03InitControlSKU()
    End Sub

#End Region

#Region "custom - method"
    Public Enum _TargetMergeSplitSKU
        _MergeSKU = 0
        _SplitSKU = 1
    End Enum

    Private Sub _cm01BersihkanEntrian()
        _01cSKU.EditValue = ""
        _02nPcs.EditValue = 0
        _02nPcs._pb01SettingDisplay(0, True)

        _03nBerat.EditValue = 0.0
        _03nBerat._pb01SettingDisplay(2, True)

        _04nJumlahSplitSKU.EditValue = 0
        _lay04nJumlahSplitSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _05chkNoSKUParentTidakBerubah.CheckState = CheckState.Checked
        _lay05chkNoSKUParentTidakBerubah.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _layCaptionDataSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        pcUniqRowWSSKUAsal = ""
        pcKodeStorageBoxWSSKUAsal = ""
        pcNamaStorageBoxWSSKUAsal = ""
        pnIndexWSSKUAsal = 0
        pcSINGLEMIXAsalwsSKU = ""
        pdTglINBOUNDwsSKUAsal = "3000-01-01"

        _01cSKU.Focus()
    End Sub

    Private Sub _cm02VisibilityControl()
        _04nJumlahSplitSKU.EditValue = 0
        _lay04nJumlahSplitSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _05chkNoSKUParentTidakBerubah.CheckState = CheckState.Checked
        _lay05chkNoSKUParentTidakBerubah.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _layCaptionDataSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Select Case _prop02TargetMergeSplit
            Case _TargetMergeSplitSKU._MergeSKU
                _lay04nJumlahSplitSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _lay05chkNoSKUParentTidakBerubah.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                _layCaptionDataSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            Case _TargetMergeSplitSKU._SplitSKU
                _lay04nJumlahSplitSKU.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05chkNoSKUParentTidakBerubah.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _layCaptionDataSplit.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        End Select
    End Sub

    Private Sub _cm03InitControlSKU()
        Cursor = Cursors.WaitCursor

        With objSettingCtrlSKU
            ._01prop_dtWSMaster = _prop03DataPosterSKU
            ._02prop_cWSDaftarField = New String() {"k03String", "f09String", "f01SmallInt", "f01Double"}
            ._05prop_cWSFieldValueMember = "k03String"
            ._06prop_cWSFieldDisplayMember = "k03String"
            ._07prop_cWSKeyKolomFilterUntSelect = "k03String"
        End With
        objSettingCtrlSKU._pb01BindingAwalDataSource("k03String", "SKU", "f09String", "Box", "f01SmallInt", "Pcs", "f01Double", "Berat")

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm04FilterSKU()
        pcUniqRowWSSKUAsal = ""
        Dim pdrRows As DataRow()

        pdrRows = objSettingCtrlSKU._pb03GetRecordTerpilih()
        For Each dtRow As Object In pdrRows
            pcUniqRowWSSKUAsal = dtRow("k02String").ToString
            pcKodeStorageBoxWSSKUAsal = dtRow("f08String").ToString
            pcNamaStorageBoxWSSKUAsal = dtRow("f09String").ToString
            pnIndexWSSKUAsal = CInt(dtRow("f01TinyInt"))
            pcSINGLEMIXAsalwsSKU = dtRow("f18String").ToString
            pdTglINBOUNDwsSKUAsal = dtRow("f01Date")

            _02nPcs.EditValue = CInt(dtRow("f01SmallInt"))
            _03nBerat.EditValue = CDbl(dtRow("f01Double"))
        Next

        If _02nPcs.EditValue > 0 Then
            _04nJumlahSplitSKU._pb01SettingDisplay(0, False)
        End If

    End Sub

    Private Function _cm05SubmitMERGESKUDataToGrid() As DataTable
        Dim pdtData As New DataTable
        Dim objSmall As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtData}
        objSmall.dtInitsTABLESMALL()

        objSmall.dtAddNewsTABLESMALL(pcUniqRowWSSKUAsal, _01cSKU.EditValue, "",
            pcKodeStorageBoxWSSKUAsal, pcNamaStorageBoxWSSKUAsal, "MERGE", pcSINGLEMIXAsalwsSKU, "", "", "", "", "", "",
            pnIndexWSSKUAsal, _02nPcs.EditValue, 0,
            _03nBerat.EditValue, 0.0, 0.0,
            pdTglINBOUNDwsSKUAsal, "3000-01-01", "3000-01-01",
            Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
            _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

        Return objSmall.prop_dtsTABLESMALL
    End Function

    Private Function _cm06SubmitSPLITSKUDataToGrid() As DataTable
        Dim pdtData As New DataTable
        Dim objSmall As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtData}
        objSmall.dtInitsTABLESMALL()

        Dim pcSKUSplit As String = ""
        Dim objSKUSplit As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                     ._prop02String = "WSNEWSKUSPLIT"}

        Dim pnPcs As Integer = 0
        Dim pnBerat As Double = 0.0
        Dim pnIndexSKU As Int16 = 0
        Dim pdTglInboundFirst As Date = _prop05TanggalTransaksi
        For i = 1 To _04nJumlahSplitSKU.EditValue
            If i = 1 Then
                If _05chkNoSKUParentTidakBerubah.Checked Then
                    pcSKUSplit = _01cSKU.EditValue
                Else
                    pcSKUSplit = objSKUSplit._pb51GetDataIncNoDocWarehouse()
                End If

                pnPcs = _02nPcs.EditValue
                pnBerat = _03nBerat.EditValue
                pnIndexSKU = pnIndexWSSKUAsal
                pdTglInboundFirst = pdTglINBOUNDwsSKUAsal
            Else
                pnPcs = 0
                pnBerat = 0
                pnIndexSKU = 0
                pdTglInboundFirst = _prop05TanggalTransaksi

                pcSKUSplit = objSKUSplit._pb51GetDataIncNoDocWarehouse()
            End If

            objSmall.dtAddNewsTABLESMALL(pcUniqRowWSSKUAsal, _01cSKU.EditValue, pcSKUSplit,
                pcKodeStorageBoxWSSKUAsal, pcNamaStorageBoxWSSKUAsal, "SPLIT", pcSINGLEMIXAsalwsSKU, "", "", "", "", "", "",
                pnIndexSKU, pnPcs, 0,
                pnBerat, 0.0, 0.0,
                pdTglInboundFirst, _prop05TanggalTransaksi, "3000-01-01",
                Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
        Next

        Return objSmall.prop_dtsTABLESMALL
    End Function

    Private Sub _cm07SubmitMERGESPLITSKU()
        Dim objMergeSplit As __dlgTambahDataGrid = AddressOf _prop04GridMergeSplit._ivkAddNewDataGridMergeSplitSKU
        If _prop02TargetMergeSplit = _TargetMergeSplitSKU._MergeSKU Then
            objMergeSplit.Invoke(_cm05SubmitMERGESKUDataToGrid, "MERGE", _03nBerat.EditValue)
        Else
            If _prop02TargetMergeSplit = _TargetMergeSplitSKU._SplitSKU Then
                objMergeSplit.Invoke(_cm06SubmitSPLITSKUDataToGrid, "SPLIT", _03nBerat.EditValue)
            End If
        End If
    End Sub
#End Region

#Region "control - event"
    Private Sub _01cSKU_EditValueChanged(sender As Object, e As EventArgs) Handles _01cSKU.EditValueChanged
        If Not String.IsNullOrEmpty(_01cSKU.EditValue) Then
            _cm04FilterSKU()
            _cm02VisibilityControl()
        End If
    End Sub

    Private Sub _otblSubmit_Click(sender As Object, e As EventArgs) Handles _otblSubmit.Click
        Dim pcPesan As String = ""
        If _prop02TargetMergeSplit = _TargetMergeSplitSKU._MergeSKU Then
            pcPesan = "MERGE"
        Else
            If _prop02TargetMergeSplit = _TargetMergeSplitSKU._SplitSKU Then
                pcPesan = "SPLIT"
            End If
        End If

        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar unt proses " & pcPesan & " Data ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor

            _cm07SubmitMERGESPLITSKU()
            Cursor = Cursors.Default

            MsgBox("Submit " & pcPesan & " Data ke grid ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            _cm01BersihkanEntrian()
        Else
            MsgBox("Maaf ... Submit " & pcPesan & " Data ke grid ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    Private Sub _otblClear_Click(sender As Object, e As EventArgs) Handles _otblClear.Click
        _cm01BersihkanEntrian()
    End Sub

#End Region

End Class
