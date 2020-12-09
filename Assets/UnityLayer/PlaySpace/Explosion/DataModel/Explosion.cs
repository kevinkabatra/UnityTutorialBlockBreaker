using UnityEngine;

/// <summary>
///     The explosion when a block explodes.
/// </summary>
public class Explosion : MonoBehaviour
{
    public float delay = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
