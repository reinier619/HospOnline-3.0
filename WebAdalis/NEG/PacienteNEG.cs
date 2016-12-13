using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class PacienteNEG
    {
        public PacienteDTO BuscarPacienteRut(PacienteDTO pacienteDTO)
        {
            PacienteDTO retorno = new PacienteDTO();

            PacienteDAO pacienteDAO = new PacienteDAO();
            DataTable dt = new DataTable();

            dt = pacienteDAO.BuscarPacienteRut(pacienteDTO);

            foreach (DataRow row in dt.Rows)
            {
                retorno.pacienteID = Convert.ToInt64(row["pacienteID"].ToString());
                retorno.rut = row["rut"].ToString();
                retorno.nombre = row["nombre"].ToString();
                retorno.digito_verificador = row["dv"].ToString();
                retorno.apellido_paterno = row["apellido_paterno"].ToString();
                retorno.apellido_materno = row["apellido_materno"].ToString();
                retorno.edad = row["edad"].ToString();
                retorno.fecha_registro = Convert.ToDateTime(row["fecha_ingreso"].ToString());
                retorno.direccion = row["direccion"].ToString();
                retorno.telefono = row["telefono"].ToString();
                retorno.clave = row["clave"].ToString();

            }

            return retorno;

        }
        public PacienteDTO buscarPorRut(PacienteDTO pacienteDTO)
        {
            PacienteDTO retorno = new PacienteDTO();

            PacienteDAO pacienteDAO = new PacienteDAO();
            DataTable dt = new DataTable();

            dt = pacienteDAO.BuscarxRut(pacienteDTO);

            foreach (DataRow row in dt.Rows)
            {
                retorno.pacienteID = Convert.ToInt64(row["pacienteID"].ToString());
                retorno.rut = row["rut"].ToString();
                retorno.nombre = row["nombre"].ToString();
                retorno.digito_verificador = row["dv"].ToString();
                retorno.apellido_paterno = row["apellido_paterno"].ToString();
                retorno.apellido_materno = row["apellido_materno"].ToString();
                retorno.edad = row["edad"].ToString();
                retorno.fecha_registro = Convert.ToDateTime(row["fecha_ingreso"].ToString());
                retorno.direccion = row["direccion"].ToString();
                retorno.telefono = row["telefono"].ToString();
                retorno.clave = row["clave"].ToString();

            }

            return retorno;
        }
    
        public PacienteDTO read(PacienteDTO pacienteDTO)
        {
            PacienteDTO retorno = new PacienteDTO();

            PacienteDAO pacienteDAO = new PacienteDAO();
            DataTable dt = new DataTable();

            dt = pacienteDAO.read(pacienteDTO);

            foreach (DataRow row in dt.Rows)
            {
                retorno.pacienteID = Convert.ToInt64(row["pacienteID"].ToString());
                retorno.rut = row["rut"].ToString();
                retorno.nombre = row["nombre"].ToString();
                retorno.digito_verificador = row["dv"].ToString();
                retorno.apellido_paterno = row["apellido_paterno"].ToString();
                retorno.apellido_materno = row["apellido_materno"].ToString();
                retorno.edad = row["edad"].ToString();
                retorno.fecha_registro = Convert.ToDateTime(row["fecha_ingreso"].ToString());
                retorno.direccion = row["direccion"].ToString();
                retorno.telefono = row["telefono"].ToString();
                retorno.clave = row["clave"].ToString();

            }

            return retorno;
        }

        public int delete(PacienteDTO pacienteDTO)
        {
            int retorno = 0;
            PacienteDAO pacienteDAO = new PacienteDAO();

            retorno = pacienteDAO.delete(pacienteDTO);

            return retorno;
        }
    }
}