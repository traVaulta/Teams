use Teams;

if not exists(select * from sys.sysobjects where name = 'Profile' and xtype = 'U')
	create table [Teams].[dbo].[Profile] (
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

if not exists(select * from sys.sysobjects where name = 'ProfileConversationJunction' and xtype = 'U')
	create table [Teams].[dbo].[ProfileConversationJunction] (
		profileId int not null,
		conversationId int not null,
		constraint [FK_ProfileConversationJunction_Profile] foreign key([profileId]) references [Teams].[dbo].[Profile] ([id]),
		constraint [FK_ProfileConversationJunction_Conversation] foreign key([conversationId]) references [Teams].[dbo].[Conversation] ([id]),
		contstraint [PK_MemoTagJunction] primary key clustered ([profileId] asc, [conversationId] asc)
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
		constraint [FK_Message_Profile] foreign key([createdBy]) references [Teams].[dbo].[Profile] ([id]),
		constraint [FK_Message_Conversation] foreign key([conversationId]) references [Teams].[dbo].[Conversation] ([id])
	);
;
