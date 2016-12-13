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
    public class CargoDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";

        public DataTable read(CargoDTO cargoDTO)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Cargo WHERE cargoID = @cargoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@cargoID", SqlDbType.Int));
            sqlcmd.Parameters["@cargoID"].Value = cargoDTO.cargoID;

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

        public int delete(CargoDTO cargoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM FormulaMedicamento WHERE formulamedicamentoID=@formulamedicamentoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cargoID", cargoDTO.cargoID);
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

        public int create(CargoDTO cargoDTO)
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Cargo ( nombre ) values( @nombre)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.AddWithValue("@nombre", cargoDTO.nombre);
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
    }
}