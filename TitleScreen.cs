using System;
using Spectre.Console;

namespace Blackjack
{
    class TitleScreen
    {
        public static void Title()
        {
            AnsiConsole.Markup("[bold black on green]                                                                                                       \n[/]");
            AnsiConsole.Markup("[bold black on green]                                                                                                       \n[/]");
            AnsiConsole.Markup("[bold black on green]         ***** **   ***                             *                                       *          \n[/]");
            AnsiConsole.Markup("[bold black on green]      ******  ***    ***                          **           *                          **           \n[/]");
            AnsiConsole.Markup("[bold black on green]     **   *  * **     **                          **          ***                         **           \n[/]");
            AnsiConsole.Markup("[bold black on green]    *    *  *  **     **                          **           *                          **           \n[/]");
            AnsiConsole.Markup("[bold black on green]        *  *   *      **                          **                                      **           \n[/]");
            AnsiConsole.Markup("[bold black on green]      * * **  *       **       ****       ****    **  ***    ***       ****       ****    **  ***      \n[/]");
            AnsiConsole.Markup("[bold black on green]      * * ** *        **      * ***  *   * ***  * ** * ***    ***     * ***  *   * ***  * ** * ***     \n[/]");
            AnsiConsole.Markup("[bold black on green]      * * ***         **     *   ****   *   ****  ***   *      **    *   ****   *   ****  ***   *      \n[/]");
            AnsiConsole.Markup("[bold black on green]      * * ** ***      **    **    **   **         **   *       *    **    **   **         **   *       \n[/]");
            AnsiConsole.Markup("[bold black on green]      * * **   ***    **    **    **   **         **  *       *     **    **   **         **  *        \n[/]");
            AnsiConsole.Markup("[bold black on green]       *  **     **   **    **    **   **         ** **      ***    **    **   **         ** **        \n[/]");
            AnsiConsole.Markup("[bold black on green]          *      **   **    **    **   **         ******      ***   **    **   **         ******       \n[/]");
            AnsiConsole.Markup("[bold black on green]      ****     ***    **    **    **   ***     *  **  ***      ***  **    **   ***     *  **  ***      \n[/]");
            AnsiConsole.Markup("[bold black on green]     *  ********      *** *  ***** **   *******   **   *** *    ***  ***** **   *******   **   *** *   \n[/]");
            AnsiConsole.Markup("[bold black on green]    *     ****         ***    ***   **   *****     **   ***      **   ***   **   *****     **   ***    \n[/]");
            AnsiConsole.Markup("[bold black on green]    *  [blue]==========================================================[/]**[blue]================================[/]    \n[/]");
            AnsiConsole.Markup("[bold black on green]     **                                                          *                                     \n[/]");
            AnsiConsole.Markup("[bold black on green]                                                                *                                      \n[/]");
            AnsiConsole.Markup("[bold black on green]                                                               *                                       \n[/]");
            AnsiConsole.Markup("[bold black on green]                                                                                                       \n[/]");
            AnsiConsole.Markup("[bold black on green]                                                                                                       \n[/]");
        }

        public static string TitleMenu()
        {
            string optionsTitle = "Would you like to [green]play[/]?";
            string[] titleOptions = {
                            "Play", "Exit"
                        };
            return UserMenu.Menu(optionsTitle, titleOptions.Length, titleOptions);

        }
    }
}
