CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
BEGIN
	SELECT Id, FirstName, LastName, Email, Preferences, Skills
	FROM dbo.[User]
	WHERE Id = @Id;
END
