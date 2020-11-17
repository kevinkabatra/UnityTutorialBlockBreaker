using UnityEngine;

public class BallPositionHandler : MonoBehaviour
{
    [SerializeField] PaddleGameObject paddle;
    [SerializeField] float ballLaunchSpeed = 10f;

    private Vector2 paddleToBallVector;
    private bool ballLaunched = false;

    void Start()
    {
        paddleToBallVector = GetPaddleToBallVector();
    }

    void Update()
    {
        if(!ballLaunched)
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
            ballRigidBody.velocity = new Vector2(0f, ballLaunchSpeed);

            ballLaunched = true;
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
