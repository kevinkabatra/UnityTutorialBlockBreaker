using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerScoreTests : PlayerAbstract
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }

        [UnityTest]
        public IEnumerator CanAddToScore()
        {
            var initialScore = 0;

            player.AddToScore();
            var updatedScore = player.GetScore();

            Assert.AreEqual(updatedScore, initialScore + 1);

            yield return null;
        }

        [UnityTest]
        public IEnumerator CanAddSpecifiedPointsToScore()
        {
            var initialScore = 0;

            var pointsToAdd = 2;
            player.AddToScore(pointsToAdd);
            var updatedScore = player.GetScore();

            Assert.AreEqual(updatedScore, initialScore + pointsToAdd);

            yield return null;
        }

        [UnityTest]
        public IEnumerator CanResetScore()
        {
            var initialScore = 0;

            player.AddToScore();
            player.ResetScore();

            var resetScore = player.GetScore();

            Assert.AreEqual(initialScore, resetScore);

            yield return null;
        }
    }
}
