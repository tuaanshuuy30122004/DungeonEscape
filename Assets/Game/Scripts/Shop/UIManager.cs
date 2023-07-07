using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text currentGems;

    [SerializeField]
    private Image Health;

    // Update is called once per frame
    void Update()
    {
        currentGems.text = " Gems : " + player.gameObject.GetComponent<Player>().currentGems.ToString();
       
    }

    public void BuyFullHealth()
    {
        if (player.gameObject.GetComponent<Player>().currentGems >= 50)
        {
            player.gameObject.GetComponent<Player>().Health = 20;
            player.gameObject.GetComponent<Player>().currentGems -= 50;
        }
        else return;
        
    }

    public void BuyKey()
    {
        if (player.gameObject.GetComponent<Player>().currentGems >= 100)
        {
            player.gameObject.GetComponent<Player>().currentGems -= 100;
            player.gameObject.GetComponent<Player>().HasKey = true;
        }
        else return;
    }
}
