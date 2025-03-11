CREATE PROCEDURE [dbo].[SP_Jeu_GetById]
    @JeuId INT
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
    WHERE [JeuId] = @JeuId
END