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
    public class UnidadDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
      
        public int create(UnidadDTO unidadDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Unidad ( nombre, descripcion) values( @nombre, @descripcion)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@nombre", unidadDTO.nombre);
            sqlcmd.Parameters.AddWithValue("@descripcion", unidadDTO.descripcion);

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
        public DataTable read(UnidadDTO unidadDTO)
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Unidad WHERE unidadID = @unidadID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@unidadID", SqlDbType.Int));

            sqlcmd.Parameters["@unidadID"].Value = unidadDTO.unidadID;
            
            try
            {
                conn.Open();
                SqlDataReader rdr = sqlcmd.ExecuteReader();
                dataTable.Load(rdr);
                rdr.Close();
            }
            catch
            {
                dataTable = null;
            }
            finally
            {
                conn.Close();
            }
            return dataTable;
        }

        public UnidadDTO  update(UnidadDTO unidadDTO)
        {
            UnidadDTO retornoDTO = new UnidadDTO();

            return retornoDTO;
        }

        public int delete(UnidadDTO unidadDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Unidad WHERE unidadID = @unidadID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@unidadID", unidadDTO.unidadID);
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

        public List<UnidadDTO> readAll(UnidadDTO unidadDTO)
        {
            List<UnidadDTO> listDTO = new List<UnidadDTO>();

            return listDTO;
        }

    }
}