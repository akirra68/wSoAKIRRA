Imports SKK02OBJECTS

Public Class XtraUserControl1
    Implements clsWSNasaInterface

    Public Sub _mnuIExecSave() Implements clsWSNasaInterface._mnuIExecSave
        _03nAngkaHasilPenjumlahan.EditValue = _01nAngkaPertama.EditValue + _02nAngkaKedua.EditValue

        Dim pcTgl As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        MsgBox(pcTgl)
    End Sub

    Public Sub _mnuIExecAddNewBox(prmcNamaBoxNew As String) Implements clsWSNasaInterface._mnuIExecAddNewBox
        Throw New NotImplementedException()
    End Sub
End Class
