USE [gestionPedidos]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 9/5/2022 6:13:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[document] [int] NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[mail] [nvarchar](50) NULL,
	[password] [nchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_Venta]    Script Date: 9/5/2022 6:13:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_Venta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[product_code] [int] NOT NULL,
	[order_code] [int] NOT NULL,
	[amount] [int] NOT NULL,
	[total_price] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pedido]    Script Date: 9/5/2022 6:13:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[clientCode] [int] NOT NULL,
	[date] [date] NOT NULL,
	[location] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 9/5/2022 6:13:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[provider_code] [int] NOT NULL,
	[product_name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NULL,
	[price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 9/5/2022 6:13:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[provider_name] [nvarchar](50) NOT NULL,
	[nit] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[phone] [numeric](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([Id], [name], [surname], [document], [phone], [mail], [password]) VALUES (1, N'duban', N'zapata', 1039450728, N'3214465989', N'duban@gmail.com', N'123       ')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[detalle_Venta] ON 

INSERT [dbo].[detalle_Venta] ([Id], [product_code], [order_code], [amount], [total_price]) VALUES (1, 1, 1, 1, CAST(1000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[detalle_Venta] OFF
GO
SET IDENTITY_INSERT [dbo].[pedido] ON 

INSERT [dbo].[pedido] ([Id], [clientCode], [date], [location]) VALUES (1, 1, CAST(N'2022-08-29' AS Date), N'cra63#74-20')
SET IDENTITY_INSERT [dbo].[pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([Id], [provider_code], [product_name], [description], [price]) VALUES (1, 1, N'producto', N'descripcion', CAST(1000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[proveedor] ON 

INSERT [dbo].[proveedor] ([Id], [provider_name], [nit], [address], [phone]) VALUES (1, N'proveedor', N'800118660', N'bello', CAST(3214465979 AS Numeric(18, 0)))
SET IDENTITY_INSERT [dbo].[proveedor] OFF
GO
ALTER TABLE [dbo].[detalle_Venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_Venta_ToTable] FOREIGN KEY([product_code])
REFERENCES [dbo].[producto] ([Id])
GO
ALTER TABLE [dbo].[detalle_Venta] CHECK CONSTRAINT [FK_detalle_Venta_ToTable]
GO
ALTER TABLE [dbo].[detalle_Venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_Venta_ToTable_1] FOREIGN KEY([product_code])
REFERENCES [dbo].[pedido] ([Id])
GO
ALTER TABLE [dbo].[detalle_Venta] CHECK CONSTRAINT [FK_detalle_Venta_ToTable_1]
GO
ALTER TABLE [dbo].[pedido]  WITH CHECK ADD  CONSTRAINT [FK_pedido_ToTable] FOREIGN KEY([clientCode])
REFERENCES [dbo].[cliente] ([Id])
GO
ALTER TABLE [dbo].[pedido] CHECK CONSTRAINT [FK_pedido_ToTable]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_ToTable] FOREIGN KEY([provider_code])
REFERENCES [dbo].[proveedor] ([Id])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_ToTable]
GO
