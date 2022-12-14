using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;


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

        public static Card DrawCard()
        {
            // drawing a card from the deck that is initialized 
            string newCard = ReturnWebRequest(BuildURL(InitializeDeck()));
            dynamic cardJSON = JsonConvert.DeserializeObject(newCard);

            if (cardJSON.success == "true")
            {
                // This works and is test for getting the deck ID and card value
                // Console.WriteLine($"The API Call was successfull and the deck is: {cardJSON.deck_id}");
                // Console.WriteLine($"The info for the card: {cardJSON.cards[0].value}");
                // Console.ReadLine();

                string cardValue = cardJSON.cards[0].value;
                Card card = new(cardValue);
                return card;


            } else
            {
                throw new NotImplementedException();
            }
        }
    }
}
