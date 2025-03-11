﻿CREATE TABLE [dbo].[Etat] (
    [EtatId] INT IDENTITY(1,1) NOT NULL ,
    [Nom] NVARCHAR(50) NOT NULL ,
    CONSTRAINT PK_Etat PRIMARY KEY ([EtatId]),
    CONSTRAINT UQ_Etat_Nom UNIQUE ([Nom])
);