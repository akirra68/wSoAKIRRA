Imports DevExpress.Drawing.Internal.Fonts.Interop
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class ctrlWSNasaMaster
    Inherits SearchLookUpEdit
    Implements IDisposable

#Region "dispose"
    Private disposedValue As Boolean

    Protected Overrides Sub Dispose(disposing As Boolean)
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

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Property _prop01WSDataSource As New DataTable  'TABLE02
    Public Property _prop02WSDaftarField As String()
    Public Property _prop03WSFieldYgDiFilter As String   'Master (contoh : isi kolom 'k01String' = 'MCUSTOMER')
    Public Property _prop04WSValueKodeMasterYgDiFilter As String
    Public Property _prop05WSFieldValueMember As String   '"k02String"
    Public Property _prop06WSFieldDisplayMember As String '"k03String"
    Public Property _prop07WSKeyKolomFilterUntSelect As String

    Private _pdvWSViewDataSource As New DataView
    Private objColValueMember As GridColumn
    Private objColDisplayMember As GridColumn
    Private objColDisplayMember01 As GridColumn
    Private objColDisplayMember02 As GridColumn
    Private objColDisplayMember03 As GridColumn
    Private objColDisplayMember04 As GridColumn

    ' ===================== CREATED BY AKIRRA - 25/07/09 =====================
    ' custom function to bind 1 field/column to the SEARCHLOOKUPEDIT
    Public Sub _pbf00BindingDataSource1Field(Optional ByVal vsCaption As String = "Name", Optional ByVal viWidthColField01 As Int16 = Nothing)
        Dim vsFieldMember As String = _prop05WSFieldValueMember

        objColValueMember = New GridColumn With {.Caption = vsCaption, .FieldName = vsFieldMember, .VisibleIndex = 0}

        Dim _oGridView As New GridView()
        AddHandler _oGridView.CustomDrawRowIndicator, AddressOf pvMCustomRowIndicator

        With Properties
            .PopupView = _oGridView
            '.View = objGridView

            .Appearance.Font = New Font("Courier New", 9, FontStyle.Bold)
            .Appearance.ForeColor = Color.DarkSlateGray

            .AppearanceReadOnly.BackColor = Color.Green
            .AppearanceReadOnly.ForeColor = Color.White

            .PopupFormMinSize = New Size(300, 300)
            .PopupFormSize = New Size(300, 300)

            .DisplayMember = vsFieldMember
            .ValueMember = vsFieldMember

            .NullText = ""
        End With

        With _oGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember})

            .OptionsView.ShowIndicator = True
            .IndicatorWidth = 45

            .Appearance.HeaderPanel.Font = New Font("Nirmala UI", 9, FontStyle.Bold)
            .Appearance.HeaderPanel.ForeColor = Color.Navy
            .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Appearance.Row.ForeColor = Color.Navy

            .Appearance.FocusedRow.Font = New Font("Courier New", 10, FontStyle.Bold Or FontStyle.Italic)
            .Appearance.FocusedRow.ForeColor = Color.DarkSlateGray


            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True

            .Appearance.EvenRow.BackColor = Color.White
            .Appearance.OddRow.BackColor = Color.FromArgb(235, 235, 235)

            .BestFitColumns()
            .Columns(vsFieldMember).MinWidth = viWidthColField01
        End With

        _pdvWSViewDataSource = _cm01dvWSDataSource()
        Properties.DataSource = _pdvWSViewDataSource
    End Sub
    ' ================================================================================

    Public Sub _pb01BindingAwalDataSource2Field(Optional ByVal prmcCaptionValueMember As String = "Code",
                                                Optional ByVal prmcCaptionDisplayMember As String = "Name",
                                                Optional ByVal viWidthColField01 As Int16 = Nothing, Optional ByVal viWidthColField02 As Int16 = Nothing)
        Dim pcfieldValueMember As String = _prop05WSFieldValueMember
        Dim pcfieldDisplayMember As String = _prop06WSFieldDisplayMember

        objColValueMember = New GridColumn With {.Caption = prmcCaptionValueMember, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmcCaptionDisplayMember, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}

        Dim objGridView As GridView = New GridView()
        AddHandler objGridView.CustomDrawRowIndicator, AddressOf pvMCustomRowIndicator

        With Properties
            .PopupView = objGridView
            '.View = objGridView

            .Appearance.Font = New Font("Courier New", 9, FontStyle.Bold)
            .Appearance.ForeColor = Color.DarkSlateGray

            .AppearanceReadOnly.BackColor = Color.Green
            .AppearanceReadOnly.ForeColor = Color.White

            .PopupFormMinSize = New Size(450, 400)
            .PopupFormSize = New Size(450, 400)

            .DisplayMember = pcfieldDisplayMember
            .ValueMember = pcfieldValueMember

            .NullText = ""
        End With

        With objGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember})

            .OptionsView.ShowIndicator = True
            .IndicatorWidth = 45

            .Appearance.HeaderPanel.Font = New Font("Nirmala UI", 9, FontStyle.Bold)
            .Appearance.HeaderPanel.ForeColor = Color.Navy
            .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Appearance.Row.ForeColor = Color.Navy

            .Appearance.FocusedRow.Font = New Font("Courier New", 10, FontStyle.Bold Or FontStyle.Italic)
            .Appearance.FocusedRow.ForeColor = Color.DarkSlateGray


            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True

            .Appearance.EvenRow.BackColor = Color.White
            .Appearance.OddRow.BackColor = Color.FromArgb(235, 235, 235)

            .BestFitColumns()
            .Columns(pcfieldValueMember).MinWidth = viWidthColField01
            .Columns(pcfieldDisplayMember).MinWidth = viWidthColField02
        End With

        _pdvWSViewDataSource = _cm01dvWSDataSource()
        Properties.DataSource = _pdvWSViewDataSource
    End Sub

    Public Sub _pb02BindingAwalDataSource3Field(ByVal prmNamaField01 As String, ByVal prmCaptionField01 As String,
                                                ByVal prmNamaField02 As String, ByVal prmCaptionField02 As String,
                                                ByVal prmNamaField03 As String, ByVal prmCaptionField03 As String,
                                                Optional ByVal viWidthColField01 As Int16 = Nothing, Optional ByVal viWidthColField02 As Int16 = Nothing,
                                                Optional ByVal viWidthColField03 As Int16 = Nothing)
        Dim pcfieldValueMember As String = prmNamaField01
        Dim pcfieldDisplayMember As String = prmNamaField02
        Dim pcfieldDisplayMember01 As String = prmNamaField03

        objColValueMember = New GridColumn With {.Caption = prmCaptionField01, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmCaptionField02, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}
        objColDisplayMember01 = New GridColumn With {.Caption = prmCaptionField03, .FieldName = pcfieldDisplayMember01, .VisibleIndex = 2}

        Dim objGridView As GridView = New GridView()
        AddHandler objGridView.CustomDrawRowIndicator, AddressOf pvMCustomRowIndicator

        With Properties
            .PopupView = objGridView
            '.View = objGridView

            .Appearance.Font = New Font("Courier New", 9, FontStyle.Bold)
            .Appearance.ForeColor = Color.DarkSlateGray

            .AppearanceReadOnly.BackColor = Color.Green
            .AppearanceReadOnly.ForeColor = Color.White

            .PopupFormMinSize = New Size(600, 450)
            .PopupFormSize = New Size(600, 450)


            .DisplayMember = _prop06WSFieldDisplayMember
            .ValueMember = _prop05WSFieldValueMember

            .NullText = ""
        End With

        With objGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember, objColDisplayMember01})

            .OptionsView.ShowIndicator = True
            .IndicatorWidth = 45

            .Appearance.HeaderPanel.Font = New Font("Nirmala UI", 9, FontStyle.Bold)
            .Appearance.HeaderPanel.ForeColor = Color.Navy
            .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Appearance.Row.ForeColor = Color.Navy

            .Appearance.FocusedRow.Font = New Font("Courier New", 10, FontStyle.Bold Or FontStyle.Italic)
            .Appearance.FocusedRow.ForeColor = Color.DarkSlateGray

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True

            .Appearance.EvenRow.BackColor = Color.White
            .Appearance.OddRow.BackColor = Color.FromArgb(235, 235, 235)

            .BestFitColumns()
            .Columns(pcfieldValueMember).MinWidth = viWidthColField01
            .Columns(pcfieldDisplayMember).MinWidth = viWidthColField02
            .Columns(pcfieldDisplayMember01).MinWidth = viWidthColField03
        End With

        _pdvWSViewDataSource = _cm01dvWSDataSource()
        Properties.DataSource = _pdvWSViewDataSource
    End Sub

    Public Sub _pb03BindingAwalDataSource4Field(ByVal prmNamaField01 As String, ByVal prmCaptionField01 As String,
                                                ByVal prmNamaField02 As String, ByVal prmCaptionField02 As String,
                                                ByVal prmNamaField03 As String, ByVal prmCaptionField03 As String,
                                                ByVal prmNamaField04 As String, ByVal prmCaptionField04 As String,
                                                Optional ByVal viWidthColField01 As Int16 = Nothing, Optional ByVal viWidthColField02 As Int16 = Nothing,
                                                Optional ByVal viWidthColField03 As Int16 = Nothing, Optional ByVal viWidthColField04 As Int16 = Nothing)
        Dim pcfieldValueMember As String = prmNamaField01
        Dim pcfieldDisplayMember As String = prmNamaField02
        Dim pcfieldDisplayMember01 As String = prmNamaField03
        Dim pcfieldDisplayMember02 As String = prmNamaField04

        objColValueMember = New GridColumn With {.Caption = prmCaptionField01, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmCaptionField02, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}
        objColDisplayMember01 = New GridColumn With {.Caption = prmCaptionField03, .FieldName = pcfieldDisplayMember01, .VisibleIndex = 2}
        objColDisplayMember02 = New GridColumn With {.Caption = prmCaptionField04, .FieldName = pcfieldDisplayMember02, .VisibleIndex = 3}

        Dim objGridView As GridView = New GridView()
        AddHandler objGridView.CustomDrawRowIndicator, AddressOf pvMCustomRowIndicator

        With Properties
            .PopupView = objGridView
            '.View = objGridView

            .Appearance.Font = New Font("Courier New", 9, FontStyle.Bold)
            .Appearance.ForeColor = Color.DarkSlateGray

            .AppearanceReadOnly.BackColor = Color.Green
            .AppearanceReadOnly.ForeColor = Color.White

            .PopupFormMinSize = New Size(700, 500)
            .PopupFormSize = New Size(700, 500)
            .DisplayMember = _prop06WSFieldDisplayMember
            .ValueMember = _prop05WSFieldValueMember

            .NullText = ""
        End With

        With objGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember, objColDisplayMember01, objColDisplayMember02})

            .OptionsView.ShowIndicator = True
            .IndicatorWidth = 45

            .Appearance.HeaderPanel.Font = New Font("Nirmala UI", 9, FontStyle.Bold)
            .Appearance.HeaderPanel.ForeColor = Color.Navy
            .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Appearance.Row.ForeColor = Color.Navy

            .Appearance.FocusedRow.Font = New Font("Courier New", 10, FontStyle.Bold Or FontStyle.Italic)
            .Appearance.FocusedRow.ForeColor = Color.DarkSlateGray

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True

            .Appearance.EvenRow.BackColor = Color.White
            .Appearance.OddRow.BackColor = Color.FromArgb(235, 235, 235)

            .BestFitColumns()
            .Columns(pcfieldValueMember).MinWidth = viWidthColField01
            .Columns(pcfieldDisplayMember).MinWidth = viWidthColField02
            .Columns(pcfieldDisplayMember01).MinWidth = viWidthColField03
            .Columns(pcfieldDisplayMember02).MinWidth = viWidthColField04
        End With

        _pdvWSViewDataSource = _cm01dvWSDataSource()
        Properties.DataSource = _pdvWSViewDataSource
    End Sub

    Public Sub _pb04BindingAwalDataSource5Field(ByVal prmNamaField01 As String, ByVal prmCaptionField01 As String,
                                                ByVal prmNamaField02 As String, ByVal prmCaptionField02 As String,
                                                ByVal prmNamaField03 As String, ByVal prmCaptionField03 As String,
                                                ByVal prmNamaField04 As String, ByVal prmCaptionField04 As String,
                                                ByVal prmNamaField05 As String, ByVal prmCaptionField05 As String,
                                                Optional ByVal viWidthColField01 As Int16 = Nothing, Optional ByVal viWidthColField02 As Int16 = Nothing,
                                                Optional ByVal viWidthColField03 As Int16 = Nothing, Optional ByVal viWidthColField04 As Int16 = Nothing,
                                                Optional viWidthColField05 As Int16 = Nothing)
        Dim pcfieldValueMember As String = prmNamaField01
        Dim pcfieldDisplayMember As String = prmNamaField02
        Dim pcfieldDisplayMember01 As String = prmNamaField03
        Dim pcfieldDisplayMember02 As String = prmNamaField04
        Dim pcfieldDisplayMember03 As String = prmNamaField05

        objColValueMember = New GridColumn With {.Caption = prmCaptionField01, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmCaptionField02, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}
        objColDisplayMember01 = New GridColumn With {.Caption = prmCaptionField03, .FieldName = pcfieldDisplayMember01, .VisibleIndex = 2}
        objColDisplayMember02 = New GridColumn With {.Caption = prmCaptionField04, .FieldName = pcfieldDisplayMember02, .VisibleIndex = 3}
        objColDisplayMember03 = New GridColumn With {.Caption = prmCaptionField05, .FieldName = pcfieldDisplayMember03, .VisibleIndex = 4}

        Dim objGridView As GridView = New GridView()
        AddHandler objGridView.CustomDrawRowIndicator, AddressOf pvMCustomRowIndicator

        With Properties
            .PopupView = objGridView
            '.View = objGridView

            .Appearance.Font = New Font("Courier New", 9, FontStyle.Bold)
            .Appearance.ForeColor = Color.DarkSlateGray

            .AppearanceReadOnly.BackColor = Color.Green
            .AppearanceReadOnly.ForeColor = Color.White

            .PopupFormMinSize = New Size(800, 550)
            .PopupFormSize = New Size(800, 550)
            .DisplayMember = _prop06WSFieldDisplayMember
            .ValueMember = _prop05WSFieldValueMember

            .NullText = ""
        End With

        With objGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember, objColDisplayMember01, objColDisplayMember02, objColDisplayMember03})

            .OptionsView.ShowIndicator = True
            .IndicatorWidth = 45

            .Appearance.HeaderPanel.Font = New Font("Nirmala UI", 9, FontStyle.Bold)
            .Appearance.HeaderPanel.ForeColor = Color.Navy
            .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Appearance.Row.ForeColor = Color.Navy

            .Appearance.FocusedRow.Font = New Font("Courier New", 10, FontStyle.Bold Or FontStyle.Italic)
            .Appearance.FocusedRow.ForeColor = Color.DarkSlateGray

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True

            .Appearance.EvenRow.BackColor = Color.White
            .Appearance.OddRow.BackColor = Color.FromArgb(235, 235, 235)

            .BestFitColumns()
            .Columns(pcfieldValueMember).MinWidth = viWidthColField01
            .Columns(pcfieldDisplayMember).MinWidth = viWidthColField02
            .Columns(pcfieldDisplayMember01).MinWidth = viWidthColField03
            .Columns(pcfieldDisplayMember02).MinWidth = viWidthColField04
            .Columns(pcfieldDisplayMember03).MinWidth = viWidthColField05
        End With

        _pdvWSViewDataSource = _cm01dvWSDataSource()
        Properties.DataSource = _pdvWSViewDataSource
    End Sub

    Public Sub _pb05BindingAwalDataSource6Field(ByVal prmNamaField01 As String, ByVal prmCaptionField01 As String,
                                                ByVal prmNamaField02 As String, ByVal prmCaptionField02 As String,
                                                ByVal prmNamaField03 As String, ByVal prmCaptionField03 As String,
                                                ByVal prmNamaField04 As String, ByVal prmCaptionField04 As String,
                                                ByVal prmNamaField05 As String, ByVal prmCaptionField05 As String,
                                                ByVal prmNamaField06 As String, ByVal prmCaptionField06 As String,
                                                Optional ByVal viWidthColField01 As Int16 = Nothing, Optional ByVal viWidthColField02 As Int16 = Nothing,
                                                Optional ByVal viWidthColField03 As Int16 = Nothing, Optional ByVal viWidthColField04 As Int16 = Nothing,
                                                Optional viWidthColField05 As Int16 = Nothing, Optional viWidthColField06 As Int16 = Nothing)
        Dim pcfieldValueMember As String = prmNamaField01
        Dim pcfieldDisplayMember As String = prmNamaField02
        Dim pcfieldDisplayMember01 As String = prmNamaField03
        Dim pcfieldDisplayMember02 As String = prmNamaField04
        Dim pcfieldDisplayMember03 As String = prmNamaField05
        Dim pcfieldDisplayMember04 As String = prmNamaField06

        objColValueMember = New GridColumn With {.Caption = prmCaptionField01, .FieldName = pcfieldValueMember, .VisibleIndex = 0}
        objColDisplayMember = New GridColumn With {.Caption = prmCaptionField02, .FieldName = pcfieldDisplayMember, .VisibleIndex = 1}
        objColDisplayMember01 = New GridColumn With {.Caption = prmCaptionField03, .FieldName = pcfieldDisplayMember01, .VisibleIndex = 2}
        objColDisplayMember02 = New GridColumn With {.Caption = prmCaptionField04, .FieldName = pcfieldDisplayMember02, .VisibleIndex = 3}
        objColDisplayMember03 = New GridColumn With {.Caption = prmCaptionField05, .FieldName = pcfieldDisplayMember03, .VisibleIndex = 4}
        objColDisplayMember04 = New GridColumn With {.Caption = prmCaptionField06, .FieldName = pcfieldDisplayMember04, .VisibleIndex = 5}

        Dim objGridView As GridView = New GridView()
        AddHandler objGridView.CustomDrawRowIndicator, AddressOf pvMCustomRowIndicator

        With Properties
            .PopupView = objGridView
            '.View = objGridView

            .Appearance.Font = New Font("Courier New", 9, FontStyle.Bold)
            .Appearance.ForeColor = Color.DarkSlateGray

            .AppearanceReadOnly.BackColor = Color.Green
            .AppearanceReadOnly.ForeColor = Color.White

            .PopupFormMinSize = New Size(900, 600)
            .PopupFormSize = New Size(900, 600)
            .DisplayMember = _prop06WSFieldDisplayMember
            .ValueMember = _prop05WSFieldValueMember

            .NullText = ""
        End With

        With objGridView
            .Columns.Clear()
            .Columns.AddRange(New GridColumn() {objColValueMember, objColDisplayMember, objColDisplayMember01, objColDisplayMember02, objColDisplayMember03, objColDisplayMember04})

            .OptionsView.ShowIndicator = True
            .IndicatorWidth = 45

            .Appearance.HeaderPanel.Font = New Font("Nirmala UI", 9, FontStyle.Bold)
            .Appearance.HeaderPanel.ForeColor = Color.Navy
            .Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            .Appearance.Row.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Appearance.Row.ForeColor = Color.Navy

            .Appearance.FocusedRow.Font = New Font("Courier New", 10, FontStyle.Bold Or FontStyle.Italic)
            .Appearance.FocusedRow.ForeColor = Color.DarkSlateGray

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True

            .Appearance.EvenRow.BackColor = Color.White
            .Appearance.OddRow.BackColor = Color.FromArgb(235, 235, 235)

            .BestFitColumns()
            .Columns(pcfieldValueMember).MinWidth = viWidthColField01
            .Columns(pcfieldDisplayMember).MinWidth = viWidthColField02
            .Columns(pcfieldDisplayMember01).MinWidth = viWidthColField03
            .Columns(pcfieldDisplayMember02).MinWidth = viWidthColField04
            .Columns(pcfieldDisplayMember03).MinWidth = viWidthColField05
            .Columns(pcfieldDisplayMember04).MinWidth = viWidthColField06
        End With

        _pdvWSViewDataSource = _cm01dvWSDataSource()
        Properties.DataSource = _pdvWSViewDataSource
    End Sub

    Private Function _cm01dvWSDataSource() As DataView

        Dim dtTemp As New DataTable
        Dim dvView As DataView = New DataView(_prop01WSDataSource)

        'Dim pcKolomData = New String() {"k01String", "k02String", "k03String"}

        dtTemp = dvView.ToTable(True, _prop02WSDaftarField)
        _cm01dvWSDataSource = New DataView(dtTemp)

        Return _cm01dvWSDataSource
    End Function

    Public Sub _pb04FilterDataViewMasterSKK()

        With _pdvWSViewDataSource
            .Sort = [String].Empty
            .RowFilter = [String].Empty
        End With

        With _pdvWSViewDataSource
            .Sort = _prop03WSFieldYgDiFilter
            .RowFilter = String.Format(" {0} = '{1}' ", _prop03WSFieldYgDiFilter, _prop04WSValueKodeMasterYgDiFilter)
            .RowStateFilter = DataViewRowState.CurrentRows
        End With

        Properties.DataSource = Nothing
        Properties.DataSource = _pdvWSViewDataSource

    End Sub

    Public Function _pb05GetRecordTerpilih() As DataRow()
        Dim pdtCopy As DataTable
        pdtCopy = _prop01WSDataSource.Copy()

        Dim pdDataRow() As DataRow
        pdDataRow = pdtCopy.Select(_prop07WSKeyKolomFilterUntSelect & " = '" & Me.EditValue & "'")

        Return pdDataRow
    End Function

    Private Sub pvMCustomRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
            e.Appearance.Font = New Font("Courier New", 8, FontStyle.Bold)
            e.Appearance.ForeColor = Color.DarkSlateGray
        End If

        If e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Header Then
            e.Appearance.DrawBackground(e.Cache, e.Bounds)

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            Dim _cFont As New Font("Nirmala UI", 9, FontStyle.Bold)
            Dim _cFontColour As Brush = Brushes.DarkSlateGray

            e.Cache.DrawString("No.", _cFont, _cFontColour, e.Bounds, sf)
            e.Handled = True
        End If
    End Sub

End Class
