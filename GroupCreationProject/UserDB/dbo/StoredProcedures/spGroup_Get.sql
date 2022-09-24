CREATE PROCEDURE [dbo].[spGroup_Get]
	@GroupId int
AS
BEGIN
	SELECT GroupId, GroupName
	FROM dbo.[Group]
	WHERE GroupId = @GroupId;
END
