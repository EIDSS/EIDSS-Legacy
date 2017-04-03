SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPatient_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPatient_SelectLookup]
GO



--##SUMMARY Returns a list of people registered in the system as a patient or the owners of farms.

--##REMARKS Author: Mirnaya O.
--##REMARKS 
--##REMARKS Update date: 28.12.2009

--##RETURNS Returns a list of patients of the system (consisting of patients of human cases, and the owners of farms from veterinary cases).


/*
Example of a call of procedure:
declare @RootHumanID	bigint
declare @HumanID		bigint

exec spPatient_SelectLookup
		@RootHumanID, 
		@HumanID
*/


create	procedure	spPatient_SelectLookup
(
	@RootHumanID as bigint = null, --##PARAM @RootHumanID A unique identifier of the original human
	@HumanID	 as bigint = null --##PARAM @ID A unique identifier of the human
)
as

-- TO DO: Criterion for idfRootParty

select		tlbHuman.idfHuman, 
			tlbParty.idfRootParty as idfRootHuman,
			(	tlbHuman.strLastName + 
					IsNull(' ' + tlbHuman.strFirstName, '') +
					IsNull(' ' + tlbHuman.strSecondName, '')
			) as PatientName 
from		tlbHuman
inner join	tlbParty
on			tlbParty.idfParty = tlbHuman.idfHuman
			and tlbParty.intRowStatus = 0
where		(@RootHumanID is null or @RootHumanID = tlbParty.idfRootParty)
			and (@HumanID is null or @HumanID = tlbHuman.idfHuman)



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

