Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class ctrlGEMINIMasterSetting
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

    Public Property _objSearchLookupEdit As SearchLookUpEdit
    Public Property _objSearchLookupEditView As GridView

    Public Property _01prop_dtGEMINIMaster As New DataTable  'TABLE02
    Public Property _02prop_cGEMINIDaftarField As String()
    Public Property _03prop_cGEMINIFieldYgDiFilter As String   'Master (contoh : isi kolom 'k01String' = 'MCUSTOMER')
    Public Property _04prop_cGEMINIValueKodeMasterYgDiFilter As String
    Public Property _05prop_cGEMINIFieldValueMember As String   '"k02String"
    Public Property _06prop_cGEMINIFieldDisplayMember As String '"k03String"
    Public Property _07prop_cGEMINIKeyKolomFilterUntSelect As String

    Private dvViewMasterSKK As New DataView

    Private objColValueMember As GridColumn
    Private objColDisplayMember As GridColumn
    Private objColDisplayMember01 As GridColumn
    Private objColDisplayMember02 As GridColumn
    Private objColDisplayMember03 As GridColumn
    Private objColDisplayMember04 As GridColumn
    Private objColDisplayMember05 As GridColumn

    '--------------------------------
    'SBU..TABLE02
    'k01String = GroupMaster
    'k02String = KeyCodeMaster
    'k03String = NamaMaster
    '================================
    'TABLEMASTER..TABLE02
    'k02String = Kode Master
    'f01String = Nama Master
    'f02String = Kode GroupMaster
    'f03String = Nama GroupMaster
    '--------------------------------

    Public Sub _03BindingAwalDataSource2Field()
        Dim pcfieldValueMember As String = _05prop_cGEMINIFieldValueMember
        Dim pcfieldDisplayMember As String = _06prop_cGEMINIFieldDisplayMember

        objColValueMember = New GridColumn With {.Caption = "Code", .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = "Name", .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}

        With _objSearchLookupEditView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember})

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
            With .Appearance.HeaderPanel
                .Font = New Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Red
                .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End With
        End With

        _objSearchLookupEditView.Columns(pcfieldValueMember).Width = 75
        _objSearchLookupEditView.Columns(pcfieldDisplayMember).Width = 500

        With _objSearchLookupEdit.Properties
            .Appearance.Font = New Font("Courier New", 10, FontStyle.Regular, GraphicsUnit.Point)
            .PopupFormMinSize = New Size With {.Height = 400, .Width = 800}

            ' Initialize data source
            .DisplayMember = pcfieldDisplayMember
            .ValueMember = pcfieldValueMember

            .NullText = ""
        End With

        dvViewMasterSKK = dvMasterSKK()
        _objSearchLookupEdit.Properties.DataSource = Nothing
        _objSearchLookupEdit.Properties.DataSource = dvViewMasterSKK

    End Sub

    Public Sub _03BindingAwalDataSource3Field(ByVal prmNamaField01 As String, ByVal prmCaptionField01 As String,
                                              ByVal prmNamaField02 As String, ByVal prmCaptionField02 As String,
                                              ByVal prmNamaField03 As String, ByVal prmCaptionField03 As String)
        Dim pcfieldValueMember As String = prmNamaField01
        Dim pcfieldDisplayMember As String = prmNamaField02
        Dim pcfieldDisplayMember01 As String = prmNamaField03

        objColValueMember = New GridColumn With {.Caption = prmCaptionField01, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmCaptionField02, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}
        objColDisplayMember01 = New GridColumn With {.Caption = prmCaptionField03, .FieldName = pcfieldDisplayMember01, .VisibleIndex = 2}

        With _objSearchLookupEditView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember, objColDisplayMember01})

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
            With .Appearance.HeaderPanel
                .Font = New Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Red
                .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End With
        End With

        _objSearchLookupEditView.Columns(pcfieldValueMember).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember01).Width = 300

        If prmCaptionField03 = "HargaEmas" Then
            With _objSearchLookupEditView.Columns(pcfieldDisplayMember01).DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:N0}"
            End With
        End If

        With _objSearchLookupEdit.Properties
            .Appearance.Font = New Font("Courier New", 10, FontStyle.Regular, GraphicsUnit.Point)
            .PopupFormMinSize = New Size With {.Height = 500, .Width = 700}

            ' Initialize data source
            .DisplayMember = _06prop_cGEMINIFieldDisplayMember
            .ValueMember = _05prop_cGEMINIFieldValueMember

            .NullText = ""
        End With

        dvViewMasterSKK = dvMasterSKK()
        _objSearchLookupEdit.Properties.DataSource = Nothing
        _objSearchLookupEdit.Properties.DataSource = dvViewMasterSKK
    End Sub

    Public Sub _03BindingAwalDataSource4Field(ByVal prmNamaField01 As String, ByVal prmCaptionField01 As String,
                                              ByVal prmNamaField02 As String, ByVal prmCaptionField02 As String,
                                              ByVal prmNamaField03 As String, ByVal prmCaptionField03 As String,
                                              ByVal prmNamaField04 As String, ByVal prmCaptionField04 As String)
        Dim pcfieldValueMember As String = prmNamaField01
        Dim pcfieldDisplayMember As String = prmNamaField02
        Dim pcfieldDisplayMember01 As String = prmNamaField03
        Dim pcfieldDisplayMember02 As String = prmNamaField04

        objColValueMember = New GridColumn With {.Caption = prmCaptionField01, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmCaptionField02, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}
        objColDisplayMember01 = New GridColumn With {.Caption = prmCaptionField03, .FieldName = pcfieldDisplayMember01, .VisibleIndex = 2}
        objColDisplayMember02 = New GridColumn With {.Caption = prmCaptionField04, .FieldName = pcfieldDisplayMember02, .VisibleIndex = 3}

        With _objSearchLookupEditView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember, objColDisplayMember01, objColDisplayMember02})

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
            With .Appearance.HeaderPanel
                .Font = New Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Red
                .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End With
        End With


        _objSearchLookupEditView.Columns(pcfieldValueMember).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember01).Width = 300
        _objSearchLookupEditView.Columns(pcfieldDisplayMember02).Width = 150

        If prmCaptionField04 = "HargaEmas" Then
            With _objSearchLookupEditView.Columns(pcfieldDisplayMember02).DisplayFormat
                .FormatType = DevExpress.Utils.FormatType.Numeric
                .FormatString = "{0:N0}"
            End With
        End If

        With _objSearchLookupEdit.Properties
            .Appearance.Font = New Font("Courier New", 10, FontStyle.Regular, GraphicsUnit.Point)
            .PopupFormMinSize = New Size With {.Height = 500, .Width = 700}

            ' Initialize data source
            .DisplayMember = _06prop_cGEMINIFieldDisplayMember
            .ValueMember = _05prop_cGEMINIFieldValueMember

            .NullText = ""
        End With

        dvViewMasterSKK = dvMasterSKK()

        _objSearchLookupEdit.Properties.DataSource = Nothing
        _objSearchLookupEdit.Properties.DataSource = dvViewMasterSKK

    End Sub

    Public Sub _03BindingAwalDataSource7Field(ByVal prmNamaField01 As String, ByVal prmCaptionField01 As String,
                                              ByVal prmNamaField02 As String, ByVal prmCaptionField02 As String,
                                              ByVal prmNamaField03 As String, ByVal prmCaptionField03 As String,
                                              ByVal prmNamaField04 As String, ByVal prmCaptionField04 As String,
                                              ByVal prmNamaField05 As String, ByVal prmCaptionField05 As String,
                                              ByVal prmNamaField06 As String, ByVal prmCaptionField06 As String,
                                              ByVal prmNamaField07 As String, ByVal prmCaptionField07 As String)
        Dim pcfieldValueMember As String = prmNamaField01
        Dim pcfieldDisplayMember As String = prmNamaField02
        Dim pcfieldDisplayMember01 As String = prmNamaField03
        Dim pcfieldDisplayMember02 As String = prmNamaField04
        Dim pcfieldDisplayMember03 As String = prmNamaField05
        Dim pcfieldDisplayMember04 As String = prmNamaField06
        Dim pcfieldDisplayMember05 As String = prmNamaField07

        objColValueMember = New GridColumn With {.Caption = prmCaptionField01, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmCaptionField02, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}
        objColDisplayMember01 = New GridColumn With {.Caption = prmCaptionField03, .FieldName = pcfieldDisplayMember01, .VisibleIndex = 2}
        objColDisplayMember02 = New GridColumn With {.Caption = prmCaptionField04, .FieldName = pcfieldDisplayMember02, .VisibleIndex = 3}
        objColDisplayMember03 = New GridColumn With {.Caption = prmCaptionField05, .FieldName = pcfieldDisplayMember03, .VisibleIndex = 4}
        objColDisplayMember04 = New GridColumn With {.Caption = prmCaptionField06, .FieldName = pcfieldDisplayMember04, .VisibleIndex = 5}
        objColDisplayMember05 = New GridColumn With {.Caption = prmCaptionField07, .FieldName = pcfieldDisplayMember05, .VisibleIndex = 6}

        With _objSearchLookupEditView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember, objColDisplayMember01, objColDisplayMember02, objColDisplayMember03, objColDisplayMember04, objColDisplayMember05})

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular, GraphicsUnit.Point)
            With .Appearance.HeaderPanel
                .Font = New Font("Nirmala UI", 9, FontStyle.Bold, GraphicsUnit.Point)
                .ForeColor = Color.Red
                .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End With

        End With

        _objSearchLookupEditView.Columns(pcfieldValueMember).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember01).Width = 300
        _objSearchLookupEditView.Columns(pcfieldDisplayMember02).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember03).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember04).Width = 150
        _objSearchLookupEditView.Columns(pcfieldDisplayMember05).Width = 300

        With _objSearchLookupEdit.Properties
            .Appearance.Font = New Font("Courier New", 10, FontStyle.Regular, GraphicsUnit.Point)
            .PopupFormMinSize = New Size With {.Height = 500, .Width = 1000}

            ' Initialize data source
            .DisplayMember = _06prop_cGEMINIFieldDisplayMember
            .ValueMember = _05prop_cGEMINIFieldValueMember

            .NullText = ""
        End With

        dvViewMasterSKK = dvMasterSKK()

        _objSearchLookupEdit.Properties.DataSource = Nothing
        _objSearchLookupEdit.Properties.DataSource = dvViewMasterSKK
    End Sub

    Private Function dvMasterSKK() As DataView

        Dim dtTemp As New DataTable
        Dim dvView As DataView = New DataView(_01prop_dtGEMINIMaster)

        'Dim pcKolomData = New String() {"k01String", "k02String", "k03String"}

        dtTemp = dvView.ToTable(True, _02prop_cGEMINIDaftarField)
        dvMasterSKK = New DataView(dtTemp)

        Return dvMasterSKK
    End Function

    Public Sub _04FilterDataViewMasterSKK()

        With dvViewMasterSKK
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With dvViewMasterSKK
            .Sort = _03prop_cGEMINIFieldYgDiFilter
            .RowFilter = String.Format(" {0} = '{1}' ", _03prop_cGEMINIFieldYgDiFilter, _04prop_cGEMINIValueKodeMasterYgDiFilter)
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        _objSearchLookupEdit.Properties.DataSource = Nothing
        _objSearchLookupEdit.Properties.DataSource = dvViewMasterSKK

    End Sub

    Public Function _05GetRecordTerpilih() As DataRow()
        Dim pdtCopy As DataTable
        pdtCopy = _01prop_dtGEMINIMaster.Copy()

        Dim pdDataRow() As DataRow = Nothing
        If Not String.IsNullOrEmpty(_objSearchLookupEdit.EditValue) Then
            pdDataRow = pdtCopy.Select(_07prop_cGEMINIKeyKolomFilterUntSelect & " = '" & _objSearchLookupEdit.EditValue & "'")
        End If

        Return pdDataRow
    End Function

End Class
