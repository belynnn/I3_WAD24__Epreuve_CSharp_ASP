CREATE PROCEDURE [dbo].[SP_Posseder_GetByUser]
    @UtilisateurId INT
AS
BEGIN
    -- Récupérer tous les jeux possédés par un utilisateur
    SELECT p.*, j.[Nom], j.[Description], e.[Nom] AS Etat
    FROM [dbo].[Posseder] p
    JOIN [dbo].[Jeux] j ON p.[JeuId] = j.[JeuId]
    JOIN [dbo].[Etat] e ON p.[EtatId] = e.[EtatId]
    WHERE p.[UtilisateurId] = @UtilisateurId
END