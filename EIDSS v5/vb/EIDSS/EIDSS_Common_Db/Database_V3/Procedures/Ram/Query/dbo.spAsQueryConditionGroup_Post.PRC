SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQueryConditionGroup_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQueryConditionGroup_Post]
GO


--##SUMMARY This procedure creates new query condition group with specified parameters.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 20.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@idfQueryConditionGroup			bigint
declare	@idfQuerySearchObject			bigint
declare	@intOrder						int
declare	@idfParentQueryConditionGroup	bigint
declare	@blnJoinByOr					bit
declare	@blnUseNot						bit

execute	spAsQueryConditionGroup_Post
		 @idfQueryConditionGroup output
		,@idfQuerySearchObject
		,@intOrder,
		,@idfParentQueryConditionGroup
		,@blnJoinByOr
		,@blnUseNot

*/ 


create procedure	spAsQueryConditionGroup_Post
(
	@idfQueryConditionGroup			bigint output,
	@idfQuerySearchObject			bigint,
	@intOrder						int,
	@idfParentQueryConditionGroup	bigint = null,
	@blnJoinByOr					bit = null,
	@blnUseNot						bit = null
)
as

if	not exists	(
		select	*
		from	tasQuerySearchObject
		where	idfQuerySearchObject = @idfQuerySearchObject
				)
	or	(	@idfParentQueryConditionGroup is not null 
			and not exists	(
						select		*
						from		tasQueryConditionGroup
						where		idfQueryConditionGroup = @idfParentQueryConditionGroup
							)
		)
	or	@intOrder is null
begin
	set	@idfQueryConditionGroup = -1
end
else begin
	execute	spsysGetNewID	@idfQueryConditionGroup output

	insert into	tasQueryConditionGroup
	(	idfQueryConditionGroup,
		idfQuerySearchObject,
		idfParentQueryConditionGroup,
		intOrder,
		blnJoinByOr,
		blnUseNot
	)
	values
	(	@idfQueryConditionGroup,
		@idfQuerySearchObject,
		@idfParentQueryConditionGroup,
		@intOrder,
		@blnJoinByOr,
		@blnUseNot
	)
end

return 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

