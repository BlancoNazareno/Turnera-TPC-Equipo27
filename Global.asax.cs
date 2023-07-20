using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Turnera_TPC_Equipo27
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            if (VerificarExistenciaDB())
            {
                CrearDB();
            }

            if (VerificarTablaPacientesVacia())
            {
                InsertarPacientesDefault();
            }

            if (VerificarTablaDiaVacia())
            {
                InsertarDiaDefault();
            }

            if (VerificarTablaHorarioVacia())
            {
                InsertarHorarioDefault();
            }
        }

        private bool VerificarExistenciaDB()
        {

            AccesoDatos datos = new AccesoDatos();
            bool vacia = false;

            try
            {
                datos.setearConsulta("select count(*) from Medicos");   //valida con una tabla X, si no está, es porque la DB no existe
                object result = datos.ejecutarAccionScalar();

                int count = Convert.ToInt32(result);
                vacia = (count == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la tabla de Médicos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return vacia;
        }
        private void CrearDB()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("use master \r\ngo\r\ndrop database Turnera_DB\r\n\r\ncreate database Turnera_DB\r\n\r\nuse Turnera_DB\r\n\r\ncreate table Pacientes(\r\n IDPaciente int identity(1000,1) not null,\r\n Nombre varchar(50) not null, \r\n Apellido varchar (50) not null,\r\n FechaNacimiento date not null,\r\n DNI int not null, \r\n Mail varchar(100) not null,\r\n Contrasenia varchar (100) not null,\r\n Cobertura varchar(30) not null,\r\n Celular varchar (15) not null, \r\n Estado bit not null,\r\n TipoUsuario int not null, \r\n Primary key (IDPaciente)\r\n)\r\n\r\ncreate table Especialidades(\r\nIDEspecialidad int identity (10,1) not null, \r\nEspecialidad varchar(50) not null,\r\nEstado bit not null,\r\nPrimary key (IDEspecialidad)\r\n)\r\n\r\ncreate table Medicos(\r\n IDMedico int identity(1000,1) not null,\r\n Nombre varchar(50) not null, \r\n Apellido varchar (50) not null,\r\n FechaNacimiento date not null,\r\n DNI int not null, \r\n Mail varchar(100) not null,\r\n IDEspecialidad int not null,\r\n Estado bit not null,\r\n Primary key (IDMedico),\r\n Foreign key (IDEspecialidad) references Especialidades (IDEspecialidad)\r\n)\r\n\r\ncreate table Disponibilidades(\r\nIDDisponibilidad int identity (1,1) not null,\r\nIDMedico int not null, \r\nDia int not null, \r\nHora varchar(50) not null, \r\nPrimary key (IDDisponibilidad), \r\nForeign key (IDMedico) references Medicos(IDMedico)\r\n)\r\n\r\nCreate table Turnos(\r\nIDTurno int identity(1000,1) not null, \r\nIDEspecialidad int not null, \r\nIDMedico int not null,\r\nIDPaciente int not null, \r\nFecha datetime not null, \r\nEstado bit not null,\r\nPrimary key (IDTurno), \r\nForeign key (IDEspecialidad) references Especialidades(IDEspecialidad),\r\nForeign key (IDMedico) references Medicos(IDMedico),\r\nForeign key (IDPaciente) references Pacientes(IDPaciente)\r\n)\r\n\r\ncreate table Horario (\r\nIDHorario int identity(1,1) not null,\r\nHora varchar(50) not null,\r\nPrimary Key (IDHorario)\r\n)\r\n\r\nCreate table Dia (\r\nIDDia int identity(1,1) not null ,\r\nDia int not null,\r\nNombreDia varchar(20) not null,\r\nPrimary Key(IDDia)\r\n)\r\n\r\nCREATE PROCEDURE sp_listarDisponibilidad\r\n    @id INT,\r\n    @dia INT,\r\n    @fechaSel DATE\r\nAS\r\nBEGIN\r\n    SET NOCOUNT ON;\r\n\r\n    SELECT DISTINCT D.Dia, D.Hora\r\n    FROM Disponibilidades D\r\n    WHERE D.IDMedico = @id\r\n      AND D.Dia = @dia\r\n      AND NOT EXISTS (\r\n        SELECT 1\r\n        FROM Turnos T\r\n        WHERE D.IDMedico = T.IDMedico AND D.Dia = @dia AND D.Hora = DATEPART(HOUR, T.Fecha)\r\n          AND CAST(T.Fecha AS DATE) = @fechaSel\r\n      );\r\nEND;\r\n");
                datos.ejecutarAccion();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la DB: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        private bool VerificarTablaPacientesVacia()
        {
            AccesoDatos datos = new AccesoDatos();
            bool vacia = false;

            try
            {
                datos.setearConsulta("select count(*) from Pacientes");
                object result = datos.ejecutarAccionScalar();

                int count = Convert.ToInt32(result);
                vacia = (count == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la tabla de Pacientes: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return vacia;
        }
        private void InsertarPacientesDefault()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //insert de usuario Admin
                datos.setearConsulta("insert into Pacientes (Nombre, Apellido, Celular, FechaNacimiento, DNI, Cobertura, Mail, Contrasenia, Estado, TipoUsuario) values (@Nombre, @Apellido, @Celular, @FechaNacimiento, @DNI, @Cobertura, @Mail, @Contrasenia, 1, 1)");
                datos.setearParametro("@Nombre", "Admin");
                datos.setearParametro("@Apellido", "Admin");
                datos.setearParametro("@Celular", "1100000001");
                datos.setearParametro("@FechaNacimiento", "2001-01-01");
                datos.setearParametro("@DNI", "000000001");
                datos.setearParametro("@Mail", "admin@admin.com");
                datos.setearParametro("@Cobertura", "admin");
                datos.setearParametro("@Contrasenia", "admin");

                datos.ejecutarAccion();

                //insert de usuario Subdmin
                datos.setearConsulta("insert into Pacientes (Nombre, Apellido, Celular, FechaNacimiento, DNI, Cobertura, Mail, Contrasenia, Estado, TipoUsuario) values (@Nombre, @Apellido, @Celular, @FechaNacimiento, @DNI, @Cobertura, @Mail, @Contrasenia, 1, 2)");
                datos.setearParametro("@Nombre", "Subdmin");
                datos.setearParametro("@Apellido", "Subdmin");
                datos.setearParametro("@Celular", "1100000002");
                datos.setearParametro("@FechaNacimiento", "2002-02-02");
                datos.setearParametro("@DNI", "000000002");
                datos.setearParametro("@Mail", "subadmin@subadmin.com");
                datos.setearParametro("@Cobertura", "subadmin");
                datos.setearParametro("@Contrasenia", "subadmin");

                datos.ejecutarAccion();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar los pacientes default: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        private bool VerificarTablaDiaVacia()
        {
            AccesoDatos datos = new AccesoDatos();
            bool vacia = false;

            try
            {
                datos.setearConsulta("select count(*) from Dia");
                object result = datos.ejecutarAccionScalar();

                int count = Convert.ToInt32(result);
                vacia = (count == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la tabla de Dia: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return vacia;
        }
        private void InsertarDiaDefault()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //insert de dias (número y nombre)
                datos.setearConsulta("insert into Dia (Dia, NombreDia) values (1, 'Lunes'), (2,'Martes'), (3,'Miércoles'), (4,'Jueves'), (5,'Viernes')");
                datos.ejecutarAccion();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar los días default: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        private bool VerificarTablaHorarioVacia()
        {
            AccesoDatos datos = new AccesoDatos();
            bool vacia = false;

            try
            {
                datos.setearConsulta("select count(*) from Horario");
                object result = datos.ejecutarAccionScalar();

                int count = Convert.ToInt32(result);
                vacia = (count == 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la tabla de Horario: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return vacia;
        }
        private void InsertarHorarioDefault()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //insert de dias (número y nombre)
                datos.setearConsulta("insert into Horario (Hora) values ('10:00'), ('11:00'), ('12:00'), ('13:00'), ('14:00'), ('15:00'), ('16:00'), ('17:00')");
                datos.ejecutarAccion();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar los horarios default: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
