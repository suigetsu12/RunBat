USE [master]

-- GO
-- ALTER DATABASE [Catalog] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
-- GO
-- ALTER DATABASE [AAAAAACore] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
-- GO
-- ALTER DATABASE [AAAAAAWorkingPaper] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
-- GO
-- /* Query to Drop Database in SQL Server  */
-- DROP DATABASE [Catalog]
-- GO
-- DROP DATABASE [AAAAAACore]
-- GO
-- DROP DATABASE [AAAAAAWorkingPaper]
-- GO
 
DECLARE @path VARCHAR(256) -- path for backup files  
DECLARE @fileNameCatalog VARCHAR(256) -- filename for backup  
DECLARE @fileNameAAAAAACore VARCHAR(256) -- filename for backup  
DECLARE @fileNameAAAAAAWorkingPaper VARCHAR(256) -- filename for backup
 


SET @path = $(path)
SET @fileNameCatalog = @path + 'Catalog' + '.BAK'  
SET @fileNameAAAAAACore = @path + 'AAAAAACore' + '.BAK'  
SET @fileNameAAAAAAWorkingPaper = @path + 'AAAAAAWorkingPaper' + '.BAK'  

RESTORE DATABASE [Catalog] FROM DISK = @fileNameCatalog  WITH REPLACE
RESTORE DATABASE AAAAAACore FROM DISK = @fileNameAAAAAACore  WITH REPLACE
RESTORE DATABASE AAAAAAWorkingPaper FROM DISK = @fileNameAAAAAAWorkingPaper WITH REPLACE

