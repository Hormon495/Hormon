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
    public class MenuTestSuite
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

    }
}