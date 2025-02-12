using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public float jumpScale = 1.0f;
    public GameObject weapon;

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

        //�÷��̾� �¿������
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
            //�����ϱ�
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (animator.GetBool("isJump"))
                    playerRigid.velocity = Vector2.zero;

                playerRigid.AddForce(Vector2.up * jumpScale, ForceMode2D.Impulse);
            }
            
            // �������� ���� ��������Ʈ ������
            if (Input.GetButton("Horizontal"))
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            }

            // �����̸� �޸��� �ִϸ��̼� ���
            animator.SetBool("isRun", Input.GetAxisRaw("Horizontal") != 0);

            // Ű�� ���� �޸��� �ִϸ��̼� ����
            if(Input.GetButtonUp("Horizontal"))
                animator.SetBool("isRun", false);
        }

        //���� �ӵ�Ȯ���� �ִϸ��̼� ���
        if (playerRigid.velocity.y > 0.5f)
        {
            animator.SetBool("isJumpUp", true);
            animator.SetBool("isJumpDown", false);
        }
        else if (playerRigid.velocity.y < -0.5f)
        {
            animator.SetBool("isJumpUp", false);
            animator.SetBool("isJumpDown", true);
        }  
        else
        {
            animator.SetBool("isJumpUp", false);
            animator.SetBool("isJumpDown", false);
        }
        

        //���� �ִ��� Ȯ��
        Debug.DrawRay(playerRigid.position, Vector2.down, Color.cyan);

        RaycastHit2D rayHit = Physics2D.Raycast(playerRigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider != null)
            if (rayHit.distance > 0.5f)
            {
                animator.SetBool("isJump", true);
                //Debug.Log(rayHit.collider.gameObject.name);
            }

        //���� ������
        if (manager.GetStun())
        {
            // �޸��� ���� ����
            animator.SetBool("isRun", false);

            timer += Time.deltaTime;
            if(timer > manager.GetStunTime())
            {
                timer = 0;
                manager.SetStun(false);
            }
        }

        // ��ī�� ��ô
        if(Input.GetKeyDown(KeyCode.A))
        {
            GameObject bullet = Instantiate(weapon, player.transform);
            bullet.transform.parent = null;
        }
    }
}
