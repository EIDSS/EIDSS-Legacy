
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spgisGetNewID]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spgisGetNewID]
GO 

--##SUMMARY This procedure returns new ID from GIS ID set for current site.

--##REMARKS Author: Zhdanova A.
--##REMARKS Create date: 03.11.2009

--##RETURNS Don't use


/*
--Example of a call of procedure:

declare @ID bigint
exec dbo.[spgisGetNewID] @ID output
print @ID
*/


CREATE PROCEDURE [dbo].[spgisGetNewID](
	@ID bigint OUTPUT --##PARAM @ID - new ID (output)
	)
AS
BEGIN
  SET NOCOUNT ON
  INSERT INTO dbo.gisNewID (strA) VALUES ('')
  SET @ID = @@IDENTITY
  DELETE FROM dbo.gisNewID WHERE gisNewID = @ID
  SET NOCOUNT OFF 
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
