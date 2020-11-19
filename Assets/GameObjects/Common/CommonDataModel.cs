using UnityEngine;

public class CommonDataModel : MonoBehaviour
{
    protected BallGameObject ball;

    private AudioSource audioSource;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ball = FindObjectOfType<BallGameObject>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(ball.hasLaunched)
        {
            PlayAudio();
        }
    }

    private void PlayAudio()
    {
        audioSource.Play();
    }
}
