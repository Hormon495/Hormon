using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : MonoBehaviour
{
    // Start is called before the first frame update
    bool _isPlayerWithinZone = false;
    public bool _talkedToPituitary = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered mailbox zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        UnityEngine.Debug.Log("Exited mailbox zone");
    }


    void Update()
    {
        if (_isPlayerWithinZone && _talkedToPituitary)
        {
            UnityEngine.Debug.Log("exit speaking");
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            FindObjectOfType<ExitBehavior>().tag = "HoleSceneChange";
            FindObjectOfType<ExitBehavior>()._areTasksCompleted = true;
            UnityEngine.Debug.Log("exit speaking");
        }
    }
}
