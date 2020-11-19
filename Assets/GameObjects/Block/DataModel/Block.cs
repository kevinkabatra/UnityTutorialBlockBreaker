using System;
using UnityEngine;

public class Block : CommonDataModel
{
    private int damageLevel = 0;
    SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite blockOneDamage;
    [SerializeField] private Sprite blockTwoDamage;

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
                Destroy(gameObject);
                break;
            default:
                throw new NotImplementedException();
        }
    }
}
