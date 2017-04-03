SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spsysBaseReference_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spsysBaseReference_Delete]
GO




--##SUMMARY Deletes base reference record and all low level related records

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 23.01.2010

--##RETURNS Doesn't use

/*
Example of procedure call:

DECLARE @idfsBaseReference bigint
EXECUTE spsysBaseReference_Delete
  @idfsBaseReference

*/


CREATE     PROCEDURE dbo.spsysBaseReference_Delete 
	@idfsBaseReference BIGINT --##PARAM @idfsBaseReference - diagnosis ID
AS
BEGIN
		DELETE FROM trtBaseReferenceToCountry 
		WHERE idfsBaseReference = @idfsBaseReference

		DELETE FROM trtStringNameTranslation 
		WHERE idfsBaseReference = @idfsBaseReference

		DELETE FROM trtBaseReference 
		WHERE idfsBaseReference = @idfsBaseReference

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

