SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumCaseFormContacts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumCaseFormContacts]


GO

--##SUMMARY Select Contacts data for Human report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 16.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec dbo.spRepHumCaseFormContacts @LangID=N'ru',@ObjID=134610000000


*/

create  Procedure [dbo].[spRepHumCaseFormContacts]
    (
        @LangID as nvarchar(10),
        @ObjID	as bigint
    )
as
	select 
	dbo.fnCreateNameString(tHuman.strLastName, 
							tHuman.strFirstName, 
							tHuman.strSecondName) as ContactName,
	rfContactType.[Name]			as Relation_Type,
	datDateOfLastContact			as ContactDate,
	tContacted.strPlaceInfo			as PlaceOfContact,
	(
		IsNull(dbo.fnAddressString(@LangID, tHuman.idfCurrentResidenceAddress) + ', ', '') + 
		IsNull(tHuman.strHomePhone, '')
	)								as ContactInformation

	from		dbo.tlbContactedCasePerson	as tContacted
	 left join	dbo.tlbHuman				as tHuman
			on	tHuman.idfHuman	= tContacted.idfHuman
	 left join	fnReference(@LangID, 19000014 /*rftPartyRelationType */) as rfContactType
			on	rfContactType.idfsReference = tContacted.idfsPersonContactType
		 where	tContacted.idfHumanCase = @ObjID

			
GO 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
