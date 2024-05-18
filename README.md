Card-Match Game Documentation

Introduction
------------
The Card-Match Game is a simple memory game where the player needs to find matching pairs of cards from a shuffled grid of face-down cards. The game is built using Unity(2021_LTS) and written in C#.


Game Overview
-------------
The objective of the game is to flip over pairs of matching cards from a grid of face-down cards. When all pairs are matched, the game is completed. During the gameplay, game is saving and loading till the apk is cleaned.


Game Flow
---------

 1.Game Setup:

  - The game begins by creating a grid of face-down cards with matching pairs randomly distributed.
  - The total number of cards and the maximum card value can be configured.


 2.Player's Turn:

  - The player clicks on a face-down card to flip it over and reveal its image.
  - The player then clicks on another face-down card, trying to find its matching pair.


 3.Match Check:

  - If the two revealed cards match, they remain face-up, and the player can continue their turn.
  - If the two revealed cards do not match, they are flipped back face-down after a short delay.


 4.Game Completion:

  - The game is completed when all pairs of matching cards have been found and revealed.
  - A "Game Completed" UI is displayed, showing the player's final score and the total number of attempts.



Project Structure
-----------------
The game project is structured into the following main components:

  1.CardManager:

   - Responsible for creating, shuffling, and displaying the cards on the game board.
   - Manages the card sprites and prefabs.


  2.GameManager:

  - Handles the game logic, such as checking for matches, keeping track of the game state, and managing player turns.
  - Communicates with the CardManager, UIManager, and PersistenceManager to update the game state and UI.


 3.UIManager:

  - Manages the game's user interface, including displaying the correct guesses, total guesses, and the "Game Completed" UI.
  - Receives updates from the GameManager and updates the UI accordingly.


 4.PersistenceManager:

  - Handles saving and loading game data, such as the current game state, score, and card positions.
  - Allows the player to resume the game from their last saved state.

 5.SoundManager

  - Handles loading and caching sound files, adjusting volume levels, and providing playing sound throughout the game.



Code Structure
--------------
The project follows a modular structure with separate scripts for different responsibilities:

CardManager.cs: Handles card creation, shuffling, and display.
GameManager.cs: Manages the game logic and state.
UIManager.cs: Handles UI updates and displays.
PersistenceManager.cs: Manages saving and loading game data.
SoundManager.cs: Being responsible for managing and playing various sound effects in the game
GLOBALCONST.cs: Contains constant values that are used across the game project. 


Dependencies
------------
The project relies on the following Unity packages and assets:

Unity UI Toolkit
Unity TextMeshPro (for UI text rendering)
Custom card sprites and backgrounds (included in the project's Assets folder)


Future Improvements
-------------------
Here are some potential future improvements for the Card-Match Game:

Add difficulty levels by increasing the number of cards or introducing different card themes.
Implement leaderboards and player profiles to track high scores and game progress.
Introduce power-ups or special abilities to enhance gameplay.
Add sound effects and background music for a more immersive experience.
Implement additional game modes or variations, such as timed challenges or multiplayer modes.


Conclusion
----------
The Card-Match Game is a simple yet engaging memory game that tests the player's observation and matching skills. The modular structure and separation of concerns in the codebase allow for easy maintenance and future extensions.