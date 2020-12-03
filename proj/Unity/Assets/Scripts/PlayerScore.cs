using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using TMPro;
using System;

public class PlayerScore : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    public int playerScore;
    public float time;


    void Start() {
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update () {
        time += Time.deltaTime;
        //score = playerScore.ToString();
        //scoreText.text = score;
        //scoreText.text = time.ToString("f0");
        scoreText.text = playerScore.ToString();
    }
/*
    public void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Player has collided with " + col.name);
        if (col.gameObject.CompareTag("Proteins"))
        {
            Debug.Log("Protein consumed");
            Destroy (col.gameObject);
            playerScore += 20;
            Debug.Log(playerScore);
            //score = playerScore.ToString();
            //scoreText.text = score;
            //scoreText.text = playerScore.ToString();
        }
    } 
/*
    private void writePlayerScore(string playerName, string email, string score) {
        PlayerScore pScore = new PlayerScore(playerName, score);
        string json = JsonUtility.ToJson(playerName);
        string jsonScore = JsonUtility.ToJson(score);

        //mDatabaseRef.Child("users").Child(playerName).SetRawJsonValueAsync(json);
        //mDatabaseRef.Child("users").Child(playerName).Child("score").SetRawJsonValueAsync(json);
    }
*/

}
