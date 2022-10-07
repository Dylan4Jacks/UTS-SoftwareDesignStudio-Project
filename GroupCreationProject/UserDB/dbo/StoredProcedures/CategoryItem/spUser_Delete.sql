CREATE PROCEDURE [dbo].[spUser_Delete]
	@UserId int
AS
BEGIN
	DELETE
	FROM dbo.[User]
	WHERE UserId = @UserId;
END
