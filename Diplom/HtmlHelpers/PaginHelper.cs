using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Diplom.HtmlHelpers
{
    public static class PaginHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i=1; i<= pagingInfo.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if(i== pagingInfo.CurrentPage)
                {
                    li.AddCssClass("page-item disabled");
                    tag.AddCssClass("page-link active rounded-0 mr-3 shadow-sm border-top-0 border-left-0");
                    
                }
                li.AddCssClass("page-item");
                tag.AddCssClass("page-link rounded-0 mr-3 shadow-sm border-top-0 border-left-0 text-dark");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}