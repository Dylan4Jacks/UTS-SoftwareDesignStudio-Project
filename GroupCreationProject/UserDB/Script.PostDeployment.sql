IF NOT EXISTS (SELECT 1 FROM dbo.[Student])
BEGIN
	INSERT INTO dbo.[Group] (GroupId, GroupName, Details)
	values (1, 'Alian Force', null), (2, 'The Avengers', 'Apple'), (3, 'Power Puff Girls', 'Hi'), 
		(4, 'Cats!', 'This is literaly a group full of cats who may or may not be part of the play Cats'), 
		(5, '42', 'Apple'), (6, 'Apples', 'Apple'), (7, '7', null), (8, '8', null), (9, '10', 'Apple'), (10, '42', 'Apple'),
		(11, 'Test1', null), (12, 'Test2', null), (13, 'Test3', null), (14, 'Test4', null);

	INSERT INTO dbo.[CategoryList] (Name, Details)
	VALUES 
		('Preferences', 'chose your preferences when working in your groups'), 
		('Background', null), 
		('Interests', 'Details about what you are interested in!'), 
		('Capabilities', 'what is it that you can do?'), 
		('F', null);

	--Get ID Based on Name - Not a good idea in production
	DECLARE @preferences_Id int = (SELECT [CategoryListId] FROM dbo.[CategoryList] WHERE Name = 'Preferences')
	DECLARE @Background_Id int = (SELECT [CategoryListId] FROM dbo.[CategoryList] WHERE Name = 'Background')
	DECLARE @Interests_Id int = (SELECT [CategoryListId] FROM dbo.[CategoryList] WHERE Name = 'Interests')
	DECLARE @Capabilities_Id int = (SELECT [CategoryListId] FROM dbo.[CategoryList] WHERE Name = 'Capabilities')
	DECLARE @F_Id int = (SELECT [CategoryListId] FROM dbo.[CategoryList] WHERE Name = 'F')
	
	INSERT INTO dbo.[CategoryItem] (Name, Details, Ranking, CategoryListId)
	VALUES 
		('High Distinction', null, 1, @preferences_Id), ('Pass', null, 5, @preferences_Id), ('Distinction', null, 9, @preferences_Id),
		('Server Development', null, 2, @Background_Id), ('Web Development', null, 6, @Background_Id), ('Data Analysis', null, 10, @Background_Id), ('Management', null, 12, @Background_Id),
		('Cooking', null, 3, @Interests_Id), ('Sports', null, 7, @Interests_Id),
		('Server SQL', null, 4, @Capabilities_Id), ('Programming', null, 8, @Capabilities_Id), ('Team Leading', null, 11, @Capabilities_Id);
	
	INSERT INTO dbo.[Teacher] (FirstName, LastName, Email, Password)
	VALUES 
		('John', 'Smith', 'John.Smith@Teacher.uts.com', '12345'),
		('Mary', 'Jane', 'Mary.Jane@Teacher.uts.com', 'b'),
		('Kate', 'Allen', 'Kate.Allen@Teacher.uts.com', 'd'),
		('Test_A', null, 'TestA@Teacher.uts.com', 'Test_A');
	
	--NOTE: NEWID()   is the equivlant to RANDOM()

	--Get Random ID's from group table
	DECLARE @Random_Group_Id_1 int = (SELECT TOP 1 GroupId FROM dbo.[Group] ORDER BY NEWID())
	DECLARE @Random_Group_Id_2 int = (SELECT TOP 1 GroupId FROM dbo.[Group] ORDER BY NEWID())
	DECLARE @Random_Group_Id_3 int = (SELECT TOP 1 GroupId FROM dbo.[Group] ORDER BY NEWID())
	
	INSERT INTO dbo.[Student] (FirstName, LastName, Email, Password, GroupId)
	VALUES 
	('John', 'Smith', 'John.Smith@Student.uts.com', '12345', @Random_Group_Id_1),
	('Mary', 'Jane', 'Mary.Jane@Student.uts.com', 'b', @Random_Group_Id_1),
	('Sue', 'Solomon', 'Sue.Solomon@Student.uts.com', 'c', @Random_Group_Id_1),
	('Kate', 'Allen', 'Kate.Allen@Student.uts.com', 'd', @Random_Group_Id_2),
	('Test_A', null, 'TestA@Student.uts.com', 'Test_A', @Random_Group_Id_2),
	('Test_B', null, 'Test.B@Student.uts.com', 'Test_B', @Random_Group_Id_3),
	('Test_C', 'A', 'Test_C@Student.uts.com', 'Test_C', @Random_Group_Id_1),
	('Test_D', null, 'TestD@Student.uts.com', 'Test_D', null),
	('Test_E', null, 'TestD@Student.uts.com', 'Test_D', null);

	INSERT  INTO dbo.[CategorySelection] (StudentId, CategoryItemId, Content)
	SELECT TOP 20 StudentID, CategoryItemId, null FROM dbo.[Student] CROSS JOIN dbo.[CategoryItem] ORDER BY NEWID();

end
