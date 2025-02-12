using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public GameObject camera;
    public CameraFollow s2;
    public bool IsUnGrounded;
    public float jump;
    [SerializeField] private LayerMask jumpableGround;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        s2 = GameObject.Find("Main Camera").GetComponent<CameraFollow>();

        // Check if the script reference is valid
        if (s2 != null)
        {
            Debug.Log("CameraFollow script found!");
        }
        else
        {
            Debug.LogError("CameraFollow script not found!");
        }
       
    }
    
    // Update is called once per frame
    private void Update()

    { 
      
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !IsUnGrounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }   
    }
    private void OnCollisionEnter2D(Collision2D other){
if (other.gameObject.CompareTag("Ground")){
    IsUnGrounded = false;
}
    }
    private void OnCollisionStay2D(Collision2D other){
        
if (other.gameObject.CompareTag("Ground")){
    IsUnGrounded = false;
}
    }
    private void OnCollisionExit2D(Collision2D other){

if (other.gameObject.CompareTag("Ground")){
    IsUnGrounded = true;
}
    }
}