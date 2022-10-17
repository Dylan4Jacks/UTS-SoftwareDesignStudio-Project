CREATE PROCEDURE [dbo].[spTeacher_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Password nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.[Teacher] (FirstName, LastName, Email, Password)
	VALUES (@FirstName, @LastName, @Email, @Password)
END
