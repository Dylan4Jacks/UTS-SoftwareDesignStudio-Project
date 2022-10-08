CREATE TABLE [dbo].[Student]
(
	[StudentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL,
    [GroupId] INT NULL,  
    CONSTRAINT [GroupId] FOREIGN KEY (GroupId) REFERENCES [Group] (GroupId)
)
