using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Hand
    {
        public List<Card> Cards { get; set; }

        public void AddToHand(Card card, Hand hand)
        {
            // take in the card from APICall.DrawCard

            // Card card = new card(DrawCard());

            // *** When get here:
            // ***      System.NullReferenceException: 'Object reference not set to an instance of an object.'
            //
            //          Blackjack.Hand.Cards.get returned null.
            
            hand.Cards.Add(card);            
        }
        
    }
}
