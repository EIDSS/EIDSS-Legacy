SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabTest_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabTest_SelectDetail]
GO
	


create   PROCEDURE [dbo].[spLabTest_SelectDetail](
	@idfTesting as bigint,
	@LANGID as nvarchar(50)
)
as
	select	*
	from	fnTestList(@LANGID) Tests
	where	Tests.idfTesting=@idfTesting
/*
SELECT 
	idfActivity,
	idfsTest_Type,
	intHACode, 
	datScheduled_Date, 
	datComplete_Date,
	strNotes,
	idfsTestResult,
	strTestNumber,
	idfsTestForDiseaseType
FROM Testing
WHERE 
	idfActivity = @TestID
-- LabTest 1, Test activity
SELECT 
	idfActivity, 
	datFinishDate, 
	datReportDate, 
	datStartDate, 
	idfsFFormTemplateID, 
	idfsActivity_Type, 
	idfsActivity_Status, 
	strActivityCode
FROM
	Activity 
WHERE
	Activity.idfActivity = @TestID
	--AND (Activity.idfsActivity_Type = 'actTest')
	AND Activity.intRowStatus=0 
--LabTest 2, PerfomedBy
SELECT 
	idfEmployee, 
	idfActivity, 
	idfEmployee_for_Activity, 
	idfsEmployee_for_Activity_Type
FROM
	Employee_for_Activity AS PerfomedByEmployee
	inner join Activity_Relationship ON
	Activity_Relationship.idfParent_Activity=PerfomedByEmployee.idfActivity 
	AND Activity_Relationship.idfsActivity_Relation_Type='artTestToBatch'
WHERE
	Activity_Relationship.idfRelated_Activity = @TestID
	AND (idfsEmployee_for_Activity_Type = 'eatPerformedBy')
	AND PerfomedByEmployee.intRowStatus=0 
--LabTest 3 , Test Material
SELECT 
	idfMaterial_Participation,
	idfActivity,
	idfMaterial,
	idfsMaterial_Participation_Type
FROM Material_Participation 
WHERE
	intRowStatus=0 
	AND idfActivity = @TestID

--LabTest 3 , Test Container
SELECT 
	idfContainer_Participation,
	idfActivity,
	idfContainer,
	idfsContainer_Participation_Type
FROM Container_Participation 
WHERE
	intRowStatus=0 
	AND idfActivity = @TestID
	
--PerformOffice 4
SELECT 		idfOffice, idfActivity, idfOffice_for_Activity, idfsOffice_for_Activity_Type
FROM 		Office_for_Activity
	inner join Activity_Relationship ON
	Activity_Relationship.idfParent_Activity=Office_for_Activity.idfActivity 
	AND Activity_Relationship.idfsActivity_Relation_Type='artTestToBatch'
where		
		(Activity_Relationship.idfRelated_Activity = @TestID) and
		(idfsOffice_for_Activity_Type = 'oatToInstitution') and
		(Office_for_Activity.intRowStatus = 0)

--5 Case Link
SELECT idfActivity_Relationship, 
	idfRelated_Activity, 
	idfParent_Activity, 
	idfsActivity_Relation_Type
FROM Activity_Relationship
WHERE 	idfRelated_Activity = @TestID
	AND idfsActivity_Relation_Type = 'artTestToCase'
	AND intRowStatus=0 


--6 Patient info ------------------------------
declare @CaseCode nvarchar(500),
@CaseID uniqueidentifier

select @CaseCode = actCase.strActivityCode,	
	   @CaseID = actCase.idfActivity	
		from activity actTest
		inner join activity_relationship arel 
				on (acttest.idfActivity =arel.idfRelated_Activity and arel.idfsActivity_Relation_Type='artTestToCase')
		inner join activity actCase
				on (actCase.idfActivity = arel.idfParent_Activity)
		where actTest.idfActivity = @TestID


declare @PartyType nvarchar(500), @PartyTypeID nvarchar(50)
select 
  @PartyType = PartyType.Name,  @PartyTypeID  = PartyType.idfsReference
			from activity a
			inner join material_participation mp on mp.idfactivity=a.idfactivity
			inner join material_responsibility mr on mp.idfMaterial=mr.idfmaterial
			inner join party p on p.idfParty = mr.idfParty 
			LEFT JOIN
				dbo.fnReference(@LangID, 'rftPartyType') PartyType ON
				PartyType.idfsReference = p.idfsParty_Type
			where a.idfactivity =@TestID
  
declare @BatchTestCode nvarchar(500)
	select @BatchTestCode = batch.strActivityCode from activity test 
			inner join activity_relationship rel on test.idfActivity = rel.idfRelated_Activity
			inner join activity batch on batch.idfActivity= rel.idfParent_Activity 
						and batch.intRowStatus=0
			where test.idfActivity = @TestID and rel.idfsActivity_Relation_Type='artTestToBatch'
				

declare @HumanName nvarchar(500)
set @HumanName = 
		(	select	
				IsNull(h.strLast_Name + N' ', N'')  +
				IsNull(h.strFirst_Name + N' ', N'') +
				IsNull(h.strSecond_Name, N'') as PatientName
			from activity a
				inner join material_participation mp on mp.idfactivity=a.idfactivity and mp.idfsMaterial_Participation_Type='mptDefault'
				inner join material_responsibility mr on mp.idfMaterial=mr.idfmaterial
				inner join Human h on h.idfParty = mr.idfParty
				where a.idfactivity =@TestID
		)

declare @AnimalName nvarchar(500)
set @AnimalName =
		(	select isnull(animal.strUniqueCode, isnull(SpeciesName.Name,''))
			from activity a
				inner join material_participation mp on mp.idfactivity=a.idfactivity and mp.idfsMaterial_Participation_Type='mptDefault'
				inner join material_responsibility mr on mp.idfMaterial=mr.idfmaterial
				left outer join animal on mr.idfParty  = animal.idfParty  
				left outer join animal_group on mr.idfParty = animal_group.idfParty 
				left outer join fnReference(@LangID,'rftSpeciesList') SpeciesName on SpeciesName.idfsReference = animal_group.idfsSpecies
				where a.idfactivity =@TestID
		)
	
declare @Diagnosis nvarchar(500)
select @Diagnosis = DiagnosisType.Name from case_table ct 
LEFT JOIN dbo.fnReference(@LangID, 'rftDiagnosis') DiagnosisType ON
					DiagnosisType.idfsReference = ct.idfsShowDiagnosis
	where ct.idfActivity = @CaseID
	
declare @CollectionDate datetime
select @CollectionDate = datCollectionDate from material m
			inner join material_participation mp on m.idfMaterial = mp.idfMaterial
		where mp.idfActivity = @TestID
	
declare @ObservationID uniqueidentifier
select @ObservationID = idfRelated_Activity from activity_Relationship Obser 
where Obser.idfsActivity_Relation_type= 'artTestObservToTest' and Obser.intRowstatus=0 
  and Obser.idfParent_Activity  = @TestID


select  CaseCode = @CaseCode,
	   PartyType = @PartyType,
	   PartyTypeID = @PartyTypeID,
	   PartyName = isnull(@HumanName, isnull(@AnimalName,'')),
	   Diagnosis = @Diagnosis,	
	   CollectionDate = @CollectionDate,
	   BatchTestCode =@BatchTestCode,
       ObservationID = @ObservationID
*/


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

