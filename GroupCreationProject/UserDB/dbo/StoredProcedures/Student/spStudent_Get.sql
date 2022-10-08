CREATE PROCEDURE [dbo].[spStudent_Get]
	@StudentId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Password nvarchar(50),
	@GroupId int
AS
BEGIN
	SELECT StudentId, FirstName, LastName, Email, Password, GroupId
	FROM dbo.[Student]
	WHERE StudentId = @StudentId;
END
