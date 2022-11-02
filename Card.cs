using System;

namespace Blackjack
{
    public class Card
    {

        public string Value { get; set; }
        public Card(string value)
        {
            Value = value;
        }

        public static int CardEvaluator(string value, Hand hand)
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
                "10" => 10,
                "jack" => 10,
                "queen" => 10,
                "king" => 10,
                "ace" => AceEvaluator(hand),
                _ => 0,
            };
        }

        public static int AceEvaluator(Hand hand)
        {
            if (hand.HandTotal >= 11)
            {
                return 1;
            }
            else
            {
                return 11;
            }
        }
    }
}
