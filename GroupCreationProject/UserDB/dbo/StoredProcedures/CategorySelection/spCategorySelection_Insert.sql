CREATE PROCEDURE [dbo].[spCategorySelection_Insert]
	@CategoryItemId int,
	@StudentId int,
	@Content nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.[CategorySelection] (CategoryItemId, StudentId, Content)
	VALUES (@CategoryItemId, @StudentId, @Content)
END
