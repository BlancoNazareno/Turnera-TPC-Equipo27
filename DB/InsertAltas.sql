use Turnera_DB
go
set dateformat 'DMY'
insert into Especialidades (Especialidad, Estado) values ('Traumatología', 1)
insert into Especialidades (Especialidad, Estado) values ('Pediatría', 1)
insert into Especialidades (Especialidad, Estado) values ('Psicología', 1)
insert into Especialidades (Especialidad, Estado) values ('Cardiología', 1)
go
insert into Medicos select 'Sigmund', 'Frued', '01-01-2001', 22111222, 'sfreud@gmail.com', 10, 1
insert into Medicos select 'René', 'Favaloro', '02-02-1990', 44111444, 'rfavaloro@gmail.com', 11, 1
go
insert into Pacientes select 'Figueroa', 'Alcorta', '10-03-1980', 20222233, 'falcorta@gmail.com',1234, 'OSDE','12435453',1,3
insert into Pacientes select 'Arturo', 'Illia', '04-04-1995', 55111155, 'aillia@gmail.com',1234, 'Galeno','12121345',1,3
go


Insert into Pacientes (Nombre, Apellido, FechaNacimiento, DNI, Mail, Contrasenia, Cobertura,Celular, Estado, TipoUsuario)
values  ('Admin','Apellido', '2000-10-10', 10000000, 'admin@admin', 1234,'admin','12435453',1,1),
('Subadmin','Apellido', '2000-10-10', 20000000, 'subadmin@subadmin', 1234,'subadmin','12435453',1,2),
('Paciente','Apellido', '2000-10-10', 30000000, 'paciente@paciente', 1234,'paciente','12435453',1,3)

Insert into Dia (Dia, NombreDia)
values (1, 'Lunes'), (2, 'Martes'), (3, 'Miercoles'), (4, 'Jueves'), (5, 'Viernes')

Insert into Horario (Hora)
values (11),(12),(13),(14),(15),(16),(17)