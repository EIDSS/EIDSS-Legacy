SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fnAsGetSearchCondition]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[fnAsGetSearchCondition]
GO

--##SUMMARY Returns correct filter condition, including correct operator and, if necessary, additional quotes to the value
--##SUMMARY depending on the type of the field and a reference to the reference table.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 14.08.2010

--##RETURNS Function returns correct filter condition, including correct operator and, if necessary, additional quotes.


/*
--Example of a call of function:
declare @idfsFieldType			bigint
declare @idfsReferenceType		bigint
declare @idfsGISReferenceType	bigint
declare @strField				nvarchar(2050)
declare @strOperator			nvarchar(200)
declare @intOperatorType		int
declare @blnUseNot				bit
declare @varValue				sql_variant

select	dbo.fnAsGetSearchCondition
		(	@idfsFieldType,
			@idfsReferenceType,
			@idfsGISReferenceType,
			@varValue
		)

*/


create	function	fnAsGetSearchCondition
(
	@idfsFieldType			bigint,			--##PARAM @idfsFieldType Id of the search field type or parameter type
	@idfsReferenceType		bigint,			--##PARAM @idfsReferenceType Id of the reference type that should contain the specified value
	@idfsGISReferenceType	bigint,			--##PARAM @idfsGISReferenceType Id of the GIS reference type that should contain the specified value
	@strField				nvarchar(2100),	--##PARAM @strField Text of the search field included in filter condition
	@strOperator			nvarchar(200),	--##PARAM @strOperator The name of the operator type (Unary or Binary)
	@intOperatorType		int,			--##PARAM @intOperatorType The number from the Operator Type enum for specified operator
	@blnUseNot				bit,			--##PARAM @blnUseNot The parameter that determines whether to use NOT for specified operator
	@varValue				sql_variant		--##PARAM @varValue The value to be converted to a string
)
returns nvarchar(MAX)
as
begin

declare	@Condition	nvarchar(MAX)
set	@Condition = N''

declare @Operator	varchar(20)
set @Operator = ''

declare @strValue	nvarchar(MAX)
set @strValue = N''

declare @Not		bit
set	@Not = IsNull(@blnUseNot, 0)

if (@strOperator = 'Binary')
begin
	if	((@intOperatorType = 0) and (@Not = 0))
		or ((@intOperatorType = 1) and (@Not = 1))
		set	@Operator = '='
	else if	((@intOperatorType = 1) and (@Not = 0))
			or ((@intOperatorType = 0) and (@Not = 1))
		set @Operator = '<>'
	else if	((@intOperatorType = 2) and (@Not = 0))
			or ((@intOperatorType = 4) and (@Not = 1))
		set @Operator = '>'
	else if	((@intOperatorType = 3) and (@Not = 0))
			or ((@intOperatorType = 5) and (@Not = 1))
		set @Operator = '<'
	else if	((@intOperatorType = 4) and (@Not = 0))
			or ((@intOperatorType = 2) and (@Not = 1))
		set @Operator = '<='
	else if	((@intOperatorType = 5) and (@Not = 0))
			or ((@intOperatorType = 3) and (@Not = 1))
		set @Operator = '>='
	else if	(@intOperatorType = 6) and (@Not = 0)
	begin
		if	@idfsFieldType not in	-- FF Field
				(	-- Search field type
					10081001,	-- Bit
					10081004,	-- Float
					10081006,	-- Integer
					10081002,	-- Date
					10081004,	-- Float
					10081005,	-- ID
					10081007	-- String
				)
			set @strField = N'cast(' + @strField + N' as nvarchar)'
		set @Operator = 'like'
	end
	else if	(@intOperatorType = 6) and (@Not = 1)
	begin
		if	@idfsFieldType not in	-- FF Field
				(	-- Search field type
					10081001,	-- Bit
					10081004,	-- Float
					10081006,	-- Integer
					10081002,	-- Date
					10081004,	-- Float
					10081005,	-- ID
					10081007	-- String
				)
			set @strField = N'cast(' + @strField + N' as nvarchar)'
		set @Operator = 'not like'
	end

	if	@varValue is not null
	begin
		if	@idfsReferenceType is not null 
			or @idfsGISReferenceType is not null
			or @idfsFieldType in
				(	-- Search field type
					10081001,	-- Bit
					10081004,	-- Float
					10081006,	-- Integer
					-- FF parameter type
					10071007,	-- Numeric
					10071025,	-- Boolean
					10071059,	-- Numeric Natural
					10071060,	-- Numeric Positive
					10071061	-- Numeric Integer
				)
				set	@strValue = cast(@varValue as nvarchar(MAX))
		else	set	@strValue = 'N''' + replace(cast(@varValue as nvarchar(MAX)), '''', '''''') + ''''
	end

	set	@Condition = IsNull(N'(' + @strField + N' ' + @Operator + N' ' + @strValue + N')', N'')
end
else if (@strOperator = 'Unary')
begin
	if (@intOperatorType = 4) and (@Not = 0)
		set	@Operator = 'is null'
	else if	(@intOperatorType = 4) and (@Not = 1)
		set @Operator = 'is not null'

	set	@Condition = IsNull(N'(' + @strField + N' ' + @Operator + N')', N'')
end
else if (@strOperator = 'OutlookInterval') 
		and (@idfsFieldType in	(10081002, 10071029, 10071030))	-- Field Date, Parameter Dste, Parameter DateTime
begin
--	set	@strField = N'cast(' + @strField + N' as date)'	
/*	if (@intOperatorType = 59) and (@Not = 0)	-- Is Interval Beyond This Year
		set	@Condition = IsNull(N'(year(' + @strField + N') <> year(getdate()))', N'')
	else if	(@intOperatorType = 59) and (@Not = 1) -- Is Interval Within This Year
		set	@Condition = IsNull(N'(year(' + @strField + N') = year(getdate()))', N'')
	
	else if (@intOperatorType = 60) and (@Not = 0)	-- Is Interval Later This Year
		set	@Condition = IsNull(N'(year(' + @strField + N') > year(getdate()))', N'')
	else if	(@intOperatorType = 60) and (@Not = 1) -- Is Interval Earlier Or Equal To This Year
		set	@Condition = IsNull(N'(year(' + @strField + N') <= year(getdate()))', N'')
	
	else if (@intOperatorType = 61) and (@Not = 0)	-- Is Interval Later This Month
		set	@Condition = IsNull(N'((month(' + @strField + N') > month(getdate()) ' +
									N'and year(' + @strField + N') = year(getdate())) ' +
								N'or (year(' + @strField + N') > year(getdate())))', N'')
	else if	(@intOperatorType = 61) and (@Not = 1) -- Is Interval Earlier Or Equal To This Month
		set	@Condition = IsNull(N'((month(' + @strField + N') <= month(getdate()) ' +
									N'and year(' + @strField + N') = year(getdate())) ' +
								N'or (year(' + @strField + N') < year(getdate())))', N'')

	else if (@intOperatorType = 62) and (@Not = 0)	-- Is Interval Next Week
		set	@Condition = IsNull(N'(' + @strField + N' > getdate() and datediff(ww, getdate(), ' + @strField + N') = 1)', N'')
	else if	(@intOperatorType = 62) and (@Not = 1) -- Is Interval Not Next Week
		set	@Condition = IsNull(N'((' + @strField + N' > getdate() and datediff(ww, getdate(), ' + @strField + N') <> 1)) ' + 
									N'or (' + @strField + N' <= getdate())', N'')

	else if (@intOperatorType = 63) and (@Not = 0)	-- Is Interval Later This Week
		set	@Condition = IsNull(N'((datepart(ww, ' + @strField + N') > datepart(ww, getdate()) ' +
									N'and year(' + @strField + N') = year(getdate())) ' +
								N'or (year(' + @strField + N') > year(getdate())))', N'')
	else if	(@intOperatorType = 63) and (@Not = 1) -- Is Interval Earlier Or Equal To This Week
		set	@Condition = IsNull(N'((datepart(ww, ' + @strField + N') <= datepart(ww, getdate()) ' +
									N'and year(' + @strField + N') = year(getdate())) ' +
								N'or (year(' + @strField + N') < year(getdate())))', N'')

	else if (@intOperatorType = 64) and (@Not = 0)	-- Is Interval Tomorrow
		set	@Condition = IsNull(N'(' + @strField + N' > getdate() and datediff(dd, getdate(), ' + @strField + N') = 1)', N'')
--		set	@Condition = IsNull(N'(' + @strField + N' = dateadd(dd, 1, getdate())', N'')
	else if	(@intOperatorType = 64) and (@Not = 1) -- Is Interval Not Tomorrow
		set	@Condition = IsNull(N'((' + @strField + N' > getdate() and datediff(dd, getdate(), ' + @strField + N') <> 1)) ' + 
									N'or (' + @strField + N' <= getdate())', N'')
--		set	@Condition = IsNull(N'(' + @strField + N' <> dateadd(dd, 1, getdate())', N'')

	else */if (@intOperatorType = 65) and (@Not = 0)	-- Is Interval Today
		--	IsOutlookIntervalToday, // Today <= x < Tomorrow
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (datediff(dd, ' + @strField + N', getdate()) = 0))', N'')

	else if	(@intOperatorType = 65) and (@Not = 1) -- Is Interval Not Today
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (datediff(dd, ' + @strField + N', getdate()) <> 0))', N'')

	else if (@intOperatorType = 66) and (@Not = 0)	-- Is Interval Yesterday
		--	IsOutlookIntervalYesterday, // Yesterday <= x < Today
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (' + @strField + N' < getdate()) and (datediff(dd, ' + @strField + N', getdate()) = 1))', N'')

	else if	(@intOperatorType = 66) and (@Not = 1) -- Is Interval Not Yesterday
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (((' + @strField + N' < getdate()) and (datediff(dd, ' + @strField + N', getdate()) <> 1)) ' + 
									N'or (' + @strField + N' >= getdate()))', N'')

	else if (@intOperatorType = 67) and (@Not = 0)	-- Is Interval Earlier This Week
		--	IsOutlookIntervalEarlierThisWeek, // ThisWeek <= x < Yesterday
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (' + @strField + N' < getdate()) and (datediff(dd, ' + @strField + N', getdate()) > 1) ' +
									N'and (datediff(ww, ' + @strField + N', getdate()) = 0))', N'')

	else if	(@intOperatorType = 67) and (@Not = 1) -- Is Interval Later Or Equal To This Week
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (((' + @strField + N' < getdate()) ' + 
									N'and ((datediff(dd, ' + @strField + N', getdate()) <= 1) ' + 
									N'or (datediff(ww, ' + @strField + N', getdate()) <> 0))) ' + 
									N'or (' + @strField + N' >= getdate())))', N'')

	else if (@intOperatorType = 68) and (@Not = 0)	-- Is Interval Last Week
		--	IsOutlookIntervalLastWeek, // LastWeek <= x < ThisWeek
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (' + @strField + N' < getdate()) and (datediff(ww, ' + @strField + N', getdate()) = 1))', N'')

	else if	(@intOperatorType = 68) and (@Not = 1) -- Is Interval Not Last Week
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (((' + @strField + N' < getdate()) and (datediff(ww, ' + @strField + N', getdate()) <> 1)) ' + 
									N'or (' + @strField + N' >= getdate()))', N'')

	else if (@intOperatorType = 69) and (@Not = 0)	-- Is Interval Earlier This Month
	--	IsOutlookIntervalEarlierThisMonth, // ThisMonth <= x < LastWeek
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (' + @strField + N' < getdate()) and (datediff(ww, ' + @strField + N', getdate()) > 1) ' +
									N'and (datediff(mm, ' + @strField + N', getdate()) = 0))', N'')

	else if	(@intOperatorType = 69) and (@Not = 1) -- Is Interval Later Or Equal To This Month
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (((' + @strField + N' < getdate()) ' + 
									N'and ((datediff(ww, ' + @strField + N', getdate()) <= 1) ' + 
									N'or (datediff(mm, ' + @strField + N', getdate()) <> 0))) ' + 
									N'or (' + @strField + N' >= getdate())))', N'')

	else if (@intOperatorType = 70) and (@Not = 0)	-- Is Interval Earlier This Year
		--	IsOutlookIntervalEarlierThisYear, // ThisYear <= x < ThisMonth
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (' + @strField + N' < getdate()) and (datediff(mm, ' + @strField + N', getdate()) >= 1) ' +
									N'and (datediff(yyyy, ' + @strField + N', getdate()) = 0))', N'')

	else if	(@intOperatorType = 70) and (@Not = 1) -- Is Interval Later Or Equal To This Year
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (((' + @strField + N' < getdate()) ' + 
									N'and ((datediff(mm, ' + @strField + N', getdate()) < 1) ' + 
									N'or (datediff(yyyy, ' + @strField + N', getdate()) <> 0))) ' + 
									N'or (' + @strField + N' >= getdate())))', N'')

	else if (@intOperatorType = 71) and (@Not = 0)	-- Is Interval Prior This Year
		--	IsOutlookIntervalPriorThisYear, // x < ThisYear
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (datediff(yyyy, ' + @strField + N', getdate()) >= 1))', N'')

	else if	(@intOperatorType = 71) and (@Not = 1) -- Is Interval Not Prior This Year
		set	@Condition = IsNull(N'((' + @strField + N' is not null) and (datediff(yyyy, ' + @strField + N', getdate()) < 1))', N'')
	
end

return @Condition
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

