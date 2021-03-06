SET IDENTITY_INSERT [dbo].[photo_table] ON
INSERT INTO [dbo].[photo_table] ([photo_id], [photo], [type_id], [characteristics_id]) VALUES (3, (SELECT * FROM OPENROWSET(BULK N'E:\Diplom\DefectsDMS\bin\Debug\Photo\3.jpg', SINGLE_BLOB) AS image), 3, 3)
SET IDENTITY_INSERT [dbo].[photo_table] OFF
