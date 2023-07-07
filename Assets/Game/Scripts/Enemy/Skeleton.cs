using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }
    private void Start()
    {
        Health = base.health;
    }
    public void Damage()
    {
        Health--;
        isHit = true;
        if(Health < 1)
        {
            this.animatorController.SetTrigger("Dead");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(DiamondPrefab, this.transform.position + new Vector3(0,-0.5f,0),Quaternion.identity);
            Destroy(this.gameObject,1f);
        }
        animatorController.SetTrigger("Hit");
    }
}
