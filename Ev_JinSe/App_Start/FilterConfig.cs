﻿using System.Web;
using System.Web.Mvc;

namespace Ev_JinSe
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}