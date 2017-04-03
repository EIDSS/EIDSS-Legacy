SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPostalCode_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPostalCode_Post]
GO



CREATE         PROCEDURE spPostalCode_Post(
	@strPostCode nvarchar(200),
	@idfsSettlement bigint
	)
as
if (@idfsSettlement is not null) and (@strPostCode is not null) and (len(@strPostCode) > 0)
begin
	if not exists	(	select	*	
						from	tlbPostalCode
						where	idfsSettlement = @idfsSettlement
								and strPostCode = @strPostCode
					)
	begin
		insert into tlbPostalCode
			(
				idfsSettlement, 
				strPostCode 
			)
		values
			(
				@idfsSettlement, 
				@strPostCode 
			)
	end
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

