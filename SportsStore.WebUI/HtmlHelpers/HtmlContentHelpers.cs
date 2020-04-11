using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class HtmlContentHelpers
    {
        public static String ConvertToString(this IHtmlContent content) {

            string result = null;
            using (var writer = new StringWriter()) {
                content.WriteTo(writer, HtmlEncoder.Default);
                result = writer.ToString();
            }
            return result;
        }
    }
}
