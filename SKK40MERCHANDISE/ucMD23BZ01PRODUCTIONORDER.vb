Imports SKK02OBJECTS

Public Class ucMD23BZ01PRODUCTIONORDER
    Implements IDisposable

    Property prop01User As clsUserGEMINI

    Private objControl As clsSetupRepository

    Private objDataSet As DataSet
    Private objTipeProduksi As ctrlGEMINIMasterSetting

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        objControl = New clsSetupRepository
        objDataSet = New DataSet

        objTipeProduksi = New ctrlGEMINIMasterSetting With {._objSearchLookupEdit = _01cTipeProduksiNew,
                                                            ._objSearchLookupEditView = SearchLookUpEdit1View}

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objControl.Dispose()

        objDataSet.Dispose()
    End Sub

    Private Sub ucMD23BZ01PRODUCTIONORDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(prop01User._UserProp10Skin)

        _02dTglProductionOrder.EditValue = Today.Date
        _cm01InitControl()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01InitControl()
        objControl._pb10InitDataSourceMDMASTER(prop01User._UserProp07TargetNetwork)

        Dim objGetDataMaster As New clsGetDataMasterGEMINI
        Dim pdtMaster As New DataTable
        pdtMaster = objGetDataMaster._pb02GetDataTIPEMERCHANDISE(prop01User._UserProp07TargetNetwork)
        _gdProductionOrder._pb01InitGrid()

        With objTipeProduksi
            ._01prop_dtGEMINIMaster = pdtMaster
            ._02prop_cGEMINIDaftarField = New String() {"k02String", "f01String", "f02String", "f03String"}
            ._03prop_cGEMINIFieldYgDiFilter = "f03String"
            ._04prop_cGEMINIValueKodeMasterYgDiFilter = "MERCHANDISE"
            ._05prop_cGEMINIFieldValueMember = "k02String"
            ._06prop_cGEMINIFieldDisplayMember = "f01String"
        End With
        objTipeProduksi._03BindingAwalDataSource2Field()
        objTipeProduksi._04FilterDataViewMasterSKK()
    End Sub

    Private Sub _cm02BersihkanEntrian()
        _01cTipeProduksiNew.EditValue = ""
        _gdProductionOrder._pb02ClearGrid()
    End Sub

    Private Sub _cm03ProsesSimpan()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar ... ?", vbYesNo + MsgBoxStyle.Question, prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            If _gdProductionOrder._pb04SaveTransaction() > 0 Then
                MsgBox("Simpan Data ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, prop01User._UserProp01cTitle)
                _cm02BersihkanEntrian()
            Else
                MsgBox("Simpan Data ... GAGAL", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Simpan Data ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
        End If
    End Sub

#End Region

#Region "control - event"

    Private Sub _otblSave_Click(sender As Object, e As EventArgs) Handles _otblSave.Click
        If Not String.IsNullOrEmpty(_01cTipeProduksiNew.EditValue) Then
            _cm03ProsesSimpan()
        End If
    End Sub

    Private Sub _otblClear_Click(sender As Object, e As EventArgs) Handles _otblClear.Click
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin membersihkan entrian data ini ... ?", vbYesNo + MsgBoxStyle.Question, prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm02BersihkanEntrian()
        Else
            MsgBox("Bersihkan Entrian Data ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _01cTipeProduksiNew_EditValueChanged(sender As Object, e As EventArgs) Handles _01cTipeProduksiNew.EditValueChanged
        If Not String.IsNullOrEmpty(_01cTipeProduksiNew.EditValue) Then

            _gdProductionOrder._prop01User = prop01User
            _gdProductionOrder._prop01TargetTransaksi = ucGridTransactionParentChild.TargetTransaksi._01MD23BZ01PRODUCTIONORDER
            _gdProductionOrder._prop10String = _01cTipeProduksiNew.EditValue
            _gdProductionOrder._pb01InitGrid()

            objDataSet.Clear()
            objDataSet = _gdProductionOrder._pb03DisplayGridTransaction()
        End If
    End Sub

#End Region

End Class
