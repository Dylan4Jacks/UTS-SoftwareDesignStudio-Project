CREATE PROCEDURE [dbo].[spCategoryItem_Update]
	@CategoryItemId int,
	@Name nvarchar(50),
	@Details nvarchar(255),
	@CategoryListId int
AS
BEGIN
	UPDATE dbo.[CategoryItem]
	SET Name = @Name, Details = @Details, CategoryListId = @CategoryListId
	WHERE CategoryItemId = @CategoryItemId
END
