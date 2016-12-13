using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospOnline.DAO
{
    public class ImagenDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HOSP_IMAGENES;Trusted_Connection=True;";
        public DataTable readxIngreso(ImagenDTO imagenDTO)
        {
            //List<ExamenDTO> retornoDTO = new List<ExamenDTO>();

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "select * from Imagen where ingresoID = @ingresoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));
            sqlcmd.Parameters["@ingresoID"].Value = imagenDTO.ingresoID;

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

        public DataTable read(ImagenDTO imagenDTO)
        {
            //List<ExamenDTO> retornoDTO = new List<ExamenDTO>();

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "select * from Imagen where imagenID = @imagenID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.Add(new SqlParameter("@imagenID", SqlDbType.Int));
            sqlcmd.Parameters["@imagenID"].Value = imagenDTO.ingresoID;

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

        public int delete(ImagenDTO imagenDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Imagen WHERE imagenID=@imagenID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@imagenID", imagenDTO.imagenID);
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
    }
}