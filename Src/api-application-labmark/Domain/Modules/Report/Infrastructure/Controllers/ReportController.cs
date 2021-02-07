using Labmark.Domain.Modules.ReportSample.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Data;
using FastReport.Utils;
using FastReport.Export.Html;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos;
using FastReport.Web;
using FastReport.Data;
using Microsoft.Extensions.Configuration;
using FastReport.Export.PdfSimple;

namespace Labmark.Domain.Modules.ReportSample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ReportController : ControllerBase, IReportController
    {
        public IConfiguration Configuration { get; }

        private readonly IHostingEnvironment _hostingEnvironment;
        public ReportController(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPut]
        public IActionResult Generate([FromBody] ReportDto query)
        {
            string mime = "application/pdf"; //MIME-header with default value
            string webRootPath = _hostingEnvironment.WebRootPath; //Define the path to the wwwroot folder
            string reportPath = (webRootPath + "/Report.frx"); //Define the path to the report
            using (MemoryStream stream = new MemoryStream()) //Create the stream for the report
            {
                try
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
                        WebReport webReport = new WebReport();
                        
                        MsSqlDataConnection sqlConnection = new MsSqlDataConnection();
                        sqlConnection.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                        sqlConnection.CreateAllTables();
                        webReport.Report.Dictionary.Connections.Add(sqlConnection);
                        
                        
                        webReport.Report.Load(reportPath);
                        webReport.Report.SetParameterValue("AmostraId", query.AmostraId);
                        for (int i = 0; i < query.Ensaios.Length; i++)
                        {
                            webReport.Report.SetParameterValue($"EnsaioSelecionados{i+1}", query.Ensaios[i]);
                        }
                        webReport.Report.Prepare();
                        PDFSimpleExport pdfExport = new PDFSimpleExport();
                        pdfExport.Export(webReport.Report, stream);
                    }
                    //Get the name of resulting report file with needed extension
                    var file = String.Concat($"Laudo-{DateTime.Now}", ".", "pdf");
                    return File(stream.ToArray(), mime, file); // attachment
                }
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
