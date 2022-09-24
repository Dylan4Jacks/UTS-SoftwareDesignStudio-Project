CREATE PROCEDURE [dbo].[spGroup_Delete]
	@GroupId int
AS
BEGIN
	DELETE
	FROM dbo.[Group]
	WHERE GroupId = @GroupId;
END
