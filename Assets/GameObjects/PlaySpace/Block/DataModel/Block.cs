using System;
using UnityEngine;

public class Block : CommonDataModel
{
    public bool isDestroyed = false;

    private int damageLevel = 0;
    SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite blockOneDamage;
    [SerializeField] private Sprite blockTwoDamage;
    [SerializeField] private AudioClip blockDestroyedAudioClip;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        HandleDamage();
    }

    private void HandleDamage()
    {
        damageLevel++;

        switch(damageLevel)
        {
            case 1:
                spriteRenderer.sprite = blockOneDamage; 
                break;
            case 2:
                spriteRenderer.sprite = blockTwoDamage;
                break;
            case 3:
                DestroyBlock();
                break;
            default:
                throw new NotImplementedException();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockDestroyedAudioClip, transform.position, 2f);
        Destroy(gameObject);
        isDestroyed = true;
        
        level.player.AddToScore();
        level.UpdateBlockCount();
    }
}
