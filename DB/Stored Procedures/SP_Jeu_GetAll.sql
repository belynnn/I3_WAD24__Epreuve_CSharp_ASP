CREATE PROCEDURE [dbo].[SP_Jeu_GetAll]
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
        [DateCreation]
    FROM [dbo].[Jeux]
END