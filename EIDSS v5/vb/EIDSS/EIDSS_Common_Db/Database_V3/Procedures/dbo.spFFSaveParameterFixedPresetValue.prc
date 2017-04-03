set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spFFSaveParameterFixedPresetValue')) DROP PROCEDURE dbo.spFFSaveParameterFixedPresetValue
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFSaveParameterFixedPresetValue
(
	@idfsParameterFixedPresetValue Bigint Output    
	,@idfsParameterType Bigint
	,@DefaultName Nvarchar(400)	
	,@NationalName  Nvarchar(600)	
	,@LangID Nvarchar(50) = Null
	,@intOrder Int = Null
	
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';
	
	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfsParameterFixedPresetValue < 0) Exec dbo.[spsysGetNewID] @idfsParameterFixedPresetValue Output
	
	Exec dbo.spBaseReference_SysPost @idfsParameterFixedPresetValue, 19000069, @LangID, @DefaultName, @NationalName, 0, @intOrder

	If Not Exists (Select Top 1 1 From dbo.[ffParameterFixedPresetValue] Where [idfsParameterFixedPresetValue] = @idfsParameterFixedPresetValue) BEGIN
		Insert into dbo.[ffParameterFixedPresetValue]
		(
			[idfsParameterFixedPresetValue]
			,[idfsParameterType]
		)
		Values
		(
			@idfsParameterFixedPresetValue
			,@idfsParameterType			
		)
	End Else BEGIN
	    Update dbo.[ffParameterFixedPresetValue]
			Set [idfsParameterType] = @idfsParameterType
				,[intRowStatus] = 0
	    Where [idfsParameterFixedPresetValue] = @idfsParameterFixedPresetValue
	END
End
Go
