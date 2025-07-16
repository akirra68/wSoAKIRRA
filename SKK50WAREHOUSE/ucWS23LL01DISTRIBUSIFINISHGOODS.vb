Imports System.Drawing.Drawing2D
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports SKK01CORE
Imports SKK02OBJECTS
Imports SKK02OBJECTS.ucWSGrid

Public Class ucWS23LL01DISTRIBUSIFINISHGOODS
    Implements IDisposable
    Implements clsRefreshTab

    Public Property _prop01User As clsWSNasaUser

    'Private objContainer As PopupContainerControl
    'Private objUserControl As XtraUserControl

    Private pdtKepada As DataTable
    Private pdtKAEMarketingPickerPameran As DataTable
    Private pdtCustomerConsignment As DataTable

    Private pdtPKB25SKU As DataTable
    Private objPKB25SKU As clsWSNasaTemplateDataLarge

    Private pdtPKB33PRODUCTCODE As DataTable
    Private objPKB33PRODUCTCODE As clsWSNasaTemplateDataMediumPlus

    Private pdtPKBMERCHANDISE As DataTable
    Private objPKBMERCHANDISE As clsWSNasaTemplateDataTiny

    Private objContainer As PopupContainerControl
    Private objUserControl As XtraUserControl

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'objContainer = New PopupContainerControl
        'objUserControl = New XtraUserControl With {.Dock = DockStyle.Fill}

        pdtKepada = New DataTable
        pdtKAEMarketingPickerPameran = New DataTable
        pdtCustomerConsignment = New DataTable

        pdtPKB25SKU = New DataTable
        objPKB25SKU = New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtPKB25SKU}
        objPKB25SKU.dtInitsTABLELARGE()

        pdtPKB33PRODUCTCODE = New DataTable
        objPKB33PRODUCTCODE = New clsWSNasaTemplateDataMediumPlus With {.prop_dtsTABLEMEDIUMPLUS = pdtPKB33PRODUCTCODE}
        objPKB33PRODUCTCODE.dtInitsTABLEMEDIUMPLUSPLUS()

        pdtPKBMERCHANDISE = New DataTable
        objPKBMERCHANDISE = New clsWSNasaTemplateDataTiny With {.prop_dtsTABLETINY = pdtPKBMERCHANDISE}
        objPKBMERCHANDISE.dtInitsTABLETINY()

        objContainer = New PopupContainerControl
        objUserControl = New XtraUserControl With {.Dock = DockStyle.Fill}

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        'objContainer.Dispose()
        'objUserControl.Dispose()

        pdtKepada.Dispose()
        pdtKAEMarketingPickerPameran.Dispose()
        pdtCustomerConsignment.Dispose()

        pdtPKB25SKU.Dispose()
        objPKB25SKU.Dispose()

        pdtPKB33PRODUCTCODE.Dispose()
        objPKB33PRODUCTCODE.Dispose()

        pdtPKBMERCHANDISE.Dispose()
        objPKBMERCHANDISE.Dispose()

        objContainer.Dispose()
        objUserControl.Dispose()

        Me.Dispose()
    End Sub

    Private Sub ucWS23LL01DISTRIBUSIBARANG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        'With _gdPKB
        '    ._prop01User = _prop01User
        '    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSDistribusiFGPKB
        'End With
        '_gdPKB.__pbWSGrid01InitGrid()

        'objContainer.Controls.Add(objUserControl)

        '***** jangan diubah urutannya *****
        _cm01InitControlTargetTransaksi()
        _cm02GetDataIndukKepada()
        _cm04InitControlKAE()
        _cm05InitControlTOP()
        '***********************************

        _cm10VisibilityControl()

        '_layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        Cursor = Cursor.Current

    End Sub

    Public Sub RefreshData() Implements clsRefreshTab.RefreshTab
        _cm00RefreshGrid()
    End Sub

#End Region

#Region "custom - method"

    Private Sub _cm01InitControlTargetTransaksi()
        Dim objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster
        objTargetTransaksi = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtTargetTransaksi As New DataTable
        If _prop01User._UserProp09IsRootUser Then
            pdtTargetTransaksi = objTargetTransaksi.__pb02GetDataTable21TargetWarehouseByUser("506")
            'pdtTargetTransaksi = objTargetTransaksi.__pb03GetDataTable21TargetWarehouseByGroup("506")
        Else
            pdtTargetTransaksi = objTargetTransaksi.__pb02GetDataTable21TargetWarehouseByUser("506")
        End If

        If pdtTargetTransaksi.Rows.Count > 0 Then
            _01cTargetTransaksi.Properties.DataSource = Nothing
            With _01cTargetTransaksi
                ._prop01WSDataSource = pdtTargetTransaksi
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _01cTargetTransaksi._pb01BindingAwalDataSource2Field("CODE", "TARGET", 0, 270)
        End If
    End Sub

    Private Sub _cm02GetDataIndukKepada()
        'Hanya sekali dipanggil yaitu pada "LOAD" event
        Dim objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster
        objTargetTransaksi = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        pdtCustomerConsignment = objTargetTransaksi.__pb04GetDataTable52Customer()
        pdtKAEMarketingPickerPameran = objTargetTransaksi.__pb02GetDataTable21TargetWarehouseByUser("5040")
        'pdtKAEMarketingPickerPameran = objTargetTransaksi.__pb03GetDataTable21TargetWarehouseByGroup("5040")
    End Sub

    '***********************************
    '***** NOT USED ********************
    '***********************************
    'Private Sub _cm03InitControlKepada(ByVal prmcTarget As String)
    '    _02cKepada.Properties.DataSource = Nothing

    '    If prmcTarget = "KAE" Or prmcTarget = "MARKETING" Then

    '        Dim pdtKAEMARKETINGCopy As New DataTable
    '        pdtKAEMARKETINGCopy = pdtKAEMarketing.Copy()

    '        Dim pdtRow() As DataRow
    '        pdtRow = Nothing

    '        If prmcTarget = "KAE" Then
    '            pdtRow = pdtKAEMARKETINGCopy.Select(" f01Int = 50402")
    '        Else
    '            If prmcTarget = "MARKETING" Then
    '                pdtRow = pdtKAEMARKETINGCopy.Select(" f01Int = 50404")
    '            End If
    '        End If

    '        pdtKepada.Clear()
    '        pdtKepada = pdtRow.CopyToDataTable

    '        With _02cKepada
    '            ._prop01WSDataSource = pdtKepada
    '            ._prop02WSDaftarField = New String() {"f05String", "f06String"}
    '            ._prop05WSFieldValueMember = "f05String"
    '            ._prop06WSFieldDisplayMember = "f06String"
    '        End With
    '        _02cKepada._pb01BindingAwalDataSource2Field("Code", "Key Account Executive")

    '    Else
    '        If prmcTarget = "CUSTOMER" Or prmcTarget = "CONSIGNMENT" Then

    '            With _02cKepada
    '                ._prop01WSDataSource = pdtCustomerConsignment
    '                ._prop02WSDaftarField = New String() {"k02String", "k03String", "f39String"}
    '                ._prop05WSFieldValueMember = "k02String"
    '                ._prop06WSFieldDisplayMember = "k03String"
    '            End With
    '            _02cKepada._pb02BindingAwalDataSource3Field("k02String", "Code", "k03String", "Customer", "f39String", "Alamat")

    '        End If
    '    End If
    'End Sub
    '***********************************
    '***** NOT USED ********************
    '***********************************

    Private Sub _cm03InitControlKepada(ByVal prmcTarget As String)
        Cursor = Cursors.WaitCursor

        _02cKepada.Properties.DataSource = Nothing

        If prmcTarget = "KAE" Or prmcTarget = "MARKETING" Then
            _cm031InitKepadaKAEMarketing(prmcTarget)

        ElseIf prmcTarget = "APVFA" Then
            _cmf034InitFilterJenisOrderApproval()
            _cmf035InitFilterCustomerApproval()
            _cmf036InitStatusApproval("FIN")

        ElseIf prmcTarget = "APVSALES" Then
            _cmf034InitFilterJenisOrderApproval()
            _cmf035InitFilterCustomerApproval()
            _cmf036InitStatusApproval("SLS")

        ElseIf prmcTarget = "CUSTOMER" Then
            _cm032InitKepadaCustConsignInternal(prmcTarget)
            _cm04InitControlKAE()
            _cm05InitControlTOP()

        ElseIf prmcTarget = "CONSIGNMENT" Then
            _cm032InitKepadaCustConsignInternal(prmcTarget)
            _cm04InitControlKAE()

        ElseIf prmcTarget = "INTERNAL" Then
            _cm032InitKepadaCustConsignInternal(prmcTarget)

        ElseIf prmcTarget = "PAMERAN" Then
            _cm033InitKepadaPameran(prmcTarget)

        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm031InitKepadaKAEMarketing(ByVal prmcTarget As String)
        Dim pdtKAEMARKETINGCopy As New DataTable
        pdtKAEMARKETINGCopy = pdtKAEMarketingPickerPameran.Copy()

        'Dim pdtRow() As DataRow
        'pdtRow = Nothing

        'If prmcTarget = "KAE" Then
        '    pdtRow = pdtKAEMARKETINGCopy.Select(" f01Int = 50402")
        'Else
        '    If prmcTarget = "MARKETING" Then
        '        pdtRow = pdtKAEMARKETINGCopy.Select(" f01Int = 50404")
        '    End If
        'End If

        ' ===================== CREATED BY AKIRRA - 25/06/02 =====================
        ' melakukan sort by f06String ASC (nama KAE/MKT).
        Dim dvKaeMkt As New DataView(pdtKAEMARKETINGCopy)

        If prmcTarget = "KAE" Then
            dvKaeMkt.RowFilter = "f01Int = 50402"
        ElseIf prmcTarget = "MARKETING" Then
            dvKaeMkt.RowFilter = "f01Int = 50404"
        End If

        dvKaeMkt.Sort = "f06String ASC, f05String ASC"
        ' =========================================================================

        pdtKepada.Clear()
        pdtKepada = dvKaeMkt.ToTable

        With _02cKepada
            ._prop01WSDataSource = pdtKepada
            ._prop02WSDaftarField = New String() {"f05String", "f06String"}
            ._prop05WSFieldValueMember = "f05String"
            ._prop06WSFieldDisplayMember = "f06String"
        End With
        _02cKepada._pb01BindingAwalDataSource2Field("CODE", prmcTarget, 0, 270)
    End Sub

    Private Sub _cm032InitKepadaCustConsignInternal(ByVal prmcTarget As String)
        Dim pdtCustomerCopy As New DataTable

        pdtCustomerCopy = pdtCustomerConsignment.Copy()

        'Dim pdtRowCustomer() As DataRow
        'pdtRowCustomer = Nothing

        'If prmcTarget = "CUSTOMER" Or prmcTarget = "CONSIGNMENT" Then
        '    pdtRowCustomer = pdtCustomerCopy.Select(" f01String <> 'INTERNAL'")
        'Else
        '    If prmcTarget = "INTERNAL" Then
        '        pdtRowCustomer = pdtCustomerCopy.Select(" f01String = 'INTERNAL'")
        '    End If
        'End If

        ' ===================== CREATED BY AKIRRA - 25/06/02 =====================
        ' melakukan sort by k03String ASC (nama customer).
        Dim dvCust As New DataView(pdtCustomerCopy)

        If prmcTarget = "CUSTOMER" Or prmcTarget = "CONSIGNMENT" Then
            dvCust.RowFilter = "f01String <> 'INTERNAL'"
        ElseIf prmcTarget = "INTERNAL" Then
            dvCust.RowFilter = "f01String = 'INTERNAL'"
        End If

        dvCust.Sort = "f02String ASC, k02String ASC"
        ' =========================================================================

        pdtKepada.Clear()
        pdtKepada = dvCust.ToTable

        With _02cKepada
            ._prop01WSDataSource = pdtKepada
            ._prop02WSDaftarField = New String() {"k02String", "k03String", "f02String", "f39String"}
            ._prop05WSFieldValueMember = "k02String"
            ._prop06WSFieldDisplayMember = "k03String"
        End With
        _02cKepada._pb03BindingAwalDataSource4Field("k02String", "CODE", "k03String", prmcTarget, "f02String", "NAME", "f39String", "ADDRESS",
                                                    85, 190, 190, 300)

    End Sub

    Private Sub _cm033InitKepadaPameran(ByVal prmcTarget As String)
        Dim pdtPameranCopy As New DataTable
        pdtPameranCopy = pdtKAEMarketingPickerPameran.Copy()

        Dim pdtRow() As DataRow
        pdtRow = Nothing

        pdtRow = pdtPameranCopy.Select(" f01Int = 50405 and f10String = 'OPEN' ")

        Dim pdtKpdPameran As New DataTable
        pdtKpdPameran = pdtRow.CopyToDataTable

        With _02cKepada
            ._prop01WSDataSource = pdtKpdPameran
            ._prop02WSDaftarField = New String() {"f05String", "f06String"}
            ._prop05WSFieldValueMember = "f05String"
            ._prop06WSFieldDisplayMember = "f06String"
        End With
        _02cKepada._pb01BindingAwalDataSource2Field("CODE", prmcTarget, 0, 270)
    End Sub

    Private Sub _cmf034InitFilterJenisOrderApproval()
        Dim _oWsGetDtForRepo As New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}

        Dim vdtJenisOrder As DataTable = _oWsGetDtForRepo._pbf10GetDataForFilterJenisOrderApproval()

        If vdtJenisOrder.Rows.Count > 0 Then
            _02cKepada.Properties.DataSource = Nothing
            With _02cKepada
                ._prop01WSDataSource = vdtJenisOrder
                ._prop02WSDaftarField = New String() {"f22String", "f23String"}
                ._prop05WSFieldValueMember = "f22String"
                ._prop06WSFieldDisplayMember = "f23String"
            End With
            _02cKepada._pb01BindingAwalDataSource2Field("CODE", "JENIS ORDER", 0, 270)
        End If
    End Sub

    Private Sub _cmf035InitFilterCustomerApproval()
        Dim _oWsGetDtForRepo2 As New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}

        Dim vdtCustomer As DataTable = _oWsGetDtForRepo2._pbf11GetDataForFilterCustomerApproval()

        If vdtCustomer.Rows.Count > 0 Then
            _03cKAE.Properties.DataSource = Nothing
            With _03cKAE
                ._prop01WSDataSource = vdtCustomer
                ._prop02WSDaftarField = New String() {"f14String", "f15String"}
                ._prop05WSFieldValueMember = "f14String"
                ._prop06WSFieldDisplayMember = "f15String"
            End With
            _03cKAE._pb01BindingAwalDataSource2Field("CODE", "CUSTOMER", 0, 270)
        End If
    End Sub

    Private Sub _cmf036InitStatusApproval(ByVal vsTarget As String)
        Dim vdtStatus As New DataTable()
        vdtStatus.Columns.Add("Status", GetType(String))

        vdtStatus.Rows.Add("APPROVE")
        vdtStatus.Rows.Add("REJECT")
        If vsTarget = "FIN" Then
            vdtStatus.Rows.Add("PENDING")
        End If

        _04cTOP.Properties.DataSource = Nothing
        With _04cTOP
            ._prop01WSDataSource = vdtStatus
            ._prop02WSDaftarField = New String() {"Status"}
            ._prop05WSFieldValueMember = "Status"
            ._prop06WSFieldDisplayMember = "Status"
        End With

        _04cTOP._pbf00BindingDataSource1Field("APPROVAL")
    End Sub


    Private Sub _cm04InitControlKAE()
        Dim pdtKAEMarketingCopy As New DataTable
        pdtKAEMarketingCopy = pdtKAEMarketingPickerPameran.Copy()

        'Dim pdtRow() As DataRow
        'pdtRow = pdtKAEMarketingCopy.Select(" f01Int = 50402 ")
        'pdtMasterKAE = pdtRow.CopyToDataTable()

        ' ===================== CREATED BY AKIRRA - 25/06/02 =====================
        ' melakukan sort by f06String ASC (nama KAE).
        Dim dvKAE As New DataView(pdtKAEMarketingCopy)

        dvKAE.RowFilter = "f01Int = '50402'"

        dvKAE.Sort = "f06String ASC, f05String ASC"
        ' =========================================================================

        Dim pdtMasterKAE As New DataTable
        pdtMasterKAE.Clear()
        pdtMasterKAE = dvKAE.ToTable

        If pdtMasterKAE.Rows.Count > 0 Then
            _03cKAE.Properties.DataSource = Nothing
            With _03cKAE
                ._prop01WSDataSource = pdtMasterKAE
                ._prop02WSDaftarField = New String() {"f05String", "f06String"}
                ._prop05WSFieldValueMember = "f05String"
                ._prop06WSFieldDisplayMember = "f06String"
            End With
            _03cKAE._pb01BindingAwalDataSource2Field("CODE", "KAE", 0, 270)
        End If
    End Sub

    Private Sub _cm05InitControlTOP()
        Dim objTargetTransaksi As clsWSNasaSelect4CtrlRepoMaster
        objTargetTransaksi = New clsWSNasaSelect4CtrlRepoMaster With {._prop01User = _prop01User}

        Dim pdtMasterTOP As New DataTable
        pdtMasterTOP = objTargetTransaksi.__pb01GetDataMasterWarehouseBerdasarkanGroup("TOP")
        If pdtMasterTOP.Rows.Count > 0 Then
            _04cTOP.Properties.DataSource = Nothing
            With _04cTOP
                ._prop01WSDataSource = pdtMasterTOP
                ._prop02WSDaftarField = New String() {"k13String", "k14String"}
                ._prop05WSFieldValueMember = "k13String"
                ._prop06WSFieldDisplayMember = "k14String"
            End With
            _04cTOP._pb01BindingAwalDataSource2Field("CODE", "TOP", 0, 270)
        End If

    End Sub

    Private Sub _cm06BersihkanEntrian()
        _cm00RefreshGrid()

        '_01cTargetTransaksi.EditValue = ""
        _02cKepada.EditValue = ""
        _03cKAE.EditValue = ""
        _04cTOP.EditValue = ""
        _05cNote.EditValue = ""
        _08cNoOrderCMK.EditValue = ""

        _06cJenisOrder.SelectedIndex = -1
        _lay06cJenisOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _07cStatusBRJMarketing.SelectedIndex = 0
        _lay07cStatusBRJMarketing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _01cTargetTransaksi.Properties.ReadOnly = False

        '_layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        '_gdDistribusiFG.__pbWSGridParentChild02Clear()
        If _01cTargetTransaksi.EditValue <> "50602" AndAlso _01cTargetTransaksi.EditValue <> "50601" Then
            _gdPKB.__pbWSGrid02ClearGrid()
        End If

        objPKB25SKU.prop_dtsTABLELARGE.Clear()
        objPKB33PRODUCTCODE.prop_dtsTABLEMEDIUMPLUS.Clear()
        objPKBMERCHANDISE.prop_dtsTABLETINY.Clear()

        _01cTargetTransaksi.Focus()
    End Sub

    Private Sub _cm07SettingContent()
        '_01cTargetTransaksi.Properties.ReadOnly = True
        '_02cCustomer.Properties.ReadOnly = True
        '_03cKAE.Properties.ReadOnly = True
        '_04cTOP.Properties.ReadOnly = True
        '_05cNote.Properties.ReadOnly = True

        'PopupContainerEdit1.Controls.Clear()
        'objUserControl.Controls.Clear()

        'PopupContainerEdit1.Properties.PopupControl = Nothing

        Select Case _01cTargetTransaksi.EditValue
            Case "5061",    'Perintah Kirim FG : CUSTOMER
                 "5062",    'Perintah Kirim FG : KAE
                 "5063",    'Perintah Kirim FG : CONSIGMENT
                 "5064",    'Perintah Kirim FG : MARKETING
                 "5065",    'Perintah Kirim FG : INTERNAL
                 "5066"     'Perintah Kirim FG : PAMERAN
                '_cm5061CreateContentPKB() :> dipindah ke tombol "Create PKB"

            Case "5065"     'Perintah Kirim FG : INTERNAL
            Case "5066"     'Perintah Kirim FG : PAMERAN 

            Case "50601",   'Manager FINANCE : Approve Kirim Barang'
                 "50602"    'Manager SALES : Approve Kirim Barang'
                _cm104DisplayGridApprovePKB()

            Case Else
        End Select

    End Sub

    Private Function _cm08GetNewNomorDocument() As String
        Dim pcTargetNoDoc As String = ""

        Select Case _01cTargetTransaksi.EditValue
            Case "5061"    'Perintah Kirim FG : CUSTOMER
                pcTargetNoDoc = "WSPKBCUSTOMER"
            Case "5062"    'Perintah Kirim FG : KAE
                pcTargetNoDoc = "WSPKBKAE"
            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                pcTargetNoDoc = "WSPKBCONSIGMENT"
            Case "5064"    'Perintah Kirim FG : MARKETING
                pcTargetNoDoc = "WSPKBMARKETING"

            Case "5065"    'Perintah Kirim FG : INTERNAL
                pcTargetNoDoc = "WSPKBINTERNAL"

            Case "5066"    'Perintah Kirim FG : PAMERAN 
                pcTargetNoDoc = "WSPKBPAMERAN"
        End Select

        Dim pcNoDokumen As String = ""
        Dim objNoDoc As New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                  ._prop02String = pcTargetNoDoc}
        pcNoDokumen = objNoDoc._pb51GetDataIncNoDocWarehouse()

        Return pcNoDokumen
    End Function

    Private Sub _cm09CekComplete()
        If _01cTargetTransaksi.EditValue = "50601" Or _01cTargetTransaksi.EditValue = "50602" Then
            '(50601/2) Manager FINANCE/SALES : Approve Kirim Barang'
            _cm07SettingContent()

            Dim _dlgSetAppvStat As pbMd08SetApprovalStatus = AddressOf _gdPKB._ivkSetApprovalStatus
            If _01cTargetTransaksi.EditValue = "50601" Then
                _dlgSetAppvStat.Invoke("FIN", If(_04cTOP.EditValue IsNot Nothing, _04cTOP.EditValue.ToString(), ""))
            Else
                _dlgSetAppvStat.Invoke("SLS", If(_04cTOP.EditValue IsNot Nothing, _04cTOP.EditValue.ToString(), ""))
            End If
        Else
            Dim plHasil As Boolean
            plHasil = True

            If String.IsNullOrEmpty(_01cTargetTransaksi.EditValue) Then
                plHasil = False
            End If

            Select Case _01cTargetTransaksi.EditValue
                Case "5061"    'Perintah Kirim FG : CUSTOMER
                    If String.IsNullOrEmpty(_02cKepada.EditValue) _
                        Or String.IsNullOrEmpty(_03cKAE.EditValue) _
                        Or String.IsNullOrEmpty(_04cTOP.EditValue) Then
                        plHasil = False
                    End If

                Case "5062"    'Perintah Kirim FG : KAE
                    If String.IsNullOrEmpty(_02cKepada.EditValue) Then
                        plHasil = False
                    Else
                        _03cKAE.EditValue = _02cKepada.EditValue
                    End If

                Case "5063"    'Perintah Kirim FG : CONSIGMENT
                    If String.IsNullOrEmpty(_02cKepada.EditValue) _
                        Or String.IsNullOrEmpty(_03cKAE.EditValue) Then
                        plHasil = False
                    End If

                Case "5064"    'Perintah Kirim FG : MARKETING
                    If String.IsNullOrEmpty(_02cKepada.EditValue) Then
                        plHasil = False
                    End If

                Case "5065"    'Perintah Kirim FG : INTERNAL
                    If String.IsNullOrEmpty(_02cKepada.EditValue) Then
                        plHasil = False
                    End If

                Case "5066"    'Perintah Kirim FG : PAMERAN 
                    If String.IsNullOrEmpty(_02cKepada.EditValue) Then
                        plHasil = False
                    End If

            End Select

            ' ===================== UPDATED BY AKIRRA - 25/07/04 =====================
            ' note tidak wajib diisi, tetap bisa lanjut create ORDER. [request mba Risma saat UAT]
            'If String.IsNullOrEmpty(_05cNote.EditValue) Then
            '    plHasil = False
            'End If
            ' ========================================================================

            If plHasil Then
                _cm07SettingContent()
                WindowsuiButtonPanel1.Buttons(0).Properties.Visible = True
                WindowsuiButtonPanel1.Buttons(1).Properties.Visible = True

                '_layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Else
                WindowsuiButtonPanel1.Buttons(0).Properties.Visible = False
                WindowsuiButtonPanel1.Buttons(1).Properties.Visible = False

                '_layPopupContainerEdit1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If
        End If

    End Sub

    Private Sub _cm10VisibilityControl()
        WindowsuiButtonPanel1.Buttons(0).Properties.Visible = False
        WindowsuiButtonPanel1.Buttons(1).Properties.Visible = False

        _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay03cKAE.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay04cTOP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay05cNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay06cJenisOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay07cStatusBRJMarketing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay08cNoOrderCMK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        _lay09cStockCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        _02cKepada.Properties.ReadOnly = True
        _03cKAE.Properties.ReadOnly = True
        _04cTOP.Properties.ReadOnly = True
        _05cNote.Properties.ReadOnly = True

        _02cKepada.EditValue = ""
        _03cKAE.EditValue = ""
        _04cTOP.EditValue = ""
        _05cNote.EditValue = ""
        _06cJenisOrder.SelectedIndex = -1
        _07cStatusBRJMarketing.SelectedIndex = 0
        _08cNoOrderCMK.EditValue = ""
        _01objStockCheck.EditValue = Nothing

        _lay02cKepada.Text = "Kepada"
        _lay03cKAE.Text = "Key Account Executive"
        _lay04cTOP.Text = "Term of Payment"

        ' ===================== UPDATED BY AKIRRA - 16/04/25 =====================
        ' agar ketika merubah target, maka grid akan terefresh ulang (sekaligus dengan header dan row numbernya).
        If Not (_01cTargetTransaksi.EditValue = "50601" OrElse _01cTargetTransaksi.EditValue = "50602") Then
            _gdPKB.__pbWSGrid01InitGrid()
            _gdPKB.__pbWSGrid02ClearGrid()

            _cm00InitControlStockCheck()
        End If
        ' ======================================================================

        Select Case _01cTargetTransaksi.EditValue
            Case "50601"
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _02cKepada.Properties.ReadOnly = False
                _lay02cKepada.Text = "Filter by Jenis Order"

                _lay03cKAE.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _03cKAE.Properties.ReadOnly = False
                _lay03cKAE.Text = "Filter by Customer"

                _lay04cTOP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _04cTOP.Properties.ReadOnly = False
                _lay04cTOP.Text = "Approval"

            Case "50602"
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _02cKepada.Properties.ReadOnly = False
                _lay02cKepada.Text = "Filter by Jenis Order"

                _lay03cKAE.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _03cKAE.Properties.ReadOnly = False
                _lay03cKAE.Text = "Filter by Customer"

                _lay04cTOP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _04cTOP.Properties.ReadOnly = False
                _lay04cTOP.Text = "Approval"

            Case "5061"    'Perintah Kirim FG : CUSTOMER
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay03cKAE.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay04cTOP.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05cNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay06cJenisOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay08cNoOrderCMK.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

                _02cKepada.Properties.ReadOnly = False
                _03cKAE.Properties.ReadOnly = False
                _04cTOP.Properties.ReadOnly = False
                _05cNote.Properties.ReadOnly = False

            Case "5062"    'Perintah Kirim FG : KAE
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05cNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _02cKepada.Properties.ReadOnly = False
                _05cNote.Properties.ReadOnly = False

            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay03cKAE.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05cNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _02cKepada.Properties.ReadOnly = False
                _03cKAE.Properties.ReadOnly = False
                _05cNote.Properties.ReadOnly = False

            Case "5064"    'Perintah Kirim FG : MARKETING 
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05cNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay07cStatusBRJMarketing.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _02cKepada.Properties.ReadOnly = False
                _05cNote.Properties.ReadOnly = False

            Case "5065"    'Perintah Kirim FG : INTERNAL
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05cNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _02cKepada.Properties.ReadOnly = False
                _05cNote.Properties.ReadOnly = False

            Case "5066"    'Perintah Kirim FG : PAMERAN 
                _lay02cKepada.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _lay05cNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                _02cKepada.Properties.ReadOnly = False
                _05cNote.Properties.ReadOnly = False

        End Select

    End Sub

    Private Sub _cm21SaveApproveFINSLS()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data ini sudah benar unt proses APPROVAL Order ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then

            Dim rsl As Int16 = _cm105ProsesSaveApprovedFinSls()
            If rsl > 0 Then
                _cm00RefreshGrid()

                MsgBox("Proses APPROVAL Order ... BERHASIL...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
            ElseIf rsl = 0 Then
                MsgBox("Proses APPROVAL Order ... GAGAL...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            Else
                MsgBox("Tidak ada data yang akan diproses ... Proses APPROVAL Order ... GAGAL... ", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
            End If
        Else
            MsgBox("Proses APPROVAL Order ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If
    End Sub

    Private Sub _cm00InitControlStockCheck()
        Cursor = Cursors.WaitCursor

        objContainer.Controls.Add(objUserControl)
        _lay09cStockCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        Select Case _01cTargetTransaksi.EditValue
            Case "5061",    'Order : CUSTOMER
                 "5062",    'Order : KAE
                 "5063",    'Order : CONSIGMENT
                 "5064",    'Order : MARKETING
                 "5065",    'Order : INTERNAL
                 "5066"     'Order : PAMERAN
                _lay09cStockCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

                objUserControl.Controls.Clear()
                _01objStockCheck.Controls.Clear()

                _01objStockCheck.Properties.PopupControl = Nothing

                Dim objStockCheck As New ucWS25DX01STOCKCHECK With {._prop01User = _prop01User}

                Dim objSize As New Size With {.Width = objStockCheck.Size.Width,
                                              .Height = objStockCheck.Size.Height}
                objContainer.Size = objSize
                objUserControl.Size = objSize

                objUserControl.Controls.Add(objStockCheck)

                _01objStockCheck.Properties.PopupControl = objContainer
        End Select

        Cursor = Cursors.Default
    End Sub

    Private Sub _cm00RefreshGrid()
        _gdPKB.__pbWSGrid01InitGrid()
        _gdPKB.__pbWSGrid02ClearGrid()
        Select Case _01cTargetTransaksi.EditValue
            Case "5061",    'Perintah Kirim FG : CUSTOMER
                 "5062",    'Perintah Kirim FG : KAE
                 "5063",    'Perintah Kirim FG : CONSIGMENT
                 "5064",    'Perintah Kirim FG : MARKETING
                 "5065",    'Perintah Kirim FG : INTERNAL
                 "5066"     'Perintah Kirim FG : PAMERAN
                With _gdPKB
                    ._prop01User = _prop01User
                    ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSDistribusiFGPKB
                End With
                _gdPKB.__pbWSGrid03DisplayGrid()
                _gdPKB._ivkRefreshDisplayGrid(objPKB33PRODUCTCODE.prop_dtsTABLEMEDIUMPLUS)

            Case "50601",   'Manager FINANCE : Approve Kirim Barang'   
                 "50602"    'Manager SALES : Approve Kirim Barang'
                _02cKepada.EditValue = ""
                _03cKAE.EditValue = ""
                _04cTOP.EditValue = ""
                _cm104DisplayGridApprovePKB()
        End Select
    End Sub

#End Region

#Region "***** 5061. PKB *****"

    Private Sub _cm5061IsOrderViaXLS()
        Dim plYes As MsgBoxResult = MsgBox("Apakah ingin ORDER via Bulk Upload XLSX .. ?", vbYesNoCancel + MsgBoxStyle.Question, "Order Creation | " & _prop01User._UserProp01cTitle)

        If plYes = MsgBoxResult.Yes Then
            _cm5061CreateOrderViaBulkUploadXLS()
        ElseIf plYes = MsgBoxResult.No Then
            _cm5061CreateContentPKB()
        End If
    End Sub

    Private Function _cm5061CreateParameterOrder() As DataTable
        Dim pcJenisOrder As String = ""
        Dim pcNamaProsesMaster As String = ""
        'Autor     : aga
        'Deskripsi : melengkapi jenis order
        Select Case _01cTargetTransaksi.EditValue
            Case "5061"
                Select Case _06cJenisOrder.SelectedIndex
                    Case 0 : pcJenisOrder = "CO" : pcNamaProsesMaster = "NEW ORDER | CUSTOMER-CO"
                    Case 1 : pcJenisOrder = "PO" : pcNamaProsesMaster = "NEW ORDER CUSTOMER-PO"
                End Select
            Case "5062"
                pcJenisOrder = "SS" : pcNamaProsesMaster = "NEW ORDER | KAE"
            Case "5063"
                pcJenisOrder = "CS" : pcNamaProsesMaster = "NEW ORDER | CONSIGNMENT"
            'Case "5064"
            '    Select Case _07cStatusBRJMarketing.SelectedIndex
            '        Case 0 : pcJenisOrder = "MO-PINJAMAN"   ' ini salah woy
            '        Case 1 : pcJenisOrder = "MO-GIFTAWAY"   ' ini salah woy
            '    End Select
            Case "5064"
                Select Case _07cStatusBRJMarketing.SelectedIndex
                    Case 0 : pcJenisOrder = "PINJAMAN" : pcNamaProsesMaster = "NEW ORDER | MKT-PINJAMAN"
                    Case 1 : pcJenisOrder = "GIFTAWAY" : pcNamaProsesMaster = "NEW ORDER | MKT-GIVEAWAY"
                End Select
            Case "5065"
                pcJenisOrder = "IN" : pcNamaProsesMaster = "NEW ORDER | INTERNAL-SALE"
            Case "5066"
                pcJenisOrder = "XB" : pcNamaProsesMaster = "NEW ORDER | EXHIBITON"
        End Select

        Dim pdtDataSmall As New DataTable
        Dim objDataSmall As New clsWSNasaTemplateDataSmall With {.prop_dtsTABLESMALL = pdtDataSmall}
        objDataSmall.dtInitsTABLESMALL()
        ' ===================== UPDATED BY AKIRRA - 25/05/21 =====================
        ' menambahkan NoOrderCMK ke f06String dan memindahkan Note ke f10String karena Note bisa saja lebih dari 50 char.
        objDataSmall.dtAddNewsTABLESMALL(
                    _01cTargetTransaksi.EditValue, pcNamaProsesMaster,
                    _02cKepada.EditValue, _02cKepada.Text,
                    _03cKAE.EditValue, _03cKAE.Text,
                    _04cTOP.EditValue, _04cTOP.Text,
                    _08cNoOrderCMK.EditValue, pcJenisOrder, _cm5061CreateRuleStock, "", _05cNote.EditValue,
                    0, 0, 0, 0.0, 0.0, 0.0,
                    "3000-01-01", "3000-01-01", "3000-01-01", "3000-01-01",
                    "", "", "", "", "")
        ' =========================================================================

        Return objDataSmall.prop_dtsTABLESMALL
    End Function

    Private Function _cm5061CreateRuleStock() As String
        Dim pcRuleStock As String = ""
        Select Case _01cTargetTransaksi.EditValue
            Case "5061"    'Perintah Kirim FG : CUSTOMER
                pcRuleStock = "FORSALE"

            Case "5062"    'Perintah Kirim FG : KAE
                pcRuleStock = "FORSALE"

            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                pcRuleStock = "FORSALE"

            Case "5064"    'Perintah Kirim FG : MARKETING 
                pcRuleStock = "ALL"

            Case "5065"    'Perintah Kirim FG : INTERNAL
                pcRuleStock = "FORSALE"

            Case "5066"    'Perintah Kirim FG : PAMERAN 
                pcRuleStock = "FORSALE"
        End Select

        Return pcRuleStock
    End Function

    Private Sub _cm5061CreateOrderViaBulkUploadXLS()
        Cursor = Cursors.WaitCursor
        Dim objBulkUploadXLS As New ucWS24LD01BULKUPLOADXLS With {._prop01User = _prop01User,
                                                                  ._prop02TargetBULKUPLOADXLS = ucWS24LD01BULKUPLOADXLS._pbEnumTargetBULKUPLOADXLS._DISTRIBUTIONOrderFG,
                                                                  ._prop03DataTableParameter = _cm5061CreateParameterOrder()}

        Dim objSize As New Size With {.Width = objBulkUploadXLS.Size.Width,
                                      .Height = objBulkUploadXLS.Size.Height + 50}

        Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                           .MinimizeBox = False, .ShowIcon = False,
                                           .StartPosition = FormStartPosition.CenterScreen,
                                           .Text = "Bulk Upload Order | " & _prop01User._UserProp01cTitle,
                                           .Dock = DockStyle.Fill}
        frmModal.AddControl(objBulkUploadXLS)

        Cursor = Cursors.Default

        frmModal.ShowDialog()
    End Sub

    Private Sub _cm5061CreateContentPKB()
        Cursor = Cursors.WaitCursor

        With _gdPKB
            ._prop01User = _prop01User
            ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSDistribusiFGPKB
        End With
        _gdPKB.__pbWSGrid01InitGrid()
        _gdPKB.__pbWSGrid02ClearGrid()
        _gdPKB.__pbWSGrid03DisplayGrid()
        _gdPKB._ivkRefreshDisplayGrid(objPKB33PRODUCTCODE.prop_dtsTABLEMEDIUMPLUS)

        Dim objUCPKBCustomer As New ucWS23LN01PKB With {._prop01User = _prop01User,
                                                        ._prop02WSGrid = _gdPKB,
                                                        ._prop03DataSmall = _cm5061CreateParameterOrder(),
                                                        ._prop04RuleStock = _cm5061CreateRuleStock(),
                                                        ._prop05DataPKBSKU = objPKB25SKU,
                                                        ._prop06DataPKBProductCode = objPKB33PRODUCTCODE,
                                                        ._prop07DataPKBMerchaindise = objPKBMERCHANDISE}

        Dim objSize As New Size With {.Width = objUCPKBCustomer.Size.Width,
                                      .Height = objUCPKBCustomer.Size.Height + 25}

        Dim frmModal As New XtraForm With {.Size = objSize, .MaximizeBox = False,
                                           .MinimizeBox = False, .ShowIcon = False,
                                           .StartPosition = FormStartPosition.CenterScreen,
                                           .Text = "Create Order | " & _prop01User._UserProp01cTitle}
        frmModal.AddControl(objUCPKBCustomer)

        Cursor = Cursors.Default

        frmModal.ShowDialog()

        'objContainer.Size = objSize
        'objUserControl.Size = objSize

        'objUserControl.Controls.Add(objUCPKBCustomer)

        'PopupContainerEdit1.Properties.PopupControl = objContainer

    End Sub

    Private Function _cm5061ProsesSavePKB() As Integer
        Cursor = Cursors.WaitCursor

        Dim pnJmlRec As Integer = 0

        If objPKB33PRODUCTCODE.prop_dtsTABLEMEDIUMPLUS.Rows.Count > 0 Then

            For Each dtRow As DataRow In objPKB33PRODUCTCODE.prop_dtsTABLEMEDIUMPLUS.Rows
                dtRow("f26String") = _08cNoOrderCMK.EditValue
                dtRow("f30String") = _05cNote.EditValue
            Next
            objPKB33PRODUCTCODE.prop_dtsTABLEMEDIUMPLUS.AcceptChanges()
            '
            For Each dtRow As DataRow In objPKB25SKU.prop_dtsTABLELARGE.Rows
                dtRow("f03String") = _01cTargetTransaksi.EditValue
                dtRow("f04String") = _01cTargetTransaksi.Text
            Next
            objPKB25SKU.prop_dtsTABLELARGE.AcceptChanges()

            Dim objNasaHelper As New clsWSNasaHelper
            pnJmlRec = objNasaHelper._pbWSNasaHelperExec01SPSQLProses(
                       _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                       2, mdWSNasaConst._pbWSNamaSPSAVE03TABLE30PKBProductCode,
                       mdWSNasaConst._pbWSNamaSPParamData02DataForSaving, objPKB25SKU.prop_dtsTABLELARGE,
                       mdWSNasaConst._pbWSNamaSPParamData04DataPOMerchandise, objPKBMERCHANDISE.prop_dtsTABLETINY,
                       "@tpDataForSaving30", objPKB33PRODUCTCODE.prop_dtsTABLEMEDIUMPLUS)
        Else
            MsgBox("Maaf ... Data masih KOSONG ...." & Chr(13) & "Proses Simpan Data Order ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

        Cursor = Cursors.Default

        Return pnJmlRec
    End Function

    Private Sub _cm5061SavePKB()
        Dim plYes As MsgBoxResult = MsgBox("Apakah anda yakin data 'ORDER' ini sudah benar untuk proses Simpan Data ... ?", vbYesNo + MsgBoxStyle.Question, _prop01User._UserProp01cTitle)

            If plYes = MsgBoxResult.Yes Then
            If _cm5061ProsesSavePKB() > 0 Then
                MsgBox("Proses Simpan Data ... SUKSES...", vbOKOnly + vbInformation, _prop01User._UserProp01cTitle)
                _cm06BersihkanEntrian()

            End If
        Else
            MsgBox("Maaf ... Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
        End If

    End Sub

    '**********************************************************
    '*******************     NOT USED     *********************
    '**********************************************************
    'Private Function _cm103ProsesSavePKBCustomer() As Integer
    '    Cursor = Cursors.WaitCursor

    '    Dim pnJmlRec As Integer = 0

    '    Dim pdtChild As New DataTable
    '    pdtChild = _gdDistribusiFG.__pbGetDataChildPKBCustomer()

    '    If pdtChild.Rows.Count > 0 Then
    '        Dim pcNoDoc As String = _cm08GetNewNomorDocument()

    '        Dim pdtData As New DataTable
    '        Dim objPKBCustomer As New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtData}
    '        objPKBCustomer.dtInitsTABLELARGE()

    '        For Each dtRow As DataRow In pdtChild.Rows
    '            objPKBCustomer.dtAddNewsTABLELARGE(
    '                            "", dtRow("f02String"), pcNoDoc,
    '                            dtRow("f03String"), dtRow("f01String"), _01cTargetTransaksi.EditValue,
    '                            _01cTargetTransaksi.Text, dtRow("f04String"), dtRow("f05String"),
    '                            dtRow("f06String"), dtRow("f07String"), _02cCustomer.EditValue,
    '                            _02cCustomer.Text, _03cKAE.EditValue, _03cKAE.Text,
    '                            _04cTOP.EditValue, _04cTOP.Text, dtRow("f18String"),
    '                            dtRow("f19String"), dtRow("f12String"), dtRow("f13String"),
    '                            dtRow("f14String"), dtRow("f15String"), dtRow("f08String"),
    '                            dtRow("f09String"), dtRow("f16String"), dtRow("f17String"),
    '                            dtRow("f10String"), dtRow("f11String"), "",
    '                            "", "", "", "", "", "", "", "", "", "", "", "", _05cNote.EditValue,
    '                            dtRow("f01Int"), dtRow("f02Int"), 0,
    '                            dtRow("f01Double"), 0.0, 0.0,
    '                            "3000-01-01", "3000-01-01",
    '                            Now, _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
    '                            _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
    '        Next

    '        Dim objNasaHelper As New clsWSNasaHelper
    '        pnJmlRec = objNasaHelper._pbWSNasaHelperExec01SPSQLProses(
    '                            _prop01User._UserProp08TargetNetwork,
    '                            clsWSNasaHelper._pnmDatabaseName.WS, 2,
    '                            mdWSNasaConst._pbWSNamaSPSAVE03TABLE25PKBCustomer,
    '                            mdWSNasaConst._pbWSNamaSPParamData02DataForSaving,
    '                            objPKBCustomer.prop_dtsTABLELARGE)

    '    Else
    '        MsgBox("Maaf ... Data masih kosong ...." & Chr(13) & "Proses Simpan Data ... DIBATALKAN...", vbOKOnly + vbCritical, _prop01User._UserProp01cTitle)
    '    End If

    '    Cursor = Cursors.Default

    '    Return pnJmlRec
    'End Function
    '**********************************************************
    '*******************     NOT USED     *********************
    '**********************************************************

#End Region

#Region "***** APPROVE - PKB *****"

    Private Sub _cm104DisplayGridApprovePKB()
        Cursor = Cursors.WaitCursor
        '3,0,5 ==> (APPROVE PKB Customer : Mgr.Sales)
        '3,0,6 ==> (APPROVE PKB Customer : Mgr.Finance)

        'With _gdDistribusiFG
        '    ._prop01User = _prop01User
        '    If _01cTargetTransaksi.EditValue = "50601" Then
        '        ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetAPPROVEPKBMgrFIN
        '    Else
        '        ._prop02TargetGridParentChild = ucWSGridParentChild.__TargetGridParentChild._TargetAPPROVEPKBMgrSLS
        '    End If
        'End With
        '_gdDistribusiFG.__pbWSGridParentChild01InitGrid()
        '_gdDistribusiFG.__pbWSGridParentChild02Clear()
        '_gdDistribusiFG.__pbWSGridParentChild03Display()

        Dim pdtDataApprove As New DataTable
        Dim objData As clsWSNasaSelect4PivotGridProses = New clsWSNasaSelect4PivotGridProses With {._prop01User = _prop01User}
        If _01cTargetTransaksi.EditValue = "50601" Then
            pdtDataApprove = objData._pb03GetDataPrepareAPPROVEPKB("FIN", If(_02cKepada.EditValue IsNot Nothing, _02cKepada.EditValue.ToString(), ""), If(_03cKAE.EditValue IsNot Nothing, _03cKAE.EditValue.ToString(), ""))
        Else
            pdtDataApprove = objData._pb03GetDataPrepareAPPROVEPKB("SLS", If(_02cKepada.EditValue IsNot Nothing, _02cKepada.EditValue.ToString(), ""), If(_03cKAE.EditValue IsNot Nothing, _03cKAE.EditValue.ToString(), ""))
        End If

        With _gdPKB
            _gdPKB.__pbWSGrid01InitGrid()
            _gdPKB.__pbWSGrid02ClearGrid()
            ._prop01User = _prop01User
            If _01cTargetTransaksi.EditValue = "50601" Then
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSDistribusiFGPKBApproveFIN
            Else
                ._prop02TargetGrid = ucWSGrid._pbEnumTargetGrid._WSDistribusiFGPKBApproveSLS
            End If
            ._prop03pdtDataSourceGrid = pdtDataApprove
        End With
        _gdPKB.__pbWSGrid03DisplayGrid()

        Cursor = Cursors.Default
    End Sub

    Private Function _cm105ProsesSaveApprovedFinSls() As Integer
        Cursor = Cursors.WaitCursor

        Dim _oWsGetDtForSaving As New clsWSNasaSelect4AllProsesMaster

        Dim vdtDataApprovedFinSls As New DataTable
        Dim vdtApprovalLatest As New DataTable()
        If _01cTargetTransaksi.EditValue = "50601" Then
            vdtDataApprovedFinSls = _gdPKB.__pvGetData4ApprovedFinSls("FIN")
            vdtApprovalLatest = _oWsGetDtForSaving._pbf09GetDataForSavingApprovalFIN(_prop01User, If(_02cKepada.EditValue IsNot Nothing, _02cKepada.EditValue.ToString(), ""), If(_03cKAE.EditValue IsNot Nothing, _03cKAE.EditValue.ToString(), ""))
        Else
            vdtDataApprovedFinSls = _gdPKB.__pvGetData4ApprovedFinSls("SLS")
            vdtApprovalLatest = _oWsGetDtForSaving._pbf10GetDataForSavingApprovalSLS(_prop01User, If(_02cKepada.EditValue IsNot Nothing, _02cKepada.EditValue.ToString(), ""), If(_03cKAE.EditValue IsNot Nothing, _03cKAE.EditValue.ToString(), ""))
        End If

        If vdtDataApprovedFinSls Is Nothing OrElse vdtDataApprovedFinSls.Rows.Count = 0 Then
            Cursor = Cursors.Default
            Return -1   ' no data to process
        End If

        If vdtApprovalLatest Is Nothing OrElse vdtApprovalLatest.Rows.Count = 0 Then
            Cursor = Cursors.Default
            Return -1   ' no data to process
        End If

        ' join selected data with latest data
        Dim joinedRows = From slct In vdtDataApprovedFinSls.AsEnumerable()
                             Join ltst In vdtApprovalLatest.AsEnumerable()
                 On slct.Field(Of String)("k01String") Equals ltst.Field(Of String)("k03String")
                             Select slct

            Dim vdtMerged As DataTable = vdtDataApprovedFinSls.Clone()
            For Each row In joinedRows
            vdtMerged.ImportRow(row)
        Next

        If vdtMerged Is Nothing OrElse vdtMerged.Rows.Count = 0 Then
            Cursor = Cursors.Default
            Return -1   ' no data to process
        End If


        Dim pnJmlRec As Integer = 0

        For Each dtRow As DataRow In vdtMerged.Rows
            dtRow("f04String") = _01cTargetTransaksi.Text
        Next
        vdtMerged.AcceptChanges()

        Dim objNasaHelper As New clsWSNasaHelper
        pnJmlRec = objNasaHelper._pbWSNasaHelperExec01SPSQLProses(
                     _prop01User._UserProp08TargetNetwork, clsWSNasaHelper._pnmDatabaseName.WS,
                       2, mdWSNasaConst._pbWSNamaSPUPDATETABLE30ApprovedShipmentOrder,
                       mdWSNasaConst._pbWSNamaSPParamData02DataForSaving, vdtMerged)

        Cursor = Cursors.Default

        Return pnJmlRec
    End Function

#End Region

#Region "control - event"

    Private Sub _01cTargetTransaksi_EditValueChanged(sender As Object, e As EventArgs) Handles _01cTargetTransaksi.EditValueChanged
        _cm09CekComplete()

        Select Case _01cTargetTransaksi.EditValue
            Case "50601"    'Approve FA 
                _cm03InitControlKepada("APVFA")

            Case "50602"    'Approve Sales
                _cm03InitControlKepada("APVSALES")

            Case "5061"    'Perintah Kirim FG : CUSTOMER
                _cm03InitControlKepada("CUSTOMER")

            Case "5062"    'Perintah Kirim FG : KAE
                _cm03InitControlKepada("KAE")

            Case "5063"    'Perintah Kirim FG : CONSIGMENT
                _cm03InitControlKepada("CONSIGNMENT")

            Case "5064"    'Perintah Kirim FG : MARKETING 
                _cm03InitControlKepada("MARKETING")

            Case "5065"    'Perintah Kirim FG : INTERNAL
                ' ===================== UPDATED BY AKIRRA - 25/05/21 =====================
                ' akses ke submenu ini sementara ditutup karena msh ada error.

                MsgBox("SUBMENU IS STILL UNDER DEVELOPMENT..", vbOKOnly + vbExclamation, _prop01User._UserProp01cTitle)
                _01cTargetTransaksi.EditValue = ""

                '_cm03InitControlKepada("INTERNAL")

                ' ======================================================================

            Case "5066"    'Perintah Kirim FG : PAMERAN 
                _cm03InitControlKepada("PAMERAN")
        End Select

        _cm10VisibilityControl()
    End Sub

    Private Sub _02cKepada_EditValueChanged(sender As Object, e As EventArgs) Handles _02cKepada.EditValueChanged
        _cm09CekComplete()
    End Sub

    Private Sub _03cKAE_EditValueChanged(sender As Object, e As EventArgs) Handles _03cKAE.EditValueChanged
        _cm09CekComplete()
    End Sub

    Private Sub _04cTOP_EditValueChanged(sender As Object, e As EventArgs) Handles _04cTOP.EditValueChanged
        _cm09CekComplete()
    End Sub

    Private Sub _05cNote_EditValueChanged(sender As Object, e As EventArgs) Handles _05cNote.EditValueChanged
        _cm09CekComplete()
    End Sub

    Private Sub WindowsuiButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsuiButtonPanel1.ButtonClick
        If TypeOf e.Button Is WindowsUIButton Then
            Dim btn As WindowsUIButton = CType(e.Button, WindowsUIButton)
            Dim tags As Int16 = CInt(btn.Tag)

            Select Case tags
                Case 100  'Save
                    If _01cTargetTransaksi.EditValue = "50601" Or _01cTargetTransaksi.EditValue = "50602" Then
                        _cm21SaveApproveFINSLS()
                    Else
                        'Save PKB
                        _cm5061SavePKB()
                    End If

                Case 200  'Clear
                    _cm06BersihkanEntrian()
                    _01cTargetTransaksi.EditValue = ""
                '_gdPKB.__pbWSGrid04CreateSettingColumnWidth("ucWS23LL01DISTRIBUSIFINISHGOODS-01")

                Case 300
                    Select Case _01cTargetTransaksi.EditValue
                        Case "5061",    'Perintah Kirim FG : CUSTOMER
                             "5062",    'Perintah Kirim FG : KAE
                             "5063",    'Perintah Kirim FG : CONSIGMENT
                             "5064",    'Perintah Kirim FG : MARKETING
                             "5065",    'Perintah Kirim FG : INTERNAL
                             "5066"     'Perintah Kirim FG : PAMERAN
                            _cm5061IsOrderViaXLS()

                            'Case "5065"     'Perintah Kirim FG : INTERNAL
                            'Case "5066"     'Perintah Kirim FG : PAMERAN 

                            'Case "50601",   'Manager FINANCE : Approve Kirim Barang'
                            '     "50602"    'Manager SALES : Approve Kirim Barang'
                        Case Else
                    End Select

                Case 400
                    _cm00RefreshGrid()

            End Select
        End If


    End Sub

#End Region

End Class
