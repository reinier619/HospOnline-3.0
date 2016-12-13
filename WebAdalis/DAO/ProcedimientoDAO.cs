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
    public class ProcedimientoDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
       
        public int create(ProcedimientoDTO procedimientoDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Procedimiento (nombre, cantidad, periodo, fecha_inicio_procedimiento, ingresoID) values(@nombre, @cantidad, @periodo, @fecha_inicio_procedimiento, @ingresoID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@nombre", procedimientoDTO.nombre);
            sqlcmd.Parameters.AddWithValue("@cantidad", procedimientoDTO.cantidad);
            sqlcmd.Parameters.AddWithValue("@periodo", procedimientoDTO.periodo);
            sqlcmd.Parameters.AddWithValue("@fecha_inicio_procedimiento", procedimientoDTO.fecha_inicio_procedimiento);
            sqlcmd.Parameters.AddWithValue("@ingresoID", procedimientoDTO.ingresoID);

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

        public DataTable read(ProcedimientoDTO procedimientoDTO)
        {

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Procedimiento where procedimiento = @procedimientoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@procedimientoID", SqlDbType.Int));

            sqlcmd.Parameters["@procedimientoID"].Value = procedimientoDTO.procedimientoID;

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

        public DataTable readxIngreso(ProcedimientoDTO procedimientoDTO)
        {

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Procedimiento where ingresoID = @ingresoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));

            sqlcmd.Parameters["@ingresoID"].Value = procedimientoDTO.ingresoID;

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

        public ProcedimientoDTO update(ProcedimientoDTO procedimientoDTO)
        {
            ProcedimientoDTO retornoDTO = new ProcedimientoDTO();

            return retornoDTO;
        }

        public int delete(ProcedimientoDTO procedimientoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Procedimiento WHERE procedimietoID=@procedimientoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@procedimietoID", procedimientoDTO.procedimientoID);
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

        public List<ProcedimientoDTO> readAll(ProcedimientoDTO procedimientoDTO)
        {
            List<ProcedimientoDTO> listDTO = new List<ProcedimientoDTO>();

            return listDTO;
        }
    }
}