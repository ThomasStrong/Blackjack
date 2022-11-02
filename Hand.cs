using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
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
        
        public int GetHandTotal(Hand hand)
        {
            int handTotal = 0;
            foreach (Card card in Cards)
            {
                int convertedValue = Card.CardEvaluator(card.Value, hand);
                handTotal += convertedValue;
            }
            HandTotal = handTotal;
            return HandTotal;
        }

        public static string PlayerMenu()
        {
            string optionsTitle = "Would you like to [green]Hit[/] / [green]Stay[/]?";
            string[] titleOptions = {
                            "Hit", "Stay", "Exit"
                        };
            return UserMenu.Menu(optionsTitle, titleOptions.Length, titleOptions);

        }
    }
}
