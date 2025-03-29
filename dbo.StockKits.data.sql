SET IDENTITY_INSERT [dbo].[StockKits] ON
INSERT INTO [dbo].[StockKits] ([StockKitId], [ExtendedDescription], [JobId], [DateIn], [DueDate], [Status]) VALUES (1002, N'abc', 123, N'12345', N'6789', 1)
SET IDENTITY_INSERT [dbo].[StockKits] OFF
DELETE FROM StockKits WHERE StockKitId = 1002;
