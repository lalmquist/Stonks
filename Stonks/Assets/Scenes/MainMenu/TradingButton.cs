using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TradingButton : MonoBehaviour
{
    [SerializeField] public LevelLoader levelLoader;

    GameObject gameData;
    GameData game_data;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    public void LoadTradingScene()
    {
        if (game_data.store.hasStarted)
        {
            levelLoader.LoadNextLevel("Trading");
        }
        else
        {
            levelLoader.LoadNextLevel("CreateStock");
        }

        
    }
}
