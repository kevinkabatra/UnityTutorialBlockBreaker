using UnityEngine;

public class CommonDataModel : MonoBehaviour
{
    protected BallGameObject ball;

    protected virtual void Start()
    {
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
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
