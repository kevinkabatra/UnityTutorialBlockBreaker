using BlockBreaker.Logic.Player.PlayerHealth;
using BlockBreaker.Logic.Player.PlayerScore;
using Logic = BlockBreaker.Logic.Player.DataModel.Player;
using TMPro;
using System;
using UnityEngine;

public class Player : Singleton<Player>, IPlayerHealth, IPlayerScore
{
    [SerializeField] private GameObject playerHealthHeartOne;
    [SerializeField] private GameObject playerHealthHeartTwo;
    [SerializeField] private GameObject playerHealthHeartThree;
    [SerializeField] private TextMeshProUGUI playerScoreDisplay;

    private BallPositionHandler ball;
    private Logic playerLogic;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallPositionHandler>();
        if (ball == null)
        {
            throw new NullReferenceException(nameof(BallPositionHandler));
        }

        playerLogic = Logic.GetOrCreateInstance(); 
    }

    public void AddDamage(int damage = 1)
    {
        playerLogic.Health.AddDamage(damage);
        HandleDamage();
    }

    public void AddToScore(int points = 1)
    {
        playerLogic.Score.AddToScore(points);
        playerScoreDisplay.text = GetScore().ToString();
    }

    public int GetPlayerHealth()
    {
        return playerLogic.Health.GetPlayerHealth();
    }

    public int GetScore()
    {
        return playerLogic.Score.GetScore();
    }

    /// <summary>
    ///     Player has perished.
    /// </summary>
    private void GameOver()
    {
        SceneLoader.LoadGameOverScene();
    }

    /// <summary>
    ///     Executes logic based on amount of damage to the player.
    /// </summary>
    private void HandleDamage()
    {
        switch (GetPlayerHealth())
        {
            case 2:
                Destroy(playerHealthHeartThree);
                break;
            case 1:
                Destroy(playerHealthHeartTwo);
                break;
            case 0:
                Destroy(playerHealthHeartOne);
                GameOver();
                return;
            default:
                throw new NotImplementedException();
        }

        ball.ResetBall();
    }
}
