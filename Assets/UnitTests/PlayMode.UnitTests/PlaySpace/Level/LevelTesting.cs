using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LevelTesting : PlayModeTestAbstract
    {
        private Level level;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            level = Level.Get();
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();

            Object.Destroy(level.gameObject);
        }

        [UnityTest]
        public IEnumerator CanFindLevelWhenPrefabIsInitiated()
        {
            UnityEngine.Assertions.Assert.IsNotNull(level);
            yield return null;
        }

        [UnityTest]
        public IEnumerator CanFindNumberOfBlocks()
        {
            var blockCountPriorToUpdate = level.GetCurrentBlockCount();
            level.UpdateBlockCount();

            Assert.AreNotEqual(blockCountPriorToUpdate, level.GetCurrentBlockCount());
            yield return null;
        }

        [UnityTest]
        public IEnumerator BlockCountIsUpdatedAfterBlockDestruction()
        {
            // Find all of the blocks that were initialized.
            level.UpdateBlockCount();
            var blockCountPriorToDestruction = level.GetCurrentBlockCount();

            // Destroy a random block, poor guy.
            var anyBlock = GameObject.FindObjectOfType<Block>();
            anyBlock.HandleDamage();
            anyBlock.HandleDamage();
            anyBlock.HandleDamage();
            Assert.IsTrue(anyBlock.isDestroyed);

            // Wait for destruction to finish. Unity is rather sleepy.
            yield return new WaitForSeconds(0.1f);

            Assert.Greater(blockCountPriorToDestruction, level.GetCurrentBlockCount());
        }

        [UnityTest]
        public IEnumerator LevelHasPlayerWhenPrefabIsInitiated()
        {
            UnityEngine.Assertions.Assert.IsNotNull(level.player);
            yield return null;
        }
    }
}
