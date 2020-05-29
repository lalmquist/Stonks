using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyQuantity : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    public FadingText fadeText;

    float price;
    string priceToString;

    Image button;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        price = -1000f;
        button = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game_data.store.quantityButton == false)
        {
            button.color = new Color32(255, 255, 255, 255);
        }
    }

    public void execute()
    {
        game_data.store.quantityButton = true;

        if (game_data.playerMoney > -price)
        {
            game_data.playerMoney = game_data.playerMoney + price;

            button.color = new Color32(0, 0, 0, 0);

            priceToString = price.ToString("n2");
            fadeText.FadeRed(priceToString);
        }
    }
}
