using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreButton : MonoBehaviour
{
    [SerializeField] public LevelLoader levelLoader;

    public void LoadStoreButton()
    {
        levelLoader.LoadNextLevel("Store");
    }
}
