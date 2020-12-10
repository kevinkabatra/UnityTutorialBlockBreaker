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
        PreventCollisionsWithBall();
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    private void PreventCollisionsWithBall()
    {
        var ballCollider = Ball.Get().GetComponent<Collider2D>();
        var thisCollider = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(ballCollider, thisCollider);
    }
}
