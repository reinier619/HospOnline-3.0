using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class FormulaMedicamentoNEG
    {
        public FormulaMedicamentoDTO read(FormulaMedicamentoDTO formulamedicamentoDTO)
        {
            FormulaMedicamentoDTO retornoDTO = new FormulaMedicamentoDTO();
            FormulaMedicamentoDAO formulamedicamentoDAO = new FormulaMedicamentoDAO();
            DataTable dt = new DataTable();

            dt = formulamedicamentoDAO.read(formulamedicamentoDTO);

            foreach (DataRow row in dt.Rows)
            {
                retornoDTO.formulamedicamentoID = Convert.ToInt64(row["formulamedicamentoID"].ToString());
                retornoDTO.medicamento = row["medicamento"].ToString();
                retornoDTO.cantidad = row["cantidad"].ToString();
                retornoDTO.medida = row["medida"].ToString();
                retornoDTO.unidad_medida = row["medida"].ToString();
                retornoDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
                
            }
            return retornoDTO;
        }

        public List<FormulaMedicamentoDTO> readxIngreso(FormulaMedicamentoDTO formulamedicamentoDTO)
        {
            List<FormulaMedicamentoDTO> lretornoDTO = new List<FormulaMedicamentoDTO>();
            FormulaMedicamentoDAO formulamedicamentoDAO = new FormulaMedicamentoDAO();
            FormulaMedicamentoDTO formulamedDTO = null;
            DataTable dt = new DataTable();

            dt = formulamedicamentoDAO.readxIngreso(formulamedicamentoDTO);

            foreach (DataRow row in dt.Rows)
            {
                formulamedDTO = new FormulaMedicamentoDTO();

                formulamedDTO.formulamedicamentoID = Convert.ToInt64(row["formulamedicamentoID"].ToString());
                formulamedDTO.medicamento = row["medicamento"].ToString();
                formulamedDTO.cantidad = row["cantidad"].ToString();
                formulamedDTO.medida = row["medida"].ToString();
                formulamedDTO.unidad_medida = row["unidad_medida"].ToString();
                formulamedDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());

                lretornoDTO.Add(formulamedDTO);
            }
            return lretornoDTO;
        }

        public int delete(FormulaMedicamentoDTO formMedDTO)
        {
            int retorno = 0;
            FormulaMedicamentoDAO formMedDAO = new FormulaMedicamentoDAO();

            retorno = formMedDAO.delete(formMedDTO);

            return retorno;
        }
    
        public int create(FormulaMedicamentoDTO formMedDTO)
        {
            int retorno = 0;
            FormulaMedicamentoDAO formMedDAO = new FormulaMedicamentoDAO();

            retorno = formMedDAO.create(formMedDTO);

            return retorno;
        }
    }

}