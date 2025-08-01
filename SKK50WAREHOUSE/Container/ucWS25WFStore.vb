Imports System.Numerics
Imports System.Windows
Imports DevExpress.CodeParser
Imports DevExpress.DashboardWin.Native
Imports DevExpress.Skins
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGantt.Scheduling
Imports DevExpress.XtraRichEdit.Layout
Imports SKK01CORE
Imports SKK02OBJECTS

Public Class ucWS25WFStore

    Property _prop01User As clsWSNasaUser
    Property _prop02DataStore As DataTable
    Property _prop03Target As Boolean ' Edit / Add

    Private pdtDataForSave As DataTable
    Private ctrlDataForSave As clsWSNasaTemplateDataLarge

    Private objExecSQL As clsWSNasaHelper

    Private _oldHeadQuarterValue As Object = Nothing
    Private _oldRegionValue As Object = Nothing

    Private _isLoading As Boolean = False
    Private _isInitializing As Boolean = False

#Region "Form - Event"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pdtDataForSave = New DataTable
        ctrlDataForSave = New clsWSNasaTemplateDataLarge With {.prop_dtsTABLELARGE = pdtDataForSave}
        ctrlDataForSave.dtInitsTABLELARGE()
        objExecSQL = New clsWSNasaHelper
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        pdtDataForSave.Dispose()
        ctrlDataForSave.Dispose()

    End Sub

    Private Sub ucWS25WFStore_Load(sender As Object, e As EventArgs) Handles Me.Load
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_prop01User._UserProp10Skin)

        Bar1.Visible = True
        BarManager1.AllowShowToolbarsPopup = False
        BarManager1.AllowQuickCustomization = False
        Bar1.OptionsBar.DrawDragBorder = False
        Bar1.BarItemHorzIndent = 10
        '  _cm01InitDataControl()
        _isInitializing = True

        _cm02UpdateData()
        _cm01InitDataControl()
        ctrlDataForSave.prop_dtsTABLELARGE.Clear()



        _isInitializing = False

    End Sub
#End Region

#Region "Custom - Method"

    Private Sub _cm00ClearControl()
        _01ctrlRTrading.Checked = True
        _02ctrlRNonTrading.Checked = False
        _03CActive.Checked = True
        _04cTypeOfStore.EditValue = " "
        _05cRegion.EditValue = " "
        _06cCodeAccount.EditValue = " "
        _07cStoreCode.EditValue = " "
        _08nTeleponToko.EditValue = " "
        _09cAccountName.EditValue = " "
        _10cAlamatToko.EditValue = " "
        _11nTeleponPemilik.EditValue = " "
        _12cPemilik.EditValue = " "
        _13DateOfBirth.EditValue = " "
        _14Email.EditValue = " "
        _15KTP.EditValue = " "
        _16NPWP.EditValue = " "
        _17PIC.EditValue = " "
        _18cStoreDiscount.EditValue = " "
        _19cKAE.EditValue = " "
        _20AlamatPemilik.EditValue = " "
        _21StoreName.EditValue = " "
        _22Categories.EditValue = " "
        _23TOP.EditValue = " "
        _24bCheckHeadQuarter.Checked = True
    End Sub

    Private Sub _cm01InitDataControl()
        Dim pdtRegion As New DataTable
        Dim pdtQurter As New DataTable

        Using objTargetPenjualan As New clsWSNasaSelect4CtrlRepoProses With {._prop01User = _prop01User}
            pdtRegion = objTargetPenjualan._pb11GetDataRegion
            pdtQurter = objTargetPenjualan._pb12GetDataHeadquarter
        End Using

        _05cRegion.Properties.DataSource = Nothing
        With _05cRegion
            ._prop01WSDataSource = pdtRegion
            ._prop02WSDaftarField = New String() {"k14String", "k12String"}
            ._prop05WSFieldValueMember = "k14String"
            ._prop06WSFieldDisplayMember = "k12String"
        End With
        _05cRegion._pb01BindingAwalDataSource2Field("Code", "Region")

        With _25cHeadQuarter
            ._prop01WSDataSource = pdtQurter
            ._prop02WSDaftarField = New String() {"k14String", "k12String"}
            ._prop05WSFieldValueMember = "k14String"
            ._prop06WSFieldDisplayMember = "k12String"
        End With
        _25cHeadQuarter._pb01BindingAwalDataSource2Field("Code", "Headquarter")

        _03CActive.Checked = True

        If _prop03Target = False Then
            _24bCheckHeadQuarter.Checked = True
            _25cHeadQuarter.Enabled = False
        End If

        _06cCodeAccount.Properties.ReadOnly = True
        _07cStoreCode.Properties.ReadOnly = True
        _06cCodeAccount.BackColor = Color.FromArgb(242, 249, 255)
        _07cStoreCode.BackColor = Color.FromArgb(242, 249, 255)

        _01ctrlRTrading.Checked = True

        _oldHeadQuarterValue = _25cHeadQuarter.EditValue
        _oldRegionValue = _05cRegion.EditValue
    End Sub



    Private Sub _cm02UpdateData()
        If _prop03Target Then

            For Each dtRow As DataRow In _prop02DataStore.Rows
                If dtRow("f05String") = "NON-TRADING" Then
                    _02ctrlRNonTrading.Checked = True
                Else dtRow("f05String") = "TRADING"
                    _01ctrlRTrading.Checked = True
                End If

                Dim k02Part As String = dtRow("k02String").ToString().Substring(0, 6)
                If Not k02Part.Contains(dtRow("f01String").ToString()) Then
                    _isInitializing = True
                    _25cHeadQuarter.EditValue = dtRow("f01String")
                    _24bCheckHeadQuarter.Checked = False
                    _05cRegion.Enabled = False
                    _isInitializing = False
                Else
                    _isInitializing = True
                    _05cRegion.EditValue = dtRow("f37String")
                    _24bCheckHeadQuarter.Checked = True
                    _25cHeadQuarter.Enabled = False
                    _isInitializing = False
                End If

                _03CActive.Checked = If(dtRow("f03String") = "Active", True, False)
                _04cTypeOfStore.EditValue = dtRow("f06String")
                _06cCodeAccount.EditValue = dtRow("f01String")
                _07cStoreCode.EditValue = dtRow("k02String")
                _08nTeleponToko.EditValue = dtRow("f17String")
                _09cAccountName.EditValue = dtRow("k03String")
                _10cAlamatToko.EditValue = dtRow("f39String")
                _11nTeleponPemilik.EditValue = dtRow("f21String")
                _12cPemilik.EditValue = dtRow("f19String")
                _13DateOfBirth.EditValue = dtRow("f20String")
                _14Email.EditValue = dtRow("f18String")
                _15KTP.EditValue = dtRow("f22String")
                _16NPWP.EditValue = dtRow("f04String")
                _17PIC.EditValue = dtRow("f07String")
                _18cStoreDiscount.EditValue = dtRow("f08String")
                _19cKAE.EditValue = dtRow("f23String")
                _20AlamatPemilik.EditValue = dtRow("f40String")
                _21StoreName.EditValue = dtRow("f02String")
                _22Categories.EditValue = dtRow("f09String")
                _23TOP.EditValue = dtRow("f10String")
            Next
        End If
    End Sub

    Private Sub _cm03ProsesSave()
        Dim result As DialogResult
        result = MessageBox.Show("Are you sure the data you entered is correct?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim pdtDataForSave As New DataTable
            Dim pcSaveStoredProcedure As String = "spTABLE52Save"

            pdtDataForSave = _cm04PrepareDataForSave(_prop03Target)

            Dim objNasa As New clsWSNasaHelper
            Dim pnJmlRec As Integer = objNasa._pbWSNasaHelperExec01SPSQLProses(
                                        _prop01User._UserProp08TargetNetwork,
                                        clsWSNasaHelper._pnmDatabaseName.TABLEMASTER,
                                        2, pcSaveStoredProcedure, "@tpDataForSaving", pdtDataForSave)

            ' Query update selalu dijalankan 1 kali
            Dim pCode As String = If(_24bCheckHeadQuarter.Checked, _05cRegion.EditValue, _25cHeadQuarter.EditValue)
            Dim pcSQLUpdate As String = "UPDATE TABLE521 " &
            "SET f10Int = f10Int + " & pdtDataForSave.Rows.Count & " " &
            "WHERE k11String = 'PROV' AND k13String = LEFT('" & pCode & "',3) + '000';"

            Dim pnHasilUpdate As Integer = objExecSQL._pbWSNasaHelperExec01SQLScript(
                                            _prop01User._UserProp08TargetNetwork,
                                            clsWSNasaHelper._pnmDatabaseName.TABLEMASTER,
                                            pcSQLUpdate)

            ' Jika _24bCheckHeadQuarter.Checked = True, jalankan tambahan insert
            If _24bCheckHeadQuarter.Checked = True Then
                If _16NPWP.SelectedIndex = 0 Then

                    Dim pcSQLInsert As String = "INSERT INTO [dbo].[TABLE521] " &
                                            "VALUES (NEWID(), " &
                                            "'STORE', " &
                                            "'" & _21StoreName.Text & "', " &
                                            "' ', " &
                                            "'" & _06cCodeAccount.EditValue.ToString() & "', '" & _05cRegion.EditValue.ToString &
                                            "', '', '', '', " &
                                            "0,0,0,0,0.0,0.0,0.0, " &
                                            "GETDATE(), '3000-01-01','" & _prop01User._UserProp03cUserName & "', '', '" & _prop01User._UserProp03cUserName & "', '');"
                    Dim pnHasilInsert As Integer = objExecSQL._pbWSNasaHelperExec01SQLScript(
                                            _prop01User._UserProp08TargetNetwork,
                                            clsWSNasaHelper._pnmDatabaseName.TABLEMASTER,
                                            pcSQLInsert)
                End If

            Else
                Dim pcSQLUpdateStore As String = "UPDATE TABLE521 " &
                            "SET f10Int = f10Int + " & pdtDataForSave.Rows.Count & " " &
                            "WHERE k11String = 'STORE' AND k14String = '" & _25cHeadQuarter.EditValue & "' and k12String = '" & _25cHeadQuarter.Text & "';"

                Dim pnHasilUpdateStore As Integer = objExecSQL._pbWSNasaHelperExec01SQLScript(
                                                _prop01User._UserProp08TargetNetwork,
                                                clsWSNasaHelper._pnmDatabaseName.TABLEMASTER,
                                                pcSQLUpdateStore)
            End If
            If pdtDataForSave.Rows.Count > 0 Then
                MessageBox.Show("Data has been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.FindForm().Close()
            Else
                MessageBox.Show("No data was saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Save operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function _cm04PrepareDataForSave(ByVal pTarget As Boolean) As DataTable
        ctrlDataForSave.prop_dtsTABLELARGE.Clear()
        If pTarget = False Then
            ctrlDataForSave.dtAddNewsTABLELARGE(
                     "", _07cStoreCode.EditValue, _09cAccountName.EditValue,
                    If(_24bCheckHeadQuarter.Checked, _06cCodeAccount.EditValue, _25cHeadQuarter.EditValue), If(_24bCheckHeadQuarter.Checked, _21StoreName.EditValue, _25cHeadQuarter.Text), If(_03CActive.Checked, "Active", "inActive"), _16NPWP.EditValue, If(_02ctrlRNonTrading.Checked, "NON-TRADING", "TRADING"),
                    _Fn08SafeToString(_04cTypeOfStore.EditValue), _Fn08SafeToString(_17PIC.EditValue), _Fn08SafeToString(_18cStoreDiscount.EditValue), _Fn08SafeToString(_22Categories.EditValue), _Fn08SafeToString(_23TOP.EditValue),
                    _05cRegion.Text, "", "", "", "",
                    "", _Fn08SafeToString(_08nTeleponToko.EditValue), _Fn08SafeToString(_14Email.EditValue), _Fn08SafeToString(_12cPemilik.EditValue), _Fn08SafeToString(_13DateOfBirth.EditValue),
                    _Fn08SafeToString(_11nTeleponPemilik.EditValue), _Fn08SafeToString(_15KTP.EditValue), _Fn08SafeToString(_19cKAE.EditValue), "", "", "", "", "", "", "",
                    "", "", "", "", "", "", _05cRegion.EditValue, "", _Fn08SafeToString(_10cAlamatToko.EditValue), _Fn08SafeToString(_20AlamatPemilik.EditValue),
                    0, 0, 0, 0.0, 0.0, 0.0,
                    "3000-01-01", "3000-01-01", Date.Now,
                    _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)
        Else
            For Each dtRow As DataRow In _prop02DataStore.Rows
                ctrlDataForSave.dtAddNewsTABLELARGE(
                   dtRow("k01String"), _07cStoreCode.EditValue, _09cAccountName.EditValue,
                    _06cCodeAccount.EditValue, _21StoreName.EditValue, If(_03CActive.Checked, "Active", "InActive"), _16NPWP.EditValue, If(_02ctrlRNonTrading.Checked, "NON-TRADING", "TRADING"),
                    _04cTypeOfStore.EditValue, CStr(_17PIC.EditValue), CStr(_18cStoreDiscount.EditValue), CStr(_22Categories.EditValue), CStr(_23TOP.EditValue),
                    _05cRegion.EditValue, "", "", "", "",
                    "", CStr(_08nTeleponToko.EditValue), CStr(_14Email.EditValue), CStr(_12cPemilik.EditValue), CStr(_13DateOfBirth.EditValue),
                    CStr(_11nTeleponPemilik.EditValue), CStr(_15KTP.EditValue), (_19cKAE.EditValue), "", "", "", "", "", "", "",
                    "", "", "", "", "", "", _05cRegion.EditValue, "", CStr(_10cAlamatToko.EditValue), CStr(_20AlamatPemilik.EditValue),
                    0, 0, 0, 0.0, 0.0, 0.0,
                    "3000-01-01", "3000-01-01", Date.Now,
                    _prop01User._UserProp02cUserID, _prop01User._UserProp03cUserName,
                    _prop01User._UserProp04ComputerName, _prop01User._UserProp05IPLocalAddress, _prop01User._UserProp06IPPublicAddress)

            Next
        End If

        ctrlDataForSave.prop_dtsTABLELARGE.AcceptChanges()
        Return ctrlDataForSave.prop_dtsTABLELARGE
    End Function

    Private Sub _cm05DisplayCodeAccounct(ByVal pTarget As Boolean)
        Dim pcNoDocPicking As String = ""
        Using objNoDoc As clsWSNasaSelect4AllProsesMaster = New clsWSNasaSelect4AllProsesMaster With {._prop01User = _prop01User,
                                                                                                        ._prop02String = If(pTarget, _05cRegion.EditValue, _25cHeadQuarter.EditValue)}
            pcNoDocPicking = objNoDoc._pb521GetDataAccountCode()
        End Using

        If pcNoDocPicking <> "" Then
            If _24bCheckHeadQuarter.Checked Then
                _06cCodeAccount.EditValue = pcNoDocPicking


            Else
                ' _06cCodeAccount.EditValue = pcNoDocPicking
                _06cCodeAccount.EditValue = _25cHeadQuarter.EditValue

                If _16NPWP.EditValue Is Nothing OrElse String.IsNullOrWhiteSpace(_16NPWP.EditValue.ToString()) Then
                    _07cStoreCode.EditValue = ""
                ElseIf _16NPWP.EditValue.ToString() = "NPWP" Then


                    _07cStoreCode.EditValue = _06cCodeAccount.EditValue & "-01"
                Else
                    _07cStoreCode.EditValue = _25cHeadQuarter.EditValue & "-02"
                End If

            End If
        Else
            MessageBox.Show("No account code available for the selected region.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            _06cCodeAccount.EditValue = ""
        End If
    End Sub

    Private Sub _cm06updateStoreCode()
        If _16NPWP.EditValue Is Nothing OrElse String.IsNullOrWhiteSpace(_16NPWP.EditValue.ToString()) Then
            _07cStoreCode.EditValue = ""
        ElseIf _16NPWP.EditValue.ToString() = "NPWP" Then


            _07cStoreCode.EditValue = _06cCodeAccount.EditValue.ToString() & "-01"
        Else
            _07cStoreCode.EditValue = _06cCodeAccount.EditValue.ToString() & "-02"
        End If
    End Sub

    Private Function _Fn07ValidateRequiredFields() As Boolean
        Dim messages As New List(Of String)()

        Dim validations As New List(Of (Control As Object, Label As String)) From {
        (If(_24bCheckHeadQuarter.Checked, _05cRegion, _25cHeadQuarter), "Region/HeadQuarter"),
        (_16NPWP, "NPWP"),
        (_22Categories, "Categorie"),
        (_04cTypeOfStore, "TypeOfStore"),
        (_21StoreName, "Store Name"),
        (_09cAccountName, "Account Name")
    }

        For Each item In validations
            Dim editValue As Object = TryCast(item.Control, DevExpress.XtraEditors.BaseEdit)?.EditValue
            If editValue Is Nothing OrElse String.IsNullOrEmpty(editValue.ToString()) Then
                messages.Add($"- {item.Label}")
            End If
        Next

        If messages.Any() Then
            Dim msgText As String = "Please complete the following fields before saving:" & Environment.NewLine & String.Join(Environment.NewLine, messages)
            MessageBox.Show(msgText, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function _Fn08SafeToString(value As Object) As String
        Return If(value IsNot Nothing, value.ToString(), "")
    End Function

#End Region

#Region "Control - Event"
    Private Sub mnubar01Save_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubar01Save.ItemClick
        If _Fn07ValidateRequiredFields() Then
            _cm03ProsesSave()
        End If
    End Sub

    Private Sub mnubar02Clear_ItemClick(sender As Object, e As ItemClickEventArgs) Handles mnubar02Clear.ItemClick
        _cm00ClearControl()
    End Sub

    Private Sub _24bCheckHeadQuarter_CheckedChanged(sender As Object, e As EventArgs) Handles _24bCheckHeadQuarter.CheckedChanged
        If _isLoading OrElse _isInitializing Then Return

        Dim isHeadQuarterChecked As Boolean = _24bCheckHeadQuarter.Checked

        Dim result As DialogResult
        result = MessageBox.Show("Are you sure you want to change this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then

            _25cHeadQuarter.Enabled = Not isHeadQuarterChecked
            _05cRegion.Enabled = isHeadQuarterChecked

            If isHeadQuarterChecked Then
                _25cHeadQuarter.EditValue = " "
                _05cRegion.EditValue = " "
                _16NPWP.Properties.Items.Clear()

                _16NPWP.Properties.Items.Add("NPWP")
                _16NPWP.Properties.Items.Add("NON NPWP")
            Else
                _05cRegion.EditValue = " "
                _25cHeadQuarter.EditValue = ""
                _16NPWP.Properties.Items.Clear()

                _16NPWP.Properties.Items.Add("NON NPWP")
            End If

            _06cCodeAccount.EditValue = " "
            _16NPWP.EditValue = ""
            _07cStoreCode.EditValue = ""

            _isLoading = False
        Else
            ' Balikkan checkbox ke nilai sebelumnya
            _isLoading = True
            _24bCheckHeadQuarter.Checked = Not isHeadQuarterChecked
            _isLoading = False
        End If
    End Sub

    Private Sub _16NPWP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _16NPWP.SelectedIndexChanged
        ' _cm06updateStoreCode()
        If _isInitializing OrElse _isLoading Then Return
        If _24bCheckHeadQuarter.Checked Then
            _isLoading = True
            '_cm05DisplayCodeAccounct(True)

            If _16NPWP.EditValue Is Nothing OrElse String.IsNullOrWhiteSpace(_16NPWP.EditValue.ToString()) Then
                _07cStoreCode.EditValue = ""
            ElseIf _16NPWP.EditValue.ToString() = "NPWP" Then


                _07cStoreCode.EditValue = _06cCodeAccount.EditValue & "-01"
            Else
                _07cStoreCode.EditValue = _06cCodeAccount.EditValue & "-02"
            End If
            _isLoading = False
        Else
            If _prop03Target Then
                _isLoading = True

                If _16NPWP.EditValue Is Nothing OrElse String.IsNullOrWhiteSpace(_16NPWP.EditValue.ToString()) Then
                    _07cStoreCode.EditValue = ""
                ElseIf _16NPWP.EditValue.ToString() = "NPWP" Then


                    _07cStoreCode.EditValue = _06cCodeAccount.EditValue & "-01"
                Else
                    _07cStoreCode.EditValue = _06cCodeAccount.EditValue & "-02"
                End If
                _isLoading = False
            Else
                _isLoading = True
                _cm05DisplayCodeAccounct(False)
                _isLoading = False
            End If
        End If

    End Sub

    Private Sub _06cCodeAccount_EditValueChanged(sender As Object, e As EventArgs) Handles _06cCodeAccount.EditValueChanged
        If _24bCheckHeadQuarter.Checked = False Then
            _06cCodeAccount.EditValue = _25cHeadQuarter.EditValue
        Else
            _cm06updateStoreCode()
        End If

    End Sub

    Private Sub _03CActive_CheckedChanged(sender As Object, e As EventArgs) Handles _03CActive.CheckedChanged
        If _03CActive.Checked Then
            _03CActive.Text = "Active"
        Else
            _03CActive.Text = "InActive"
        End If
    End Sub

    Private Sub _05cRegion_EditValueChanged(sender As Object, e As EventArgs) Handles _05cRegion.EditValueChanged
        If _isInitializing OrElse _isLoading Then Return

        Dim newValue = _05cRegion.EditValue

        Cursor = Cursors.WaitCursor

        If _prop03Target Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to change this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                _isLoading = True
                _cm05DisplayCodeAccounct(True)
                _oldRegionValue = newValue
                _isLoading = False
            Else
                ' rollback
                _isLoading = True
                _05cRegion.EditValue = _oldRegionValue
                _isLoading = False
            End If
        Else
            _isLoading = True
            _cm05DisplayCodeAccounct(True)
            _oldRegionValue = newValue
            _isLoading = False
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub _25cHeadQuarter_EditValueChanged(sender As Object, e As EventArgs) Handles _25cHeadQuarter.EditValueChanged
        If _isInitializing OrElse _isLoading Then Return

        Dim newValue = _25cHeadQuarter.EditValue

        Cursor = Cursors.WaitCursor

        If _prop03Target Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to change this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                _isLoading = True
                _06cCodeAccount.EditValue = newValue
                _oldHeadQuarterValue = newValue
                _isLoading = False
            Else
                ' rollback
                _isLoading = True
                _25cHeadQuarter.EditValue = _oldHeadQuarterValue
                _isLoading = False
            End If
        Else
            _isLoading = True
            _cm05DisplayCodeAccounct(False)
            _oldHeadQuarterValue = newValue
            _isLoading = False
        End If

        Cursor = Cursors.Default
    End Sub

#End Region


End Class
