SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleTransfer_SelectDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleTransfer_SelectDetail]
GO

CREATE PROCEDURE [dbo].[spLabSampleTransfer_SelectDetail] 
	@idfTransferOut bigint,
	@LangID as nvarchar(20)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select		*
	from		tlbTransferOUT
	where		idfTransferOut=@idfTransferOut

	select		Containers.idfContainer,
				Containers.strBarcode,
				Containers.SpecimenType,
				Containers.idfMaterial,


				tlbTransferIn.idfTransferIn,
				tlbTransferIn.idfContainer as idfContainerNew,
				tlbTransferIn.idfReceivedByPerson,
				--tlbTransferIn.datTransferInDate,
				--tlbTransferIn.strNote,
				tlbTransferIn.strCondition,

				ContainerNew.datCreationDate,
				ContainerNew.strBarcode as strBarcodeNew,
				ContainerNew.idfInDepartment,
				ContainerNew.strNote,

				ContainerNew.idfSubdivision

	from		fnContainerList(@LangID) Containers
	inner join	tlbTransferOutContainerList
	on			tlbTransferOutContainerList.idfContainer=Containers.idfContainer and
				tlbTransferOutContainerList.idfTransferOut=@idfTransferOut and
				tlbTransferOutContainerList.intRowStatus=0
	left join	tlbTransferIn
	on			tlbTransferIn.idfTransferOut=@idfTransferOut and
				tlbTransferIn.idfOldContainer=tlbTransferOutContainerList.idfContainer
	left join	tlbContainer ContainerNew
	on			ContainerNew.idfContainer=tlbTransferIn.idfContainer
	/*left join	fn_RepositorySchema(@LangID,null,null) freezer
	on			freezer.idfSubdivision=ContainerNew.idfSubdivision*/
/*
	SELECT 
		Activity.idfActivity,
		Activity.strActivityCode,
		Activity.idfsActivity_Status,
		Activity.datStartDate,
		Activity.strNote,
		OFrom.idfOffice as idfOfficeFrom,
		OTo.idfOffice as idfOfficeTo,
		ESent.idfEmployee as idfSentBy,
		EReceived.idfEmployee as idfReceivedBy
	FROM Activity LEFT OUTER JOIN 
	Office_For_Activity OFrom ON Activity.idfActivity=OFrom.idfActivity AND OFrom.idfsOffice_For_Activity_Type='oatFromInstitution' LEFT OUTER JOIN
	Office_For_Activity OTo ON OTo.intRowStatus=0 AND Activity.idfActivity=OTo.idfActivity AND OTo.idfsOffice_For_Activity_Type='oatToInstitution' LEFT OUTER JOIN
	Employee_For_Activity ESent ON Activity.idfActivity=ESent.idfActivity AND ESent.idfsEmployee_For_Activity_Type='eatSentBy' AND ESent.introwstatus=0 LEFT OUTER JOIN
	Employee_For_Activity EReceived ON Activity.idfActivity=EReceived.idfActivity AND EReceived.idfsEmployee_For_Activity_Type='eatReceivedBy'
	WHERE Activity.idfActivity=@idfActivity AND idfsActivity_Type='actTransferOut'

	SELECT 
		Container.idfContainer,
		Container.strBarcode,
		Material.idfMaterial,
		Material.strFieldBarcode,
		ST.Name as SpecimenType,
		dst.strBarcode as strBarcodeNew,
		tin.datStartDate,
		tin.strNote,
		Lab_Location.idfsSubdivisionID,
		Person.FullName,
		RepositorySchema.Path,
		dst.idfOffice,
		SpecimenTransferIn.strCondition,
		Activity.strActivityCode as CaseID,
		dbo.Specimen_Type.strCode as SpecimenCode,
		SpeciesList.strCode as SpeciesCode
		
	FROM
	Container_Participation INNER JOIN 
	Container 
	ON Container_Participation.idfContainer=Container.idfContainer AND 
	Container_Participation.intRowStatus=0 AND Container.idfContainer=Container.idfBaseID INNER JOIN
	Material ON Container.idfMaterial=Material.idfMaterial INNER JOIN
	Specimen ON Specimen.idfMaterial=Material.idfMaterial LEFT OUTER JOIN
	Activity tin INNER JOIN
	Container_Participation cin INNER JOIN
	Container_Relationship cr 
	ON cr.idfRelated_Container=cin.idfContainer
	ON tin.idfActivity=cin.idfActivity AND tin.idfsActivity_Type='actTransferIN' 
	ON Container.idfContainer=cr.idfParent_Container LEFT OUTER JOIN
	Container dst on dst.idfContainer=cin.idfContainer AND dst.idfContainer=dst.idfBaseID LEFT OUTER JOIN
	Lab_Location ON Lab_Location.idfContainer=dst.idfContainer LEFT OUTER JOIN
	SpecimenTransferIn ON tin.idfActivity=SpecimenTransferIn.idfActivity LEFT OUTER JOIN
	Employee_For_Activity ON Employee_For_Activity.idfActivity=tin.idfActivity LEFT OUTER JOIN
	(
		SELECT		
		idfEmployee, 
		IsNULL(strFamilyName,N'') + N' ' +
		IsNULL(strFirstName,N'') + N' ' +
		IsNULL(strSecondName,N'') AS FullName,
		Organization,
		strRankName As Position
	from dbo.fn_Person_SelectList(@LangID)
	) Person ON Person.idfEmployee=Employee_For_Activity.idfEmployee LEFT OUTER JOIN
	(select * from dbo.fn_RepositorySchema(null,null,null)) as RepositorySchema ON RepositorySchema.idfsSubdivisionID=Lab_Location.idfsSubdivisionID LEFT OUTER JOIN
	fnReference(@LangID,'rftSpecimenType') ST ON ST.idfsReference=Specimen.idfsSpecimen_Type

	left join dbo.Specimen_Type 
	on dbo.Specimen_Type.idfsSpecimen_Type=Specimen.idfsSpecimen_Type

	left outer join	
--retrieve case information
				Material_Participation inner join
				Activity inner join
				Case_Table
				on Case_Table.idfActivity=Activity.idfActivity 
				on Material_Participation.idfActivity=Activity.idfActivity and Material_Participation.intRowStatus = 0
				on Material_Participation.idfMaterial=Material.idfMaterial

	left join 	Material_Responsibility 
	on Material_Responsibility.idfMaterial=Material.idfMaterial
	and Material_Responsibility.idfsMaterial_Responsibility_Type='mrtAnimalSample'

	left join Animal 
	on Animal.idfParty=Material_Responsibility.idfParty

	left join SpeciesList 
	on SpeciesList.idfsSpecies=Animal.idfsSpecies	


	WHERE Container_Participation.idfActivity=@idfActivity AND Container_Participation.intRowStatus=0
*/
END


GO