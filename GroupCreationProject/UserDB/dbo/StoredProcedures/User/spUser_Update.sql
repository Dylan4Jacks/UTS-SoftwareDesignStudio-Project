CREATE PROCEDURE [dbo].[spUser_Update]
	@UserId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Preferences nvarchar(100),
	@Skills nvarchar(100)
AS
BEGIN
	UPDATE dbo.[User]
	SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Preferences = @Preferences, Skills = @Skills
	WHERE UserId = @UserId
END
