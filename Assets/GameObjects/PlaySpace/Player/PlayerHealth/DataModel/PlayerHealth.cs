using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject playerHealthHeartOne;
    [SerializeField] private GameObject playerHealthHeartTwo;
    [SerializeField] private GameObject playerHealthHeartThree;

    private int playerHealth = 3;
    private BallPositionHandler ball;

    private void Start()
    {
        ball = FindObjectOfType<BallPositionHandler>();
        if(ball == null)
        {
            throw new NullReferenceException(nameof(BallPositionHandler));
        }
    }

    public void HandleDamage()
    {
        playerHealth--;

        switch (playerHealth)
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

    private void GameOver()
    {
        SceneLoader.LoadGameOverScene();
    }
}
