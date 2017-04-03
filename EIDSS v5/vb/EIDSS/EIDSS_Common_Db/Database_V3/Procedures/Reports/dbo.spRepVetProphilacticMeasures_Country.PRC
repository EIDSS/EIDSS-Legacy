 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetProphilacticMeasures_Country]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetProphilacticMeasures_Country]


GO

--##SUMMARY Select data for Report "Veterinary-sanitary measures" V3.
--##REMARKS Author: Grigoreva Elena
--##REMARKS Create date: 19.01.2011  

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec spRepVetProphilacticMeasures_Country 
'en', 
'2011-02-01', 
'2011-03-01', 
'<ItemList><Item key="952220000000" value="Deratization"/></ItemList>', 
NULL
  
*/

CREATE  PROCEDURE [dbo].[spRepVetProphilacticMeasures_Country]
	(
		@LangID		AS NVARCHAR(10), 
		@StartDate	AS DATETIME,	 
		@FinishDate	AS DATETIME,
		@Measures	AS XML,
        @Region AS BIGINT = NULL
	)
AS	

-- Field description may be found here
-- "https://repos.btrp.net/BTRP/Project_Documents/08x-Implementation/Customizations/KZ/Reports/Specification_for_reports_development_Country_vaccination-treatment-KZ-V3.docx"
-- by number marked red at screen form prototype 

DECLARE	@ReportTable	TABLE
(	idfsBaseReference	BIGINT NOT NULL,
	strRegionName		NVARCHAR(200) COLLATE database_default NULL, --1
    strRayonName		NVARCHAR(200) COLLATE database_default NULL, --1
	
	strMeasureType		NVARCHAR(200) COLLATE database_default NULL, --2
	
    intNumOfObjForRep INT NULL, --3
    intThousSquareForRep INT NULL, --4
    intNumOfObjYear INT NULL, --5
    intThousSquareYear INT NULL, --6

	intOrder			INT NOT NULL
)

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
FROM fnAggregateSettings (10102003)--@AggrCaseType
WHERE idfsCountry = 1240000000


Print @MinTimeInterval
-- âûáîðêà çà îò÷åòíûé ïåðèîä
declare	@VetSanitaryActionMatrix	table
(	
	idfAggrCase	BIGINT not null primary KEY,
	datStartDate DATETIME,
	idfSanitaryVersion BIGINT,
	idfSanitaryObservation BIGINT,
	idfsRegion BIGINT
)


insert into	@VetSanitaryActionMatrix  
(	
	idfAggrCase,
	datStartDate,
	idfSanitaryVersion,
	idfSanitaryObservation,
	idfsRegion
)
select	
		a.idfAggrCase,
		a.datStartDate,
		a.idfSanitaryVersion,
		a.idfSanitaryObservation,
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
				)    
			and		
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

--SELECT * from @VetSanitaryActionMatrix

DECLARE	@VetSanitaryActionMatrixValuesTable	TABLE
(	
		idfsRegion	BIGINT,
		idfsSanitaryAction	BIGINT,
		intNumOfObjectsRep INT,
		intNumOfSquareMeters INT --6
 )



insert into	@VetSanitaryActionMatrixValuesTable
(
		idfsRegion,
		idfsSanitaryAction,
		intNumOfObjectsRep,
		intNumOfSquareMeters
)
select		
	fhac.idfsRegion,
	asa.idfsSanitaryAction,
	sum(IsNull(CAST(agp_NVA.varValue AS INT), 0)), 
	sum(IsNull(CAST(agp_SM.varValue AS INT), 0)) 

from		@VetSanitaryActionMatrix fhac

inner join dbo.trtSanitaryAction asa
    INNER JOIN @MeasuresTable mt
    ON mt.[KEY] = asa.idfsSanitaryAction
	inner join	trtBaseReference br_asa
	on			br_asa.idfsBaseReference = asa.idfsSanitaryAction
				and br_asa.intRowStatus = 0
on   asa.intRowStatus = 0 


inner join (
 tlbAggrMatrixVersionHeader h
 inner join tlbAggrMatrixVersion vP
 on   vP.idfVersion = h.idfVersion
 and vP.idfsParameter = 233190000000 -- Sanytary action measure type   
    and vP.intRowStatus = 0
   )
on   h.blnIsActive = 1
   and h.idfsAggrCaseSection = 71260000000 -- Sanitaty Action
--   and asa.idfsSanitaryAction = vP.idfRow
   and asa.idfsSanitaryAction = cast(vP.varValue as bigint)
   and (h.idfVersion = fhac.idfSanitaryVersion or fhac.idfSanitaryVersion is null)
   and (h.datStartDate <= fhac.datStartDate)
   and h.intRowStatus = 0
left join (
 tlbAggrMatrixVersionHeader h_later
 inner join tlbAggrMatrixVersion vP_later
 on   vP_later.idfVersion = h_later.idfVersion
 and vP_later.idfsParameter = 233190000000 -- Sanytary action measure type   
    and vP_later.intRowStatus = 0
   )
on   h_later.blnIsActive = 1
   and h_later.idfsAggrCaseSection = 233190000000 -- Sanytary action measure type   
   --and asa.idfsSanitaryAction = vP_later.idfRow
   and asa.idfsSanitaryAction = cast(vP_later.varValue as bigint)
   and fhac.idfSanitaryVersion is null
   and h_later.datStartDate <= fhac.datStartDate
   and h_later.intRowStatus = 0
   and ( h_later.datStartDate > h.datStartDate
     or ( h_later.datStartDate = h.datStartDate
       and h_later.idfVersion > h.idfVersion
      )
    )

----/* 6 column “Number of objects”*/
left join	(
	dbo.tlbActivityParameters agp_NVA
	inner join	dbo.ffParameter p_NVA
	on			p_NVA.idfsParameter = agp_NVA.idfsParameter
				and p_NVA.intRowStatus = 0 
				and p_NVA.idfsParameter = 1092840000000   /*column “Number of objects”*/
	inner join	trtBaseReference br_p_NVA
	on			br_p_NVA.idfsBaseReference = p_NVA.idfsParameter
				and br_p_NVA.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_NVA.intRowStatus = 0
			)
on			agp_NVA.idfObservation = fhac.idfSanitaryObservation
			and agp_NVA.idfRow = vP.idfRow -- agpD.idfRow
			and agp_NVA.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_NVA.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
----/* 6 column “Thousands square m.”*/
left join	(
	dbo.tlbActivityParameters agp_SM
	inner join	dbo.ffParameter p_SM
	on			p_SM.idfsParameter = agp_SM.idfsParameter
				and p_SM.intRowStatus = 0 
				and p_SM.idfsParameter = 1126780000000   /*column “Thousands square m.”*/
	inner join	trtBaseReference br_p_SM
	on			br_p_SM.idfsBaseReference = p_SM.idfsParameter
				and br_p_SM.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_SM.intRowStatus = 0
			)
on			agp_SM.idfObservation = fhac.idfSanitaryObservation
			and agp_SM.idfRow = vP.idfRow -- agpD.idfRow
			and agp_SM.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_SM.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

WHERE h_later.idfVersion IS NULL
GROUP BY    
    fhac.idfsRegion, 
    idfsSanitaryAction

--SELECT * FROM @VetSanitaryActionMatrixValuesTable	


-- âûáîðêà êåéñîâ ñ íà÷àëà ãîäà	äî êîíöà îò÷åòíîãî ïåðèîäà
SET @StartDate = CAST(CAST(YEAR(@StartDate)	 AS VARCHAR(4)) + '0101' AS DATETIME)


declare	@VetSanytaryActionMatrix_Year	table
(	
	idfAggrCase	BIGINT not null primary KEY,
	datStartDate DATETIME,
	idfSanitaryVersion BIGINT,
	idfSanitaryObservation BIGINT,
	idfsRegion BIGINT
)

insert into	@VetSanytaryActionMatrix_Year  
(	
	idfAggrCase,
	datStartDate,
	idfSanitaryVersion,
	idfSanitaryObservation,
	idfsRegion
)
select	
		a.idfAggrCase,
		a.datStartDate,
		a.idfSanitaryVersion,
		a.idfSanitaryObservation,
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
				)    
			and		
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

--SELECT * from @VetSanytaryActionMatrix_Year

DECLARE	@VetSanitaryActionMatrixValuesTable_Year	TABLE
(	
		idfsRegion	BIGINT,
		idfsSanitaryAction	BIGINT,
		intNumOfObjectsRep INT,
		intNumOfSquareMeters INT --6
 )



insert into	@VetSanitaryActionMatrixValuesTable_Year
(
		idfsRegion,
		idfsSanitaryAction,
		intNumOfObjectsRep,
		intNumOfSquareMeters
)
select		
	fhac.idfsRegion,
	asa.idfsSanitaryAction,
	sum(IsNull(CAST(agp_NVA.varValue AS INT), 0)), 
	sum(IsNull(CAST(agp_SM.varValue AS INT), 0)) 

from		@VetSanytaryActionMatrix_Year fhac

inner join dbo.trtSanitaryAction asa
    INNER JOIN @MeasuresTable mt
    ON mt.[KEY] = asa.idfsSanitaryAction
	inner join	trtBaseReference br_asa
	on			br_asa.idfsBaseReference = asa.idfsSanitaryAction
				and br_asa.intRowStatus = 0
on   asa.intRowStatus = 0 


inner join (
 tlbAggrMatrixVersionHeader h
 inner join tlbAggrMatrixVersion vP
 on   vP.idfVersion = h.idfVersion
 and vP.idfsParameter = 233190000000 -- Sanytary action measure type   
    and vP.intRowStatus = 0
   )
on   h.blnIsActive = 1
   and h.idfsAggrCaseSection = 71260000000 -- Sanitaty Action
--   and asa.idfsSanitaryAction = vP.idfRow
   and asa.idfsSanitaryAction = cast(vP.varValue as bigint)
   and (h.idfVersion = fhac.idfSanitaryVersion or fhac.idfSanitaryVersion is null)
   and (h.datStartDate <= fhac.datStartDate)
   and h.intRowStatus = 0
left join (
 tlbAggrMatrixVersionHeader h_later
 inner join tlbAggrMatrixVersion vP_later
 on   vP_later.idfVersion = h_later.idfVersion
 and vP_later.idfsParameter = 233190000000 -- Sanytary action measure type   
    and vP_later.intRowStatus = 0
   )
on   h_later.blnIsActive = 1
   and h_later.idfsAggrCaseSection = 233190000000 -- Sanytary action measure type   
   --and asa.idfsSanitaryAction = vP_later.idfRow
   and asa.idfsSanitaryAction = cast(vP_later.varValue as bigint)
   and fhac.idfSanitaryVersion is null
   and h_later.datStartDate <= fhac.datStartDate
   and h_later.intRowStatus = 0
   and ( h_later.datStartDate > h.datStartDate
     or ( h_later.datStartDate = h.datStartDate
       and h_later.idfVersion > h.idfVersion
      )
    )

----/* 6 column “Number of objects”*/
left join	(
	dbo.tlbActivityParameters agp_NVA
	inner join	dbo.ffParameter p_NVA
	on			p_NVA.idfsParameter = agp_NVA.idfsParameter
				and p_NVA.intRowStatus = 0 
				and p_NVA.idfsParameter = 1092840000000   /*column “Number of objects”*/
	inner join	trtBaseReference br_p_NVA
	on			br_p_NVA.idfsBaseReference = p_NVA.idfsParameter
				and br_p_NVA.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_NVA.intRowStatus = 0
			)
on			agp_NVA.idfObservation = fhac.idfSanitaryObservation
			and agp_NVA.idfRow = vP.idfRow -- agpD.idfRow
			and agp_NVA.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_NVA.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')
----/* 6 column “Thousands square m.”*/
left join	(
	dbo.tlbActivityParameters agp_SM
	inner join	dbo.ffParameter p_SM
	on			p_SM.idfsParameter = agp_SM.idfsParameter
				and p_SM.intRowStatus = 0 
				and p_SM.idfsParameter = 1126780000000   /*column “Thousands square m.”*/
	inner join	trtBaseReference br_p_SM
	on			br_p_SM.idfsBaseReference = p_SM.idfsParameter
				and br_p_SM.idfsReferenceType = 19000066 -- 'rftParameter'
				and br_p_SM.intRowStatus = 0
			)
on			agp_SM.idfObservation = fhac.idfSanitaryObservation
			and agp_SM.idfRow = vP.idfRow -- agpD.idfRow
			and agp_SM.intRowStatus = 0
			and SQL_VARIANT_PROPERTY(agp_SM.varValue, 'BaseType') in ('smallint', 'int', 'bigint', 'numeric')

WHERE h_later.idfVersion IS NULL
GROUP BY    
    fhac.idfsRegion, 
    idfsSanitaryAction

--SELECT *FROM @VetSanitaryActionMatrixValuesTable_Year


INSERT INTO @ReportTable
(	idfsBaseReference
	,strRegionName
    ,strRayonName
	,strMeasureType
    ,intNumOfObjForRep
    ,intThousSquareForRep
    ,intNumOfObjYear
    ,intThousSquareYear
	,intOrder
)
SELECT
	0, 
    ref_Region.[Name],
    NULL,
    ref_SanitaryAction.[Name],
    ISNULL(mx1.intNumOfObjectsRep,0),
    ISNULL(mx1.intNumOfSquareMeters,0),
    ISNULL(mx2.intNumOfObjectsRep,0),
    ISNULL(mx2.intNumOfSquareMeters,0),
	0
FROM 	
 (
    SELECT DISTINCT idfsRegion, idfsSanitaryAction FROM @VetSanitaryActionMatrixValuesTable
    UNION
    SELECT DISTINCT idfsRegion, idfsSanitaryAction FROM @VetSanitaryActionMatrixValuesTable_Year
 ) All_rows
 
LEFT OUTER JOIN fnGisReference (@LangID, 19000003) ref_region
ON ref_region.idfsReference = All_rows.idfsRegion

LEFT OUTER JOIN fnReference (@LangID, 19000079) ref_SanitaryAction
ON ref_SanitaryAction.idfsReference = All_rows.idfsSanitaryAction


LEFT OUTER JOIN @VetSanitaryActionMatrixValuesTable mx1
ON 
    All_rows.idfsRegion = mx1.idfsRegion AND 
    All_rows.idfsSanitaryAction = mx1.idfsSanitaryAction 
    
LEFT OUTER JOIN @VetSanitaryActionMatrixValuesTable_Year mx2
ON 
    All_rows.idfsRegion = mx2.idfsRegion AND 
    All_rows.idfsSanitaryAction = mx2.idfsSanitaryAction 


INSERT INTO @ReportTable
(	idfsBaseReference
	,strRegionName
	,strMeasureType
    ,intNumOfObjForRep
    ,intThousSquareForRep
    ,intNumOfObjYear
    ,intThousSquareYear
	,intOrder
)
SELECT
	0, 
    ref_Region.[Name],
    ref_SanitaryAction.[Name],
    null,
    null,
    null,
    null,
	0
FROM 	
 (
    SELECT DISTINCT idfsSanitaryAction FROM @VetSanitaryActionMatrixValuesTable
    UNION
    SELECT DISTINCT idfsSanitaryAction FROM @VetSanitaryActionMatrixValuesTable_Year
 ) All_ref
inner join	gisRegion r
on			r.idfsCountry = 1240000000
			and r.intRowStatus = 0
inner join	fnGisReference (@LangID, 19000003) ref_region
on			ref_region.idfsReference = r.idfsRegion
 
LEFT OUTER JOIN fnReference (@LangID, 19000079) ref_SanitaryAction
ON ref_SanitaryAction.idfsReference = All_ref.idfsSanitaryAction

left join	 (
    SELECT DISTINCT idfsRegion, idfsSanitaryAction FROM @VetSanitaryActionMatrixValuesTable
    UNION
    SELECT DISTINCT idfsRegion, idfsSanitaryAction FROM @VetSanitaryActionMatrixValuesTable_Year
 ) All_rows
on			All_rows.idfsSanitaryAction = All_Ref.idfsSanitaryAction
			and All_rows.idfsRegion = r.idfsRegion

where		All_rows.idfsSanitaryAction is null

    
update		rt
set			rt.intOrder = (
				select		count(*)
				from		@ReportTable rt_min
				where		rt_min.strRegionName < rt.strRegionName
							or	(	rt_min.strRegionName = rt.strRegionName
									and rt_min.strMeasureType <= rt.strMeasureType
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

