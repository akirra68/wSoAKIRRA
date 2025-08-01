Imports DevExpress.XtraEditors.Repository

Public Class repoWS07LookUpEditAKIRRA
    Inherits RepositoryItemLookUpEdit

    Public Sub New(Optional isFA As String = "NO")
        Dim items As New List(Of ComboBoxItem) From {
            New ComboBoxItem With {.Value = 10, .Description = "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀"},
            New ComboBoxItem With {.Value = 1, .Description = "APPROVE"},
            New ComboBoxItem With {.Value = 2, .Description = "REJECT"}
        }

        If isFA = "YES" Then
            items.Add(New ComboBoxItem With {.Value = 3, .Description = "PENDING"})
        End If

        Me.DataSource = items
        Me.ValueMember = "Value"
        Me.DisplayMember = "Description"

        Me.PopulateColumns()
        Me.Columns(0).Visible = False
        Me.Columns(1).Caption = "Approval Status"

        Me.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Me.AppearanceDropDownHeader.Font = New Font("Nirmala UI", 9.0F, FontStyle.Bold)
        Me.AppearanceDropDownHeader.ForeColor = Color.Navy

        Me.AppearanceDropDown.Font = New Font("Nirmala UI", 10.0F, FontStyle.Regular)
        Me.AppearanceDropDown.ForeColor = Color.Navy

        Me.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Me.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(
        DevExpress.XtraEditors.Controls.ButtonPredefines.Clear))

        AddHandler Me.ButtonClick, AddressOf OnButtonClick
    End Sub

    Private Sub OnButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim edit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If edit IsNot Nothing AndAlso e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            edit.EditValue = 10
        End If
    End Sub
End Class

Public Class ComboBoxItem
    Public Property Value As Integer
    Public Property Description As String
End Class
