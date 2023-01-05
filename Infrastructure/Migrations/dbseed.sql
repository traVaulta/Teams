use Teams;

if (
	exists(select * from sys.sysobjects where name = 'Person' and xtype = 'U') and
	(select count(*) from [Teams].[dbo].[Person]) = 0
)
  INSERT INTO [Teams].[dbo].[Person] (username, firstName, lastName, email)
  VALUES (
	'samanthasmith',
	'Samantha',
	'Smith',
	'smith.samantha@outlook.com'
  ), (
	'johnsmith',
	'John',
	'Smith',
	'smith.john@outlook.com'
  );
;
