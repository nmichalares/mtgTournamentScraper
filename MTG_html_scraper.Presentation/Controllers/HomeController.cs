using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTG_html_scraper.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IHtmlLoader _parserBl;

        public ActionResult Index()
        {
            _parserBl = new MagicOnlineTournamentParser();
            var url = "http://magic.wizards.com/en/articles/archive/mtgo-standings/standard-daily-2015-08-15";

            _parserBl.LoadTournamentResults(url);

            return View();
        }
    }
}