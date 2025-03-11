-- TESTS: SP_Utilisateur_Insert
EXEC [dbo].[SP_Utilisateur_Insert] 
    @Email = 'test@example.com', 
    @MotDePasse = 'password123', 
    @Pseudo = 'TestUser';

-- Vérifier l'insertion
SELECT * FROM [dbo].[Utilisateur] WHERE Email = 'test@example.com';

-- TESTS: SP_Utilisateur_GetAll
EXEC [dbo].[SP_Utilisateur_GetAll];

-- TESTS: SP_Utilisateur_GetAllActive
EXEC [dbo].[SP_Utilisateur_GetAllActive];

-- Récupération de l'ID pour les tests suivants
DECLARE @TestUserId INT;
SELECT @TestUserId = UtilisateurId FROM [dbo].[Utilisateur] WHERE Email = 'test@example.com';

-- TESTS: SP_Utilisateur_GetById
EXEC [dbo].[SP_Utilisateur_GetById] @UtilisateurId = @TestUserId;

-- TESTS: SP_Utilisateur_Update
EXEC [dbo].[SP_Utilisateur_Update] @UtilisateurId = @TestUserId, @NewPseudo = 'UpdatedUser';

-- Vérifier la mise à jour
SELECT * FROM [dbo].[Utilisateur] WHERE UtilisateurId = @TestUserId;

-- TESTS: SP_Utilisateur_Delete
EXEC [dbo].[SP_Utilisateur_Delete] @UtilisateurId = @TestUserId;

-- Vérifier la désactivation
SELECT * FROM [dbo].[Utilisateur] WHERE UtilisateurId = @TestUserId;