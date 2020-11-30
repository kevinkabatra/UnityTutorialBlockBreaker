using UnityEngine;
using UnityEngine.Events;

public class BallPositionHandler : MonoBehaviour
{
    private Ball ball;
    private Paddle paddle;
    private Vector2 paddleToBallVector;
    private VirtualController controller;
    private UnityAction fireEventAction;

    public void ResetBall()
    {
        // I found through unit testing that it is possible to have this be null, probably not possible via game play.
        if(ball == null)
        {
            ball = Ball.Get();
        }

        ball.hasLaunched = false;
        controller.FireEventSubscribe(fireEventAction);
    }

    private void Start()
    {
        ball = GetComponent<Ball>();
        paddle = Paddle.Get();
        paddleToBallVector = GetPaddleToBallVector();

        fireEventAction = new UnityAction(() => { LaunchBall(); });

        controller = VirtualController.Get();
        controller.FireEventSubscribe(fireEventAction);
    }

    private void Update()
    {
        if (!ball.hasLaunched)
        {
            KeepBallAttachedToPaddle();
        }
    }

    private void LaunchBall()
    {
        // I found through unit testing that it is possible to have this be null, probably not possible via game play.
        if (ball == null)
        {
            ball = Ball.Get();
        }

        if (!ball.hasLaunched)
        {
            var ballRigidBody = GetComponent<Rigidbody2D>();
            ballRigidBody.velocity = new Vector2(0f, ball.launchSpeed);

            ball.hasLaunched = true;
            controller.FireEventUnsubscribe(fireEventAction);
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
