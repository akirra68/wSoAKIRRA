Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports SKK02OBJECTS

Public Class clsWSNasaPrinterHelper
    Implements IDisposable

#Region "_dispose"
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

    Public Sub New()
        MyBase.New
    End Sub

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.None, ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.None, ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.None, ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi, EntryPoint:="OpenPrinterA", ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function OpenPrinter(ByVal szPrinter As String, <Out> ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean
    End Function

    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As System.IntPtr, ByVal dwCount As Integer) As Boolean
        Dim lastWin32Error As Integer = 0
        Dim num As Integer = 0
        Dim intPtr As System.IntPtr = New System.IntPtr(0)
        Dim dOCINFOA As clsWSNasaPrinterHelper.DOCINFOA = New clsWSNasaPrinterHelper.DOCINFOA()
        Dim flag As Boolean = False
        dOCINFOA.pDocName = "Nextvibes RAW Printer"
        dOCINFOA.pDataType = "RAW"
        If (clsWSNasaPrinterHelper.OpenPrinter(szPrinterName.Normalize(), intPtr, System.IntPtr.Zero)) Then
            If (clsWSNasaPrinterHelper.StartDocPrinter(intPtr, 1, dOCINFOA)) Then
                If (clsWSNasaPrinterHelper.StartPagePrinter(intPtr)) Then
                    flag = clsWSNasaPrinterHelper.WritePrinter(intPtr, pBytes, dwCount, num)
                    clsWSNasaPrinterHelper.EndPagePrinter(intPtr)
                End If
                clsWSNasaPrinterHelper.EndDocPrinter(intPtr)
            End If
            clsWSNasaPrinterHelper.ClosePrinter(intPtr)
        End If
        If (Not flag) Then
            lastWin32Error = Marshal.GetLastWin32Error()
        End If
        Return flag
    End Function

    Public Shared Function SendBytesToPrinterNew(ByVal szPrinterName As String, ByVal bytes As Byte(), ByVal dwCount As Integer) As Boolean
        Dim num As Integer = 0
        Dim intPtr As System.IntPtr = New System.IntPtr(0)
        Dim dOCINFOA As clsWSNasaPrinterHelper.DOCINFOA = New clsWSNasaPrinterHelper.DOCINFOA()
        Dim flag As Boolean = False
        dOCINFOA.pDocName = "Zebra Label"
        dOCINFOA.pDataType = "RAW"
        If (clsWSNasaPrinterHelper.OpenPrinter(szPrinterName.Normalize(), intPtr, System.IntPtr.Zero)) Then
            If (clsWSNasaPrinterHelper.StartDocPrinter(intPtr, 1, dOCINFOA)) Then
                If (clsWSNasaPrinterHelper.StartPagePrinter(intPtr)) Then
                    flag = clsWSNasaPrinterHelper.WritePrinter(intPtr, bytes, dwCount, num)
                    clsWSNasaPrinterHelper.EndPagePrinter(intPtr)
                End If
                clsWSNasaPrinterHelper.EndDocPrinter(intPtr)
            End If
            clsWSNasaPrinterHelper.ClosePrinter(intPtr)
        End If
        If (Not flag) Then
            Throw New Win32Exception(Marshal.GetLastWin32Error())
        End If
        Return flag
    End Function

    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        Dim fileStream As System.IO.FileStream = New System.IO.FileStream(szFileName, FileMode.Open)
        Dim binaryReader As System.IO.BinaryReader = New System.IO.BinaryReader(fileStream)
        'Dim numArray(DirectCast(fileStream.Length, System.IntPtr) - 1) As Byte
        Dim numArray() As Byte
        Dim printer As Boolean = False
        Dim intPtr As System.IntPtr = New System.IntPtr(0)
        Dim num As Integer = Convert.ToInt32(fileStream.Length)
        numArray = binaryReader.ReadBytes(num)
        intPtr = Marshal.AllocCoTaskMem(num)
        Marshal.Copy(numArray, 0, intPtr, num)
        printer = clsWSNasaPrinterHelper.SendBytesToPrinter(szPrinterName, intPtr, num)
        Marshal.FreeCoTaskMem(intPtr)

        Return printer
    End Function

    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String) As Boolean
        Dim length As Integer = szString.Length
        Dim coTaskMemAnsi As IntPtr = Marshal.StringToCoTaskMemAnsi(szString)
        clsWSNasaPrinterHelper.SendBytesToPrinter(szPrinterName, coTaskMemAnsi, length)
        Marshal.FreeCoTaskMem(coTaskMemAnsi)
        Return True
    End Function

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Ansi, EntryPoint:="StartDocPrinterA", ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Integer, <InAttribute> ByVal di As clsWSNasaPrinterHelper.DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.None, ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.None, ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Integer, <Out> ByRef dwWritten As Integer) As Boolean
    End Function

    <DllImport("winspool.Drv", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.None, ExactSpelling:=True, SetLastError:=True)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As Byte(), ByVal dwCount As Integer, <Out> ByRef dwWritten As Integer) As Boolean
    End Function

    Partial Public Class DOCINFOA
        Public pDocName As String

        Public pOutputFile As String

        Public pDataType As String

        Public Sub New()
            MyBase.New()
        End Sub
    End Class

End Class

