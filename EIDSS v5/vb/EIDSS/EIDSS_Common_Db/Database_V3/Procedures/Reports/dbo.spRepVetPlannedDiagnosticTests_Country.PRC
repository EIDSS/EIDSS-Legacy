 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetPlannedDiagnosticTests_Country]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetPlannedDiagnosticTests_Country]

 
GO

--##SUMMARY Select data for Country Report "Planned diagnostic  tests" V3.
--##REMARKS Author: Grigoreva Elena
--##REMARKS Create date: 20.01.2011 

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec spRepVetPlannedDiagnosticTests_Country 
'en', 
'2011-01-01', 
'2011-02-01',  
N'<ItemList><Item key="2955920000000" value="Brucellosis"/></ItemList>', 
N'<ItemList><Item key="952120000000" value="Serology"/><Item key="952150000000" value="Virusology"/></ItemList>', 
N'<ItemList><Item key="837780000000" value="Birds"/><Item key="837810000000" value="Camelidae"/></ItemList>',
41180000000
  
*/

CREATE  PROCEDURE [dbo].[spRepVetPlannedDiagnosticTests_Country]
	(
		@LangID				AS NVARCHAR(10), 
		@StartDate			AS DATETIME,	 
		@FinishDate			AS DATETIME,
		@Diagnosis			AS XML,
        @InvestigationType	AS XML,
        @Species			AS XML,
		@Region				AS BIGINT = NULL
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/KZ/Reports/Specification_for_reports_development_Country_Diagnostic-investigation-KZ-V3.docx"
-- by number marked red at screen form prototype 

DECLARE	@ReportTable	TABLE
(	idfsBaseReference		BIGINT NOT NULL,
	strRegionName			NVARCHAR(200) COLLATE database_default NULL, --1
    strRayonName			NVARCHAR(200) COLLATE database_default NULL, --1
	strDiagnosisName		NVARCHAR(300) COLLATE database_default NULL, --2
	strInvestigationType	NVARCHAR(200) COLLATE database_default NULL, --3
	strSpecies				NVARCHAR(200) COLLATE database_default NULL, --4

    intTestedTotalWeek		INT NULL, --7
    intPosReactTotalWeek	INT NULL, --8
    intPlannedToTest		INT NULL, --9
    intTestedTotalYear		INT NULL, --10
    intNumOfExecPer			INT NULL, --11
    intPosReactTotalYear	INT NULL, --12
    intInfectedPer			INT NULL, --13
    
	intOrder				INT NOT NULL
)

---------------
DECLARE @iSpecies	INT
DECLARE @SpeciesTable	TABLE
(
	 [key]	NVARCHAR(300)
	,[value]	NVARCHAR(300)
)

EXEC sp_xml_preparedocument @iSpecies OUTPUT, @Species

INSERT INTO @SpeciesTable (
	[key],
	[value]
	
) 
SELECT * 
FROM OPENXML (@iSpecies, '/ItemList/Item')
WITH ([key] BIGINT '@key',
      [value] NVARCHAR(300) '@value'
        )

EXEC sp_xml_removedocument @iSpecies
--------------------

DECLARE @iMeasures	INT
DECLARE @MeasuresTable	TABLE
(
	 [key]	NVARCHAR(300)
	,[value]	NVARCHAR(300)
)

EXEC sp_xml_preparedocument @iMeasures OUTPUT, @InvestigationType

INSERT INTO @MeasuresTable (
	[key],
	[value]
	
) 
SELECT * 
FROM OPENXML (@iMeasures, '/ItemList/Item')
WITH ([key] BIGINT '@key',
      [value] NVARCHAR(300) '@value'
        )

EXEC sp_xml_removedocument @iMeasures
--------------------

DECLARE @iDiagnosis	INT
DECLARE @DiagnosisTable	TABLE
(
	 [key]	NVARCHAR(300)
	,[value]	NVARCHAR(300)
)

EXEC sp_xml_preparedocument @iDiagnosis OUTPUT, @Diagnosis

INSERT INTO @DiagnosisTable (
	[key],
	[value]
	
) 
SELECT * 
FROM OPENXML (@iDiagnosis, '/ItemList/Item')
WITH ([key] BIGINT '@key',
      [value] NVARCHAR(300) '@value'
        )

EXEC sp_xml_removedocument @iDiagnosis
-----------------



DECLARE @MinAdminLevel BIGINT
DECLARE @MinTimeInterval BIGINT
DECLARE @AggrCaseType BIGINT


/*

19000091	rftStatisticPeriodType:
    10091001	sptMonth	Month
    10091002	sptOnday	Day
    10091003	sptQuarter	Quarter
    10091004	sptWeek	Week
    10091005	sptYear	Year

19000089	rftStatisticAreaType
    10089001	satCountry	Country
    10089002	satRayon	Rayon
    10089003	satRegion	Region
    10089004	satSettlement	Settlement


19000102	rftAggregateCaseType:
    10102003  Vet Aggregate Action

*/

IF @FinishDate is not null SET @FinishDate = dateadd(day, 1, @FinishDate)
SET @AggrCaseType = 10102003 /*Vet Aggregate Action*/

SELECT	@MinAdminLevel = idfsStatisticAreaType,
		@MinTimeInterval = idfsStatisticPeriodType
FROM fnAggregateSettings (@AggrCaseType)--@AggrCaseType
WHERE idfsCountry = 1240000000


-- выборка за отчетный период
declare	@VetInvestigationTypeMatrix	table
(	idfAggrCase	BIGINT not null primary KEY,
  datStartDate DATETIME,
  idfDiagnosticVersion BIGINT,
  idfDiagnosticObservation BIGINT,
  idfsRegion BIGINT
)


insert into	@VetInvestigationTypeMatrix  
(	idfAggrCase,
  datStartDate,
  idfDiagnosticVersion,
  idfDiagnosticObservation,
  idfsRegion
)
select		a.idfAggrCase,
          a.datStartDate,
          a.idfDiagnosticVersion,
          a.idfDiagnosticObservation,
          ISNULL(IsNull(r.idfsRegion, rr.idfsRegion), s.idfsRegion)
from		tlbAggrCase a
    left join	gisCountry c
    on			c.idfsCountry = a.idfsAdministrativeUnit
			    and c.idfsCountry = 1240000000
    left join	gisRegion r
    on			r.idfsRegion = a.idfsAdministrativeUnit 
			    and r.idfsCountry = 1240000000
    left join	gisRayon rr
    on			rr.idfsRayon = a.idfsAdministrativeUnit
			    and rr.idfsCountry = 1240000000
    left join	gisSettlement s
    on			s.idfsSettlement = a.idfsAdministrativeUnit
			    and s.idfsCountry = 1240000000

WHERE 			
			a.idfsAggrCaseType = @AggrCaseType
			and (	@StartDate <= a.datStartDate
					and a.datFinishDate < @FinishDate
				)
			and (	(	@MinTimeInterval = 10091005 --'sptYear'
						and DateDiff(year, a.datStartDate, a.datFinishDate) = 0
						and DateDiff(quarter, a.datStartDate, a.datFinishDate) > 1
						and DateDiff(month, a.datStartDate, a.datFinishDate) > 1
						and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) > 1
						and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
					)
					or	(	@MinTimeInterval = 10091003 --'sptQuarter'
							and DateDiff(quarter, a.datStartDate, a.datFinishDate) = 0
							and DateDiff(month, a.datStartDate, a.datFinishDate) > 1
							and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) > 1
							and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
						)
					or (	@MinTimeInterval = 10091001 --'sptMonth'
							and DateDiff(month, a.datStartDate, a.datFinishDate) = 0
							and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) > 1
							and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
						)
					or (	@MinTimeInterval = 10091004 --'sptWeek'
							and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) = 0
							and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
						)
					or (	@MinTimeInterval = 10091002--'sptOnday'
						and DateDiff(day, a.datStartDate, a.datFinishDate) = 0)
				)    and		
        (	(	@MinAdminLevel = 10089001 --'satCountry' 
			    and a.idfsAdministrativeUnit = c.idfsCountry
		      )
		    or	(	@MinAdminLevel = 10089003 --'satRegion' 
				    and a.idfsAdministrativeUnit = r.idfsRegion
			    )
		    or	(	@MinAdminLevel = 10089002 --'satRayon' 
				    and a.idfsAdministrativeUnit = rr.idfsRayon
			    )
		    or	(	@MinAdminLevel = 10089004 --'satSettlement' 
				    and a.idfsAdministrativeUnit = s.idfsSettlement
			    )
	      )

DECLARE	@VetInvestigationTypeMatrixValuesTable	TABLE
(	idfsRegion	BIGINT,
	idfsDiagnosis	BIGINT,
	idfsSpeciesType	BIGINT,
	idfsDiagnosticAction	BIGINT,
	intTestedTotalWeek INT, --7
	intPosReactTotalWeek INT --8
 )


insert into	@VetInvestigationTypeMatrixValuesTable
(	idfsRegion,
	idfsDiagnosis,
	idfsSpeciesType,
	idfsDiagnosticAction,
	intTestedTotalWeek,
	intPosReactTotalWeek
)
select		
		fhac.idfsRegion,
		apa.idfsDiagnosis,
		apa.idfsSpeciesType,
		apa.idfsDiagnosticAction,
		sum(IsNull(CAST(agp_TTW.varValue AS INT), 0)), 
		sum(IsNull(CAST(agp_PRT.varValue AS INT), 0)) 


from		@VetInvestigationTypeMatrix fhac

inner join tlbAggrDiagnosticActionMTX apa
    INNER JOIN @SpeciesTable st
    ON st.[KEY] = apa.idfsSpeciesType
    INNER JOIN @DiagnosisTable dt
    ON dt.[KEY] = apa.idfsDiagnosis
    INNER JOIN @MeasuresTable mt
    ON mt.[KEY] = apa.idfsDiagnosticAction
on   apa.intRowStatus = 0 


inner join (
 tlbAggrMatrixVersionHeader h
 inner join tlbAggrMatrixVersion vD
 on   vD.idfVersion = h.idfVersion
 and vD.idfsParameter = 226930000000 -- Vet Epizootic Action Diagnosis Inv: Diagnosis   
    and vD.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS
 on   vS.idfVersion = h.idfVersion
 and vS.idfsParameter = 239030000000 -- Vet Epizootic Action Diagnosis Inv: Species   
 and vS.idfRow = vD.idfRow
    and vS.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP
 on   vP.idfVersion = h.idfVersion
 and vP.idfsParameter = 231670000000 -- Vet Epizootic Action Diagnosis Inv: Investigation type   
 and vP.idfRow = vD.idfRow
    and vP.intRowStatus = 0
   )
on   h.blnIsActive = 1
   and h.idfsAggrCaseSection = 71460000000 -- Diagnostic Action
   and apa.idfAggrDiagnosticActionMTX = vD.idfRow
   and apa.idfsDiagnosis = cast(vD.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS.varValue as bigint)
   and apa.idfsDiagnosticAction = cast(vP.varValue as bigint)
   and (h.idfVersion = fhac.idfDiagnosticVersion or fhac.idfDiagnosticVersion is null)
   and (h.datStartDate <= fhac.datStartDate)
   and h.intRowStatus = 0
left join (
 tlbAggrMatrixVersionHeader h_later
 inner join tlbAggrMatrixVersion vD_later
 on   vD_later.idfVersion = h_later.idfVersion
 and vD_later.idfsParameter = 226930000000 -- Vet Epizootic Action Diagnosis Inv: Diagnosis   
    and vD_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS_later
 on   vS_later.idfVersion = h_later.idfVersion
 and vS_later.idfsParameter = 239030000000 -- Vet Epizootic Action Diagnosis Inv: Species   
 and vS_later.idfRow = vD_later.idfRow
    and vS_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP_later
 on   vP_later.idfVersion = h_later.idfVersion
 and vP_later.idfsParameter = 231670000000 -- Vet Epizootic Action Diagnosis Inv: Investigation type   
 and vP_later.idfRow = vD_later.idfRow
    and vP_later.intRowStatus = 0
   )
on   h_later.blnIsActive = 1
   and h_later.idfsAggrCaseSection = 71460000000 -- Diagnostic Action
   and apa.idfAggrDiagnosticActionMTX = vD_later.idfRow
   and apa.idfsDiagnosis = cast(vD_later.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS_later.varValue as bigint)
   and apa.idfsDiagnosticAction = cast(vP_later.varValue as bigint)
   and fhac.idfDiagnosticVersion is null
   and h_later.datStartDate <= fhac.datStartDate
   and h_later.intRowStatus = 0
   and ( h_later.datStartDate > h.datStartDate
     or ( h_later.datStartDate = h.datStartDate
       and h_later.idfVersion > h.idfVersion
      )
    )

--/* 7 column "Number of tested animals" */

left join	(
	dbo.tlbActivityParameters agp_TTW
	inner join	dbo.ffParameter p_TTW
	on			p_TTW.idfsParameter = agp_TTW.idfsParameter
				and p_TTW.intRowStatus = 0 
				and p_TTW.idfsParameter = 1093240000000	-- Number of tested animals
	inner join	trtBaseReference br_p_TTW
	on			br_p_TTW.idfsBaseReference = p_TTW.idfsParameter
				and br_p_TTW.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_TTW.intRowStatus = 0
			)
on			agp_TTW.idfObservation = fhac.idfDiagnosticObservation
			and agp_TTW.idfRow = vD.idfRow -- agpD.idfRow
			and agp_TTW.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_TTW.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--/* 8 column "Number of animals with positive reaction" */

left join	(
	dbo.tlbActivityParameters agp_PRT
	inner join	dbo.ffParameter p_PRT
	on			p_PRT.idfsParameter = agp_PRT.idfsParameter
				and p_PRT.intRowStatus = 0 
				and p_PRT.idfsParameter = 1092400000000	-- Number of animals with positive reaction
	inner join	trtBaseReference br_p_PRT
	on			br_p_PRT.idfsBaseReference = p_PRT.idfsParameter
				and br_p_PRT.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_PRT.intRowStatus = 0
			)
on			agp_PRT.idfObservation = fhac.idfDiagnosticObservation
			and agp_PRT.idfRow = vD.idfRow -- agpD.idfRow
			and agp_PRT.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_PRT.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

WHERE h_later.idfVersion IS NULL
GROUP BY    
    fhac.idfsRegion, 
    idfsDiagnosis,
    idfsSpeciesType,
    idfsDiagnosticAction


-- выборка кейсов с начала года	до конца отчетного периода
SET @StartDate = CAST(CAST(YEAR(@StartDate)	 AS VARCHAR(4)) + '0101' AS DATETIME)


declare	@VetInvestigationTypeMatrix_Year	table
(	idfAggrCase	BIGINT not null primary KEY,
  datStartDate DATETIME,
  idfDiagnosticVersion BIGINT,
  idfDiagnosticObservation BIGINT,
  idfsRegion BIGINT,
  idfsRayon BIGINT
)


insert into	@VetInvestigationTypeMatrix_Year  
(	idfAggrCase,
	datStartDate,
	idfDiagnosticVersion,
	idfDiagnosticObservation,
	idfsRegion,
	idfsRayon
)
select		a.idfAggrCase,
          a.datStartDate,
          a.idfDiagnosticVersion,
          a.idfDiagnosticObservation,
          @Region,
          ISNULL(rr.idfsRayon, s.idfsRayon)
from		tlbAggrCase a
    left join	gisCountry c
    on			c.idfsCountry = a.idfsAdministrativeUnit
			    and c.idfsCountry = 1240000000
    left join	gisRegion r
    on			r.idfsRegion = a.idfsAdministrativeUnit 
			    and r.idfsCountry = 1240000000
    left join	gisRayon rr
    on			rr.idfsRayon = a.idfsAdministrativeUnit
			    and rr.idfsCountry = 1240000000
    left join	gisSettlement s
    on			s.idfsSettlement = a.idfsAdministrativeUnit
			    and s.idfsCountry = 1240000000

WHERE 			
			a.idfsAggrCaseType = @AggrCaseType
			and (	@StartDate <= a.datStartDate
					and a.datFinishDate < @FinishDate
				)
			and (	(	@MinTimeInterval = 10091005 --'sptYear'
						and DateDiff(year, a.datStartDate, a.datFinishDate) = 0
						and DateDiff(quarter, a.datStartDate, a.datFinishDate) > 1
						and DateDiff(month, a.datStartDate, a.datFinishDate) > 1
						and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) > 1
						and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
					)
					or	(	@MinTimeInterval = 10091003 --'sptQuarter'
							and DateDiff(quarter, a.datStartDate, a.datFinishDate) = 0
							and DateDiff(month, a.datStartDate, a.datFinishDate) > 1
							and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) > 1
							and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
						)
					or (	@MinTimeInterval = 10091001 --'sptMonth'
							and DateDiff(month, a.datStartDate, a.datFinishDate) = 0
							and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) > 1
							and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
						)
					or (	@MinTimeInterval = 10091004 --'sptWeek'
							and dbo.fnWeekDatediff(a.datStartDate, a.datFinishDate) = 0
							and DateDiff(day, a.datStartDate, a.datFinishDate) > 1
						)
					or (	@MinTimeInterval = 10091002--'sptOnday'
						and DateDiff(day, a.datStartDate, a.datFinishDate) = 0)
				)    and		
        (	(	@MinAdminLevel = 10089001 --'satCountry' 
			    and a.idfsAdministrativeUnit = c.idfsCountry
		      )
		    or	(	@MinAdminLevel = 10089003 --'satRegion' 
				    and a.idfsAdministrativeUnit = r.idfsRegion
				    -- фильтр по региону
				    AND (r.idfsRegion = @Region)
			    )
		    or	(	@MinAdminLevel = 10089002 --'satRayon' 
				    and a.idfsAdministrativeUnit = rr.idfsRayon
				    -- фильтр по региону 
				    AND (rr.idfsRegion = @Region)
			    )
		    or	(	@MinAdminLevel = 10089004 --'satSettlement' 
				    and a.idfsAdministrativeUnit = s.idfsSettlement
				    -- фильтр по региону
				    AND (s.idfsRegion = @Region)

			    )
	      )


DECLARE	@VetInvestigationTypeMatrixValuesTable_Year	TABLE
(	idfsRegion				BIGINT,
	idfsDiagnosis			BIGINT,
	idfsSpeciesType			BIGINT,
	idfsDiagnosticAction	BIGINT,
	intTestedTotalYear		INT,
	intPosReactTotalYear	INT
     
)



insert into	@VetInvestigationTypeMatrixValuesTable_Year
(	idfsRegion,
	idfsDiagnosis,
	idfsSpeciesType,
	idfsDiagnosticAction,
	intTestedTotalYear,
	intPosReactTotalYear
)
select		
		fhac.idfsRegion,
		apa.idfsDiagnosis,
		apa.idfsSpeciesType,
		apa.idfsDiagnosticAction,
		sum(IsNull(CAST(agp_TTW.varValue AS INT), 0)), 
		sum(IsNull(CAST(agp_PRT.varValue AS INT), 0)) 


from		@VetInvestigationTypeMatrix_Year fhac

inner join tlbAggrDiagnosticActionMTX apa
    INNER JOIN @SpeciesTable st
    ON st.[KEY] = apa.idfsSpeciesType
    INNER JOIN @DiagnosisTable dt
    ON dt.[KEY] = apa.idfsDiagnosis
    INNER JOIN @MeasuresTable mt
    ON mt.[KEY] = apa.idfsDiagnosticAction
on   apa.intRowStatus = 0

inner join (
 tlbAggrMatrixVersionHeader h
 inner join tlbAggrMatrixVersion vD
 on   vD.idfVersion = h.idfVersion
 and vD.idfsParameter = 226930000000 -- Vet Epizootic Action Diagnosis Inv: Diagnosis   
    and vD.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS
 on   vS.idfVersion = h.idfVersion
 and vS.idfsParameter = 239030000000 -- Vet Epizootic Action Diagnosis Inv: Species   
 and vS.idfRow = vD.idfRow
    and vS.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP
 on   vP.idfVersion = h.idfVersion
 and vP.idfsParameter = 231670000000 -- Vet Epizootic Action Diagnosis Inv: Investigation type   
 and vP.idfRow = vD.idfRow
    and vP.intRowStatus = 0
   )
on   h.blnIsActive = 1
   and h.idfsAggrCaseSection = 71460000000 -- Diagnostic Action
   and apa.idfAggrDiagnosticActionMTX = vD.idfRow
   and apa.idfsDiagnosis = cast(vD.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS.varValue as bigint)
   and apa.idfsDiagnosticAction = cast(vP.varValue as bigint)
   and (h.idfVersion = fhac.idfDiagnosticVersion or fhac.idfDiagnosticVersion is null)
   and (h.datStartDate <= fhac.datStartDate)
   and h.intRowStatus = 0
left join (
 tlbAggrMatrixVersionHeader h_later
 inner join tlbAggrMatrixVersion vD_later
 on   vD_later.idfVersion = h_later.idfVersion
 and vD_later.idfsParameter = 226930000000 -- Vet Epizootic Action Diagnosis Inv: Diagnosis   
    and vD_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS_later
 on   vS_later.idfVersion = h_later.idfVersion
 and vS_later.idfsParameter = 239030000000 -- Vet Epizootic Action Diagnosis Inv: Species   
 and vS_later.idfRow = vD_later.idfRow
    and vS_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP_later
 on   vP_later.idfVersion = h_later.idfVersion
 and vP_later.idfsParameter = 231670000000 -- Vet Epizootic Action Diagnosis Inv: Investigation type   
 and vP_later.idfRow = vD_later.idfRow
    and vP_later.intRowStatus = 0
   )
on   h_later.blnIsActive = 1
   and h_later.idfsAggrCaseSection = 71460000000 -- Diagnostic Action
   and apa.idfAggrDiagnosticActionMTX = vD_later.idfRow
   and apa.idfsDiagnosis = cast(vD_later.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS_later.varValue as bigint)
   and apa.idfsDiagnosticAction = cast(vP_later.varValue as bigint)
   and fhac.idfDiagnosticVersion is null
   and h_later.datStartDate <= fhac.datStartDate
   and h_later.intRowStatus = 0
   and ( h_later.datStartDate > h.datStartDate
     or ( h_later.datStartDate = h.datStartDate
       and h_later.idfVersion > h.idfVersion
      )
    )
    
    

--/* 10 column "Tested: total" */

left join	(
	dbo.tlbActivityParameters agp_TTW
	inner join	dbo.ffParameter p_TTW
	on			p_TTW.idfsParameter = agp_TTW.idfsParameter
				and p_TTW.intRowStatus = 0 
				and p_TTW.idfsParameter = 1093240000000	-- Number of tested animals
	inner join	trtBaseReference br_p_TTW
	on			br_p_TTW.idfsBaseReference = p_TTW.idfsParameter
				and br_p_TTW.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_TTW.intRowStatus = 0
			)
on			agp_TTW.idfObservation = fhac.idfDiagnosticObservation
			and agp_TTW.idfRow = vD.idfRow -- agpD.idfRow
			and agp_TTW.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_TTW.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--/* 12 column "Positive reaction taken: total" */

left join	(
	dbo.tlbActivityParameters agp_PRT
	inner join	dbo.ffParameter p_PRT
	on			p_PRT.idfsParameter = agp_PRT.idfsParameter
				and p_PRT.intRowStatus = 0 
				and p_PRT.idfsParameter = 1092400000000	-- Number of animals with positive reaction
	inner join	trtBaseReference br_p_PRT
	on			br_p_PRT.idfsBaseReference = p_PRT.idfsParameter
				and br_p_PRT.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_PRT.intRowStatus = 0
			)
on			agp_PRT.idfObservation = fhac.idfDiagnosticObservation
			and agp_PRT.idfRow = vD.idfRow -- agpD.idfRow
			and agp_PRT.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_PRT.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
    
    
WHERE h_later.idfVersion IS NULL
GROUP BY    
    fhac.idfsRegion, 
    fhac.idfsRayon,
    idfsDiagnosis,
    idfsSpeciesType,
    idfsDiagnosticAction


-- ¬џборка первых кейсов с начала года

declare		@VetInvestigationTypeMatrixRows_Year table
(	idfAggrCase	BIGINT not null,
	datStartDate DATETIME,
	idfDiagnosticVersion BIGINT,
	idfDiagnosticObservation BIGINT,
	idfsRegion BIGINT,
	idfsRayon BIGINT,
	idfsDiagnosis BIGINT,
	idfsSpeciesType BIGINT,
	idfsDiagnosticAction BIGINT,
	idfRow BIGINT,
	primary key
	(	idfsDiagnosticAction asc,
		idfsSpeciesType asc,
		idfsDiagnosis asc,
		idfAggrCase asc
	)
)

insert into	@VetInvestigationTypeMatrixRows_Year
(	idfAggrCase,
	datStartDate,
	idfDiagnosticVersion,
	idfDiagnosticObservation,
	idfsRegion,
	idfsRayon,
	idfsDiagnosis,
	idfsSpeciesType,
	idfsDiagnosticAction,
	idfRow
)
select	
		fhac.idfAggrCase,
		fhac.datStartDate,
		h.idfVersion,
		fhac.idfDiagnosticObservation,
		fhac.idfsRegion,
		fhac.idfsRayon,
		apa.idfsDiagnosis,
		apa.idfsSpeciesType,
		apa.idfsDiagnosticAction,
		apa.idfAggrDiagnosticActionMTX

from	@VetInvestigationTypeMatrix_Year fhac

inner join tlbAggrDiagnosticActionMTX apa
    INNER JOIN @SpeciesTable st
    ON st.[KEY] = apa.idfsSpeciesType
    INNER JOIN @DiagnosisTable dt
    ON dt.[KEY] = apa.idfsDiagnosis
    INNER JOIN @MeasuresTable mt
    ON mt.[KEY] = apa.idfsDiagnosticAction
on   apa.intRowStatus = 0

inner join (
 tlbAggrMatrixVersionHeader h
 inner join tlbAggrMatrixVersion vD
 on   vD.idfVersion = h.idfVersion
 and vD.idfsParameter = 226930000000 -- Vet Epizootic Action Diagnosis Inv: Diagnosis   
    and vD.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS
 on   vS.idfVersion = h.idfVersion
 and vS.idfsParameter = 239030000000 -- Vet Epizootic Action Diagnosis Inv: Species   
 and vS.idfRow = vD.idfRow
    and vS.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP
 on   vP.idfVersion = h.idfVersion
 and vP.idfsParameter = 231670000000 -- Vet Epizootic Action Diagnosis Inv: Investigation type   
 and vP.idfRow = vD.idfRow
    and vP.intRowStatus = 0
   )
on   h.blnIsActive = 1
   and h.idfsAggrCaseSection = 71460000000 -- Diagnostic Action
   and apa.idfAggrDiagnosticActionMTX = vD.idfRow
   and apa.idfsDiagnosis = cast(vD.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS.varValue as bigint)
   and apa.idfsDiagnosticAction = cast(vP.varValue as bigint)
   and (h.idfVersion = fhac.idfDiagnosticVersion or fhac.idfDiagnosticVersion is null)
   and (h.datStartDate <= fhac.datStartDate)
   and h.intRowStatus = 0
left join (
 tlbAggrMatrixVersionHeader h_later
 inner join tlbAggrMatrixVersion vD_later
 on   vD_later.idfVersion = h_later.idfVersion
 and vD_later.idfsParameter = 226930000000 -- Vet Epizootic Action Diagnosis Inv: Diagnosis   
    and vD_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS_later
 on   vS_later.idfVersion = h_later.idfVersion
 and vS_later.idfsParameter = 239030000000 -- Vet Epizootic Action Diagnosis Inv: Species   
 and vS_later.idfRow = vD_later.idfRow
    and vS_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP_later
 on   vP_later.idfVersion = h_later.idfVersion
 and vP_later.idfsParameter = 231670000000 -- Vet Epizootic Action Diagnosis Inv: Investigation type   
 and vP_later.idfRow = vD_later.idfRow
    and vP_later.intRowStatus = 0
   )
on   h_later.blnIsActive = 1
   and h_later.idfsAggrCaseSection = 71460000000 -- Diagnostic Action
   and apa.idfAggrDiagnosticActionMTX = vD_later.idfRow
   and apa.idfsDiagnosis = cast(vD_later.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS_later.varValue as bigint)
   and apa.idfsDiagnosticAction = cast(vP_later.varValue as bigint)
   and fhac.idfDiagnosticVersion is null
   and h_later.datStartDate <= fhac.datStartDate
   and h_later.intRowStatus = 0
   and ( h_later.datStartDate > h.datStartDate
     or ( h_later.datStartDate = h.datStartDate
       and h_later.idfVersion > h.idfVersion
      )
    )
WHERE		h_later.idfVersion is null

delete		fhacr_later
from		@VetInvestigationTypeMatrixRows_Year fhacr
inner join	@VetInvestigationTypeMatrixRows_Year fhacr_later
on			fhacr_later.idfsRayon = fhacr.idfsRayon
			and fhacr_later.idfsRegion = fhacr.idfsRegion
			and fhacr_later.idfsDiagnosticAction = fhacr.idfsDiagnosticAction
			and fhacr_later.idfsSpeciesType = fhacr.idfsSpeciesType
			and fhacr_later.idfsDiagnosis = fhacr.idfsDiagnosis
			and	(	fhacr_later.datStartDate > fhacr.datStartDate
					or	(	fhacr_later.datStartDate = fhacr.datStartDate
							and fhacr_later.idfAggrCase > fhacr.idfAggrCase
						)
				)

DECLARE	@VetInvestigationTypeMatrixValuesTable_FirstInYear	TABLE
(	idfsRegion				BIGINT,
	idfsDiagnosis			BIGINT,
	idfsSpeciesType			BIGINT,
	idfsDiagnosticAction	BIGINT,
	intPlannedToTest		INT 
)

insert into	@VetInvestigationTypeMatrixValuesTable_FirstInYear
(	idfsRegion,
	idfsDiagnosis,
	idfsSpeciesType,
	idfsDiagnosticAction,
	intPlannedToTest
)
select		
		fhacr.idfsRegion,
		fhacr.idfsDiagnosis,
		fhacr.idfsSpeciesType,
		fhacr.idfsDiagnosticAction,
		sum(IsNull(CAST(agp_NAPT.varValue AS INT), 0))

from	@VetInvestigationTypeMatrixRows_Year fhacr

--/*10 column "Number of animals planned to test in this year"*/
left join	(
	tlbActivityParameters agp_NAPT
	inner join	dbo.ffParameter p_NAPT
	on			p_NAPT.idfsParameter = agp_NAPT.idfsParameter
				and p_NAPT.intRowStatus = 0 
				and p_NAPT.idfsParameter = 1092360000000	-- Number of animals planned to test in this year
	inner join	trtBaseReference br_p_NAPT
	on			br_p_NAPT.idfsBaseReference = p_NAPT.idfsParameter
				and br_p_NAPT.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_NAPT.intRowStatus = 0
			)
on		agp_NAPT.idfObservation = fhacr.idfDiagnosticObservation
			and agp_NAPT.idfRow = fhacr.idfRow
			and agp_NAPT.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_NAPT.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

group by	fhacr.idfsRegion,
			fhacr.idfsDiagnosis,
			fhacr.idfsSpeciesType,
			fhacr.idfsDiagnosticAction
	
	
insert into	@ReportTable
(	idfsBaseReference,
	strRegionName,
    strRayonName,
	strDiagnosisName,
	strInvestigationType,
	strSpecies,
    intTestedTotalWeek,
    intPosReactTotalWeek,
    intPlannedToTest,
    intTestedTotalYear,
    intNumOfExecPer,
    intPosReactTotalYear,
    intInfectedPer,
	intOrder
)


SELECT
	0, 
    ref_Region.[Name],
    null,
    ref_Diagnosis.[Name],
    ref_DiagnosticAction.[Name],
    ref_Species.[Name],
	mx3.intTestedTotalWeek,
	mx3.intPosReactTotalWeek,
    mx2.intPlannedToTest,
	mx1.intTestedTotalYear,
    CASE 
        WHEN ISNULL(mx2.intPlannedToTest, 0) <> 0 
        THEN (cast(mx1.intTestedTotalYear as float) / cast(mx2.intPlannedToTest as float)) * 100.00
        ELSE NULL 
    END,
	mx1.intPosReactTotalYear,
    CASE 
        WHEN ISNULL(mx2.intPlannedToTest, 0) <> 0 
        THEN (cast(mx1.intPosReactTotalYear as float) / cast(mx2.intPlannedToTest as float)) * 100.00
        ELSE NULL 
    END,
	0
FROM 	
 (
    SELECT DISTINCT idfsRegion, idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable
    UNION
    SELECT DISTINCT idfsRegion, idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable_Year
    UNION
    SELECT DISTINCT idfsRegion, idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable_FirstInYear
 ) All_rows
 
LEFT OUTER JOIN fnGisReference (@LangID, 19000003) ref_region
ON ref_region.idfsReference = All_rows.idfsRegion

LEFT OUTER JOIN fnReference (@LangID, 19000019) ref_Diagnosis
ON ref_Diagnosis.idfsReference = All_rows.idfsDiagnosis

LEFT OUTER JOIN fnReference (@LangID, 19000086) ref_Species
ON ref_Species.idfsReference = All_rows.idfsSpeciesType

LEFT OUTER JOIN fnReference (@LangID, 19000021) ref_DiagnosticAction
ON ref_DiagnosticAction.idfsReference = All_rows.idfsDiagnosticAction


LEFT OUTER JOIN @VetInvestigationTypeMatrixValuesTable_Year mx1
ON 
    All_rows.idfsRegion = mx1.idfsRegion AND 
    All_rows.idfsDiagnosis = mx1.idfsDiagnosis AND
    All_rows.idfsSpeciesType = mx1.idfsSpeciesType AND
    All_rows.idfsDiagnosticAction = mx1.idfsDiagnosticAction 
    
LEFT OUTER JOIN @VetInvestigationTypeMatrixValuesTable_FirstInYear mx2
ON 
    All_rows.idfsRegion = mx2.idfsRegion AND 
    All_rows.idfsDiagnosis = mx2.idfsDiagnosis AND
    All_rows.idfsSpeciesType = mx2.idfsSpeciesType AND
    All_rows.idfsDiagnosticAction = mx2.idfsDiagnosticAction 
    
LEFT OUTER JOIN @VetInvestigationTypeMatrixValuesTable mx3
ON 
    All_rows.idfsRegion = mx3.idfsRegion AND 
    All_rows.idfsDiagnosis = mx3.idfsDiagnosis AND 
    All_rows.idfsSpeciesType = mx3.idfsSpeciesType AND 
    All_rows.idfsDiagnosticAction = mx3.idfsDiagnosticAction    



insert into	@ReportTable
(	idfsBaseReference,
	strRegionName,
    strRayonName,
	strDiagnosisName,
	strInvestigationType,
	strSpecies,
    intTestedTotalWeek,
    intPosReactTotalWeek,
    intPlannedToTest,
    intTestedTotalYear,
    intNumOfExecPer,
    intPosReactTotalYear,
    intInfectedPer,
	intOrder
)
select		
	0, 
    ref_Region.[Name],
    null,
    ref_Diagnosis.[Name],
    ref_DiagnosticAction.[Name],
    ref_Species.[Name],
	null,
	null,
	null,
	null,
	null,
	null,
	null,
	0
from		(
    SELECT DISTINCT idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable
    UNION
    SELECT DISTINCT idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable_Year
    UNION
    SELECT DISTINCT idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable_FirstInYear
			) All_Ref
inner join	gisRegion r
on			r.idfsCountry = 1240000000
			and r.intRowStatus = 0
inner join	fnGisReference (@LangID, 19000003) ref_region
on			ref_region.idfsReference = r.idfsRegion

LEFT OUTER JOIN fnReference (@LangID, 19000019) ref_Diagnosis
ON ref_Diagnosis.idfsReference = All_Ref.idfsDiagnosis

LEFT OUTER JOIN fnReference (@LangID, 19000086) ref_Species
ON ref_Species.idfsReference = All_Ref.idfsSpeciesType

LEFT OUTER JOIN fnReference (@LangID, 19000021) ref_DiagnosticAction
ON ref_DiagnosticAction.idfsReference = All_Ref.idfsDiagnosticAction

left join	(
    SELECT DISTINCT idfsRegion, idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable
    UNION
    SELECT DISTINCT idfsRegion, idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable_Year
    UNION
    SELECT DISTINCT idfsRegion, idfsDiagnosis, idfsSpeciesType, idfsDiagnosticAction FROM @VetInvestigationTypeMatrixValuesTable_FirstInYear
			) All_rows
on			All_rows.idfsDiagnosis = All_Ref.idfsDiagnosis
			and All_rows.idfsSpeciesType = All_Ref.idfsSpeciesType
			and All_rows.idfsDiagnosticAction = All_Ref.idfsDiagnosticAction
			and All_rows.idfsRegion = r.idfsRegion

where		All_rows.idfsDiagnosticAction is null


update		rt
set			rt.intOrder = (
				select		count(*)
				from		@ReportTable rt_min
				where		rt_min.strRegionName < rt.strRegionName
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strDiagnosisName < rt.strDiagnosisName
								)
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strDiagnosisName = rt.strDiagnosisName
									and rt_min.strInvestigationType < rt.strInvestigationType
								)
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strDiagnosisName = rt.strDiagnosisName
									and rt_min.strInvestigationType = rt.strInvestigationType
									and rt_min.strSpecies <= rt.strSpecies
								)
									)
from		@ReportTable rt

update		rt
set			rt.idfsBaseReference = rt.intOrder
from		@ReportTable rt

SELECT * 
FROM @ReportTable
ORDER BY intOrder











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

