using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class UserMenu
    {

        public static string Menu(string title, int pageSize, string[] options)
        {
            if (pageSize < 3)
            {
                pageSize = 3;
            }
            return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(pageSize)
                .AddChoices(options));
        }
    }
}
