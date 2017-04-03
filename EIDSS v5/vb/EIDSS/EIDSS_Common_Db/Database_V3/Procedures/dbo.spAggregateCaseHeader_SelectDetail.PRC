SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateCaseHeader_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateCaseHeader_SelectDetail]
GO



--##SUMMARY Selects data for header of all aggregate forms.
--##SUMMARY These data are common for all aggreage cases.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 01.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @idfAggrCase bigint
DECLARE @idfsAggrCaseType bigint
SET @idfsAggrCaseType = 10102002 --Vet aggregate case
EXECUTE spAggregateCaseHeader_SelectDetail 
	@idfAggrCase
	,@idfsAggrCaseType

*/




CREATE PROC	spAggregateCaseHeader_SelectDetail
		@idfAggrCase	bigint --##PARAM @idfAggrCase - aggregate case ID
		,@idfsAggrCaseType bigint --##PARAM @idfsAggrCaseType - aggregate case type
as

IF @idfsAggrCaseType IS NULL
	EXECUTE spThrowException 'Aggregate case type is not defined'

SELECT idfAggrCase
      ,idfsAggrCaseType
      ,idfsAdministrativeUnit
      ,idfReceivedByOffice
      ,idfReceivedByPerson
      ,idfSentByOffice
      ,idfSentByPerson
      ,idfEnteredByOffice
      ,idfEnteredByPerson
      ,idfCaseObservation
      ,CaseObservation.idfsFormTemplate as idfsCaseObservationFormTemplate
      ,idfDiagnosticObservation
      ,DiagnosticObservation.idfsFormTemplate as idfsDiagnosticObservationFormTemplate
      ,idfProphylacticObservation
      ,ProphylacticObservation.idfsFormTemplate as idfsProphylacticObservationFormTemplate
      ,idfSanitaryObservation
      ,SanitaryObservation.idfsFormTemplate as idfsSanitaryObservationFormTemplate
	  ,idfVersion
	  ,idfDiagnosticVersion
	  ,idfProphylacticVersion
	  ,idfSanitaryVersion
      ,datReceivedByDate
      ,datSentByDate
      ,datEnteredByDate
      ,datStartDate
      ,datFinishDate
      ,strCaseID
		,Year(datStartDate) as YearForAggr
		,QuarterForAggr =
			case DateDiff(quarter, datStartDate, datFinishDate)
				when 0 then DatePart(quarter, datStartDate)
				when 1 then DatePart(quarter, datStartDate)
				else null
			end
		,MonthForAggr =
			case DateDiff(month, datStartDate, datFinishDate)
				when 0 then DatePart(month, datStartDate)
				when 1 then DatePart(month, datStartDate)
				else null
			end
		,WeekForAggr =
			case dbo.fnWeekDatediff(datStartDate, datFinishDate)
				when 0 then dbo.fnWeekDatepart(datStartDate)
				when 1 then dbo.fnWeekDatepart(datStartDate)
				else null
			end
		,DayForAggr =
			case DateDiff(day, datStartDate, datFinishDate)
				when 0 then datStartDate
				when 1 then datStartDate
				else null
			end
		,gisCountry.idfsCountry 
		,gisRegion.idfsRegion
		,gisRayon.idfsRayon
		,gisSettlement.idfsSettlement
		,CAST (NULL as bigint) as CurPeriodType
		,CAST (NULL as bigint) as CurAreaType
  FROM tlbAggrCase
		left outer join tlbObservation CaseObservation
		on		CaseObservation.idfObservation = tlbAggrCase.idfCaseObservation
				and CaseObservation.intRowStatus=0
		left outer join tlbObservation DiagnosticObservation
		on		DiagnosticObservation.idfObservation = tlbAggrCase.idfDiagnosticObservation
				and DiagnosticObservation.intRowStatus=0
		left outer join tlbObservation ProphylacticObservation
		on		ProphylacticObservation.idfObservation = tlbAggrCase.idfProphylacticObservation
				and ProphylacticObservation.intRowStatus=0
		left outer join tlbObservation SanitaryObservation
		on		SanitaryObservation.idfObservation = tlbAggrCase.idfSanitaryObservation
				and SanitaryObservation.intRowStatus=0
		left outer join gisCountry
		on		gisCountry.idfsCountry = idfsAdministrativeUnit 
				or exists(
					select	* 
					from	gisRegion
					where	gisRegion.idfsRegion = idfsAdministrativeUnit
							and gisRegion.idfsCountry = gisCountry.idfsCountry)
				or exists(
					select	* 
					from	gisRayon
					where	gisRayon.idfsRayon = idfsAdministrativeUnit
							and gisRayon.idfsCountry = gisCountry.idfsCountry)
				or exists(
					select	* 
					from	gisSettlement 
					where	gisSettlement.idfsSettlement = idfsAdministrativeUnit
							and gisSettlement.idfsCountry = gisCountry.idfsCountry)
		left outer join gisRegion
		on		gisRegion.idfsRegion = idfsAdministrativeUnit 
				or exists(
					select	* 
					from	gisRayon
					where	gisRayon.idfsRayon = idfsAdministrativeUnit
							and gisRayon.idfsRegion = gisRegion.idfsRegion)
				or exists(
					select	* 
					from	gisSettlement
					where	gisSettlement.idfsSettlement = idfsAdministrativeUnit
							and gisSettlement.idfsRegion = gisRegion.idfsRegion)
		left outer join gisRayon
		on		gisRayon.idfsRayon = idfsAdministrativeUnit
				or exists(
					select	* 
					from	gisSettlement
					where	gisSettlement.idfsSettlement = idfsAdministrativeUnit
							and gisSettlement.idfsRayon = gisRayon.idfsRayon)
		left outer join gisSettlement
		on		gisSettlement.idfsSettlement = idfsAdministrativeUnit
WHERE 
	idfAggrCase = @idfAggrCase

SELECT @idfsAggrCaseType = ISNULL(idfsAggrCaseType,@idfsAggrCaseType)
FROM
	tlbAggrCase
WHERE 
	idfAggrCase = @idfAggrCase

EXEC spAggregateSettings_SelectDetail @idfsAggrCaseType

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

