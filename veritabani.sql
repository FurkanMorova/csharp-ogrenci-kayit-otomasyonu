USE [OgrenciKayitDB]
GO
/****** Object:  Table [dbo].[Ogrenciler]    Script Date: 16.07.2025 17:25:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenciler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NULL,
	[Soyad] [nvarchar](50) NULL,
	[TC] [nvarchar](11) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Okul] [nvarchar](100) NULL,
	[Adres] [nvarchar](200) NULL,
	[Puan] [float] NULL,
	[DogumTarihi] [date] NULL,
	[ResimYolu] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
