USE [DBUtility]
GO
/****** Object:  Table [dbo].[TestTable]    Script Date: 2020/8/5 6:22:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreateOn] [datetime] NULL,
	[Boolean] [bit] NULL,
	[Amt_Numeric] [numeric](5, 2) NULL,
	[Amt_Decimal] [decimal](5, 2) NULL,
	[Amt_Float] [float] NULL,
	[Amt_Int] [int] NULL,
	[Desc_EN] [varchar](20) NULL,
	[Desc_CN] [nvarchar](20) NULL,
	[Key_EN] [char](10) NULL,
	[Key_CN] [nchar](10) NULL,
	[Remark_CN] [ntext] NULL,
	[Remark_EN] [text] NULL,
	[XML_Data] [xml] NULL,
 CONSTRAINT [PK__TestTabl__3214EC07E5FB20D4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TestTable] ADD  CONSTRAINT [DF_TestTable_Amt_Int]  DEFAULT ((99)) FOR [Amt_Int]
GO
