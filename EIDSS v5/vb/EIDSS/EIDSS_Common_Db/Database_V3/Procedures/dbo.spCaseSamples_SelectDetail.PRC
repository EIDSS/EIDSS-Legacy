SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCaseSamples_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCaseSamples_SelectDetail]
GO

/*
exec spCaseSamples_SelectDetail '30bd2fe3-2bbe-4ade-988d-f2e1b8f56ba8', 'en'
exec spCaseSamples_SelectDetail '0e0721bf-af88-4e86-9fcd-013011e19969', 'en'
*/

CREATE             PROCEDURE dbo.spCaseSamples_SelectDetail
	@idfCase as bigint,
	@LangID nvarchar(50)
AS

	select * from fn_CaseSamples(@idfCase,@LangID)

/*
	select
				tlbMaterial.*,
				dbo.fnReference.Name AS strSpecimenName,
				case when MaterialOnSite.UsageCount>0 then 0 else 1 end as blnCanDelete
	from		tlbMaterial
	inner join	dbo.fnReference(@LangID,19000087/*rftSpecimenType*/)
	on			dbo.fnReference.idfsReference = tlbMaterial.idfsSpecimenType
	inner join	tlbParty
	on			tlbParty.idfParty=tlbMaterial.idfParty and
				tlbMaterial.intRowStatus=0 and tlbParty.intRowStatus=0
	left join	(
				select idfMaterial, count(*) as UsageCount
				from tlbMaterialOnSite
				group by idfMaterial
				)MaterialOnSite
	on			MaterialOnSite.idfMaterial=tlbMaterial.idfMaterial
	where		tlbParty.idfCase=@idfCase
*/

/*
--0 Case Samples 	
SELECT 
	Material.idfMaterial, 
	datCollectionDate, 
	strBarcode, 
	strFieldBarcode, 
	Material.strNote, 
	idfsMaterial_Danger_Code, 
	idfsMaterial_Type, 
	SpecimenType.[Name] AS SpecimenType,
	SpecimenType.idfsReference AS SpecimenTypeID,
	Party.idfParty,
	ISNULL(Animal.strUniqueCode,
		(SELECT strUniqueCode FROM Animal_Group  WHERE idfParty = Party.idfParty)) AS AnimalID,
	0 As Qty,
	Animal.idfsAnimal_Condition as idfsPartyStatus,
	RegistrationActivity.idfActivity as idfRegistrationActivity,
	CollectedByOrganization.idfOffice as idfCollectedByOrganization,
	CollectedByEmployee.idfEmployee as idfCollectedByEmployee,
	blnCanDelete =	case 
						when exists	(
								select	*
								from	Material_On_Site mos 
								where	mos.idfMaterial = Material.idfMaterial
										and (	mos.intRowStatus = 0 
												or mos.intRowStatus is null)
									)	
							then cast(0 as bit)
						else cast(1 as bit)
					end

FROM 
	Material
Inner JOIN (
	dbo.Specimen 
	Inner JOIN
		dbo.fnReference(@LangID, 'rftSpecimenType') SpecimenType 
		ON SpecimenType.idfsReference = Specimen.idfsSpecimen_Type)
	ON Specimen.idfMaterial = Material.idfMaterial AND idfsMaterial_Type = 'mttLivingObject'
INNER JOIN 	Material_Participation ON
		Material_Participation.idfMaterial = Material.idfMaterial
		AND Material_Participation.intRowStatus=0 
INNER JOIN 	Material_Responsibility ON
		Material_Responsibility.idfMaterial = Material.idfMaterial
		AND Material_Responsibility.intRowStatus=0 
INNER JOIN (Party
LEFT OUTER JOIN Animal ON 
		Animal.idfParty = Party.idfParty)
ON
		Material_Responsibility.idfParty = Party.idfParty
		AND Party.intRowStatus=0 
INNER JOIN ((SELECT 
	Activity.idfActivity, 
	Material_Participation.idfMaterial
FROM Activity
INNER JOIN 	Material_Participation ON
	Material_Participation.idfActivity = Activity.idfActivity
	AND Material_Participation.intRowStatus=0 
INNER JOIN 	Material_Participation AS CaseMaterial_Participation ON
		CaseMaterial_Participation.idfMaterial = Material_Participation.idfMaterial
		AND CaseMaterial_Participation.intRowStatus=0 
WHERE 
	CaseMaterial_Participation.idfActivity = @idfCase
	AND Activity.idfsActivity_Type = N'actLabRegistration'
	AND Activity.intRowStatus=0 
) RegistrationActivity  
	LEFT OUTER JOIN Office_for_Activity AS CollectedByOrganization ON
		RegistrationActivity.idfActivity = CollectedByOrganization.idfActivity
		AND CollectedByOrganization.idfsOffice_for_Activity_Type = N'oatCollectedByInstitution'
		AND CollectedByOrganization.intRowStatus = 0 
	LEFT OUTER JOIN Employee_for_Activity AS CollectedByEmployee ON
		RegistrationActivity.idfActivity = CollectedByEmployee.idfActivity
		AND CollectedByEmployee.idfsEmployee_for_Activity_Type = N'eatCollectedBy'
		AND CollectedByEmployee.intRowStatus = 0 )
ON
		RegistrationActivity.idfMaterial = Material.idfMaterial
WHERE 
		Material_Participation.idfActivity = @idfCase
*/




	select
			idfCase as idfVetCase,
			strSampleNotes
	from	tlbCase
	where	idfCase=@idfCase

/*
--1 Case activity
SELECT Activity.idfActivity as idfActivity,
       Activity.idfsActivity_Type as idfsActivity_Type,
       Case_Table.strSampleNotes,
	Animal_Case_Table.intCaseType as VetCaseType
FROM 
	Case_Table
INNER JOIN Activity ON
	Case_Table.idfActivity = Activity.idfActivity
LEFT OUTER JOIN Animal_Case_Table ON
	Animal_Case_Table.idfActivity = Activity.idfActivity
WHERE 	Activity.idfActivity = @idfCase
	AND Activity.intRowStatus=0 
*/

--2 Samples To Collect
--EXEC spCaseSamples_GetSamplesToCollect @idfCase, NULL, @LangID
	select 
				idfMaterialForDisease,
				idfsSpecimenType as idfsReference,
				idfsDiagnosis,
				Names.Name
	from		trtMaterialForDisease
	left join	fnReference(@LangID,19000087) Names--specimen type
	on			Names.idfsReference=trtMaterialForDisease.idfsSpecimenType
	where		intRowStatus=0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

