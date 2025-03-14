CREATE PROCEDURE [dbo].[SP_Emprunt_GetAllActive]
AS
BEGIN
    -- Sélectionner tous les emprunts actifs avec le nom du jeu
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
    INNER JOIN [dbo].[Jeux] G ON E.[JeuId] = G.[JeuId]  -- Jointure avec la table Jeux
    WHERE E.[DateRetour] IS NULL;
END