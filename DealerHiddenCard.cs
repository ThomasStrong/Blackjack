using System;

namespace Blackjack
{
    class DealerHiddenCard : Card
    {
        public DealerHiddenCard(string value) : base(value)
        {
           Value = value;
        }

        public static void ReplaceDealerHiddenCard(Hand hand)
        {
            hand.Cards.RemoveAt(0);
            hand.AddToHand(APICall.DrawCard());
            hand.GetHandTotal(hand);
        }
    }
}
