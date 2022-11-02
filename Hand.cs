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
            
            switch (value.ToLower())
            {
                case "2":
                    return 2;
                    
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "0":
                    return 10;
                case "jack":
                    return 10;
                case "queen":
                    return 10;
                case "king":
                    return 10;
                case "ace":
                    return 11;
                default:
                    return 0;
            }
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
