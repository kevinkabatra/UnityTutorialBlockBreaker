using UnityEngine;

public class LoseColliderTriggerHandler : MonoBehaviour
{
    private LevelGameObject level;

    private void Start()
    {
        level = FindObjectOfType<LevelGameObject>();    
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        level.player.AddDamage();
    }
}
