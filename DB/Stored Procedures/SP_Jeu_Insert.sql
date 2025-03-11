﻿CREATE PROCEDURE [dbo].[SP_Jeu_Insert]
    @Nom NVARCHAR(100),
    @Description NVARCHAR(MAX) = NULL,
    @AgeMin INT,
    @AgeMax INT,
    @NbJoueurMin INT,
    @NbJoueurMax INT,
    @DureeMinute INT = NULL
AS
BEGIN
    INSERT INTO [dbo].[Jeux] ([Nom], [Description], [AgeMin], [AgeMax], [NbJoueurMin], [NbJoueurMax], [DureeMinute])
    VALUES (@Nom, @Description, @AgeMin, @AgeMax, @NbJoueurMin, @NbJoueurMax, @DureeMinute)
END