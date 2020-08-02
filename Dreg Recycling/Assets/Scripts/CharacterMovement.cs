using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform camera;

    public Rigidbody2D rb;

    private bool facingRight = true;
    private float moveInput;

    public bool CameraFollow = false;
    public bool LookTowardsMouse = false;
    public bool FlipOnMovement = false;

    Vector2 movement;

    void Update()
    {
        moveSpeed = GetComponent<PlayerManager>().moveSpeed;

        if (LookTowardsMouse == true)
        {
            faceMouse();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveInput = Input.GetAxisRaw("Horizontal");

        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.position.z);

        if (FlipOnMovement == true)
        {
            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        transform.up = direction;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
