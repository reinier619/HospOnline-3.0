using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospOnline.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HospOnline.DAO
{
    public class SalaDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
       

        public int create(SalaDTO salaDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Sala ( numero, descripcion, unidadID) values( @numero, @descripcion, @unidadID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@numero", salaDTO.numero);
            sqlcmd.Parameters.AddWithValue("@descripcion", salaDTO.descripcion);
            sqlcmd.Parameters.AddWithValue("@unidadID", salaDTO.unidadID);

            sqlcmd.CommandType = CommandType.Text;
            conn.Open();

            try
            {
                retorno = sqlcmd.ExecuteNonQuery();
            }
            catch
            {
                retorno = 0;
            }
            finally
            {
                conn.Close();
            }

            return retorno;
        }
        public DataTable read(SalaDTO salaDTO)
        {
            
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Sala WHERE salaID = @salaID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@salaID", SqlDbType.Int));

            sqlcmd.Parameters["@salaID"].Value = salaDTO.salaID;

            try
            {
                conn.Open();
                SqlDataReader rdr = sqlcmd.ExecuteReader();
                dt.Load(rdr);
                rdr.Close();
            }
            catch
            {
                dt = null;
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public SalaDTO update(SalaDTO salaDTO)
        {
            SalaDTO retornoDTO = new SalaDTO();

            return retornoDTO;
        }

        public int delete(SalaDTO salaDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Sala WHERE salaID=@salaID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@salaID", salaDTO.salaID);
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

        public List<SalaDTO> readAll(SalaDTO salaDTO)
        {
            List<SalaDTO> listDTO = new List<SalaDTO>();

            return listDTO;
        }

    }
}