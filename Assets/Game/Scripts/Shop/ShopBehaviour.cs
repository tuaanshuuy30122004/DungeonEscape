using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{
    public GameObject shopPanel;
    void Start()
    {
        shopPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }
}
