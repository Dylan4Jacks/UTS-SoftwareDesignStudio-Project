CREATE PROCEDURE [dbo].[spCategoryList_GetAll]
AS
BEGIN
	SELECT CategoryListId, Name, Details
	FROM dbo.[CategoryList];
END