create table ventas_mensuales(
id int identity primary key not null,
fecha_del_informe date not null,
codigo_vendedor varchar(3) not null,
venta decimal(10,2) not null,
venta_grande varchar(1) not null,
)
---------------- TABLA PARAMETRIA -------------------

create table parametria(
id int identity primary key,
regla varchar (50) not null,
valor_regla varchar (50) not null,
)

---------------- TABLA RECHAZOS -------------------

create table rechazos(
id int identity primary key not null,
motivos varchar (100)
)

---------------- INSERTAR A PARAMETRIA -------------------

insert into parametria(regla, valor_regla) values ('fecha','2023-10-31')

drop table parametria
 
drop table parametria 

-----------------------------------------------------------
select *
from parametria
