
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spWebVetCaseDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spWebVetCaseDetail]
GO

/*
exec spWebVetCaseDetail 0,'en'
*/

CREATE PROCEDURE dbo.spWebVetCaseDetail
	@id nvarchar(200),
	@LangID nvarchar(50)
AS
BEGIN

	select	*
	from	fnWebVetCaseList(@LangID)
	where	strCaseID=@id
END
GO
