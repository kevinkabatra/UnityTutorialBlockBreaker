using UnityEngine;
using UnityEngine.Events;

public class Block : AudioPlayer<Block>
{
    public bool isDestroyed = false;

    private readonly UnityEvent blockDestroyedEvent = new UnityEvent();
    private int damageLevel = 0;
    private Level level;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite blockWithOneDamage;
    [SerializeField] private Sprite blockWithTwoDamage;
    [SerializeField] private AudioClip blockDestroyedAudioClip;

    /// <summary>
    ///     Handles the damage to the block.
    /// </summary>
    public void HandleDamage()
    {
        damageLevel++;

        switch (damageLevel)
        {
            case 1:
                spriteRenderer.sprite = blockWithOneDamage;
                break;
            case 2:
                spriteRenderer.sprite = blockWithTwoDamage;
                break;
            case 3:
                DestroyBlock();
                break;
            default:
                throw new System.NotImplementedException();
        }
    }
    
    /// <summary>
    ///     Used in unit testing only, returns the damage of the block.
    /// </summary>
    /// <returns></returns>
    public int GetDamage()
    {
        return damageLevel;
    }

    /// <summary>
    ///     Initialize object.
    /// </summary>
    protected override void Start()
    {
        base.Start();
        level = Level.Get();
        spriteRenderer = GetComponent<SpriteRenderer>();

        AddEventListeners();
    }

    /// <summary>
    ///     Handles collision.
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        HandleDamage();
    }

    /// <summary>
    ///     Adds listeners for the Block's events.
    /// </summary>
    private void AddEventListeners()
    {
        var updateBlockCountOnBlockDestructionAction = new UnityAction(() => { level.UpdateBlockCount(); });
        blockDestroyedEvent.AddListener(updateBlockCountOnBlockDestructionAction);

        var addToScoreOnBlockDestructionAction = new UnityAction(() => { level.player.AddToScore(); });
        blockDestroyedEvent.AddListener(addToScoreOnBlockDestructionAction);
    }

    /// <summary>
    ///     Destroys the block.
    /// </summary>
    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockDestroyedAudioClip, transform.position, 2f);
        isDestroyed = true;
        Destroy(gameObject);
        blockDestroyedEvent.Invoke();
    }
}
