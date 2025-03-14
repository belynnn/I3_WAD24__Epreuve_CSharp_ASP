CREATE PROCEDURE [dbo].[SP_Emprunt_GetAll]
AS
BEGIN
    -- Récupérer tous les emprunts avec le nom du jeu
    SELECT 
        E.[EmpruntId],
        E.[JeuId],
        G.[Nom] AS JeuNom,  -- Ajout du nom du jeu
        E.[PreteurId],
        E.[EmprunteurId],
        E.[DateEmprunt],
        E.[DateRetour],
        E.[EvaluationPreteur],
        E.[EvaluationEmprunteur]
    FROM [dbo].[Emprunt] E
    INNER JOIN [dbo].[Jeux] G ON E.[JeuId] = G.[JeuId];  -- Jointure avec la table Jeux
END