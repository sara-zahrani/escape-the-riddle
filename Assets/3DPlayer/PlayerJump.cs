using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public int jumpForce;
    private bool canJump;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            Jump();
        }

        bool grounded = Physics.Linecast(new Vector3(transform.position.x, transform.position.y, transform.position.z), groundCheck.position, groundLayer);
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z), groundCheck.position, Color.red);

        if (grounded == true)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void Jump()
    {
        canJump = false;
        rb.AddForce(Vector3.up * jumpForce);
    }
}