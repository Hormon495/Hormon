using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {

    public void Back ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
        Debug.Log("Back");
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