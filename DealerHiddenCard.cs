using System;

namespace Blackjack
{
    class DealerHiddenCard : Card
    {
        public DealerHiddenCard(string value) : base(value)
        {
           Value = value;
        }
    }
}
