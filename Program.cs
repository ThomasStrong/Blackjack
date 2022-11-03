﻿using Spectre.Console;
using System;
using System.Threading;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "_Blackjack";

            LoopExit exit = new();
            exit.ToExit = false;

            const int win = 21;

            while (!exit.ToExit)
            {
                Console.Clear();
                TitleScreen.Title();

                Hand playerHand = new();
                Hand dealerHand = new();

                string toPlay = TitleScreen.TitleMenu().ToLower();
                if (toPlay == "exit")
                {
                    exit.ToExit = true;
                }

                if (!exit.ToExit)
                {
                    Console.Clear();
                    Hand.InitiateHands(playerHand,dealerHand);
                    DisplayTable.DisplayGameTable(playerHand, dealerHand);
                }

                // *****Player Turn Loop*****
                LoopExit stay = new();
                stay.ToExit = false;
                if (exit.ToExit)
                {
                    stay.ToExit = true;
                }
                if (playerHand.HandTotal == win)
                {
                    AnsiConsole.Markup("[green]Blackjack! You win!!![/]\n");
                    stay.ToExit = true;
                }
                while (playerHand.HandTotal <= win && !stay.ToExit)
                {
                    while (!stay.ToExit)
                    {
                        if (playerHand.HandTotal == win)
                        {
                            stay.ToExit = true;
                            Console.Beep();
                            AnsiConsole.Markup("[green]21![/] Let's see what the dealer does...\n");                            
                            AnsiConsole.Markup($"Press Enter to begin again.");
                            Console.ReadLine();
                        }
                        else if (playerHand.HandTotal > win)
                        {
                            stay.ToExit = true;
                            AnsiConsole.Markup("[red]Bust! You lose.[/]\n");
                            AnsiConsole.Markup($"Press Enter to begin again.");
                            Console.ReadLine();
                        }
                        else if (playerHand.HandTotal < win && !stay.ToExit)
                        {
                            Hand.HitStayMenu(playerHand, stay, exit);
                            DisplayTable.DisplayGameTable(playerHand, dealerHand);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }

                // *****Dealer Turn Loop*****
                int dealerHit = 16;
                int dealerStay = 17;
                LoopExit dealerExit = new();
                dealerExit.ToExit = false;

                if (!exit.ToExit)
                {
                    DealerHiddenCard.ReplaceDealerHiddenCard(dealerHand);
                }

                if (playerHand.HandTotal > win || dealerHand.HandTotal > win || exit.ToExit)
                {
                    dealerExit.ToExit = true;
                }

                while (!dealerExit.ToExit)
                {
                    DisplayTable.DisplayGameTable(playerHand, dealerHand);
                    Thread.Sleep(500);

                    if (dealerHand.HandTotal < win)
                    {
                        if (dealerHand.HandTotal <= dealerHit)
                        {
                            dealerHand.AddToHand(APICall.DrawCard());
                            dealerHand.GetHandTotal(dealerHand);
                        }
                        else if (dealerHand.HandTotal >= dealerStay)
                        {
                            dealerExit.ToExit = true;
                            AnsiConsole.Markup($"The Dealer stays with {dealerHand.HandTotal}.\n");
                        }
                        else
                        {
                            dealerExit.ToExit = true;
                        }
                    }
                    else if (dealerHand.HandTotal == win)
                    {
                        AnsiConsole.Markup($"The Dealer has Blackjack!\n");
                        dealerExit.ToExit = true;
                    }
                    else
                    {
                        AnsiConsole.Markup($"The Dealer busted!  [green]You Win!![/]\n");
                        dealerExit.ToExit = true;
                    }
                }
                
                // Win conditions if Player does not have Blackjack
                if (!exit.ToExit)
                {
                    Hand.CompareHands(playerHand, dealerHand);
                }
            }
        }
    }
}
