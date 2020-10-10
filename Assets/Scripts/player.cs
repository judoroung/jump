using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask ground;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }
    void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true){
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { isJumping = false; }
        }
        if (Input.GetKeyUp(KeyCode.Space)) isJumping = false;
    }
}
