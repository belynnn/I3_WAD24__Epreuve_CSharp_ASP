﻿CREATE PROCEDURE [dbo].[SP_Jeu_GetAll]
AS
BEGIN
    SELECT 
        [JeuId],
        [Nom],
        [Description],
        [AgeMin],
        [AgeMax],
        [NbJoueurMin],
        [NbJoueurMax],
        [DureeMinute],
        [DateCreation],
        [DateDesactivation]
    FROM [dbo].[Jeux]
END