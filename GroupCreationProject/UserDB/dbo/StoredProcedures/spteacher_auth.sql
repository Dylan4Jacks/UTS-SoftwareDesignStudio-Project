CREATE PROCEDURE [dbo].[spteacher_auth]
	@email varchar(50),
	@password varchar(50)
AS
BEGIN
	SELECT * FROM 
	dbo.teacher 
	WHERE email = @email and password = @password
END