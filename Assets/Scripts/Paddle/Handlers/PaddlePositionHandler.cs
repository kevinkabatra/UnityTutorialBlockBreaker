using UnityEngine;

public class PaddlePositionHandler : MonoBehaviour
{
    [SerializeField] const float screenWidthInUnits = 16f;

    // Update is called once per frame
    void Update()
    {
        var updatedPositionX = AdjustPositionToKeepPaddleOnScreen(GetMousePositionInUnits());
        var newPaddlePosition = new Vector2(updatedPositionX, transform.position.y);
        transform.position = newPaddlePosition;
    }

    private float GetMousePositionInUnits()
    {
        var mousePosition = Input.mousePosition.x / Screen.width;
        var mousePositionInUnits = mousePosition * screenWidthInUnits;
        return mousePositionInUnits;
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
