SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumCaseFormSpecimens]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumCaseFormSpecimens]


GO

--##SUMMARY Select Speciemen data for Human report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 21.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepHumCaseFormSpecimens 'en' , 128990000002 

*/
 
create  Procedure [dbo].[spRepHumCaseFormSpecimens]
    (
        @LangID as nvarchar(10), 
        @ObjID	as bigint 
    )
as
	select	
				tMaterial.strFieldBarcode		as SpecimenLocalID,
				tMaterial.SpecimenType			as SpecimenType,
				tMaterial.datFieldCollectionDate as DateTimeOfCollection,
				tMaterial.datFieldSentDate		as DateTimeSpecimenSent,
				tAccession.datAccession			as DateTimeCpecimenReceivedLab,
				tAccession.strCondition			as Condition,
				tCondition.[Name]				as ConditionReceived,
				tTests.TestCategory				as TypeOfLabTest,
				tTests.TestResult				as TestResult,
				tTests.datPerformedDate			as TestDate

	from		fnMaterialList(@LangID) as tMaterial
	left join   tlbAccessionIN as tAccession
	on			tAccession.idfMaterial = tMaterial.idfMaterial
	left join	fnTestList(@LangID)	as tTests
	on			tMaterial.idfTesting = tTests.idfTesting
	left join	fnReference_Full(@LangID) as tCondition
	on			tCondition.idfsReference = tAccession.idfsAccessionCondition
	where		tMaterial.idfCase = @ObjID
			
			
GO 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
