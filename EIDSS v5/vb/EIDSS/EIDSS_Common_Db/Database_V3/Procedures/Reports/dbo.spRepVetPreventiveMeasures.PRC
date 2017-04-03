 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetPreventiveMeasures]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetPreventiveMeasures]


GO

--##SUMMARY Select data for Report "Veterinary preventive measures" V3.
--##REMARKS Author: Grigoreva Elena
--##REMARKS Create date: 18.01.2011 

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec [spRepVetPreventiveMeasures] 
'en', 
'2010-01-01', 
'2010-02-01',  
'<ItemList><Item key="952220000000" value="Deratization"/></ItemList>', 
'<ItemList><Item key="952220000000" value="Deratization"/></ItemList>', 
'<ItemList><Item key="952220000000" value="Deratization"/></ItemList>', 
1
  
*/

CREATE  PROCEDURE [dbo].[spRepVetPreventiveMeasures]
	(
		@LangID		AS NVARCHAR(10), 
		@StartDate	AS DATETIME,	 
		@FinishDate	AS DATETIME,
		@Diagnosis AS XML,
    @Species AS XML,
		@Measures	AS XML,
    @Region AS BIGINT
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/KZ/Reports/Specification_for_reports_development_Country_vaccination-treatment-KZ-V3.docx"
-- by number marked red at screen form prototype 

DECLARE	@ReportTable	TABLE
(	idfsBaseReference	BIGINT NOT NULL,
	strRegionName		NVARCHAR(300) COLLATE database_default NULL, --1
  strRayonName		NVARCHAR(300) COLLATE database_default NULL, --1
	strDiagnosisName	NVARCHAR(500) COLLATE database_default NULL, --2
	strMeasureType		NVARCHAR(500) COLLATE database_default NULL, --3
	strSpecies			NVARCHAR(300) COLLATE database_default NULL, --4

    intNumOfAnimForVact INT NULL, --5
    intNumOfVactAnimRep INT NULL, --6
    intNumOfVactAnimYear INT NULL, --7
    intPlanExec FLOAT NULL, --8

	intOrder			INT NOT NULL
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

EXEC sp_xml_preparedocument @iMeasures OUTPUT, @Measures

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
declare	@VetProphylacticMeasureMatrix	table
(	idfAggrCase	BIGINT not null primary KEY,
  datStartDate DATETIME,
  idfProphylacticVersion BIGINT,
  idfProphylacticObservation BIGINT,
  idfsRegion BIGINT,
  idfsRayon BIGINT
)


insert into	@VetProphylacticMeasureMatrix  
(	idfAggrCase,
  datStartDate,
  idfProphylacticVersion,
  idfProphylacticObservation,
  idfsRegion,
  idfsRayon
)
select		a.idfAggrCase,
          a.datStartDate,
          a.idfProphylacticVersion,
          a.idfProphylacticObservation,
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




DECLARE	@VetProphylacticMeasureMatrixValuesTable	TABLE
(	   idfsRegion	BIGINT,
     idfsRayon	BIGINT,
     idfsDiagnosis	BIGINT,
     idfsSpeciesType	BIGINT,
     idfsProphilacticAction	BIGINT,
     intNumOfVactAnimRep INT --6
 )



insert into	@VetProphylacticMeasureMatrixValuesTable
(	idfsRegion,
  idfsRayon,
  idfsDiagnosis,
  idfsSpeciesType,
  idfsProphilacticAction,
  intNumOfVactAnimRep
)
select		
   fhac.idfsRegion,
   fhac.idfsRayon,
   apa.idfsDiagnosis,
   apa.idfsSpeciesType,
   apa.idfsProphilacticAction,
	 sum(IsNull(CAST(agp_NVA.varValue AS INT), 0)) 


from		@VetProphylacticMeasureMatrix fhac

inner join tlbAggrProphylacticActionMTX apa
    INNER JOIN @SpeciesTable st
    ON st.[KEY] = apa.idfsSpeciesType
    INNER JOIN @DiagnosisTable dt
    ON dt.[KEY] = apa.idfsDiagnosis
    INNER JOIN @MeasuresTable mt
    ON mt.[KEY] = apa.idfsProphilacticAction
on   apa.intRowStatus = 0 


inner join (
 tlbAggrMatrixVersionHeader h
 inner join tlbAggrMatrixVersion vD
 on   vD.idfVersion = h.idfVersion
 and vD.idfsParameter = 226950000000 -- Vet Epizootic Action Treatment: Diagnosis   
    and vD.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS
 on   vS.idfVersion = h.idfVersion
 and vS.idfsParameter = 239050000000 -- Vet Epizootic Action Treatment: Species   
 and vS.idfRow = vD.idfRow
    and vS.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP
 on   vP.idfVersion = h.idfVersion
 and vP.idfsParameter = 245270000000 -- Vet Epizootic Action Treatment: Measure Type   
 and vP.idfRow = vD.idfRow
    and vP.intRowStatus = 0
   )
on   h.blnIsActive = 1
   and h.idfsAggrCaseSection = 71300000000 -- Prophylactic Action
   and apa.idfAggrProphylacticActionMTX = vD.idfRow
   and apa.idfsDiagnosis = cast(vD.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS.varValue as bigint)
   and apa.idfsProphilacticAction = cast(vP.varValue as bigint)
   and (h.idfVersion = fhac.idfProphylacticVersion or fhac.idfProphylacticVersion is null)
   and (h.datStartDate <= fhac.datStartDate)
   and h.intRowStatus = 0
left join (
 tlbAggrMatrixVersionHeader h_later
 inner join tlbAggrMatrixVersion vD_later
 on   vD_later.idfVersion = h_later.idfVersion
 and vD_later.idfsParameter = 226950000000 -- Vet Epizootic Action Treatment: Diagnosis   
    and vD_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS_later
 on   vS_later.idfVersion = h_later.idfVersion
 and vS_later.idfsParameter = 239050000000 -- Vet Epizootic Action Treatment: Species   
 and vS_later.idfRow = vD_later.idfRow
    and vS_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP_later
 on   vP_later.idfVersion = h_later.idfVersion
 and vP_later.idfsParameter = 245270000000 -- Vet Epizootic Action Treatment: Measure Type   
 and vP_later.idfRow = vD_later.idfRow
    and vP_later.intRowStatus = 0
   )
on   h_later.blnIsActive = 1
   and h_later.idfsAggrCaseSection = 71300000000 -- Prophylactic Action
   and apa.idfAggrProphylacticActionMTX = vD_later.idfRow
   and apa.idfsDiagnosis = cast(vD_later.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS_later.varValue as bigint)
   and apa.idfsProphilacticAction = cast(vP_later.varValue as bigint)
   and fhac.idfProphylacticVersion is null
   and h_later.datStartDate <= fhac.datStartDate
   and h_later.intRowStatus = 0
   and ( h_later.datStartDate > h.datStartDate
     or ( h_later.datStartDate = h.datStartDate
       and h_later.idfVersion > h.idfVersion
      )
    )

--/* 6 column УNumber of vaccinated animalsФ*/
left join	(
	dbo.tlbActivityParameters agp_NVA
	inner join	dbo.ffParameter p_NVA
	on			p_NVA.idfsParameter = agp_NVA.idfsParameter
				and p_NVA.intRowStatus = 0 
				and p_NVA.idfsParameter = 1093360000000   /*column УNumber of vaccinated animalsФ*/
	inner join	trtBaseReference br_p_NVA
	on			br_p_NVA.idfsBaseReference = p_NVA.idfsParameter
				and br_p_NVA.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_NVA.intRowStatus = 0
			)
on			agp_NVA.idfObservation = fhac.idfProphylacticObservation
			and agp_NVA.idfRow = vD.idfRow -- agpD.idfRow
			and agp_NVA.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_NVA.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

WHERE h_later.idfVersion IS NULL
GROUP BY    
    fhac.idfsRegion, 
    fhac.idfsRayon,
    idfsDiagnosis,
    idfsSpeciesType,
    idfsProphilacticAction

	

-- выборка кейсов с начала года	до конца отчетного периода
SET @StartDate = CAST(CAST(YEAR(@StartDate)	 AS VARCHAR(4)) + '0101' AS DATETIME)


declare	@VetProphylacticMeasureMatrix_Year	table
(	idfAggrCase	BIGINT not null primary KEY,
  datStartDate DATETIME,
  idfProphylacticVersion BIGINT,
  idfProphylacticObservation BIGINT,
  idfsRegion BIGINT,
  idfsRayon BIGINT
)


insert into	@VetProphylacticMeasureMatrix_Year  
(	idfAggrCase,
  datStartDate,
  idfProphylacticVersion,
  idfProphylacticObservation,
  idfsRegion,
  idfsRayon
)
select		a.idfAggrCase,
          a.datStartDate,
          a.idfProphylacticVersion,
          a.idfProphylacticObservation,
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
	
	
DECLARE	@VetProphylacticMeasureMatrixValuesTable_Year	TABLE
(	   idfsRegion	BIGINT,
     idfsRayon	BIGINT,
     idfsDiagnosis	BIGINT,
     idfsSpeciesType	BIGINT,
     idfsProphilacticAction	BIGINT,
     intNumOfVactAnimYear INT 
     
)



insert into	@VetProphylacticMeasureMatrixValuesTable_Year
(	idfsRegion,
  idfsRayon,
  idfsDiagnosis,
  idfsSpeciesType,
  idfsProphilacticAction,
  intNumOfVactAnimYear
)
select		
   fhac.idfsRegion,
   fhac.idfsRayon,
   apa.idfsDiagnosis,
   apa.idfsSpeciesType,
   apa.idfsProphilacticAction,
	 sum(IsNull(CAST(agp_NVAY.varValue AS INT), 0))


from		@VetProphylacticMeasureMatrix_Year fhac

inner join tlbAggrProphylacticActionMTX apa
    INNER JOIN @SpeciesTable st
    ON st.[KEY] = apa.idfsSpeciesType
    INNER JOIN @DiagnosisTable dt
    ON dt.[KEY] = apa.idfsDiagnosis
    INNER JOIN @MeasuresTable mt
    ON mt.[KEY] = apa.idfsProphilacticAction
on   apa.intRowStatus = 0

inner join (
 tlbAggrMatrixVersionHeader h
 inner join tlbAggrMatrixVersion vD
 on   vD.idfVersion = h.idfVersion
 and vD.idfsParameter = 226950000000 -- Vet Epizootic Action Treatment: Diagnosis   
    and vD.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS
 on   vS.idfVersion = h.idfVersion
 and vS.idfsParameter = 239050000000 -- Vet Epizootic Action Treatment: Species   
 and vS.idfRow = vD.idfRow
    and vS.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP
 on   vP.idfVersion = h.idfVersion
 and vP.idfsParameter = 245270000000 -- Vet Epizootic Action Treatment: Measure Type   
 and vP.idfRow = vD.idfRow
    and vP.intRowStatus = 0
   )
on   h.blnIsActive = 1
   and h.idfsAggrCaseSection = 71300000000 -- Prophylactic Action
   and apa.idfAggrProphylacticActionMTX = vD.idfRow
   and apa.idfsDiagnosis = cast(vD.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS.varValue as bigint)
   and apa.idfsProphilacticAction = cast(vP.varValue as bigint)
   and (h.idfVersion = fhac.idfProphylacticVersion or fhac.idfProphylacticVersion is null)
   and (h.datStartDate <= fhac.datStartDate)
   and h.intRowStatus = 0
left join (
 tlbAggrMatrixVersionHeader h_later
 inner join tlbAggrMatrixVersion vD_later
 on   vD_later.idfVersion = h_later.idfVersion
 and vD_later.idfsParameter = 226950000000 -- Vet Epizootic Action Treatment: Diagnosis   
    and vD_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vS_later
 on   vS_later.idfVersion = h_later.idfVersion
 and vS_later.idfsParameter = 239050000000 -- Vet Epizootic Action Treatment: Species   
 and vS_later.idfRow = vD_later.idfRow
    and vS_later.intRowStatus = 0
 inner join tlbAggrMatrixVersion vP_later
 on   vP_later.idfVersion = h_later.idfVersion
 and vP_later.idfsParameter = 245270000000 -- Vet Epizootic Action Treatment: Measure Type   
 and vP_later.idfRow = vD_later.idfRow
    and vP_later.intRowStatus = 0
   )
on   h_later.blnIsActive = 1
   and h_later.idfsAggrCaseSection = 71300000000 -- Prophylactic Action
   and apa.idfAggrProphylacticActionMTX = vD_later.idfRow
   and apa.idfsDiagnosis = cast(vD_later.varValue as bigint)
   and apa.idfsSpeciesType = cast(vS_later.varValue as bigint)
   and apa.idfsProphilacticAction = cast(vP_later.varValue as bigint)
   and fhac.idfProphylacticVersion is null
   and h_later.datStartDate <= fhac.datStartDate
   and h_later.intRowStatus = 0
   and ( h_later.datStartDate > h.datStartDate
     or ( h_later.datStartDate = h.datStartDate
       and h_later.idfVersion > h.idfVersion
      )
    )
    
    
--/*column УNumber of vaccinated animalsФФ*/
left join	(
	dbo.tlbActivityParameters agp_NVAY
	inner join	dbo.ffParameter p_NVAY
	on			p_NVAY.idfsParameter = agp_NVAY.idfsParameter
				and p_NVAY.intRowStatus = 0 
				and p_NVAY.idfsParameter = 1093360000000   /*column УNumber of vaccinated animalsФ*/
	inner join	trtBaseReference br_p_NVAY
	on			br_p_NVAY.idfsBaseReference = p_NVAY.idfsParameter
				and br_p_NVAY.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_NVAY.intRowStatus = 0
			)
on			agp_NVAY.idfObservation = fhac.idfProphylacticObservation
			and agp_NVAY.idfRow = vD.idfRow -- agpD.idfRow
			and agp_NVAY.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_NVAY.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')    
    
    
WHERE h_later.idfVersion IS NULL
GROUP BY    
    fhac.idfsRegion, 
    fhac.idfsRayon,
    idfsDiagnosis,
    idfsSpeciesType,
    idfsProphilacticAction
    
    
    
-- ¬џборка первых кейсов с начала года

DECLARE	@VetProphylacticMeasureMatrixValuesTable_FirstInYear	TABLE
(	   idfsRegion	BIGINT,
     idfsRayon	BIGINT,
     idfsDiagnosis	BIGINT,
     idfsSpeciesType	BIGINT,
     idfsProphilacticAction	BIGINT,
     intNumOfAnimForVact INT 
)

insert into	@VetProphylacticMeasureMatrixValuesTable_FirstInYear
(	idfsRegion,
  idfsRayon,
  idfsDiagnosis,
  idfsSpeciesType,
  idfsProphilacticAction,
  intNumOfAnimForVact
)
select		
   fy.idfsRegion,
   fy.idfsRayon,
   fy.idfsDiagnosis,
   fy.idfsSpeciesType,
   fy.idfsProphilacticAction,
	 IsNull(CAST(agp_NAFV.varValue AS INT), 0)


from	
(SELECT 
   fhac.idfsRegion,
   fhac.idfsRayon,
   apa.idfsDiagnosis,
   apa.idfsSpeciesType,
   apa.idfsProphilacticAction,
   vD.idfRow,
   fhac.idfProphylacticObservation,
   row_number() over(partition by  fhac.idfsRegion,
                                   fhac.idfsRayon,
                                   apa.idfsDiagnosis,
                                   apa.idfsSpeciesType,
                                   apa.idfsProphilacticAction
                       order by fhac.datStartDate) AS RN
	FROM @VetProphylacticMeasureMatrix_Year fhac

    inner join tlbAggrProphylacticActionMTX apa
        INNER JOIN @SpeciesTable st
        ON st.[KEY] = apa.idfsSpeciesType
        INNER JOIN @DiagnosisTable dt
        ON dt.[KEY] = apa.idfsDiagnosis
        INNER JOIN @MeasuresTable mt
        ON mt.[KEY] = apa.idfsProphilacticAction
    on   apa.intRowStatus = 0

    inner join (
     tlbAggrMatrixVersionHeader h
     inner join tlbAggrMatrixVersion vD
     on   vD.idfVersion = h.idfVersion
     and vD.idfsParameter = 226950000000 -- Vet Epizootic Action Treatment: Diagnosis   
        and vD.intRowStatus = 0
     inner join tlbAggrMatrixVersion vS
     on   vS.idfVersion = h.idfVersion
     and vS.idfsParameter = 239050000000 -- Vet Epizootic Action Treatment: Species   
     and vS.idfRow = vD.idfRow
        and vS.intRowStatus = 0
     inner join tlbAggrMatrixVersion vP
     on   vP.idfVersion = h.idfVersion
     and vP.idfsParameter = 245270000000 -- Vet Epizootic Action Treatment: Measure Type   
     and vP.idfRow = vD.idfRow
        and vP.intRowStatus = 0
       )
    on   h.blnIsActive = 1
       and h.idfsAggrCaseSection = 71300000000 -- Prophylactic Action
	   and apa.idfAggrProphylacticActionMTX = vD.idfRow
       and apa.idfsDiagnosis = cast(vD.varValue as bigint)
       and apa.idfsSpeciesType = cast(vS.varValue as bigint)
       and apa.idfsProphilacticAction = cast(vP.varValue as bigint)
       and (h.idfVersion = fhac.idfProphylacticVersion or fhac.idfProphylacticVersion is null)
       and (h.datStartDate <= fhac.datStartDate)
       and h.intRowStatus = 0
    left join (
     tlbAggrMatrixVersionHeader h_later
     inner join tlbAggrMatrixVersion vD_later
     on   vD_later.idfVersion = h_later.idfVersion
     and vD_later.idfsParameter = 226950000000 -- Vet Epizootic Action Treatment: Diagnosis   
        and vD_later.intRowStatus = 0
     inner join tlbAggrMatrixVersion vS_later
     on   vS_later.idfVersion = h_later.idfVersion
     and vS_later.idfsParameter = 239050000000 -- Vet Epizootic Action Treatment: Species   
     and vS_later.idfRow = vD_later.idfRow
        and vS_later.intRowStatus = 0
     inner join tlbAggrMatrixVersion vP_later
     on   vP_later.idfVersion = h_later.idfVersion
     and vP_later.idfsParameter = 245270000000 -- Vet Epizootic Action Treatment: Measure Type   
     and vP_later.idfRow = vD_later.idfRow
        and vP_later.intRowStatus = 0
       )
    on   h_later.blnIsActive = 1
       and h_later.idfsAggrCaseSection = 71300000000 -- Prophylactic Action
	   and apa.idfAggrProphylacticActionMTX = vD_later.idfRow
       and apa.idfsDiagnosis = cast(vD_later.varValue as bigint)
       and apa.idfsSpeciesType = cast(vS_later.varValue as bigint)
       and apa.idfsProphilacticAction = cast(vP_later.varValue as bigint)
       and fhac.idfProphylacticVersion is null
       and h_later.datStartDate <= fhac.datStartDate
       and h_later.intRowStatus = 0
       and ( h_later.datStartDate > h.datStartDate
         or ( h_later.datStartDate = h.datStartDate
           and h_later.idfVersion > h.idfVersion
          )
        )    
    WHERE h_later.idfVersion IS NULL
  ) fy    

--/*column УNumber of animals planned for vaccination in this yearФ*/
left join	(
	dbo.tlbActivityParameters agp_NAFV
	inner join	dbo.ffParameter p_NAFV
	on			p_NAFV.idfsParameter = agp_NAFV.idfsParameter
				and p_NAFV.intRowStatus = 0 
				and p_NAFV.idfsParameter = 1092320000000 /*column УNumber of animals planned for vaccination in this yearФ*/
	inner join	trtBaseReference br_p_NAFV
	on			br_p_NAFV.idfsBaseReference = p_NAFV.idfsParameter
				and br_p_NAFV.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_NAFV.intRowStatus = 0
			)
on		agp_NAFV.idfObservation = fy.idfProphylacticObservation
			and agp_NAFV.idfRow = fy.idfRow
			and agp_NAFV.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_NAFV.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
			
where	fy.RN = 1
	
	
	
	
INSERT INTO	@ReportTable
(	idfsBaseReference,
	strRegionName, --1
	strRayonName, --1
	strDiagnosisName, --2
	strMeasureType, --3
	strSpecies, --4

    intNumOfAnimForVact, --5
    intNumOfVactAnimRep, --6
    intNumOfVactAnimYear, --7
    intPlanExec, --8
	intOrder
)


SELECT
	0, 
    ref_Region.[Name],
    ref_Rayon.[Name],
    ref_Diagnosis.[Name],
    ref_ProphilacticAction.[Name],
    ref_Species.[Name],
    mx2.intNumOfAnimForVact,
    mx3.intNumOfVactAnimRep,
    mx1.intNumOfVactAnimYear,
    CASE 
        WHEN ISNULL(mx2.intNumOfAnimForVact, 0) <> 0 
        THEN (cast(mx1.intNumOfVactAnimYear as float) / cast(mx2.intNumOfAnimForVact as float)) * 100.00
        ELSE NULL 
    END AS intPlanExec,
	0
FROM 	
 (
    SELECT DISTINCT idfsRegion, idfsRayon, idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable
    UNION
    SELECT DISTINCT idfsRegion, idfsRayon, idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable_Year
    UNION
    SELECT DISTINCT idfsRegion, idfsRayon, idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable_FirstInYear
 ) All_rows
 
LEFT OUTER JOIN fnGisReference (@LangID, 19000003) ref_region
ON ref_region.idfsReference = All_rows.idfsRegion

LEFT OUTER JOIN fnGisReference (@LangID, 19000002) ref_rayon
ON ref_rayon.idfsReference = All_rows.idfsRayon

LEFT OUTER JOIN fnReference (@LangID, 19000019) ref_Diagnosis
ON ref_Diagnosis.idfsReference = All_rows.idfsDiagnosis

LEFT OUTER JOIN fnReference (@LangID, 19000086) ref_Species
ON ref_Species.idfsReference = All_rows.idfsSpeciesType

LEFT OUTER JOIN fnReference (@LangID, 19000074) ref_ProphilacticAction
ON ref_ProphilacticAction.idfsReference = All_rows.idfsProphilacticAction


LEFT OUTER JOIN @VetProphylacticMeasureMatrixValuesTable_Year mx1
ON 
    All_rows.idfsRegion = mx1.idfsRegion AND 
    All_rows.idfsRayon = mx1.idfsRayon AND
    All_rows.idfsDiagnosis = mx1.idfsDiagnosis AND
    All_rows.idfsSpeciesType = mx1.idfsSpeciesType AND
    All_rows.idfsProphilacticAction = mx1.idfsProphilacticAction 
    
LEFT OUTER JOIN @VetProphylacticMeasureMatrixValuesTable_FirstInYear mx2
ON 
    All_rows.idfsRegion = mx2.idfsRegion AND 
    All_rows.idfsRayon = mx2.idfsRayon AND
    All_rows.idfsDiagnosis = mx2.idfsDiagnosis AND
    All_rows.idfsSpeciesType = mx2.idfsSpeciesType AND
    All_rows.idfsProphilacticAction = mx2.idfsProphilacticAction 
    
LEFT OUTER JOIN @VetProphylacticMeasureMatrixValuesTable mx3
ON 
    All_rows.idfsRegion = mx3.idfsRegion AND 
    All_rows.idfsRayon = mx3.idfsRayon AND 
    All_rows.idfsDiagnosis = mx3.idfsDiagnosis AND 
    All_rows.idfsSpeciesType = mx3.idfsSpeciesType AND 
    All_rows.idfsProphilacticAction = mx3.idfsProphilacticAction    


INSERT INTO	@ReportTable
(	idfsBaseReference,
	strRegionName, --1
	strRayonName, --1
	strDiagnosisName, --2
	strMeasureType, --3
	strSpecies, --4

    intNumOfAnimForVact, --5
    intNumOfVactAnimRep, --6
    intNumOfVactAnimYear, --7
    intPlanExec, --8
	intOrder
)
SELECT
	0, 
    ref_Region.[Name],
    ref_Rayon.[Name],
    ref_Diagnosis.[Name],
    ref_ProphilacticAction.[Name],
    ref_Species.[Name],
    null,
    null,
    null,
    null,
	0
FROM 	
 (
    SELECT DISTINCT idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable
    UNION
    SELECT DISTINCT idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable_Year
    UNION
    SELECT DISTINCT idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable_FirstInYear
 ) All_ref
inner join	gisRayon r
on			r.idfsRegion = @Region
			and r.intRowStatus = 0
inner join	fnGisReference (@LangID, 19000003) ref_region
on			ref_region.idfsReference = r.idfsRegion
inner join	fnGisReference (@LangID, 19000002) ref_rayon
on			ref_rayon.idfsReference = r.idfsRayon


LEFT OUTER JOIN fnReference (@LangID, 19000019) ref_Diagnosis
ON ref_Diagnosis.idfsReference = All_ref.idfsDiagnosis

LEFT OUTER JOIN fnReference (@LangID, 19000086) ref_Species
ON ref_Species.idfsReference = All_ref.idfsSpeciesType

LEFT OUTER JOIN fnReference (@LangID, 19000074) ref_ProphilacticAction
ON ref_ProphilacticAction.idfsReference = All_ref.idfsProphilacticAction

left join	 (
    SELECT DISTINCT idfsRegion, idfsRayon, idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable
    UNION
    SELECT DISTINCT idfsRegion, idfsRayon, idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable_Year
    UNION
    SELECT DISTINCT idfsRegion, idfsRayon, idfsDiagnosis, idfsSpeciesType, idfsProphilacticAction FROM @VetProphylacticMeasureMatrixValuesTable_FirstInYear
 ) All_rows
on			All_rows.idfsDiagnosis = All_Ref.idfsDiagnosis
			and All_rows.idfsSpeciesType = All_Ref.idfsSpeciesType
			and All_rows.idfsProphilacticAction = All_Ref.idfsProphilacticAction
			and All_rows.idfsRegion = r.idfsRegion
			and All_rows.idfsRayon = r.idfsRayon

where		All_rows.idfsProphilacticAction is null


update		rt
set			rt.intOrder = (
				select		count(*)
				from		@ReportTable rt_min
				where		rt_min.strRegionName < rt.strRegionName
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strRayonName < rt.strRayonName
								)
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strRayonName = rt.strRayonName
									and rt_min.strDiagnosisName < rt.strDiagnosisName
								)
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strRayonName = rt.strRayonName
									and rt_min.strDiagnosisName = rt.strDiagnosisName
									and rt_min.strMeasureType < rt.strMeasureType
								)
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strRayonName = rt.strRayonName
									and rt_min.strDiagnosisName = rt.strDiagnosisName
									and rt_min.strMeasureType = rt.strMeasureType
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

