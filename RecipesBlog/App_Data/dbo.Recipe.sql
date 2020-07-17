﻿CREATE TABLE Recipe
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Ingredients] NVARCHAR(MAX) NOT NULL, 
    [Directions] NVARCHAR(MAX) NOT NULL, 
    [Source] NVARCHAR(50) NULL
)