CREATE PROCEDURE [dbo].[spGroup_Insert]
	@GroupId int,
	@GroupName nvarchar(50),
	@Details nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.[Group] (GroupId, GroupName, Details)
	VALUES (@GroupId, @GroupName, @Details)
END
