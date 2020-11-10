using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }
    public void RegisterScreen() // Regester button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }

    public void LoginBackButton()
    {
        StartCoroutine(LoadLevel(0));
        Debug.Log("LoginBack");
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
