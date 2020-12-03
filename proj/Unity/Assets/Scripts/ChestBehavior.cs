using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    bool _isPlayerWithinZone = false;
    private Animator anim;
    public bool _isUnlocked;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = true;
        UnityEngine.Debug.Log("Entered chest zone");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerWithinZone = false;
            UnityEngine.Debug.Log("Exited chest zone");
    }

    void Update()
    {
        if (_isPlayerWithinZone)
        {
            if (_isUnlocked)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    FindObjectOfType<PituitaryBehavior>()._haveItems = true;
                    anim = gameObject.GetComponent<Animator>();
                    anim.Play("chest_open");
                    UnityEngine.Debug.Log("chest opened");
                }
            }
        }
    }
}
