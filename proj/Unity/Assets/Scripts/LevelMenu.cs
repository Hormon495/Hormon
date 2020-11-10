using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {

    public void Level1 ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 3));
    }

    public void Level2 ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Level3 ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void Level4 ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void Level5 ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }

    public IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        //transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(1);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }

}
