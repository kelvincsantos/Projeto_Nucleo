use ControleContas
GO

create table Tabela (
	 ID varchar(50) primary key
	,Nome varchar(50) not null
	,NomeTabelaDominio varchar(50) null
	,DataCriacao datetime not null
	,DataAtualizacao datetime null
)
GO

create table Coluna (
	 ID varchar(50) primary key
	,Nome varchar(50) not null
	,Tipo varchar(50) not null
	,Precisao varchar(50) null
	,TabelaID varchar(50) not null FOREIGN KEY REFERENCES Tabela(ID)
	,IndexSimples bit default(0) not null
)
GO

create table IndexComposto (
	 ID varchar(50) primary key
	,Nome varchar(100) not null
	,TabelaID varchar(50) not null FOREIGN KEY REFERENCES Tabela(ID)
)
GO

create table CamposIndexComposto (
	 ID varchar(50) primary key
	,ColunaID varchar(50) not null FOREIGN KEY REFERENCES Coluna(ID)
	,IndexCompostosID varchar(50) not null FOREIGN KEY REFERENCES IndexComposto(ID)
)
GO

create table ChaveEstrangeira (
	 ID varchar(50) primary key
	,Nome varchar(100) not null
	,TabelaPrimariaID		varchar(50) FOREIGN KEY REFERENCES Tabela(ID)
	,TabelaEstrangeiraID	varchar(50) FOREIGN KEY REFERENCES Tabela(ID)
	,ColunaPrimariaID		varchar(50) FOREIGN KEY REFERENCES Coluna(ID)
	,ColunaEstrangeiraID	varchar(50) FOREIGN KEY REFERENCES Coluna(ID)
)
GO