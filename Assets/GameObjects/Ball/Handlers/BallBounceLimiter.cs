using UnityEngine;

/// <summary>
///     Limits the ball from moving too slow or too fast, this helps ensure an enjoyable game.
/// </summary>
public class BallBounceLimiter : MonoBehaviour
{
    private BallGameObject ball;

    /// <summary>
    ///     Initializer
    /// </summary>
    private void Start()
    {
        ball = GetComponent<BallGameObject>();
    }
    
    /// <summary>
    ///     Event handler for the ball colliding with another object.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ball.hasLaunched)
        {
            AdjustBallSpeed();
        }
    }

    /// <summary>
    ///     Generic method to adjust the speed of the ball.
    /// </summary>
    private void AdjustBallSpeed()
    {
        var ballRigidBody = GetComponent<Rigidbody2D>();
        AdjustBallSpeedHandler(ballRigidBody, ball.launchSpeed);
    }

    /// <summary>
    ///     Handler that will adjust the X and Y velocities of the ball.
    /// </summary>
    /// <param name="ballRigidBody">The ball.</param>
    /// <param name="speedToAdjustTo">The speed to adjust to.</param>
    private void AdjustBallSpeedHandler(Rigidbody2D ballRigidBody, float speedToAdjustTo)
    {
        AdjustBallSpeedHandlerForX(ballRigidBody, speedToAdjustTo);
        AdjustBallSpeedHandlerForY(ballRigidBody, speedToAdjustTo);
    }

    /// <summary>
    ///     Handler that will adjust the X velocity of the ball.
    /// </summary>
    /// <param name="ballRigidBody">The ball.</param>
    /// <param name="speedToAdjustTo">The speed to adjust to.</param>
    private void AdjustBallSpeedHandlerForX(Rigidbody2D ballRigidBody, float speedToAdjustTo)
    {
        // If velocity is equal to 0 the ball is going in a straight vertical line, and therefore its x value should not be adjusted.
        if (ballRigidBody.velocity.x != 0)
        {
            // If ball is leaning right
            if (ballRigidBody.velocity.x > 0.5)
            {
                var positiveSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo);
                if (ballRigidBody.velocity.x < positiveSpeedToAdjustTo)
                {
                    ballRigidBody.velocity = new Vector2(positiveSpeedToAdjustTo, ballRigidBody.velocity.y);
                }
            }
            // If ball is leaning left
            else if (ballRigidBody.velocity.x < -0.5)
            {
                var negativeSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo) * -1;
                if (ballRigidBody.velocity.x > negativeSpeedToAdjustTo)
                {
                    ballRigidBody.velocity = new Vector2(negativeSpeedToAdjustTo, ballRigidBody.velocity.y);
                }
            }
        }
    }

    /// <summary>
    ///     Handler that will adjust the Y velocity of the ball.
    /// </summary>
    /// <param name="ballRigidBody">The ball.</param>
    /// <param name="speedToAdjustTo">The speed to adjust to.</param>
    private void AdjustBallSpeedHandlerForY(Rigidbody2D ballRigidBody, float speedToAdjustTo)
    {
        // If ball is heading upwards
        if (ballRigidBody.velocity.y > 0)
        {
            float positiveSpeedToAdjustTo;
            if(ballRigidBody.velocity.y > ball.maxSpeed)
            {
                positiveSpeedToAdjustTo = System.Math.Abs(ball.maxSpeed);
            }
            else if (ballRigidBody.velocity.y < speedToAdjustTo)
            {
                positiveSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo);
            }
            else
            {
                return;
            }
            
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, positiveSpeedToAdjustTo);
        }

        // If ball is heading downwards
        else if (ballRigidBody.velocity.y < 0)
        {
            float negativeSpeedToAdjustTo;
            if(ballRigidBody.velocity.y < ball.maxSpeed)
            {
                negativeSpeedToAdjustTo = System.Math.Abs(ball.maxSpeed) * -1;
            }
            else if(ballRigidBody.velocity.y > speedToAdjustTo)
            {
                negativeSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo) * -1;
            }
            else
            {
                return;
            }
            
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, negativeSpeedToAdjustTo);
        }
    }
}
