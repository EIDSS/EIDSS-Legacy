SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFreezerSubdivision_Validate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFreezerSubdivision_Validate]
GO

/*
exec spFreezerTree
exec spFreezerSubdivision_Validate @idfContainer=749880000000 ,@idfSubdivision=750130000000 
*/


CREATE    PROCEDURE spFreezerSubdivision_Validate
	@idfSubdivision bigint,
	@idfContainer bigint=null,
	@intCapacity int=null
as
	declare @stored bigint

--	set @stored=0
	
	select	@stored=count(*)
	from	tlbContainer
	where	idfSubdivision=@idfSubdivision and
			intRowStatus=0 and
			(idfContainer<>@idfContainer or @idfContainer is null)

	declare @real int
	set @real=@intCapacity

	if @real is null
	begin
		select	@real=intCapacity
		from	tlbFreezerSubdivision
		where	idfSubdivision=@idfSubdivision
	end

	if @idfContainer is not null set @stored=@stored-1
	
	if @stored>@real
	begin
		if @intCapacity is null	raiserror('errNoFreeLocation',16,1,null)
		else raiserror('msgCanNotDecreaseLocationVial',16,1,null) --here should be other message

	end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

