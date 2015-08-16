using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_html_scraper.DataClass
{
    public class TournamentDeck
    {
        public List<DeckItem> CardsInDeck {get;set;}
        public string Pilot { get; set; }
        public string Record { get; set; }
    }
}
