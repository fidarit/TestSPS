CREATE TRIGGER TR_Product_Insert ON dbo.Product
AFTER INSERT
AS
BEGIN
	INSERT INTO dbo.EventLog (Description)
    SELECT 'Добавлено изделие: ' + new.Name 
	FROM inserted new;
END;