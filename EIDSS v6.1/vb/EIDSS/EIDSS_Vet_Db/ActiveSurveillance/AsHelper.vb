Imports bv.winclient.Core
Imports bv.common.Core

Namespace ActiveSurveillance
    Public Class AsHelper
        Public Shared Function GetDiagnosisRowFilter(row As DataRow, Optional checkSampleType As Boolean = True) As String
            If (checkSampleType) Then
                If (row("idfsDiagnosis") Is DBNull.Value) Then
                    Return String.Empty
                ElseIf row("idfsSpeciesType") Is DBNull.Value AndAlso row("idfsSampleType") Is DBNull.Value Then
                    Return String.Format("idfsDiagnosis={0} and idfsSpeciesType is null and idfsSampleType is null ", row("idfsDiagnosis"))
                ElseIf row("idfsSpeciesType") Is DBNull.Value AndAlso Not row("idfsSampleType") Is DBNull.Value Then
                    Return String.Format("idfsDiagnosis={0} and idfsSampleType = {1}  and idfsSpeciesType is null ", row("idfsDiagnosis"), row("idfsSampleType"))
                ElseIf Not row("idfsSpeciesType") Is DBNull.Value AndAlso row("idfsSampleType") Is DBNull.Value Then
                    Return String.Format("idfsDiagnosis={0} and idfsSpeciesType = {1} and idfsSampleType is null ", row("idfsDiagnosis"), row("idfsSpeciesType"))
                Else
                    Return String.Format("idfsDiagnosis={0} and idfsSpeciesType = {1} and idfsSampleType = {2}", row("idfsDiagnosis"), row("idfsSpeciesType"), row("idfsSampleType"))
                End If
            Else
                If (row("idfsDiagnosis") Is DBNull.Value) Then
                    Return String.Empty
                ElseIf row("idfsSpeciesType") Is DBNull.Value Then
                    Return String.Format("idfsDiagnosis={0} and idfsSpeciesType is null", row("idfsDiagnosis"))
                Else
                    Return String.Format("idfsDiagnosis={0} and idfsSpeciesType = {1}", row("idfsDiagnosis"), row("idfsSpeciesType"))
                End If
            End If
        End Function

        Public Shared Function ValidateSessionDataAgainstDiseaseRecords(usedSpeciesSamplesTable As DataTable, diseaseTable As DataTable) As Boolean
            If diseaseTable.Select("").Length = 0 Then
                Return True
            End If
            For Each row As DataRow In usedSpeciesSamplesTable.Rows
                If Not Utils.IsEmpty(row("idfsSampleType")) Then
                    If diseaseTable.Select(String.Format("(idfsSpeciesType = {0} or idfsSpeciesType is null) and (idfsSampleType = {1} or idfsSampleType is null)", row("idfsSpeciesType"), row("idfsSampleType"))).Length = 0 Then
                        Return False
                    End If
                Else
                    If diseaseTable.Select(String.Format("(idfsSpeciesType = {0} or idfsSpeciesType is null)", row("idfsSpeciesType"))).Length = 0 Then
                        Return False
                    End If
                End If
            Next
            Return True
        End Function
        Public Shared Function IsSessionDiseasesIncludedToCampaignDesieseas(sessionDiseases As DataTable, campaignDiseases As DataTable) As Boolean
            For Each row As DataRow In sessionDiseases.Rows
                If row.RowState = DataRowState.Deleted Then
                    Continue For
                End If
                Dim speciesType As Long = CLng(IIf(IsDBNull(row("idfsSpeciesType")), 0, row("idfsSpeciesType")))
                Dim sampleType As Long = CLng(IIf(IsDBNull(row("idfsSampleType")), 0, row("idfsSampleType")))
                If campaignDiseases.Select(String.Format("idfsDiagnosis={0} and isnull(idfsSpeciesType,0)= {1} and isnull(idfsSampleType,0)={2}", row("idfsDiagnosis"), speciesType, sampleType)).Length = 0 Then
                    Return False
                End If
            Next
            Return True
        End Function
    End Class
End Namespace