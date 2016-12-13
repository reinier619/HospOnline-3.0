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
    public class ExamenDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
        public int create(ExamenDTO examenDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Examen ( nombre_examen, fecha_examen, resultado, ingresoID ) values( @nombre_examen, @fecha_examen, @resultado, @ingresoID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@nombre_examen", examenDTO.nombre_examen);
            sqlcmd.Parameters.AddWithValue("@fecha_examen", examenDTO.fecha_examen);
            sqlcmd.Parameters.AddWithValue("@resultado", examenDTO.resultado);
            sqlcmd.Parameters.AddWithValue("@ingresoID", examenDTO.ingresoID);


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
        public DataTable read(ExamenDTO examenDTO)
        {
            //List<ExamenDTO> retornoDTO = new List<ExamenDTO>();

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Examen where examenID = @examenID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.Add(new SqlParameter("@examenID", SqlDbType.Int));
            sqlcmd.Parameters["@examenID"].Value = examenDTO.ingresoID;

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

        public ExamenDTO update(ExamenDTO examenDTO)
        {
            ExamenDTO retornoDTO = new ExamenDTO();

            return retornoDTO;
        }

        public int delete(ExamenDTO examenDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Examen WHERE examenID=@examenID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@examenID", examenDTO.examenID);
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

        public List<ExamenDTO> readAll(ExamenDTO examenDTO)
        {
            List<ExamenDTO> listDTO = new List<ExamenDTO>();

            return listDTO;
        }

        public DataTable readxIngreso(ExamenDTO examenDTO)
        {
            //List<ExamenDTO> retornoDTO = new List<ExamenDTO>();

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "select * from Examen where ingresoID = @ingresoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));
            sqlcmd.Parameters["@ingresoID"].Value = examenDTO.ingresoID;

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
    }
}