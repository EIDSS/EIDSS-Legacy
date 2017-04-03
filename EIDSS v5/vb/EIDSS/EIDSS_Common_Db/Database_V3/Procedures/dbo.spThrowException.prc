IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spThrowException]')) DROP PROCEDURE [dbo].[spThrowException]
GO

CREATE PROCEDURE [dbo].[spThrowException]
	@ErrorMessage	nvarchar(3900)
AS	
	Set @ErrorMessage = '???' + @ErrorMessage + '???'
	raiserror(@ErrorMessage,16, 1)
RETURN 0