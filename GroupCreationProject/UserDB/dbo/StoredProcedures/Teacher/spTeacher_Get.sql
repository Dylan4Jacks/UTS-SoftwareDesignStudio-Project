CREATE PROCEDURE [dbo].[spTeacher_Get]
	@TeacherId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Password nvarchar(50)
AS
BEGIN
	SELECT TeacherId, FirstName, LastName, Email, Password
	FROM dbo.[Teacher]
	WHERE TeacherId = @TeacherId;
END
