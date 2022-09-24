CREATE PROCEDURE [dbo].[spGroup_GetAll]
AS
BEGIN
	SELECT GroupId, GroupName
	FROM dbo.[Group];
END
