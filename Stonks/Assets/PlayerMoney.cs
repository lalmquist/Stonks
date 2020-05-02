using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] int playerMoney = 0;
    [SerializeField] TextMeshProUGUI moneyText;


    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = playerMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = playerMoney.ToString();
    }
}
