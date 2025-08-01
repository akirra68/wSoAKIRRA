Public Class mdWSNasaConst

#Region "Database WS"
    'Database WS - Nama Parameter Data - SELECT
    Public Shared _pbWSNamaSPParamData01SQLSelect = "@tpParamSQLSelect"

    'Database WS - Nama Stored Procedure - SELECT
    Public Shared _pbWSNamaSPSELECT01EXECUTEParent = "spWS100EXECUTESELECT"

    'Database WS - Nama Parameter Data - SAVE
    Public Shared _pbWSNamaSPParamData02DataForSaving = "@tpDataForSaving"
    Public Shared _pbWSNamaSPParamData03DataForProses = "@tpDataForProses"
    Public Shared _pbWSNamaSPParamData04DataPOMerchandise = "@tpDataPOMerchandise"

    'Database WS - Nama Stored Procedure - SAVE
    Public Shared _pbWSNamaSPSAVE01TABLE10 = "spWSTABLE10Save"
    Public Shared _pbWSNamaSPSAVE02TABLE20 = "spWSTABLE20Save"
    Public Shared _pbWSNamaSPSAVE02TABLE20FromCitrixToSKU = "spWSTABLE20TerimaCitrixJadiSKU"
    Public Shared _pbWSNamaSPSAVE03TABLE30PKBProductCode = "spWSTABLE30SavePKBProductCode"
    Public Shared _pbWSNamaSPUPDATETABLE30ApprovedShipmentOrder = "spWS30ShipmentOrderApprovedByFinSls2"
    Public Shared _pbWSNamaSPUPDATETABLE27UpdatePickingSKU = "spWS27UpdatePickingSKU"
#End Region

#Region "Database TABLEMASTER"

    'Database TABLEMASTER - Nama Stored Procedure - SELECT
    Public Shared _pbTABLEMASTERSPSELECT01EXECUTE = "sp100EXECUTESELECT"

#End Region

End Class
