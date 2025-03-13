CREATE PROCEDURE [dbo].[SP_Game_Top10_Emprunter]
AS
BEGIN
    SELECT TOP 10 
        J.JeuId,
        J.Nom,
        J.Description,
        COUNT(E.JeuId) AS BorrowCount
    FROM [dbo].[Jeux] AS J
    INNER JOIN [dbo].[Emprunt] AS E ON J.JeuId = E.JeuId
    GROUP BY J.JeuId, J.Nom, J.Description
    ORDER BY COUNT(E.JeuId) DESC;
END