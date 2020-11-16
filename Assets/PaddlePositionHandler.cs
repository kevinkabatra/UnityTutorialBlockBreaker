using UnityEngine;

public class PaddlePositionHandler : MonoBehaviour
{
    [SerializeField] const float screenWidthInUnits = 16f;

    // Update is called once per frame
    void Update()
    {
        var mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        var newPaddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        transform.position = newPaddlePosition;
    }
}
