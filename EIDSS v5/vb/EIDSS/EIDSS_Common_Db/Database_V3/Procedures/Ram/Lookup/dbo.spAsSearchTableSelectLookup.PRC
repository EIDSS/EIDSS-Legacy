SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsSearchTableSelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsSearchTableSelectLookup]
GO

--##SUMMARY Selects lookup tree of search tables.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 01.09.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:
exec spAsSearchTableSelectLookup 'en'

*/ 
CREATE          PROCEDURE dbo.spAsSearchTableSelectLookup
	@LanguageID	as nvarchar(50) --##PARAM @LanguageID - language ID
as

select		cast(stjr.idfMainSearchTable as varchar(100)) + '__' + 
				cast(stjr.idfSearchTable as varchar(100)) as idfSearchTableTree,
			stjr.idfMainSearchTable,
			stjr.idfSearchTable,
			stjr.idfParentSearchTable,
			stjr.strJoinCondition,
			st.strTableName,
			st.strFrom,
			st.intTableCount,
			st.blnPrimary
from		tasSearchTableJoinRule stjr
inner join	tasSearchTable st
on			st.idfSearchTable = stjr.idfSearchTable
union
select		cast(st_main.idfSearchTable as varchar(100)) + '__' + 
				cast(st_main.idfSearchTable as varchar(100)) as idfSearchTableTree,
			st_main.idfSearchTable,
			st_main.idfSearchTable,
			null as idfParentSearchTable,
			null as strJoinCondition,
			st_main.strTableName,
			st_main.strFrom,
			st_main.intTableCount,
			st_main.blnPrimary
from		tasSearchObject so
inner join	trtBaseReference br_so
on			br_so.idfsBaseReference = so.idfsSearchObject
			and br_so.idfsReferenceType = 19000082	-- rftSearchObject
			and br_so.intRowStatus = 0
inner join	tasSearchTable st_main
on			st_main.idfSearchTable = so.idfMainSearchTable
order by	idfSearchTableTree


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

