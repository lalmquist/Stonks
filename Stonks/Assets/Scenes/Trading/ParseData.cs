using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseData : MonoBehaviour
{ 
    GameObject gameData;
    GameData game_data;

    [SerializeField] public MaxBuyPossible stock1;
    [SerializeField] public MaxBuyPossible stock2;
    [SerializeField] public MaxBuyPossible stock3;
    [SerializeField] public MaxBuyPossible stock4;


    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        stock1.price = game_data.Stock1.price;
        stock2.price = game_data.Stock2.price;
        stock3.price = game_data.Stock3.price;
        stock4.price = game_data.Stock4.price;
    }
}
