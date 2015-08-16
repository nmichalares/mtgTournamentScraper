using MTG_html_scraper.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_html_scraper
{
    public interface IHtmlLoader
    {
        TournamentResults LoadTournamentResults(string url);
    }
}
