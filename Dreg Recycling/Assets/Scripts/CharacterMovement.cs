using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Sprite Player;
    public Sprite Player2;
    public Sprite Player3;

    public float moveSpeed = 5f;
    private int Skin = 0;
    public float speed;

    public Transform camera;

    public Rigidbody2D rb;

    private bool facingRight = true;
    private float moveInput;

    public bool CameraFollow = false;
    public bool LookTowardsMouse = false;
    public bool FlipOnMovement = false;
    public bool Skins = false;

    Vector2 movement;

    private void Start()
    {
        if (Skins == true)
        {
            Skin = PlayerPrefs.GetInt("Skin");
        }
    }

    void Update()
    {
        if (Skins == true)
        {
            SetSprite();
        }

        if (LookTowardsMouse == true)
        {
            faceMouse();
        }

        if (CameraFollow == true)
        {
            StartCoroutine(CameraFollowing());
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveInput = Input.GetAxisRaw("Horizontal");

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

    void SetSprite()
    {
        if (Skin == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = Player;
        }

        if (Skin == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = Player2;
        }

        if (Skin == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = Player3;
        }
    }

    IEnumerator CameraFollowing()
    {
        yield return new WaitForSeconds(speed);
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.position.z);
        StartCoroutine(CameraFollowing());
    }
}
