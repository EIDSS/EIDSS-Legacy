 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumMonthlyInfectiousDiseaseFatal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumMonthlyInfectiousDiseaseFatal]


GO

--##SUMMARY Select data for Reportable Infectious Diseases (Monthly Form IV03).
--##REMARKS Author: 
--##REMARKS Create date: 10.01.2011

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepHumMonthlyInfectiousDiseaseFatal 'ru', '2010-01-01', '2010-02-01',  37020000000, 3260000000

*/

CREATE  Procedure [dbo].[spRepHumMonthlyInfectiousDiseaseFatal]
	(
		@LangID		as nvarchar(10), 
		@StartDate	as datetime,	 
		@FinishDate	as datetime,
		@RegionID	as bigint = null,
		@RayonID	as bigint = null
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/GG/Reports/Specification for report development - Monthly Form 03 Human GG v1.0.doc"
-- by number marked red at screen form prototype 

declare	@ReportTable	table
(	strICD10			nvarchar(200) collate database_default null,	--6 
	-- strICD10 should be null!
	intAge_0_1			float not null,	--7
	intAge_1_4			float not null, --8
	intAge_5_14			float not null, --9
	intAge_15_19		float not null, --10
	intAge_20_29		float not null, --11
	intAge_30_59		float not null, --12
	intAge_60_more		float not null, --14
	intLethalCases		float not null, --14
	strSpecifyDiseases  nvarchar(max) --45
)




DECLARE @idfsSummaryReportType BIGINT
DECLARE @idfsLanguage BIGINT
DECLARE @idfsSite BIGINT

SET @idfsLanguage = dbo.fnGetLanguageCode (@LangID)

IF @RayonID IS NULL
BEGIN
  SET @idfsSite = dbo.fnSiteID()
  
END
ELSE
BEGIN
  SELECT @idfsSite = tstSite.idfsSite
  FROM tstSite
      INNER JOIN tlbOffice
          INNER JOIN tlbGeoLocation
          ON tlbOffice.idfLocation = tlbGeoLocation.idfGeoLocation AND
          tlbGeoLocation.idfsRayon = @RayonID      
      ON tstSite.idfOffice = tlbOffice.idfOffice

  WHERE tstSite.intFlags = 1 AND tstSite.intRowStatus = 0
  
  IF @idfsSite IS NULL SET @idfsSite = dbo.fnSiteID()
END





SET @idfsSummaryReportType = 10290001 /**/


DECLARE	@MonthlyReportDiagnosisTable	TABLE
(	idfsDiagnosis	BIGINT NOT NULL PRIMARY KEY,
  blnIsAggregate BIT,
	intAge_0_1			INT NOT NULL,	--7
	intAge_1_4			INT NOT NULL, --8
	intAge_5_14			INT NOT NULL, --9
	intAge_15_19		INT NOT NULL, --10
	intAge_20_29		INT NOT NULL, --11
	intAge_30_59		INT NOT NULL, --12
	intAge_60_more		INT NOT NULL, --13
	intLethalCases INT NOT NULL
)

INSERT INTO @MonthlyReportDiagnosisTable (
	idfsDiagnosis,
  blnIsAggregate,
	intAge_0_1,
	intAge_1_4,
	intAge_5_14,
	intAge_15_19,
	intAge_20_29,
	intAge_30_59,
	intAge_60_more,
	intLethalCases
	
) 
SELECT DISTINCT
  fdt.idfsDiagnosis,
  CASE WHEN  trtd.idfsUsingType = 10020002  --dutAggregatedCase
    THEN 1
    ELSE 0
  END,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0

FROM dbo.trtDiagnosisToGroupForReportType fdt
    INNER JOIN trtDiagnosis trtd
    ON trtd.idfsDiagnosis = fdt.idfsDiagnosis AND
    trtd.intRowStatus = 0
WHERE  fdt.idfsSummaryReportType = @idfsSummaryReportType 
       AND  fdt.intRowStatus = 0 AND
       fdt.idfsDiagnosisGroup = 959290000000 /*Fatal cases of infectious diseases*/
       
       
INSERT INTO @MonthlyReportDiagnosisTable (
	idfsDiagnosis,
  blnIsAggregate,
	intAge_0_1,
	intAge_1_4,
	intAge_5_14,
	intAge_15_19,
	intAge_20_29,
	intAge_30_59,
	intAge_60_more,
	intLethalCases
) 
SELECT 
  trtd.idfsDiagnosis,
  CASE WHEN  trtd.idfsUsingType = 10020002  --dutAggregatedCase
    THEN 1
    ELSE 0
  END,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0

FROM dbo.trtReportRows rr
    INNER JOIN trtBaseReference br
    ON br.idfsBaseReference = rr.idfsDiagnosisOrGroup
        AND br.idfsReferenceType = 19000019 --'rftDiagnosis'
        AND br.intRowStatus = 0
    INNER JOIN trtDiagnosis trtd
    ON trtd.idfsDiagnosis = rr.idfsDiagnosisOrGroup 
        AND trtd.intRowStatus = 0
WHERE  rr.idfsSummaryReportType = @idfsSummaryReportType 
       AND  rr.intRowStatus = 0 
       AND NOT EXISTS 
       (
       SELECT * FROM @MonthlyReportDiagnosisTable
       WHERE idfsDiagnosis = rr.idfsDiagnosisOrGroup
       )      AND
       rr.idfsDiagnosisOrGroup = 959290000000 /*Fatal cases of infectious diseases*/




       
       
       

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
    10102001  Aggregate Case

*/

SET @AggrCaseType = 10102001

SELECT	@MinAdminLevel = idfsStatisticAreaType,
		@MinTimeInterval = idfsStatisticPeriodType
FROM fnAggregateSettings (@AggrCaseType)--@AggrCaseType
WHERE idfsCountry = 780000000



declare	@MonthlyReportHumanAggregateCase	table
(	idfAggrCase	BIGINT not null primary KEY,
  idfCaseObservation BIGINT,
  datStartDate datetime,
  idfVersion bigint
)


insert into	@MonthlyReportHumanAggregateCase
(	idfAggrCase,
  idfCaseObservation,
  datStartDate,
  idfVersion
)
select		a.idfAggrCase,
          a.idfCaseObservation,
		  a.datStartDate,
		  a.idfVersion
from		tlbAggrCase a
    left join	gisCountry c
    on			c.idfsCountry = a.idfsAdministrativeUnit
			    and c.idfsCountry = 780000000
    left join	gisRegion r
    on			r.idfsRegion = a.idfsAdministrativeUnit 
			    and r.idfsCountry = 780000000
    left join	gisRayon rr
    on			rr.idfsRayon = a.idfsAdministrativeUnit
			    and rr.idfsCountry = 780000000
    left join	gisSettlement s
    on			s.idfsSettlement = a.idfsAdministrativeUnit
			    and s.idfsCountry = 780000000

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
				    -- фильтр по региону, если задан регион
				    AND (r.idfsRegion = @RegionID OR @RegionID IS NULL)
			    )
		    or	(	@MinAdminLevel = 10089002 --'satRayon' 
				    and a.idfsAdministrativeUnit = rr.idfsRayon
				    -- фильтр по региону и/или району, если задан
				    AND (rr.idfsRayon = @RayonID OR @RayonID IS NULL) 
				    AND (rr.idfsRegion = @RegionID OR @RegionID IS NULL)
			    )
		    or	(	@MinAdminLevel = 10089004 --'satSettlement' 
				    and a.idfsAdministrativeUnit = s.idfsSettlement
				    -- фильтр по региону и/или району, если задан
				    AND (s.idfsRayon = @RayonID OR @RayonID IS NULL) 
				    AND (s.idfsRegion = @RegionID OR @RegionID IS NULL)

			    )
	      )
	      
	      


DECLARE	@MonthlyReportAggregateDiagnosisValuesTable	TABLE
(	idfsBaseReference	BIGINT NOT NULL PRIMARY KEY,
	intAge_0_1			INT NULL,	--7
	intAge_1_4			INT NULL, --8
	intAge_5_14			INT NULL, --9
	intAge_15_19		INT NULL, --10
	intAge_20_29		INT NULL, --11
	intAge_30_59		INT NULL, --12
	intAge_60_more		INT NULL, --13
	intLethalCases		INT NOT NULL
)

DECLARE 
    @FFP_Age_0_1 BIGINT,--7
    @FFP_Age_1_4 BIGINT, --8
    @FFP_Age_5_14 BIGINT, --9
    @FFP_Age_15_19 BIGINT, --10
    @FFP_Age_20_29 BIGINT, --11
    @FFP_Age_30_59 BIGINT, --12
    @FFP_Age_60_more BIGINT, --13
    @FFP_LethalCases BIGINT
    
    
SET @FFP_Age_0_1 = 1024220000000
SET @FFP_Age_1_4 = 1024470000000
SET @FFP_Age_5_14 = 1024740000000
SET @FFP_Age_15_19 = 1024510000000
SET @FFP_Age_20_29 = 1024660000000
SET @FFP_Age_30_59 = 1024700000000
SET @FFP_Age_60_more = 1024860000000
SET @FFP_LethalCases = 1027870000000

insert into	@MonthlyReportAggregateDiagnosisValuesTable
(	idfsBaseReference,
	intLethalCases
)
select		
      fdt.idfsDiagnosis,
			sum(CAST(IsNull(agp_LethalCases.varValue, 0)AS INT))

from		@MonthlyReportHumanAggregateCase fhac
-- Added by Olga (active matrixes)
  inner join	(
    dbo.ffParameter pD
    inner join	trtBaseReference br_pD
    on		br_pD.idfsBaseReference = pD.idfsParameter
			    and br_pD.idfsReferenceType = 19000066 --'rftParameter'
			    and br_pD.intRowStatus = 0
		    )
  on		pD.intRowStatus = 0
            and pD.idfsFormType = 10034012 --ftyHumanAggregate
			and pD.idfsSection is null
  inner join	(
    dbo.ffParameterType ptD
    inner join	trtBaseReference br_ptD
    on			br_ptD.idfsBaseReference = ptD.idfsParameterType
			    and br_ptD.idfsReferenceType = 19000071--'rftParameterType'
			    and br_ptD.intRowStatus = 0
		    )
  on		ptD.idfsParameterType = pD.idfsParameterType
		    and ptD.idfsReferenceType = 19000019--'rftDiagnosis'
		    and ptD.intRowStatus = 0
inner join	(
	tlbAggrMatrixVersionHeader h
	inner join	tlbAggrMatrixVersion v
	on			v.idfVersion = h.idfVersion
				and v.intRowStatus = 0
			)
on			h.blnIsActive = 1
			and h.idfsAggrCaseSection = 71190000000	-- Human Aggregate Case
			and (h.idfVersion = fhac.idfVersion or fhac.idfVersion is null)
			and (h.datStartDate <= fhac.datStartDate)
			and h.intRowStatus = 0
			and v.idfsParameter = pD.idfsParameter
			
left join	(
	tlbAggrMatrixVersionHeader h_later
	inner join	tlbAggrMatrixVersion v_later
	on			v_later.idfVersion = h_later.idfVersion
				and v_later.intRowStatus = 0
			)
on			h_later.blnIsActive = 1
			and h_later.idfsAggrCaseSection = 71190000000	-- Human Aggregate Case
			and fhac.idfVersion is null
			and (h_later.datStartDate <= fhac.datStartDate)
			and h_later.intRowStatus = 0
			and v_later.idfsParameter = pD.idfsParameter
			and (	h_later.datStartDate > h.datStartDate
					or	(	h_later.datStartDate = h.datStartDate
							and h_later.idfVersion > h.idfVersion
						)
				)
-- Added by Olga
			
			
inner join	@MonthlyReportDiagnosisTable fdt
on			fdt.blnIsAggregate = 1
		and SQL_VARIANT_PROPERTY(v.varValue, 'BaseType') = 'bigint'
        AND fdt.idfsDiagnosis = CAST(v.varValue AS BIGINT)

 
--	LethalCases		
left join	(
	dbo.tlbActivityParameters agp_LethalCases
	inner join	dbo.ffParameter p_LethalCases
	on			p_LethalCases.idfsParameter = agp_LethalCases.idfsParameter
				and p_LethalCases.intRowStatus = 0 
				and p_LethalCases.idfsParameter = @FFP_LethalCases
	inner join	trtBaseReference br_p_LethalCases
	on			br_p_LethalCases.idfsBaseReference = p_LethalCases.idfsParameter
				and br_p_LethalCases.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_LethalCases.intRowStatus = 0
			)
on			agp_LethalCases.idfObservation= fhac.idfCaseObservation
			and agp_LethalCases.idfRow = v.idfRow -- agpD.idfRow
			and agp_LethalCases.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_LethalCases.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

where		h_later.idfVersion is null

group by	fdt.idfsDiagnosis



declare	@MonthlyReportCaseTable	table
(	idfsDiagnosis			BIGINT  not null,
	idfCase				BIGINT not null primary key,
	intYear					int NULL
)

insert into	@MonthlyReportCaseTable
(	idfsDiagnosis,
	idfCase,
	intYear
)
select distinct
			fdt.idfsDiagnosis,
			ct.idfCase,
			case
				when	hc .idfsHumanAgeType =  10042003	--Years 
						and (hc.intPatientAge >= 0 and hc.intPatientAge <= 150)
					then	hc.intPatientAge
				when	hc.idfsHumanAgeType in (10042002 /*'hatMonth'*/, 10042001 /*'hatDays'*/)
						and (hc.intPatientAge >= 0)
					then 0
				else	null
			END
			
FROM tlbCase ct
    INNER JOIN tlbHumanCase hc
    ON ct.idfCase = hc.idfHumanCase
         AND ct.intRowStatus = 0 
         AND IsNull(IsNull(ct.idfsCaseStatus, hc.idfsInitialCaseStatus), 370000000) <> 370000000 --'casRefused'
         AND hc.idfsOutcome = 10770000000 /*outDied*/
     

    INNER JOIN	@MonthlyReportDiagnosisTable fdt
    ON			fdt.blnIsAggregate = 0
            AND fdt.idfsDiagnosis = ct.idfsShowDiagnosis

    INNER JOIN tlbParty pp
      INNER JOIN tlbHuman h
        LEFT OUTER JOIN tlbGeoLocation gl
        ON h.idfCurrentResidenceAddress = gl.idfGeoLocation
		AND gl.intRowStatus = 0
      ON pp.idfParty = h.idfHuman
    ON  pp.idfCase = ct.idfCase AND
        pp.intRowStatus = 0
    			
    LEFT OUTER JOIN  tlbGeoLocation cgl
    ON hc.idfPointGeoLocation = cgl.idfGeoLocation
        AND cgl.intRowStatus = 0
			
WHERE	
			(	@StartDate <= ISNULL(hc.datOnSetDate, IsNull(hc.datFinalDiagnosisDate, ISNULL(hc.datTentativeDiagnosisDate, ct.datEnteredDate)))
					and ISNULL(hc.datOnSetDate, IsNull(hc.datFinalDiagnosisDate, ISNULL(hc.datTentativeDiagnosisDate, ct.datEnteredDate))) < @FinishDate				
			) AND
		(	
			(	cgl.idfsRegion is not null /*and cgl.idfsRayon is not null*/ and @RegionID is not null
				and (cgl.idfsRegion = @RegionID)
				and (cgl.idfsRayon = @RayonID or @RayonID is null)
			)
			or	(	cgl.idfsRegion is null and gl.idfsRegion is not null /*and gl.idfsRayon is not null*/ and @RegionID is not null
					and (gl.idfsRegion = @RegionID)
					and (gl.idfsRayon = @RayonID or @RayonID is null)
				)
			or @RegionID is null
    )
    
    

--Total Age_0_1
declare	@MonthlyReportCaseDiagnosis_Age_0_1_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_0_1				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_Age_0_1_TotalValuesTable
(	idfsDiagnosis,
	intAge_0_1
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
where		(fct.intYear >= 0 and fct.intYear < 1)
group by	fct.idfsDiagnosis


--Total Age_1_4
declare	@MonthlyReportCaseDiagnosis_Age_1_4_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_1_4				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_Age_1_4_TotalValuesTable
(	idfsDiagnosis,
	intAge_1_4
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
where		(fct.intYear >= 1 and fct.intYear <= 4)
group by	fct.idfsDiagnosis


--Total Age_5_14
declare	@MonthlyReportCaseDiagnosis_Age_5_14_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_5_14				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_Age_5_14_TotalValuesTable
(	idfsDiagnosis,
	intAge_5_14
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
where		(fct.intYear >= 5 and fct.intYear <= 14)
group by	fct.idfsDiagnosis


--Total Age_15_19
declare	@MonthlyReportCaseDiagnosis_Age_15_19_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_15_19				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_Age_15_19_TotalValuesTable
(	idfsDiagnosis,
	intAge_15_19
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
where		(fct.intYear >= 15 and fct.intYear <= 19)
group by	fct.idfsDiagnosis


--Total Age_20_29
declare	@MonthlyReportCaseDiagnosis_Age_20_29_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_20_29				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_Age_20_29_TotalValuesTable
(	idfsDiagnosis,
	intAge_20_29
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
where		(fct.intYear >= 20 and fct.intYear <= 29)
group by	fct.idfsDiagnosis


--Total Age_30_59
declare	@MonthlyReportCaseDiagnosis_Age_30_59_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_30_59				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_Age_30_59_TotalValuesTable
(	idfsDiagnosis,
	intAge_30_59
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
where		(fct.intYear >= 30 and fct.intYear <= 59)
group by	fct.idfsDiagnosis


--Total Age_60_more
declare	@MonthlyReportCaseDiagnosis_Age_60_more_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_60_more				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_Age_60_more_TotalValuesTable
(	idfsDiagnosis,
	intAge_60_more
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
where		(fct.intYear >= 60)
group by	fct.idfsDiagnosis

--Total LethalCases
declare	@MonthlyReportCaseDiagnosis_LethalCases_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intLethalCases				INT not null
)

insert into	@MonthlyReportCaseDiagnosis_LethalCases_TotalValuesTable
(	idfsDiagnosis,
	intLethalCases
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@MonthlyReportCaseTable fct
group by	fct.idfsDiagnosis



--aggregate cases
update		fdt
set				
	fdt.intLethalCases = fadvt.intLethalCases		
from		@MonthlyReportDiagnosisTable fdt
    inner join	@MonthlyReportAggregateDiagnosisValuesTable fadvt
    on			fadvt.idfsBaseReference = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 1


--standard cases
update		fdt
set			fdt.intAge_0_1 = fcdvt.intAge_0_1
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_Age_0_1_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0

update		fdt
set			fdt.intAge_1_4 = fcdvt.intAge_1_4
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_Age_1_4_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0

update		fdt
set			fdt.intAge_5_14 = fcdvt.intAge_5_14
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_Age_5_14_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0
	
update		fdt
set			fdt.intAge_15_19 = fcdvt.intAge_15_19
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_Age_15_19_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0	
	
update		fdt
set			fdt.intAge_20_29 = fcdvt.intAge_20_29
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_Age_20_29_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
update		fdt
set			fdt.intAge_30_59 = fcdvt.intAge_30_59
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_Age_30_59_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
update		fdt
set			fdt.intAge_60_more = fcdvt.intAge_60_more
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_Age_60_more_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
	
	
update		fdt
set			fdt.intLethalCases = fcdvt.intLethalCases
from		@MonthlyReportDiagnosisTable fdt
inner join	@MonthlyReportCaseDiagnosis_LethalCases_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
	
	

	

DECLARE	@MonthlyReportDiagnosisGroupTable	TABLE
(	idfsDiagnosisGroup	BIGINT NOT NULL PRIMARY KEY,
	intAge_0_1			INT NOT NULL,	--7
	intAge_1_4			INT NOT NULL, --8
	intAge_5_14			INT NOT NULL, --9
	intAge_15_19		INT NOT NULL, --10
	intAge_20_29		INT NOT NULL, --11
	intAge_30_59		INT NOT NULL, --12
	intAge_60_more		INT NOT NULL, --13
	intLethalCases	INT NULL		
)
	
	
insert into	@MonthlyReportDiagnosisGroupTable
(	idfsDiagnosisGroup,
	intAge_0_1,	
	intAge_1_4, 
	intAge_5_14, 
	intAge_15_19, 
	intAge_20_29, 
	intAge_30_59, 
	intAge_60_more, 
	intLethalCases
)
select		dtg.idfsDiagnosisGroup,
	    sum(intAge_0_1),	
	    sum(intAge_1_4), 
	    sum(intAge_5_14), 
	    sum(intAge_15_19), 
	    sum(intAge_20_29), 
	    sum(intAge_30_59), 
	    sum(intAge_60_more), 
	    sum(intLethalCases)
from		@MonthlyReportDiagnosisTable fdt
inner join	dbo.trtDiagnosisToGroupForReportType dtg
on			dtg.idfsDiagnosis = fdt.idfsDiagnosis AND
dtg.idfsSummaryReportType = @idfsSummaryReportType AND
dtg.idfsDiagnosisGroup = 959290000000 /*Fatal cases of infectious diseases*/
group by	dtg.idfsDiagnosisGroup	
	
	
declare	@SpecifyDiadnoses	nvarchar(MAX)
set	@SpecifyDiadnoses = N''
select	@SpecifyDiadnoses = IsNull(RTrim(r.[Name]) + N' ', N'')
from	fnReference(@LangID, 19000132) r	-- Additional report Text
where	r.strDefault = N'Specify disease(s):'

declare	@Separator	nvarchar(10)
set	@Separator = N''

select		@SpecifyDiadnoses = @SpecifyDiadnoses + @Separator + d_ref.[Name],
			@Separator = N', '
from	dbo.trtDiagnosisToGroupForReportType	 dtg
inner join	@MonthlyReportDiagnosisTable fdt
on			fdt.idfsDiagnosis = dtg.idfsDiagnosis
			and fdt.intLethalCases > 0
inner join	fnReference(@LangID, 19000019 /*rftDiagnosis*/) d_ref
on			d_ref.idfsReference = fdt.idfsDiagnosis
where		dtg.idfsDiagnosisGroup = 959290000000 --'dgmFatalCasesOfInfectiousDiseases'


	
	


	

INSERT INTO @ReportTable (
	strICD10,
	intAge_0_1,
	intAge_1_4,
	intAge_5_14,
	intAge_15_19,
	intAge_20_29,
	intAge_30_59,
	intAge_60_more,
  intLethalCases,
	strSpecifyDiseases)
SELECT 
    NULL,
    fdt.intAge_0_1,	
    fdt.intAge_1_4, 
    fdt.intAge_5_14, 
    fdt.intAge_15_19, 
    fdt.intAge_20_29, 
    fdt.intAge_30_59, 
    fdt.intAge_60_more, 
    fdt.intLethalCases,
    @SpecifyDiadnoses
from	@MonthlyReportDiagnosisGroupTable fdt	
	
	


	
select 
	*
from @ReportTable
	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

