/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
-- 0. Ajout du salt unique par utilisateur
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Utilisateur' AND COLUMN_NAME = 'Salt')
BEGIN
    ALTER TABLE [dbo].[Utilisateur]
    ADD [Salt] UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL;
END

CREATE TABLE #UserSaltTemp (
    UtilisateurId INT,
    Salt UNIQUEIDENTIFIER
);

-- 1. Insertion dans la table Etat (table indépendante)
INSERT INTO [dbo].[Etat] ([Nom])
VALUES
    ('Neuf'),
    ('Incomplet'),
    ('Abimé');

-- 2. Insertion dans la table Tag (table indépendante)
INSERT INTO [dbo].[Tag] ([Tag])
VALUES
    ('Coopératif'),
    ('Equipe'),
    ('Dés'),
    ('Cartes'),
    ('Plateau'),
    ('Argent');

-- 3. Insertion dans la table Jeux (dépend de Etat)
INSERT INTO [dbo].[Jeux] ([Nom], [Description], [AgeMin], [AgeMax], [NbJoueurMin], [NbJoueurMax], [DureeMinute], [EtatId])
VALUES
    ('Monopoly', 'Jeu de société classique où l''objectif est de devenir riche en achetant et vendant des propriétés.', 8, 99, 2, 6, 120, 1),
    ('Risk', 'Jeu de stratégie où l''objectif est de conquérir le monde.', 12, 99, 2, 6, 180, 1);

-- 4. Insertion dans la table Utilisateur
INSERT INTO [dbo].[Utilisateur] ([Email], [MotDePasse], [Pseudo], [DateCreation], [Salt])
OUTPUT INSERTED.UtilisateurId, INSERTED.Salt INTO #UserSaltTemp (UtilisateurId, Salt)
VALUES 
    ('john.doe@example.com', '1234', 'JohnDoe', GETDATE(), NEWID()), 
    ('jane.smith@example.com', '1234', 'JaneSmith', GETDATE(), NEWID());

-- 5. Insertion dans la table Posseder (dépend de Utilisateur, Jeux, et Etat)
-- Assure-toi que les UtilisateurId et JeuId existent et sont valides
INSERT INTO [dbo].[Posseder] ([UtilisateurId], [JeuId], [EtatId])
VALUES
    (1, 1, 1),  -- JohnDoe possède Monopoly
    (2, 2, 1);  -- JaneSmith possède Risk

-- 6. Insertion dans la table Associer (dépend de Jeux et Tag)
INSERT INTO [dbo].[Associer] ([JeuId], [TagId])
VALUES
    (1, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Coopératif')),
    (1, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Plateau')),
    (2, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Dés')),
    (2, (SELECT TagId FROM [dbo].[Tag] WHERE Tag = 'Cartes'));

-- 7. Insertion dans la table Emprunt (dépend de Jeux et Utilisateur)
INSERT INTO [dbo].[Emprunt] ([JeuId], [PreteurId], [EmprunteurId], [DateEmprunt])
VALUES
    (1, 1, 2, GETDATE());  -- JohnDoe prête Monopoly à JaneSmith

UPDATE u
SET u.MotDePasse = dbo.SF_SaltAndHash(u.MotDePasse, ut.Salt)  -- Hash le mot de passe avec le salt
FROM [dbo].[Utilisateur] u
JOIN #UserSaltTemp ut ON u.UtilisateurId = ut.UtilisateurId;