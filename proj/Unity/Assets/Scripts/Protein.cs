using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protein : MonoBehaviour
{
<<<<<<< Updated upstream
    public int proteinValue = 10;
=======
    public int proteinValue = 1;
>>>>>>> Stashed changes

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(proteinValue);
            Debug.Log("Protein consumed");
            Destroy (this.gameObject);
<<<<<<< Updated upstream
            //playerScore += 20;
            //Debug.Log(playerScore);
=======
>>>>>>> Stashed changes
        }
    }
}