using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movespeed value is defined here, but can be changed in Unity
    public float moveSpeed = 5f;

    // jump height need to be defined in Unity (change the 'Y' variable in player sprite)
    public Vector2 jumpHeight;

    // this variable is used to know if the player is in the ground, so he can't keep jumping in the air
    // to make this, the ground tilemap need to have a tag(here the tag is 'Ground')
    public bool isGrounded;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // moves horizontally when press A, D, or arrow keys left and right
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        Jump();
    }

    // Jumps when press W, spacebar or up arrow key
    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
             if (isGrounded == true) {
                GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            }
        }
    }

    // the next two functions are used to know if the player is in the ground
    // using Unity functions to know if there any collision between them
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }
}