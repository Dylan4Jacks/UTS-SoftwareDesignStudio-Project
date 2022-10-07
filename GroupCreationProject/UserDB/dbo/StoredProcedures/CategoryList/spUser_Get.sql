CREATE PROCEDURE [dbo].[spUser_Get]
	@UserId int
AS
BEGIN
	SELECT UserId, FirstName, LastName, Email, Preferences, Skills
	FROM dbo.[User]
	WHERE UserId = @UserId;
END
