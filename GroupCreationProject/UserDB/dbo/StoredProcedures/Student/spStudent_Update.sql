CREATE PROCEDURE [dbo].[spStudent_Update]
	@StudentId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Password nvarchar(50),
	@GroupId int
AS
BEGIN
	UPDATE dbo.[Student]
	SET FirstName = @FirstName, LastName = @LastName, Email = @Email, @Password = Password, @GroupId = GroupId
	WHERE StudentId = @StudentId
END
