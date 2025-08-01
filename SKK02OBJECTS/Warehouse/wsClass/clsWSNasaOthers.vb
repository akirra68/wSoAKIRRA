Public Class clsWSNasaOthers
    Implements IDisposable

    '/***** Function for date format: YYYY-MM-DD *****/
    '/***** Created by Indra Rahmat Jatnika on 11-05-2015 21:58 *****/

    Public Shared Function TglYYYYMMDD(ByVal prmDate As Date) As String
        Dim plhasil As String = ""
        plhasil = String.Format("{0}-{1}-{2}", Format(prmDate.Year, "0000"), Format(prmDate.Month, "00"), Format(prmDate.Day, "00"))
        Return plhasil
    End Function

    Public Shared Function TglDDMMYYYY(ByVal prmDate As Date) As String
        Dim plhasil As String = ""
        plhasil = String.Format("{0}-{1}-{2}", Format(prmDate.Day, "00"), Format(prmDate.Month, "00"), Format(prmDate.Year, "0000"))
        Return plhasil
    End Function

    Public Shared Function TglDDMMYYYYWithNameMonth(ByVal prmDate As Date) As String
        Dim pcNamaBulan As String = ""
        Select Case prmDate.Month
            Case 1
                pcNamaBulan = "Januari"
            Case 2
                pcNamaBulan = "Februari"
            Case 3
                pcNamaBulan = "Maret"
            Case 4
                pcNamaBulan = "April"
            Case 5
                pcNamaBulan = "Mei"
            Case 6
                pcNamaBulan = "Juni"
            Case 7
                pcNamaBulan = "Juli"
            Case 8
                pcNamaBulan = "Agustus"
            Case 9
                pcNamaBulan = "September"
            Case 10
                pcNamaBulan = "Oktober"
            Case 11
                pcNamaBulan = "November"
            Case 12
                pcNamaBulan = "Desember"
        End Select

        Dim plhasil As String = ""
        plhasil = String.Format("{0} {1} {2}", Format(prmDate.Day, "00"), pcNamaBulan, Format(prmDate.Year, "0000"))
        Return plhasil
    End Function

    Public Shared Function TglDDMMYYYYWithNameMonthAbbreviation(ByVal prmDate As Date) As String
        Dim pcNamaBulan As String = ""
        Select Case prmDate.Month
            Case 1
                pcNamaBulan = "Jan"
            Case 2
                pcNamaBulan = "Feb"
            Case 3
                pcNamaBulan = "Mar"
            Case 4
                pcNamaBulan = "Apr"
            Case 5
                pcNamaBulan = "Mei"
            Case 6
                pcNamaBulan = "Jun"
            Case 7
                pcNamaBulan = "Jul"
            Case 8
                pcNamaBulan = "Agu"
            Case 9
                pcNamaBulan = "Sep"
            Case 10
                pcNamaBulan = "Okt"
            Case 11
                pcNamaBulan = "Nov"
            Case 12
                pcNamaBulan = "Des"
        End Select

        Dim plhasil As String = ""
        plhasil = String.Format("{0}-{1}-{2}", Format(prmDate.Day, "00"), pcNamaBulan, Format(prmDate.Year, "0000"))
        Return plhasil
    End Function

    'Fungsi terbilang dalam IDR dan USD (dua digit dibelakang koma)
    Public Shared Function ArisNJP_Usd(ByVal nAmount As String, Optional ByVal wAmount As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String
        'Let's make sure entered value is numeric
        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

        Dim tempDecValue As String = String.Empty : If InStr(nAmount, ".") Then _
            tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try
            Dim intAmount As Long = nAmount
            If intAmount > 0 Then
                nSet = IIf((intAmount.ToString.Trim.Length / 3) _
                    > (CLng(intAmount.ToString.Trim.Length / 3)),
                  CLng(intAmount.ToString.Trim.Length / 3) + 1,
                    CLng(intAmount.ToString.Trim.Length / 3))
                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim,
                  (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                Dim Ones() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}
                Dim Teens() As String = {"", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Dim Tens() As String = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                Dim HMBT() As String = {"", "", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion"}

                intAmount = eAmount

                Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1

                If nHundred > 0 Then wAmount = wAmount &
                Ones(nHundred) & " Hundred " 'This is for hundreds                
                If nTen > 0 Then 'This is for tens and teens
                    If nTen = 1 And nOne > 0 Then 'This is for teens 
                        wAmount = wAmount & Teens(nOne) & " "
                    Else 'This is for tens, 10 to 90
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, "-", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else 'This is for ones, 1 to 9
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If
                wAmount = wAmount & HMBT(nSet) & " "
                wAmount = ArisNJP_Usd(CStr(CLng(nAmount) -
                  (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
            Else
                If Val(nAmount) = 0 Then nAmount = nAmount &
                tempDecValue : tempDecValue = String.Empty
                If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount =
                  Trim(ArisNJP_Usd(CStr(Math.Round(Val(nAmount), 2) * 100),
                  wAmount.Trim & " Dollar And ", 1)) & " Cents"
            End If
        Catch ex As Exception
            'MessageBox.Show("Error Encountered: " & ex.Message, _
            '  "Convert Numbers To Words", _
            '  MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "!#ERROR_ENCOUNTERED"
        End Try

        'Trap null values
        If IsNothing(wAmount) = True Then wAmount = String.Empty Else wAmount =
          IIf(InStr(wAmount.Trim.ToLower, "dollar"),
          wAmount.Trim, wAmount.Trim & " Dollar")

        'Display the result
        Return wAmount
    End Function

    Public Shared Function ArisNJP_Rp(ByVal nAmount As String, Optional ByVal wAmount As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String
        'Let's make sure entered value is numeric
        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

        Dim tempDecValue As String = String.Empty
        If InStr(nAmount, ".") Then tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try
            Dim intAmount As Long = nAmount
            If intAmount > 0 Then
                nSet = IIf((intAmount.ToString.Trim.Length / 3) _
                    > (CLng(intAmount.ToString.Trim.Length / 3)),
                  CLng(intAmount.ToString.Trim.Length / 3) + 1,
                    CLng(intAmount.ToString.Trim.Length / 3))
                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim,
                  (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                Dim Ones() As String = {"", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan"}
                Dim Teens() As String = {"", "Sebelas", "Dua Belas", "Tiga Belas", "Empat Belas", "Lima Belas", "Enam Belas", "Tujuh Belas", "Delapan Belas", "Sembilan Belas"}
                Dim Tens() As String = {"", "Sepuluh", "Dua Puluh", "Tiga Puluh", "Empat Puluh", "Lima Puluh", "Enam Puluh", "Tujuh Puluh", "Delapan Puluh", "Sembilan Puluh"}
                Dim HMBT() As String = {"", "", "Ribu", "Juta", "Milyar", "Trilyun", "Quadrilyun", "Quintilyun"}
                Dim HMBT1() As String = {"", "", "ribu", "Juta", "Milyar", "Trilyun", "Quadrilyun", "Quintilyun"}

                intAmount = eAmount

                Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1

                'If nHundred > 0 Then wAmount = wAmount & Ones(nHundred) & " Ratus " 'This is for hundreds  
                If nHundred > 0 Then
                    If nHundred = 1 Then
                        wAmount = wAmount & "Seratus " 'This is for hundreds
                    Else
                        wAmount = wAmount & Ones(nHundred) & " Ratus " 'This is for hundreds
                    End If
                End If

                If nTen > 0 Then 'This is for tens and teens
                    If nTen = 1 And nOne > 0 Then 'This is for teens 
                        wAmount = wAmount & Teens(nOne) & " "
                    Else 'This is for tens, 10 to 90
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, " ", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else 'This is for ones, 1 to 9
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If

                '****/diubah oleh indra tgl 08-06-2015
                'karena program yg sebelumnya tidak bisa membaca angka 1000 menjadi seribu
                If nAmount >= 1000 And nAmount <= 1999 Then

                    wAmount = "se" & HMBT1(nSet) & " "
                    wAmount = ArisNJP_Rp(CStr(CLng(nAmount) -
                      (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
                Else
                    wAmount = wAmount & HMBT(nSet) & " "
                    wAmount = ArisNJP_Rp(CStr(CLng(nAmount) -
                      (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
                End If
                '*************************************************************************
            Else
                If Val(nAmount) = 0 Then nAmount = nAmount &
                tempDecValue : tempDecValue = String.Empty

                If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount =
                  Trim(ArisNJP_Rp(CStr(Math.Round(Val(nAmount), 2) * 100),
                  wAmount.Trim & " koma ", 1)) & ""

                'If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount = _
                '  Trim(SIMATIKAmountInWords_IDR(CStr(Math.Round(Val(nAmount), 2) * 100), _
                '  wAmount.Trim & " Rupiah dan ", 1)) & " Sen"
            End If
        Catch ex As Exception
            'MessageBox.Show("Error Encountered: " & ex.Message, _
            '  "Convert Numbers To Words", _
            '  MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "!#ERROR_ENCOUNTERED"
        End Try

        'Trap null values
        If IsNothing(wAmount) = True Then wAmount = String.Empty Else wAmount =
          IIf(InStr(wAmount.Trim.ToLower, "rupiah"),
          wAmount.Trim, wAmount.Trim & " Rupiah")

        'Display the result
        Return wAmount
    End Function

    Public Function ArisNJP_TerbilangBerat(ByVal prmnDesimal As Double) As String
        ArisNJP_TerbilangBerat = ""

        Dim pcAngkaDiDepanKoma As String = prmnDesimal.ToString
        Dim pcAngkadiBelakangKoma As String = String.Empty
        If InStr(pcAngkaDiDepanKoma, ".") Then
            pcAngkadiBelakangKoma = pcAngkaDiDepanKoma.Substring(pcAngkaDiDepanKoma.IndexOf("."))
        Else
            If InStr(pcAngkaDiDepanKoma, ",") Then
                pcAngkadiBelakangKoma = pcAngkaDiDepanKoma.Substring(pcAngkaDiDepanKoma.IndexOf(","))
            End If
        End If
        pcAngkaDiDepanKoma = Replace(pcAngkaDiDepanKoma, pcAngkadiBelakangKoma, String.Empty)

        ArisNJP_TerbilangBerat = ArisNJP_TerbilangBilanganBulat(CDbl(pcAngkaDiDepanKoma)) +
                                 ArisNJP_TerbilangDesimal(pcAngkadiBelakangKoma.Substring(1, pcAngkadiBelakangKoma.Length - 1))
    End Function

    Private Function ArisNJP_TerbilangDesimal(ByVal cAngkadiBelakangKoma As String) As String
        Dim pcHasil As String = " koma "

        Dim SATUAN As String() = {" Nol", " Satu", " Dua", " Tiga", " Empat", " Lima",
                                  " Enam", " Tujuh", " Delapan", " Sembilan"}

        Dim pcProses As String = cAngkadiBelakangKoma

        For i = 0 To pcProses.Length - 1
            Select Case pcProses.Substring(i, 1)
                Case "0"
                    pcHasil = pcHasil + " Nol"
                Case "1"
                    pcHasil = pcHasil + " Satu"
                Case "2"
                    pcHasil = pcHasil + " Dua"
                Case "3"
                    pcHasil = pcHasil + " Tiga"
                Case "4"
                    pcHasil = pcHasil + " Empat"
                Case "5"
                    pcHasil = pcHasil + " Lima"
                Case "6"
                    pcHasil = pcHasil + " Enam"
                Case "7"
                    pcHasil = pcHasil + " Tujuh"
                Case "8"
                    pcHasil = pcHasil + " Delapan"
                Case "9"
                    pcHasil = pcHasil + " Sembilan"
            End Select
            'pcHasil += SATUAN(pcProses.Substring(i, 1))
        Next

        Return pcHasil
    End Function

    Private Function ArisNJP_TerbilangBilanganBulat(ByVal n As Double) As String
        Dim SATUAN As String() = {"", "Satu", "Dua", "Tiga", "Empat", "Lima",
                                  "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}

        Select Case n
            Case 0 To 11
                ArisNJP_TerbilangBilanganBulat = " " + SATUAN(Fix(n))
            Case 12 To 19
                ArisNJP_TerbilangBilanganBulat = ArisNJP_TerbilangBilanganBulat(n Mod 10) + " Belas"
            Case 20 To 99
                ArisNJP_TerbilangBilanganBulat = ArisNJP_TerbilangBilanganBulat(Fix(n / 10)) + " Puluh" +
                ArisNJP_TerbilangBilanganBulat(n Mod 10)
            Case 100 To 199
                ArisNJP_TerbilangBilanganBulat = " Seratus" + ArisNJP_TerbilangBilanganBulat(n - 100)
            Case 200 To 999
                ArisNJP_TerbilangBilanganBulat = ArisNJP_TerbilangBilanganBulat(Fix(n / 100)) + " Ratus" +
                ArisNJP_TerbilangBilanganBulat(n Mod 100)
            Case 1000 To 1999
                ArisNJP_TerbilangBilanganBulat = " Seribu" + ArisNJP_TerbilangBilanganBulat(n - 1000)
            Case 2000 To 999999
                ArisNJP_TerbilangBilanganBulat = ArisNJP_TerbilangBilanganBulat(Fix(n / 1000)) + " Ribu" +
                ArisNJP_TerbilangBilanganBulat(n Mod 1000)
            Case 1000000 To 999999999
                ArisNJP_TerbilangBilanganBulat = ArisNJP_TerbilangBilanganBulat(Fix(n / 1000000)) + " Juta" +
                ArisNJP_TerbilangBilanganBulat(n Mod 1000000)
            Case 1000000000 To 999999999999
                ArisNJP_TerbilangBilanganBulat = ArisNJP_TerbilangBilanganBulat(Fix(n / 1000000000)) + " Milyar" +
                ArisNJP_TerbilangBilanganBulat(n Mod 1000000000)
            Case Else
                ArisNJP_TerbilangBilanganBulat = ArisNJP_TerbilangBilanganBulat(Fix(n / 1000000000000)) + " Trilyun" +
                ArisNJP_TerbilangBilanganBulat(n Mod 1000000000000)
        End Select
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
