CREATE TABLE [dbo].[ProjectImage]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ProjectImage] NVARCHAR(MAX) NOT NULL, 
    [CreatedAt] DATETIME NOT NULL,
    [ModifiedAt] DATETIME NOT NULL,
    [ProjectListId] int foreign key references ProjectList(Id)
)
