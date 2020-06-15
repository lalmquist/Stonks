using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    [SerializeField] public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void execute()
    {
        if (game_data.store.hasStarted)
        {
            levelLoader.LoadNextLevel("Store");
        }
        else
        {
            levelLoader.LoadNextLevel("MainMenu");
        }
        
    }
}
