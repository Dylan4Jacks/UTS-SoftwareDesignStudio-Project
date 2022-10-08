if not exists (select 1 from dbo.[Student])
begin
	insert into dbo.[Student] (FirstName, LastName, Email, Password, GroupId)
	values ('John', 'Smith', 'John.Smith@gmail.com', 'a', null),
	('Mary', 'Jane', 'Mary.Jane@gmail.com', 'b', 1),
	('Sue', 'Solomon', 'Sue.Solomon@gmail.com', 'c', null),
	('Kate', 'Allen', 'Kate.Allen@gmail.com', 'd', 1);

	insert into dbo.[CategoryList] (Name, Details)
	values ('A', null);

	insert into dbo.[CategoryItem] (Name, Details, CategoryListId)
	values ('Apple', null, 1);

	insert into dbo.[CategorySelection] (StudentId, CategoryItemId, Content)
	values (1, 1, null);

end
