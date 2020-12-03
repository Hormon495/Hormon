using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protein : MonoBehaviour
{
    public int proteinValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(proteinValue);
            Debug.Log("Protein consumed");
            Destroy (this.gameObject);
            //playerScore += 20;
            //Debug.Log(playerScore);
        }
    }
}