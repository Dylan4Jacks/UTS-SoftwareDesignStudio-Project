CREATE PROCEDURE [dbo].[spGroup_Update]
	@GroupId int,
	@GroupName nvarchar(50),
	@GroupDetails nvarchar(50)
AS
BEGIN
	UPDATE dbo.[Group]
	SET GroupName = @GroupName, GroupDetails = @GroupDetails
	WHERE GroupId= @GroupId
END
