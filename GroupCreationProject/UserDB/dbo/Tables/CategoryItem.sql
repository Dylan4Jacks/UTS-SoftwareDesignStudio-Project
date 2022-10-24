CREATE TABLE [dbo].[CategoryItem]
(
	[CategoryItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL,
    [Details] NCHAR(255) NULL,
    [Ranking] INT NOT NULL,
    [CategoryListId] INT NOT NULL,
    CONSTRAINT [CategoryListId] FOREIGN KEY (CategoryListId) REFERENCES [CategoryList] (CategoryListId)
)
