using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
 public class MusicManager : MonoBehaviour
 {
     private void Awake()
     {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        if (gameObject != null)
        {
            if (musicObj.Length > 2)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
     }
 }