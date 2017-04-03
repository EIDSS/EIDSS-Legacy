SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spQuery_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spQuery_CanDelete]
GO


--##SUMMARY Checks if a human case could be deleted.
--##SUMMARY This procedure is called before the deletion of the query.
--##SUMMARY Query can only be deleted when the procedure allows it.
--##SUMMARY The query is allowed to delete, if it is not read-only.

--##REMARKS Author: Mirnaya O.
--##REMARKS 
--##REMARKS Update date: 21.04.2010

--##RETURNS Returns 0 if the query can not be deleted.
--##RETURNS Returns 1 if the query can be deleted.


/*
Example of a call of procedure:

declare @ID bigint
declare @Result bit
exec spQuery_CanDelete @ID, @Result output
print @Result

*/


create procedure	spQuery_CanDelete
( 
	@ID bigint,
	@Result bit output
)
as

	set @Result = 1

	if exists	(	 
			select	* 
			from	tasQuery 
			where	idflQuery = @ID
					and IsNull(blnReadOnly, 0) = 1
				)
	begin
		set @Result = 0
	end
	else begin
		set @Result = 1
	end

	return @Result



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

