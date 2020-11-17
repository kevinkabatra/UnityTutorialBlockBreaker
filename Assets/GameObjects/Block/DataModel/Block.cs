using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int damageLevel = 0;
    SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite blockOneDamage;
    [SerializeField] private Sprite blockTwoDamage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
