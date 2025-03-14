CREATE PROCEDURE [dbo].[SP_Game_Top10_Emprunter]
AS
BEGIN
    -- Sélectionner les 10 jeux les plus empruntés en comptant uniquement les emprunts
    SELECT TOP 10 
        j.[JeuId],
        j.[Nom],
        j.[Description],
        COUNT(e.[EmpruntId]) AS NombreEmprunts
    FROM [dbo].[Emprunt] e
    INNER JOIN [dbo].[Jeux] j ON e.[JeuId] = j.[JeuId]
    GROUP BY j.[JeuId], j.[Nom], j.[Description]
    ORDER BY NombreEmprunts DESC;
END