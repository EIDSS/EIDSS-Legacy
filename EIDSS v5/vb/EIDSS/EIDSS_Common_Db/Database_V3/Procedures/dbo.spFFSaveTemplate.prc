set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFSaveTemplate')) DROP PROCEDURE [dbo].spFFSaveTemplate
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 22.09.09
-- Description:	Save Template
-- =============================================
Create Procedure dbo.spFFSaveTemplate
(
	@idfsFormTemplate Bigint Output
    ,@idfsFormType Bigint
    ,@DefaultName Nvarchar(400)
    ,@NationalName Nvarchar(600) = Null    
    ,@strNote Nvarchar(200) = Null 
    ,@LangID Nvarchar(50) = Null
    ,@blnUNI Bit = Null
)
AS
BEGIN
	SET NOCOUNT ON;
	
	If (@LangID Is Null) Set @LangID = 'en';
	
	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfsFormTemplate < 0) Exec dbo.[spsysGetNewID] @idfsFormTemplate Output
	
	-- если не задан признак универсальности шаблона, то он таким не является
	If (@blnUNI Is Null) Set @blnUNI = 0;
	
	-- сохраняем названия
	Exec dbo.spBaseReference_SysPost @idfsFormTemplate, 19000033 /*'rftFFTemplate'*/,@LangID, @DefaultName, @NationalName, 0
		
	If Not Exists (Select Top 1 1 From dbo.ffFormTemplate Where [idfsFormTemplate] = @idfsFormTemplate) BEGIN
		 Insert into [dbo].[ffFormTemplate]
           (
           		[idfsFormTemplate]
			   ,[idfsFormType]			   
			   ,[strNote]
			   ,[intRowStatus]
			   ,[blnUNI]
           )
		Values
           (
           		@idfsFormTemplate
			   ,@idfsFormType
			   ,@strNote
			   ,0
			   ,@blnUNI
           )          
	End Else BEGIN
	       Update [dbo].[ffFormTemplate]
			   Set [idfsFormType] = @idfsFormType				  
				  ,[strNote] = @strNote
				  ,[blnUNI] = @blnUNI
				  ,[intRowStatus] = 0
 			Where [idfsFormTemplate] = @idfsFormTemplate
	End
	
	-- если для данного шаблона выставляется признак UNI, то для всех остальных шаблонов данного типа формы нужно снять сей признак
--	If (@blnUNI = 1) BEGIN	                
--		Update dbo.[ffFormTemplate]
--			Set [blnUNI] =0
--			Where [idfsFormType] = @idfsFormType
--					   And
--					   [idfsFormTemplate] <> @idfsFormTemplate	
--	 END
END