using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    /// <summary>
    ///     Tests that various collisions will increase the damage of the block.
    /// </summary>
    public class BlockCollisionsUpdateDamageTests : BlockTests
    {
        private Ball ball;
        private Vector3 ballOriginalPosition;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            
            ball = Ball.Get();
            ballOriginalPosition = ball.transform.position;
            ball.hasLaunched = true; // Launch ball so that it does not teleport back to the paddle.
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            Object.Destroy(ball.gameObject);
        }

        [UnityTest]
        public IEnumerator BlockHasOneDamagedAfterFirstCollisionWithBall()
        {
            yield return CauseCollision();
            
            Assert.AreEqual(oneDamage, anyBlock.GetDamage());
        }

        [UnityTest]
        public IEnumerator BlockHasTwoDamagedAfterSecondCollisionWithBall()
        {
            yield return CauseCollision();
            yield return ResetBallPosition();

            yield return CauseCollision();

            Assert.AreEqual(twoDamage, anyBlock.GetDamage());
        }

        [UnityTest]
        public IEnumerator BlockHasThreeDamagedAfterThirdCollisionWithBall()
        {
            yield return CauseCollision();
            yield return ResetBallPosition();

            yield return CauseCollision();
            yield return ResetBallPosition();

            yield return CauseCollision();

            Assert.AreEqual(threeDamage, anyBlock.GetDamage());
        }

        /// <summary>
        ///     Cause a collision between the ball and the block, then wait so that Unity can register the change.
        /// </summary>
        /// <returns></returns>
        private IEnumerator CauseCollision()
        {
            yield return ObjectCollider.CauseCollision(ball, anyBlock);
        }

        /// <summary>
        ///     Reset the position of the ball, then wait so that Unity can register the change.
        /// </summary>
        /// <returns></returns>
        private IEnumerator ResetBallPosition()
        {
            ball.transform.position = ballOriginalPosition;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
