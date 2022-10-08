CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SELECT UserId, FirstName, LastName, Email, Preferences, Skills
	FROM dbo.[User];
END
