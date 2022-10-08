CREATE TABLE [dbo].[CategorySelection]
(
	[CategoryItemId] INT NOT NULL,
	[StudentId] INT NOT NULL,
	[Content] NVARCHAR(50) NULL, 
    CONSTRAINT [CategoryItemId] FOREIGN KEY (CategoryItemId) REFERENCES [CategoryItem] (CategoryItemId),
	CONSTRAINT [StudentId] FOREIGN KEY (StudentId) REFERENCES [Student] (StudentId),
	CONSTRAINT CategorySelectionId PRIMARY KEY (CategoryItemId, StudentId)
)
