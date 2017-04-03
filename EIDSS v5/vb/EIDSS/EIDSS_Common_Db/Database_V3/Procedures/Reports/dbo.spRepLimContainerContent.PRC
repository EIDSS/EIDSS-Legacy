SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimContainerContent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimContainerContent]

GO

--##SUMMARY Select data for Container content report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 15.12.2009

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec dbo.spRepLimContainerContent @LangID=N'en',@ContID=NULL,@FreezerID=145890000000
exec dbo.spRepLimContainerContent @LangID=N'en',@ContID=145900000000,@FreezerID=NULL
select * from dbo.fn_RepositorySchema( N'en', 145890000000, null)
select * from dbo.fn_RepositorySchema( N'en',  null, 145900000000)
*/

create  Procedure [dbo].[spRepLimContainerContent]
    (
        @LangID			as nvarchar(10),
		@ContID			as bigint,
		@FreezerID		as bigint
    )
as
	if @FreezerID < 0 SET @FreezerID=null
	if @ContID < 0 SET @ContID=null
	if (@FreezerID is not null) SET @ContID=null

	select 
	tRepository.FreezerBarcode		as FreezerBarcode,
	tRepository.strFreezerName		as FreezerName,
	tRepository.SubdivisionBarcode	as SubDivisionBarcode,
	tRepository.SubdivisionName		as SubDivisionName,
	tContainer.strBarcode			as ContainerBarcode,
	tContainer.idfContainer			as ContainerID,
	tMaterial.strFieldBarcode		as FieldID,
	rfSpecimenType.[Name]			as MaterialType,
	tRepository.[Path]				as [Path]

	from		dbo.fn_RepositorySchema (@LangID, @FreezerID, @ContID) as tRepository
	 left join	dbo.tlbContainer	as tContainer
			on	tContainer.idfSubdivision = tRepository.idfSubdivision
	 left join	dbo.tlbMaterial		as tMaterial
			on	tMaterial.idfMaterial = tContainer.idfMaterial
		   and	tMaterial.intRowStatus = 0
		   and	tContainer.intRowStatus = 0
	 left join	dbo.fnReference(@LangID, 19000087/*rftSpecimenType*/) rfSpecimenType
			on	tMaterial.idfsSpecimenType = rfSpecimenType.idfsReference
		-- where
			 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

