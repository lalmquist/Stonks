using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyPrinterButton : MonoBehaviour
{
    [SerializeField] public LevelLoader levelLoader;

    public void LoadMoneyPrinterButton()
    {
        levelLoader.LoadNextLevel("MoneyPrinter");
    }
}
