using Spectre.Console;
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
            int counter = 0;
            while (!exit.ToExit)
            {

                Hand playerHand = new();
                Hand dealerHand = new();

                if (counter == 0)
                {
                    Console.Clear();
                    TitleScreen.Title();
                    string toPlay = TitleScreen.TitleMenu().ToLower();
                    if (toPlay == "exit")
                    {
                        exit.ToExit = true;
                    }
                    counter++;
                }
                else
                {
                    string toPlay = TitleScreen.ReplayMenu().ToLower();
                    if (toPlay == "exit")
                    {
                        exit.ToExit = true;
                    }
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
                    stay.ToExit = true;
                    WinLose.PlayerHasBlackjack();
                }
                while (playerHand.HandTotal <= win && !stay.ToExit)
                {
                    while (!stay.ToExit)
                    {
                        if (playerHand.HandTotal == win)
                        {
                            stay.ToExit = true;
                            WinLose.PlayerHasTwentyOne();
                        }
                        else if (playerHand.HandTotal > win)
                        {
                            stay.ToExit = true;
                            WinLose.PlayerBust();
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
                            AnsiConsole.Markup($"The Dealer stays with {dealerHand.HandTotal}.\n"); 
                            dealerExit.ToExit = true;
                        }
                    }
                    else if (dealerHand.HandTotal == win)
                    {
                        dealerExit.ToExit = true;
                        WinLose.DealerHasBlackjack();
                    }
                    else
                    {
                        dealerExit.ToExit = true;
                        WinLose.DealerBust();
                    }
                }
                
                // Win conditions if Player does not have Blackjack
                if (!exit.ToExit && playerHand.HandTotal < win)
                {
                    Hand.CompareHands(playerHand, dealerHand);
                }
            }
        }
    }
}
