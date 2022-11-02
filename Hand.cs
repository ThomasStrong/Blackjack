using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Hand
    {
        public int HandTotal = 0;

        public List<Card> Cards = new();

        public void AddToHand(Card card)
        {
            // take in the card from APICall.DrawCard

            // Card card = new card(DrawCard());

            // *** When get here:
            // ***      System.NullReferenceException: 'Object reference not set to an instance of an object.'
            //
            //          Blackjack.Hand.Cards.get returned null.
            
            Cards.Add(card);            
        }

        private static int CardEvaluator(string value)
        {

            return value.ToLower() switch
            {
                "2" => 2,
                "3" => 3,
                "4" => 4,
                "5" => 5,
                "6" => 6,
                "7" => 7,
                "8" => 8,
                "9" => 9,
                "0" => 10,
                "jack" => 10,
                "queen" => 10,
                "king" => 10,
                "ace" => 11,
                _ => 0,
            };
        }
        
        public int GetHandTotal()
        {
            int handTotal = 0;
            foreach (Card card in Cards)
            {
                int convertedValue = CardEvaluator(card.Value);
                handTotal += convertedValue;
            }
            return handTotal;
        }
    }
}
