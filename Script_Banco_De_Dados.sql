USE [BDPROJETO]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 30/01/2022 18:15:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Codigo] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
	[CPF] [nvarchar](11) NOT NULL,
	[DataDeNascimento] [date] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 30/01/2022 18:15:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[Codigo] [uniqueidentifier] NOT NULL,
	[CodigoDoCliente] [uniqueidentifier] NOT NULL,
	[Logradouro] [nvarchar](50) NOT NULL,
	[SemNumero] [bit] NOT NULL,
	[Numero] [int] NULL,
	[Bairro] [nvarchar](40) NOT NULL,
	[Cidade] [nvarchar](40) NOT NULL,
	[Estado] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Endereco] ADD  CONSTRAINT [DF_Endereco_SemNumero]  DEFAULT ((0)) FOR [SemNumero]
GO
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Cliente] FOREIGN KEY([CodigoDoCliente])
REFERENCES [dbo].[Cliente] ([Codigo])
GO
ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Cliente]
GO
