using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PituitaryBehavior : MonoBehaviour
{
    bool _isPlayerWithinZone = false;
    public bool _talkedToHypothalamus = false;
    public bool _haveItems = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered pituitary zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        UnityEngine.Debug.Log("Exited pituitary zone");
    }


    void Update()
    {
        if (_isPlayerWithinZone && _talkedToHypothalamus && _haveItems)
        {
            UnityEngine.Debug.Log("pituitary speaking");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                FindObjectOfType<Mailbox>()._talkedToPituitary = true;
                UnityEngine.Debug.Log("pituitary speaking");
            }
        }
    }
}
