SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPatient_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPatient_SelectDetail]
GO

--##SUMMARY Selects data for a specified human.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 22.01.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
declare	@idfHuman	bigint

execute	spPatient_SelectDetail
	@idfHuman
*/



create procedure	spPatient_SelectDetail
(		@idfHuman	bigint		--##PARAM @idfHuman Human Id
)
as

-- 0 tlbHuman
select		tlbHuman.idfHuman,
			tlbParty.idfRootParty as idfRootHuman,
			tlbParty.idfCase,
			tlbHuman.idfsOccupationType,
			tlbHuman.idfsNationality,
			tlbHuman.idfsHumanGender,
			tlbHuman.idfCurrentResidenceAddress,
			tlbHuman.idfEmployerAddress,
			tlbHuman.idfRegistrationAddress,
			tlbHuman.datDateofBirth,
			tlbHuman.datDateOfDeath,
			tlbHuman.strLastName,
			tlbHuman.strSecondName,
			tlbHuman.strFirstName,
			tlbHuman.strRegistrationPhone,
			tlbHuman.strEmployerName,
			tlbHuman.strHomePhone,
			tlbHuman.strWorkPhone
from		tlbHuman
inner join	tlbParty
on			tlbParty.idfParty = tlbHuman.idfHuman
			and tlbParty.idfsPartyType = 10072006			-- Human
			and tlbParty.intRowStatus = 0
where		tlbHuman.idfHuman = @idfHuman


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

