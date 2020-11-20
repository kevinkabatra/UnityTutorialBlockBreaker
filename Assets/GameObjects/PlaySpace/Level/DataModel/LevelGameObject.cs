using System;
using UnityEngine;
using TMPro;

public class LevelGameObject : MonoBehaviour
{
    [SerializeField] public PlayerHealth playerHealth;

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private TextMeshProUGUI playerScoreDisplay;

    private int currentBlockCount;
    private int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneLoader == null)
        {
            throw new NullReferenceException(nameof(sceneLoader));
        }

        if (playerScoreDisplay == null)
        {
            throw new NullReferenceException(nameof(playerScoreDisplay));
        }

        if (playerHealth == null)
        {
            throw new NullReferenceException(nameof(playerHealth));
        }
    }

    public void AddPointsToScore(int points = 1)
    {
        playerScore += points;
        playerScoreDisplay.text = playerScore.ToString();
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
