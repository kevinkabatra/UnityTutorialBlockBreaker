using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    /// <summary>
    ///     Tests that various damage levels will update the visual appearance of a block.
    /// </summary>
    public class BlockDamageUpdatesSpriteTests : BlockTests
    {
        [UnityTest]
        public IEnumerator BlockSpriteAfterOneDamageIsUpdated()
        {
            anyBlock.HandleDamage();

            var blockWithOneDamage = Resources.Load<Sprite>("PlaySpace/Blocks/Sprites/BlockOneHitDamage");
            var actualSprite = GetSprite();
            
            Assert.AreEqual(blockWithOneDamage, actualSprite);
            Assert.AreEqual(oneDamage, anyBlock.GetDamage());
            yield return null;
        }

        [UnityTest]
        public IEnumerator BlockSpriteAfterTwoDamageIsUpdated()
        {
            anyBlock.HandleDamage();
            anyBlock.HandleDamage();

            var blockWithOneDamage = Resources.Load<Sprite>("PlaySpace/Blocks/Sprites/BlockTwoHitDamage");
            var actualSprite = GetSprite();
            
            Assert.AreEqual(blockWithOneDamage, actualSprite);
            Assert.AreEqual(twoDamage, anyBlock.GetDamage());
            yield return null;
        }

        [UnityTest]
        public IEnumerator BlockIsDestroyedAfterThreeDamage()
        {
            anyBlock.HandleDamage();
            anyBlock.HandleDamage();
            anyBlock.HandleDamage();

            Assert.AreEqual(threeDamage, anyBlock.GetDamage());
            Assert.IsTrue(anyBlock.isDestroyed);
            yield return null;
        }

        /// <summary>
        ///     Gets the current Sprite on the Block.
        /// </summary>
        /// <returns></returns>
        private Sprite GetSprite()
        {
            var spriteRenderer = anyBlock.GetComponent<SpriteRenderer>();
            var sprite = spriteRenderer.sprite;

            return sprite;
        }
    }
}
