﻿CREATE PROCEDURE [dbo].[spUser_auth]
	@email varchar(50),
	@password varchar(50)
AS
BEGIN
	SELECT * FROM 
	dbo.[User]
	WHERE email = @email and password = @password
END