using UnityEngine;

public class AudioPlayer<T> : Common<T> where T: Object
{
    private AudioSource audioSource;
    private Ball ball;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ball = Ball.Get();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (ball.hasLaunched)
        {
            PlayAudio();
        }
    }

    private void PlayAudio()
    {
        audioSource.Play();
    }
}
