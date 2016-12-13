using HospOnline.DAO;
using HospOnline.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospOnline.NEG
{
    public class IngresoNEG
    {
        public IngresoDTO readxPaciente(IngresoDTO ingresoDTO)
        {
            IngresoDTO retornoDTO = new IngresoDTO();
            IngresoDAO ingresoDAO = new IngresoDAO();
            DataTable dt = new DataTable();

            dt = ingresoDAO.readxPaciente(ingresoDTO);

            foreach(DataRow row in dt.Rows)
            {
                retornoDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
                retornoDTO.estado = row["estado"].ToString();
                retornoDTO.enfermedad = row["enfermedad"].ToString();
                retornoDTO.unidadID = Convert.ToInt64(row["unidadID"].ToString());

                if (retornoDTO.unidadID != null)
                {
                    UnidadDTO unidadDTO = new UnidadDTO();
                    UnidadNEG unidadNEG = new UnidadNEG();

                    unidadDTO.unidadID = retornoDTO.unidadID;

                    retornoDTO.unidad = new UnidadDTO();

                    retornoDTO.unidad = unidadNEG.read(unidadDTO);

                }
                
                retornoDTO.salaID = Convert.ToInt64(row["salaID"].ToString());

                if (retornoDTO.salaID != null)
                {
                    SalaDTO salaDTO = new SalaDTO();
                    SalaNEG salaNEG = new SalaNEG();

                    salaDTO.salaID = retornoDTO.salaID;
                    
                    retornoDTO.sala = new SalaDTO();
                    
                    retornoDTO.sala = salaNEG.read(salaDTO);                    
                }

                retornoDTO.camaID = Convert.ToInt64(row["camaID"].ToString());

                if (retornoDTO.camaID != null)
                {
                    CamaDTO camaDTO = new CamaDTO();
                    CamaNEG camaNEG = new CamaNEG();

                    camaDTO.camaID = retornoDTO.camaID;
                    
                    retornoDTO.cama = new CamaDTO();
                    
                    retornoDTO.cama = camaNEG.read(camaDTO);
                }

                retornoDTO.descripcion = row["descripcion"].ToString();
                retornoDTO.pacienteID = Convert.ToInt64(row["pacienteID"].ToString());
                retornoDTO.fecha_ingreso = Convert.ToDateTime(row["fecha_ingreso"].ToString());
                retornoDTO.hora_ingreso = row["hora_ingreso"].ToString();
            }

            return retornoDTO;
        }

        public IngresoDTO read(IngresoDTO ingresoDTO)
        {
            IngresoDTO retornoDTO = new IngresoDTO();
            IngresoDAO ingresoDAO = new IngresoDAO();
            DataTable dt = new DataTable();

            dt = ingresoDAO.read(ingresoDTO);

            foreach (DataRow row in dt.Rows)
            {
                retornoDTO.ingresoID = Convert.ToInt64(row["ingresoID"].ToString());
                retornoDTO.estado = row["estado"].ToString();
                retornoDTO.enfermedad = row["enfermedad"].ToString();
                retornoDTO.unidadID = Convert.ToInt64(row["unidadID"].ToString());

                if (retornoDTO.unidadID != 0)
                {
                    UnidadDTO unidadDTO = new UnidadDTO();
                    UnidadNEG unidadNEG = new UnidadNEG();

                    unidadDTO.unidadID = retornoDTO.unidadID;

                    retornoDTO.unidad = new UnidadDTO();

                    retornoDTO.unidad = unidadNEG.read(unidadDTO);

                }

                retornoDTO.salaID = Convert.ToInt64(row["salaID"].ToString());

                if (retornoDTO.salaID != 0)
                {
                    SalaDTO salaDTO = new SalaDTO();
                    SalaNEG salaNEG = new SalaNEG();

                    salaDTO.salaID = retornoDTO.salaID;

                    retornoDTO.sala = new SalaDTO();

                    retornoDTO.sala = salaNEG.read(salaDTO);
                }

                retornoDTO.camaID = Convert.ToInt64(row["camaID"].ToString());

                if (retornoDTO.camaID != 0)
                {
                    CamaDTO camaDTO = new CamaDTO();
                    CamaNEG camaNEG = new CamaNEG();

                    camaDTO.camaID = retornoDTO.camaID;

                    retornoDTO.cama = new CamaDTO();

                    retornoDTO.cama = camaNEG.read(camaDTO);
                }

                retornoDTO.descripcion = row["descripcion"].ToString();
                retornoDTO.pacienteID = Convert.ToInt64(row["pacienteID"].ToString());
                retornoDTO.fecha_ingreso = Convert.ToDateTime(row["fecha_ingreso"].ToString());
                retornoDTO.hora_ingreso = row["hora_ingreso"].ToString();   
            }

            return retornoDTO;

        }

        public int delete(IngresoDTO ingresoDTO)
        {
            int retorno = 0;
            IngresoDAO ingresoDAO = new IngresoDAO();

            retorno = ingresoDAO.delete(ingresoDTO);

            return retorno;
        }

        public int create(IngresoDTO ingresoDTO)
        {
            int retorno = 0;
            IngresoDAO ingresoDAO = new IngresoDAO();

            retorno = ingresoDAO.create(ingresoDTO);

            return retorno;
        }
    }
}