using Labmark.Domain.Modules.ReportSample.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Data;
using FastReport.Utils;
using FastReport;
using FastReport.Export.Html;
using FastReport.Export.Image;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.ReportSample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ReportController : ControllerBase, IReportController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ReportController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromQuery] ReportDto query)
        {
            string mime = "application/" + query.Format; //MIME-header with default value
            string webRootPath = _hostingEnvironment.WebRootPath; //Define the path to the wwwroot folder
            string reportPath = (webRootPath + "\\Report.frx"); //Define the path to the report
            string dataPath = (webRootPath + "/App_Data/nwind.xml");//Define the path to the data base
            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        //Fill the source with data
                        //Enable FastReport web mode
                        Config.WebMode = true;
                        using (Report report = new Report())
                        {
                            report.Load(reportPath); //Load the report

                            report.Prepare();//Prepare the report
                                             //if the selected format is png

                            if (query.Format == "png")
                            {
                                ImageExport img = new ImageExport();
                                img.ImageFormat = ImageExportFormat.Png;
                                img.SeparateFiles = false;
                                img.ResolutionX = 96;
                                img.ResolutionY = 96;
                                report.Export(img, stream);
                                mime = "image/" + query.Format; //redefine mime for png

                            }
                            //if the report format is html

                            else if (query.Format == "html")
                            {
                                //report export to HTML
                                HTMLExport html = new HTMLExport();
                                html.SinglePage = true; //report on the one page
                                html.Navigator = false; //navigation panel on top
                                html.EmbedPictures = true; //build in images to the document
                                report.Export(html, stream);
                                mime = "text/" + query.Format; //redefine mime for html
                            }
                        }
                    }
                    //Get the name of resulting report file with needed extension
                    var file = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", query.Format);
                    //if the inline parameter is true, open in browser
                    if (query.Inline)
                        return File(stream.ToArray(), mime);
                    else
                        //otherwise download report file
                        return File(stream.ToArray(), mime, file); // attachment
                }
                //Edit exceptions
                catch
                {
                    return new NoContentResult();
                }
                finally
                {
                    stream.Dispose();
                }
            }
        }
    }
}
