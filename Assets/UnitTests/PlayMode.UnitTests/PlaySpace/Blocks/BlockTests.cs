using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BlockTests : PlayModeTestAbstract
    {
        protected Block anyBlock;
        protected const float oneDamage = 1f;
        protected const float twoDamage = 2f;
        protected const float threeDamage = 3;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            
            anyBlock = Block.Get();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            // If testing damage, the block could have already been destroyed during the test.
            if(anyBlock != null)
            {
                Object.Destroy(anyBlock.gameObject);
            }
        }

        [UnityTest]
        public IEnumerator CanFindBlockWhenPrefabIsInitiated()
        {
            UnityEngine.Assertions.Assert.IsNotNull(anyBlock);
            yield return null;
        }

        [UnityTest]
        public IEnumerator BlockIsNotDestroyedOnCreation()
        {
            Assert.IsFalse(anyBlock.isDestroyed);
            yield return null;
        }
    }
}
