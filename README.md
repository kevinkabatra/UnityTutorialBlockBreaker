# Unity Tutorial: Block Breaker
Welcome to Block Breaker. In this tutorial I needed to demonstrate some new concepts, when compared to the previous exercise the [Labyrinth](https://github.com/kevinkabatra/UnityTutorialLabyrinth). These concepts were:

1. Leveraging the Unity Engine for its in-game physics. This system is really quite something, without any proper source code from me I was able to quickly setup a playable "game" that included a ball and paddle. Leveraging the in-game physics I could bounce the ball off of the paddle and watch gravity pull it back down. As a developer I cannot help but think about how complex creating your own physics engine must be, so I am very happy to use the one from Unity and for this project it works quite well. In this tutorial I used the following portions of the physics engine:
    * Rigid Bodies - This is what allows you to tell Unity to control a particular game object with the physics engine. 
        * The ball for example was setup to be a `dynamic` body which means that it can be moved by gravity and from forces of collisions. This is how the ball was able to fall in the game without adding any source code. Magic.
        * The paddle was a different type, it was a `kinematic` body. This allows me to tell the object that it can move, but it must be controlled by the user. This type of object is not affected by gravity or other collisions. It would be much harder to play a game like Breakout if your paddle continually got knocked away from you.
        * The blocks are the final type, which is `static`. These objects do not move for any reason and are not affected by any outside forces.
    * Physics Materials - This is a component that you can add to a game object that will allow you to adjust the amount of bounce and friction that will occur on collision. This component enables the ball to repel from an object that it strikes. It is important to note that you can set this material up to gain speed on each bounce, where in reality it would obviously lose some due to friction, but doing so is super tricky. It is very easy for this object to become too fast for a human to manage and follow along the screen, in fact this object can begin to move so fast that the Unity physics engine cannot keep up with it during each frame. To handle this I actually added a `BallBounceLimiter` inside this repository, this ensures that the ball will get faster as you play but I capped it off at a more reasonable speed. Be sure to check out that class if you are interested, I will also write an article about that in the future.
    * Colliders and Collision - Unity has several Collider components that can be added to a game object, this allows you to quickly tell the physics engine the shape of the object and where its hit box(es) are. Adding colliders to the game objects mentioned above enabled the objects to interact with one another physically when they touched. In combination with the materials it allowed the ball to bounce off of every object that it struck. Unity also provides some events that you can listen to for your collision, this obviously allows you to write some logic for what the game should do when two objects touch.
1. Speaking of events, there is another module (that might be the right term) from Unity called UnityEngine.Events. Using this system it is possible to setup your own events and subscribers (a.k.a listeners). Using the event system allowed me to decouple my code more, instead of game object being called by another, where the second object has to understand the signature of the first. I can have one game object offer a public API that a second game object can listen to, and then that second object can invoke its own methods when the event is fired.
    * If this sounds complex, relax it is not at all. Look at the `VirtualController` class that I setup and notice how the `BallPositionHandler` references the `FireEvent`.
1. With all of this code I ran into issues the first time I tried to implement this tutorial. Due to some over eager use of Singletons the game got into a state where I could not accurately predict what the code was doing anymore. Whenever the game would continue after a game over most of the systems would die, and tracking down and fixing all of the issues seemed to lead to additional issues popping up. So I did what any sane developer would do, I scrapped everything. I actually started a second repository and started to rebuild this project one object | mini-feature at a time. The major difference was that I began to introduce unit testing on my Unity layer as I created it. I already had unit testing for my business logic layer, creating unit tests for C# is dead simple. However, doing the same for Unity was not so easy. I will be writing at least one article on unit testing with Unity in the future. As difficult as it was to implement and rely on it paid massive dividends throughout the development. As any developer worth their salt would understand, I would sometimes make a minor change to one game object and then an entire system elsewhere in the code would explode. Having the unit tests allowed me to see these issues right away and make changes to handle them.
1. Finally I implemented audio with some sound effects and background music. Again using Unity made this dead simple, it was mostly just drag and drop and some minor configurations to get this to work correctly. The most complex task that I had here is that I wanted the block to play two different sounds. The first was whenever the block was struck, while the second was when the block was destroyed. I wrote a small class called `AudioPlayer` to handle playing sounds on collision, and I called Unity's `AudioSource` directly to play the block's death rattle.    
    
I also once again demonstrate concepts that have been shown in previous exercises:
1. Developing games using n-tier architecture. Again Unity does not want to support this seamlessly, it seems that most games are not made with this as a focus. But I really want to focus on the ability to move a future game from one game engine to another. It is most likely that I will never have a need to undertake such an effort, but I think it is bad practice to tightly couple my work to a particular third party tool.
1. I once again levered the Singleton design pattern. This time I actually implemented the Singleton object within my business logic and within Unity itself as well. Be sure to check out that bit of code because as much as I hate Singletons, I am rather proud of how cleanly it was implemented. With that said, Unity does not appreciate Singletons and that is even more evident when attempting to unit test one. There was lots of pain that stemmed from this but the concept of a player being a Singleton was so engrained in this design that I did not want to change that midway through development. Especially since I had already restarted this project once before. Might be a tough sell though, having me add another Singleton into Unity in the future.
1. Handling real-time input from users. In my previous example I supported real-time input, however input lag was not a concern with that project. In the Labyrinth project controls were limited to the keyboard only, and in this tutorial I wanted to implement touch controls as well. To do so I created a Virtual Controller that will handle all of the inputs and then inform the game, via events, what input the player has provided. This level of abstraction is really helpful if multiple items in the game need to listen for the controller, and it easily enables adding support for additional input options in the future. For example I could add support for XBox game pads by simply updating a single method, the event would still fire the same, and the rest of the game would behave accordingly.
1. Finally I wanted to introduce a novel concept where the game would get easier the more times you failed while playing it. To do this I setup a health system where each time you get a game over you can continue the game and gain an additional life point. To simplify this implementation I limited the maximum life to 15 points, and by leveraging LINQ I was able to cleanly introduce this concept without a bunch of monolithic switch statements.

## Play this game
You can play this game at [Itch.io](https://kevinkabatra.itch.io/unity-tutorial-block-breaker), this has been play tested on PC, Android, and iPhone devices. I hope that you enjoy this game and best of luck to you, I have been told that it is so difficult that it made one person want to throw their phone out of their window. I take pride in that comment. Feel free to provide some feedback on this game, since this is a tutorial I do not plan to go back and change anything. But your feedback could be valuable for future lessons that I complete.

## Credits
Again as I am only focusing on programming and learning Unity I decided that I would find some open source material to aid in the development of this tutorial.

### Artwork
All artwork that is not specifically called out below was provided by the instructor for this class. In my previous tutorial I mentioned that I had found [Open Game Art](https://opengameart.org), which is a site that offers just that. The artwork in this tutorial will once again come from artists who share their hard-work on that site, and this document will give appropriate credit to those artists.

#### Heart
This object was used to display the current health of the player.
Author: https://opengameart.org/users/mart
Link: https://opengameart.org/content/heart-2

#### Explosion
The explosion is used when Red Blocks are broken.
Author: https://opengameart.org/users/cuzco
Link: https://opengameart.org/content/explosion

### Audio
I found a site similar to Open Game Art that focused on audio files, [FreeSound.org](https://freesound.org/). 

* Start background music
    * Creator: [SRJA_Gaming](https://freesound.org/people/SRJA_Gaming/)
    https://freesound.org/people/SRJA_Gaming/sounds/545393/
* Level background music
    * Creator: [SRJA_Gaming](https://freesound.org/people/SRJA_Gaming/)
    * Link: https://freesound.org/people/SRJA_Gaming/sounds/545392/
* Game Over sound effect
    * Creator: [Adam Weeden](https://freesound.org/people/AdamWeeden/)
    * Link: https://freesound.org/people/AdamWeeden/sounds/157218/
* Blocks Breaking: 
    * Creator: [yottasounds](https://freesound.org/people/yottasounds/)
    * https://freesound.org/people/yottasounds/sounds/232137/
* All other sounds. Any other sounds that have been included in this project were provided by the Unity course instructor.

## References and other content I found helpful
1. Of course the Udemy class: https://www.udemy.com/course/unitycourse/.
1. The Unity Docs, you can learn so much about programming going through documentation: https://docs.unity3d.com/Manual/index.html. Well so long as it is documented properly, I am looking at you Unity Testing Framework.
1. Because the Unity documentation for testing is so poor I had to find additional sources to help me understand how to properly implement that. I found a great tutorial [on an introduction to Unity unit testing](https://www.raywenderlich.com/9454-introduction-to-unity-unit-testing), takin this class fully explained everything that I needed to know to setup up Play Mode unit testing.
1. In Unity 2020 there is an issue with hosting WebGL builds on Itch.io, I found that there is an issue with compression and decompression fallback. This [posting](https://forum.unity.com/threads/webgl-both-async-and-sync-fetching-of-the-wasm-failed-build-and-runs-works-fails-when-uploading.944400/?_ga=2.219423577.1505386112.1606324287-632776480.1605231597) helped me discover the fix for this.
1. Tutorial on how to create animations using Sprites in Unity: https://learn.unity.com/tutorial/introduction-to-sprite-animations?signup=true#.

## Further reading
If you found this article interesting perhaps you would like to read how I:
* [supported localization within Unity using C# Resources](https://kevinkabatra.wordpress.com/2019/11/10/supporting-localization-in-unity-using-c-resources/).
* [used NuGet with Unity](https://kevinkabatra.wordpress.com/2020/11/14/using-nuget-with-unity/).
* see how I originally implemented N-tier architecture, localization, and NuGet in the [Labyrinth](https://github.com/kevinkabatra/UnityTutorialLabyrinth) tutorial. Some of these concepts are repeated here, but I think it is important to show the progression between projects.

Also you can check out my blog [Computer Science for Humans](https://kevinkabatra.wordpress.com/), where I write articles on anything that interests me.

## Consider sponsoring
If you found this helpful please consider sponsoring additional content. You can sign up to be a sponsor through [GitHub Sponsors](https://github.com/sponsors/kevinkabatra) and there are a few tiers of support that you can choose from. Any contributions would be greatly appreciated.
