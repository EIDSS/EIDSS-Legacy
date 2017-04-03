SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spQuery_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spQuery_Delete]
GO

--##SUMMARY This procedure deletes records related to specified query.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 21.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@ID bigint
execute	spQuery_Delete @ID		
				
*/ 


create procedure	spQuery_Delete
	@ID bigint
as

declare	@QueryDescriptionID	bigint
declare	@FunctionName		varchar(200)

select	@FunctionName = strFunctionName,
		@QueryDescriptionID = idflDescription
from	tasQuery
where	idflQuery = @ID


select	cast(idfQuerySearchObject as bigint) as idfQuerySearchObject into #DelQSO
from	tasQuerySearchObject
where	idflQuery = @ID

declare @GoOn int
set @GoOn = 1

while @GoOn > 0
begin
	insert into		#DelQSO
	select distinct	qso.idfQuerySearchObject
	from			tasQuerySearchObject qso
	inner join		#DelQSO qso_parent
	on				qso_parent.idfQuerySearchObject = qso.idfParentQuerySearchObject
	left join		#DelQSO qso_ex
	on				qso_ex.idfQuerySearchObject = qso.idfQuerySearchObject
	where			qso_ex.idfQuerySearchObject is null

	set @GoOn = @@rowcount
end


select		cast(idfQueryConditionGroup as bigint) as idfQueryConditionGroup into #DelQCG
from		tasQueryConditionGroup qcg
inner join	#DelQSO qso_del
on			qso_del.idfQuerySearchObject = qcg.idfQuerySearchObject

set @GoOn = 1
while @GoOn > 0
begin
	insert into		#DelQCG
	select distinct	qcg.idfQueryConditionGroup
	from			tasQueryConditionGroup qcg
	inner join		#DelQCG qcg_parent
	on				qcg_parent.idfQueryConditionGroup = qcg.idfParentQueryConditionGroup
	left join		#DelQCG qcg_ex
	on				qcg_ex.idfQueryConditionGroup = qcg.idfQueryConditionGroup
	where			qcg_ex.idfQueryConditionGroup is null

	set @GoOn = @@rowcount
end

delete		qsfc
from		tasQuerySearchFieldCondition qsfc
inner join	#DelQCG qcg_del
on			qcg_del.idfQueryConditionGroup = qsfc.idfQueryConditionGroup

delete		qcg
from		tasQueryConditionGroup qcg
inner join	#DelQCG qcg_del
on			qcg_del.idfQueryConditionGroup = qcg.idfQueryConditionGroup

drop table	#DelQCG

delete		qsfc
from		tasQuerySearchFieldCondition qsfc
inner join	tasQuerySearchField qsf
on			qsf.idfQuerySearchField = qsfc.idfQuerySearchField
inner join	#DelQSO qso_del
on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

delete		lsfa
from		tasLayoutSearchFieldAggregation lsfa
inner join	tasQuerySearchField qsf
on			qsf.idfQuerySearchField = lsfa.idfDenominatorQuerySearchField
inner join	#DelQSO qso_del
on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

delete		lsfa
from		tasLayoutSearchFieldAggregation lsfa
inner join	tasQuerySearchField qsf
on			qsf.idfQuerySearchField = lsfa.idfUnitQuerySearchField
inner join	#DelQSO qso_del
on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

delete		lsfa
from		tasLayoutSearchFieldAggregation lsfa
inner join	tasQuerySearchField qsf
on			qsf.idfQuerySearchField = lsfa.idfQuerySearchField
inner join	#DelQSO qso_del
on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

delete		qsf
from		tasQuerySearchField qsf
inner join	#DelQSO qso_del
on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

delete		qso
from		tasQuerySearchObject qso
inner join	#DelQSO qso_del
on			qso_del.idfQuerySearchObject = qso.idfQuerySearchObject

drop table	#DelQSO


select		cast(idflLayout as bigint) as idflLayout into	#DelLayout
from		tasLayout
where		idflQuery = @ID

delete		lsfa
from		tasLayoutSearchFieldAggregation lsfa
inner join	#DelLayout l_del
on			l_del.idflLayout = lsfa.idflLayout

delete		l
from		tasLayout l
inner join	#DelLayout l_del
on			l_del.idflLayout = l.idflLayout

delete		lsnt
from		locStringNameTranslation lsnt
inner join	#DelLayout l_del
on			l_del.idflLayout = lsnt.idflBaseReference

delete		lbr
from		locBaseReference lbr
inner join	#DelLayout l_del
on			l_del.idflLayout = lbr.idflBaseReference

drop table	#DelLayout


select		cast(idflLayoutFolder as bigint) as idflLayoutFolder into	#DelLayoutFolder
from		tasLayoutFolder
where		idflQuery = @ID

delete		lf
from		tasLayoutFolder lf
inner join	#DelLayoutFolder lf_del
on			lf_del.idflLayoutFolder = lf.idflLayoutFolder

delete		lsnt
from		locStringNameTranslation lsnt
inner join	#DelLayoutFolder lf_del
on			lf_del.idflLayoutFolder = lsnt.idflBaseReference

delete		lbr
from		locBaseReference lbr
inner join	#DelLayoutFolder lf_del
on			lf_del.idflLayoutFolder = lbr.idflBaseReference

drop table	#DelLayoutFolder


delete from	tasQuery
where		idflQuery = @ID

if @ID is not null
begin
	execute	spAsReferenceDelete @ID
end

if @QueryDescriptionID is not null
begin
	execute	spAsReferenceDelete @QueryDescriptionID
end

if @FunctionName is not null
begin
	declare @sqlCmd nvarchar(2000)
	set @sqlCmd = '
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N''[dbo].[' + @FunctionName + ']'') AND type in (N''FN'', N''IF'', N''TF'', N''FS'', N''FT''))
DROP FUNCTION [dbo].[' + @FunctionName + ']
'
	exec sp_executeSQL @sqlCmd
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

