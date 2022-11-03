using Spectre.Console;
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

        public static void HitStayMenu(Hand hand, LoopExit stay, LoopExit exit)
        {
            switch (PlayerMenu().ToLower())
            {
                case "hit":
                    hand.AddToHand(APICall.DrawCard());
                    hand.GetHandTotal(hand);
                    break;
                case "stay":
                    stay.ToExit = true;
                    break;
                case "exit":
                    stay.ToExit = true;
                    exit.ToExit = true;
                    break;
                default:
                    break;
            }
        }

        public static void InitiateHands(Hand playerHand, Hand dealerHand)
        {
            dealerHand.AddToHand(new DealerHiddenCard("X"));
            playerHand.AddToHand(APICall.DrawCard());
            dealerHand.AddToHand(APICall.DrawCard());
            playerHand.AddToHand(APICall.DrawCard());

            playerHand.GetHandTotal(playerHand);
            dealerHand.GetHandTotal(dealerHand);
        }

        public static void CompareHands(Hand playerHand, Hand dealerHand)
        {
            int win = 21;

            if (playerHand.HandTotal < win && dealerHand.HandTotal < win)
            {
                if (playerHand.HandTotal > dealerHand.HandTotal)
                {
                    AnsiConsole.Markup($"[green]You Win!![/]\n");
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
                else if (dealerHand.HandTotal > playerHand.HandTotal)
                {
                    AnsiConsole.Markup($"[red]You Lose...[/]\n");
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
                else
                {
                    AnsiConsole.Markup($"TIE\n");
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
            }
            else if (dealerHand.HandTotal == win)
            {
                AnsiConsole.Markup($"[red]You Lose...[/]\n");
                AnsiConsole.Markup($"Press Enter to begin again.");
                Console.ReadLine();
            }
            else if (dealerHand.HandTotal == win && playerHand.HandTotal == win)
            {
                AnsiConsole.Markup($"[red]You TIE with Blackjack![/]\n");
                AnsiConsole.Markup($"Press Enter to begin again.");
                Console.ReadLine();
            }
            else if (dealerHand.HandTotal > win)
            {
                AnsiConsole.Markup($"Press Enter to begin again.");
                Console.ReadLine();
            }
        }
    }
}
