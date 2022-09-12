CREATE PROCEDURE [dbo].[sqlUser_Get]
	@Id int
AS
begin
	select Id, FirstName, LastName, Email, Preferences, Skills
	from dbo.[User]
	where Id = @Id;
end
