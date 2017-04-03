SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepGetNumberNameList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepGetNumberNameList]


GO

--##SUMMARY Select list of number names for barcodes.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec spRepGetNumberNameList  'ru'

*/

CREATE  Procedure [dbo].[spRepGetNumberNameList]
    (
		@LangID as nvarchar(10)
    )
as
	select  tNumbers.idfsNumberName, 
			rfNumbers.[Name] as strNumberName
	  from	tstNextNumbers				as tNumbers
inner join	fnReference(@LangID, 19000057) as rfNumbers
		on	rfNumbers.idfsReference = tNumbers.idfsNumberName

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
