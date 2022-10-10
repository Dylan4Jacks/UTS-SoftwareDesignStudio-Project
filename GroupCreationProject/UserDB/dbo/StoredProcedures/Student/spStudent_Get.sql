CREATE PROCEDURE [dbo].[spStudent_Get]
	@StudentId int
AS
BEGIN
	SELECT StudentId, FirstName, LastName, Email, Password, GroupId
	FROM dbo.[Student]
	WHERE StudentId = @StudentId;
END
