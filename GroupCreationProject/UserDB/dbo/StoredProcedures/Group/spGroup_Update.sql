CREATE PROCEDURE [dbo].[spGroup_Update]
	@GroupId int,
	@GroupName nvarchar(50),
	@Details nvarchar(50)
AS
BEGIN
	UPDATE dbo.[Group]
	SET GroupId = @GroupId, GroupName = @GroupName, Details = @Details
	WHERE GroupId = @GroupId
END
