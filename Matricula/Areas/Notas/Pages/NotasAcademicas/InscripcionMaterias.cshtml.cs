using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Notas.Data;
using Matricula.Areas.Notas.Models;
using Matricula.Controllers;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Matricula.Areas.Mantenimiento.Models;

namespace Matricula.Areas.Notas.Pages.NotasAcademicas
{
    public class InscripcionMateriasModel : PageModel
    {
        public static InputModelNotasProfesor _dataInput;
        ActionsBDNotas action = new ActionsBDNotas();
        private static NotasProfesorM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Notas = _dataInput;
            }
            else
            {
                Input_Notas = new InputModelNotasProfesor();
            }

            if (_dataUser1 != null)
            {
                Input_Notas = new InputModelNotasProfesor
                {
                    profesor = _dataUser1.profesor,
                    listaMateriasxCarrera = _dataUser1.listaMateriasxCarrera,
                    lista_MateriasInscriptas = _dataUser1.lista_MateriasInscriptas
                };
            }
        }

        [BindProperty]
        public InputModelNotasProfesor Input_Notas { get; set; }

        public class InputModelNotasProfesor : NotasProfesorM
        {
        }

        public IActionResult OnPost(string dataInscripcion)
        {
            if (dataInscripcion == null)
            {
                if (registrandoInscripcion() == 0)
                {
                    if (LUser.usuario == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    else
                    {
                        return generarBoletaInscripcion();
                        //return Redirect("/Principal/Principal?area=Principal"); ;
                    }
                }
                else
                {
                    return Redirect("/Notas/InscripcionMaterias");
                }
            }
            else
            {
                _dataUser1 = JsonConvert.DeserializeObject<NotasProfesorM>(dataInscripcion);
                return Redirect("/Notas/InscripcionMaterias");
            }
        }

        public int registrandoInscripcion()
        {
            _dataInput = Input_Notas;
            _dataInput.lista_MateriasInscriptas = _dataUser1.lista_MateriasInscriptas;

            int dato = 1;

            int estado = Int32.Parse(action.registrarInscripcion(_dataInput));
            if (estado == 0)
            {
                dato = 0;
            }
            else
            {
                dato = 1;
            }

            return dato;
        }

        public IActionResult generarBoletaInscripcion()
        {
            int contador = 180;
            string nombreC = _dataUser1.profesor.PrimerApellido + " " + _dataUser1.profesor.SegundoApellido + " " + _dataUser1.profesor.Nombre;
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
            graphics.DrawString("Boleta de Inscripcion de Materias", font, PdfBrushes.Black, new PointF(0, 0));
            graphics.DrawString("\n", font, PdfBrushes.Black, new PointF(0, 20));
            graphics.DrawString("Identificacion profesor: " + _dataUser1.profesor.Identificacion, font2, PdfBrushes.Black, new PointF(0, 40));
            graphics.DrawString("Nombre profesor: " + nombreC, font2, PdfBrushes.Black, new PointF(0, 60));
            graphics.DrawString("Correo Electronico: " + _dataUser1.profesor.CorreoElectronico, font2, PdfBrushes.Black, new PointF(0, 80));
            graphics.DrawString("Carrera: " + _dataUser1.profesor.Carrera, font2, PdfBrushes.Black, new PointF(0, 100));
            graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString(), font2, PdfBrushes.Black, new PointF(0, 120));
            graphics.DrawString("\n", font2, PdfBrushes.Black, new PointF(0, 140));

            graphics.DrawString("Materias Inscriptas", font2, PdfBrushes.Black, new PointF(0, 160));

            foreach (MateriasM materia in _dataInput.lista_MateriasInscriptas)
            {
                graphics.DrawString("|Codigo Materia: " + materia.Codigo_Materia + "\t|Nombre Materia: " + materia.Nombre + "\t|Horario: " + materia.NombreHorario, font2, PdfBrushes.Black, new PointF(0, contador));
                contador += 20;
            }


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
