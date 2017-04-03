set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spEIDSSUpdate_ManageUsers')) DROP PROCEDURE [dbo].spEIDSSUpdate_ManageUsers
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spEIDSSUpdate_ManageUsers
(
	@enable Bit
)
AS
BEGIN
	Set Nocount On;
	
	--Alter Login A1 Enable
	--Alter Login A1 Disable

	Declare @name Nvarchar(255)

	Declare curs Cursor For Select [name] From sys.server_principals Where type_desc='SQL_LOGIN' And [name] <> 'EIDSSMaintanceEngineer' And [name] <> 'sa'

	Open curs

	Fetch Next From curs Into @name

	Declare @sql Nvarchar(500)

	While @@FETCH_STATUS = 0 Begin
		If (@enable = 1) Begin
			Set @sql = 'Alter Login [' + @name + '] Enable';
		End Else Begin
			Set @sql = 'Alter Login [' + @name + '] Disable';
		End	
			
		exec(@sql)
		
		Fetch Next From curs Into @name                     	
	END

	Close curs
	Deallocate curs
	
END