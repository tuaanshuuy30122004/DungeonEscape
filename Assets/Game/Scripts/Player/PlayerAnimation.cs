using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator spriteAnim; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetRunAnimation()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            move = 0;
        }
        spriteAnim.SetFloat("Move",Mathf.Abs(move));
    }

    public void SetJumpAnimation()
    {
        spriteAnim.SetBool("isJump", true);
    }

    public void EndJumpAnimation()
    {
        spriteAnim.SetBool("isJump", false);
    }

    public void AttackAnimation()
    {
        spriteAnim.SetTrigger("Attacking");
    }

    public void JumpSwingAnimation() 
    {
        spriteAnim.SetTrigger("AttackJump");
        spriteAnim.ResetTrigger("Attacking");
    }
    public void DeadAnimation()
    {
        spriteAnim.SetTrigger("Dead");
    }

    
}
