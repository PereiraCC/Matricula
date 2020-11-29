using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Mantenimiento.Controllers
{
    [Area("Mantenimiento")]
    public class MantenimientoController : Controller
    {
        ActionsBDCo_Requesitos actionsCo_Requesito = new ActionsBDCo_Requesitos();
        ActionsBDRequesitos actionsRequesito = new ActionsBDRequesitos();
        ActionsBDHorarios actionsHorarios = new ActionsBDHorarios();

        public IActionResult Mantenimiento(string filtrar)
        {
            if (LUser.login == true)
            {
                List<string> nombres = llenarNombres();
                List<string> pathImages = llenarpathImages();
                List<string> nombresCarpeta = llenarNombreCarpeta();
                List<string> nombresRegistrar = llenarNombreArchivoRegistrar();
                List<string> nombresActions = llenarNombreAction();
                List<MantenimientoModel> data = llenarData(nombres, pathImages, nombresCarpeta, nombresRegistrar, nombresActions);

                if (filtrar == null)
                {
                    return View(data);
                }
                else
                {
                    List<MantenimientoModel> datafiltrada = new List<MantenimientoModel>();
                    MantenimientoModel resul = buscarData(data, filtrar);
                    if(resul.nombre != null)
                    {
                        datafiltrada.Add(resul);
                    }
                    
                    return View(datafiltrada);
                }
            }
            else
            {
                return Redirect("/");
            }
            
        }

        public List<string> llenarNombres()
        {
            List<string> nombres = new List<string>();
            nombres.Add("Co-Requesitos");
            nombres.Add("Requesitos");
            nombres.Add("Horarios");
            nombres.Add("Materias");
            nombres.Add("Carreras");
            nombres.Add("Planes Estudios");
            nombres.Add("Ofertas Academicas");

            return nombres;
        }

        public List<string> llenarpathImages()
        {
            List<string> pathImages = new List<string>();
            pathImages.Add("iconsRequesitos.png");
            pathImages.Add("iconsRequesitos.png");
            pathImages.Add("iconsHorario.png");
            pathImages.Add("iconsMaterias.png");
            pathImages.Add("iconsCarreras.png");
            pathImages.Add("iconsPlan.png");
            pathImages.Add("iconsOferta.png");

            return pathImages;
        }

        public List<string> llenarNombreCarpeta()
        {
            List<string> nombresCarpetas = new List<string>();
            nombresCarpetas.Add("Co_Requesitos");
            nombresCarpetas.Add("Requesitos");
            nombresCarpetas.Add("Horarios");
            nombresCarpetas.Add("Materias");
            nombresCarpetas.Add("Carreras");
            nombresCarpetas.Add("Planes_Estudios");
            nombresCarpetas.Add("Ofertas_Academicas");

            return nombresCarpetas;
        }

        public List<string> llenarNombreArchivoRegistrar()
        {
            List<string> nombresRegistrar = new List<string>();
            nombresRegistrar.Add("RegistrarCo_Requesitos");
            nombresRegistrar.Add("RegistrarRequesitos");
            nombresRegistrar.Add("RegistrarHorarios");
            nombresRegistrar.Add("RegistrarMaterias");
            nombresRegistrar.Add("RegistrarCarreras");
            nombresRegistrar.Add("RegistrarPlanes_Estudios");
            nombresRegistrar.Add("RegistrarOfertas_Academicas");

            return nombresRegistrar;
        }

        public List<string> llenarNombreAction()
        {
            List<string> nombresAction = new List<string>();
            nombresAction.Add("listadoCo_Requesitos");
            nombresAction.Add("listadoRequesitos");
            nombresAction.Add("listadoHorarios");
            nombresAction.Add("listadoMaterias");
            nombresAction.Add("listadoCarreras");
            nombresAction.Add("listadoPlanes_Estudios");
            nombresAction.Add("listadoOfertas_Academicas");

            return nombresAction;
        }

        public List<MantenimientoModel> llenarData(List<string> nombres, List<string> pathImages, List<string> nombresCarpetas, List<string> nombresRegistrar, List<string> nombresActions)
        {
            List<MantenimientoModel> data = new List<MantenimientoModel>();
            for (int i = 0; i < 7; i++)
            {
                MantenimientoModel temp = new MantenimientoModel();
                temp.nombre = nombres[i].ToString();
                temp.pathImg = pathImages[i].ToString();
                temp.nombreCarpeta = nombresCarpetas[i].ToString();
                temp.nombreRegistrar = nombresRegistrar[i].ToString();
                temp.nombreAction = nombresActions[i].ToString();

                data.Add(temp);
            }

            return data;
        }

        public MantenimientoModel buscarData(List<MantenimientoModel> data, string filtro)
        {
            MantenimientoModel resul = new MantenimientoModel();
            foreach(MantenimientoModel temp in data)
            {
                if (temp.nombre.Equals(filtro))
                {
                    resul.nombre = temp.nombre;
                    resul.pathImg = temp.pathImg;
                }
            }

            return resul;
        }

        public IActionResult listadoCo_Requesitos(string filtrar)
        {
            List<Co_RequesitosM> data = actionsCo_Requesito.getCo_Requesitos();
            if (filtrar == null)
            {
                return View(data);
            }
            else
            {
                List<Co_RequesitosM> datafiltrada = new List<Co_RequesitosM>();
                Co_RequesitosM resul = buscarCo_Requesito(data, filtrar);
                if (resul.Nombre != null)
                {
                    datafiltrada.Add(resul);
                }

                return View(datafiltrada);
            }
        }

        public Co_RequesitosM buscarCo_Requesito(List<Co_RequesitosM> data, string filtro)
        {
            Co_RequesitosM resul = new Co_RequesitosM();
            foreach (Co_RequesitosM temp in data)
            {
                if (temp.Nombre.Equals(filtro))
                {
                    resul.Codigo_CoRequesito = temp.Codigo_CoRequesito;
                    resul.Nombre = temp.Nombre;
                }
            }

            return resul;
        }

        public IActionResult listadoRequesitos(string filtrar)
        {
            List<RequesitosM> data = actionsRequesito.getRequesitos();
            if (filtrar == null)
            {
                return View(data);
            }
            else
            {
                List<RequesitosM> datafiltrada = new List<RequesitosM>();
                RequesitosM resul = buscarRequesito(data, filtrar);
                if (resul.Nombre_Requesito != null)
                {
                    datafiltrada.Add(resul);
                }

                return View(datafiltrada);
            }
        }

        public RequesitosM buscarRequesito(List<RequesitosM> data, string filtro)
        {
            RequesitosM resul = new RequesitosM();
            foreach (RequesitosM temp in data)
            {
                if (temp.Nombre_Requesito.Equals(filtro))
                {
                    resul.Codigo_Requesito = temp.Codigo_Requesito;
                    resul.Nombre_Requesito = temp.Nombre_Requesito;
                }
            }

            return resul;
        }

        public IActionResult listadoHorarios(string filtrar)
        {
            List<HorariosM> data = actionsHorarios.getHorarios();
            if (filtrar == null)
            {
                return View(data);
            }
            else
            {
                List<HorariosM> datafiltrada = new List<HorariosM>();
                HorariosM resul = buscarHorario(data, filtrar);
                if (resul.Dia != null)
                {
                    datafiltrada.Add(resul);
                }

                return View(datafiltrada);
            }
        }

        public HorariosM buscarHorario(List<HorariosM> data, string filtro)
        {
            HorariosM resul = new HorariosM();
            foreach (HorariosM temp in data)
            {
                if (temp.Dia.Equals(filtro))
                {
                    resul.Codigo_Horario = temp.Codigo_Horario;
                    resul.Dia = temp.Dia;
                    resul.Hora_Inicial = temp.Hora_Inicial;
                    resul.Hora_Final = temp.Hora_Final;
                }
            }

            return resul;
        }
    }
}
