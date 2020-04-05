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
}
