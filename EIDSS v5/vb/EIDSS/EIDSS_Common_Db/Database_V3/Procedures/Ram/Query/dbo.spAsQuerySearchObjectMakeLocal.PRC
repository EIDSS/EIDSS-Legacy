SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQuerySearchObjectMakeLocal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQuerySearchObjectMakeLocal]
GO

--##SUMMARY This procedure publishes query search object 

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 20.08.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

execute	spAsQuerySearchObjectMakeLocal 719900000000, 719150000000

*/ 



create procedure	spAsQuerySearchObjectMakeLocal
(
	@idflLayout					bigint,
	@idfsLayout					bigint
	)
as
	
	declare @idflQuery					bigint
	declare @idfsQuery					bigint
	declare @idfRootQuerySearchObject	bigint
	
	
	if	not exists	(	
					select	*
					from	tasLayout
					where	idflLayout = @idflLayout
					)
	begin
		Raiserror (N'Layout with ID=%I64d doesn''t exist.', 15, 1,  @idflLayout)
		return 1
	end
	
	begin try
		select	@idflQuery = idflQuery
		from	tasLayout 
		where	idflLayout = @idflLayout
		
		
		select	@idfsQuery = idfsGlobalQuery 
		from	tasQuery
		where	idflQuery = @idflQuery
		
		
		-- delete old Query Search Field Condition
		delete		glsfc
		from		tasglQuerySearchFieldCondition	 gqsfc
		inner join 	tasQuerySearchFieldCondition	 glsfc
		on			gqsfc.idfQuerySearchFieldCondition = gqsfc.idfQuerySearchFieldCondition
		inner join	tasglQueryConditionGroup	gqcg
		on			gqcg.idfQueryConditionGroup = gqsfc.idfQueryConditionGroup 
		inner join	tasQueryConditionGroup lqcg
		on			lqcg.idfQueryConditionGroup = gqcg.idfQueryConditionGroup
		inner join	tasQuerySearchObject	lqso
		on			gqcg.idfQuerySearchObject = lqso.idfQuerySearchObject
		inner join	tasglQuerySearchObject	gqso
		on			lqso.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery

	-- delete old Layout Search Field Aggregation
		delete		lsfa
		from		tasLayoutSearchFieldAggregation lsfa
		inner join	tasQuerySearchField	lqsf
		on			lsfa.idfQuerySearchField = lqsf.idfQuerySearchField
		inner join	tasQuerySearchObject	lqso
		on			lqsf.idfQuerySearchObject = lqso.idfQuerySearchObject
		inner join	tasglQuerySearchObject	gqso
		on			lqso.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery
		
	-- delete old Query Search Field
		delete		lqsf	
		from		tasQuerySearchField lqsf
		inner join	tasglQuerySearchField	gqsf
		on			lqsf.idfQuerySearchField = gqsf.idfQuerySearchField
		inner join	tasQuerySearchObject	lqso
		on			gqsf.idfQuerySearchObject = lqso.idfQuerySearchObject
		inner join	tasglQuerySearchObject	gqso
		on			lqso.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery
		
	-- delete old Query Condition Group
		delete		lqcg	
		from		tasQueryConditionGroup lqcg
		inner join	tasglQueryConditionGroup	gqcg
		on			lqcg.idfQueryConditionGroup = gqcg.idfQueryConditionGroup
		inner join	tasQuerySearchObject	lqso
		on			gqcg.idfQuerySearchObject = lqso.idfQuerySearchObject
		inner join	tasglQuerySearchObject	gqso
		on			lqso.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery
		
	-- delete old Query Search Object
		delete		lqso
		from		tasQuerySearchObject	lqso
		inner join	tasglQuerySearchObject	gqso
		on			lqso.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery

		-- insert root query search object
		insert into tasQuerySearchObject
			   (idfQuerySearchObject
			   ,idflQuery
			   ,idfsSearchObject
			   ,idfParentQuerySearchObject
			   ,intOrder)
		select	idfQuerySearchObject
			   ,@idflQuery
			   ,idfsSearchObject
			   ,null
			   ,intOrder
		from	tasglQuerySearchObject 	
		where   idfsQuery = @idfsQuery
		and		idfParentQuerySearchObject is null
	    
		select	@idfRootQuerySearchObject = idfQuerySearchObject
		from	tasQuerySearchObject
		where	idflQuery = @idflQuery
		and		idfParentQuerySearchObject is null
		
		-- insert child query search object
		insert into tasQuerySearchObject
			   (idfQuerySearchObject
			   ,idflQuery
			   ,idfsSearchObject
			   ,idfParentQuerySearchObject
			   ,intOrder)
		select	idfQuerySearchObject
			   ,@idflQuery
			   ,idfsSearchObject
			   ,@idfRootQuerySearchObject
			   ,intOrder
		from	tasglQuerySearchObject 	
		where	idfsQuery = @idfsQuery
		and		idfParentQuerySearchObject = @idfRootQuerySearchObject
		
		
	--insert Query search field
		
		insert into tasQuerySearchField
			   (idfQuerySearchField
			   ,idfQuerySearchObject
			   ,blnShow
			   ,idfsSearchField
			   ,idfsParameter
			   )
		select
				qsf.idfQuerySearchField
			   ,qsf.idfQuerySearchObject
			   ,qsf.blnShow
			   ,qsf.idfsSearchField
			   ,qsf.idfsParameter
		from	tasglQuerySearchField qsf
		inner join	tasglQuerySearchObject	qso
		on			qsf.idfQuerySearchObject = qso.idfQuerySearchObject
		where		qso.idfsQuery = @idfsQuery	
		

	--insert Query Condition Group
		insert into tasQueryConditionGroup
			   (idfQueryConditionGroup
			   ,idfQuerySearchObject
			   ,idfParentQueryConditionGroup
			   ,intOrder
			   ,blnJoinByOr
			   ,blnUseNot)
		select	qcg.idfQueryConditionGroup
			   ,qcg.idfQuerySearchObject
			   ,qcg.idfParentQueryConditionGroup
			   ,qcg.intOrder
			   ,qcg.blnJoinByOr
			   ,qcg.blnUseNot
		from		tasglQueryConditionGroup qcg	
		inner join	tasglQuerySearchObject qso
		on			qcg.idfQuerySearchObject = qso.idfQuerySearchObject
		where		qso.idfsQuery = @idfsQuery
		
	--insert Query search field condition

		insert into tasQuerySearchFieldCondition
			   (idfQuerySearchFieldCondition
			   ,idfQueryConditionGroup
			   ,idfQuerySearchField
			   ,strOperator
			   ,intOrder
			   ,intOperatorType
			   ,blnUseNot
			   ,varValue)
		select
				qsfc.idfQuerySearchFieldCondition
			   ,qsfc.idfQueryConditionGroup
			   ,qsfc.idfQuerySearchField
			   ,qsfc.strOperator
			   ,qsfc.intOrder
			   ,qsfc.intOperatorType
			   ,qsfc.blnUseNot
			   ,qsfc.varValue
		from		tasglQuerySearchFieldCondition qsfc
		inner join	tasglQueryConditionGroup qcg	
		on			qsfc.idfQueryConditionGroup = qcg.idfQueryConditionGroup
		inner join	tasglQuerySearchObject qso
		on			qcg.idfQuerySearchObject = qso.idfQuerySearchObject
		where		qso.idfsQuery = @idfsQuery     
		
	end try
	begin catch
		declare @error nvarchar(max)
		set @error = ERROR_PROCEDURE() +': '+ ERROR_MESSAGE()
		Raiserror (N'Error while making local query search object: %s', 15, 1, @error)
		return 1
	end catch

GO



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

