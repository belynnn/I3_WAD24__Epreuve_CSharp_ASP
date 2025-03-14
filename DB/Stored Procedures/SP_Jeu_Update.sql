﻿CREATE PROCEDURE [dbo].[SP_Jeu_Update]
    @JeuId INT,
    @Nom NVARCHAR(100),
    @Description NVARCHAR(MAX) = NULL,
    @AgeMin INT,
    @AgeMax INT,
    @NbJoueurMin INT,
    @NbJoueurMax INT,
    @DureeMinute INT = NULL
AS
BEGIN
    UPDATE [dbo].[Jeux]
    SET 
        [Nom] = @Nom,
        [Description] = @Description,
        [AgeMin] = @AgeMin,
        [AgeMax] = @AgeMax,
        [NbJoueurMin] = @NbJoueurMin,
        [NbJoueurMax] = @NbJoueurMax,
        [DureeMinute] = @DureeMinute
    WHERE [JeuId] = @JeuId
END