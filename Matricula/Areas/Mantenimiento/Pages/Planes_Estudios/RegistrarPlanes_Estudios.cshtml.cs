using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Matricula.Areas.Mantenimiento.Pages.Planes_Estudios
{
    public class RegistrarPlanes_EstudiosModel : PageModel
    {
        public static InputModelPlanesEstudio _dataInput;
        ActionsBDPlanesEstudio actions = new ActionsBDPlanesEstudio();
        private static PlanesEstudioM _dataUser1;
        List<string> StrmateriasTec, StrmateriasTur, StrmateriasCri, StrmateriasDen, StrmateriasElec, StrmateriasSecre, StrmateriasAdm;

        public void OnGet()
        {
            List<List<SelectListItem>> Data = obtenerListaMateriasSegunCarrera();
            Input_Plan = new InputModelPlanesEstudio
            {
                lista_Carreras = obtenerListaCarreras(),
                lista_MateriasTecnologias = Data[0],
                lista_MateriasTurismo = Data[1],
                lista_MateriasCriminal = Data[2],
                lista_MateriasDental = Data[3],
                lista_MateriasElectronica = Data[4],
                lista_MateriasSecretariado = Data[5],
                lista_MateriasAdministracion = Data[6],
            };
        }

        [BindProperty]
        public InputModelPlanesEstudio Input_Plan { get; set; }

        public class InputModelPlanesEstudio : PlanesEstudioM
        {

            public List<SelectListItem> lista_Carreras { get; set; }

            public List<SelectListItem> lista_MateriasTecnologias { get; set; }

            public List<SelectListItem> lista_MateriasTurismo { get; set; }

            public List<SelectListItem> lista_MateriasCriminal { get; set; }

            public List<SelectListItem> lista_MateriasDental { get; set; }

            public List<SelectListItem> lista_MateriasElectronica { get; set; }

            public List<SelectListItem> lista_MateriasSecretariado { get; set; }

            public List<SelectListItem> lista_MateriasAdministracion { get; set; }

        }

        public List<SelectListItem> obtenerListaCarreras()
        {
            List<string> carreras = actions.getCarreras();
            List<SelectListItem> LCarreras = new List<SelectListItem>();
            foreach (string dato in carreras)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                LCarreras.Add(temp);
            }

            return LCarreras;
        }

        public List<List<SelectListItem>> obtenerListaMateriasSegunCarrera()
        {
            List<List<string>> dataMaterias = new List<List<string>>();
            List<List<SelectListItem>> data = new List<List<SelectListItem>>();
            List<string> carreras = actions.getCarreras();
            
            foreach (string dato in carreras)
            {
                List<string> materiasTemp = actions.getMateriasXCarrera(dato);
                dataMaterias.Add(materiasTemp);
            }

            List<SelectListItem> LMateriasTec = llenarMaterias(dataMaterias[0]);
            List<SelectListItem> LMateriasTur = llenarMaterias(dataMaterias[1]);
            List<SelectListItem> LMateriasCri = llenarMaterias(dataMaterias[2]);
            List<SelectListItem> LMateriasDen = llenarMaterias(dataMaterias[3]);
            List<SelectListItem> LMateriasElec = llenarMaterias(dataMaterias[4]);
            List<SelectListItem> LMateriasSecre = llenarMaterias(dataMaterias[5]);
            List<SelectListItem> LMateriasAdm = llenarMaterias(dataMaterias[6]);

            data.Add(LMateriasTec);
            data.Add(LMateriasTur);
            data.Add(LMateriasCri);
            data.Add(LMateriasDen);
            data.Add(LMateriasElec);
            data.Add(LMateriasSecre);
            data.Add(LMateriasAdm);

            return data;
        }

        public List<SelectListItem> llenarMaterias(List<string> data)
        {
            List<SelectListItem> listado = new List<SelectListItem>();
            foreach (string dato in data) 
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                listado.Add(temp);
            }

            return listado;
        }
    }
}
