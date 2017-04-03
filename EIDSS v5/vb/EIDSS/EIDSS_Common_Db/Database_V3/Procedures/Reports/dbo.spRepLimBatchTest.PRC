SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimBatchTest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimBatchTest]


GO

--##SUMMARY Select data for Batch report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 10.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepLimBatchTest 93050000000 , 'en' 

*/

CREATE  Procedure [dbo].[spRepLimBatchTest]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as
	select 
	tBatch.strBarcode			as BatchTestID,	
	rfTestType.[Name]			as TestName,
	rfPerformed.[Name]			as LocationPerformed,
	dbo.fnCreateNameString(rfTestedBy.strFamilyName, rfTestedBy.strFirstName, rfTestedBy.strSecondName) as TestedByName,
	tBatch.datPerformedDate		as TestedDate,
	dbo.fnCreateNameString(rfValidatedBy.strFamilyName, rfValidatedBy.strFirstName, rfValidatedBy.strSecondName) as ValidatedByName,
	tBatch.datValidatedDate		as datValidatedDate	,
	tBatch.idfObservation		as idfBatchObservation

	from		tlbBatchTest			as tBatch
	 left join	fnReference(@LANGID, 19000097 /* rftTestType*/ )	as  rfTestType
			on	rfTestType.idfsReference = tBatch.idfsTestType
	 left join	fnInstitution (@LangID) as rfPerformed
			on	rfPerformed.idfOffice = tBatch.idfPerformedByOffice
	 left join	tlbPerson				as rfTestedBy
			on	rfTestedBy.idfPerson = tBatch.idfPerformedByPerson	
	 left join	tlbPerson				as rfValidatedBy
			on	rfValidatedBy.idfPerson = tBatch.idfValidatedByPerson	
		 where  tBatch.idfBatchTest = @ObjID

			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

