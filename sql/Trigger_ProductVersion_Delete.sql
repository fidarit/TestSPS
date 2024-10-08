CREATE TRIGGER TR_ProductVersion_Delete ON dbo.ProductVersion
AFTER DELETE
AS
BEGIN
	INSERT INTO dbo.EventLog (Description)
    SELECT 'Удалена версия изделия: ' + old.Name 
	FROM deleted old;
END;