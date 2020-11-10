using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SceneTestSuite
    {

        [UnityTest]
        public IEnumerator MainMenuIndex() 
        {
            SceneManager.LoadScene("MainMenu");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);

        }

        [UnityTest]
        public IEnumerator LevelMenuIndex() 
        {
            SceneManager.LoadScene("LevelMenu");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);

        }

        [UnityTest]
        public IEnumerator OptionsMenuIndex() 
        {
            SceneManager.LoadScene("OptionsMenu");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(2, SceneManager.GetActiveScene().buildIndex);

        }

        [UnityTest]
        public IEnumerator LoginIndex() 
        {
            SceneManager.LoadScene("Login");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(3, SceneManager.GetActiveScene().buildIndex);

        }

        [UnityTest]
        public IEnumerator BrainIndex() 
        {
            SceneManager.LoadScene("Main");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(4, SceneManager.GetActiveScene().buildIndex);

        }

        [UnityTest]
        public IEnumerator SpinalCordIndex() 
        {
            SceneManager.LoadScene("Spinal Cord");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(5, SceneManager.GetActiveScene().buildIndex);

        }

        [UnityTest]
        public IEnumerator AdrenalGlandIndex() 
        {
            SceneManager.LoadScene("AdrenalGlands");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(6, SceneManager.GetActiveScene().buildIndex);

        }

        [UnityTest]
        public IEnumerator LiverIndex() 
        {
            SceneManager.LoadScene("Liver");

            yield return new WaitForSeconds(1);

            Assert.AreEqual(7, SceneManager.GetActiveScene().buildIndex);

        }

    }
}