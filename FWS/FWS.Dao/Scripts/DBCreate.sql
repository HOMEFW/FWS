
CREATE TABLE Pessoa
( 
	PessoaId             integer  NOT NULL ,
	Email                varchar(100)  NULL ,
	IdentificacaoUnica   uniqueidentifier  NOT NULL ,
	Apelido              varchar(100)  NULL ,
	Nome                 varchar(100)  NULL ,
	Sobrenome            varchar(100)  NULL ,
	DataNascimento       datetime  NULL ,
	Sexo                 char(1)  NULL ,
	EstadoCivil          char(2)  NULL ,
	Imagem               varchar(50)  NULL ,
	ContaAtiva           char(1)  NULL ,
	AcessoLiberado       char(1)  NULL ,
	QtdTentativaAcesso   smallint  NULL ,
	PessoaConvite_id     integer  NULL ,
	Publicar             char(1)  NULL ,
	 PRIMARY KEY  CLUSTERED (PessoaId ASC)
)
go

CREATE TABLE Tipo_Interesse
( 
	TipoInteresseId      integer  NOT NULL ,
	Descricao            varchar(100)  NULL ,
	Ativo                char(1)  NULL ,
	 PRIMARY KEY  CLUSTERED (TipoInteresseId ASC)
)
go

CREATE TABLE Interesse
( 
	InteresseId          integer  NOT NULL ,
	Descricao            varchar(100)  NULL ,
	Ativo                char(1)  NULL ,
	TipoInteresseId      integer  NULL ,
	 PRIMARY KEY  CLUSTERED (InteresseId ASC),
	 FOREIGN KEY (TipoInteresseId) REFERENCES Tipo_Interesse(TipoInteresseId)
)
go

CREATE TABLE Pessoa_Interesse
( 
	PessoaId             integer  NOT NULL ,
	InteresseId          integer  NOT NULL ,
	 PRIMARY KEY  CLUSTERED (PessoaId ASC,InteresseId ASC),
	 FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId),
 FOREIGN KEY (InteresseId) REFERENCES Interesse(InteresseId)
)
go



CREATE TABLE Convite
( 
	ConviteId            integer  NOT NULL ,
	Email                varchar(100)  NULL ,
	Lido                 char(1)  NULL ,
	Enviado              char(1)  NULL ,
	Registrado           char(1)  NULL ,
	Mensagem             varchar(100)  NULL ,
	PessoaId             integer  NOT NULL ,
	 PRIMARY KEY  CLUSTERED (ConviteId ASC,PessoaId ASC),
	 FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId)
)
go



CREATE TABLE Pessoa_Phone
( 
	PhoneId              smallint  NOT NULL ,
	CodigoPais           varchar(5)  NULL ,
	CodigoArea           varchar(5)  NULL ,
	Telefone             varchar(10)  NULL ,
	Publicar             varchar(1)  NULL ,
	PessoaId             integer  NOT NULL ,
	 PRIMARY KEY  CLUSTERED (PhoneId ASC,PessoaId ASC),
	 FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId)
)
go



CREATE TABLE Pessoa_Email
( 
	EmailId              integer  NOT NULL ,
	Email                varchar(100)  NULL ,
	Publicar             char(1)  NULL ,
	PessoaId             integer  NOT NULL ,
	 PRIMARY KEY  CLUSTERED (EmailId ASC,PessoaId ASC),
	 FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId)
)
go




ALTER TABLE Interesse
	ADD CONSTRAINT R_7 FOREIGN KEY (TipoInteresseId) REFERENCES Tipo_Interesse(TipoInteresseId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Pessoa_Email
	ADD CONSTRAINT R_1 FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Pessoa_Interesse
	ADD CONSTRAINT R_5 FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Pessoa_Interesse
	ADD CONSTRAINT R_6 FOREIGN KEY (InteresseId) REFERENCES Interesse(InteresseId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Pessoa_Phone
	ADD CONSTRAINT R_2 FOREIGN KEY (PessoaId) REFERENCES Pessoa(PessoaId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go

