using UnityEngine;

public class BallPositionHandler : MonoBehaviour
{
    [SerializeField] PaddleGameObject paddle;
    Vector2 paddleToBallVector;

    void Start()
    {
        paddleToBallVector = GetPaddleToBallVector();
    }

    void Update()
    {
        KeepBallAttachedToPaddle();
    }

    private Vector2 GetPaddleToBallVector()
    {
        return transform.position - paddle.transform.position;
    }

    private void KeepBallAttachedToPaddle()
    {
        var paddleCurrentPosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddleCurrentPosition + paddleToBallVector;
    }
}
