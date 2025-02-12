using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float maxSpeed = 1.0f;
    public float jumpScale = 1.0f;

    private GameObject player;
    Rigidbody2D playerRigid;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        playerRigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (playerRigid.velocity.x > maxSpeed)
        {
            playerRigid.velocity = new Vector2(maxSpeed, playerRigid.velocity.y);
        }
        else if (playerRigid.velocity.x < -maxSpeed)
        {
            playerRigid.velocity = new Vector2(-maxSpeed, playerRigid.velocity.y);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRigid.AddForce(Vector2.up * jumpScale, ForceMode2D.Impulse);
            Debug.Log("Jump!");
        }

        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
    }
}
