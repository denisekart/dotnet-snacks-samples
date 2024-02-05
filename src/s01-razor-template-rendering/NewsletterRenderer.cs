using ConsoleRazorRenderer.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

public class NewsletterRenderer(HtmlRenderer renderer)
{
    public async Task<string> RenderHtml(NewsletterComponent.NewsletterDto content)
    {
        var result = await renderer.Dispatcher.InvokeAsync(async () =>
        {
            var parameters = ParameterView.FromDictionary(new Dictionary<string, object?>
            {
                { "Content", content }
            });
            var output = await renderer.RenderComponentAsync<NewsletterComponent>(parameters);

            return output.ToHtmlString();
        });

        return result;
    }
}
