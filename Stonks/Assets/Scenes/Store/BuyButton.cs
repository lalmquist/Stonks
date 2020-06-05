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

    public float price;
    string priceToString;

    Image button;

    [SerializeField] public HandleBuys handleBuy;

    [SerializeField] public TextMeshProUGUI textMesh;
    [SerializeField] public bool buyBool;


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
            textMesh.text = "BUY";
            textMesh.color = new Color32(255, 255, 255, 255);
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
            button.color = new Color32(255, 255, 255, 255);
            textMesh.text = "OWNED";
            textMesh.color = new Color32(50, 50, 50, 255);
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
}
