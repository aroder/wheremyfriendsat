using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace WhereMyFriendsAt.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static void Repeater<T>(this HtmlHelper html
          , IEnumerable<T> items
          , string className
          , string classNameAlt
          , Action<T, string> render)
        {
            if (items == null)
                return;

            int i = 0;
            items.ForEach(item =>
            {
                render(item, (i++ % 2 == 0) ? className : classNameAlt);
            });
        }

        public static void Repeater<T>(this HtmlHelper html
          , string viewDataKey
          , string cssClass
          , string altCssClass
          , Action<T, string> render)
        {
            var items = GetViewDataAsEnumerable<T>(html, viewDataKey);

            int i = 0;
            items.ForEach(item =>
            {
                render(item, (i++ % 2 == 0) ? cssClass : altCssClass);
            });
        }

        static IEnumerable<T> GetViewDataAsEnumerable<T>(HtmlHelper html, string viewDataKey)
        {
            var items = html.ViewContext.ViewData as IEnumerable<T>;
            var viewData = html.ViewContext.ViewData as IDictionary<string, object>;
            if (viewData != null)
            {
                items = viewData[viewDataKey] as IEnumerable<T>;
            }
            else
            {
                items = new ViewDataDictionary(viewData)[viewDataKey]
                  as IEnumerable<T>;
            }
            return items;
        }
    }
}
