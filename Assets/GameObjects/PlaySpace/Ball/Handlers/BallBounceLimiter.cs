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
            var speedAdjustment = 0f;

            // If ball is leaning rightt
            if (ballRigidBody.velocity.x > 0.5)
            {
                var positiveMaxLeftRightSpeed = System.Math.Abs(ball.maxLeftRightSpeed);
                var positiveSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo);

                if (ballRigidBody.velocity.x > positiveMaxLeftRightSpeed)
                {
                    speedAdjustment = positiveMaxLeftRightSpeed;
                }
                else if (ballRigidBody.velocity.x < positiveSpeedToAdjustTo)
                {
                    speedAdjustment = positiveSpeedToAdjustTo;
                }
                else
                {
                    return;
                }
            }
            // If ball is leaning left
            else if (ballRigidBody.velocity.x < -0.5)
            {
                var negativeMaxLeftRightSpeed = System.Math.Abs(ball.maxLeftRightSpeed) * -1;
                var negativeSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo) * -1;

                if (ballRigidBody.velocity.x < negativeMaxLeftRightSpeed)
                {
                    speedAdjustment = negativeMaxLeftRightSpeed;
                }
                else if (ballRigidBody.velocity.x < negativeSpeedToAdjustTo)
                {
                    speedAdjustment = negativeSpeedToAdjustTo;
                }
                else
                {
                    return;
                }

                if (ballRigidBody.velocity.x > negativeSpeedToAdjustTo)
                {
                    ballRigidBody.velocity = new Vector2(negativeSpeedToAdjustTo, ballRigidBody.velocity.y);
                }
            }

            if (speedAdjustment != 0f)
            {
                ballRigidBody.velocity = new Vector2(speedAdjustment, ballRigidBody.velocity.y);
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
        var speedAdjustment = 0f;

        // If ball is heading upwards
        if (ballRigidBody.velocity.y > 0)
        {
            var positiveMaxUpwardSpeed = System.Math.Abs(ball.maxUpwardSpeed);
            var positiveSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo);

            if (ballRigidBody.velocity.y > positiveMaxUpwardSpeed)
            {
                speedAdjustment = System.Math.Abs(positiveMaxUpwardSpeed);
            }
            else if (ballRigidBody.velocity.y < positiveSpeedToAdjustTo)
            {
                speedAdjustment = System.Math.Abs(positiveSpeedToAdjustTo);
            }
            else
            {
                return;
            }                        
        }
        // If ball is heading downwards
        else if (ballRigidBody.velocity.y < 0)
        {
            var negativeMaxDownwardSpeed = System.Math.Abs(ball.maxDownwardSpeed) * -1;
            var negativeSpeedToAdjustTo = System.Math.Abs(speedToAdjustTo) * -1;

            if(ballRigidBody.velocity.y < negativeMaxDownwardSpeed)
            {
                speedAdjustment = negativeMaxDownwardSpeed;
            }
            else if(ballRigidBody.velocity.y > negativeSpeedToAdjustTo)
            {
                speedAdjustment = negativeSpeedToAdjustTo;
            }
            else
            {
                return;
            }
        }

        if(speedAdjustment != 0f)
        {
            ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, speedAdjustment);
        }
    }
}
