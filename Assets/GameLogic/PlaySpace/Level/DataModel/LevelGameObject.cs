using System;
using UnityEngine;

public class LevelGameObject : MonoBehaviour
{
    public Player player;
    public SceneLoader sceneLoader;
    
    private int currentBlockCount;

    public static LevelGameObject GetLevel()
    {
        var level = FindObjectOfType<LevelGameObject>();
        if (level == null)
        {
            var errorMessage = string.Format("Cannot find {0}", nameof(level));
            throw new NullReferenceException(errorMessage);
        }
        
        return level;
    }

    public void UpdateBlockCount()
    {
        currentBlockCount = BlockCounter.GetBlockCount();
        EndLevelWhenZeroBlocksRemain();
    }

    private void EndLevelWhenZeroBlocksRemain()
    {
        if(currentBlockCount == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (sceneLoader == null)
        {
            throw new NullReferenceException(nameof(sceneLoader));
        }

        player = Player.Get();
        if (player == null)
        {
            throw new NullReferenceException(nameof(player));
        }
    }
}
