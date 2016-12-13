using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class CamaNEG
    {
        public CamaDTO read(CamaDTO camaDTO)
        {
            CamaDTO retornoDTO = new CamaDTO();
            CamaDAO camaDAO = new CamaDAO();
            DataTable dt = new DataTable();

            dt = camaDAO.read(camaDTO);

            foreach(DataRow row in dt.Rows)
            {
                retornoDTO.camaID = Convert.ToInt64(row["camaID"].ToString());
                retornoDTO.numero = row["numero"].ToString();
                retornoDTO.descripcion = row["descripcion"].ToString();
                retornoDTO.salaID = Convert.ToInt64(row["salaID"].ToString());
            }

            return retornoDTO;

        }

        public int delete(CamaDTO camaDTO)
        {
            int retorno = 0;
            CamaDAO camaDAO = new CamaDAO();

            retorno = camaDAO.delete(camaDTO);

            return retorno;
        }

        public int create(CamaDTO camaDTO)
        {
            int retorno = 0;
            CamaDAO camaDAO = new CamaDAO();

            retorno = camaDAO.create(camaDTO);

            return retorno;
        }
    }
}