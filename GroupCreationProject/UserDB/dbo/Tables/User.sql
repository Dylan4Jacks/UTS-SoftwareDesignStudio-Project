CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Preferences] NVARCHAR(100) NOT NULL,
    [Skills] NVARCHAR(100) NOT NULL,
    [GroupId] INT NULL, 
    CONSTRAINT [GroupId] FOREIGN KEY (GroupId) REFERENCES [Group] (GroupId)
)
