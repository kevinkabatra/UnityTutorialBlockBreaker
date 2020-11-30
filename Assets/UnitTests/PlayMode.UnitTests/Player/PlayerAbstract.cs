using NUnit.Framework;

public abstract class PlayerAbstract : PlayModeTestAbstract
{
    protected Player player;

    [SetUp]
    public override void Setup()
    {
        base.Setup();

        player = Player.Get();
    }

    [TearDown]
    public override void TearDown()
    {
        base.TearDown();

        // Cannot destroy, otherwise the delay in its destruction will break other tests, because this is a Singleton.
        player.ResetPlayerHealth();
        player.ResetScore();
        player = null;
    }
}
