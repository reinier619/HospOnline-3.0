using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class ImagenNEG
    {
        public List<ImagenDTO> readxIngreso(ImagenDTO imagenDTO)
        {
            List<ImagenDTO> retornoDTO = new List<ImagenDTO>();
            ImagenDAO ImagenDAO = new ImagenDAO();
            
            DataTable dt = new DataTable();

            dt = ImagenDAO.readxIngreso(imagenDTO);

            ImagenDTO imDTO = null;

            foreach(DataRow row in dt.Rows)
            {
                imDTO = new ImagenDTO();

                imDTO.imagenID = Convert.ToInt64(row["imagenID"].ToString());
                imDTO.fecha_informe = Convert.ToDateTime(row["fecha_informe"].ToString());
                imDTO.descripcion = row["descripcion"].ToString();
                imDTO.diagnostico = row["diagnostico"].ToString();
                imDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
                imDTO.ingresoID = Convert.ToInt64(row["pacienteID"].ToString());

                retornoDTO.Add(imDTO);
            }

            return retornoDTO;
        }

        public ImagenDTO read(ImagenDTO imagenDTO)
        {
            ImagenDTO retornoDTO = new ImagenDTO();
            ImagenDAO ImagenDAO = new ImagenDAO();

            DataTable dt = new DataTable();

            dt = ImagenDAO.read(imagenDTO);

            foreach (DataRow row in dt.Rows)
            {

                retornoDTO.imagenID = Convert.ToInt64(row["imagenID"].ToString());
                retornoDTO.fecha_informe = Convert.ToDateTime(row["fecha_informe"].ToString());
                retornoDTO.descripcion = row["descripcion"].ToString();
                retornoDTO.diagnostico = row["diagnostico"].ToString();
                retornoDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
                retornoDTO.ingresoID = Convert.ToInt64(row["pacienteID"].ToString());

            }

            return retornoDTO;
        }

        public int delete(ImagenDTO imagenDTO)
        {
            int retorno = 0;
            ImagenDAO imagenDAO = new ImagenDAO();

            retorno = imagenDAO.delete(imagenDTO);

            return retorno;
        }

    }
}