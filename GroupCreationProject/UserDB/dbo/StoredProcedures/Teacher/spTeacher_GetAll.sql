CREATE PROCEDURE [dbo].[spTeacher_GetAll]
AS
BEGIN
	SELECT TeacherId, FirstName, LastName, Email, Password
	FROM dbo.[Teacher];
END