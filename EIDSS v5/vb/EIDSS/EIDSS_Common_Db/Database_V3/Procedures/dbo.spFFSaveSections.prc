set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFSaveSections')) DROP PROCEDURE [dbo].spFFSaveSections
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 14.09.09
-- Description:	
-- =============================================
Create Procedure dbo.spFFSaveSections
(
	@idfsSection Bigint Output
    ,@idfsParentSection Bigint = Null
    ,@idfsFormType Bigint
    ,@DefaultName Nvarchar(400)
    ,@NationalName Nvarchar(600) = Null
    ,@LangID Nvarchar(50) = Null
    ,@intOrder Int = 0
    ,@blnGrid Bit = 0
    ,@blnFixedRowset Bit = 0   
)	
AS
BEGIN	
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	
	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfsSection < 0) Exec dbo.[spsysGetNewID] @idfsSection Output

	-- сохраняем названия
	Exec dbo.spBaseReference_SysPost @idfsSection, 19000101 /*'rftSection'*/, @LangID, @DefaultName, @NationalName, 0
	
	If Not Exists (Select Top 1 1 From dbo.ffSection Where idfsSection = @idfsSection) BEGIN
		 Insert into [dbo].[ffSection]
			   (
			   		[idfsSection]
				   ,[idfsParentSection]
				   ,[idfsFormType]	
				   ,[intOrder]
				   ,[blnGrid]
				   ,[blnFixedRowset]
			   )
		 Values
			   (
			   		@idfsSection
				   ,@idfsParentSection
				   ,@idfsFormType
				   ,@intOrder
				   ,@blnGrid
				   ,@blnFixedRowset
			   )
	End Else BEGIN
	         	Update [dbo].[ffSection]
				   Set 
						[idfsParentSection] = @idfsParentSection
						,[idfsFormType] = @idfsFormType	
						 ,[intOrder] = @intOrder
						,[blnGrid] = @blnGrid
						,[blnFixedRowset] = @blnFixedRowset
						,[intRowStatus] = 0
				  Where [idfsSection] = @idfsSection
	End	
End
Go