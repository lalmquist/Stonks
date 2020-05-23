using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{

    GameObject gameData;
    GameData game_data;

    TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
        textMesh.color = new Color32(0, 255, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        //textMesh.text = "$" + game_data.playerMoney.ToString("#.00");
        textMesh.text = "$" + game_data.playerMoney.ToString("n2");

    }

}
