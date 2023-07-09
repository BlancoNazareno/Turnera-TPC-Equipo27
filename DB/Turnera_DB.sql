use master 
go
drop database Turnera_DB

create database Turnera_DB

use Turnera_DB

create table Pacientes(
 IDPaciente int identity(1000,1) not null,
 Nombre varchar(50) not null, 
 Apellido varchar (50) not null,
 FechaNacimiento date not null,
 DNI int not null, 
 Mail varchar(100) not null,
 Contrasenia varchar (100) not null,
 Cobertura varchar(30) not null,
 Estado bit not null,
 TipoUsuario int not null, 
 Primary key (IDPaciente)
)

create table Especialidades(
IDEspecialidad int identity (10,1) not null, 
Especialidad varchar(50) not null,
Estado bit not null,
Primary key (IDEspecialidad)
)

create table Medicos(
 IDMedico int identity(1000,1) not null,
 Nombre varchar(50) not null, 
 Apellido varchar (50) not null,
 FechaNacimiento date not null,
 DNI int not null, 
 Mail varchar(100) not null,
 IDEspecialidad int not null,
 Estado bit not null,
 Primary key (IDMedico),
 Foreign key (IDEspecialidad) references Especialidades (IDEspecialidad)
)

Create table Disponibilidades(
IDDisponibilidad int identity (1,1) not null,
IDMedico int not null, 
Dia datetime not null, 
Hora datetime not null, 
Primary key (IDDisponibilidad), 
Foreign key (IDMedico) references Medicos(IDMedico)
)

Create table Turnos(
IDTurno int identity(1000,1) not null, 
IDEspecialidad int not null, 
IDMedico int not null,
IDPaciente int not null, 
IDDisponibilidad int not null, 
Estado bit not null,
Primary key (IDTurno), 
Foreign key (IDEspecialidad) references Especialidades(IDEspecialidad),
Foreign key (IDMedico) references Medicos(IDMedico),
Foreign key (IDPaciente) references Pacientes(IDPaciente)
)