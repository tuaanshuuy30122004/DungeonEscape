using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject HasKeyPanel;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject YouwinPanel;

    private void Start()
    {
        HasKeyPanel.SetActive(false);
        YouwinPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(player.gameObject.GetComponent<Player>().HasKey)
            {
                YouwinPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                HasKeyPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HasKeyPanel.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }


}
