SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHumanCase_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHumanCase_Delete]
GO


--##SUMMARY Deletes human case with its contacts, antimicrobial therapies, observations, and geographical location.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 22.01.2010

--##RETURNS Doesn't use



/*
--Example of a call of procedure:
declare	@ID bigint
exec	spHumanCase_Delete @ID
*/

create	procedure	spHumanCase_Delete
		@ID bigint --##PARAM  @ID - Human case ID
as

--TODO: Delete samples, tests here?

declare	@tlbHuman_del		table (idfHuman bigint not null primary key)
declare	@idfHuman_del		bigint

declare	@idfEpiObservation	bigint
declare	@idfCSObservation	bigint

select	@idfEpiObservation		=	tlbHumanCase.idfEpiObservation,
		@idfCSObservation		=	tlbHumanCase.idfCSObservation
from	tlbHumanCase
where	tlbHumanCase.idfHumanCase = @ID

insert into	@tlbHuman_del (idfHuman)
select		tlbParty.idfParty
from		tlbParty
where		tlbParty.idfCase = @ID

insert into		@tlbHuman_del (idfHuman)
select distinct	tlbContactedCasePerson.idfHuman
from			tlbContactedCasePerson
left join		@tlbHuman_del as tlbHuman_del
on				tlbHuman_del.idfHuman = tlbContactedCasePerson.idfHuman
where			tlbContactedCasePerson.idfHumanCase = @ID
				and tlbHuman_del.idfHuman is null

declare Human_Cursor Cursor local read_only forward_only for
	select		idfHuman
	from		@tlbHuman_del
	order by	idfHuman
open Human_Cursor
fetch next from Human_Cursor into @idfHuman_del
while @@FETCH_STATUS <>-1
begin
	exec spPatient_Delete @idfHuman_del
	fetch next from Human_Cursor into @idfHuman_del
end
close Human_Cursor
deallocate Human_Cursor

exec	spObservation_Delete	@idfEpiObservation
exec	spObservation_Delete	@idfCSObservation

delete		GeoLocation
from		tlbGeoLocation GeoLocation
inner join	tlbHumanCase HumanCase
on			HumanCase.idfPointGeoLocation = GeoLocation.idfGeoLocation
where		HumanCase.idfHumanCase = @ID

delete
from	tlbAntimicrobialTherapy
where	tlbAntimicrobialTherapy.idfHumanCase = @ID

delete
from	tlbChangeDiagnosisHistory
where	tlbChangeDiagnosisHistory.idfHumanCase = @ID

delete
from	tlbHumanCase
where	tlbHumanCase.idfHumanCase = @ID

delete
from	tlbCase
where	tlbCase.idfCase = @ID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

