SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAntimicrobialTherapy_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAntimicrobialTherapy_Delete]
GO


--##SUMMARY Deletes atibiotic/antitrival therapy.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 25.01.2010

--##RETURNS Doesn't use



/*
--Example of a call of procedure:
declare	@ID bigint
exec	spAntimicrobialTherapy_Delete @ID
*/

create	procedure	spAntimicrobialTherapy_Delete
		@ID bigint --##PARAM  @ID - Atibiotic/antitrival therapy Id
as

delete
from	tlbAntimicrobialTherapy
where	tlbAntimicrobialTherapy.idfAntimicrobialTherapy = @ID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

