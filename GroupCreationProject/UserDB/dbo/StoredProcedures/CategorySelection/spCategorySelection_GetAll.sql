CREATE PROCEDURE [dbo].[spCategorySelection_GetAll]
AS
BEGIN
	SELECT CategoryItemId, StudentId, Content
	FROM dbo.[CategorySelection];
END