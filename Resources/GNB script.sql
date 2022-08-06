USE [GNB_Db]
GO
/****** Object:  Schema [GNB]    Script Date: 8/6/2022 6:26:24 PM ******/
CREATE SCHEMA [GNB]
GO
/****** Object:  Table [GNB].[Rate]    Script Date: 8/6/2022 6:26:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GNB].[Rate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fromR] [varchar](50) NULL,
	[toR] [varchar](50) NULL,
	[rate] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GNB].[Transactions]    Script Date: 8/6/2022 6:26:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GNB].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[sku] [varchar](50) NULL,
	[toR] [varchar](50) NULL,
	[currency] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
