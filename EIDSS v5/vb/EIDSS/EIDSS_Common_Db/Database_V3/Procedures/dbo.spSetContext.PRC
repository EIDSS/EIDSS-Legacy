SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSetContext]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSetContext]
GO




CREATE PROCEDURE dbo.spSetContext(@ContextString varchar(50))
AS
	IF @ContextString IS NULL OR @ContextString=''
		BEGIN
			SET CONTEXT_INFO NULL
			RETURN 0
		END
		
	DECLARE @Context VARBINARY(128)

	SET @Context = CAST(@ContextString AS VARBINARY(128))
	SET CONTEXT_INFO @Context

RETURN 0





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

