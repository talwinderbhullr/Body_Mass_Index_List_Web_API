SET IDENTITY_INSERT [dbo].[BMIRecord] ON
INSERT INTO [dbo].[BMIRecord] ([Id], [Name], [Weight], [Height]) VALUES (1, N'Ravneet', CAST(70.00 AS Decimal(18, 2)), CAST(1.90 AS Decimal(18, 2)))
INSERT INTO [dbo].[BMIRecord] ([Id], [Name], [Weight], [Height]) VALUES (2, N'Danny', CAST(68.00 AS Decimal(18, 2)), CAST(1.20 AS Decimal(18, 2)))
INSERT INTO [dbo].[BMIRecord] ([Id], [Name], [Weight], [Height]) VALUES (3, N'Franklin', CAST(65.00 AS Decimal(18, 2)), CAST(1.10 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[BMIRecord] OFF

