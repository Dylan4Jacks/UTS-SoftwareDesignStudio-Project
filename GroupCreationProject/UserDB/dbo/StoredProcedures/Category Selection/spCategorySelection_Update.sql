CREATE PROCEDURE [dbo].[spCategorySelection_Update]
	@CategoryItemId int,
	@StudentId int,
	@Content nvarchar(50)
AS
BEGIN
	UPDATE dbo.[CategorySelection]
	SET Content = @Content
	WHERE CategoryItemId = @CategoryItemId AND StudentId = @StudentId
END
