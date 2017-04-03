GO
/****** Object:  StoredProcedure [dbo].[spRepHumFormN1InfectiousDiseases]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepHumFormN1InfectiousDiseases]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepHumFormN1InfectiousDiseases]

/****** Object:  StoredProcedure [dbo].[spRepHumFormN1InfectiousDiseases]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure returns Header (Page 1) for Form N1

--##REMARKS Author: 
--##REMARKS Create date: 

--##RETURNS Don't use 

/*
--Example of a call of procedure:

exec spRepHumFormN1InfectiousDiseases 'en', 2011, 1

*/ 
 
CREATE PROCEDURE [dbo].[spRepHumFormN1InfectiousDiseases]
	@LangId			as varchar(36),
	@Year			as int, 
	@Month			as int = null,
	@RegionID		as bigint = null,
	@RayonID		as bigint = null
AS
BEGIN
	declare	@ReportTable	table
	(	idfsBaseReference	bigint not null primary key,
		intRowNumber		int null, --1
		strDiseaseName		nvarchar(300) collate database_default not null, --2
		strICD10			nvarchar(200) collate database_default null,	--3
		intTotal			int not null, --4
		intWomen			int not null, --5
		intAge_0_17			int not null, --6
		intAge_0_1			int not null, --7
		intAge_1_4			int not null, --8
		intAge_5_13			int not null, --9
		intAge_14_17		int not null, --10
		intAge_18_more		int not null, --11
		intRuralTotal		int not null, --12
		intRuralAge_0_17	int not null, --13
		intOrder			int not null
	)


DECLARE 		
		@StartDate	DATETIME,	 
		@FinishDate	DATETIME,
		@idfsSummaryReportType BIGINT,
		@idfsLanguage BIGINT
		
SET @idfsLanguage = dbo.fnGetLanguageCode (@LangID)		
		
if @Month IS null
begin
	set @StartDate = (CAST(@Year AS VARCHAR(4)) + '01' + '01')
	set @FinishDate = dateADD(yyyy, 1, @StartDate)
end
else
begin	
  IF @Month < 10 set @StartDate = (CAST(@Year AS VARCHAR(4)) + '0' +CAST(@Month AS VARCHAR(2)) + '01')
  ELSE  set @StartDate = (CAST(@Year AS VARCHAR(4)) + CAST(@Month AS VARCHAR(2)) + '01')
	set @FinishDate = dateADD(mm, 1, @StartDate)
end		




SET @idfsSummaryReportType =10290000 /*Form number 1*/


INSERT INTO @ReportTable (
	idfsBaseReference,
	intRowNumber,
	strDiseaseName,
	strICD10,
	intTotal,
	intWomen,
	intAge_0_17,
	intAge_0_1,
	intAge_1_4,
	intAge_5_13,
	intAge_14_17,
	intAge_18_more,
	intRuralTotal,
	intRuralAge_0_17,
	intOrder
) 
SELECT 
  rr.idfsDiagnosisOrGroup,
  case
	when	IsNull(br.idfsReferenceType, -1) = 19000130	-- Diagnosis Group
			and IsNull(br.strDefault, N'') = N'Total'
		then	null
	else	rr.intRowOrder
  end,
  case
	when	IsNull(br.idfsReferenceType, -1) = 19000130	-- Diagnosis Group
			and IsNull(br.strDefault, N'') = N'Total'
		then	IsNull(IsNull(snt1.strTextString, br1.strDefault) +  N' ', N'') + IsNull(snt.strTextString, br.strDefault) + N'*'
	else	IsNull(IsNull(snt1.strTextString, br1.strDefault) +  N' ', N'') + IsNull(snt.strTextString, br.strDefault)
  end,
  ISNULL(d.strIDC10, dg.strCode),
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
  rr.intRowOrder
FROM   dbo.trtReportRows rr
    LEFT JOIN trtBaseReference br
        LEFT JOIN trtStringNameTranslation snt
        ON br.idfsBaseReference = snt.idfsBaseReference
			AND snt.idfsLanguage = @idfsLanguage
			and snt.intRowStatus = 0
        LEFT OUTER JOIN trtDiagnosis d
        ON br.idfsBaseReference = d.idfsDiagnosis
			and d.intRowStatus = 0
        LEFT OUTER JOIN trtDiagnosisGroup dg
        ON br.idfsBaseReference = dg.idfsDiagnosisGroup
			and dg.intRowStatus = 0
    ON rr.idfsDiagnosisOrGroup = br.idfsBaseReference
		and br.intRowStatus = 0
   
    LEFT OUTER JOIN trtBaseReference br1
        LEFT OUTER JOIN trtStringNameTranslation snt1
        ON br1.idfsBaseReference = snt1.idfsBaseReference
			AND snt1.idfsLanguage = @idfsLanguage
			and snt1.intRowStatus = 0
    ON rr.idfsReportAdditionalText = br1.idfsBaseReference
		and br1.intRowStatus = 0
    

WHERE rr.idfsSummaryReportType = @idfsSummaryReportType
		and rr.intRowStatus = 0
ORDER BY rr.intRowOrder  



DECLARE	@Form1DiagnosisTable	TABLE
(	idfsDiagnosis		BIGINT NOT NULL PRIMARY KEY,
	blnIsAggregate		BIT,
	intTotal			INT NOT NULL,
	intWomen			INT NOT NULL,
	intAge_0_17			INT NOT NULL,
	intAge_0_1			INT NOT NULL,
	intAge_1_4			INT NOT NULL,
	intAge_5_13			INT NOT NULL,
	intAge_14_17		INT NOT NULL,
	intAge_18_more		INT NOT NULL,
	intRuralTotal		INT NOT NULL,
	intRuralAge_0_17	INT NOT NULL
)

INSERT INTO @Form1DiagnosisTable (
	idfsDiagnosis,
	blnIsAggregate,
	intTotal,
	intWomen,
	intAge_0_17,
	intAge_0_1,
	intAge_1_4,
	intAge_5_13,
	intAge_14_17,
	intAge_18_more,
	intRuralTotal,
	intRuralAge_0_17
) 
SELECT distinct
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
	intTotal,
	intWomen,
	intAge_0_17,
	intAge_0_1,
	intAge_1_4,
	intAge_5_13,
	intAge_14_17,
	intAge_18_more,
	intRuralTotal,
	intRuralAge_0_17
) 
SELECT distinct
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
  0

FROM dbo.trtReportRows rr
    INNER JOIN trtBaseReference br
    ON br.idfsBaseReference = rr.idfsDiagnosisOrGroup
        AND br.idfsReferenceType = 19000019 --'rftDiagnosis'
        AND br.intRowStatus = 0
--    INNER JOIN   dbo.trtBaseReferenceToCountry br_tc ON
--    br_tc.idfsBaseReference = br.idfsBaseReference AND
--    br_tc.idfsCountry = 170000000 AND
--    br_tc.intRowStatus = 0
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
WHERE idfsCountry = 170000000


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
			    and c.idfsCountry = 170000000
    left join	gisRegion r
    on			r.idfsRegion = a.idfsAdministrativeUnit 
			    and r.idfsCountry = 170000000
    left join	gisRayon rr
    on			rr.idfsRayon = a.idfsAdministrativeUnit
			    and rr.idfsCountry = 170000000
    left join	gisSettlement s
    on			s.idfsSettlement = a.idfsAdministrativeUnit
			    and s.idfsCountry = 170000000

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
	intTotal			INT NOT NULL,
	intWomen			INT NOT NULL,
	intAge_0_17			INT NOT NULL,
	intAge_0_1			INT NOT NULL,
	intAge_1_4			INT NOT NULL,
	intAge_5_13			INT NOT NULL,
	intAge_14_17			INT NOT NULL,
	intAge_18_more			INT NOT NULL,
	intRuralTotal			INT NOT NULL,
	intRuralAge_0_17			INT NOT NULL)

DECLARE 
	@FFP_Total			BIGINT,
	@FFP_Women			BIGINT,
	@FFP_Age_0_17			BIGINT,
	@FFP_Age_0_1			BIGINT,
	@FFP_Age_1_4			BIGINT,
	@FFP_Age_5_13			BIGINT,
	@FFP_Age_14_17			BIGINT,
	@FFP_Age_18_more			BIGINT,
	@FFP_RuralTotal			BIGINT,
	@FFP_RuralAge_0_17			BIGINT
    

	SET @FFP_Total			= 1127680000000
	SET @FFP_Women			= 1092680000000
	SET @FFP_Age_0_17			= 1035910000000
	SET @FFP_Age_0_1			= 1035830000000
	SET @FFP_Age_1_4			= 1035950000000
	SET @FFP_Age_5_13			= 1036030000000
	SET @FFP_Age_14_17			= 1035990000000
	SET @FFP_Age_18_more			= 1092880000000
	SET @FFP_RuralTotal			= 1145070000000
	SET @FFP_RuralAge_0_17	=1035870000000    


insert into	@Form1AggregateDiagnosisValuesTable
(	idfsBaseReference,
	intTotal,
	intWomen,
	intAge_0_17,
	intAge_0_1,
	intAge_1_4,
	intAge_5_13,
	intAge_14_17,
	intAge_18_more,
	intRuralTotal,
	intRuralAge_0_17
)
select		
      fdt.idfsDiagnosis      ,
			sum(IsNull(CAST(agp_Total.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_Women.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_Age_0_17.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_Age_0_1.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_Age_1_4.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_Age_5_13.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_Age_14_17.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_Age_18_more.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_RuralTotal.varValue AS INT), 0)),
			sum(IsNull(CAST(agp_RuralAge_0_17.varValue AS INT), 0))

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

        
        
        
        
--Total
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
on			agp_Total.idfObservation = fhac.idfCaseObservation
			and agp_Total.idfRow = v.idfRow -- agpD.idfRow
			and agp_Total.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Total.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
--	Women		
left join	(
	dbo.tlbActivityParameters agp_Women
	inner join	dbo.ffParameter p_Women
	on			p_Women.idfsParameter = agp_Women.idfsParameter
				and p_Women.intRowStatus = 0 
				and p_Women.idfsParameter = @FFP_Women
	inner join	trtBaseReference br_p_Women
	on			br_p_Women.idfsBaseReference = p_Women.idfsParameter
				and br_p_Women.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Women.intRowStatus = 0
			)
on			agp_Women.idfObservation= fhac.idfCaseObservation
			and agp_Women.idfRow = v.idfRow	-- agpD.idfRow
			and agp_Women.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Women.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
			

--	Age_0_17		
left join	(
	dbo.tlbActivityParameters agp_Age_0_17
	inner join	dbo.ffParameter p_Age_0_17
	on			p_Age_0_17.idfsParameter = agp_Age_0_17.idfsParameter
				and p_Age_0_17.intRowStatus = 0 
				and p_Age_0_17.idfsParameter = @FFP_Age_0_17
	inner join	trtBaseReference br_p_Age_0_17
	on			br_p_Age_0_17.idfsBaseReference = p_Age_0_17.idfsParameter
				and br_p_Age_0_17.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_0_17.intRowStatus = 0
			)
on			agp_Age_0_17.idfObservation= fhac.idfCaseObservation
			and agp_Age_0_17.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_0_17.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_0_17.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

--	Age_0_1		
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
on			agp_Age_0_1.idfObservation= fhac.idfCaseObservation
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

--	Age_5_13		
left join	(
	dbo.tlbActivityParameters agp_Age_5_13
	inner join	dbo.ffParameter p_Age_5_13
	on			p_Age_5_13.idfsParameter = agp_Age_5_13.idfsParameter
				and p_Age_5_13.intRowStatus = 0 
				and p_Age_5_13.idfsParameter = @FFP_Age_5_13
	inner join	trtBaseReference br_p_Age_5_13
	on			br_p_Age_5_13.idfsBaseReference = p_Age_5_13.idfsParameter
				and br_p_Age_5_13.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_5_13.intRowStatus = 0
			)
on			agp_Age_5_13.idfObservation= fhac.idfCaseObservation
			and agp_Age_5_13.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_5_13.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_5_13.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

--	Age_14_17		
left join	(
	dbo.tlbActivityParameters agp_Age_14_17
	inner join	dbo.ffParameter p_Age_14_17
	on			p_Age_14_17.idfsParameter = agp_Age_14_17.idfsParameter
				and p_Age_14_17.intRowStatus = 0 
				and p_Age_14_17.idfsParameter = @FFP_Age_14_17
	inner join	trtBaseReference br_p_Age_14_17
	on			br_p_Age_14_17.idfsBaseReference = p_Age_14_17.idfsParameter
				and br_p_Age_14_17.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_14_17.intRowStatus = 0
			)
on			agp_Age_14_17.idfObservation= fhac.idfCaseObservation
			and agp_Age_14_17.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_14_17.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_14_17.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	Age_18_more		
left join	(
	dbo.tlbActivityParameters agp_Age_18_more
	inner join	dbo.ffParameter p_Age_18_more
	on			p_Age_18_more.idfsParameter = agp_Age_18_more.idfsParameter
				and p_Age_18_more.intRowStatus = 0 
				and p_Age_18_more.idfsParameter = @FFP_Age_18_more
	inner join	trtBaseReference br_p_Age_18_more
	on			br_p_Age_18_more.idfsBaseReference = p_Age_18_more.idfsParameter
				and br_p_Age_18_more.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_Age_18_more.intRowStatus = 0
			)
on			agp_Age_18_more.idfObservation= fhac.idfCaseObservation
			and agp_Age_18_more.idfRow = v.idfRow -- agpD.idfRow
			and agp_Age_18_more.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_Age_18_more.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	RuralTotal		
left join	(
	dbo.tlbActivityParameters agp_RuralTotal
	inner join	dbo.ffParameter p_RuralTotal
	on			p_RuralTotal.idfsParameter = agp_RuralTotal.idfsParameter
				and p_RuralTotal.intRowStatus = 0 
				and p_RuralTotal.idfsParameter = @FFP_RuralTotal
	inner join	trtBaseReference br_p_RuralTotal
	on			br_p_RuralTotal.idfsBaseReference = p_RuralTotal.idfsParameter
				and br_p_RuralTotal.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_RuralTotal.intRowStatus = 0
			)
on			agp_RuralTotal.idfObservation = fhac.idfCaseObservation
			and agp_RuralTotal.idfRow = v.idfRow -- agpD.idfRow
			and agp_RuralTotal.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_RuralTotal.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')


--	RuralAge_0_17		
left join	(
	dbo.tlbActivityParameters agp_RuralAge_0_17
	inner join	dbo.ffParameter p_RuralAge_0_17
	on			p_RuralAge_0_17.idfsParameter = agp_RuralAge_0_17.idfsParameter
				and p_RuralAge_0_17.intRowStatus = 0 
				and p_RuralAge_0_17.idfsParameter = @FFP_RuralAge_0_17
	inner join	trtBaseReference br_p_RuralAge_0_17
	on			br_p_RuralAge_0_17.idfsBaseReference = p_RuralAge_0_17.idfsParameter
				and br_p_RuralAge_0_17.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_RuralAge_0_17.intRowStatus = 0
			)
on			agp_RuralAge_0_17.idfObservation = fhac.idfCaseObservation
			and agp_RuralAge_0_17.idfRow = v.idfRow -- agpD.idfRow
			and agp_RuralAge_0_17.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_RuralAge_0_17.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
where		h_later.idfVersion is null

group by	fdt.idfsDiagnosis

declare	@Form1CaseTable	table
(	idfsDiagnosis			BIGINT  not null,
	idfCase				BIGINT not null primary key,
	intYear					int NULL,
	idfsHumanGender  BIGINT,
	idfsRegion BIGINT,
	idfsRayon BIGINT
)


insert into	@Form1CaseTable
(	idfsDiagnosis,
	idfCase,
	intYear,
	idfsHumanGender,
	idfsRegion,
	idfsRayon
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
			h.idfsHumanGender, /*gender*/
      gl.idfsRegion,  /*region CR*/
      gl.idfsRayon  /*rayon CR*/
			
FROM tlbCase ct
    INNER JOIN tlbHumanCase hc
    ON ct.idfCase = hc.idfHumanCase
         AND ct.intRowStatus = 0 
         AND IsNull(ct.idfsCaseStatus, hc.idfsInitialCaseStatus) = 350000000 /*Confirmed Case*/
     

    INNER JOIN	@Form1DiagnosisTable fdt
    ON			fdt.blnIsAggregate = 0
            AND fdt.idfsDiagnosis = ct.idfsShowDiagnosis

    INNER JOIN tlbParty pp
      INNER JOIN tlbHuman h
        LEFT OUTER JOIN tlbGeoLocation gl
        ON h.idfCurrentResidenceAddress = gl.idfGeoLocation AND gl.intRowStatus = 0
      ON pp.idfParty = h.idfHuman
    ON  pp.idfCase = ct.idfCase AND
        pp.intRowStatus = 0
			
WHERE		hc.datTentativeDiagnosisDate is not null and
			(	@StartDate <= hc.datTentativeDiagnosisDate
					and hc.datTentativeDiagnosisDate < @FinishDate				
			) and
        (gl.idfsRegion = @RegionID or @RegionID is null) and
        (gl.idfsRayon = @RayonID OR @RayonID is null)

--Total
declare	@Form1CaseDiagnosisTotalValuesTable	table
(	idfsDiagnosis	BIGINT not null primary key,
	intTotal		INT not null
)

insert into	@Form1CaseDiagnosisTotalValuesTable
(	idfsDiagnosis,
	intTotal
)
SELECT fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
group by	fct.idfsDiagnosis


--Total Women
declare	@Form1CaseDiagnosisWomenValuesTable	table
(	idfsDiagnosis	BIGINT not null primary key,
	intWomen		INT not null
)

insert into	@Form1CaseDiagnosisWomenValuesTable
(	idfsDiagnosis,
	intWomen
)
SELECT fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
WHERE fct.idfsHumanGender = 10043001
group by	fct.idfsDiagnosis



--Total Age_0_17
declare	@Form1CaseDiagnosis_Age_0_17_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_0_17				INT not null
)

insert into	@Form1CaseDiagnosis_Age_0_17_TotalValuesTable
(	idfsDiagnosis,
	intAge_0_17
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 0 and fct.intYear <= 17)
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




--Total Age_5_13
declare	@Form1CaseDiagnosis_Age_5_13_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_5_13				INT not null
)

insert into	@Form1CaseDiagnosis_Age_5_13_TotalValuesTable
(	idfsDiagnosis,
	intAge_5_13
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 5 and fct.intYear <= 13)
group by	fct.idfsDiagnosis



--Total Age_14_17
declare	@Form1CaseDiagnosis_Age_14_17_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_14_17				INT not null
)

insert into	@Form1CaseDiagnosis_Age_14_17_TotalValuesTable
(	idfsDiagnosis,
	intAge_14_17
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 14 and fct.intYear <= 17)
group by	fct.idfsDiagnosis




--Total Age_18_more
declare	@Form1CaseDiagnosis_Age_18_more_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intAge_18_more				INT not null
)

insert into	@Form1CaseDiagnosis_Age_18_more_TotalValuesTable
(	idfsDiagnosis,
	intAge_18_more
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		(fct.intYear >= 18 )
group by	fct.idfsDiagnosis



--Total RuralTotal
declare	@Form1CaseDiagnosis_RuralTotal_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intRuralTotal				INT not null
)

insert into	@Form1CaseDiagnosis_RuralTotal_TotalValuesTable
(	idfsDiagnosis,
	intRuralTotal
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		
/*EXCEPT:
 If Region=Baku, or 
 if (Region=Nakhichevan AR and Rayon=Nakhichevan) or 
 if (Region=Other rayons and Rayon= Genje or Mingechevir or Naftalan or Shirvan or Sumgayit)
*/
(fct.idfsRegion <> 1344330000000/*Baku*/ ) AND
(fct.idfsRegion <> 1344350000000 AND fct.idfsRayon <> 1345180000000) AND
(fct.idfsRayon NOT IN (1344920000000, 1344830000000, 1344890000000, 1344650000000, 1344470000000))
group by	fct.idfsDiagnosis



--Total RuralAge_0_17
declare	@Form1CaseDiagnosis_RuralAge_0_17_TotalValuesTable	table
(	idfsDiagnosis			BIGINT not null primary key,
	intRuralAge_0_17				INT not null
)

insert into	@Form1CaseDiagnosis_RuralAge_0_17_TotalValuesTable
(	idfsDiagnosis,
	intRuralAge_0_17
)
select		fct.idfsDiagnosis,
			count(fct.idfCase)
from		@Form1CaseTable fct
where		
/*EXCEPT:
 If Region=Baku, or 
 if (Region=Nakhichevan AR and Rayon=Nakhichevan) or 
 if (Region=Other rayons and Rayon= Genje or Mingechevir or Naftalan or Shirvan or Sumgayit)
*/
(fct.intYear >= 0 and fct.intYear <= 17) AND 
(fct.idfsRegion <> 1344330000000/*Baku*/ ) AND
(fct.idfsRegion <> 1344350000000 AND fct.idfsRayon <> 1345180000000) AND
(fct.idfsRayon NOT IN (1344920000000, 1344830000000, 1344890000000, 1344650000000, 1344470000000))
group by	fct.idfsDiagnosis
		
		
		

--aggregate cases
update		fdt
set				
	fdt.intAge_0_17 = fadvt.intAge_0_17,
	fdt.intAge_0_1 = fadvt.intAge_0_1,
	fdt.intAge_1_4 = fadvt.intAge_1_4,	
	fdt.intAge_5_13 = fadvt.intAge_5_13,	
	fdt.intAge_14_17 = fadvt.intAge_14_17,	
	fdt.intAge_18_more = fadvt.intAge_18_more,	
	fdt.intTotal = fadvt.intTotal,	
	fdt.intWomen = fadvt.intWomen,	
	fdt.intRuralTotal = fadvt.intRuralTotal,	
	fdt.intRuralAge_0_17 = fadvt.intRuralAge_0_17		
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
set			fdt.intWomen = fcdvt.intWomen
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosisWomenValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0			


update		fdt
set			fdt.intAge_0_17 = fcdvt.intAge_0_17
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_0_17_TotalValuesTable fcdvt
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
set			fdt.intAge_5_13 = fcdvt.intAge_5_13
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_5_13_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0	


update		fdt
set			fdt.intAge_14_17 = fcdvt.intAge_14_17
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_14_17_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0	


update		fdt
set			fdt.intAge_18_more = fcdvt.intAge_18_more
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_Age_18_more_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0	
		
		
update		fdt
set			fdt.intRuralTotal = fcdvt.intRuralTotal
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_RuralTotal_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0			
		
		
update		fdt
set			fdt.intRuralAge_0_17 = fcdvt.intRuralAge_0_17
from		@Form1DiagnosisTable fdt
inner join	@Form1CaseDiagnosis_RuralAge_0_17_TotalValuesTable fcdvt
on			fcdvt.idfsDiagnosis = fdt.idfsDiagnosis
where		fdt.blnIsAggregate = 0			





DECLARE	@Form1DiagnosisGroupTable	TABLE
(	idfsDiagnosisGroup	BIGINT NOT NULL PRIMARY KEY,
	intTotal			INT NOT NULL,
	intWomen			INT NOT NULL,
	intAge_0_17			INT NOT NULL,
	intAge_0_1			INT NOT NULL,
	intAge_1_4			INT NOT NULL,
	intAge_5_13			INT NOT NULL,
	intAge_14_17			INT NOT NULL,
	intAge_18_more			INT NOT NULL,
	intRuralTotal			INT NOT NULL,
	intRuralAge_0_17			INT NOT NULL
)


insert into	@Form1DiagnosisGroupTable
(	idfsDiagnosisGroup,
	intTotal,
	intWomen,
	intAge_0_17,
	intAge_0_1,
	intAge_1_4,
	intAge_5_13,
	intAge_14_17,
	intAge_18_more,
	intRuralTotal,
	intRuralAge_0_17
)
select		dtg.idfsDiagnosisGroup,
	    sum(intTotal),	
	    sum(intWomen), 
	    sum(intAge_0_17), 
	    sum(intAge_0_1), 
	    sum(intAge_1_4), 
	    sum(intAge_5_13), 
	    sum(intAge_14_17), 
	    sum(intAge_18_more), 
	    sum(intRuralTotal),		
	    sum(intRuralAge_0_17)
from		@Form1DiagnosisTable fdt
inner join	dbo.trtDiagnosisToGroupForReportType dtg
on			dtg.idfsDiagnosis = fdt.idfsDiagnosis
			and dtg.idfsSummaryReportType = @idfsSummaryReportType
			and dtg.intRowStatus = 0
group by	dtg.idfsDiagnosisGroup	


update		ft
set	
  ft.intTotal = fdt.intTotal,	
	ft.intWomen = fdt.intWomen, 
	ft.intAge_0_17 = fdt.intAge_0_17, 
	ft.intAge_0_1 = fdt.intAge_0_1, 
	ft.intAge_1_4 = fdt.intAge_1_4, 
	ft.intAge_5_13 = fdt.intAge_5_13, 
	ft.intAge_14_17 = fdt.intAge_14_17, 
	ft.intAge_18_more = fdt.intAge_18_more, 
	ft.intRuralTotal = fdt.intRuralTotal, 
	ft.intRuralAge_0_17 = fdt.intRuralAge_0_17

from		@ReportTable ft
inner join	@Form1DiagnosisTable fdt
on			fdt.idfsDiagnosis = ft.idfsBaseReference	
		
		
update		ft
set	
  ft.intTotal = fdgt.intTotal,	
	ft.intWomen = fdgt.intWomen, 
	ft.intAge_0_17 = fdgt.intAge_0_17, 
	ft.intAge_0_1 = fdgt.intAge_0_1, 
	ft.intAge_1_4 = fdgt.intAge_1_4, 
	ft.intAge_5_13 = fdgt.intAge_5_13, 
	ft.intAge_14_17 = fdgt.intAge_14_17, 
	ft.intAge_18_more = fdgt.intAge_18_more, 
	ft.intRuralTotal = fdgt.intRuralTotal, 
	ft.intRuralAge_0_17 = fdgt.intRuralAge_0_17
from		@ReportTable ft
inner join	@Form1DiagnosisGroupTable fdgt
on			fdgt.idfsDiagnosisGroup = ft.idfsBaseReference			
		
		
		
	select * 
	from @ReportTable
	order by intOrder

END
GO
