using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Shared.Providers
{
    public interface ITemplateMailProvider
    {
        public string GetTemplateHtml(string templateName);
    }
}
