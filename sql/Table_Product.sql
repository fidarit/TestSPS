CREATE TABLE dbo.Product  
(
	ID			uniqueidentifier DEFAULT NEWID(),
	Name		nvarchar(255) NOT NULL,
	Description nvarchar(MAX),
	
	CONSTRAINT PK_Product_ID PRIMARY KEY(ID), 
	CONSTRAINT UQ_Product_Name UNIQUE(Name) 
);

CREATE NONCLUSTERED INDEX IX_Product_Name
    ON dbo.Product(Name) WITH (ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);