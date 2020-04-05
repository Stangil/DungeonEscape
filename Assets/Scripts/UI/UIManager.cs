using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager UIinstance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is null");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImage;
    public Text uiGemCount;
    public Image[] healthBars;
    private void Awake()
    {
        _instance = this;
    }
    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G"; 
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
    public void UpdateGemCount(int count)
    {
        uiGemCount.text = ""+count;
    }
    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            //do nothing till hit the max
            if(i == livesRemaining)
            {
                //hide i
                healthBars[i].enabled = false;
            }
        }
    }
}
