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
    public class IngresoDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
        
        public int create(IngresoDTO ingresoDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Ingreso ( estado, enfermedad, unidadID, salaID, camaID, descripcion, pacienteID, fecha_ingreso, hora_ingreso) values( @estado, @enfermedad, @unidadID, @salaID, @camaID, @descripcion, @pacienteID, @fecha_ingreso, @hora_ingreso)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@estado", ingresoDTO.estado);
            sqlcmd.Parameters.AddWithValue("@enfermedad", ingresoDTO.enfermedad);
            sqlcmd.Parameters.AddWithValue("@unidadID", ingresoDTO.unidadID);
            sqlcmd.Parameters.AddWithValue("@salaID", ingresoDTO.salaID);
            sqlcmd.Parameters.AddWithValue("@camaID", ingresoDTO.camaID);
            sqlcmd.Parameters.AddWithValue("@descripcion", ingresoDTO.descripcion);
            sqlcmd.Parameters.AddWithValue("@pacienteID", ingresoDTO.pacienteID);
            sqlcmd.Parameters.AddWithValue("@fecha_ingreso", ingresoDTO.fecha_ingreso);
            sqlcmd.Parameters.AddWithValue("@hora_ingreso", ingresoDTO.hora_ingreso);

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

        public DataTable readxPaciente(IngresoDTO ingresoDTO)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Ingreso WHERE pacienteID = @pacienteID and estado <> 'INACTIVO'";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@pacienteID", SqlDbType.Int));

            sqlcmd.Parameters["@pacienteID"].Value = ingresoDTO.pacienteID;

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

        public DataTable read(IngresoDTO ingresoDTO)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Ingreso WHERE ingresoID = @ingresoID and estado = 'ACTIVO'";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));
            sqlcmd.Parameters["@ingresoID"].Value = ingresoDTO.pacienteID;

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

        public IngresoDTO update(IngresoDTO ingresoDTO)
        {
            IngresoDTO retornoDTO = new IngresoDTO();

            return retornoDTO;
        }

        public int delete(IngresoDTO ingresoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Ingreso WHERE ingresoID=@ingresoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ingresoID", ingresoDTO.ingresoID);
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

        public List<IngresoDTO> readAll(IngresoDTO ingresoDTO)
        {
            List<IngresoDTO> listDTO = new List<IngresoDTO>();

            return listDTO;
        }
    }
}