CREATE PROCEDURE [dbo].[spGroup_Insert]
	@GroupName nvarchar(50)
AS
begin
	insert into dbo.[Group] (GroupName)
	values (@GroupName);
end
