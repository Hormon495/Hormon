using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene("Main");   
        }
    }

    void OnTriggerEnter2D(Collider2D trig) {
        CountScore();
    }
    void CountScore()
    {
        playerScore = playerScore + (int)(timeLeft * 10);
        Debug.Log(playerScore);
    }
}
