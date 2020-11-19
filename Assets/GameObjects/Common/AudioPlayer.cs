using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    protected AudioSource audioSource;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected void PlayAudio()
    {
        audioSource.Play();
    }
}
