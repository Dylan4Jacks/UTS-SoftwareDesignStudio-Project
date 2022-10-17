CREATE PROCEDURE [dbo].[spGroup_Insert]
	@GroupName nvarchar(50),
	@Details nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.[Group] (GroupName, Details)
	VALUES (@GroupName, @Details)
END
