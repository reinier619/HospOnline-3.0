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
    public class DiagnosticoDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
        
        public int create(DiagnosticoDTO diagnosticoDTO)
        {

            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Diagnostico ( descripcion, fecha_diagnostico, ingresoID ) values( @descripcion, @fecha_diagnostico, @ingresoID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@descripcion", diagnosticoDTO.descripcion);
            sqlcmd.Parameters.AddWithValue("@fecha_diagnostico", diagnosticoDTO.fecha_diagnostico);
            sqlcmd.Parameters.AddWithValue("@ingresoID", diagnosticoDTO.ingresoID);

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
        public DataTable read(DiagnosticoDTO diagnosticoDTO)
        {
            DiagnosticoDTO dDTO = new DiagnosticoDTO();

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Diagnostico where diagnosticoID = @diagnosticoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@diagnosticoID", SqlDbType.Int));

            sqlcmd.Parameters["@diagnosticoID"].Value = diagnosticoDTO.diagnosticoID;

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

        public DataTable readxIngreso(DiagnosticoDTO diagnosticoDTO)
        {
            DiagnosticoDTO dDTO = new DiagnosticoDTO();

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Diagnostico where ingresoID = @ingresoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));

            sqlcmd.Parameters["@ingresoID"].Value = diagnosticoDTO.ingresoID;

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


        public DiagnosticoDTO update(DiagnosticoDTO diagnosticoDTO)
        {
            DiagnosticoDTO retornoDTO = new DiagnosticoDTO();

            return retornoDTO;
        }

        public int delete(DiagnosticoDTO diagnosticoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Diagnostico WHERE diagnosticoID=@diagnosticoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@diagnosticoID", diagnosticoDTO.diagnosticoID);
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

        public List<DiagnosticoDTO> readAll(DiagnosticoDTO unidadDTO)
        {
            List<DiagnosticoDTO> listDTO = new List<DiagnosticoDTO>();

            return listDTO;
        }

    }
}