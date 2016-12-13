using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospOnline.DTO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HospOnline.DAO
{
    public class MedicamentoDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
 
        public MedicamentoDTO create(MedicamentoDTO medicamentoDTO)
        {
            MedicamentoDTO retornoDTO = new MedicamentoDTO();

            return retornoDTO;
        }
        public MedicamentoDTO read(MedicamentoDTO medicamentoDTO)
        {
            MedicamentoDTO retornoDTO = new MedicamentoDTO();

            return retornoDTO;
        }

        public MedicamentoDTO update(MedicamentoDTO medicamentoDTO)
        {
            MedicamentoDTO retornoDTO = new MedicamentoDTO();

            return retornoDTO;
        }

        public int delete(MedicamentoDTO medicamentoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Medicamento WHERE medicamentoID=@medicamentoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@medicamentoID", medicamentoDTO.medicamentoID);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                retorno = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                retorno = 0;
            }
            finally
            {
                con.Close();
            }
            return retorno;
        }

        public List<MedicamentoDTO> readAll(MedicamentoDTO medicamentoDTO)
        {
            List<MedicamentoDTO> listDTO = new List<MedicamentoDTO>();

            return listDTO;
        }
    }
}