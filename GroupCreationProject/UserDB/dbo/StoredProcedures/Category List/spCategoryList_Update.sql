CREATE PROCEDURE [dbo].[spCategoryList_Update]
	@CategoryListId int,
	@Name nvarchar(50),
	@Details nvarchar(255)
AS
BEGIN
	UPDATE dbo.[CategoryList]
	SET Name = @Name, Details = @Details
	WHERE CategoryListId = @CategoryListId
END
