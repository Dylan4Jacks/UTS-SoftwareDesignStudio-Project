CREATE PROCEDURE [dbo].[spGroup_GetAll]
AS
BEGIN
	SELECT GroupId, GroupName, Details
	FROM dbo.[Group];
END