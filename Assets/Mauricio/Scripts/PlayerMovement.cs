using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    float horizontal;
    public float Speed;
    public float JumpForce;
    private bool Grounded;

    public GameObject TimeItem;
    private TimeManager timeManager;
    private ScoreManager scoreManager;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        timeManager = FindObjectOfType<TimeManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        // Movimiento
        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {

        scoreManager.IncreaseScore();
        timeManager.IncreaseTime();

        /*if (collision.CompareTag("Untagged"))
        {
            scoreManager.IncreaseScore();
            timeManager.IncreaseTime();
        }
        else
        {
            scoreManager.ResetScore();
        }*/

        //Destroy(collision.gameObject);
    //}
}

