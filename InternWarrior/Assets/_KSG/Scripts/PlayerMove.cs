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
            
            // 왼쪽으로 가면 스프라이트 뒤집기
            if (Input.GetButton("Horizontal"))
            {
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
            }

            // 움직이면 달리기 애니메이션 재생
            animator.SetBool("isRun", Input.GetAxisRaw("Horizontal") != 0);

            // 키를 띄우면 달리기 애니메이션 중지
            if(Input.GetButtonUp("Horizontal"))
                animator.SetBool("isRun", false);
        }

        //땅에 있는지 확인
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

        //점프 속도확인후 애니메이션 재생
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

        //스턴 딜레이
        if (manager.GetStun())
        {
            // 달리기 상태 해제
            animator.SetBool("isRun", false);

            timer += Time.deltaTime;
            if(timer > manager.GetStunTime())
            {
                timer = 0;
                manager.SetStun(false);
            }
        }

        // 박카스 투척
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            //무기 투척방향 설정
            if (spriteRenderer.flipX)
                manager.SetWeaponDir("left");
            else
                manager.SetWeaponDir("right");

            //박카스 수량 확인
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
            //점프카운트 초기화
            currntJump = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 점프하지 않았는데 땅에서 떨어질시에

        if (collision.gameObject.CompareTag("Ground") && !Input.GetKey(KeyCode.UpArrow))
        {
            //점프한걸로 치기
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
