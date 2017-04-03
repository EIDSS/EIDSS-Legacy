SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCase_DiagnosisList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCase_DiagnosisList]
GO

--##SUMMARY Get list of diagnoses associated with case.

--##REMARKS Author: Kletkin.
--##REMARKS Update date: 28.04.2010

--##RETURNS Case and Diagnosis and Diagnosis title


CREATE PROCEDURE [dbo].[spCase_DiagnosisList]
	@idfCase bigint,
	@LangID nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select		Diagnoses.*,
				Names.Name
	from
	(
		select		idfCase,idfsShowDiagnosis as idfsDiagnosis
		from		tlbCase
		where		idfCase=@idfCase and (idfsShowDiagnosis is not null)
		union
		select		idfVetCase,idfsFinalDiagnosis
		from		tlbVetCase		
		where		idfVetCase=@idfCase and (idfsFinalDiagnosis is not null)
		union
		select		idfVetCase,idfsTentativeDiagnosis
		from		tlbVetCase
		where		idfVetCase=@idfCase and (idfsTentativeDiagnosis is not null)
		union
		select		idfVetCase,idfsTentativeDiagnosis1
		from		tlbVetCase
		where		idfVetCase=@idfCase and (idfsTentativeDiagnosis1 is not null)
		union
		select		idfVetCase,idfsTentativeDiagnosis2
		from		tlbVetCase
		where		idfVetCase=@idfCase and (idfsTentativeDiagnosis2 is not null)
		union
		select		idfMonitoringSession,idfsDiagnosis
		from		tlbMonitoringSessionToDiagnosis
		where		idfMonitoringSession=@idfCase and (idfsDiagnosis is not null) and intRowStatus=0
	)Diagnoses
	left join	fnReference(@LangID,19000019) Names
	on			Names.idfsReference=Diagnoses.idfsDiagnosis

END
