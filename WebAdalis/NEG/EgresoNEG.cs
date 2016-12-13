using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class EgresoNEG
    {
        public EgresoDTO readxIngreso(EgresoDTO egresoDTO)
        {
            DataTable dt = new DataTable();
            EgresoDTO retornoDTO = new EgresoDTO();
            EgresoDAO eDAO = new EgresoDAO();

            dt = eDAO.readxIngreso(egresoDTO);

            foreach(DataRow row in dt.Rows)
            {
                retornoDTO.egresoID = Convert.ToInt64(row["egresoID"].ToString());
                retornoDTO.fecha_egreso = Convert.ToDateTime(row["fecha_egreso"].ToString());
                retornoDTO.descripcion = row["descripcion"].ToString();
                retornoDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
            }

            return retornoDTO;

        }

        public EgresoDTO read(EgresoDTO egresoDTO)
        {
            DataTable dt = new DataTable();
            EgresoDTO retornoDTO = new EgresoDTO();
            EgresoDAO eDAO = new EgresoDAO();

            dt = eDAO.readxIngreso(egresoDTO);

            foreach (DataRow row in dt.Rows)
            {
                retornoDTO.egresoID = Convert.ToInt64(row["egresoID"].ToString());
                retornoDTO.fecha_egreso = Convert.ToDateTime(row["fecha_egreso"].ToString());
                retornoDTO.descripcion = row["descripcion"].ToString();
                retornoDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
            }

            return retornoDTO;

        }

        public int delete(EgresoDTO egresoDTO)
        {
            int retorno = 0;
            EgresoDAO egresoDAO = new EgresoDAO();

            retorno = egresoDAO.delete(egresoDTO);

            return retorno;
        }

        public int create(EgresoDTO egresoDTO)
        {
            int retorno = 0;
            EgresoDAO egresoDAO = new EgresoDAO();

            retorno = egresoDAO.create(egresoDTO);

            return retorno;
        }

    }
}