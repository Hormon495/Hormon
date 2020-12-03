using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehavior : MonoBehaviour
{
    bool _isPlayerWithinZone = false;
    public bool _isSwitchFlipped = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered teleport zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        UnityEngine.Debug.Log("Exited teleport zone");
    }


    void Update()
    {
        if (_isPlayerWithinZone)
        {
            if (_isSwitchFlipped == false)
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                UnityEngine.Debug.Log("teleport speaking");
            }
        }
    }
}
