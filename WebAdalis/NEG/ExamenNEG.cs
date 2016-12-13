using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class ExamenNEG
    {
        public ExamenDTO read(ExamenDTO examenDTO)
        {

            DataTable dt = new DataTable();

            ExamenDAO examenDAO = new ExamenDAO();

            dt = examenDAO.read(examenDTO);

            ExamenDTO exDTO = new ExamenDTO();

            foreach (DataRow row in dt.Rows)
            {

                exDTO.examenID = Convert.ToInt64(row["examenID"].ToString());
                exDTO.nombre_examen = row["nombre_examen"].ToString();
                exDTO.fecha_examen = Convert.ToDateTime(row["fecha_examen"].ToString());
                exDTO.resultado = row["resultado"].ToString();
                exDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
            }

            return exDTO;
        }
        public List<ExamenDTO> readxIngreso(ExamenDTO examenDTO)
        {
            
            DataTable dt = new DataTable();

            ExamenDAO examenDAO = new ExamenDAO();

            dt = examenDAO.readxIngreso(examenDTO);

            List<ExamenDTO> retornoDTO = new List<ExamenDTO>();

            ExamenDTO exDTO = null;

            foreach (DataRow row in dt.Rows)
            {
                exDTO = new ExamenDTO();

                exDTO.examenID = Convert.ToInt64(row["examenID"].ToString());
                exDTO.nombre_examen = row["nombre_examen"].ToString();
                exDTO.fecha_examen = Convert.ToDateTime(row["fecha_examen"].ToString());
                exDTO.resultado = row["resultado"].ToString();
                exDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());

                retornoDTO.Add(exDTO);
            }

            return retornoDTO;
        }

        public int delete(ExamenDTO examenDTO)
        {
            int retorno = 0;
            ExamenDAO examenDAO = new ExamenDAO();

            retorno = examenDAO.delete(examenDTO);

            return retorno;
        }

        public int create(ExamenDTO examenDTO)
        {
            int retorno = 0;
            ExamenDAO examenDAO = new ExamenDAO();

            retorno = examenDAO.create(examenDTO);

            return retorno;
        }
    }
}