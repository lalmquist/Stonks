using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TradingButton : MonoBehaviour
{
    public void LoadTradingScene()
    {
        SceneManager.LoadScene("Trading");
    }
}
