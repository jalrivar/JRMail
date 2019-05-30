USE JRMail;
        
SET NOCOUNT ON;

/********************************************************************************************************************************************************************************************/
--Creación de esquema.
/********************************************************************************************************************************************************************************************/
DECLARE @ESQUEMA CHAR(3) = 'JRM';
IF NOT EXISTS (SELECT 'X' FROM sys.schemas WHERE name = @ESQUEMA)
BEGIN
	EXEC('CREATE SCHEMA ' + @ESQUEMA)
END

/********************************************************************************************************************************************************************************************/
--Creación de tablas.
/********************************************************************************************************************************************************************************************/
DROP TABLE IF EXISTS JRM.MailMessageClassifaction;
DROP TABLE IF EXISTS JRM.MailClassification;

DROP TABLE IF EXISTS JRM.MailMessage;
DROP TABLE IF EXISTS JRM.MailBox;
DROP TABLE IF EXISTS JRM.MailMessageStatus;

CREATE TABLE JRM.MailBox
(MailBoxId   INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 MailBoxName VARCHAR(50)
);

CREATE TABLE JRM.MailMessageStatus
(MailMessageStatusId   INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 MailMessageStatusName VARCHAR(25) NOT NULL
);

CREATE TABLE JRM.MailMessage
(MailMessageId       INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 MailBoxId           INT NOT NULL, 
 MailMessageStatusId INT NOT NULL, 
 UserName            NVARCHAR(256) NOT NULL, 
 [To]                VARCHAR(250) NOT NULL, 
 [CC]                VARCHAR(250) NULL, 
 [BCC]               VARCHAR(250) NULL, 
 [From]              VARCHAR(250) NOT NULL, 
 [Subject]           VARCHAR(250) NOT NULL, 
 Body                VARCHAR(3999) NOT NULL, 
 [Date]              DATETIME NOT NULL, 
 Readed              BIT NOT NULL, 
 CONSTRAINT FK_MailBox_MailMessage FOREIGN KEY(MailBoxId) REFERENCES JRM.MailBox(MailBoxId), 
 CONSTRAINT FK_MailMessageStatus_MailMessage FOREIGN KEY(MailMessageStatusId) REFERENCES JRM.MailMessageStatus(MailMessageStatusId)
);

CREATE TABLE JRM.MailClassification
(MailClassificationId   INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 UserName           NVARCHAR(256) NOT NULL, 
 MailClassificationName VARCHAR(25) NOT NULL
);

CREATE TABLE JRM.MailMessageClassifaction
(MailMessageClassifactionId INT
 PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
 MailMessageId              INT NOT NULL, 
 MailClassificationId       INT NOT NULL, 
 CONSTRAINT FK_Classification_MailMessageClassification FOREIGN KEY(MailClassificationId) REFERENCES JRM.MailClassification(MailClassificationId), 
 CONSTRAINT FK_MailMessage_MailMessageClassification FOREIGN KEY(MailMessageId) REFERENCES JRM.MailMessage(MailMessageId)
);
/********************************************************************************************************************************************************************************************/
--Inserts para catalogos
/********************************************************************************************************************************************************************************************/
INSERT INTO JRM.MailBox(MailBoxName)
VALUES('Inbox'), ('Sentbox');

INSERT INTO JRM.MailMessageStatus(MailMessageStatusName)
VALUES('Draft'), ('Sent');