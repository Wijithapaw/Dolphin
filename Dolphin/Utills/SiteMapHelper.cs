using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dolphin.Utills
{
    public static class SiteMapHelper
    {
        public static void SetParentRouteValues(string paramName, string value)
        {
            var node = SiteMaps.Current.CurrentNode;
            if (node != null)
                SetNodeRouteValues(node.ParentNode, paramName, value);
        }

        public static void SetNodeRouteValues(ISiteMapNode node, string routeName, string value)
        {
            if (node != null)
                node.RouteValues[routeName] = value;
        }
    }
}