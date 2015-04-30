

IF NOT EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'FWSBUSTED')
	BEGIN
		CREATE TABLE FWSBUSTED
		( 
			logId                INTEGER  IDENTITY,
			level				 SMALLINT NOT NULL,
			data                 DATETIME NOT NULL,
			classe               VARCHAR(50)  NULL,
			metodo               VARCHAR(50)  NULL,
			mensagem             VARCHAR(500)  NULL,
			message              VARCHAR(500)  NULL,
			stack                VARCHAR(500)  NULL
		)

		ALTER TABLE FWSBUSTED
			ADD CONSTRAINT XPFWSBUSTED PRIMARY KEY  CLUSTERED (logId ASC)
		SELECT 'T' AS CREATED
	END 
ELSE
	SELECT 'F' AS CREATED
