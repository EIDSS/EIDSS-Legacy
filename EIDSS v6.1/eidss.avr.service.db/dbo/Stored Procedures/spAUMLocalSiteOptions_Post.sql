CREATE PROCEDURE [dbo].[spAUMLocalSiteOptions_Post]
(
	@versionUpdate varchar(50)	
)
AS
begin
	declare @version varchar(50);
	select @version = [strValue] from dbo.tstLocalSiteOptions where strName = 'DatabaseVersion';
	if (@version = null or Len(@version) = 0) return;
	declare @versionNum bigint, @versionUpdateNum bigint;
	set @versionNum = Cast(REPLACE(@version,'.','') as bigint);
	set @versionUpdateNum = Cast(REPLACE(@versionUpdate,'.','') as bigint);
	--select @versionNum, @versionUpdateNum
	if (@versionUpdateNum > @versionNum) begin
		Update dbo.tstLocalSiteOptions
			set [strValue] = @versionUpdate 
			where strName = 'DatabaseVersion';
	end;
end;
