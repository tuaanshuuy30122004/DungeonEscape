using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health = 3;
    [SerializeField]
    protected int speed = 1;
    [SerializeField] 
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;
    [SerializeField]
    protected Animator animatorController;
    [SerializeField]
    protected Player player;
    [SerializeField]
    protected GameObject DiamondPrefab;

    protected bool isSwitch;
    protected bool isHit = false;
    protected bool inCombat = false;

    public virtual void Attacks()
    {

    }

    public virtual void Update() 
    {
        Movement();
    }

    public virtual void Movement()
    {
        if (transform.position == this.pointA.position)
        {
            isSwitch = true;

        }
        else if (transform.position == this.pointB.position)
        {
            isSwitch = false;

        }
        
        if(!isHit && !inCombat)
        {
            
            if (isSwitch)
            {
                transform.position = Vector3.MoveTowards(transform.position, this.pointB.position, speed * Time.deltaTime);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            else if (!isSwitch)
            {
                transform.position = Vector3.MoveTowards(transform.position, this.pointA.position, speed * Time.deltaTime);
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance > 1.5f)
        {
            isHit = false;
            inCombat = false;
            animatorController.SetBool("inCombat", false);
        }
        else
        {
            inCombat = true;
            animatorController.SetBool("inCombat", true);
        }

        if(inCombat)
        {
            if(transform.position.x < player.transform.position.x)
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if(transform.position.x > player.transform.position.x)
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
        }
    }

}
