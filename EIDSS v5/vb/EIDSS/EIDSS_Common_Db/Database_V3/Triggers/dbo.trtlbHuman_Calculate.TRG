SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trtlbHuman_Calculate]'))
DROP TRIGGER [dbo].[trtlbHuman_Calculate]
GO


CREATE trigger [trtlbHuman_Calculate] on [dbo].[tlbHuman]	
for update
NOT FOR REPLICATION
as
begin

if  UPDATE(strLastName) or UPDATE(strSecondName) or UPDATE(strFirstName) 
	Begin
		UPDATE a
		SET strCalculatedHumanName = IsNull(HumanFromCase.strLastName + ' ', '')+IsNull(HumanFromCase.strFirstName + ' ', '') + IsNull(HumanFromCase.strSecondName, '')
		FROM tlbMaterial a
		inner join	tlbParty
		on			tlbParty.idfParty = a.idfParty
					and tlbParty.intRowStatus=0
		inner join	tlbCase
		on			tlbCase.idfCase=tlbParty.idfCase
		inner join
				(
					tlbFarm
					inner join	tlbParty FarmParty
					on			FarmParty.idfParty=tlbFarm.idfFarm and FarmParty.intRowStatus=0
					inner join	tlbParty FarmOwner
					on			FarmOwner.idfParty=tlbFarm.idfHuman and FarmOwner.intRowStatus=0
				)
		on			FarmParty.idfCase=tlbCase.idfCase
		inner join	inserted HumanFromCase
		on			HumanFromCase.idfHuman=tlbFarm.idfHuman

	End

end


