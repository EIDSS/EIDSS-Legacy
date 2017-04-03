SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetYearSampleCountReport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetYearSampleCountReport]

GO

--##SUMMARY Select data for Samples Count Report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 15.12.2009

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec spRepVetYearSampleCountReport  'en', '2010'

*/

CREATE  Procedure [dbo].[spRepVetYearSampleCountReport]
    (
		@LangID as nvarchar(10),
        @Year   as int
    )
as
	SELECT			
			tDiagnosis.Name					AS Disease,
			rfFarmRegion.[Name]				AS Region,
            fnAnimalList.SpeciesName		AS Species,
            COUNT(fnMaterial.idfMaterial)	AS Total,
            COUNT(tPositiv.idfMaterial)		AS TotalPR,

            COUNT(case when month(tVetCase.datReportDate) = 1 THEN fnMaterial.idfMaterial	ELSE NULL END)  AS Jan,
            COUNT(case when month(tVetCase.datReportDate) = 1 THEN tPositiv.idfMaterial ELSE NULL END)	AS JanPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 2 THEN fnMaterial.idfMaterial	ELSE NULL END)  AS Feb,
            COUNT(case when month(tVetCase.datReportDate) = 2 THEN tPositiv.idfMaterial ELSE NULL END)	AS FebPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 3 THEN fnMaterial.idfMaterial	ELSE NULL END)	AS Mar,  
            COUNT(case when month(tVetCase.datReportDate) = 3 THEN tPositiv.idfMaterial ELSE NULL END)	AS MarPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 4 THEN fnMaterial.idfMaterial	ELSE NULL END)  AS Apr, 
            COUNT(case when month(tVetCase.datReportDate) = 4 THEN tPositiv.idfMaterial ELSE NULL END)	AS AprPR, 
            
            COUNT(case when month(tVetCase.datReportDate) = 5 THEN fnMaterial.idfMaterial	ELSE NULL END)	AS May,  
            COUNT(case when month(tVetCase.datReportDate) = 5 THEN tPositiv.idfMaterial ELSE NULL END)	AS MayPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 6 THEN fnMaterial.idfMaterial	ELSE NULL END)  AS Jun, 
            COUNT(case when month(tVetCase.datReportDate) = 6 THEN tPositiv.idfMaterial ELSE NULL END)	AS JunPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 7 THEN fnMaterial.idfMaterial	ELSE NULL END)  AS Jul, 
            COUNT(case when month(tVetCase.datReportDate) = 7 THEN tPositiv.idfMaterial ELSE NULL END)	AS JulPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 8 THEN fnMaterial.idfMaterial	ELSE NULL END)	AS Aug,  
            COUNT(case when month(tVetCase.datReportDate) = 8 THEN tPositiv.idfMaterial ELSE NULL END)	AS AugPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 9 THEN fnMaterial.idfMaterial	ELSE NULL END)	AS Sep,   
            COUNT(case when month(tVetCase.datReportDate) = 9 THEN tPositiv.idfMaterial ELSE NULL END)	AS SepPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 10 THEN fnMaterial.idfMaterial  ELSE NULL END) AS Oct, 
            COUNT(case when month(tVetCase.datReportDate) = 10 THEN tPositiv.idfMaterial ELSE NULL END) AS OctPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 11 THEN fnMaterial.idfMaterial  ELSE NULL END) AS Nov,  
            COUNT(case when month(tVetCase.datReportDate) = 11 THEN tPositiv.idfMaterial ELSE NULL END) AS NovPR,
            
            COUNT(case when month(tVetCase.datReportDate) = 12 THEN fnMaterial.idfMaterial  ELSE NULL END) AS Dec,  
            COUNT(case when month(tVetCase.datReportDate) = 12 THEN tPositiv.idfMaterial ELSE NULL END) AS DecPR


	from		dbo.tlbVetCase					as tVetCase
	inner join	dbo.tlbCase		as tCase
			on	tCase.idfCase = tVetCase.idfVetCase
		   and  tCase.intRowStatus = 0
	inner join	dbo.fnMaterialList(@LangId)	as fnMaterial
			on	tVetCase.idfVetCase = fnMaterial.idfCase
	inner join	fnAnimalList(@LAngID)fnAnimalList
			on	fnAnimalList.idfParty=fnMaterial.idfParty
	-- Get Farm
	 left join	(		
						dbo.tlbParty		as tFarmParty
			inner join	dbo.tlbFarm			as tFarm
					on	tFarmParty.idfParty = tFarm.idfFarm
				   and  tFarmParty.intRowStatus = 0
			 left join	dbo.tlbGeoLocation	as tFarmLocation
					on	tFarmLocation.idfGeoLocation = tFarm.idfFarmLocation
				   and  tFarmLocation.intRowStatus = 0
			 left join	dbo.fnGisReference(@LangID, 19000003 /*'rftRegion'*/)  rfFarmRegion 
					on	rfFarmRegion.idfsReference = tFarmLocation.idfsRegion
				)
			on	tVetCase.idfVetCase = tFarmParty.idfCase
	 left join	(	
					select	distinct tContainer.idfMaterial
					  from	tlbContainer			as tContainer
				inner join	dbo.tlbTesting			as tTesting
						on	tTesting.idfContainer = tContainer.idfContainer
					   and  tContainer.intRowStatus = 0
				inner join	dbo.tlbTestValidation	as tTestValidation
						on	tTestValidation.idfTesting = tTesting.idfTesting
					   and  tTestValidation.idfsInterpretedStatus = 10104001 /*Rule In*/
					   and  tTestValidation.intRowStatus = 0
					   and  tTesting.intRowStatus = 0
				) as tPositiv
			on	tPositiv.idfMaterial = fnMaterial.idfMaterial
	 left join	dbo.fnReference(@LANGID, 19000019 ) tDiagnosis --rftDiagnosis
			on	tCase.idfsShowDiagnosis = tDiagnosis.idfsReference
		 where  year(tVetCase.datReportDate) = @Year
	  group by  tDiagnosis.Name , rfFarmRegion.[Name], fnAnimalList.SpeciesName

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
