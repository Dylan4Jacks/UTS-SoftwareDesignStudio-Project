CREATE PROCEDURE [dbo].[spCategoryItem_Delete]
	@CategoryItemId int
AS
BEGIN
	DELETE
	FROM dbo.[CategoryItem]
	WHERE CategoryItemId = @CategoryItemId;
	DELETE
	FROM dbo.[CategorySelection]
	WHERE CategoryItemId = @CategoryItemId;
END
