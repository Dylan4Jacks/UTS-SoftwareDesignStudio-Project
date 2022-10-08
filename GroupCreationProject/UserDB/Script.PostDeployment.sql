if not exists (select 1 from dbo.[Student])
begin
	insert into dbo.[Group] (GroupName, Details)
	values ('a', 'Apple'), ('b', 'Apple'), ('c', 'Apple'), ('d', 'Apple'), ('e', 'Apple');

	insert into dbo.[Student] (FirstName, LastName, Email, Password, GroupId)
	values ('John', 'Smith', 'John.Smith@gmail.com', 'a', null),
	('Mary', 'Jane', 'Mary.Jane@gmail.com', 'b', 1),
	('Sue', 'Solomon', 'Sue.Solomon@gmail.com', 'c', null),
	('Kate', 'Allen', 'Kate.Allen@gmail.com', 'd', 1);

	insert into dbo.[CategoryList] (Name, Details)
	values ('A', null),  ('B', null), ('D', null), ('E', null), ('F', null);

	insert into dbo.[CategoryItem] (Name, Details, CategoryListId)
	values ('Banana', null, 3), ('Baaaba', null, 3), ('banza', null, 3), ('Blob', null, 3), ('Bob', null, 3)

	INSERT INTO dbo.[CategorySelection] (StudentId, CategoryItemId, Content)
	values (3, 3, 'My Fav Piano');

end
