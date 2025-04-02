using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public GameObject camera;
    public CameraFollow s2;
    public bool IsGrounded = false;
     private bool isFacingRight = true;
   [SerializeField] public int jump = 8;
private float timeSinceLanded = 0f;
public float correctionDelay = 1.5f; // Time before correcting rotation
public float correctionSpeed = 5f;   // Speed of correction
private bool isCorrectingRotation = false;
public Transform groundCheck;
public LayerMask groundLayer; 
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
      IsGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }   
        Flip(horizontal);
        if (IsGrounded) // If grounded
{
    timeSinceLanded += Time.deltaTime;

    if (timeSinceLanded >= correctionDelay && !isCorrectingRotation)
    {
        StartCoroutine(CorrectRotation());
    }
}
    }

    private void Flip(float horizontal)
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator CorrectRotation()
{
    isCorrectingRotation = true; // Prevent multiple corrections

    Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * correctionSpeed);
        yield return null;
    }

    transform.rotation = targetRotation; // Ensure final alignment
    isCorrectingRotation = false;
}
}