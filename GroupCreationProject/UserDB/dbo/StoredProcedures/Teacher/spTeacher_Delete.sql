CREATE PROCEDURE [dbo].[spTeacher_Delete]
	@TeacherId int
AS
BEGIN
	DELETE
	FROM dbo.[Teacher]
	WHERE TeacherId = @TeacherId;
END
