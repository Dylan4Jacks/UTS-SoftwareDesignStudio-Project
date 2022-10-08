if not exists (select 1 from dbo.[Student])
begin
	insert into dbo.[Student] (FirstName, LastName, Email, Password, GroupId)
	values ('John', 'Smith', 'John.Smith@gmail.com', 'a', null),
	('Mary', 'Jane', 'Mary.Jane@gmail.com', 'b', 1),
	('Sue', 'Solomon', 'Sue.Solomon@gmail.com', 'c', null),
	('Kate', 'Allen', 'Kate.Allen@gmail.com', 'd', 1);

	insert into dbo.[Group] (GroupName, Details)
	values (null, null), ('The Incredibles', 'Group filled with Incredible people'), ('Jungle Book', null);
end
