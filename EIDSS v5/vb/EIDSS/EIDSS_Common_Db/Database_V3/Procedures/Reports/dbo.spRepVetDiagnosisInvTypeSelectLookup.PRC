GO
/****** Object:  StoredProcedure [dbo].[spRepVetDiagnosisInvTypeSelectLookup]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepVetDiagnosisInvTypeSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepVetDiagnosisInvTypeSelectLookup]

/****** Object:  StoredProcedure [dbo].[spRepVetDiagnosisInvTypeSelectLookup]    Script Date: 11/30/2009 17:11:49 ******/
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

exec spRepVetDiagnosisInvTypeSelectLookup 'en'

*/ 
 
CREATE PROCEDURE [dbo].[spRepVetDiagnosisInvTypeSelectLookup]
	@LangId			as varchar(36)
AS
BEGIN
	select distinct
		r.idfsReference, 
		r.[Name] as strName,
		r.intOrder  

--[Commented by Olga because of changes in report specification]			
--		from		tlbAggrMatrixVersionHeader h
--		inner join	tlbAggrMatrixVersion v
--		on			v.idfVersion = h.idfVersion
--					and v.intRowStatus = 0
--
--		-- P
--		inner join	tlbAggrProphylacticActionMTX p
--		on			p.idfAggrProphylacticActionMTX = v.idfRow
--					and p.intRowStatus = 0
--					and cast(v.varValue as bigint) = p.idfsProphilacticAction
--		inner join	fnReference(@LangID, 19000021) r
--		on			r.idfsReference = cast(v.varValue as bigint)
--
--		where		h.idfsAggrCaseSection = 71300000000
--					and h.blnIsActive = 1
--					and h.intRowStatus = 0
--					and v.idfsParameter = 245270000000
		from		fnReference(@LangID, 19000021) r
		order by	r.intOrder, r.[Name], r.idfsReference

END
GO
