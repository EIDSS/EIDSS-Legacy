SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleDestruction_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleDestruction_Delete]
GO

CREATE PROCEDURE [dbo].[spLabSampleDestruction_Delete]
	@ID bigint
AS
BEGIN

	UPDATE	tlbContainer 
	SET		idfsContainerStatus=10015007--cotInRepository
	WHERE	idfContainer=@ID AND idfsContainerStatus in (10015003,10015002) --cotDestroy,cotDelete

END
GO