set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spEIDSSUpdate_CanStartUpdate')) DROP PROCEDURE [dbo].spEIDSSUpdate_CanStartUpdate
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spEIDSSUpdate_CanStartUpdate
(
	@ClientID Nvarchar(50)
	,@WithDatabaseUpdate Bit
	,@Result Bit output
)
AS
BEGIN
	Set Nocount On;
	
	Set @Result = 0;
	
	-- Выявляем, можно ли начинать апдейт
	-- его можно начать:
	-- если требуется обновление БД, то все агенты должны быть остановлены
	-- если не требуется обновления БД, то не должно в данный момент идущего обновления
	
	-- определяем, есть ли сейчас апдейт и какого он вида
	Declare @updateNow Bit 
	Set @updateNow = Null
	Select Top 1 @updateNow = [blnWithDatabaseUpdate] From dbo.updUpdateBlock
	
	-- если в данный момент не идёт никакой апдейт, то можно производить апдейт
	If (@updateNow = 0 Or @updateNow Is Null) BEGIN
		Set @Result = 1;                    	
	End Else BEGIN
	    If (@updateNow = 1 And @WithDatabaseUpdate = 0) BEGIN
			-- если сейчас идёт апдейт с БД, но данной программе не требуется обновлять БД, то апдейтиться можно
			Set @Result = 1; 			                                                	
	    End Else If (@updateNow = 1 And @WithDatabaseUpdate = 1) BEGIN
	        -- если сейчас идёт апдейт с БД и программе требуется обновлять БД, то нельзя апдейтиться
	        Set @Result = 0;
	    End
	END
	
	-- очистим аварийно завершившиеся приложения
	Exec dbo.spEIDSSUpdate_RemoveApplications
	
	-- если разрешён апдейт и нужно обновлять БД, то требуется проверить, чтобы все клиенты были отключены от БД
	If (@Result = 1 And @WithDatabaseUpdate = 1) BEGIN
	    -- не должно быть ничего запущено
	    If Exists (Select Top 1 1 From dbo.updRunningApps)
			Set @Result = 0
		Else
			Set @Result = 1	                              	
	End
	
	Return @Result
		
END