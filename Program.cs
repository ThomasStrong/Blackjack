﻿using Newtonsoft.Json;
using Spectre.Console;
using System;
using System.Threading;

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
                Console.Clear();
                TitleScreen.Title();
                string toPlay = TitleScreen.TitleMenu().ToLower();
                if (toPlay == "exit")
                {
                    exit.ToExit = true;
                }
                Console.Clear();

                Hand playerHand = new();
                Hand dealerHand = new();

                if (!exit.ToExit)
                {
                    playerHand.AddToHand(APICall.DrawCard());
                    dealerHand.AddToHand(APICall.DrawCard());
                    playerHand.AddToHand(APICall.DrawCard());

                    playerHand.GetHandTotal();
                    dealerHand.GetHandTotal();

                    // override this with display method dealerHiddenDisplayTable()
                    DisplayTable.DealerHiddenDisplayTable(playerHand, dealerHand);
                }

                //Player Turn Loop
                LoopExit stay = new();
                stay.ToExit = false;
                while (playerHand.HandTotal < 21 && !stay.ToExit)
                {

                    while (!stay.ToExit)
                    {
                        if (playerHand.HandTotal == 21)
                        {
                            AnsiConsole.Markup("[green]BLACKJACK! You win![/]\n");
                            stay.ToExit = true;
                            Thread.Sleep(1500);
                            AnsiConsole.Markup($"Press Enter to begin again.");
                            Console.ReadLine();
                        }
                        else if (playerHand.HandTotal > 21)
                        {
                            AnsiConsole.Markup("[red]Bust! You lose.[/]\n");
                            stay.ToExit = true;
                            Thread.Sleep(1500);
                            AnsiConsole.Markup($"Press Enter to begin again.");
                            Console.ReadLine();
                        }
                        else if (playerHand.HandTotal < 21 && !stay.ToExit)
                        {
                            switch (Hand.PlayerMenu().ToLower())
                            {
                                case "hit":
                                    playerHand.AddToHand(APICall.DrawCard());
                                    playerHand.GetHandTotal();
                                    break;
                                case "stay":
                                    // This is not working atm
                                    stay.ToExit = true;
                                    break;
                                case "exit":
                                    exit.ToExit = true;
                                    break;
                                default:
                                    break;
                            }

                            // Display method dealerHiddenDisplayTable() in CardTable Class
                            DisplayTable.DealerHiddenDisplayTable(playerHand, dealerHand);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }



                    }
                }

                //Dealer Turn Loop
                int dealerHit = 16;
                int dealerStay = 17;
                LoopExit dealerExit = new();
                dealerExit.ToExit = false;
                //Give dealer second card
                dealerHand.AddToHand(APICall.DrawCard());
                dealerHand.GetHandTotal();

                if (playerHand.HandTotal > 21 || playerHand.HandTotal > 21)
                {
                    dealerExit.ToExit = true;
                }

                while (!dealerExit.ToExit)
                {
                    // Display method DisplayTable() (dealer not hidden) in CardTable Class
                    DisplayTable.DealerVisibleDisplayTable(playerHand, dealerHand);
                    Thread.Sleep(500);

                    if (dealerHand.HandTotal < 21)
                    {
                        if (dealerHand.HandTotal <= dealerHit)
                        {
                            dealerHand.AddToHand(APICall.DrawCard());
                            dealerHand.GetHandTotal();
                        }
                        else if (dealerHand.HandTotal >= dealerStay)
                        {
                            AnsiConsole.Markup($"The Dealer stays with {dealerHand.HandTotal}.\n");
                            dealerExit.ToExit = true;
                        }
                        else
                        {
                            dealerExit.ToExit = true;
                        }
                    }
                    else if (dealerHand.HandTotal == 21)
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
                if (playerHand.HandTotal < 21 && dealerHand.HandTotal < 21)
                {
                    if (playerHand.HandTotal > dealerHand.HandTotal)
                    {
                        AnsiConsole.Markup($"[green]You Win!![/]\n");
                        Thread.Sleep(1000);
                        AnsiConsole.Markup($"Press Enter to begin again.");
                        Console.ReadLine();
                    }
                    else if (dealerHand.HandTotal > playerHand.HandTotal)
                    {
                        AnsiConsole.Markup($"[red]You Lose...[/]\n");
                        Thread.Sleep(1000);
                        AnsiConsole.Markup($"Press Enter to begin again.");
                        Console.ReadLine();
                    }
                    else
                    {
                        AnsiConsole.Markup($"TIE\n");
                        Thread.Sleep(1000);
                        AnsiConsole.Markup($"Press Enter to begin again.");
                        Console.ReadLine();
                    }
                }
                else if (dealerHand.HandTotal == 21)
                {
                    AnsiConsole.Markup($"[red]You Lose...[/]\n");
                    Thread.Sleep(1000);
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
                else if (dealerHand.HandTotal > 21)
                {
                    Thread.Sleep(200);
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
            }
        }
    }
}
