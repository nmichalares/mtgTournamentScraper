using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTG_html_scraper;
using MTG_html_scraper.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_html_scraper.Tests
{
    [TestClass()]
    public class MagicOnlineTournamentParserTests
    {
        public IHtmlLoader _magicOnlineParser;
        private TournamentResults _resultSet;

        [TestMethod()]
        public void MtgoDataIsParsedCorrectly()
        {
            _magicOnlineParser = new MagicOnlineTournamentParser();
            //This is a live test, the handler relies on this data being accurate.  If the site changes format, the parser will no longer work.
            //All Tests combined so they'll run quicker, since we need to go out and get data from WOTC to run the tests.
            var url = "http://magic.wizards.com/en/articles/archive/mtgo-standings/standard-daily-2015-08-15";

            _resultSet = _magicOnlineParser.LoadTournamentResults(url);

            //Pilots
            Assert.AreEqual("sans", _resultSet.Decks[0].Pilot);
            Assert.AreEqual("giorno211", _resultSet.Decks[10].Pilot);

            //Results

            //Decks

            //Tournament Information
        }
    }
}