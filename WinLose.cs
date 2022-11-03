using Spectre.Console;
using System;


namespace Blackjack
{
    class WinLose
    {
        public static void PlayerHasBlackjack()
        {
            Console.Beep();
            AnsiConsole.Markup("[green]Blackjack! You win!!![/]\n");
        }

        public static void PlayerHasTwentyOne()
        {
            AnsiConsole.Markup("[green]21![/] Let's see what the dealer does...\n");
            AnsiConsole.Markup($"Press Enter to begin again.");
            Console.ReadLine();
        }

        public static void PlayerWins()
        {
            AnsiConsole.Markup($"[green]You Win!![/]\n");
            AnsiConsole.Markup($"Press Enter to begin again.");
            Console.ReadLine();
        }

        public static void PlayerBust()
        {
            AnsiConsole.Markup("[red]Bust! You lose.[/]\n");
            AnsiConsole.Markup($"Press Enter to begin again.");
            Console.ReadLine();
        }

        public static void PlayerLose()
        {
            AnsiConsole.Markup($"[red]You Lose...[/]\n");
            AnsiConsole.Markup($"Press Enter to begin again.");
            Console.ReadLine();
        }

        public static void Tie()
        {
            AnsiConsole.Markup($"TIE\n");
            AnsiConsole.Markup($"Press Enter to begin again.");
            Console.ReadLine();
        }
        public static void TieTwentyOne()
        {
            AnsiConsole.Markup($"[red]You TIE with 21![/]\n");
            AnsiConsole.Markup($"Press Enter to begin again.");
            Console.ReadLine();
        }
        public static void DealerHasBlackjack()
        {
            AnsiConsole.Markup($"The Dealer has Blackjack!\n");
        }

        public static void DealerBust()
        {
            AnsiConsole.Markup($"The Dealer busted!  [green]You Win!![/]\n");
        }

    }
}
