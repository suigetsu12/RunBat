USE [AAAAAACore] 
GO 
INSERT INTO Entity(Id, Name, IsActive, SiteCollectionUrl) 
SELECT NEWID(), 'E11', 1, 'https://hainguyenstepmedia.sharepoint.com/sites/6e5f19be-a6f8-4ad5-940b-23054fb2420e' 
WHERE NOT EXISTS 
( 
SELECT 1 FROM Entity WHERE name='E11' 
); 