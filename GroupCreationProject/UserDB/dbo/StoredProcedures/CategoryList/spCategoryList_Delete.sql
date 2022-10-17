CREATE PROCEDURE [dbo].[spCategoryList_Delete]
	@CategoryListId int
AS
BEGIN
	DELETE
	FROM dbo.[CategoryList]
	WHERE CategoryListId = @CategoryListId;
END
