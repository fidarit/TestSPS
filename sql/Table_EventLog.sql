CREATE TABLE dbo.EventLog  
(
	ID			uniqueidentifier DEFAULT NEWID(),
	EventDate	datetimeoffset NOT NULL DEFAULT GETDATE(),
	Description nvarchar(MAX),
	
	CONSTRAINT PK_EventLog_ID PRIMARY KEY(ID)
);

CREATE NONCLUSTERED INDEX IX_EventLog_EventDate
    ON dbo.EventLog(EventDate) WITH (ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON);