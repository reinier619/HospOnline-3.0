using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class TratamientoNEG
    {
        public TratamientoDTO read(TratamientoDTO tratamientoDTO)
        {
            DataTable dt = new DataTable();
            TratamientoDTO trDTO = new TratamientoDTO();
            TratamientoDAO prDAO = new TratamientoDAO();


            dt = prDAO.read(tratamientoDTO);

            foreach (DataRow row in dt.Rows)
            {
                trDTO.tratamientoID = Convert.ToInt64(row["tratamientoID"].ToString());
                trDTO.descripcion = row["descripcion"].ToString();
                trDTO.egresoID = Convert.ToInt64(row["egresoID"].ToString());

            }

            return trDTO;
        }

        public List<TratamientoDTO> readxEgreso(TratamientoDTO tratamientoDTO)
        {
            DataTable dt = new DataTable();
            TratamientoDTO trDTO = null;
            TratamientoDAO prDAO = new TratamientoDAO();

            List<TratamientoDTO> lretornoDTO = new List<TratamientoDTO>();

            dt = prDAO.readxEgreso(tratamientoDTO);

            foreach (DataRow row in dt.Rows)
            {
                trDTO = new TratamientoDTO();

                trDTO.tratamientoID = Convert.ToInt64(row["tratamientoID"].ToString());
                trDTO.descripcion = row["descripcion"].ToString();
                trDTO.egresoID = Convert.ToInt64(row["egresoID"].ToString());

                lretornoDTO.Add(trDTO);

            }

            return lretornoDTO;
        }

        public List<TratamientoDTO> readxIngreso(TratamientoDTO tratamientoDTO)
        {
            DataTable dt = new DataTable();
            TratamientoDTO trDTO = null;
            TratamientoDAO prDAO = new TratamientoDAO();

            List<TratamientoDTO> lretornoDTO = new List<TratamientoDTO>();

            dt = prDAO.readxIngreso(tratamientoDTO);

            foreach (DataRow row in dt.Rows)
            {
                trDTO = new TratamientoDTO();

                trDTO.tratamientoID = Convert.ToInt64(row["tratamientoID"].ToString());
                trDTO.descripcion = row["descripcion"].ToString();
                trDTO.egresoID = Convert.ToInt64(row["egresoID"].ToString());

                lretornoDTO.Add(trDTO);

            }

            return lretornoDTO;
        }

        public int delete(TratamientoDTO tratamientoDTO)
        {
            int retorno = 0;
            TratamientoDAO tratamientoDAO = new TratamientoDAO();

            retorno = tratamientoDAO.delete(tratamientoDTO);

            return retorno;
        }

        public int create(TratamientoDTO tratamientoDTO)
        {
            int retorno = 0;
            TratamientoDAO tratamientoDAO = new TratamientoDAO();

            retorno = tratamientoDAO.create(tratamientoDTO);

            return retorno;
        }
    }
}