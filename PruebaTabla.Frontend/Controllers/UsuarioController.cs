using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTabla.DataAcces;
using PruebaTabla.Frontend.Models;
using PruebaTabla.Models;
using SMS.Asignaciones.Frontend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTabla.Frontend.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly PruebaTablaDbContext _context;
        private readonly ViewRendererService _viewService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        //private IWebHostEnvironment Environment;

        public UsuarioController(PruebaTablaDbContext context, ViewRendererService viewService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _viewService = viewService;
            _webHostEnvironment = webHostEnvironment;
        }

        //public UsuarioController(IWebHostEnvironment _environment)
        //{
        //    Environment = _environment;
        //}

        public async Task<IActionResult> Index()
        {
            //string webRootPath = this.Environment.WebRootPath;
            //string contentRootPath = this.Environment.ContentRootPath;

            return View();
        }

        //PARCIAL VIEW USUARIO
        public async Task<ActionResult> _ViewAllUsuario()
        {
            var model = await _context.Usuarios.ToListAsync();
            return PartialView("_ViewAllUsuario", model);
        }


        //Crear o editar USUARIO

        public async Task<IActionResult> _CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                Usuario model = new Usuario() { Id = 0 };
                return View(model);
            }
            else
            {
                var model = await _context.Usuarios.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }

        [HttpPost, ActionName("AddOrEdit")]
        //ADD OR EDIT usuario
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Nombre,Nombre2,Edad,Edad2,FechaInscripcion,FechaInscripcion2,Email,Email2,Password,Password2,NumeroDecimal,NumeroDecimal2")] Usuario model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    await _context.AddAsync(model);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(model);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllUsuario", await _context.Usuarios.ToListAsync()) });
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "_CreateOrEdit", model) });
        }

        //DELETE USUARIO
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Usuarios.FindAsync(id);

            _context.Usuarios.Remove(model);
            await _context.SaveChangesAsync();

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllUsuario", await _context.Usuarios.ToListAsync()) });
        }
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }


        [ActionName("ExportarExcel")]
        public async Task<IActionResult> ExportarExcel()
        {
            var registros = await _context.Usuarios.ToListAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Usuarios");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Nombre";
                worksheet.Cell(currentRow, 2).Value = "Nombre2";
                worksheet.Cell(currentRow, 3).Value = "Edad";
                worksheet.Cell(currentRow, 4).Value = "Edad2";
                worksheet.Cell(currentRow, 5).Value = "FechaInscripcion";
                worksheet.Cell(currentRow, 6).Value = "FechaInscripcion2";
                worksheet.Cell(currentRow, 7).Value = "Email";
                worksheet.Cell(currentRow, 8).Value = "Email2";
                worksheet.Cell(currentRow, 9).Value = "Password";
                worksheet.Cell(currentRow, 10).Value = "Password2";
                worksheet.Cell(currentRow, 11).Value = "NumeroDecimal";
                worksheet.Cell(currentRow, 12).Value = "NumeroDecimal2";

                foreach (var r in registros)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = r.Nombre;
                    worksheet.Cell(currentRow, 2).Value = r.Nombre2;
                    worksheet.Cell(currentRow, 3).Value = r.Edad;
                    worksheet.Cell(currentRow, 4).Value = r.Edad2;
                    worksheet.Cell(currentRow, 5).Value = r.FechaInscripcion;
                    worksheet.Cell(currentRow, 6).Value = r.FechaInscripcion2;
                    worksheet.Cell(currentRow, 7).Value = r.Email;
                    worksheet.Cell(currentRow, 8).Value = r.Email2;
                    worksheet.Cell(currentRow, 9).Value = r.Password;
                    worksheet.Cell(currentRow, 10).Value = r.Password2;
                    worksheet.Cell(currentRow, 11).Value = r.NumeroDecimal;
                    worksheet.Cell(currentRow, 12).Value = r.NumeroDecimal2;
                }


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    var nombreArchivo = string.Concat("ExcelTablaUsuario ", DateTime.Now.ToString(), ".xlsx");

                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreArchivo);
                }
            }

        }


    }
}
