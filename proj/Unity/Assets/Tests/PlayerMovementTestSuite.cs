using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;

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

        [UnityTest]
        public IEnumerator PlayerMovementFlipPlayer()
        {
            float intitialXPos = body.gameObject.transform.localScale.x;
            bool initialDirection = (intitialXPos < 0) ? true : false;
            body.FlipPlayer();

            yield return new WaitForSeconds(0.1f);

            float newXPos = body.gameObject.transform.localScale.x;
            bool newDirection = (newXPos < 0) ? true : false;
            Assert.AreNotEqual(newDirection, initialDirection);
        }

        [UnityTest]
        public IEnumerator PlayerMovementFlipPlayerTwice()
        {
            float intitialXPos = body.gameObject.transform.localScale.x;
            
            body.FlipPlayer();
            body.FlipPlayer();

            yield return new WaitForSeconds(0.1f);

            float newXPos = body.gameObject.transform.localScale.x;
            Assert.AreEqual(intitialXPos, newXPos);
        }

        [UnityTest]
        public IEnumerator PlayerMovementOnTriggerEnter2DRespawnPoint()
        {
            Vector3 testRespawnPoint = body.transform.position;
            yield return null;

            Assert.AreEqual(testRespawnPoint.x, body.respawnPoint.x);
            Assert.Less(testRespawnPoint.y - 1, body.respawnPoint.y);
            Assert.Greater(testRespawnPoint.y + 1, body.respawnPoint.y);
        }

        [UnityTest]
        public IEnumerator PlayerMovementOnTriggerEnter2DBoundary()
        {
            Vector3 respawnPoint = body.transform.position;

            // set tag from list of available tags
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            SerializedProperty tagsProp = tagManager.FindProperty("tags");
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(0);
            for (int i = 0; i < tagsProp.arraySize; i++)
            {
                t = tagsProp.GetArrayElementAtIndex(i);
                if (t.stringValue.Equals("DeathBoundary")) { break; }
            }
            
            GameObject colliderGameObject = new GameObject();
            BoxCollider2D testCollider2D = colliderGameObject.AddComponent<BoxCollider2D>();
            testCollider2D.gameObject.tag = t.stringValue;

            yield return new WaitForSeconds(1f);

            body.OnTriggerEnter2D(testCollider2D);
            Vector2 newPoint = body.transform.position;

            Assert.AreEqual(respawnPoint.x, newPoint.x);
            
            //tolerance for gravity
            Assert.Less(respawnPoint.y - 1, newPoint.y);
            Assert.Greater(respawnPoint.y + 1, newPoint.y);
        }

        [UnityTest]
        public IEnumerator PlayerMovementOnTriggerEnter2DAdrenalTeleport()
        {
            // set tag from list of available tags
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            SerializedProperty tagsProp = tagManager.FindProperty("tags");
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(0);
            for (int i = 0; i < tagsProp.arraySize; i++)
            {
                t = tagsProp.GetArrayElementAtIndex(i);
                if (t.stringValue.Equals("AdrenalTeleport")) { break; }
            }

            GameObject colliderGameObject = new GameObject();
            BoxCollider2D testCollider2D = colliderGameObject.AddComponent<BoxCollider2D>();
            testCollider2D.gameObject.tag = t.stringValue;

            yield return new WaitForSeconds(1f);

            body.OnTriggerEnter2D(testCollider2D);
            Vector3 newPoint = body.transform.position;

            Assert.AreEqual(newPoint, body.teleport);
            /*Assert.AreEqual(respawnPoint.x, newPoint.x);

            //tolerance for gravity
            Assert.Less(respawnPoint.y - 1, newPoint.y);
            Assert.Greater(respawnPoint.y + 1, newPoint.y);*/
        }
    }
}
