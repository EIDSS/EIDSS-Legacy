SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQuerySearchObjectPublish]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQuerySearchObjectPublish]
GO

--##SUMMARY This procedure publishes query search object 

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 20.08.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

execute	spAsQuerySearchObjectPublish 711830000000

*/ 



create procedure	spAsQuerySearchObjectPublish
(
	@idflLayout					bigint
	)
as
	declare @idfsLayout					bigint
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
		
		select	 @idfsLayout = idfsGlobalLayout 
				,@idflQuery = idflQuery
		from	tasLayout 
		where	idflLayout = @idflLayout
		
		select	@idfsQuery = idfsGlobalQuery 
		from	tasQuery 
		where	idflQuery = @idflQuery

	-- delete old Query Search Field Condition
		delete		gqsfc
		from		tasglQuerySearchFieldCondition	 gqsfc
		inner join 	tasQuerySearchFieldCondition	 glsfc
		on			gqsfc.idfQuerySearchFieldCondition = gqsfc.idfQuerySearchFieldCondition
		inner join	tasglQueryConditionGroup	gqcg
		on			gqcg.idfQueryConditionGroup = gqsfc.idfQueryConditionGroup 
		inner join	tasQueryConditionGroup lqcg
		on			lqcg.idfQueryConditionGroup = gqcg.idfQueryConditionGroup
		inner join	tasglQuerySearchObject	gqso
		on			gqcg.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery

	-- delete old Layout Search Field Aggregation
		delete		lsfa
		from		tasglLayoutSearchFieldAggregation lsfa
		inner join	tasglQuerySearchField	gqsf
		on			lsfa.idfQuerySearchField = gqsf.idfQuerySearchField
		inner join	tasglQuerySearchObject	gqso
		on			gqsf.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery	
		
	-- delete old Query Search Field
		delete		gqsf	
		from		tasQuerySearchField lqsf
		inner join	tasglQuerySearchField	gqsf
		on			lqsf.idfQuerySearchField = gqsf.idfQuerySearchField
		inner join	tasglQuerySearchObject	gqso
		on			gqsf.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery	
		
	-- delete old Query Condition Group
		delete		gqcg	
		from		tasQueryConditionGroup lqcg
		inner join	tasglQueryConditionGroup	gqcg
		on			lqcg.idfQueryConditionGroup = gqcg.idfQueryConditionGroup
		inner join	tasglQuerySearchObject	gqso
		on			gqcg.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery
		
	-- delete old Query Search Object
		delete		gqso
		from		tasQuerySearchObject	lqso
		inner join	tasglQuerySearchObject	gqso
		on			lqso.idfQuerySearchObject = gqso.idfQuerySearchObject
		where		gqso.idfsQuery = @idfsQuery
				
				
		-- insert root query search object
		insert into tasglQuerySearchObject
			   (idfQuerySearchObject
			   ,idfsQuery
			   ,idfsSearchObject
			   ,idfParentQuerySearchObject
			   ,intOrder)
		select	idfQuerySearchObject
			   ,@idfsQuery
			   ,idfsSearchObject
			   ,null
			   ,intOrder
		from	tasQuerySearchObject 	
		where   idflQuery = @idflQuery
		and		idfParentQuerySearchObject is null
	    
		select	@idfRootQuerySearchObject = idfQuerySearchObject
		from	tasglQuerySearchObject
		where	idfsQuery = @idfsQuery
		and		idfParentQuerySearchObject is null
		
		-- insert child query search object
		insert into tasglQuerySearchObject
			   (idfQuerySearchObject
			   ,idfsQuery
			   ,idfsSearchObject
			   ,idfParentQuerySearchObject
			   ,intOrder)
		select	idfQuerySearchObject
			   ,@idfsQuery
			   ,idfsSearchObject
			   ,@idfRootQuerySearchObject
			   ,intOrder
		from	tasQuerySearchObject 	
		where	idflQuery = @idflQuery
		and		idfParentQuerySearchObject = @idfRootQuerySearchObject
		
		

	--insert Query search field
		
		insert into tasglQuerySearchField
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
		from	tasQuerySearchField qsf
		inner join	tasQuerySearchObject	qso
		on			qsf.idfQuerySearchObject = qso.idfQuerySearchObject
		--where		qso.idflQuery = 710430000000
		where		qso.idflQuery = @idflQuery	
		

	--insert Query Condition Group
		insert into tasglQueryConditionGroup
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
		from		tasQueryConditionGroup qcg	
		inner join	tasQuerySearchObject qso
		on			qcg.idfQuerySearchObject = qso.idfQuerySearchObject
		where		qso.idflQuery = @idflQuery
		
	--insert Query search field condition

		insert into tasglQuerySearchFieldCondition
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
		from		tasQuerySearchFieldCondition qsfc
		inner join	tasQueryConditionGroup qcg	
		on			qsfc.idfQueryConditionGroup = qcg.idfQueryConditionGroup
		inner join	tasQuerySearchObject qso
		on			qcg.idfQuerySearchObject = qso.idfQuerySearchObject
		where		qso.idflQuery = @idflQuery     

	end try
	begin catch
		declare @error nvarchar(max)
		set @error = ERROR_PROCEDURE() +': '+ ERROR_MESSAGE()
		Raiserror (N'Error while publishing query search object: %s', 15, 1, @error)
		return 1
	end catch




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

