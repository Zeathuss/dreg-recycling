using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform camera;
    [SerializeField] private Rigidbody2D rb;

    private bool facingRight = true;
    private float moveInput;

    [SerializeField] private bool CameraFollow = false;
    [SerializeField] private bool LookTowardsMouse = false;
    [SerializeField] private bool FlipOnMovement = false;

    [SerializeField] private Animator anim;

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



        #region Animations
        if (movement.x > 0 && movement.y > 0)
        {
            anim.Play("PlayerUp");
        }else if (movement.x > 0 && movement.y < 0)
        {
            anim.Play("PlayerDown");
        }else if (movement.x < 0 && movement.y > 0)
        {
            anim.Play("PlayerUp");
        }else if (movement.x < 0 && movement.y < 0)
        {
            anim.Play("PlayerDown");
        }else if (movement.x > 0)
        {
            anim.Play("PlayerRight");
        }else if (movement.x < 0)
        {
            anim.Play("PlayerLeft");
        }else if (movement.y > 0)
        {
            anim.Play("PlayerUp");
        }else if (movement.y < 0)
        {
            anim.Play("PlayerDown");
        }else if(movement.x == 0 && movement.y == 0)
        {
            anim.Play("PlayerDown 0");
        }
        #endregion
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
