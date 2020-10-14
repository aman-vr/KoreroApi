CREATE TABLE [dbo].[ProjectList]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ProjectName] NVARCHAR(50) NOT NULL
	,[CreatedAt] DATETIME NOT NULL,
    [ModifiedAt] DATETIME NOT NULL,
)
