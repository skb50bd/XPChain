using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Core.TagHelpers {
    public class Email : TagHelper
    {
        public override async Task ProcessAsync(
            TagHelperContext context,
            TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            var mailto = $"mailto:{content.GetContent()}";
            output.TagName = "a";
            output.Attributes.Add("href", mailto);
        }
    }

    public class Tel : TagHelper
    {
        public override async Task ProcessAsync(
            TagHelperContext context,
            TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            var call = $"tel:{content.GetContent()}";
            output.TagName = "a";
            output.Attributes.Add("href", call);
        }
    }

    public class Url : TagHelper
    {
        public override async Task ProcessAsync(
            TagHelperContext context,
            TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            var link = content.GetContent();
            output.TagName = "a";
            output.Attributes.Add("href", link);
        }
    }
}