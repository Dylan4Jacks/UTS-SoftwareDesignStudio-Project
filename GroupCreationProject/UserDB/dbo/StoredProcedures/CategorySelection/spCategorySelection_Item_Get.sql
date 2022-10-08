CREATE PROCEDURE [dbo].[spCategorySelection_Item_Get]
	@CategoryItemId int
AS
BEGIN
	SELECT CategoryItemId, StudentId, Content
	FROM dbo.[CategorySelection]
	WHERE CategoryItemId = @CategoryItemId;
END
