 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumAnnualInfectiousDisease]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumAnnualInfectiousDisease]


GO

--##SUMMARY Select data for Reportable Infectious Diseases (Annual Form IV03).
--##REMARKS Author: 
--##REMARKS Create date: 10.01.2011 

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepHumAnnualInfectiousDisease 'en', '2010-01-01', '2010-02-01',  37050000000, 3450000000

*/

CREATE  PROCEDURE [dbo].[spRepHumAnnualInfectiousDisease]
	(
		@LangID		AS NVARCHAR(10), 
		@StartDate	AS DATETIME,	 
		@FinishDate	AS DATETIME,
		@RegionID	AS BIGINT = NULL,
		@RayonID	AS BIGINT = NULL
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/GG/Reports/Specification for report development - Intermediate Report by Annual Form 03 Human GG 1.0.doc"
-- by number marked red at screen form prototype 

DECLARE	@ReportTable	TABLE
(	idfsBaseReference	BIGINT NOT NULL PRIMARY KEY,
	strDiseaseName		NVARCHAR(300) COLLATE database_default NOT NULL, --52
	strICD10			NVARCHAR(200) COLLATE database_default NULL,	--53
	intAge_0_1			INT NOT NULL,	--7
	intAge_1_4			INT NOT NULL, --8
	intAge_5_14			INT NOT NULL, --9
	intAge_15_19		INT NOT NULL, --10
	intAge_20_29		INT NOT NULL, --11
	intAge_30_59		INT NOT NULL, --12
	intAge_60_more		INT NOT NULL, --13
	intTotal			INT NOT NULL, --14
	intLabTested		INT NULL,		--15
	intLabConfirmed		INT NULL,		--18
	intTotalConfirmed	INT NULL,		--21
	strNameOfRespondent NVARCHAR(200) COLLATE database_default NULL, --1
	strActualAddress	NVARCHAR(200) COLLATE database_default NULL, --2
	strTelephone		NVARCHAR(200) COLLATE database_default NULL, --3
	intOrder			INT NOT NULL
)

DECLARE @idfsSummaryReportType BIGINT
DECLARE @idfsLanguage BIGINT
DECLARE @strNameOfRespondent NVARCHAR(200)
DECLARE @strActualAddress NVARCHAR(200)
DECLARE @strTelephone  NVARCHAR(200)
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
			and   tlbGeoLocation.intRowStatus = 0
      ON tstSite.idfOffice = tlbOffice.idfOffice
			and tlbOffice.intRowStatus = 0

  WHERE tstSite.intFlags = 1 AND tstSite.intRowStatus = 0
  
  --IF @idfsSite IS NULL SET @idfsSite = dbo.fnSiteID()
END


SELECT 
    @strActualAddress = dbo.fnAddressString(@LangID, tlbOffice.idfLocation),
    @strTelephone = tlbOffice.strContactPhone,
    @strNameOfRespondent = ISNULL(trtStringNameTranslation.strTextString, trtBaseReference.strDefault)
FROM tlbOffice
    INNER JOIN tstSite
    ON tlbOffice.idfOffice = tstSite.idfOffice
    AND tstSite.intRowStatus = 0

    INNER JOIN trtBaseReference
    ON tlbOffice.idfsOfficeName = trtBaseReference.idfsBaseReference AND
    trtBaseReference.intRowStatus = 0

    LEFT OUTER JOIN trtStringNameTranslation
    ON trtBaseReference.idfsBaseReference = trtStringNameTranslation.idfsBaseReference
    AND trtStringNameTranslation.idfsLanguage = @idfsLanguage 
    AND trtStringNameTranslation.intRowStatus = 0

WHERE tstSite.idfsSite = @idfsSite AND tlbOffice.intRowStatus = 0



SET @idfsSummaryReportType = 10290002 /*Report on Cases of Annualy Reportable Infectious Diseases*/



INSERT INTO @ReportTable (
	idfsBaseReference,
	strDiseaseName,
	strICD10,
	intAge_0_1,
	intAge_1_4,
	intAge_5_14,
	intAge_15_19,
	intAge_20_29,
	intAge_30_59,
	intAge_60_more,
	intTotal,
	intLabTested,
	intLabConfirmed,
	intTotalConfirmed,
	strNameOfRespondent,
	strActualAddress,
	strTelephone,
	intOrder
) 
SELECT 
  rr.idfsDiagnosisOrGroup,
  ISNULL(ISNULL(snt1.strTextString, br1.strDefault) +  ' ','')  +ISNULL(snt.strTextString, br.strDefault)  ,
  CASE WHEN rr.idfsDiagnosisOrGroup IN (786120000000, 785420000000) THEN NULL ELSE ISNULL(d.strIDC10, dg.strCode) END ,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  @strNameOfRespondent,
  @strActualAddress,
  @strTelephone,
  rr.intRowOrder

  
FROM   dbo.trtReportRows rr
    LEFT JOIN trtBaseReference br
        LEFT JOIN trtStringNameTranslation snt
        ON br.idfsBaseReference = snt.idfsBaseReference
        AND snt.idfsLanguage = @idfsLanguage

        LEFT OUTER JOIN trtDiagnosis d
        ON br.idfsBaseReference = d.idfsDiagnosis
        
        LEFT OUTER JOIN trtDiagnosisGroup dg
        ON br.idfsBaseReference = dg.idfsDiagnosisGroup
    ON rr.idfsDiagnosisOrGroup = br.idfsBaseReference
   
    LEFT OUTER JOIN trtBaseReference br1
        LEFT OUTER JOIN trtStringNameTranslation snt1
        ON br1.idfsBaseReference = snt1.idfsBaseReference
        AND snt1.idfsLanguage = @idfsLanguage
    ON rr.idfsReportAdditionalText = br1.idfsBaseReference
    

WHERE rr.idfsSummaryReportType = @idfsSummaryReportType
ORDER BY rr.intRowOrder


DECLARE	@Form1DiagnosisTable	TABLE
(	idfsDiagnosis	BIGINT NOT NULL PRIMARY KEY,
  blnIsAggregate BIT,
	intAge_0_1			INT NOT NULL,	--7
	intAge_1_4			INT NOT NULL, --8
	intAge_5_14			INT NOT NULL, --9
	intAge_15_19		INT NOT NULL, --10
	intAge_20_29		INT NOT NULL, --11
	intAge_30_59		INT NOT NULL, --12
	intAge_60_more		INT NOT NULL, --13
	intTotal			INT NOT NULL, --14
	intLabTested		INT NULL,		--15
	intLabConfirmed		INT NULL,		--18
	intTotalConfirmed	INT NULL		--21
)

INSERT INTO @Form1DiagnosisTable (
	idfsDiagnosis,
  blnIsAggregate,
	intAge_0_1,
	intAge_1_4,
	intAge_5_14,
	intAge_15_19,
	intAge_20_29,
	intAge_30_59,
	intAge_60_more,
	intTotal,
	intLabTested,
	intLabConfirmed,
	intTotalConfirmed
) 
SELECT 
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
  0,
  0,
  0,
  0

FROM dbo.trtDiagnosisToGroupForReportType fdt
    INNER JOIN trtDiagnosis trtd
    ON trtd.idfsDiagnosis = fdt.idfsDiagnosis AND
    trtd.intRowStatus = 0
WHERE  fdt.idfsSummaryReportType = @idfsSummaryReportType 
       AND  fdt.intRowStatus = 0
       
INSERT INTO @Form1DiagnosisTable (
	idfsDiagnosis,
  blnIsAggregate,
	intAge_0_1,
	intAge_1_4,
	intAge_5_14,
	intAge_15_19,
	intAge_20_29,
	intAge_30_59,
	intAge_60_more,
	intTotal,
	intLabTested,
	intLabConfirmed,
	intTotalConfirmed
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
       SELECT * FROM @Form1DiagnosisTable
       WHERE idfsDiagnosis = rr.idfsDiagnosisOrGroup
       )      



       
       
       

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



declare	@Form1HumanAggregateCase	table
(	idfAggrCase	BIGINT not null primary KEY,
  idfCaseObservation BIGINT,
  datStartDate datetime,
  idfVersion bigint
)


insert into	@Form1HumanAggregateCase
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
	      
	      


DECLARE	@Form1AggregateDiagnosisValuesTable	TABLE
(	idfsBaseReference	BIGINT NOT NULL PRIMARY KEY,
	intAge_0_1			INT NOT NULL,	--7
	intAge_1_4			INT NOT NULL, --8
	intAge_5_14			INT NOT NULL, --9
	intAge_15_19		INT NOT NULL, --10
	intAge_20_29		INT NOT NULL, --11
	intAge_30_59		INT NOT NULL, --12
	intAge_60_more		INT NOT NULL, --13
	intTotal			INT NOT NULL, --14
	intLabTested		INT NULL,		--15
	intLabConfirmed		INT NULL,		--18
	intTotalConfirmed	INT NULL		--21
)

DECLARE 
    @FFP_Age_0_1 BIGINT,--7
    @FFP_Age_1_4 BIGINT, --8
    @FFP_Age_5_14 BIGINT, --9
    @FFP_Age_15_19 BIGINT, --10
    @FFP_Age_20_29 BIGINT, --11
    @FFP_Age_30_59 BIGINT, --12
    @FFP_Age_60_more BIGINT, --13
    @FFP_Total BIGINT, --14
    @FFP_LabTested BIGINT,		--15
    @FFP_LabConfirmed BIGINT,		--18
    @FFP_TotalConfirmed BIGINT --21
    
    
SET @FFP_Age_0_1 = 1024220000000
SET @FFP_Age_1_4 = 1024470000000
SET @FFP_Age_5_14 = 1024740000000
SET @FFP_Age_15_19 = 1024510000000
SET @FFP_Age_20_29 = 1024660000000
SET @FFP_Age_30_59 = 1024700000000
SET @FFP_Age_60_more = 1024860000000
SET @FFP_Total = 1127720000000
SET @FFP_LabTested  = 1023700000000
SET @FFP_LabConfirmed = 1027830000000
SET @FFP_TotalConfirmed = 1027830000000 

insert into	@Form1AggregateDiagnosisValuesTable
(	idfsBaseReference,
	intAge_0_1,	--7
	intAge_1_4, --8
	intAge_5_14, --9
	intAge_15_19, --10
	intAge_20_29, --11
	intAge_30_59, --12
	intAge_60_more, --13
	intTotal, --14
	intLabTested,		--15
	intLabConfirmed,		--18
	intTotalConfirmed--21
)
select		
      fdt.idfsDiagnosis      ,
			sum(CAST(IsNull(agp_Age_0_1.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_Age_1_4.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_Age_5_14.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_Age_15_19.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_Age_20_29.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_Age_30_59.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_Age_60_more.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_Total.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_LabTested.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_LabConfirmed.varValue, 0)AS INT)),
			sum(CAST(IsNull(agp_TotalConfirmed.varValue, 0)AS INT))

from		@Form1HumanAggregateCase fhac
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
-- Commented By Olga
--inner join	(
--  dbo.tlbActivityParameters agpD
--  inner join	(
--    dbo.ffParameter pD
--    inner join	trtBaseReference br_pD
--    on		br_pD.idfsBaseReference = pD.idfsParameter
--			    and br_pD.idfsReferenceType = 19000066 --'rftParameter'
--			    and br_pD.intRowStatus = 0
--		    )
--  on			pD.idfsParameter = agpD.idfsParameter and pD.intRowStatus = 0
--            and pD.idfsFormType = 10034012 --ftyHumanAggregate
--  inner join	(
--    dbo.ffParameterType ptD
--    inner join	trtBaseReference br_ptD
--    on			br_ptD.idfsBaseReference = ptD.idfsParameterType
--			    and br_ptD.idfsReferenceType = 19000071--'rftParameterType'
--			    and br_ptD.intRowStatus = 0
--		    )
--  on			ptD.idfsParameterType = pD.idfsParameterType
--		    and ptD.idfsReferenceType = 19000019--'rftDiagnosis'
--		    and ptD.intRowStatus = 0
--	    )
--on			agpD.idfObservation= fhac.idfCaseObservation
--	    and agpD.intRowStatus = 0
--			
--			
--inner join	@Form1DiagnosisTable fdt
--on			fdt.blnIsAggregate = 1
--        AND fdt.idfsDiagnosis = CAST(agpD.varValue AS BIGINT)  
-- commented by Olga			
			
			
inner join	@Form1DiagnosisTable fdt
on			fdt.blnIsAggregate = 1
		and SQL_VARIANT_PROPERTY(v.varValue, 'BaseType') = 'bigint'
        AND fdt.idfsDiagnosis = CAST(v.varValue AS BIGINT)
        
        
        
        
--Age_0_1
left join	(
	dbo.tlbActivityParameters agp_Age_0_1
	inner join	dbo.ffParameter p_Age_0_1
	on			p_Age_0_1.idfsParameter = agp_Age_0_1.idfsParameter
				and p_Age_0_1.intRowStatus = 0 
				and p_Age_0_1.idfsParameter = @FFP_Age_0_1
	inner join	trtBaseReference br_p_Age_0_1
	on			br_p_Age_0_1.idfsBaseReference = p_Age_0_1.idfsParameter
				and br_p_Age_0_1.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_0_1.intRowStatus = 0
			)
on			agp_Age_0_1.idfObservation = fhac.idfCaseObservation
			and agp_Age_0_1.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_0_1.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_0_1.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
			
--	Age_1_4		
left join	(
	dbo.tlbActivityParameters agp_Age_1_4
	inner join	dbo.ffParameter p_Age_1_4
	on			p_Age_1_4.idfsParameter = agp_Age_1_4.idfsParameter
				and p_Age_1_4.intRowStatus = 0 
				and p_Age_1_4.idfsParameter = @FFP_Age_1_4
	inner join	trtBaseReference br_p_Age_1_4
	on			br_p_Age_1_4.idfsBaseReference = p_Age_1_4.idfsParameter
				and br_p_Age_1_4.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_1_4.intRowStatus = 0
			)
on			agp_Age_1_4.idfObservation= fhac.idfCaseObservation
			and agp_Age_1_4.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_1_4.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_1_4.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
			

--	Age_5_14		
left join	(
	dbo.tlbActivityParameters agp_Age_5_14
	inner join	dbo.ffParameter p_Age_5_14
	on			p_Age_5_14.idfsParameter = agp_Age_5_14.idfsParameter
				and p_Age_5_14.intRowStatus = 0 
				and p_Age_5_14.idfsParameter = @FFP_Age_5_14
	inner join	trtBaseReference br_p_Age_5_14
	on			br_p_Age_5_14.idfsBaseReference = p_Age_5_14.idfsParameter
				and br_p_Age_5_14.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_5_14.intRowStatus = 0
			)
on			agp_Age_5_14.idfObservation= fhac.idfCaseObservation
			and agp_Age_5_14.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_5_14.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_5_14.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

--	Age_15_19		
left join	(
	dbo.tlbActivityParameters agp_Age_15_19
	inner join	dbo.ffParameter p_Age_15_19
	on			p_Age_15_19.idfsParameter = agp_Age_15_19.idfsParameter
				and p_Age_15_19.intRowStatus = 0 
				and p_Age_15_19.idfsParameter = @FFP_Age_15_19
	inner join	trtBaseReference br_p_Age_15_19
	on			br_p_Age_15_19.idfsBaseReference = p_Age_15_19.idfsParameter
				and br_p_Age_15_19.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_15_19.intRowStatus = 0
			)
on			agp_Age_15_19.idfObservation= fhac.idfCaseObservation
			and agp_Age_15_19.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_15_19.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_15_19.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	Age_20_29		
left join	(
	dbo.tlbActivityParameters agp_Age_20_29
	inner join	dbo.ffParameter p_Age_20_29
	on			p_Age_20_29.idfsParameter = agp_Age_20_29.idfsParameter
				and p_Age_20_29.intRowStatus = 0 
				and p_Age_20_29.idfsParameter = @FFP_Age_20_29
	inner join	trtBaseReference br_p_Age_20_29
	on			br_p_Age_20_29.idfsBaseReference = p_Age_20_29.idfsParameter
				and br_p_Age_20_29.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_20_29.intRowStatus = 0
			)
on			agp_Age_20_29.idfObservation= fhac.idfCaseObservation
			and agp_Age_20_29.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_20_29.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_20_29.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	Age_30_59		
left join	(
	dbo.tlbActivityParameters agp_Age_30_59
	inner join	dbo.ffParameter p_Age_30_59
	on			p_Age_30_59.idfsParameter = agp_Age_30_59.idfsParameter
				and p_Age_30_59.intRowStatus = 0 
				and p_Age_30_59.idfsParameter = @FFP_Age_30_59
	inner join	trtBaseReference br_p_Age_30_59
	on			br_p_Age_30_59.idfsBaseReference = p_Age_30_59.idfsParameter
				and br_p_Age_30_59.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_30_59.intRowStatus = 0
			)
on			agp_Age_30_59.idfObservation= fhac.idfCaseObservation
			and agp_Age_30_59.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_30_59.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_30_59.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

--	Age_60_more		
left join	(
	dbo.tlbActivityParameters agp_Age_60_more
	inner join	dbo.ffParameter p_Age_60_more
	on			p_Age_60_more.idfsParameter = agp_Age_60_more.idfsParameter
				and p_Age_60_more.intRowStatus = 0 
				and p_Age_60_more.idfsParameter = @FFP_Age_60_more
	inner join	trtBaseReference br_p_Age_60_more
	on			br_p_Age_60_more.idfsBaseReference = p_Age_60_more.idfsParameter
				and br_p_Age_60_more.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_60_more.intRowStatus = 0
			)
on			agp_Age_60_more.idfObservation= fhac.idfCaseObservation
			and agp_Age_60_more.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_60_more.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_60_more.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	Total		
left join	(
	dbo.tlbActivityParameters agp_Total
	inner join	dbo.ffParameter p_Total
	on			p_Total.idfsParameter = agp_Total.idfsParameter
				and p_Total.intRowStatus = 0 
				and p_Total.idfsParameter = @FFP_Total
	inner join	trtBaseReference br_p_Total
	on			br_p_Total.idfsBaseReference = p_Total.idfsParameter
				and br_p_Total.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Total.intRowStatus = 0
			)
on			agp_Total.idfObservation= fhac.idfCaseObservation
			and agp_Total.idfRow = v.idfRow -- agpD.idfRow
			and agp_Total.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Total.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	LabTested		
left join	(
	dbo.tlbActivityParameters agp_LabTested
	inner join	dbo.ffParameter p_LabTested
	on			p_LabTested.idfsParameter = agp_LabTested.idfsParameter
				and p_LabTested.intRowStatus = 0 
				and p_LabTested.idfsParameter = @FFP_LabTested
	inner join	trtBaseReference br_p_LabTested
	on			br_p_LabTested.idfsBaseReference = p_LabTested.idfsParameter
				and br_p_LabTested.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_LabTested.intRowStatus = 0
			)
on			agp_LabTested.idfObservation = fhac.idfCaseObservation
			and agp_LabTested.idfRow = v.idfRow -- agpD.idfRow
			and agp_LabTested.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_LabTested.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	LabConfirmed		
left join	(
	dbo.tlbActivityParameters agp_LabConfirmed
	inner join	dbo.ffParameter p_LabConfirmed
	on			p_LabConfirmed.idfsParameter = agp_LabConfirmed.idfsParameter
				and p_LabConfirmed.intRowStatus = 0 
				and p_LabConfirmed.idfsParameter = @FFP_LabConfirmed
	inner join	trtBaseReference br_p_LabConfirmed
	on			br_p_LabConfirmed.idfsBaseReference = p_LabConfirmed.idfsParameter
				and br_p_LabConfirmed.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_LabConfirmed.intRowStatus = 0
			)
on			agp_LabConfirmed.idfObservation = fhac.idfCaseObservation
			and agp_LabConfirmed.idfRow = v.idfRow -- agpD.idfRow
			and agp_LabConfirmed.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_LabConfirmed.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')



--	TotalConfirmed		
left join	(
	dbo.tlbActivityParameters agp_TotalConfirmed
	inner join	dbo.ffParameter p_TotalConfirmed
	on			p_TotalConfirmed.idfsParameter = agp_TotalConfirmed.idfsParameter
				and p_TotalConfirmed.intRowStatus = 0 
				and p_TotalConfirmed.idfsParameter = @FFP_TotalConfirmed
	inner join	trtBaseReference br_p_TotalConfirmed
	on			br_p_TotalConfirmed.idfsBaseReference = p_TotalConfirmed.idfsParameter
				and br_p_TotalConfirmed.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_TotalConfirmed.intRowStatus = 0
			)
on			agp_TotalConfirmed.idfObservation = fhac.idfCaseObservation
			and agp_TotalConfirmed.idfRow = v.idfRow -- agpD.idfRow
			and agp_TotalConfirmed.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_TotalConfirmed.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
where		h_later.idfVersion is null

group by	fdt.idfsDiagnosis



declare	@Form1CaseTable	table
(	idfsDiagnosis			BIGINT  not null,
	idfCase				BIGINT not null primary key,
	intYear					int NULL,
	blnLabTested  BIT,
	blnLabConfirmed   BIT,
	blnLabEpiConfirmed BIT
)

insert into	@Form1CaseTable
(	idfsDiagnosis,
	idfCase,
	intYear,
	blnLabTested,
	blnLabConfirmed,
	blnLabEpiConfirmed
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
			END,
			0,
			CASE 
			  WHEN hc.blnLabDiagBasis = 1 AND ct.idfsCaseStatus = 350000000 /*Confirmed Case*/ 
			  THEN 1 ELSE 0 
			END,
			CASE 
			  WHEN CAST(hc.blnLabDiagBasis AS INT) + CAST(hc.blnEpiDiagBasis AS INT) >0  AND 
			       ct.idfsCaseStatus = 350000000 /*Confirmed Case*/ 
			  THEN 1 ELSE 0 
			END
			
FROM tlbCase ct
    INNER JOIN tlbHumanCase hc
    ON ct.idfCase = hc.idfHumanCase
         AND ct.intRowStatus = 0 
         AND IsNull(IsNull(ct.idfsCaseStatus, hc.idfsInitialCaseStatus), 370000000) <> 370000000 --'casRefused'
     

    INNER JOIN	@Form1DiagnosisTable fdt
    ON			fdt.blnIsAggregate = 0
            AND fdt.idfsDiagnosis = ct.idfsShowDiagnosis

    INNER JOIN tlbParty pp
      INNER JOIN tlbHuman h
        LEFT OUTER JOIN tlbGeoLocation gl
        ON h.idfCurrentResidenceAddress = gl.idfGeoLocation
		and gl.intRowStatus = 0
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
    
    
UPDATE fct
SET fct.blnLabTested = 1
FROM @Form1CaseTable fct
    INNER JOIN tlbParty p
        INNER JOIN tlbMaterial m
            INNER JOIN tlbTesting t
            ON m.idfTesting = t.idfTesting AND
            t.intRowStatus = 0 AND
            t.idfsTestStatus = 0
        ON p.idfParty = m.idfParty AND 
            m.intRowStatus = 10001001 /*acsCompleted*/
    ON p.idfCase = fct.idfCase AND
        p.intRowStatus = 0

--Total
declare	@Form1CaseDiagnosisTotalValuesTable	table
(	idfsDiagnosis		BIGINT not null primary key,
	intTotal				INT not null
)

insert into	@Form1CaseDiagnosisTotalValuesTable
(	idfsDiagnosis,
	intTotal
)
SELECT fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
group by	fct.idfsDiagnosis



--Total Age_0_1
declare	@Form1CaseDiagnosis_Age_0_1_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_0_1				INT not null
)

insert into	@Form1CaseDiagnosis_Age_0_1_TotalValuesTable
(	idfsDiagnosis,
	intAge_0_1
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 0 and fct.intYear < 1)
group by	fct.idfsDiagnosis


--Total Age_1_4
declare	@Form1CaseDiagnosis_Age_1_4_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_1_4				INT not null
)

insert into	@Form1CaseDiagnosis_Age_1_4_TotalValuesTable
(	idfsDiagnosis,
	intAge_1_4
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 1 and fct.intYear <= 4)
group by	fct.idfsDiagnosis


--Total Age_5_14
declare	@Form1CaseDiagnosis_Age_5_14_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_5_14				INT not null
)

insert into	@Form1CaseDiagnosis_Age_5_14_TotalValuesTable
(	idfsDiagnosis,
	intAge_5_14
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 5 and fct.intYear <= 14)
group by	fct.idfsDiagnosis


--Total Age_15_19
declare	@Form1CaseDiagnosis_Age_15_19_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_15_19				INT not null
)

insert into	@Form1CaseDiagnosis_Age_15_19_TotalValuesTable
(	idfsDiagnosis,
	intAge_15_19
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 15 and fct.intYear <= 19)
group by	fct.idfsDiagnosis


--Total Age_20_29
declare	@Form1CaseDiagnosis_Age_20_29_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_20_29				INT not null
)

insert into	@Form1CaseDiagnosis_Age_20_29_TotalValuesTable
(	idfsDiagnosis,
	intAge_20_29
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 20 and fct.intYear <= 29)
group by	fct.idfsDiagnosis


--Total Age_30_59
declare	@Form1CaseDiagnosis_Age_30_59_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_30_59				INT not null
)

insert into	@Form1CaseDiagnosis_Age_30_59_TotalValuesTable
(	idfsDiagnosis,
	intAge_30_59
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 30 and fct.intYear <= 59)
group by	fct.idfsDiagnosis


--Total Age_60_more
declare	@Form1CaseDiagnosis_Age_60_more_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_60_more				INT not null
)

insert into	@Form1CaseDiagnosis_Age_60_more_TotalValuesTable
(	idfsDiagnosis,
	intAge_60_more
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 60)
group by	fct.idfsDiagnosis


--Total LabTested 
declare	@Form1CaseDiagnosis_LabTested_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intLabTested				INT not null
)

insert into	@Form1CaseDiagnosis_LabTested_TotalValuesTable
(	idfsDiagnosis,
	intLabTested
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		fct.blnLabTested = 1
group by	fct.idfsDiagnosis



--Total LabConfirmed 
declare	@Form1CaseDiagnosis_LabConfirmed_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intLabConfirmed				INT not null
)

insert into	@Form1CaseDiagnosis_LabConfirmed_TotalValuesTable
(	idfsDiagnosis,
	intLabConfirmed
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		fct.blnLabConfirmed = 1
group by	fct.idfsDiagnosis

--Total TotalConfirmed
declare	@Form1CaseDiagnosis_TotalConfirmed_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intTotalConfirmed				INT not null
)

insert into	@Form1CaseDiagnosis_TotalConfirmed_TotalValuesTable
(	idfsDiagnosis,
	intTotalConfirmed
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		fct.blnLabEpiConfirmed = 1
group by	fct.idfsDiagnosis

--aggregate cases
update		fdt
set				
	fdt.intAge_0_1 = fadvt.intAge_0_1,
	fdt.intAge_1_4 = fadvt.intAge_1_4,
	fdt.intAge_5_14 = fadvt.intAge_5_14,	
	fdt.intAge_15_19 = fadvt.intAge_15_19,	
	fdt.intAge_20_29 = fadvt.intAge_20_29,	
	fdt.intAge_30_59 = fadvt.intAge_30_59,
	fdt.intAge_60_more = fadvt.intAge_60_more,	
	fdt.intTotal = fadvt.intTotal,	
	fdt.intLabTested = fadvt.intLabTested,	
	fdt.intLabConfirmed = fadvt.intLabConfirmed,	
	fdt.intTotalConfirmed = fadvt.intTotalConfirmed		
from		@Form1DiagnosisTable fdt
    inner join	@Form1AggregateDiagnosisValuesTable fadvt
    on			fadvt.idfsBaseReference = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 1


--standard cases
update		fdt
set			fdt.intTotal = fcdvt.intTotal
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosisTotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0

update		fdt
set			fdt.intAge_0_1 = fcdvt.intAge_0_1
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_0_1_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0

update		fdt
set			fdt.intAge_1_4 = fcdvt.intAge_1_4
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_1_4_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0

update		fdt
set			fdt.intAge_5_14 = fcdvt.intAge_5_14
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_5_14_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0
	
update		fdt
set			fdt.intAge_15_19 = fcdvt.intAge_15_19
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_15_19_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0	
	
update		fdt
set			fdt.intAge_20_29 = fcdvt.intAge_20_29
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_20_29_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
update		fdt
set			fdt.intAge_30_59 = fcdvt.intAge_30_59
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_30_59_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
update		fdt
set			fdt.intAge_60_more = fcdvt.intAge_60_more
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_60_more_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
	
update		fdt
set			fdt.intLabTested = fcdvt.intLabTested
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_LabTested_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
	
update		fdt
set			fdt.intLabConfirmed = fcdvt.intLabConfirmed
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_LabConfirmed_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
	
update		fdt
set			fdt.intTotalConfirmed = fcdvt.intTotalConfirmed
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_TotalConfirmed_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0		
	
	
	

	

DECLARE	@Form1DiagnosisGroupTable	TABLE
(	idfsDiagnosisGroup	BIGINT NOT NULL PRIMARY KEY,
	intAge_0_1			INT NOT NULL,	--7
	intAge_1_4			INT NOT NULL, --8
	intAge_5_14			INT NOT NULL, --9
	intAge_15_19		INT NOT NULL, --10
	intAge_20_29		INT NOT NULL, --11
	intAge_30_59		INT NOT NULL, --12
	intAge_60_more		INT NOT NULL, --13
	intTotal			INT NOT NULL, --14
	intLabTested		INT NULL,		--15
	intLabConfirmed		INT NULL,		--18
	intTotalConfirmed	INT NULL		--21
)
	
	
insert into	@Form1DiagnosisGroupTable
(	idfsDiagnosisGroup,
	intAge_0_1,	
	intAge_1_4, 
	intAge_5_14, 
	intAge_15_19, 
	intAge_20_29, 
	intAge_30_59, 
	intAge_60_more, 
	intTotal, 
	intLabTested,		
	intLabConfirmed,		
	intTotalConfirmed
)
select		dtg.idfsDiagnosisGroup,
	    sum(intAge_0_1),	
	    sum(intAge_1_4), 
	    sum(intAge_5_14), 
	    sum(intAge_15_19), 
	    sum(intAge_20_29), 
	    sum(intAge_30_59), 
	    sum(intAge_60_more), 
	    sum(intTotal), 
	    sum(intLabTested),		
	    sum(intLabConfirmed),		
	    sum(intTotalConfirmed)
from		@Form1DiagnosisTable fdt
inner join	dbo.trtDiagnosisToGroupForReportType dtg
on			dtg.idfsDiagnosis = fdt.idfsDiagnosis AND
dtg.idfsSummaryReportType = @idfsSummaryReportType
group by	dtg.idfsDiagnosisGroup	
	
	
update		ft
set	
  ft.intAge_0_1 = fdt.intAge_0_1,	
	ft.intAge_1_4 = fdt.intAge_1_4, 
	ft.intAge_5_14 = fdt.intAge_5_14, 
	ft.intAge_15_19 = fdt.intAge_15_19, 
	ft.intAge_20_29 = fdt.intAge_20_29, 
	ft.intAge_30_59 = fdt.intAge_30_59, 
	ft.intAge_60_more = fdt.intAge_60_more, 
	ft.intTotal = fdt.intTotal, 
	ft.intLabTested = 
	  CASE 
	      WHEN  fdt.idfsDiagnosis = 785670000000 /*Neonatal Tetanus*/ THEN NULL
	      WHEN  fdt.idfsDiagnosis = 786250000000 /*Tetanus*/ THEN NULL
	      ELSE fdt.intLabTested
	  END,		
	ft.intLabConfirmed = 
		  CASE 
	      WHEN  fdt.idfsDiagnosis = 785670000000 /*Neonatal Tetanus*/ THEN NULL
	      WHEN  fdt.idfsDiagnosis = 786250000000 /*Tetanus*/ THEN NULL
	      ELSE fdt.intLabConfirmed
	  END,		
	ft.intTotalConfirmed = 
		  CASE 
	      WHEN  fdt.idfsDiagnosis IN (
            784700000000,	--Cholera
            786100000000, --Scarlet fever
            786490000000, --Varicella
            785760000000  --Other viral hepatitis
	      ) THEN fdt.intTotalConfirmed
	      ELSE NULL
	  END	
from		@ReportTable ft
inner join	@Form1DiagnosisTable fdt
on			fdt.idfsDiagnosis = ft.idfsBaseReference	
	
	
update		ft
set	
  ft.intAge_0_1 = fdgt.intAge_0_1,	
	ft.intAge_1_4 = fdgt.intAge_1_4, 
	ft.intAge_5_14 = fdgt.intAge_5_14, 
	ft.intAge_15_19 = fdgt.intAge_15_19, 
	ft.intAge_20_29 = fdgt.intAge_20_29, 
	ft.intAge_30_59 = fdgt.intAge_30_59, 
	ft.intAge_60_more = fdgt.intAge_60_more, 
	ft.intTotal = fdgt.intTotal, 
	ft.intLabTested = fdgt.intLabTested,		
	ft.intLabConfirmed = fdgt.intLabConfirmed,		
	ft.intTotalConfirmed = 
	  CASE WHEN fdgt.idfsDiagnosisGroup = 956900000000 /*Arthropods transmitted viral fevers and viral hemorrhagic fevers*/
	      THEN NULL 
	      ELSE fdgt.intTotalConfirmed 
	  END 
from		@ReportTable ft
inner join	@Form1DiagnosisGroupTable fdgt
on			fdgt.idfsDiagnosisGroup = ft.idfsBaseReference		
	
	
	
	
SELECT * 
FROM @ReportTable
ORDER BY intOrder
	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

