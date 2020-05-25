using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyQuantity : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    public FadingText fadeText;

    float price;
    string priceToString;


    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        price = -1000f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute()
    {
        game_data.store.quantityButton = true;
        game_data.playerMoney = game_data.playerMoney + price;

        priceToString = price.ToString("n2");
        fadeText.FadeRed(priceToString);
    }
}
