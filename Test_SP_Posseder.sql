-- TESTS: SP_Posseder_Insert
DECLARE @TestUtilisateurId INT = 1;  -- Assurez-vous que cet utilisateur existe
DECLARE @TestJeuId INT = 1;  -- Assurez-vous que ce jeu existe
DECLARE @TestEtatId INT = 1;  -- Assurez-vous que cet état existe (ex: "Bon état")

-- Insérer un jeu dans la collection de l'utilisateur
EXEC [dbo].[SP_Posseder_Insert] 
    @UtilisateurId = @TestUtilisateurId, 
    @JeuId = @TestJeuId, 
    @EtatId = @TestEtatId;

-- Vérifier l'insertion
SELECT * FROM [dbo].[Posseder] 
WHERE [UtilisateurId] = @TestUtilisateurId 
  AND [JeuId] = @TestJeuId;

-- TESTS: SP_Posseder_GetByUser
EXEC [dbo].[SP_Posseder_GetByUser] @UtilisateurId = @TestUtilisateurId;

-- Récupération de l'ID de la possession pour les tests suivants
DECLARE @TestEtatPossessionId INT;
SELECT @TestEtatPossessionId = [EtatId] 
FROM [dbo].[Posseder] 
WHERE [UtilisateurId] = @TestUtilisateurId AND [JeuId] = @TestJeuId;

-- TESTS: SP_Posseder_GetById
EXEC [dbo].[SP_Posseder_GetById] 
    @UtilisateurId = @TestUtilisateurId, 
    @JeuId = @TestJeuId;

-- TESTS: SP_Posseder_Update
EXEC [dbo].[SP_Posseder_Update] 
    @UtilisateurId = @TestUtilisateurId, 
    @JeuId = @TestJeuId, 
    @EtatId = 2;  -- Changer l'état (ex: "Abîmé")

-- Vérifier la mise à jour
SELECT * FROM [dbo].[Posseder] 
WHERE [UtilisateurId] = @TestUtilisateurId 
  AND [JeuId] = @TestJeuId;

-- TESTS: SP_Posseder_Delete
EXEC [dbo].[SP_Posseder_Delete] 
    @UtilisateurId = @TestUtilisateurId, 
    @JeuId = @TestJeuId;

-- Vérifier la suppression
SELECT * FROM [dbo].[Posseder] 
WHERE [UtilisateurId] = @TestUtilisateurId 
  AND [JeuId] = @TestJeuId;