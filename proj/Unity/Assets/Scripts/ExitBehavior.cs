using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehavior : MonoBehaviour
{
    bool _isPlayerWithinZone = false;
    public bool _areTasksCompleted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered exit zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        UnityEngine.Debug.Log("Exited exit zone");
    }


    void Update()
    {
        if (_isPlayerWithinZone)
        {
            if (_areTasksCompleted == false)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                UnityEngine.Debug.Log("exit speaking");
            }
        }
    }
}
