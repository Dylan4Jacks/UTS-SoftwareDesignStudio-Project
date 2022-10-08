CREATE PROCEDURE [dbo].[spCategoryList_Get]
	@CategoryListId int
AS
BEGIN
	SELECT CategoryListId, Name, Details
	FROM dbo.[CategoryList]
	WHERE CategoryListId = @CategoryListId;
END
