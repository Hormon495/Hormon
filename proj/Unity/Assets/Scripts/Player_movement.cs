using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_movement : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;
    public int playerJumpPower = 1300;
    private float moveX;
    public bool isGrounded;
    public Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove (); 
    }
    void PlayerMove() {
        //Controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            Jump();
        }
        //Animations
        //Player Direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true) {
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump() {
        //Jump Code  
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }
    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Player has collided with " + col.collider.name);
        if (col.gameObject.tag == "Ground") {
            isGrounded = true;
        }

    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log("trigger");
        if (trig.gameObject.tag == "HoleSceneChange")
        {
            Scene scene = SceneManager.GetActiveScene();
            if(scene.name == "Main")
            {
                SceneManager.LoadScene("Spinal Cord");
            }
            else if(scene.name == "Spinal Cord")
            {
                SceneManager.LoadScene("AdrenalGlands");
            }
        }
        else if(trig.gameObject.tag == "Boundary")
        {
            transform.position = respawnPoint;
        }
        else if(trig.gameObject.tag == "AdrenalTeleport")
        {
            transform.position = new Vector3(12, 1, 0);
        }
    }

}
