SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHACode_SelectCheckList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHACode_SelectCheckList]
GO





--exec spHACode_SelectCheckList 'en'


CREATE       PROCEDURE dbo.spHACode_SelectCheckList
	@LangID As nvarchar(50)
AS

select dbo.trtHACodeList.intHACode, HACodeName.[name] as CodeName 
from dbo.trtHACodeList 
left join fnReference(@LangID,19000040) as HACodeName  --'rftHA_Code_List'
on HACodeName.idfsReference=dbo.trtHACodeList.idfsCodeName
WHERE dbo.trtHACodeList.idfsCodeName=10040002--'hacAnimal' 
OR dbo.trtHACodeList.idfsCodeName=10040003 --'hacAvian' 
OR dbo.trtHACodeList.idfsCodeName=10040007 --'hacLivestock'
OR dbo.trtHACodeList.idfsCodeName=10040005 --'hacHuman'


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

