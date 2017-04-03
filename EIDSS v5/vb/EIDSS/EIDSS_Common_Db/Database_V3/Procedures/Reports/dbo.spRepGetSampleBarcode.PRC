 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepGetSampleBarcode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepGetSampleBarcode]


GO

--##SUMMARY Select data for barcode.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 13.01.2010

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec spRepGetSampleBarcode 747500000000, 'en'

*/

CREATE  Procedure [dbo].[spRepGetSampleBarcode]
	(
		@ObjID	    as bigint,
		@LangID		varchar(20)
	)
AS	
	select		fnContainer.CaseID					as strCase, 
				fnContainer.strBarcode				as strBarcode,
				trtSpeciesType.strCode				as strSpeciesCode,
				rfSpeciemenType.strBaseReferenceCode as strSpecimenCode, -- this is the temporary solution for GAT only. We should create the special table with sample codes.
				--trtSpeciesType.strCode				as strSpeciesCode,
				convert(varchar(10), fnContainer.datFieldCollectionDate, 103)	as datCollectionDate
	from		fnContainerList(@LangID) as fnContainer
	left join	trtSpeciesType
	on			trtSpeciesType.idfsSpeciesType = fnContainer.idfsSpeciesType
	left join	fnReference(@LangID,19000086) rfSpeciesType 
	on			rfSpeciesType.idfsReference = fnContainer.idfsSpeciesType
	left join	dbo.trtBaseReference rfSpeciemenType
	on			rfSpeciemenType.idfsBaseReference = fnContainer.idfsSpecimenType
	where		idfContainer  = @ObjID
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

