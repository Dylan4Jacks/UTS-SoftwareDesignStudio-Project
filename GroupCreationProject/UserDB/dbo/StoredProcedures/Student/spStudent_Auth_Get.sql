CREATE PROCEDURE [dbo].[spStudent_Auth_Get]
	@Email varchar(50),
	@Password varchar(50)
AS
BEGIN
	SELECT * FROM 
	dbo.[Student]
	WHERE Email = @Email and Password = @Password
END