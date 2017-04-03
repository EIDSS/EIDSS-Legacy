GO
/****** Object:  StoredProcedure [dbo].[spAsLayoutAggregatePost]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayoutAggregatePost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayoutAggregatePost]

/****** Object:  StoredProcedure [dbo].[spAsLayoutAggregatePost]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY select layouts for analytical module

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 03.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec spAsLayoutAggregatePost 
	@idflLayout=23480000241,
	@idfsAggregateFunction=10004006,
	@SearchFieldAlias=N'sflHC_CaseID',
	@UnitSearchFieldAlias=N'sflHC_PatientCRRegion',
	@DenominatorSearchFieldAlias=N'',
	@DateSearchFieldAlias=N'sflHC_EnteredDate'

*/ 

CREATE PROCEDURE [dbo].[spAsLayoutAggregatePost]

	@idflLayout						as bigint,
	@SearchFieldAlias				as varchar(200),
	@idfsAggregateFunction			as bigint,
	@UnitSearchFieldAlias			as varchar(200) = null,
	@DenominatorSearchFieldAlias	as varchar(200) = null,
	@DateSearchFieldAlias			as varchar(200) = null
AS
-- todo: Olga, please check end of procedure
	if	not exists	(	 
						select	1
						from	tasLayout
						where	idflLayout = @idflLayout
					)
	begin
		RAISERROR (N'Layout with ID=%I64d doesnt exist.', 15, 1,  @idflLayout)
		return 1
	end

	if	not exists	(	 
						select	1
						from	dbo.fnReference('en', 19000004 /*'rftAggregateFunction'*/) as fnRef
						where	fnRef.idfsReference = @idfsAggregateFunction
					)
	begin
		RAISERROR (N'Aggregate function with ID=%I64d doesnt exist.', 15, 1,  @idfsAggregateFunction)
		return 1
	end
	
	declare @idfQuerySearchField as bigint
	declare @idfUnitQuerySearchField as bigint
	declare @idfDenominatorQuerySearchField as bigint
	declare @idfDateQuerySearchField as bigint
	declare @idfLayoutSearchFieldAggregation as bigint
	
	select	@idfQuerySearchField = qsf.idfQuerySearchField
	  from	tasQuerySearchField qsf
inner join	(
					tasQuerySearchObject qso
		inner join	tasLayout l
				on	l.idflQuery = qso.idflQuery
			   and	l.idflLayout = @idflLayout
		inner join	tasSearchObject sob
				on	sob.idfsSearchObject = qso.idfsSearchObject
		inner join	trtBaseReference br_sob
				on	br_sob.idfsBaseReference = sob.idfsSearchObject
			   and	br_sob.intRowStatus = 0
			)
		on	qso.idfQuerySearchObject = qsf.idfQuerySearchObject
inner join	(
					tasSearchField sf
		inner join	trtBaseReference br_sf
				on	br_sf.idfsBaseReference = sf.idfsSearchField
			   and	br_sf.intRowStatus = 0
			)
		on	sf.idfsSearchField = qsf.idfsSearchField
	   and	sf.idfsSearchObject = qso.idfsSearchObject
 left join	(
					ffParameter p
		inner join	trtBaseReference br_p
				on	br_p.idfsBaseReference = p.idfsParameter
			   and	br_p.intRowStatus = 0
			)
		on	p.idfsParameter = qsf.idfsParameter
			and p.idfsFormType = sob.idfsFormType
			and p.intRowStatus = 0
	 where	sf.strSearchFieldAlias + 
			IsNull(	'__' + cast(sob.idfsFormType as varchar(20)) + '__' + 
			cast(qsf.idfsParameter as varchar(20)), '') = @SearchFieldAlias
	

	
	if (@UnitSearchFieldAlias is not null)
	select	@idfUnitQuerySearchField = qsf.idfQuerySearchField
	  from	tasQuerySearchField qsf
inner join	(
					tasQuerySearchObject qso
		inner join	tasLayout l
				on	l.idflQuery = qso.idflQuery
			   and	l.idflLayout = @idflLayout
		inner join	tasSearchObject sob
				on	sob.idfsSearchObject = qso.idfsSearchObject
		inner join	trtBaseReference br_sob
				on	br_sob.idfsBaseReference = sob.idfsSearchObject
			   and	br_sob.intRowStatus = 0
			)
		on	qso.idfQuerySearchObject = qsf.idfQuerySearchObject
inner join	(
					tasSearchField sf
		inner join	trtBaseReference br_sf
				on	br_sf.idfsBaseReference = sf.idfsSearchField
			   and	br_sf.intRowStatus = 0
			)
		on	sf.idfsSearchField = qsf.idfsSearchField
	   and	sf.idfsSearchObject = qso.idfsSearchObject
 left join	(
					ffParameter p
		inner join	trtBaseReference br_p
				on	br_p.idfsBaseReference = p.idfsParameter
			   and	br_p.intRowStatus = 0
			)
		on	p.idfsParameter = qsf.idfsParameter
			and p.idfsFormType = sob.idfsFormType
			and p.intRowStatus = 0
	 where	sf.strSearchFieldAlias + 
			IsNull(	'__' + cast(sob.idfsFormType as varchar(20)) + '__' + 
			cast(qsf.idfsParameter as varchar(20)), '') = @UnitSearchFieldAlias
	
	
	if (@DenominatorSearchFieldAlias is not null)
	select	@idfDenominatorQuerySearchField = qsf.idfQuerySearchField
	  from	tasQuerySearchField qsf
inner join	(
					tasQuerySearchObject qso
		inner join	tasLayout l
				on	l.idflQuery = qso.idflQuery
			   and	l.idflLayout = @idflLayout
		inner join	tasSearchObject sob
				on	sob.idfsSearchObject = qso.idfsSearchObject
		inner join	trtBaseReference br_sob
				on	br_sob.idfsBaseReference = sob.idfsSearchObject
			   and	br_sob.intRowStatus = 0
			)
		on	qso.idfQuerySearchObject = qsf.idfQuerySearchObject
inner join	(
					tasSearchField sf
		inner join	trtBaseReference br_sf
				on	br_sf.idfsBaseReference = sf.idfsSearchField
			   and	br_sf.intRowStatus = 0
			)
		on	sf.idfsSearchField = qsf.idfsSearchField
	   and	sf.idfsSearchObject = qso.idfsSearchObject
 left join	(
					ffParameter p
		inner join	trtBaseReference br_p
				on	br_p.idfsBaseReference = p.idfsParameter
			   and	br_p.intRowStatus = 0
			)
		on	p.idfsParameter = qsf.idfsParameter
			and p.idfsFormType = sob.idfsFormType
			and p.intRowStatus = 0
	 where	sf.strSearchFieldAlias + 
			IsNull(	'__' + cast(sob.idfsFormType as varchar(20)) + '__' + 
			cast(qsf.idfsParameter as varchar(20)), '') = @DenominatorSearchFieldAlias
	
	if (@DateSearchFieldAlias is not null)
	select	@idfDateQuerySearchField = qsf.idfQuerySearchField
	  from	tasQuerySearchField qsf
inner join	(
					tasQuerySearchObject qso
		inner join	tasLayout l
				on	l.idflQuery = qso.idflQuery
			   and	l.idflLayout = @idflLayout
		inner join	tasSearchObject sob
				on	sob.idfsSearchObject = qso.idfsSearchObject
		inner join	trtBaseReference br_sob
				on	br_sob.idfsBaseReference = sob.idfsSearchObject
			   and	br_sob.intRowStatus = 0
			)
		on	qso.idfQuerySearchObject = qsf.idfQuerySearchObject
inner join	(
					tasSearchField sf
		inner join	trtBaseReference br_sf
				on	br_sf.idfsBaseReference = sf.idfsSearchField
			   and	br_sf.intRowStatus = 0
			)
		on	sf.idfsSearchField = qsf.idfsSearchField
	   and	sf.idfsSearchObject = qso.idfsSearchObject
 left join	(
					ffParameter p
		inner join	trtBaseReference br_p
				on	br_p.idfsBaseReference = p.idfsParameter
			   and	br_p.intRowStatus = 0
			)
		on	p.idfsParameter = qsf.idfsParameter
			and p.idfsFormType = sob.idfsFormType
			and p.intRowStatus = 0
	 where	sf.strSearchFieldAlias + 
			IsNull(	'__' + cast(sob.idfsFormType as varchar(20)) + '__' + 
			cast(qsf.idfsParameter as varchar(20)), '') = @DateSearchFieldAlias

	select	@idfLayoutSearchFieldAggregation = idfLayoutSearchFieldAggregation
	  from	tasLayoutSearchFieldAggregation
	 where	idflLayout = @idflLayout
	   and	idfQuerySearchField = @idfQuerySearchField
			   
	if (@idfLayoutSearchFieldAggregation is null)
	begin
		exec spsysGetNewID @idfLayoutSearchFieldAggregation output
		insert into	tasLayoutSearchFieldAggregation
				   (idfLayoutSearchFieldAggregation
				   ,idflLayout
				   ,idfsAggregateFunction
				   ,idfQuerySearchField
				   ,idfUnitQuerySearchField
				   ,idfDenominatorQuerySearchField
				   ,idfDateQuerySearchField)
			 values
				   (@idfLayoutSearchFieldAggregation
				   ,@idflLayout
				   ,@idfsAggregateFunction
				   ,@idfQuerySearchField
				   ,@idfUnitQuerySearchField
				   ,@idfDenominatorQuerySearchField
				   ,@idfDateQuerySearchField)
    end
    else begin
		update	tasLayoutSearchFieldAggregation
		   set	idfsAggregateFunction = @idfsAggregateFunction, 
				idfUnitQuerySearchField = @idfUnitQuerySearchField,
				idfDenominatorQuerySearchField = @idfDenominatorQuerySearchField,
				idfDateQuerySearchField = @idfDateQuerySearchField
		 where	@idfLayoutSearchFieldAggregation = idfLayoutSearchFieldAggregation
    end

    
GO

