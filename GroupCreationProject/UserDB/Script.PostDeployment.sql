if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, Email, Preferences, Skills, GroupId)
	values ('John', 'Smith', 'John.Smith@gmail.com', 'Mary Jane', 'Communication', null),
	('Mary', 'Jane', 'Mary.Jane@gmail.com', 'Kate Allen', 'Leadership', 1),
	('Sue', 'Solomon', 'Sue.Solomon@gmail.com', 'John Smith', 'Problem Solving', null),
	('Kate', 'Allen', 'Kate.Allen@gmail.com', 'John Smith', 'Visual Design', 1);

	insert into dbo.[Group] (GroupName, GroupDetails)
	values (null, null), ('The Incredibles', 'Group filled with Incredible people'), ('Jungle Book', null);
end
