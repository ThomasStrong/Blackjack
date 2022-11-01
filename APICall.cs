using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class APICall
    {
        public static string initiateDeckUrl = "https://www.deckofcardsapi.com/api/deck/new/shuffle/?deck_count=6";
        private static WebClient webClient = new WebClient();

        private static byte[] WebRequest(string url)
        {
            var data = new byte[] { };
            try
            {
                data = webClient.DownloadData(url);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem with web request!");
            }
            return data;
        }

        public static string ReturnWebRequest(string url)
        {
            byte[] data = WebRequest(url);
            using var stream = new MemoryStream(data);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static string BuildURL(string deckID)
        {
            return ($"https://www.deckofcardsapi.com/api/deck/{deckID}/draw/?count=1");
        }

        public static string InitializeDeck()
        {
            string newDeck = ReturnWebRequest(initiateDeckUrl);
            dynamic json = JsonConvert.DeserializeObject(newDeck);
            string deckID = json.deck_id;
            return deckID;
        }

    }
}
