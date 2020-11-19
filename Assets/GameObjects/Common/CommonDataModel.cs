using UnityEngine;

public class CommonDataModel : AudioPlayer
{
    protected BallGameObject ball;

    protected new virtual void Start()
    {
        base.Start();
        ball = FindObjectOfType<BallGameObject>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(ball.hasLaunched)
        {
            PlayAudio();
        }
    }
}
