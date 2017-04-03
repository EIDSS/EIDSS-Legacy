SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spsysBaseReferenceToCountry_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spsysBaseReferenceToCountry_Post]
GO


--##SUMMARY Fills trtBaseReferenceToCountry table with passed reference and country ID.
--##SUMMARY Called from spBaseReference_SysPost to link reference with country.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 23.01.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfsReference bigint
DECLARE @idfsCountry bigint


EXECUTE spsysBaseReferenceToCountry_Post
   @idfsReference
  ,@idfsCountry

*/




CREATE     PROCEDURE dbo.spsysBaseReferenceToCountry_Post 
	@idfsReference BIGINT, --##PARAM @idfsReference - reference ID
	@idfsCountry BIGINT --##PARAM @idfsCountry - country ID

AS
BEGIN
	IF NOT EXISTS (SELECT * FROM trtBaseReferenceToCountry WHERE idfsBaseReference = @idfsReference AND idfsCountry = @idfsCountry)
		INSERT INTO trtBaseReferenceToCountry(
				idfsBaseReference
			   ,idfsCountry
		)
		Values (
				@idfsReference
			   ,@idfsCountry
		)


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

