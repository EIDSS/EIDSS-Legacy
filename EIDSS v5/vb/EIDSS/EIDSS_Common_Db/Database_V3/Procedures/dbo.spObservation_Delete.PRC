SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spObservation_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spObservation_Delete]
GO


--##SUMMARY Deletes observation object with related flexible form data.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @idfObservation bigint

EXECUTE spObservation_Delete @idfObservation

*/



CREATE   PROC	spObservation_Delete
	@ID AS BIGINT --#PARAM @ID - observation ID
as

DELETE dbo.tlbActivityParameters
WHERE 
	idfObservation = @ID

DELETE dbo.tlbObservation 
WHERE 
	idfObservation = @ID
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

