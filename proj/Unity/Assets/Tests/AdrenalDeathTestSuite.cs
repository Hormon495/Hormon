using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class AdrenalDeathTestSuite
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
        public IEnumerator PlayerMovementDeath()
        {
            Vector3 initPos = body.transform.position;

            var triggerGameObject = new GameObject("Trigger");
            triggerGameObject.transform.position = Vector3.zero;
            triggerGameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            var triggerObject = triggerGameObject.AddComponent<Player_movement>() as Player_movement;
            var triggerBoxCollider2D = triggerGameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
            var triggerRigidBody2D = triggerGameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
            triggerGameObject.gameObject.tag = "DeathBoundary";
            triggerBoxCollider2D.isTrigger = true;


            body.transform.position = triggerGameObject.transform.position;

            yield return new WaitForSeconds(.5f);

            Assert.IsTrue(triggerObject.IsTriggered);
        }
    }
}
