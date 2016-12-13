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
    public class EgresoDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
        public int create(EgresoDTO egresoDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Egreso (fecha_egreso, descripcion, ingresoID) values(@fecha_egreso, @descripcion, @ingresoID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@fecha_egreso", egresoDTO.fecha_egreso);
            sqlcmd.Parameters.AddWithValue("@descripcion", egresoDTO.descripcion);
            sqlcmd.Parameters.AddWithValue("@ingresoID", egresoDTO.ingresoID);

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
        public DataTable readxIngreso(EgresoDTO egresoDTO)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            
            string sql = "select * from Egreso where ingresoID = @ingresoID";
            
            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));
            sqlcmd.Parameters["@ingresoID"].Value = egresoDTO.ingresoID;

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

        public DataTable read(EgresoDTO egresoDTO)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Egreso where egresoID = @egresoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@egresoID", SqlDbType.Int));
            sqlcmd.Parameters["@egresoID"].Value = egresoDTO.ingresoID;

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

        public EgresoDTO update(EgresoDTO egresoDTO)
        {
            EgresoDTO retornoDTO = new EgresoDTO();

            return retornoDTO;
        }

        public int delete(EgresoDTO egresoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Egreso WHERE egresoID=@egresoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@egresoID", egresoDTO.egresoID);
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

        public List<EgresoDTO> readAll(EgresoDTO egresoDTO)
        {
            List<EgresoDTO> listDTO = new List<EgresoDTO>();

            return listDTO;
        }
    }
}