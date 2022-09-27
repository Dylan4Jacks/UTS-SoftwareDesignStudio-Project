CREATE PROCEDURE [dbo].[spGroup_Get]
	@GroupId int
AS
BEGIN
	SELECT GroupId, GroupName, GroupDetails
	FROM dbo.[Group]
	WHERE GroupId = @GroupId;
END