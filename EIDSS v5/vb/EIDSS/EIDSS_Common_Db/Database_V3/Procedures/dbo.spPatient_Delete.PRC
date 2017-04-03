SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPatient_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPatient_Delete]
GO


--##SUMMARY Deletes human case with its contacts, antimicrobial therapies, observations, and geographical location.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 22.01.2010

--##RETURNS Doesn't use



/*
--Example of a call of procedure:
declare	@ID bigint
exec	spPatient_Delete @ID
*/

create	procedure	spPatient_Delete
		@ID bigint --##PARAM  @ID - Human Id
as

--TODO: Delete samples, tests here?

delete		GeoLocation
from		tlbGeoLocation GeoLocation
inner join	tlbHuman Human
on			Human.idfCurrentResidenceAddress = GeoLocation.idfGeoLocation
where		Human.idfHuman = @ID

delete		GeoLocation
from		tlbGeoLocation GeoLocation
inner join	tlbHuman Human
on			Human.idfEmployerAddress = GeoLocation.idfGeoLocation
where		Human.idfHuman = @ID

delete		GeoLocation
from		tlbGeoLocation GeoLocation
inner join	tlbHuman Human
on			Human.idfRegistrationAddress = GeoLocation.idfGeoLocation
where		Human.idfHuman = @ID

delete
from	tlbContactedCasePerson
where	tlbContactedCasePerson.idfHuman = @ID

delete	
from	tlbHuman
where	tlbHuman.idfHuman = @ID

delete
from	tlbParty
where	tlbParty.idfParty = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

