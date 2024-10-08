CREATE TABLE dbo.ProductVersion
(
	ID				uniqueidentifier DEFAULT NEWID(),
	ProductID		uniqueidentifier NOT NULL,
	Name			nvarchar(255) NOT NULL,
	Description		nvarchar(max),
	CreatingDate	datetime NOT NULL DEFAULT GETDATE(),
	Width			real NOT NULL,
	Height			real NOT NULL,
	Length			real NOT NULL,

	CONSTRAINT PK_ProductVersion_ID PRIMARY KEY(ID), 
	CONSTRAINT FK_ProductVersion_ProductID FOREIGN KEY(ProductID)
		REFERENCES Product(ID) ON DELETE CASCADE,

	CONSTRAINT UQ_ProductVersion_Name UNIQUE(Name),
	
	CONSTRAINT CK_ProductVersion_Width CHECK(Width > 0),
	CONSTRAINT CK_ProductVersion_Height CHECK(Height > 0),
	CONSTRAINT CK_ProductVersion_Length CHECK(Length > 0)
);

CREATE NONCLUSTERED INDEX IX_ProductVersion_Name
    ON dbo.ProductVersion(Name) WITH (ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);

CREATE NONCLUSTERED INDEX IX_ProductVersion_CreatingDate
    ON dbo.ProductVersion(CreatingDate) WITH (ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);

CREATE NONCLUSTERED INDEX IX_ProductVersion_Width
    ON dbo.ProductVersion(Width) WITH (ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);

CREATE NONCLUSTERED INDEX IX_ProductVersion_Height
    ON dbo.ProductVersion(Height) WITH (ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);

CREATE NONCLUSTERED INDEX IX_ProductVersion_Length
    ON dbo.ProductVersion(Length) WITH (ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);