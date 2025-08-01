Public Class clsWSNasaUser
    Property _UserProp01cTitle As String
    Property _UserProp02cUserID As String
    Property _UserProp03cUserName As String
    Property _UserProp04ComputerName As String
    Property _UserProp05IPLocalAddress As String
    Property _UserProp06IPPublicAddress As String
    Property _UserProp07Password As String
    Property _UserProp08TargetNetwork As Int16   '0:LOCAL - 1:PRIVATE - 2:PUBLIC
    Property _UserProp09IsRootUser As Boolean = False
    Property _UserProp10Skin As String

    Public Function _pbInitWSNasaUser() As DataTable
        Dim pdtHasil As New DataTable

        Dim objTableUser As New clsWSNasaTemplateKey With {.prop_dtKEY = pdtHasil}
        objTableUser.dtInitKEY()

        objTableUser.dtAddNewKEY(_UserProp02cUserID, _UserProp03cUserName, _UserProp04ComputerName, _UserProp05IPLocalAddress, "")

        Return objTableUser.prop_dtKEY
    End Function
End Class

'Dim httpClient As New System.Net.Http.HttpClient
'Dim IPPublic As String = Await httpClient.GetStringAsync("https://api.ipify.org")
