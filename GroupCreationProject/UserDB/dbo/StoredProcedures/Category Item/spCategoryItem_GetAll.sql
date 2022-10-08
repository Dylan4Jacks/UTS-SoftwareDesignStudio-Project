CREATE PROCEDURE [dbo].[spCategoryItem_GetAll]
AS
BEGIN
	SELECT CategoryItemId, Name, Details, CategoryListId
	FROM dbo.[CategoryItem];
END