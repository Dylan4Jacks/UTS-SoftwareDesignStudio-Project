CREATE PROCEDURE [dbo].[sqlUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Preferences nvarchar(100),
	@Skills nvarchar(100)
AS
begin
	update dbo.[User]
	set FirstName = @FirstName, LastName = @LastName, Email = @Email, Preferences = @Preferences, Skills = @Skills
	where Id = @Id
end
