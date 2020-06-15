using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasStartedVisible : MonoBehaviour
{
    GameObject gameData;
    GameData game_data;

    public CanvasGroup canvasGroup;

    public bool invert;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData");
        game_data = gameData.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((game_data.store.hasStarted && invert == false) || (invert && game_data.store.hasStarted == false))
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
        }
    }
}
