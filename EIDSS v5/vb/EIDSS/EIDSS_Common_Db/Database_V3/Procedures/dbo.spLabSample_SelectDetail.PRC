SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabSample_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabSample_SelectDetail]
GO

CREATE            PROCEDURE dbo.spLabSample_SelectDetail( 
	@idfContainer AS bigint,
	@LANGID NVARCHAR(50)
)
AS

--declare @idfCase bigint

select		
			Containers.idfContainer,
			Containers.idfsContainerStatus,
			Containers.datCreationDate,
			Containers.strBarcode,
			Containers.idfCase,
			Containers.idfMonitoringSession,
			Containers.strCaseID,
			Containers.strMonitoringSessionID,
			Containers.idfsCaseType,
			Containers.SpecimenType,
			Containers.SpeciesName,
			Containers.strAnimalCode,
			Containers.HumanName,
			Containers.DiagnosisName,
			Containers.idfInDepartment,
			Containers.idfSubdivision,
			Containers.idfFieldCollectedByOffice,
			Containers.idfFieldCollectedByPerson,
			Containers.strNote,
			Parent.idfContainer as idfParentContainer,
			Parent.strBarcode as strParentBarcode,
			CaseType.Name as CaseType/*,
			Freezer.Path*/
from		fnContainerList(@LANGID) Containers
left join	tlbContainer Parent
on			Parent.idfContainer=Containers.idfParentContainer and
			Parent.intRowStatus=0
left join	fnReference(@LANGID,19000012) CaseType--rftCaseType
on			CaseType.idfsReference=Containers.idfsCaseType
/*left join	fn_RepositorySchema(@LANGID, null, null) Freezer
on			Freezer.idfSubdivision=Containers.idfSubdivision*/
where		Containers.idfContainer=@idfContainer

select		Tests.idfTesting,
			Tests.idfsTestType,
			Tests.idfsTestForDiseaseType,
			Tests.idfsTestResult,
			Tests.idfBatchTest,
			Tests.idfsTestStatus,
			Tests.BatchTestCode,
			Tests.idfsDiagnosis,
			Tests.datPerformedDate,
			Tests.idfExtBatchTest,
			Tests.idfPerformedByOffice,
			Tests.datReceivedDate,
			Tests.strContactPerson
from		fnTestList(@LANGID) Tests
/*left join	tlbExtBatchTest
on			tlbExtBatchTest.idfExtBatchTest=Tests.idfExtBatchTest*/
where		idfContainer=@idfContainer

select		tlbTransferOut.idfTransferOut,
			tlbTransferOut.idfSendFromOffice,
			tlbTransferOut.strBarcode,
			tlbContainer.idfContainer,
			tlbContainer.strBarcode as ContainerBarcode
from		tlbTransferOut
inner join	tlbTransferIn
on			tlbTransferIn.idfTransferOut=tlbTransferOut.idfTransferOut
inner join	tlbContainer
on			tlbContainer.idfContainer=tlbTransferIn.idfOldContainer and
			tlbContainer.intRowStatus=0
where		tlbTransferIn.idfContainer=@idfContainer and
			tlbTransferOut.intRowStatus=0 and
			tlbTransferIn.intRowStatus=0

select		tlbTransferOut.idfTransferOut,
			tlbTransferOut.idfSendToOffice,
			tlbTransferOut.strBarcode,
			tlbTransferOut.datSendDate,
			tlbContainer.idfContainer,
			tlbContainer.strBarcode as ContainerBarcode,
			tstSite.idfsSite
from		tlbTransferOut
inner join	tlbTransferOutContainerList
on			tlbTransferOutContainerList.idfTransferOut=tlbTransferOut.idfTransferOut and
			tlbTransferOutContainerList.idfContainer=@idfContainer and
			tlbTransferOutContainerList.intRowStatus=0
left join	tlbTransferIn
on			tlbTransferIn.idfTransferOut=tlbTransferOut.idfTransferOut and
			tlbTransferIn.intRowStatus=0
left join	tlbContainer
on			tlbContainer.idfContainer=tlbTransferIn.idfContainer and
			tlbContainer.intRowStatus=0
left join	tstSite
on			tstSite.idfOffice=tlbTransferOut.idfSendToOffice and
			tstSite.intRowStatus=0
where		tlbTransferOut.intRowStatus=0 and
			tlbTransferOut.idfsTransferStatus=10001003



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

