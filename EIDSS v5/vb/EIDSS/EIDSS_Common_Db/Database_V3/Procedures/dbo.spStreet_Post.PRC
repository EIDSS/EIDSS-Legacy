SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStreet_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStreet_Post]
GO

--##SUMMARY Posts street name for futher quick referencing in the system.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

DECLARE @strStreetName nvarchar(200)
DECLARE @idfsSettlement varchar(36)

EXECUTE @RC = [EIDSS_v3].[dbo].[spStreet_Post] 
   @strStreetName
  ,@idfsSettlement
*/


CREATE         PROCEDURE spStreet_Post(
	@strStreetName nvarchar(200),  --##PARAM @strStreetName - street name
	@idfsSettlement varchar(36)  --##PARAM @idfsSettlement - ID of settlement to which stree is belongs
	)
as
if (@idfsSettlement is not null) and (@strStreetName is not null) and (len(@strStreetName) > 0)
begin
	if not exists	(	select	*	
						from	tlbStreet
						where	idfsSettlement = @idfsSettlement
								and strStreetName = @strStreetName
					)
	begin
		insert into tlbStreet
			(
				idfsSettlement, 
				strStreetName 
			)
		values
			(
				@idfsSettlement, 
				@strStreetName 
			)
	end
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

