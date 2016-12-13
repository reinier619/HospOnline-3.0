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
    public class CamaDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";

        
        public int create(CamaDTO camaDTO)
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Cama ( descripcion, numero, salaID ) values( @descripcion, @numero, @salaID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@descripcion", camaDTO.descripcion);
            sqlcmd.Parameters.AddWithValue("@numero", camaDTO.numero);
            sqlcmd.Parameters.AddWithValue("@salaID", camaDTO.salaID);

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

        public DataTable read(CamaDTO camaDTO)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Cama WHERE camaID = @camaID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@camaID", SqlDbType.Int));

            sqlcmd.Parameters["@camaID"].Value = camaDTO.camaID;

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

        public int update(CamaDTO camaDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "UPDATE INTO Cama (descripcion, numero, salaID) values(@descripcion, @numero, @salaID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@descripcion", camaDTO.descripcion);
            sqlcmd.Parameters.AddWithValue("@numero", camaDTO.numero);
            sqlcmd.Parameters.AddWithValue("@salaID", camaDTO.salaID);

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

        public int delete(CamaDTO camaDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Cama WHERE camaID=@camaID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@camaID", camaDTO.camaID);
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


        public List<CamaDTO> readAll(CamaDTO unidadDTO)
        {
            List<CamaDTO> listDTO = new List<CamaDTO>();

            return listDTO;
        }

    }
}