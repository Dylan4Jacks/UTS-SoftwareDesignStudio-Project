CREATE PROCEDURE [dbo].[spTeacher_Auth_Get]
	@Email varchar(50),
	@Password varchar(50)
AS
BEGIN
	SELECT * FROM 
	dbo.[Teacher]
	WHERE Email = @Email and Password = @Password
END