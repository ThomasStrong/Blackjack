using Newtonsoft.Json;
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
                    dealerHand.AddToHand(new DealerHiddenCard("X"));
                    playerHand.AddToHand(APICall.DrawCard());
                    dealerHand.AddToHand(APICall.DrawCard());
                    playerHand.AddToHand(APICall.DrawCard());
                    

                    playerHand.GetHandTotal(playerHand);
                    dealerHand.GetHandTotal(dealerHand);


                    DisplayTable.DisplayGameTable(playerHand, dealerHand);
                }

                //Player Turn Loop
                LoopExit stay = new();
                stay.ToExit = false;
                if (playerHand.HandTotal == 21)
                {
                    AnsiConsole.Markup("[green]Blackjack! You win!!![/]\n");
                    stay.ToExit = true;
                }
                while (playerHand.HandTotal <= 21 && !stay.ToExit)
                {
                    while (!stay.ToExit)
                    {
                        if (playerHand.HandTotal == 21)
                        {
                            AnsiConsole.Markup("[green]21![/] Let's see what the dealer does...\n");                            
                            AnsiConsole.Markup($"Press Enter to begin again.");
                            stay.ToExit = true;
                            Console.ReadLine();
                        }
                        else if (playerHand.HandTotal > 21)
                        {
                            AnsiConsole.Markup("[red]Bust! You lose.[/]\n");
                            stay.ToExit = true;
                            AnsiConsole.Markup($"Press Enter to begin again.");
                            Console.ReadLine();
                        }
                        else if (playerHand.HandTotal < 21 && !stay.ToExit)
                        {
                            switch (Hand.PlayerMenu().ToLower())
                            {
                                case "hit":
                                    playerHand.AddToHand(APICall.DrawCard());
                                    playerHand.GetHandTotal(playerHand);
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
                            DisplayTable.DisplayGameTable(playerHand, dealerHand);
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
                dealerHand.Cards.RemoveAt(0);
                dealerHand.AddToHand(APICall.DrawCard());
                dealerHand.GetHandTotal(dealerHand);

                if (playerHand.HandTotal > 21 || dealerHand.HandTotal > 21)
                {
                    dealerExit.ToExit = true;
                }

                while (!dealerExit.ToExit)
                {
                    DisplayTable.DisplayGameTable(playerHand, dealerHand);
                    Thread.Sleep(500);

                    if (dealerHand.HandTotal < 21)
                    {
                        if (dealerHand.HandTotal <= dealerHit)
                        {
                            dealerHand.AddToHand(APICall.DrawCard());
                            dealerHand.GetHandTotal(dealerHand);
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
                else if (dealerHand.HandTotal == 21)
                {
                    AnsiConsole.Markup($"[red]You Lose...[/]\n");
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
                else if (dealerHand.HandTotal == 21 && playerHand.HandTotal == 21)
                {
                    AnsiConsole.Markup($"[red]You TIE with Blackjack![/]\n");
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
                else if (dealerHand.HandTotal > 21)
                {
                    AnsiConsole.Markup($"Press Enter to begin again.");
                    Console.ReadLine();
                }
            }
        }
    }
}
