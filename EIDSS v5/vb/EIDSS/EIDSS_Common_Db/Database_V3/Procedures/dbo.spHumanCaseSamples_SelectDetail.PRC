SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spHumanCaseSamples_SelectDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spHumanCaseSamples_SelectDetail]
GO

--##SUMMARY Load list of tests required for Samples panel in Human Case
--##SUMMARY This procedure load only part of information.
--##SUMMARY Information about materials loaded using spCaseSamples_SelectDetail

--##REMARKS Author: Kletkin
--##REMARKS Create date: 9.02.2010

--##RETURNS list of tests associated with samples from specified case

CREATE PROCEDURE [dbo].[spHumanCaseSamples_SelectDetail]
	@idfCase AS bigint,
	@LangID NVARCHAR(50)
AS

select	Samples.*,
		cast(null as bigint)as idfsTestType,
		cast(null as bigint)as idfsTestResult,
		cast(null as datetime) as datPerformedDate
--,tlbContainer.datCreationDate
from		fn_CaseSamples(@idfCase,@LangID) Samples
/*left join	
		(
		tlbAccessionIN
		inner join	tlbContainer
		on			tlbContainer.idfContainer=tlbAccessionIN.idfContainer and
					tlbAccessionIN.intRowStatus=0 and tlbContainer.intRowStatus=0
		)
on		tlbContainer.idfMaterial=Samples.idfMaterial
*/

select		Tests.idfTesting,
			Tests.idfsTestType,
			Tests.TestType,
			Tests.idfMaterial,
			Tests.idfsTestResult,
			Tests.TestResult,
			Tests.datPerformedDate
from		fnTestList(@LangID) Tests
where	idfCase=@idfCase and
		idfsTestStatus=10001001

select
		idfCase as idfVetCase,
		strSampleNotes
from	tlbCase
where	idfCase=@idfCase

GO

