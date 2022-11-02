using Spectre.Console;
using System;

namespace Blackjack
{
    class DisplayTable
    {
        public static void DisplayGameTable(Hand playerHand, Hand dealerHand)
        {
            Console.Clear();
            DrawDealer(dealerHand);
            DrawPlayer(playerHand);
        }

        private static void DrawPlayer(Hand hand)
        {
            var table = new Table();
            table.Width(120);
            table.Centered();

            table.AddColumn("[blue]Player[/] Hand").Centered();
            // table.AddColumn(new TableColumn("CARDS").Centered());
            table.AddColumn(new TableColumn("Total").Centered());

            foreach (Card card in hand.Cards)
            {
                table.AddRow(card.Value, " ");
            }
            table.AddRow(" ", ($"[green]{hand.HandTotal}[/]"));

            AnsiConsole.Write(table);
        }

        private static void DrawDealer(Hand hand)
        {
            var dealerTable = new Table();
            dealerTable.Width(120);
            dealerTable.Centered();

            dealerTable.AddColumn("[yellow]Dealer[/] Hand").Centered();
            // dealerTable.AddColumn(new TableColumn("CARDS").Centered());
            dealerTable.AddColumn(new TableColumn("Total").Centered());

            foreach (Card card in hand.Cards)
            {
                dealerTable.AddRow(card.Value, " ");
            }
            dealerTable.AddRow(" ", ($"[green]{hand.HandTotal}[/]"));

            AnsiConsole.Write(dealerTable);
        }

    }
}
