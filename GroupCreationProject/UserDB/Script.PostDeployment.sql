if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, Email, Preferences, Skills, password)
	values ('John', 'Smith', 'John.Smith@gmail.com', 'Mary Jane', 'Communication', 'pinkfloyd2'),
	('Mary', 'Jane', 'Mary.Jane@gmail.com', 'Kate Allen', 'Leadership', 'slint44'),
	('Sue', 'Solomon', 'Sue.Solomon@gmail.com', 'John Smith', 'Problem Solving', 'deathgrips1'),
	('Kate', 'Allen', 'Kate.Allen@gmail.com', 'John Smith', 'Visual Design', 'blackflag99');

end
if not exists (select 1 from dbo.teacher)
begin
	insert into dbo.teacher (Id, name, email, password) values
	(1, 'steve balmer', 'stevebalmer@gmail.com', 'bahaus1234');
end