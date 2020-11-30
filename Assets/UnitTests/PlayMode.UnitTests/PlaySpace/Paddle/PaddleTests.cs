using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PaddleTests : PlayModeTestAbstract
    {
        private Paddle paddle;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            paddle = Paddle.Get();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            Object.Destroy(paddle.gameObject);
        }

        [UnityTest]
        public IEnumerator CanFindPaddleWhenPrefabIsInitiated()
        {
            UnityEngine.Assertions.Assert.IsNotNull(paddle);
            yield return null;
        }
    }
}
