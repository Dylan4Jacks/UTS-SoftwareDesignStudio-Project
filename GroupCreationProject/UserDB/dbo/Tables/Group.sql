CREATE TABLE [dbo].[Group]
(
	[GroupId] INT NOT NULL PRIMARY KEY IDENTITY,
    [GroupName] NVARCHAR(50) NULL, 
    [GroupDetails] NCHAR(255) NULL
)