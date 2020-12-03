using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TouchButtonTestSuite
    {
        private TouchButton button;

        [SetUp]
        public void Setup()
        {
            GameObject buttonsGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Buttons"));
            button = buttonsGameObject.transform.GetChild(0).gameObject.GetComponent<TouchButton>(); ;
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(button.gameObject);
        }

        [UnityTest]
        public IEnumerator TouchButtonInitialState()
        {
            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(button.pressedDown, false);
            Assert.AreEqual(button.CurrentState, InputManager.ButtonState.None);
        }

        [UnityTest]
        public IEnumerator TouchButtonPressedDown()
        {
            button.PressDown();

            yield return null;

            Assert.AreEqual(button.pressedDown, true);
        }

        [UnityTest]
        public IEnumerator TouchButtonRelease()
        {
            button.Release();

            yield return null;

            Assert.AreEqual(button.pressedDown, false);
        }

        [UnityTest]
        public IEnumerator TouchButtonHeld()
        {
            button.PressDown();

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(button.CurrentState, InputManager.ButtonState.Held);
        }

        [UnityTest]
        public IEnumerator TouchButtonReset()
        {
            button.PressDown();
            button.Release();

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(button.CurrentState, InputManager.ButtonState.None);
        }
    }
}
