CREATE PROCEDURE [dbo].[spStudent_Delete]
	@StudentId int
AS
BEGIN
	DELETE
	FROM dbo.[Student]
	WHERE StudentId = @StudentId;
END
