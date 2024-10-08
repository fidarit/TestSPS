CREATE TRIGGER TR_Product_Delete ON dbo.Product
AFTER DELETE
AS
BEGIN
	INSERT INTO dbo.EventLog (Description)
    SELECT 'Удалено изделие: ' + old.Name 
	FROM deleted old;
END;