use Turnera_DB
go
set dateformat 'DMY'
insert into Especialidades (Especialidad) values ('Traumatología')
insert into Especialidades (Especialidad) values ('Pediatría')
insert into Especialidades (Especialidad) values ('Psicología')
insert into Especialidades (Especialidad) values ('Cardiología')
go
insert into Medicos select 'Sigmund', 'Frued', '01-01-2001', 22111222, 'sfreud@gmail.com', 12
insert into Medicos select 'René', 'Favaloro', '02-02-1990', 44111444, 'rfavaloro@gmail.com', 13
go
insert into Pacientes select 'Figueroa', 'Alcorta', '10-03-1980', 20222233, 'falcorta@gmail.com', 'OSDE'
insert into Pacientes select 'Arturo', 'Illia', '04-04-1995', 55111155, 'aillia@gmail.com', 'Galeno'
go


Select * From Especialidades

