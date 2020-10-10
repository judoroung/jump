using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    private float startDashTime;
    private int direction;

    public float StartDashTime { get => startDashTime; set => startDashTime = value; }

    void Start()
    {
        rb = GetComponent < Rigidbody2D>();
        dashTime = StartDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                direction = 1;
            }else if (Input.GetAxis("Horizontal") < 0)
            {
                direction = 2;
            }else if (Input.GetAxis("Vertical") > 0)
            {
                direction = 3;
            }else if (Input.GetAxis("Vertical") < 0)
            {
                direction = 4;
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = StartDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if(direction == 1 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }else if(direction == 2 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }else if (direction == 3 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4 && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }
}
