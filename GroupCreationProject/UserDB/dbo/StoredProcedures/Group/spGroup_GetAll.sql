CREATE PROCEDURE [dbo].[spGroup_GetAll]
AS
BEGIN
	SELECT GroupId, GroupName, GroupDetails
	FROM dbo.[Group];
END
