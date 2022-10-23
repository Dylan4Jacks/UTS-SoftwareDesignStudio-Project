CREATE PROCEDURE [dbo].[spCategoryItem_Get]
	@CategoryItemId int
AS
BEGIN
	SELECT CategoryItemId, Name, Details, Ranking, CategoryListId
	FROM dbo.[CategoryItem]
	WHERE CategoryItemId = @CategoryItemId;
END
