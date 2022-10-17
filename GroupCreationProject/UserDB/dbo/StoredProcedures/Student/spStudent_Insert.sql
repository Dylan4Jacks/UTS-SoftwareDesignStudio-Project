CREATE PROCEDURE [dbo].[spStudent_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Password nvarchar(50),
	@GroupId int
AS
BEGIN
	INSERT INTO dbo.[Student] (FirstName, LastName, Email, Password, GroupId)
	VALUES (@FirstName, @LastName, @Email, @Password, @GroupId)
END
