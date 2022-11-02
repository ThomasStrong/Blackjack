# Blackjack
<img align="center" src=".\bjtitlescreen.png" alt="Blackjack title screen">
<img align="center" src=".\gameplay.png" alt="Blackjack title screen">

## Description

Console Blackjack/21 card game.

## Table of Contents

- [Overview](#overview)
- [Instructions](#instructions)
- [Features](#features)
- [Technologies](#technologies)
- [Future Development](#future-development)
- [Questions](#questions)
- [Contributions](#contributions)

## Overview

The card playing game Blackjack in C# console application.  The target framework for this app is .NET 5.0.  It uses Spectre.Console for rendering and Newtonsoft for JSON serialization.

  <br></br>

## Instructions

- Clone this Repository:  Using the green 'Code' button above clone the repo to your local machine.
- Open the file Blackjack.sln in Visual Studio (or preferred IDE).
    * **Note: In Visual Studio, you can select: Open > 'Open a Project or Solution'; 
              Or navigate to the file in your file explorer, right-click and choose 'Open in Visual Studio'.
- Run Debug to begin the application.
       
## Features

-	Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program
    * This is accomplished in Program.cs with a while loop that runs until asked to "exit".
-	Connect to an external/3rd party API and read data into your app (Deck of Cards API)
    * This project calls the DeckofCards API to instantiate 6 decks (Blackjack standard) and to draw consequent cards from those decks;
-	Create an additional class which inherits one or more properties from its parent
    * The `DealerHiddenCard` class inherits from the `Card` class, in order to set a hidden card in the dealer's hand until the dealer's turn.


## Technologies

- C# <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" alt="C sharp" width="5%" />      

- .NET <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" alt="dot Net" width="5%" />

- Spectre.Console Package

- Newtonsoft.Json
          

## Future Development

- Fix LoopExit exit conditions
- Console.Beep() method for indicating win/loss?
- Add split and/or double-down functionality
- Implement a score (each win) or betting (monetary calculations)
- Allow players to set their name and save their score/money
  (1)   Subsequently saving and reading the save file for re-entrance of player (?)
- Allow player to set Dealer rules on hit/stay
- Implement other simple card games to the game as extras
  (1)	High card (can also be used as a chooser for ‘who-goes-first’, etc.)
  (2)	War (extended high card game)
  (3)   etc.
- More than one player (blackjack “table”) functionality; 
  (1)   "Choose # players" on title screen


  <br></br>

## Questions?

If you have any questions or concerns feel free to reach out to me at [Github](https://github.com/ThomasStrong) or through email at <strng_thms@yahoo.com>.
<br></br>

## Contributions

Contributions are not necessary at this time.  However, I will be open to any contributions after 11/30/22.  As always any advice, insight, or proffered information is always welcome!