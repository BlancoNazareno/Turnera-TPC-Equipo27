﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public  class DisponibilidadNegocio

    {
        public List<Disponibilidad> listar() {
            List<Disponibilidad> lista = new List<Disponibilidad>();
            return lista;
        }
        public void agregar(Disponibilidad nuevaDisponibilidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Consulta para que no se repitan disponibilidades en la DB

                datos.setearConsulta("INSERT INTO Disponibilidades (IDMedico, Dia, Hora) SELECT @IDMedico, @Dia, @Hora WHERE NOT EXISTS (SELECT 1 FROM Disponibilidades WHERE IDMedico = @IDMedico AND Dia = @Dia AND Hora = @Hora)");
                datos.setearParametro("@IDMedico", nuevaDisponibilidad.Medico.Id);
                datos.setearParametro("@Dia", nuevaDisponibilidad.Dia);
                datos.setearParametro("@Hora", nuevaDisponibilidad.Hora);
                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool checkearDisponibilidad(int id, int dia, string hora)
        {
            bool existeRegistro = false;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select count(*) from Disponibilidades where IDMedico = @Id and Dia = @Dia and Hora = @Hora");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Dia", dia);
                datos.setearParametro("@Hora", hora);

                int count = datos.ejecutarAccionScalar();

                if (count > 0)
                {
                    existeRegistro = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return existeRegistro;


        }
    }
}
