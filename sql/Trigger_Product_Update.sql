CREATE TRIGGER TR_Product_Update ON dbo.Product
AFTER UPDATE
AS
BEGIN
	INSERT INTO dbo.EventLog (Description)
    SELECT 'Изменено изделие: ' + new.Name 
	FROM inserted new;
END;