using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class CargoNEG
    {
        public CargoDTO read(CargoDTO cargoDTO)
        {
            CargoDTO retornoDTO = new CargoDTO();
            CargoDAO cargoDAO = new CargoDAO();
            DataTable dt = new DataTable();

            dt = cargoDAO.read(cargoDTO);

            foreach (DataRow row in dt.Rows)
            {
                retornoDTO.cargoID = Convert.ToInt64(row["cargoID"].ToString());
                retornoDTO.nombre = row["nombre"].ToString();
            }
            return retornoDTO;
        }

        public int delete(CargoDTO cargoDTO)
        {
            int retorno = 0;
            CargoDAO cargoDAO = new CargoDAO();

            retorno = cargoDAO.delete(cargoDTO);

            return retorno;
        }

        public int create(CargoDTO cargoDTO)
        {
            int retorno = 0;
            CargoDAO cargoDAO = new CargoDAO();

            retorno = cargoDAO.create(cargoDTO);

            return retorno;
        }
    }
}