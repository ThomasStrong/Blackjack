using Newtonsoft.Json;
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
                string toPlay = TitleScreen.TitleMenu().ToLower();
                if (toPlay == "exit")
                {
                    exit.ToExit = true;
                }

                Console.Clear();

                Hand playerHand = new();
                Console.WriteLine(playerHand);
                playerHand.AddToHand(APICall.DrawCard(), playerHand);
                Console.WriteLine(playerHand);


                // init deck (api call) https://www.deckofcardsapi.com/api/deck/new/shuffle/?deck_count=6 , read string deck_id and set variable to use for card draws
                // init hands by constructing the first 2 cards https://www.deckofcardsapi.com/api/deck/<<deck_id>>/draw/?count=1
                // Hand playerHand = new Hand(); Hand dealerHand = new Hand();
                //  -init cards with ctor
                //   + one card to player
                //   + one card to dealer
                //   + one card to player
                //   + one card to dealer & show blank? || blank card & draw 2nd at begin of dealer turn?
                //      *(image at https://deckofcardsapi.com/static/img/back.png)
                //
                // begin player loop
                //  -init LoopExit playerStay = new();
                //  -while loop: total >= 21 playerStay = true;
                //  -exit message: "win/bust/tie"
            }
            


            // *****Pseudcode Outline*****
            //
            //1)	Run File
            //  Title Screen: Blackjack!  Play / Exit
            //
            //  Initialize Deck(API call)
            //
            //    
            //  Initiate Player hand and dealer hand(one card face down/ hidden)
            //       -hand has list of cards
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
