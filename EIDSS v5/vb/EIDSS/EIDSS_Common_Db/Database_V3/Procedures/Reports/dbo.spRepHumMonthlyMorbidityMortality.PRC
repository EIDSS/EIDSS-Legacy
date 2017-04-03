SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumMonthlyMorbidityMortality]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumMonthlyMorbidityMortality]

GO

--##SUMMARY Select data for Monthly Morbidity and Mortality report

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 23.12.2009
 
--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec dbo.spRepHumMonthlyMorbidityMortality @LANGID=N'en',@Year=2010,@Month=02

*/

CREATE  Procedure [dbo].[spRepHumMonthlyMorbidityMortality]
	 (
		 @LangID		As nvarchar(50), 
		 @Year			as int, 
		 @Month			as int,
		 @IsDeceased	as bit = null 
	 )
AS	

	declare @FinalState as bigint
	if (@IsDeceased = 1) set @FinalState = 10035001 /*fstDeceased*/

	declare @StartDate as datetime
	declare @EndDate as datetime

	set @StartDate = convert( datetime, ltrim(rtrim(str(@Year))) + '-' + ltrim(rtrim(str(@Month))) + '-01  00:00:00', 20)
	if (@Month = 12)
	begin
		set @Year = @Year+1
		set @Month = 1
	end
	set @EndDate = convert( datetime, ltrim(rtrim(str(@Year))) + '-' + ltrim(rtrim(str(@Month+1))) + '-01  00:00:00', 20)

	
	select		tDiagnosisList.idfsDiagnosis		as DiagnosisID,
				tDiagnosisList.strIDC10				as IDC10,
				tDiagnosisList.strDiseaseName		as Disease,
				fnAge0_1.intCount					as Age_1,
				fnAge1_4.intCount					as Age1_4,
				fnAge5_14.intCount					as Age5_14,
				fnAge15_19.intCount					as Age15_19,
				fnAge20_29.intCount					as Age20_29,
				fnAge30_54.intCount					as Age30_54,
				fnAge55_.intCount					as Age55_,
				fnTotal.intCount					as TotalCases,
				tLabConfirmed.intCount				as TotalLabTested,
				tTotalConfirmed.intCount			as TotalConfirmed
			
	from		( select	tDiagnosis.idfsDiagnosis,
							tDiagnosis.strIDC10	,
							rfDiagnosis.[Name]		as strDiseaseName
					from	dbo.trtDiagnosis		as tDiagnosis
				inner join	fnReference(@LangID, 19000019/*'rftDiagnosis' */) as rfDiagnosis
						on	rfDiagnosis.idfsReference = tDiagnosis.idfsDiagnosis
					   and	rfDiagnosis.intHACode & 2 > 0
					   and  idfsUsingType = 10020001 /*Human */
				) as tDiagnosisList
		-- Get age statistics
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,0,1,@FinalState)	as fnAge0_1
			on	tDiagnosisList.idfsDiagnosis = fnAge0_1.idfsDiagnosis
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,1,4,@FinalState)	as fnAge1_4
			on	tDiagnosisList.idfsDiagnosis = fnAge1_4.idfsDiagnosis
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,5,14,@FinalState)	as fnAge5_14
			on	tDiagnosisList.idfsDiagnosis = fnAge5_14.idfsDiagnosis
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,15,19,@FinalState)	as fnAge15_19
			on	tDiagnosisList.idfsDiagnosis = fnAge15_19.idfsDiagnosis
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,20,29,@FinalState)	as fnAge20_29
			on	tDiagnosisList.idfsDiagnosis = fnAge20_29.idfsDiagnosis
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,30,54,@FinalState)	as fnAge30_54
			on	tDiagnosisList.idfsDiagnosis = fnAge30_54.idfsDiagnosis
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,55,2147483647,@FinalState)	as fnAge55_
			on	tDiagnosisList.idfsDiagnosis = fnAge55_.idfsDiagnosis	
	 left join	dbo.fnRepGetHumanCaseForAge(@StartDate,@EndDate,0,0,@FinalState)	as fnTotal
			on	tDiagnosisList.idfsDiagnosis = fnTotal.idfsDiagnosis	
	 left join	(			
				select		tCase.idfsShowDiagnosis			as idfsDiagnosis,
							count(tHumanCase.idfHumanCase)	as intCount
				from		dbo.tlbCase as tCase
				inner join  dbo.tlbHumanCase as tHumanCase
						on	tCase.idfCase = tHumanCase.idfHumanCase
					   and  tCase.datEnteredDate >= @StartDate
					   and  tCase.datEnteredDate < @EndDate
					   and  tCase.intRowStatus = 0
					   and  tCase.idfsCaseStatus = 350000000 /* Confirmed*/
					   and  (@FinalState is null or tHumanCase.idfsFinalState = @FinalState)					   
				  group by	tCase.idfsShowDiagnosis	
				) as tTotalConfirmed
			on	tDiagnosisList.idfsDiagnosis = tTotalConfirmed.idfsDiagnosis	
	 left join	(			
				select		tCase.idfsShowDiagnosis			as idfsDiagnosis,
							count(tHumanCase.idfHumanCase)	as intCount
				from		dbo.tlbCase as tCase
				inner join  dbo.tlbHumanCase as tHumanCase
						on	tCase.idfCase = tHumanCase.idfHumanCase
					   and  tCase.datEnteredDate >= @StartDate
					   and  tCase.datEnteredDate < @EndDate
					   and  tCase.intRowStatus = 0
					   and  tHumanCase.blnLabDiagBasis = 1
					   and  (@FinalState is null or tHumanCase.idfsFinalState = @FinalState)
				  group by	tCase.idfsShowDiagnosis	
				) as tLabConfirmed
			on	tDiagnosisList.idfsDiagnosis = tLabConfirmed.idfsDiagnosis				
			
	  order by	tDiagnosisList.strDiseaseName

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

