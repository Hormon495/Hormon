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
<<<<<<< Updated upstream
        text.text = score.ToString();
=======
        text.text = "X" + score.ToString();
>>>>>>> Stashed changes
        Debug.Log(score);
    }

}