CREATE PROCEDURE [dbo].[spteacher_auth]
	@email varchar,
	@password varchar
AS
	SELECT * FROM 
	dbo.teacher 
	WHERE email = @email and password = @password
RETURN 0
