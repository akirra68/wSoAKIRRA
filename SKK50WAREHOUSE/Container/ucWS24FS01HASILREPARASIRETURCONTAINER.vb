Imports SKK02OBJECTS

Public Class ucWS24FS01HASILREPARASIRETURCONTAINER
    Implements IDisposable

    Property _prop01User As clsWSNasaUser

    Property _prop02pdtMasterProduct As DataTable
    Property _prop03pdtMasterSize As DataTable

    Private pdtItem As DataTable
    Private pdtKadar As DataTable
    Private pdtBrand As DataTable
    Private pdtWarna As DataTable

#Region "form - event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtItem = New DataTable
        pdtKadar = New DataTable
        pdtBrand = New DataTable
        pdtWarna = New DataTable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtItem.Dispose()
        pdtKadar.Dispose()
        pdtBrand.Dispose()
        pdtWarna.Dispose()
    End Sub

    Private Sub ucWS24FS01HASILREPARASIRETURCONTAINER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        Cursor = Cursors.WaitCursor

        _cm01BersihkanEntrian()
        _cm02GetDataMasterMRP()

        _cm03InitControlItem()
        _cm031InitControlKadar()
        _cm032InitControlBrand()
        _cm033InitControlSize()
        _cm034InitControlWarna()

        Cursor = Cursors.Default
    End Sub
#End Region

#Region "custom - method"

    Private Sub _cm01BersihkanEntrian()
        _01Tanggal.EditValue = Today.Date
        _02cSKU.EditValue = ""
        _03cKeterangan.EditValue = ""

        _20cDesignCode.EditValue = ""
        _21cProductCode.EditValue = ""
        _22nPcs.EditValue = 1
        _23nBeratGross.EditValue = 0.00
        _24nBeratNett.EditValue = 0.00

        _30cItem.EditValue = ""
        _31cKadar.EditValue = ""
        _32cBrand.EditValue = ""
        _33cSize.EditValue = ""
        _34cWarna.EditValue = ""
    End Sub

    Private Sub _cm02GetDataMasterMRP()

        pdtItem = _prop02pdtMasterProduct.Copy()
        pdtKadar = _prop02pdtMasterProduct.Copy()
        pdtBrand = _prop02pdtMasterProduct.Copy()
        pdtWarna = _prop02pdtMasterProduct.Copy()
    End Sub

    Private Sub _cm03InitControlItem()
        If pdtItem.Rows.Count > 0 Then
            _30cItem.Properties.DataSource = Nothing
            With _30cItem
                ._prop01WSDataSource = pdtItem
                ._prop02WSDaftarField = New String() {"", ""}
                ._prop03WSFieldYgDiFilter = ""
                ._prop04WSValueKodeMasterYgDiFilter = ""
                ._prop05WSFieldValueMember = ""
                ._prop06WSFieldDisplayMember = ""
            End With
            _30cItem._pb01BindingAwalDataSource2Field("Code", "ITEM")
            _30cItem._pb04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _cm031InitControlKadar()
        If pdtKadar.Rows.Count > 0 Then
            _31cKadar.Properties.DataSource = Nothing
            With _31cKadar
                ._prop01WSDataSource = pdtKadar
                ._prop02WSDaftarField = New String() {"", ""}
                ._prop03WSFieldYgDiFilter = ""
                ._prop04WSValueKodeMasterYgDiFilter = ""
                ._prop05WSFieldValueMember = ""
                ._prop06WSFieldDisplayMember = ""
            End With
            _31cKadar._pb01BindingAwalDataSource2Field("Code", "KADAR")
            _31cKadar._pb04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _cm032InitControlBrand()
        If pdtBrand.Rows.Count > 0 Then
            _32cBrand.Properties.DataSource = Nothing
            With _32cBrand
                ._prop01WSDataSource = pdtBrand
                ._prop02WSDaftarField = New String() {"", ""}
                ._prop03WSFieldYgDiFilter = ""
                ._prop04WSValueKodeMasterYgDiFilter = ""
                ._prop05WSFieldValueMember = ""
                ._prop06WSFieldDisplayMember = ""
            End With
            _32cBrand._pb01BindingAwalDataSource2Field("Code", "BRAND")
            _32cBrand._pb04FilterDataViewMasterSKK()
        End If
    End Sub

    Private Sub _cm033InitControlSize()
        If _prop03pdtMasterSize.Rows.Count > 0 Then
            _33cSize.Properties.DataSource = Nothing
            With _33cSize
                ._prop01WSDataSource = _prop03pdtMasterSize
                ._prop02WSDaftarField = New String() {"", ""}
                ._prop05WSFieldValueMember = ""
                ._prop06WSFieldDisplayMember = ""
            End With
            _33cSize._pb01BindingAwalDataSource2Field("Code", "SIZE")
        End If
    End Sub

    Private Sub _cm034InitControlWarna()
        If pdtWarna.Rows.Count > 0 Then
            _34cWarna.Properties.DataSource = Nothing
            With _34cWarna
                ._prop01WSDataSource = pdtWarna
                ._prop02WSDaftarField = New String() {"", ""}
                ._prop05WSFieldValueMember = ""
                ._prop06WSFieldDisplayMember = ""
            End With
            _34cWarna._pb01BindingAwalDataSource2Field("Code", "WARNA")
        End If
    End Sub

    Private Function _cm04IsExistDesignProductCode() As Boolean
        Cursor = Cursors.WaitCursor

        Dim plHasil As Boolean = False
        Using objDesignProductCode As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster()
            plHasil = objDesignProductCode._pb07IsExistDesignProductCode(_20cDesignCode.EditValue, _21cProductCode.EditValue)
        End Using

        Cursor = Cursors.Default

        Return plHasil
    End Function

#End Region

#Region "control - event"
    Private Sub _20cDesignCode_EditValueChanged(sender As Object, e As EventArgs) Handles _20cDesignCode.EditValueChanged

    End Sub

    Private Sub _21cProductCode_EditValueChanged(sender As Object, e As EventArgs) Handles _21cProductCode.EditValueChanged

    End Sub

    Private Sub _otblSave_Click(sender As Object, e As EventArgs) Handles _otblSave.Click

    End Sub
#End Region

End Class
