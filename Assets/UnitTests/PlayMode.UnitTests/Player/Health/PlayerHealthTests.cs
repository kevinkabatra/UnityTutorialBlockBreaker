using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerHealthTests : PlayerAbstract
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
        public IEnumerator CanGetHealth()
        {
            // Wait until the Start method has been called.
            yield return new WaitForFixedUpdate();

            Assert.NotZero(player.GetPlayerHealth());
        }

        [UnityTest]
        public IEnumerator CanAddDamage()
        {
            // Wait until the Start method has been called.
            yield return new WaitForFixedUpdate();

            var startingHealth = player.GetPlayerHealth();

            player.AddDamage();

            Assert.Less(player.GetPlayerHealth(), startingHealth);
        }

        [UnityTest]
        public IEnumerator CanResetHealth()
        {
            var originalHealthValue = player.GetPlayerHealth();

            player.AddDamage();
            player.ResetPlayerHealth();

            Assert.AreEqual(originalHealthValue, player.GetPlayerHealth());

            yield return null;
        }
    }
}
