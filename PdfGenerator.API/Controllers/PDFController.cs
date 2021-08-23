using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfGenerator.API.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PdfGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly IConverter _converter;

        public PDFController(IConverter converter)
        {
            this._converter = converter;
        }

        public IActionResult CreatePDF()
        {
            var globerSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
                #region If i dont want the pdf on my directory
                // Out = @"C:\PDFCreator\Exam_Question.pdf" 
                #endregion
            };

            var objecSettings = new ObjectSettings
            {
                PagesCount = true,
                //HtmlContent = TemplateGenerator.GetHTMLString(),
                Page = @"C:/Users/mohammed.shelle/Desktop/ENTRANCEEXAMS/index.html",
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "StyleSheet.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page[page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = globerSettings,
                Objects = { objecSettings }
            };
            #region If i dont want the pdf on my directory
            //_converter.Convert(pdf);

            //return Ok("Successfully created the PDF document"); 
            #endregion

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", "ENTRANCEEXAMS.pdf");
            //then the pdf is open in a browser
        }
    }
}
