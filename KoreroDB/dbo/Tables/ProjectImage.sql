CREATE TABLE [dbo].[ProjectImage]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ProjectImage] NVARCHAR(MAX) NOT NULL, 
    [ProjectId] INT NOT NULL
)
