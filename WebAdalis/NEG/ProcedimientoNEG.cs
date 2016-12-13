using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class ProcedimientoNEG
    {
        public List<ProcedimientoDTO> readxIngreso(ProcedimientoDTO procedimientoDTO)
        {
            DataTable dt = new DataTable();
            ProcedimientoDTO prDTO = null;
            ProcedimientoDAO prDAO = new ProcedimientoDAO();
            
            List<ProcedimientoDTO> retornoDTO = new List<ProcedimientoDTO>();


            dt = prDAO.readxIngreso(procedimientoDTO);

            foreach(DataRow row in dt.Rows)
            {
                prDTO = new ProcedimientoDTO();

                prDTO.procedimientoID = Convert.ToInt64(row["procedimientoID"].ToString());
                prDTO.nombre = row["nombre"].ToString();
                prDTO.cantidad = row["cantidad"].ToString();
                prDTO.periodo = row["periodo"].ToString();
                prDTO.fecha_inicio_procedimiento = Convert.ToDateTime(row["fecha_inicio_procedimiento"].ToString());
                prDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
                retornoDTO.Add(prDTO);
            }

            return retornoDTO;

        }

        public int delete(ProcedimientoDTO procedimientoDTO)
        {
            int retorno = 0;
            ProcedimientoDAO personaDAO = new ProcedimientoDAO();

            retorno = personaDAO.delete(procedimientoDTO);

            return retorno;
        }

        public int create(ProcedimientoDTO procedimientoDTO)
        {
            int retorno = 0;
            ProcedimientoDAO procedimientoDAO = new ProcedimientoDAO();

            retorno = procedimientoDAO.create(procedimientoDTO);

            return retorno;
        }
    }
}