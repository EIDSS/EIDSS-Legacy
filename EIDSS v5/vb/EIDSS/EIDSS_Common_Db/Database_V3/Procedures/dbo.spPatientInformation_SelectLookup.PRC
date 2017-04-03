SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPatientInformation_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPatientInformation_SelectLookup]
GO



--##SUMMARY Returns a list of patients, contact persons and farm owners with additional information.

--##REMARKS Author: Mirnaya O.
--##REMARKS 
--##REMARKS Update date: 28.01.2010

--##RETURNS Returns a list of patients, contact persons and farm owners with additional information.


/*
Example of a call of procedure:
declare @LangID			nvarchar(50)
declare @RootHumanID	bigint
declare @ID				bigint

set @LangID = 'en'
exec spPatientInformation_SelectLookup
		@LangID, 
		@RootHumanID, 
		@ID
*/


create	procedure	spPatientInformation_SelectLookup
(
	@LangID			as nvarchar(50),	--##PARAM Language Id
	@RootHumanID	as bigint = null,	--##PARAM @RootHumanID A unique identifier of the original human
	@ID				as bigint = null	--##PARAM @ID A unique identifier of the human
)
as

-- TO DO: Criterion for idfRootParty

select		tlbHuman.idfHuman, 
			tlbParty.idfRootParty as idfRootHuman,
			(	tlbHuman.strLastName + 
					IsNull(' ' + tlbHuman.strFirstName, '') +
					IsNull(' ' + tlbHuman.strSecondName, '')
			) as PatientName,
			(dbo.fnCreateAddressString	
				(	@LangID,
					[Address].Country,
					[Address].Region,
					[Address].Rayon,
					[Address].PostalCode,
					[Address].SettlementType,
					[Address].Settlement,
					[Address].Street,
					[Address].House,
					[Address].Building,
					[Address].Appartment,
					[Address].ResidentType
				) + IsNull(', ' + tlbHuman.strHomePhone, '')
			) as PatientInformation
from		tlbHuman
inner join	tlbParty
on			tlbParty.idfParty = tlbHuman.idfHuman
			and tlbParty.intRowStatus = 0

left join	fnAddressAsRow(@LangID) [Address]
on			[Address].idfGeoLocation = tlbHuman.idfCurrentResidenceAddress

where		(@RootHumanID is null or @RootHumanID = tlbParty.idfRootParty)
			and (@ID is null or @ID = tlbHuman.idfHuman)



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

