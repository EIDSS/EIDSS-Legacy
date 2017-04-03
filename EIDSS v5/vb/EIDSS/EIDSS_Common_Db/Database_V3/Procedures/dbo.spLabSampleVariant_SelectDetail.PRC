SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleVariant_SelectDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleVariant_SelectDetail]
GO

CREATE PROCEDURE [dbo].[spLabSampleVariant_SelectDetail] 
	@idfContainer bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		tlbContainer.idfContainer,
				--tlbContainer.idfParentContainer,
				--tlbContainer.idfRootParentContainer,
				tlbContainer.strBarcode,
				tlbContainer.idfInDepartment,
				--tlbContainer.idfMaterial,
				--tlbMaterial.idfParentMaterial,
				--tlbMaterial.idfRootParentMaterial,
				tlbMaterial.idfsSpecimenType,
				--tlbMaterial.strFieldBarcode,
				--tlbMaterial.datFieldCollectionDate,
				--tlbMaterial.datFieldSentDate,
				--tlbMaterial.idfParty,
				--tlbParty.idfCase,--Material_Participation.idfActivity,
	--			Activity.idfActivity,
				--Activity.idfsActivity_Type,
				tlbContainer.idfSubdivision,
				tlbcontainer.strNote,
				--RepositorySchema.Path,
				HA.intHACode
	--			Animal_Case_Table.intCaseType
	--			Accession.datStartDate as AccessionDate,Accession.strNote as Comment,
	--			Check_In.strCondition,
	--			EmployeeReceived.idfEmployee as idfEmployeeReceived,OfficeReceived.idfOffice as idfOfficeReceived,
	--			EmployeeCollected.idfEmployee as idfEmployeeCollected,OfficeCollected.idfOffice as idfOfficeCollected
	FROM		tlbContainer
	inner join	tlbMaterial
	on			tlbContainer.idfMaterial=tlbMaterial.idfMaterial
/*	inner join	tlbParty
	on			tlbParty.idfParty=tlbMaterial.idfParty*/
	inner join	fnReference('en', 19000087) HA --rftSpecimenType
	on			tlbMaterial.idfsSpecimenType=HA.idfsReference

/*
		Material INNER JOIN
		Specimen ON Material.idfMaterial = Specimen.idfMaterial INNER JOIN
		Container ON Material.idfMaterial = Container.idfMaterial AND Container.intRowStatus=0 AND Container.idfContainer=Container.idfBaseID INNER JOIN
		Material_Responsibility ON Material.idfMaterial = Material_Responsibility.idfMaterial INNER JOIN
		Material_Participation ON Material_Participation.idfMaterial = Material.idfMaterial AND Material_Participation.intRowStatus=0 AND Material.intRowStatus=0 LEFT OUTER JOIN
		fnReference('en','rftSpecimenType') HA ON Specimen.idfsSpecimen_Type=HA.idfsReference INNER JOIN
		Activity ON Material_Participation.idfActivity=Activity.idfActivity AND Activity.idfsActivity_Type in ('actHumanCase','actVetCase')	LEFT OUTER JOIN
		Lab_Location ON Container.idfContainer = Lab_Location.idfContainer*/
	WHERE tlbContainer.idfContainer=@idfContainer

END
GO