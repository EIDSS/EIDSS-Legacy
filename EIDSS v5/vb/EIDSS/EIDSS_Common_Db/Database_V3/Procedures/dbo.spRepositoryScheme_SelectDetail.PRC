SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepositoryScheme_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepositoryScheme_SelectDetail]
GO

CREATE     PROCEDURE dbo.spRepositoryScheme_SelectDetail 
	@idfFreezer AS VARCHAR(36)
AS

SELECT	tlbFreezer.idfFreezer,
		--tlbFreezer.idfsPlacementID, 
		tlbFreezer.strFreezerName, 
		--tlbFreezer.intMaximumChildNumber, 
		tlbFreezer.strNote, 
		--tlbFreezer.intNormalTemperature, 
		--tlbFreezer.intPossibleTemperatureDeviation, 
		tlbFreezer.strBarcode, 
		--tlbFreezer.idfsSite, 
		--tlbFreezer.idfsSubdivisionType, 
--		tlbFreezer.idfUserID, 
		tlbFreezer.idfsStorageType/*,

--	@LanguageID instead of "en"	--

		dbo.fn_RepositoryGetPlacement('en', tlbFreezer.idfsPlacementID) as fullPath*/
--		ST.[Name]	
FROM		tlbFreezer
--			fnReference('en', 'rftStorageType') AS ST 
WHERE	idfFreezer = @idfFreezer
and	tlbFreezer.intRowStatus = 0
--	AND ST.idfsReference = tlbFreezer.idfsStorageType

SELECT	idfSubdivision, 
		strNameChars, 
		idfFreezer, 
		--intChildMaximumNumber, 
		strNote, 
		strBarcode, 
		--blnMovable, 
		--idfsSite, 
		--idfsLabLocationStatus, 
		idfsSubdivisionType, 
--		idfUserID, 
		idfParentSubdivision,
		intCapacity/*,
		idfsChild_SubdivisionType*/
FROM		tlbFreezerSubdivision
WHERE		idfFreezer = @idfFreezer
and		tlbFreezerSubdivision.intRowStatus = 0
order by strNameChars
/*
SELECT	idfLocationID, 
		idfContainer, 
		idfsSubdivisionID, 
		idfsSite, 
		idfsLab_Location_Type, 
		idfsLabLocationStatus
--		idfUserID
FROM		dbo.Lab_Location
WHERE		EXISTS(Select * From tlbFreezerSubdivision
			Where tlbFreezerSubdivision.idfsSubdivisionID = dbo.Lab_Location.idfsSubdivisionID
			And tlbFreezerSubdivision.idfSFreezerID = @idfsFreezerID
			and (isnull(tlbFreezerSubdivision.intRowStatus, 0) = 0))
*/


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

