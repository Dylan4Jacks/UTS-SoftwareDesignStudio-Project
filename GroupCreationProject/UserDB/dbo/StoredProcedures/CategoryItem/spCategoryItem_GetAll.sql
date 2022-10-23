CREATE PROCEDURE [dbo].[spCategoryItem_GetAll]
AS
BEGIN
	SELECT CategoryItemId, Name, Details, Ranking, CategoryListId
	FROM dbo.[CategoryItem];
END