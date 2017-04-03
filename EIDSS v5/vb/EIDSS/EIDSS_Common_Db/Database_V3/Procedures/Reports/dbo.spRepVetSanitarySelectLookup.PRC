GO
/****** Object:  StoredProcedure [dbo].[spRepVetSanitarySelectLookup]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepVetSanitarySelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepVetSanitarySelectLookup]

/****** Object:  StoredProcedure [dbo].[spRepVetSanitarySelectLookup]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure 
--##REMARKS Author: 
--##REMARKS Create date: 

--##RETURNS Don't use 

/*
--Example of a call of procedure:

exec spRepVetSanitarySelectLookup 'en'

*/ 
 
CREATE PROCEDURE [dbo].[spRepVetSanitarySelectLookup]
	@LangId			as varchar(36)
AS
BEGIN
	select distinct
		r.idfsReference, 
		r.[Name] as strName,
		r.intOrder  

--[Commented by Olga because of changes in report specification]			
--	from  tlbAggrMatrixVersionHeader h
--	inner join tlbAggrMatrixVersion v
--	on   v.idfVersion = h.idfVersion
--	   and v.intRowStatus = 0
--	-- S
--	inner join fnReference(@LangId, 19000079) r
--	on   r.idfsReference = cast(v.varValue as bigint)
--
--	where  h.idfsAggrCaseSection = 71260000000
--	   and h.blnIsActive = 1
--	   and h.intRowStatus = 0
--	   and v.idfsParameter = 233190000000
	from		fnReference(@LangId, 19000079) r
	inner join	trtSanitaryAction sa
	on			sa.idfsSanitaryAction = r.idfsReference
				and sa.intRowStatus = 0
	order by r.intOrder, r.[Name], r.idfsReference

END
GO
