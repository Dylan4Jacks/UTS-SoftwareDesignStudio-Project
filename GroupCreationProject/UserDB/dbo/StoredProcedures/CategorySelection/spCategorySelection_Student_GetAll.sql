CREATE PROCEDURE [dbo].[spCategorySelection_Student_GetAll]
	@StudentId int
AS
BEGIN
	SELECT CategoryItemId, StudentId, Content
	FROM dbo.[CategorySelection]
	WHERE StudentId = @StudentId;
END
