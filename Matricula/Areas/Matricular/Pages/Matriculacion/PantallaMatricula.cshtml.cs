using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Matricular.Data;
using Matricula.Areas.Matricular.Models;
using Matricula.Controllers;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;


namespace Matricula.Areas.Matricular.Pages.Matriculacion
{
    public class PantallaMatriculaModel : PageModel
    {
        public static InputModelMatricula _dataInput;
        ActionsBDPeriodos actionsP = new ActionsBDPeriodos();
        ActionBDMatricular action = new ActionBDMatricular();
        private static MatricularM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Matricula = _dataInput;
            }
            else
            {
                Input_Matricula = new InputModelMatricula
                {
                    Lista_Periodos = obtenerPeriodos(),
                };
            }

            if (_dataUser1 != null)
            {
                Input_Matricula = new InputModelMatricula
                {
                    estudiante = _dataUser1.estudiante,
                    lista_Materias = _dataUser1.lista_Materias,
                    lista_MateriasMatriculadas = _dataUser1.lista_MateriasMatriculadas,
                    Monto = obtenerMonto(_dataUser1.lista_MateriasMatriculadas),
                    Lista_Periodos = obtenerPeriodos(),
                };
            }
            
        }

        [BindProperty]
        public InputModelMatricula Input_Matricula { get; set; }

        public class InputModelMatricula : MatricularM
        {
            public string Nombre_Periodo_Year { get; set; }
            public List<SelectListItem> Lista_Periodos { get; set; }
        }

        public IActionResult OnPost(string dataMatricula)
        {
            if (dataMatricula == null)
            {
                if (Input_Matricula.Numero_Tarjeta != null && Input_Matricula.Nombre_Periodo != null)
                {
                    if (registrandoMatricula() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            return generarBoleta();
                            //return Redirect("/Principal/Principal?area=Principal"); ;
                        }
                    }
                    else
                    {
                        return Redirect("/Matricular/Pantalla_Matricula");
                    }
                } 
                else
                {
                    Input_Matricula.ErrorMessage = "Digite un periodo y numero de tarjeta valido";
                    return Redirect("/Matricular/Pantalla_Matricula");
                }
            }
            else
            {
                _dataUser1 = JsonConvert.DeserializeObject<MatricularM>(dataMatricula);
                return Redirect("/Matricular/Pantalla_Matricula");
            }
            
        }

        public int registrandoMatricula()
        {
            _dataInput = Input_Matricula;
            _dataInput.lista_MateriasMatriculadas = _dataUser1.lista_MateriasMatriculadas;
            string[] temp = _dataInput.Nombre_Periodo.Split(" ");
            _dataInput.Nombre_Periodo_Year = _dataInput.Nombre_Periodo;
            _dataInput.Nombre_Periodo = temp[0] + " " + temp[1];
            int dato = 1;
            if (action.consultarMatriculaPeriodo(_dataInput.estudiante.Identificacion, _dataInput.Nombre_Periodo).Equals("0"))
            {
                int estado = Int32.Parse(action.registrarMatricular(_dataInput));
                if (estado == 0)
                {
                    dato = 0;
                }
                else
                {
                    dato = 1;
                }
            }
            else
            {
                _dataInput.ErrorMessage = "El estudiante ya realizo un matricula en ese mismo periodo.";
                dato = 1;
            }
            

            return dato;
        }

        public List<SelectListItem> obtenerPeriodos()
        {
            List<PeriodosM> periodos = actionsP.getPeriodos();

            List<SelectListItem> LPeriodos = new List<SelectListItem>();
            foreach (PeriodosM dato in periodos)
            {
                SelectListItem temp = new SelectListItem(dato.Nombre_Periodo + " " + dato.Nombre_Anno, dato.Nombre_Periodo + " " + dato.Nombre_Anno);
                LPeriodos.Add(temp);
            }

            return LPeriodos;
        }

        public string obtenerMonto(List<MateriasM> materias)
        {
            string monto = "";
            double tempMonto = 0.0;
            
            foreach(MateriasM materia in materias)
            {
                tempMonto += Double.Parse(materia.Costo.Substring(1)); 
            }

            return monto = tempMonto.ToString("0.00");
 
        }

        public IActionResult generarBoleta()
        {
            int contador = 200;
            string nombreC = _dataInput.estudiante.PrimerApellido + " " + _dataInput.estudiante.SegundoApellido + " " + _dataInput.estudiante.Nombre;
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);

            //Draw the text
            graphics.DrawString("Boleta de Matricula", font, PdfBrushes.Black, new PointF(0, 0));
            graphics.DrawString("\n", font, PdfBrushes.Black, new PointF(0, 20));
            graphics.DrawString("Identificacion estudiante: " + _dataInput.estudiante.Identificacion, font2, PdfBrushes.Black, new PointF(0, 40));
            graphics.DrawString("Nombre estudiante: " + nombreC, font2, PdfBrushes.Black, new PointF(0, 60));
            graphics.DrawString("Correo Electronico: " + _dataInput.estudiante.CorreoElectronico, font2, PdfBrushes.Black, new PointF(0, 80));
            graphics.DrawString("Carrera: " + _dataInput.estudiante.Carrera, font2, PdfBrushes.Black, new PointF(0, 100));
            graphics.DrawString("Periodo: " + _dataInput.Nombre_Periodo_Year, font2, PdfBrushes.Black, new PointF(0, 120));
            graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString(), font2, PdfBrushes.Black, new PointF(0, 140));
            graphics.DrawString("\n", font2, PdfBrushes.Black, new PointF(0, 160));

            graphics.DrawString("Materias", font2, PdfBrushes.Black, new PointF(0, 180));

            foreach(MateriasM materia in _dataInput.lista_MateriasMatriculadas)
            {
                graphics.DrawString("|Codigo Materia: " + materia.Codigo_Materia + "\t|Nombre Materia: " + materia.Nombre + "\t|Costo: " + materia.Costo, font2, PdfBrushes.Black, new PointF(0, contador));
                contador += 20;
            }

            graphics.DrawString("Costo Total: " + _dataInput.Monto, font2, PdfBrushes.Black, new PointF(0, contador + 20));


            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = nombreC.Trim() + ".pdf";

            return fileStreamResult;
        }
    }
}
