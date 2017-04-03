SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spContactedCasePerson_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spContactedCasePerson_SelectDetail]
GO

--##SUMMARY Selects contact data for a specified human case.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 23.01.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
declare	@idfCase	bigint

execute	spContactedCasePerson_SelectDetail
	@idfCase
*/



create procedure	spContactedCasePerson_SelectDetail
(		@idfCase	bigint		--##PARAM @idfCase Case Id
)
as

-- 0 tlbContactedCasePerson
select		tlbContactedCasePerson.idfContactedCasePerson,
			tlbContactedCasePerson.idfHumanCase,
			tlbContactedCasePerson.idfHuman,
			tlbContactedCasePerson.idfsPersonContactType,
			tlbContactedCasePerson.datDateOfLastContact,
			tlbContactedCasePerson.strPlaceInfo,
			tlbParty.idfRootParty as idfRootHuman,
			cast(0 as tinyint) as bitIsRootMain
from		tlbContactedCasePerson
inner join	tlbCase
on			tlbCase.idfCase = tlbContactedCasePerson.idfHumanCase
			and tlbCase.intRowStatus = 0
inner join	tlbParty
on			tlbParty.idfParty = tlbContactedCasePerson.idfHuman
			and tlbParty.intRowStatus = 0
where		tlbContactedCasePerson.idfHumanCase = @idfCase
			and tlbContactedCasePerson.intRowStatus = 0


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

