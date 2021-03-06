﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject player;
    private int currentItemSelected;
    private int costOfItem = 0;
    private string itemName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                UIManager.UIinstance.OpenShop(player.diamonds);
            }
            Debug.Log("Activate shop");
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        
        Debug.Log("Button clicked " + item);
        switch (item)
        {
            case 0://flame sword
                UIManager.UIinstance.UpdateShopSelection(55);
                costOfItem = 200;
                itemName = "Flame Sword";
                currentItemSelected = 0;
                break;
            case 1://Boots of flight
                UIManager.UIinstance.UpdateShopSelection(-56);
                costOfItem = 500;
                itemName = "Boots of Flight";
                currentItemSelected = 1;
                break;
            case 2://Key to Castle
                UIManager.UIinstance.UpdateShopSelection(-164);
                costOfItem = 100;
                itemName = "Key to Castle";
                currentItemSelected = 2;
                break;
        }

    }
    public void BuyItemMethod()
    {
       // int playerGems = player.GetComponent<Player>().diamonds;
        
        if (player != null)
        {
            if(player.GetComponent<Player>().diamonds >= costOfItem)
            {
                //TODO switch set up later for multiple items
                if(currentItemSelected == 2)//checking to  see if item is key
                {
                    GameManager.Instance.HasKeyToCastle = true;
                }
                Debug.Log("Player purchased: " + itemName);
                player.GetComponent<Player>().diamonds -= costOfItem;
            }
        }
        shopPanel.SetActive(false);
    }

}
