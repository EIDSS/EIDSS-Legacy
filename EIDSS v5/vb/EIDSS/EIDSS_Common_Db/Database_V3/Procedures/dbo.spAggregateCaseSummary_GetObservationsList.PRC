SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateCaseSummary_GetObservationsList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateCaseSummary_GetObservationsList]
GO


--##SUMMARY Selects the list of observations that complain conditions defined by @AggrXml parameter.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 012.01.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @AggrXml nvarchar(4000)
DECLARE @FormType bigint
SET @AggrXml = '<?xml version="1.0" encoding="UTF-16"?><ROOT><AdminLevel AreaType="Settlement"><AdminUnit AdminUnitID="259730000000" /></AdminLevel><TimeInterval PeriodType="Day"><TimeIntervalUnit StartDate="2010-01-12" FinishDate="2010-01-12" /></TimeInterval></ROOT>'

SET @FormType = 10034021
EXECUTE spAggregateCaseSummary_GetObservationsList 
	@AggrXml,
	@FormType

*/

CREATE proc dbo.spAggregateCaseSummary_GetObservationsList(
						@AggrXml nvarchar(4000),  --##PARAM @AggrXml - xml that lists all administrative units and statistic periods that should be included to summary
						@FormType bigint  --##PARAM @FormType - flexible form type type
											)
as
begin


declare @MinAdminLevel bigint
declare @MinTimeInterval bigint
declare @strMinAdminLevel nvarchar(100)
declare @strMinTimeInterval nvarchar(100)
declare @AggregateCaseType bigint
IF @FormType = 10034012 --HumanAggregateCase 
	SET @AggregateCaseType = 10102001 --Human Aggregate Case 
ELSE IF  @FormType = 10034021 --VETAggregateCase 
	SET @AggregateCaseType = 10102002 --Vet Aggregate Case 
ELSE IF @FormType = 10034022/*VetEpizooticAction*/ OR @FormType = 10034023/*VetEpizooticActionDiagnosisInv*/ OR @FormType = 10034024/*VetEpizooticActionTreatment*/
	SET @AggregateCaseType = 10102003 --Vet Aggregate Action 

SELECT @MinAdminLevel=idfsStatisticAreaType,@MinTimeInterval=idfsStatisticPeriodType  
FROM fnAggregateSettings(@AggregateCaseType)
SET @strMinTimeInterval  = CASE (@MinTimeInterval)
						WHEN 10091001 THEN 'Month'
						WHEN 10091002 THEN 'Day'
						WHEN 10091003 THEN 'Quarter'
						WHEN 10091004 THEN 'Week'
						WHEN 10091005 THEN 'Year'
						ELSE '' END

SET @strMinAdminLevel  = CASE (@MinAdminLevel)
						WHEN 10089001 THEN 'Country'
						WHEN 10089002 THEN 'Rayon'
						WHEN 10089003 THEN 'Region'
						WHEN 10089004 THEN 'Settlement'
						ELSE '' END

declare @AreaType nvarchar(100)
declare @PeriodType nvarchar(100)
declare @AdminUnit table (AdminUnitID bigint)
declare @TimeIntervalUnit table (StartDate datetime, FinishDate datetime)

declare @idoc int

exec sp_xml_preparedocument @idoc OUTPUT, @AggrXml

select	@AreaType = AreaType
from	OPENXML (@idoc, '/ROOT/AdminLevel', 1)
		WITH (AreaType  nvarchar(100))

select	@PeriodType = PeriodType
from	OPENXML (@idoc, '/ROOT/TimeInterval', 1)
		WITH (PeriodType  nvarchar(100))

insert into @AdminUnit(AdminUnitID)
select	AdminUnitID
from	OPENXML (@idoc, '/ROOT/AdminLevel/AdminUnit', 1)
		WITH (AdminUnitID  bigint)


insert into @TimeIntervalUnit(StartDate, FinishDate)
select	StartDate, FinishDate
from	OPENXML (@idoc, '/ROOT/TimeInterval/TimeIntervalUnit', 1)
		WITH (StartDate datetime, FinishDate datetime)

exec sp_xml_removedocument @idoc



SELECT	(CASE @FormType 
		WHEN 10034012 /*HumanAggregateCase*/ THEN idfCaseObservation
		WHEN 10034021 /*VETAggregateCase*/  THEN idfCaseObservation
		WHEN 10034022/*VetEpizooticAction*/  THEN idfSanitaryObservation
		WHEN 10034023/*VetEpizooticActionDiagnosisInv*/  THEN idfDiagnosticObservation
		WHEN 10034024/*VetEpizooticActionTreatment*/  THEN idfProphylacticObservation 
		ELSE idfCaseObservation END) 
		AS idfObservation

from			tlbAggrCase
inner join		@TimeIntervalUnit tiu
on				tiu.StartDate <= tlbAggrCase.datStartDate
				and tiu.FinishDate >= tlbAggrCase.datFinishDate
				and	(	(	@PeriodType = 'Year'
							and DateDiff(year, tlbAggrCase.datStartDate, tlbAggrCase.datFinishDate) = 0)
						or (@PeriodType = 'Quarter'
							and DateDiff(quarter, tlbAggrCase.datStartDate, tlbAggrCase.datFinishDate) = 0)
						or (@PeriodType = 'Month'
							and DateDiff(month, tlbAggrCase.datStartDate, tlbAggrCase.datFinishDate) = 0)
						or (@PeriodType = 'Week'
							and dbo.fnWeekDatediff(tlbAggrCase.datStartDate, tlbAggrCase.datFinishDate) = 0)
						or (@PeriodType = 'Day'
							and DateDiff(day, tlbAggrCase.datStartDate, tlbAggrCase.datFinishDate) = 0)
					)
left outer join gisCountry c
on				c.idfsCountry = idfsAdministrativeUnit 
				or exists(
					select	* 
					from	gisRegion rc 
					where	rc.idfsRegion = idfsAdministrativeUnit
							and rc.idfsCountry = c.idfsCountry)
				or exists(
					select	* 
					from	gisRayon rrc 
					where	rrc.idfsRayon = idfsAdministrativeUnit
							and rrc.idfsCountry = c.idfsCountry)
				or exists(
					select	* 
					from	gisSettlement sc 
					where	sc.idfsSettlement = idfsAdministrativeUnit
							and sc.idfsCountry = c.idfsCountry)
left outer join gisRegion r
on				r.idfsRegion = idfsAdministrativeUnit 
				or exists(
					select	* 
					from	gisRayon rrr 
					where	rrr.idfsRayon = idfsAdministrativeUnit
							and rrr.idfsRegion = r.idfsRegion)
				or exists(
					select	* 
					from	gisSettlement sr 
					where	sr.idfsSettlement = idfsAdministrativeUnit
							and sr.idfsRegion = r.idfsRegion)
left outer join gisRayon rr
on				rr.idfsRayon = idfsAdministrativeUnit
				or exists(
					select	* 
					from	gisSettlement srr 
					where	srr.idfsSettlement = idfsAdministrativeUnit
							and srr.idfsRayon = rr.idfsRayon)
left outer join gisSettlement s
on				s.idfsSettlement = idfsAdministrativeUnit
inner join		@AdminUnit au
on				(@AreaType = 'Country' and au.AdminUnitID = c.idfsCountry)
				or (@AreaType = 'Region' and au.AdminUnitID = r.idfsRegion)
				or (@AreaType = 'Rayon' and au.AdminUnitID = rr.idfsRayon)
				or (@AreaType = 'Settlement' and au.AdminUnitID = s.idfsSettlement)

where			idfsAggrCaseType = @AggregateCaseType
				and (	(	@strMinTimeInterval = 'Year'
							and DateDiff(year, datStartDate, datFinishDate) = 0
							and DateDiff(quarter, datStartDate, datFinishDate) > 1
							and DateDiff(month, datStartDate, datFinishDate) > 1
							and dbo.fnWeekDatediff(datStartDate, datFinishDate) > 1
							and DateDiff(day, datStartDate, datFinishDate) > 1
							)
						or (@strMinTimeInterval = 'Quarter'
							and DateDiff(quarter, datStartDate, datFinishDate) = 0
							and DateDiff(month, datStartDate, datFinishDate) > 1
							and dbo.fnWeekDatediff(datStartDate, datFinishDate) > 1
							and DateDiff(day, datStartDate, datFinishDate) > 1
							)
						or (@strMinTimeInterval = 'Month'
							and DateDiff(month, datStartDate, datFinishDate) = 0
							and dbo.fnWeekDatediff(datStartDate, datFinishDate) > 1
							and DateDiff(day, datStartDate, datFinishDate) > 1
							)
						or (@strMinTimeInterval = 'Week'
							and dbo.fnWeekDatediff(datStartDate, datFinishDate) = 0
							and DateDiff(day, datStartDate, datFinishDate) > 1
							)
						or (@strMinTimeInterval = 'Day'
							and DateDiff(day, datStartDate, datFinishDate) = 0)
					)
				and (tlbAggrCase.intRowStatus = 0)
				and ((@strMinAdminLevel = 'Country' 
					and idfsAdministrativeUnit = c.idfsCountry)
				or (@strMinAdminLevel = 'Region' 
					and idfsAdministrativeUnit = r.idfsRegion)
				or (@strMinAdminLevel = 'Rayon' 
					and idfsAdministrativeUnit = rr.idfsRayon)
				or (@strMinAdminLevel = 'Settlement' 
					and idfsAdministrativeUnit = s.idfsSettlement))


end
  


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
