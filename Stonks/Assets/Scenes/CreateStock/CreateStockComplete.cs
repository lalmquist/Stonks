using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CreateStockComplete : MonoBehaviour
{
    [SerializeField] public LevelLoader levelLoader;
    GameObject gameData;
    GameData game_data;
    [SerializeField] public TextMeshProUGUI buttonText;
    [SerializeField] public Image button;

    [SerializeField] public StockInputBox stockInputBox;
    [SerializeField] public ValueInputBox valueInputBox;

    bool Enabled;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (valueInputBox.InputError | stockInputBox.InputError)
        {
            buttonText.color = new Color32(213, 213, 213, 126);
            button.color = new Color32(213, 213, 213, 126);
            Enabled = false;
        }
        else
        {
            buttonText.color = new Color32(255, 255, 255, 255);
            button.color = new Color32(255, 255, 255, 255);
            Enabled = true;
        }
    }

    public void execute()
    {
        if (Enabled)
        {
            game_data.playerMoney -= game_data.stockBuyPrice;
            Debug.Log(game_data.playerMoney);

            if (game_data.store.unlockStock2 == false)
            {
                game_data.Stock2.name = stockInputBox.outputValue;
                game_data.Stock2.price = valueInputBox.outputValue;

                game_data.store.unlockStock2 = true;
            }

            else if (game_data.store.unlockStock3 == false)
            {
                game_data.Stock3.name = stockInputBox.outputValue;
                game_data.Stock3.price = valueInputBox.outputValue;

                game_data.store.unlockStock3 = true;
            }

            else if (game_data.store.unlockStock4 == false)
            {
                game_data.Stock4.name = stockInputBox.outputValue;
                game_data.Stock4.price = valueInputBox.outputValue;

                game_data.store.unlockStock4 = true;
            }

            game_data.SaveJSON();
            LoadTradingScene();
        }
    }

    public void LoadTradingScene()
    {
        levelLoader.LoadNextLevel("Trading");
    }
}
