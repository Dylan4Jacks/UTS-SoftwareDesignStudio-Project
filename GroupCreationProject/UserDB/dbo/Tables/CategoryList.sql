CREATE TABLE [dbo].[CategoryList]
(
	[CategoryListId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL,
    [Details] NCHAR(255) NULL
)
