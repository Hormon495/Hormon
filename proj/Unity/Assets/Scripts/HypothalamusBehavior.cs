using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypothalamusBehavior : MonoBehaviour
{
    bool _isPlayerWithinZone = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered hypothalamus zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        UnityEngine.Debug.Log("Exited hypothalamus zone");
    }


    void Update()
    {
        if (_isPlayerWithinZone)
        {
            UnityEngine.Debug.Log("hypothalamus speaking");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                FindObjectOfType<ChestBehavior>()._isUnlocked = true;
                FindObjectOfType<ChestBehavior>().GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Pretty sure this is what I need.";
                FindObjectOfType<PituitaryBehavior>()._talkedToHypothalamus = true;
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                gameObject.GetComponent<DialogueTrigger>().dialogue.sentences = new string[0];
                UnityEngine.Debug.Log("hypothalamus speaking");
            }
        }
    }
}
