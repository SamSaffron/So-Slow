
IF OBJECT_ID(N'[dbo].[Badges]') is not null
	DROP TABLE [Badges]

IF OBJECT_ID(N'[dbo].[Comments]') is not null
	DROP TABLE [Comments]

IF OBJECT_ID(N'[dbo].[Posts]') is not null
	DROP TABLE [Posts]
	
IF OBJECT_ID(N'[dbo].[Users]') is not null
	DROP TABLE [Users]
	
IF OBJECT_ID(N'[dbo].[Votes]') is not null
	DROP TABLE [Votes]

CREATE TABLE [dbo].[Badges] (
  [Id]            [int]   IDENTITY ( 1 , 1 )   NOT NULL
  ,[UserId]       [int]   NULL
  ,[Name]         [nvarchar](50)   NULL
  ,[CreationDate] [datetime]   NULL,
  CONSTRAINT [PK_Badges] PRIMARY KEY CLUSTERED ( [Id] ASC ) WITH ( PAD_INDEX = OFF,STATISTICS_NORECOMPUTE = OFF,IGNORE_DUP_KEY = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY])
ON [PRIMARY]

CREATE TABLE [dbo].[Comments] (
  [Id]            [int]   NOT NULL
  ,[PostId]       [int]   NULL
  ,[Text]         [nvarchar](max)   NULL
  ,[CreationDate] [datetime]   NULL
  ,[UserId]       [int]   NULL,
  CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ( [Id] ASC ) WITH ( PAD_INDEX = OFF,STATISTICS_NORECOMPUTE = OFF,IGNORE_DUP_KEY = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY])
ON [PRIMARY]

                    
CREATE TABLE [dbo].[Posts](
	[Id] [int] NOT NULL,
	[PostTypeId] [int] NULL,
	[AcceptedAnswerId] [int] NULL,
	[CreationDate] [datetime] NULL,
	[Score] [int] NULL,
	[ViewCount] [int] NULL,
	[Body] [nvarchar](max) NULL,
	[OwnerUserId] [int] NULL,
	[OwnerDisplayName] [nvarchar](40) NULL,
	[LastEditorUserId] [int] NULL,
	[LastEditDate] [datetime] NULL,
	[LastActivityDate] [datetime] NULL,
	[Title] [nvarchar](250) NULL,
	[Tags] [nvarchar](150) NULL,
	[AnswerCount] [int] NULL,
	[CommentCount] [int] NULL,
	[FavoriteCount] [int] NULL,
	[ClosedDate] [datetime] NULL,
	[ParentId] [int] NULL,
CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Users] (
  [Id]              [int]   NOT NULL
  ,[Reputation]     [int]   NULL
  ,[CreationDate]   [datetime]   NULL
  ,[DisplayName]    [nvarchar](40)   NULL
  ,[LastAccessDate] [datetime]   NULL
  ,[WebsiteUrl]     [nvarchar](200)   NULL
  ,[Location]       [nvarchar](100)   NULL
  ,[Age]            [int]   NULL
  ,[AboutMe]        [nvarchar](max)   NULL
  ,[Views]          [int]   NULL
  ,[UpVotes]        [int]   NULL
  ,[DownVotes]      [int]   NULL,
  CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ( [Id] ASC ) WITH ( PAD_INDEX = OFF,STATISTICS_NORECOMPUTE = OFF,IGNORE_DUP_KEY = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY])
ON [PRIMARY]


CREATE TABLE [dbo].[Votes] (
[Id] [int] NOT NULL
,[PostId]       [int]   NULL
,[VoteTypeId]   [int]   NULL
,[CreationDate] [datetime]   NULL,
CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED ( [Id] ASC ) WITH ( PAD_INDEX = OFF,STATISTICS_NORECOMPUTE = OFF,IGNORE_DUP_KEY = OFF,ALLOW_ROW_LOCKS = ON,ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY])

ON [PRIMARY]

