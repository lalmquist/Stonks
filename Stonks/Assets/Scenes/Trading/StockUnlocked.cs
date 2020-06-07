using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockUnlocked : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;
    
    public CanvasGroup canvasGroup;
    public Number stockNumber;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stockNumber.StockNumber == 1)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
        }

        if (stockNumber.StockNumber == 2)
        {
            if (game_data.store.unlockStock2 == true)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
            }
            else
            {
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
            }
        }


        if (stockNumber.StockNumber == 3)
        {
            if (game_data.store.unlockStock3 == true)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
            }
            else
            {
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
            }
        }

        if (stockNumber.StockNumber == 4)
        {
            if (game_data.store.unlockStock4 == true)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
            }
            else
            {
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
            }
        }
    }
}
