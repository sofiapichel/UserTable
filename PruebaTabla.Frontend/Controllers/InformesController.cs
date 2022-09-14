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



    public class InformesController : Controller
    {

        private readonly PruebaTablaDbContext _context;
        private readonly ViewRendererService _viewService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InformesController(PruebaTablaDbContext context, ViewRendererService viewService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _viewService = viewService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<FileResult> InformeUsuarios()
        {

            var model = await _context.Usuarios.ToListAsync();
            var templatePath = "~/Views/Usuario/_ViewAllUsuario.cshtml";
            var htmlinner = await _viewService.RenderViewToStringAsync(ControllerContext, templatePath, model);

            string html = @"<?xml version=""1.0"" encoding=""UTF-8""?>" + htmlinner;


            return CreatePDF(html, "TablaUsuarios.pdf");
        }

        public FileResult CreatePDF(string html, string nombrePDF)
        {
            MemoryStream ms = new MemoryStream();
            StringReader txtReader = new StringReader(html);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter pdfwriter = PdfWriter.GetInstance(document, ms);

            document.Open();

            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";

            path = Path.Combine(webRootPath, "css");
            var elCss = Path.Combine(path, "site.css");


            using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(elCss)))
            {
                using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(pdfwriter, document, htmlMemoryStream, cssMemoryStream);
                }
            }


            document.Close();

            return File(ms.ToArray(), "application/pdf", nombrePDF);
        }

    }
}
