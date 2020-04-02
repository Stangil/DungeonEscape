using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                UIManager.UIinstance.OpenShop(player.diamonds);
            }
            //Debug.Log("Activate shop");
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

        switch(item)
        {
            case 0://flame sword
                UIManager.UIinstance.UpdateShopSelection(55);
                break;
            case 1://Boots of flight
                UIManager.UIinstance.UpdateShopSelection(-56);
                break;
            case 2://Key to Castle
                UIManager.UIinstance.UpdateShopSelection(-164);
                break;
        }

    }
}
