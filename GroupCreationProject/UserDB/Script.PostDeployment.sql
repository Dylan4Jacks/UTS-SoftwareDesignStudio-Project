IF NOT EXISTS (SELECT 1 FROM dbo.[Student])
BEGIN
	INSERT INTO dbo.[Group] (GroupName, Details)
	values ('Alian Force', null), ('The Avengers', 'Apple'), ('Power Puff Girls', 'Hi'), 
		('Cats!', 'This is literaly a group full of cats who may or may not be part of the play Cats'), 
		('42', 'Apple'), ('Apples', 'Apple'), ('7', null), ('8', null), ('10', 'Apple'), ('42', 'Apple'),
		('Test1', null), ('Test2', null), ('Test3', null), ('Test4', null);

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
	
	INSERT INTO dbo.[CategoryItem] (Name, Details, CategoryListId)
	VALUES 
		('High Distinction', null, @preferences_Id), ('Pass', null, @preferences_Id), ('Distinction', null, @preferences_Id),
		('Server Development', null, @Background_Id), ('Web Development', null, @Background_Id), ('Data Analysis', null, @Background_Id), ('Management', null, @Background_Id),
		('Cooking', null, @Interests_Id), ('Sports', null, @Interests_Id),
		('Server SQL', null, @Capabilities_Id), ('Programming', null, @Capabilities_Id), ('Team Leading', null, @Capabilities_Id);
	
	INSERT INTO dbo.[Teacher] (FirstName, LastName, Email, Password)
	VALUES 
		('John', 'Smith', 'John.Smith@Teacher.com', '12345'),
		('Mary', 'Jane', 'Mary.Jane@Teacher.com', 'b'),
		('Sue', 'Solomon', 'Sue.Solomon@google.Teacher.com', 'c'),
		('Kate', 'Allen', 'Kate.Allen@Teacher.com', 'd'),
		('Test_A', null, 'TestA@Teacher.com', 'Test_A'),
		('Test_B', null, 'Test.B@Teacher.com', 'Test_B'),
		('Test_C', 'A', 'Test_C@google.Teacher.com', 'Test_C'),
		('Test_D', null, 'TestD@Teacher.com', 'Test_D');
	
	--NOTE: NEWID()   is the equivlant to RANDOM()

	--Get Random ID's from group table
	DECLARE @Random_Group_Id_1 int = (SELECT TOP 1 GroupId FROM dbo.[Group] ORDER BY NEWID())
	DECLARE @Random_Group_Id_2 int = (SELECT TOP 1 GroupId FROM dbo.[Group] ORDER BY NEWID())
	DECLARE @Random_Group_Id_3 int = (SELECT TOP 1 GroupId FROM dbo.[Group] ORDER BY NEWID())
	
	INSERT INTO dbo.[Student] (FirstName, LastName, Email, Password, GroupId)
	VALUES 
	('John', 'Smith', 'John.Smith@A.com', '12345', @Random_Group_Id_1),
	('Mary', 'Jane', 'Mary.Jane@Gmail.com', 'b', @Random_Group_Id_1),
	('Sue', 'Solomon', 'Sue.Solomon@google.Student.com', 'c', @Random_Group_Id_1),
	('Kate', 'Allen', 'Kate.Allen@Student.com', 'd', @Random_Group_Id_2),
	('Test_A', null, 'TestA@Student.com', 'Test_A', @Random_Group_Id_2),
	('Test_B', null, 'Test.B@Student.com', 'Test_B', @Random_Group_Id_3),
	('Test_C', 'A', 'Test_C@google.Student.com', 'Test_C', @Random_Group_Id_1),
	('Test_D', null, 'TestD@Student.com', 'Test_D', null),
	('Test_E', null, 'TestD@Student.com', 'Test_D', null);

	INSERT  INTO dbo.[CategorySelection] (StudentId, CategoryItemId, Content)
	SELECT TOP 10 StudentID, CategoryItemId, null FROM dbo.[Student] CROSS JOIN dbo.[CategoryItem] ORDER BY NEWID();

end
