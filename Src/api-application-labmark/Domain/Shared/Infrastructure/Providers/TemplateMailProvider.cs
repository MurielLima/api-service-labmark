using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Shared.Providers;

namespace Labmark.Domain.Shared.Infrastructure.Providers
{
    public class TemplateMailProvider : ITemplateMailProvider
    {
        public string GetTemplateHtml(string templateName)
        {
            var path = Environment.CurrentDirectory + "/Domain/Modules/Account/Infrastructure/Templates/"+templateName+".html";
            return System.IO.File.ReadAllText(path);
        }
    }
}
