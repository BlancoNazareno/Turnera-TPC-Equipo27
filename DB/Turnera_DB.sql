create database Turnera_DB

use Turnera_DB

create table Pacientes(
 IDPaciente int identity(1000,1) not null,
 Nombre varchar(50) not null, 
 Apellido varchar (50) not null,
 FechaNacimiento date not null,
 DNI int not null, 
 Mail varchar(100) not null,
 Cobertura varchar(30) not null,
 Primary key (IDPaciente)
)

create table Especialidades(
IDEspecialidad int identity (10,1) not null, 
Nombre varchar(50) not null,
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
 Primary key (IDMedico),
 Foreign key (IDEspecialidad) references Especialidades (IDEspecialidad)
)

Create table HorariosMedicos(
IDHorario int identity(1000,1) not null, 
IDMedico int not null, 
DiaSemana int not null, 
HorarioEntrada datetime, 
HorarioSalida datetime
Primary key (IDHorario), 
Foreign key (IDMedico) references Medicos(IDMedico)
)

Create table Turnos(
IDTurno int identity(1000,1) not null, 
IDMedico int not null, 
IDEspecialidad int not null, 
FechaHora datetime check (DATEPART(MINUTE, FechaHora) = 0 AND DATEPART(SECOND, FechaHora) = 0) not null, 
Primary key (IDTurno), 
Foreign key (IDMedico) references Medicos(IDMedico),
Foreign key (IDEspecialidad) references Especialidades(IDEspecialidad)
)
