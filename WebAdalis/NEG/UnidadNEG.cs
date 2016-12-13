using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class UnidadNEG
    {
        public UnidadDTO read(UnidadDTO unidadDTO)
        {
            DataTable dt = new DataTable();

            UnidadDAO unidadDAO = new UnidadDAO();

            dt = unidadDAO.read(unidadDTO);
            
            UnidadDTO retornoDTO = new UnidadDTO();

            foreach(DataRow row in dt.Rows)
            {
                retornoDTO.unidadID = Convert.ToInt64(row["unidadID"].ToString());
                retornoDTO.nombre = row["nombre"].ToString();
                retornoDTO.descripcion = row["descripcion"].ToString();
            }

            return retornoDTO;
        }

        public int delete(UnidadDTO unidadDTO)
        {
            int retorno = 0;
            UnidadDAO unidadDAO = new UnidadDAO();

            retorno = unidadDAO.delete(unidadDTO);

            return retorno;
        }

        public int create(UnidadDTO unidadDTO)
        {
            int retorno = 0;
            UnidadDAO unidadDAO = new UnidadDAO();

            retorno = unidadDAO.create(unidadDTO);

            return retorno;
        }
    }
}