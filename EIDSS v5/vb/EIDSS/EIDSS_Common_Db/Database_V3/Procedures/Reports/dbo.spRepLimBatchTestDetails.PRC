SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimBatchTestDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimBatchTestDetails]


GO

--##SUMMARY Select data for Batch report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 10.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec [spRepLimBatchTestDetails] 93050000000 , 'en' 

*/

CREATE  Procedure [dbo].[spRepLimBatchTestDetails]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as
		select 
			idfTesting,  
			idfObservation,
			intTestNumber		as Sequence,
			TestResult			as Result,
			TestType			as TestName,
			strBarcode			as LabSampleID,
			DiagnosisName		as Diagnosis,
			SpecimenType		as Specimen,
			TestCategory		as Category

	from	fnTestList(@LangID)
	where	idfBatchTest=@ObjID

			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

