using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class DiagnosticoNEG
    {
        public DiagnosticoDTO read(DiagnosticoDTO diagnosticoDTO)
        {
            DiagnosticoDTO diagDTO = new DiagnosticoDTO();
            DataTable dt = new DataTable();
            DiagnosticoDAO diagDAO = new DiagnosticoDAO();

            dt = diagDAO.read(diagnosticoDTO);

            foreach(DataRow row in dt.Rows)
            {
                diagDTO.diagnosticoID = Convert.ToInt64(row["diagnosticoID"].ToString());
                diagDTO.descripcion = row["descripcion"].ToString();
                diagDTO.fecha_diagnostico = Convert.ToDateTime(row["fecha_diagnostico"].ToString());
                diagDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());

            }

            return diagDTO;
        }
        public List<DiagnosticoDTO> readxIngreso(DiagnosticoDTO diagnosticoDTO)
        {
            List<DiagnosticoDTO> ldiagDTO = new List<DiagnosticoDTO>();
            DiagnosticoDTO dgDTO = null;
            DiagnosticoDAO dgDAO = new DiagnosticoDAO();
            DataTable dt = new DataTable();

            dt = dgDAO.readxIngreso(diagnosticoDTO);

            foreach(DataRow row in dt.Rows)
            {
                dgDTO = new DiagnosticoDTO();

                dgDTO.diagnosticoID = Convert.ToInt64(row["diagnosticoID"].ToString());
                dgDTO.descripcion = row["descripcion"].ToString();
                dgDTO.fecha_diagnostico = Convert.ToDateTime(row["fecha_diagnostico"].ToString());
                dgDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());

                ldiagDTO.Add(dgDTO);

            }

            return ldiagDTO;
        }

        public int delete(DiagnosticoDTO diagnosticoDTO)
        {
            int retorno = 0;
            DiagnosticoDAO diagnosticoDAO = new DiagnosticoDAO();

            retorno = diagnosticoDAO.delete(diagnosticoDTO);

            return retorno;
        }

        public int create(DiagnosticoDTO diagnosticoDTO)
        {
            int retorno = 0;
            DiagnosticoDAO diagnosticoDAO = new DiagnosticoDAO();

            retorno = diagnosticoDAO.create(diagnosticoDTO);

            return retorno;
        }

    }
}