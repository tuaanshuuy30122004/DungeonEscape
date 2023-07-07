using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private int jumpCount = 0;
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private PlayerAnimation AnimatorController;
    public int currentGems = 0;
    public bool HasKey = false;

    [SerializeField]
    private GameObject gameOverPanel;

    public int Health { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Health = 10;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal > 0)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            
        }
        else if(horizontal < 0)
        {
            this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            
        }
        AnimatorController.SetRunAnimation();
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }

    void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3 (0, -0.63f, 0), Vector2.down , 200f, 1<<8);
        if(hit.collider != null )
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpCount<2)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x,jumpForce);
            AnimatorController.SetJumpAnimation();
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
            AnimatorController.EndJumpAnimation();
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && isGrounded)
        {
            AnimatorController.AttackAnimation();
        }

        if(Input.GetMouseButtonUp(0) && jumpCount>0)
        {
            AnimatorController.JumpSwingAnimation();
        }
    }

    public void Damage()
    {
        //Health--;
        if(Health < 1)
        {
            AnimatorController.DeadAnimation();
            StartCoroutine(TimePause());                        
        }
    }

    IEnumerator TimePause()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            this.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
            
        }
    }

    public void AddGems(int gems)
    {
        currentGems += gems;
    }

}
