CREATE PROCEDURE [dbo].[spCategorySelection_Delete]
	@CategoryItemId int,
	@StudentId int
AS
BEGIN
	DELETE
	FROM dbo.[CategorySelection]
	WHERE CategoryItemId = @CategoryItemId AND StudentId = @StudentId;
END
