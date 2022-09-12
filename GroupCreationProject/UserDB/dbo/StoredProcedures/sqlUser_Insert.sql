CREATE PROCEDURE [dbo].[sqlUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Preferences nvarchar(100),
	@Skills nvarchar(100)
AS
begin
	insert into dbo.[User] (FirstName, LastName, Email, Preferences, Skills)
	values (@FirstName, @LastName, @Email, @Preferences, @Skills);
end
