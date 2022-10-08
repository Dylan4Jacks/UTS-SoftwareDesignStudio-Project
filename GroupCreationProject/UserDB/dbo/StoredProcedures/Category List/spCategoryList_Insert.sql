CREATE PROCEDURE [dbo].[spCategoryList_Insert]
	@Name nvarchar(50),
	@Details nvarchar(255)
AS
BEGIN
	INSERT INTO dbo.[CategoryList] (Name, Details)
	VALUES (@Name, @Details)
END
