IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabExtBatch_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabExtBatch_Create]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spLabExtBatch_Create]
--	@idfTesting bigint,
	@idfExtBatchTest bigint,
--	@idfsDiagnosis bigint,
--	@idfContainer bigint,
--	@idfCase bigint,
--	@idfsTestType bigint,
--	@idfsTestForDiseaseType bigint,
	@idfPerformedByOffice bigint=null,
	@datPerformedDate datetime,
	@datReceivedDate datetime,
	@strContactPerson nvarchar(200)
as 

--	declare @idfExtBatchTest bigint
--	exec spSysgetNewID @idfExtBatchTest out

	insert into tlbExtBatchTest
	(
		idfExtBatchTest,
		idfPerformedByOffice,
		datPerformedDate,
		datReceivedDate,
		strContactPerson
	)
	values
	(
		@idfExtBatchTest,
		@idfPerformedByOffice,
		@datPerformedDate,
		@datReceivedDate,
		@strContactPerson
	)

--	exec spLabTest_Create @idfTesting, @idfContainer,@idfCase,@idfsTestType,@idfsTestForDiseaseType,@idfsDiagnosis,@idfExtBatchTest

