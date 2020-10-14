CREATE TABLE [dbo].[ProjectImage]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [ProjectImage] NVARCHAR(MAX) NOT NULL, 
    [ProjectListId] int foreign key references ProjectList(Id)
)
