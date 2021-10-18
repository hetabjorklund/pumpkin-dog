using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogCode : MonoBehaviour
{
    private float speed = 7f;    
    private int direction = 1; // 1 is right, -1 is left
    private float jumpPower = 270f;
    public bool canJump; // the dog can't jump if it's already in the air

    // player states: 0 = standing, 1 = walking, 2 = jumping

    void Start()
    {
        
    }

    void Update()
    {
        // press right arrow
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (this.direction == -1) { // if the dog is going left
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f); // turn the dog around
                this.direction = 1; // change the direction to right
            }            
            this.GetComponent<Animator>().SetInteger("player_state", 1); // set player state as 1, walking
        }       

        // right arrow no longer pressed
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            this.GetComponent<Animator>().SetInteger("player_state", 0); // set player state as 0, standing
        }

        // press left arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (this.direction == 1) { // if the dog is going right
                this.GetComponent<Transform>().Rotate(0f, 180f, 0f); // turn the dog around
                this.direction = -1; // change the direction to left
            }
            this.GetComponent<Animator>().SetInteger("player_state", 1); // set player state as 1, walking
        }

        // left arrow no longer pressed
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            this.GetComponent<Animator>().SetInteger("player_state", 0); // set player state as 0, standing
        }

        // right or left arrow kept down, the dog is moving
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            this.GetComponent<Transform>().Translate(this.speed * Time.deltaTime, 0f, 0f);
        } 

        // press space bar
        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            if (this.GetComponent<Animator>().GetInteger("player_state") == 0 || this.GetComponent<Animator>().GetInteger("player_state") == 1) { // if the dog is standing or walking (can't jump if it's already jumping)
                this.GetComponent<Animator>().SetInteger("player_state", 2); // set player state as 2, jumping
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1f) * jumpPower);
                canJump = false; 
            }            
        }

        // space bar no longer pressed
        if (Input.GetKeyUp(KeyCode.Space)) {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) { // if the arrow key is kept down
                this.GetComponent<Animator>().SetInteger("player_state", 1); // set player state as 1, walking
            }
            else {
                this.GetComponent<Animator>().SetInteger("player_state", 0); // set player state as 0, standing
            }            
        }                       
    }

    // if the dog is touching the ground or a platform, it can jump
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {     
            canJump = true;
        }
    }
   
}
