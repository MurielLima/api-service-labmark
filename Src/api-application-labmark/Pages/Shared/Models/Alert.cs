using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Labmark.Pages.Shared.Models
{
    public enum AlertType
    {
        warning,
        error,
        success
    }
    public class Alert
    {
        public Alert(AlertType type)
        {
            Type = type;
            switch (Type)
            {
                case AlertType.success: Title = "Sucesso!"; Icon = "success"; break;
                case AlertType.warning: Title = "Ops..\\nTem algo errado!"; Icon = "warning"; break;
                case AlertType.error: Title = "Ops..\\nTivemos um erro!"; Icon = "error"; break;
            }
        }
        public readonly AlertType Type;
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool ButtonOk { get; set; } = false;
        public bool ButtonCancel { get; set; } = false;
        public void ShowAlert(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add("alert", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this))));
        }
    }
}
