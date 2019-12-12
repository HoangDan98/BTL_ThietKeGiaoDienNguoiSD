﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBanMayTinh.Models.AdminViewModels;

namespace WebBanMayTinh.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString CreatePageLinks(this HtmlHelper htmlHelper, PagingInfo pageInfo, Func<int, string> urlCreator)
        {
            StringBuilder stringResult = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPage; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", urlCreator(i));
                a.InnerHtml = i.ToString();
                if (i == pageInfo.CurrentPage)
                {
                    a.AddCssClass("btn btn-primary");
                    a.AddCssClass("selected");
                }
                a.AddCssClass("btn btn-default");
                stringResult.Append(a.ToString());
            }
            return MvcHtmlString.Create(stringResult.ToString());
        }
    }
}