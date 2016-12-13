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
    public class TratamientoDAO
    {

        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
       
        public int create(TratamientoDTO tratamientoDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Tratamiento ( descripcion, egresoID, pacienteID, ingresoID) values( @descripcion, @egresoID, @pacienteID, @ingresoID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@descripcion", tratamientoDTO.descripcion);
            sqlcmd.Parameters.AddWithValue("@egresoID", tratamientoDTO.egresoID);
            sqlcmd.Parameters.AddWithValue("@pacienteID", tratamientoDTO.pacienteID);
            sqlcmd.Parameters.AddWithValue("@ingresoID", tratamientoDTO.ingresoID);

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
        public DataTable read(TratamientoDTO tratamientoDTO)
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Tratamiento where tratamientoID = @tratamientoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@tratamientoID", SqlDbType.Int));

            sqlcmd.Parameters["@tratamientoID"].Value = tratamientoDTO.tratamientoID;

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

        public DataTable readxEgreso(TratamientoDTO tratamientoDTO)
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Tratamiento where egresoID = @egresoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@egresoID", SqlDbType.Int));

            sqlcmd.Parameters["@egresoID"].Value = tratamientoDTO.egresoID;

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

        public DataTable readxIngreso(TratamientoDTO tratamientoDTO)
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Tratamiento where ingresoID = @ingresoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));

            sqlcmd.Parameters["@ingresoID"].Value = tratamientoDTO.ingresoID;

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

        public TratamientoDTO update(TratamientoDTO tratamientoDTO)
        {
            TratamientoDTO retornoDTO = new TratamientoDTO();

            return retornoDTO;
        }

        public int delete(TratamientoDTO tratamientoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Tratamieto WHERE tratamientoID=@tratamientoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tratamientoID", tratamientoDTO.tratamientoID);
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

        public List<TratamientoDTO> readAll(TratamientoDTO tratamientoDTO)
        {
            List<TratamientoDTO> listDTO = new List<TratamientoDTO>();

            return listDTO;
        }
    }
}