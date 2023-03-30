create table Carregadores(
	nCarregador int identity primary key,
	localidade varchar(20),
	empresa int foreign key references Utilizadores(id),
	estado bit default 0, --está em utilização?
	preco_por_kWh decimal(4,2),
	latitude varchar(10),
	longitude varchar(10),

	check (preco_por_kWh > 0)	
);

create table Utilizadores(
	id int identity primary key,
	nif varchar(9),
	nome varchar(40),
	email varchar(40),
	palavra_passe varchar(40),
	perfil int,
	sal int,

	check ((trim(nome) like '% %') and (len(trim(nome))>4))
);

create table Carregamento(
	nCarregamento int identity primary key,
	nCarregador int foreign key references Carregadores(nCarregador),
	cliente int foreign key references Utilizadores(id),
	data_carregamento date,
	kWh decimal(5,2),
	precoTotal decimal(7,2),

	check (kWh > 0),
	check (precoTotal > 0),
);

ALTER DATABASE database_name   
SET COMPATIBILITY_LEVEL = 140
