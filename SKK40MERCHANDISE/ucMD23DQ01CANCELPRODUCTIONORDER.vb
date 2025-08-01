Imports SKK02OBJECTS
Imports SKK02OBJECTS.clsGetDataProsesTransaksiGEMINI

Public Class ucMD23DQ01CANCELPRODUCTIONORDER
    Implements IDisposable

    Property prop01User As clsUserGEMINI

    Private objProses As clsGetDataProsesTransaksiGEMINI

    Private pdtDataCancelPO As DataTable

#Region "event - form"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objProses = New clsGetDataProsesTransaksiGEMINI

        pdtDataCancelPO = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objProses.Dispose()

        pdtDataCancelPO.Dispose()
    End Sub

    Private Sub ucMD23DQ01CANCELPRODUCTIONORDER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(prop01User._UserProp10Skin)

        _cm01InitControl()
        _cm02BersihkanEntrian()
    End Sub

#End Region

#Region "method - custom"

    Private Sub _cm01InitControl()
        Dim objSetupRepo As New clsSetupRepository

        objSetupRepo._pb40InitDataSourceSBUTRANSAKSI(prop01User._UserProp07TargetNetwork)
        objSetupRepo._pb401SetupCtrlPO(_01cKodeProductionOrder)

        _gdPOBatal._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER
        _gdPOBatal._pb01InitGrid()
    End Sub

    Private Sub _cm02BersihkanEntrian()
        _01cKodeProductionOrder.EditValue = ""
        _02cAlasanBatal.EditValue = ""

        _gdPOBatal._pb02ClearGrid()
    End Sub

    Private Sub _cm03DisplayDataPO2Cancel()
        Dim pdtPrepareDataPOCancel As New DataTable
        Dim objGetData As New clsGetDataProsesTransaksiGEMINI
        pdtPrepareDataPOCancel = objGetData._pbsy01PrepareDataPOCancel(prop01User._UserProp07TargetNetwork, _01cKodeProductionOrder.EditValue) '

        With _gdPOBatal
            ._prop01TargetTransaksi = ucGridTransaction.TargetTransaksi._03MD23DQ01CANCELPRODUCTIONORDER
            ._prop02pdtDataSourceGrid = pdtPrepareDataPOCancel
        End With

        _gdPOBatal._pb02ClearGrid()
        _gdPOBatal._pb03DisplayGridTransaction()

    End Sub

    Private Function _cm04GetNumberDokumen() As String
        Dim pcNumberOrderMD As String = ""
        Dim objMaster As New clsGetDataMasterGEMINI()
        pcNumberOrderMD = objMaster._pb03IncNumberMaster(prop01User._UserProp07TargetNetwork, "MNBATALPOMD", "cNOMORDOKUMEN")

        Return pcNumberOrderMD
    End Function

    Private Function _cm05ProsesSimpanDataBatalPO() As Int32
        Cursor.Current = Cursors.WaitCursor

        Dim pcNoDokumen As String = _cm04GetNumberDokumen()

        Dim pdtDataBatalPO As New DataTable
        pdtDataBatalPO = _gdPOBatal._pb05GetDataMD23DQ01CANCELPRODUCTIONORDER(prop01User._UserProp02cUserID,
                                                                              prop01User._UserProp03cUserName,
                                                                              _02cAlasanBatal.Text,
                                                                              pcNoDokumen)

        Return objProses._tr01NasaExecDirectAllDB(prop01User._UserProp07TargetNetwork, _pnmDatabaseName.SBU,
                                                  2, "spTABLE52Save", "@tpTEMPLATEGEMINI", pdtDataBatalPO)

        Cursor.Current = Cursors.Default
    End Function

    Private Sub _cm06SimpanDataBatalPO()
        If String.IsNullOrEmpty(_02cAlasanBatal.EditValue) Then
            MsgBox("Maaf ... ALASAN BATAL harus diisi ...", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, prop01User._UserProp01cTitle)
        Else
            Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar ... ?", vbYesNo + MsgBoxStyle.Question, prop01User._UserProp01cTitle)

            If plYes = MsgBoxResult.Yes Then
                If _cm05ProsesSimpanDataBatalPO() > 0 Then
                    MsgBox("Simpan Data ... BERHASIL", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, prop01User._UserProp01cTitle)
                    _cm02BersihkanEntrian()
                Else
                    MsgBox("Simpan Data ... GAGAL", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
                End If
            Else
                MsgBox("Simpan Data ... DIBATALKAN", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, prop01User._UserProp01cTitle)
            End If
        End If

    End Sub

#End Region

#Region "event - control"
    Private Sub _01cKodeProductionOrder_EditValueChanged(sender As Object, e As EventArgs) Handles _01cKodeProductionOrder.EditValueChanged
        If Not String.IsNullOrEmpty(_01cKodeProductionOrder.EditValue) Then
            _cm03DisplayDataPO2Cancel()
        End If
    End Sub

    Private Sub _otblProsesBatal_Click(sender As Object, e As EventArgs) Handles _otblProsesBatal.Click
        _cm06SimpanDataBatalPO()
    End Sub
#End Region

End Class
