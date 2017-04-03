SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOutbreak_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOutbreak_CanDelete]
GO














CREATE            PROCEDURE dbo.spOutbreak_CanDelete( 
	@ID AS bigint,
	@Result AS BIT OUTPUT
)
as

if exists	(
	select		* 
	from		tlbCase
	inner join	tlbOutbreak
	on			tlbOutbreak.idfOutbreak = tlbCase.idfOutbreak
				and tlbCase.intRowStatus = 0
	where		tlbOutbreak.idfOutbreak = @ID
)
	SET @Result=0
ELSE
	SET @Result=1

Return @Result




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

