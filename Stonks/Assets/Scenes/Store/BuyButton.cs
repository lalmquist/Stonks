using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    public FadingText fadeText;

    public decimal price;
    string priceToString;

    bool Done = false;

    Image button;

    [SerializeField] public HandleBuys handleBuy;

    [SerializeField] public TextMeshProUGUI buttonText;
    [SerializeField] public bool buyBool;

    [SerializeField] public TextMeshProUGUI buyText;


    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        button = this.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (buyBool == false)
        {
            buyText.color = new Color32(255, 255, 255, 255);

            buttonText.text = "BUY";
            buttonText.color = new Color32(255, 255, 255, 255);
            if (game_data.playerMoney > price)
            {
                button.color = new Color32(213, 213, 0, 255);
            }
            else
            {
                button.color = new Color32(213, 0, 0, 255);
            }
        }
        else if (buyBool == true)
        {
            buyText.color = new Color32(213, 213, 213, 126);

            button.color = new Color32(255, 255, 255, 255);
            buttonText.text = "OWNED";
            buttonText.color = new Color32(50, 50, 50, 255);
        }

        if (Done == false & price > 0)
        {
            setPriceText();
            Done = true;
        }
    }

    public void execute()
    {

        if (game_data.playerMoney > price && buyBool == false)
        {
            buyBool = true;

            handleBuy.UpdateStore(price);

            priceToString = price.ToString("n2");
            fadeText.FadeRed(priceToString);
        }
    }

    void setPriceText()
    {
        buyText.text += " $" + price;
    }
}
