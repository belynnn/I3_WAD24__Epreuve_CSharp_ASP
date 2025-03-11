-- TESTS: SP_Emprunt_Insert
DECLARE @TestJeuId INT = 1;  -- Assurez-vous que ce jeu existe
DECLARE @TestPreteurId INT = 1;  -- Assurez-vous que ce préteur existe
DECLARE @TestEmprunteurId INT = 2;  -- Assurez-vous que cet emprunteur existe

EXEC [dbo].[SP_Emprunt_Insert] 
    @JeuId = @TestJeuId, 
    @PreteurId = @TestPreteurId, 
    @EmprunteurId = @TestEmprunteurId;

-- Vérifier l'insertion
SELECT * FROM [dbo].[Emprunt] WHERE [PreteurId] = @TestPreteurId AND [EmprunteurId] = @TestEmprunteurId;

-- TESTS: SP_Emprunt_GetByUser
EXEC [dbo].[SP_Emprunt_GetByUser] @UtilisateurId = @TestPreteurId;

-- Récupération de l'ID de l'emprunt pour les tests suivants
DECLARE @TestEmpruntId INT;
SELECT @TestEmpruntId = [EmpruntId] FROM [dbo].[Emprunt] 
WHERE [PreteurId] = @TestPreteurId AND [EmprunteurId] = @TestEmprunteurId;

-- TESTS: SP_Emprunt_GetById
EXEC [dbo].[SP_Emprunt_GetById] @EmpruntId = @TestEmpruntId;

-- TESTS: SP_Emprunt_Update
EXEC [dbo].[SP_Emprunt_Update] 
    @EmpruntId = @TestEmpruntId, 
    @EvaluationPreteur = 4, 
    @EvaluationEmprunteur = 5;

-- Vérifier la mise à jour
SELECT * FROM [dbo].[Emprunt] WHERE [EmpruntId] = @TestEmpruntId;

-- TESTS: SP_Emprunt_Return
EXEC [dbo].[SP_Emprunt_Return] @EmpruntId = @TestEmpruntId;

-- Vérifier la date de retour
SELECT * FROM [dbo].[Emprunt] WHERE [EmpruntId] = @TestEmpruntId;

-- TESTS: SP_Emprunt_Delete
EXEC [dbo].[SP_Emprunt_Delete] @EmpruntId = @TestEmpruntId;

-- Vérifier la suppression
SELECT * FROM [dbo].[Emprunt] WHERE [EmpruntId] = @TestEmpruntId;
