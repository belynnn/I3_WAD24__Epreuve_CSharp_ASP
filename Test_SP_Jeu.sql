-- TESTS: SP_Jeu_Insert
EXEC [dbo].[SP_Jeu_Insert] 
    @Nom = 'Test Jeu', 
    @Description = 'Un jeu pour tester', 
    @AgeMin = 8, 
    @AgeMax = 99, 
    @NbJoueurMin = 2, 
    @NbJoueurMax = 4, 
    @DureeMinute = 30;

-- Vérification de l'insertion
SELECT * FROM [dbo].[Jeux] WHERE [Nom] = 'Test Jeu';

-- Récupération de l'ID du jeu inséré
DECLARE @JeuId INT;
SELECT @JeuId = [JeuId] FROM [dbo].[Jeux] WHERE [Nom] = 'Test Jeu';

-- TESTS: SP_Jeu_GetById
EXEC [dbo].[SP_Jeu_GetById] @JeuId = @JeuId;

-- TESTS: SP_Jeu_GetAll
EXEC [dbo].[SP_Jeu_GetAll];

-- TESTS: SP_Jeu_Update
EXEC [dbo].[SP_Jeu_Update] 
    @JeuId = @JeuId,
    @Nom = 'Test Jeu Modifié', 
    @Description = 'Description modifiée', 
    @AgeMin = 10, 
    @AgeMax = 90, 
    @NbJoueurMin = 3, 
    @NbJoueurMax = 6, 
    @DureeMinute = 45,
    @EtatId = 1;

-- Vérification de la mise à jour
SELECT * FROM [dbo].[Jeux] WHERE [JeuId] = @JeuId;

-- TESTS: SP_Jeu_Delete
EXEC [dbo].[SP_Jeu_Delete] @JeuId = @JeuId;

-- Vérification de la suppression
SELECT * FROM [dbo].[Jeux] WHERE [JeuId] = @JeuId;