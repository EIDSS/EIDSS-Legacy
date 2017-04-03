SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateCase_GetStartupParameters]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateCase_GetStartupParameters]
GO



--##SUMMARY Returns row with startup parameters for aggregate case detail form.
--##SUMMARY This procedure is called from aggregate summary form that defines administrative unit and start/finish dates for aggregate case that should be shown.
--##SUMMARY All undefined columns in the returned row are filled with NULL.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 08.01.2010

--##RETURNS Doesn't use



/*
Example of procedure call:

DECLARE @idfsAdminUnit bigint
DECLARE @datStartDate  datetime
DECLARE @datFinishDate datetime
EXECUTE spAggregateCase_GetStartupParameters 
	@idfsAdminUnit,
	@datStartDate,
	@datFinishDate

*/




CREATE PROC	spAggregateCase_GetStartupParameters
		@idfsAdminUnit	bigint, --##PARAM @idfsAdminUnit - administrative unit ID. Can point to country, region, rayon or settlement
		@datStartDate  datetime, --##PARAM @datStartDate - aggregate case start date
		@datFinishDate datetime --##PARAM @datFinishDate - aggregate case finish date
as
DECLARE @idfsCountry bigint
DECLARE @idfsRegion bigint
DECLARE @idfsRayon bigint
DECLARE @idfsSettlement bigint


SELECT	@idfsCountry =idfsCountry 
FROM	gisCountry
WHERE		gisCountry.idfsCountry = @idfsAdminUnit 
			or exists(
				select	* 
				from	gisRegion
				where	gisRegion.idfsRegion = @idfsAdminUnit
						and gisRegion.idfsCountry = gisCountry.idfsCountry)
			or exists(
				select	* 
				from	gisRayon
				where	gisRayon.idfsRayon = @idfsAdminUnit
						and gisRayon.idfsCountry = gisCountry.idfsCountry)
			or exists(
				select	* 
				from	gisSettlement 
				where	gisSettlement.idfsSettlement = @idfsAdminUnit
						and gisSettlement.idfsCountry = gisCountry.idfsCountry)

SELECT	@idfsRegion =idfsRegion 
FROM	gisRegion
WHERE	gisRegion.idfsRegion = @idfsAdminUnit 
		or exists(
			select	* 
			from	gisRayon
			where	gisRayon.idfsRayon = @idfsAdminUnit
					and gisRayon.idfsRegion = gisRegion.idfsRegion)
		or exists(
			select	* 
			from	gisSettlement
			where	gisSettlement.idfsSettlement = @idfsAdminUnit
					and gisSettlement.idfsRegion = gisRegion.idfsRegion)

SELECT	@idfsRayon=idfsRayon 
FROM	gisRayon
WHERE	gisRayon.idfsRayon = @idfsAdminUnit
		or exists(
			select	* 
			from	gisSettlement
			where	gisSettlement.idfsSettlement = @idfsAdminUnit
					and gisSettlement.idfsRayon = gisRayon.idfsRayon)

SELECT	@idfsSettlement=idfsSettlement
FROM	gisSettlement
WHERE	gisSettlement.idfsSettlement = @idfsAdminUnit

SELECT	@idfsCountry as Country, 
		@idfsRegion as Region,
		@idfsRayon as Rayon,
		@idfsSettlement as Settlement,
		@idfsAdminUnit as AdminUnit,
		Year(@datStartDate) as [Year],
		case DateDiff(quarter, @datStartDate, @datFinishDate)
			when 0 then DatePart(quarter, @datStartDate)
			when 1 then DatePart(quarter, @datStartDate)
			else null
		end as [Quarter],
		case DateDiff(month, @datStartDate, @datFinishDate)
			when 0 then DatePart(month, @datStartDate)
			when 1 then DatePart(month, @datStartDate)
			else null
		end as [Month],
		case dbo.fnWeekDatediff(@datStartDate, @datFinishDate)
			when 0 then dbo.fnWeekDatepart(@datStartDate)
			when 1 then dbo.fnWeekDatepart(@datStartDate)
			else null
		end as [Week],
		case DateDiff(day, @datStartDate, @datFinishDate)
			when 0 then @datStartDate
			when 1 then @datStartDate
			else null
		end as [Day],
		@datStartDate as StartDate,
		@datFinishDate as FinishDate
		
where	(@datStartDate is not null) and (@datFinishDate is not null) 
		and (@datFinishDate >= @datStartDate)

union
select	@idfsCountry as Country, 
		@idfsRegion as Region,
		@idfsRayon as Rayon,
		@idfsSettlement as Settlement,
		@idfsAdminUnit as AdminUnit,
		null as [Year],
		null as [Quarter],
		null as [Month],
		null as [Week],
		null as [Day],
		@datStartDate as StartDate,
		@datFinishDate as FinishDate
where	(@datStartDate is null) or (@datFinishDate is null) 
		or (@datFinishDate < @datStartDate)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

