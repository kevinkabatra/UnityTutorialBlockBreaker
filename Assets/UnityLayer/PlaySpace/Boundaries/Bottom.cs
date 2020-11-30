using UnityEngine;

public class Bottom : Common<Bottom>
{
    private Level level;

    // Start is called before the first frame update
    void Start()
    {
        level = Level.Get();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        level.player.AddDamage();
    }
}
