using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TradingButton : MonoBehaviour
{
    [SerializeField] public LevelLoader levelLoader;

    public void LoadTradingScene()
    {
        levelLoader.LoadNextLevel("Trading");
    }
}
