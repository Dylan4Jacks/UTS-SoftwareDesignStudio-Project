<<<<<<< Updated upstream:GroupCreationProject/UserDB/dbo/Tables/Student.sql
﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Preferences] NVARCHAR(100) NOT NULL,
    [Skills] NVARCHAR(100) NOT NULL
)
=======
﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Preferences] NVARCHAR(100) NOT NULL,
    [Skills] NVARCHAR(100) NOT NULL,
    CONSTRAINT [GroupId] FOREIGN KEY (GroupId) REFERENCES [Group] (GroupId)
)
>>>>>>> Stashed changes:GroupCreationProject/UserDB/dbo/Tables/User.sql
