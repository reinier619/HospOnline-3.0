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
    public class PersonaDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";

        public int create(PersonaDTO personaDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO Persona ( rut, dv, nombres, ap_paterno, ap_materno, direccion, telefono) values(@rut, @dv, @nombres, @ap_paterno, @ap_materno, @direccion, @telefono)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.AddWithValue("@rut", personaDTO.rut);
            sqlcmd.Parameters.AddWithValue("@dv", personaDTO.digito_verificador);
            sqlcmd.Parameters.AddWithValue("@nombres", personaDTO.nombre);
            sqlcmd.Parameters.AddWithValue("@ap_paterno", personaDTO.apellido_paterno);
            sqlcmd.Parameters.AddWithValue("@ap_materno", personaDTO.apellido_materno);
            sqlcmd.Parameters.AddWithValue("@direccion", personaDTO.direccion);
            sqlcmd.Parameters.AddWithValue("@telefono", personaDTO.telefono);

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
        public DataTable read(PersonaDTO personaDTO)
        {
            
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from Persona where personaID = @personaID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@personaID", SqlDbType.Int));

            sqlcmd.Parameters["@personaID"].Value = personaDTO.personaID;

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

        public PersonaDTO update(PersonaDTO personaDTO)
        {
            PersonaDTO retornoDTO = new PersonaDTO();

            return retornoDTO;
        }

        public int delete(PersonaDTO personaDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM Persona WHERE personaID=@personaID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@personaID", personaDTO.personaID);
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

        public List<PersonaDTO> readAll(PersonaDTO personaDTO)
        {
            List<PersonaDTO> listDTO = new List<PersonaDTO>();

            return listDTO;
        }
    }
}