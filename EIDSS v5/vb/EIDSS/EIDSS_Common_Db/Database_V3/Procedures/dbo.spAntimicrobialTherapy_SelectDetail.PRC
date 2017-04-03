SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAntimicrobialTherapy_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAntimicrobialTherapy_SelectDetail]
GO

--##SUMMARY Selects antibiotics/antitrivial therapies data for a specified human case.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 25.01.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
declare	@idfCase	bigint

execute	spAntimicrobialTherapy_SelectDetail
	@idfCase
*/



create procedure	spAntimicrobialTherapy_SelectDetail
(		@idfCase	bigint		--##PARAM @idfCase Case Id
)
as

-- 0 tlbAntimicrobialTherapy
select		tlbAntimicrobialTherapy.idfAntimicrobialTherapy,
			tlbAntimicrobialTherapy.idfHumanCase,
			tlbAntimicrobialTherapy.datFirstAdministeredDate,
			tlbAntimicrobialTherapy.strAntimicrobialTherapyName,
			tlbAntimicrobialTherapy.strDosage
from		tlbAntimicrobialTherapy
inner join	tlbCase
on			tlbCase.idfCase = tlbAntimicrobialTherapy.idfHumanCase
			and tlbCase.intRowStatus = 0
where		tlbAntimicrobialTherapy.idfHumanCase = @idfCase
			and tlbAntimicrobialTherapy.intRowStatus = 0


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

