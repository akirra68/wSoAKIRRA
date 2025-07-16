Public Class clsUserGEMINI

    Property _UserProp01cTitle As String
    Property _UserProp02cUserID As String
    Property _UserProp03cUserName As String
    Property _UserProp04ComputerName As String
    Property _UserProp05IPAddress As String
    Property _UserProp06Password As String
    Property _UserProp07TargetNetwork As Int16   '0:LOCAL - 1:PRIVATE - 2:PUBLIC
    Property _UserProp10Skin As String

    Public Function _pbTableUserGemini() As DataTable
        Dim pdtHasil As New DataTable

        Dim objTableUserGemini As New clsTEMPLATEKEY With {.prop_dtKEYGEMINI = pdtHasil}
        objTableUserGemini.dtInitKEYGEMINI()

        objTableUserGemini.dtAddNewKEYGEMINI(_UserProp02cUserID, _UserProp03cUserName, _UserProp04ComputerName, _UserProp05IPAddress, "")

        Return objTableUserGemini.prop_dtKEYGEMINI
    End Function

End Class
