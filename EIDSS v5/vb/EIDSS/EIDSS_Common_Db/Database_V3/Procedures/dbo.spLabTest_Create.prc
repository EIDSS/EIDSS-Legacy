SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabTest_Create]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabTest_Create]
GO
 


create proc [dbo].[spLabTest_Create]
	@idfTesting bigint,
	@idfContainer bigint,
	@idfCase bigint,
	@idfMonitoringSession bigint,
	@idfsTestType bigint,
	@idfsTestForDiseaseType bigint,
	@idfsDiagnosis bigint,
	@idfExtBatchTest bigint=null
as 

declare @country bigint
select @country=idfsCountry from tstSite where idfsSite=dbo.fnsiteid()

declare @template bigint
exec dbo.spFFGetActualTemplate @idfsGISBaseReference=@country,@idfsBaseReference=@idfsTestType,@idfsFormType=10034018,@idfsFormTemplateActual=@template out

if @template=-1
begin
	set @template=null
end

declare @idfObservation bigint
exec spsysGetNewID @idfObservation output

insert into tlbObservation
(
			idfObservation,
			idfsFormTemplate			
)
values(
			@idfObservation,
			@template
)

insert into	tlbTesting(
			idfTesting,
			idfsTestType,
			idfsTestForDiseaseType,
			idfContainer,
			idfCase,
			idfMonitoringSession,
			idfsDiagnosis,
			idfObservation,
			idfExtBatchTest,
			idfsTestStatus
)
values		(
			@idfTesting,
			@idfsTestType,
			@idfsTestForDiseaseType,
			@idfContainer,
			@idfCase,
			@idfMonitoringSession,
			@idfsDiagnosis,
			@idfObservation,
			@idfExtBatchTest,
			10001005 --undefined
			)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

