using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    bool _isPlayerWithinZone = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered switch zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        UnityEngine.Debug.Log("Exited switch zone");
    }


    void Update()
    {
        if (_isPlayerWithinZone && !FindObjectOfType<TeleportBehavior>()._isSwitchFlipped)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                FindObjectOfType<TeleportBehavior>().tag = "AdrenalTeleport";
                FindObjectOfType<TeleportBehavior>()._isSwitchFlipped = true;
                UnityEngine.Debug.Log("switch speaking");
            }
            
        }
        else if(_isPlayerWithinZone && FindObjectOfType<MachineBehavior>()._hasACTH)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                FindObjectOfType<ExitBehavior>().tag = "HoleSceneChange";
                FindObjectOfType<ExitBehavior>()._areTasksCompleted = true;
                UnityEngine.Debug.Log("switch speaking");
                GameObject buttonOff = GameObject.Find("Button_Off");
                GameObject buttonOn  = GameObject.Find("Button_On");
                buttonOff.GetComponent<SpriteRenderer>().sortingOrder = 0;
                buttonOn.GetComponent<SpriteRenderer>().sortingOrder = 1;


            }

        }
    }
}
