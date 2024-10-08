CREATE TRIGGER TR_ProductVersion_Insert ON dbo.ProductVersion
AFTER INSERT
AS
BEGIN
	INSERT INTO dbo.EventLog (Description)
    SELECT 'Добавлена версия изделия: ' + new.Name 
	FROM inserted new;
END;