using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests : PlayerAbstract
    {
        [UnityTest]
        public IEnumerator CanFindPlayerWhenPrefabIsInitiated()
        {
            UnityEngine.Assertions.Assert.IsNotNull(player);
            yield return null;
        }
    }
}
