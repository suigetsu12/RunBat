
USE [AAAAAACore]
GO 
INSERT INTO Entity(Id, Name, IsActive, SiteCollectionUrl)
SELECT NEWID(), 'E12', 1, 'https://hainguyenstepmedia.sharepoint.com/sites/Local-AAAAAA-83b7fe22-65b9-4bd3-9b9c-0bccc8354dd2'
WHERE NOT EXISTS
(SELECT 1 FROM Entity WHERE name='E12')