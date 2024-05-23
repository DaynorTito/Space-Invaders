# Space Invaders Game Documentation

## Overview

Space Invaders is a classic arcade game where the player controls a ship at the bottom of the screen and must shoot down rows of alien invaders before they reach the bottom. The game is known for its simple yet addictive gameplay and challenging levels.
![image](https://github.com/DaynorTito/Space-Invaders/assets/107761709/98b4083e-394f-4784-bab7-41bb5fd02eb7)


## Technologies Used

- **C#:** The game is developed using the C# programming language, providing a powerful and flexible platform for game development.
- **Uno Platform:** The game is built using the Uno Platform framework, allowing it to run on multiple platforms including Windows, Android, iOS, and macOS. Uno Platform provides a unified development experience across different devices.
- **Model-View-ViewModel (MVVM):** The game follows the MVVM design pattern, which helps in separating the concerns of the application and enables easier maintenance and testing.

## Components

### Model

The Model represents the game's data and business logic. In Space Invaders, the Model includes classes for:

- **PlayerShip:** Represents the player's ship, including its position, health, and movement logic.
- **AlienInvader:** Represents an alien invader, including its position, health, and movement logic.
- **Shield:** Represents a shield that protects the player's ship from enemy fire.
- **GameScore:** Represents the game's score and provides methods for updating and retrieving the score.

### View

The View is responsible for the game's user interface. In Space Invaders, the View includes:

- **GameScreen:** The main game screen where the gameplay takes place.
- **PlayerShipView:** The visual representation of the player's ship.
- **AlienInvaderView:** The visual representation of the alien invaders.
- **ShieldView:** The visual representation of the shields.

### ViewModel

The ViewModel acts as an intermediary between the Model and the View. In Space Invaders, the ViewModel includes:

- **GameViewModel:** Controls the game logic, such as updating the game state, handling player input, and managing collisions.
- **PlayerShipViewModel:** Manages the player's ship, including its movement and shooting logic.
- **AlienInvaderViewModel:** Manages the alien invaders, including their movement patterns and behavior.
- **ShieldViewModel:** Manages the shields, including their health and degradation over time.

## Implementation Details

- **Player Ship:** The player's ship is controlled using the arrow keys (left and right) to move horizontally and the spacebar to shoot.
- **Alien Invaders:** The alien invaders move horizontally across the screen and gradually descend towards the player's ship. The player must shoot them down before they reach the bottom of the screen.
- **Shields:** The shields protect the player's ship from enemy fire. They gradually degrade as they are hit by bullets, eventually disappearing completely.
- **Scoring System:** The game keeps track of the player's score, which increases as the player shoots down alien invaders. The score is displayed on the screen for the player to see.

## Conclusion

Space Invaders demonstrates the use of C#, Uno Platform, and the MVVM design pattern in game development. By separating the game's logic into distinct components, the code is easier to maintain and extend, making it a great example of modern game development practices.

