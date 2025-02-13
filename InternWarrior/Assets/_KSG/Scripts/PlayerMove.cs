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
    int currntJump = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigid = player.GetComponent<Rigidbody2D>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        animator = player.GetComponent<Animator>();
        manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        manager.SetPlayerSpeed(maxSpeed);
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
                if(manager.maxJump <= 0)
                {
                    Jump();
                }
                else
                {
                    if(currntJump < manager.maxJump)
                    {
                        currntJump++;
                        Jump();
                    }
                }
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

        //���� �ִ��� Ȯ��
        Debug.DrawRay(playerRigid.position, Vector2.down, Color.cyan);

        RaycastHit2D rayHit = Physics2D.Raycast(playerRigid.position, Vector3.down, 20, LayerMask.GetMask("Platform"));

        if (rayHit.collider != null)
            if (rayHit.distance > 1.1f)
            {
                animator.SetBool("isJump", true);
                //Debug.Log(rayHit.collider.gameObject.name);
            }
            else if(rayHit.distance < 1.1f && rayHit.collider.CompareTag("Ground"))
            {
                animator.SetBool("isJump", false);
            }

        //���� �ӵ�Ȯ���� �ִϸ��̼� ���
        if (playerRigid.velocity.y > 1f && animator.GetBool("isJump"))
        {
            animator.SetBool("isJumpUp", true);
            animator.SetBool("isJumpDown", false);
        }
        else if (playerRigid.velocity.y < -1f && animator.GetBool("isJump"))
        {
            animator.SetBool("isJumpUp", false);
            animator.SetBool("isJumpDown", true);
        }
        else
        {
            animator.SetBool("isJumpUp", false);
            animator.SetBool("isJumpDown", false);
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
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            //���� ��ô���� ����
            if (spriteRenderer.flipX)
                manager.SetWeaponDir("left");
            else
                manager.SetWeaponDir("right");

            //��ī�� ���� Ȯ��
            if (manager.weaponCount > 0)
            {
                manager.weaponCount--;

                GameObject bullet = Instantiate(weapon, player.transform);
                bullet.transform.parent = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //����ī��Ʈ �ʱ�ȭ
            currntJump = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �������� �ʾҴµ� ������ �������ÿ�

        if (collision.gameObject.CompareTag("Ground") && !Input.GetKey(KeyCode.UpArrow))
        {
            //�����Ѱɷ� ġ��
            currntJump++;
        }
    }

    private void Jump()
    {
        if (animator.GetBool("isJump"))
            playerRigid.velocity = Vector2.zero;

        playerRigid.AddForce(Vector2.up * jumpScale, ForceMode2D.Impulse);
    }
}
