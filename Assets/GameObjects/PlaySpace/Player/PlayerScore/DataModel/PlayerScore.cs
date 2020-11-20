using System;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScoreDisplay;

    private int score;

    private void Start()
    {
        if (playerScoreDisplay == null)
        {
            throw new NullReferenceException(nameof(playerScoreDisplay));
        }
    }

    public void AddPointsToScore(int points = 1)
    {
        score += points;
        playerScoreDisplay.text = score.ToString();
    }
}
