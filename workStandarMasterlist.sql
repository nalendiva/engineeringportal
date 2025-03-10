USE [workStandardMasterlist]
GO

/****** Object:  Table [dbo].[workStandarMasterlist]    Script Date: 10/03/2025 14:41:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[workStandarMasterlist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wsNumber] [varchar](50) NULL,
	[description] [varchar](50) NULL,
	[owner] [varchar](50) NULL,
	[dateEffective] [varchar](50) NULL,
	[expireDate] [varchar](50) NULL,
	[fileWs] [varchar](255) NULL,
	[note] [varchar](max) NULL,
 CONSTRAINT [PK_workStandarMasterlist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


