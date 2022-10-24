CREATE PROCEDURE [dbo].[spCategoryItem_Insert]
	@Name nvarchar(50),
	@Details nvarchar(255),
	@Ranking int,
	@CategoryListId int
AS
BEGIN
	INSERT INTO dbo.[CategoryItem] (Name, Details, Ranking, CategoryListId)
	VALUES (@Name, @Details, @Ranking, @CategoryListId)
	SELECT SCOPE_IDENTITY()
END
