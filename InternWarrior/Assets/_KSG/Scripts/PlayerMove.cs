using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float maxSpeed = 1.0f;
    public float jumpScale = 1.0f;

    GameObject player;
    Rigidbody2D playerRigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    PlayerManager manager;
    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (manager.GetStun())
        {
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

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRigid.AddForce(Vector2.up * jumpScale, ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
            Debug.Log("Jump!");
        }

        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        animator.SetBool("isRun", Input.GetAxisRaw("Horizontal") != 0);

        //땅에 있는지 확인
        Debug.DrawRay(playerRigid.position, Vector2.down, Color.cyan);

        RaycastHit2D rayHit = Physics2D.Raycast(playerRigid.position, Vector2.down, 1);

        if (rayHit.collider != null)
            if (rayHit.distance < 0.5f && animator.GetBool("isJump"))
                animator.SetBool("isJump", false);

        //스턴 딜레이
        if (manager.GetStun())
        {
            timer += Time.deltaTime;
            if(timer > manager.GetStunTime())
            {
                timer = 0;
                manager.SetStun(false);
            }
        }

    }
}
