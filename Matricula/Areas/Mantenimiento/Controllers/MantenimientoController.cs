using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Mantenimiento.Controllers
{
    [Area("Mantenimiento")]
    public class MantenimientoController : Controller
    {
        public IActionResult Mantenimiento(string filtrar)
        {
            if (LUser.login == true)
            {
                List<string> nombres = llenarNombres();
                List<string> pathImages = llenarpathImages();
                List<MantenimientoModel> data = llenarData(nombres, pathImages);

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


        public List<MantenimientoModel> llenarData(List<string> nombres, List<string> pathImages)
        {
            List<MantenimientoModel> data = new List<MantenimientoModel>();
            for (int i = 0; i < 7; i++)
            {
                MantenimientoModel temp = new MantenimientoModel();
                temp.nombre = nombres[i].ToString();
                temp.pathImg = pathImages[i].ToString();

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
    }
}
