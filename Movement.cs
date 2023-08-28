using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D player;
    public float jumpForce;
    public bool isGrounded = false;
    
    public GameObject Crouching;
    private bool isCrouch;

    private void Awake() {
        player = GetComponent<Rigidbody2D>();
        Crouching.SetActive(false);
    }

    void Crouch()
    {
        if(!isCrouch) {
            Crouching.SetActive(true);
            isCrouch = true;
        }
    }
    void UnCrouch()
    {
        Crouching.SetActive(false);
        if(isCrouch) {
            isCrouch = false;
        }
    }
    void Update()
    {
        if(isGrounded) 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                player.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                Crouch();
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                UnCrouch();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
                isGrounded = true;
                Debug.Log("You are on the ground.");
        }
    }
}
