using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehavior : MonoBehaviour
{

    // Start is called before the first frame update
    bool _isPlayerWithinZone = false;
    public bool _hasACTH = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered Machine zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
        UnityEngine.Debug.Log("Exited Machine zone");
    }


    void Update()
    {
        if (_isPlayerWithinZone && !_hasACTH)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                UnityEngine.Debug.Log("Machine speaking");
                _hasACTH = true;
                gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                UnityEngine.Debug.Log("Machine speaking");
            }
        }
    }
}
