using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTG_html_scraper.DataClass;

namespace MTG_html_scraper
{
    public class MagicOnlineTournamentParser : IHtmlLoader
    {
        public TournamentResults LoadTournamentResults(string url)
        {
            var doc = new HtmlWeb().Load(url);

            if (doc.DocumentNode != null)
            {
                var decksObj = doc.DocumentNode.SelectSingleNode("//div[@class='decklists']");
                var tourneyData = new TournamentResults { Decks = new List<TournamentDeck>(), IsMtgoResult = true };

                foreach(var singleDeck in decksObj.ChildNodes)
                {
                    var playerObj = singleDeck.SelectSingleNode(".//span[@class='deck-meta']/h4");
                    var tournamentObj = singleDeck.SelectSingleNode(".//span[@class='deck-meta']/h5");
                    var mainDeckObj = singleDeck.SelectSingleNode(".//div[@class='deck-list-text']").ChildNodes[1];
                    var sideDeckObj = singleDeck.SelectSingleNode(".//div[@class='deck-list-text']").ChildNodes[3];

                    if (string.IsNullOrEmpty(tourneyData.TournamentInformation))
                    {
                        tourneyData.TournamentInformation = tournamentObj.InnerText.Trim();
                    }

                    var deck = new TournamentDeck { CardsInDeck = new List<DeckItem>() };
                    deck.Pilot = playerObj.InnerText.Substring(0, playerObj.InnerText.IndexOf('(')).Trim();
                    deck.Record = playerObj.InnerText.Substring(playerObj.InnerText.IndexOf('(')).Replace("(", "").Replace(")", "");
                    foreach(var mainDeckCardListing in mainDeckObj.SelectNodes(".//span[@class='row']"))
                    {
                        deck.CardsInDeck.Add(ParseCards(mainDeckCardListing, true));
                    }

                    foreach(var sideDeckCardListing in sideDeckObj.SelectNodes(".//span[@class='row']"))
                    {
                        deck.CardsInDeck.Add(ParseCards(sideDeckCardListing, false));
                    }

                    tourneyData.Decks.Add(deck);
                }

                return tourneyData;
            }

            return null;
        }

        private DeckItem ParseCards(HtmlNode cardListing, bool isMainDeck) 
        {
            var cardNameObj = cardListing.SelectSingleNode("span[@class='card-name']/a");
            if (cardNameObj == null)
            {
                //Sometimes cards exist without an anchor around them
                cardNameObj = cardListing.SelectSingleNode("span[@class='card-name']");
            }

            return new DeckItem
            {
                IsMainDeck = isMainDeck,
                CardName = cardNameObj.InnerText.Trim(),
                Quantity = cardListing.SelectSingleNode("span[@class='card-count']").InnerText.Trim()
            };
        }
    }
}
