USE [BSDB2]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 3/13/2022 4:07:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[IDAdmin] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](50) NULL,
	[Hometown] [nvarchar](250) NULL,
	[DateOfBirth] [smalldatetime] NULL,
	[DateOfDeath] [smalldatetime] NULL,
	[Biographic] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[PublisherID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
	[BookName] [nvarchar](250) NULL,
	[Price] [money] NULL,
	[Description] [nvarchar](500) NULL,
	[Translator] [nvarchar](50) NULL,
	[Image] [varchar](50) NULL,
	[DateUpdate] [smalldatetime] NULL,
	[Inventory] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [varchar](50) NULL,
	[DateOfBirth] [smalldatetime] NULL,
	[Account] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ConfirmPassword ] [varchar](50) NOT NULL,
	[DateCreate] [datetime] NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FBID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Phone] [varchar](50) NULL,
	[Contents] [nvarchar](500) NULL,
	[DateUpdate] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FBID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[DateStart] [smalldatetime] NULL,
	[DateEnd] [smalldatetime] NULL,
	[OrderStatus] [bit] NULL,
	[CustomerID] [int] NOT NULL,
	[Payment] [int] NULL,
	[Tracking] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[BookID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 3/13/2022 4:07:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[PublisherID] [int] IDENTITY(1,1) NOT NULL,
	[PublisherName] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PublisherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([IDAdmin], [Account], [Password], [FullName], [Status]) VALUES (1, N'admin', N'admin', N'Thanh Nhan', 1)
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (1, N'Donald J. Trump ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (2, N'Xuan Quynh', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (3, N'Trinh Huyen Trang', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (4, N'Nguyen Nhat Anh', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (5, N'Nguyen Kim Tuan ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (6, N'Vo Van Nhi', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (7, N'May McCarthy', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (8, N'Nguyen Danh Lam', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (9, N'Ai Van', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (10, N'My Chi', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (11, N'David Ebershoff ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (12, N'Jojo Moyes ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (13, N'J. K. Rowling ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (14, N'Do Huan ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (15, N'Pham Tuan Son ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (16, N' Luong Duc Thiep ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (17, N'Watanabe Dzunichi ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (18, N'Tran Thi Huyen Thao ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (19, N'Tieu Hong Hoa ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (20, N'Jo Gang-Soo ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (21, N'Thich Nhat Nhu', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (22, N' NXB Chinh Tri Quoc Gia', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (23, N'Her Worlds', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (24, N'Dale Carnegie', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (25, N'Bo GD-DT', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (26, N'Eiichiro Oda', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (27, N'Akira Toriyama', NULL, NULL, NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [AuthorName], [Hometown], [DateOfBirth], [DateOfDeath], [Biographic]) VALUES (28, N'Fujiko F Fujio', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (8, 3, 2, 2, N'Combo Stay Calm + There''s a Way, Don''t Worry', 13000.0000, N'Keep Calm! Life cycle, there will be love, there will be hate. It would be impossible to advise people not to hate anyone. I used to hate people too, because I thought they were the cause of me losing what I loved. But in the end,', NULL, N'cu-binh-tinh.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 5)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (9, 7, 4, 5, N'Every Morning Let''s Create Something New', 90000.0000, N'From birth, you have been a creative person. You see the world with curious eyes, full of excitement. in highly challenging situations.You ...', NULL, N'moi-buoi-sang-hay-tao-ra-mot-dieu-gi-do-moi-me.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 8)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (10, 3, 3, 9, N'Once Upon A Time There Was A Love Story', 34000.0000, N'Once upon a time, there was a love story that was a touching story when people loved each other, the longing for such a warm and peaceful happiness; Or is it simply a matter of three people - you, me, and that person…?', NULL, N'ngay-xua-co-mot-chuyen-tinh.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 12)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (11, 1, 8, 13, N'Harry Potter And The Cursed Child - Parts I & II ', 53000.0000, NULL, NULL, N'harrypotter.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 4)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (12, 2, 1, 14, N'Skilled Trainer', 12000.0000, N'EVERYTHING YOU NEED FOR TRAINING & DEVELOPMENT “The only thing that remains the same these days is…change.” “Let''s face it, a leader who wants good employees has only two choices: either hire or stand..', NULL, N'nha-dao-tao-sanh-soi.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 12)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (13, 2, 1, 15, N'Dare To Get Rich', 32000.0000, N'There are many different ways to become rich, but how to go to the destination of wealth is what we care about. In the age of living with technology, making money is not difficult', NULL, N'dam-lam-giau.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 7)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (14, 3, 9, 16, N'Vietnam Poetry and Social Literature', 54000.0000, N'For Luong Duc Thiep, Literature is the product and weapon of class struggle. Literature is used to instill ideas into the public consciousness. The more intense the class conflict, the darker the influence of caste interests everywhere', NULL, N'viet-nam.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 4)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (16, 4, 9, 17, N'No Shading Lights', 40000.0000, N'The literary quintessence of every human being needs to be discovered and rediscovered. Every great work is a miracle and every visit is a pleasurable adventure. Coming to the novel The Lamp Doesn''t Shine, we are walking', NULL, N'den-khong-hat-bong.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 23)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (17, 9, 1, 4, N'Dream of Changing Your Life', 45000.0000, N'The desire to change life is like a seed that is sown, passed on from one generation to another. Sometimes the seed in the barren land also grows fat on its own, but most of it is quickly shrivelled in the middle by objective conditions. . The problem is... View details', NULL, N'mong-doi-doi.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 22)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (29, 13, 6, 11, N'Danish Girl', 95000.0000, N'The Danish Girl is a touching story about the world''s first transgender person, a Danish artist who bravely faced and returned to her own self. This is also a story about altruism, sacrifice in love. All are expressed in a clear and beautiful style.', NULL, N'co-gai-dan-mach.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 6)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (30, 6, 4, 19, N'Language Development', 36000.0000, N'The book series of Children''s Intellectual Development Through Sticker Games (4-6 years old) helps children develop Creativity, Math, Language, Thinking, intelligence training, hand dexterity. Books with 150-300 stickers + stories + games to help your baby learn and play. Please ..', NULL, N'phat-trien-kha-nang-ngon-ngu.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 16)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (31, 8, 10, 20, N'Toeic Test Preparation 750 Reading', 87000.0000, N'5 HOURS PER DAY, GET 750 POINTS IMMEDIATELY • PROVIDE RICH AND DIFFERENTLY DIFFERENT AND DIFFERENT TEST QUESTIONS AND SAMPLES • DETAILED ANALYSIS, EFFICIENT HOW TO WORK PART 7 INSTANT EFFICIENCY – COMPLETE TOEIC 1. Courage to break the notion that ''theory is fundamental''! Although memorized', NULL, N'luyen-thi-toeic.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 5)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (32, 9, 1, 21, N'Tripitaka Dharma Number', 30000.0000, N'The Tripitaka of the Dharma, also known as Dai Minh Phap Number or the Buddhist Study Dictionary... is a set of books that help Buddhist learners easily look up the Buddha''s teachings, suitable for many classes of subjects: from beginners to advanced people. high, due to Nhat Nhu, Dao...', NULL, N'tam-tang-phap.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 6)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (34, 14, 12, 23, N'Radiant Youth', 9000.0000, NULL, NULL, N'tap-chi-lam-dep-2.jpg', CAST(N'2022-05-03T00:00:00' AS SmallDateTime), 12)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (35, 5, 13, 24, N'Dac Nhan Tam (Reissue 2021)', 9000.0000, NULL, NULL, N'dacnhantam.jpg', CAST(N'2022-07-03T00:00:00' AS SmallDateTime), 15)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (36, 10, 14, 25, N'Vietnam Geographical Atlas - 2021', 9000.0000, NULL, NULL, N'alat.jpg', CAST(N'2022-03-07T00:00:00' AS SmallDateTime), 10)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (37, 6, 15, 28, N'Year 2112 Doraemon Born (2019 Reissue)', 9000.0000, NULL, NULL, N'doraemon.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 15)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (38, 6, 15, 27, N'Dragon Ball - 7 Dragon Balls Episode 8: Son Goku Raid (2019 Reissue)', 8500.0000, NULL, NULL, N'goku.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 15)
INSERT [dbo].[Book] ([BookID], [CategoryID], [PublisherID], [AuthorID], [BookName], [Price], [Description], [Translator], [Image], [DateUpdate], [Inventory]) VALUES (39, 6, 15, 26, N'One Piece Episode 77: Smile (2019 Reissue)', 5000.0000, NULL, NULL, N'onepice.jpg', CAST(N'2022-03-03T00:00:00' AS SmallDateTime), 15)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1, N'Books of Literature')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (2, N'Economic Book')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (3, N'Book of Domestic Literature')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (4, N'Books of Foreign Literature')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (5, N'Book of Skills - Life')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (6, N'Children''s Books')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (7, N'Personal Development Book')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (8, N'Book of Informatics - Foreign Language')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (9, N'Specialized Book')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (10, N'Textbooks - Reference Books')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (13, N'Literary-Fiction Books')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (14, N'Magazine - Stationery')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [Email], [Address], [Phone], [DateOfBirth], [Account], [Password], [ConfirmPassword ], [DateCreate], [Status]) VALUES (6, N'Trần Thanh Nhân', N'heinekencn@gmail.com', N'Huyện Cái Nước', N'+841275378057', CAST(N'2001-07-24T00:00:00' AS SmallDateTime), N'test', N'123456', N'123456', CAST(N'2022-03-10T22:02:36.463' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [DateStart], [DateEnd], [OrderStatus], [CustomerID], [Payment], [Tracking]) VALUES (1, CAST(N'2022-03-11T08:39:00' AS SmallDateTime), CAST(N'2022-03-14T08:39:00' AS SmallDateTime), 1, 6, 1, NULL)
INSERT [dbo].[Order] ([OrderID], [DateStart], [DateEnd], [OrderStatus], [CustomerID], [Payment], [Tracking]) VALUES (2, CAST(N'2022-03-11T08:39:00' AS SmallDateTime), CAST(N'2022-03-14T08:39:00' AS SmallDateTime), 1, 6, 1, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([BookID], [OrderID], [Quantity], [Price]) VALUES (34, 2, 1, 9000.0000)
INSERT [dbo].[OrderDetail] ([BookID], [OrderID], [Quantity], [Price]) VALUES (35, 1, 1, 9000.0000)
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (1, N'NXB Lao Dong', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (2, N'NXB The Gioi', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (3, N'NXB Tri Thuc', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (4, N'NXB Phu Nu', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (5, N'NXB Phuong Dong', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (6, N'NXB Tre', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (7, N'ArtBook', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (8, N'CDIMex', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (9, N'NXB Hoi Nha Van', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (10, N'NXB Khoa Hoc Xa Hoi', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (11, N' NXB Chinh Tri Quoc Gia', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (12, N'Her Worlds', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (13, N'NXB TPHCM', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (14, N'NXB Giao duc Viet Nam', NULL, NULL)
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [Address], [Phone]) VALUES (15, N'NXB Kim Dong', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT (getdate()) FOR [DateUpdate]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [DateStart]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([PublisherID])
REFERENCES [dbo].[Publisher] ([PublisherID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
