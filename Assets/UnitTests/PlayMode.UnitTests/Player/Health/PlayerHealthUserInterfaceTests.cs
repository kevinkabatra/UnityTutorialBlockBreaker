using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerHealthUserInterfaceTests : PlayerAbstract
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
        public IEnumerator HealthHeartsAreActiveOnCreation()
        {
            Assert.True(player.heartOne.gameObject.activeSelf);
            Assert.True(player.heartTwo.gameObject.activeSelf);
            Assert.True(player.heartThree.gameObject.activeSelf);
            yield return null;
        }

        [UnityTest]
        public IEnumerator OneHeartDisabledAfterOneDamage()
        {
            player.AddDamage();

            var expectedHealth = 2;
            Assert.AreEqual(expectedHealth, player.GetPlayerHealth());

            Assert.False(player.heartThree.gameObject.activeSelf);
            yield return null;

        }

        [UnityTest]
        public IEnumerator TwoHeartsDisabledAfterTwoDamage()
        {
            const int damageToAdd = 2;
            player.AddDamage(damageToAdd);

            var expectedHealth = 1;
            Assert.AreEqual(expectedHealth, player.GetPlayerHealth());

            Assert.False(player.heartThree.gameObject.activeSelf);
            Assert.False(player.heartTwo.gameObject.activeSelf);

            yield return null;
        }

        [UnityTest]
        public IEnumerator ThreeHeartsDisabledAfterThreeDamage()
        {
            const int damageToAdd = 3;
            player.AddDamage(damageToAdd);

            var expectedHealth = 0;
            Assert.AreEqual(expectedHealth, player.GetPlayerHealth());

            Assert.False(player.heartThree.gameObject.activeSelf);
            Assert.False(player.heartTwo.gameObject.activeSelf);
            Assert.False(player.heartOne.gameObject.activeSelf);

            yield return null;
        }

        [UnityTest]
        public IEnumerator HeartsEnabledAfterReset()
        {
            const int damageToAdd = 3;
            player.AddDamage(damageToAdd);

            var expectedHealth = 0;
            Assert.AreEqual(expectedHealth, player.GetPlayerHealth());

            player.ResetPlayerHealth();

            Assert.True(player.heartOne.gameObject.activeSelf);
            Assert.True(player.heartTwo.gameObject.activeSelf);
            Assert.True(player.heartThree.gameObject.activeSelf);

            yield return null;
        }
    }
}
