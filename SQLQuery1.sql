USE [engineeringPortal_processRouting]
GO

/****** Object:  Table [dbo].[engineeringPortal_processRouting]    Script Date: 06/03/2025 09:00:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[engineeringPortal_processRouting](
	[id] [int] NOT NULL identity ,
	[processType] [varchar](50) NULL,
	[opNumber] [varchar](50) NULL,
	[workcenter] [varchar](50) NULL,
	[processDescriptionShort] [varchar](255) NULL,
	[processDescriptionLong] [varchar](255) NULL,
	[processSpec] [varchar](50) NULL,
	[processInstruction] [varchar](50) NULL,
	[checkingChart] [varchar](50) NULL,
	[kc] [varchar](50) NULL,
	[fixture] [varchar](50) NULL,
	[notes] [varchar](50) NULL,
 CONSTRAINT [PK_engineeringPortal_processRouting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


