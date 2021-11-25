using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;
    private bool isJumping = true;
    private Rigidbody2D playerRB2D;

    // Start is called before the first frame update
    void Awake()
    {
        playerRB2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputListener();
    }

    void InputListener()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("'A' key was pressed.");
            PlayerMoverHorizontal(speedX, false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            print("'D' key was pressed.");
            PlayerMoverHorizontal(speedX, true);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            print("'W' key was pressed.");
            PlayerMoverVertical(speedY);

        }
    }

    void PlayerMoverHorizontal(float velX, bool isRight)
    {
        if (isRight == true)
        {
            playerRB2D.AddForce(Vector2.right * velX);
        }
        else
        {
            playerRB2D.AddForce(Vector2.left * velX);
        }
    }

    void PlayerMoverVertical(float velY)
    {
        if (isJumping == false)
        {
            playerRB2D.AddForce(Vector2.up * velY);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }
}
