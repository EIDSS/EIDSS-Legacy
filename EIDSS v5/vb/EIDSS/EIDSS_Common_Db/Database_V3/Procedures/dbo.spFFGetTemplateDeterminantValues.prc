set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetTemplateDeterminantValues]')) DROP PROCEDURE [dbo].[spFFGetTemplateDeterminantValues]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 22.09.09
-- Description:	Return list of Template Determinant Values
-- =============================================
CREATE PROCEDURE dbo.spFFGetTemplateDeterminantValues
(
	@LangID Nvarchar(50) = Null
	,@idfsFormTemplate Bigint = Null	
)
AS
BEGIN	
	Set Nocount On;

	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);

    Select
		DV.idfDeterminantValue
		,FT.idfsFormTemplate
		,FT.idfsFormType
		,Isnull(DV.idfsBaseReference, DV.idfsGISBaseReference) as [DeterminantValue]
		,Case 
			When (DV.idfsBaseReference Is Not null) Then
				(Select [strDefault] From dbo.trtBaseReference Where [idfsBaseReference] = DV.idfsBaseReference  And [intRowStatus] = 0)
			Else
				(Select [strDefault] From dbo.gisBaseReference Where [idfsGISBaseReference] = DV.idfsGISBaseReference  And [intRowStatus] = 0)
			End As  [DeterminantDefaultName]
		,Case
			When (DV.idfsBaseReference Is Not null) Then
				(Select [strTextString] From dbo.[trtStringNameTranslation] Where [idfsBaseReference] = DV.idfsBaseReference And idfsLanguage = @LangID_int  And [intRowStatus] = 0)
			Else
				(Select [strTextString] From dbo.[gisStringNameTranslation] Where [idfsGISBaseReference] = DV.idfsGISBaseReference And idfsLanguage = @LangID_int  And [intRowStatus] = 0)
			End As  [DeterminantNationalName]	
				
		,[idfsBaseReference]
		,[idfsGISBaseReference]
		
		,Case
			When (DV.idfsBaseReference Is Not null) Then
				(Select idfsReferenceType From dbo.trtBaseReference Where [idfsBaseReference] = DV.idfsBaseReference And [intRowStatus] = 0)
			Else
				(Select idfsGISReferenceType From dbo.gisBaseReference Where [idfsGISBaseReference] = DV.idfsGISBaseReference And [intRowStatus] = 0)
			End As  [DeterminantType]
			
		,Case
			When (DV.idfsBaseReference Is Not null) Then
				(Select strReferenceTypeName From dbo.trtReferenceType Where [idfsReferenceType] in
					(Select Top 1 idfsReferenceType From dbo.trtBaseReference Where [idfsBaseReference] = DV.idfsBaseReference And [intRowStatus] = 0) And [intRowStatus] = 0
				)
			Else
				(Select strGISReferenceTypeName From dbo.gisReferenceType Where [idfsGISReferenceType] in
					(Select Top 1 idfsGISReferenceType From dbo.gisBaseReference Where [idfsGISBaseReference] = DV.idfsGISBaseReference And [intRowStatus] = 0)  And [intRowStatus] = 0
				)
			End As  [DeterminantTypeDefaultName]
			
		,Isnull(
					Case
					When (DV.idfsBaseReference Is Not null) Then
						(Select [strTextString] From dbo.[trtStringNameTranslation] Where idfsLanguage = @LangID_int And [idfsBaseReference] in
							(Select Top 1 idfsReferenceType From dbo.trtReferenceType Where [idfsReferenceType] in
								(Select Top 1 idfsReferenceType From dbo.trtBaseReference Where [idfsBaseReference] = DV.idfsBaseReference And [intRowStatus] = 0) And [intRowStatus] = 0
							) And [intRowStatus] = 0
						)
					Else
						(
							Select strTextString From dbo.trtStringNameTranslation Where idfsBaseReference = 10003001 And idfsLanguage = @LangID_int And [intRowStatus] = 0
						)
					End 
				,
				Case
				When (DV.idfsBaseReference Is Not null) Then
				(Select strReferenceTypeName From dbo.trtReferenceType Where [idfsReferenceType] in
					(Select Top 1 idfsReferenceType From dbo.trtBaseReference Where [idfsBaseReference] = DV.idfsBaseReference And [intRowStatus] = 0) And [intRowStatus] = 0
				)
				Else
					(
						Select strGISReferenceTypeName From dbo.gisReferenceType Where idfsGISReferenceType = 19000001 And [intRowStatus] = 0
					)
				End
			)
			As  [DeterminantTypeNationalName]
		
		From dbo.[ffFormTemplate] FT
		Inner Join dbo.[ffDeterminantValue] DV On FT.idfsFormTemplate = DV.idfsFormTemplate And DV.[intRowStatus]=0 
		Where
			((FT.idfsFormTemplate = @idfsFormTemplate ) OR (@idfsFormTemplate IS null))				
			 And FT.[intRowStatus] = 0
		Order by [DeterminantNationalName]
End
Go
