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
        Debug.Log("Player has coliided with " + col.collider.name);
        if (col.gameObject.tag == "Ground") {
            isGrounded = true;
        }

    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "HoleSceneChange")
        {
            SceneManager.LoadScene("Spinal Cord");
        }
    }

}
