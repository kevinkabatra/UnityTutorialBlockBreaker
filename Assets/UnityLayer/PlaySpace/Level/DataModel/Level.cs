/// <summary>
///     The Level.
/// </summary>
public class Level : Common<Level>
{
    public Player player;

    private SceneLoader sceneLoader;
    private int currentBlockCount;

    /// <summary>
    ///     Used in unit testing only, gets the current block count.
    /// </summary>
    /// <returns></returns>
    public int GetCurrentBlockCount()
    {
        return currentBlockCount;
    }

    /// <summary>
    ///     Updates the private block counter.
    /// </summary>
    public void UpdateBlockCount()
    {
        currentBlockCount = BlockCounter.GetBlockCount();
        EndLevelWhenZeroBlocksRemain();
    }

    private void Start()
    {
        player = Player.Get();
        sceneLoader = SceneLoader.Get();
    }

    private void EndLevelWhenZeroBlocksRemain()
    {
        if (currentBlockCount == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
