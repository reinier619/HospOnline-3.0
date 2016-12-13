using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class SalaNEG
    {
        public SalaDTO read(SalaDTO salaDTO)
        {
            SalaDTO retornoDTO = new SalaDTO();

            SalaDAO salaDAO = new SalaDAO();
            DataTable dt = new DataTable();

            dt = salaDAO.read(salaDTO);

            foreach(DataRow row in dt.Rows)
            {
                retornoDTO.salaID = Convert.ToInt64(row["salaID"].ToString());
                retornoDTO.numero = row["numero"].ToString();
                retornoDTO.descripcion = row["descripcion"].ToString();
            }

            return retornoDTO;
        }

        public int delete(SalaDTO salaDTO)
        {
            int retorno = 0;
            SalaDAO salaDAO = new SalaDAO();

            retorno = salaDAO.delete(salaDTO);

            return retorno;
        }

        public int create(SalaDTO salaDTO)
        {
            int retorno = 0;
            SalaDAO salaDAO = new SalaDAO();

            retorno = salaDAO.create(salaDTO);

            return retorno;
        }
    }
}