CREATE PROCEDURE [dbo].[SP_Jeu_GetAllActive]
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
    WHERE [DateDesactivation] IS NULL -- Sélectionner uniquement les jeux non désactivés
    ORDER BY [DateCreation] DESC;
END