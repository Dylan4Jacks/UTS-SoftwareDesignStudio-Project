CREATE PROCEDURE [dbo].[spGroup_Insert]
	@GroupName nvarchar(50),
	@GroupDetails nvarchar(50)
AS
begin
	insert into dbo.[Group] (GroupName, GroupDetails)
	values (@GroupName, @GroupDetails);
end
