using MTG_html_scraper.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace MTG_html_scraper.Presentation.Controllers.API
{
    public class MTGOController : ApiController
    {
        public IHtmlLoader _parserBl;
        
        [HttpGet]
        [Route("api/MTGO/Standard/{startDate}/{numberOfDays}")]
        public List<TournamentResults> Standard(string startDate, int numberOfDays)
        {
            _parserBl = new MagicOnlineTournamentParser();

            var tournaments = new List<TournamentResults>();
            var urlBaseString = "http://magic.wizards.com/en/articles/archive/mtgo-standings/standard-daily-";
            var actualStartDate = DateTime.Parse(startDate);

            for (var x = 0; x < numberOfDays; x++)
            {
                try
                {
                    var newDate = actualStartDate.AddDays(x);
                    var url = urlBaseString + newDate.Year + "-" + newDate.Month.ToString("d2") + "-" + newDate.Day.ToString("00");
                    tournaments.Add(_parserBl.LoadTournamentResults(url));
                }
                catch
                {
                    //Tournament page doesn't exist
                }
                
            }

            return tournaments;
        }
    }
}
