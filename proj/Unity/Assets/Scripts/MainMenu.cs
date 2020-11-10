using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //public Animator transition;

    public static MainMenu Instance;
    public int PlayGameSceneIndex = 1;
    public int OptionsSceneIndex = 2;
    public int LoginSceneIndex = 3;


    void Awake()
    {
        Instance = this;
    }

    public void PlayGame ()
    {
    
        StartCoroutine(LoadLevel(PlayGameSceneIndex));
        Debug.Log("Play");
    }

    public void Login () 
    {
        StartCoroutine(LoadLevel(LoginSceneIndex));
        Debug.Log("Login");
    }

    public void Options () 
    {
        StartCoroutine(LoadLevel(OptionsSceneIndex));
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


