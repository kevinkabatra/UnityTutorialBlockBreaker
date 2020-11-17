using UnityEngine;

public class BallPositionHandler : MonoBehaviour
{
    [SerializeField] PaddleGameObject paddle;

    private BallGameObject ball;
    private Vector2 paddleToBallVector;

    void Start()
    {
        ball = GetComponent<BallGameObject>();
        paddleToBallVector = GetPaddleToBallVector();
    }

    void Update()
    {
        if(!ball.hasLaunched)
        {
            KeepBallAttachedToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick()
    {
        var leftMouseButton = 0;
        if (Input.GetMouseButtonDown(leftMouseButton))
        {
            var ballRigidBody = GetComponent<Rigidbody2D>();
            ballRigidBody.velocity = new Vector2(0f, ball.launchSpeed);

            ball.hasLaunched = true;
        }
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
