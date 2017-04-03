SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trtlbMaterial_Calculate]'))
DROP TRIGGER [dbo].[trtlbMaterial_Calculate]
GO



CREATE  trigger [trtlbMaterial_Calculate] on [dbo].[tlbMaterial]	
for insert, update
NOT FOR REPLICATION
as
begin

if  UPDATE(idfParty) 
	Begin
		UPDATE a
		SET strCalculatedCaseID = isnull(tlbCase.strCaseID,tlbMonitoringSession.strMonitoringSessionID)
		FROM tlbMaterial a
		inner join inserted
		on			inserted.idfMaterial=a.idfMaterial
		inner join	tlbParty
		on			tlbParty.idfParty = a.idfParty
					and tlbParty.intRowStatus=0
		left join	tlbMonitoringSession
		on			tlbMonitoringSession.idfMonitoringSession=tlbParty.idfMonitoringSession
		left join	tlbCase
		on			tlbCase.idfCase=tlbParty.idfCase


		UPDATE a
		SET strCalculatedHumanName = IsNull(HumanFromCase.strLastName + ' ', '')+IsNull(HumanFromCase.strFirstName + ' ', '') + IsNull(HumanFromCase.strSecondName, '')
		FROM tlbMaterial a
		inner join inserted
		on			inserted.idfMaterial=a.idfMaterial
		inner join	tlbParty
		on			tlbParty.idfParty = a.idfParty
					and tlbParty.intRowStatus=0
		left join	tlbCase
		on			tlbCase.idfCase=tlbParty.idfCase
		left join
				(
					tlbFarm
					inner join	tlbParty FarmParty
					on			FarmParty.idfParty=tlbFarm.idfFarm and FarmParty.intRowStatus=0
					inner join	tlbParty FarmOwner
					on			FarmOwner.idfParty=tlbFarm.idfHuman and FarmOwner.intRowStatus=0
				)
		on			FarmParty.idfCase=tlbCase.idfCase
		left join	tlbHuman HumanFromCase
		on			HumanFromCase.idfHuman=tlbFarm.idfHuman or
					HumanFromCase.idfHuman=a.idfParty
	End

end


