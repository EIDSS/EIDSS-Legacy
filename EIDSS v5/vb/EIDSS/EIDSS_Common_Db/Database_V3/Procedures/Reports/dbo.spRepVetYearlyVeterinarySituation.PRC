SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetYearlyVeterinarySituation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetYearlyVeterinarySituation]
GO

--##SUMMARY Select veterinary cases by month.

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use 


/*
--Example of a call of procedure:
exec spRepVetYearlyVeterinarySituation'en', 2010

*/

----------------------------

CREATE  Procedure  [dbo].[spRepVetYearlyVeterinarySituation]
	(
	@LANGID As nvarchar(50),
	@Year	as int
	
	)
as
	declare @TotalTable table
	(
	  strDiagnosis nvarchar(200),
	  intTotal int
	)

	declare @MonthTable table
	(
	  strDiagnosis		nvarchar(200),
	  intMonth			int,
	  intCount			int
	)

	insert		@TotalTable	
				(
					strDiagnosis,
					intTotal
				)
		select	fnCaseList.DiagnosisName			as strDiagnosis, 
				Count(fnCaseList.idfsDiagnosis)		as intCount 
		  from	dbo.fn_VetCase_SelectList(@LANGID)	as fnCaseList
		 where	Month(fnCaseList.datReportDate)	is not null
		   and  fnCaseList.idfsDiagnosis is not null
		   and	year(fnCaseList.datReportDate) = @Year

	  group by	fnCaseList.DiagnosisName

	insert		@MonthTable	
				(
					strDiagnosis,
					intMonth,
					intCount
				)
	    select  fnCaseList.DiagnosisName			as strDiagnosis, 
				Month(fnCaseList.datReportDate)		as intMonth,
				Count(fnCaseList.idfsDiagnosis)		as intCount 
		from	dbo.fn_VetCase_SelectList(@LANGID)	as fnCaseList
		 where	year(fnCaseList.datReportDate) = @Year
	group by	Month(fnCaseList.datReportDate), fnCaseList.DiagnosisName

	select	total.strDiagnosis		as Disease, 
			tJan.intCount			as Jan,
			tFeb.intCount			as Feb,
			tMar.intCount			as Mar,
			tApr.intCount			as Apr,
			tMay.intCount			as May,
			tJun.intCount			as Jun,
			tJul.intCount			as Jul,
			tAug.intCount			as Aug,
			tSep.intCount			as Sep,
			tOct.intCount			as Oct,
			tNov.intCount			as Nov,
			tDec.intCount			as [Dec],
			total.intTotal			as Total

	  from	@TotalTable				as total
 left join	@MonthTable tJan
		on	total.strDiagnosis = tJan.strDiagnosis
	   and	tJan.intMonth = 1
 left join	@MonthTable tFeb
		on	total.strDiagnosis = tFeb.strDiagnosis
	   and	tFeb.intMonth = 2
 left join	@MonthTable tMar
		on	total.strDiagnosis = tMar.strDiagnosis
	   and	tMar.intMonth = 3
 left join	@MonthTable tApr
		on	total.strDiagnosis = tApr.strDiagnosis
	   and	tApr.intMonth = 4
 left join	@MonthTable tMay
		on	total.strDiagnosis = tMay.strDiagnosis
	   and	tMay.intMonth = 5
 left join	@MonthTable tJun
		on	total.strDiagnosis = tJun.strDiagnosis
	   and	tJun.intMonth = 6
 left join	@MonthTable tJul
		on	total.strDiagnosis = tJul.strDiagnosis
	   and	tJul.intMonth = 7
 left join	@MonthTable tAug
		on	total.strDiagnosis = tAug.strDiagnosis
	   and	tAug.intMonth = 8
 left join	@MonthTable tSep
		on	total.strDiagnosis = tSep.strDiagnosis
	   and	tSep.intMonth = 9
 left join	@MonthTable tOct
		on	total.strDiagnosis = tOct.strDiagnosis
	   and	tOct.intMonth = 10
 left join	@MonthTable tNov
		on	total.strDiagnosis = tNov.strDiagnosis
	   and	tNov.intMonth = 11
 left join	@MonthTable tDec
		on	total.strDiagnosis = tDec.strDiagnosis
	   and	tDec.intMonth = 12

GO
	

