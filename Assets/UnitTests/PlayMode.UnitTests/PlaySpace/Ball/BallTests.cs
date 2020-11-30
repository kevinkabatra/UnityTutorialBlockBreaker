using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BallTests : PlayModeTestAbstract
    {
        private Ball ball;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            
            ball = Ball.Get();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            Object.Destroy(ball.gameObject);
        }

        [UnityTest]
        public IEnumerator CanFindBallWhenPrefabIsInitiated()
        {
            UnityEngine.Assertions.Assert.IsNotNull(ball);
            yield return null;
        }

        [UnityTest]
        public IEnumerator BallDoesNotLaunchOnCreation()
        {
            Assert.IsFalse(ball.hasLaunched);
            yield return null;
        }

        [UnityTest]
        public IEnumerator BallCanLaunch()
        {
            yield return LaunchBall();
            Assert.IsTrue(ball.hasLaunched);
        }

        [UnityTest]
        public IEnumerator BallCanResetAfterFirstCollisionWithBottom()
        {
            // Set launched status to true so that we can test to see that something is different after reset.
            ball.hasLaunched = true;

            yield return ResetBall();
            Assert.IsFalse(ball.hasLaunched);
        }

        [UnityTest]
        public IEnumerator BallCanLaunchAfterReset()
        {
            // Set launched status to true so that we can test to see that something is different after reset.
            ball.hasLaunched = true;

            yield return ResetBall(); // Player crashes into ground
            yield return LaunchBall(); // Player launches again

            Assert.IsTrue(ball.hasLaunched);
        }

        /// <summary>
        ///     Ball should be launched after the controller registers the Fire event.
        /// </summary>
        /// <returns></returns>
        private IEnumerator LaunchBall()
        {
            var controller = VirtualController.Get();
            controller.FireEvent();

            yield return new WaitForSeconds(0.1f);
        }

        /// <summary>
        ///     Ball should be reset after collision with Bottom.
        /// </summary>
        /// <returns></returns>
        private IEnumerator ResetBall()
        {
            var bottom = Bottom.Get();
            yield return ObjectCollider.CauseCollision(ball, bottom);
        }
    }
}
