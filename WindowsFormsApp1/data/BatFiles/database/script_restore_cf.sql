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
SET @fileNameCatalog = @path + 'Catalog' + 'CF.BAK'  
SET @fileNameAAAAAACore = @path + 'AAAAAACore' + 'CF.BAK'  
SET @fileNameAAAAAAWorkingPaper = @path + 'AAAAAAWorkingPaper' + 'CF.BAK'  

RESTORE DATABASE [Catalog] FROM DISK = @fileNameCatalog  WITH  FILE = 1,  NOUNLOAD,  STATS = 5
RESTORE DATABASE AAAAAACore FROM DISK = @fileNameAAAAAACore   WITH  FILE = 1,  NOUNLOAD,  STATS = 5
RESTORE DATABASE AAAAAAWorkingPaper FROM DISK = @fileNameAAAAAAWorkingPaper  WITH  FILE = 1,  NOUNLOAD,  STATS = 5

