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
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        //플레이어 좌우움직임
        if (!manager.GetStun())
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
        if(!manager.GetStun())
        {
            //점프하기
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (animator.GetBool("isJump"))
                    playerRigid.velocity = Vector2.zero;
                else
                    animator.SetBool("isJump", true);

                playerRigid.AddForce(Vector2.up * jumpScale, ForceMode2D.Impulse);
            }
        }
        

        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        animator.SetBool("isRun", Input.GetAxisRaw("Horizontal") != 0);

        //땅에 있는지 확인
        Debug.DrawRay(playerRigid.position, Vector2.down, Color.cyan);

        RaycastHit2D rayHit = Physics2D.Raycast(playerRigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider != null)
            if (rayHit.distance < 0.5f && animator.GetBool("isJump"))
            {
                animator.SetBool("isJump", false);
                Debug.Log(rayHit.collider.gameObject.name);
            }

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
