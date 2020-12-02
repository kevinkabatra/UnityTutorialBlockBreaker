# Unit Testing with Unity




Business | domain logic layer
    * Player
        * Health
        * Score

Using n-tier architecture to have a separate business layer for code that does not depend on Unity assemblies. This allows normal unit tests to be written.
Using Unity Testing Framework, find link, to create Play Mode unit tests. Play Mode unit tests allow you to create an instance of your game objects and test their behaviors.

MonoBehavior.Instantiate requires a Prefab, and the Prefab must be placed under Assets/Resources folder in order to access it.
It is very important to separate the concept of the Prefab from the object that is in the actual scene. For example a few times I would make a change on the game objects within the Scene and forget to apply it back to the Prefab, then run the unit tests and they would fail. Possibly nine out of ten times a new test failure would be because of this.

Mention timing, especially the limitation on the Start method not being called prior to the unit test starting to run. And not having any proper control over the timing of the objects.

Mention how much Singletons suck for unit testing and why they should be avoided in Unity at all costs. The tests are not running in parallel but they are also not finished with cleaning themselves up prior to the next test starting. And due to where Destroy is in the execution list, bad things tend to happen with Singletons.