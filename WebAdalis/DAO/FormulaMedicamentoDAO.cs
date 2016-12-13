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
    public class FormulaMedicamentoDAO
    {
        string connectionString = @"Server=ADALIS-PC\SQLEXPRESS;Database=HospOnline;Trusted_Connection=True;";
        public DataTable read(FormulaMedicamentoDTO formulamedicamentoDTO)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from FormulaMedimiento where formulamedicamentoID = @formulaMedicamentoID";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);

            sqlcmd.Parameters.Add(new SqlParameter("@formulaMedicamentoID", SqlDbType.Int));
            sqlcmd.Parameters["@formulaMedicamentoID"].Value = formulamedicamentoDTO.formulamedicamentoID;

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
        public DataTable readxIngreso(FormulaMedicamentoDTO formulamedicamentoDTO)
        {
            //List<ExamenDTO> retornoDTO = new List<ExamenDTO>();

            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "select * from FormulaMedicamento where ingresoID = @ingresoID";
            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.Add(new SqlParameter("@ingresoID", SqlDbType.Int));
            sqlcmd.Parameters["@ingresoID"].Value = formulamedicamentoDTO.ingresoID;

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

        public int delete(FormulaMedicamentoDTO formulamedicamentoDTO)
        {
            int retorno = 0;

            string sql = "DELETE FROM FormulaMedicamento WHERE formulamedicamentoID=@formulamedicamentoID";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@formulamedicamentoID", formulamedicamentoDTO.formulamedicamentoID);
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

        public int create(FormulaMedicamentoDTO formulamedicamentoDTO)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection(connectionString);

            string sql = "INSERT INTO FormulaMedicamento ( medicamento, cantidad, medida, unidad_medida, ingresoID ) values( @medicamento, @cantidad, @medida, @unidad_medida, @ingresoID)";

            SqlCommand sqlcmd = new SqlCommand(sql, conn);
            sqlcmd.Parameters.AddWithValue("@medicamento", formulamedicamentoDTO.medicamento);
            sqlcmd.Parameters.AddWithValue("@cantidad", formulamedicamentoDTO.cantidad);
            sqlcmd.Parameters.AddWithValue("@medida", formulamedicamentoDTO.medida);
            sqlcmd.Parameters.AddWithValue("@unidad_medida", formulamedicamentoDTO.unidad_medida);
            sqlcmd.Parameters.AddWithValue("@ingresoID", formulamedicamentoDTO.ingresoID);



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