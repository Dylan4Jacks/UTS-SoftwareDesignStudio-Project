CREATE PROCEDURE [dbo].[spCategorySelection_Get]
	@CategoryItemId int,
	@StudentId int
AS
BEGIN
	SELECT CategoryItemId, StudentId, Content
	FROM dbo.[CategorySelection]
	WHERE CategoryItemId = @CategoryItemId AND StudentId = @StudentId;
END
