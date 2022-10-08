CREATE PROCEDURE [dbo].[spCategorySelection_Insert]
	@Content nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.[CategorySelection] (Content)
	VALUES (@Content)
END
