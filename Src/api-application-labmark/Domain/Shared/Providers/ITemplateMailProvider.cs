namespace Labmark.Domain.Shared.Providers
{
    public interface ITemplateMailProvider
    {
        public string GetTemplateHtml(string templateName);
    }
}
