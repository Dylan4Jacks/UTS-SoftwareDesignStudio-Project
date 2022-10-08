CREATE PROCEDURE [dbo].[spCategorySelection_Item_GetAll]
	@CategoryItemId int
AS
BEGIN
	SELECT CategoryItemId, StudentId, Content
	FROM dbo.[CategorySelection]
	WHERE CategoryItemId = @CategoryItemId;
END
