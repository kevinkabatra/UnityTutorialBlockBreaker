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

    private LevelGameObject level;
    private BallPositionHandler ball;
    private Logic playerLogic;

    public static Player Get()
    {
        var player = FindObjectOfType<Player>();
        if (player == null)
        {
            var errorMessage = string.Format("Cannot find {0}", nameof(player));
            throw new NullReferenceException(errorMessage);
        }

        return player;
    }

    private void InitializeForStart()
    {
        ResetHealth();
        ResetScore();
    }

    private void InitializeForNewLevel()
    {
        playerLogic = Logic.GetOrCreateInstance();
        level = LevelGameObject.GetLevel();

        ball = FindObjectOfType<BallPositionHandler>();
        if (ball == null)
        {
            throw new NullReferenceException(nameof(BallPositionHandler));
        }
    }

    private void SetupListeners()
    {
        //level.sceneLoader.AddListenerForStartGameEvent(() => { Logic.Reset(); });
        level.sceneLoader.AddListenerForStartGameEvent(() => { InitializeForStart(); });
        level.sceneLoader.AddListenerForNextSceneEvent(() => { InitializeForNewLevel(); });
    }

    // Start is called before the first frame update
    private void Start()
    {
        if(level == null & ball == null)
        {
            InitializeForNewLevel();
            SetupListeners();
        }
    }

    /// <inheritdoc/>
    public void AddDamage(int damage = 1)
    {
        playerLogic.Health.AddDamage(damage);
        HandleDamage();
    }

    /// <inheritdoc/>
    public void AddToScore(int points = 1)
    {
        playerLogic.Score.AddToScore(points);
        UpdateScoreDisplay();        
    }

    /// <inheritdoc/>
    public int GetHealth()
    {
        return playerLogic.Health.GetHealth();
    }

    /// <inheritdoc/>
    public int GetScore()
    {
        return playerLogic.Score.GetScore();
    }

    /// <inheritdoc/>
    public void ResetHealth()
    {
        playerHealthHeartOne.SetActive(true);
        playerHealthHeartTwo.SetActive(true);
        playerHealthHeartThree.SetActive(true);

        playerLogic.Health.ResetHealth();
    }

    /// <inheritdoc/>
    public void ResetScore()
    {
        playerLogic.Score.ResetScore();
        UpdateScoreDisplay();
    }

    /// <summary>
    ///     Updates the in game display.
    /// </summary>
    private void UpdateScoreDisplay()
    {
        playerScoreDisplay.text = GetScore().ToString();
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
        switch (GetHealth())
        {
            case 2:
                playerHealthHeartThree.SetActive(false);
                break;
            case 1:
                playerHealthHeartTwo.SetActive(false);
                break;
            case 0:
                playerHealthHeartOne.SetActive(false);
                GameOver();
                return;
            default:
                throw new NotImplementedException();
        }

        ball.ResetBall();
    }
}
