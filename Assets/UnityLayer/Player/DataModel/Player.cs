using BlockBreaker.Logic.Player.PlayerHealth;
using BlockBreaker.Logic.Player.PlayerScore;
using Logic = BlockBreaker.Logic.Player.DataModel.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     The Player.
/// </summary>
public class Player : Singleton<Player>, IPlayerHealth, IPlayerScore
{
    public Heart heartOne;
    public Heart heartTwo;
    public Heart heartThree;

    public Heart continueHeartFour;
    public Heart continueHeartFive;
    public Heart continueHeartSix;
    public Heart continueHeartSeven;
    public Heart continueHeartEight;
    public Heart continueHeartNine;
    public Heart continueHeartTen;
    public Heart continueHeartEleven;
    public Heart continueHeartTwelve;
    public Heart continueHeartThirteen;
    public Heart continueHeartFourteen;
    public Heart continueHeartFifteen;

    [SerializeField] private Text playerScoreDisplay;
    
    private Logic playerLogic;
    private List<Heart> hearts;

    /// <summary>
    ///     Damages the player's health.
    /// </summary>
    /// <param name="damage"></param>
    public void AddDamage(int damage = 1)
    {
        playerLogic.Health.AddDamage(damage);
        HandleDamage();
    }

    /// <summary>
    ///     Adds to the player's score.
    /// </summary>
    /// <param name="points"></param>
    public void AddToScore(int points = 1)
    {
        playerLogic.Score.AddToScore(points);
        UpdateScoreDisplayToShowCurrentScore();
    }

    /// <summary>
    ///     Returns the health.
    /// </summary>
    /// <returns></returns>
    public int GetPlayerHealth()
    {
        return playerLogic.Health.GetPlayerHealth();
    }

    /// <summary>
    ///     Returns the score.
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return playerLogic.Score.GetScore();
    }

    /// <summary>
    ///     Increases the player's health up to the hard coded max.
    /// </summary>
    public void IncreasePlayerHealth()
    {
        playerLogic.Health.IncreasePlayerHealth();

        var nextHeartToEnable = hearts.Where(heart => heart.isEnabled == false).First();
        nextHeartToEnable.isEnabled = true;

        SetEnabledHeartsToActive();
    }

    /// <summary>
    ///     Resets the player's health.
    /// </summary>
    public void ResetPlayerHealth()
    {
        playerLogic.Health.ResetPlayerHealth();
        SetEnabledHeartsToActive();
    }

    /// <summary>
    ///     Resets the score back to zero.
    /// </summary>
    public void ResetScore()
    {
        playerLogic.Score.ResetScore();
        UpdateScoreDisplayToShowCurrentScore();

    }
    /// <summary>
    ///     Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        playerLogic = Logic.GetOrCreateInstance();
        UpdateScoreDisplayToShowCurrentScore();

        hearts = new List<Heart>
        {
            heartOne,
            heartTwo,
            heartThree,
            continueHeartFour,
            continueHeartFive,
            continueHeartSix,
            continueHeartSeven,
            continueHeartEight,
            continueHeartNine,
            continueHeartTen,
            continueHeartEleven,
            continueHeartTwelve,
            continueHeartThirteen,
            continueHeartFourteen,
            continueHeartFifteen
        };

        EnableHeartsForDefaultHealth();
        SetEnabledHeartsToActive();
    }

    /// <summary>
    ///     Enables the hearts to match the Player's health.
    /// </summary>
    private void EnableHeartsForDefaultHealth()
    {
        var health = GetPlayerHealth();
        for (int iterator = 0; iterator < health; iterator++)
        {
            hearts[iterator].isEnabled = true;
        }
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
    /// <remarks>
    ///     Need to update the hearts multiple times due to AddDamage
    ///     supporting adding multiple points of damage at one time.
    /// </remarks>
    private void HandleDamage()
    {
        SetAllHeartsToNotActive();
        var health = GetPlayerHealth();
        
        for (int iterator = 0; iterator < health; iterator++)
        {
            hearts[iterator].gameObject.SetActive(true);    
        }

        if(health == 0)
        {
            GameOver();
        }
        else if(health < 0)
        {
            // This only occurs during unit testing, where extra balls hit the collider before they are destroyed.
            playerLogic.Health.ResetPlayerHealth();
            HandleDamage();
        }

        // Find the ball each time we need to use the position handler. The original ball will be destroyed when the level that
        // created it is destroyed, and if this logic is in the Start method the position handler will be null for the next level.
        var ball = Ball.Get();
        var ballPosition = ball.GetComponent<BallPositionHandler>();
        ballPosition.ResetBall();
    }

    /// <summary>
    ///     Disable all hearts temporarily, this will allow simpler code to be used to enable required hearts
    /// </summary>
    private void SetAllHeartsToNotActive()
    {
        hearts.ForEach(heart => heart.gameObject.SetActive(false));
    }
    /// <summary>
    ///     Set any heart that has been enabled for the player to be active.
    /// </summary>
    private void SetEnabledHeartsToActive()
    {
        SetAllHeartsToNotActive();

        foreach (var heart in hearts.Where(heart => heart.isEnabled))
        {
            heart.gameObject.SetActive(true);
        }
    }

    /// <summary>
    ///     Updates the heads up display to show the current score.
    /// </summary>
    private void UpdateScoreDisplayToShowCurrentScore()
    {
        playerScoreDisplay.text = GetScore().ToString();
    }
}
