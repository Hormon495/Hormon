using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
 
 public class LevelManager : MonoBehaviour
 {

    public TMP_Text sceneName;
    private void Awake()
     {
        GameObject[] canvasObj = GameObject.FindGameObjectsWithTag("LevelCanvas");

        if (gameObject != null)
        {
            if (canvasObj.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
     }

    void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 4) {
            sceneName.text = "Brain";
        }
        if (SceneManager.GetActiveScene().buildIndex == 5) {
            sceneName.text = "Spinal Cord";
        }
        if (SceneManager.GetActiveScene().buildIndex == 6) {
            sceneName.text = "Adrenal Glands";
        }
        if (SceneManager.GetActiveScene().buildIndex == 7) {
            sceneName.text = "Liver";
        }
    }

 }
    