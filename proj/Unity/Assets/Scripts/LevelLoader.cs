using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

	public Animator transition;

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetMouseButtonDown(0)) 
    	{
    		LoadNextLevel();
    	}      
    }

   	public void LoadNextLevel()
   	{
   		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
   	}

   	public IEnumerator LoadLevel(int levelIndex)
   	{
   		//Play animation
   		transition.SetTrigger("Start");

   		//Wait
   		yield return new WaitForSeconds(1);

   		//Load scene
   		SceneManager.LoadScene(levelIndex);
   	}
}
