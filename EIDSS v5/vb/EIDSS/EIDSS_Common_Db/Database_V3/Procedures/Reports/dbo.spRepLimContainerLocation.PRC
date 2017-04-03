SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimContainerLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimContainerLocation]


GO

--##SUMMARY Select data for Container location report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 16.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepLimContainerLocation 'en' , 124020000000

*/

create  Procedure [dbo].[spRepLimContainerLocation]
    (
        @LangID as nvarchar(10),
        @ObjID	as bigint
    )
as
	select
				tContainer.strBarcode					as ContainerBarcode,
				tContainer.SpecimenType					as SpecimenType,
				tContainer.CaseID						as CaseID,
				tContainer.datCreationDate				as RegistrationDate,
				tContainer.datFieldCollectionDate		as CollectionDate,
				fnSheme.[Path]							as Location,		
				tContainer.DepartmentName				as FunctionalArea

	from		fnContainerList(@LANGID)	as tContainer
	 left join	dbo.fn_RepositorySchema(@LANGID, null, null) as fnSheme
			on	fnSheme.idfSubdivision  = tContainer.idfSubdivision
		 where	tContainer.idfContainer = @ObjID
			
GO 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
