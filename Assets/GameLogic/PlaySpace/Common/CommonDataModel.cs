using System;
using UnityEngine;

public class CommonDataModel : AudioPlayer
{
    protected LevelGameObject level;
    protected BallGameObject ball;

    protected new virtual void Start()
    {
        base.Start();
        
        ball = FindObjectOfType<BallGameObject>();
        level = FindObjectOfType<LevelGameObject>();

        if (ball == null || level == null)
        {
            throw new NullReferenceException();
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(ball.hasLaunched)
        {
            PlayAudio();
        }
    }
}
