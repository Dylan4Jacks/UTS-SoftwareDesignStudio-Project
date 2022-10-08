if not exists (select 1 from dbo.[Student])
begin
	insert into dbo.[Group] (GroupName, Details)
	values ('a', 'Apple'), ('b', 'Apple'), ('c', 'Apple'), ('d', 'Apple'), ('e', 'Apple');

	insert into dbo.[Student] (FirstName, LastName, Email, Password, GroupId)
	values ('John', 'Smith', 'John.Smith@gmail.com', 'a', null),
	('Mary', 'Jane', 'Mary.Jane@gmail.com', 'b', 1),
	('Sue', 'Solomon', 'Sue.Solomon@gmail.com', 'c', null),
	('Kate', 'Allen', 'Kate.Allen@gmail.com', 'd', 1);

	--insert into dbo.[CategoryList] (Name, Details)
	--values ('A', null);

	--insert into dbo.[CategoryItem] (Name, Details, CategoryListId)
	--Select 'Apple', null, catList.CategoryListId
	--FROM dbo.[CategoryList] catList 
	--where catList.Name = 'A';

	--INSERT INTO dbo.[CategorySelection] (StudentId, CategoryItemId, Content)
	--SELECT name, stu.StudentId, cat.CategoryItemId, null
	--FROM dbo.[Student] stu, dbo.[CategoryItem] cat
	--where stu.Email = 'John.Smith@gmail.com' AND stu.Password = 'a'
	--AND cat.Name= 'Apple';

	--DELETE
	--FROM dbo.[Student]
	--WHERE Email = 'John.Smith@gmail.com' AND Password = 'a';
end
