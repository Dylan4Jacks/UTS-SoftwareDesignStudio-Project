CREATE PROCEDURE [dbo].[spCategoryItem_Insert]
	@Name nvarchar(50),
	@Details nvarchar(255),
	@CategoryListId int
AS
BEGIN
	INSERT INTO dbo.[CategoryItem] (Name, Details, CategoryListId)
	VALUES (@Name, @Details, @CategoryListId)
END
