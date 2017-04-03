SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimSampleTransferForm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimSampleTransferForm]

GO

--##SUMMARY Select data for Container Transfer report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 15.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepLimSampleTransferForm 1, 'en'
*/
 
create  Procedure [dbo].[spRepLimSampleTransferForm]
    (
		@ObjID bigint,
		@LangID as nvarchar(20)
    )
as
begin 
	select	
		tlbTransferOut.strNote			as PurposeOfTransfer,
		InstFromName.Name				as TransferredFrom,
		InstToName.[name]				as SampleTrasnferredTo,
		dbo.fnCreateNameString(SentByPerson.strFamilyName, SentByPerson.strFirstName, SentByPerson.strSecondName) as SentBy,
		datSendDate						as DateSent,
		Cont.strBarcode					as ContainerID,
		Cont.strFieldBarcode			as SampleID,
		Cont.SpecimenType				as SampleType,
		tlbTransferIn.strCondition		as StorageCondition,
		tlbContainer.datCreationDate	as DateSampleReceived

	from		tlbTransferOut
	left join	tlbTransferOutContainerList
	on			tlbTransferOutContainerList.idfTransferOut=tlbTransferOut.idfTransferOut
	left join	fnContainerList(@LangID) Cont
	on			Cont.idfContainer=tlbTransferOutContainerList.idfContainer

	left join	tlbTransferIn
	on			tlbTransferIn.idfTransferOut=tlbTransferOut.idfTransferOut and
				tlbTransferIn.idfOldContainer=tlbTransferOutContainerList.idfContainer
	left join	tlbContainer
	on			tlbContainer.idfContainer=tlbTransferIn.idfContainer

	left join fnInstitution (@LangID) as InstFromName
	on tlbTransferOut.idfSendFromOffice=InstFromName.idfOffice

	left join fnInstitution (@LangID) as InstToName
	on tlbTransferOut.idfSendToOffice=InstToName.idfOffice

	Left join tlbPerson as SentByPerson
	on tlbTransferOut.idfSendByPerson=SentByPerson.idfPerson

	where	tlbTransferOut.idfTransferOut=@ObjID
end	
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

