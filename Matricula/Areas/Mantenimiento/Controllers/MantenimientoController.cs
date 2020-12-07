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
        ActionsBDMaterias actionsMaterias = new ActionsBDMaterias();
        ActionsBDCarreras actionsCarreras = new ActionsBDCarreras();
        ActionsBDPlanesEstudio actionsPlanes = new ActionsBDPlanesEstudio();
        ActionsBDPeriodos actionsPeriodos = new ActionsBDPeriodos();

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
            nombres.Add("Periodos");
            nombres.Add("Horarios");
            nombres.Add("Materias");
            nombres.Add("Carreras");
            nombres.Add("Planes Estudios");

            return nombres;
        }

        public List<string> llenarpathImages()
        {
            List<string> pathImages = new List<string>();
            pathImages.Add("iconsRequesitos.png");
            pathImages.Add("iconsRequesitos.png");
            pathImages.Add("iconsOferta.png");
            pathImages.Add("iconsHorario.png");
            pathImages.Add("iconsMaterias.png");
            pathImages.Add("iconsCarreras.png");
            pathImages.Add("iconsPlan.png");

            return pathImages;
        }

        public List<string> llenarNombreCarpeta()
        {
            List<string> nombresCarpetas = new List<string>();
            nombresCarpetas.Add("Co_Requesitos");
            nombresCarpetas.Add("Requesitos");
            nombresCarpetas.Add("Periodos");
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
            nombresRegistrar.Add("RegistrarPeriodos");
            nombresRegistrar.Add("RegistrarHorarios");
            nombresRegistrar.Add("RegistrarMaterias");
            nombresRegistrar.Add("RegistrarCarreras");
            nombresRegistrar.Add("RegistrarPlanes_Estudios");

            return nombresRegistrar;
        }

        public List<string> llenarNombreAction()
        {
            List<string> nombresAction = new List<string>();
            nombresAction.Add("listadoCo_Requesitos");
            nombresAction.Add("listadoRequesitos");
            nombresAction.Add("listadoPeriodos");
            nombresAction.Add("listadoHorarios");
            nombresAction.Add("listadoMaterias");
            nombresAction.Add("listadoCarreras");
            nombresAction.Add("listadoPlanes_Estudios");

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
                List<Co_RequesitosM> resul = buscarCo_Requesito(data, filtrar);

                foreach(Co_RequesitosM temp in resul)
                {
                    if (temp.Nombre != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
                
                return View(datafiltrada);
            }
        }

        public List<Co_RequesitosM> buscarCo_Requesito(List<Co_RequesitosM> data, string filtro)
        {
            List<Co_RequesitosM> resul = new List<Co_RequesitosM>();
            foreach (Co_RequesitosM temp in data)
            {
                if (temp.Nombre.Equals(filtro))
                {
                    Co_RequesitosM tempe = new Co_RequesitosM();
                    tempe.Codigo_CoRequesito = temp.Codigo_CoRequesito;
                    tempe.Nombre = temp.Nombre;

                    resul.Add(tempe);
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
                List<RequesitosM> resul = buscarRequesito(data, filtrar);
                foreach(RequesitosM temp in resul)
                {
                    if (temp.Nombre_Requesito != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
               
                return View(datafiltrada);
            }
        }

        public List<RequesitosM> buscarRequesito(List<RequesitosM> data, string filtro)
        {
            List<RequesitosM> resul = new List<RequesitosM>();
            foreach (RequesitosM temp in data)
            {
                if (temp.Nombre_Requesito.Equals(filtro))
                {
                    RequesitosM tempe = new RequesitosM();
                    tempe.Codigo_Requesito = temp.Codigo_Requesito;
                    tempe.Nombre_Requesito = temp.Nombre_Requesito;

                    resul.Add(tempe);
                }
            }

            return resul;
        }

        public IActionResult listadoPeriodos(string filtrar)
        {
            List<PeriodosM> data = actionsPeriodos.getPeriodos();
            if (filtrar == null)
            {
                return View(data);
            }
            else
            {
                List<PeriodosM> datafiltrada = new List<PeriodosM>();
                List<PeriodosM> resul = buscarPeriodos(data, filtrar);
                foreach(PeriodosM temp in resul)
                {
                    if (temp.Nombre_Periodo != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
                
                return View(datafiltrada);
            }
        }

        public List<PeriodosM> buscarPeriodos(List<PeriodosM> data, string filtro)
        {
            List<PeriodosM> resul = new List<PeriodosM>();
            foreach (PeriodosM temp in data)
            {
                if (temp.Nombre_Periodo.Equals(filtro))
                {
                    PeriodosM tempe = new PeriodosM();
                    tempe.Codigo_Periodo = temp.Codigo_Periodo;
                    tempe.Nombre_Periodo = temp.Nombre_Periodo;
                    tempe.Nombre_Anno = temp.Nombre_Anno;

                    resul.Add(tempe);
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
                List<HorariosM> resul = buscarHorario(data, filtrar);
                foreach(HorariosM temp in resul)
                {
                    if (temp.Dia != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
                
                return View(datafiltrada);
            }
        }

        public List<HorariosM> buscarHorario(List<HorariosM> data, string filtro)
        {
            List<HorariosM> resul = new List<HorariosM>();
            foreach (HorariosM temp in data)
            {
                if (temp.Dia.Equals(filtro))
                {
                    HorariosM tempe = new HorariosM();
                    tempe.Codigo_Horario = temp.Codigo_Horario;
                    tempe.Dia = temp.Dia;
                    tempe.Hora_Inicial = temp.Hora_Inicial;
                    tempe.Hora_Final = temp.Hora_Final;

                    resul.Add(tempe);
                }
            }

            return resul;
        }

        public IActionResult listadoMaterias(string filtrar)
        {
            List<MateriasM> data = actionsMaterias.getMaterias();
            if (filtrar == null)
            {
                return View(data);
            }
            else
            {
                List<MateriasM> datafiltrada = new List<MateriasM>();
                List<MateriasM> resul = buscarMateria(data, filtrar);
                foreach(MateriasM temp in resul)
                {
                    if (temp.Nombre != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
                
                return View(datafiltrada);
            }
        }

        public List<MateriasM> buscarMateria(List<MateriasM> data, string filtro)
        {
            List<MateriasM> resul = new List<MateriasM>();
            foreach (MateriasM temp in data)
            {
                if (temp.Nombre.Equals(filtro))
                {
                    MateriasM tempe = new MateriasM();
                    tempe.Codigo_Materia = temp.Codigo_Materia;
                    tempe.Nombre = temp.Nombre;
                    tempe.Descripcion = temp.Descripcion;
                    tempe.Creditos = temp.Creditos;
                    tempe.Nombre_Requesito = temp.Nombre_Requesito;
                    tempe.NombreCo_Requesito = temp.NombreCo_Requesito;

                    resul.Add(tempe);
                }
            }

            return resul;
        }

        public IActionResult listadoCarreras(string filtrar)
        {
            List<CarrerasM> data = actionsCarreras.getCarreras();
            if (filtrar == null)
            {
                return View(data);
            }
            else
            {
                List<CarrerasM> datafiltrada = new List<CarrerasM>();
                List<CarrerasM> resul = buscarCarrera(data, filtrar);
                foreach(CarrerasM temp in resul)
                {
                    if (temp.Nombre_Carrera != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
                
                return View(datafiltrada);
            }
        }

        public List<CarrerasM> buscarCarrera(List<CarrerasM> data, string filtro)
        {
            List<CarrerasM> resul = new List<CarrerasM>();
            foreach (CarrerasM temp in data)
            {
                if (temp.Nombre_Carrera.Equals(filtro))
                {
                    CarrerasM tempe = new CarrerasM();
                    tempe.Codigo_Carrera = temp.Codigo_Carrera;
                    tempe.Nombre_Carrera = temp.Nombre_Carrera;
                    tempe.Descripcion_Carrera = temp.Descripcion_Carrera;

                    resul.Add(tempe);
                }
            }

            return resul;
        }

        public IActionResult listadoPlanes_Estudios(string filtrar)
        {
            List<PlanesEstudioM> data = actionsPlanes.getPlanes();
            if (filtrar == null)
            {
                return View(data);
            }
            else
            {
                List<PlanesEstudioM> datafiltrada = new List<PlanesEstudioM>();
                List<PlanesEstudioM> resul = buscarPlan(data, filtrar);
                foreach(PlanesEstudioM temp in resul)
                {
                    if (temp.Nombre_Plan != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
               
                return View(data);
            }
        }

        public List<PlanesEstudioM> buscarPlan(List<PlanesEstudioM> data, string filtro)
        {
            List<PlanesEstudioM> resul = new List<PlanesEstudioM>();
            foreach (PlanesEstudioM temp in data)
            {
                if (temp.Nombre_Carrera.Equals(filtro))
                {
                    PlanesEstudioM tempe = new PlanesEstudioM();
                    tempe.Codigo_Plan = temp.Codigo_Plan;
                    tempe.Nombre_Plan = temp.Nombre_Plan;
                    tempe.Descripcion_Plan = temp.Descripcion_Plan;
                    temp.Nombre_Carrera = temp.Nombre_Carrera;

                    resul.Add(tempe);
                }
            }

            return resul;
        }
    }
}
