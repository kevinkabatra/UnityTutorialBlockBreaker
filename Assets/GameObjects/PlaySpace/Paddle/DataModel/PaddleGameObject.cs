using UnityEngine;

/// <summary>
///     Data model to enable attaching paddle to other game objects.
/// </summary>
public class PaddleGameObject : CommonDataModel
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
