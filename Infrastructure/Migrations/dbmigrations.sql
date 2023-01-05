use Teams;

if not exists(select * from sys.sysobjects where name = 'Person' and xtype = 'U')
	create table [Teams].[dbo].[Person] (
		id int identity(1,1) primary key not null,
		username nvarchar(50) not null unique,
		firstName nvarchar(50) not null,
		lastName nvarchar(50) not null,
		email nvarchar(50) not null unique
	);
;

if not exists(select * from sys.sysobjects where name = 'Conversation' and xtype = 'U')
	create table [Teams].[dbo].[Conversation] (
		id int identity(1,1) primary key not null,
		title nvarchar(50) not null
	);
;

if not exists(select * from sys.sysobjects where name = 'PersonConversationJunction' and xtype = 'U')
	create table [Teams].[dbo].[PersonConversationJunction] (
		personId int not null,
		conversationId int not null,
		constraint [FK_PersonConversationJunction_Person] foreign key([personId]) references [Teams].[dbo].[Person] ([id]),
		constraint [FK_PersonConversationJunction_Conversation] foreign key([conversationId]) references [Teams].[dbo].[Conversation] ([id]),
		constraint [PK_PersonConversationJunction] primary key clustered ([personId] asc, [conversationId] asc)
	);
;

if not exists(select * from sys.sysobjects where name = 'Message' and xtype = 'U')
	create table [Teams].[dbo].[Message] (
		id int identity(1,1) primary key not null,
		content nvarchar(50) not null,
		createdAt datetime not null,
		editedAt datetime not null,
		createdBy int,
		conversationId int,
		constraint [FK_Message_Person] foreign key([createdBy]) references [Teams].[dbo].[Person] ([id]),
		constraint [FK_Message_Conversation] foreign key([conversationId]) references [Teams].[dbo].[Conversation] ([id])
	);
;
