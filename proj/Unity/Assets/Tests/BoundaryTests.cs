using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BoundaryTests
    {
        private Player_movement body;
        private EdgeCollider2D edgeCollider2D;
        private GameObject bodyGameObject;

        [SetUp]
        public void Setup()
        {
            bodyGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Body"));
            body = bodyGameObject.AddComponent<Player_movement>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(body.gameObject);
        }

        [UnityTest]
        public IEnumerator BrainCollision()
        {
            var gameObject = new GameObject();
            edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
            List<Vector2> points = new List<Vector2> {
               new Vector2( -0.5f,  0f),  new Vector2( 5.483756f,  -0.07626438f),  new Vector2( 11.248056f,  -2.0437698f),  new Vector2( 15.409069f,  -3.0040493f),  new Vector2( 17.428743f,  -3.1149588f),  new Vector2( 19.989761f,  -4.6313076f),  new Vector2( 21.397114f,  -6.777884f),  new Vector2( 24.340788f,  -8.776867f),  new Vector2( 26.798933f,  -11.833279f),  new Vector2( 28.19651f,  -13.615391f),  new Vector2( 28.535725f,  -16.618504f),  new Vector2( 28.231966f,  -20.188692f),  new Vector2( 26.199703f,  -22.875149f),  new Vector2( 22.276999f,  -23.83761f),  new Vector2( 18.70648f,  -24.240894f),  new Vector2( 15.63173f,  -24.5252f),
               new Vector2( 13.295993f,  -24.790375f),  new Vector2( 10.786539f,  -26.39249f),  new Vector2( 9.622611f,  -27.564684f),  new Vector2( 9.701511f,  -29.189121f),  new Vector2( 8.742065f,  -30.377363f),  new Vector2( 6.766983f,  -32.237522f),  new Vector2( 2.0947068f,  -33.488556f),  new Vector2( -0.8004205f,  -33.61819f),  new Vector2( -4.776636f,  -33.115807f),  new Vector2( -7.457345f,  -32.082535f),  new Vector2( -10.233053f,  -30.676975f),  new Vector2( -15.62582f,  -30.933088f),  new Vector2( -19.89461f,  -29.842686f),  new Vector2( -23.606386f,  -28.15508f),  new Vector2( -24.82372f,  -27.595417f),  new Vector2( -26.149658f,  -27.13031f),
               new Vector2( -26.50234f,  -25.509075f),  new Vector2( -27.91491f,  -23.834694f),  new Vector2( -29.236362f,  -22.041803f),  new Vector2( -29.570572f,  -20.122387f),  new Vector2( -29.373262f,  -16.976345f),  new Vector2( -30.150871f,  -15.102986f),  new Vector2( -30.09556f,  -13.564009f),  new Vector2( -29.240538f,  -11.71546f),
               new Vector2( -27.721586f,  -10.386864f),  new Vector2( -27.548561f,  -8.56397f),  new Vector2( -25.219885f,  -5.640544f),  new Vector2( -22.35447f,  -3.2385902f),  new Vector2( -17.577059f,  -1.3576488f),  new Vector2( -14.220031f,  -0.39365768f),  new Vector2( -10.374317f,  -0.50925255f),  new Vector2( -4.3615274f,  0.07686424f),
               new Vector2( -0.52996445f,  0.028679848f)
           };
            edgeCollider2D.SetPoints(points);
            edgeCollider2D.tag = "Ground";

            yield return new WaitForSeconds(2);

            Assert.IsTrue(body.isGrounded);
        }
}
