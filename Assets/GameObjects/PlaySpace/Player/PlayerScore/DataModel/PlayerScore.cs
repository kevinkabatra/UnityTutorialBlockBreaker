using BlockBreaker.Logic.Player.PlayerScore;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour, IPlayerScore
{
    [SerializeField] private TextMeshProUGUI playerScoreDisplay;

    private IPlayerScore playerScoreLogic;

    private void Start()
    {
        playerScoreLogic = new BlockBreaker.Logic.Player.PlayerScore.PlayerScore();    
    }

    public void AddToScore(int points = 1)
    {
        playerScoreLogic.AddToScore(points);
        playerScoreDisplay.text = GetScore().ToString();
    }

    public int GetScore()
    {
        return playerScoreLogic.GetScore();
    }
}
