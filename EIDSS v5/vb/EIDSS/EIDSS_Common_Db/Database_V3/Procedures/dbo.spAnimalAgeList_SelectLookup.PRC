SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAnimalAgeList_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAnimalAgeList_SelectLookup]
GO
--##SUMMARY Selects list of animal ages for lookup purposes

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:
exec spAnimalAgeList_SelectLookup 'en', null
*/

CREATE   PROCEDURE dbo.spAnimalAgeList_SelectLookup
	@LanguageID As nvarchar(50), --##PARAM @LanguageID - language ID
	@idfsSpecies AS VARCHAR(36)	--##PARAM @idfsSpecies - pointer to species type. If not null only ages for specific species are selected, in other case full ages list is returned
AS
DECLARE @tmp Table
(
	idfRowNumber bigint not null PRIMARY KEY ,
	idfsSpeciesType bigint,
	idfsReference bigint,
	[Name] nvarchar(200),
	intOrder int
)
insert into @tmp
SELECT 	
	ROW_NUMBER() OVER(ORDER BY idfsReference DESC) AS idfRowNumber,
	idfsSpeciesType,
	idfsReference,
	[Name],
	intOrder
FROM dbo.fnReference(@LanguageID,19000005/*'rftAnimalAgeList'*/)
INNER JOIN trtSpeciesTypeToAnimalAge ON 
	trtSpeciesTypeToAnimalAge.idfsAnimalAge = dbo.fnReference.idfsReference
WHERE 
	trtSpeciesTypeToAnimalAge.intRowStatus = 0 
	AND (@idfsSpecies IS NULL OR trtSpeciesTypeToAnimalAge.idfsSpeciesType=@idfsSpecies)

select * from @tmp ORDER BY intOrder



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

