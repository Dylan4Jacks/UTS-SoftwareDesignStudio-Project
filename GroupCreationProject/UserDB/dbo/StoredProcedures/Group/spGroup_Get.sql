CREATE PROCEDURE [dbo].[spGroup_Get]
	@GroupId int
AS
BEGIN
	SELECT GroupId, GroupName, Details
	FROM dbo.[Group]
	WHERE GroupId = @GroupId;
END
