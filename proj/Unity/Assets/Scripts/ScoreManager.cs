using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    //public int proteinValue;
    public static ScoreManager instance;
    public TMP_Text text;
    int score;

    void Start()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void ChangeScore(int value)
    {
        score += value;
        text.text = "X" + score.ToString();
        Debug.Log(score);
    }

}