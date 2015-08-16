using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_html_scraper.DataClass
{
    public class DeckItem
    {
        public string CardName { get; set; }
        public string Quantity { get; set; }
        public bool IsMainDeck { get; set; }
    }
}
