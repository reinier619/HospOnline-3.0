using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class PersonaNEG
    {
        public PersonaDTO read(PersonaDTO personaDTO)
        {
            DataTable dt = new DataTable();
            PersonaDTO retornoDTO = new PersonaDTO();
            PersonaDAO personaDAO = new PersonaDAO();

            dt = personaDAO.read(personaDTO);

            foreach(DataRow row in dt.Rows)
            {
                retornoDTO.personaID = Convert.ToInt64(row["personaID"].ToString());
                retornoDTO.rut = row["rut"].ToString();
                retornoDTO.digito_verificador = row["dv"].ToString();
                retornoDTO.nombre = row["nombres"].ToString();
                retornoDTO.apellido_paterno = row["ap_paterno"].ToString();
                retornoDTO.apellido_materno = row["ap_materno"].ToString();
                retornoDTO.direccion = row["direccion"].ToString();
                retornoDTO.telefono = row["telefono"].ToString();
            }
            return retornoDTO;
        }

        public int delete(PersonaDTO personaDTO)
        {
            int retorno = 0;
            PersonaDAO personaDAO = new PersonaDAO();

            retorno = personaDAO.delete(personaDTO);

            return retorno;
        }
    }
}