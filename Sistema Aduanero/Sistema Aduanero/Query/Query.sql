CREATE TABLE RoleUsuario
(
	ID int identity(102478,100) primary key,
	tipo_de_rol varchar(50)
)
go
insert into RoleUsuario values('empleado')
insert into RoleUsuario values('cliente')
go
select * from RoleUsuario
go

Create Table Usuario
(
	id int identity(1,1) primary key,
	id_rol_fk int,
	nombres varchar(50) not null,
	apellidos varchar(50) not null,
	pass varchar(50),
	empresa varchar(50),
	provincia varchar(50),
	municipio varchar(50),
	calle varchar(30),
	sector varchar(30),
	estatus varchar(50),
	CONSTRAINT id_rol_fk FOREIGN KEY (id_rol_fk) REFERENCES RoleUsuario(ID)
)
go
ALTER TABLE Usuario ADD cedula varchar(11)
ALTER TABLE Usuario ADD fecha_de_registro date
go
--	Estos son los datos de los empleados.
insert into Usuario values(102478, 'gerson', 'santos mateo', '102030', 'GATEWAY TO THE WORLD', 'Santo Domingo', 'santo domingo este', 'presidente antonio guzman', 'invivienda', 'activo', '40225810475')
insert into Usuario values(102478, 'rachell', 'acosta cuevas', '102030', 'GATEWAY TO THE WORLD', 'Santo Domingo', 'santo domingo oeste', 'residencial el antonia', 'manoguayabo', 'activo', '40214312047')
insert into Usuario values(102478, 'marinelva', 'mateo landa', '102030', 'GATEWAY TO THE WORLD', 'Santo Domingo', 'santo domingo este', 'presidente antonio guzman', 'invivienda', 'activo','00100134471')
go
--	Estos son los datos de algunos clientes prueba
insert into Usuario values(102578, 'josefa', 'martinez martinez', 'jfmm123', '', 'Santo Domingo', 'santo domingo este', 'presidente antonio guzman', 'invivienda', 'activo', '40221417843')
insert into Usuario values(102578, 'raquel', 'cuevas', 'rc102030', '', 'Santo Domingo', 'santo domingo oeste', 'residencial el antonia', 'manoguayabo', 'activo', '00100178524')
insert into Usuario values(102578, 'christy', 'mateo', 'lcmb123', 'lumen christy', 'Santo Domingo', 'distrito nacional', 'Torre Empresarial Reyna II', 'zona universitaria', 'activo','00100124781')
go
--	Fechas de registro
--update Usuario set fecha_de_registro = '04/04/2020' from Usuario where estatus = 'activo'
select * from Usuario
go

Create Table Usuario_Telefono
(
id int identity(1,1) primary key,
id_usuario_fk_telefono int not null,
telefono varchar(11)
constraint FK_CT foreign key (id_usuario_fk_telefono) references Usuario(ID) 
)
go
--	Estos son los datos de los empleados.
insert into Usuario_Telefono values(2, '8498511742')
insert into Usuario_Telefono values(5, '8182456324')
insert into Usuario_Telefono values(6, '8294493535')
go
--	Estos son los datos de algunos clientes prueba
insert into Usuario_Telefono values(7, '8498511742')
insert into Usuario_Telefono values(8, '8492513124')
insert into Usuario_Telefono values(10, '8292302456')
go
--delete from Usuario_Telefono
--truncate table Usuario_Telefono
--DROP TABLE Usuario_Telefono
select * from Usuario_Telefono
go

Create Table Usuario_Correo
(
id int identity(1,1) primary key,
id_usuario_fk_correo int not null,
correo varchar(50)
constraint id_usuario_fk_correo foreign key (id_usuario_fk_correo) references Usuario(ID) 
)
go
--	Estos son los datos de los empleados.
insert into Usuario_Correo values(2, 'racostacuevas@gmail.com')
insert into Usuario_Correo values(5, 'mmateolanda@gmail.com')
insert into Usuario_Correo values(6, 'gerson.santosm3@gmail.com')
go
--	Estos son los datos de algunos clientes prueba
insert into Usuario_Correo values(7, 'jmartinez@gmail.com')
insert into Usuario_Correo values(8, 'rcuevas@gmail.com')
insert into Usuario_Correo values(10, 'cmateo@gmail.com')
go
--delete from Clientes_Telefono
--truncate table Clientes_Telefono
--DROP TABLE Usuario_Telefono
select * from Usuario_Correo
go

Create Table Solicitud
(
ID int identity(1,1) primary key,
tipo_de_solicitud varchar (40),
tipo_Mercancia text,
cantidad int,
peso float,--se cambio el tipo de datos
descripción text,
tiempo_deseado_en_llegar varchar(100),
nombre_completo_de_quien_recibe varchar(50),
cedula varchar(11),
fecha_de_la_solicitud date,
estatus varchar(100),
id_cliente_fk_solicitud int not null,
Constraint Fk_CP foreign key (id_cliente_fk_solicitud) references Usuario(ID)
)
ALTER TABLE Solicitud ADD peso_de_la_mercancia varchar(30)
SELECT * FROM Solicitud
go

Create Table Facturacion
(
ID int identity(1,1) primary key,
id_cliente_fk_facturacion int not null,
Tipo_Pago varchar(50), -- Tarjeta de credito o Efectivo.
id_solicitud_fk_facturacion int not null,
fecha_de_facturacion date,
Balance money
constraint FK_CF foreign key (id_cliente_fk_facturacion) references Usuario(ID),
constraint FK_PF foreign key (id_solicitud_fk_facturacion) references Solicitud(ID)
)
SELECT * FROM Facturacion
GO

Create Table Declaracion 
(
ID int identity(1,1) primary key, 
id_factura_fk_declaracion int, 
id_cliente_fk_declaracion int, 
descripcion text,
estatus varchar(30),
constraint FK_FD foreign key (id_factura_fk_declaracion) references Facturacion(ID),
constraint FK_CD foreign key (id_cliente_fk_declaracion) references Usuario(ID)
)
SELECT * FROM Declaracion
GO

Create Table Entrega 
(
ID_Entrega int identity(1,1) primary key, 
id_factura_fk_entrega int, 
id_cliente_fk_entrega int,
cantidad_articulos int,
cedula_quien_recibe varchar(11),
fecha_de_entrega date,
Estatus varchar(30), -- Sin entregar o Entrega satisfactoria
constraint FK_CE foreign key (id_cliente_fk_entrega) references Usuario(ID),
constraint FK_FE foreign key (id_factura_fk_entrega) references Facturacion(ID)
)
select * from Entrega
GO


Create Table Envio 
(
ID_Envio int identity(1,1) primary key, 
id_factura_fk_envio int, 
id_cliente_fk_envio int, 
cantidad_articulos int, 
fecha_de_envio date,
Estatus varchar(20),
constraint FK_CE1 foreign key (id_cliente_fk_envio) references Usuario(ID),
constraint FK_FE1 foreign key (id_factura_fk_envio) references Facturacion(ID)
)
SELECT * FROM Envio
GO