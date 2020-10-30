using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMovementTestSuite
    {
        private Player_movement body; 

        [SetUp]
        public void Setup()
        {
            GameObject bodyGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Body"));
            body = bodyGameObject.GetComponent<Player_movement>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(body.gameObject);
        }

        [UnityTest]
        public IEnumerator PlayerMovementJump()
        {
            float initialYPos = body.transform.position.y;
            body.Jump();

            yield return new WaitForSeconds(0.1f);

            Assert.Greater(body.transform.position.y, initialYPos);
        }
    }
}
