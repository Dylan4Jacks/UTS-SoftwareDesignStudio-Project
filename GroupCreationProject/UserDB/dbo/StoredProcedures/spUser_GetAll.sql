CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
BEGIN
	SELECT Id, FirstName, LastName, Email, Preferences, Skills
	FROM dbo.[User];
END
