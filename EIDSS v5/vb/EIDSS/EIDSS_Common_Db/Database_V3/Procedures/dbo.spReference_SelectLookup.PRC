SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spReference_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spReference_SelectLookup]
GO



--##SUMMARY Selects lookup list of specific type
--##SUMMARY Used by Lookup Cache for populating base reference lookups
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:
DECLARE @type bigint
DECLARE @HACode int
SET @type = 19000086 
SET @HACode =64

EXECUTE spReference_SelectLookup
   'en'
  ,@type
  ,@HACode
  ,NULL
*/


CREATE     PROCEDURE dbo.spReference_SelectLookup 
	@LANGID	nvarchar(50),  --##PARAM @LANGID - language ID
	@type	bigint,   --##PARAM @type - base reference type
	@HACode	int = null,  --##PARAM @HACode - HA code for reference filtration
	@ID bigint = null  --##PARAM @ID - ID of specific record in trtBaseReference to be populated. If NULL entire lookup list is populated
AS
select
			b.idfsBaseReference as idfsReference, 
			IsNull(c.strTextString, b.strDefault) as [Name],
			b.strDefault, 
			b.intOrder

from		dbo.trtBaseReference as b 
left join	dbo.trtStringNameTranslation as c 
on			b.idfsBaseReference = c.idfsBaseReference 
			and c.idfsLanguage = dbo.fnGetLanguageCode(@LANGID)

where		b.idfsReferenceType = @type 
			and b.intRowStatus = 0 
			and (@ID IS NULL OR b.idfsBaseReference = @ID)
			and (@HACode = 0 or @HACode is null or intHACode is null or 
			CASE 
			--1=animal, 32=livestock , 64=avian
			--below we assume that client will never pass animal bit without livstock or avian bits
			WHEN (b.intHACode & 97) > 1 THEN (~1 & b.intHACode) & @HACode -- if avian or livstock bits are set, clear animal bit in  b.intHA_Code
			WHEN (b.intHACode & 97) = 1 THEN (~1 & b.intHACode | 96) & @HACode --if only animal bit is set, clear clear animal bit and set both avian and livstock bits in  b.intHA_Code
			ELSE b.intHACode & @HACode  END >0
			)
order by	IsNull(intOrder, 0), [Name]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

