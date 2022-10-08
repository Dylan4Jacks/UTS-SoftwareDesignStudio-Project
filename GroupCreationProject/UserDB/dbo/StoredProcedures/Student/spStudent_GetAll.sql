CREATE PROCEDURE [dbo].[spStudent_GetAll]
AS
BEGIN
	SELECT StudentId, FirstName, LastName, Email, Password, GroupId
	FROM dbo.[Student];
END