using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Labmark.Pages.Shared.Models
{
    public enum AlertType
    {
        warning,
        error,
        info
    }
    public class Alert
    {
        public Alert(AlertType type)
        {
            this.Type = type;
            switch (this.Type)
            {
                case AlertType.info: this.Title = "Sucesso!"; this.Icon = "success"; break;
                case AlertType.warning: this.Title = "Ops..\\nTem algo errado!"; this.Icon = "warning"; break;
                case AlertType.error: this.Title = "Ops..\\nTivemos um erro!"; this.Icon = "error"; break;
            }
        }
        public readonly AlertType Type;
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool ButtonOk { get; set; } = false;
        public bool ButtonCancel { get; set; } = false;
        public void ShowAlert(IHeaderDictionary headers)
        {
            headers.Add("alert", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this))));
        }
    }
}
