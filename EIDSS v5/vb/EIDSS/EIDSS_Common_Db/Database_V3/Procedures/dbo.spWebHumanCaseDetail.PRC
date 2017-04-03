SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spWebHumanCaseDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spWebHumanCaseDetail]
GO

CREATE PROCEDURE dbo.spWebHumanCaseDetail
	@id nvarchar(100),
	@LangID nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	select	*
	from	fnWebHumanCaseListEx(@LangID)
	where	strCaseID=@id

END
