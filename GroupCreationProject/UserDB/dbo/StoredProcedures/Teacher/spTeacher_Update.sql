CREATE PROCEDURE [dbo].[spTeacher_Update]
	@TeacherId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Password nvarchar(50)
AS
BEGIN
	UPDATE dbo.[Teacher]
	SET FirstName = @FirstName, LastName = @LastName, Email = @Email, @Password = Password
	WHERE TeacherId = @TeacherId
END
