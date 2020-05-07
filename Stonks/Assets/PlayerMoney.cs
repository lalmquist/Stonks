using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{

    GameObject gameData;
    GameData game_data;

    [SerializeField] TextMeshProUGUI self;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        self.color = new Color32(0, 255, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        self.text = "$" + game_data.playerMoney.ToString("#.00");
    }
}
