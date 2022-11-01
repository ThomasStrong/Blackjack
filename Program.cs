using System;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "   Blackjack   ";

            LoopExit exit = new();
            exit.ToExit = false;

            while (!exit.ToExit)
            {
                TitleScreen.Title();
                
                // At this time this serves to keep title from infinite loop
                string line = Console.ReadLine().ToLower();
                if (line == "exit")
                {
                    exit.ToExit = true;
                }
            }


            //1)	Run File
            //  Title Screen: Blackjack!  Play / Exit
            //
            //  Initialize Deck(API call)
            //
            //    
            //  Initiate Player hand and dealer hand(one card face down/ hidden)
            //       -dealerhand has list of cards
            //          -cards constructed from api call, evaluated and given int value as new Card()
            //        	    -Total = X; this given for each player and keeps running total.For dealer this total will show but will only include the value of the face - up card.
            //  Player Turn:  Choose Hit, Stay ***`Loop while total < 21`***
            //        -	HIT – draw a card(API), add to the player hand and this will be added to total
            //            - Player choice again
            //        - STAY – end player turn, begin dealer turn
            //
            //  Dealer Turn: Use house rules on hand total to decide dealer choice ***`Loop while total < 21`***
            //        Dealer can ONLY hit/ stay 
            //
            //  End Dealer Turn / Compare Hand Scores
            //
            //  Win Condition and Message
            //       - “You win!”, “Draw”, “You lost!”

        }
    }
}
