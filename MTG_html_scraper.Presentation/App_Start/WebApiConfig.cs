using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MTG_html_scraper.Presentation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}
