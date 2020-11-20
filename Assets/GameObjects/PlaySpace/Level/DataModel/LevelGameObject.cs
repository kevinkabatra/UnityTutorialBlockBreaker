using System;
using UnityEngine;

public class LevelGameObject : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerScore playerScore;

    [SerializeField] private SceneLoader sceneLoader;
    
    private int currentBlockCount;

    // Start is called before the first frame update
    void Start()
    {
        if(sceneLoader == null)
        {
            throw new NullReferenceException(nameof(sceneLoader));
        }

        if(playerHealth == null)
        {
            throw new NullReferenceException(nameof(playerHealth));
        }

        if(playerScore == null)
        {
            throw new NullReferenceException(nameof(playerScore));
        }    
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
}
