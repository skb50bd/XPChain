using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    namespace Web
    {
        public class EmailTagHelper : TagHelper
        {
            public override async Task ProcessAsync(
                TagHelperContext context,
                TagHelperOutput  output)
            {
                var content = await output.GetChildContentAsync();
                var mailto  = $"mailto:{content.GetContent()}";
                output.TagName = "a";
                output.Attributes.Add("href", mailto);
            }
        }

        public class TelTagHelper : TagHelper
        {
            public override async Task ProcessAsync(
                TagHelperContext context,
                TagHelperOutput  output)
            {
                var content = await output.GetChildContentAsync();
                var call    = $"tel:{content.GetContent()}";
                output.TagName = "a";
                output.Attributes.Add("href", call);
            }
        }

        public class UrlTagHelper : TagHelper
        {
            public override async Task ProcessAsync(
                TagHelperContext context,
                TagHelperOutput  output)
            {
                var content = await output.GetChildContentAsync();
                var link    = content.GetContent();
                output.TagName = "a";
                output.Attributes.Add("href", link);
            }
        }
    }
}
