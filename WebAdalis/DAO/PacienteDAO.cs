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
    public class PacienteDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=Hosp_Ingreso;Trusted_Connection=True;";

        public PacienteDTO create(PacienteDTO pacienteDTO)
        {
            PacienteDTO retornoDTO = new PacienteDTO();

            return retornoDTO;
        }

        public DataTable read(PacienteDTO pacienteDTO)
        {

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Paciente WHERE pacienteID = @pacienteID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@pacienteID", SqlDbType.VarChar));
            sqlcmd.Parameters["@pacienteID"].Value = pacienteDTO.pacienteID;
            

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

        public PacienteDTO update(PacienteDTO pacienteDTO)
        {
            PacienteDTO retornoDTO = new PacienteDTO();

            return retornoDTO;
        }

        public List<PacienteDTO> readAll(PacienteDTO pacienteDTO)
        {
            List<PacienteDTO> listDTO = new List<PacienteDTO>();

            return listDTO;
        }

        public DataTable BuscarxRut(PacienteDTO pacienteDTO)
        {
            
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Paciente WHERE rut = @rut and clave = @clave";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@rut", SqlDbType.VarChar));
            sqlcmd.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar));

            sqlcmd.Parameters["@rut"].Value = pacienteDTO.rut;
            sqlcmd.Parameters["@clave"].Value = pacienteDTO.clave;

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

        public DataTable BuscarPacienteRut(PacienteDTO pacienteDTO)
        {

            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Paciente WHERE rut = @rut";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@rut", SqlDbType.VarChar));

            sqlcmd.Parameters["@rut"].Value = pacienteDTO.rut;

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

        public int delete(PacienteDTO pacienteDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Paciente WHERE pacienteID=@pacienteID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pacienteID", pacienteDTO.pacienteID);
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