  create  Database Librerias

  Drop Database libreria
  

  use Librerias

   create table Marcas (
 Id_Marca   int Primary key IDENTITY(1,1),
 Nom_Marca varchar(60) not null,
 )
 
 
 
 create table  Generos (
 Id_Genero int Primary key IDENTITY(1,1),
 Nom_Genero varchar(60) not null,

 )
  
 
  create table  Estados (
 Id_Estado   int Primary key IDENTITY(1,1),
 Nom_Estado varchar(60) not null,


  )



 create table  libros (
 Id_Libro   int Primary key IDENTITY(1,1),
 Titulo varchar(60) not null,
 Id_Genero int,
 Genero varchar(60) not null,
 Id_Marca   int, 
 Marca  varchar(60) not null,
 Id_Estado   int ,
 Nom_Estado varchar(60),
  FOREIGN KEY (Id_Estado)  REFERENCES Estados(Id_Estado),
   FOREIGN KEY ( Id_Genero)REFERENCES Generos( Id_Genero),
    FOREIGN KEY ( Id_Marca)  REFERENCES Marcas( Id_Marca),
 

  )




 create table Tercero (
 Id_Tercero varchar(20) primary key ,
 Nombre_Ter  varchar(60) not null,
 Apellido_Ter varchar(60) not null,
 Telefono varchar(15) not null,
 Correo     varchar(50) not null,
 Fecha_Nacimi date,
 Direccion   varchar(80) not null,
 Localidad    varchar(60) not null,
 Cuidad varchar(60) not null,
)



 create table Historial (
 
 Id_Historial  int Primary key IDENTITY(1,1),
  Id_Tercero varchar(20) ,
 Nombre_Ter  varchar(60) not null,
 Id_Libro   int ,
 Titulo varchar(60) not null,
 Fecha_Pres  date ,
 Fecha_Devo  date ,
 Id_Estado   int,
 Nom_Estado varchar(60) not null
 FOREIGN KEY (Id_Tercero)  REFERENCES Tercero(Id_Tercero),
 FOREIGN KEY ( Id_Libro )  REFERENCES Libros(Id_Libro ),
 FOREIGN KEY (Id_Estado)  REFERENCES Estados(Id_Estado),
 
 
 
 
 )






