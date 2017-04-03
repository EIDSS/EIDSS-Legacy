IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLoginChallenge]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLoginChallenge]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Return security authority generated value.
--##SUMMARY This value should be used by client to mix pasword with this Challenge value

--##REMARKS Author: Kletkin
--##REMARKS Create date: 31.05.2010

--##RETURNS Should be always succeeded

/*
--Example of procedure call:
declare @challenge varbinary(max)
exec spLoginChallenge @challenge output
select @challenge
*/

CREATE PROCEDURE [dbo].[spLoginChallenge]
	@challenge varbinary(max) output
AS
BEGIN
	
	declare @context nvarchar(50)
	set @context=dbo.fnGetContext()
	if @context is null return

	delete	
	from	tstLocalConnectionContext
	where	datLastUsed<dateadd(d,-30,getutcdate())

	set @challenge=NEWID()--0x6AB7F7794389E3479F9714FE83F67854--

	update	tstLocalConnectionContext
	set		binChallenge=@challenge,
			idfUserID=null,
			idfsSite=null
	where	strConnectionContext=@context
	if @@ROWCOUNT=0
	begin
	insert into tstLocalConnectionContext(strConnectionContext,binChallenge,datLastUsed)
	values(@context,@challenge,getutcdate())
	end

END
