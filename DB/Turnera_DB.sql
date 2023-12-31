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
 Celular varchar (15) not null, 
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

create table Disponibilidades(
IDDisponibilidad int identity (1,1) not null,
IDMedico int not null, 
Dia int not null, 
Hora int not null, 
Primary key (IDDisponibilidad), 
Foreign key (IDMedico) references Medicos(IDMedico)
)

Create table Turnos(
IDTurno int identity(1000,1) not null, 
IDEspecialidad int not null, 
IDMedico int not null,
IDPaciente int not null, 
Fecha datetime not null, 
Estado bit not null,
Primary key (IDTurno), 
Foreign key (IDEspecialidad) references Especialidades(IDEspecialidad),
Foreign key (IDMedico) references Medicos(IDMedico),
Foreign key (IDPaciente) references Pacientes(IDPaciente)
)

create table Horario (
IDHorario int identity(1,1) not null,
Hora int not null,
Primary Key (IDHorario)
)

Create table Dia (
IDDia int identity(1,1) not null ,
Dia int not null,
NombreDia varchar(20) not null,
Primary Key(IDDia)
)

CREATE PROCEDURE sp_listarDisponibilidad
    @id INT,
    @dia INT,
    @fechaSel DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT D.Dia, D.Hora
    FROM Disponibilidades D
    WHERE D.IDMedico = @id
      AND D.Dia = @dia
      AND NOT EXISTS (
        SELECT 1
        FROM Turnos T
        WHERE D.IDMedico = T.IDMedico AND D.Dia = @dia AND D.Hora = DATEPART(HOUR, T.Fecha)
          AND CAST(T.Fecha AS DATE) = @fechaSel
      );
END;
