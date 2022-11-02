using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        //code
        //image
        //value
        public string Value { get; set; }
        public Card(string value)
        {
            Value = value;
        }

        public static int CardEvaluator(string value)
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
                "ace" => 11,
                _ => 0,
            };
        }
    }
}
