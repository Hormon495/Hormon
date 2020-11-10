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


        [UnityTest]
        public IEnumerator SpineCollision()
        {
            var gameObject = new GameObject();
            edgeCollider2D = gameObject.AddComponent<EdgeCollider2D>();
            List<Vector2> points = new List<Vector2> {
                new Vector2(-0.42338628f, -0.33771434f), new Vector2(-0.27438346f, -0.27500242f), new Vector2(-0.2181394f, -0.21217895f), new Vector2(-0.22508667f, -0.07866065f), new Vector2(-0.20784585f, -0.048826963f), new Vector2(-0.17483893f, -0.029122554f), new Vector2(-0.19026527f, 0.0075134914f), new Vector2(-0.16010085f, 0.10201358f),
                new Vector2(-0.11279889f, 0.1204476f), new Vector2(-0.09608494f, 0.17076856f), new Vector2(-0.05489932f, 0.35008773f), new Vector2(-0.037464887f, 0.35224938f), new Vector2(-0.03552404f, 0.39520073f), new Vector2(-0.018119633f, 0.40756997f), new Vector2(-0.032724537f, 0.44011682f), new Vector2(-0.005022198f, 0.51748574f),
                new Vector2(0.020055555f, 0.5197035f), new Vector2(0.017560877f, 0.54796743f), new Vector2(0.051633097f, 0.55458343f), new Vector2(0.052665137f, 0.61078185f), new Vector2(0.07225179f, 0.6560588f), new Vector2(0.083806925f, 0.7079313f), new Vector2(0.07909122f, 0.7679362f), new Vector2(0.097843595f, 0.7684508f),
                new Vector2(0.10023857f, 0.8233896f), new Vector2(0.09754634f, 0.8807752f), new Vector2(0.11253804f, 0.8856836f), new Vector2(0.11030191f, 0.919717f), new Vector2(0.13249327f, 0.94349885f), new Vector2(0.22289766f, 1.200381f), new Vector2(0.21521416f, 1.25941f), new Vector2(0.22004128f, 1.2962172f), new Vector2(0.22172804f, 1.3536625f), new Vector2(0.26825726f, 1.3819343f),
                new Vector2(0.25668982f, 1.4386154f), new Vector2(0.2562974f, 1.5087137f), new Vector2(0.28076357f, 1.5828987f), new Vector2(0.30149722f, 1.6062098f), new Vector2(0.29584768f, 1.6441171f), new Vector2(0.29306418f, 1.714479f), new Vector2(0.32370237f, 1.7913812f), new Vector2(0.29623163f, 1.8702084f),
                new Vector2(0.29460502f, 2.037129f), new Vector2(0.26148605f, 2.1153977f), new Vector2(0.26205605f, 2.1848114f), new Vector2(0.2750173f, 2.234324f), new Vector2(0.25557265f, 2.288236f), new Vector2(0.22420849f, 2.338448f), new Vector2(0.22109884f, 2.378279f), new Vector2(0.20219669f, 2.3951385f),
                new Vector2(0.13814816f, 2.5204036f), new Vector2(0.15183538f, 2.542648f), new Vector2(0.0764623f, 2.6586378f), new Vector2(0.053137586f, 2.6713958f), new Vector2(0.06331987f, 2.709558f), new Vector2(0.03109657f, 2.7299592f), new Vector2(-0.021132883f, 2.8372211f), new Vector2(-0.030155722f, 2.9017007f),
                new Vector2(-0.091898374f, 3.0338783f), new Vector2(-0.18492022f, 3.1098447f), new Vector2(-0.18594182f, 3.1573582f), new Vector2(-0.21100552f, 3.1561923f), new Vector2(-0.24149248f, 3.2130492f), new Vector2(-0.26501912f, 3.2738473f), new Vector2(-0.29456505f, 3.305498f), new Vector2(-0.3123181f, 3.347181f),
                new Vector2(-0.3286137f, 3.3999684f), new Vector2(-0.32440424f, 3.474977f), new Vector2(-0.3258425f, 3.5172489f), new Vector2(-0.34285524f, 3.5190578f), new Vector2(-0.3463142f, 3.6322665f), new Vector2(-0.37661546f, 3.6697261f), new Vector2(-0.41834408f, 3.7224379f), new Vector2(-0.41724092f, 3.793549f),
                new Vector2(-0.43248317f, 3.7999723f), new Vector2(-0.4494484f, 3.842824f), new Vector2(-0.4633612f, 3.8604496f), new Vector2(-0.4658556f, 3.8990784f), new Vector2(-0.4932365f, 3.9068506f), new Vector2(-0.4926115f, 3.9727147f), new Vector2(-0.5158235f, 4.050565f), new Vector2(-0.51110876f, 4.1050177f),
                new Vector2(-0.5370481f, 4.1231995f), new Vector2(-0.5422942f, 4.192922f), new Vector2(-0.5741247f, 4.198603f), new Vector2(-0.60194224f, 4.354571f), new Vector2(-0.6270448f, 4.492844f), new Vector2(-0.63064253f, 4.593698f), new Vector2(-0.6147651f, 4.651174f), new Vector2(-0.61504054f, 4.7695136f),
                new Vector2(-0.576317f, 4.930582f), new Vector2(-0.5747146f, 4.9980946f), new Vector2(-0.56183106f, 5.0311813f), new Vector2(-0.56533134f, 5.12007f), new Vector2(-0.5960586f, 5.260877f), new Vector2(-0.6414772f, 5.3357735f), new Vector2(-0.6393498f, 5.40661f)
        };
            edgeCollider2D.SetPoints(points);
            edgeCollider2D.tag = "Ground";

            yield return new WaitForSeconds(4);
            Assert.IsTrue(body.isGrounded);
            
        }
    }
}
