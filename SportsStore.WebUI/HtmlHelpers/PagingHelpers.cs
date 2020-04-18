using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SportsStore.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using System.Security.Cryptography.Xml;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this IHtmlHelper htmlHelper, PagingInfo pagingInfo, Func<int, string> pageUrl) {
            StringBuilder result = new StringBuilder();
            for (int i=1; i <= pagingInfo.TotalPages; i++) {
                TagBuilder tag = new TagBuilder("a");
                string returnValue = pageUrl(i);
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.Append(i.ToString());
                if (i == pagingInfo.CurrentPage) {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                string stringTag = tag.ConvertToString();
                result.Append(stringTag);
            }
            return new HtmlString(result.ToString());
        }
    }
}
