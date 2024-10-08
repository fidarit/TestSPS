CREATE TRIGGER TR_ProductVersion_Update ON dbo.ProductVersion
AFTER UPDATE
AS
BEGIN
	INSERT INTO dbo.EventLog (Description)
    SELECT 'Изменена версия изделия: ' + new.Name 
	FROM inserted new;
END;