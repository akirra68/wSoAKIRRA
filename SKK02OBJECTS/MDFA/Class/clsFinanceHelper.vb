Imports SKK01CORE
Imports SKK01CORE.clsNasaHelper

Public Class clsFinanceHelper
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

    Private objHelper As clsNasaHelper

#Region "form - event"
    Public Sub New()
        objHelper = New clsNasaHelper()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        objHelper.Dispose()
    End Sub
#End Region

#Region "custom - method"
    Private Function _cmDateSerial(ByVal prmdDate As Date) As Date
        Dim pnYear As Int32 = 0 : Dim pnMonth As Int32 = 0 : Dim pnDay As Int32 = 0

        pnYear = DateAndTime.Year(prmdDate)
        pnMonth = DateAndTime.Month(prmdDate)
        pnDay = DateAndTime.Day(prmdDate)

        Return DateSerial(pnYear, pnMonth, pnDay)
    End Function

#End Region

#Region " CORE Finance Helper : RETURN DATATABLE (SELECT SQL)"

    Private Function _pFAAddNasaSelectParamData(ByVal prmf01nTargetSPParent_int As Int16, ByVal prmf02nTargetSPChild_int As Int16, ByVal prmf03nTargetExec_int As Int16,
                                              ByVal prmf01cParamString As String, ByVal prmf02cParamString As String, ByVal prmf03cParamString As String,
                                              ByVal prmf01nParamNumerik As Double, ByVal prmf02nParamNumerik As Double, ByVal prmf01dParamDate As Date, ByVal prmf02dParamDate As Date) As clsNasaSelectParamData
        Dim objParam As New clsNasaSelectParamData

        With objParam
            .f01nTargetSPParent_int = prmf01nTargetSPParent_int
            .f02nTargetSPChild_int = prmf02nTargetSPChild_int
            .f03nTargetExec_int = prmf03nTargetExec_int
            .f01cParamString = prmf01cParamString
            .f02cParamString = prmf02cParamString
            .f03cParamString = prmf03cParamString
            .f01nParamNumerik = prmf01nParamNumerik
            .f02nParamNumerik = prmf02nParamNumerik
            .f01dParamDate = prmf01dParamDate
            .f02dParamDate = prmf02dParamDate
        End With

        Return objParam
    End Function

    Private Function _pFACore01SPSELECTtoDataTable(ByVal prmnTargetServer012 As Int16, ByVal objParamData As clsNasaSelectParamData, ByVal prmcNamaDatabase As _pnmDatabaseName) As DataTable
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        With objParamData
            objParamCollection._01AddNew(.f01nTargetSPParent_int, .f02nTargetSPChild_int, .f03nTargetExec_int,
                                         .f01cParamString, .f02cParamString, .f03cParamString,
                                         .f01nParamNumerik, .f02nParamNumerik, .f01dParamDate, .f02dParamDate)
        End With

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = objHelper._pb02NasaExecSPSELECTtoDataTable(prmnTargetServer012, prmcNamaDatabase)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

    Private Async Function _pFACore01SPSELECTtoDataTable_Async(ByVal prmnTargetServer012 As Int16, ByVal objParamData As clsNasaSelectParamData, ByVal prmcNamaDatabase As _pnmDatabaseName) As Task(Of DataTable)
        Dim pdtHasil As New DataTable

        Dim objParamCollection As clsNasaSelectParamDataCollection = New clsNasaSelectParamDataCollection()
        With objParamData
            objParamCollection._01AddNew(.f01nTargetSPParent_int, .f02nTargetSPChild_int, .f03nTargetExec_int,
                                         .f01cParamString, .f02cParamString, .f03cParamString,
                                         .f01nParamNumerik, .f02nParamNumerik, .f01dParamDate, .f02dParamDate)
        End With

        objHelper._prop01VarNasaSelectParamDataCollection = objParamCollection
        pdtHasil = Await objHelper._pb02NasaExecSPSELECTtoDataTableAsync(prmnTargetServer012, prmcNamaDatabase)

        objParamCollection.Dispose()

        Return pdtHasil
    End Function

#End Region

#Region " CORE Finance Helper : RETURN INT (EXECUTE SP/SQL)"
    Public Async Function _pFACore10SPSQLExecDirectToInt_Async(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                         ByVal prmnTarget1Text2SP As Int16, ByVal prmcSQLScriptORNamaSP As String,
                                                         Optional ByVal prmcParamTemplateData As String = "", Optional ByVal prmdtTemplateData As DataTable = Nothing,
                                                         Optional ByVal prmcParamAdditional As String = "", Optional ByVal prmdtAdditional As DataTable = Nothing) As Task(Of Integer)

        Return Await objHelper._pb01NasaExecSQLDirectAsync(prmnTargetServer012, prmcNasaDatabaseTarget,
                                                           prmnTarget1Text2SP, prmcSQLScriptORNamaSP,
                                                           prmcParamTemplateData, prmdtTemplateData,
                                                           prmcParamAdditional, prmdtAdditional)
    End Function

    Public Function _pFACore10SPSQLExecDirectToInt(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                   ByVal prmnTarget1Text2SP As Int16, ByVal prmcSQLScriptORNamaSP As String,
                                                   Optional ByVal prmcParamTemplateData As String = "", Optional ByVal prmdtTemplateData As DataTable = Nothing) As Integer
        objHelper._prop10SQLCommand = prmcSQLScriptORNamaSP
        objHelper._prop11StoredProcedureName = prmcSQLScriptORNamaSP

        Return objHelper._pb01NasaExecSQLDirect(prmnTargetServer012, prmcNasaDatabaseTarget,
                                                 prmnTarget1Text2SP, prmcParamTemplateData, prmdtTemplateData)
    End Function

    Public Function _pFACore10SPSQLExecDirectTigaParamDataTableToInt(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                                     ByVal prmcNamaStoredProcedure As String,
                                                                     ByVal prmcParamTemplateDataTable01 As String, ByVal prmdtTemplateDataTable01 As DataTable,
                                                                     ByVal prmcParamTemplateDataTable02 As String, ByVal prmdtTemplateDataTable02 As DataTable,
                                                                     Optional ByVal prmcParamTemplateDataTable03 As String = "", Optional ByVal prmdtTemplateDataTable03 As DataTable = Nothing) As Integer
        Return objHelper._pb01NasaExecSQLDirectTigaParamDataTable(prmnTargetServer012, prmcNasaDatabaseTarget, prmcNamaStoredProcedure,
                                                                  prmcParamTemplateDataTable01, prmdtTemplateDataTable01,
                                                                  prmcParamTemplateDataTable02, prmdtTemplateDataTable02,
                                                                  prmcParamTemplateDataTable03, prmdtTemplateDataTable03)
    End Function

#End Region

#Region " CORE Finance Helper : RETURN DATATABLE (EXECUTE SP/SQL)"
    Public Async Function _pFACore11SPSQLExecDirectToDataTable_Async(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                                     ByVal prmcNamaStoredProcedure As String, Optional ByVal prmcParamTemplateData2023 As String = "",
                                                                     Optional ByVal prmdtTemplateData2023 As DataTable = Nothing) As Task(Of DataTable)
        Return Await objHelper._pb03NasaExecSPPROCESStoDataTableAsync(prmnTargetServer012, prmcNasaDatabaseTarget, prmcNamaStoredProcedure, prmcParamTemplateData2023, prmdtTemplateData2023)
    End Function

    Public Function _pFACore11SPSQLExecDirectToDataTable(ByVal prmnTargetServer012 As Int16, ByVal prmcNasaDatabaseTarget As _pnmDatabaseName,
                                                         ByVal prmcNamaStoredProcedure As String, Optional ByVal prmcParamTemplateData2023 As String = "",
                                                         Optional ByVal prmdtTemplateData2023 As DataTable = Nothing) As DataTable
        Return objHelper._pb03NasaExecSPPROCESStoDataTable(prmnTargetServer012, prmcNasaDatabaseTarget, prmcNamaStoredProcedure, prmcParamTemplateData2023, prmdtTemplateData2023)
    End Function

#End Region

#Region " Finance - Mastering (bukan TABLEMASTER)"

    'Data CREATE/UPDATE/DELETE - PROFORMA INVOICE (ucFA23GV01PROFORMAINVOICE : _02cCustomer)
    Public Function _mFA61GetDataMastering(ByVal prmnTargetServer012 As Int16, ByVal prmnTarget1Cre2UptDel As Int16,
                                           ByVal prmcString01 As String, Optional ByVal prmcString02 As String = "") As DataTable
        Dim objParam As New clsNasaSelectParamData

        Select Case prmnTarget1Cre2UptDel
            Case 1   'CREATE Proforma - (ucFA23GV01PROFORMAINVOICE : _02cCustomer)
                objParam = _pFAAddNasaSelectParamData(60, 1, 1, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 2   'UPDATE/DELETE Proforma - (ucFA23GV01PROFORMAINVOICE : _02cCustomer)
                objParam = _pFAAddNasaSelectParamData(60, 1, 2, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 3   'No. Proforma - (ucFA23GV01PROFORMAINVOICE) ==> prmcString01 = Kode Customer
                objParam = _pFAAddNasaSelectParamData(60, 1, 3, prmcString01, "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 4   'No. Faktur : unt ADD NEW pd UPDATE ucFA23GV01PROFORMAINVOICE  ==> prmcString01 = Kode Customer
                objParam = _pFAAddNasaSelectParamData(60, 1, 4, prmcString01, "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 5   'List Customer yg melakukan Settlement/Pelunasan (list customer yg belum lunas) ==> ucFA23GU01SETTLEMENTAR = kode customer
                objParam = _pFAAddNasaSelectParamData(60, 1, 5, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 6   'List OST Collection pd customer yg akan dipakai unt Settlement/Pelunasan (ucFA23GU01SETTLEMENTAR ==> _gridCollectionAR)
                objParam = _pFAAddNasaSelectParamData(60, 4, 3, prmcString01, prmcString02, "", 0, 0, "3000-01-01", "3000-01-01")

            Case 7   'List Customer TAGIHAN (ucFA23HH01BILLING ==> _01Customer)
                objParam = _pFAAddNasaSelectParamData(60, 5, 1, prmcString01, "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 8   'RepoControl List Customer YANG SUDAH LUNAS Faktur/AR-nya.
                objParam = _pFAAddNasaSelectParamData(60, 5, 2, prmcString01, "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 9   'RepoControl Group Customer unt RESERVED GOLD PRICE (ucFA23HQ01GOLDPRICE)
                objParam = _pFAAddNasaSelectParamData(60, 5, 4, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 10  'List OST Collection pd customer yg akan dipakai unt Settlement/Pelunasan (ucFA23GU01SETTLEMENTAR ==> _gridCollectionAR)
                objParam = _pFAAddNasaSelectParamData(60, 4, 4, "", "", "", 0, 0, "3000-01-01", "3000-01-01")


                    ' UPDATED BY ADI, AQILA & AGOY

            Case 11  'List Customer OMSET
                objParam = _pFAAddNasaSelectParamData(60, 6, 30, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 12  'List Brand PIUTANG
                objParam = _pFAAddNasaSelectParamData(60, 6, 40, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 13  'List Barang RONGSOK
                objParam = _pFAAddNasaSelectParamData(60, 6, 50, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 14  'List Customer GOLDBAR
                objParam = _pFAAddNasaSelectParamData(60, 6, 60, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            Case 15  'List Customer CASHBACK
                objParam = _pFAAddNasaSelectParamData(60, 6, 70, "", "", "", 0, 0, "3000-01-01", "3000-01-01")


            ' REPORT TAGIHAN FINANCE
            Case 100  'List Customer untuk Report Tagihan
                objParam = _pFAAddNasaSelectParamData(60, 6, 100, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

            'REPORT PELUNASAN FINANCE
            Case 110 'List Customer untuk Report Pelunasan
                objParam = _pFAAddNasaSelectParamData(60, 6, 110, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        End Select

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

#End Region

#Region " Finance - Master TABLEMASTER"

    Public Function _mFA101TableMasterForMastering(ByVal prmnTargetServer012 As Int16, ByVal prmnTargetExecMaster As Int16,
                                                   Optional ByVal prmcString01 As String = "", Optional ByVal prmcString02 As String = "") As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(101, 0, prmnTargetExecMaster, prmcString01, prmcString02, "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.TABLEMASTER)

        Return pdtHasil
    End Function

    Public Function _mFA03IncNumberMaster(ByVal prmnTargetServer012 As Int16, ByVal prmf01cParamString As String, ByVal prmcFieldNameReturn As String) As String

        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(160, 0, 0, prmf01cParamString, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.TABLEMASTER)

        Dim pcIncNumberOrderMD As String = ""

        For Each dtRow As DataRow In pdtHasil.Rows
            pcIncNumberOrderMD = CStr(dtRow(prmcFieldNameReturn))
        Next

        Return pcIncNumberOrderMD
    End Function

    Public Function _mFA101TableMasterHistoryTGP(ByVal prmnTargetServer012 As Int16, ByVal prmdDate01 As Date) As Integer

        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(101, 0, 7, "", "", "", 0, 0, prmdDate01, "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.TABLEMASTER)

        Dim pnTGP As Integer = 0
        For Each dtRow As DataRow In pdtHasil.Rows
            pnTGP = CInt(dtRow("f10Int"))
        Next

        Return pnTGP
    End Function
#End Region

#Region " Finance - Transaction"

    Public Function _mFA61GetDataFakturForTagihan(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeCustomer As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 4, 1, prmcKodeCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _mFA61GetDataFakturDetailForTagihan(ByVal prmnTargetServer012 As Int16, ByVal prmcParamName As String, ByVal prmdtKey As DataTable) As DataTable
        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore11SPSQLExecDirectToDataTable(prmnTargetServer012,
                                                        _pnmDatabaseName.SBU,
                                                        "spFA62GetDataFaktuDetail",
                                                        prmcParamName, prmdtKey)

        Return pdtHasil
    End Function

    'Repo Entitas, baik unt BILLING ataupun SETTLEMENT
    Public Function _mFA61GetDataForRepoEntitas(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeCustomer As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 5, 3, prmcKodeCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _mFA61GetDataOSTFakturForSettlement(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeCustomer As String) As DataTable
        Cursor.Current = Cursors.WaitCursor

        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 4, 2, prmcKodeCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        For Each dtRow As DataRow In pdtHasil.Rows
            dtRow("f03Double16") = dtRow("f03Double16") - dtRow("f07Double")

            'dtRow("f05Double16") = dtRow("f01Int") / 10   'INI ADALAH kadar YG ADA DI "SETTLEMENT"

            'Tot.Rupiah di hitung manual sb yg TABLE61.f01Double16 itu salah. (hanya (AR*TGP), shrnya ((AR+Charge) * TGP)
            dtRow("f01Double16") = (dtRow("f03Double16") * dtRow("f04Int")) - dtRow("f02Double16")
        Next
        pdtHasil.AcceptChanges()

        For Each dtRow As DataRow In pdtHasil.Rows
            dtRow("f02Double16") = 0     '"Rupiah Settlement (Rp.)"
            dtRow("f05Double16") = 0     '"Sisa Settlement (Rp.)"
            dtRow("f07Double") = 0       '"Sisa (gr)"
            dtRow("f04Double16") = 0     '"Gram Settlement (gr.)"
        Next
        pdtHasil.AcceptChanges()

        Cursor.Current = Cursors.Default

        Return pdtHasil
    End Function

    Public Function _mFA61GetDataFakturForProforma(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeCustomer As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 2, 1, prmcKodeCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _mFA62GetDataProformaForUpdateDelete(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeCustomer As String, ByVal prmcNoProforma As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 2, 2, prmcKodeCustomer, prmcNoProforma, "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _mFA6361GetDataRepoCtrlPINDAHBUKU(ByVal prmnTargetServer012 As Int16, ByVal prmcTargetA63T61 As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        Dim pdtHasil As New DataTable

        Select Case prmcTargetA63T61
            Case "Asal63"
                objParam = _pFAAddNasaSelectParamData(60, 5, 5, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
                pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

            Case "Tujuan61"
                objParam = _pFAAddNasaSelectParamData(60, 5, 6, "", "", "", 0, 0, "3000-01-01", "3000-01-01")
                pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        End Select

        Return pdtHasil
    End Function

#End Region

#Region " Finance - 70-an Transaction"
    Public Function _mFA70GetDataOSTPaymentTagihan(ByVal prmnTargetServer012 As Int16, ByVal prmcKodeCustomer As String, Optional ByVal prmcNoDocPayment As String = "") As DataTable
        Dim objParam As New clsNasaSelectParamData
        If prmcNoDocPayment = "" Then
            objParam = _pFAAddNasaSelectParamData(70, 0, 1, prmcKodeCustomer, "", "", 0, 0, "3000-01-01", "3000-01-01")
        Else
            objParam = _pFAAddNasaSelectParamData(70, 0, 2, prmcKodeCustomer, prmcNoDocPayment, "", 0, 0, "3000-01-01", "3000-01-01")
        End If

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _mFA71GetDataTagihanACTIVE(ByVal prmnTargetServer012 As Int16) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(71, 0, 1, "", "", "", 0, 0, "3000-01-01", "3000-01-01")

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _mFA7173GetData4DisplayEditTagihan(ByVal prmnTargetTable As Int16, ByVal prmnTargetServer012 As Int16, ByVal prmcNoTagihan As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        If prmnTargetTable = 71 Then
            objParam = _pFAAddNasaSelectParamData(70, 0, 3, prmcNoTagihan, "", "", 0, 0, "3000-01-01", "3000-01-01")
        Else
            If prmnTargetTable = 73 Then
                objParam = _pFAAddNasaSelectParamData(70, 0, 4, prmcNoTagihan, "", "", 0, 0, "3000-01-01", "3000-01-01")
            End If
        End If

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

#End Region

#Region " Finance - Reporting - Async"
    Public Async Function _FA61RPT01SemuaPenerimaanFakturAsync(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date) As Task(Of DataTable)
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 1, "", "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = Await _pFACore01SPSELECTtoDataTable_Async(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Async Function _FA61RPT02SemuaTagihanFakturAsync(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date) As Task(Of DataTable)
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 2, "", "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = Await _pFACore01SPSELECTtoDataTable_Async(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Async Function _FA61RPT03SemuaPelunasanFakturAsync(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date) As Task(Of DataTable)
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 3, "", "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = Await _pFACore01SPSELECTtoDataTable_Async(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Async Function _FA61RPT04TagihanFakturPerCustomerAsync(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date, ByVal prmcKodeCustomer As String) As Task(Of DataTable)
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 4, prmcKodeCustomer, "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = Await _pFACore01SPSELECTtoDataTable_Async(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Async Function _FA61RPT05PelunasanFakturPerCustomerAsync(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date, ByVal prmcKodeCustomer As String) As Task(Of DataTable)
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 5, prmcKodeCustomer, "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = Await _pFACore01SPSELECTtoDataTable_Async(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

#End Region

#Region " Finance - Reporting - "
    Public Function _FA61RPT01SemuaPenerimaanFaktur(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date) As DataTable

        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 1, "", "", "", 0, 0, prmdDate1, prmdDate2)

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _FA61RPT02SemuaTagihanFaktur(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 2, "", "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _FA61RPT03SemuaPelunasanFaktur(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 3, "", "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _FA61RPT04TagihanFakturPerCustomer(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date, ByVal prmcKodeCustomer As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 4, prmcKodeCustomer, "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

    Public Function _FA61RPT05PelunasanFakturPerCustomer(ByVal prmnTargetServer012 As Int16, ByVal prmdDate1 As Date, ByVal prmdDate2 As Date, ByVal prmcKodeCustomer As String) As DataTable
        Dim objParam As New clsNasaSelectParamData
        objParam = _pFAAddNasaSelectParamData(60, 6, 5, prmcKodeCustomer, "", "", 0, 0, _cmDateSerial(prmdDate1), _cmDateSerial(prmdDate2))

        Dim pdtHasil As New DataTable
        pdtHasil = _pFACore01SPSELECTtoDataTable(prmnTargetServer012, objParam, _pnmDatabaseName.SBU)

        Return pdtHasil
    End Function

#End Region

End Class
