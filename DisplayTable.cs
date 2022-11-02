using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class DisplayTable
    {
        public static void DealerHiddenDisplayTable(Hand playerHand, Hand dealerHand)
        {
            Console.Clear();
            AnsiConsole.Markup($"Dealer: ");
            for (int i = 0; i < dealerHand.Cards.Count; i++)
            {
                AnsiConsole.Markup($"{dealerHand.Cards[i].Value}, ");
            }
            AnsiConsole.Markup($"X Total:{ dealerHand.HandTotal}\n");
            AnsiConsole.Markup($"Player: ");
            for (int i = 0; i < playerHand.Cards.Count; i++)
            {
                AnsiConsole.Markup($"{playerHand.Cards[i].Value}, ");
            }
            AnsiConsole.Markup($" Total:{ playerHand.HandTotal}\n");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        public static void DealerVisibleDisplayTable(Hand playerHand, Hand dealerHand)
        {
            Console.Clear();
            AnsiConsole.Markup($"Dealer: ");
            for (int i = 0; i < dealerHand.Cards.Count; i++)
            {
                AnsiConsole.Markup($"{dealerHand.Cards[i].Value}, ");
            }
            AnsiConsole.Markup($" Total:{ dealerHand.HandTotal}\n");
            AnsiConsole.Markup($"Player: ");
            for (int i = 0; i < playerHand.Cards.Count; i++)
            {
                AnsiConsole.Markup($"{playerHand.Cards[i].Value}, ");
            }
            AnsiConsole.Markup($" Total:{ playerHand.HandTotal}\n");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
    }
}
