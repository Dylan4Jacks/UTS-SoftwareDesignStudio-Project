CREATE PROCEDURE [dbo].[sqlUser_GetAll]
AS
begin
	select Id, FirstName, LastName, Email, Preferences, Skills
	from dbo.[User];
end
