if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, Email, Preferences, Skills)
	values ('John', 'Smith', 'John.Smith@gmail.com', 'Mary Jane', 'Communication'),
	('Mary', 'Jane', 'Mary.Jane@gmail.com', 'Kate Allen', 'Leadership'),
	('Sue', 'Solomon', 'Sue.Solomon@gmail.com', 'John Smith', 'Problem Solving'),
	('Kate', 'Allen', 'Kate.Allen@gmail.com', 'John Smith', 'Visual Design');
end
