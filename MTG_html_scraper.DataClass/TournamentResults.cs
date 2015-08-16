using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_html_scraper.DataClass
{
    public class TournamentResults
    {
        public List<TournamentDeck> Decks { get; set; }
        public string TournamentInformation { get; set; }
        public bool IsMtgoResult { get; set; }
    }
}
