
USE [CrystalMindTask]
GO

/****** Object:  Table [dbo].[Addresses]    Script Date: 5/15/2022 6:06:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 5/15/2022 6:06:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[Addresses] ON
GO

INSERT [dbo].[Addresses] ([AddressID], [StreetName], [FlatNo], [FloorNo], [CustomerId]) VALUES (3, N'Gawahergy', 1, 1, 3)
GO

INSERT [dbo].[Addresses] ([AddressID], [StreetName], [FlatNo], [FloorNo], [CustomerId]) VALUES (1002, N'Gawahergy', 1, 1, 1002)
GO

INSERT [dbo].[Addresses] ([AddressID], [StreetName], [FlatNo], [FloorNo], [CustomerId]) VALUES (1003, N'Gawahergy', 1, 1, 1003)
GO

INSERT [dbo].[Addresses] ([AddressID], [StreetName], [FlatNo], [FloorNo], [CustomerId]) VALUES (1004, N'Gawahergy', 2, 1, 1003)
GO

SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO

SET IDENTITY_INSERT [dbo].[Customers] ON
GO

INSERT [dbo].[Customers] ([CustomerID], [CustomerFristName], [CustomerLastName], [CustomerGender], [CustomerDOB], [CustomerEmail]) VALUES (3, N'Nancy', N'Samy', N'M', CAST(N'2020-11-30' AS Date), N'nancysamy900@gmail.com')
GO

INSERT [dbo].[Customers] ([CustomerID], [CustomerFristName], [CustomerLastName], [CustomerGender], [CustomerDOB], [CustomerEmail]) VALUES (1002, N'Nancy', N'Samy', N'M', CAST(N'2020-11-30' AS Date), N'nancysamy900@gmail.com')
GO

INSERT [dbo].[Customers] ([CustomerID], [CustomerFristName], [CustomerLastName], [CustomerGender], [CustomerDOB], [CustomerEmail]) VALUES (1003, N'NancyUpdated', N'Samy', N'M', CAST(N'2020-11-30' AS Date), N'nancysamy900@gmail.com')
GO

SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
