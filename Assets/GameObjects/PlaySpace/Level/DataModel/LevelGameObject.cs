using System;
using UnityEngine;

public class LevelGameObject : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;

    private int currentBlockCount;

    // Start is called before the first frame update
    void Start()
    {
        if(sceneLoader == null)
        {
            throw new NullReferenceException(nameof(sceneLoader));
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
