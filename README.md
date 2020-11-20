# Unity Tutorial: Block Breaker
Kata that involved me learning how to make a game that demonstrates:
1. In game physics
    * Colliders and Collision
    * Gravity
    * Rigid bodies
1. Particle effects
1. Sounds effects
1. Background music

I also once again demonstrate concepts that have been shown in previous exercises. 
1. Utilizing `Stateless` as a light-weight state machine for managing the various game states. Since this game will not be tracking the user's position with a state machine I should be able to lift the previous state machine code from the previous exercise. This will allow me to control the flow of starting and stopping the game without having to reinvent the wheel for a second time.
1. Developing games using n-tier architecture. Again Unity does not want to support this seamlessly, it seems that most games are not made with this as a focus. But I really want to focus on the ability to move a future game from one game engine to another. It is most likely that I will never have a need to undertake such an effort, but I think it is bad practice to tightly couple my work to a particular third party tool.
1. ToDo: determine a design pattern for this game. Perhaps mediator for handling `Main`. Are there other patterns that are reasonable | beneficial to leverage.
1. Handling real-time input from users. In my previous example I supported real-time input, however input lag was not a concern with that project. It will be interesting to see how quickly Unity will process constant input to handle the paddle object. In addition I might want to consider supporting touch screen controls so that this game can be played on mobile devices. That has been a limitation within my previous offerings. ToDo: clean up this section.

## Credits

### Artwork
As I am focusing only on programming I decided that I should find some open source images to create my "game art". In my previous tutorial I mentioned that I had found [Open Game Art](https://opengameart.org), which is a site that offers just that. The artwork in this tutorial will once again come from artists who share their hard-work on that site, and this document will give appropriate credit to those artists.

#### Heart
Author: https://opengameart.org/users/mart
Link: https://opengameart.org/content/heart-2

#### Background Image
All elements of the background, and the backgrounds themselves come courtesy of [Kenney.nl](http://donate.kenney.nl/). Here is the [link](https://opengameart.org/content/background-elements) to his work that I pulled from Open Game Art. His work was released under a [CCO](https://creativecommons.org/licenses/by/3.0/) license, so I want to thank him for that and give him the proper credit.

### Audio
ToDo: Add proper comments for works used

[FreeSound.org](https://freesound.org/)

* Start
    * Creator: [SRJA_Gaming](https://freesound.org/people/SRJA_Gaming/)
    https://freesound.org/people/SRJA_Gaming/sounds/545393/
* Background
    * Creator: [SRJA_Gaming](https://freesound.org/people/SRJA_Gaming/)
    * Link: https://freesound.org/people/SRJA_Gaming/sounds/545392/
* Game Over
    * Creator: [Adam Weeden](https://freesound.org/people/AdamWeeden/)
    * Link: https://freesound.org/people/AdamWeeden/sounds/157218/
* Blocks Breaking: 
    * Creator: [yottasounds](https://freesound.org/people/yottasounds/)
    * https://freesound.org/people/yottasounds/sounds/232137/
* All other sounds. Any other sounds that have been included in this project were provided by the Unity course intructor.

## References and other content I found helpful
1. Of course the Udemy class: https://www.udemy.com/course/unitycourse/.
