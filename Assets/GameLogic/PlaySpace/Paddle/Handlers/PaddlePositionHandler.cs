using UnityEngine;

public class PaddlePositionHandler : MonoBehaviour
{
    [SerializeField] const float screenWidthInUnits = 16f;
    
    // Update is called once per frame
    void Update()
    {
        var updatedPositionX = AdjustPositionToKeepPaddleOnScreen(GetPositionInUnits());
        var newPaddlePosition = new Vector2(updatedPositionX, transform.position.y);
        transform.position = newPaddlePosition;
    }

    private float GetPositionInUnits()
    {
        float inputPosition = 0f;
        if(Input.touchSupported && Input.touchCount != 0)
        {
            inputPosition = Input.GetTouch(0).position.x;
        }

        if(inputPosition == 0f)
        {
            inputPosition = Input.mousePosition.x;
        }
        
        var inputPositionInUnits = (inputPosition / Screen.width) * screenWidthInUnits;
        return inputPositionInUnits;
    }

    private float AdjustPositionToKeepPaddleOnScreen(float expectedPosition)
    {
        var worldUnitsToCenterPointOfSprite = GetWorldUnitsToCenterPointOfSprite();
        var minimumPositionToKeepPaddleOnScreen = 0 + worldUnitsToCenterPointOfSprite;
        var maximumPositionToKeepPaddleOnScreen = screenWidthInUnits - worldUnitsToCenterPointOfSprite;
        var actualPosition = Mathf.Clamp(expectedPosition, minimumPositionToKeepPaddleOnScreen, maximumPositionToKeepPaddleOnScreen);
        return actualPosition;
    }

    private float GetWorldUnitsToCenterPointOfSprite()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var sprite = spriteRenderer.sprite;
        var worldUnitsToCenterPointOfSprite = sprite.rect.center.x / sprite.pixelsPerUnit;
        return worldUnitsToCenterPointOfSprite;
    }
}
