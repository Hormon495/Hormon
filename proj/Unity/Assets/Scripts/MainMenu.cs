using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    //public Animator transition;

    public void PlayGame ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Debug.Log("Play");
    }

    public void Options () 
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
        Debug.Log("Options");
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


